<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSTime
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
        Dim Label6 As System.Windows.Forms.Label
        Dim IDTypeIDLabel As System.Windows.Forms.Label
        Dim AddressLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim FolioNumberLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSTime))
        Me.GroupBoxGuestInfo = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Time_End = New System.Windows.Forms.DateTimePicker()
        Me.Time_Start = New System.Windows.Forms.DateTimePicker()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.txtNotes = New System.Windows.Forms.RichTextBox()
        Me.cmbIDType = New System.Windows.Forms.ComboBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnUpdate_record = New System.Windows.Forms.Button()
        Me.label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNewRecord = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lb_id = New System.Windows.Forms.Label()
        Me.txtNormal = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtVip = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        IDTypeIDLabel = New System.Windows.Forms.Label()
        AddressLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        FolioNumberLabel = New System.Windows.Forms.Label()
        Me.GroupBoxGuestInfo.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.ForeColor = System.Drawing.Color.Black
        Label6.Location = New System.Drawing.Point(26, 65)
        Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(31, 17)
        Label6.TabIndex = 271
        Label6.Text = "เวลา"
        '
        'IDTypeIDLabel
        '
        IDTypeIDLabel.AutoSize = True
        IDTypeIDLabel.ForeColor = System.Drawing.Color.Black
        IDTypeIDLabel.Location = New System.Drawing.Point(26, 136)
        IDTypeIDLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        IDTypeIDLabel.Name = "IDTypeIDLabel"
        IDTypeIDLabel.Size = New System.Drawing.Size(41, 17)
        IDTypeIDLabel.TabIndex = 266
        IDTypeIDLabel.Text = "สถานะ"
        '
        'AddressLabel
        '
        AddressLabel.AutoSize = True
        AddressLabel.ForeColor = System.Drawing.Color.Black
        AddressLabel.Location = New System.Drawing.Point(26, 96)
        AddressLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        AddressLabel.Name = "AddressLabel"
        AddressLabel.Size = New System.Drawing.Size(73, 17)
        AddressLabel.TabIndex = 263
        AddressLabel.Text = "รายการแสดง"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.ForeColor = System.Drawing.Color.Black
        Label1.Location = New System.Drawing.Point(26, 237)
        Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(40, 17)
        Label1.TabIndex = 277
        Label1.Text = "Notes"
        '
        'FolioNumberLabel
        '
        FolioNumberLabel.AutoSize = True
        FolioNumberLabel.ForeColor = System.Drawing.Color.Black
        FolioNumberLabel.Location = New System.Drawing.Point(26, 29)
        FolioNumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        FolioNumberLabel.Name = "FolioNumberLabel"
        FolioNumberLabel.Size = New System.Drawing.Size(30, 17)
        FolioNumberLabel.TabIndex = 261
        FolioNumberLabel.Text = "วันที่"
        '
        'GroupBoxGuestInfo
        '
        Me.GroupBoxGuestInfo.BackColor = System.Drawing.Color.Transparent
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtNormal)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Label11)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtVip)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Label12)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Label2)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Time_End)
        Me.GroupBoxGuestInfo.Controls.Add(Me.Time_Start)
        Me.GroupBoxGuestInfo.Controls.Add(Me.dtpDate)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtNotes)
        Me.GroupBoxGuestInfo.Controls.Add(Label1)
        Me.GroupBoxGuestInfo.Controls.Add(Me.cmbIDType)
        Me.GroupBoxGuestInfo.Controls.Add(Me.txtName)
        Me.GroupBoxGuestInfo.Controls.Add(Label6)
        Me.GroupBoxGuestInfo.Controls.Add(IDTypeIDLabel)
        Me.GroupBoxGuestInfo.Controls.Add(AddressLabel)
        Me.GroupBoxGuestInfo.Controls.Add(FolioNumberLabel)
        Me.GroupBoxGuestInfo.Location = New System.Drawing.Point(17, 13)
        Me.GroupBoxGuestInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Name = "GroupBoxGuestInfo"
        Me.GroupBoxGuestInfo.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBoxGuestInfo.Size = New System.Drawing.Size(481, 348)
        Me.GroupBoxGuestInfo.TabIndex = 0
        Me.GroupBoxGuestInfo.TabStop = False
        Me.GroupBoxGuestInfo.Text = "Show Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(274, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 17)
        Me.Label2.TabIndex = 282
        Me.Label2.Text = "-"
        '
        'Time_End
        '
        Me.Time_End.CustomFormat = "HH.mm"
        Me.Time_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Time_End.Location = New System.Drawing.Point(309, 61)
        Me.Time_End.Margin = New System.Windows.Forms.Padding(2)
        Me.Time_End.Name = "Time_End"
        Me.Time_End.Size = New System.Drawing.Size(129, 24)
        Me.Time_End.TabIndex = 281
        '
        'Time_Start
        '
        Me.Time_Start.CustomFormat = "HH.mm"
        Me.Time_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Time_Start.Location = New System.Drawing.Point(119, 61)
        Me.Time_Start.Margin = New System.Windows.Forms.Padding(2)
        Me.Time_Start.Name = "Time_Start"
        Me.Time_Start.Size = New System.Drawing.Size(129, 24)
        Me.Time_Start.TabIndex = 280
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd-MMM-yyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(119, 30)
        Me.dtpDate.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(129, 24)
        Me.dtpDate.TabIndex = 279
        '
        'txtNotes
        '
        Me.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotes.Location = New System.Drawing.Point(119, 237)
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtNotes.Size = New System.Drawing.Size(319, 88)
        Me.txtNotes.TabIndex = 6
        Me.txtNotes.Text = ""
        '
        'cmbIDType
        '
        Me.cmbIDType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIDType.FormattingEnabled = True
        Me.cmbIDType.Items.AddRange(New Object() {"จำหน่าย", "งดจำหน่าย", "เหมา"})
        Me.cmbIDType.Location = New System.Drawing.Point(119, 134)
        Me.cmbIDType.Name = "cmbIDType"
        Me.cmbIDType.Size = New System.Drawing.Size(149, 25)
        Me.cmbIDType.TabIndex = 4
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(119, 97)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(319, 24)
        Me.txtName.TabIndex = 1
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
        Me.panel1.Location = New System.Drawing.Point(527, 22)
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
        Me.btnSave.Enabled = False
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
        'lb_id
        '
        Me.lb_id.AutoSize = True
        Me.lb_id.Location = New System.Drawing.Point(547, 250)
        Me.lb_id.Name = "lb_id"
        Me.lb_id.Size = New System.Drawing.Size(43, 17)
        Me.lb_id.TabIndex = 2
        Me.lb_id.Text = "NULL"
        Me.lb_id.Visible = False
        '
        'txtNormal
        '
        Me.txtNormal.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNormal.Location = New System.Drawing.Point(119, 202)
        Me.txtNormal.Name = "txtNormal"
        Me.txtNormal.Size = New System.Drawing.Size(152, 24)
        Me.txtNormal.TabIndex = 295
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(26, 208)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 17)
        Me.Label11.TabIndex = 296
        Me.Label11.Text = "ราคาที่นั่งปกติ"
        '
        'txtVip
        '
        Me.txtVip.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVip.Location = New System.Drawing.Point(119, 171)
        Me.txtVip.Name = "txtVip"
        Me.txtVip.Size = New System.Drawing.Size(152, 24)
        Me.txtVip.TabIndex = 293
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(26, 177)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 17)
        Me.Label12.TabIndex = 294
        Me.Label12.Text = "ราคาที่นั่ง VIP"
        '
        'frmSTime
        '
        Me.AcceptButton = Me.btnSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImage = Global.Ticket_Management_System.My.Resources.Resources._21
        Me.ClientSize = New System.Drawing.Size(658, 375)
        Me.Controls.Add(Me.lb_id)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.GroupBoxGuestInfo)
        Me.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frmSTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Show Time"
        Me.GroupBoxGuestInfo.ResumeLayout(False)
        Me.GroupBoxGuestInfo.PerformLayout()
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxGuestInfo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbIDType As System.Windows.Forms.ComboBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Public WithEvents panel1 As System.Windows.Forms.Panel
    Public WithEvents btnUpdate_record As System.Windows.Forms.Button
    Public WithEvents label4 As System.Windows.Forms.Label
    Public WithEvents btnSave As System.Windows.Forms.Button
    Public WithEvents btnNewRecord As System.Windows.Forms.Button
    Public WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtNotes As System.Windows.Forms.RichTextBox
    Public WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lb_id As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Time_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents Time_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNormal As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVip As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
