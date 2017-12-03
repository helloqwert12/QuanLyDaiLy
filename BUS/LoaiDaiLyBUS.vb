Imports DTO.QuanLyDaiLyDTO
Imports DAL.QuanLyDaiLyDAL
Namespace QuanLyDaiLyBUS
    Public Class LoaiDaiLyBUS
        'Kiểm tra nợ đại lý có vượt quá nợ tối đa cho phép hay không
        Public Function KiemTraNoToiDa(ByVal MaLoaiDaiLy As String, ByVal MaDaiLy As String) As Boolean
            Dim notoida As Long = KetNoiDAL.LayDuLieu("LOAIDAILY", "NoToiDa", "MaLoaiDaiLy = '" + MaLoaiDaiLy + "'")(0)(0)
            Dim nohientai As Long = KetNoiDAL.LayDuLieu("DAILY", "NoDaiLy", "MaDaiLy = '" + MaDaiLy + "'")(0)(0)
            If (nohientai > notoida) Then
                Return False
            Else
                Return True
            End If
        End Function
        'Kiểm tra nợ tối đa có nhỏ hơn 0 hay không
        Public Function IsValid_NoToiDa(LoaiDaiLy As LoaiDaiLyDTO) As Boolean
            If LoaiDaiLy.NoToiDa < 0 Then
                Return False
            Else
                Return True
            End If
        End Function
        'Kiểm tra rỗng
        Public Function IsEmpty(ByVal LoaiDaiLy As LoaiDaiLyDTO) As Boolean
            If (LoaiDaiLy.MaLoaiDaiLy = String.Empty Or
                LoaiDaiLy.TenLoaiDaiLy = String.Empty) Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class
End Namespace

