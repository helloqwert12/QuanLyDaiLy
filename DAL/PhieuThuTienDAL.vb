Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class PhieuThuTienDAL
        'Lay du lieu trong bang
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("PHIEUTHUTIEN")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("PHIEUTHUTIEN", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("PHIEUTHUTIEN", thuoctinh, dieukien)
        End Function
        'Them du lieu vao bang
        Public Function ThemDuLieu(PhieuThuTien As PhieuThuTienDTO) As Boolean
            Dim success = KetNoiDAL.ThemDuLieu("PHIEUTHUTIEN", PhieuThuTien.MaPhieuThu, PhieuThuTien.MaDaiLy,
                                 PhieuThuTien.NgayThuTien, PhieuThuTien.SoTienThu)
            If success Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("PHIEUTHUTIEN", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("PHIEUTHUTIEN", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function
    End Class

End Namespace
