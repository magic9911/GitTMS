Imports System.Drawing.Printing

Public Class frmPrint
    Inherits System.Windows.Forms.Form

    Public txtDate As String = "12/8/2557" 'String.Empty
    Public txtTime As String = "20.00-22.00" 'String.Empty
    Public txtSeat As String = "A01" 'String.Empty
    Public txtPrice As String = "500" 'String.Empty

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents dlgPrint As System.Windows.Forms.PrintDialog
    Friend WithEvents dlgPrintPreview As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnPrintNow As System.Windows.Forms.Button
    Friend WithEvents btnPrintWithDialog As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrint))
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrintWithDialog = New System.Windows.Forms.Button()
        Me.dlgPrint = New System.Windows.Forms.PrintDialog()
        Me.dlgPrintPreview = New System.Windows.Forms.PrintPreviewDialog()
        Me.btnPrintNow = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Location = New System.Drawing.Point(439, 52)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(96, 23)
        Me.btnPrintPreview.TabIndex = 0
        Me.btnPrintPreview.Text = "Print Preview"
        '
        'btnPrintWithDialog
        '
        Me.btnPrintWithDialog.Location = New System.Drawing.Point(439, 90)
        Me.btnPrintWithDialog.Name = "btnPrintWithDialog"
        Me.btnPrintWithDialog.Size = New System.Drawing.Size(96, 23)
        Me.btnPrintWithDialog.TabIndex = 1
        Me.btnPrintWithDialog.Text = "Print w/Dialog"
        '
        'dlgPrintPreview
        '
        Me.dlgPrintPreview.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.dlgPrintPreview.ClientSize = New System.Drawing.Size(400, 300)
        Me.dlgPrintPreview.Enabled = True
        Me.dlgPrintPreview.Icon = CType(resources.GetObject("dlgPrintPreview.Icon"), System.Drawing.Icon)
        Me.dlgPrintPreview.Name = "dlgPrintPreview"
        Me.dlgPrintPreview.Visible = False
        '
        'btnPrintNow
        '
        Me.btnPrintNow.Location = New System.Drawing.Point(439, 12)
        Me.btnPrintNow.Name = "btnPrintNow"
        Me.btnPrintNow.Size = New System.Drawing.Size(96, 23)
        Me.btnPrintNow.TabIndex = 2
        Me.btnPrintNow.Text = "Print Now"
        '
        'frmPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(537, 166)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPrintNow)
        Me.Controls.Add(Me.btnPrintWithDialog)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrint"
        Me.Text = "Printing..."
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Display a print preview.
    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click
        ' Make a PrintDocument and attach it to 
        ' the PrintPreview dialog.
        dlgPrintPreview.Document = PreparePrintDocument()

        ' Preview.
        dlgPrintPreview.WindowState = FormWindowState.Maximized
        dlgPrintPreview.ShowDialog()
    End Sub

    ' Print with the print dialog.
    Private Sub btnPrintWithDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintWithDialog.Click
        ' Make a PrintDocument and attach it to 
        ' the Print dialog.
        dlgPrint.Document = PreparePrintDocument()

        ' Display the print dialog.
        dlgPrint.ShowDialog()
    End Sub

    Public Sub PrintNow()
        ' Make a PrintDocument object.
        Dim print_document As PrintDocument = PreparePrintDocument()

        ' Print immediately.
        print_document.Print()
    End Sub
    ' Print immediately.

    Private Sub btnPrintNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintNow.Click
        PrintNow()
    End Sub

    ' Make and return a PrintDocument object that's ready
    ' to print the paragraphs.
    Private Function PreparePrintDocument() As PrintDocument
        ' Make the PrintDocument object.
        Dim print_document As New PrintDocument
        print_document.DefaultPageSettings.PaperSize = New PaperSize("Custom", 288, 576)
        ' Install the PrintPage event handler.
        AddHandler print_document.PrintPage, AddressOf Print_PrintPage

        ' Return the object.
        Return print_document
    End Function

    ' Print the next page.
    Private Sub Print_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim x As Integer = 265
        Dim g As Graphics = e.Graphics
        g.FillRectangle(Brushes.White, Me.ClientRectangle)

        Dim sf As New StringFormat(StringFormatFlags.DirectionVertical)
        Dim f As New Font("Tahoma", 13)

        Dim sizeDate As SizeF = g.MeasureString(txtDate, f, Int32.MaxValue, sf)
        Dim sizeTime As SizeF = g.MeasureString(txtTime, f, Int32.MaxValue, sf)
        Dim sizeSeat As SizeF = g.MeasureString(txtSeat, f, Int32.MaxValue, sf)
        Dim sizePrice As SizeF = g.MeasureString(txtPrice, f, Int32.MaxValue, sf)

        Dim rs_Date As New RectangleF(x, 10, sizeDate.Width, sizeDate.Height)
        Dim rs_Time As New RectangleF(x, 115, sizeTime.Width, sizeTime.Height)
        Dim rs_Seat As New RectangleF(x, 250, sizeSeat.Width, sizeSeat.Height)
        Dim rs_Price As New RectangleF(x, 370, sizePrice.Width, sizePrice.Height)
        'g.DrawRectangle(Pens.Black, rf.Left, rf.Top, rf.Width, rf.Height)
        g.DrawString(txtDate, f, Brushes.Black, rs_Date, sf)
        g.DrawString(txtTime, f, Brushes.Black, rs_Time, sf)
        g.DrawString(txtSeat, f, Brushes.Black, rs_Seat, sf)
        g.DrawString(txtPrice, f, Brushes.Black, rs_Price, sf)

        'Dim the_font As New Font("Tahoma", 16, FontStyle.Bold, GraphicsUnit.Pixel)

        'Dim rect_wid As Integer = 200 - 20
        'Dim rect_hgt As Integer = 200 - 20
        'Dim layout_rect As New RectangleF( _
        '    (200 - rect_wid) \ 2, _
        '    (200 - rect_hgt) \ 2, _
        '    rect_wid, rect_hgt)

        'Dim string_format As New StringFormat

        'string_format.Alignment = StringAlignment.Center
        'string_format.LineAlignment = StringAlignment.Center

        'e.Graphics.TranslateTransform(-200 \ 2, -200 \ 2, MatrixOrder.Append)
        'e.Graphics.RotateTransform(180, MatrixOrder.Append)
        'e.Graphics.TranslateTransform(200 \ 2, 200 \ 2, MatrixOrder.Append)

        'e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit
        'e.Graphics.DrawString(txtDate, the_font, Brushes.Black, layout_rect, string_format)
    End Sub
End Class
