<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStock
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
        Dim Label1 As System.Windows.Forms.Label
        Dim IDNumberLabel As System.Windows.Forms.Label
        Dim IDTypeIDLabel As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStock))
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtTotalVolume = New System.Windows.Forms.TextBox()
        Me.txtVolume = New System.Windows.Forms.TextBox()
        Me.txtNoOfBottles = New System.Windows.Forms.TextBox()
        Me.cmbLiquorName = New System.Windows.Forms.ComboBox()
        Me.txtStockID = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUpdate_record = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLiquor = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBeer = New System.Windows.Forms.TextBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnExportExcel1 = New System.Windows.Forms.Button()
        Me.btnUpdate1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave1 = New System.Windows.Forms.Button()
        Me.btnNew1 = New System.Windows.Forms.Button()
        Me.btnDelete1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtNoOfBottles1 = New System.Windows.Forms.TextBox()
        Me.cmbBeerName = New System.Windows.Forms.ComboBox()
        Me.txtStockID1 = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Label1 = New System.Windows.Forms.Label()
        IDNumberLabel = New System.Windows.Forms.Label()
        IDTypeIDLabel = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Me.GroupBoxGuestInfo.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.ForeColor = System.Drawing.Color.Black
        Label1.Location = New System.Drawing.Point(26, 147)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(51, 17)
        Label1.TabIndex = 277
        Label1.Text = "Volume"
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.ForeColor = System.Drawing.Color.Black
        IDNumberLabel.Location = New System.Drawing.Point(26, 110)
        IDNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(86, 17)
        IDNumberLabel.TabIndex = 267
        IDNumberLabel.Text = "No. Of Bottles"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(26, 68)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(81, 17)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "Liquor Name"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(26, 29)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(56, 17)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "Stock ID"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(251, 147)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(28, 17)
        Label2.TabIndex = 280
        Label2.Text = "ML"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.ForeColor = System.Drawing.Color.Black
        Label3.Location = New System.Drawing.Point(26, 184)
        Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(83, 17)
        Label3.TabIndex = 281
        Label3.Text = "Total Volume"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.ForeColor = System.Drawing.Color.Black
        Label5.Location = New System.Drawing.Point(251, 184)
        Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(28, 17)
        Label5.TabIndex = 283
        Label5.Text = "ML"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.ForeColor = System.Drawing.Color.Black
        Label11.Location = New System.Drawing.Point(26, 110)
        Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(86, 17)
        Label11.TabIndex = 267
        Label11.Text = "No. Of Bottles"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.ForeColor = System.Drawing.Color.Black
        Label12.Location = New System.Drawing.Point(26, 68)
        Label12.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(69, 17)
        Label12.TabIndex = 266
        Label12.Text = "Beer Name"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.ForeColor = System.Drawing.Color.Black
        Label13.Location = New System.Drawing.Point(26, 29)
        Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(56, 17)
        Label13.TabIndex = 261
        Label13.Text = "Stock ID"
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.Controls.Add(Me.TextBox2)
        Me.GroupBoxGuestInfo.Controls.Add(Me.TextBox1)
        Me.GroupBoxGuestInfo.Controls.Add(Label5)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtTotalVolume)
        Me.GroupBoxGuestInfo.Controls.Add(Label3)
        Me.GroupBoxGuestInfo.Controls.Add(Label2)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtVolume)
        Me.GroupBoxGuestInfo.Controls.Add(Label1)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtNoOfBottles)
        Me.GroupBoxGuestInfo.Controls.Add(Me.cmbLiquorName)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtStockID)
        Me.GroupBoxGuestInfo.Controls.Add(IDNumberLabel)
        Me.GroupBoxGuestInfo.Controls.Add(IDTypeIDLabel)
        Me.GroupBoxGuestInfo.Controls.Add(FolioNumberLabel)
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(10, 5)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(597, 228)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        Me.GroupBoxGuestInfo.Text = "Stock Info"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(349, 178)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 24)
        Me.TextBox2.TabIndex = 285
        Me.TextBox2.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(349, 147)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 24)
        Me.TextBox1.TabIndex = 284
        Me.TextBox1.Visible = False
        '
        'txtTotalVolume
        '
        Me.txtTotalVolume.Location = New System.Drawing.Point(130, 181)
        Me.txtTotalVolume.Name = "txtTotalVolume"
        Me.txtTotalVolume.ReadOnly = True
        Me.txtTotalVolume.Size = New System.Drawing.Size(104, 24)
        Me.txtTotalVolume.TabIndex = 3
        '
        'txtVolume
        '
        Me.txtVolume.Location = New System.Drawing.Point(130, 144)
        Me.txtVolume.Name = "txtVolume"
        Me.txtVolume.Size = New System.Drawing.Size(104, 24)
        Me.txtVolume.TabIndex = 2
        '
        'txtNoOfBottles
        '
        Me.txtNoOfBottles.Location = New System.Drawing.Point(130, 107)
        Me.txtNoOfBottles.Name = "txtNoOfBottles"
        Me.txtNoOfBottles.Size = New System.Drawing.Size(104, 24)
        Me.txtNoOfBottles.TabIndex = 1
        '
        'cmbLiquorName
        '
        Me.cmbLiquorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbLiquorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLiquorName.FormattingEnabled = True
        Me.cmbLiquorName.Location = New System.Drawing.Point(130, 65)
        Me.cmbLiquorName.Name = "cmbLiquorName"
        Me.cmbLiquorName.Size = New System.Drawing.Size(269, 25)
        Me.cmbLiquorName.TabIndex = 0
        '
        'txtStockID
        '
        Me.txtStockID.Location = New System.Drawing.Point(130, 29)
        Me.txtStockID.Name = "txtStockID"
        Me.txtStockID.ReadOnly = True
        Me.txtStockID.Size = New System.Drawing.Size(149, 24)
        Me.txtStockID.TabIndex = 4
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.Transparent
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.Button1)
        Me.panel1.Controls.Add(Me.btnUpdate_record)
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.btnSave)
        Me.panel1.Controls.Add(Me.btnNewRecord)
        Me.panel1.Controls.Add(Me.btnDelete)
        Me.panel1.Location = New System.Drawing.Point(620, 13)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(111, 208)
        Me.panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(9, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 31)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Export Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnUpdate_record
        '
        Me.btnUpdate_record.Enabled = False
        Me.btnUpdate_record.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate_record.Location = New System.Drawing.Point(9, 124)
        Me.btnUpdate_record.Name = "btnUpdate_record"
        Me.btnUpdate_record.Size = New System.Drawing.Size(87, 31)
        Me.btnUpdate_record.TabIndex = 3
        Me.btnUpdate_record.Text = "&Update"
        Me.btnUpdate_record.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(334, 31)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(11, 17)
        Me.label4.TabIndex = 19
        Me.label4.Text = "."
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(9, 50)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(87, 31)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNewRecord
        '
        Me.btnNewRecord.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewRecord.Location = New System.Drawing.Point(9, 13)
        Me.btnNewRecord.Name = "btnNewRecord"
        Me.btnNewRecord.Size = New System.Drawing.Size(87, 31)
        Me.btnNewRecord.TabIndex = 0
        Me.btnNewRecord.Text = "&New"
        Me.btnNewRecord.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(9, 87)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(87, 31)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.DataGridView1.Location = New System.Drawing.Point(10, 304)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(748, 336)
        Me.DataGridView1.TabIndex = 3
        '
        'Column1
        '
        Me.Column1.HeaderText = "Stock ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Liquor Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 200
        '
        'Column3
        '
        Me.Column3.HeaderText = "No. Of Bottles"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Volume (in ML)"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Total Volume (in ML)"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Last Stock Date"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(10, 247)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 18)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Search Liquor"
        '
        'txtLiquor
        '
        Me.txtLiquor.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLiquor.Location = New System.Drawing.Point(10, 274)
        Me.txtLiquor.Multiline = True
        Me.txtLiquor.Name = "txtLiquor"
        Me.txtLiquor.Size = New System.Drawing.Size(244, 24)
        Me.txtLiquor.TabIndex = 81
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Location = New System.Drawing.Point(289, 235)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(120, 63)
        Me.GroupBox1.TabIndex = 83
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(16, 22)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 31)
        Me.Button2.TabIndex = 84
        Me.Button2.Text = "Out Of Stock"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-2, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(785, 679)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackgroundImage = Global.Ticket_Management_System.My.Resources.Resources._5
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage1.Controls.Add(Me.lblUserType)
        Me.TabPage1.Controls.Add(Me.txtID)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtBeer)
        Me.TabPage1.Controls.Add(Me.DataGridView2)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(777, 649)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Beer"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Location = New System.Drawing.Point(629, 274)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(44, 17)
        Me.lblUserType.TabIndex = 89
        Me.lblUserType.Text = "Label3"
        Me.lblUserType.Visible = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(586, 15)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 24)
        Me.txtID.TabIndex = 88
        Me.txtID.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button8)
        Me.GroupBox3.Location = New System.Drawing.Point(289, 205)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(120, 63)
        Me.GroupBox3.TabIndex = 87
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search By"
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.Location = New System.Drawing.Point(16, 22)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(87, 31)
        Me.Button8.TabIndex = 84
        Me.Button8.Text = "Out Of Stock"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Palatino Linotype", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label7.Location = New System.Drawing.Point(16, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 18)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "Search Beer"
        '
        'txtBeer
        '
        Me.txtBeer.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeer.Location = New System.Drawing.Point(14, 244)
        Me.txtBeer.Multiline = True
        Me.txtBeer.Name = "txtBeer"
        Me.txtBeer.Size = New System.Drawing.Size(244, 24)
        Me.txtBeer.TabIndex = 85
        '
        'DataGridView2
        '
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn6})
        Me.DataGridView2.Location = New System.Drawing.Point(14, 274)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.Size = New System.Drawing.Size(545, 366)
        Me.DataGridView2.TabIndex = 84
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Stock ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Beer Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 200
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "No. Of Bottles"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Last Stock Date"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnExportExcel1)
        Me.Panel2.Controls.Add(Me.btnUpdate1)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.btnSave1)
        Me.Panel2.Controls.Add(Me.btnNew1)
        Me.Panel2.Controls.Add(Me.btnDelete1)
        Me.Panel2.Location = New System.Drawing.Point(453, 15)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(111, 208)
        Me.Panel2.TabIndex = 2
        '
        'btnExportExcel1
        '
        Me.btnExportExcel1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportExcel1.Location = New System.Drawing.Point(9, 161)
        Me.btnExportExcel1.Name = "btnExportExcel1"
        Me.btnExportExcel1.Size = New System.Drawing.Size(87, 31)
        Me.btnExportExcel1.TabIndex = 4
        Me.btnExportExcel1.Text = "&Export Excel"
        Me.btnExportExcel1.UseVisualStyleBackColor = True
        '
        'btnUpdate1
        '
        Me.btnUpdate1.Enabled = False
        Me.btnUpdate1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate1.Location = New System.Drawing.Point(9, 124)
        Me.btnUpdate1.Name = "btnUpdate1"
        Me.btnUpdate1.Size = New System.Drawing.Size(87, 31)
        Me.btnUpdate1.TabIndex = 3
        Me.btnUpdate1.Text = "&Update"
        Me.btnUpdate1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(334, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(11, 17)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "."
        '
        'btnSave1
        '
        Me.btnSave1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave1.Location = New System.Drawing.Point(9, 50)
        Me.btnSave1.Name = "btnSave1"
        Me.btnSave1.Size = New System.Drawing.Size(87, 31)
        Me.btnSave1.TabIndex = 1
        Me.btnSave1.Text = "&Save"
        Me.btnSave1.UseVisualStyleBackColor = True
        '
        'btnNew1
        '
        Me.btnNew1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew1.Location = New System.Drawing.Point(9, 13)
        Me.btnNew1.Name = "btnNew1"
        Me.btnNew1.Size = New System.Drawing.Size(87, 31)
        Me.btnNew1.TabIndex = 0
        Me.btnNew1.Text = "&New"
        Me.btnNew1.UseVisualStyleBackColor = True
        '
        'btnDelete1
        '
        Me.btnDelete1.Enabled = False
        Me.btnDelete1.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete1.Location = New System.Drawing.Point(9, 87)
        Me.btnDelete1.Name = "btnDelete1"
        Me.btnDelete1.Size = New System.Drawing.Size(87, 31)
        Me.btnDelete1.TabIndex = 2
        Me.btnDelete1.Text = "&Delete"
        Me.btnDelete1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNoOfBottles1)
        Me.GroupBox2.Controls.Add(Me.cmbBeerName)
        Me.GroupBox2.Controls.Add(Me.txtStockID1)
        Me.GroupBox2.Controls.Add(Label11)
        Me.GroupBox2.Controls.Add(Label12)
        Me.GroupBox2.Controls.Add(Label13)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 7)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(422, 154)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Stock Info"
        '
        'txtNoOfBottles1
        '
        Me.txtNoOfBottles1.Location = New System.Drawing.Point(130, 107)
        Me.txtNoOfBottles1.Name = "txtNoOfBottles1"
        Me.txtNoOfBottles1.Size = New System.Drawing.Size(104, 24)
        Me.txtNoOfBottles1.TabIndex = 1
        '
        'cmbBeerName
        '
        Me.cmbBeerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBeerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBeerName.FormattingEnabled = True
        Me.cmbBeerName.Location = New System.Drawing.Point(130, 66)
        Me.cmbBeerName.Name = "cmbBeerName"
        Me.cmbBeerName.Size = New System.Drawing.Size(269, 25)
        Me.cmbBeerName.TabIndex = 0
        '
        'txtStockID1
        '
        Me.txtStockID1.Location = New System.Drawing.Point(130, 29)
        Me.txtStockID1.Name = "txtStockID1"
        Me.txtStockID1.ReadOnly = True
        Me.txtStockID1.Size = New System.Drawing.Size(149, 24)
        Me.txtStockID1.TabIndex = 4
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = Global.Ticket_Management_System.My.Resources.Resources._5
        Me.TabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TabPage2.Controls.Add(Me.GroupBoxGuestInfo)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtLiquor)
        Me.TabPage2.Controls.Add(Me.panel1)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(777, 649)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Others"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.Ticket_Management_System.My.Resources.Resources._5
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(783, 678)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock"
        Me.GroupBoxGuestInfo.ResumeLayout(False)
        Me.GroupBoxGuestInfo.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxGuestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoOfBottles As System.Windows.Forms.TextBox
    Friend WithEvents cmbLiquorName As System.Windows.Forms.ComboBox
    Friend WithEvents txtStockID As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVolume As System.Windows.Forms.TextBox
    Friend WithEvents txtVolume As System.Windows.Forms.TextBox
    Public WithEvents panel1 As System.Windows.Forms.Panel
    Public WithEvents btnUpdate_record As System.Windows.Forms.Button
    Public WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnNewRecord As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Public WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLiquor As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents btnExportExcel1 As System.Windows.Forms.Button
    Public WithEvents btnUpdate1 As System.Windows.Forms.Button
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents btnSave1 As System.Windows.Forms.Button
    Public WithEvents btnNew1 As System.Windows.Forms.Button
    Public WithEvents btnDelete1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNoOfBottles1 As System.Windows.Forms.TextBox
    Friend WithEvents cmbBeerName As System.Windows.Forms.ComboBox
    Friend WithEvents txtStockID1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents Button8 As System.Windows.Forms.Button
    Private WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBeer As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents lblUserType As System.Windows.Forms.Label
End Class
