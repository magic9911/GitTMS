Imports MySql.Data.MySqlClient

Module ConnectionString


    Public Const EWX_LogOff = 0
    Public Const EWX_SHUTDOWN = 1
    Public Const EWX_REBOOT = 2
    Public Const EWX_FORCE = 4

    Public Declare Function ExitWindowsEx Lib "user32" (ByVal uFlags As Long, ByVal dwReserved As Long) As Long

    'Public Const cs As String = "Server=192.168.1.208;User Id=root;Password=1ca40a6114b928c6f5fabaebde2daeb6;Database=TMS"
    'Public Const cs As String = "Server=127.0.0.1;User Id=root;Password=1ca40a6114b928c6f5fabaebde2daeb6;Database=TMS"

    Public Const cs As String = "Server=127.0.0.1;User Id=appuser;Password=password;Database=tms"

    'Public Const cs As String = "Server=192.168.1.1;User Id=root;Password=lionking19;Database=ticket"
    'Public Const cs As String = "Server=192.168.1.1;User Id=root;Password=lionking19;Database=tms"

    Public fullScreen As Boolean = False
    Public ShowPrice As Boolean = False
    Public txtPrice As String = "CL"

    Public Seats_VIP_Val As Integer = 1000
    Public Seats_Main_Val As Integer = 0
    Public Seats_Normal_Val As Integer = 800

    Public S_VIP As Integer = 222
    Public S_Main As Integer = 0
    Public S_Normal As Integer = 243

    Public Mode_A(S_Normal) As Integer
    Public Mode_B(S_VIP) As Integer
    Public Mode_C(S_Main) As Integer

    Public User_Id As Integer = 0


    '****************************************************************
    Public Row_Name As String() = New String(11) {}
    Public Row_Name_V As String() = New String(11) {}

    Public Num_Seats As Integer() = New Integer(11) {}
    Public Num_Seats_V As Integer() = New Integer(11) {}

    Public VIP_Seats As String() = New String(11) {"VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VI", "VJ", "VK", "VL"}
    Public Normal_Seats As String() = New String(11) {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"}


    Public Sub msgError()
        frmSeats.Timer1.Enabled = False
        MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้", "ฐานข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End
    End Sub

    Public Sub seat_ini()
        For i As Integer = 0 To Row_Name.Length - 1
            Row_Name(i) = Chr(65 + i)

            If i < 9 Then
                Num_Seats(i) = 20
            Else
                Num_Seats(i) = 21
            End If
        Next

        For i As Integer = 0 To Row_Name_V.Length - 1
            Row_Name_V(i) = "V" & Chr(65 + i)
            If i Mod 2 = 0 Then
                Num_Seats_V(i) = 19
            Else
                Num_Seats_V(i) = 18
            End If
        Next
    End Sub

    Public Sub LogoffComputer()
        Call ExitWindowsEx(EWX_LogOff, &HFFFFFFFF)
    End Sub

    Public Function getTime(t As String) As String
        Dim tm As New DateTimePicker()
        tm.Value = t
        Return tm.Value.ToString("dd-MM-yyyy")
    End Function

    Public Function checkVIP(sName As String) As Boolean
        Dim zone As String = String.Empty
        Dim mytext As String = sName
        Dim myChars() As Char = mytext.ToCharArray()
        For Each ch As Char In myChars
            If Char.IsDigit(ch) = False Then
                zone += ch
            End If
        Next

        If Array.IndexOf(VIP_Seats, zone) >= 0 Then
            Return True

        Else
            Return False
        End If

    End Function

    Public Function blackupdb() As Boolean
        Try
            'Dim file As String = "C:\backup.sql"
            'Using conn As New MySqlConnection(cs)
            '    Using cmd As New MySqlCommand()
            '        Using mb As New MySqlBackup(cmd)
            '            cmd.Connection = conn
            '            conn.Open()
            '            mb.ExportToFile(file)
            '            conn.Close()
            '        End Using
            '    End Using
            'End Using


            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Sub PrintSeat(idshow As String, txtSeat As String)
        Try
            Dim txtDate As String = String.Empty
            Dim txtTime As String = String.Empty

            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError
            End Try

            Dim MyAdapter As New MySqlDataAdapter
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = "SELECT * from showtime Where id = '" & idshow & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            While (MyData.Read() = True)
                txtDate = MyData(2)
                txtTime = MyData(3)
            End While
            Conn.Close()

            Dim seatOne As String() = txtSeat.Split(",")
            Dim txt_Seat As String = String.Empty

            For i As Integer = 1 To seatOne.Length - 1

                If InStr(seatOne(i), "V") > 0 Then
                    txt_Seat = Mid(seatOne(i), 1, 2) & " " & Mid(seatOne(i), 3, 2)
                Else
                    Dim is_Seat As Integer = Val(Mid(seatOne(i), 2, 2))
                    If is_Seat <= 9 Then
                        txt_Seat = "L " & Mid(seatOne(i), 1, 1) & " " & Mid(seatOne(i), 2, 2)
                    Else
                        txt_Seat = "R " & Mid(seatOne(i), 1, 1) & " " & Mid(seatOne(i), 2, 2)
                    End If
                End If


                frmPrint.txtDate = txtDate
                frmPrint.txtTime = txtTime
                frmPrint.txtSeat = txt_Seat

                If ShowPrice = True Then
                    If InStr(seatOne(i), "V") > 0 Then
                        frmPrint.txtPrice = Seats_VIP_Val.ToString
                    Else
                        frmPrint.txtPrice = Seats_Normal_Val.ToString
                    End If
                Else
                    frmPrint.txtPrice = txtPrice
                End If

                PrintLog(idshow, txtDate, txtTime, seatOne(i), "")
                frmPrint.PrintNow()
                'frmPrint.Show()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub PrintLog(idshow As String, date_txt As String, time_txt As String, seat As String, Notes As String)
        Try
            Dim sTime As DateTimePicker = setTime(date_txt)
            'Dim myId As String = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
            Dim sql As String = "SELECT * from showtime Where id = '" & idshow & "'"

            If checkData(sql) = False Then
                MessageBox.Show("+++ error log save +++", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim dr As String = "INSERT INTO  print_seats(id,date,time,seat,note,id_print,time_print) VALUES(NULL,'" & _
sTime.Value.ToString("yyyy-MM-dd") & "','" & time_txt & "','" & seat & "','" & Notes & "','" & User_Id & "','" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "')"

            If AddData(dr) = False Then
                MessageBox.Show("+++ error log save +++", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function setTime(t As String) As DateTimePicker
        Dim res As DateTimePicker = New DateTimePicker()
        Dim tmp As String() = t.Split("-")
        If tmp.Length >= 3 Then
            Dim dd As Integer = tmp(0)
            Dim mm As Integer = tmp(1)
            Dim yy As Integer = tmp(2)
            res.Value = New DateTime(yy, mm, dd, 0, 0, 0)
        End If
        Return res

    End Function
    Public Function getMMName(mm As Integer) As String
        Dim res As String = String.Empty
        Select Case mm
            Case 1 : res = "มกราคม"
            Case 2 : res = "กุมภาพันธ์"
            Case 3 : res = "มีนาคม"
            Case 4 : res = "เมษายน"
            Case 5 : res = "พฤษาภาคม"
            Case 6 : res = "มิถุนายน"
            Case 7 : res = "กรกฎาคม"
            Case 8 : res = "สิงหาคม"
            Case 9 : res = "กันยายน"
            Case 10 : res = "ตุลาคม"
            Case 11 : res = "พฤศจิกายน"
            Case 12 : res = "ธันวาคม"
        End Select
        Return res
    End Function
    Public Function getSeatsName(index As Integer, z As String) As String
        Dim res As String = String.Empty
        Dim n As Integer = index
        If z = "A" Then
            Dim rw As Integer = n Mod 24
            Dim rs As Integer = CInt(n \ 24)
            Dim sTxt As String = String.Empty
            If rw = 0 Then
                rs -= 1
                rw = 24
            End If
            sTxt = Chr(65 + rs) & Format(rw, "00")
            res = sTxt
        End If

        If z = "B" Then
            Dim rw As Integer = 0
            Dim sTxt As String = String.Empty

            If (index >= 1) And (index <= 19) Then
                rw = n Mod 19
                If rw = 0 Then rw = 19
                sTxt = "VA" & Format(rw, "00")
            End If

            If (index >= 20) And (index <= 37) Then
                n -= 1
                rw = n Mod 18
                If rw = 0 Then rw = 18
                sTxt = "VB" & Format(rw, "00")
            End If

            If (index >= 38) And (index <= 56) Then
                n += 1
                rw = n Mod 19
                If rw = 0 Then rw = 19
                sTxt = "VC" & Format(rw, "00")
            End If

            If (index >= 57) And (index <= 74) Then
                n -= 2
                rw = n Mod 18
                If rw = 0 Then rw = 18
                sTxt = "VD" & Format(rw, "00")
            End If

            If (index >= 75) And (index <= 93) Then
                n += 2
                rw = n Mod 19
                If rw = 0 Then rw = 19
                sTxt = "VE" & Format(rw, "00")
            End If

            If (index >= 94) And (index <= 111) Then
                n -= 3
                rw = n Mod 18
                If rw = 0 Then rw = 18
                sTxt = "VF" & Format(rw, "00")
            End If

            res = sTxt

        End If

        If z = "C" Then
            Dim rw As Integer = 0
            Dim sTxt As String = String.Empty

            If (index >= 1) And (index <= 19) Then
                rw = n Mod 19
                If rw = 0 Then rw = 19
                sTxt = "L" & Format(rw, "00")
            End If

            If (index >= 20) And (index <= 37) Then
                n -= 1
                rw = n Mod 18
                If rw = 0 Then rw = 18
                sTxt = "M" & Format(rw, "00")
            End If

            If (index >= 38) And (index <= 56) Then
                n += 1
                rw = n Mod 19
                If rw = 0 Then rw = 19
                sTxt = "N" & Format(rw, "00")
            End If

            If (index >= 57) And (index <= 74) Then
                n -= 2
                rw = n Mod 18
                If rw = 0 Then rw = 18
                sTxt = "O" & Format(rw, "00")
            End If

            If (index >= 75) And (index <= 93) Then
                n += 2
                rw = n Mod 19
                If rw = 0 Then rw = 19
                sTxt = "P" & Format(rw, "00")
            End If

            res = sTxt

        End If

        Return res
    End Function

    Public Function checkData(sqlTxt As String) As Boolean
        Try
            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError
            End Try

            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlTxt
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            If MyData.HasRows Then
                Conn.Close()
                Return True
            End If
            Conn.Close()
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function DelData(sqlTxt As String) As Boolean
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
            mycommand.CommandText = sqlTxt
            mycommand.ExecuteNonQuery()
            Conn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function AddData(sqlTxt As String) As Boolean
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
            mycommand.CommandText = sqlTxt
            mycommand.ExecuteNonQuery()
            Conn.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function UpdateData(sqlTxt As String) As Integer
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
            mycommand.CommandText = sqlTxt
            Dim res As Integer = mycommand.ExecuteNonQuery()
            Conn.Close()
            Return res

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Public Function GetAllShow() As String
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
            mycommand.CommandText = "SELECT id from showtime"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            While (MyData.Read() = True)
                res += MyData(0) & ","
            End While
            Conn.Close()
            Return res
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function
    Public Function GetShowtime(idres As String, txt As String) As String
        Try
            Dim id As String = GetShowformRes(idres)
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
            mycommand.CommandText = "SELECT " & txt & " from showtime Where id = '" & id & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            If MyData.HasRows Then
                MyData.Read()
                Return MyData(txt)
            Else
                Return ""
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetShowformRes(id As String) As String
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
            mycommand.CommandText = "SELECT id_showtime from reservation Where id = '" & id & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            If MyData.HasRows Then
                MyData.Read()
                Return MyData("id_showtime")
            Else
                Return ""
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetIdformRes(id As String) As String
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
            mycommand.CommandText = "SELECT GuestID from reservation Where id = '" & id & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            If MyData.HasRows Then
                MyData.Read()
                Return MyData("GuestID")
            Else
                Return ""
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetGuestById(id As String) As String
        Try
            Dim idGuest As String = GetIdformRes(id)

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
            mycommand.CommandText = "SELECT GuestName from guest Where id = '" & idGuest & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            If MyData.HasRows Then
                MyData.Read()
                Return MyData("GuestName")
            Else
                Return ""
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetIdByName2(name As String) As String
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
            mycommand.CommandText = "SELECT id from guest Where GuestName = '" & name & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            If MyData.HasRows Then
                MyData.Read()
                Return MyData("id")
            Else
                Return "0"
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function getModeBySeats(seats As String, id_show As String) As String
        Try
            If seats <> "" Then
                Dim Conn As MySqlConnection
                Conn = New MySqlConnection
                Conn.ConnectionString = cs
                Try
                    Conn.Open()
                Catch myerror As MySqlException
                    MsgBox("Error connecting to Database getModeBySeats")
                End Try

                Dim seat As String() = seats.Split(",")
                Dim sqltxt As String = "SELECT mode from seats Where id_showtime = '" & id_show & "' And ("
                For i As Integer = 1 To seat.Length - 1
                    If i = 1 Then
                        sqltxt += "name = '" & seat(i) & "'"
                    Else
                        sqltxt += " Or name = '" & seat(i) & "'"
                    End If

                Next
                sqltxt += ")"

                Dim MyAdapter As New MySqlDataAdapter
                Dim mycommand As New MySqlCommand()
                mycommand.Connection = Conn
                mycommand.CommandText = sqltxt
                MyAdapter.SelectCommand = mycommand
                Dim MyData As MySqlDataReader
                MyData = mycommand.ExecuteReader
                Dim res As String = String.Empty

                Dim vip As Integer = 0
                Dim normal As Integer = 0

                While (MyData.Read() = True)
                    If MyData("mode") = 0 Then
                        vip += 1
                    End If
                    If MyData("mode") = 1 Then
                        normal += 1
                    End If
                End While

                Conn.Dispose()
                Conn.Close()

                Return vip.ToString & "," & normal.ToString
            Else
                Return Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error getModeBySeats", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function GetIdByName(name As String) As String
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
            mycommand.CommandText = "SELECT id from registration Where NameOfuser = '" & name & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            If MyData.HasRows Then
                MyData.Read()
                Return MyData("id")
            Else
                Return "0"
            End If
            Conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetAllGuestName() As String
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
            mycommand.CommandText = "SELECT GuestName from guest"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            While (MyData.Read() = True)
                res += MyData(0) & ","
            End While
            Conn.Close()
            Return res
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetOneRes(name As String) As String
        Try
            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim idName As String = GetIdByName2(name)

            Dim MyAdapter As New MySqlDataAdapter
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = "SELECT id from reservation Where GuestID = '" & idName & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            While (MyData.Read() = True)
                res += MyData(0) & ","
            End While
            Conn.Close()
            Return res
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetAllRes() As String
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
            mycommand.CommandText = "SELECT id from reservation"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            While (MyData.Read() = True)
                res += MyData(0) & ","
            End While
            Conn.Close()
            Return res
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetAllId() As String
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
            mycommand.CommandText = "SELECT NameOfuser from registration"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            Dim res As String = String.Empty
            While (MyData.Read() = True)
                res += MyData(0) & ","
            End While
            Conn.Close()
            Return res
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function GetData(tabel As String, sqlTxt As String) As String
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
            mycommand.CommandText = sqlTxt
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader

            If MyData.HasRows Then
                MyData.Read()
                Return MyData(tabel)
            End If

            Return String.Empty

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function Getid(sqlTxt As String) As String
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
            mycommand.CommandText = sqlTxt
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader

            If MyData.HasRows Then
                MyData.Read()
                Return MyData("id")
            End If

            Return "NULL"
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function GetStatusRev(idshow As String) As String
        Try
            Dim res As String = String.Empty
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
            mycommand.CommandText = "SELECT Status from reservation Where id = '" & idshow & "'"
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader
            While (MyData.Read() = True)
                res = MyData(0)
            End While
            Conn.Close()
            If res = "0" Then
                res = "รอชำระเงิน"
            Else
                res = "ยืนยัน"
            End If
            Return res
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    Public Function SetStatusSeat(g_id As String, idshow As String, seat As String, status As String, txtAnd As String) As Integer
        If InStr(seat, ",") > 0 Then
            Dim tmpList As String() = seat.Split(",")

            Dim sql As String = "UPDATE seats SET status = '" & status & "',GuestID = '" & g_id & _
            "',id_update = '" & User_Id & "',time_update = '" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "' WHERE name ='" & tmpList(1) & "' And id_showtime = '" & idshow & "'"
            If txtAnd <> "" Then
                sql += " And " & txtAnd
            End If
            sql += ";"
            For i As Integer = 2 To tmpList.Length - 1
                sql += "UPDATE seats SET status = '" & status & "',GuestID = '" & g_id & _
                    "',id_update = '" & User_Id & "',time_update = '" & System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", New System.Globalization.CultureInfo("en-US")) & "' WHERE name ='" & tmpList(i) & "' And id_showtime = '" & idshow & "'"
                If txtAnd <> "" Then
                    sql += " And " & txtAnd
                End If
                sql += ";"
            Next

            Return UpdateData(sql)
        End If
        Return 0
    End Function
End Module
