Imports System.Linq
Public Class Form1
    'Dim path1 As String = Application.StartupPath()

    ' Dim path1 As String = "Y:\mixalis\apothikeusi.exe"
    Dim col1, col2, col3 As Color

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.CornflowerBlue
        Button2.BackColor = col2
        Button4.BackColor = col1
        Button5.BackColor = col2
        tmima = 101
        form_initialization()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.CornflowerBlue
        Button1.BackColor = col1
        Button4.BackColor = col1
        Button5.BackColor = col2
        tmima = 102
        form_initialization()

        'runquerycombo("SELECT username FROM promusers WHERE tmima=102", ComboBox1, "username")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'If Button1.BackColor = col1 And Button2.BackColor = col2 And Button4.BackColor = col3 Then
        'If Button2.BackColor = col2 Then

        '    MessageBox.Show("Δεν έχετε επιλέξει τμήμα")
        '    Exit Sub
        'End If
        Dim password, pass As String
        'If Button2.BackColor = Color.CornflowerBlue Then
        '    password = returnsinglevaluequery("SELECT password FROM promusers WHERE username='" & ComboBox1.Text & "'and tmima='" & tmima & "'")

        'Else
        'password = returnsinglevaluequery("SELECT password FROM promusers WHERE username='" & TextBox2.Text.Trim & "'and tmima='" & tmima & "'")
        dtvaluetoset("SELECT password,tmima FROM promusers WHERE username='" & TextBox2.Text.Trim & "'")
        If dt.Rows.Count > 0 Then
            password = dt.Rows(0).Item(0)
            tmima = dt.Rows(0).Item(1)

        End If
        pass = TextBox1.Text
        If password = pass And password <> "" Then
            If tmima <> 102 Then
                username = TextBox2.Text.Trim
                If username = "katerina" Then
                    username = "admin"
                End If
            Else
                username = ComboBox1.Text
            End If
            'If Button5.BackColor <> Color.CornflowerBlue Then
            Form6.Show()
            'Me.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            Button1.BackColor = col1
            Button2.BackColor = col2
            Button3.BackColor = col3
            ComboBox1.Visible = False

            'Else

            '    If System.IO.File.Exists(path1) Then

            '        Try
            '            'Process.Start("explorer.exe", path1)
            '            Process.Start(path1)
            '        Catch ex As Exception
            '            MessageBox.Show(ex.ToString)
            '        End Try
            '    Else
            '        MessageBox.Show("Η διαδρομή αρχείου apothikeusi δεν υπάρχει")
            '    End If
            'End If
            Me.Close()

        Else
            MessageBox.Show("Λάθος κωδικός")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.BackColor = Color.CornflowerBlue
        Button2.BackColor = col2
        Button1.BackColor = col1
        Button5.BackColor = col2
        tmima = 103
        form_initialization()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'runquerycombo("SELECT username FROM promusers WHERE tmima=102 and username is not null", ComboBox1, "username")
        TextBox2.Focus()
        col1 = Button1.BackColor
        col2 = Button2.BackColor
        col3 = Button3.BackColor
        'path1 = path1 & "\apothikeusi.exe"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.BackColor = Color.CornflowerBlue
        Button2.BackColor = col2
        Button1.BackColor = col1
        tmima = 103
        form_initialization()

    End Sub

    Private Sub form_initialization()
        Label1.Enabled = True
        Label2.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        Button3.Enabled = True
        TextBox2.Focus()
        If tmima = 102 Then
            ComboBox1.Visible = True
        Else
            ComboBox1.Visible = False
        End If
        If Application.OpenForms().OfType(Of Form2).Any Then
            Form2.Close()
        End If
    End Sub
    Private Sub frmCustomerDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Focused Then

                Button3.PerformClick()
            End If
            If TextBox2.Focused Then
                TextBox1.Focus()
            End If

        End If
    End Sub
End Class
