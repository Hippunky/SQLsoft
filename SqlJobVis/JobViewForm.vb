Imports System.Data.SqlClient
Imports System.Globalization
Imports SQLsoftTools

Public Class JobViewForm
    Private m_ConnectionInfo As ConnectionInfo
    Private m_AllJobsList As New List(Of Job)
    Private m_FilterType As FilterType = 0
    Private m_SortType As SortType = SortType.JobName

    Private m_UpdateThread As Threading.Thread = Nothing
    Private m_CancelUpdate As Boolean = False

    Private m_ForceZoomToFit As Boolean = False

    Public Event FilterComplete(ByVal Sender As JobViewForm, ByVal ShownJobCount As Integer, ByVal TotalJobCount As Integer)

    Public Sub CancelUpdate(Optional ByVal Closing As Boolean = False)
        m_CancelUpdate = True

        While Not IsNothing(m_UpdateThread)
            Application.DoEvents()
            Threading.Thread.Sleep(50)
        End While

        m_CancelUpdate = False
    End Sub

    Private Delegate Sub GetHistoryCompleted(ByVal Jobs As List(Of Job))

    Private Sub MyGetHistoryCompleted(ByVal Jobs As List(Of Job))
        JobRunInfosViewer1.Jobs = Jobs

        JobRunInfosViewer1.RestoreScrollPosition()

        SetTitle(False)
        JobRunInfosViewer1.StatusText = Nothing

        If m_ForceZoomToFit Then
            ZoomToFit()

            m_ForceZoomToFit = False
        End If
    End Sub

    Public ReadOnly Property ConnectionInfo() As ConnectionInfo
        Get
            Return m_ConnectionInfo
        End Get
    End Property

    Public Property ForceZoomToFit() As Boolean
        Get
            Return m_ForceZoomToFit
        End Get
        Set(ByVal value As Boolean)
            m_ForceZoomToFit = value
        End Set
    End Property

    Public Sub New(ByVal CI As ConnectionInfo)
        InitializeComponent()

        Me.Icon = Utils.AppIcon

        m_ConnectionInfo = CI

        SetTitle(False)

        JobRunInfosViewer1.RowZoomLevel = 8
        JobRunInfosViewer1.HourWidth = 160

        JobRunInfosViewer1.SetDateRange(Options.GetStartDate(), DateTime.Now.Date.AddDays(1.0))

        DoRefresh()
    End Sub

    Public Sub ZoomToFit()
        JobRunInfosViewer1.ZoomToFit()
    End Sub

    Public Sub DoRefresh()
        JobRunInfosViewer1.StatusText = "Updating"
        GetHistory()
    End Sub

    Public Sub ShowDateRangeDialog()
        Dim DRD As New DateRangeDlg
        DRD.FromDate = JobRunInfosViewer1.StartTime.Date
        DRD.ToDate = JobRunInfosViewer1.EndTime.AddDays(-1.0).Date

        If DRD.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            JobRunInfosViewer1.SetDateRange(DRD.FromDate, DRD.ToDate.AddDays(1.0))
            JobRunInfosViewer1.Jobs = FilterAndSort()
        End If
    End Sub

    Private Enum ExportFormat
        CSV
        TSV
    End Enum

    Private Function EscapeExportedString(ByVal S As String, ByVal Fmt As ExportFormat)
        Select Case Fmt
            Case ExportFormat.CSV
                Return """" & S.Replace("""", """""") & """"
            Case ExportFormat.TSV
                Return S
            Case Else
                Return S
        End Select
    End Function

    Public Sub Export()
        If IsNothing(JobRunInfosViewer1.Jobs) Then
            Return
        End If

        If Sfd_Export.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Select Case Sfd_Export.FilterIndex
                Case 1, 2
                    Dim Fmt As ExportFormat = If(Sfd_Export.FilterIndex = 1, ExportFormat.CSV, ExportFormat.TSV)
                    Dim Separator As String = If(Fmt = ExportFormat.CSV, ",", vbTab)

                    Using SW As New IO.StreamWriter(Sfd_Export.FileName)
                        SW.WriteLine("Server" & Separator & "JobName" & Separator & "Enabled" & _
                                     Separator & "StartTime" & Separator & _
                                     "EndTime" & Separator & "Duration" & Separator & "RunStatus")

                        For Each J As Job In JobRunInfosViewer1.Jobs
                            For Each RI As RunInfo In J.m_RunInfos
                                SW.WriteLine(J.m_Server & Separator & _
                                             EscapeExportedString(J.m_Name, Fmt) & Separator & _
                                             If(J.m_Enabled, 1, 0) & Separator & _
                                             RI.m_StartTime.ToString("yyyy-MM-dd HH:mm:ss") & Separator & _
                                             RI.m_EndTime.ToString("yyyy-MM-dd HH:mm:ss") & Separator & _
                                             RI.m_Duration.ToString() & Separator & _
                                             RI.m_Status.ToString())
                            Next
                        Next

                        SW.Close()
                    End Using
                Case Else
                    Throw New ApplicationException("No extension detected.")
            End Select
        End If
    End Sub

    Public Property RowZoomLevel() As Integer
        Get
            Return JobRunInfosViewer1.RowZoomLevel
        End Get
        Set(ByVal value As Integer)
            JobRunInfosViewer1.RowZoomLevel = value
        End Set
    End Property

    Public Property HourWidth() As Integer
        Get
            Return JobRunInfosViewer1.HourWidth
        End Get
        Set(ByVal value As Integer)
            JobRunInfosViewer1.HourWidth = value
        End Set
    End Property

    Public Property FilterType() As FilterType
        Get
            Return m_FilterType
        End Get
        Set(ByVal value As FilterType)
            m_FilterType = value

            JobRunInfosViewer1.Jobs = FilterAndSort()
        End Set
    End Property

    Public Property SortType() As SortType
        Get
            Return m_SortType
        End Get
        Set(ByVal value As SortType)
            m_SortType = value

            JobRunInfosViewer1.Jobs = FilterAndSort()
        End Set
    End Property

    Private Sub GetHistoryMT()

        Dim Jobs As IEnumerable(Of Job)
        Dim gateway As JobGateway = New JobGateway()

        Try
            Jobs = gateway.GetJobs(m_ConnectionInfo, Options.m_QueryTimeoutSecs)

            'm_AllJobsList = New List(Of Job)(Jobs.Values)

            'Dim FilteredAndSortedJobs As List(Of Job) = FilterAndSort()

            Me.Invoke(New GetHistoryCompleted(AddressOf MyGetHistoryCompleted), New Object() {New List(Of Job)(Jobs)})

        Catch ex As Exception
            JobRunInfosViewer1.Jobs = Nothing

            JobRunInfosViewer1.StatusText = "Could not acquire jobs from the server." & vbCrLf & vbCrLf & "Reason: " & ex.Message
            SetTitle(False)

        Finally
            m_UpdateThread = Nothing
        End Try
    End Sub

    Private Sub SetTitle(ByVal Refreshing As Boolean)
        Try
            Me.Text = m_ConnectionInfo.m_Server
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetHistory()
        Try
            Me.Cursor = Cursors.WaitCursor

            SetTitle(True)

            JobRunInfosViewer1.RememberScrollPosition()

            CancelUpdate()

            m_UpdateThread = New Threading.Thread(AddressOf GetHistoryMT)
            m_UpdateThread.Priority = Threading.ThreadPriority.Lowest
            m_UpdateThread.Start()
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function FilterAndSort() As List(Of Job)
        Dim ResultJobs As New List(Of Job)

        For Each J As Job In m_AllJobsList
            If m_CancelUpdate Then
                Return Nothing
            End If

            Dim NewJob As Job = J '.Clone()

            Dim I As Integer = 0
            While I < NewJob.m_RunInfos.Count
                Dim RI As RunInfo = NewJob.m_RunInfos(I)

                Dim EndTime As DateTime = RI.m_StartTime.Add(RI.m_Duration)

                If RI.m_StartTime < JobRunInfosViewer1.EndTime AndAlso EndTime > JobRunInfosViewer1.StartTime Then
                    I += 1
                Else
                    NewJob.m_RunInfos.RemoveAt(I)
                End If
            End While

            ResultJobs.Add(NewJob)
        Next

        Dim AllRunInfos As New List(Of RunInfo)
        For Each J As Job In ResultJobs
            For Each RI As RunInfo In J.m_RunInfos
                AllRunInfos.Add(RI)
            Next
        Next

        AllRunInfos.Sort()

        For Each J As Job In ResultJobs
            J.m_ClashTime = New TimeSpan(0)
        Next

        For Each RI1 As RunInfo In AllRunInfos
            If m_CancelUpdate Then
                Return Nothing
            End If

            RI1.m_ClashTime = New TimeSpan(0)

            For Each RI2 As RunInfo In AllRunInfos
                If Not RI1.m_Job Is RI2.m_Job Then
                    If RI1.m_EndTime < RI2.m_StartTime Then
                        Exit For
                    End If

                    If RI1.m_StartTime <= RI2.m_EndTime Then
                        RI1.m_ClashTime = RI1.m_ClashTime.Add(RI1.Intersect(RI2))
                        RI1.m_Job.m_ClashTime = RI1.m_Job.m_ClashTime.Add(RI1.Intersect(RI2))
                    End If
                End If
            Next
        Next

        Dim I2 As Integer = 0
        While I2 < ResultJobs.Count
            If m_CancelUpdate Then
                Return Nothing
            End If

            Dim TheJob As Job = ResultJobs(I2)
            Dim KeepJob As Boolean = True

            If KeepJob AndAlso m_SuppressedJobCategories.Contains(TheJob.m_Category) Then
                KeepJob = False
            End If

            If KeepJob AndAlso (m_FilterType And SqlJobVis.FilterType.Disabled) <> 0 Then
                KeepJob = TheJob.m_Enabled
            End If

            If KeepJob AndAlso (m_FilterType And SqlJobVis.FilterType.Inactive) <> 0 Then
                KeepJob = (TheJob.m_RunInfos.Count <> 0)
            End If

            If KeepJob AndAlso (m_FilterType And SqlJobVis.FilterType.Failed) <> 0 Then
                KeepJob = False
                For Each RI As RunInfo In TheJob.m_RunInfos
                    If RI.m_Status = RunStatus.Failed Then
                        KeepJob = True
                        Exit For
                    End If
                Next
            End If

            If KeepJob AndAlso ((m_FilterType And SqlJobVis.FilterType.Clashing) <> 0) Then
                If TheJob.m_ClashTime.TotalSeconds = 0 Then
                    KeepJob = False
                End If
            End If

            If KeepJob AndAlso ((m_FilterType And SqlJobVis.FilterType.LongRunning) <> 0) Then
                KeepJob = False
                For Each RI As RunInfo In TheJob.m_RunInfos
                    If RI.m_Duration.TotalSeconds >= Options.m_LongRunningJobSecs Then
                        KeepJob = True
                        Exit For
                    End If
                Next
            End If

            If KeepJob Then
                I2 += 1
            Else
                ResultJobs.RemoveAt(I2)
            End If
        End While

        ResultJobs.Sort(New JobComparer(m_SortType))

        RaiseEvent FilterComplete(Me, ResultJobs.Count, m_AllJobsList.Count)

        Return ResultJobs
    End Function

    Private Sub JobViewForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CancelUpdate()
    End Sub

    Public ReadOnly Property ShownJobCount() As Integer
        Get
            If Not IsNothing(JobRunInfosViewer1) AndAlso Not IsNothing(JobRunInfosViewer1.Jobs) Then
                Return JobRunInfosViewer1.Jobs.Count
            End If
        End Get
    End Property

    Public ReadOnly Property TotalJobCount() As Integer
        Get
            Return m_AllJobsList.Count
        End Get
    End Property

    Public ReadOnly Property AllJobCategories() As String()
        Get
            Dim result As New List(Of String)
            For Each J As Job In m_AllJobsList
                If Not result.Contains(J.m_Category) Then
                    result.Add(J.m_Category)
                End If
            Next

            result.Sort()

            Return result.ToArray()
        End Get
    End Property

    Private m_SuppressedJobCategories As New List(Of String)
    Public Property SuppressedJobCategories() As String()
        Get
            Return m_SuppressedJobCategories.ToArray()
        End Get
        Set(ByVal value As String())
            m_SuppressedJobCategories.Clear()
            m_SuppressedJobCategories.AddRange(value)

            JobRunInfosViewer1.Jobs = FilterAndSort()
        End Set
    End Property
End Class