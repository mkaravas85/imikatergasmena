Imports System.ComponentModel

Public Class Form4
    Public eidos, rowindex As Integer
    Dim Ctl As Control

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If formcontrol <> "form2" Then
            dtvaluetoset("select eidos,code,perigrafi from eidi where code like '" & TextBox2.Text & "%'")

            If dt.Rows.Count > 1 Then
                formcontrol = "form4"
                Form3.Show()
            ElseIf dt.Rows.Count = 1 Then
                TextBox2.Text = dt.Rows(0).Item(1)
                eidos = dt.Rows(0).Item(0)
                TextBox3.Text = dt.Rows(0).Item(2)
            Else
                MessageBox.Show("Δε βρέθηκαν εγγραφές")
            End If
        End If
        dtvaluetoset("select * from eidi_plus where eidos='" & eidos & "'")
        If dt.Rows.Count = 1 Then
            ComboBox1.Text = dt.Rows(0).Item(1)
            ComboBox2.Text = dt.Rows(0).Item(2)

            ComboBox3.Text = dt.Rows(0).Item(3)

            ComboBox4.Text = dt.Rows(0).Item(4)
            TextBox1.Text = dt.Rows(0).Item(5)
            ComboBox5.Text = dt.Rows(0).Item(6)
        End If

    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        runquerycombo("select epistra from eidi_plus_epistra", ComboBox1, "epistra")
        runquerycombo("select epistrb from eidi_plus_epistrb", ComboBox2, "epistrb")

        runquerycombo("select leuki from eidi_plus_leuki", ComboBox3, "leuki")

        runquerycombo("select xrwm from eidi_plus_xrwm", ComboBox4, "xrwm")

        runquerycombo("select final from eidi_plus_final", ComboBox5, "final")
        If formcontrol = "form2" Then
            Button2.PerformClick()
        End If

    End Sub
    Private Sub frmCustomerDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then

            Button2.PerformClick()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'runquery("insert into eidi_plus(eidos,epistra,epistrb,leuki.xrwm,pantone,final_epistr) values('" & eidos & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & TextBox1.Text & "','" & ComboBox5.Text & "')")
        runquery("insert into eidi_plus values('" & eidos & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & ComboBox4.Text & "','" & TextBox1.Text & "','" & ComboBox5.Text & "') on duplicate key update epistra='" & ComboBox1.Text & "',epistrb='" & ComboBox2.Text & "',leuki='" & ComboBox3.Text & "',xrwm='" & ComboBox4.Text & "',pantone='" & TextBox1.Text & "',final_epistr='" & ComboBox5.Text & "'")

        If queryerror = False Then
            MessageBox.Show("Επιτυχής καταχώρηση")

            If formcontrol = "form2" Then
                Form2.DataGridView1.Rows(rowindex).Cells(9).Value = ComboBox1.Text
                Form2.DataGridView1.Rows(rowindex).Cells(10).Value = ComboBox2.Text
                Form2.DataGridView1.Rows(rowindex).Cells(11).Value = ComboBox3.Text
                Form2.DataGridView1.Rows(rowindex).Cells(12).Value = ComboBox4.Text
                Form2.DataGridView1.Rows(rowindex).Cells(13).Value = TextBox1.Text
                Form2.DataGridView1.Rows(rowindex).Cells(14).Value = ComboBox5.Text
                formcontrol = ""
                Me.Close()
            End If
            ComboBox1.SelectedItem = Nothing
            ComboBox2.SelectedItem = Nothing
            ComboBox3.SelectedItem = Nothing
            ComboBox4.SelectedItem = Nothing
            TextBox1.Text = ""
            ComboBox5.SelectedItem = Nothing
            TextBox2.Text = ""
            TextBox3.Text = ""
            eidos = 0
        End If
    End Sub

    Private Sub Form4_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        eidos = 0
        formcontrol = ""
    End Sub
End Class