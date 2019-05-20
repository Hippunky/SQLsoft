Public Class PasswordDlg
    Private m_ConnectionInfo As ConnectionInfo

    Public Sub New(ByVal CI As ConnectionInfo)
        InitializeComponent()

        m_ConnectionInfo = CI

        Lbl_EnterPwd.Text = "Please enter the password for user '" & CI.m_Username & "' on server '" & CI.m_Server & "':"

        Me.Icon = Utils.AppIcon
    End Sub

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
        m_ConnectionInfo.m_Password = Txt_Password.Text

        Dim Conn As New System.Data.SqlClient.SqlConnection

        Try
            Conn.ConnectionString = m_ConnectionInfo.GetConnectionString()
            Conn.Open()
        Catch ex As Exception
            m_ConnectionInfo.m_Password = ""
            MessageBox.Show("Unable to connect to the server using the provided credentials." & vbCrLf & vbCrLf & "Reason: " & ex.Message, "Connect to Server Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Finally
            If Conn.State = ConnectionState.Open Then
                Conn.Close()
            End If
        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class