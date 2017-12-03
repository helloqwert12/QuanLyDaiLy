Namespace QuanLyDaiLyDTO
    Public Class QuanDTO
#Region "DECLARE"
        Private strMaquan As String
        Private strTenquan As String
#End Region

#Region "METHOD"
        Property MaQuan() As String
            Get
                Return strMaquan
            End Get
            Set(value As String)
                strMaquan = value
            End Set
        End Property
        Property TenQuan() As String
            Get
                Return strTenquan
            End Get
            Set(value As String)
                strTenquan = value
            End Set
        End Property
#End Region

    End Class
End Namespace

