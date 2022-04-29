Imports System.IO.StreamWriter
Public Class Form5
    Public date1, date2, user As String
    Dim dat, dat2 As DateTime
    Dim cellvalue As String
    Dim sunolo1, sunolo2, lepta As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim posot, elat, minas, usr, txt, fileloc As String
        SaveFileDialog1.Filter = "CSV Files (*.csv*)|*.csv"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
       Then
            fileloc = SaveFileDialog1.FileName
        Else
            Exit Sub
        End If
        Dim header As String = "Σωστά;Ελλατωματικά;Μήνας;Χειριστής"
        dtvaluetoset("select sum(posotpar)-sum(posotelatt),sum(posotelatt),date_format(posot_dt,'%M'),user from os_ylika where aatelier=1 and batelier=1 and paid=1 and finalized=1 and user is not null and user<>'lithografeio' and year(posot_dt)='" & TextBox5.Text & "' group by user,date_format(posot_dt,'%M')  order by month(posot_dt),user")
        Using sw As New System.IO.StreamWriter(fileloc, False, System.Text.Encoding.UTF8)
            For i = 0 To dt.Rows.Count - 1
                Dim lst As New List(Of String)
                posot = dt.Rows(i).Item(0)
                lst.Add(posot)
                elat = dt.Rows(i).Item(1)
                lst.Add(elat)
                minas = dt.Rows(i).Item(2)
                lst.Add(minas)
                usr = dt.Rows(i).Item(3)
                lst.Add(usr)
                txt = txt & lst(0) & ";" & lst(1) & ";" & lst(2) & ";" & lst(3) & vbCrLf
            Next
            sw.WriteLine(header & vbCrLf & txt)

        End Using
    End Sub
    Dim sunolo3 As Double
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If formcontrol = "button5" Then
            Button1.Enabled = True
            TextBox5.Enabled = True
            TextBox5.Text = Date.Today.Year
            Me.ShowIcon = False
            If user = "" Then
                loadgrid("select id,code,posotpar,posotelatt,null,posot_dt,null,null from os_ylika where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 order by posot_dt asc", DataGridView1)
            Else
                loadgrid("select id,code,posotpar,posotelatt,null,posot_dt,null,null from os_ylika where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 and user='" & user & "' order by posot_dt asc", DataGridView1)

            End If

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(5).Visible = False

            DataGridView1.Columns(1).Width = 161
            DataGridView1.Columns(1).HeaderText = "Κωδικός"
            DataGridView1.Columns(2).HeaderText = "Ποσότητα Παραγωγής"
            DataGridView1.Columns(3).HeaderText = "Ποσότητα Ελαττωματικών"
            DataGridView1.Columns(4).HeaderText = "Συνολικός χρόνος (ώρες)"
            DataGridView1.Columns(7).HeaderText = "Ποσοστό Ελαττωματικών /1000"
            DataGridView1.Columns(6).HeaderText = "Παραγωγή/Ωρα"

            For v = 2 To 4
                DataGridView1.Columns(v).DefaultCellStyle.Format = "N0"
            Next
            DataGridView1.Columns(7).DefaultCellStyle.Format = "N2"

            dat = returnsinglevaluequery("select posot_dt from os_ylika where id='" & DataGridView1.Rows(0).Cells(0).Value & "'")
            'dat2 = dat.AddHours(8)
            'DataGridView1.Rows(0).Cells(4).Value = returnsinglevaluequery("select TIMESTAMPDIFF(minute,'" & dat2.ToString("yyyy-MM-dd HH:mm:ss") & "',(select posot_dt from os_ylika where id='" & DataGridView1.Rows(0).Cells(0).Value & "'))")


            lepta = returnsinglevaluequery("select TIMESTAMPDIFF(minute,(select posot_dt from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate<'" & date1 & "' and finalized=1 and posot_dt<'" & dat.ToString("yyyy-MM-dd HH:mm:ss") & "' order by posot_dt desc limit 1),'" & dat.ToString("yyyy-MM-dd HH:mm:ss") & "')")
            'dat = returnsinglevaluequery("select posot_dt from os_ylika where id='" & DataGridView1.Rows(0).Cells(0).Value & "'")
            'dat2 = returnsinglevaluequery("select posot_dt from os_ylika where aatelier=1 and batelier=1 and paid=1 and finaldate<'" & date1 & "' and finalized=1 and posot_dt<'" & dat.ToString("yyyy-MM-dd HH:mm:ss") & "' order by posot_dt desc limit 1")
            If lepta < 720 Then

                DataGridView1.Rows(0).Cells(4).Value = Math.Round(lepta / 60, 2)
            Else
                dat = returnsinglevaluequery("select DATE((select posot_dt from os_ylika where id='" & DataGridView1.Rows(0).Cells(0).Value & "'))")

                'lepta = returnsinglevaluequery("select TIMESTAMPDIFF(minute,'" & dat2.ToString("yyyy-MM-dd HH:mm:ss") & "','" & dat.ToString("yyyy-MM-dd HH:mm:ss") & "')")
                dat2 = dat.AddHours(6)
                lepta = returnsinglevaluequery("select TIMESTAMPDIFF(minute,'" & dat2.ToString("yyyy-MM-dd HH:mm:ss") & "',(select posot_dt from os_ylika where id='" & DataGridView1.Rows(0).Cells(0).Value & "'))")
                DataGridView1.Rows(0).Cells(4).Value = Math.Round(lepta / 60, 2)
            End If
            sunolo1 = Integer.Parse(DataGridView1.Rows(0).Cells(2).Value.ToString)
            sunolo2 = Integer.Parse(DataGridView1.Rows(0).Cells(3).Value.ToString)
            sunolo3 = Double.Parse(DataGridView1.Rows(0).Cells(4).Value.ToString)
            DataGridView1.Rows(0).Cells(7).Value = Math.Round((DataGridView1.Rows(0).Cells(3).Value / DataGridView1.Rows(0).Cells(2).Value) * 1000, 2)
            DataGridView1.Rows(0).Cells(6).Value = Math.Round((DataGridView1.Rows(0).Cells(3).Value + DataGridView1.Rows(0).Cells(2).Value) / DataGridView1.Rows(0).Cells(4).Value, 2)

            For i = 1 To DataGridView1.RowCount - 2
                'cellvalue = returnsinglevaluequery("select TIMESTAMPDIFF(minute,(select posot_dt from os_ylika where id='" & DataGridView1.Rows(i - 1).Cells(0).Value & "'),(select posot_dt from os_ylika where id='" & DataGridView1.Rows(i).Cells(0).Value & "'))")
                cellvalue = Math.Round(DateDiff(DateInterval.Minute, DataGridView1.Rows(i - 1).Cells(5).Value, DataGridView1.Rows(i).Cells(5).Value) / 60, 2)

                If DateDiff(DateInterval.Day, DataGridView1.Rows(i - 1).Cells(5).Value, DataGridView1.Rows(i).Cells(5).Value) = 0 Then
                    DataGridView1.Rows(i).Cells(4).Value = cellvalue
                Else
                    If cellvalue < 12 Then
                        DataGridView1.Rows(i).Cells(4).Value = cellvalue
                    Else
                        'dat = returnsinglevaluequery("select DATE((select posot_dt from os_ylika where id='" & DataGridView1.Rows(i).Cells(0).Value & "'))")
                        'dat2 = dat.AddHours(8)
                        'DataGridView1.Rows(i).Cells(4).Value = returnsinglevaluequery("select TIMESTAMPDIFF(minute,'" & dat2.ToString("yyyy-MM-dd HH:mm:ss") & "',(select posot_dt from os_ylika where id='" & DataGridView1.Rows(i).Cells(0).Value & "'))")
                        dat = DateValue(DataGridView1.Rows(i).Cells(5).Value)
                        dat2 = dat.AddHours(6)
                        DataGridView1.Rows(i).Cells(4).Value = Math.Round(DateDiff(DateInterval.Minute, dat2, DataGridView1.Rows(i).Cells(5).Value) / 60, 2)
                    End If
                End If
                sunolo1 = Integer.Parse(DataGridView1.Rows(i).Cells(2).Value.ToString) + sunolo1
                sunolo2 = Integer.Parse(DataGridView1.Rows(i).Cells(3).Value.ToString) + sunolo2
                ' MessageBox.Show(DataGridView1.Rows(i).Cells(4).Value.ToString)
                sunolo3 = Double.Parse(DataGridView1.Rows(i).Cells(4).Value.ToString) + sunolo3

                If DataGridView1.Rows(i).Cells(2).Value <> 0 Then
                    DataGridView1.Rows(i).Cells(7).Value = Math.Round((DataGridView1.Rows(i).Cells(3).Value / DataGridView1.Rows(i).Cells(2).Value) * 1000, 2)
                End If
                If DataGridView1.Rows(i).Cells(4).Value <> 0 Then
                    DataGridView1.Rows(i).Cells(6).Value = Math.Round((DataGridView1.Rows(i).Cells(3).Value + DataGridView1.Rows(i).Cells(2).Value) / DataGridView1.Rows(i).Cells(4).Value, 2)
                End If
            Next
            TextBox1.Text = FormatNumber(sunolo1, 0)
            TextBox2.Text = FormatNumber(sunolo2, 0)
            TextBox3.Text = FormatNumber(sunolo3, 2)
            TextBox4.Text = Math.Round(sunolo2 / sunolo1, 2)
        ElseIf formcontrol = "button6lithografeio" Or formcontrol = "button6admin" Then
            If user = "" Then
                'loadgrid("select date(posot_dt),count(id),sum(posotpar),sum(posotelatt),round(TIMESTAMPDIFF(minute,min(posot_dt),max(posot_dt))/60,2) from os_ylika where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 group by date(posot_dt) order by date(posot_dt) asc ", DataGridView1)
                loadgrid("select date(posot_dt),count(id),sum(posotpar),sum(posotelatt) from os_ylika where aatelier=1 and batelier=1 and paid=1 and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 group by date(posot_dt) order by date(posot_dt) asc ", DataGridView1)

            Else
                'loadgrid("select date(posot_dt),count(id),sum(posotpar),sum(posotelatt),round(TIMESTAMPDIFF(minute,min(posot_dt),max(posot_dt))/60,2) from os_ylika where aatelier=1 and batelier=1 and paid=1 and user='" & user & "' and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 group by date(posot_dt) order by date(posot_dt) asc ", DataGridView1)
                loadgrid("select date(posot_dt),count(id),sum(posotpar),sum(posotelatt) from os_ylika where aatelier=1 and batelier=1 and paid=1 and user='" & user & "' and posot_dt>='" & date1 & "' and posot_dt<='" & date2 & "' and finalized=1 group by date(posot_dt) order by date(posot_dt) asc ", DataGridView1)

            End If
            formlayout()
        ElseIf formcontrol = "button6atelie1" Then

            'loadgrid("select date(aatelier_dt),count(id),sum(finalqty),round(TIMESTAMPDIFF(minute,min(aatelier_dt),max(aatelier_dt))/60,2) from os_ylika where aatelier=1 and executed=1 and aatelier_dt>='" & date1 & "' and aatelier_dt<='" & date2 & "' group by date(aatelier_dt) order by date(aatelier_dt) asc ", DataGridView1)
            loadgrid("select date(aatelier_dt),count(id),coalesce(sum(finalqty),0) from os_ylika where aatelier=1 and executed=1 and aatelier_dt>='" & date1 & "' and aatelier_dt<='" & date2 & "' group by date(aatelier_dt) order by date(aatelier_dt) asc ", DataGridView1)

            formlayout()
        ElseIf formcontrol = "button6atelie2" Then
            'loadgrid("select date(batelier_dt),count(id),sum(finalqty),round(TIMESTAMPDIFF(minute,min(batelier_dt),max(batelier_dt))/60,2) from os_ylika where aatelier=1 and batelier=1 and batelier_dt>='" & date1 & "' and batelier_dt<='" & date2 & "' group by date(batelier_dt) order by date(batelier_dt) asc ", DataGridView1)
            loadgrid("select date(batelier_dt),count(id),coalesce(sum(finalqty),0) from os_ylika where aatelier=1 and batelier=1 and batelier_dt>='" & date1 & "' and batelier_dt<='" & date2 & "' group by date(batelier_dt) order by date(batelier_dt) asc ", DataGridView1)

            formlayout()
        ElseIf formcontrol = "button6athena" Then
            'loadgrid("select date(fdate),count(id),sum(finalqty) from os_ylika where aatelier=1 and batelier=1 and paid=1 and fdate>='" & date1 & "' and fdate<='" & date2 & "' and finalized=1 group by date(posot_dt) order by date(posot_dt) asc ", DataGridView1)
            loadgrid("select date(fdate),count(id),coalesce(sum(finalqty),0) from os_ylika where fdate>='" & date1 & "' and fdate<='" & date2 & "' group by date(fdate) order by date(fdate) asc ", DataGridView1)

            formlayout()
        End If

    End Sub
    Private Sub formlayout()
        'TextBox1.Visible = False
        'TextBox2.Visible = False
        TextBox4.Visible = False
        'Label1.Visible = False
        DataGridView1.Columns(2).DefaultCellStyle.Format = "N0"
        DataGridView1.Columns(0).Width = 154

        DataGridView1.Columns(0).HeaderText = "Ημέρα"
        DataGridView1.Columns(1).HeaderText = "Σύνολο Εντολών Ημέρας"
        If formcontrol = "button6atelie1" Or formcontrol = "button6atelie2" Or formcontrol = "button6athena" Then
            TextBox3.Visible = False

            DataGridView1.Width = 400

            DataGridView1.Columns(2).HeaderText = "Συνολική Ποσότητα Προς Παραγωγή"
            'DataGridView1.Columns(3).HeaderText = "Συνολικός Χρόνος"
            For i = 0 To DataGridView1.RowCount - 2
                sunolo2 = DataGridView1.Rows(i).Cells(2).Value + sunolo2
                'sunolo2 = DataGridView1.Rows(i).Cells(3).Value
                sunolo1 = DataGridView1.Rows(i).Cells(1).Value + sunolo1

            Next
        End If
        If formcontrol = "button6lithografeio" Or formcontrol = "button6admin" Then
            DataGridView1.Width = 500

            DataGridView1.Columns(2).HeaderText = "Συνολική Ποσότητα Παραγωγής"
            DataGridView1.Columns(3).HeaderText = "Συνολική Ποσότητα Ελαττωματικών"
            'DataGridView1.Columns(4).HeaderText = "Συνολικός Χρόνος"
            DataGridView1.Columns(3).DefaultCellStyle.Format = "N0"
            For i = 0 To DataGridView1.RowCount - 2
                sunolo1 = DataGridView1.Rows(i).Cells(1).Value + sunolo1

                sunolo2 = DataGridView1.Rows(i).Cells(2).Value + sunolo2
                sunolo3 = DataGridView1.Rows(i).Cells(3).Value + sunolo3

            Next
        End If
        TextBox1.Text = sunolo1

        TextBox2.Text = sunolo2
        TextBox3.Text = sunolo3

    End Sub
End Class