Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class QuanDAL
        'Lay du lieu
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("QUAN")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("QUAN", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("QUAN", thuoctinh, dieukien)
        End Function
        'Them du lieu
        Public Function ThemDuLieu(Quan As QuanDTO) As Boolean
            Dim success = KetNoiDAL.ThemDuLieu("QUAN", Quan.MaQuan, Quan.TenQuan)
            If success Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("QUAN", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("QUAN", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function
    End Class
End Namespace

