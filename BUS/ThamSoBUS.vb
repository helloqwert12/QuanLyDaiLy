Imports DTO.QuanLyDaiLyDTO
Imports DAL.QuanLyDaiLyDAL
Namespace QuanLyDaiLyBUS
    Public Class ThamSoBUS
        'Thay đổi số đại lý tối đa trong quận không được nhỏ hơn số đại lý nhiều nhất của một trong các quận hiện tại
        Public Function KiemTraSoDaiLyToiDa() As Integer
            Dim max As Integer = 0
            Dim count As Integer = 0
            Dim maquan As DataTable = KetNoiDAL.LayDuLieu("QUAN", "MaQuan", "")
            For i = 0 To maquan.Rows.Count - 1
                Dim data As DataTable = KetNoiDAL.LayDuLieu("DAILY", "MaQuan", "")
                For j = 0 To data.Rows.Count - 1
                    If maquan.Rows(i)(0) = data.Rows(j)(0) Then
                        count = count + 1
                    End If
                Next
                If (max < count) Then
                    max = count
                End If
                count = 0
            Next
            Return max
        End Function
        'Kiểm tra xem số lượng đại lý tối đa trong quận có nhỏ hơn 1 không
        Public Function IsValid_SoLuongDLToiDa(SoLuongDLToiDa As Integer) As Boolean
            If SoLuongDLToiDa < 1 Then
                Return False
            Else
                Return True
            End If
        End Function
    End Class
End Namespace

