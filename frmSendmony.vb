Imports System.Data.OleDb
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports MySql.Data.MySqlClient

Public Class frmSendmony
    Public datesend As String = String.Empty
    Public namesend As String = String.Empty
    Public vipsend As Integer = 0
    Public norsend As Integer = 0
    Public vipsum As Integer = 0
    Public norsum As Integer = 0
    Public sumall As Integer = 0

    Public Sub process(name As String)
        Try
            ' Dim userid As String = Getidbyname(name)

            Dim addNo As Boolean = False

            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim MyAdapter As New MySqlDataAdapter

            Dim sqlquery = "SELECT * from view_sale WHERE NameOfuser = '" & name & "' And time_update LIKE '" & Now.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "%' order by time_update"
            Dim mycommand As New MySqlCommand()

            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim vip As Integer = 0
            Dim normal As Integer = 0

            While (MyData.Read() = True)
                If MyData(4) = 2 Then
                    Select Case MyData(5)
                        Case 0 : normal += 1
                        Case 1 : vip += 1
                    End Select
                End If
            End While

            Dim sum As Integer = (vip * Seats_VIP_Val) + (normal * Seats_Normal_Val)

            datesend = Now.ToString("dd-MM-yyyy")
            namesend = name
            vipsend = vip
            norsend = normal
            vipsum = (vip * Seats_VIP_Val)
            norsum = (normal * Seats_Normal_Val)
            sumall = sum

            Conn.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmSendmony_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSendmony_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            'Timer1.Enabled = True
            Dim rpt As New rptsendmony() 'The report you created.
            'Dim myConnection As oledbConnection
            'Dim MyCommand As New oledbCommand()
            'Dim myDA As New oledbDataAdapter()
            'Dim myDS As New AttendanceDBDataSet 'The DataSet you created.
            'myConnection = New OleDbConnection(cs)
            'MyCommand.Connection = myConnection
            'MyCommand.CommandText = "SELECT EA.AttendanceID, EA.WorkingDate, EA.EmployeeID, EA.BasicWorkingTime, EA.Status, EA.InTime, EA.OutTime, EA.Overtime, ER.EmployeeID AS Expr1,ER.EmployeeName, ER.Address, ER.MobileNo, ER.Email, ER.Bloodgroup, ER.Department, ER.Designation, ER.DateOfJoining, ER.Salary,ER.BasicWorkingTime AS Expr2 FROM (EmployeeAttendance EA INNER JOIN EmployeeRegistration ER ON EA.EmployeeID = ER.EmployeeID) where WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "#  and Status = 'P'  order by ER.EmployeeName"
            'MyCommand.CommandType = CommandType.Text
            'myDA.SelectCommand = MyCommand
            'myDA.Fill(myDS, "EmployeeAttendance")
            'myDA.Fill(myDS, "EmployeeRegistration")
            'rpt.SetDataSource(myDS)
            'con = New OleDbConnection(cs)
            'con.Open()
            'cmd = New OleDbCommand("select count(EmployeeID) from employeeattendance where WorkingDate between #" & DateFrom.Text & "# And #" & DateTo.Text & "#  group by EmployeeID ", con)
            'rdr = cmd.ExecuteReader()

            'If (rdr.Read()) Then

            '    Label1.Text = rdr.GetValue(0).ToString()
            'End If
            'If ((rdr Is Nothing)) Then

            '    rdr.Close()
            'End If
            'If (con.State = ConnectionState.Open) Then

            '    con.Close()
            'End If

            rpt.SetParameterValue("variable", datesend)
            rpt.SetParameterValue("variable1", namesend)
            rpt.SetParameterValue("variable2", vipsend)
            rpt.SetParameterValue("variable3", norsend)
            rpt.SetParameterValue("variable4", vipsum)
            rpt.SetParameterValue("variable5", norsum)
            rpt.SetParameterValue("variable6", sumall)

            CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class