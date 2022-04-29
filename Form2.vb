Imports System.ComponentModel

Public Class Form2
    Dim lst As New List(Of Integer)
    Dim kolwna As Integer = -1
    Dim date1, date2, finalqty As String
    Public a, sender1 As String
    Dim col14 As New DataGridViewColumn
    Dim keli18 As String = ""

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        DateTimePicker1.Value = DateTimePicker2.Value.AddDays(-30)
        TextBox1.Text = username.ToUpper
        RadioButton1.Checked = True

        If username = "admin" Then
            TextBox1.Visible = False
            ComboBox1.Visible = True
            Label1.Visible = True
            Button5.Visible = True
            Button7.Visible = True

            ComboBox2.Visible = True
            ComboBox2.SelectedIndex = 2
            runquerycombo("SELECT username FROM promusers WHERE tmima=102", ComboBox1, "username")
        End If
        If tmima = 102 Then
            Button3.Visible = True
            Button4.Visible = False

        End If
        If username = "athena" Then
            TextBox1.Visible = False
            ComboBox1.Visible = True
            ComboBox1.Enabled = False

            Label1.Visible = True
            Button5.Visible = False
            Button7.Visible = True

            ComboBox2.Visible = True
            ComboBox2.Items.Add("admin")
            ComboBox2.SelectedIndex = 3
            runquerycombo("SELECT username FROM promusers WHERE tmima=102", ComboBox1, "username")
        End If
        Button2.PerformClick()
    End Sub
    Private Sub gridlayout_at()
        With DataGridView1

            .Columns(2).HeaderText = "Kωδικός"
            .Columns(3).HeaderText = "Περιγραφή"
            .Columns(4).HeaderText = "Διάσταση"
            .Columns(5).HeaderText = "Πελάτης"
            .Columns(6).HeaderText = "Ποσότητα Παραγωγής"
            .Columns(7).HeaderText = "Ημ/νία Παραγωγής"
            .Columns(8).HeaderText = "M. Κατ."
            .Columns(9).HeaderText = "Επιστρ. Α"
            .Columns(10).HeaderText = "Επιστρ. Β"
            .Columns(11).HeaderText = "Λευκή"
            .Columns(12).HeaderText = "Χρωμ."
            .Columns(13).HeaderText = "Pantone"
            .Columns(14).HeaderText = "Τελική Επιστρ."
            .Columns(15).HeaderText = "Παρατηρήσεις"
            .Columns(16).HeaderText = "Ατελιέ 1"
            .Columns(17).HeaderText = "Ατελιέ 2"
            .Columns(18).HeaderText = "Κατ"
            .Columns(0).Visible = False
            .Columns(1).Visible = False

            .Columns(3).Width = 280
            .Columns(6).Width = 73
            .Columns(5).Width = 280
            .Columns(7).Width = 67
            .Columns(8).Width = 57

            For y = 9 To 14
                .Columns(y).Width = 50
            Next
            .Columns(13).Width = 70

            .Columns(6).DefaultCellStyle.Format = "N0"
            .Columns(18).DefaultCellStyle.Format = "N0"
            For j = 0 To 14
                .Columns(j).ReadOnly = True
            Next
            If kolwna = 16 Then
                .Columns(17).ReadOnly = True

            ElseIf kolwna = 17 Then
                .Columns(16).ReadOnly = True

            End If
            If username = "atelie1" Then

                For i = 0 To DataGridView1.RowCount - 1
                    If DataGridView1.Rows(i).Cells(kolwna).Value = True Then
                        DataGridView1.Rows(i).Cells(15).ReadOnly = True
                        DataGridView1.Rows(i).Cells(kolwna).ReadOnly = True
                    Else
                        DataGridView1.Rows(i).Cells(15).ReadOnly = False
                    End If
                Next

            End If

        End With
    End Sub
    Private Sub gridlayout_lith()
        With DataGridView1
            '.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(2).HeaderText = "Kωδικός"
            .Columns(3).HeaderText = "Περιγραφή"
            .Columns(4).HeaderText = "Διάσταση"
            .Columns(5).HeaderText = "Πελάτης"
            .Columns(6).HeaderText = "Ποσότητα Παραγωγής"
            .Columns(7).HeaderText = "Ημ/νία Παραγωγής"
            .Columns(8).HeaderText = "Κατ."
            .Columns(9).HeaderText = "Επιστρ. Α"
            .Columns(10).HeaderText = "Επιστρ. Β"
            .Columns(11).HeaderText = "Λευκή"
            .Columns(12).HeaderText = "Χρωμ."
            .Columns(13).HeaderText = "Pantone"
            .Columns(14).HeaderText = "Τελική Επιστρ."
            .Columns(15).HeaderText = "Παρατηρήσεις"
            .Columns(16).HeaderText = "Ποσότητα Παραγωγής"
            .Columns(17).HeaderText = "Ποσότητα Ελαττωματικών"
            .Columns(18).HeaderText = "Παλέτα"
            .Columns(20).HeaderText = "Παρατηρήσεις Λιθογραφείου"

            .Columns(0).Visible = False
            .Columns(1).Visible = False
            .Columns(19).Visible = False

            .Columns(3).Width = 280
            .Columns(6).Width = 73
            .Columns(5).Width = 280
            .Columns(7).Width = 67
            .Columns(8).Width = 57

            For y = 9 To 14
                .Columns(y).Width = 50
            Next
            .Columns(13).Width = 70

            .Columns(6).DefaultCellStyle.Format = "N0"

            .Columns(16).DefaultCellStyle.Format = "N0"
            .Columns(17).DefaultCellStyle.Format = "N0"


            For j = 0 To 15
                .Columns(j).ReadOnly = True

            Next
            .Columns(18).ReadOnly = True
            For x = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Rows(x).Cells(19).Value = 1 Then
                    DataGridView1.Rows(x).ReadOnly = True
                End If
            Next

            DataGridView1.FirstDisplayedScrollingColumnIndex = 7

        End With
    End Sub
    Private Sub gridlayout_admin()
        With DataGridView1

            .Columns(2).HeaderText = "Kωδικός"
            .Columns(3).HeaderText = "Περιγραφή"
            .Columns(4).HeaderText = "Διάσταση"
            .Columns(5).HeaderText = "Πελάτης"
            .Columns(6).HeaderText = "Ποσότητα Παραγωγής"
            .Columns(7).HeaderText = "Ημ/νία Παραγωγής"
            .Columns(8).HeaderText = "Κατ."
            .Columns(9).HeaderText = "Επιστρ. Α"
            .Columns(10).HeaderText = "Επιστρ. Β"
            .Columns(11).HeaderText = "Λευκή"
            .Columns(12).HeaderText = "Χρωμ."
            .Columns(13).HeaderText = "Pantone"
            .Columns(14).HeaderText = "Τελική Επιστρ."
            .Columns(15).HeaderText = "Παρατηρήσεις"
            .Columns(16).HeaderText = "Πληρωμή"
            .Columns(17).HeaderText = "Ατελιέ 1"
            .Columns(18).HeaderText = "Ατελιέ 2"
            .Columns(19).HeaderText = "Ποσότητα Παραγωγής"
            .Columns(20).HeaderText = "Ποσότητα Ελαττωματικών"
            .Columns(21).HeaderText = "Παλέτα"
            .Columns(22).HeaderText = "Χρήστης"

            .Columns(0).Visible = False
            .Columns(1).Visible = False

            .Columns(3).Width = 280
            .Columns(6).Width = 73
            .Columns(5).Width = 280
            .Columns(7).Width = 67
            .Columns(8).Width = 57

            .Columns(6).DefaultCellStyle.Format = "N0"
            .Columns(20).DefaultCellStyle.Format = "N0"

        End With

        For f = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(f).ReadOnly = True
        Next
        DataGridView1.Columns(6).ReadOnly = False
        DataGridView1.Columns(7).ReadOnly = False
        DataGridView1.Columns(8).ReadOnly = False

        DataGridView1.Columns(16).ReadOnly = False

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lst.Count = 0 Then
            MessageBox.Show("Δεν έχετε επιλέξει γραμμές")
            Exit Sub
        End If
        Dim egkrisi, egkrisi2 As Integer
        Dim cmdtext As String = ""
        Dim cmdtext2 As String = ""
        Dim cmdtext3 As String = ""
        Dim newlst As New List(Of Integer)
        'Dim mytimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim new_date As String

        newlst = lst.Distinct().ToList
        For i = 0 To newlst.Count - 1
            'MessageBox.Show(newlst(i))

            If tmima = 101 Then

                If DataGridView1.Rows(newlst(i)).Cells(kolwna).Value = False Then
                    egkrisi = 0
                Else
                    egkrisi = 1
                End If
            End If
            If username = "atelie1" Then

                cmdtext = cmdtext & "update os_ylika set comments='" & DataGridView1.Rows(newlst(i)).Cells(15).Value.ToString & "', aatelier='" & egkrisi & "', aatelier_dt=Now() where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"
                'cmdtext2 = cmdtext & "update os_ylika set aatelier_dt='" & Now & "' where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"
            ElseIf username = "atelie2" Then
                cmdtext = cmdtext & "update os_ylika set comments='" & DataGridView1.Rows(newlst(i)).Cells(15).Value.ToString & "',batelier='" & egkrisi & "', batelier_dt=Now() where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"
                'cmdtext2 = cmdtext & "update os_ylika set batelier_dt='" & Now & "' where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"
            ElseIf tmima = 102 And sender1 <> "button3" Then

                If DataGridView1.Rows(newlst(i)).Cells(18).Value.ToString = "" Then

                    cmdtext = cmdtext & "update os_ylika set posotpar='" & DataGridView1.Rows(newlst(i)).Cells(16).Value & "', posotelatt='" & DataGridView1.Rows(newlst(i)).Cells(17).Value & "', posot_dt=Now(), user='" & username & "',parat_lith='" & DataGridView1.Rows(newlst(i)).Cells(20).Value & "' where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"
                    'If DataGridView1.Rows(newlst(i)).Cells(14).Value IsNot Nothing AndAlso DataGridView1.Rows(newlst(i)).Cells(14).Value.ToString <> "" Then
                    '    Dim paleta As String() = DataGridView1.Rows(newlst(i)).Cells(14).Value.ToString.Split(",")
                    '    For t = 0 To paleta.Length - 1

                    '        cmdtext2 = cmdtext2 & "insert into os_palletes values('" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "','" & paleta(t) & "');"
                    '    Next
                    'End If
                Else

                    cmdtext = cmdtext & "update os_ylika set posotpar='" & DataGridView1.Rows(newlst(i)).Cells(16).Value & "', posotelatt='" & DataGridView1.Rows(newlst(i)).Cells(17).Value & "', posot_dt=Now(), user='" & username & "',finalized=1,parat_lith='" & DataGridView1.Rows(newlst(i)).Cells(20).Value & "' where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"

                End If
                cmdtext2 = a
                If DataGridView1.Rows(newlst(i)).Cells(18).Value.ToString = "" Then
                    cmdtext3 = "delete from os_palletes where os_ylikaid='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "'"
                End If
            ElseIf tmima = 102 And sender1 = "button3" Then
                cmdtext = cmdtext & "update os_ylika set parat_lith='" & DataGridView1.Rows(newlst(i)).Cells(20).Value & "' where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"

            ElseIf username = "admin" Then
                If DataGridView1.Rows(newlst(i)).Cells(16).Value = False Then
                    egkrisi = 0
                Else
                    egkrisi = 1
                End If
                todecimalvalue(DataGridView1.Rows(newlst(i)).Cells(6).Value, finalqty)
                TODATE2(DataGridView1.Rows(newlst(i)).Cells(7).Value.ToString, new_date)
                cmdtext = cmdtext & "update os_ylika set finaldate='" & new_date & "',paid='" & egkrisi & "',finalqty='" & finalqty & "',mkat='" & DataGridView1.Rows(newlst(i)).Cells(8).Value & "' where id='" & DataGridView1.Rows(newlst(i)).Cells(0).Value & "';"
                'runquery(cmdtext)
            End If
        Next
        cmdtext = cmdtext & cmdtext2 & cmdtext3


        runquery(cmdtext)
        'runquery(cmdtext2)
        lst.Clear()
        If queryerror = False Then
            MessageBox.Show("Επιτυχής καταχώρηση")
            runquery("drop temporary table if exists t1")
            Button2.PerformClick()
            sender1 = ""
            If tmima = 101 Then

                For i = 0 To DataGridView1.RowCount - 1
                    If DataGridView1.Rows(i).Cells(kolwna).Value = True Then

                        DataGridView1.Rows(i).Cells(kolwna).ReadOnly = True
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        DataGridView1.BeginEdit(True)

        For u = 0 To lst.Count - 1
            DataGridView1.Rows(lst(u)).Selected = True

        Next
        If tmima = 102 AndAlso e.RowIndex <> -1 AndAlso DataGridView1.Rows(e.RowIndex).Cells(19).Value = 0 Then
            If e.ColumnIndex = 18 Then
                Form3.os_ylikaid = DataGridView1.Rows(e.RowIndex).Cells(0).Value
                Form3.rowindex = e.RowIndex
                'Form3.ShowDialog()
                formcontrol = "form2"
                Form3.Show()
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form4.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sender1 = "button3"
        Button1.PerformClick()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        lst.Clear()
        TODATE(DateTimePicker1, date1)
        TODATE2(DateTimePicker2.Value.AddDays(1), date2)

        If username = "atelie1" Then
            kolwna = 16
            If RadioButton1.Checked = True Then

                If CheckBox1.Checked = True Then
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,colors,comments,aatelier,batelier from os_ylika where executed=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where executed=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                ElseIf CheckBox2.Checked = True Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and executed=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)

                Else
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,aatelier,batelier from os_ylika where aatelier=0 and executed=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=0 and executed=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)

                End If
            ElseIf RadioButton2.Checked = True Then
                loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and executed=1 and aatelier_dt>='" & date1 & "' and aatelier_dt<='" & date2 & "'", DataGridView1)
            End If
            gridlayout_at()
        ElseIf username = "atelie2" Then
            If RadioButton1.Checked = True Then

                If CheckBox1.Checked = True Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                ElseIf CheckBox2.Checked = True Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)

                Else
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=0 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                End If
            ElseIf RadioButton2.Checked = True Then
                loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,aatelier,batelier,sxesi from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and batelier_dt>='" & date1 & "' and batelier_dt<='" & date2 & "'", DataGridView1)

            End If
            kolwna = 17
            gridlayout_at()
        ElseIf tmima = 102 Or username = "lithografeio" Then
            If RadioButton1.Checked = True Then

                If CheckBox1.Checked = True Then
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,colors,comments,aatelier,batelier,posotpar,posotelatt,palletanumber from os_ylika left join os_palletes on id=os_ylikaid where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,aatelier,batelier,posotpar,posotelatt,null,finalized,parat_lith from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' order by mkat desc,fdimension desc", DataGridView1)
                ElseIf CheckBox2.Checked = True Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'  and finalized=1 order by mkat desc,fdimension desc", DataGridView1)

                Else

                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,colors,comments,aatelier,batelier,posotpar,posotelatt,palletanumber from os_ylika left join os_palletes on id=os_ylikaid where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and palletanumber is null", DataGridView1)
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,colors,comments,aatelier,batelier,posotpar,posotelatt,null,finalized,parat_lith from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and id not in (select os_ylikaid from os_palletes)", DataGridView1)
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0  order by mkat desc,fdimension desc", DataGridView1)
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,aatelier,batelier,posotpar,posotelatt,null,finalized,parat_lith from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0", DataGridView1)

                End If
            ElseIf RadioButton2.Checked = True Then
                loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1  and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "'  and finalized=1 order by mkat desc,fdimension desc", DataGridView1)

            End If
            gridlayout_lith()

            For p = 0 To DataGridView1.RowCount - 1
                dtvaluetoset("select palletanumber from os_palletes where os_ylikaid='" & DataGridView1.Rows(p).Cells(0).Value & "'")
                keli18 = ""
                For d = 0 To dt.Rows.Count - 1
                    keli18 = dt.Rows(d).Item(0).ToString & "," & keli18

                Next
                keli18 = keli18.TrimEnd(",")
                DataGridView1.Rows(p).Cells(18).Value = keli18

            Next
        ElseIf username = "admin" Then
            If RadioButton1.Checked = True Then

                If ComboBox1.Text = "" Then

                    If CheckBox1.Checked = True Then
                        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)

                        'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0", DataGridView1)
                    ElseIf CheckBox2.Checked = True Then
                        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1", DataGridView1)

                    Else
                        'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1", DataGridView1)
                        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0", DataGridView1)

                    End If
                Else
                    If CheckBox1.Checked = True Then
                        'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0 and user='" & ComboBox1.Text & "'", DataGridView1)
                        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and user='" & ComboBox1.Text & "'", DataGridView1)
                    ElseIf CheckBox2.Checked = True Then

                        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'", DataGridView1)

                    Else
                        'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'", DataGridView1)
                        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0 and user='" & ComboBox1.Text & "'", DataGridView1)

                    End If
                End If
            ElseIf RadioButton2.Checked = True Then
                If ComboBox1.Text = "" Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1", DataGridView1)
                Else
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'", DataGridView1)

                End If
            End If
            gridlayout_admin()
            For v = 0 To DataGridView1.RowCount - 1
                dtvaluetoset("select palletanumber from os_palletes where os_ylikaid='" & DataGridView1.Rows(v).Cells(0).Value & "'")
                keli18 = ""
                For l = 0 To dt.Rows.Count - 1
                    keli18 = dt.Rows(l).Item(0).ToString & "," & keli18

                Next
                keli18 = keli18.TrimEnd(",")
                DataGridView1.Rows(v).Cells(21).Value = keli18
            Next
        ElseIf username = "athena" Then
            If RadioButton1.Checked = True Then

                'If ComboBox1.Text = "" Then

                If CheckBox1.Checked = True Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'", DataGridView1)

                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0", DataGridView1)
                ElseIf CheckBox2.Checked = True Then
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and fdate>='" & date1 & "' and fdate<='" & date2 & "' and finalized=1", DataGridView1)

                Else
                    'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1", DataGridView1)
                    loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,null from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0", DataGridView1)

                End If
                'Else
                '    If CheckBox1.Checked = True Then
                '        'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0 and user='" & ComboBox1.Text & "'", DataGridView1)
                '        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and user='" & ComboBox1.Text & "'", DataGridView1)
                '    ElseIf CheckBox2.Checked = True Then

                '        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'", DataGridView1)

                '    Else
                '        'loadgrid("select id,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'", DataGridView1)
                '        loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0 and user='" & ComboBox1.Text & "'", DataGridView1)

                '    End If
                'End If
            ElseIf RadioButton2.Checked = True Then
                'If ComboBox1.Text = "" Then
                loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where fdate>='" & date1 & "' and fdate<='" & date2 & "'", DataGridView1)
                'Else
                'loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra, eidi_plus.epistrb, eidi_plus.leuki, eidi_plus.xrwm, eidi_plus.pantone, eidi_plus.final_epistr,comments,paid,aatelier,batelier,posotpar,posotelatt,null,user from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and fdate>='" & date1 & "' and fdate<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'", DataGridView1)

                'End If
            End If
            gridlayout_admin()
            For v = 0 To DataGridView1.RowCount - 1
                dtvaluetoset("select palletanumber from os_palletes where os_ylikaid='" & DataGridView1.Rows(v).Cells(0).Value & "'")
                keli18 = ""
                For l = 0 To dt.Rows.Count - 1
                    keli18 = dt.Rows(l).Item(0).ToString & "," & keli18

                Next
                keli18 = keli18.TrimEnd(",")
                DataGridView1.Rows(v).Cells(21).Value = keli18
            Next
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Application.OpenForms().OfType(Of Form5).Any Then
            Form5.Close()
        End If
        formcontrol = "button5"
        TODATE(DateTimePicker1, date1)
        TODATE2(DateTimePicker2.Value.AddDays(1), date2)
        If ComboBox1.Text = "" Then
            dtvaluetoset("select id,code,posotpar,posotelatt,posot_dt from os_ylika where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1")
        Else
            dtvaluetoset("select id,code,posotpar,posotelatt,posot_dt from os_ylika where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 and user='" & ComboBox1.Text & "'")
        End If
        If dt.Rows.Count > 0 Then
            Form5.date1 = date1
            Form5.date2 = date2
            'TODATE(DateTimePicker1, Form5.date1)
            'TODATE(DateTimePicker2, Form5.date2)
            Form5.user = ComboBox1.Text
            Form5.Show()
        Else
            MessageBox.Show("Δε βρέθηκαν εγγραφές")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Application.OpenForms().OfType(Of Form5).Any Then
            Form5.Close()
        End If
        'If tmima <> 102 Then
        formcontrol = "button6" & username
        'Else
        'formcontrol = "button6lithografeio"
        'End If
        TODATE(DateTimePicker1, Form5.date1)
        TODATE2(DateTimePicker2.Value.AddDays(1), Form5.date2)
        Form5.user = ComboBox1.Text
        Form5.Show()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Button6.Enabled = False
            Button5.Enabled = False
            CheckBox1.Enabled = True
            ComboBox1.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ComboBox1.Enabled = True
            Button5.Enabled = True
            'If ComboBox2.Text <> "" Then
            Button6.Enabled = True
            'End If
            CheckBox2.Checked = True
            CheckBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
        End If

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        keli18 = ""
        date1 = ""
        date2 = ""
        finalqty = ""
        kolwna = -1
        Form5.user = ""
        If RadioButton2.Checked Then
            Button6.Enabled = True
        End If
        'RadioButton1.Checked = True
        username = ComboBox2.Text
        If username = "admin" Then
            '    ComboBox1.Visible = True
            '    Label1.Visible = True
            '    Button5.Visible = True
            '    Button6.Visible = True
            '    'tmima = 102

            '    runquerycombo("SELECT username FROM promusers WHERE tmima=102", ComboBox1, "username")
            'Else
            '    tmima = 0
            username = "athena"
            'TODATE(DateTimePicker1, date1)
            'TODATE2(DateTimePicker2.Value.AddDays(1), date2)
            'loadgrid("select fdate,count(id) from os_ylika where aatelier=1 and batelier=1 and paid=1 and fdate>='" & date1 & "' and fdate<='" & date2 & "' and finalized=1 group by fdate order by fdate asc ", DataGridView1)
            'Exit Sub
        End If
        'If username = "lithografeio" Then
        '    tmima = 102
        '    Button3.Visible = True
        '    Button4.Visible = False
        'Else
        '    tmima = 0
        'End If
        If username = "atelie1" Or username = "atelie2" Then
            Label1.Visible = False
            ComboBox1.Visible = False
        Else
            Label1.Visible = True
            ComboBox1.Visible = True
        End If
        Button2.PerformClick()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick

        If lst.Contains(e.RowIndex) Then
            DataGridView1.Rows(e.RowIndex).Selected = False
            lst.Remove(e.RowIndex)
        Else
            lst.Add(e.RowIndex)

        End If
        For u = 0 To lst.Count - 1
            'If DataGridView1.Rows(lst(u)).Selected = False Then
            DataGridView1.Rows(lst(u)).Selected = True

        Next

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.ColumnIndex = 2 And tmima <> 102 Then
            Form4.eidos = DataGridView1.CurrentRow.Cells(1).Value
            Form4.rowindex = DataGridView1.CurrentRow.Index
            formcontrol = "form2"
            Form4.TextBox2.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
            Form4.TextBox3.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString

            Form4.Show()
        End If
    End Sub
    Private Sub todecimalvalue(val As String, ByRef ex As String)
        If val.Contains(",") Then
            ex = val.Replace(",", ".")
        Else
            ex = val
        End If

    End Sub

    Private Sub DataGridView1_ColumnHeaderMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.ColumnHeaderMouseClick
        lst.Clear()

        If tmima = 102 And e.ColumnIndex <> 8 And e.ColumnIndex <> 18 Then
            Dim newquery, column_name As String
            If e.ColumnIndex = 2 Then
                column_name = ",code desc"
            ElseIf e.ColumnIndex = 3 Then
                column_name = ",perigrafi desc"
            ElseIf e.ColumnIndex = 4 Then
                column_name = ",fdimension desc"
            ElseIf e.ColumnIndex = 5 Then
                column_name = ",eponymia desc"
            ElseIf e.ColumnIndex = 6 Then
                column_name = ",finalqty desc"
            ElseIf e.ColumnIndex = 7 Then
                column_name = ",finaldate asc"

            ElseIf e.ColumnIndex = 9 Then
                column_name = ",eidi_plus.epistra desc"
            ElseIf e.ColumnIndex = 10 Then
                column_name = ",eidi_plus.epistrb desc"
            ElseIf e.ColumnIndex = 11 Then
                column_name = ",eidi_plus.leuki desc"
            ElseIf e.ColumnIndex = 12 Then
                column_name = ",eidi_plus.xrwm desc"
            ElseIf e.ColumnIndex = 13 Then
                column_name = ",eidi_plus.pantone desc"
            ElseIf e.ColumnIndex = 14 Then
                column_name = ",eidi_plus.final_epistr desc"
            ElseIf e.ColumnIndex = 15 Then
                column_name = ",comments desc"
            ElseIf e.ColumnIndex = 16 Then
                column_name = ",posotpar desc"
            ElseIf e.ColumnIndex = 17 Then
                column_name = ",posotelatt desc"

            ElseIf e.ColumnIndex = 20 Then
                column_name = ",parat_lith desc"
            End If

            If RadioButton1.Checked = True Then

                If CheckBox1.Checked = True Then
                    newquery = "select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' order by mkat desc,"
                    'loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' order by mkat desc,fdimension desc", DataGridView1)
                    loadgrid(newquery & column_name, DataGridView1)
                ElseIf CheckBox2.Checked = True Then
                    newquery = "select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'  and finalized=1 order by mkat desc"
                    loadgrid(newquery & column_name, DataGridView1)

                    'loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "'  and finalized=1 order by mkat desc,fdimension desc", DataGridView1)

                Else

                    newquery = "select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0  order by mkat desc"
                    'loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1 and batelier=1 and paid=1 and finaldate>='" & date1 & "' and finaldate<='" & date2 & "' and finalized=0  order by mkat desc,fdimension desc", DataGridView1)
                    loadgrid(newquery & column_name, DataGridView1)
                End If
            ElseIf RadioButton2.Checked = True Then
                'loadgrid("select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1  and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "'  and finalized=1 order by mkat desc,fdimension desc", DataGridView1)
                newquery = "select id,os_ylika.eidos,code,perigrafi,fdimension,eponymia,finalqty,finaldate,mkat,eidi_plus.epistra,eidi_plus.epistrb,eidi_plus.leuki,eidi_plus.xrwm,eidi_plus.pantone,eidi_plus.final_epistr,comments,posotpar,posotelatt,null,finalized,parat_lith from os_ylika left join eidi_plus on os_ylika.eidos=eidi_plus.eidos where aatelier=1  and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "'  and finalized=1 order by mkat desc"
                loadgrid(newquery & column_name, DataGridView1)

            End If
            gridlayout_lith()

            For p = 0 To DataGridView1.RowCount - 1
                dtvaluetoset("select palletanumber from os_palletes where os_ylikaid='" & DataGridView1.Rows(p).Cells(0).Value & "'")
                keli18 = ""
                For d = 0 To dt.Rows.Count - 1
                    keli18 = dt.Rows(d).Item(0).ToString & "," & keli18

                Next
                keli18 = keli18.TrimEnd(",")
                DataGridView1.Rows(p).Cells(18).Value = keli18

            Next
        End If
    End Sub


    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then

            If DataGridView1.CurrentCell.ColumnIndex = 2 Then
                Form11.eidos = DataGridView1.CurrentRow.Cells(1).Value
                Form11.TextBox1.Text = DataGridView1.CurrentCell.Value
                Form11.Show()
                Form11.Focus()
            End If
        End If
    End Sub
End Class