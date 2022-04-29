Public Class Form7
    Dim date1, date2 As String
    Public pelprom, eidos As Integer
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        Me.Text = "SigNet S.A"
    End Sub
    Private Sub frmCustomerDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Focused Then
                TextBox2.Text = ""
                pelprom = 0
                eidos = 0
                dtvaluetoset("select pelprom,code,eponymia from pelproms where ptype='ΠΕΛΑΤΗΣ' and eponymia like '" & TextBox1.Text & "%'")

                If dt.Rows.Count = 1 Then
                    TextBox1.Text = dt.Rows(0).Item(2).ToString
                    pelprom = dt.Rows(0).Item(0)
                ElseIf dt.Rows.Count > 1 Then
                    Form8.formcontrol = "pelprom"
                    loadgrid("select pelprom,code,eponymia from pelproms where ptype='ΠΕΛΑΤΗΣ' and eponymia like '" & TextBox1.Text & "%'", Form8.DataGridView1)
                    Form8.Show()
                Else
                    MessageBox.Show("Δε βρέθηκαν πελάτες")
                End If
            End If
            If TextBox2.Focused Then
                dtvaluetoset("select eidos,code from eidi where code like '" & TextBox2.Text & "%' and pelprom= '" & pelprom & "%'")
                If dt.Rows.Count = 1 Then
                    TextBox2.Text = dt.Rows(0).Item(1).ToString
                    eidos = dt.Rows(0).Item(0)
                ElseIf dt.Rows.Count > 1 Then
                    Form8.formcontrol = "eidos"
                    Form8.formcontrol2 = "form7"
                    loadgrid("select eidos,code,perigrafi from eidi where code like '" & TextBox2.Text & "%' and pelprom= '" & pelprom & "%'", Form8.DataGridView1)
                    Form8.Show()
                End If
            End If

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim kwdikos, perigrafi, partidanumber, datecompleted, posotita1, posotita2, fyra, pososto_fyras, txt, fileloc As String
        SaveFileDialog1.Filter = "CSV Files (*.csv*)|*.csv"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
       Then
            fileloc = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If
        Dim header As String = "Κωδικός;Περιγραφή;Παρτίδα;Ημ/νία ολοκλήρωσης;Ποσότητα Παραγωγής;Ποσότητα Αποθήκευσης;Φύρα;Ποσοστό Φύρας (%)"
        If eidos = 0 Then
            dtvaluetoset("select a.kwdikos,a.perigrafi,a.partidanumber,a.datecompleted,posotita1,posotita2,posotita1-posotita2,round(((posotita1-posotita2)/posotita1)*100,2) from (select eidi.code as kwdikos,eidi.perigrafi as perigrafi,endqty as posotita1,partidanumber,datecompleted from paragogi  join partides on paragogi.partida=partides.partidaid join eidi on eidi.eidos=partides.eidos where eidi.eidos in (select eidi.eidos from eidi where pelprom='" & pelprom & "') and endqty is not null and datecompleted>='" & date1 & "' and datecompleted<='" & date2 & "') a join (select partida,sum(posotita) as posotita2 from grammeskin join kiniseis on grammeskin.kinisi= kiniseis.kinisi where palletanumber is not null and  eidos in (select eidi.eidos from eidi where pelprom='" & pelprom & "') and axia is null group by kiniseis.partida) b on a.partidanumber=b.partida")

        Else
            dtvaluetoset("select a.kwdikos,a.perigrafi,a.partidanumber,a.datecompleted,posotita1,posotita2,posotita1-posotita2,round(((posotita1-posotita2)/posotita1)*100,2) from (select eidi.code as kwdikos,eidi.perigrafi as perigrafi,endqty as posotita1,partidanumber,datecompleted from paragogi  join partides on paragogi.partida=partides.partidaid join eidi on eidi.eidos=partides.eidos where eidi.eidos='" & eidos & "' and endqty is not null and datecompleted>='" & date1 & "' and datecompleted<='" & date2 & "') a join (select partida,sum(posotita) as posotita2 from grammeskin join kiniseis on grammeskin.kinisi= kiniseis.kinisi where palletanumber is not null  and  eidos='" & eidos & "' and axia is null group by kiniseis.partida) b on a.partidanumber=b.partida")
        End If

        Using sw As New System.IO.StreamWriter(fileloc, False, System.Text.Encoding.UTF8)
            Try
                For i = 0 To dt.Rows.Count - 1
                    Dim lst As New List(Of String)
                    kwdikos = dt.Rows(i).Item(0)
                    lst.Add(kwdikos)
                    perigrafi = dt.Rows(i).Item(1)
                    lst.Add(perigrafi)
                    partidanumber = dt.Rows(i).Item(2)
                    lst.Add(partidanumber)
                    datecompleted = dt.Rows(i).Item(3)
                    lst.Add(datecompleted)

                    posotita1 = dt.Rows(i).Item(4)
                    lst.Add(posotita1)

                    posotita2 = dt.Rows(i).Item(5)
                    lst.Add(posotita2)

                    fyra = dt.Rows(i).Item(6)
                    lst.Add(fyra)

                    pososto_fyras = dt.Rows(i).Item(7)
                    lst.Add(pososto_fyras)

                    txt = txt & lst(0) & ";" & lst(1) & ";" & lst(2) & ";" & lst(3) & ";" & lst(4) & ";" & lst(5) & ";" & lst(6) & ";" & lst(7) & vbCrLf
                Next
                sw.WriteLine(header & vbCrLf & txt)
                MessageBox.Show("Το αρχείο παρήχθη επιτυχώς!")
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Using
    End Sub

    Private Sub gridlayout()
        'If eidos = 0 Then
        DataGridView1.Columns(0).HeaderText = "Κωδικός"
        DataGridView1.Columns(1).HeaderText = "Περιγραφή"
        DataGridView1.Columns(2).HeaderText = "Αρ. Παρτίδας"

        DataGridView1.Columns(3).HeaderText = "Ημ/νία Ολοκλήρωσης"

        DataGridView1.Columns(4).HeaderText = "Ποσότητα Παραγωγής"
        DataGridView1.Columns(5).HeaderText = "Ποσότητα Αποθήκευσης"
        DataGridView1.Columns(6).HeaderText = "Φύρα"
        DataGridView1.Columns(7).HeaderText = "Ποσοστό Φύρας (%)"
        DataGridView1.Columns(6).DefaultCellStyle.Format = "N0"
        'Else
        'DataGridView1.Columns(0).HeaderText = "Αρ. Παρτίδας"
        '    DataGridView1.Columns(1).HeaderText = "Ποσότητα Παραγωγής"
        '    DataGridView1.Columns(2).HeaderText = "Ποσότητα Αποθήκευσης"
        '    DataGridView1.Columns(3).HeaderText = "Φύρα"
        '    DataGridView1.Columns(4).HeaderText = "Ποσοστό Φύρας (%)"
        '    DataGridView1.Columns(1).DefaultCellStyle.Format = "N0"
        'End If
        DataGridView1.Columns(4).DefaultCellStyle.Format = "N0"
        DataGridView1.Columns(5).DefaultCellStyle.Format = "N0"
        DataGridView1.Columns(1).Width = 350
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TODATE(DateTimePicker1, date1)
        TODATE(DateTimePicker2, date2)

        If pelprom = 0 Then
            MessageBox.Show("Δεν έχετε επιλέξει πελάτη")
            Exit Sub
        End If
        If eidos = 0 Then
            'loadgrid("select a.eidos1,quantity-posotita2 from(select eidi.eidos,eidi.code as eidos1,sum(endqty) as quantity from paragogi join partides on paragogi.partida=partides.partidaid join eidi on eidi.eidos=partides.eidos where eidi.eidos in (select eidi.eidos from eidi where pelprom='" & pelprom & "') and endqty is not null group by eidi.eidos) a join (select eidos,sum(posotita) as posotita2 from grammeskin where grammeskin.kinisi in (select kiniseis.kinisi from kiniseis where palletanumber is not null) and  eidos in (select eidos from eidi where pelprom='" & pelprom & "') and axia is null group by eidos) b on a.eidos=b.eidos group by a.eidos", DataGridView1)
            loadgrid("select a.kwdikos,a.perigrafi,a.partidanumber,a.datecompleted,posotita1,posotita2,posotita1-posotita2,round(((posotita1-posotita2)/posotita1)*100,2) from (select eidi.code as kwdikos,eidi.perigrafi as perigrafi,endqty as posotita1,partidanumber,datecompleted from paragogi  join partides on paragogi.partida=partides.partidaid join eidi on eidi.eidos=partides.eidos where eidi.eidos in (select eidi.eidos from eidi where pelprom='" & pelprom & "') and endqty is not null and datecompleted>='" & date1 & "' and datecompleted<='" & date2 & "') a join (select partida,sum(posotita) as posotita2 from grammeskin join kiniseis on grammeskin.kinisi= kiniseis.kinisi where palletanumber is not null and  eidos in (select eidi.eidos from eidi where pelprom='" & pelprom & "') and axia is null group by kiniseis.partida) b on a.partidanumber=b.partida", DataGridView1)

        Else
            loadgrid("select a.kwdikos,a.perigrafi,a.partidanumber,a.datecompleted,posotita1,posotita2,posotita1-posotita2,round(((posotita1-posotita2)/posotita1)*100,2) from (select eidi.code as kwdikos,eidi.perigrafi as perigrafi,endqty as posotita1,partidanumber,datecompleted from paragogi  join partides on paragogi.partida=partides.partidaid join eidi on eidi.eidos=partides.eidos where eidi.eidos='" & eidos & "' and endqty is not null and datecompleted>='" & date1 & "' and datecompleted<='" & date2 & "') a join (select partida,sum(posotita) as posotita2 from grammeskin join kiniseis on grammeskin.kinisi= kiniseis.kinisi where palletanumber is not null  and  eidos='" & eidos & "' and axia is null group by kiniseis.partida) b on a.partidanumber=b.partida", DataGridView1)
            'select a.partidanumber,posotita1-posotita2 from (select endqty as posotita1,partidanumber from paragogi  join partides on paragogi.partida=partides.partidaid join eidi on eidi.eidos=partides.eidos where eidi.eidos=10485 and endqty is not null) a join (select partida,sum(posotita) as posotita2 from grammeskin join kiniseis on grammeskin.kinisi= kiniseis.kinisi where palletanumber is not null  and  eidos=10485 and axia is null group by kiniseis.partida) b on a.partidanumber=b.partida
        End If
        gridlayout()
    End Sub
End Class