Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmRePrint

    Public ReserIdShow As String = String.Empty

    Public Sub DeleteRecord()
        Try
            'Dim Sql As String = "UPDATE seats SET status = '0' WHERE name ='" & seat_no.Text & "' And id_showtime = '" & ReserIdShow & "';"

            If SetStatusSeat("0", ReserIdShow, "," & seat_no.Text, "0", "") > 0 Then
                MessageBox.Show("ยกเลิกบัตรเข้าชม [" & seat_no.Text & "]  สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                reset()
            Else
                MessageBox.Show("ไม่สามารถยกเลิกบัตรเข้าชม [" & seat_no.Text & "] ได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            btnCancelReservation.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            btnCancelReservation.Enabled = False
        End Try
    End Sub
    Private Sub reset()
        txtReservationNo.Text = ""
        seat_no.Text = ""
        txtNotes.Text = ""
        dtpDate.Value = Now
        Time_Start.Value = Now
        Time_End.Value = Now
    End Sub

    Private Sub btnCancelReservation_Click(sender As Object, e As EventArgs) Handles btnCancelReservation.Click
        Try
            If Len(Trim(txtReservationNo.Text)) = 0 Then
                MessageBox.Show("กรุณากรอกเลขที่บัตร", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtReservationNo.Focus()
                Exit Sub
            End If

            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd") 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")

            If MessageBox.Show("คุณต้องการยกเลิกบัตรเข้าชมเลขที่ [" & txtReservationNo.Text & "] ใช่หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                If txtNotes.Text.Length < 8 Then
                    MessageBox.Show("เหตุผลต้องยาวอย่างน้อย 8 ตัวอักษรขึ้นไป", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                'Dim myId As String = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
                Dim sql As String = "SELECT * FROM seats where id_showtime = '" & ReserIdShow & "' and name = '" & seat_no.Text & "' and status != '0'"

                If checkData(sql) = False Then
                    MessageBox.Show("ไม่พบเลขที่นั่งตามที่ระบุ", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim dr As String = "INSERT INTO  del_seats(id,date,time,no,seat,note,id_del,time_del) VALUES(NULL,'" & _
date_txt & "','" & time_txt & "','" & txtReservationNo.Text & "','" & seat_no.Text & "','" & txtNotes.Text & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "')"
                If AddData(dr) Then

                End If
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmGuestRecord2.mode = 2
        frmGuestRecord2.GetData()
        frmGuestRecord2.ShowDialog()
    End Sub

    Private Sub frmCancelReservation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class