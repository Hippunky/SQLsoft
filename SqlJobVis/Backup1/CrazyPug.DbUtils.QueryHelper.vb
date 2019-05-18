Imports System.Data.SqlClient

Public Class QueryHelper
    Private m_ConnectionString As String = ""

    Public Sub New(ByVal ConnStr As String)
        m_ConnectionString = ConnStr
    End Sub

    Public Sub New(ByVal Server As String, ByVal Database As String, Optional ByVal Username As String = Nothing, Optional ByVal Password As String = Nothing)
        If Not IsNothing(Username) And Not IsNothing(Password) Then
            m_ConnectionString = "Data Source=" & Server & ";Initial Catalog=" & Database & ";User Id=" & Username & ";Password=" & Password & ";"
        Else
            m_ConnectionString = "Data Source=" & Server & ";Initial Catalog=" & Database & ";Integrated Security=SSPI;"
        End If
    End Sub

    Public Property ConnectionString() As String
        Get
            Return m_ConnectionString
        End Get
        Set(ByVal value As String)
            m_ConnectionString = value
        End Set
    End Property

    Public Function GetRowsForSprocCall(ByVal SprocName As String, ByVal Params() As String) As DataRowCollection
        Dim Conn As New SqlConnection(Me.ConnectionString)
        Conn.Open()

        Dim Cmd As New SqlCommand(SprocName, Conn)
        Cmd.CommandType = CommandType.StoredProcedure

        If Not IsNothing(Params) Then
            For Each Param As String In Params
                Dim FirstEqualsIndex As Integer = Param.IndexOf("=")

                If FirstEqualsIndex < 0 Then
                    Throw New ApplicationException("Malformed Parameter Specification in GetRowsForSprocCall")
                End If

                Dim ParamName As String = Param.Substring(0, FirstEqualsIndex)
                Dim ParamValue As String = Param.Substring(FirstEqualsIndex + 1)

                Cmd.Parameters.AddWithValue(ParamName, ParamValue)
            Next
        End If

        Dim Ds As New DataSet
        Dim Da As New SqlDataAdapter(Cmd)
        Da.Fill(Ds)

        Conn.Close()

        Return Ds.Tables(0).Rows
    End Function

    Public Function GetRowsForSprocCall(ByVal SprocName As String, Optional ByVal Params As String = Nothing) As DataRowCollection
        Dim ParamList As New ArrayList()

        If Not IsNothing(Params) AndAlso Params.Trim() <> "" Then
            Dim Bits() As String = Params.Split(",")
            For Each Bit As String In Bits
                Dim FirstEqualsIndex As Integer = Bit.IndexOf("=")

                If FirstEqualsIndex < 0 Then
                    Throw New ApplicationException("Malformed Parameter Specification in GetRowsForSprocCall")
                End If

                Dim ParamName As String = Bit.Substring(0, FirstEqualsIndex)
                Dim ParamValue As String = Bit.Substring(FirstEqualsIndex + 1)

                ParamList.Add(ParamName.Trim() & "=" & ParamValue.Trim())
            Next
        Else
            Params = Nothing
        End If

        Return GetRowsForSprocCall(SprocName, ParamList.ToArray(GetType(String)))
    End Function
End Class
