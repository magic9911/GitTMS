<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGuest
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
        Dim Label46 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim IDNumberLabel As System.Windows.Forms.Label
        Dim IDTypeIDLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGuest))
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.cmbIDType = New System.Windows.Forms.ComboBox()
        Me.txtGuestContactNo = New System.Windows.Forms.TextBox()
        Me.txtGuestCity = New System.Windows.Forms.TextBox()
        Me.txtGuestAddress = New System.Windows.Forms.TextBox()
        Me.txtGuestName = New System.Windows.Forms.TextBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUpdate_record = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Label46 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        IDNumberLabel = New System.Windows.Forms.Label()
        IDTypeIDLabel = New System.Windows.Forms.Label()
        AddressLabel = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxGuestInfo.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label46
        '
        Label46.AutoSize = True
        Label46.ForeColor = System.Drawing.Color.Black
        Label46.Location = New System.Drawing.Point(26, 169)
        Label46.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label46.Name = "Label46"
        Label46.Size = New System.Drawing.Size(37, 17)
        Label46.TabIndex = 276
        Label46.Text = "มือถือ"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.ForeColor = System.Drawing.Color.Black
        Label2.Location = New System.Drawing.Point(26, 130)
        Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(85, 17)
        Label2.TabIndex = 274
        Label2.Text = "จังหวัด/ประเทศ"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(26, 65)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(56, 17)
        Label6.TabIndex = 271
        Label6.Text = "ชื่อ - สกุล"
        '
        'IDNumberLabel
        '
        IDNumberLabel.AutoSize = True
        IDNumberLabel.ForeColor = System.Drawing.Color.Black
        IDNumberLabel.Location = New System.Drawing.Point(26, 246)
        IDNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDNumberLabel.Name = "IDNumberLabel"
        IDNumberLabel.Size = New System.Drawing.Size(36, 17)
        IDNumberLabel.TabIndex = 267
        IDNumberLabel.Text = "เลขที่"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(26, 207)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(67, 17)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "ประเภทบัตร"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.ForeColor = System.Drawing.Color.Black
        AddressLabel.Location = New System.Drawing.Point(26, 96)
        AddressLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(30, 17)
        AddressLabel.TabIndex = 263
        AddressLabel.Text = "ที่อยู่"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(26, 29)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(57, 17)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "รหัสลูกค้า"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.ForeColor = System.Drawing.Color.Black
        Label1.Location = New System.Drawing.Point(26, 286)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(57, 17)
        Label1.TabIndex = 277
        Label1.Text = "หมายเหตุ"
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtNotes)
        Me.GroupBoxGuestInfo.Controls.Add(Label1)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtIDNumber)
        Me.GroupBoxGuestInfo.Controls.Add(Me.cmbIDType)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestContactNo)
        Me.GroupBoxGuestInfo.Controls.Add(Label46)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestCity)
        Me.GroupBoxGuestInfo.Controls.Add(Label2)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestAddress)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtGuestName)
        Me.GroupBoxGuestInfo.Controls.Add(Label6)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtid)
        Me.GroupBoxGuestInfo.Controls.Add(IDNumberLabel)
        Me.GroupBoxGuestInfo.Controls.Add(IDTypeIDLabel)
        Me.GroupBoxGuestInfo.Controls.Add(AddressLabel)
        Me.GroupBoxGuestInfo.Controls.Add(FolioNumberLabel)
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(17, 13)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(597, 390)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        Me.GroupBoxGuestInfo.Text = "รายละเอียดลูกค้า"
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Location = New System.Drawing.Point(119, 286)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes.Size = New System.Drawing.Size(256, 88)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Text = ""
        '
        'txtIDNumber
        '
        Me.txtIDNumber.Location = New System.Drawing.Point(119, 243)
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(256, 24)
        Me.txtIDNumber.TabIndex = 5
        '
        'cmbIDType
        '
        Me.cmbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIDType.FormattingEnabled = True
        Me.cmbIDType.Items.AddRange(New Object() {"บัตรประชาชน", "บัตรข้าราชการ", "ใบอนุญาตขับขี่", "หนังสือเดินทาง", "อื่นๆ"})
        Me.cmbIDType.Location = New System.Drawing.Point(119, 205)
        Me.cmbIDType.Name = "cmbIDType"
        Me.cmbIDType.Size = New System.Drawing.Size(149, 25)
        Me.cmbIDType.TabIndex = 4
        '
        'txtGuestContactNo
        '
        Me.txtGuestContactNo.Location = New System.Drawing.Point(119, 169)
        Me.txtGuestContactNo.Name = "txtGuestContactNo"
        Me.txtGuestContactNo.Size = New System.Drawing.Size(149, 24)
        Me.txtGuestContactNo.TabIndex = 3
        '
        'txtGuestCity
        '
        Me.txtGuestCity.Location = New System.Drawing.Point(119, 134)
        Me.txtGuestCity.Name = "txtGuestCity"
        Me.txtGuestCity.Size = New System.Drawing.Size(319, 24)
        Me.txtGuestCity.TabIndex = 2
        '
        'txtGuestAddress
        '
        Me.txtGuestAddress.Location = New System.Drawing.Point(119, 97)
        Me.txtGuestAddress.Name = "txtGuestAddress"
        Me.txtGuestAddress.Size = New System.Drawing.Size(438, 24)
        Me.txtGuestAddress.TabIndex = 1
        '
        'txtGuestName
        '
        Me.txtGuestName.Location = New System.Drawing.Point(119, 62)
        Me.txtGuestName.Name = "txtGuestName"
        Me.txtGuestName.Size = New System.Drawing.Size(319, 24)
        Me.txtGuestName.TabIndex = 0
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(119, 29)
        Me.txtid.Name = "txtid"
        Me.txtid.ReadOnly = True
        Me.txtid.Size = New System.Drawing.Size(149, 24)
        Me.txtid.TabIndex = 7
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
        Me.panel1.Location = New System.Drawing.Point(629, 22)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(111, 205)
        Me.panel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(9, 161)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 31)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&Get Data"
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
        'frmGuest
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.Ticket_Management_System.My.Resources.Resources._21
        Me.ClientSize = New System.Drawing.Size(762, 421)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBoxGuestInfo)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmGuest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ลูกค้า"
        Me.GroupBoxGuestInfo.ResumeLayout(False)
        Me.GroupBoxGuestInfo.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxGuestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmbIDType As System.Windows.Forms.ComboBox
    Friend WithEvents txtGuestContactNo As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestCity As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestAddress As System.Windows.Forms.TextBox
    Friend WithEvents txtGuestName As System.Windows.Forms.TextBox
    Friend WithEvents txtid As System.Windows.Forms.TextBox
    Public WithEvents panel1 As System.Windows.Forms.Panel
    Public WithEvents btnUpdate_record As System.Windows.Forms.Button
    Public WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnNewRecord As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Public WithEvents Button1 As System.Windows.Forms.Button
End Class
