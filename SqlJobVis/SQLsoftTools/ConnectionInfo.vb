Imports System.Data.SqlClient
Imports System.Xml

Public Class ConnectionInfo
    Implements ICloneable

    Public m_Name As String = ""
    Public m_Server As String = ""
    Public m_Authentication As Authentication = Authentication.Windows
    Public m_Username As String = ""
    Public m_Password As String = ""
    Public m_RememberPassword As Boolean = False
    Public m_Database As String = ""

    Public Sub New()
    End Sub

    Public Sub New(ByVal Elem As XmlElement)
        m_Name = Elem.GetAttribute("Name")
        m_Server = Elem.GetAttribute("Server")
        m_Authentication = Elem.GetAttribute("Authentication")
        m_Username = Elem.GetAttribute("Username")
        m_RememberPassword = Elem.GetAttribute("RememberPassword")

        If m_RememberPassword Then
            m_Password = Utils.VerifyForXml(Elem.GetAttribute("Password"))
        End If

        If Elem.HasAttribute("Database") Then
            m_Database = Elem.GetAttribute("Database")
        End If
    End Sub

    Public Function ToXml(ByVal Doc As XmlDocument) As XmlElement
        Dim Elem As XmlElement = Doc.CreateElement("ConnectionInfo")

        Elem.SetAttribute("Name", m_Name)
        Elem.SetAttribute("Server", m_Server)
        Elem.SetAttribute("Authentication", m_Authentication)
        Elem.SetAttribute("Username", m_Username)
        Elem.SetAttribute("RememberPassword", m_RememberPassword)
        If m_RememberPassword Then
            Elem.SetAttribute("Password", Utils.CheckExists(m_Password))
        Else
            ' Do nothing.
        End If
        Elem.SetAttribute("Database", m_Database)

        Return Elem
    End Function

    Public Overrides Function ToString() As String
        Return m_Name
    End Function

    Public Function GetConnectionString() As String
        Dim csb As New SqlConnectionStringBuilder()

        csb.DataSource = m_Server
        csb.InitialCatalog = m_Database

        Select Case m_Authentication
            Case Authentication.Windows
                csb.IntegratedSecurity = True
            Case Authentication.SqlServer
                csb.IntegratedSecurity = False
                csb.UserID = m_Username
                csb.Password = m_Password
            Case Else
                Throw New ApplicationException("Unknown authentication type.")
        End Select

        Return csb.ConnectionString
    End Function

    Public Function AuthenticateIfRequired(ByVal ParentForm As Form) As Boolean
        If (m_Authentication = Authentication.SqlServer) And (m_Password = "") And (Not m_RememberPassword) Then
            Dim PD As New SQLsoftTools.PasswordDlg(Me)

            If PD.ShowDialog(ParentForm) <> Windows.Forms.DialogResult.OK Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim CI As New ConnectionInfo

        CI.m_Name = Me.m_Name
        CI.m_Server = Me.m_Server
        CI.m_Authentication = Me.m_Authentication
        CI.m_Username = Me.m_Username
        CI.m_Password = Me.m_Password
        CI.m_RememberPassword = Me.m_RememberPassword
        CI.m_Database = Me.m_Database

        Return CI
    End Function

    Public Function GetServerVersionParts() As String()
        Try
            Dim Ds As New DataSet()

            Using Conn As New SqlConnection(GetConnectionString())
                Conn.Open()

                Using Cmd As New SqlCommand("SELECT SERVERPROPERTY('productversion')", Conn)
                    Dim Da As New SqlDataAdapter(Cmd)

                    Da.Fill(Ds)
                End Using

                Conn.Close()
            End Using

            Return Ds.Tables(0).Rows(0)(0).ToString().Split(New Char() {"."c}, StringSplitOptions.None)
        Catch ex As SqlException
            Throw New ApplicationException("This version of SQL Server is not supported." & vbCrLf & vbCrLf & "SQLjobvis supports SQL Server 2000 or higher.")
        End Try
    End Function
End Class
