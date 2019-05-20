Public Class RunInfo
    Implements ICloneable, IComparable(Of RunInfo)

    Public ReadOnly m_Status As RunStatus
    Public ReadOnly m_StartTime As DateTime
    Public ReadOnly m_Duration As TimeSpan
    Public m_ClashTime As TimeSpan
    Public ReadOnly m_EndTime As DateTime
    Public m_ExecInfo As String = ""
    Public ReadOnly m_Job As Job

    Public Sub New(Status As RunStatus, _
                    StartTime As DateTime, _
                    Duration As TimeSpan, _
                    EndTime As DateTime, _
                    ExecInfo As String, _
                    Job As Job)
        m_Duration = Duration
        m_EndTime = EndTime
        m_ExecInfo = ExecInfo
        m_Job = Job
        m_Status = Status
        m_StartTime = StartTime

    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return MyBase.MemberwiseClone()
    End Function

    Public Function Intersect(ByVal RI2 As RunInfo) As TimeSpan
        If Me.m_EndTime < RI2.m_StartTime Or Me.m_StartTime > RI2.m_EndTime Then
            Return New TimeSpan(0)
        End If

        Dim LowTime As DateTime = Me.m_StartTime
        If Me.m_StartTime < RI2.m_StartTime Then
            LowTime = RI2.m_StartTime
        End If

        Dim HighTime As DateTime = Me.m_EndTime
        If Me.m_EndTime > RI2.m_EndTime Then
            HighTime = RI2.m_EndTime
        End If

        Return HighTime.Subtract(LowTime)
    End Function

    Public Function CompareTo(ByVal other As RunInfo) As Integer Implements System.IComparable(Of RunInfo).CompareTo
        Return m_StartTime.CompareTo(other.m_StartTime)
    End Function
End Class
