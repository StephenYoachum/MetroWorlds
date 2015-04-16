<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtChat = New System.Windows.Forms.TextBox()
        Me.radMode1 = New System.Windows.Forms.RadioButton()
        Me.radMode2 = New System.Windows.Forms.RadioButton()
        Me.radMode3 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.selAvatar = New System.Windows.Forms.ComboBox()
        Me.txtSend = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlwaysOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGetAllText = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtChat
        '
        Me.txtChat.BackColor = System.Drawing.SystemColors.Window
        Me.txtChat.Location = New System.Drawing.Point(12, 57)
        Me.txtChat.Multiline = True
        Me.txtChat.Name = "txtChat"
        Me.txtChat.ReadOnly = True
        Me.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChat.Size = New System.Drawing.Size(580, 211)
        Me.txtChat.TabIndex = 0
        '
        'radMode1
        '
        Me.radMode1.Appearance = System.Windows.Forms.Appearance.Button
        Me.radMode1.Checked = True
        Me.radMode1.Location = New System.Drawing.Point(465, 271)
        Me.radMode1.Name = "radMode1"
        Me.radMode1.Size = New System.Drawing.Size(46, 24)
        Me.radMode1.TabIndex = 4
        Me.radMode1.TabStop = True
        Me.radMode1.Text = "Speak"
        Me.radMode1.UseVisualStyleBackColor = True
        '
        'radMode2
        '
        Me.radMode2.Appearance = System.Windows.Forms.Appearance.Button
        Me.radMode2.Location = New System.Drawing.Point(510, 271)
        Me.radMode2.Name = "radMode2"
        Me.radMode2.Size = New System.Drawing.Size(46, 24)
        Me.radMode2.TabIndex = 5
        Me.radMode2.Text = "Think"
        Me.radMode2.UseVisualStyleBackColor = True
        '
        'radMode3
        '
        Me.radMode3.Appearance = System.Windows.Forms.Appearance.Button
        Me.radMode3.Location = New System.Drawing.Point(555, 271)
        Me.radMode3.Name = "radMode3"
        Me.radMode3.Size = New System.Drawing.Size(37, 24)
        Me.radMode3.TabIndex = 6
        Me.radMode3.Text = "ESP"
        Me.radMode3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 274)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "To:"
        '
        'selAvatar
        '
        Me.selAvatar.FormattingEnabled = True
        Me.selAvatar.Location = New System.Drawing.Point(34, 271)
        Me.selAvatar.Name = "selAvatar"
        Me.selAvatar.Size = New System.Drawing.Size(135, 21)
        Me.selAvatar.TabIndex = 8
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(170, 271)
        Me.txtSend.Multiline = True
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(294, 20)
        Me.txtSend.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.WindowToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(604, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlwaysOnTopToolStripMenuItem})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "Window"
        '
        'AlwaysOnTopToolStripMenuItem
        '
        Me.AlwaysOnTopToolStripMenuItem.Name = "AlwaysOnTopToolStripMenuItem"
        Me.AlwaysOnTopToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AlwaysOnTopToolStripMenuItem.Text = "Always On Top"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'btnGetAllText
        '
        Me.btnGetAllText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetAllText.Location = New System.Drawing.Point(395, 31)
        Me.btnGetAllText.Name = "btnGetAllText"
        Me.btnGetAllText.Size = New System.Drawing.Size(197, 23)
        Me.btnGetAllText.TabIndex = 14
        Me.btnGetAllText.Text = "Capture Chat"
        Me.btnGetAllText.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(357, 20)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "MetroWorlds' Developer API Demonstration"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 300)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGetAllText)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.selAvatar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.radMode3)
        Me.Controls.Add(Me.radMode2)
        Me.Controls.Add(Me.radMode1)
        Me.Controls.Add(Me.txtChat)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.Text = "MetroWorlds Developer API Demonstration"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtChat As System.Windows.Forms.TextBox
    Friend WithEvents radMode1 As System.Windows.Forms.RadioButton
    Friend WithEvents radMode2 As System.Windows.Forms.RadioButton
    Friend WithEvents radMode3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents selAvatar As System.Windows.Forms.ComboBox
    Friend WithEvents txtSend As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AlwaysOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnGetAllText As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
