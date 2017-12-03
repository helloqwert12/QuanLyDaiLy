Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class MatHangDAL
        'Lay du lieu trong bang
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("MATHANG")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("MATHANG", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("MATHANG", thuoctinh, dieukien)
        End Function
        'Them du lieu vao bang
        Public Function ThemDuLieu(Mathang As MatHangDTO) As Boolean
            Dim success = KetNoiDAL.ThemDuLieu("MATHANG", Mathang.MaMatHang, Mathang.TenMatHang, Mathang.SoLuongTon)
            If success Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("MATHANG", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("MATHANG", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function
    End Class
End Namespace
