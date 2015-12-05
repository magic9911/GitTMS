Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmRegistration
    Sub Reset()
        txtContactNo.Text = ""
        txtEmailID.Text = ""
        txtName.Text = ""
        txtPassword.Text = ""
        txtUsername.Text = ""
        cmbUserType.SelectedIndex = -1
        txtUsername.Focus()
        btnSave.Enabled = True
        btnUpdate_record.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub frmRegistration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub
    Public Sub Getdata()
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
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = "SELECT * from Registration order by JoiningDate"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader

            DataGridView1.Rows.Clear()
            While (MyData.Read() = True)
                DataGridView1.Rows.Add(MyData(1), MyData(2), MyData(3), MyData(4), MyData(5), MyData(6), MyData(7))
            End While
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub DataGridView1_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
            txtUsername.Text = dr.Cells(0).Value.ToString()
            TextBox1.Text = dr.Cells(0).Value.ToString()
            cmbUserType.Text = dr.Cells(1).Value.ToString()
            txtPassword.Text = dr.Cells(2).Value.ToString()
            txtName.Text = dr.Cells(3).Value.ToString()
            txtContactNo.Text = dr.Cells(4).Value.ToString()
            txtEmailID.Text = dr.Cells(5).Value.ToString()
            btnUpdate_record.Enabled = True
            btnDelete.Enabled = True
            btnSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtUsername.Text = "" Then
            MessageBox.Show("กรุณากรอกชื่อผู้ใช้งาน", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtUsername.Focus()
            Return
        End If
        If cmbUserType.Text = "" Then
            MessageBox.Show("กรุณาเลือก ตำแหน่ง", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbUserType.Focus()
            Return
        End If
        If txtPassword.Text = "" Then
            MessageBox.Show("กรุณากรอก รหัสผ่าน", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtPassword.Focus()
            Return
        End If
        If txtName.Text = "" Then
            MessageBox.Show("กรุณากรอก ชื่อ - สกุล", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtName.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("กรุณากรอก เบอร์โทรศัพท์มือถือ", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtContactNo.Focus()
            Return
        End If
       
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
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = "SELECT username from Registration where username='" & txtUsername.Text & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader

            If MyData.Read() Then
                MessageBox.Show("มีชื่อผู้ใช้ดังกล่าวแล้ว", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUsername.Text = ""
                txtUsername.Focus()
                If (MyData IsNot Nothing) Then
                    MyData.Close()
                    End
                    Return
                End If
                Conn.Close()
            End If

            Dim cb As String = "insert into Registration(id,UserName, UserType, User_Password, NameOfuser, ContactNo, Email,JoiningDate) VALUES (NULL,'" & _
                txtUsername.Text & "','" & cmbUserType.Text & "','" & txtPassword.Text & "','" & txtName.Text & "','" & _
                txtContactNo.Text & "','" & txtEmailID.Text & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("th-TH")) & "')"

            If AddData(cb) Then
                Dim cb1 As String = "insert into users(username) VALUES ('" & txtUsername.Text & "')"
                If AddData(cb1) Then
                    MessageBox.Show("บันทึก ผู้ใช้งานสำเร็จ", "User", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnSave.Enabled = False
                    Getdata()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("คุณต้องการลบรายการที่เลือก ใช่หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()

        Try
            If txtUsername.Text = "admin" Or txtUsername.Text = "Admin" Then
                MessageBox.Show("ระดับสิทธิการใช้งานของคุณไม่สามารถ ลบข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim RowsAffected As Integer = 0

            Dim ct As String = "delete from Users where Username='" & txtUsername.Text & "'"
            Dim cq As String = "delete from Registration where Username='" & txtUsername.Text & "'"

            If DelData(ct) Then
                If DelData(cq) Then
                    MessageBox.Show("ลบผู้ใช้งาน สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Getdata()
                    Reset()
                Else
                    MessageBox.Show("ไม่สามารถลบผู้ใช้งานได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Reset()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub txtContactNo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtContactNo.Validating
        If (txtContactNo.TextLength > 10) Then
            MessageBox.Show("Only 10 digits are allowed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtContactNo.Focus()
        End If
    End Sub

    Private Sub txtContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContactNo.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtEmailID_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtEmailID.Validating
        Dim rEMail As New System.Text.RegularExpressions.Regex("^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$")
        If txtEmailID.Text.Length > 0 Then
            If Not rEMail.IsMatch(txtEmailID.Text) Then
                MessageBox.Show("invalid email address", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtEmailID.SelectAll()
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try
            If txtUsername.Text = "" Then
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้งาน", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUsername.Focus()
                Return
            End If
            If cmbUserType.Text = "" Then
                MessageBox.Show("กรุณาเลือก ตำแหน่ง", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUserType.Focus()
                Return
            End If
            If txtPassword.Text = "" Then
                MessageBox.Show("กรุณากรอก รหัสผ่าน", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPassword.Focus()
                Return
            End If
            If txtName.Text = "" Then
                MessageBox.Show("กรุณากรอก ชื่อ - สกุล", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtName.Focus()
                Return
            End If
            If txtContactNo.Text = "" Then
                MessageBox.Show("กรุณากรอก เบอร์โทรศัพท์มือถือ", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtContactNo.Focus()
                Return
            End If

            Dim cb As String = "update registration set username='" & txtUsername.Text & "', usertype='" & cmbUserType.Text & "',user_password='" & txtPassword.Text & "',contactno='" & txtContactNo.Text & "',email='" & txtEmailID.Text & "',nameofuser='" & txtName.Text & "' where username='" & TextBox1.Text & "'"
            If UpdateData(CB) > 0 Then
                MessageBox.Show("บันทึก สำเร็จ", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnUpdate_record.Enabled = False
                Getdata()
            Else
                MessageBox.Show("ไม่สามารถบันทึกได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class