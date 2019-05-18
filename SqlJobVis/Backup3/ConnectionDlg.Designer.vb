<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConnectionDlg
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Server = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Cbo_Authentication = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Username = New System.Windows.Forms.TextBox
        Me.Txt_Password = New System.Windows.Forms.TextBox
        Me.Btn_OK = New System.Windows.Forms.Button
        Me.Btn_Cancel = New System.Windows.Forms.Button
        Me.Chk_RememberPassword = New System.Windows.Forms.CheckBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Cbo_Database = New System.Windows.Forms.ComboBox
        Me.Lbl_PopulatingDatabases = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "&Server name:"
        '
        'Txt_Server
        '
        Me.Txt_Server.Location = New System.Drawing.Point(102, 10)
        Me.Txt_Server.Name = "Txt_Server"
        Me.Txt_Server.Size = New System.Drawing.Size(285, 21)
        Me.Txt_Server.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "&Authentication:"
        '
        'Cbo_Authentication
        '
        Me.Cbo_Authentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cbo_Authentication.FormattingEnabled = True
        Me.Cbo_Authentication.Items.AddRange(New Object() {"Windows Authentication", "SQL Server Authentication"})
        Me.Cbo_Authentication.Location = New System.Drawing.Point(102, 36)
        Me.Cbo_Authentication.Name = "Cbo_Authentication"
        Me.Cbo_Authentication.Size = New System.Drawing.Size(285, 21)
        Me.Cbo_Authentication.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "&Password:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "&User name:"
        '
        'Txt_Username
        '
        Me.Txt_Username.Location = New System.Drawing.Point(117, 66)
        Me.Txt_Username.Name = "Txt_Username"
        Me.Txt_Username.Size = New System.Drawing.Size(270, 21)
        Me.Txt_Username.TabIndex = 5
        '
        'Txt_Password
        '
        Me.Txt_Password.Location = New System.Drawing.Point(117, 93)
        Me.Txt_Password.Name = "Txt_Password"
        Me.Txt_Password.Size = New System.Drawing.Size(270, 21)
        Me.Txt_Password.TabIndex = 7
        Me.Txt_Password.UseSystemPasswordChar = True
        '
        'Btn_OK
        '
        Me.Btn_OK.Location = New System.Drawing.Point(231, 180)
        Me.Btn_OK.Name = "Btn_OK"
        Me.Btn_OK.Size = New System.Drawing.Size(75, 23)
        Me.Btn_OK.TabIndex = 11
        Me.Btn_OK.Text = "OK"
        Me.Btn_OK.UseVisualStyleBackColor = True
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Cancel.Location = New System.Drawing.Point(312, 180)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.Btn_Cancel.TabIndex = 12
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Chk_RememberPassword
        '
        Me.Chk_RememberPassword.AutoSize = True
        Me.Chk_RememberPassword.Location = New System.Drawing.Point(119, 120)
        Me.Chk_RememberPassword.Name = "Chk_RememberPassword"
        Me.Chk_RememberPassword.Size = New System.Drawing.Size(126, 17)
        Me.Chk_RememberPassword.TabIndex = 8
        Me.Chk_RememberPassword.Text = "&Remember password"
        Me.Chk_RememberPassword.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "&Database:"
        '
        'Cbo_Database
        '
        Me.Cbo_Database.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Cbo_Database.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Cbo_Database.FormattingEnabled = True
        Me.Cbo_Database.Location = New System.Drawing.Point(102, 143)
        Me.Cbo_Database.Name = "Cbo_Database"
        Me.Cbo_Database.Size = New System.Drawing.Size(285, 21)
        Me.Cbo_Database.TabIndex = 10
        '
        'Lbl_PopulatingDatabases
        '
        Me.Lbl_PopulatingDatabases.AutoSize = True
        Me.Lbl_PopulatingDatabases.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_PopulatingDatabases.ForeColor = System.Drawing.Color.ForestGreen
        Me.Lbl_PopulatingDatabases.Location = New System.Drawing.Point(13, 185)
        Me.Lbl_PopulatingDatabases.Name = "Lbl_PopulatingDatabases"
        Me.Lbl_PopulatingDatabases.Size = New System.Drawing.Size(156, 13)
        Me.Lbl_PopulatingDatabases.TabIndex = 13
        Me.Lbl_PopulatingDatabases.Text = "Populating Database List..."
        Me.Lbl_PopulatingDatabases.Visible = False
        '
        'ConnectionDlg
        '
        Me.AcceptButton = Me.Btn_OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Cancel
        Me.ClientSize = New System.Drawing.Size(399, 212)
        Me.Controls.Add(Me.Lbl_PopulatingDatabases)
        Me.Controls.Add(Me.Cbo_Database)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Chk_RememberPassword)
        Me.Controls.Add(Me.Btn_Cancel)
        Me.Controls.Add(Me.Btn_OK)
        Me.Controls.Add(Me.Txt_Password)
        Me.Controls.Add(Me.Txt_Username)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Cbo_Authentication)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Server)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ConnectionDlg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Server As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Authentication As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Txt_Username As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Password As System.Windows.Forms.TextBox
    Friend WithEvents Btn_OK As System.Windows.Forms.Button
    Friend WithEvents Btn_Cancel As System.Windows.Forms.Button
    Friend WithEvents Chk_RememberPassword As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Cbo_Database As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_PopulatingDatabases As System.Windows.Forms.Label
End Class
