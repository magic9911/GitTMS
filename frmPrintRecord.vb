Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports MySql.Data.MySqlClient

Public Class frmPrintRecord

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
            Dim sqlquery = "SELECT * from view_print"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim myDataSet As DataSet = New DataSet()
            MyAdapter.Fill(myDataSet, "view_print")
            dataGridView1.DataSource = myDataSet.Tables("view_print").DefaultView
            Conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dataGridView1.RowHeaderMouseClick
        'Try
        '    Dim dr As DataGridViewRow = dataGridView1.SelectedRows(0)
        '    Me.Hide()
        '    frmReservation.ReserRev = dr.Cells(0).Value.ToString()
        '    frmReservation.txtReservationNo.Text = String.Format("{0:0000}", CInt(dr.Cells(0).Value.ToString()))
        '    frmReservation.txtid.Text = dr.Cells(1).Value.ToString()
        '    frmReservation.txtGuestName.Text = dr.Cells(2).Value.ToString()
        '    frmReservation.seats_free.Text = dr.Cells(4).Value.ToString()
        '    frmReservation.RichTextBox1.Text = dr.Cells(3).Value.ToString()
        '    frmReservation.txtVip.Text = dr.Cells(8).Value.ToString()
        '    frmReservation.txtNormal.Text = dr.Cells(9).Value.ToString()

        '    frmReservation.vip_c = dr.Cells(10).Value.ToString()
        '    frmReservation.normal_c = dr.Cells(11).Value.ToString()
        '    frmReservation.vip_free_c = dr.Cells(12).Value.ToString()
        '    frmReservation.normal_free_c = dr.Cells(13).Value.ToString()

        '    frmReservation.txtNotes.Text = dr.Cells(15).Value.ToString()

        '    frmReservation.dtpDate.Value = dr.Cells(6).Value.ToString()
        '    Dim d As Date = frmReservation.dtpDate.Value.ToString("yyyy-MM-dd")

        '    Dim st As String() = dr.Cells(7).Value.ToString().Split("-")
        '    Dim st1 As String() = st(0).Split(".")
        '    Dim st2 As String() = st(1).Split(".")

        '    frmReservation.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
        '    frmReservation.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)
        '    frmReservation.editing = False

        '    frmReservation.TextBox1.Text = GetStatusRev(frmReservation.ReserRev)
        '    If frmReservation.TextBox1.Text = "ยืนยัน" Then
        '        'frmReservation.Button5.Enabled = False
        '        frmReservation.btnCancelReservation.Enabled = False
        '        frmReservation.btnUpdate_record.Enabled = False
        '        frmReservation.Button2.Enabled = False
        '        frmReservation.Button3.Enabled = False
        '        frmReservation.Button4.Enabled = False
        '    Else
        '        'frmReservation.Button5.Enabled = True
        '        frmReservation.btnCancelReservation.Enabled = True
        '        frmReservation.btnUpdate_record.Enabled = True
        '        frmReservation.Button2.Enabled = True
        '        frmReservation.Button3.Enabled = True
        '        frmReservation.Button6.Enabled = True
        '        frmReservation.Button4.Enabled = False
        '    End If

        '    Dim myId As String = Getid("SELECT * FROM showtime where date_time = '" & frmReservation.dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "' and time = '" & dr.Cells(7).Value.ToString() & "'")
        '    frmReservation.ReserIdShow = myId
        '    frmReservation.btnNewRecord.Enabled = True
        '    frmReservation.btnSave.Enabled = False
        '    frmReservation.btnUpdate_record.Enabled = True
        '    frmReservation.Panel2.Visible = True

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

    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGuestName.TextChanged
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
            Dim sqlquery = "SELECT * from view_print where seat like '" + txtGuestName.Text + "%' order by time_print"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim myDataSet As DataSet = New DataSet()
            MyAdapter.Fill(myDataSet, "view_reservation")
            dataGridView1.DataSource = myDataSet.Tables("view_reservation").DefaultView
            Conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '        SELECT * FROM view_reservation
        'WHERE date_time BETWEEN '2012-12-25' AND '2012-12-25'

        Try
            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim date_start As String = dtpDateFrom.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US"))
            Dim date_end As String = dtpDateTo.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US"))

            Dim MyAdapter As New MySqlDataAdapter
            Dim sqlquery = "SELECT * from view_print WHERE time_print BETWEEN '" & date_start & "' AND '" & date_end & "'"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim myDataSet As DataSet = New DataSet()
            MyAdapter.Fill(myDataSet, "view_print")
            dataGridView1.DataSource = myDataSet.Tables("view_print").DefaultView
            Conn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        txtGuestName.Text = ""
        GetData()
    End Sub

    Private Sub dtpDateTo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDateTo.Validating
        If (dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtpDateTo.Focus()
        End If
    End Sub

    Private Sub frmReservationRecord_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmReservationRecord_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetData()
    End Sub

End Class