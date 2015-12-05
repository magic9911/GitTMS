Imports System.Security.Cryptography
Imports System.Text
Public Class frmGuest

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
        txtid.Text = ""
        txtGuestName.Text = ""
        txtGuestAddress.Text = ""
        txtGuestCity.Text = ""
        txtGuestContactNo.Text = ""
        cmbIDType.SelectedIndex = -1
        txtIDNumber.Text = ""
        txtNotes.Text = ""
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate_record.Enabled = False
        txtGuestName.Focus()
    End Sub

    Private Sub frmGuest_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmGuest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtGuestContactNo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGuestContactNo.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnNewRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRecord.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtGuestName.Text)) = 0 Then
                MessageBox.Show("Please enter guest name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestName.Focus()
                Exit Sub
            End If

            'If Len(Trim(txtGuestAddress.Text)) = 0 Then
            '    MessageBox.Show("Please enter guest address", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtGuestAddress.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtGuestCity.Text)) = 0 Then
            '    MessageBox.Show("Please enter guest city", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtGuestCity.Focus()
            '    Exit Sub
            'End If

            If Len(Trim(txtGuestContactNo.Text)) = 0 Then
                MessageBox.Show("Please enter guest contact no.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtGuestContactNo.Focus()
                Exit Sub
            End If
            'If Len(Trim(cmbIDType.Text)) = 0 Then
            '    MessageBox.Show("Please select id type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    cmbIDType.Focus()
            '    Exit Sub
            'End If
            'If Len(Trim(txtIDNumber.Text)) = 0 Then
            '    MessageBox.Show("Please enter id number", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtIDNumber.Focus()
            '    Exit Sub
            'End If
            'txtid.Text = "G-" & GetUniqueKey(6)

            Dim cb As String = "insert into Guest(id, GuestName, Address, City, ContactNo, IDType, IDNumber, Notes) VALUES (NULL,'" & txtGuestName.Text & "','" & txtGuestAddress.Text & "','" & txtGuestCity.Text & "','" & txtGuestContactNo.Text & "','" & cmbIDType.Text & "','" & txtIDNumber.Text & "','" & txtNotes.Text & "')"
            If UpdateData(cb) > 0 Then
                MessageBox.Show("บันทึก สำเร็จ", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnSave.Enabled = False
            Else
                MessageBox.Show("ไม่สามารถบันทึกได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("คุณต้องการลบรายการที่เลือก ใช่หรือไม่?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteGuest()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DeleteGuest()
        Try
            Dim ct As String = "delete from guest where id='" & txtid.Text & "'"

            If DelData(ct) Then
                MessageBox.Show("ลบข้อมูลลูกค้า สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("ไม่สามารถลบข้อมูลลูกค้าได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub btnUpdate_record_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate_record.Click
        Try
            Dim cb As String = "update Guest set GuestName='" & txtGuestName.Text & "',Address='" & txtGuestAddress.Text & "',City='" & txtGuestCity.Text & "',ContactNo='" & txtGuestContactNo.Text & "',IDType='" & cmbIDType.Text & "',IDNumber='" & txtIDNumber.Text & "',Notes='" & txtNotes.Text & "' where id='" & txtid.Text & "'"
            If UpdateData(CB) > 0 Then
                MessageBox.Show("บันทึก สำเร็จ", "User Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnUpdate_record.Enabled = False
            Else
                MessageBox.Show("ไม่สามารถบันทึกได้", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Reset()
        frmGuestRecord1.mode_return = 0
        frmGuestRecord1.GetData()
        frmGuestRecord1.ShowDialog()
    End Sub
End Class