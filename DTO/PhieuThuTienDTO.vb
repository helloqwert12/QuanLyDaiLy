Namespace QuanLyDaiLyDTO
    Public Class PhieuThuTienDTO
#Region "DECLARE"
        Private strMaphieuthu As String
        Private strMadaily As String
        Private dateNgaythutien As Date
        Private longSotienthu As Long
#End Region

#Region "METHOD"
        Property MaPhieuThu() As String
            Get
                Return strMaphieuthu
            End Get
            Set(value As String)
                strMaphieuthu = value
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
        Property NgayThuTien() As Date
            Get
                Return dateNgaythutien
            End Get
            Set(value As Date)
                dateNgaythutien = value
            End Set
        End Property
        Property SoTienThu() As Long
            Get
                Return longSotienthu
            End Get
            Set(value As Long)
                longSotienthu = value
            End Set
        End Property
#End Region

    End Class
End Namespace

