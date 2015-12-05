Imports System.Data.OleDb
Imports MySql.Data.MySqlClient

Public Class frmLogin

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Len(Trim(UserType.Text)) = 0 Then
            MessageBox.Show("Please select user type", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UserType.Focus()
            Exit Sub
        End If
        If Len(Trim(UserName.Text)) = 0 Then
            MessageBox.Show("Please enter user name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            UserName.Focus()
            Exit Sub
        End If
        If Len(Trim(Password.Text)) = 0 Then
            MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Password.Focus()
            Exit Sub
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
            Dim sqlquery = "SELECT * FROM Registration where Username = '" & _
            UserName.Text & "' and user_password = '" & Password.Text & "' and UserType='" & UserType.Text & "'"

            'Dim sqlquery = "SELECT * FROM Registration where Username = '" & _
            '    UserName.Text & "' and user_password = '" & Password.Text & "'"

            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            'If MyData.HasRows = 0 Then
            '    MsgBox("Invalid Login!")
            'Else
            '    MsgBox("Login Accepted")

            'End If

            Dim Login As Object = 0
            Dim name As String = String.Empty

            If MyData.HasRows Then

                MyData.Read()

                Login = MyData("id")
                name = MyData("NameOfuser")
            End If

            If Login = Nothing Then

                MsgBox("Login is Failed...Try again !", MsgBoxStyle.Critical, "Login Denied")
                UserName.Text = ""
                Password.Text = ""
                UserName.Focus()
                Exit Sub
            End If

            User_Id = CInt(Login)

            'If UserType.Text = "User" Then
            '    frmMainMenu.DatabaseToolStripMenuItem.Enabled = False
            '    frmMainMenu.DataEntryToolStripMenuItem.Enabled = False
            '    frmMainMenu.ReportsToolStripMenuItem.Enabled = False
            '    frmMainMenu.SearchRecordsToolStripMenuItem.Enabled = False
            '    frmMainMenu.UsersToolStripMenuItem.Enabled = False
            '    frmMainMenu.TransactionToolStripMenuItem.Enabled = False
            '    frmMainMenu.GuestToolStripMenuItem1.Enabled = False
            '    frmMainMenu.ReservationToolStripMenuItem.Enabled = False
            '    frmMainMenu.CheckInToolStripMenuItem.Enabled = False
            '    frmMainMenu.CheckOutToolStripMenuItem.Enabled = False
            '    frmMainMenu.EmployeeToolStripMenuItem1.Enabled = False
            '    frmMainMenu.AttendanceToolStripMenuItem2.Enabled = False
            '    frmMainMenu.PaymentToolStripMenuItem1.Enabled = False
            '    frmMainMenu.AdvanceEntryToolStripMenuItem1.Enabled = False
            '    frmMainMenu.StockToolStripMenuItem1.Enabled = True
            '    frmMainMenu.OrderToolStripMenuItem.Enabled = True
            '    frmMainMenu.RoomsAvailabilityToolStripMenuItem.Enabled = False
            '    frmMainMenu.lblUser.Text = UserName.Text
            '    frmMainMenu.lblUserType.Text = UserType.Text
            '    ProgressBar1.Visible = True
            '    ProgressBar1.Maximum = 5000
            '    ProgressBar1.Minimum = 0
            '    ProgressBar1.Value = 4
            '    ProgressBar1.Step = 1
            '    For i = 0 To 5000
            '        ProgressBar1.PerformStep()
            '    Next
            '    Me.Hide()
            '    frmMainMenu.ShowDialog()
            'End If

            If (UserType.Text = "ผู้ดูแลระบบ") Or (UserType.Text = "ผู้บริหาร") Then
                frmMainMenu.UsersToolStripMenuItem.Visible = True
                frmMainMenu.DatabaseToolStripMenuItem.Visible = True
                frmMainMenu.TransactionToolStripMenuItem.Visible = True
                frmMainMenu.RoomsAvailabilityToolStripMenuItem.Visible = True

                frmMainMenu.ReservationToolStripMenuItem.Visible = True
                frmMainMenu.CheckInToolStripMenuItem.Visible = True
                frmMainMenu.PaymentToolStripMenuItem1.Visible = True

                frmMainMenu.lblUser.Text = name 'UserName.Text
                frmMainMenu.lblUserType.Text = UserType.Text
                ProgressBar1.Visible = True
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 4
                ProgressBar1.Step = 1
                For i = 0 To 5000
                    ProgressBar1.PerformStep()
                Next
                Me.Close()
                frmSeats.Timer1.Enabled = True
                frmMainMenu.ShowDialog()

            End If

            If (UserType.Text = "พนักงานขาย") Then
                frmMainMenu.UsersToolStripMenuItem.Visible = False
                frmMainMenu.DatabaseToolStripMenuItem.Visible = False
                frmMainMenu.TransactionToolStripMenuItem.Visible = True
                frmMainMenu.RoomsAvailabilityToolStripMenuItem.Visible = False

                frmMainMenu.ReservationToolStripMenuItem.Visible = True
                frmMainMenu.CheckInToolStripMenuItem.Visible = True
                frmMainMenu.PaymentToolStripMenuItem1.Visible = True

                frmMainMenu.lblUser.Text = name 'UserName.Text
                frmMainMenu.lblUserType.Text = UserType.Text
                ProgressBar1.Visible = True
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 4
                ProgressBar1.Step = 1
                For i = 0 To 5000
                    ProgressBar1.PerformStep()
                Next
                Me.Close()
                frmSeats.Timer1.Enabled = True
                frmMainMenu.ShowDialog()

            End If

            If (UserType.Text = "พนักงานบัญชี") Then
                frmMainMenu.UsersToolStripMenuItem.Visible = False
                frmMainMenu.DatabaseToolStripMenuItem.Visible = False
                frmMainMenu.TransactionToolStripMenuItem.Visible = False
                frmMainMenu.RoomsAvailabilityToolStripMenuItem.Visible = False

                frmMainMenu.ReservationToolStripMenuItem.Visible = False
                frmMainMenu.CheckInToolStripMenuItem.Visible = False
                frmMainMenu.PaymentToolStripMenuItem1.Visible = False


                frmMainMenu.lblUser.Text = name 'UserName.Text
                frmMainMenu.lblUserType.Text = UserType.Text
                ProgressBar1.Visible = True
                ProgressBar1.Maximum = 5000
                ProgressBar1.Minimum = 0
                ProgressBar1.Value = 4
                ProgressBar1.Step = 1
                For i = 0 To 5000
                    ProgressBar1.PerformStep()
                Next
                Me.Close()
                frmSeats.Timer1.Enabled = True
                frmMainMenu.ShowDialog()

            End If

            myCommand.Dispose()
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Me.Hide()
        frmChangePassword.ShowDialog()
        frmChangePassword.cmbUserType.SelectedIndex = -1
        frmChangePassword.UserName.Text = ""
        frmChangePassword.OldPassword.Text = ""
        frmChangePassword.NewPassword.Text = ""
        frmChangePassword.ConfirmPassword.Text = ""
        frmChangePassword.cmbUserType.Focus()
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        frmPasswordRecovery.ShowDialog()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If fullScreen Then
            LogoffComputer()
        End If
        End
    End Sub

    Private Sub frmLogin_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
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
End Class
