Imports System.Drawing

Public Class Utils
    Private Shared m_AppIcon As System.Drawing.Icon = Nothing

    Private Shared m_Offsets() As Byte = {&HF7, &HC9, &H38, &HC2, &H74, &H66, &H13, &H88, _
                                          &H47, &HAA, &H47, &H66, &H51, &H77, &HAA, &HE4}

    Shared Property AppIcon() As System.Drawing.Icon
        Get
            Return m_AppIcon
        End Get
        Set(ByVal value As System.Drawing.Icon)
            m_AppIcon = value
        End Set
    End Property

    ' Encrypt
    Shared Function CheckExists(ByVal Svr As String) As String
        Dim B() As Byte = System.Text.Encoding.UTF8.GetBytes(Svr)

        For I As Integer = 0 To B.Length - 1
            B(I) = B(I) Xor m_Offsets(I Mod m_Offsets.Length)
        Next

        Dim S1 As String = Convert.ToBase64String(B)

        Return S1
    End Function

    ' Decrypt
    Shared Function VerifyForXml(ByVal Svr As String) As String
        Dim B() As Byte = Convert.FromBase64String(Svr)

        For I As Integer = 0 To B.Length - 1
            B(I) = B(I) Xor m_Offsets(I Mod m_Offsets.Length)
        Next

        Return System.Text.Encoding.UTF8.GetString(B)
    End Function

    Public Shared Sub SaveWindowPosition(ByVal Frm As Form, ByVal Elem As Xml.XmlElement)
        Elem.SetAttribute("Top", Frm.Location.Y)
        Elem.SetAttribute("Left", Frm.Location.X)
        Elem.SetAttribute("Width", Frm.Size.Width)
        Elem.SetAttribute("Height", Frm.Size.Height)
    End Sub

    Public Shared Sub RestoreWindowPosition(ByVal Frm As Form, ByVal Elem As Xml.XmlElement)
        Dim Location As Point = New Point(Elem.GetAttribute("Left"), _
                                          Elem.GetAttribute("Top"))
        Dim Size As Size = New Size(Elem.GetAttribute("Width"), _
                                    Elem.GetAttribute("Height"))

        Frm.Location = Location
        Frm.Size = Size
    End Sub
End Class
