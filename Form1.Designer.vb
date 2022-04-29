<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button1.Location = New System.Drawing.Point(341, 56)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 60)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Ατελιέ"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button2.Location = New System.Drawing.Point(528, 70)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(151, 60)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Λιθογραφείο"
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(331, 204)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(179, 26)
        Me.TextBox1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(215, 204)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Κωδικός"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button3.Location = New System.Drawing.Point(331, 258)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(179, 29)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Είσοδος"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(215, 167)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Όνομα Χρήστη"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(331, 167)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(179, 26)
        Me.TextBox2.TabIndex = 1
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button4.Location = New System.Drawing.Point(45, 382)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(168, 40)
        Me.Button4.TabIndex = 10
        Me.Button4.Text = "Διαχείριση Συστήματος"
        Me.Button4.UseVisualStyleBackColor = False
        Me.Button4.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(550, 202)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(179, 28)
        Me.ComboBox1.TabIndex = 11
        Me.ComboBox1.Visible = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Button5.Location = New System.Drawing.Point(72, 122)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(151, 60)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "Έλεγχος Αποθήκευσης"
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Signet s.a"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button5 As Button
End Class
