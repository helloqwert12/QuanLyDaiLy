'Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports System.Windows.Forms
Imports System.Data.Odbc
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Namespace QuanLyDaiLyDAL
    Public Class Export
        Public Shared Sub ExportExcel(ByVal dgv As DataGridView)
            'Hiện bảng Excel sau khi nhấn Export (chưa save)
            Dim ExcelApp As Object
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
        Public Shared Sub ExportPDF(ByVal dgv As DataGridView, ByVal _titleName As String)
            'Save first
            Dim SaveFileDialog1 As New SaveFileDialog
            Dim _temp = ""
            SaveFileDialog1.FileName = ""
            SaveFileDialog1.Filter = "PDF (*.pdf)|*.pdf"

            If (SaveFileDialog1.ShowDialog = DialogResult.OK) Then
                _temp = SaveFileDialog1.FileName
            End If


            Dim Paragraph As New Paragraph ' declaration for new paragraph
            Dim PdfFile As New Document(PageSize.A4, 40, 40, 40, 20) ' set pdf page size

            Dim Write As PdfWriter = PdfWriter.GetInstance(PdfFile, New FileStream(_temp, FileMode.Create))
            PdfFile.Open()

            ' declaration font type
            Dim pTitle As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
            Dim pTable As New Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

            'Insert title into Pdf File
            Paragraph = New Paragraph(New Chunk(_titleName, pTitle))
            Paragraph.Alignment = Element.ALIGN_CENTER
            Paragraph.SpacingAfter = 5.0F

            ' set and add page with current setting
            PdfFile.Add(Paragraph)

            ' create data into table       
            Dim PdfTable As New PdfPTable(dgv.Columns.Count)

            ' setting width of table
            PdfTable.TotalWidth = 500.0F
            PdfTable.LockedWidth = True

            Dim widths(0 To dgv.Columns.Count - 1) As Single
            For i As Integer = 0 To dgv.Columns.Count - 1
                widths(i) = 1.0F
            Next

            PdfTable.SetWidths(widths)
            PdfTable.HorizontalAlignment = 0
            PdfTable.SpacingBefore = 5.0F

            ' declaration pdf cells
            Dim PdfCell As PdfPCell = New PdfPCell

            ' create pdf header
            For i As Integer = 0 To dgv.Columns.Count - 1
                PdfCell = New PdfPCell(New Phrase(New Chunk(dgv.Columns(i).HeaderText, pTable)))
                ' alignment header table
                PdfCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                ' add cells into pdf table
                PdfTable.AddCell(PdfCell)
            Next

            ' add data into pdf table
            For i As Integer = 0 To dgv.Rows.Count - 2
                For j As Integer = 0 To dgv.Columns.Count - 1
                    PdfCell = New PdfPCell(New Phrase(dgv(j, i).Value.ToString(), pTable))
                    PdfTable.HorizontalAlignment = PdfPCell.ALIGN_LEFT
                    PdfTable.AddCell(PdfCell)
                Next
            Next

            ' add pdf table into pdf document
            PdfFile.Add(PdfTable)
            PdfFile.Close()

            MessageBox.Show("Xuất file PDF thành công", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace