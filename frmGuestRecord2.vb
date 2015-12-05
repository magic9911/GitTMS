Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmGuestRecord2
    Public mode As Integer = 0

    Private Sub frmGuestRecord2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmGuestRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
            'Dim wD As Long = DateDiff(DateInterval.Day, setTime(Now.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US"))).Value, setTime(dr.Cells(1).Value.ToString()).Value)
            Dim dat As DateTimePicker = setTime(dr.Cells(2).Value.ToString())
            Dim datTim1 As Date = Now
            Dim datTim2 As Date = dat.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US"))
            ' Assume Sunday is specified as first day of the week. 
            Dim wD2 As Long = DateDiff(DateInterval.Day, datTim1, datTim2)

            If wD2 >= 0 And dr.Cells(5).Value.ToString() = "จำหน่าย" Then

            Else
                MessageBox.Show("รอบการแสดงดังกล่าว งดการจำหน่าย / พ้นกำหนดการแสดง", "ไม่สามารถเลือกรอบการแสดงได้", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Select Case mode
                Case 0
                    Me.Hide()
                    frmSTime.dtpDate.Value = dr.Cells(2).Value.ToString()
                    Dim d As Date = frmSTime.dtpDate.Value

                    Dim st As String() = dr.Cells(3).Value.ToString().Split("-")
                    Dim st1 As String() = st(0).Split(".")
                    Dim st2 As String() = st(1).Split(".")

                    frmSTime.lb_id.Text = dr.Cells(0).Value.ToString()
                    frmSTime.txtName.Text = dr.Cells(1).Value.ToString()

                    frmSTime.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
                    frmSTime.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)

                    frmSTime.cmbIDType.Text = dr.Cells(5).Value.ToString()
                    frmSTime.txtNotes.Text = dr.Cells(6).Value.ToString()
                    frmSTime.btnDelete.Enabled = True
                    frmSTime.btnUpdate_record.Enabled = True
                    frmSTime.btnSave.Enabled = False
                Case 1

                    Dim wD As Long = DateDiff(DateInterval.Day, Now, setTime(dr.Cells(2).Value.ToString()).Value)
                    If wD >= 0 And dr.Cells(5).Value.ToString() = "จำหน่าย" Then
                        If dr.Cells(0).Value.ToString() <> frmReservation.ReserIdShow And frmReservation.ReserIdShow <> 0 Then
                            If MessageBox.Show("คุณต้องการเปลี่ยนแปลงวันที่ในการจองใช่หรือไม่?" & vbCrLf & ">> ถ้าเปลี่ยนรอบการแสดง จำเป็นต้องเลือกเลขที่นั่งใหม่ <<", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                                frmReservation.CancelData2()
                                frmReservation.RichTextBox1.Text = ""
                                frmReservation.ReserIdShow = dr.Cells(0).Value.ToString()
                                frmReservation.dtpDate.Value = dr.Cells(2).Value.ToString()

                                Dim d As Date = frmSTime.dtpDate.Value

                                Dim st As String() = dr.Cells(3).Value.ToString().Split("-")
                                Dim st1 As String() = st(0).Split(".")
                                Dim st2 As String() = st(1).Split(".")

                                frmReservation.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
                                frmReservation.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)
                                frmReservation.Button2.Enabled = True
                                frmReservation.Button6.Enabled = True
                                frmReservation.editing = True
                            End If
                        Else
                            frmReservation.ReserIdShow = dr.Cells(0).Value.ToString()
                            frmReservation.dtpDate.Value = dr.Cells(2).Value.ToString()

                            Dim d As Date = frmSTime.dtpDate.Value

                            Dim st As String() = dr.Cells(3).Value.ToString().Split("-")
                            Dim st1 As String() = st(0).Split(".")
                            Dim st2 As String() = st(1).Split(".")

                            frmReservation.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
                            frmReservation.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)
                            frmReservation.Button2.Enabled = True
                            frmReservation.Button6.Enabled = True
                            frmReservation.editing = True
                        End If
                        Me.Hide()
                    Else
                        MessageBox.Show("รอบการแสดงดังกล่าว เกินระยะเวลาในการจอง", "ไม่สามารถจองได้", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                Case 2
                    Me.Hide()
                    frmCancelReservation.ReserIdShow = dr.Cells(0).Value.ToString()
                    frmCancelReservation.dtpDate.Value = dr.Cells(2).Value.ToString()
                    Dim d As Date = frmSTime.dtpDate.Value

                    Dim st As String() = dr.Cells(3).Value.ToString().Split("-")
                    Dim st1 As String() = st(0).Split(".")
                    Dim st2 As String() = st(1).Split(".")

                    frmCancelReservation.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
                    frmCancelReservation.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)
                    frmCancelReservation.btnCancelReservation.Enabled = True

            End Select

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

    Private Sub txtCustomers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'con = New OleDbConnection(cs)
            'con.Open()
            'cmd = New OleDbCommand("SELECT (id)as [Guest ID],(Guestname) as [Guest Name],(address) as [Address],(city) as [City],(ContactNo) as [Contact No],IDType as [ID Type],IDNumber as [ID Number],Notes from Guest where GuestName like '" + txtGuests.Text + "%' order by GuestName", con)
            'Dim myDA As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            'Dim myDataSet As DataSet = New DataSet()
            'myDA.Fill(myDataSet, "Guest")
            'dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            'con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetData()
        Try
            'Dim Conn As MySqlConnection
            'Conn = New MySqlConnection
            'Conn.ConnectionString = cs
            'Try
            '    Conn.Open()
            'Catch myerror As MySqlException
            '    MsgBox("Error connecting to Database")
            'End Try

            'Dim MyAdapter As New MySqlDataAdapter
            'Dim sqlquery = "SELECT * FROM showtime"
            'Dim mycommand As New MySqlCommand()
            'mycommand.Connection = Conn
            'mycommand.CommandText = sqlquery
            'MyAdapter.SelectCommand = mycommand
            'Dim myDataSet As DataSet = New DataSet()
            'MyAdapter.Fill(myDataSet, "showtime")
            'dataGridView1.DataSource = myDataSet.Tables("showtime").DefaultView
            'Conn.Close()

            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim MyAdapter As New MySqlDataAdapter
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = "SELECT * from showtime order by date_time"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader

            dataGridView1.Rows.Clear()
            While (MyData.Read() = True)
                dataGridView1.Rows.Add(MyData(0), MyData(1), getTime(MyData(2)), MyData(3), MyData(4), MyData(5), MyData(6))
            End While
            Conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        '        For I = 0 To rowsTotal - 1
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

    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim MyAdapter As New MySqlDataAdapter
            Dim sqlquery = "SELECT * FROM showtime where date_time = '" & dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "'"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            dataGridView1.Rows.Clear()
            While (MyData.Read() = True)
                dataGridView1.Rows.Add(MyData(0), MyData(1), getTime(MyData(2)), MyData(3), MyData(4), MyData(5), MyData(6))
            End While
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class