Imports System.Globalization
Imports SQLsoftTools

Public Class OptionsForm
    Public Sub New()
        InitializeComponent()

        Nud_WorkingDaysBack.Value = Options.m_WorkingDaysBack

        For I As Integer = 0 To 6
            Clb_WorkingDays.Items.Add(CultureInfo.CurrentCulture.DateTimeFormat.DayNames(I), Options.m_WorkingDays(I) <> "0")
        Next

        Chk_StoreSession.Checked = Options.m_StoreSession

        Nud_LongRunningJobSecs.Value = Options.m_LongRunningJobSecs
        Nud_QueryTimeoutSecs.Value = Options.m_QueryTimeoutSecs

        For Each UIC As UiColour In Options.m_Colours
            Lb_Colours.Items.Add(UIC.Clone)
        Next

        Lb_Colours.SelectedIndex = 0

        Chk_AutoRefresh.Checked = (Options.m_RefreshInterval <> 0)
        Nud_RefreshInterval.Value = If(Options.m_RefreshInterval = 0, 5 * 60, Options.m_RefreshInterval)

        Chk_DefaultZoomToFit.Checked = Options.m_ZoomToFitByDefault

        EnableUI()
    End Sub

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
        If Clb_WorkingDays.CheckedIndices.Count = 0 Then
            Me.DialogResult = Windows.Forms.DialogResult.None

            MessageBox.Show("At least one day must be selected as a working day.", "Working Day Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Options.m_WorkingDaysBack = Nud_WorkingDaysBack.Value

        Dim WorkingDays As String = ""
        For I As Integer = 0 To 6
            WorkingDays &= If(Clb_WorkingDays.CheckedIndices.Contains(I), "1", "0")
        Next

        Options.m_WorkingDays = WorkingDays
        Options.m_StoreSession = Chk_StoreSession.Checked
        Options.m_LongRunningJobSecs = Nud_LongRunningJobSecs.Value
        Options.m_QueryTimeoutSecs = Nud_QueryTimeoutSecs.Value

        For Each UIC As UiColour In Options.m_Colours
            For Each UIC2 As UiColour In Lb_Colours.Items
                If UIC2.m_Name = UIC.m_Name Then
                    UIC.m_Colour = UIC2.m_Colour
                End If
            Next
        Next

        If Chk_AutoRefresh.Checked Then
            Options.m_RefreshInterval = Nud_RefreshInterval.Value
        Else
            Options.m_RefreshInterval = 0
        End If

        Options.m_ZoomToFitByDefault = Chk_DefaultZoomToFit.Checked
    End Sub

    Private Sub Lb_Colours_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Lb_Colours.DrawItem
        If (e.State And DrawItemState.Selected) = 0 Then
            e.Graphics.FillRectangle(Drawing.SystemBrushes.Window, e.Bounds)
        Else
            e.Graphics.FillRectangle(Drawing.SystemBrushes.Highlight, e.Bounds)
        End If
        Dim UIC As UiColour = Lb_Colours.Items(e.Index)

        Dim SF As New StringFormat
        SF.Alignment = StringAlignment.Center
        SF.LineAlignment = StringAlignment.Center

        Dim R As Rectangle = e.Bounds
        R.Offset(150, 0)
        R.Intersect(e.Bounds)

        If UIC.m_IsText Then
            e.Graphics.FillRectangle(Brushes.White, R)
            e.Graphics.DrawString("ABC", Me.Font, New SolidBrush(UIC.m_Colour), R, SF)
        Else
            e.Graphics.FillRectangle(New SolidBrush(UIC.m_Colour), R)
        End If
        Dim BoldFont As New Font(Me.Font, FontStyle.Bold)
        Dim SF2 As New StringFormat
        SF2.Alignment = StringAlignment.Near
        SF2.LineAlignment = StringAlignment.Center
        If (e.State And DrawItemState.Selected) = 0 Then
            e.Graphics.DrawString(UIC.m_Name, BoldFont, Drawing.SystemBrushes.WindowText, e.Bounds, SF2)
        Else
            e.Graphics.DrawString(UIC.m_Name, BoldFont, Drawing.SystemBrushes.HighlightText, e.Bounds, SF2)
        End If

        If (e.State And DrawItemState.Focus) Then
            e.DrawFocusRectangle()
        End If
    End Sub

    Private Sub EditColour()
        Dim UIC As UiColour = Lb_Colours.SelectedItem

        Cd_Colour.Color = UIC.m_Colour
        If Cd_Colour.ShowDialog() = Windows.Forms.DialogResult.OK Then
            UIC.m_Colour = Cd_Colour.Color
            Lb_Colours.Invalidate()
        End If
    End Sub

    Private Sub Btn_EditColour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EditColour.Click
        EditColour()
    End Sub

    Private Sub Lb_Colours_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Lb_Colours.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            EditColour()
        End If
    End Sub

    Private Sub EnableUI()
        Nud_RefreshInterval.Enabled = Chk_AutoRefresh.Checked
        Lbl_AutoRefresh.Enabled = Chk_AutoRefresh.Checked
    End Sub

    Private Sub Chk_AutoRefresh_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_AutoRefresh.CheckedChanged
        EnableUI()
    End Sub

    Private Sub Btn_RevertToDefaultColours_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_RevertToDefaultColours.Click
        Lb_Colours.Items.Clear()

        For Each UIC As UiColour In Options.GetDefaultColours()
            Lb_Colours.Items.Add(UIC)
        Next
    End Sub
End Class