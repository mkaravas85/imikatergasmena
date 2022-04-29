Public Class Form11
    Dim date1, date2 As String
    Public eidos As Integer
    Private Sub Form11_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TODATE(DateTimePicker1, date1)
        TODATE(DateTimePicker2, date2)
        loadgrid("select distinct palletanumber from os_palletes where os_ylikaid in (select id from os_ylika where eidos='" & eidos & "' and date(posot_dt)>='" & date1 & "' and date(posot_dt)<='" & date2 & "')", DataGridView1)
        DataGridView1.Columns(0).HeaderText = "Αρ. Παλέτας"
    End Sub
End Class