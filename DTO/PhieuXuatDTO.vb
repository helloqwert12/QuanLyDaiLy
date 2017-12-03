Namespace QuanLyDaiLyDTO
    Public Class PhieuXuatDTO
#Region "DECLARE"
        Private strMaphieuxuat As String
        Private strMadaily As String
        Private dateNgaylapphieu As Date
        Private longTongtrigia As Long
#End Region

#Region "METHOD"
        Property MaPhieuXuat() As String
            Get
                Return strMaphieuxuat
            End Get
            Set(value As String)
                strMaphieuxuat = value
            End Set
        End Property
        Property MaDaiLy() As String
            Get
                Return strMadaily
            End Get
            Set(value As String)
                strMadaily = value
            End Set
        End Property
        Property NgayLapPhieu() As Date
            Get
                Return dateNgaylapphieu
            End Get
            Set(value As Date)
                dateNgaylapphieu = value
            End Set
        End Property
        Property TongTriGia() As Long
            Get
                Return longTongtrigia
            End Get
            Set(value As Long)
                longTongtrigia = value
            End Set
        End Property
#End Region

    End Class
End Namespace

