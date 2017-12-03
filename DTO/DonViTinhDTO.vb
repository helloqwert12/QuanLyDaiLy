Namespace QuanLyDaiLyDTO
    Public Class DonViTinhDTO
#Region "DECLARE"
        Private strMadonvitinh As String
        Private strTendonvitinh As String
#End Region

#Region "METHOD"
        Property MaDonViTinh() As String
            Get
                Return strMadonvitinh
            End Get
            Set(value As String)
                strMadonvitinh = value
            End Set
        End Property
        Property TenDonViTinh() As String
            Get
                Return strTendonvitinh
            End Get
            Set(value As String)
                strTendonvitinh = value
            End Set
        End Property
#End Region

    End Class
End Namespace

