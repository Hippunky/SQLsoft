Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Xml
Imports SQLsoftTools

Public Class MainForm
    Private ColumnZoomLevels() As Integer = {1, 2, 4, 6, 8, 16, 32}
    Private m_AllJobsList As New List(Of Job)

    Private Delegate Sub FilterCompleteDel(ByVal Sender As JobViewForm, ByVal ShownJobCount As Integer, ByVal TotalJobCount As Integer)

    Public Sub New()
        InitializeComponent()

        Utils.AppIcon = My.Resources.data_server
    End Sub

    Private ReadOnly Property SaveFolder() As String
        Get
            Dim Result As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SqlJobVis\"

            If Not IO.Directory.Exists(Result) Then
                IO.Directory.CreateDirectory(Result)
            End If

            Return Result
        End Get
    End Property

    Private ReadOnly Property SavePath() As String
        Get
            Return Me.SaveFolder & "Settings.xml"
        End Get
    End Property

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim Doc As New XmlDocument()
            Dim RootElem As XmlElement = Doc.CreateElement("SqlJobVis")
            Doc.AppendChild(RootElem)

            If Not Me.WindowState = FormWindowState.Minimized Then
                Dim WindowInfo As XmlElement = Doc.CreateElement("WindowInfo")
                RootElem.AppendChild(WindowInfo)
                Utils.SaveWindowPosition(Me, WindowInfo)
            End If

            Dim ConnectionInfosElem As XmlElement = Doc.CreateElement("ConnectionInfos")
            RootElem.AppendChild(ConnectionInfosElem)

            For Each CI As Object In ConnectionComboBox.Items
                If TypeOf CI Is ConnectionInfo Then
                    ConnectionInfosElem.AppendChild(CI.ToXml(Doc))
                End If
            Next

            If Options.m_StoreSession Then
                Dim SessionInfosElem As XmlElement = Doc.CreateElement("SessionInfos")
                RootElem.AppendChild(SessionInfosElem)

                For Each JVF As JobViewForm In Me.MdiChildren
                    Dim SessionInfoElem As XmlElement = Doc.CreateElement("SessionInfo")
                    SessionInfosElem.AppendChild(SessionInfoElem)

                    Utils.SaveWindowPosition(JVF, SessionInfoElem)

                    SessionInfoElem.SetAttribute("Connection", JVF.ConnectionInfo.m_Name)
                    SessionInfoElem.SetAttribute("Filter", JVF.FilterType)
                    SessionInfoElem.SetAttribute("SuppressedCategories", String.Join("||||", JVF.SuppressedJobCategories))
                    SessionInfoElem.SetAttribute("Sort", JVF.SortType)
                    SessionInfoElem.SetAttribute("RowZoomLevel", JVF.RowZoomLevel)
                    SessionInfoElem.SetAttribute("HourWidth", JVF.HourWidth)
                Next
            End If

            Doc.Save(Me.SavePath)

            Options.Save()

            For Each Frm As JobViewForm In Me.MdiChildren
                Frm.CancelUpdate(True)
            Next
        Catch ex As Exception
            MessageBox.Show("Could not save settings file: " & ex.Message, "Failed to Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RefreshButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshButton.Click
        If Not IsNothing(GetActiveJobViewForm()) Then
            GetActiveJobViewForm().DoRefresh()
        End If
    End Sub

    Private Function GetActiveJobViewForm() As JobViewForm
        If Not IsNothing(Me.ActiveMdiChild) Then
            Return Me.ActiveMdiChild
        End If

        Return Nothing
    End Function

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RowSizeComboBox.SelectedIndexChanged
        If Not IsNothing(Me.ActiveMdiChild) Then
            Dim JVF As JobViewForm = Me.ActiveMdiChild

            JVF.RowZoomLevel = (RowSizeComboBox.SelectedIndex + 1) * 2
        End If
    End Sub

    Private Sub ToolStripComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ColumnSizeComboBox.SelectedIndexChanged
        If Not IsNothing(Me.ActiveMdiChild) Then
            Dim JVF As JobViewForm = Me.ActiveMdiChild

            JVF.HourWidth = (CStr(ColumnSizeComboBox.SelectedItem).Replace("%", "") \ 2) * 4
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If Not IsNothing(GetActiveJobViewForm()) Then
            GetActiveJobViewForm.DoRefresh()
        End If
    End Sub

    Private Sub ConnectionComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ConnectionComboBox.SelectedIndexChanged
        If TypeOf ConnectionComboBox.SelectedItem Is ConnectionInfo Then
            Dim CI As ConnectionInfo = ConnectionComboBox.SelectedItem
            If Not CI.AuthenticateIfRequired(Me) Then
                Return
            End If

            Try
                Dim Conn As New SqlConnection(CI.GetConnectionString())
                Conn.Open()
            Catch ex As Exception
                MessageBox.Show("Unable to connect to the server: " & ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim JVF As New JobViewForm(CI)
            JVF.ForceZoomToFit = Options.m_ZoomToFitByDefault
            JVF.MdiParent = Me
            AddHandler JVF.FilterComplete, AddressOf MyFilterComplete

            JVF.Show()
        Else
            NewConnectionButton_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DoNewConnection()
        Dim CI As New ConnectionInfo()
        CI.m_Database = "msdb"

        If IO.File.Exists("C:\Temp\SQLjobvisDEBUGFILE.txt") Then
            CI.m_Database = "msdb_old"
        End If

        Dim CD As New ConnectionDlg(CI)
        CD.AllowDatabaseSelection = False

        If CD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If CI.AuthenticateIfRequired(Me) Then
                Try
                    Dim Conn As New SqlConnection(CI.GetConnectionString())
                    Conn.Open()
                Catch ex As Exception
                    MessageBox.Show("Unable to connect to the server: " & ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try

                Dim I As Integer = ConnectionComboBox.Items.Add(CI)
                ConnectionComboBox.SelectedIndex = I
            End If
        End If
    End Sub

    Private Sub NewConnectionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewConnectionButton.Click
        DoNewConnection()
    End Sub

    Private Sub SortComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SortComboBox.SelectedIndexChanged
        If Not IsNothing(GetActiveJobViewForm()) Then
            GetActiveJobViewForm().SortType = SortComboBox.SelectedIndex
        End If
    End Sub

    Private Function GetFilters(ByVal FT As FilterType, ByVal CategoriesFiltered As Boolean) As List(Of String)
        Dim Filters As New List(Of String)

        If FT = 0 Then
            If CategoriesFiltered Then
                Filters.Add("<Category>")
            Else
                Filters.Add("All")
            End If
        End If

        If (FT And FilterType.Failed) <> 0 Then
            Filters.Add("Failed")
        End If

        If (FT And FilterType.LongRunning) <> 0 Then
            Filters.Add("Long-running")
        End If

        If (FT And FilterType.Clashing) <> 0 Then
            Filters.Add("Clashing")
        End If

        If (FT And FilterType.Disabled) <> 0 Then
            Filters.Add("Enabled")
        End If

        If (FT And FilterType.Inactive) <> 0 Then
            Filters.Add("Active")
        End If

        Return Filters
    End Function

    Private Sub RefreshSettings()
        Dim JVF As JobViewForm = GetActiveJobViewForm()

        If Not IsNothing(JVF) Then
            RowSizeComboBox.SelectedIndex = JVF.RowZoomLevel / 2 - 1
            RowSizeComboBox.Enabled = True

            Dim PC As Integer = (JVF.HourWidth \ 4) * 2
            ColumnSizeComboBox.SelectedIndex = (PC \ 2) - 1

            ColumnSizeComboBox.Enabled = True

            Dim Filters As List(Of String) = GetFilters(JVF.FilterType, JVF.SuppressedJobCategories.Length > 0)
            Dim FilterString As String = "<Multiple>"

            If Filters.Count = 1 Then
                FilterString = Filters(0) & " jobs."
            End If

            Dim FilterTooltipInner As String = ""

            For Each FS As String In Filters
                If FilterTooltipInner <> "" Then
                    FilterTooltipInner &= vbCrLf
                End If

                FilterTooltipInner &= FS
            Next

            FilterButton.Text = "Fi&lter: " & FilterString
            FilterButton.ToolTipText = "Jobs that meet all of the following criteria are shown:" & vbCrLf & FilterTooltipInner

            If JVF.SuppressedJobCategories.Length > 0 Then
                FilterButton.ToolTipText &= vbCrLf & vbCrLf & "The following categories are suppressed:" & vbCrLf & String.Join(", ", JVF.SuppressedJobCategories)
            End If

            FilterButton.Enabled = True

            SortComboBox.SelectedIndex = JVF.SortType
            SortComboBox.Enabled = True

            ExportMenuItem.Enabled = True
            SetDateRangeMenuItem.Enabled = True
            RefreshToolStripMenuItem.Enabled = True

            RefreshButton.Enabled = True
            ZoomButton.Enabled = True
            ZoomToFitMenuItem.Enabled = True

            SetJobCounts(JVF.ShownJobCount, JVF.TotalJobCount)
        Else
            RowSizeComboBox.Enabled = False
            ColumnSizeComboBox.Enabled = False

            FilterButton.Enabled = False
            SortComboBox.Enabled = False

            ExportMenuItem.Enabled = False
            SetDateRangeMenuItem.Enabled = False
            RefreshToolStripMenuItem.Enabled = False

            RefreshButton.Enabled = False
            ZoomButton.Enabled = False
            ZoomToFitMenuItem.Enabled = False

            Sl_JobCount.Text = ""
        End If
    End Sub

    Private Sub MainForm_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        RefreshSettings()
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        Me.Icon = My.Resources.data_server

        Sl_JobCount.Text = ""

        ColumnSizeComboBox.Items.Clear()

        For PC As Integer = 2 To 400 Step 2
            ColumnSizeComboBox.Items.Add(PC & "%")
        Next

        SortComboBox.SelectedIndex = 0

        RowSizeComboBox.SelectedIndex = 3
        ColumnSizeComboBox.SelectedIndex = 0

        If IO.File.Exists(Me.SavePath) Then
            Dim Doc As New XmlDocument
            Doc.Load(Me.SavePath)

            Dim WindowInfoElem As XmlElement = Doc.SelectSingleNode("//SqlJobVis/WindowInfo")
            If Not IsNothing(WindowInfoElem) Then
                Utils.RestoreWindowPosition(Me, WindowInfoElem)
            End If

            Dim ConnectionInfosElem As XmlElement = Doc.SelectSingleNode("//SqlJobVis/ConnectionInfos")
            For Each CIElem As XmlElement In ConnectionInfosElem.ChildNodes
                Dim CI As New ConnectionInfo(CIElem)
                If CI.m_Database = "" Then
                    CI.m_Database = "msdb"
                End If

                If IO.File.Exists("C:\Temp\SQLjobvisDEBUGFILE.txt") Then
                    CI.m_Database = "msdb_old"
                End If

                ConnectionComboBox.Items.Add(CI)
            Next

            Dim SessionInfosElem As XmlElement = Doc.SelectSingleNode("//SqlJobVis/SessionInfos")
            If Not IsNothing(SessionInfosElem) Then
                For Each SessionInfoElem As XmlElement In SessionInfosElem.ChildNodes
                    For Each CI As ConnectionInfo In ConnectionComboBox.Items
                        If CI.m_Name = SessionInfoElem.GetAttribute("Connection") Then
                            If CI.AuthenticateIfRequired(Me) Then
                                Dim JVF As New JobViewForm(CI)
                                JVF.MdiParent = Me

                                AddHandler JVF.FilterComplete, AddressOf MyFilterComplete

                                If SessionInfoElem.HasAttribute("Filter") Then
                                    JVF.FilterType = SessionInfoElem.GetAttribute("Filter")
                                    JVF.SortType = SessionInfoElem.GetAttribute("Sort")
                                    JVF.RowZoomLevel = SessionInfoElem.GetAttribute("RowZoomLevel")
                                    JVF.HourWidth = SessionInfoElem.GetAttribute("HourWidth")
                                End If

                                If SessionInfoElem.HasAttribute("SuppressedCategories") Then
                                    JVF.SuppressedJobCategories = SessionInfoElem.GetAttribute("SuppressedCategories").Split(New String() {"||||"}, StringSplitOptions.RemoveEmptyEntries)
                                End If


                                Utils.RestoreWindowPosition(JVF, SessionInfoElem)

                                JVF.Show()
                                Exit For
                            End If
                        End If
                    Next
                Next
            End If
        End If

        If Options.m_RefreshInterval > 0 Then
            Tmr_Refresh.Interval = Options.m_RefreshInterval * 1000
            Tmr_Refresh.Enabled = True
        End If
    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Me.Invalidate()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim AF As New AboutBox1

        AF.ShowDialog(Me)
    End Sub

    Private Sub SetDateRangeMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetDateRangeMenuItem.Click
        If Not IsNothing(GetActiveJobViewForm()) Then
            GetActiveJobViewForm().ShowDateRangeDialog()
        End If
    End Sub

    Private Sub ExportMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ExportMenuItem.Click
        If Not IsNothing(GetActiveJobViewForm()) Then
            GetActiveJobViewForm.Export()
        End If
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim OptForm As New OptionsForm()

        If OptForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            For Each Frm As Form In Me.MdiChildren
                Frm.Invalidate()
            Next

            If Options.m_RefreshInterval > 0 Then
                If Options.m_RefreshInterval <> Tmr_Refresh.Interval Then
                    Tmr_Refresh.Interval = Options.m_RefreshInterval * 1000
                    Tmr_Refresh.Enabled = True
                End If
            Else
                Tmr_Refresh.Enabled = False
            End If
        End If
    End Sub

    Private Sub Tmr_Refresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Refresh.Tick
        For Each Frm As JobViewForm In Me.MdiChildren
            Frm.DoRefresh()
        Next
    End Sub

    Private Sub ZoomToFit()
        If Not IsNothing(GetActiveJobViewForm()) Then
            GetActiveJobViewForm().ZoomToFit()

            RefreshSettings()
        End If
    End Sub

    Private Sub ZoomButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomButton.Click
        ZoomToFit()
    End Sub

    Private Sub ZoomToFitMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToFitMenuItem.Click
        ZoomToFit()
    End Sub

    Private Sub NewConnectionMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewConnectionMenuItem.Click
        DoNewConnection()
    End Sub

    Private Sub ManageConnectionsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CIs As New List(Of ConnectionInfo)
        For Each CI As ConnectionInfo In ConnectionComboBox.Items
            CIs.Add(CI)
        Next

        Dim CMD As New ConnectionMgrDlg(CIs)
        If CMD.ShowDialog() = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub FilterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterButton.Click
        Dim JVF As JobViewForm = GetActiveJobViewForm()
        If Not IsNothing(JVF) Then
            Dim FD As New FilterDlg(JVF.FilterType, JVF.SuppressedJobCategories, JVF.AllJobCategories)

            Dim FDLoc As Point = ToolStrip1.PointToScreen(New Point(FilterButton.Bounds.Left, ToolStrip1.Height))
            FD.Location = FDLoc

            If FD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                JVF.FilterType = FD.FilterType
                JVF.SuppressedJobCategories = FD.SuppressedCategories

                RefreshSettings()
            End If
        End If
    End Sub

    Private Sub MyFilterComplete(ByVal Sender As JobViewForm, ByVal ShownJobCount As Integer, ByVal TotalJobCount As Integer)
        Me.Invoke(New FilterCompleteDel(AddressOf MyFilterComplete2), New Object() {Sender, ShownJobCount, TotalJobCount})
    End Sub

    Private Sub SetJobCounts(ByVal ShownJobCount As Integer, ByVal TotalJobCount As Integer)
        Sl_JobCount.Text = "Showing " & ShownJobCount & " of " & TotalJobCount & " jobs."
    End Sub

    Private Sub MyFilterComplete2(ByVal Sender As JobViewForm, ByVal ShownJobCount As Integer, ByVal TotalJobCount As Integer)
        Try
            If GetActiveJobViewForm() Is Sender Then
                SetJobCounts(ShownJobCount, TotalJobCount)
            End If
        Catch ex As Exception
            Sl_JobCount.Text = "Error determining job count."
        End Try
    End Sub
End Class
