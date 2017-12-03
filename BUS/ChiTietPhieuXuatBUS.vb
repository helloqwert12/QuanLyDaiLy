Imports DTO.QuanLyDaiLyDTO
Imports DAL.QuanLyDaiLyDAL
Namespace QuanLyDaiLyBUS
    Public Class ChiTietPhieuXuatBUS
        'Kiểm tra rỗng
        Public Function IsEmpty(ByVal ChiTietPhieuXuat As ChiTietPhieuXuatDTO, ByVal PhieuXuat As PhieuXuatDTO) As Boolean
            If (ChiTietPhieuXuat.MaDonViTinh = String.Empty Or
                ChiTietPhieuXuat.MaMatHang = String.Empty Or
                ChiTietPhieuXuat.SoLuongXuat = "0" Or
                ChiTietPhieuXuat.DonGia = "0" Or
                PhieuXuat.MaPhieuXuat = String.Empty Or
                PhieuXuat.MaDaiLy = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
        'Kiểm tra số lượng xuất có nhỏ hơn hoặc bằng 0 hay không
        Public Function IsValid_SoLuongXuat(CTPhieuXuat As ChiTietPhieuXuatDTO) As Boolean
            If CTPhieuXuat.SoLuongXuat <= 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        'Kiểm tra đơn giá có nhỏ hơn hoặc bằng 0 hay không
        Public Function IsValid_DonGia(CTPhieXuat As ChiTietPhieuXuatDTO) As Boolean
            If CTPhieXuat.DonGia <= 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        'Kiểm tra thành tiền có nhỏ hơn hoặc bằng 0 hay không
        Public Function IsValid_ThanhTien(CTPhieXuat As ChiTietPhieuXuatDTO) As Boolean
            If CTPhieXuat.ThanhTien <= 0 Then
                Return False
            Else
                Return True
            End If
        End Function
    End Class
End Namespace