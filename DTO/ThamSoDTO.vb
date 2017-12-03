Namespace QuanLyDaiLyDTO
    Public Class ThamSoDTO
#Region "DECLARE"
        Private intSoluongdltoida As Integer
        Private boolApdung As Boolean
#End Region

#Region "METHOD"
        Property SoLuongDLToiDa() As Integer
            Get
                Return intSoluongdltoida
            End Get
            Set(value As Integer)
                intSoluongdltoida = value
            End Set
        End Property
        Property ApDung() As Boolean
            Get
                Return boolApdung
            End Get
            Set(value As Boolean)
                boolApDung = value
            End Set
        End Property
#End Region

    End Class
End Namespace

