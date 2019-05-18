<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewConnectionMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetDateRangeMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomToFitMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Tmr_Refresh = New System.Windows.Forms.Timer(Me.components)
        Me.WindowManagerPanel1 = New MDIWindowManager.WindowManagerPanel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ConnectionComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.NewConnectionButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ColumnSizeComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.RowSizeComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.SortComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.RefreshButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.FilterButton = New System.Windows.Forms.ToolStripButton()
        Me.Ss_Status = New System.Windows.Forms.StatusStrip()
        Me.Sl_JobCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Ss_Status.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.ToolsMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1016, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewConnectionMenuItem, Me.ToolStripSeparator7, Me.ExportMenuItem, Me.ToolStripSeparator3, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'NewConnectionMenuItem
        '
        Me.NewConnectionMenuItem.Name = "NewConnectionMenuItem"
        Me.NewConnectionMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NewConnectionMenuItem.Text = "New &Connection..."
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(169, 6)
        '
        'ExportMenuItem
        '
        Me.ExportMenuItem.Enabled = False
        Me.ExportMenuItem.Name = "ExportMenuItem"
        Me.ExportMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ExportMenuItem.Text = "&Export..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(169, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetDateRangeMenuItem, Me.ToolStripSeparator6, Me.ZoomToFitMenuItem, Me.ToolStripSeparator5, Me.RefreshToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'SetDateRangeMenuItem
        '
        Me.SetDateRangeMenuItem.Enabled = False
        Me.SetDateRangeMenuItem.Name = "SetDateRangeMenuItem"
        Me.SetDateRangeMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SetDateRangeMenuItem.Text = "Set &Date Range..."
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(159, 6)
        '
        'ZoomToFitMenuItem
        '
        Me.ZoomToFitMenuItem.Enabled = False
        Me.ZoomToFitMenuItem.Name = "ZoomToFitMenuItem"
        Me.ZoomToFitMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ZoomToFitMenuItem.Text = "&Zoom to Fit"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(159, 6)
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Enabled = False
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.RefreshToolStripMenuItem.Text = "&Refresh"
        '
        'ToolsMenuItem
        '
        Me.ToolsMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem})
        Me.ToolsMenuItem.Name = "ToolsMenuItem"
        Me.ToolsMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsMenuItem.Text = "&Tools"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(125, 22)
        Me.OptionsToolStripMenuItem.Text = "&Options..."
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.AboutToolStripMenuItem.Text = "&About SqlJobVis"
        '
        'Tmr_Refresh
        '
        '
        'WindowManagerPanel1
        '
        Me.WindowManagerPanel1.AllowUserVerticalRepositioning = False
        Me.WindowManagerPanel1.AutoDetectMdiChildWindows = True
        Me.WindowManagerPanel1.AutoHide = False
        Me.WindowManagerPanel1.ButtonRenderMode = MDIWindowManager.ButtonRenderMode.Standard
        Me.WindowManagerPanel1.DisableCloseAction = False
        Me.WindowManagerPanel1.DisableHTileAction = True
        Me.WindowManagerPanel1.DisablePopoutAction = True
        Me.WindowManagerPanel1.DisableTileAction = True
        Me.WindowManagerPanel1.EnableTabPaintEvent = False
        Me.WindowManagerPanel1.Location = New System.Drawing.Point(2, 65)
        Me.WindowManagerPanel1.MinMode = False
        Me.WindowManagerPanel1.Name = "WindowManagerPanel1"
        Me.WindowManagerPanel1.Orientation = MDIWindowManager.WindowManagerOrientation.Top
        Me.WindowManagerPanel1.ShowCloseButton = True
        Me.WindowManagerPanel1.ShowIcons = True
        Me.WindowManagerPanel1.ShowLayoutButtons = False
        Me.WindowManagerPanel1.ShowTitle = False
        Me.WindowManagerPanel1.Size = New System.Drawing.Size(1012, 28)
        Me.WindowManagerPanel1.Style = MDIWindowManager.TabStyle.ModernTabs
        Me.WindowManagerPanel1.TabIndex = 6
        Me.WindowManagerPanel1.TabRenderMode = MDIWindowManager.TabsProvider.Standard
        Me.WindowManagerPanel1.Text = "WindowManagerPanel1"
        Me.WindowManagerPanel1.TitleBackColor = System.Drawing.SystemColors.ControlDark
        Me.WindowManagerPanel1.TitleForeColor = System.Drawing.SystemColors.ControlLightLight
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripLabel5.Text = "&Connection:"
        '
        'ConnectionComboBox
        '
        Me.ConnectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ConnectionComboBox.Name = "ConnectionComboBox"
        Me.ConnectionComboBox.Size = New System.Drawing.Size(121, 39)
        '
        'NewConnectionButton
        '
        Me.NewConnectionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewConnectionButton.Image = CType(resources.GetObject("NewConnectionButton.Image"), System.Drawing.Image)
        Me.NewConnectionButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewConnectionButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewConnectionButton.Name = "NewConnectionButton"
        Me.NewConnectionButton.Size = New System.Drawing.Size(28, 36)
        Me.NewConnectionButton.Text = "New Connection..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ColumnSizeComboBox
        '
        Me.ColumnSizeComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ColumnSizeComboBox.Enabled = False
        Me.ColumnSizeComboBox.Items.AddRange(New Object() {"12.5%", "25%", "50%", "75%", "100%", "200%", "400%"})
        Me.ColumnSizeComboBox.Margin = New System.Windows.Forms.Padding(1, 0, 15, 0)
        Me.ColumnSizeComboBox.Name = "ColumnSizeComboBox"
        Me.ColumnSizeComboBox.Size = New System.Drawing.Size(75, 39)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(88, 36)
        Me.ToolStripLabel2.Text = "Column &Width:"
        '
        'RowSizeComboBox
        '
        Me.RowSizeComboBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.RowSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RowSizeComboBox.Enabled = False
        Me.RowSizeComboBox.Items.AddRange(New Object() {"25%", "50%", "75%", "100%"})
        Me.RowSizeComboBox.Name = "RowSizeComboBox"
        Me.RowSizeComboBox.Size = New System.Drawing.Size(75, 39)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(30, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(72, 36)
        Me.ToolStripLabel1.Text = "&Row Height:"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Margin = New System.Windows.Forms.Padding(5, 1, 0, 2)
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(31, 36)
        Me.ToolStripLabel3.Text = "&Sort:"
        '
        'SortComboBox
        '
        Me.SortComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SortComboBox.Enabled = False
        Me.SortComboBox.Items.AddRange(New Object() {"Job Name (asc)", "Total Run Time (desc)", "Frequency (desc)", "Time Clashing (desc)", "Earliest Start Time (asc)"})
        Me.SortComboBox.Name = "SortComboBox"
        Me.SortComboBox.Size = New System.Drawing.Size(135, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'RefreshButton
        '
        Me.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.RefreshButton.Enabled = False
        Me.RefreshButton.Image = CType(resources.GetObject("RefreshButton.Image"), System.Drawing.Image)
        Me.RefreshButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.RefreshButton.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(28, 36)
        Me.RefreshButton.Text = "Refresh"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ZoomButton
        '
        Me.ZoomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomButton.Enabled = False
        Me.ZoomButton.Image = CType(resources.GetObject("ZoomButton.Image"), System.Drawing.Image)
        Me.ZoomButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomButton.Name = "ZoomButton"
        Me.ZoomButton.Size = New System.Drawing.Size(36, 36)
        Me.ZoomButton.Text = "Zoom to Fit"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5, Me.ConnectionComboBox, Me.NewConnectionButton, Me.ToolStripSeparator1, Me.ColumnSizeComboBox, Me.ToolStripLabel2, Me.RowSizeComboBox, Me.ToolStripLabel1, Me.FilterButton, Me.ToolStripLabel3, Me.SortComboBox, Me.ToolStripSeparator2, Me.RefreshButton, Me.ToolStripSeparator4, Me.ZoomButton})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1016, 39)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'FilterButton
        '
        Me.FilterButton.AutoSize = False
        Me.FilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.FilterButton.Image = CType(resources.GetObject("FilterButton.Image"), System.Drawing.Image)
        Me.FilterButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.FilterButton.Name = "FilterButton"
        Me.FilterButton.Size = New System.Drawing.Size(150, 36)
        Me.FilterButton.Text = "Fi&lter: (none)"
        '
        'Ss_Status
        '
        Me.Ss_Status.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Sl_JobCount})
        Me.Ss_Status.Location = New System.Drawing.Point(0, 712)
        Me.Ss_Status.Name = "Ss_Status"
        Me.Ss_Status.Size = New System.Drawing.Size(1016, 22)
        Me.Ss_Status.TabIndex = 8
        Me.Ss_Status.Text = "StatusStrip1"
        '
        'Sl_JobCount
        '
        Me.Sl_JobCount.Name = "Sl_JobCount"
        Me.Sl_JobCount.Size = New System.Drawing.Size(39, 17)
        Me.Sl_JobCount.Text = "Ready"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.Controls.Add(Me.Ss_Status)
        Me.Controls.Add(Me.WindowManagerPanel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SQLjobvis 3.0"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Ss_Status.ResumeLayout(False)
        Me.Ss_Status.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetDateRangeMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolsMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Tmr_Refresh As System.Windows.Forms.Timer
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZoomToFitMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewConnectionMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WindowManagerPanel1 As MDIWindowManager.WindowManagerPanel
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ConnectionComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents NewConnectionButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ColumnSizeComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents RowSizeComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SortComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RefreshButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ZoomButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents FilterButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Ss_Status As System.Windows.Forms.StatusStrip
    Friend WithEvents Sl_JobCount As System.Windows.Forms.ToolStripStatusLabel

End Class
