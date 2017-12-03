Imports System
Imports System.Data.SqlClient
Imports System.Data
Imports System.Windows.Forms
Namespace QuanLyDaiLyDAL
    Public Class KetNoiDAL
#Region "Khai bao Connection"
        Public Shared connet As SqlConnection
#End Region

#Region "Cac ham ket noi"
        'Khoi tao ket noi
        Public Shared Sub TaoKetNoi()
            Dim startPath As String = Application.StartupPath + "\QuanLyDaiLy.mdf"
            'connet = New SqlConnection("Data Source=(localdb)\MINHQUAN-s;Initial Catalog=QuanLyDaiLy;Integrated Security=True")
            connet = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + startPath + ";Integrated Security=True;Connect Timeout=30")
            'connet = New SqlClient.SqlConnection("Data Source = GEFORCELIBRA \ SQLEXPRESS;Initial Catalog=QuanLyDaiLy;Integrated Security=True")
            'connet = New SqlConnection("Data Source = (local);Initial Catalog=QuanLyDaiLy;Integrated Security=True")
        End Sub
        'Mo ket noi den CSDL
        Public Shared Function MoKetNoi() As Boolean
            Try
                If Not DangMo() Then
                    connet.Open()
                    Return True
                End If
            Catch ex As Exception
                MessageBox.Show("Kết nối đến CSDL không thành công, vui lòng thử lại", "THÔNG BÁO")
                Return False
            End Try
        End Function
        'Ngat ket noi voi CSDL
        Public Shared Function NgatKetNoi() As Boolean
            Try
                If (connet.State = ConnectionState.Open) Then
                    connet.Close()
                    Return True
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function
        'Kiem tra xem ket noi co dang mo khong
        Public Shared Function DangMo() As Boolean
            If (connet.State = ConnectionState.Open) Then
                Return True
            End If
            Return False
        End Function
        'Lay du lieu tu mot bang
        Public Shared Function LayDuLieu(ByVal tenbang As String) As DataTable
            Dim dtTable As DataTable
            Dim adapter As SqlDataAdapter
            Dim dtSet As DataSet
            dtTable = New DataTable()
            dtSet = New DataSet()
            Try
                adapter = New SqlDataAdapter("SELECT * FROM " + tenbang, connet)
                adapter.Fill(dtSet)
                dtTable = dtSet.Tables(0)
            Catch ex As Exception
                MessageBox.Show("Không tải được dữ liệu", "THÔNG BÁO")
            End Try
            Return dtTable
        End Function

        'Lay du lieu tu mot thuoc tinh voi dieu kien cho truoc (neu co)
        Public Shared Function LayDuLieu(ByVal tenbang As String,
                                         ByVal thuoctinh As String,
                                         Optional ByVal dieukien As String = "") As DataTable
            Dim dtTable As DataTable
            Dim adapter As SqlDataAdapter
            Dim dtSet As DataSet
            dtTable = New DataTable()
            dtSet = New DataSet()
            Try
                If (dieukien = "") Then
                    adapter = New SqlDataAdapter("SELECT " + thuoctinh + " FROM " + tenbang, connet)
                Else
                    adapter = New SqlDataAdapter("SELECT " + thuoctinh + " FROM " + tenbang + " WHERE " + dieukien, connet)
                End If
                adapter.Fill(dtSet)
                dtTable = dtSet.Tables(0)
            Catch ex As Exception
                MessageBox.Show("Không tải được dữ liệu", "THÔNG BÁO")
            End Try
            Return dtTable
        End Function
        'Lay du lieu tu bang voi dieu kien cho truoc
        Public Shared Function LayDuLieu(ByVal tenbang As String,
                                         ByVal dieukien As String) As DataTable
            Dim dtTable As DataTable
            Dim adapter As SqlDataAdapter
            Dim dtSet As DataSet
            dtTable = New DataTable()
            dtSet = New DataSet()
            Try
                adapter = New SqlDataAdapter("SELECT * FROM " + tenbang + " WHERE " + dieukien, connet)
                adapter.Fill(dtSet)
                dtTable = dtSet.Tables(0)
            Catch ex As Exception
                MessageBox.Show("Không tải được dữ liệu", "THÔNG BÁO")
            End Try
            Return dtTable
        End Function

        Public Shared Function LayDuLieu(ByVal tenbang As String, ByVal ParamArray thuoctinh As String()) As DataTable
            Dim dtTable As DataTable
            Dim adapter As SqlDataAdapter
            Dim dtSet As DataSet
            dtTable = New DataTable()
            dtSet = New DataSet()
            Try
                Dim conStr As String = "SELECT "
                For Each i As String In thuoctinh
                    conStr += i + ","
                Next
                conStr = conStr.Remove(conStr.Length - 1, 1)
                conStr += " FROM " + tenbang
                adapter = New SqlDataAdapter(conStr, connet)
                adapter.Fill(dtSet)
                dtTable = dtSet.Tables(0)
            Catch ex As Exception
                MessageBox.Show("Không tải được dữ liệu", "THÔNG BÁO")
            End Try
            Return dtTable
        End Function
        Public Shared Function LayDuLieu(ByVal tenbang As String, ByVal codieukien As Boolean, ByVal dieukien As String, ParamArray tenthuoctinh As String())
            Dim dtTable As DataTable
            Dim adapter As SqlDataAdapter
            Dim dtSet As DataSet
            dtTable = New DataTable()
            dtSet = New DataSet()
            Try
                Dim conStr As String = "SELECT "
                For Each i As String In tenthuoctinh
                    conStr += i + ","
                Next
                conStr = conStr.Remove(conStr.Length - 1, 1)
                conStr += " FROM " + tenbang
                If codieukien Then
                    conStr += " WHERE " + dieukien
                End If
                adapter = New SqlDataAdapter(conStr, connet)
                adapter.Fill(dtSet)
                dtTable = dtSet.Tables(0)
            Catch ex As Exception
                MessageBox.Show("Không tải được dữ liệu", "THÔNG BÁO")
            End Try
            Return dtTable
        End Function

        'Them du lieu vao bang
        Public Shared Function ThemDuLieu(ByVal tenbang As String,
                                          ByVal ParamArray gtthuoctinh As String()) As Boolean
            Dim str As String = ("INSERT INTO " + tenbang + " VALUES(N'")

            For Each i As String In gtthuoctinh
                str &= (i + "',N'")
            Next
            str = str.Remove(str.Length - 3, 3)
            str &= " )"

            Dim sqlCmd As SqlCommand
            sqlCmd = New SqlCommand(str, connet)
            Try
                sqlCmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        'Xoa du lieu tu bang voi dieu kien cho truoc
        Public Shared Function XoaDuLieu(ByVal tenbang As String,
                                         ByVal tendieukien As String,
                                         ByVal giatridieukien As String) As Boolean
            Dim str As String = ("DELETE FROM " + tenbang + " WHERE " + tendieukien + " = " + " '" + giatridieukien + "'")

            Dim sqlCmd As SqlCommand
            sqlCmd = New SqlCommand(str, connet)
            Try
                If sqlCmd.ExecuteNonQuery() = 0 Then
                    MessageBox.Show("Không tìm thấy dữ liệu cần xóa. Vui lòng kiểm tra lại", "THÔNG BÁO")
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        'Xoa toan bo du lieu tu bang
        Public Shared Function XoaDuLieu(ByVal tenbang As String) As Boolean
            Dim str As String = ("DELETE FROM " + tenbang)

            Dim sqlCmd As SqlCommand
            sqlCmd = New SqlCommand(str, connet)
            Try
                If sqlCmd.ExecuteNonQuery() = 0 Then
                    MessageBox.Show("Không tìm thấy dữ liệu cần xóa. Vui lòng kiểm tra lại", "THÔNG BÁO")
                End If
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        'Cap nhat du lieu moi voi dieu kien cho truoc
        'Chua test
        Public Shared Function CapNhatDuLieu(ByVal tenbang As String,
                                             ByVal tendieukien As String,
                                             ByVal giatridieukien As String,
                                             ByVal ParamArray thuoctinhvagt As String()) As Boolean
            Dim str As String = ("UPDATE " + tenbang + " SET ")
            For i = 0 To thuoctinhvagt.Length - 1
                If i Mod 2 = 0 Then
                    str &= (thuoctinhvagt(i) + "=")
                Else
                    str &= ("'" + thuoctinhvagt(i) + "',")
                End If
            Next
            str = str.Remove(str.Length - 1, 1)
            str &= (" WHERE " + tendieukien + " ='" + giatridieukien + "'")
            Dim sqlCmd As SqlCommand
            sqlCmd = New SqlCommand(str, connet)
            Try
                sqlCmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        'Generate key
        Public Shared Function TaoKhoaChinh(ByVal tenbang As String, ByVal tenthuoctinhkhoa As String, ByVal prefix As String) As String
            'Load du lieu khoa tu bang
            KetNoiDAL.MoKetNoi()
            Dim data As DataTable = KetNoiDAL.LayDuLieu(tenbang, tenthuoctinhkhoa, "")
            Dim khoa As String = String.Empty
            'Tao khoa
            '  Neu chua co du lieu
            If data.Rows.Count = 0 Then
                If prefix.Length = 1 Then
                    khoa = prefix + "001"
                End If
                If prefix.Length = 2 Then
                    khoa = prefix + "01"
                End If
                If prefix.Length = 3 Then
                    khoa = prefix + "1"
                End If
            Else
                '  Neu da co du lieu
                Dim sokhoa(data.Rows.Count) As Integer

                For i = 0 To data.Rows.Count - 1
                    Dim str As String
                    str = data.Rows(i)(0)
                    str = str.Remove(0, prefix.Length) 'Loai bo prefix
                    sokhoa(i) = Integer.Parse(str)
                Next
                ' Tim so lon nhat trong khoa
                Dim max As Integer = sokhoa(0)
                For Each i As Integer In sokhoa
                    If max < i Then
                        max = i
                    End If
                Next
                Dim soconlai As Integer = 3 - max.ToString().Length
                If soconlai = 2 Then
                    khoa = (prefix + "00" + (max + 1).ToString())
                End If
                If soconlai = 1 Then
                    khoa = (prefix + "0" + (max + 1).ToString())
                End If
                If soconlai = 0 Then
                    khoa = (prefix + (max + 1).ToString())
                End If

            End If
            Return khoa
        End Function

        'Ham chuyen ma thanh ten
        Public Shared Function ChuyenMaThanhTen(ByVal tenbang As String, ByVal thuoctinhma As String, ByVal giatri As String, ByVal thuoctinhten As String) As String
            KetNoiDAL.MoKetNoi()
            Dim data As DataTable = KetNoiDAL.LayDuLieu(tenbang, thuoctinhten, thuoctinhma + "=N'" + giatri + "'")
            Dim str As String = data.Rows(0)(0)
            Return str
        End Function

        'Hàm chuyển tên thành mã
        Public Shared Function ChuyenTenThanhMa(ByVal tenbang As String, ByVal thuoctinhten As String, ByVal giatri As String, ByVal thuoctinhma As String) As String
            KetNoiDAL.MoKetNoi()
            Dim data As DataTable = KetNoiDAL.LayDuLieu(tenbang, thuoctinhma, thuoctinhten + "=N'" + giatri + "'")
            Dim str As String = data.Rows(0)(0)
            Return str
        End Function
        'Ham lay du lieu cho viec Auto Complete
        Public Shared Sub LayDuLieuAutoComplete(ByVal dataCollection As AutoCompleteStringCollection, ByVal tenbang As String,
                                         ByVal thuoctinh As String)
            Dim adapter As New SqlDataAdapter("SELECT DISTINCT " + thuoctinh + " FROM " + tenbang, connet)
            Dim ds As New DataSet()
            Try
                adapter.Fill(ds)
                For Each row As DataRow In ds.Tables(0).Rows
                    dataCollection.Add(row(0).ToString())
                Next
            Catch ex As Exception
                MessageBox.Show("Không tải được dữ liệu", "THÔNG BÁO")
            End Try
        End Sub
#End Region

    End Class
End Namespace

