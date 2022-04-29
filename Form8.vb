Public Class Form8
    Public formcontrol, formcontrol2 As String
    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        Me.Text = "SigNet S.A"
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Κωδικός"
        DataGridView1.Columns(2).Width = 315
        If formcontrol = "pelprom" Then
            DataGridView1.Columns(2).HeaderText = "Επωνυμία"
        ElseIf formcontrol = "eidos" Then
            DataGridView1.Columns(2).HeaderText = "Περιγραφή"
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If formcontrol = "pelprom" Then
            Form7.pelprom = DataGridView1.CurrentRow.Cells(0).Value
            Form7.TextBox1.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
        ElseIf formcontrol = "eidos" Then
            If formcontrol2 = "form7" Then
                Form7.eidos = DataGridView1.CurrentRow.Cells(0).Value
                Form7.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString

            ElseIf formcontrol2 = "form10-1" Then
                Form10.proion = DataGridView1.CurrentRow.Cells(0).Value

                If Form10.Button3.BackColor = Color.CornflowerBlue Then
                    Form10.DataGridView2.Columns.Clear()
                    Form10.TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                    Form10.TextBox15.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                    Form10.Button3.Enabled = True
                    dtvaluetoset("select grammes_paragogis.name,suntelestis,tmima from grammes_par_pososta join grammes_paragogis on tmima=grammes_paragogis.id where proion='" & Form10.proion & "'")
                    If dt.Rows.Count = 1 Then
                        Form10.cmb6.Text = dt.Rows(0).Item(0)
                        Form10.TextBox9.Text = dt.Rows(0).Item(1)
                        Form10.cmb6.Enabled = True
                        Form10.cmb7.Enabled = False
                        Form10.cmb8.Enabled = False
                        Form10.cmb9.Enabled = False
                        Form10.cmb10.Enabled = False
                        Form10.cmb6.id = dt.Rows(0).Item(2)
                    End If
                    If dt.Rows.Count = 2 Then
                        Form10.cmb6.Text = dt.Rows(0).Item(0)
                        Form10.TextBox9.Text = dt.Rows(0).Item(1)
                        Form10.cmb7.Text = dt.Rows(1).Item(0)
                        Form10.TextBox10.Text = dt.Rows(1).Item(1)
                        Form10.cmb6.Enabled = True
                        Form10.cmb7.Enabled = True
                        Form10.cmb8.Enabled = False
                        Form10.cmb9.Enabled = False
                        Form10.cmb10.Enabled = False
                        Form10.cmb6.id = dt.Rows(0).Item(2)
                        Form10.cmb7.id = dt.Rows(1).Item(2)

                    End If
                    If dt.Rows.Count = 3 Then
                        Form10.cmb6.Text = dt.Rows(0).Item(0)
                        Form10.TextBox9.Text = dt.Rows(0).Item(1)
                        Form10.cmb7.Text = dt.Rows(1).Item(0)
                        Form10.TextBox10.Text = dt.Rows(1).Item(1)
                        Form10.cmb8.Text = dt.Rows(2).Item(0)
                        Form10.TextBox11.Text = dt.Rows(2).Item(1)
                        Form10.cmb6.Enabled = True
                        Form10.cmb7.Enabled = True
                        Form10.cmb8.Enabled = True
                        Form10.cmb9.Enabled = False
                        Form10.cmb10.Enabled = False
                        Form10.cmb6.id = dt.Rows(0).Item(2)
                        Form10.cmb7.id = dt.Rows(1).Item(2)
                        Form10.cmb8.id = dt.Rows(2).Item(2)

                    End If
                    If dt.Rows.Count = 4 Then
                        Form10.cmb6.Text = dt.Rows(0).Item(0)
                        Form10.TextBox9.Text = dt.Rows(0).Item(1)
                        Form10.cmb7.Text = dt.Rows(1).Item(0)
                        Form10.TextBox10.Text = dt.Rows(1).Item(1)
                        Form10.cmb8.Text = dt.Rows(2).Item(0)
                        Form10.TextBox11.Text = dt.Rows(2).Item(1)
                        Form10.cmb9.Text = dt.Rows(3).Item(0)
                        Form10.TextBox12.Text = dt.Rows(3).Item(1)
                        Form10.cmb6.Enabled = True
                        Form10.cmb7.Enabled = True
                        Form10.cmb8.Enabled = True
                        Form10.cmb9.Enabled = True
                        Form10.cmb10.Enabled = False
                        Form10.cmb6.id = dt.Rows(0).Item(2)
                        Form10.cmb7.id = dt.Rows(1).Item(2)
                        Form10.cmb8.id = dt.Rows(2).Item(2)
                        Form10.cmb9.id = dt.Rows(3).Item(2)

                    End If
                    If dt.Rows.Count = 5 Then
                        Form10.cmb6.Text = dt.Rows(0).Item(0)
                        Form10.TextBox9.Text = dt.Rows(0).Item(1)
                        Form10.cmb7.Text = dt.Rows(1).Item(0)
                        Form10.TextBox10.Text = dt.Rows(1).Item(1)
                        Form10.cmb8.Text = dt.Rows(2).Item(0)
                        Form10.TextBox11.Text = dt.Rows(2).Item(1)
                        Form10.cmb9.Text = dt.Rows(3).Item(0)
                        Form10.TextBox12.Text = dt.Rows(3).Item(1)
                        Form10.cmb10.Text = dt.Rows(4).Item(0)
                        Form10.TextBox13.Text = dt.Rows(4).Item(1)
                        Form10.cmb6.Enabled = True
                        Form10.cmb7.Enabled = True
                        Form10.cmb8.Enabled = True
                        Form10.cmb9.Enabled = True
                        Form10.cmb10.Enabled = True
                        Form10.cmb6.id = dt.Rows(0).Item(2)
                        Form10.cmb7.id = dt.Rows(1).Item(2)
                        Form10.cmb8.id = dt.Rows(2).Item(2)
                        Form10.cmb9.id = dt.Rows(3).Item(2)
                        Form10.cmb10.id = dt.Rows(4).Item(2)

                    End If
                    loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & Form10.proion & "' group by yliko", Form10.DataGridView2)
                    Form10.gridlayout2()
                ElseIf Form10.Button2.BackColor <> Color.CornflowerBlue And Form10.Button3.BackColor <> Color.CornflowerBlue Then

                    If (((returnsinglevaluequery("select proion from grammes_par_ylika where proion='" & Form10.proion & "'")) Is Nothing And ((returnsinglevaluequery("select proion from grammes_par_pososta where proion='" & Form10.proion & "'") Is Nothing)))) Then
                        MessageBox.Show("Δε βρέθηκε καταχώρηση για το συγκεκριμένο προιόν.")
                        Form10.proion = 0
                    Else
                        Form10.DataGridView2.Columns.Clear()
                        Form10.TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                        Form10.TextBox15.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                        Form10.Button3.Enabled = True
                        dtvaluetoset("select grammes_paragogis.name,suntelestis,tmima from grammes_par_pososta join grammes_paragogis on tmima=grammes_paragogis.id where proion='" & Form10.proion & "'")
                        If dt.Rows.Count = 1 Then
                            Form10.cmb6.Text = dt.Rows(0).Item(0)
                            Form10.TextBox9.Text = dt.Rows(0).Item(1)
                            Form10.cmb6.Enabled = True
                            Form10.cmb7.Enabled = False
                            Form10.cmb8.Enabled = False
                            Form10.cmb9.Enabled = False
                            Form10.cmb10.Enabled = False
                            Form10.cmb6.id = dt.Rows(0).Item(2)
                        End If
                        If dt.Rows.Count = 2 Then
                            Form10.cmb6.Text = dt.Rows(0).Item(0)
                            Form10.TextBox9.Text = dt.Rows(0).Item(1)
                            Form10.cmb7.Text = dt.Rows(1).Item(0)
                            Form10.TextBox10.Text = dt.Rows(1).Item(1)
                            Form10.cmb6.Enabled = True
                            Form10.cmb7.Enabled = True
                            Form10.cmb8.Enabled = False
                            Form10.cmb9.Enabled = False
                            Form10.cmb10.Enabled = False
                            Form10.cmb6.id = dt.Rows(0).Item(2)
                            Form10.cmb7.id = dt.Rows(1).Item(2)

                        End If
                        If dt.Rows.Count = 3 Then
                            Form10.cmb6.Text = dt.Rows(0).Item(0)
                            Form10.TextBox9.Text = dt.Rows(0).Item(1)
                            Form10.cmb7.Text = dt.Rows(1).Item(0)
                            Form10.TextBox10.Text = dt.Rows(1).Item(1)
                            Form10.cmb8.Text = dt.Rows(2).Item(0)
                            Form10.TextBox11.Text = dt.Rows(2).Item(1)
                            Form10.cmb6.Enabled = True
                            Form10.cmb7.Enabled = True
                            Form10.cmb8.Enabled = True
                            Form10.cmb9.Enabled = False
                            Form10.cmb10.Enabled = False
                            Form10.cmb6.id = dt.Rows(0).Item(2)
                            Form10.cmb7.id = dt.Rows(1).Item(2)
                            Form10.cmb8.id = dt.Rows(2).Item(2)

                        End If
                        If dt.Rows.Count = 4 Then
                            Form10.cmb6.Text = dt.Rows(0).Item(0)
                            Form10.TextBox9.Text = dt.Rows(0).Item(1)
                            Form10.cmb7.Text = dt.Rows(1).Item(0)
                            Form10.TextBox10.Text = dt.Rows(1).Item(1)
                            Form10.cmb8.Text = dt.Rows(2).Item(0)
                            Form10.TextBox11.Text = dt.Rows(2).Item(1)
                            Form10.cmb9.Text = dt.Rows(3).Item(0)
                            Form10.TextBox12.Text = dt.Rows(3).Item(1)
                            Form10.cmb6.Enabled = True
                            Form10.cmb7.Enabled = True
                            Form10.cmb8.Enabled = True
                            Form10.cmb9.Enabled = True
                            Form10.cmb10.Enabled = False
                            Form10.cmb6.id = dt.Rows(0).Item(2)
                            Form10.cmb7.id = dt.Rows(1).Item(2)
                            Form10.cmb8.id = dt.Rows(2).Item(2)
                            Form10.cmb9.id = dt.Rows(3).Item(2)

                        End If
                        If dt.Rows.Count = 5 Then
                            Form10.cmb6.Text = dt.Rows(0).Item(0)
                            Form10.TextBox9.Text = dt.Rows(0).Item(1)
                            Form10.cmb7.Text = dt.Rows(1).Item(0)
                            Form10.TextBox10.Text = dt.Rows(1).Item(1)
                            Form10.cmb8.Text = dt.Rows(2).Item(0)
                            Form10.TextBox11.Text = dt.Rows(2).Item(1)
                            Form10.cmb9.Text = dt.Rows(3).Item(0)
                            Form10.TextBox12.Text = dt.Rows(3).Item(1)
                            Form10.cmb10.Text = dt.Rows(4).Item(0)
                            Form10.TextBox13.Text = dt.Rows(4).Item(1)
                            Form10.cmb6.Enabled = True
                            Form10.cmb7.Enabled = True
                            Form10.cmb8.Enabled = True
                            Form10.cmb9.Enabled = True
                            Form10.cmb10.Enabled = True
                            Form10.cmb6.id = dt.Rows(0).Item(2)
                            Form10.cmb7.id = dt.Rows(1).Item(2)
                            Form10.cmb8.id = dt.Rows(2).Item(2)
                            Form10.cmb9.id = dt.Rows(3).Item(2)
                            Form10.cmb10.id = dt.Rows(4).Item(2)

                        End If
                        loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & Form10.proion & "' group by yliko", Form10.DataGridView2)
                        Form10.gridlayout2()
                    End If
                Else
                    If (((returnsinglevaluequery("select proion from grammes_par_ylika where proion='" & Form10.proion & "'")) IsNot Nothing Or ((returnsinglevaluequery("select proion from grammes_par_pososta where proion='" & Form10.proion & "'") IsNot Nothing)))) Then
                        MessageBox.Show("Για το συγκεκριμένο προιόν υπάρχει ήδη καταχώρηση είτε στα υλικά είτε στους χρόνους." & vbCrLf & "Επιλέξτε μεταβολή")
                        Form10.proion = 0
                    Else
                        Form10.TextBox1.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                        Form10.TextBox15.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                    End If
                    Form10.cmb6.Enabled = True

                End If
                'Form10.datagridview1.Enabled = True
                'MessageBox.Show(grammi)
            ElseIf formcontrol2 = "form10-2" Then

                'Form10.datagridview1.CurrentCell.Value = DataGridView1.CurrentRow.Cells(1).Value
                'Form10.datagridview1.Rows(grammi).Cells(1).Value = DataGridView1.CurrentRow.Cells(2).Value
                'Form10.datagridview1.Rows(grammi).Cells(13).Value = DataGridView1.CurrentRow.Cells(0).Value

                'Form10.datagridview1.CurrentCell = Form10.datagridview1.Rows(grammi).Cells(2)
                'Form10.datagridview1.BeginEdit(True)
                Form10.yliko = DataGridView1.CurrentRow.Cells(0).Value
                Form10.TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                Form10.TextBox16.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                Form10.cmb1.Enabled = True
            End If
        End If
        Me.Close()

    End Sub
End Class