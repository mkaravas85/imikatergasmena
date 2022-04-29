Public Class Form9
    Dim ctl As Control
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.CornflowerBlue
        Button2.Enabled = False
        Button3.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.CornflowerBlue
        Button1.Enabled = False
        Button3.Enabled = True

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        For Each ctl In Me.Controls
            If TypeOf ctl Is TextBox Then
                If ctl.Text = "" Then
                    ctl.Text = 0
                End If
            End If
        Next
        If Button1.BackColor = Color.CornflowerBlue Then
            runquery("insert into grammes_paragogis(name,cost_ergat,cost_energy,gve,aposveseis,loipa) values('" & TextBox1.Text & "','" & todecimalvalue(TextBox2.Text) & "','" & todecimalvalue(TextBox3.Text) & "','" & todecimalvalue(TextBox7.Text) & "','" & todecimalvalue(TextBox4.Text) & "','" & todecimalvalue(TextBox5.Text) & "')")
        ElseIf Button2.BackColor = Color.CornflowerBlue Then
            runquery("update grammes_paragogis set name='" & TextBox1.Text & "',cost_ergat='" & todecimalvalue(TextBox2.Text) & "',cost_energy='" & todecimalvalue(TextBox3.Text) & "',gve='" & todecimalvalue(TextBox7.Text) & "',aposveseis='" & todecimalvalue(TextBox4.Text) & "',loipa='" & todecimalvalue(TextBox5.Text) & "' where id='" & DataGridView1.CurrentRow.Cells(0).Value & "'")

        End If
        loadgrid("select * from grammes_paragogis", DataGridView1)
        gridlayout()
        Button1.Enabled = True
        Button2.Enabled = True
        Button1.BackColor = DefaultBackColor
        Button2.BackColor = DefaultBackColor
        For Each ctl In Me.Controls
            If TypeOf ctl Is TextBox Then
                If ctl.Text <> "" Then
                    ctl.Text = ""
                End If
            End If
        Next
    End Sub

    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        loadgrid("select * from grammes_paragogis", DataGridView1)
        gridlayout()
    End Sub
    Private Sub gridlayout()
        DataGridView1.Columns(0).Width = 35
        DataGridView1.Columns(1).Width = 265
        DataGridView1.Columns(0).HeaderText = "Κωδ."
        DataGridView1.Columns(1).HeaderText = "Γραμμή Παραγωγής"
        For i = 2 To 6
            DataGridView1.Columns(i).Visible = False
        Next
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
        TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
        TextBox4.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
        TextBox5.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
        TextBox7.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
    End Sub

    Private Function todecimalvalue(cl As String) As String
        Dim ex As String
        If cl.ToString.Contains(",") Then
            ex = cl.Replace(",", ".")
            Return ex
        Else
            Return cl
        End If
    End Function

End Class