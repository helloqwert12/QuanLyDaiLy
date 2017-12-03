Imports DTO.QuanLyDaiLyDTO
Imports DAL.QuanLyDaiLyDAL
Namespace QuanLyDaiLyBUS
    Public Class DonViTinhBUS
        'Kiểm tra rỗng
        Public Function IsEmpty(ByVal DonViTinh As DonViTinhDTO) As Boolean
            If (DonViTinh.MaDonViTinh = String.Empty Or
                DonViTinh.TenDonViTinh = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

