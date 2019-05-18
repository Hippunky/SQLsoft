Imports System.Data.SqlClient

Public Class ConnectionDlg
    Private m_ConnectionInfo As ConnectionInfo = Nothing
    Private m_AllowRememberingPassword As Boolean = True

    Public Sub New(ByVal CI As ConnectionInfo)
        InitializeComponent()

        Me.Icon = Utils.AppIcon

        m_ConnectionInfo = CI

        Txt_Server.Text = m_ConnectionInfo.m_Server
        Cbo_Authentication.SelectedIndex = CInt(m_ConnectionInfo.m_Authentication)
        Txt_Username.Text = m_ConnectionInfo.m_Username
        Txt_Password.Text = m_ConnectionInfo.m_Password
        Chk_RememberPassword.Checked = m_ConnectionInfo.m_RememberPassword
        Cbo_Database.Text = CI.m_Database
    End Sub

    Public Property AllowDatabaseSelection() As Boolean
        Get
            Return Cbo_Database.Enabled
        End Get
        Set(ByVal value As Boolean)
            Cbo_Database.Enabled = value
        End Set
    End Property

    Public Property AllowRememberingPassword() As Boolean
        Get
            Return m_AllowRememberingPassword
        End Get
        Set(ByVal value As Boolean)
            m_AllowRememberingPassword = value
        End Set
    End Property

    Private Sub Btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub PopulateConnectionInfo(ByVal CI As ConnectionInfo)
        CI.m_Name = Txt_Server.Text
        CI.m_Server = Txt_Server.Text
        CI.m_Authentication = Cbo_Authentication.SelectedIndex

        If CI.m_Authentication = Authentication.SqlServer Then
            CI.m_Username = Txt_Username.Text
            CI.m_Password = Txt_Password.Text
            CI.m_RememberPassword = Chk_RememberPassword.Checked
        Else
            CI.m_Username = ""
            CI.m_Password = ""
            CI.m_RememberPassword = False
        End If

        CI.m_Database = Cbo_Database.Text
    End Sub

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
        PopulateConnectionInfo(m_ConnectionInfo)

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub EnableControls()
        If Cbo_Authentication.SelectedIndex = 0 Then
            Txt_Username.Enabled = False
            Txt_Password.Enabled = False
            Chk_RememberPassword.Enabled = False
        Else
            Txt_Username.Enabled = True
            Txt_Password.Enabled = True
            Chk_RememberPassword.Enabled = m_AllowRememberingPassword
        End If
    End Sub

    Private Sub ConnectionDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If m_ConnectionInfo.m_Authentication = Authentication.Windows Then
            Cbo_Authentication.SelectedIndex = 0
        Else
            Cbo_Authentication.SelectedIndex = 1
        End If

        EnableControls()
    End Sub

    Private Sub Cbo_Authentication_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cbo_Authentication.SelectedIndexChanged
        EnableControls()
    End Sub

    Private Sub Cbo_Database_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cbo_Database.DropDown
        Dim CI As New ConnectionInfo

        PopulateConnectionInfo(CI)
        CI.m_Database = "master"

        For I As Integer = Cbo_Database.Items.Count - 1 To 0 Step -1
            Cbo_Database.Items.RemoveAt(I)
        Next

        Try
            Lbl_PopulatingDatabases.Visible = True
            Lbl_PopulatingDatabases.Update()

            Dim Conn As New SqlConnection(CI.GetConnectionString())
            Conn.Open()

            Dim Cmd As New SqlCommand("SELECT name FROM sys.databases WITH(NOLOCK) ORDER BY name", Conn)

            Dim Da As New SqlDataAdapter(Cmd)
            Dim Ds As New DataSet
            Da.Fill(Ds)

            Conn.Close()

            For Each Row As DataRow In Ds.Tables(0).Rows
                Cbo_Database.Items.Add(Row("name"))
            Next
        Catch ex As Exception
        End Try

        Lbl_PopulatingDatabases.Visible = False
    End Sub
End Class