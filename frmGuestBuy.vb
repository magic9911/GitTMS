Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmGuestBuy


    Private sumall As Integer = 0
    Private Sub dataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        'Try
        '    Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
        '    Me.Hide()
        '    frmReservation.ShowDialog()
        '    ' or simply use column name instead of index
        '    'dr.Cells["id"].Value.ToString();
        '    frmReservation.txtid.Text = dr.Cells(0).Value.ToString()
        '    frmReservation.txtGuestName.Text = dr.Cells(1).Value.ToString()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try


        Try
            Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim MyAdapter As New MySqlDataAdapter
            Dim sqlquery = "SELECT * from Guest where GuestName = '" & dr.Cells(2).Value.ToString() & "'"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim myDataSet As DataSet = New DataSet()
            MyAdapter.Fill(myDataSet, "Guest")

            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New rptInvoice
            rptDoc.SetDataSource(myDataSet.Tables("Guest").DefaultView)
            rptDoc.SetParameterValue("variable1", dr.Cells(3).Value.ToString())
            'rptDoc.SetParameterValue("variable2", dr.Cells(1).Value.ToString())

            rptDoc.SetParameterValue("data1", dr.Cells(4).Value.ToString())
            rptDoc.SetParameterValue("data2", dr.Cells(5).Value.ToString())
            rptDoc.SetParameterValue("data3", dr.Cells(6).Value.ToString())
            rptDoc.SetParameterValue("data4", dr.Cells(7).Value.ToString())
            rptDoc.SetParameterValue("data5", dr.Cells(8).Value.ToString())
            rptDoc.SetParameterValue("data6", dr.Cells(8).Value.ToString())

            Conn.Close()
            '

            frmSaleReport.CrystalReportViewer1.ReportSource = rptDoc
            frmSaleReport.ShowDialog()
            frmSaleReport.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub dataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub GetData_Yearly()
        Try
            Dim userid As String = String.Empty
            If ComboBox1.Text = "แสดงทั้งหมด" Then
                userid = GetAllRes()
            Else
                userid = GetOneRes(ComboBox1.Text)
            End If
            Dim arrayID As String() = userid.Split(",")
            Dim current_start As String = dtpDateFrom.Value.ToString("yyyy", New System.Globalization.CultureInfo("en-US"))
            Dim current_end As String = dtpDateTo.Value.ToString("yyyy", New System.Globalization.CultureInfo("en-US"))
            sumall = 0
            'current_start = current_start.AddDays(1)
            Dim no As Integer = 1
            For wD As Integer = CInt(current_start) To CInt(current_end)
                Dim addNo As Boolean = False
                For i As Integer = 0 To arrayID.Length - 2
                    Dim Conn As MySqlConnection
                    Conn = New MySqlConnection
                    Conn.ConnectionString = cs
                    Try
                        Conn.Open()
                    Catch myerror As MySqlException
                        msgError()
                    End Try

                    Dim MyAdapter As New MySqlDataAdapter

                    Dim sqlquery = "SELECT * FROM view_reservation Where id = '" & arrayID(i) & "' And YEAR(time_update) = '" & wD & "'"

                    'Dim sqlquery = "SELECT * from view_sale WHERE NameOfuser = '" & arrayID(i) & "' And time_update BETWEEN '" & current_start.ToString("yyyy-MM-dd") & _
                    '    "' And '" & current_start2.ToString("yyyy-MM-dd") & "' order by time_update"
                    Dim mycommand As New MySqlCommand()

                    mycommand.Connection = Conn
                    mycommand.CommandText = sqlquery
                    MyAdapter.SelectCommand = mycommand
                    Dim MyData As MySqlDataReader
                    MyData = mycommand.ExecuteReader
                    Dim vip As Integer = 0
                    Dim normal As Integer = 0
                    Dim vip_P As Integer = 0
                    Dim normal_P As Integer = 0
                    Dim tmp_idshow As String = String.Empty

                    Dim vip_free As Integer = 0
                    Dim normal_free As Integer = 0

                    Dim seat As String = String.Empty
                    Dim seat_free As String = String.Empty

                    Dim status As Integer = 0

                    Dim Gname As String = String.Empty

                    Dim txtDate As String = String.Empty
                    Dim txtTime As String = String.Empty

                    While (MyData.Read() = True)
                        vip_P = MyData(8)
                        normal_P = MyData(9)
                        status = Val(MyData(14))
                        seat = MyData(3)
                        seat_free = MyData(4)

                        vip = MyData(10)
                        normal = MyData(11)
                        vip_free = MyData(12)
                        normal_free = MyData(13)

                        Gname = MyData(2)

                        txtDate = MyData(6)
                        txtTime = MyData(7)

                    End While
                    Conn.Close()

                    If status = 1 Then
                        Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val)
                        If sum >= 0 Then
                            sumall += sum
                            If addNo = False Then
                                dataGridView1.Rows.Add(no, wD + 543, Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                                no += 1
                                addNo = True
                            Else
                                dataGridView1.Rows.Add("", "", Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                            End If
                        End If
                    End If
                    'If index > 1 Then
                    '    no += 1
                    'End If
                    Conn.Close()
                Next
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GetData_Monthly()
        Try
            Dim userid As String = String.Empty
            If ComboBox1.Text = "แสดงทั้งหมด" Then
                userid = GetAllRes()
            Else
                userid = GetOneRes(ComboBox1.Text)
            End If
            Dim arrayID As String() = userid.Split(",")
            Dim month_start As DateTime = dtpDateFrom.Value.ToString("yyyy-MM-dd")
            Dim month_end As DateTime = dtpDateTo.Value.ToString("yyyy-MM-dd")
            sumall = 0
            'current_start = current_start.AddDays(1)
            Dim no As Integer = 1
            Dim mD As Integer = DateDiff(DateInterval.Month, month_start, month_end)

            Do While (mD >= 0)
                Dim addNo As Boolean = False
                For i As Integer = 0 To arrayID.Length - 2
                    Dim Conn As MySqlConnection
                    Conn = New MySqlConnection
                    Conn.ConnectionString = cs
                    Try
                        Conn.Open()
                    Catch myerror As MySqlException
                        msgError()
                    End Try

                    Dim MyAdapter As New MySqlDataAdapter

                    Dim sqlquery = "SELECT * FROM view_reservation Where id = '" & arrayID(i) & "' And MONTH(time_update) = '" & month_start.Month & "' And YEAR(time_update) = '" & month_start.Year & "'"

                    'Dim sqlquery = "SELECT * from view_sale WHERE NameOfuser = '" & arrayID(i) & "' And time_update BETWEEN '" & current_start.ToString("yyyy-MM-dd") & _
                    '    "' And '" & current_start2.ToString("yyyy-MM-dd") & "' order by time_update"
                    Dim mycommand As New MySqlCommand()

                    mycommand.Connection = Conn
                    mycommand.CommandText = sqlquery
                    MyAdapter.SelectCommand = mycommand
                    Dim MyData As MySqlDataReader
                    MyData = mycommand.ExecuteReader
                    Dim vip As Integer = 0
                    Dim normal As Integer = 0
                    Dim vip_P As Integer = 0
                    Dim normal_P As Integer = 0
                    Dim tmp_idshow As String = String.Empty

                    Dim vip_free As Integer = 0
                    Dim normal_free As Integer = 0

                    Dim seat As String = String.Empty
                    Dim seat_free As String = String.Empty

                    Dim status As Integer = 0

                    Dim Gname As String = String.Empty

                    Dim txtDate As String = String.Empty
                    Dim txtTime As String = String.Empty

                    While (MyData.Read() = True)
                        vip_P = MyData(8)
                        normal_P = MyData(9)
                        status = Val(MyData(14))
                        seat = MyData(3)
                        seat_free = MyData(4)

                        vip = MyData(10)
                        normal = MyData(11)
                        vip_free = MyData(12)
                        normal_free = MyData(13)

                        Gname = MyData(2)

                        txtDate = MyData(6)
                        txtTime = MyData(7)

                    End While
                    Conn.Close()

                    If status = 1 Then
                        Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val)
                        If sum >= 0 Then
                            sumall += sum
                            If addNo = False Then
                                dataGridView1.Rows.Add(no, getMMName(month_start.Month) & "  " & month_start.Year + 543, Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                                no += 1
                                addNo = True
                            Else
                                dataGridView1.Rows.Add("", "", Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                            End If
                        End If
                    End If
                    'If index > 1 Then
                    '    no += 1
                    'End If
                    Conn.Close()
                Next
                month_start = month_start.AddMonths(1)
                mD = DateDiff(DateInterval.Month, month_start, month_end)
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GetData_Weekly()
        Try
            Dim userid As String = String.Empty
            If ComboBox1.Text = "แสดงทั้งหมด" Then
                userid = GetAllRes()
            Else
                userid = GetOneRes(ComboBox1.Text)
            End If
            Dim arrayID As String() = userid.Split(",")
            Dim current_start As DateTime = dtpDateFrom.Value.ToString("yyyy-MM-dd")
            Dim current_start2 As DateTime = current_start.AddDays(7)
            Dim current_end As DateTime = dtpDateTo.Value.ToString("yyyy-MM-dd")
            sumall = 0
            'current_start = current_start.AddDays(1)

            Dim wD As Integer = DateDiff(DateInterval.Weekday, current_start, current_end)
            Dim no As Integer = 1

            Do While (wD >= 0)
                Dim addNo As Boolean = False
                For i As Integer = 0 To arrayID.Length - 2
                    Dim Conn As MySqlConnection
                    Conn = New MySqlConnection
                    Conn.ConnectionString = cs
                    Try
                        Conn.Open()
                    Catch myerror As MySqlException
                        msgError()
                    End Try

                    Dim MyAdapter As New MySqlDataAdapter

                    Dim sqlquery = "SELECT * from view_reservation WHERE id = '" & arrayID(i) & "' And time_update BETWEEN '" & current_start.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & _
                        "' And '" & current_start2.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "' order by time_update"
                    Dim mycommand As New MySqlCommand()

                    mycommand.Connection = Conn
                    mycommand.CommandText = sqlquery
                    MyAdapter.SelectCommand = mycommand
                    Dim MyData As MySqlDataReader
                    MyData = mycommand.ExecuteReader
                    Dim vip As Integer = 0
                    Dim normal As Integer = 0
                    Dim vip_P As Integer = 0
                    Dim normal_P As Integer = 0
                    Dim tmp_idshow As String = String.Empty

                    Dim vip_free As Integer = 0
                    Dim normal_free As Integer = 0

                    Dim seat As String = String.Empty
                    Dim seat_free As String = String.Empty

                    Dim status As Integer = 0

                    Dim Gname As String = String.Empty

                    Dim txtDate As String = String.Empty
                    Dim txtTime As String = String.Empty

                    While (MyData.Read() = True)
                        vip_P = MyData(8)
                        normal_P = MyData(9)
                        status = Val(MyData(14))
                        seat = MyData(3)
                        seat_free = MyData(4)

                        vip = MyData(10)
                        normal = MyData(11)
                        vip_free = MyData(12)
                        normal_free = MyData(13)

                        Gname = MyData(2)

                        txtDate = MyData(6)
                        txtTime = MyData(7)

                    End While
                    Conn.Close()

                    If status = 1 Then
                        Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val)
                        If sum >= 0 Then
                            sumall += sum
                            If addNo = False Then
                                Dim current_temp As DateTime = current_start.AddDays(6)
                                dataGridView1.Rows.Add(no, current_start.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")) & " ถึง " & current_temp.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")), Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                                no += 1
                                addNo = True
                            Else
                                dataGridView1.Rows.Add("", "", Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                            End If
                        End If
                    End If
                    'If index > 1 Then
                    '    no += 1
                    'End If
                    Conn.Close()
                Next
                current_start = current_start.AddDays(7)
                current_start2 = current_start.AddDays(7)
                wD = DateDiff(DateInterval.Day, current_start, current_end)
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '    Daily
    'Weekly
    'Monthly
    'Yearly

    Sub GetData()
        Try
            Button1.Enabled = False

            Dim userid As String = String.Empty
            If ComboBox1.Text = "แสดงทั้งหมด" Then
                userid = GetAllRes()
            Else
                userid = GetOneRes(ComboBox1.Text)
            End If

            Dim arrayID As String() = userid.Split(",")
            Dim current_start As DateTime = dtpDateFrom.Value.ToString("yyyy-MM-dd")
            Dim current_end As DateTime = dtpDateTo.Value.ToString("yyyy-MM-dd")
            sumall = 0
            'current_start = current_start.AddDays(1)
            Dim wD As Integer = DateDiff(DateInterval.Day, current_start, current_end)
            Dim no As Integer = 1

            Do While (wD >= 0)
                Dim addNo As Boolean = False
                For i As Integer = 0 To arrayID.Length - 2
                    Dim Conn As MySqlConnection
                    Conn = New MySqlConnection
                    Conn.ConnectionString = cs
                    Try
                        Conn.Open()
                    Catch myerror As MySqlException
                        MsgBox("Error connecting to Database GetData")
                    End Try

                    Dim MyAdapter As New MySqlDataAdapter

                    Dim sqlquery As String = String.Empty
                    sqlquery = "SELECT * from view_reservation WHERE id = '" & arrayID(i) & "' And time_update LIKE '" & current_start.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "%' order by time_update"


                    Dim mycommand As New MySqlCommand()


                    mycommand.Connection = Conn
                    mycommand.CommandText = sqlquery
                    MyAdapter.SelectCommand = mycommand
                    Dim MyData As MySqlDataReader
                    MyData = mycommand.ExecuteReader
                    Dim vip As Integer = 0
                    Dim normal As Integer = 0
                    Dim vip_P As Integer = 0
                    Dim normal_P As Integer = 0
                    Dim tmp_idshow As String = String.Empty

                    Dim vip_free As Integer = 0
                    Dim normal_free As Integer = 0

                    Dim seat As String = String.Empty
                    Dim seat_free As String = String.Empty

                    Dim status As Integer = 0

                    Dim Gname As String = String.Empty

                    Dim txtDate As String = String.Empty
                    Dim txtTime As String = String.Empty

                    While (MyData.Read() = True)
                        vip_P = MyData(8)
                        normal_P = MyData(9)
                        status = Val(MyData(14))
                        seat = MyData(3)
                        seat_free = MyData(4)

                        vip = MyData(10)
                        normal = MyData(11)
                        vip_free = MyData(12)
                        normal_free = MyData(13)

                        Gname = MyData(2)

                        txtDate = MyData(6)
                        txtTime = MyData(7)

                    End While
                    Conn.Close()

                    If status = 1 Then
                        Dim sum As Integer = (vip * vip_P) + (normal * normal_P)
                        If sum >= 0 Then
                            sumall += sum
                            If addNo = False Then
                                dataGridView1.Rows.Add(no, current_start.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")), Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                                no += 1
                                addNo = True
                            Else
                                dataGridView1.Rows.Add("", "", Gname, arrayID(i), _
                                                       txtDate, txtTime, vip & " X " & vip_P, normal & " X " & normal_P, sum, "ปกติ x " & normal_free & " VIP X " & vip_free)
                            End If
                        End If
                    End If

                Next
                current_start = current_start.AddDays(1)
                wD = DateDiff(DateInterval.Day, current_start, current_end)
            Loop
            Button1.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error GetData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'Dim seats As String = getModeBySeats(seat, tmp_idshow)
        'If seats <> Nothing Then
        '    Dim seats_val As String() = seats.Split(",")
        '    If seats_val.Length = 2 Then
        '        vip = 0 'seats_val(1)
        '        normal = 7 'seats_val(0)
        '    End If
        'End If

        'Dim seats_free As String = getModeBySeats(seat_free, tmp_idshow)
        'If seats_free <> Nothing Then
        '    Dim seats_free_val As String() = seats_free.Split(",")
        '    If seats_free_val.Length = 2 Then
        '        vip_free = 0 'seats_free_val(1)
        '        normal_free = 0 'seats_free_val(0)
        '    End If
        'End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Dim rowsTotal, colsTotal As Short
        'Dim I, j, iC As Short
        'System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        'Dim xlApp As New Excel.Application
        'Try
        '    Dim excelBook As Excel.Workbook = xlApp.Workbooks.Add
        '    Dim excelWorksheet As Excel.Worksheet = CType(excelBook.Worksheets(1), Excel.Worksheet)
        '    xlApp.Visible = True

        '    rowsTotal = dataGridView1.RowCount - 1
        '    colsTotal = dataGridView1.Columns.Count - 1
        '    With excelWorksheet
        '        .Cells.Select()
        '        .Cells.Delete()
        '        For iC = 0 To colsTotal
        '            .Cells(1, iC + 1).Value = dataGridView1.Columns(iC).HeaderText
        '        Next
        '        For I = 0 To rowsTotal
        '            For j = 0 To colsTotal
        '                .Cells(I + 2, j + 1).value = dataGridView1.Rows(I).Cells(j).Value
        '            Next j
        '        Next I
        '        .Rows("1:1").Font.FontStyle = "Bold"
        '        .Rows("1:1").Font.Size = 12

        '        .Cells.Columns.AutoFit()
        '        .Cells.Select()
        '        .Cells.EntireColumn.AutoFit()
        '        .Cells(1, 1).Select()
        '    End With
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Finally
        '    'RELEASE ALLOACTED RESOURCES
        '    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        '    xlApp = Nothing
        'End Try
    End Sub

    Private Sub frmGuestRecord5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmGuestRecord5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim userName As String = GetAllGuestName()
        Dim arrayName As String() = userName.Split(",")
        ComboBox1.Items.Add("แสดงทั้งหมด")
        For i As Integer = 0 To arrayName.Length - 2
            ComboBox1.Items.Add(arrayName(i))
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmGuestRecord1.mode_return = 2
        frmGuestRecord1.GetData()
        frmGuestRecord1.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim dt As New DataTable

            With dt
                .Columns.Add("no")
                .Columns.Add("date")
                .Columns.Add("name")
                .Columns.Add("vip")
                .Columns.Add("nor")
                .Columns.Add("sum")
                .Columns.Add("free")
            End With

            For Each dr As DataGridViewRow In Me.dataGridView1.Rows
                dt.Rows.Add(dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value, dr.Cells(6).Value, dr.Cells(7).Value, dr.Cells(8).Value, dr.Cells(9).Value)
            Next
            '
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New rptbuy
            rptDoc.SetDataSource(dt)
            rptDoc.SetParameterValue("variable", dtpDateFrom.Value.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")))
            rptDoc.SetParameterValue("variable1", dtpDateTo.Value.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")))
            rptDoc.SetParameterValue("variable2", sumall)

            Dim txtReport As String = String.Empty
            If RadioButton1.Checked = True Then
                txtReport = "รายงาน - รายวัน"
            ElseIf RadioButton2.Checked = True Then
                txtReport = "รายงาน - รายอาทิตย์"
            ElseIf RadioButton3.Checked = True Then
                txtReport = "รายงาน - รายเดือน"
            ElseIf RadioButton4.Checked = True Then
                txtReport = "รายงาน - รายปี"
            End If
            rptDoc.SetParameterValue("variable3", txtReport)
            '

            frmSaleReport.CrystalReportViewer1.ReportSource = rptDoc
            frmSaleReport.ShowDialog()
            frmSaleReport.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            dataGridView1.Rows.Clear()
            Me.GetData()

        ElseIf RadioButton2.Checked = True Then
            dataGridView1.Rows.Clear()
            Me.GetData_Weekly()
        ElseIf RadioButton3.Checked = True Then
            dataGridView1.Rows.Clear()
            Me.GetData_Monthly()
        ElseIf RadioButton4.Checked = True Then
            dataGridView1.Rows.Clear()
            Me.GetData_Yearly()
        End If
        Button3.Enabled = True
    End Sub
End Class