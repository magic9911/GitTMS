Public Class frmSplash

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ProgressBar1.Visible = True
        ProgressBar1.Value = ProgressBar1.Value + 2
        If (ProgressBar1.Value = 10) Then
            Label3.Text = "Crate Seats modules.."
            seat_ini()
        ElseIf (ProgressBar1.Value = 20) Then
            Label3.Text = "Turning on modules."
        ElseIf (ProgressBar1.Value = 40) Then
            Label3.Text = "Starting modules.."
            Timer2.Enabled = True
        ElseIf (ProgressBar1.Value = 60) Then
            Label3.Text = "Loading modules.."
        ElseIf (ProgressBar1.Value = 80) Then
            Label3.Text = "Done Loading modules.."
        ElseIf (ProgressBar1.Value = 100) Then
            Timer1.Enabled = False

            Try
                frmSeats.ShowDialog()
            Finally
                frmSeats.WindowState = FormWindowState.Maximized
                frmSeats.Hide()
            End Try

            frmLogin.ShowDialog()
            Me.Hide()
        End If
    End Sub


    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If fullScreen Then


            'Me.Size = SystemInformation.PrimaryMonitorSize
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.Location = New Point(0, 0)
            Me.WindowState = FormWindowState.Maximized
            'Me.TopMost = True
            Me.FormBorderStyle = 0

            'Make center all components
            Dim mainScreen As Screen = Screen.FromPoint(Me.Location)

            Dim Y As Integer = (mainScreen.WorkingArea.Height - ProgressBar1.Height)
            ProgressBar1.Width = mainScreen.WorkingArea.Width
            ProgressBar1.Location = New Point(0, Y)

            'Disable START Button
            Dim process As System.Diagnostics.Process = Nothing
            Dim psi As New ProcessStartInfo
            psi.UseShellExecute = True
            psi.FileName = "taskkill.exe"
            psi.Arguments = "/F /IM explorer.exe"
            process = System.Diagnostics.Process.Start(psi)

        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        For Each form In My.Application.OpenForms
            If (form.name = frmSeats.Name) Then
                frmSeats.Hide()
                Timer2.Enabled=False
            End If
        Next
    End Sub
End Class