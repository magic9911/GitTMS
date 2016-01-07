Imports System.Data.OleDb
Imports System.Security.Cryptography
Imports System.Text
Public Class frmReservation
    Public ReserRev As Integer = 0
    Public ReserIdShow As Integer = 0
    Public editing As Boolean = False
    Public resup As Boolean = False


    Public vip_c As Integer
    Public normal_c As Integer
    Public vip_free_c As Integer
    Public normal_free_c As Integer


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmGuestRecord1.mode_return = 1
        frmGuestRecord1.GetData()
        frmGuestRecord1.ShowDialog()
    End Sub
    Private Sub auto()
        txtReservationNo.Text = "R-" & GetUniqueKey(8)

    End Sub
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function

    Sub Reset()
        vip_c = 0
        normal_c = 0
        vip_free_c = 0
        normal_free_c = 0

        editing = False
        Panel2.Visible = False
        Button2.Enabled = False
        Button6.Enabled = False

        txtReservationNo.Text = ""
        txtid.Text = ""
        txtGuestName.Text = ""
        txtNotes.Text = ""
        RichTextBox1.Text = ""
        seats_free.Text = ""
        TextBox1.Text = ""
        txtVip.Text = Seats_VIP_Val.ToString
        txtNormal.Text = Seats_Normal_Val.ToString
    End Sub

    Private Sub frmReservation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If RichTextBox1.Text <> "" Then
            UpdateRes()
        End If

        If (RichTextBox1.Text <> "" Or seats_free.Text <> "") And editing = True Then
            Dim save As Integer = MsgBox("คุณไม่ได้ทำการบันทึกข้อมูลการจอง" & vbCrLf & "คุณต้องการบันทึกข้อมูลหรือไม่ ?", MsgBoxStyle.YesNo, "ยืนยัน")

            If save = 6 Then
                SaveData()
            End If

            If save = 7 Then
                CancelData()
            End If
        End If
        Me.Dispose()
    End Sub

    Private Sub SaveData()
        Dim sql As String = "INSERT INTO  reservation(id,GuestID,SeatNo,SeatFree,id_showtime,Status,Notes,vip,normal,count_vip,count_normal,count_vip_free,count_normal_free, id_add,id_update,time_add,time_update) VALUES (NULL,'" & _
            txtid.Text & "','" & RichTextBox1.Text & "','" & seats_free.Text & "','" & ReserIdShow.ToString & "','0','" & _
            txtNotes.Text & "','" & txtVip.Text & "','" & txtNormal.Text & "','" & vip_c & "','" & normal_c & "','" & vip_free_c & "','" & normal_free_c & _
        "','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "');"
        If AddData(sql) Then
            Dim myId As Integer = CInt(Getid("SELECT * FROM reservation where id_showtime = '" & ReserIdShow.ToString & "' and SeatNo = '" & RichTextBox1.Text & "'"))
            MessageBox.Show("บันทึกการจอง เรียบร้อย" & vbCrLf & "รหัสการจอง [" & myId.ToString("0000") & "]", "บันทึกการจอง", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
            btnNewRecord.Enabled = True
            Button3.Enabled = False
            Button4.Enabled = False
        Else
            MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub CancelData2()
        Dim txtSeats As String = RichTextBox1.Text & seats_free.Text

        If SetStatusSeat("0", ReserIdShow.ToString, txtSeats, "0", "") > 0 Then
            MessageBox.Show("Successfully Cancel", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
        Else
            MessageBox.Show("ไม่สามารถยกเลิกได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Sub CancelData()
        'Dim tmpList() As String = RichTextBox1.Text.Split(",")
        'Dim sql As String = "UPDATE seats SET status = '0' WHERE name ='" & tmpList(1) & "' And id_showtime = '" & ReserIdShow.ToString & "';"
        'For i As Integer = 2 To tmpList.Length - 1
        '    sql += "UPDATE seats SET status = '0' WHERE name ='" & tmpList(i) & "' And id_showtime = '" & ReserIdShow.ToString & "';"
        'Next
        Dim txtSeats As String = RichTextBox1.Text & seats_free.Text

        If SetStatusSeat("0", ReserIdShow.ToString, txtSeats, "0", "") > 0 Then
            MessageBox.Show("Successfully Cancel", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
        Else
            MessageBox.Show("ไม่สามารถยกเลิกได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
        ReserIdShow = 0
        btnSave.Enabled = True
        btnNewRecord.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        editing = True
        Button1.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If RichTextBox1.Text = "" And seats_free.Text = "" Then
            MessageBox.Show("กรุณาเลือกที่นั่ง", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            SaveData()
            Button1.Enabled = True
            btnSave.Enabled = False
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateRes()
        Try
            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")

            Dim sqlquery As String = "UPDATE reservation SET GuestID = '" & txtid.Text & "',SeatNo = '" & RichTextBox1.Text & "',SeatFree = '" & seats_free.Text & "',id_showtime = '" & ReserIdShow.ToString & "',Notes = '" & txtNotes.Text & "'," & _
                "vip = '" & txtVip.Text & "',normal = '" & txtNormal.Text & "',count_vip = '" & vip_c & "',count_normal = '" & normal_c & "',count_vip_free = '" & vip_free_c & "',count_normal_free = '" & normal_free_c & _
                "',id_update = '" & User_Id & "',time_update = '" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "' where id='" & ReserRev.ToString & "'"
            UpdateData(sqlquery)

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try
            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")

            Dim sqlquery As String = "UPDATE reservation SET GuestID = '" & txtid.Text & "',SeatNo = '" & RichTextBox1.Text & "',SeatFree = '" & seats_free.Text & "',id_showtime = '" & ReserIdShow.ToString & "',Notes = '" & txtNotes.Text & "'," & _
                "vip = '" & txtVip.Text & "',normal = '" & txtNormal.Text & "',count_vip = '" & vip_c & "',count_normal = '" & normal_c & "',count_vip_free = '" & vip_free_c & "',count_normal_free = '" & normal_free_c & _
                "',id_update = '" & User_Id & "',time_update = '" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "' where id='" & ReserRev.ToString & "'"

            If UpdateData(sqlquery) Then
                MessageBox.Show("บันทึก สำเร็จ", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnUpdate_record.Enabled = False
                Button3.Enabled = False
                Button4.Enabled = False
                Button1.Enabled = True
                Reset()
            Else
                MessageBox.Show("ไม่สามารถบันทึกได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmReservationRecord.dtpDateFrom.Text = Today
        frmReservationRecord.dtpDateTo.Text = Today
        frmReservationRecord.txtGuestName.Text = ""
        'frmReservationRecord.GetData()
        frmReservationRecord.ShowDialog()
    End Sub

    Private Sub btnCancelReservation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelReservation.Click
        Try
            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")

            If MessageBox.Show("คุณต้องการยกเลิกการจองเลขที่ [" & txtReservationNo.Text & "] ใช่หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim note As String = InputBox("กรุณากรอกเหตุผลที่ต้องการยกเลิก ดังกล่าว ...", "เหตุผลในการยกเลิก", "")
                If note.Length < 8 Then
                    MessageBox.Show("เหตุผลต้องยาวอย่างน้อย 8 ตัวอักษรขึ้นไป", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                'Dim myId As String = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
                'Dim sql As String = "SELECT * FROM reservation where id = '" & ReserRev & "'"

                'If checkData(sql) = False Then
                '    MessageBox.Show("ไม่พบเลขที่นั่งตามที่ระบุ", ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If

                Dim dr As String = "INSERT INTO  del_reser(id,date,time,guest,seat,note,id_del,time_del) VALUES(NULL,'" & _
date_txt & "','" & time_txt & "','" & txtGuestName.Text & "','" & RichTextBox1.Text & seats_free.Text & "','" & note & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                If AddData(dr) Then

                End If
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub DeleteRecord()
        Try
            'Dim Sql As String = "UPDATE seats SET status = '0' WHERE name ='" & seat_no.Text & "' And id_showtime = '" & ReserIdShow & "';"
            Dim ct As String = "delete from reservation where id='" & ReserRev.ToString & "'"

            If DelData(ct) And SetStatusSeat("0", ReserIdShow, "," & RichTextBox1.Text & seats_free.Text, "0", "") > 0 Then
                MessageBox.Show("ยกเลิกบัตรเข้าชมการจอง  สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("ไม่สามารถยกเลิกการจองได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            btnCancelReservation.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            btnCancelReservation.Enabled = False
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Loading.Show()
            Loading.Refresh()

            frmSeats.Seats_Status = "1"
            frmSeats.Seats_Txt = "จอง"
            frmSeats.idShow = ReserIdShow
            frmSeats.id_guest = txtid.Text
            'frmSeats.date_txt = dtpDate.Value.ToString("yyyy-MM-dd")
            frmSeats.time_txt = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")
            If RichTextBox1.Text <> "" Then
                frmSeats.Seats_Tmp = RichTextBox1.Text
                frmSeats.Seats_ReChack(RichTextBox1.Text)
            Else
                frmSeats.Refresh_Seats()
            End If

            Loading.Hide()
            frmSeats.Text = "เลือกที่นั่ง" & "     วันที่ " & dtpDate.Value.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")) & "   เวลา " & Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")
            frmSeats.Button1.Text = "ยืนยันการจอง"
            frmSeats.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frmGuestRecord2.mode = 1
        'frmGuestRecord2.GetData()
        frmGuestRecord2.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'frmPrint2.showSeat(idShow, listSeats.Text)
        'frmPrint2.ShowDialog()

        ShowPrice = CheckBox1.Checked
        Dim txtSeats As String = RichTextBox1.Text & seats_free.Text
        Dim tmpList As String() = txtSeats.Split(",")
        'Dim save As Integer = MsgBox("ยืนยันการพิมพ์บัตร จำนวน " & tmpList.Length - 1 & " ที่นั่ง", MsgBoxStyle.YesNo, "ยืนยัน")
        Dim save As Integer = MsgBox("ยืนยันการพิมพ์บัตร", MsgBoxStyle.YesNo, "ยืนยัน")

        If save = 6 Then
            Dim sqlRev As String = "UPDATE reservation SET Status = '1" & _
            "',id_update = '" & User_Id & "',time_update = '" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "' where id = '" & ReserRev.ToString & "';"

            If RadioButton1.Checked = True Then
                PrintSeat(ReserIdShow, txtSeats)
                If SetStatusSeat(txtid.Text, ReserIdShow.ToString, txtSeats, "2", "") > 0 And UpdateData(sqlRev) > 0 Then
                    'Dim okPrint As Integer = MsgBox("กรุณาตรวจสอบการพิมพ์บัตร จำนวน " & tmpList.Length - 1 & " บัตร ว่าครบถ้วนหรือไม่?", MsgBoxStyle.YesNo, "ยืนยัน")
                    'If okPrint = 6 Then
                    Reset()
                    Exit Sub
                    'Else
                    '    frmPrint2.showSeat(ReserIdShow, txtSeats)
                    '    frmPrint2.ShowDialog()
                    '    Reset()
                    '    Exit Sub
                    'End If

                Else
                    MessageBox.Show("ไม่สามารถปรับปรุงสถานะที่นั่ง", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            If RadioButton2.Checked = True Then
                If SetStatusSeat(txtid.Text, ReserIdShow.ToString, txtSeats, "2", "") > 0 And UpdateData(sqlRev) > 0 Then
                    frmPrint2.showSeat(ReserIdShow, txtSeats)
                    frmPrint2.ShowDialog()
                    Reset()
                    Exit Sub
                End If
            Else
                MessageBox.Show("ไม่สามารถปรับปรุงสถานะที่นั่ง", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

        End If


    End Sub

    Private Sub txtVip_TextChanged(sender As Object, e As EventArgs) Handles txtVip.TextChanged
        txtVip.Text = Val(txtVip.Text)
    End Sub

    Private Sub txtNormal_TextChanged(sender As Object, e As EventArgs) Handles txtNormal.TextChanged
        txtNormal.Text = Val(txtNormal.Text)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Loading.Show()
            Loading.Refresh()

            frmSeats.Seats_Status = "3"
            frmSeats.Seats_Txt = "จอง(ฟรี)"
            frmSeats.idShow = ReserIdShow
            'frmSeats.date_txt = dtpDate.Value.ToString("yyyy-MM-dd")
            frmSeats.time_txt = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")
            If seats_free.Text <> "" Then
                frmSeats.Seats_Tmp = seats_free.Text
                frmSeats.Seats_ReChack(seats_free.Text)
            Else
                frmSeats.Refresh_Seats()
            End If

            Loading.Hide()
            frmSeats.Text = "เลือกที่นั่ง" & "     วันที่ " & dtpDate.Value.ToString("dd-MM-yyyy", New System.Globalization.CultureInfo("th-TH")) & "   เวลา " & Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")
            frmSeats.Button1.Text = "ยืนยันการจอง (ฟรี)"
            frmSeats.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
