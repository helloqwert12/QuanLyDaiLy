Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class PhieuXuatDAL
        'Lay du lieu
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("PHIEUXUAT")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("PHIEUXUAT", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("PHIEUXUAT", thuoctinh, dieukien)
        End Function
        'Them du lieu vao bang
        Public Function ThemDuLieu(ByVal PhieuXuat As PhieuXuatDTO) As Boolean
            If KetNoiDAL.ThemDuLieu("PHIEUXUAT", PhieuXuat.MaPhieuXuat, PhieuXuat.MaDaiLy, PhieuXuat.NgayLapPhieu, PhieuXuat.TongTriGia) Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("PHIEUXUAT", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("PHIEUXUAT", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace
