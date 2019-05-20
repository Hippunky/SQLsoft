Public Class UiColour
    Implements ICloneable

    Public m_Name As String
    Public m_Colour As System.Drawing.Color
    Public m_IsText As Boolean = False

    Public Sub New(ByVal Name As String, ByVal Color As System.Drawing.Color, ByVal IsText As Boolean)
        m_Name = Name
        m_Colour = Color
        m_IsText = IsText
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return New UiColour(m_Name, m_Colour, m_IsText)
    End Function
End Class
