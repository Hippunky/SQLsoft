Imports SQLsoftTools
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Resources


Public Class JobGateway

    Public Function GetJobs(ByVal m_ConnectionInfo As ConnectionInfo, m_QueryTimeoutSecs As Integer) As IEnumerable(Of Job)

        Dim Conn As SqlConnection = Nothing
        Dim Cmd As SqlCommand = Nothing
        Dim CmdStr As String
        Dim jobs As New Dictionary(Of Guid, Job)
        Dim server As String = m_ConnectionInfo.m_Server
        Dim runningJobInfos As New Dictionary(Of Guid, RunInfo)

        Try

            If CInt(m_ConnectionInfo.GetServerVersionParts()(0)) > 8 Then
                CmdStr = My.Resources.GetJobsWithActivity
            Else
                CmdStr = My.Resources.GetJobs
            End If

            Conn = New SqlConnection(m_ConnectionInfo.GetConnectionString())
            Conn.Open()

            Cmd = New SqlCommand(CmdStr, Conn)
            Cmd.CommandTimeout = m_QueryTimeoutSecs
            Dim reader As IDataReader = Cmd.ExecuteReader()

            'job details
            Do While reader.Read()
                Dim id As Guid = CType(reader("job_id"), Guid)
                jobs.Add(id, New Job(id, _
                                    CStr(reader("name")), _
                                    CBool(reader("enabled")), _
                                    CType(reader("delete_level"), DeleteLevel), _
                                    CStr(reader("category")), _
                                    server))
            Loop

            'Job history
            If reader.NextResult() Then

                Do While reader.Read()
                    Dim id As Guid = CType(reader("job_id"), Guid)

                    If jobs.ContainsKey(id) Then

                        Dim job As Job = jobs(id)
                        Dim status As RunStatus = CType(reader("run_status"), RunStatus)

                        Dim timeStamp As String = reader("run_date") & " " & reader("run_time").ToString().PadLeft(6, "0")
                        Dim startTime As DateTime = DateTime.ParseExact(timeStamp, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture)

                        Dim runDuration As String = reader("run_duration").ToString().PadLeft(6, "0")
                        Dim duration = New TimeSpan(CInt(runDuration.Substring(0, 2)), _
                                                                             CInt(runDuration.Substring(2, 2)), _
                                                                             CInt(runDuration.Substring(4, 2)))
                        Dim endTime As DateTime = startTime.Add(duration)


                        Dim runInfo As New RunInfo(status, startTime, duration, endTime, "", job)
                        job.m_RunInfos.Add(runInfo)

                        If (runInfo.m_Status = RunStatus.InProgress) Then
                            runningJobInfos(id) = runInfo
                        End If
                    End If
                Loop
            End If

            'job current execution step (if any) from sp_help_job
            If reader.NextResult() Then

                Do While reader.Read()
                    Dim id As Guid = CType(reader("job_id"), Guid)

                    If runningJobInfos.ContainsKey(id) Then
                        Dim StepCount As Integer = CInt(reader("has_step"))
                        Dim CurrStep As String = CStr(reader("current_execution_step"))

                        runningJobInfos(id).m_ExecInfo = String.Format("Executing step {0} of {1}", CurrStep, StepCount)

                    End If
                Loop
            End If

            Return jobs.Values

        Finally

            If Not (Conn Is Nothing) Then
                Conn.Dispose()
            End If
        End Try

    End Function
End Class
