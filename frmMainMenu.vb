Imports System.Data.OleDb
Imports System.IO

Public Class frmMainMenu
    Private logout As Boolean = False
    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAboutBox1.ShowDialog()
    End Sub


    Private Sub NotePadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotePadToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Notepad.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub main_form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If fullScreen Then
            'Me.Size = SystemInformation.PrimaryMonitorSize
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.Location = New Point(0, 0)
            Me.WindowState = FormWindowState.Maximized
            'Me.TopMost = True
            Me.FormBorderStyle = 0

            'Make center all components
            Dim mainScreen As Screen = Screen.FromPoint(Me.Location)

            'Dim mywidth = GroupBox1.Width / 2
            'Dim myhight = GroupBox1.Height / 2
            'Dim X As Integer = (mainScreen.WorkingArea.Width - (mywidth * 2)) / 2 + mainScreen.WorkingArea.Left
            'Dim Y As Integer = (mainScreen.WorkingArea.Height - (myhight * 2)) / 2 + mainScreen.WorkingArea.Top
            'GroupBox1.Location = New Point(X, Y)

            PictureBox1.Width = mainScreen.WorkingArea.Width
            PictureBox1.Height = mainScreen.WorkingArea.Height - StatusStrip1.Height - MenuStrip2.Height - 25

            'Disable START Button
            'Dim process As System.Diagnostics.Process = Nothing
            'Dim psi As New ProcessStartInfo
            'psi.UseShellExecute = True
            'psi.FileName = "taskkill.exe"
            'psi.Arguments = "/F /IM explorer.exe"
            'process = System.Diagnostics.Process.Start(psi)
        End If

        logout = False
        'Me.Refresh()
        'Button2.PerformClick()
        'Timer2.Start()
        'Timer2.Interval = 1000
        'ToolStripStatusLabel4.Text = Now
        'lblUser.Text = frmLogin.UserName.Text
    End Sub


    Private Sub SystemInfoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemInfoToolStripMenuItem.Click
        frmSystemInfo.ShowDialog()
    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalculatorToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel4.Text = Now
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        'If fullScreen Then
        '    LogoffComputer()
        'End If
        'End
        logout = True

        Me.Close()
        Me.Hide()
        'frmGuest.Hide()
        'frmRegistration.Hide()
        'frmLoginDetails.Hide()
        'frmReservation.Hide()
        'frmGuestRecord1.Hide()
        'frmGuestRecord2.Hide()
        'frmAttendanceReport.Hide()
        'frmReservationRecord.Hide()
        'frmAboutBox1.Hide()
        'frmStock.Hide()
        'frmGuestsReport.Hide()
        frmLogin.UserName.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserType.SelectedIndex = -1
        frmLogin.ProgressBar1.Visible = False
        frmLogin.UserType.Focus()
        frmLogin.ShowDialog()
    End Sub

    Private Sub AttendanceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttendanceToolStripMenuItem1.Click
        frmGuestBuy.ShowDialog()
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInToolStripMenuItem.Click
        frmRoomsAvailability.ShowDialog()
    End Sub

    Private Sub ReservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationToolStripMenuItem.Click
        frmReservation.ShowDialog()
    End Sub

    Private Sub ReservationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReservation.ShowDialog()
    End Sub


    Private Sub RegistrationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistrationToolStripMenuItem1.Click
        frmRegistration.ShowDialog()
    End Sub


    Private Sub GuestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem.Click
        frmGuest.ShowDialog()
    End Sub

    Private Sub LoginDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginDetailsToolStripMenuItem.Click
        frmLoginDetails.ShowDialog()
    End Sub


    Private Sub StockToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (lblUserType.Text = "User") Then
            frmStock.btnSave.Enabled = False
            frmStock.btnSave1.Enabled = False
            frmStock.lblUserType.Text = lblUserType.Text
            frmStock.ShowDialog()
        End If
        If (lblUserType.Text = "Admin") Then
            frmStock.ShowDialog()
        End If
    End Sub

    Private Sub StockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockToolStripMenuItem.Click
        frmSTime.ShowDialog()
    End Sub


    Private Sub GuestToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuestToolStripMenuItem1.Click
        frmGuest.ShowDialog()

    End Sub

    Private Sub frmMainMenu_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If logout = False Then
            If fullScreen Then
                LogoffComputer()
            End If
            End
        End If
        Me.Dispose()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        If blackupdb() = True Then
            MessageBox.Show("สำรองข้อมูล เรียบร้อย", "สำรองข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("ไม่สามารถสำรองข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        'Dim dlg As New OpenFileDialog
        'dlg.DefaultExt = "*.accdb"
        'dlg.Filter = "ACCESS DB|*.accdb|All File|*"
        'If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    con.Close()
        '    File.Copy(dlg.FileName, Application.StartupPath & "\HMS_DB.accdb", True)
        '    main_form_Load(Nothing, Nothing)
        'End If
    End Sub

    Private Sub frmMainMenu_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If fullScreen = False Then
            PictureBox1.Width = Me.Width - 10
            PictureBox1.Height = Me.Height - StatusStrip1.Height - MenuStrip2.Height - 60
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        frmCancelReservation.ShowDialog()
    End Sub

    Private Sub RoomsAvailabilityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomsAvailabilityToolStripMenuItem.Click
        frmSTime.ShowDialog()
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frmGuestRecord5.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PaymentToolStripMenuItem1.Click
        frmReservation.ShowDialog()
        'frmReservationRecord.dtpDateFrom.Text = Today
        'frmReservationRecord.dtpDateTo.Text = Today
        'frmReservationRecord.txtGuestName.Text = ""
        'frmReservationRecord.GetData()
        'frmReservationRecord.ShowDialog()

    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        If InputBox("Password", "Login", "") = Now.ToString("dd-yyyy") Then
            Dim process As System.Diagnostics.Process = Nothing
            Dim psi As New ProcessStartInfo
            psi.UseShellExecute = True
            psi.FileName = "explorer.exe"
            'psi.Arguments = "/F /IM explorer.exe"
            process = System.Diagnostics.Process.Start(psi)
            fullScreen = False
            End
            'Me.Hide()
            'Application.Exit()
        Else
            MessageBox.Show("Incorrect Password", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub monySend_Click(sender As Object, e As EventArgs) Handles monySend.Click
        'frmSendmony.datesend = Now
        'frmSendmony.namesend = lblUser.Text
        'frmSendmony.vipsend = 0
        'frmSendmony.norsend = 0
        'frmSendmony.vipsum = 0
        'frmSendmony.norsum = 0
        'frmSendmony.sumall = 0
        frmSendmony.process(lblUser.Text)
        frmSendmony.ShowDialog()
    End Sub

    Private Sub PrintSeats_Click(sender As Object, e As EventArgs) Handles PrintSeats.Click
        frmRePrint.ShowDialog()
    End Sub

    Private Sub recPrint_Click(sender As Object, e As EventArgs) Handles recPrint.Click
        frmPrintRecord.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        frmGuestRecord5.ShowDialog()
    End Sub

    Private Sub OrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderToolStripMenuItem.Click
        frmGuestRecord5.ShowDialog()
    End Sub

    Private Sub ราคาบตรToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ราคาบตรToolStripMenuItem.Click
        frmSTime.ShowDialog()
    End Sub
End Class