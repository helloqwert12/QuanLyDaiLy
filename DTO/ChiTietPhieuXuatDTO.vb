Namespace QuanLyDaiLyDTO
    Public Class ChiTietPhieuXuatDTO
#Region "DECLARE"
        Private strMactphieuxuat As String
        Private strMaphieuxuat As String
        Private strMamathang As String
        Private strMadonvitinh As String
        Private intSoluongxuat As Integer
        Private longDongia As Long
        Private longThanhtien As Long
#End Region

#Region "METHOD"
        Property MaCTPhieuXuat() As String
            Get
                Return strMactphieuxuat
            End Get
            Set(value As String)
                strMactphieuxuat = value
            End Set
        End Property
        Property MaPhieuXuat() As String
            Get
                Return strMaphieuxuat
            End Get
            Set(value As String)
                strMaphieuxuat = value
            End Set
        End Property
        Property MaMatHang() As String
            Get
                Return strMamathang
            End Get
            Set(value As String)
                strMamathang = value
            End Set
        End Property
        Property MaDonViTinh() As String
            Get
                Return strMadonvitinh
            End Get
            Set(value As String)
                strMadonvitinh = value
            End Set
        End Property
        Property SoLuongXuat() As Integer
            Get
                Return intSoluongxuat
            End Get
            Set(value As Integer)
                intSoluongxuat = value
            End Set
        End Property
        Property DonGia() As Long
            Get
                Return longDongia
            End Get
            Set(value As Long)
                longDongia = value
            End Set
        End Property
        Property ThanhTien() As Long
            Get
                Return longThanhtien
            End Get
            Set(value As Long)
                longThanhtien = value
            End Set
        End Property
#End Region

    End Class
End Namespace

