Imports DTO.QuanLyDaiLyDTO
Imports DAL.QuanLyDaiLyDAL
Namespace QuanLyDaiLyBUS
    Public Class QuanBUS
        'Kiểm tra rỗng
        Public Function IsEmpty(ByVal Quan As QuanDTO) As Boolean
            If (Quan.MaQuan = String.Empty Or
                Quan.TenQuan = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

