Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmRoomsAvailability

    Private Sub dataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            'Dim wD As Long = DateDiff(DateInterval.Day, setTime(Now.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US"))).Value, setTime(dr.Cells(1).Value.ToString()).Value)
            Dim dat As DateTimePicker = setTime(dr.Cells(1).Value.ToString())
            Dim datTim1 As Date = Now
            Dim datTim2 As Date = dat.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US"))
            ' Assume Sunday is specified as first day of the week. 
            Dim wD As Long = DateDiff(DateInterval.Day, datTim1, datTim2)

            If wD >= 0 And dr.Cells(5).Value.ToString() = "จำหน่าย" Then
                Me.Hide()
                'frmSeats.ShowDialog()
                'Form2.ShowDialog()

                Loading.Show()
                Loading.Refresh()


                frmSeats.Seats_Status = "2"
                frmSeats.Seats_Txt = "จำหน่าย"
                frmSeats.idShow = dr.Cells(0).Value.ToString()
                frmSeats.date_txt = dr.Cells(1).Value.ToString()
                frmSeats.time_txt = dr.Cells(2).Value.ToString()
                frmSeats.Refresh_Seats()
                Loading.Hide()
                frmSeats.Text = "เลือกที่นั่ง" & "     วันที่ " & dr.Cells(1).Value.ToString() & "   เวลา " & dr.Cells(2).Value.ToString()
                frmSeats.Button1.Text = "ยืนยัน / พิมพ์บัตร"
                frmSeats.ShowDialog()
            Else
                MessageBox.Show("รอบการแสดงดังกล่าว งดการจำหน่าย / พ้นกำหนดการแสดง", "ไม่สามารถเลือกรอบการแสดงได้", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If




        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
            DataGridView1.Rows.Clear()
            While (MyData.Read() = True)
                DataGridView1.Rows.Add(MyData(0), getTime(MyData(2)), MyData(3), MyData(1), MyData(4), MyData(5))
            End While
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmRoomsAvailability_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmRoomsAvailability_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        countseat()
    End Sub

    Private Sub countseat()
        Try
            Dim sid As String = GetAllShow()
            Dim idshow As String() = sid.Split(",")

            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            For i As Integer = 0 To idshow.Length - 2

                Dim MyAdapter As New MySqlDataAdapter
                Dim sqlquery = "Select COUNT(*) FROM seats where id_showtime = '" & idshow(i) & "' And status = '2'"
                Dim mycommand As New MySqlCommand()
                mycommand.Connection = Conn
                mycommand.CommandText = sqlquery
                MyAdapter.SelectCommand = mycommand
                Dim Count As Integer = mycommand.ExecuteScalar

                Dim txtquery As String = "UPDATE showtime SET s_count = '" & Count & "' where id='" & idshow(i) & "'"

                UpdateData(txtquery)

            Next

            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
            Dim sqlquery = "SELECT * FROM showtime"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            DataGridView1.Rows.Clear()
            While (MyData.Read() = True)
                Dim tm As New DateTimePicker()
                tm.Value = MyData(2)
                DataGridView1.Rows.Add(MyData(0), tm.Value.ToString("dd-MM-yyyy"), MyData(3), MyData(1), MyData(4), MyData(5))
            End While
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class