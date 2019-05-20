Public Class JobComparer
    Implements IComparer(Of Job)

    Private m_SortType As SortType = SortType.JobName

    Public Sub New(ByVal sortType As SortType)
        m_SortType = SortType
    End Sub

    Public Function Compare(ByVal x As Job, ByVal y As Job) As Integer Implements System.Collections.Generic.IComparer(Of Job).Compare
        Select Case m_SortType
            Case SortType.JobName
                Return x.m_Name.CompareTo(y.m_Name)
            Case SortType.TotalRunTime
                Return -(x.TotalRunTimeSecs.CompareTo(y.TotalRunTimeSecs))
            Case SortType.Frequency
                Return -(x.m_RunInfos.Count.CompareTo(y.m_RunInfos.Count))
            Case SortType.TimeClashing
                Return -(x.m_ClashTime.CompareTo(y.m_ClashTime))
            Case SortType.EarliestStartTime
                Dim StartX As DateTime = DateTime.MaxValue
                Dim StartY As DateTime = DateTime.MaxValue

                If x.m_RunInfos.Count > 0 Then
                    StartX = x.m_RunInfos(0).m_StartTime
                End If

                If y.m_RunInfos.Count > 0 Then
                    StartY = y.m_RunInfos(0).m_StartTime
                End If

                Return StartX.CompareTo(StartY)
            Case Else
                Return 0
        End Select
    End Function
End Class
