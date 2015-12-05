Imports MySql.Data.MySqlClient

Public Class frmSeats
    Public Seats_Zone_A(S_Normal) As Boolean
    Public Seats_Zone_B(S_VIP) As Boolean
    Public Seats_Zone_C(S_Main) As Boolean

    Public Status_A(S_Normal) As Integer
    Public Status_B(S_VIP) As Integer
    Public Status_C(S_Main) As Integer


    Public Seats_VIP_Count As Integer = 0
    Public Seats_Main_Count As Integer = 0
    Public Seats_Normal_Count As Integer = 0

    Public date_txt As String
    Public time_txt As String
    Public idShow As String
    Public id_guest As String

    Public Seats_Status As String = "0"
    Public Seats_Txt As String = "จำหน่าย"
    Public Seats_Tmp As String = String.Empty

    Public id_rev As String = String.Empty
    Public button_name As String = String.Empty

    Public Sub Refresh_Seats_one(txtseats As Object)
        Try

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
            'idShow = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
            Dim sqlTxt As String = "SELECT * FROM seats where name = '" & txtseats & "'"
            mycommand.Connection = Conn
            mycommand.CommandText = sqlTxt
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader()

            Dim seats_name As String = String.Empty
            Dim seats_zone As String = String.Empty
            Dim seats_status As String = String.Empty

            While MyData.Read()
                seats_name = MyData.GetString("name")
                seats_zone = MyData.GetString("zone")
                seats_status = MyData.GetString("status")
            End While

            Conn.Close()

            For Each seats As Object In Me.Panel1.Controls
                If txtseats = seats.Name Then
                    Dim sName As String = seats.Name
                    Dim sTag As String = seats.Tag
                    sTag = seats_status

                    If checkVIP(sName) Then
                        Select Case sTag
                            Case 0
                                seats.Image = SB_0.Image
                            Case 1
                                seats.Image = SB_1.Image
                            Case 2
                                seats.Image = SB_2.Image
                            Case 4
                                seats.Image = SB_3.Image
                        End Select
                    Else
                        Select Case sTag
                            Case 0
                                seats.Image = SA_0.Image
                            Case 1
                                seats.Image = SA_1.Image
                            Case 2
                                seats.Image = SA_2.Image
                            Case 4
                                seats.Image = SA_3.Image
                        End Select
                    End If
                    seats.Tag = sTag
                End If
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Timer1.Enabled = False
        End Try
    End Sub

    Public Sub Refresh_Seats_Chack()
        Try
            'listSeats.Text = ""

            'N_Val.Text = "0"
            'N_Count.Text = "x 0"
            'Seats_Normal_Count = 0

            'V_Val.Text = "0"
            'V_Count.Text = "x 0"
            'Seats_VIP_Count = 0
            'lb_Sum.Text = "0"

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
            'idShow = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
            Dim sqlTxt As String = "SELECT * FROM seats where id_showtime = '" & idShow & "'"
            mycommand.Connection = Conn
            mycommand.CommandText = sqlTxt
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader()

            Dim seats_name As String = String.Empty
            Dim seats_zone As String = String.Empty
            Dim seats_status As String = String.Empty

            While MyData.Read()
                seats_name += "," & MyData.GetString("name")
                seats_zone += "," & MyData.GetString("zone")
                seats_status += "," & MyData.GetString("status")
            End While

            Conn.Close()

            Dim seats_name_Array As String() = seats_name.Split(",")
            Dim seats_zone_Array As String() = seats_zone.Split(",")
            Dim seats_status_Array As String() = seats_status.Split(",")

            For Each seats As Object In Me.Panel1.Controls
                Dim sName As String = seats.Name
                Dim sTag As String = seats.Tag
                If sTag <> "3" Then
                    Dim index As Integer = Array.IndexOf(seats_name_Array, sName)

                    If index >= 0 Then
                        sTag = seats_status_Array(index)

                        If checkVIP(sName) Then
                            Select Case sTag
                                Case 0
                                    seats.Image = SB_0.Image
                                Case 1
                                    seats.Image = SB_1.Image
                                Case 2
                                    seats.Image = SB_2.Image
                                Case 4
                                    seats.Image = SB_3.Image
                            End Select
                        Else
                            Select Case sTag
                                Case 0
                                    seats.Image = SA_0.Image
                                Case 1
                                    seats.Image = SA_1.Image
                                Case 2
                                    seats.Image = SA_2.Image
                                Case 4
                                    seats.Image = SA_3.Image
                            End Select
                        End If
                        seats.Tag = sTag
                    End If
                End If
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Timer1.Enabled = False
        End Try
    End Sub

    Public Sub Refresh_Seats()
        Try

            listSeats.Text = ""

            N_Val.Text = "0"
            N_Count.Text = "x 0"
            Seats_Normal_Count = 0

            V_Val.Text = "0"
            V_Count.Text = "x 0"
            Seats_VIP_Count = 0
            lb_Sum.Text = "0"

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
            'idShow = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
            Dim sqlTxt As String = "SELECT * FROM seats where id_showtime = '" & idShow & "'"
            mycommand.Connection = Conn
            mycommand.CommandText = sqlTxt
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader()

            Dim seats_name As String = String.Empty
            Dim seats_zone As String = String.Empty
            Dim seats_status As String = String.Empty

            While MyData.Read()
                seats_name += "," & MyData.GetString("name")
                seats_zone += "," & MyData.GetString("zone")
                seats_status += "," & MyData.GetString("status")
            End While

            Conn.Close()

            Dim seats_name_Array As String() = seats_name.Split(",")
            Dim seats_zone_Array As String() = seats_zone.Split(",")
            Dim seats_status_Array As String() = seats_status.Split(",")

            For Each seats As Object In Me.Panel1.Controls
                Dim sName As String = seats.Name
                Dim sTag As String = seats.Tag
                Dim index As Integer = Array.IndexOf(seats_name_Array, sName)

                If index >= 0 Then
                    sTag = seats_status_Array(index)

                    If checkVIP(sName) Then
                        Select Case sTag
                            Case 0
                                seats.Image = SB_0.Image
                            Case 1
                                seats.Image = SB_1.Image
                            Case 2
                                seats.Image = SB_2.Image
                            Case 4
                                seats.Image = SB_3.Image
                        End Select
                    Else
                        Select Case sTag
                            Case 0
                                seats.Image = SA_0.Image
                            Case 1
                                seats.Image = SA_1.Image
                            Case 2
                                seats.Image = SA_2.Image
                            Case 4
                                seats.Image = SA_3.Image
                        End Select
                    End If
                    seats.Tag = sTag
                End If
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Timer1.Enabled = False
        End Try
    End Sub

    Public Sub Seats_ReChack(txtRecheck As String)
        'Try

        'Catch ex As Exception
        '    Dim aa As String = ex.StackTrace
        'End Try

        Try
            Dim reCheck_array As String() = txtRecheck.Split(",")
            listSeats.Text = txtRecheck

            Seats_Normal_Count = 0

            Seats_VIP_Count = 0

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
            'idShow = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
            Dim sqlTxt As String = "SELECT * FROM seats where id_showtime = '" & idShow & "'"
            mycommand.Connection = Conn
            mycommand.CommandText = sqlTxt
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader()

            Dim seats_name As String = String.Empty
            Dim seats_zone As String = String.Empty
            Dim seats_status As String = String.Empty

            While MyData.Read()
                seats_name += "," & MyData.GetString("name")
                seats_zone += "," & MyData.GetString("zone")
                seats_status += "," & MyData.GetString("status")
            End While

            Conn.Close()

            Dim seats_name_Array As String() = seats_name.Split(",")
            Dim seats_zone_Array As String() = seats_zone.Split(",")
            Dim seats_status_Array As String() = seats_status.Split(",")

            For Each seats As Object In Me.Panel1.Controls
                Dim sName As String = seats.Name
                Dim sTag As String = seats.Tag
                Dim index As Integer = Array.IndexOf(seats_name_Array, sName)

                If index >= 0 Then
                    sTag = seats_status_Array(index)

                    If Array.IndexOf(reCheck_array, sName) >= 0 Then
                        sTag = 3
                    End If

                    If checkVIP(sName) Then
                        Select Case sTag
                            Case 0
                                seats.Image = SB_0.Image
                            Case 1
                                seats.Image = SB_1.Image
                            Case 2
                                seats.Image = SB_2.Image
                            Case 3
                                seats.Image = PicCheck3.Image
                                Seats_VIP_Count += 1
                                V_Count.Text = "x " & Seats_VIP_Count.ToString
                                V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
                            Case 4
                                seats.Image = SB_3.Image
                        End Select
                    Else
                        Select Case sTag
                            Case 0
                                seats.Image = SA_0.Image
                            Case 1
                                seats.Image = SA_1.Image
                            Case 2
                                seats.Image = SA_2.Image
                            Case 3
                                seats.Image = PicCheck1.Image
                                Seats_Normal_Count += 1
                                N_Count.Text = "x " & Seats_Normal_Count.ToString
                                N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
                            Case 4
                                seats.Image = SA_3.Image
                        End Select
                    End If
                    seats.Tag = sTag
                End If
            Next

            lb_Sum.Text = (Val(N_Val.Text) + Val(V_Val.Text)).ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Public Sub Refresh_Seats_Check(seat As String)
    '    Try
    '        ReDim Seats_Zone_A(S_Normal)
    '        ReDim Seats_Zone_B(S_VIP)
    '        ReDim Seats_Zone_C(S_Main)

    '        listSeats.Text = seat

    '        N_Val.Text = "0"
    '        N_Count.Text = "x 0"
    '        Seats_Normal_Count = 0

    '        V_Val.Text = "0"
    '        V_Count.Text = "x 0"
    '        Seats_VIP_Count = 0
    '        lb_Sum.Text = "0"

    '        Dim Conn As MySqlConnection
    '        Conn = New MySqlConnection
    '        Conn.ConnectionString = cs
    '        Try
    '            Conn.Open()
    '        Catch myerror As MySqlException
    '            MsgBox("Error connecting to Database")
    '        End Try

    '        Dim MyAdapter As New MySqlDataAdapter
    '        Dim mycommand As New MySqlCommand()
    '        'idShow = Getid("SELECT * FROM showtime where date_time = '" & date_txt & "' and time = '" & time_txt & "'")
    '        Dim sqlTxt As String = "SELECT * FROM seats where id_showtime = '" & idShow & "'"
    '        mycommand.Connection = Conn
    '        mycommand.CommandText = sqlTxt
    '        MyAdapter.SelectCommand = mycommand
    '        Dim MyData As MySqlDataReader
    '        MyData = mycommand.ExecuteReader()

    '        While MyData.Read()
    '            Dim zone As String = MyData.GetChar("zone")
    '            Dim taq As Integer = MyData.GetInt32("taq")
    '            Dim status As Integer = MyData.GetInt32("status")
    '            Dim sName As String = MyData.GetString("name")
    '            If checker(seat, sName) = False Then
    '                Select Case zone
    '                    Case "A"
    '                        Status_A(taq) = status
    '                    Case "B"
    '                        Status_B(taq) = status
    '                    Case "C"
    '                        Status_C(taq) = status
    '                End Select
    '            Else
    '                Select Case zone
    '                    Case "A"
    '                        Status_A(taq) = 3
    '                        Seats_Zone_A(taq) = True

    '                        Select Case Mode_A(taq)
    '                            Case 0
    '                                Seats_Normal_Count += 1
    '                                N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                                N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
    '                            Case 1
    '                                Seats_VIP_Count += 1
    '                                V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                                V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                        End Select

    '                    Case "B"
    '                        Status_B(taq) = 3
    '                        Seats_Zone_B(taq) = True

    '                        Select Case Mode_B(taq)
    '                            Case 0
    '                                Seats_Normal_Count += 1
    '                                N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                                N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
    '                            Case 1
    '                                Seats_VIP_Count += 1
    '                                V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                                V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                        End Select

    '                    Case "C"
    '                        Status_C(taq) = 3
    '                        Seats_Zone_C(taq) = True

    '                        Select Case Mode_C(taq)
    '                            Case 0
    '                                Seats_Normal_Count += 1
    '                                N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                                N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
    '                            Case 1
    '                                Seats_VIP_Count += 1
    '                                V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                                V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                        End Select

    '                End Select
    '            End If
    '        End While

    '        For Each seats As Object In Panel1.Controls
    '            Dim N1 As String = Mid(seats.Name, 1, 1)
    '            Dim N2 As String = Mid(seats.Name, 1, 2)

    '            If (N1 = "A") Or (N1 = "B") Or (N1 = "C") Or (N1 = "D") Or (N1 = "E") Or (N1 = "F") Or _
    '                (N1 = "G") Or (N1 = "H") Or (N1 = "I") Or (N1 = "J") Or (N1 = "K") Then
    '                Select Case Status_A(seats.Tag)
    '                    Case 0
    '                        Select Case Mode_A(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_0.Image
    '                            Case 1
    '                                seats.Image = SB_0.Image
    '                        End Select
    '                    Case 1
    '                        Select Case Mode_A(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_1.Image
    '                            Case 1
    '                                seats.Image = SB_1.Image
    '                        End Select
    '                    Case 2
    '                        Select Case Mode_A(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_2.Image
    '                            Case 1
    '                                seats.Image = SB_2.Image
    '                        End Select
    '                    Case 3
    '                        Select Case Mode_A(seats.Tag)
    '                            Case 0
    '                                seats.Image = PicCheck1.Image
    '                            Case 1
    '                                seats.Image = PicCheck3.Image
    '                        End Select
    '                End Select
    '            End If

    '            If (N2 = "VA") Or (N2 = "VB") Or (N2 = "VC") Or (N2 = "VD") Or (N2 = "VE") Or (N2 = "VF") Then
    '                Select Case Status_B(seats.Tag)
    '                    Case 0
    '                        Select Case Mode_B(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_0.Image
    '                            Case 1
    '                                seats.Image = SB_0.Image
    '                        End Select
    '                    Case 1
    '                        Select Case Mode_B(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_1.Image
    '                            Case 1
    '                                seats.Image = SB_1.Image
    '                        End Select
    '                    Case 2
    '                        Select Case Mode_B(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_2.Image
    '                            Case 1
    '                                seats.Image = SB_2.Image
    '                        End Select
    '                    Case 3
    '                        Select Case Mode_B(seats.Tag)
    '                            Case 0
    '                                seats.Image = PicCheck1.Image
    '                            Case 1
    '                                seats.Image = PicCheck3.Image
    '                        End Select
    '                End Select
    '            End If

    '            If (N1 = "L") Or (N1 = "M") Or (N1 = "N") Or (N1 = "O") Or (N1 = "P") Then
    '                Select Case Status_C(seats.Tag)
    '                    Case 0
    '                        Select Case Mode_C(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_0.Image
    '                            Case 1
    '                                seats.Image = SB_0.Image
    '                        End Select
    '                    Case 1
    '                        Select Case Mode_C(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_1.Image
    '                            Case 1
    '                                seats.Image = SB_1.Image
    '                        End Select
    '                    Case 2
    '                        Select Case Mode_C(seats.Tag)
    '                            Case 0
    '                                seats.Image = SA_2.Image
    '                            Case 1
    '                                seats.Image = SB_2.Image
    '                        End Select
    '                    Case 3
    '                        Select Case Mode_C(seats.Tag)
    '                            Case 0
    '                                seats.Image = PicCheck1.Image
    '                            Case 1
    '                                seats.Image = PicCheck3.Image
    '                        End Select
    '                End Select
    '            End If
    '        Next


    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    'Public Function checker(seat_array As String, seat As String) As Boolean
    '    Dim seat_tmp As String() = seat_array.Split(",")
    '    For Each stxt As String In seat_tmp
    '        If stxt = seat Then Return True
    '    Next
    '    Return False
    'End Function
    Public Sub Seats_SetColor(sender As Object)
        Try
            Dim id_guest As String = String.Empty
            Dim name_guest As String = String.Empty
            Dim Seats_txt As String = String.Empty
            Dim Seats_arr As String()
            Dim sqlTxt As String = "SELECT * FROM seats where name = '" & sender.name & "' And id_showtime = '" & idShow & "'"

            id_guest = GetData("GuestID", sqlTxt)

            id_rev = String.Empty
            button_name = sender.name

            If id_guest <> String.Empty Then
                name_guest = GetData("GuestName", "SELECT * FROM guest where id = '" & id_guest & "'")
                ContextMenuStrip1.Items(0).Text = "<" & name_guest & ">"
                sqlTxt = "SELECT * FROM reservation where GuestID = '" & id_guest & "' And id_showtime = '" & idShow & "'"
                Seats_txt = GetData("SeatNo", sqlTxt)
                id_rev = GetData("id", sqlTxt)

                If Seats_txt <> String.Empty Then
                    Seats_arr = Seats_txt.Split(",")
                    For Each seats As Object In Me.Panel1.Controls
                        Dim index As Integer = Array.IndexOf(Seats_arr, seats.name)

                        If index >= 0 Then
                            seats.BackColor = Color.Fuchsia
                        Else
                            seats.BackColor = Color.Transparent
                        End If

                    Next
                Else
                    Seats_ReColorr()
                    sender.BackColor = Color.Fuchsia
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Seats_ReColorr()
        Try
            For Each seats As Object In Me.Panel1.Controls
                seats.BackColor = Color.Transparent
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Zone_A_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) _
Handles A01.Click, A02.Click, A03.Click, A04.Click, A05.Click, A06.Click, A07.Click, A08.Click, A09.Click, A10.Click, A11.Click, A12.Click, _
        A13.Click, A14.Click, A15.Click, A16.Click, A17.Click, A18.Click, A19.Click, A20.Click, _
        B01.Click, B02.Click, B03.Click, B04.Click, B05.Click, B06.Click, B07.Click, B08.Click, B09.Click, B10.Click, B11.Click, B12.Click, _
        B13.Click, B14.Click, B15.Click, B16.Click, B17.Click, B18.Click, B19.Click, B20.Click, _
        C01.Click, C02.Click, C03.Click, C04.Click, C05.Click, C06.Click, C07.Click, C08.Click, C09.Click, C10.Click, C11.Click, C12.Click, _
        C13.Click, C14.Click, C15.Click, C16.Click, C17.Click, C18.Click, C19.Click, C20.Click, _
        D01.Click, D02.Click, D03.Click, D04.Click, D05.Click, D06.Click, D07.Click, D08.Click, D09.Click, D10.Click, D11.Click, D12.Click, _
        D13.Click, D14.Click, D15.Click, D16.Click, D17.Click, D18.Click, D19.Click, D20.Click, _
        E01.Click, E02.Click, E03.Click, E04.Click, E05.Click, E06.Click, E07.Click, E08.Click, E09.Click, E10.Click, E11.Click, E12.Click, _
        E13.Click, E14.Click, E15.Click, E16.Click, E17.Click, E18.Click, E19.Click, E20.Click, _
        F01.Click, F02.Click, F03.Click, F04.Click, F05.Click, F06.Click, F07.Click, F08.Click, F09.Click, F10.Click, F11.Click, F12.Click, _
        F13.Click, F14.Click, F15.Click, F16.Click, F17.Click, F18.Click, F19.Click, F20.Click, _
        G01.Click, G02.Click, G03.Click, G04.Click, G05.Click, G06.Click, G07.Click, G08.Click, G09.Click, G10.Click, G11.Click, G12.Click, _
        G13.Click, G14.Click, G15.Click, G16.Click, G17.Click, G18.Click, G19.Click, G20.Click, _
        H01.Click, H02.Click, H03.Click, H04.Click, H05.Click, H06.Click, H07.Click, H08.Click, H09.Click, H10.Click, H11.Click, H12.Click, _
        H13.Click, H14.Click, H15.Click, H16.Click, H17.Click, H18.Click, H19.Click, H20.Click, _
        I01.Click, I02.Click, I03.Click, I04.Click, I05.Click, I06.Click, I07.Click, I08.Click, I09.Click, I10.Click, I11.Click, I12.Click, _
        I13.Click, I14.Click, I15.Click, I16.Click, I17.Click, I18.Click, I19.Click, I20.Click, _
        J01.Click, J02.Click, J03.Click, J04.Click, J05.Click, J06.Click, J07.Click, J08.Click, J09.Click, J10.Click, J11.Click, J12.Click, _
        J13.Click, J14.Click, J15.Click, J16.Click, J17.Click, J18.Click, J19.Click, J20.Click, J21.Click, _
        K01.Click, K02.Click, K03.Click, K04.Click, K05.Click, K06.Click, K07.Click, K08.Click, K09.Click, K10.Click, K11.Click, K12.Click, _
        K13.Click, K14.Click, K15.Click, K16.Click, K17.Click, K18.Click, K19.Click, K20.Click, K21.Click, _
        L01.Click, L02.Click, L03.Click, L04.Click, L05.Click, L06.Click, L07.Click, L08.Click, L09.Click, L10.Click, L11.Click, L12.Click, _
        L13.Click, L14.Click, L15.Click, L16.Click, L17.Click, L18.Click, L19.Click, L20.Click, L21.Click, _
        VA01.Click, VA02.Click, VA03.Click, VA04.Click, VA05.Click, VA06.Click, VA07.Click, VA08.Click, VA09.Click, _
        VA10.Click, VA11.Click, VA12.Click, VA13.Click, VA14.Click, VA15.Click, VA16.Click, VA17.Click, VA18.Click, VA19.Click, _
        VB01.Click, VB02.Click, VB03.Click, VB04.Click, VB05.Click, VB06.Click, VB07.Click, VB08.Click, VB09.Click, _
        VB10.Click, VB11.Click, VB12.Click, VB13.Click, VB14.Click, VB15.Click, VB16.Click, VB17.Click, VB18.Click, _
        VC01.Click, VC02.Click, VC03.Click, VC04.Click, VC05.Click, VC06.Click, VC07.Click, VC08.Click, VC09.Click, _
        VC10.Click, VC11.Click, VC12.Click, VC13.Click, VC14.Click, VC15.Click, VC16.Click, VC17.Click, VC18.Click, VC19.Click, _
        VD01.Click, VD02.Click, VD03.Click, VD04.Click, VD05.Click, VD06.Click, VD07.Click, VD08.Click, VD09.Click, _
        VD10.Click, VD11.Click, VD12.Click, VD13.Click, VD14.Click, VD15.Click, VD16.Click, VD17.Click, VD18.Click, _
        VE01.Click, VE02.Click, VE03.Click, VE04.Click, VE05.Click, VE06.Click, VE07.Click, VE08.Click, VE09.Click, _
        VE10.Click, VE11.Click, VE12.Click, VE13.Click, VE14.Click, VE15.Click, VE16.Click, VE17.Click, VE18.Click, VE19.Click, _
        VF01.Click, VF02.Click, VF03.Click, VF04.Click, VF05.Click, VF06.Click, VF07.Click, VF08.Click, VF09.Click, _
        VF10.Click, VF11.Click, VF12.Click, VF13.Click, VF14.Click, VF15.Click, VF16.Click, VF17.Click, VF18.Click, _
        VG01.Click, VG02.Click, VG03.Click, VG04.Click, VG05.Click, VG06.Click, VG07.Click, VG08.Click, VG09.Click, _
        VG10.Click, VG11.Click, VG12.Click, VG13.Click, VG14.Click, VG15.Click, VG16.Click, VG17.Click, VG18.Click, VG19.Click, _
        VH01.Click, VH02.Click, VH03.Click, VH04.Click, VH05.Click, VH06.Click, VH07.Click, VH08.Click, VH09.Click, _
        VH10.Click, VH11.Click, VH12.Click, VH13.Click, VH14.Click, VH15.Click, VH16.Click, VH17.Click, VH18.Click, _
        VI01.Click, VI02.Click, VI03.Click, VI04.Click, VI05.Click, VI06.Click, VI07.Click, VI08.Click, VI09.Click, _
        VI10.Click, VI11.Click, VI12.Click, VI13.Click, VI14.Click, VI15.Click, VI16.Click, VI17.Click, VI18.Click, VI19.Click, _
        VJ01.Click, VJ02.Click, VJ03.Click, VJ04.Click, VJ05.Click, VJ06.Click, VJ07.Click, VJ08.Click, VJ09.Click, _
        VJ10.Click, VJ11.Click, VJ12.Click, VJ13.Click, VJ14.Click, VJ15.Click, VJ16.Click, VJ17.Click, VJ18.Click, _
        VK01.Click, VK02.Click, VK03.Click, VK04.Click, VK05.Click, VK06.Click, VK07.Click, VK08.Click, VK09.Click, _
        VK10.Click, VK11.Click, VK12.Click, VK13.Click, VK14.Click, VK15.Click, VK16.Click, VK17.Click, VK18.Click, VK19.Click, _
        VL01.Click, VL02.Click, VL03.Click, VL04.Click, VL05.Click, VL06.Click, VL07.Click, VL08.Click, VL09.Click, _
        VL10.Click, VL11.Click, VL12.Click, VL13.Click, VL14.Click, VL15.Click, VL16.Click, VL17.Click, VL18.Click

        If e.Button = MouseButtons.Right Then
            If sender.Tag <> 0 And sender.Tag <> 3 Then
                'Seats_ReColorr()
                Seats_SetColor(sender)
                'sender.BackColor = Color.Fuchsia
                sender.ContextMenuStrip = ContextMenuStrip1
                sender.ContextMenuStrip.Show(sender, New Point(e.X, e.Y))
                sender.ContextMenuStrip = Nothing
            End If

            Exit Sub
        End If

        Seats_ReColorr()

        If sender.Tag = 0 Or sender.Tag = 3 Then
            If sender.Tag = 0 Then
                sender.Tag = 3
                If SetStatusSeat("0", idShow, "," & sender.Name, "1", "status = '0'") > 0 Then
                    If checkVIP(sender.Name) Then
                        sender.Image = PicCheck3.Image
                        listSeats.Text += "," & sender.Name
                        Seats_VIP_Count += 1
                        V_Count.Text = "x " & Seats_VIP_Count.ToString
                        V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
                    Else
                        sender.Image = PicCheck1.Image
                        listSeats.Text += "," & sender.Name
                        Seats_Normal_Count += 1
                        N_Count.Text = "x " & Seats_Normal_Count.ToString
                        N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
                    End If
                Else
                    MessageBox.Show("ไม่สามารถเลือกที่นั่งดังกล่าวได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Refresh_Seats_one(sender.Name)
                    Exit Sub
                End If
            ElseIf sender.Tag = 3 Then
                sender.Tag = 0
                Dim tmpList As String() = listSeats.Text.Split(",")
                Dim txtList As String = String.Empty
                Dim rs As String = sender.Name
                Dim index As Integer = 0
                'sql = "UPDATE seats SET status = '0' WHERE name ='" & sender.Name & "' And id_showtime = '" & idShow & "';"
                If SetStatusSeat("0", idShow, "," & sender.Name, "0", "") > 0 Then
                    For i As Integer = 1 To tmpList.Length - 1
                        If tmpList(i) = rs Then
                            index = i
                        Else
                            txtList += "," & tmpList(i)
                        End If
                    Next

                    If checkVIP(sender.Name) Then
                        Seats_VIP_Count -= 1
                        V_Count.Text = "x " & Seats_VIP_Count.ToString
                        V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
                        listSeats.Text = txtList
                        sender.Image = PicUnCheck3.Image
                    Else
                        Seats_Normal_Count -= 1
                        N_Count.Text = "x " & Seats_Normal_Count.ToString
                        N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
                        listSeats.Text = txtList
                        sender.Image = PicUnCheck1.Image
                    End If

                Else
                    MessageBox.Show("ไม่สามารถยกที่นั่ง [" & rs & "] ได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Refresh_Seats_Chack()
                    Exit Sub
                End If
            End If
        End If

        lb_Sum.Text = (Val(N_Val.Text) + Val(M_Val.Text) + Val(V_Val.Text)).ToString

    End Sub


    '    Private Sub Zone_B_Click(sender As Object, e As EventArgs) _
    'Handles VA01.Click, VA02.Click, VA03.Click, VA04.Click, VA05.Click, VA06.Click, VA07.Click, VA08.Click, VA09.Click, _
    '        VA10.Click, VA11.Click, VA12.Click, VA13.Click, VA14.Click, VA15.Click, VA16.Click, VA17.Click, VA18.Click, VA19.Click, _
    '        VB01.Click, VB02.Click, VB03.Click, VB04.Click, VB05.Click, VB06.Click, VB07.Click, VB08.Click, VB09.Click, _
    '        VB10.Click, VB11.Click, VB12.Click, VB13.Click, VB14.Click, VB15.Click, VB16.Click, VB17.Click, VB18.Click, _
    '        VC01.Click, VC02.Click, VC03.Click, VC04.Click, VC05.Click, VC06.Click, VC07.Click, VC08.Click, VC09.Click, _
    '        VC10.Click, VC11.Click, VC12.Click, VC13.Click, VC14.Click, VC15.Click, VC16.Click, VC17.Click, VC18.Click, VC19.Click, _
    '        VD01.Click, VD02.Click, VD03.Click, VD04.Click, VD05.Click, VD06.Click, VD07.Click, VD08.Click, VD09.Click, _
    '        VD10.Click, VD11.Click, VD12.Click, VD13.Click, VD14.Click, VD15.Click, VD16.Click, VD17.Click, VD18.Click, _
    '        VE01.Click, VE02.Click, VE03.Click, VE04.Click, VE05.Click, VE06.Click, VE07.Click, VE08.Click, VE09.Click, _
    '        VE10.Click, VE11.Click, VE12.Click, VE13.Click, VE14.Click, VE15.Click, VE16.Click, VE17.Click, VE18.Click, VE19.Click, _
    '        VF01.Click, VF02.Click, VF03.Click, VF04.Click, VF05.Click, VF06.Click, VF07.Click, VF08.Click, VF09.Click, _
    '        VF10.Click, VF11.Click, VF12.Click, VF13.Click, VF14.Click, VF15.Click, VF16.Click, VF17.Click, VF18.Click

    '        'Dim sql As String

    '        If Status_B(sender.Tag) = 0 Or Status_B(sender.Tag) = 3 Then
    '            Seats_Zone_B(sender.Tag) = Not (Seats_Zone_B(sender.Tag))
    '            If Seats_Zone_B(sender.Tag) Then
    '                'sql = "UPDATE seats SET status = '1' WHERE name ='" & sender.Name & "' And status = '0' And id_showtime = '" & idShow & "';"
    '                If SetStatusSeat(idShow, "," & sender.Name, "1", "status = '0'") > 0 Then
    '                    Select Case Mode_B(sender.Tag)
    '                        Case 0
    '                            sender.Image = PicCheck1.Image
    '                            listSeats.Text += "," & sender.Name
    '                            Seats_Normal_Count += 1
    '                            N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                            N_Val.Text = Seats_Normal_Count * Seats_Normal_Val

    '                        Case 1
    '                            sender.Image = PicCheck3.Image
    '                            listSeats.Text += "," & sender.Name
    '                            Seats_VIP_Count += 1
    '                            V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                            V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                    End Select
    '                Else
    '                    MessageBox.Show("ไม่สามารถเลือกที่นั่งดังกล่าวได้", ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Seats_Zone_A(sender.Tag) = Not (Seats_Zone_A(sender.Tag))
    '                    Refresh_Seats_one(sender)
    '                End If

    '            Else
    '                Dim tmpList As String() = listSeats.Text.Split(",")
    '                Dim txtList As String = String.Empty
    '                Dim rs As String = sender.Name
    '                Dim index As Integer = 0
    '                'sql = "UPDATE seats SET status = '0' WHERE name ='" & sender.Name & "' And id_showtime = '" & idShow & "';"
    '                If SetStatusSeat(idShow, "," & sender.Name, "0", "") > 0 Then
    '                    For i As Integer = 1 To tmpList.Length - 1
    '                        If tmpList(i) = rs Then
    '                            index = i
    '                        Else
    '                            txtList += "," & tmpList(i)
    '                        End If

    '                    Next
    '                    Select Case Mode_B(sender.Tag)
    '                        Case 0
    '                            Seats_Normal_Count -= 1
    '                            N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                            N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
    '                            listSeats.Text = txtList
    '                            sender.Image = PicUnCheck1.Image

    '                        Case 1
    '                            Seats_VIP_Count -= 1
    '                            V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                            V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                            listSeats.Text = txtList
    '                            sender.Image = PicUnCheck3.Image
    '                    End Select
    '                Else
    '                    MessageBox.Show("ไม่สามารถยกที่นั่ง [" & rs & "] ได้", ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Seats_Zone_A(sender.Tag) = Not (Seats_Zone_A(sender.Tag))
    '                    Refresh_Seats_one(sender)
    '                End If


    '            End If

    '            lb_Sum.Text = (Val(N_Val.Text) + Val(M_Val.Text) + Val(V_Val.Text)).ToString
    '        End If
    '    End Sub

    '    Private Sub Zone_c_Click(sender As Object, e As EventArgs) _
    'Handles L01.Click, L02.Click, L03.Click, L04.Click, L05.Click, L06.Click, L07.Click, L08.Click, L09.Click, _
    '        L10.Click, L11.Click, L12.Click, L13.Click, L14.Click, L15.Click, L16.Click, L17.Click, L18.Click, L19.Click, _
    '        M01.Click, M02.Click, M03.Click, M04.Click, M05.Click, M06.Click, M07.Click, M08.Click, M09.Click, _
    '        M10.Click, M11.Click, M12.Click, M13.Click, M14.Click, M15.Click, M16.Click, M17.Click, M18.Click, _
    '        N01.Click, N02.Click, N03.Click, N04.Click, N05.Click, N06.Click, N07.Click, N08.Click, N09.Click, _
    '        N10.Click, N11.Click, N12.Click, N13.Click, N14.Click, N15.Click, N16.Click, N17.Click, N18.Click, N19.Click, _
    '        O01.Click, O02.Click, O03.Click, O04.Click, O05.Click, O06.Click, O07.Click, O08.Click, O09.Click, _
    '        O10.Click, O11.Click, O12.Click, O13.Click, O14.Click, O15.Click, O16.Click, O17.Click, O18.Click, _
    '        P01.Click, P02.Click, P03.Click, P04.Click, P05.Click, P06.Click, P07.Click, P08.Click, P09.Click, _
    '        P10.Click, P11.Click, P12.Click, P13.Click, P14.Click, P15.Click, P16.Click, P17.Click, P18.Click, P19.Click

    '        ' Dim sql As String

    '        If Status_C(sender.Tag) = 0 Or Status_C(sender.Tag) = 3 Then
    '            Seats_Zone_C(sender.Tag) = Not (Seats_Zone_C(sender.Tag))
    '            If Seats_Zone_C(sender.Tag) Then
    '                'sql = "UPDATE seats SET status = '1' WHERE name ='" & sender.Name & "' And status = '0' And id_showtime = '" & idShow & "';"
    '                If SetStatusSeat(idShow, "," & sender.Name, "1", "status = '0'") > 0 Then
    '                    Select Case Mode_C(sender.Tag)
    '                        Case 0
    '                            sender.Image = PicCheck1.Image
    '                            listSeats.Text += "," & sender.Name
    '                            Seats_Normal_Count += 1
    '                            N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                            N_Val.Text = Seats_Normal_Count * Seats_Normal_Val

    '                        Case 1
    '                            sender.Image = PicCheck3.Image
    '                            listSeats.Text += "," & sender.Name
    '                            Seats_VIP_Count += 1
    '                            V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                            V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                    End Select
    '                Else
    '                    MessageBox.Show("ไม่สามารถเลือกที่นั่งดังกล่าวได้", ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Seats_Zone_A(sender.Tag) = Not (Seats_Zone_A(sender.Tag))
    '                    Refresh_Seats_one(sender)
    '                End If

    '            Else
    '                Dim tmpList As String() = listSeats.Text.Split(",")
    '                Dim txtList As String = String.Empty
    '                Dim rs As String = sender.Name
    '                Dim index As Integer = 0
    '                'sql = "UPDATE seats SET status = '0' WHERE name ='" & sender.Name & "' And id_showtime = '" & idShow & "';"
    '                If SetStatusSeat(idShow, "," & sender.Name, "0", "") > 0 Then
    '                    For i As Integer = 1 To tmpList.Length - 1
    '                        If tmpList(i) = rs Then
    '                            index = i
    '                        Else
    '                            txtList += "," & tmpList(i)
    '                        End If

    '                    Next
    '                    Select Case Mode_C(sender.Tag)
    '                        Case 0
    '                            Seats_Normal_Count -= 1
    '                            N_Count.Text = "x " & Seats_Normal_Count.ToString
    '                            N_Val.Text = Seats_Normal_Count * Seats_Normal_Val
    '                            listSeats.Text = txtList
    '                            sender.Image = PicUnCheck1.Image

    '                        Case 1
    '                            Seats_VIP_Count -= 1
    '                            V_Count.Text = "x " & Seats_VIP_Count.ToString
    '                            V_Val.Text = Seats_VIP_Count * Seats_VIP_Val
    '                            listSeats.Text = txtList
    '                            sender.Image = PicUnCheck3.Image
    '                    End Select
    '                Else
    '                    MessageBox.Show("ไม่สามารถยกที่นั่ง [" & rs & "] ได้", ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                    Seats_Zone_A(sender.Tag) = Not (Seats_Zone_A(sender.Tag))
    '                    Refresh_Seats_one(sender)
    '                End If


    '            End If

    '            lb_Sum.Text = (Val(N_Val.Text) + Val(V_Val.Text)).ToString
    '        End If
    '    End Sub

    Private Sub frmSeats_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If listSeats.Text <> "" Then
            cleanSeats()
        End If
        Seats_ReColorr()
        'Me.Dispose()
    End Sub

    Private Sub cleanSeats()
        If Seats_Status = "2" Then
            SetStatusSeat("0", idShow, listSeats.Text, "0", "")
        Else
            If listSeats.Text <> "" Then SetStatusSeat("0", idShow, listSeats.Text, "0", "")
            If Seats_Tmp <> "" Then SetStatusSeat(id_guest, idShow, Seats_Tmp, "1", "")
        End If
        'Dim temp As String() = listSeats.Text.Split(",")
        'For i As Integer = 1 To temp.Length - 1
        '    Dim Sql As String = "UPDATE seats SET status = '0' WHERE name ='" & temp(i) & "' And id_showtime = '" & idShow & "';"
        '    UpdateData(Sql)
        'Next
    End Sub

    'Public Function getSeatsName(n As Integer) As String
    '    Dim rw As Integer = n Mod 12
    '    Dim rs As Integer = Val(n / 12)
    '    Dim sTxt As String = String.Empty
    '    sTxt = Chr(65 + rs) & rw.ToString
    '    Return sTxt
    'End Function

    Private Sub frmSeats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'For i As Integer = 0 To Seats_Zone_A.Length - 1
        '    Seats_Zone_A(i) = False
        'Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If listSeats.Text <> "" Then
            If Seats_Status = "2" Then
                Dim tmpList As String() = listSeats.Text.Split(",")
                Dim save As Integer = MsgBox("ยืนยันการ" & Seats_Txt & "บัตร จำนวน " & tmpList.Length - 1 & " ที่นั่ง", MsgBoxStyle.YesNo, "ยืนยัน")

                If save = 6 Then

                    'Dim sql As String = "UPDATE seats SET status = '" & Seats_Status & "' WHERE name ='" & tmpList(1) & "' And id_showtime = '" & idShow & "';"
                    'For i As Integer = 2 To tmpList.Length - 1
                    '    sql += "UPDATE seats SET status = '" & Seats_Status & "' WHERE name ='" & tmpList(i) & "' And id_showtime = '" & idShow & "';"
                    'Next

                    If SetStatusSeat("0", idShow, listSeats.Text, "4", "") > 0 Then
                        PrintSeat(idShow, listSeats.Text)
                        MessageBox.Show("Successfully Print", "Prin & Save", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        'Dim okPrint As Integer = MsgBox("กรุณาตรวจสอบการพิมพ์บัตร จำนวน " & tmpList.Length - 1 & " บัตร ว่าครบถ้วนหรือไม่?", MsgBoxStyle.YesNo, "ยืนยัน")

                        'If okPrint = 6 Then
                        Refresh_Seats()
                        Exit Sub
                        'Else
                        '    frmPrint2.showSeat(idShow, listSeats.Text)
                        '    frmPrint2.ShowDialog()
                        'End If
                    Else
                        MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    Exit Sub
                End If
            End If

            If Seats_Status = "1" Then
                Dim tmpList As String() = listSeats.Text.Split(",")

                If SetStatusSeat(id_guest, idShow, listSeats.Text, Seats_Status, "") > 0 Then
                    MessageBox.Show("การ" & Seats_Txt & "บัตร จำนวน " & tmpList.Length - 1 & " ที่นั่ง สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmReservation.RichTextBox1.Text = listSeats.Text
                    frmReservation.vip_c = Seats_VIP_Count
                    frmReservation.normal_c = Seats_Normal_Count

                    listSeats.Text = ""
                    Me.Hide()
                Else
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

            If Seats_Status = "3" Then
                Dim tmpList As String() = listSeats.Text.Split(",")

                If SetStatusSeat(id_guest, idShow, listSeats.Text, "1", "") > 0 Then
                    MessageBox.Show("การ" & Seats_Txt & "บัตร จำนวน " & tmpList.Length - 1 & " ที่นั่ง สำเร็จ", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmReservation.seats_free.Text = listSeats.Text
                    frmReservation.vip_free_c = Seats_VIP_Count
                    frmReservation.normal_free_c = Seats_Normal_Count
                    listSeats.Text = ""
                    Me.Hide()
                Else
                    MessageBox.Show("ไม่สามารถเพิ่มข้อมูลได้", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End If

        Else
            MessageBox.Show("ไม่มีการเลือกที่นั่ง", "Error Txt", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub frmSeats_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Panel1.Width = Me.Width - 10 '- GroupBox1.Width
        'Panel1.Height = Me.Height - 180
        'GroupBox1.Location = New Point(Panel1.Width + 80, 24)
        'GroupBox1.Height = Me.Height - 80
        'PictureBox2.Width = Panel1.Width
        'Label47.Location = New Point((PictureBox2.Width / 2) - 40, 20)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If listSeats.Text = "" Then
            Refresh_Seats()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If listSeats.Text = "" Then
            Refresh_Seats()
        Else
            Refresh_Seats_Chack()
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Seats_ReColorr()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Seats_ReColorr()
        If id_rev <> String.Empty And id_rev <> "0" Then
            Dim Conn As MySqlConnection
            Conn = New MySqlConnection
            Conn.ConnectionString = cs
            Try
                Conn.Open()
            Catch myerror As MySqlException
                msgError()
            End Try

            Dim MyAdapter As New MySqlDataAdapter
            Dim sqlquery = "SELECT * from view_reservation where id = '" & id_rev & "'"
            Dim mycommand As New MySqlCommand()
            mycommand.Connection = Conn
            mycommand.CommandText = sqlquery
            MyAdapter.SelectCommand = mycommand
            Dim MyData As MySqlDataReader
            MyData = mycommand.ExecuteReader

            If MyData.HasRows Then
                MyData.Read()

                frmReservation.ReserRev = MyData(0)
                frmReservation.txtReservationNo.Text = String.Format("{0:0000}", CInt(MyData(0)))
                frmReservation.txtid.Text = MyData(1)
                frmReservation.txtGuestName.Text = MyData(2)
                frmReservation.seats_free.Text = MyData(4)
                frmReservation.RichTextBox1.Text = MyData(3)
                frmReservation.txtVip.Text = MyData(8)
                frmReservation.txtNormal.Text = MyData(9)

                frmReservation.vip_c = MyData(10)
                frmReservation.normal_c = MyData(11)
                frmReservation.vip_free_c = MyData(12)
                frmReservation.normal_free_c = MyData(13)

                frmReservation.txtNotes.Text = MyData(15)

                frmReservation.dtpDate.Value = MyData(6)
                Dim d As Date = frmReservation.dtpDate.Value.ToString("yyyy-MM-dd")

                Dim st As String() = MyData(7).Split("-")
                Dim st1 As String() = st(0).Split(".")
                Dim st2 As String() = st(1).Split(".")

                frmReservation.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
                frmReservation.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)
                frmReservation.editing = False

                frmReservation.TextBox1.Text = GetStatusRev(frmReservation.ReserRev)
                If frmReservation.TextBox1.Text = "ยืนยัน" Then
                    'frmReservation.Button5.Enabled = False
                    frmReservation.btnCancelReservation.Enabled = False
                    frmReservation.btnUpdate_record.Enabled = False
                    frmReservation.Button2.Enabled = False
                    frmReservation.Button3.Enabled = False
                    frmReservation.Button4.Enabled = False
                Else
                    'frmReservation.Button5.Enabled = True
                    frmReservation.btnCancelReservation.Enabled = True
                    frmReservation.btnUpdate_record.Enabled = True
                    frmReservation.Button2.Enabled = True
                    frmReservation.Button3.Enabled = True
                    frmReservation.Button6.Enabled = True
                    frmReservation.Button4.Enabled = False
                End If

                Dim myId As String = Getid("SELECT * FROM showtime where date_time = '" & frmReservation.dtpDate.Value.ToString("yyyy-MM-dd", New System.Globalization.CultureInfo("en-US")) & "' and time = '" & MyData(7) & "'")
                frmReservation.ReserIdShow = myId
                frmReservation.btnNewRecord.Enabled = True
                frmReservation.btnSave.Enabled = False
                frmReservation.btnUpdate_record.Enabled = True
                frmReservation.Panel2.Visible = True

            End If
            Conn.Close()
            frmReservation.ShowDialog()

        Else

            frmCancelReservation.ReserIdShow = idShow
            frmCancelReservation.dtpDate.Value = date_txt
            Dim d As Date = frmSTime.dtpDate.Value

            Dim st As String() = time_txt.Split("-")
            Dim st1 As String() = st(0).Split(".")
            Dim st2 As String() = st(1).Split(".")

            frmCancelReservation.Time_Start.Value = New DateTime(d.Year, d.Month, d.Day, st1(0), st1(1), 0)
            frmCancelReservation.Time_End.Value = New DateTime(d.Year, d.Month, d.Day, st2(0), st2(1), 0)
            frmCancelReservation.btnCancelReservation.Enabled = True
            frmCancelReservation.seat_no.Text = button_name
            frmCancelReservation.ShowDialog()
            'button_name
            'idShow
            'Public date_txt As String
            'Public time_txt As String
        End If
    End Sub

    Private Sub Zone_A_Click(sender As Object, e As EventArgs) Handles VF18.Click, VF17.Click, VF16.Click, VF15.Click, VF14.Click, VF13.Click, VF12.Click, VF11.Click, VF10.Click, VF09.Click, VF08.Click, VF07.Click, VF06.Click, VF05.Click, VF04.Click, VF03.Click, VF02.Click, VF01.Click, VE19.Click, VE18.Click, VE17.Click, VE16.Click, VE15.Click, VE14.Click, VE13.Click, VE12.Click, VE11.Click, VE10.Click, VE09.Click, VE08.Click, VE07.Click, VE06.Click, VE05.Click, VE04.Click, VE03.Click, VE02.Click, VE01.Click, VD18.Click, VD17.Click, VD16.Click, VD15.Click, VD14.Click, VD13.Click, VD12.Click, VD11.Click, VD10.Click, VD09.Click, VD08.Click, VD07.Click, VD06.Click, VD05.Click, VD04.Click, VD03.Click, VD02.Click, VD01.Click, VC19.Click, VC18.Click, VC17.Click, VC16.Click, VC15.Click, VC14.Click, VC13.Click, VC12.Click, VC11.Click, VC10.Click, VC09.Click, VC08.Click, VC07.Click, VC06.Click, VC05.Click, VC04.Click, VC03.Click, VC02.Click, VC01.Click, VB18.Click, VB17.Click, VB16.Click, VB15.Click, VB14.Click, VB13.Click, VB12.Click, VB11.Click, VB10.Click, VB09.Click, VB08.Click, VB07.Click, VB06.Click, VB05.Click, VB04.Click, VB03.Click, VB02.Click, VB01.Click, VA19.Click, VA18.Click, VA17.Click, VA16.Click, VA15.Click, VA14.Click, VA13.Click, VA12.Click, VA11.Click, VA10.Click, VA09.Click, VA08.Click, VA07.Click, VA06.Click, VA05.Click, VA04.Click, VA03.Click, VA02.Click, VA01.Click, VK19.Click, VK18.Click, VK17.Click, VK16.Click, VK15.Click, VK14.Click, VK13.Click, VK12.Click, VK11.Click, VK10.Click, VK09.Click, VK08.Click, VK07.Click, VK06.Click, VK05.Click, VK04.Click, VK03.Click, VK02.Click, VK01.Click, VJ18.Click, VJ17.Click, VJ16.Click, VJ15.Click, VJ14.Click, VJ13.Click, VJ12.Click, VJ11.Click, VJ10.Click, VJ09.Click, VJ08.Click, VJ07.Click, VJ06.Click, VJ05.Click, VJ04.Click, VJ03.Click, VJ02.Click, VJ01.Click, VI19.Click, VI18.Click, VI17.Click, VI16.Click, VI15.Click, VI14.Click, VI13.Click, VI12.Click, VI11.Click, VI10.Click, VI09.Click, VI08.Click, VI07.Click, VI06.Click, VI05.Click, VI04.Click, VI03.Click, VI02.Click, VI01.Click, VH18.Click, VH17.Click, VH16.Click, VH15.Click, VH14.Click, VH13.Click, VH12.Click, VH11.Click, VH10.Click, VH09.Click, VH08.Click, VH07.Click, VH06.Click, VH05.Click, VH04.Click, VH03.Click, VH02.Click, VH01.Click, VG19.Click, VG18.Click, VG17.Click, VG16.Click, VG15.Click, VG14.Click, VG13.Click, VG12.Click, VG11.Click, VG10.Click, VG09.Click, VG08.Click, VG07.Click, VG06.Click, VG05.Click, VG04.Click, VG03.Click, VG02.Click, VG01.Click, K20.Click, K19.Click, K18.Click, K17.Click, K16.Click, K15.Click, K14.Click, K13.Click, K12.Click, K11.Click, K10.Click, K09.Click, K08.Click, K07.Click, K06.Click, K05.Click, K04.Click, K03.Click, K02.Click, K01.Click, J20.Click, J19.Click, J18.Click, J17.Click, J16.Click, J15.Click, J14.Click, J13.Click, J12.Click, J11.Click, J10.Click, J09.Click, J08.Click, J07.Click, J06.Click, J05.Click, J04.Click, J03.Click, J02.Click, J01.Click, I20.Click, I19.Click, I18.Click, I17.Click, I16.Click, I15.Click, I14.Click, I13.Click, I12.Click, I11.Click, I10.Click, I09.Click, I08.Click, I07.Click, I06.Click, I05.Click, I04.Click, I03.Click, I02.Click, I01.Click, H20.Click, H19.Click, H18.Click, H17.Click, H16.Click, H15.Click, H14.Click, H13.Click, H12.Click, H11.Click, H10.Click, H09.Click, H08.Click, H07.Click, H06.Click, H05.Click, H04.Click, H03.Click, H02.Click, H01.Click, G20.Click, G19.Click, G18.Click, G17.Click, G16.Click, G15.Click, G14.Click, G13.Click, G12.Click, G11.Click, G10.Click, G09.Click, G08.Click, G07.Click, G06.Click, G05.Click, G04.Click, G03.Click, G02.Click, G01.Click, F20.Click, F19.Click, F18.Click, F17.Click, F16.Click, F15.Click, F14.Click, F13.Click, F12.Click, F11.Click, F10.Click, F09.Click, F08.Click, F07.Click, F06.Click, F05.Click, F04.Click, F03.Click, F02.Click, F01.Click, E20.Click, E19.Click, E18.Click, E17.Click, E16.Click, E15.Click, E14.Click, E13.Click, E12.Click, E11.Click, E10.Click, E09.Click, E08.Click, E07.Click, E06.Click, E05.Click, E04.Click, E03.Click, E02.Click, E01.Click, D20.Click, D19.Click, D18.Click, D17.Click, D16.Click, D15.Click, D14.Click, D13.Click, D12.Click, D11.Click, D10.Click, D09.Click, D08.Click, D07.Click, D06.Click, D05.Click, D04.Click, D03.Click, D02.Click, D01.Click, C20.Click, C19.Click, C18.Click, C17.Click, C16.Click, C15.Click, C14.Click, C13.Click, C12.Click, C11.Click, C10.Click, C09.Click, C08.Click, C07.Click, C06.Click, C05.Click, C04.Click, C03.Click, C02.Click, C01.Click, B20.Click, B19.Click, B18.Click, B17.Click, B16.Click, B15.Click, B14.Click, B13.Click, B12.Click, B11.Click, B10.Click, B09.Click, B08.Click, B07.Click, B06.Click, B05.Click, B04.Click, B03.Click, B02.Click, B01.Click, A20.Click, A19.Click, A18.Click, A17.Click, A16.Click, A15.Click, A14.Click, A13.Click, A12.Click, A11.Click, A10.Click, A09.Click, A08.Click, A07.Click, A06.Click, A05.Click, A04.Click, A03.Click, A02.Click, A01.Click, L08.Click, L07.Click, L06.Click, L05.Click, L04.Click, L21.Click, L20.Click, L19.Click, L03.Click, L18.Click, L17.Click, L16.Click, L15.Click, L14.Click, L13.Click, L12.Click, L11.Click, L10.Click, K21.Click, L02.Click, J21.Click, VL01.Click, VL02.Click, VL03.Click, VL04.Click, VL05.Click, VL06.Click, VL07.Click, VL08.Click, VL09.Click, VL10.Click, VL11.Click, VL12.Click, VL13.Click, VL14.Click, VL15.Click, VL16.Click, VL17.Click, VL18.Click, L09.Click, L01.Click

    End Sub

End Class