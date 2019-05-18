Public Class JobRunInfosViewer
    Public Event SelectionChange()

    Private m_Jobs As List(Of Job) = Nothing
    Private m_StartDateTime As DateTime = DateTime.Now.Date
    Private m_EndDateTime As DateTime = m_StartDateTime.AddDays(1.0)

    Private m_HeaderRowHeight As Integer = 16
    Private m_RowHeight As Integer = 16
    Private m_HourWidth As Integer = 160

    Private Class RunInfoRect
        Public m_Rect As Rectangle = Nothing
        Public m_Job As Job = Nothing
        Public m_RunInfo As RunInfo = Nothing
    End Class

    Private m_RunInfoRects As New List(Of RunInfoRect)

    Private m_RunCountHash As New Dictionary(Of DateTime, Integer)

    Public Sub New()
        InitializeComponent()

        Me.DoubleBuffered = True
    End Sub

    Public ReadOnly Property Selection() As List(Of Job)
        Get
            Return m_SelectedJobs
        End Get
    End Property

    Private Sub ClearSelection()
        m_AnchorIndex = -1
        m_SelectedJobs.Clear()

        Me.Invalidate()
        RaiseEvent SelectionChange()
    End Sub

    Public Property Jobs() As List(Of Job)
        Get
            Return m_Jobs
        End Get
        Set(ByVal value As List(Of Job))
            m_Jobs = value

            If Not IsNothing(m_Jobs) Then
                m_RunCountHash.Clear()

                ClearSelection()

                For Each J As Job In m_Jobs
                    For Each RI As RunInfo In J.m_RunInfos
                        If Not m_RunCountHash.ContainsKey(RI.m_StartTime) Then
                            m_RunCountHash.Add(RI.m_StartTime, 0)
                        End If

                        m_RunCountHash(RI.m_StartTime) += 1

                        If Not m_RunCountHash.ContainsKey(RI.m_EndTime) Then
                            m_RunCountHash.Add(RI.m_EndTime, 0)
                        End If

                        m_RunCountHash(RI.m_EndTime) -= 1
                    Next
                Next
            End If

            SetScrollBars()
        End Set
    End Property

    Public Sub SetDateRange(ByVal FromDateTime As DateTime, ByVal ToDateTime As DateTime)
        m_StartDateTime = FromDateTime
        m_EndDateTime = ToDateTime

        SetScrollBars()
    End Sub

    Public ReadOnly Property StartTime() As DateTime
        Get
            Return m_StartDateTime
        End Get
    End Property

    Public ReadOnly Property EndTime() As DateTime
        Get
            Return m_EndDateTime
        End Get
    End Property

    Public Property RowZoomLevel() As Integer
        Get
            Return m_RowHeight / 2
        End Get
        Set(ByVal value As Integer)
            m_RowHeight = value * 2

            SetScrollBars()
        End Set
    End Property

    Public Property HourWidth() As Integer
        Get
            Return m_HourWidth
        End Get
        Set(ByVal value As Integer)
            m_HourWidth = value

            SetScrollBars()
        End Set
    End Property

    Private m_StatusText As String = Nothing
    Public Property StatusText() As String
        Get
            Return m_StatusText
        End Get
        Set(ByVal value As String)
            m_StatusText = value

            If IsNothing(m_Jobs) OrElse (m_Jobs.Count = 0) Then
                Invalidate()
            End If
        End Set
    End Property

    Private Sub SetScrollBars()
        If Not IsNothing(m_Jobs) AndAlso (m_Jobs.Count > 0) Then
            VScrollBar1.Minimum = 0
            VScrollBar1.Maximum = m_Jobs.Count - 1
            VScrollBar1.Value = 0
            VScrollBar1.LargeChange = Math.Max((Me.ClientSize.Height - 2 * m_HeaderRowHeight - HScrollBar1.Height) \ m_RowHeight, 0)
        End If

        HScrollBar1.Minimum = 0
        HScrollBar1.Maximum = m_EndDateTime.Subtract(m_StartDateTime).TotalHours - 1
        HScrollBar1.Value = 0
        HScrollBar1.LargeChange = Math.Max((Me.ClientSize.Width - Me.RowHeaderWidth - VScrollBar1.Width) \ m_HourWidth, 0)

        Me.Invalidate()
    End Sub

    Private m_HScrollValue As Integer = 0
    Private m_VScrollValue As Integer = 0

    Public Sub RememberScrollPosition()
        m_HScrollValue = HScrollBar1.Value
        m_VScrollValue = VScrollBar1.Value
    End Sub

    Public Sub RestoreScrollPosition()
        HScrollBar1.Value = m_HScrollValue
        VScrollBar1.Value = m_VScrollValue
    End Sub

    Private ReadOnly Property RowHeaderWidth() As Integer
        Get
            Return IIf(m_RowHeight >= 16, 200, 0)
        End Get
    End Property

    Private m_AnchorIndex As Integer = -1
    Private m_SelectedJobs As New List(Of Job)

    Private Function GetJobIndex(ByVal J As Job) As Integer
        Return m_Jobs.IndexOf(J)
    End Function

    Private Sub JobRunInfosViewer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Select Case e.Button
            Case Windows.Forms.MouseButtons.Left, Windows.Forms.MouseButtons.Right
                For Each RIR As RunInfoRect In m_RunInfoRects
                    If RIR.m_Rect.Contains(e.Location) AndAlso IsNothing(RIR.m_RunInfo) Then
                        If ((Control.ModifierKeys And Keys.Control) = 0) Then
                            If ((Control.ModifierKeys And Keys.Shift) = 0) OrElse (m_AnchorIndex < 0) Then
                                m_SelectedJobs.Clear()
                                m_SelectedJobs.Add(RIR.m_Job)


                                m_AnchorIndex = GetJobIndex(RIR.m_Job)
                            Else
                                m_SelectedJobs.Clear()

                                Dim I1 As Integer = m_AnchorIndex
                                Dim I2 As Integer = GetJobIndex(RIR.m_Job)

                                For I As Integer = Math.Min(I1, I2) To Math.Max(I1, I2)
                                    If Not m_SelectedJobs.Contains(m_Jobs(I)) Then
                                        m_SelectedJobs.Add(m_Jobs(I))
                                    End If
                                Next
                            End If
                        Else
                            If m_SelectedJobs.Contains(RIR.m_Job) Then
                                m_SelectedJobs.Remove(RIR.m_Job)
                            Else
                                m_SelectedJobs.Add(RIR.m_Job)
                            End If
                        End If

                        Me.Invalidate()
                        RaiseEvent SelectionChange()

                        Exit For
                    End If
                Next
        End Select
    End Sub

    Private Function SetTooltipText(ByVal ClearIfNowt As Boolean) As Boolean
        Dim TooltipText As String = Nothing

        For Each RIR As RunInfoRect In m_RunInfoRects
            If RIR.m_Rect.Contains(Me.PointToClient(Cursor.Position)) Then
                If Not IsNothing(RIR.m_RunInfo) Then
                    TooltipText = "Job: " & RIR.m_Job.m_Name & If(RIR.m_Job.m_Enabled, "", " (disabled)") & vbCrLf
                    TooltipText &= "Category: " & RIR.m_Job.m_Category & vbCrLf
                    TooltipText &= "Run Started: " & RIR.m_RunInfo.m_StartTime.ToString("HH:mm:ss") & vbCrLf
                    TooltipText &= "Run Duration: " & RIR.m_RunInfo.m_Duration.ToString() & vbCrLf
                    TooltipText &= "Run Clash Time: " & RIR.m_RunInfo.m_ClashTime.ToString()

                    If RIR.m_RunInfo.m_ExecInfo <> "" Then
                        TooltipText &= vbCrLf & RIR.m_RunInfo.m_ExecInfo
                    End If
                Else
                    TooltipText = "Job: " & RIR.m_Job.m_Name & If(RIR.m_Job.m_Enabled, "", " (disabled)") & vbCrLf
                    TooltipText &= "Category: " & RIR.m_Job.m_Category & vbCrLf
                    TooltipText &= "Total Job Duration: " & TimeSpan.FromSeconds(RIR.m_Job.TotalRunTimeSecs()).ToString()
                    TooltipText &= "Total Job Clash Time: " & RIR.m_Job.m_ClashTime.ToString() & vbCrLf
                End If

                Exit For
            End If
        Next

        If ClearIfNowt OrElse Not IsNothing(TooltipText) Then
            If ToolTip1.GetToolTip(Me) <> TooltipText Then
                ToolTip1.SetToolTip(Me, TooltipText)
            End If
        End If

        Return IsNothing(TooltipText)
    End Function

    Private Sub JobRunInfosViewer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If m_AnchorIndex >= 0 Then
                For Each RIR As RunInfoRect In m_RunInfoRects
                    If RIR.m_Rect.Contains(e.Location) AndAlso IsNothing(RIR.m_RunInfo) Then
                        m_SelectedJobs.Clear()

                        Dim I1 As Integer = m_AnchorIndex
                        Dim I2 As Integer = GetJobIndex(RIR.m_Job)

                        For I As Integer = Math.Min(I1, I2) To Math.Max(I1, I2)
                            If Not m_SelectedJobs.Contains(m_Jobs(I)) Then
                                m_SelectedJobs.Add(m_Jobs(I))
                            End If
                        Next

                        Me.Invalidate()

                        RaiseEvent SelectionChange()

                        Exit For
                    End If
                Next
            End If
        End If

        If SetTooltipText(False) Then
            Tmr_Tooltip.Start()
        Else
            Tmr_Tooltip.Stop()
        End If
    End Sub

    Private Sub JobRunInfosViewer_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If e.Delta <> 0 Then
            Dim NewScrollVal As Integer = VScrollBar1.Value + (-8 * Math.Sign(e.Delta))

            If NewScrollVal < VScrollBar1.Minimum Then
                NewScrollVal = VScrollBar1.Minimum
            End If

            If NewScrollVal > VScrollBar1.Maximum Then
                NewScrollVal = VScrollBar1.Maximum
            End If

            VScrollBar1.Value = NewScrollVal

            Me.Invalidate()
        End If
    End Sub

    Private Sub JobRunInfosViewer_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim RenderStartTime As DateTime = DateTime.Now
        m_RunInfoRects.Clear()

        If IsNothing(m_Jobs) OrElse (m_Jobs.Count = 0) Then
            Dim CentredDrawFormat As New StringFormat
            CentredDrawFormat.Alignment = StringAlignment.Center
            CentredDrawFormat.LineAlignment = StringAlignment.Center

            Dim BigFont As New Font(Me.Font.FontFamily, 20.0)
            Dim R As New Rectangle(20, 20, Me.ClientSize.Width - 40, Me.ClientSize.Height - 40)

            e.Graphics.DrawString(If(IsNothing(m_StatusText), "No Jobs", m_StatusText), _
                                  BigFont, Brushes.Gray, R, CentredDrawFormat)

            HScrollBar1.Visible = False
            VScrollBar1.Visible = False

            Return
        Else
            HScrollBar1.Visible = True
            VScrollBar1.Visible = True

            e.Graphics.Clear(SystemColors.Control)
            e.Graphics.SetClip(New RectangleF(0, 0, Me.ClientSize.Width - VScrollBar1.Width, Me.ClientSize.Height - HScrollBar1.Height))
            e.Graphics.Clear(Color.White)

            If Me.RowHeaderWidth <> 0 Then
                Dim TheFont As Font = Me.Font

                TheFont = New Font("Times New Roman", 9.0F, FontStyle.Italic)

                Dim SF As New StringFormat
                SF.Alignment = StringAlignment.Center
                SF.LineAlignment = StringAlignment.Center

                Dim RR As New Rectangle(0, 0, Me.RowHeaderWidth, 2 * m_RowHeight)
                e.Graphics.DrawString("Disabled jobs shown in italics", TheFont, New SolidBrush(Options.GetColour("Disabled")), RR, SF)
            End If
        End If

            Dim X As Integer = 0
            Dim Y As Integer = 0

            Dim DT As DateTime = m_StartDateTime.AddHours(HScrollBar1.Value)
            Dim BaseTime As DateTime = DT

            Dim LastX As Integer = Me.RowHeaderWidth + m_EndDateTime.Subtract(BaseTime).TotalHours * m_HourWidth

            Dim LeftCentredDrawFormat As New StringFormat
            LeftCentredDrawFormat.Alignment = StringAlignment.Near
            LeftCentredDrawFormat.LineAlignment = StringAlignment.Center
            LeftCentredDrawFormat.FormatFlags = StringFormatFlags.NoWrap
            LeftCentredDrawFormat.Trimming = StringTrimming.EllipsisCharacter

            X = 0
            Y = 2 * m_HeaderRowHeight

            For JI As Integer = VScrollBar1.Value To m_Jobs.Count - 1
                If Y < Me.ClientSize.Height Then
                    Dim J As Job = m_Jobs(JI)

                    Dim BackColour As Color
                    Dim ForeColour As Color = Color.Black

                    If m_SelectedJobs.Contains(J) Then
                        BackColour = Drawing.SystemColors.Highlight
                        ForeColour = Drawing.SystemColors.HighlightText
                    Else
                        If JI Mod 2 = 0 Then
                            BackColour = Color.White
                        Else
                            BackColour = Color.LightGray
                        End If
                    End If

                    e.Graphics.FillRectangle(New SolidBrush(BackColour), 0, Y, Math.Min(Me.ClientSize.Width, LastX), m_RowHeight)

                    Dim R As New Rectangle(X, Y, Me.RowHeaderWidth, m_RowHeight)
                    Dim RF As New RectangleF(X, Y, Me.RowHeaderWidth, m_RowHeight)

                    e.Graphics.DrawRectangle(Pens.Black, R)

                    If m_RowHeight >= 16 Then
                        Dim TheFont As Font = Me.Font

                        Dim B As New SolidBrush(ForeColour)
                        If Not J.m_Enabled Then
                            B = New SolidBrush(Options.GetColour("Disabled"))
                        TheFont = New Font("Times New Roman", 9.0F, FontStyle.Italic)
                        End If

                        e.Graphics.DrawString(J.m_Name, TheFont, B, RF, LeftCentredDrawFormat)
                    End If

                    Dim RIR As New RunInfoRect
                    RIR.m_Rect = R
                    RIR.m_Job = J
                    m_RunInfoRects.Add(RIR)

                    Y += m_RowHeight
                End If
            Next

            Dim DTS As New List(Of DateTime)(m_RunCountHash.Keys)
            DTS.Sort()

            Dim PrevRunningCount As Integer = 0
            Dim PrevDT As DateTime = DateTime.MinValue
            For Each DTChg As DateTime In DTS
                Dim Delta As Integer = m_RunCountHash(DTChg)

                If PrevDT <> DateTime.MinValue Then
                    If PrevRunningCount > 0 Then
                        Dim XS As Integer = Me.RowHeaderWidth + (PrevDT.Subtract(BaseTime).TotalHours * m_HourWidth)
                        Dim XE As Integer = Me.RowHeaderWidth + (DTChg.Subtract(BaseTime).TotalHours * m_HourWidth)
                        XS = Math.Max(Me.RowHeaderWidth, XS)
                        XE = Math.Min(LastX, XE)

                        If XS < LastX Then
                            Dim C As Color = Color.LightGreen

                            If PrevRunningCount = 2 Then
                                C = Color.Yellow
                            End If

                            If PrevRunningCount > 2 Then
                                C = Color.Pink
                            End If

                            Dim C2 As Color = Color.FromArgb(64, C)

                            e.Graphics.FillRectangle(New SolidBrush(C2), XS, m_HeaderRowHeight, XE - XS + 1, m_HeaderRowHeight)
                        End If
                    End If
                End If

                PrevRunningCount += Delta
                PrevDT = DTChg
            Next

            Dim LineHeight = (m_Jobs.Count - VScrollBar1.Value) * m_RowHeight + 2 * m_HeaderRowHeight

            Dim QuarterHoursToNextDay As Integer = 4 * 24

            If DT.Hour <> 0 OrElse DT.Minute <> 0 Then
                QuarterHoursToNextDay = 0
                Dim DT2 As DateTime = DT
                While (DT2.Hour <> 0 OrElse DT.Minute <> 0)
                    QuarterHoursToNextDay += 1
                    DT2 = DT2.AddMinutes(15.0)
                End While
            End If

            Dim TimeFormat As String = "HH:mm"
            Dim LabelNthHour As Integer = 1

            If m_HourWidth < (e.Graphics.MeasureString("88:88", Me.Font).Width + 2) Then
                TimeFormat = "HH"

                Dim Nths() As Integer = {1, 2, 4, 6, 12}

                For Each Nth As Integer In Nths
                    If Nth * m_HourWidth >= (e.Graphics.MeasureString("88", Me.Font).Width + 2) Then
                        LabelNthHour = Nth
                        Exit For
                    End If
                Next
            End If

            X = Me.RowHeaderWidth
            While DT < m_EndDateTime AndAlso X <= Math.Min(Me.ClientSize.Width, LastX)
                If (DT = BaseTime) OrElse (DT.Hour = 0 And DT.Minute = 0) Then
                    Dim Text As String = DT.ToString("d MMM yyyy (ddd)")
                    Dim TextWidth As Integer = e.Graphics.MeasureString(Text, Me.Font).Width

                    If (DT <> BaseTime) OrElse (TextWidth <= (QuarterHoursToNextDay * (m_HourWidth / 4))) Then
                        e.Graphics.DrawString(DT.ToString("d MMM yyyy (ddd)"), Me.Font, Brushes.Black, X + 2, 0)
                    End If
                End If

                If (DT.Hour = 0 And DT.Minute = 0) Then
                    e.Graphics.DrawLine(Pens.LightGray, X, 0, X, LineHeight)
                End If

                If DT.Minute = 0 Then
                    Dim StartY As Integer = If(DT.Hour = 0, 0, m_HeaderRowHeight)

                    If DT.Hour Mod LabelNthHour = 0 Then
                        If TimeFormat <> "" Then
                            e.Graphics.DrawString(DT.ToString(TimeFormat), Me.Font, Brushes.Black, X + 2, m_HeaderRowHeight)
                        End If
                    Else
                        StartY = 2 * m_HeaderRowHeight
                    End If

                    e.Graphics.DrawLine(Pens.Black, X, StartY, X, LineHeight)
                Else
                    If m_HourWidth > 4 Then
                        e.Graphics.DrawLine(Pens.DarkGray, X, 2 * m_HeaderRowHeight, X, LineHeight)
                    End If
                End If

                X += m_HourWidth / 4
                DT = DT.AddMinutes(15.0)
            End While

            e.Graphics.DrawRectangle(Pens.Black, Me.RowHeaderWidth, 0, LastX - Me.RowHeaderWidth, 2 * m_HeaderRowHeight)
            e.Graphics.DrawRectangle(Pens.Black, Me.RowHeaderWidth, 0, LastX - Me.RowHeaderWidth, LineHeight)

            X = 0
            Y = 2 * m_HeaderRowHeight

            For JI As Integer = VScrollBar1.Value To m_Jobs.Count - 1
                Dim J As Job = m_Jobs(JI)
                Dim R As New Rectangle(X, Y, Me.RowHeaderWidth, m_RowHeight)
                Dim RF As New RectangleF(X, Y, Me.RowHeaderWidth, m_RowHeight)

                If Y < Me.ClientSize.Height Then
                    For Each RI As RunInfo In J.m_RunInfos
                        Dim EndTime As DateTime = RI.m_StartTime.Add(RI.m_Duration)
                        If RI.m_StartTime < m_EndDateTime AndAlso EndTime > BaseTime Then
                            Dim XS As Integer = Me.RowHeaderWidth + (RI.m_StartTime.Subtract(BaseTime).TotalHours * m_HourWidth)

                            If XS < Me.ClientSize.Width Then
                                Dim W As Integer = Math.Max(RI.m_Duration.TotalHours * m_HourWidth, 3)

                                If XS < Me.RowHeaderWidth Then
                                    W -= Me.RowHeaderWidth - XS
                                    XS = Me.RowHeaderWidth
                                End If

                                If XS + W > LastX Then
                                    W = LastX - XS
                                End If

                                R = New Rectangle(XS, Y, W, m_RowHeight)
                                RF = New RectangleF(XS, Y, W, m_RowHeight)

                                Dim RunColour As Color = Color.Black

                                Select Case RI.m_Status
                                    Case RunStatus.Succeeded
                                        If RI.m_Duration.TotalSeconds < Options.m_LongRunningJobSecs Then
                                            RunColour = Options.GetColour("Succeeded")
                                        Else
                                            RunColour = Options.GetColour("Long Running")
                                        End If
                                    Case RunStatus.Failed
                                        RunColour = Options.GetColour("Failed")
                                    Case RunStatus.Canceled
                                        RunColour = Options.GetColour("Cancelled")
                                    Case RunStatus.InProgress
                                        RunColour = Options.GetColour("In Progress")
                                    Case RunStatus.Retried
                                        RunColour = Options.GetColour("Retried")
                                    Case Else
                                        ' Shouldn't get here.
                                End Select

                                Dim RIR As New RunInfoRect
                                RIR.m_Rect = R
                                RIR.m_Job = J
                                RIR.m_RunInfo = RI

                                m_RunInfoRects.Add(RIR)

                                Dim RC2 As Color = Color.FromArgb(224, RunColour)

                                e.Graphics.FillRectangle(New SolidBrush(RC2), R)
                            End If
                        End If
                    Next

                    Y += m_RowHeight
                End If
            Next
    End Sub

    Private Sub DoScroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll, HScrollBar1.Scroll
        Me.Invalidate()
    End Sub

    Private Sub JobRunInfosViewer_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        SetScrollBars()
    End Sub

    Private Sub Tmr_Tooltip_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tmr_Tooltip.Tick
        Tmr_Tooltip.Enabled = False
        SetTooltipText(True)
    End Sub

    Public Sub ZoomToFit()
        Dim NumHours As Integer = m_EndDateTime.Subtract(m_StartDateTime).TotalHours
        Dim WidthAvail As Integer = Me.ClientSize.Width - Me.RowHeaderWidth() - VScrollBar1.Width
        Dim DesiredHourWidth As Integer = WidthAvail \ NumHours

        While DesiredHourWidth Mod 4 <> 0
            DesiredHourWidth -= 1
        End While

        If DesiredHourWidth < 4 Then
            DesiredHourWidth = 4
        End If

        If DesiredHourWidth > 640 Then
            DesiredHourWidth = 640
        End If

        Me.HourWidth = DesiredHourWidth
    End Sub
End Class
