Imports DTO.QuanLyDaiLyDTO
Namespace QuanLyDaiLyDAL
    Public Class LoaiDaiLyDAL
        'Lay du lieu
        Public Function LayDuLieu() As DataTable
            Return KetNoiDAL.LayDuLieu("LOAIDAILY")
        End Function
        Public Function LayDuLieu(ByVal dieukien As String) As DataTable
            Return KetNoiDAL.LayDuLieu("LOAIDAILY", dieukien)
        End Function
        Public Function LayDuLieu(ByVal thuoctinh As String, Optional ByVal dieukien As String = "") As DataTable
            Return KetNoiDAL.LayDuLieu("LOAIDAILY", thuoctinh, dieukien)
        End Function

        Public Function ThemDuLieu(LoaiDaiLy As LoaiDaiLyDTO) As Boolean
            Dim success = KetNoiDAL.ThemDuLieu("LOAIDAILY", LoaiDaiLy.MaLoaiDaiLy, LoaiDaiLy.TenLoaiDaiLy, LoaiDaiLy.NoToiDa)
            If success Then
                Return True
            End If
            Return False
        End Function
        'Xoa du lieu
        Public Function XoaDuLieu(ByVal tendieukien As String, ByVal giatridieukien As String) As Boolean
            If KetNoiDAL.XoaDuLieu("LOAIDAILY", tendieukien, giatridieukien) Then
                Return True
            End If
            Return False
        End Function
        'Cap nhat du lieu
        Public Function CapNhatDuLieu(ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            If KetNoiDAL.CapNhatDuLieu("LOAIDAILY", tendieukien, giatridieukien, thuoctinhvagt) Then
                Return True
            End If
            Return False
        End Function
    End Class
End Namespace

