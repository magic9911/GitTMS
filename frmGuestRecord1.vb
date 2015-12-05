Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmGuestRecord1
    Public mode_return As Integer = 0

    Private Sub frmGuestRecord1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmGuestRecord_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        Try
            Select Case mode_return
                Case 0
                    Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)

                    'frmGuest.ShowDialog()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmGuest.txtid.Text = dr.Cells(0).Value.ToString()
                    frmGuest.txtGuestName.Text = dr.Cells(1).Value.ToString()
                    frmGuest.txtGuestAddress.Text = dr.Cells(2).Value.ToString()
                    frmGuest.txtGuestCity.Text = dr.Cells(3).Value.ToString()
                    frmGuest.txtGuestContactNo.Text = dr.Cells(4).Value.ToString()
                    frmGuest.cmbIDType.Text = dr.Cells(5).Value.ToString()
                    frmGuest.txtIDNumber.Text = dr.Cells(6).Value.ToString()
                    frmGuest.txtNotes.Text = dr.Cells(7).Value.ToString()
                    frmGuest.btnUpdate_record.Enabled = True
                    frmGuest.btnDelete.Enabled = True
                    frmGuest.btnSave.Enabled = False
                    frmGuest.txtGuestName.Focus()
                    Me.Hide()

                Case 1
                    Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                    frmReservation.txtid.Text = dr.Cells(0).Value.ToString()
                    frmReservation.txtGuestName.Text = dr.Cells(1).Value.ToString()
                    Me.Hide()

                Case 2
                    Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
                    frmGuestBuy.ComboBox1.Text = dr.Cells(1).Value.ToString()
                    Me.Hide()

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

    Private Sub txtCustomers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuests.TextChanged
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
            Dim sqlquery = "SELECT id,Guestname,address,city,ContactNo,IDType,IDNumber,Notes from Guest where GuestName like '" + txtGuests.Text + "%' Or Address like '" + txtGuests.Text + "%'order by GuestName"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim myDataSet As DataSet = New DataSet()
            MyAdapter.Fill(myDataSet, "Guest")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            Conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetData()
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
            Dim sqlquery = "SELECT id,Guestname,address,city,ContactNo,IDType,IDNumber,Notes from Guest order by id"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim myDataSet As DataSet = New DataSet()
            MyAdapter.Fill(myDataSet, "Guest")
            dataGridView1.DataSource = myDataSet.Tables("Guest").DefaultView
            Conn.Close()

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

End Class