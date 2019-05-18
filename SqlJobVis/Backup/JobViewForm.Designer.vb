<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobViewForm
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
        Me.Sfd_Export = New System.Windows.Forms.SaveFileDialog
        Me.JobRunInfosViewer1 = New SqlJobVis.JobRunInfosViewer
        Me.SuspendLayout()
        '
        'Sfd_Export
        '
        Me.Sfd_Export.DefaultExt = "csv"
        Me.Sfd_Export.Filter = "Comma-separated files|*.csv|Tab-separated files|*.txt"
        Me.Sfd_Export.Title = "Export Job Run Information to Flat File"
        '
        'JobRunInfosViewer1
        '
        Me.JobRunInfosViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.JobRunInfosViewer1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.JobRunInfosViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.JobRunInfosViewer1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.JobRunInfosViewer1.HourWidth = 60
        Me.JobRunInfosViewer1.Jobs = Nothing
        Me.JobRunInfosViewer1.Location = New System.Drawing.Point(6, 6)
        Me.JobRunInfosViewer1.Name = "JobRunInfosViewer1"
        Me.JobRunInfosViewer1.RowZoomLevel = 1
        Me.JobRunInfosViewer1.Size = New System.Drawing.Size(913, 521)
        Me.JobRunInfosViewer1.StatusText = Nothing
        Me.JobRunInfosViewer1.TabIndex = 1
        '
        'JobViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(925, 533)
        Me.Controls.Add(Me.JobRunInfosViewer1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "JobViewForm"
        Me.Text = "JobViewForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents JobRunInfosViewer1 As SqlJobVis.JobRunInfosViewer
    Friend WithEvents Sfd_Export As System.Windows.Forms.SaveFileDialog
End Class
