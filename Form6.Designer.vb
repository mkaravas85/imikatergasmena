<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form6
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Form1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΈλεγχοςΑποθήκευσηςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΈλεγχοςΚόστουςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΓραμμέςΠαραγωγήςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΚόστοςΥλικώνToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Form1ToolStripMenuItem, Me.ΈλεγχοςΑποθήκευσηςToolStripMenuItem, Me.ΈλεγχοςΚόστουςToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Form1ToolStripMenuItem
        '
        Me.Form1ToolStripMenuItem.Name = "Form1ToolStripMenuItem"
        Me.Form1ToolStripMenuItem.Size = New System.Drawing.Size(154, 20)
        Me.Form1ToolStripMenuItem.Text = "Εφαρμογή Λιθογραφείου"
        '
        'ΈλεγχοςΑποθήκευσηςToolStripMenuItem
        '
        Me.ΈλεγχοςΑποθήκευσηςToolStripMenuItem.Enabled = False
        Me.ΈλεγχοςΑποθήκευσηςToolStripMenuItem.Name = "ΈλεγχοςΑποθήκευσηςToolStripMenuItem"
        Me.ΈλεγχοςΑποθήκευσηςToolStripMenuItem.Size = New System.Drawing.Size(140, 20)
        Me.ΈλεγχοςΑποθήκευσηςToolStripMenuItem.Text = "Έλεγχος Αποθήκευσης"
        '
        'ΈλεγχοςΚόστουςToolStripMenuItem
        '
        Me.ΈλεγχοςΚόστουςToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΓραμμέςΠαραγωγήςToolStripMenuItem, Me.ΚόστοςΥλικώνToolStripMenuItem})
        Me.ΈλεγχοςΚόστουςToolStripMenuItem.Enabled = False
        Me.ΈλεγχοςΚόστουςToolStripMenuItem.Name = "ΈλεγχοςΚόστουςToolStripMenuItem"
        Me.ΈλεγχοςΚόστουςToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
        Me.ΈλεγχοςΚόστουςToolStripMenuItem.Text = "Έλεγχος Κόστους"
        '
        'ΓραμμέςΠαραγωγήςToolStripMenuItem
        '
        Me.ΓραμμέςΠαραγωγήςToolStripMenuItem.Name = "ΓραμμέςΠαραγωγήςToolStripMenuItem"
        Me.ΓραμμέςΠαραγωγήςToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ΓραμμέςΠαραγωγήςToolStripMenuItem.Text = "Γραμμές Παραγωγής"
        '
        'ΚόστοςΥλικώνToolStripMenuItem
        '
        Me.ΚόστοςΥλικώνToolStripMenuItem.Name = "ΚόστοςΥλικώνToolStripMenuItem"
        Me.ΚόστοςΥλικώνToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ΚόστοςΥλικώνToolStripMenuItem.Text = "Κόστος Υλικών"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Maroon
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 425)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(800, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BackColor = System.Drawing.Color.Maroon
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Forte", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox1.ForeColor = System.Drawing.SystemColors.Info
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(183, 25)
        Me.ToolStripTextBox1.Text = "SigNet S.A"
        '
        'Form6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form6"
        Me.Text = "Form6"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Form1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ΈλεγχοςΑποθήκευσηςToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ΈλεγχοςΚόστουςToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ΓραμμέςΠαραγωγήςToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ΚόστοςΥλικώνToolStripMenuItem As ToolStripMenuItem
End Class
