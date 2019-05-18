Imports System.Data.SqlClient

Public Class Job
    'Implements ICloneable

    Public m_Server As String
    Public m_Id As Guid
    Public m_Name As String
    Public m_Enabled As Boolean
    Public m_DeleteLevel As DeleteLevel
    Public m_Schedules As New List(Of Schedule)
    Public m_RunInfos As New List(Of RunInfo)
    Public m_ClashTime As TimeSpan
    Public m_Category As String

    Public Sub New(ByVal Id As Guid, ByVal Name As String, ByVal Enabled As Boolean, ByVal DeleteLevel As DeleteLevel, _
                   ByVal Category As String, ByVal Server As String)
        m_Id = Id
        m_Name = Name
        m_Enabled = Enabled
        m_DeleteLevel = DeleteLevel
        m_Server = Server
        m_Category = Category
    End Sub

    Public ReadOnly Property TotalRunTimeSecs() As Long
        Get
            Dim Total As Long = 0
            For Each RI As RunInfo In m_RunInfos
                Total += RI.m_Duration.TotalSeconds
            Next

            Return Total
        End Get
    End Property

    'Public Function Clone() As Object Implements System.ICloneable.Clone
    '    Dim NewJob As Job = MyBase.MemberwiseClone

    '    NewJob.m_RunInfos = New List(Of RunInfo)

    '    For Each RI As RunInfo In m_RunInfos
    '        Dim RINew As RunInfo = RI.Clone()
    '        RINew.m_Job = NewJob

    '        NewJob.m_RunInfos.Add(RINew)
    '    Next

    '    Return NewJob
    'End Function
End Class
