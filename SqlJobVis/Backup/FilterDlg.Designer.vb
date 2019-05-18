<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FilterDlg
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
        Me.Clb_Filters = New System.Windows.Forms.CheckedListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Btn_OK = New System.Windows.Forms.Button
        Me.Chk_HideInactive = New System.Windows.Forms.CheckBox
        Me.Chk_HideDisabled = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Clb_Filters
        '
        Me.Clb_Filters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Clb_Filters.CheckOnClick = True
        Me.Clb_Filters.FormattingEnabled = True
        Me.Clb_Filters.IntegralHeight = False
        Me.Clb_Filters.Location = New System.Drawing.Point(5, 28)
        Me.Clb_Filters.Name = "Clb_Filters"
        Me.Clb_Filters.Size = New System.Drawing.Size(181, 95)
        Me.Clb_Filters.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Show jobs that meet all:"
        '
        'Btn_OK
        '
        Me.Btn_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Btn_OK.Location = New System.Drawing.Point(111, 184)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 24)
        Me.Btn_OK.TabIndex = 2
        Me.Btn_OK.Text = "Close"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Chk_HideInactive
        '
        Me.Chk_HideInactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_HideInactive.AutoSize = True
        Me.Chk_HideInactive.Location = New System.Drawing.Point(5, 152)
        Me.Chk_HideInactive.Name = "Chk_HideInactive"
        Me.Chk_HideInactive.Size = New System.Drawing.Size(110, 17)
        Me.Chk_HideInactive.TabIndex = 3
        Me.Chk_HideInactive.Text = "Hide inactive jobs"
        Me.Chk_HideInactive.UseVisualStyleBackColor = True
        '
        'Chk_HideDisabled
        '
        Me.Chk_HideDisabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Chk_HideDisabled.AutoSize = True
        Me.Chk_HideDisabled.Location = New System.Drawing.Point(5, 129)
        Me.Chk_HideDisabled.Name = "Chk_HideDisabled"
        Me.Chk_HideDisabled.Size = New System.Drawing.Size(112, 17)
        Me.Chk_HideDisabled.TabIndex = 4
        Me.Chk_HideDisabled.Text = "Hide disabled jobs"
        Me.Chk_HideDisabled.UseVisualStyleBackColor = True
        '
        'FilterDlg
        '
        Me.AcceptButton = Me.Btn_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(192, 215)
        Me.ControlBox = False
        Me.Controls.Add(Me.Chk_HideDisabled)
        Me.Controls.Add(Me.Chk_HideInactive)
        Me.Controls.Add(Me.Btn_OK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Clb_Filters)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FilterDlg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Job Filters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Clb_Filters As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Chk_HideInactive As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_HideDisabled As System.Windows.Forms.CheckBox
End Class
