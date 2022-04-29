Imports System.ComponentModel

Public Class Form6

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        Me.Text = "SigNet S.A"
        If username = "athena" Then
            ΈλεγχοςΑποθήκευσηςToolStripMenuItem.Enabled = True
            ΈλεγχοςΚόστουςToolStripMenuItem.Enabled = True
        End If
        Me.IsMdiContainer = True
        Me.WindowState = FormWindowState.Maximized
        'Me.Size = My.Computer.Screen.WorkingArea.Size

    End Sub

    Private Sub Form1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Form1ToolStripMenuItem.Click

        Form2.MdiParent = Me
        Form2.Show()
    End Sub

    Private Sub ΈλεγχοςΑποθήκευσηςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΈλεγχοςΑποθήκευσηςToolStripMenuItem.Click
        Form7.MdiParent = Me
        Form7.Show()
    End Sub

    Private Sub ΓραμμέςΠαραγωγήςToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΓραμμέςΠαραγωγήςToolStripMenuItem.Click
        Form9.MdiParent = Me
        Form9.Show()
    End Sub

    Private Sub ΚόστοςΥλικώνToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ΚόστοςΥλικώνToolStripMenuItem.Click
        Form10.MdiParent = Me
        Form10.Show()
    End Sub

    Private Sub Form6_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Application.Exit()
    End Sub
End Class