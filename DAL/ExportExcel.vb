Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Windows.Forms

Namespace QuanLyDaiLyDAL
    Public Class ExportExcel
        Public Shared Sub Export(ByVal _table As DataTable, ByVal dgv As DataGridView)
            'Hiện bảng Excel sau khi nhấn Export (chưa save)

            Dim ExcelApp As Object
            'ExcelApp = New Application()
            Dim Lig_cpt, Col_cpt As Integer
            ExcelApp = CreateObject("Excel.Application")
            ExcelApp.workbooks.add()

            ExcelApp.Visible = True

            Try
                'Change Properties of the Workbook
                ExcelApp.Columns.ColumnWidth = 20
                For Col_cpt = 0 To dgv.ColumnCount - 1
                    ExcelApp.ActiveSheet.cells(1, Col_cpt + 1).value = dgv.Columns(Col_cpt).HeaderText
                Next
                For Lig_cpt = 0 To dgv.Rows.Count - 1
                    For Col_cpt = 0 To dgv.ColumnCount - 1
                        If IsNumeric(dgv.Item(Col_cpt, Lig_cpt).Value) Then
                            ExcelApp.ActiveSheet.cells(Lig_cpt + 2, Col_cpt + 1).value = CDbl(dgv.Item(Col_cpt, Lig_cpt).Value)
                        Else
                            ExcelApp.ActiveSheet.cells(Lig_cpt + 2, Col_cpt + 1).value = dgv.Item(Col_cpt, Lig_cpt).Value
                        End If
                    Next
                Next
            Catch ex As Exception
            End Try
        End Sub
    End Class
End Namespace