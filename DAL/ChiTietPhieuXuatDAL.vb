Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class ChiTietPhieuXuatDAL
        'Lay du lieu
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("CHITIETPHIEUXUAT")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("CHITIETPHIEUXUAT", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("CHITIETPHIEUXUAT", thuoctinh, dieukien)
        End Function
        'Them du lieu vao bang
        Public Function ThemDuLieu(ByVal CTPhieuXuat As ChiTietPhieuXuatDTO) As Boolean
            If KetNoiDAL.ThemDuLieu("CHITIETPHIEUXUAT", CTPhieuXuat.MaCTPhieuXuat, CTPhieuXuat.MaPhieuXuat,
                                    CTPhieuXuat.MaMatHang, CTPhieuXuat.MaDonViTinh, CTPhieuXuat.SoLuongXuat,
                                    CTPhieuXuat.DonGia, CTPhieuXuat.ThanhTien) Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("CHITIETPHIEUXUAT", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                         ByVal giatridieukien As String,
                                         ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("CHITIETPHIEUXUAT", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function
    End Class
End Namespace