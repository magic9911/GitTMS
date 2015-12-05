Public Class frmPrint2
    Private idshow As String = String.Empty
    Private seatList As String = String.Empty

    Public Sub showSeat(id As String, ss As String)
        idshow = id
        seatList = ss
        Dim seat As String() = ss.Split(",")
        Dim offset = 10
        For i As Integer = 1 To seat.Length - 1
            Dim checkBox = New CheckBox()
            checkBox.Location = New Point(10, offset)
            checkBox.Text = seat(i)
            checkBox.Checked = True
            checkBox.Size = New Size(100, 20)
            Panel1.Controls.Add(checkBox)
            offset += 30
        Next
    End Sub

    Private Sub frmPrint2_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmPrint2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'showSeat(",A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03,A01,A02,A03")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim seat As String = String.Empty
        For Each ss As Object In Panel1.Controls
            If ss.Checked = True Then
                seat += "," & ss.Text
            End If
        Next

        PrintSeat(idshow, seat)
        'SetStatusSeat(idshow, seat, "2", "")

        Dim tmp As String() = seat.Split(",")
        MessageBox.Show("Successfully Print", "Prin & Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim okPrint As Integer = MsgBox("กรุณาตรวจสอบการพิมพ์บัตร จำนวน " & tmp.Length - 1 & " บัตร ว่าครบถ้วนหรือไม่?", MsgBoxStyle.YesNo, "ยืนยัน")

        If okPrint = 6 Then
            frmSeats.Refresh_Seats()
            Me.Hide()
        End If
    End Sub
End Class