Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class ConnectionMgrDlg
    Private m_CIs As List(Of ConnectionInfo)

    Public Sub New(ByVal CIs As List(Of ConnectionInfo))
        MyBase.New()

        InitializeComponent()

        m_CIs = CIs

        For Each CI As ConnectionInfo In m_CIs
            Dim CI2 As ConnectionInfo = CI.Clone()

            Dim LVI As New ListViewItem(New String() {CI2.m_Name, CI2.GetConnectionString()}) With {.Tag = CI2}

            Lv_Connections.Items.Add(LVI)
        Next

        UpdateButtons()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        m_CIs.Clear()

        For Each LVI As ListViewItem In Lv_Connections.Items
            m_CIs.Add(LVI.Tag)
        Next

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Btn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Add.Click
        Dim CI As New ConnectionInfo() With {.m_Database = "msdb"}

        Dim CD As New ConnectionDlg(CI) With {.AllowDatabaseSelection = False}

        If CD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If CI.AuthenticateIfRequired(Me) Then
                Try
                    Using Conn As New SqlConnection(CI.GetConnectionString())
                        Conn.Open()
                        Conn.Close()
                    End Using

                    Dim LVI As New ListViewItem(New String() {CI.m_Name, CI.GetConnectionString()}) With {.Tag = CI}

                    Lv_Connections.Items.Add(LVI)
                Catch ex As Exception
                    MessageBox.Show("Unable to connect to the server: " & ex.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End Try
            End If
        End If
    End Sub

    Private Sub Btn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Edit.Click
        If Lv_Connections.SelectedItems.Count <> 0 Then
            Dim LVI As ListViewItem = Lv_Connections.SelectedItems(0)

            Dim CI As ConnectionInfo = LVI.Tag

            Dim CD As New ConnectionDlg(CI) With {.AllowDatabaseSelection = False}

            If CD.ShowDialog() = Windows.Forms.DialogResult.OK Then
                LVI.Text = CI.m_Name
                LVI.SubItems(1).Text = CI.GetConnectionString()
            End If
        End If
    End Sub

    Private Sub Btn_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Remove.Click
        If Lv_Connections.SelectedItems.Count <> 0 Then
            Lv_Connections.Items.Remove(Lv_Connections.SelectedItems(0))
        End If
    End Sub

    Private Sub UpdateButtons()
        Dim ItemSelected As Boolean = Lv_Connections.SelectedItems.Count > 0

        Btn_Edit.Enabled = ItemSelected
        Btn_Remove.Enabled = ItemSelected
    End Sub

    Private Sub Lv_Connections_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lv_Connections.SelectedIndexChanged
        UpdateButtons()
    End Sub
End Class
