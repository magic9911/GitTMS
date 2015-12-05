Public Class frmSaleReport

    Private Sub frmSaleReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Cursor = Cursors.WaitCursor
            'Dim rpt As New rptsale()

            ''rpt.SetParameterValue("variable", datesend)
            ''rpt.SetParameterValue("variable1", namesend)
            ''rpt.SetParameterValue("variable2", vipsend)
            ''rpt.SetParameterValue("variable3", norsend)
            ''rpt.SetParameterValue("variable4", vipsum)
            ''rpt.SetParameterValue("variable5", norsum)
            ''rpt.SetParameterValue("variable6", sumall)

            'CrystalReportViewer1.ReportSource = rpt
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class