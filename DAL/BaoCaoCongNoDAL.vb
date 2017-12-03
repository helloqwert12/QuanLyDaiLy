Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class BaoCaoCongNoDAL
        'Lay du lieu trong bang
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("BAOCAOCONGNO")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("BAOCAOCONGNO", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("BAOCAOCONGNO", thuoctinh, dieukien)
        End Function
        'Them du lieu vao bang
        Public Function ThemDuLieu(Baocaocongno As BaoCaoCongNoDTO) As Boolean
            Dim success = KetNoiDAL.ThemDuLieu("BAOCAOCONGNO", Baocaocongno.MaBaoCaoCongNo, Baocaocongno.MaDaiLy, Baocaocongno.ThoiGian,
                                               Baocaocongno.NoDau, Baocaocongno.PhatSinh, Baocaocongno.NoCuoi)
            If success Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("BAOCAOCONGNO", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("BAOCAOCONGNO", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function
    End Class

End Namespace
