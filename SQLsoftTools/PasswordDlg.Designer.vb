<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordDlg
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
        Me.Lbl_EnterPwd = New System.Windows.Forms.Label
        Me.Txt_Password = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Btn_OK
        '
        Me.Btn_OK.Location = New System.Drawing.Point(302, 65)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.Btn_OK.TabIndex = 2
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancel.Location = New System.Drawing.Point(383, 65)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancel.TabIndex = 3
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Lbl_EnterPwd
        '
        Me.Lbl_EnterPwd.AutoSize = True
        Me.Lbl_EnterPwd.Location = New System.Drawing.Point(13, 13)
        Me.Lbl_EnterPwd.Name = "Lbl_EnterPwd"
        Me.Lbl_EnterPwd.Size = New System.Drawing.Size(39, 13)
        Me.Lbl_EnterPwd.TabIndex = 0
        Me.Lbl_EnterPwd.Text = "Label1"
        '
        'Txt_Password
        '
        Me.Txt_Password.Location = New System.Drawing.Point(16, 30)
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txt_Password.Size = New System.Drawing.Size(442, 20)
        Me.Txt_Password.TabIndex = 1
        '
        'PasswordDlg
        '
        Me.AcceptButton = Me.Btn_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancel
        Me.ClientSize = New System.Drawing.Size(470, 99)
        Me.Controls.Add(Me.Txt_Password)
        Me.Controls.Add(Me.Lbl_EnterPwd)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_OK)
        Me.Name = "PasswordDlg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Password Required"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Lbl_EnterPwd As System.Windows.Forms.Label
    Friend WithEvents Txt_Password As System.Windows.Forms.TextBox
End Class
