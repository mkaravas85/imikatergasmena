Public Class Form3
    Public os_ylikaid, rowindex As Integer
    Private cmdtext As String
    Public cmdtext2 As String
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        If formcontrol = "form2" Then
            Button1.Text = "Καταχώρηση"
            Form2.a = "delete from os_palletes where os_ylikaid in (select distinct osylikaid from t1);insert into os_palletes(os_ylikaid,palletanumber) select osylikaid,paleta from t1;"
            Me.Text = "Eισαγωγή Παλετών"
            runquery("CREATE TEMPORARY TABLE if not exists t1(osylikaid INT(11),paleta VARCHAR(40))")
            With DataGridView1
                If returnsinglevaluequery("select paleta from t1 where osylikaid='" & os_ylikaid & "'") <> "" Then
                    loadgrid("select osylikaid,paleta from t1 where osylikaid='" & os_ylikaid & "'", DataGridView1)
                ElseIf returnsinglevaluequery("select palletanumber from os_palletes where os_ylikaid='" & os_ylikaid & "'") <> "" Then
                    loadgrid("select os_ylikaid,palletanumber from os_palletes where os_ylikaid='" & os_ylikaid & "'", DataGridView1)
                Else
                    .Columns.AddRange(Enumerable.Range(0, 2).Select(Function(x) New DataGridViewTextBoxColumn).ToArray)
                    .Rows.AddRange(Enumerable.Range(0, 12).Select(Function(x) New DataGridViewRow).ToArray)
                End If
                .Columns(0).Visible = False
                .Columns(1).Width = 196
                .Columns(1).HeaderText = "Παλέτα"

            End With
        ElseIf formcontrol = "form4" Then
            Button1.Text = "Επιλογή"
            loadgrid("select eidos,code,perigrafi from eidi where code like '" & Form4.TextBox2.Text & "%'", DataGridView1)

            With DataGridView1

                .Columns(0).Visible = False
                .Columns(2).Width = 226
                .Columns(1).HeaderText = "Κωδικός"
                .Columns(2).HeaderText = "Περιγραφή"

            End With
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If formcontrol = "form2" Then
            Dim celltext As String = ""
            For i = 0 To DataGridView1.RowCount - 1

                If DataGridView1.Rows(i).Cells(1).Value IsNot Nothing AndAlso DataGridView1.Rows(i).Cells(1).Value.ToString <> "" Then

                    cmdtext = cmdtext & "insert into t1 values('" & os_ylikaid & "','" & DataGridView1.Rows(i).Cells(1).Value & "');"
                    celltext = DataGridView1.Rows(i).Cells(1).Value.ToString & "," & celltext

                End If

            Next
            runquery("delete From t1 where osylikaid='" & os_ylikaid & "';" & cmdtext)

            Form2.DataGridView1.Rows(rowindex).Cells(18).Value = celltext

            'Form2.DataGridView1.cell = Form2.DataGridView1.Rows(rowindex).Cells(18)
        ElseIf formcontrol = "form4" Then
            Form4.eidos = DataGridView1.CurrentRow.Cells(0).Value
            Form4.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            Form4.TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString

            dtvaluetoset("select * from eidi_plus where eidos='" & DataGridView1.CurrentRow.Cells(0).Value & "'")
            If dt.Rows.Count > 0 Then
                Form4.ComboBox1.Text = dt.Rows(0).Item(1)
                Form4.ComboBox2.Text = dt.Rows(0).Item(2)

                Form4.ComboBox3.Text = dt.Rows(0).Item(3)

                Form4.ComboBox4.Text = dt.Rows(0).Item(4)

                Form4.TextBox1.Text = dt.Rows(0).Item(5)
                Form4.ComboBox5.Text = dt.Rows(0).Item(6)
            End If
        End If
        formcontrol = ""
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If formcontrol = "form2" Then
            DataGridView1.BeginEdit(True)
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If formcontrol = "form4" Then
            Button1.PerformClick()
        End If
    End Sub
End Class