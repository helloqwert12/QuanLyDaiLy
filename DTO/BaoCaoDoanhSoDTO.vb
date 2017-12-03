Namespace QuanLyDaiLyDTO
    Public Class BaoCaoDoanhSoDTO
#Region "DECLARE"
        Private strMabaocaodoanhso As String
        Private strMadaily As String
        Private dateThoiGian As Date
        Private floatTyle As Double
        Private intSophieuxuat As Integer
        Private longTongtrigia As Long
#End Region

#Region "METHOD"
        Property MaBaoCaoDoanhSo() As String
            Get
                Return strMabaocaodoanhso
            End Get
            Set(value As String)
                strMabaocaodoanhso = value
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
        Property ThoiGian() As Date
            Get
                Return dateThoiGian
            End Get
            Set(value As Date)
                dateThoiGian = value
            End Set
        End Property
        Property SoPhieuXuat() As Integer
            Get
                Return intSophieuxuat
            End Get
            Set(value As Integer)
                intSophieuxuat = value
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
        Property TyLe() As Double
            Get
                Return floatTyle
            End Get
            Set(value As Double)
                floatTyle = value
            End Set
        End Property
#End Region

    End Class
End Namespace