Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmGuestRecord5
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
            Dim userid As String = GetAllId()
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

                    Dim sqlquery = "SELECT * FROM view_sale Where NameOfuser = '" & arrayID(i) & "' And YEAR(time_update) = '" & wD & "'"

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
                    Dim main As Integer = 0

                    While (MyData.Read() = True)
                        If MyData(4) = 2 Then
                            If MyData(4) = 2 Then
                                Select Case MyData(5)
                                    Case 0 : normal += 1
                                    Case 1 : vip += 1
                                End Select
                            End If
                        End If
                    End While

                    Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val) + (main * Seats_Main_Val)
                    If sum > 0 Then
                        sumall += sum
                        If addNo = False Then
                            dataGridView1.Rows.Add(no, wD + 543, arrayID(i), vip, main + normal, sum)
                            no += 1
                            addNo = True
                        Else
                            dataGridView1.Rows.Add("", "", arrayID(i), vip, main + normal, sum)
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
            Dim userid As String = GetAllId()
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

                    Dim sqlquery = "SELECT * FROM view_sale Where NameOfuser = '" & arrayID(i) & "' And MONTH(time_update) = '" & month_start.Month & "' And YEAR(time_update) = '" & month_start.Year & "'"

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
                    Dim main As Integer = 0

                    While (MyData.Read() = True)
                        If MyData(4) = 2 Then
                            If MyData(4) = 2 Then
                                Select Case MyData(5)
                                    Case 0 : normal += 1
                                    Case 1 : vip += 1
                                End Select
                            End If
                        End If
                    End While

                    Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val) + (main * Seats_Main_Val)
                    If sum > 0 Then
                        sumall += sum
                        If addNo = False Then
                            dataGridView1.Rows.Add(no, getMMName(month_start.Month) & "  " & month_start.Year + 543, arrayID(i), vip, main + normal, sum)
                            no += 1
                            addNo = True
                        Else
                            dataGridView1.Rows.Add("", "", arrayID(i), vip, main + normal, sum)
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
            Dim userid As String = GetAllId()
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

                    Dim sqlquery = "SELECT * from view_sale WHERE NameOfuser = '" & arrayID(i) & "' And time_update BETWEEN '" & current_start.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & _
                        "' And '" & current_start2.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "' order by time_update"
                    Dim mycommand As New MySqlCommand()

                    mycommand.Connection = Conn
                    mycommand.CommandText = sqlquery
                    MyAdapter.SelectCommand = mycommand
                    Dim MyData As MySqlDataReader
                    MyData = mycommand.ExecuteReader
                    Dim vip As Integer = 0
                    Dim normal As Integer = 0
                    Dim main As Integer = 0

                    While (MyData.Read() = True)
                        If MyData(4) = 2 Then
                            If MyData(4) = 2 Then
                                Select Case MyData(5)
                                    Case 0 : normal += 1
                                    Case 1 : vip += 1
                                End Select
                            End If
                        End If
                    End While

                    Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val) + (main * Seats_Main_Val)
                    If sum > 0 Then
                        sumall += sum
                        If addNo = False Then
                            Dim current_temp As DateTime = current_start.AddDays(6)
                            dataGridView1.Rows.Add(no, current_start.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")) & " ถึง " & current_temp.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")), arrayID(i), vip, main + normal, sum)
                            no += 1
                            addNo = True
                        Else
                            dataGridView1.Rows.Add("", "", arrayID(i), vip, main + normal, sum)
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
            Dim userid As String = GetAllId()
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
                        msgError()
                    End Try

                    Dim MyAdapter As New MySqlDataAdapter

                    Dim sqlquery = "SELECT * from view_sale WHERE NameOfuser = '" & arrayID(i) & "' And time_update LIKE '" & current_start.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "%' order by time_update"
                    Dim mycommand As New MySqlCommand()

                    mycommand.Connection = Conn
                    mycommand.CommandText = sqlquery
                    MyAdapter.SelectCommand = mycommand
                    Dim MyData As MySqlDataReader
                    MyData = mycommand.ExecuteReader
                    Dim vip As Integer = 0
                    Dim normal As Integer = 0
                    Dim main As Integer = 0

                    While (MyData.Read() = True)
                        If MyData(4) = 2 Then
                            If MyData(4) = 2 Then
                                Select Case MyData(5)
                                    Case 0 : normal += 1
                                    Case 1 : vip += 1
                                End Select
                            End If
                        End If
                    End While

                    Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val) + (main * Seats_Main_Val)
                    If sum > 0 Then
                        sumall += sum
                        If addNo = False Then
                            dataGridView1.Rows.Add(no, current_start.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")), arrayID(i), vip, main + normal, sum)
                            no += 1
                            addNo = True
                        Else
                            dataGridView1.Rows.Add("", "", arrayID(i), vip, main + normal, sum)
                        End If
                    End If

                    'If index > 1 Then
                    '    no += 1
                    'End If
                    Conn.Close()
                Next
                current_start = current_start.AddDays(1)
                wD = DateDiff(DateInterval.Day, current_start, current_end)
            Loop
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            dataGridView1.Rows.Clear()
            GetData()

        ElseIf RadioButton2.Checked = True Then
            dataGridView1.Rows.Clear()
            GetData_Weekly()
        ElseIf RadioButton3.Checked = True Then
            dataGridView1.Rows.Clear()
            GetData_Monthly()
        ElseIf RadioButton4.Checked = True Then
            dataGridView1.Rows.Clear()
            GetData_Yearly()
        End If
        Button3.Enabled = True
    End Sub

    Private Sub frmGuestRecord5_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmGuestRecord5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            End With

            For Each dr As DataGridViewRow In Me.dataGridView1.Rows
                dt.Rows.Add(dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value, dr.Cells(3).Value, dr.Cells(4).Value, dr.Cells(5).Value)
            Next
            '
            Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            rptDoc = New rptsale
            rptDoc.SetDataSource(dt)
            rptDoc.SetParameterValue("variable", dtpDateFrom.Value.ToString("dd-MM-yyyy"))
            rptDoc.SetParameterValue("variable1", dtpDateTo.Value.ToString("dd-MM-yyyy"))
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
End Class