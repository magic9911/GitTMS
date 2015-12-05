<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainMenu))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.UsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistrationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdvancePaymentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeePaymentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.monySend = New System.Windows.Forms.ToolStripMenuItem()
        Me.recPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintSeats = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotePadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalculatorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUserType = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.RoomsAvailabilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuestToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReservationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckInToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.HallToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GardenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DishToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquorToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ราคาบตรToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gray
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsersToolStripMenuItem, Me.DatabaseToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1249, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'UsersToolStripMenuItem
        '
        Me.UsersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RegistrationToolStripMenuItem1, Me.LoginDetailsToolStripMenuItem, Me.AdminToolStripMenuItem})
        Me.UsersToolStripMenuItem.Name = "UsersToolStripMenuItem"
        Me.UsersToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.UsersToolStripMenuItem.Text = "Users"
        '
        'RegistrationToolStripMenuItem1
        '
        Me.RegistrationToolStripMenuItem1.Name = "RegistrationToolStripMenuItem1"
        Me.RegistrationToolStripMenuItem1.Size = New System.Drawing.Size(142, 22)
        Me.RegistrationToolStripMenuItem1.Text = "Registration"
        '
        'LoginDetailsToolStripMenuItem
        '
        Me.LoginDetailsToolStripMenuItem.Name = "LoginDetailsToolStripMenuItem"
        Me.LoginDetailsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.LoginDetailsToolStripMenuItem.Text = "Login Details"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem})
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.DatabaseToolStripMenuItem.Text = "ฐานข้อมูล"
        Me.DatabaseToolStripMenuItem.Visible = False
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        Me.RestoreToolStripMenuItem.Visible = False
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.AdvancePaymentToolStripMenuItem, Me.EmployeePaymentToolStripMenuItem1, Me.AttendanceToolStripMenuItem1, Me.monySend, Me.recPrint})
        Me.ReportsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.ReportsToolStripMenuItem.Text = "รายงาน"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(170, 22)
        Me.ToolStripMenuItem2.Text = "ยอดขาย"
        '
        'AdvancePaymentToolStripMenuItem
        '
        Me.AdvancePaymentToolStripMenuItem.Name = "AdvancePaymentToolStripMenuItem"
        Me.AdvancePaymentToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.AdvancePaymentToolStripMenuItem.Text = "รายการยกเลิกบัตร"
        Me.AdvancePaymentToolStripMenuItem.Visible = False
        '
        'EmployeePaymentToolStripMenuItem1
        '
        Me.EmployeePaymentToolStripMenuItem1.Name = "EmployeePaymentToolStripMenuItem1"
        Me.EmployeePaymentToolStripMenuItem1.Size = New System.Drawing.Size(170, 22)
        Me.EmployeePaymentToolStripMenuItem1.Text = "รายการยกเลิกการจอง"
        Me.EmployeePaymentToolStripMenuItem1.Visible = False
        '
        'AttendanceToolStripMenuItem1
        '
        Me.AttendanceToolStripMenuItem1.Name = "AttendanceToolStripMenuItem1"
        Me.AttendanceToolStripMenuItem1.Size = New System.Drawing.Size(170, 22)
        Me.AttendanceToolStripMenuItem1.Text = "ยอดขายกรณีพิเศษ"
        '
        'monySend
        '
        Me.monySend.Name = "monySend"
        Me.monySend.Size = New System.Drawing.Size(170, 22)
        Me.monySend.Text = "ใบรายการนำส่ง"
        '
        'recPrint
        '
        Me.recPrint.Name = "recPrint"
        Me.recPrint.Size = New System.Drawing.Size(170, 22)
        Me.recPrint.Text = "รายการพิมพ์บัตร"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StockToolStripMenuItem, Me.ToolStripMenuItem1, Me.PrintSeats, Me.ราคาบตรToolStripMenuItem})
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.TransactionToolStripMenuItem.Text = "แก้ไข"
        '
        'StockToolStripMenuItem
        '
        Me.StockToolStripMenuItem.Name = "StockToolStripMenuItem"
        Me.StockToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.StockToolStripMenuItem.Text = "รอบการแสดง"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "ยกเลิกบัตร"
        '
        'PrintSeats
        '
        Me.PrintSeats.Name = "PrintSeats"
        Me.PrintSeats.Size = New System.Drawing.Size(152, 22)
        Me.PrintSeats.Text = "พิมพ์บัตร"
        Me.PrintSeats.Visible = False
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotePadToolStripMenuItem, Me.CalculatorToolStripMenuItem, Me.SystemInfoToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ToolsToolStripMenuItem.Text = "เครื่องมือ"
        '
        'NotePadToolStripMenuItem
        '
        Me.NotePadToolStripMenuItem.Name = "NotePadToolStripMenuItem"
        Me.NotePadToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NotePadToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.NotePadToolStripMenuItem.Text = "Note Pad"
        '
        'CalculatorToolStripMenuItem
        '
        Me.CalculatorToolStripMenuItem.Name = "CalculatorToolStripMenuItem"
        Me.CalculatorToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CalculatorToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.CalculatorToolStripMenuItem.Text = "Calculator"
        '
        'SystemInfoToolStripMenuItem
        '
        Me.SystemInfoToolStripMenuItem.Name = "SystemInfoToolStripMenuItem"
        Me.SystemInfoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SystemInfoToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SystemInfoToolStripMenuItem.Text = "System Info"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AboutToolStripMenuItem.Text = "เกี่ยวกับเรา"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblUserType, Me.ToolStripStatusLabel2, Me.lblUser, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel4})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 655)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1249, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(72, 17)
        Me.ToolStripStatusLabel1.Text = "ช์่อผู้ใช้งาน :"
        '
        'lblUserType
        '
        Me.lblUserType.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserType.Image = Global.Ticket_Management_System.My.Resources.Resources.images51
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(81, 17)
        Me.lblUserType.Text = "User Type"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(11, 17)
        Me.ToolStripStatusLabel2.Text = ":"
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.Black
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(69, 17)
        Me.lblUser.Text = "User Name"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(919, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel4.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel4.Image = Global.Ticket_Management_System.My.Resources.Resources.time_1920x12001
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(82, 17)
        Me.ToolStripStatusLabel4.Text = "Date Time"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Gray
        Me.MenuStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RoomsAvailabilityToolStripMenuItem, Me.GuestToolStripMenuItem1, Me.ReservationToolStripMenuItem, Me.CheckInToolStripMenuItem, Me.PaymentToolStripMenuItem1, Me.OrderToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(1249, 77)
        Me.MenuStrip2.TabIndex = 7
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'RoomsAvailabilityToolStripMenuItem
        '
        Me.RoomsAvailabilityToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoomsAvailabilityToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.RoomsAvailabilityToolStripMenuItem.Image = Global.Ticket_Management_System.My.Resources.Resources._11949857921496995420hotel_icon_in_room_bagg_01_svg1
        Me.RoomsAvailabilityToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.RoomsAvailabilityToolStripMenuItem.Name = "RoomsAvailabilityToolStripMenuItem"
        Me.RoomsAvailabilityToolStripMenuItem.Size = New System.Drawing.Size(118, 73)
        Me.RoomsAvailabilityToolStripMenuItem.Text = "รอบการแสดง"
        Me.RoomsAvailabilityToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'GuestToolStripMenuItem1
        '
        Me.GuestToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GuestToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.GuestToolStripMenuItem1.Image = Global.Ticket_Management_System.My.Resources.Resources.images4
        Me.GuestToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.GuestToolStripMenuItem1.Name = "GuestToolStripMenuItem1"
        Me.GuestToolStripMenuItem1.Size = New System.Drawing.Size(62, 73)
        Me.GuestToolStripMenuItem1.Text = "ลูกค้า"
        Me.GuestToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ReservationToolStripMenuItem
        '
        Me.ReservationToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.ReservationToolStripMenuItem.Image = Global.Ticket_Management_System.My.Resources.Resources.booking_icon
        Me.ReservationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ReservationToolStripMenuItem.Name = "ReservationToolStripMenuItem"
        Me.ReservationToolStripMenuItem.Size = New System.Drawing.Size(99, 73)
        Me.ReservationToolStripMenuItem.Text = "สำรองที่นั่ง"
        Me.ReservationToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'CheckInToolStripMenuItem
        '
        Me.CheckInToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckInToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.CheckInToolStripMenuItem.Image = Global.Ticket_Management_System.My.Resources.Resources.icon_ci_big
        Me.CheckInToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.CheckInToolStripMenuItem.Name = "CheckInToolStripMenuItem"
        Me.CheckInToolStripMenuItem.Size = New System.Drawing.Size(102, 73)
        Me.CheckInToolStripMenuItem.Text = "จำหน่ายตั๋ว"
        Me.CheckInToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'PaymentToolStripMenuItem1
        '
        Me.PaymentToolStripMenuItem1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentToolStripMenuItem1.ForeColor = System.Drawing.Color.White
        Me.PaymentToolStripMenuItem1.Image = Global.Ticket_Management_System.My.Resources.Resources.images_5
        Me.PaymentToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PaymentToolStripMenuItem1.Name = "PaymentToolStripMenuItem1"
        Me.PaymentToolStripMenuItem1.Size = New System.Drawing.Size(83, 73)
        Me.PaymentToolStripMenuItem1.Text = "ชำระเงิน"
        Me.PaymentToolStripMenuItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'OrderToolStripMenuItem
        '
        Me.OrderToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.OrderToolStripMenuItem.Image = Global.Ticket_Management_System.My.Resources.Resources.order_icon
        Me.OrderToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.OrderToolStripMenuItem.Name = "OrderToolStripMenuItem"
        Me.OrderToolStripMenuItem.Size = New System.Drawing.Size(84, 73)
        Me.OrderToolStripMenuItem.Text = "ยอดขาย"
        Me.OrderToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogoutToolStripMenuItem.ForeColor = System.Drawing.Color.White
        Me.LogoutToolStripMenuItem.Image = Global.Ticket_Management_System.My.Resources.Resources.logout
        Me.LogoutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(120, 73)
        Me.LogoutToolStripMenuItem.Text = "ออกจากระบบ"
        Me.LogoutToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(660, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(1, 1)
        Me.Button1.TabIndex = 83
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(458, 95)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(1, 1)
        Me.Button2.TabIndex = 85
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'HallToolStripMenuItem
        '
        Me.HallToolStripMenuItem.Name = "HallToolStripMenuItem"
        Me.HallToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HallToolStripMenuItem.Text = "Hall"
        '
        'GardenToolStripMenuItem
        '
        Me.GardenToolStripMenuItem.Name = "GardenToolStripMenuItem"
        Me.GardenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GardenToolStripMenuItem.Text = "Garden"
        '
        'DishToolStripMenuItem
        '
        Me.DishToolStripMenuItem.Name = "DishToolStripMenuItem"
        Me.DishToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DishToolStripMenuItem.Text = "Food"
        '
        'ExtraToolStripMenuItem
        '
        Me.ExtraToolStripMenuItem.Name = "ExtraToolStripMenuItem"
        Me.ExtraToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExtraToolStripMenuItem.Text = "Extra Bed"
        '
        'BeerToolStripMenuItem
        '
        Me.BeerToolStripMenuItem.Name = "BeerToolStripMenuItem"
        Me.BeerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.BeerToolStripMenuItem.Text = "Beer"
        '
        'LiquorToolStripMenuItem1
        '
        Me.LiquorToolStripMenuItem1.Name = "LiquorToolStripMenuItem1"
        Me.LiquorToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.LiquorToolStripMenuItem1.Text = "Liquor"
        '
        'LiquorToolStripMenuItem
        '
        Me.LiquorToolStripMenuItem.Name = "LiquorToolStripMenuItem"
        Me.LiquorToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LiquorToolStripMenuItem.Text = "Liquor Pricing"
        '
        'RoomToolStripMenuItem
        '
        Me.RoomToolStripMenuItem.Name = "RoomToolStripMenuItem"
        Me.RoomToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RoomToolStripMenuItem.Text = "Room"
        '
        'GuestToolStripMenuItem
        '
        Me.GuestToolStripMenuItem.Name = "GuestToolStripMenuItem"
        Me.GuestToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GuestToolStripMenuItem.Text = "Guest"
        '
        'PurchaseToolStripMenuItem
        '
        Me.PurchaseToolStripMenuItem.Name = "PurchaseToolStripMenuItem"
        Me.PurchaseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.PurchaseToolStripMenuItem.Text = "Purchase"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 104)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1249, 548)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        '
        'ราคาบตรToolStripMenuItem
        '
        Me.ราคาบตรToolStripMenuItem.Name = "ราคาบตรToolStripMenuItem"
        Me.ราคาบตรToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ราคาบตรToolStripMenuItem.Text = "ราคาบัตร"
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.ControlDark
        Me.ClientSize = New System.Drawing.Size(1249, 677)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ระบบบริหารจัดการ บัตรเข้าชมการแสดง CHIANG MAI CABARET"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotePadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalculatorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SystemInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdvancePaymentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeePaymentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents PaymentToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckInToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReservationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistrationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GuestToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblUserType As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents RoomsAvailabilityToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HallToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GardenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DishToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BeerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiquorToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiquorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents monySend As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintSeats As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents recPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ราคาบตรToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
