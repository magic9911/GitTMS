Imports System.Data.OleDb
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Public Class frmSTime

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
    Public Sub Reset()
        txtName.Text = ""
        cmbIDType.SelectedIndex = 0
        txtNotes.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate_record.Enabled = False
    End Sub

    Private Sub frmSTime_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtGuestContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            If Len(Trim(txtName.Text)) = 0 Then
                MessageBox.Show("Please enter Show Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtName.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbIDType.Text)) = 0 Then
                MessageBox.Show("Please select id type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbIDType.Focus()
                Exit Sub
            End If

            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")

            Dim sqlquery = "SELECT * FROM showtime where date_time = '" & _
                            date_txt & "' and time = '" & time_txt & "'"

            If checkData(sqlquery) Then
                MessageBox.Show("วันที่และเวลาดังกล่าวมีการบันทึกใว้แล้ว", "บันทึก", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            sqlquery = "INSERT INTO  showtime(id ,name ,date_time ,time ,s_count ,status ,coment, id_add,id_update,time_add,time_update) VALUES (NULL,'" & _
                txtName.Text & "','" & date_txt & "','" & time_txt & "','0','" & cmbIDType.Text & "','" & txtNotes.Text & _
                "','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "');"
            If AddData(sqlquery) Then

                Dim myId As String = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
                Dim addZone As String = "INSERT INTO seats(id,id_showtime,GuestID,zone,taq,status,mode,name,coment,id_add,id_update,time_add,time_update) VALUES"
                Dim valZone As String = String.Empty

                Dim lowone As Boolean = True

                For i As Integer = 0 To Row_Name.Length - 1
                    If Array.IndexOf(VIP_Seats, Row_Name(i)) >= 0 Then
                        For j As Integer = 1 To Num_Seats(i)
                            If lowone Then
                                valZone += " (NULL ,'" & myId & "','0','" & Row_Name(i) & "','" & j.ToString & "','0','1','" & Row_Name(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            Else
                                valZone += ", (NULL ,'" & myId & "','0','" & Row_Name(i) & "','" & j.ToString & "','0','1','" & Row_Name(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            End If
                        Next
                    Else
                        For j As Integer = 1 To Num_Seats(i)
                            If lowone Then
                                valZone += " (NULL ,'" & myId & "','0','" & Row_Name(i) & "','" & j.ToString & "','0','0','" & Row_Name(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            Else
                                valZone += ", (NULL ,'" & myId & "','0','" & Row_Name(i) & "','" & j.ToString & "','0','0','" & Row_Name(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            End If
                        Next
                    End If
                Next

                For i As Integer = 0 To Row_Name_V.Length - 1
                    If Array.IndexOf(VIP_Seats, Row_Name_V(i)) >= 0 Then
                        For j As Integer = 1 To Num_Seats_V(i)
                            If lowone Then
                                valZone += " (NULL ,'" & myId & "','0','" & Row_Name_V(i) & "','" & j.ToString & "','0','1','" & Row_Name_V(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            Else
                                valZone += ", (NULL ,'" & myId & "','0','" & Row_Name_V(i) & "','" & j.ToString & "','0','1','" & Row_Name_V(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            End If
                        Next
                    Else
                        For j As Integer = 1 To Num_Seats_V(i)
                            If lowone Then
                                valZone += " (NULL ,'" & myId & "','0','" & Row_Name_V(i) & "','" & j.ToString & "','0','0','" & Row_Name_V(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            Else
                                valZone += ", (NULL ,'" & myId & "','0','" & Row_Name_V(i) & "','" & j.ToString & "','0','0','" & Row_Name_V(i) & j.ToString("00") & "','','" & User_Id & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                                lowone = False
                            End If
                        Next
                    End If
                Next


                Dim addSql As String = addZone & valZone
                If AddData(addSql) Then
                    MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            'sqlquery = "SELECT * FROM showtime where date_time = '" & _
            '                date_txt & "' and time = '" & time_txt & "'"
            'Dim mycommand3 As New MySqlCommand()
            'mycommand3.Connection = Conn
            'mycommand3.CommandText = sqlquery
            'MyAdapter.SelectCommand = mycommand
            'Dim MyData3 As MySqlDataReader
            'MyData3 = mycommand.ExecuteReader
            'Dim AddObbj As Object = 0

            'If MyData.HasRows Then

            '    MyData3.Read()

            '    AddObbj = MyData3(AddObbj)
            'End If

            'Dim addZoneA As String = "INSERT INTO seats(id,id_showtime,zone,taq,status,coment) VALUES (NULL ,  '1',  'A',  '2',  '0',  '')"
            'Dim valZoneA As String = String.Empty

            'For i As Integer = 2 To S_Normal
            '    valZoneA += ", (NULL ,  '" & i.ToString & "',  'A',  '" & i.ToString & "',  '0',  '')"
            'Next

            'MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Conn.Close()
            btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")

            If MessageBox.Show("คุณต้องการลบรายการที่เลือก ใช่หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                Dim note As String = InputBox("กรุณากรอกเหตุผลที่ต้องการลบรอบการแสดงดังกล่าว ...", "เหตุผลในการลบ", "")
                If note.Length < 8 Then
                    MessageBox.Show("เหตุผลต้องยาวอย่างน้อย 8 ตัวอักษรขึ้นไป", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim dr As String = "INSERT INTO  del_showtime(id,date,time,name,note,id_del,time_del) VALUES(NULL,'" & _
date_txt & "','" & time_txt & "','" & txtName.Text & "','" & note & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"
                If AddData(dr) Then

                End If
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim ct As String = "delete from showtime where id='" & lb_id.Text & "'"
            Dim cq As String = "delete from seats where id_showtime='" & lb_id.Text & "'"

            If DelData(ct) Then
                If DelData(cq) Then
                    MessageBox.Show("ลบรายการแสดง สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                Else
                    MessageBox.Show("ไม่สามารถลบรายการแสดงได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try
            If Len(Trim(txtName.Text)) = 0 Then
                MessageBox.Show("Please enter guest address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtName.Focus()
                Exit Sub
            End If

            If Len(Trim(cmbIDType.Text)) = 0 Then
                MessageBox.Show("Please select id type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                cmbIDType.Focus()
                Exit Sub
            End If

            Dim date_txt As String = dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) 'dtpDate.Value.Year & "-" & dtpDate.Value.Month & "-" & dtpDate.Value.Day
            Dim time_txt As String = Time_Start.Value.ToString("HH.mm") & "-" & Time_End.Value.ToString("HH.mm")


            Dim sqlquery As String = "UPDATE showtime SET name = '" & txtName.Text & "',date_time = '" & date_txt & "',time = '" & time_txt & _
                "',status = '" & cmbIDType.Text & "',coment = '" & txtNotes.Text & _
                "',id_update = '" & User_Id & "',time_update = '" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "' where id='" & lb_id.Text & "'"

            If UpdateData(sqlquery) Then
                MessageBox.Show("บันทึก สำเร็จ", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnUpdate_record.Enabled = False
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
        Me.Reset()
        frmGuestRecord2.mode = 0
        frmGuestRecord2.ShowDialog()
        'frmGuestRecord2.GetData()
    End Sub

    Private Sub txtVip_TextChanged(sender As Object, e As EventArgs) Handles txtVip.TextChanged
        txtVip.Text = Val(txtVip.Text)
    End Sub

    Private Sub txtNormal_TextChanged(sender As Object, e As EventArgs) Handles txtNormal.TextChanged
        txtNormal.Text = Val(txtNormal.Text)
    End Sub
End Class