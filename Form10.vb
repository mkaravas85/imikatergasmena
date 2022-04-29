'Imports MySql.Data.MySqlClient
Public Class Form10
    Public proion, yliko As Integer
    Dim ctl As Control
    Dim y As Integer = 120
    Public cmb1, cmb6, cmb7, cmb8, cmb9, cmb10 As New CustomControl1
    Dim cmb2, cmb3, cmb4, cmb5 As New CustomControl1
    'Public col1 As Color
    Dim col18 As New DataGridViewColumn
    Dim kataxwrisi As Boolean = False
    Private Sub Form10_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        Button4.Enabled = False
        'col1 = Button2.BackColor

        cmb1.Location = New Point(6, 120)
        cmb2.Location = New Point(6, 160)
        cmb3.Location = New Point(6, 200)
        cmb4.Location = New Point(6, 240)
        cmb5.Location = New Point(6, 280)
        cmb1.DropDownStyle = ComboBoxStyle.DropDownList
        cmb2.DropDownStyle = ComboBoxStyle.DropDownList
        cmb3.DropDownStyle = ComboBoxStyle.DropDownList
        cmb4.DropDownStyle = ComboBoxStyle.DropDownList
        cmb5.DropDownStyle = ComboBoxStyle.DropDownList

        cmb1.Enabled = False
        cmb2.Enabled = False
        cmb3.Enabled = False
        cmb4.Enabled = False
        cmb5.Enabled = False

        GroupBox1.Controls.Add(cmb1)
        GroupBox1.Controls.Add(cmb2)
        GroupBox1.Controls.Add(cmb3)
        GroupBox1.Controls.Add(cmb4)
        GroupBox1.Controls.Add(cmb5)

        For Each ctl In GroupBox1.Controls
            If TypeOf ctl Is CustomControl1 Then
                ctl.Size = New Size(177, 21)

            End If
        Next

        AddHandler cmb1.SelectedIndexChanged, AddressOf ComboBox1_SelectedIndexChanged
        AddHandler cmb2.SelectedIndexChanged, AddressOf ComboBox2_SelectedIndexChanged
        AddHandler cmb3.SelectedIndexChanged, AddressOf ComboBox3_SelectedIndexChanged
        AddHandler cmb4.SelectedIndexChanged, AddressOf ComboBox4_SelectedIndexChanged
        AddHandler cmb5.SelectedIndexChanged, AddressOf ComboBox5_SelectedIndexChanged

        runquerycombo("select name from grammes_paragogis", cmb1, "name")
        runquerycombo("select name from grammes_paragogis", cmb2, "name")
        runquerycombo("select name from grammes_paragogis", cmb3, "name")
        runquerycombo("select name from grammes_paragogis", cmb4, "name")
        runquerycombo("select name from grammes_paragogis", cmb5, "name")



        cmb6.Location = New Point(6, 68)
        cmb7.Location = New Point(6, 108)
        cmb8.Location = New Point(6, 148)
        cmb9.Location = New Point(6, 188)
        cmb10.Location = New Point(6, 228)

        cmb6.DropDownStyle = ComboBoxStyle.DropDownList
        cmb7.DropDownStyle = ComboBoxStyle.DropDownList
        cmb8.DropDownStyle = ComboBoxStyle.DropDownList
        cmb9.DropDownStyle = ComboBoxStyle.DropDownList
        cmb10.DropDownStyle = ComboBoxStyle.DropDownList

        'cmb6.Enabled = False
        cmb7.Enabled = False
        cmb8.Enabled = False
        cmb9.Enabled = False
        cmb10.Enabled = False

        GroupBox2.Controls.Add(cmb6)
        GroupBox2.Controls.Add(cmb7)
        GroupBox2.Controls.Add(cmb8)
        GroupBox2.Controls.Add(cmb9)
        GroupBox2.Controls.Add(cmb10)

        For Each ctl In GroupBox2.Controls
            If TypeOf ctl Is CustomControl1 Then
                ctl.Size = New Size(177, 21)

            End If
        Next

        AddHandler cmb6.SelectedIndexChanged, AddressOf ComboBox6_SelectedIndexChanged
        AddHandler cmb7.SelectedIndexChanged, AddressOf ComboBox7_SelectedIndexChanged
        AddHandler cmb8.SelectedIndexChanged, AddressOf ComboBox8_SelectedIndexChanged
        AddHandler cmb9.SelectedIndexChanged, AddressOf ComboBox9_SelectedIndexChanged
        AddHandler cmb10.SelectedIndexChanged, AddressOf ComboBox10_SelectedIndexChanged

        AddHandler cmb6.Click, AddressOf ComboBox6_Click
        AddHandler cmb7.Click, AddressOf ComboBox7_Click
        AddHandler cmb8.Click, AddressOf ComboBox8_Click
        AddHandler cmb9.Click, AddressOf ComboBox9_Click
        AddHandler cmb10.Click, AddressOf ComboBox10_Click

        runquerycombo("select name from grammes_paragogis", cmb6, "name")
        runquerycombo("select name from grammes_paragogis", cmb7, "name")
        runquerycombo("select name from grammes_paragogis", cmb8, "name")
        runquerycombo("select name from grammes_paragogis", cmb9, "name")
        runquerycombo("select name from grammes_paragogis", cmb10, "name")

        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima<>'" & cmb6.id & "')", cmb7, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb8, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb9, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb10, "name")

    End Sub

    Private Sub datagridview2_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If Button3.BackColor = Color.CornflowerBlue Then

            If e.ColumnIndex <> 3 Then
                cmb1.SelectedIndex = -1
                cmb2.SelectedIndex = -1
                cmb3.SelectedIndex = -1
                cmb4.SelectedIndex = -1
                cmb5.SelectedIndex = -1

                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                dtvaluetoset("select grammes_paragogis.name,posotita,tmima,eidi.code,eidi.perigrafi from grammes_par_ylika join grammes_paragogis on tmima=grammes_paragogis.id join eidi on yliko=eidos where yliko='" & DataGridView2.CurrentRow.Cells(0).Value & "' and proion='" & proion & "'")
                'If dt.Rows.Count > 0 Then
                TextBox2.ReadOnly = True
                TextBox2.Text = dt.Rows(0).Item(3)
                TextBox16.Text = dt.Rows(0).Item(4)
                'End If
                yliko = DataGridView2.CurrentRow.Cells(0).Value

                If dt.Rows.Count = 1 Then
                    cmb1.Text = dt.Rows(0).Item(0)
                    TextBox3.Text = dt.Rows(0).Item(1)
                    cmb1.Enabled = True
                    cmb2.Enabled = False
                    cmb3.Enabled = False
                    cmb4.Enabled = False
                    cmb5.Enabled = False
                    cmb1.id = dt.Rows(0).Item(2)
                End If
                If dt.Rows.Count = 2 Then
                    cmb1.Text = dt.Rows(0).Item(0)
                    TextBox3.Text = dt.Rows(0).Item(1)
                    cmb2.Text = dt.Rows(1).Item(0)
                    TextBox4.Text = dt.Rows(1).Item(1)
                    cmb1.Enabled = True
                    cmb2.Enabled = True
                    cmb3.Enabled = False
                    cmb4.Enabled = False
                    cmb5.Enabled = False
                    cmb1.id = dt.Rows(0).Item(2)
                    cmb2.id = dt.Rows(1).Item(2)

                End If
                If dt.Rows.Count = 3 Then
                    cmb1.Text = dt.Rows(0).Item(0)
                    TextBox3.Text = dt.Rows(0).Item(1)
                    cmb2.Text = dt.Rows(1).Item(0)
                    TextBox4.Text = dt.Rows(1).Item(1)
                    cmb3.Text = dt.Rows(2).Item(0)
                    TextBox5.Text = dt.Rows(2).Item(1)
                    cmb1.Enabled = True
                    cmb2.Enabled = True
                    cmb3.Enabled = True
                    cmb4.Enabled = False
                    cmb5.Enabled = False
                    cmb1.id = dt.Rows(0).Item(2)
                    cmb2.id = dt.Rows(1).Item(2)
                    cmb3.id = dt.Rows(2).Item(2)

                End If
                If dt.Rows.Count = 4 Then
                    cmb1.Text = dt.Rows(0).Item(0)
                    TextBox3.Text = dt.Rows(0).Item(1)
                    cmb2.Text = dt.Rows(1).Item(0)
                    TextBox4.Text = dt.Rows(1).Item(1)
                    cmb3.Text = dt.Rows(2).Item(0)
                    TextBox5.Text = dt.Rows(2).Item(1)
                    cmb4.Text = dt.Rows(3).Item(0)
                    TextBox6.Text = dt.Rows(3).Item(1)
                    cmb1.Enabled = True
                    cmb2.Enabled = True
                    cmb3.Enabled = True
                    cmb4.Enabled = True
                    cmb5.Enabled = False
                    cmb1.id = dt.Rows(0).Item(2)
                    cmb2.id = dt.Rows(1).Item(2)
                    cmb3.id = dt.Rows(2).Item(2)
                    cmb4.id = dt.Rows(3).Item(2)

                End If
                If dt.Rows.Count = 5 Then
                    cmb1.Text = dt.Rows(0).Item(0)
                    TextBox3.Text = dt.Rows(0).Item(1)
                    cmb2.Text = dt.Rows(1).Item(0)
                    TextBox4.Text = dt.Rows(1).Item(1)
                    cmb3.Text = dt.Rows(2).Item(0)
                    TextBox5.Text = dt.Rows(2).Item(1)
                    cmb4.Text = dt.Rows(3).Item(0)
                    TextBox6.Text = dt.Rows(3).Item(1)
                    cmb5.Text = dt.Rows(4).Item(0)
                    TextBox7.Text = dt.Rows(4).Item(1)
                    cmb1.Enabled = True
                    cmb2.Enabled = True
                    cmb3.Enabled = True
                    cmb4.Enabled = True
                    cmb5.Enabled = True
                    cmb1.id = dt.Rows(0).Item(2)
                    cmb2.id = dt.Rows(1).Item(2)
                    cmb3.id = dt.Rows(2).Item(2)
                    cmb4.id = dt.Rows(3).Item(2)
                    cmb5.id = dt.Rows(4).Item(2)

                End If
            ElseIf e.ColumnIndex = 3 Then
                runquery("delete from grammes_par_ylika where yliko='" & DataGridView2.CurrentRow.Cells(0).Value & "' and proion='" & proion & "'")
                DataGridView2.Columns.Clear()
                loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
                gridlayout2()
            End If
            TextBox2.ReadOnly = False
        End If

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
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        'If Button2.BackColor = Color.CornflowerBlue Then
        If keyData = Keys.Enter Then     ' YES
            If TextBox1.Focused Then
                dtvaluetoset("select eidos,code,perigrafi from eidi where code like '" & TextBox1.Text & "%'")
                If dt.Rows.Count < 1 Then
                    MessageBox.Show("Δε βρέθηκαν εγγραφές")
                    Exit Function
                End If
                If dt.Rows.Count = 1 Then
                    proion = dt.Rows(0).Item(0)
                    cmb6.Enabled = True
                    ' returnsinglevaluequery("select proion from grammes_par_ylika where proion='" & proion & "'")
                    If Button2.BackColor = Color.CornflowerBlue Then

                        If (((returnsinglevaluequery("select proion from grammes_par_ylika where proion='" & proion & "'")) IsNot Nothing Or ((returnsinglevaluequery("select proion from grammes_par_pososta where proion='" & proion & "'") IsNot Nothing)))) Then
                            MessageBox.Show("Για το συγκεκριμένο προιόν υπάρχει ήδη καταχώρηση είτε στα υλικά είτε στους χρόνους." & vbCrLf & "Επιλέξτε μεταβολή")
                            proion = 0
                            Exit Function
                        Else
                            TextBox1.Text = dt.Rows(0).Item(1)
                            TextBox15.Text = dt.Rows(0).Item(2)
                            Exit Function
                        End If
                    ElseIf Button2.BackColor <> Color.CornflowerBlue And Button3.BackColor <> Color.CornflowerBlue Then
                        If (((returnsinglevaluequery("select proion from grammes_par_ylika where proion='" & proion & "'")) Is Nothing And ((returnsinglevaluequery("select proion from grammes_par_pososta where proion='" & proion & "'") Is Nothing)))) Then
                            MessageBox.Show("Δε βρέθηκε καταχώρηση για το συγκεκριμένο προιόν.")
                            proion = 0
                            Exit Function
                        End If
                    End If
                    TextBox1.Text = dt.Rows(0).Item(1)
                    TextBox15.Text = dt.Rows(0).Item(2)
                    Button3.Enabled = True
                    dtvaluetoset("select grammes_paragogis.name,suntelestis,tmima from grammes_par_pososta join grammes_paragogis on tmima=grammes_paragogis.id where proion='" & proion & "'")
                    If dt.Rows.Count = 1 Then
                        cmb6.Text = dt.Rows(0).Item(0)

                        TextBox9.Text = dt.Rows(0).Item(1)
                        cmb6.Enabled = True
                        cmb7.Enabled = False
                        cmb8.Enabled = False
                        cmb9.Enabled = False
                        cmb10.Enabled = False
                        cmb6.id = dt.Rows(0).Item(2)

                    End If
                    If dt.Rows.Count = 2 Then
                        cmb6.Text = dt.Rows(0).Item(0)
                        TextBox9.Text = dt.Rows(0).Item(1)
                        cmb7.Text = dt.Rows(1).Item(0)
                        TextBox10.Text = dt.Rows(1).Item(1)
                        cmb6.Enabled = True
                        cmb7.Enabled = True
                        cmb8.Enabled = False
                        cmb9.Enabled = False
                        cmb10.Enabled = False
                        cmb6.id = dt.Rows(0).Item(2)
                        cmb7.id = dt.Rows(1).Item(2)

                    End If
                    If dt.Rows.Count = 3 Then
                        cmb6.Text = dt.Rows(0).Item(0)
                        TextBox9.Text = dt.Rows(0).Item(1)
                        cmb7.Text = dt.Rows(1).Item(0)
                        TextBox10.Text = dt.Rows(1).Item(1)
                        cmb8.Text = dt.Rows(2).Item(0)
                        TextBox11.Text = dt.Rows(2).Item(1)
                        cmb6.Enabled = True
                        cmb7.Enabled = True
                        cmb8.Enabled = True
                        cmb9.Enabled = False
                        cmb10.Enabled = False
                        cmb6.id = dt.Rows(0).Item(2)
                        cmb7.id = dt.Rows(1).Item(2)
                        cmb8.id = dt.Rows(2).Item(2)

                    End If
                    If dt.Rows.Count = 4 Then
                        cmb6.Text = dt.Rows(0).Item(0)
                        TextBox9.Text = dt.Rows(0).Item(1)
                        cmb7.Text = dt.Rows(1).Item(0)
                        TextBox10.Text = dt.Rows(1).Item(1)
                        cmb8.Text = dt.Rows(2).Item(0)
                        TextBox11.Text = dt.Rows(2).Item(1)
                        cmb9.Text = dt.Rows(3).Item(0)
                        TextBox12.Text = dt.Rows(3).Item(1)
                        cmb6.Enabled = True
                        cmb7.Enabled = True
                        cmb8.Enabled = True
                        cmb9.Enabled = True
                        cmb10.Enabled = False
                        cmb6.id = dt.Rows(0).Item(2)
                        cmb7.id = dt.Rows(1).Item(2)
                        cmb8.id = dt.Rows(2).Item(2)
                        cmb9.id = dt.Rows(3).Item(2)

                    End If
                    If dt.Rows.Count = 5 Then
                        cmb6.Text = dt.Rows(0).Item(0)
                        TextBox9.Text = dt.Rows(0).Item(1)
                        cmb7.Text = dt.Rows(1).Item(0)
                        TextBox10.Text = dt.Rows(1).Item(1)
                        cmb8.Text = dt.Rows(2).Item(0)
                        TextBox11.Text = dt.Rows(2).Item(1)
                        cmb9.Text = dt.Rows(3).Item(0)
                        TextBox12.Text = dt.Rows(3).Item(1)
                        cmb10.Text = dt.Rows(4).Item(0)
                        TextBox13.Text = dt.Rows(4).Item(1)
                        cmb6.Enabled = True
                        cmb7.Enabled = True
                        cmb8.Enabled = True
                        cmb9.Enabled = True
                        cmb10.Enabled = True
                        cmb6.id = dt.Rows(0).Item(2)
                        cmb7.id = dt.Rows(1).Item(2)
                        cmb8.id = dt.Rows(2).Item(2)
                        cmb9.id = dt.Rows(3).Item(2)
                        cmb10.id = dt.Rows(4).Item(2)

                    End If
                    If Button2.BackColor <> Color.CornflowerBlue Then
                        DataGridView2.Columns.Clear()
                        loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
                        gridlayout2()
                    End If
                    Exit Function
                Else
                    loadgrid("select eidos,code,perigrafi from eidi where code like '" & TextBox1.Text & "%'", Form8.DataGridView1)
                    Form8.formcontrol = "eidos"
                    Form8.formcontrol2 = "form10-1"
                    Form8.Show()
                    Exit Function
                End If
            End If
            If TextBox2.Focused Then
                dtvaluetoset("select eidos,code,perigrafi from eidi where code like '" & TextBox2.Text & "%'")
                If dt.Rows.Count < 1 Then
                    MessageBox.Show("Δε βρέθηκαν εγγραφές")
                    Exit Function
                End If
                If dt.Rows.Count = 1 Then
                    yliko = dt.Rows(0).Item(0)
                    TextBox2.Text = dt.Rows(0).Item(1)
                    TextBox16.Text = dt.Rows(0).Item(2)
                    cmb1.Enabled = True
                    Exit Function
                Else
                    loadgrid("select eidos,code,perigrafi from eidi where code like '" & TextBox2.Text & "%'", Form8.DataGridView1)
                    Form8.formcontrol = "eidos"
                    Form8.formcontrol2 = "form10-2"
                    Form8.Show()
                    Exit Function
                End If
            End If


        End If
        'Else
        'End If
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmdtext As String = ""
        Dim cmdtext2 As String = ""
        If proion = 0 Then
            MessageBox.Show("Δεν εχετε επιλέξει προιόν")
            Exit Sub
        End If
        If yliko = 0 Then
            MessageBox.Show("Δεν εχετε επιλέξει υλικό")
            Exit Sub
        End If
        If Button3.BackColor = Color.CornflowerBlue Then
            'ElseIf Button3.BackColor = Color.CornflowerBlue Then
            cmdtext2 = "delete from grammes_par_ylika where proion='" & proion & "' and yliko='" & yliko & "';"
        End If


        If cmb1.Text <> "" And TextBox3.Text <> "" Then
            cmdtext = cmdtext2 & "insert into grammes_par_ylika(proion,yliko,tmima,posotita) values('" & proion & "','" & yliko & "','" & cmb1.id & "', '" & todecimalvalue(TextBox3.Text) & "');"
        Else
            'runquery(cmdtext)
            'loadgrid("select grammes_par_ylika.id,grammes_paragogis.name,eidi.code,eidi.perigrafi,posotita from grammes_par_ylika join eidi on eidos=yliko join grammes_paragogis on grammes_paragogis.id=tmima where proion='" & proion & "'", DataGridView2)

            'clearform()
            MessageBox.Show("Δεν έχετε εισάγει στοιχεία")
            Exit Sub
        End If
        kataxwrisi = True

        If cmb2.Text <> "" And TextBox4.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_ylika(proion,yliko,tmima,posotita) values('" & proion & "','" & yliko & "','" & cmb2.id & "', '" & todecimalvalue(TextBox4.Text) & "');"
        Else

            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            DataGridView2.Columns.Clear()

            'loadgrid("select grammes_par_ylika.id,grammes_paragogis.name,eidi.code,eidi.perigrafi,posotita from grammes_par_ylika join eidi on eidos=yliko join grammes_paragogis on grammes_paragogis.id=tmima where proion='" & proion & "'", DataGridView2)
            loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
            gridlayout2()
            clearform()

            Exit Sub
        End If
        If cmb3.Text <> "" And TextBox5.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_ylika(proion,yliko,tmima,posotita) values('" & proion & "','" & yliko & "','" & cmb3.id & "', '" & todecimalvalue(TextBox5.Text) & "');"
        Else
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            DataGridView2.Columns.Clear()

            'loadgrid("select grammes_par_ylika.id,grammes_paragogis.name,eidi.code,eidi.perigrafi,posotita from grammes_par_ylika join eidi on eidos=yliko join grammes_paragogis on grammes_paragogis.id=tmima where proion='" & proion & "'", DataGridView2)
            loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
            gridlayout2()
            clearform()

            Exit Sub
        End If
        If cmb4.Text <> "" And TextBox6.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_ylika(proion,yliko,tmima,posotita) values('" & proion & "','" & yliko & "','" & cmb4.id & "', '" & todecimalvalue(TextBox6.Text) & "');"
        Else
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            DataGridView2.Columns.Clear()

            'loadgrid("select grammes_par_ylika.id,grammes_paragogis.name,eidi.code,eidi.perigrafi,posotita from grammes_par_ylika join eidi on eidos=yliko join grammes_paragogis on grammes_paragogis.id=tmima where proion='" & proion & "'", DataGridView2)
            loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
            gridlayout2()
            clearform()

            Exit Sub
        End If
        If cmb5.Text <> "" And TextBox7.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_ylika(proion,yliko,tmima,posotita) values('" & proion & "','" & yliko & "','" & cmb5.id & "', '" & todecimalvalue(TextBox7.Text) & "')"
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            DataGridView2.Columns.Clear()

            'loadgrid("select grammes_par_ylika.id,grammes_paragogis.name,eidi.code,eidi.perigrafi,posotita from grammes_par_ylika join eidi on eidos=yliko join grammes_paragogis on grammes_paragogis.id=tmima where proion='" & proion & "'", DataGridView2)
            loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
            gridlayout2()
            clearform()
        Else
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            DataGridView2.Columns.Clear()

            'loadgrid("select grammes_par_ylika.id,grammes_paragogis.name,eidi.code,eidi.perigrafi,posotita from grammes_par_ylika join eidi on eidos=yliko join grammes_paragogis on grammes_paragogis.id=tmima where proion='" & proion & "'", DataGridView2)
            loadgrid("select yliko,eidi.code,eidi.perigrafi from grammes_par_ylika join eidi on eidos=yliko where proion='" & proion & "' group by yliko", DataGridView2)
            gridlayout2()
            clearform()

            Exit Sub

        End If

    End Sub
    Private Sub clearform()
        For Each ctl In GroupBox1.Controls

            If TypeOf ctl Is TextBox Then
                'If ctl.enabled = Then
                ctl.Text = ""
                ' End If
            End If
        Next

        cmb1.SelectedIndex = -1
        cmb2.SelectedIndex = -1
        cmb3.SelectedIndex = -1
        cmb4.SelectedIndex = -1
        cmb5.SelectedIndex = -1

        cmb1.Enabled = False
        cmb2.Enabled = False
        cmb3.Enabled = False
        cmb4.Enabled = False
        cmb5.Enabled = False

        cmb1.id = 0
        cmb2.id = 0
        cmb3.id = 0
        cmb4.id = 0
        cmb5.id = 0

        Button1.Enabled = False
    End Sub
    Private Sub clearform2()
        For Each ctl In GroupBox2.Controls

            If TypeOf ctl Is TextBox Then
                'If ctl.enabled = Then
                ctl.Text = ""
                ' End If
            End If
        Next
        cmb6.SelectedIndex = -1
        cmb7.SelectedIndex = -1
        cmb8.SelectedIndex = -1
        cmb9.SelectedIndex = -1
        cmb10.SelectedIndex = -1

        cmb6.Enabled = False
        cmb7.Enabled = False
        cmb8.Enabled = False
        cmb9.Enabled = False
        cmb10.Enabled = False

        cmb6.id = 0
        cmb7.id = 0
        cmb8.id = 0
        cmb9.id = 0
        cmb10.id = 0
        Button1.Enabled = False

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.CornflowerBlue
        TextBox1.Text = ""
        TextBox15.Text = ""
        proion = 0
        yliko = 0
        DataGridView2.Columns.Clear()
        'DataGridView2.DataSource = Nothing
        clearform()
        clearform2()
        TextBox1.Focus()
        Button3.Enabled = False
        Button4.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Enabled = False
        Button3.BackColor = Color.CornflowerBlue
        TextBox1.ReadOnly = True
        For Each ctl In GroupBox1.Controls
            If TypeOf ctl Is CustomControl1 Then
                ctl.Enabled = False

            End If
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If kataxwrisi = False Then
            MessageBox.Show("Δεν έχετε αποθηκεύσει την επιλογή σας" & vbCrLf & " Για έξοδο πατήστε το κουμπί Άκυρο")
            Exit Sub
        End If
        Button3.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        'proion = 0
        'yliko = 0
        Button2.Enabled = True
        Button3.Enabled = True
        'Button3.Enabled = False
        TextBox1.ReadOnly = False
    End Sub

    Public Sub gridlayout2()

        DataGridView2.Columns(0).Visible = False

        '.Columns(1).HeaderText = "Γραμμή παραγωγής"
        DataGridView2.Columns(1).HeaderText = "Κωδικος Υλικού"
        DataGridView2.Columns(2).HeaderText = "Περιγραφή"
        '.Columns(4).HeaderText = "Ποσότητα"

        DataGridView2.Columns(1).Width = 100
        DataGridView2.Columns(2).Width = 300
        Dim columnbutton As New DataGridViewButtonColumn
        'DataGridView2.Columns.Insert(3, columnbutton)
        DataGridView2.Columns.Add(columnbutton)
        columnbutton.Text = "Διαγραφή"
        columnbutton.UseColumnTextForButtonValue = True

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        cmb2.Enabled = True
        Button1.Enabled = True
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        cmb3.Enabled = True
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        cmb4.Enabled = True
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        cmb7.Enabled = True
    End Sub
    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        cmb8.Enabled = True
    End Sub
    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        cmb9.Enabled = True
    End Sub
    Private Sub TextBox12_TextChanged(sender As Object, e As EventArgs) Handles TextBox12.TextChanged
        cmb10.Enabled = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cmb1.Enabled = False
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        proion = 0
        yliko = 0
        Button1.Enabled = False
        TextBox1.Text = ""
        TextBox15.Text = ""
        Button3.Enabled = True
        DataGridView2.Columns.Clear()
        TextBox1.ReadOnly = False
        Button2.Enabled = True
        Button3.Enabled = False

        clearform()
        clearform2()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmb1.id = returnsinglevaluequery("Select id from grammes_paragogis where name='" & cmb1.Text & "'")
            TextBox3.Enabled = True
        TextBox3.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim cmdtext As String = ""
        Dim cmdtext2 As String = ""
        If proion = 0 Then
            MessageBox.Show("Δεν εχετε επιλέξει προιόν")
            Exit Sub
        End If

        If Button3.BackColor = Color.CornflowerBlue Then
            'ElseIf Button3.BackColor = Color.CornflowerBlue Then
            cmdtext2 = "delete from grammes_par_pososta where proion='" & proion & "';"
        End If

        If cmb6.Text <> "" And TextBox9.Text <> "" Then
            cmdtext = cmdtext2 & "insert into grammes_par_pososta(proion,tmima,suntelestis) values('" & proion & "','" & cmb6.id & "', '" & todecimalvalue(TextBox9.Text) & "');"
        Else

            MessageBox.Show("Δεν έχετε εισάγει στοιχεία")
            Exit Sub
        End If
        kataxwrisi = True

        If cmb7.Text <> "" And TextBox10.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_pososta(proion,tmima,suntelestis) values('" & proion & "','" & cmb7.id & "', '" & todecimalvalue(TextBox10.Text) & "');"
        Else

            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            'clearform2()
            Exit Sub
        End If
        If cmb8.Text <> "" And TextBox11.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_pososta(proion,tmima,suntelestis) values('" & proion & "','" & cmb8.id & "', '" & todecimalvalue(TextBox11.Text) & "');"
        Else
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            'clearform2()
            Exit Sub
        End If
        If cmb9.Text <> "" And TextBox12.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_pososta(proion,tmima,suntelestis) values('" & proion & "','" & cmb9.id & "', '" & todecimalvalue(TextBox12.Text) & "');"
        Else
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            'clearform2()
            Exit Sub
        End If
        If cmb10.Text <> "" And TextBox13.Text <> "" Then
            cmdtext = cmdtext & "insert into grammes_par_pososta(proion,tmima,suntelestis) values('" & proion & "','" & cmb10.id & "', '" & todecimalvalue(TextBox13.Text) & "');"
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If

        Else
            runquery(cmdtext)
            If queryerror = False Then
                MessageBox.Show("Επιτυχής καταχώρηση!")
            End If
            'clearform2()
            Exit Sub

        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmb2.id = returnsinglevaluequery("select id from grammes_paragogis where name='" & cmb2.Text & "'")

        TextBox4.Enabled = True
        TextBox4.Focus()
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmb3.id = returnsinglevaluequery("select id from grammes_paragogis where name='" & cmb3.Text & "'")

        TextBox5.Enabled = True
        TextBox5.Focus()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmb4.id = returnsinglevaluequery("select id from grammes_paragogis where name='" & cmb4.Text & "'")

        TextBox6.Enabled = True
        TextBox6.Focus()
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs)
        cmb5.id = returnsinglevaluequery("select id from grammes_paragogis where name='" & cmb5.Text & "'")

        TextBox7.Enabled = True
        TextBox7.Focus()
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs)

        'cmb6.Items.Clear()


        cmb6.id = returnsinglevaluequery("Select id from grammes_paragogis where name='" & cmb6.Text & "'")
        TextBox9.Enabled = True
        TextBox9.Focus()

    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs)

        ' cmb6.Items.Clear()

        cmb7.id = returnsinglevaluequery("Select id from grammes_paragogis where name='" & cmb7.Text & "'")
        TextBox10.Enabled = True
        TextBox10.Focus()
    End Sub
    Private Sub ComboBox8_SelectedIndexChanged(sender As Object, e As EventArgs)

        ' cmb6.Items.Clear()

        cmb8.id = returnsinglevaluequery("Select id from grammes_paragogis where name='" & cmb8.Text & "'")
        TextBox11.Enabled = True
        TextBox11.Focus()
    End Sub
    Private Sub ComboBox9_SelectedIndexChanged(sender As Object, e As EventArgs)

        'cmb6.Items.Clear()

        cmb9.id = returnsinglevaluequery("Select id from grammes_paragogis where name='" & cmb9.Text & "'")
        TextBox12.Enabled = True
        TextBox12.Focus()
    End Sub
    Private Sub ComboBox10_SelectedIndexChanged(sender As Object, e As EventArgs)

        'cmb6.Items.Clear()

        cmb10.id = returnsinglevaluequery("Select id from grammes_paragogis where name='" & cmb10.Text & "'")
        TextBox13.Enabled = True
        TextBox13.Focus()
    End Sub
    Private Sub ComboBox6_Click(sender As Object, e As EventArgs)
        cmb6.Items.Clear()
        runquerycombo("select distinct name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "')", cmb6, "name")
    End Sub
    Private Sub ComboBox7_Click(sender As Object, e As EventArgs)
        cmb7.Items.Clear()
        runquerycombo("select distinct name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima<>'" & cmb6.id & "')", cmb7, "name")
    End Sub
    Private Sub ComboBox8_Click(sender As Object, e As EventArgs)
        cmb8.Items.Clear()
        runquerycombo("select distinct name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb8, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb9, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb10, "name")
    End Sub
    Private Sub ComboBox9_Click(sender As Object, e As EventArgs)
        cmb9.Items.Clear()
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb8, "name")
        runquerycombo("select distinct name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb9, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb10, "name")
    End Sub
    Private Sub ComboBox10_Click(sender As Object, e As EventArgs)
        cmb10.Items.Clear()
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb8, "name")
        'runquerycombo("select name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb9, "name")
        runquerycombo("select distinct name from grammes_paragogis where id in (select tmima from grammes_par_ylika where proion='" & proion & "' and tmima not in ('" & cmb6.id & "','" & cmb7.id & "'))", cmb10, "name")
    End Sub
End Class