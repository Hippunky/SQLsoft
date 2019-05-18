<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Btn_OK = New System.Windows.Forms.Button
        Me.Btn_Cancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Nud_WorkingDaysBack = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Clb_WorkingDays = New System.Windows.Forms.CheckedListBox
        Me.Chk_StoreSession = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Nud_LongRunningJobSecs = New System.Windows.Forms.NumericUpDown
        Me.Label5 = New System.Windows.Forms.Label
        Me.Lb_Colours = New System.Windows.Forms.ListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Btn_EditColour = New System.Windows.Forms.Button
        Me.Cd_Colour = New System.Windows.Forms.ColorDialog
        Me.Lbl_AutoRefresh = New System.Windows.Forms.Label
        Me.Nud_RefreshInterval = New System.Windows.Forms.NumericUpDown
        Me.Chk_AutoRefresh = New System.Windows.Forms.CheckBox
        Me.Btn_RevertToDefaultColours = New System.Windows.Forms.Button
        Me.Chk_DefaultZoomToFit = New System.Windows.Forms.CheckBox
        CType(Me.Nud_WorkingDaysBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_LongRunningJobSecs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Nud_RefreshInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_OK
        '
        Me.Btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Btn_OK.Location = New System.Drawing.Point(337, 398)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.Btn_OK.TabIndex = 12
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancel.Location = New System.Drawing.Point(418, 398)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancel.TabIndex = 13
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Default start &date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "working days in the past"
        '
        'Nud_WorkingDaysBack
        '
        Me.Nud_WorkingDaysBack.Location = New System.Drawing.Point(16, 30)
        Me.Nud_WorkingDaysBack.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Nud_WorkingDaysBack.Name = "Nud_WorkingDaysBack"
        Me.Nud_WorkingDaysBack.Size = New System.Drawing.Size(49, 21)
        Me.Nud_WorkingDaysBack.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "&Working days:"
        '
        'Clb_WorkingDays
        '
        Me.Clb_WorkingDays.CheckOnClick = True
        Me.Clb_WorkingDays.FormattingEnabled = True
        Me.Clb_WorkingDays.Location = New System.Drawing.Point(13, 77)
        Me.Clb_WorkingDays.Name = "Clb_WorkingDays"
        Me.Clb_WorkingDays.Size = New System.Drawing.Size(264, 132)
        Me.Clb_WorkingDays.TabIndex = 4
        '
        'Chk_StoreSession
        '
        Me.Chk_StoreSession.AutoSize = True
        Me.Chk_StoreSession.Location = New System.Drawing.Point(13, 227)
        Me.Chk_StoreSession.Name = "Chk_StoreSession"
        Me.Chk_StoreSession.Size = New System.Drawing.Size(250, 17)
        Me.Chk_StoreSession.TabIndex = 5
        Me.Chk_StoreSession.Text = "&Remember open windows between invocations"
        Me.Chk_StoreSession.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "&Long-running job duration:"
        '
        'Nud_LongRunningJobSecs
        '
        Me.Nud_LongRunningJobSecs.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.Nud_LongRunningJobSecs.Location = New System.Drawing.Point(13, 279)
        Me.Nud_LongRunningJobSecs.Maximum = New Decimal(New Integer() {7200, 0, 0, 0})
        Me.Nud_LongRunningJobSecs.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Nud_LongRunningJobSecs.Name = "Nud_LongRunningJobSecs"
        Me.Nud_LongRunningJobSecs.Size = New System.Drawing.Size(52, 21)
        Me.Nud_LongRunningJobSecs.TabIndex = 7
        Me.Nud_LongRunningJobSecs.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 281)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "seconds"
        '
        'Lb_Colours
        '
        Me.Lb_Colours.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Lb_Colours.FormattingEnabled = True
        Me.Lb_Colours.IntegralHeight = False
        Me.Lb_Colours.ItemHeight = 24
        Me.Lb_Colours.Location = New System.Drawing.Point(301, 29)
        Me.Lb_Colours.Name = "Lb_Colours"
        Me.Lb_Colours.Size = New System.Drawing.Size(188, 180)
        Me.Lb_Colours.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(298, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "&Colours:"
        '
        'Btn_EditColour
        '
        Me.Btn_EditColour.Location = New System.Drawing.Point(439, 215)
        Me.Btn_EditColour.Name = "Btn_EditColour"
        Me.Btn_EditColour.Size = New System.Drawing.Size(50, 23)
        Me.Btn_EditColour.TabIndex = 11
        Me.Btn_EditColour.Text = "Edi&t..."
        Me.Btn_EditColour.UseVisualStyleBackColor = True
        '
        'Cd_Colour
        '
        Me.Cd_Colour.AnyColor = True
        Me.Cd_Colour.SolidColorOnly = True
        '
        'Lbl_AutoRefresh
        '
        Me.Lbl_AutoRefresh.AutoSize = True
        Me.Lbl_AutoRefresh.Location = New System.Drawing.Point(95, 342)
        Me.Lbl_AutoRefresh.Name = "Lbl_AutoRefresh"
        Me.Lbl_AutoRefresh.Size = New System.Drawing.Size(140, 13)
        Me.Lbl_AutoRefresh.TabIndex = 16
        Me.Lbl_AutoRefresh.Text = "seconds between refreshes"
        '
        'Nud_RefreshInterval
        '
        Me.Nud_RefreshInterval.Increment = New Decimal(New Integer() {15, 0, 0, 0})
        Me.Nud_RefreshInterval.Location = New System.Drawing.Point(37, 340)
        Me.Nud_RefreshInterval.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.Nud_RefreshInterval.Minimum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.Nud_RefreshInterval.Name = "Nud_RefreshInterval"
        Me.Nud_RefreshInterval.Size = New System.Drawing.Size(52, 21)
        Me.Nud_RefreshInterval.TabIndex = 15
        Me.Nud_RefreshInterval.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Chk_AutoRefresh
        '
        Me.Chk_AutoRefresh.AutoSize = True
        Me.Chk_AutoRefresh.Location = New System.Drawing.Point(13, 319)
        Me.Chk_AutoRefresh.Name = "Chk_AutoRefresh"
        Me.Chk_AutoRefresh.Size = New System.Drawing.Size(88, 17)
        Me.Chk_AutoRefresh.TabIndex = 17
        Me.Chk_AutoRefresh.Text = "&Auto-refresh"
        Me.Chk_AutoRefresh.UseVisualStyleBackColor = True
        '
        'Btn_RevertToDefaultColours
        '
        Me.Btn_RevertToDefaultColours.Location = New System.Drawing.Point(301, 215)
        Me.Btn_RevertToDefaultColours.Name = "Btn_RevertToDefaultColours"
        Me.Btn_RevertToDefaultColours.Size = New System.Drawing.Size(111, 23)
        Me.Btn_RevertToDefaultColours.TabIndex = 18
        Me.Btn_RevertToDefaultColours.Text = "Revert to Defaults"
        Me.Btn_RevertToDefaultColours.UseVisualStyleBackColor = True
        '
        'Chk_DefaultZoomToFit
        '
        Me.Chk_DefaultZoomToFit.AutoSize = True
        Me.Chk_DefaultZoomToFit.Location = New System.Drawing.Point(301, 261)
        Me.Chk_DefaultZoomToFit.Name = "Chk_DefaultZoomToFit"
        Me.Chk_DefaultZoomToFit.Size = New System.Drawing.Size(130, 17)
        Me.Chk_DefaultZoomToFit.TabIndex = 19
        Me.Chk_DefaultZoomToFit.Text = "Default to &zoom-to-fit"
        Me.Chk_DefaultZoomToFit.UseVisualStyleBackColor = True
        '
        'OptionsForm
        '
        Me.AcceptButton = Me.Btn_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancel
        Me.ClientSize = New System.Drawing.Size(505, 430)
        Me.Controls.Add(Me.Chk_DefaultZoomToFit)
        Me.Controls.Add(Me.Btn_RevertToDefaultColours)
        Me.Controls.Add(Me.Chk_AutoRefresh)
        Me.Controls.Add(Me.Lbl_AutoRefresh)
        Me.Controls.Add(Me.Nud_RefreshInterval)
        Me.Controls.Add(Me.Btn_EditColour)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Lb_Colours)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Nud_LongRunningJobSecs)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Chk_StoreSession)
        Me.Controls.Add(Me.Clb_WorkingDays)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Nud_WorkingDaysBack)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_OK)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        CType(Me.Nud_WorkingDaysBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_LongRunningJobSecs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Nud_RefreshInterval, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Nud_WorkingDaysBack As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Clb_WorkingDays As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_StoreSession As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Nud_LongRunningJobSecs As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Lb_Colours As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Btn_EditColour As System.Windows.Forms.Button
    Friend WithEvents Cd_Colour As System.Windows.Forms.ColorDialog
    Friend WithEvents Lbl_AutoRefresh As System.Windows.Forms.Label
    Friend WithEvents Nud_RefreshInterval As System.Windows.Forms.NumericUpDown
    Friend WithEvents Chk_AutoRefresh As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_RevertToDefaultColours As System.Windows.Forms.Button
    Friend WithEvents Chk_DefaultZoomToFit As System.Windows.Forms.CheckBox
End Class
