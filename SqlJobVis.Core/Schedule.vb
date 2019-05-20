Public Class Schedule
    Public m_Id As Integer
    Public m_Uid As Guid
    Public m_Name As String
    Public m_Enabled As Boolean
    Public m_FreqType As FreqType
    Public m_FreqInterval As Integer
    Public m_FreqSubdayType As FreqSubdayType
    Public m_FreqSubdayInterval As Integer
    Public m_FreqRelativeInterval As FreqRelativeInterval
    Public m_FreqRecurrenceFactor As Integer
    Public m_ActiveStartDate As DateTime
    Public m_ActiveEndDate As DateTime
    Public m_ActiveStartTime As DateTime
    Public m_ActiveEndTime As DateTime
End Class
