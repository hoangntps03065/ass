Imports System.Data.SqlClient
Imports System.Data
Public Class Class1
    Public Function Loadkhachang() As DataSet
        Dim chuoiketnoi As String = "workstation id=phucnlvps03027.mssql.somee.com;packet size=4096;user id=phucnlvps03027_SQLLogin_1;pwd=s3p639p8me;data source=phucnlvps03027.mssql.somee.com;persist security info=False;initial catalog=phucnlvps03027"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadKH As New SqlDataAdapter("select MAKH as 'Mã KH' ,TENKH as 'Tên Khách Hàng', DIACHI as 'Địa chỉ', SDT as 'SĐT', EMAIL from KHACHHANGps03027", conn)
        Dim db As New DataSet
        conn.Open()
        LoadKH.Fill(db)
        conn.Close()
        Return db
    End Function
    Public Function Loadsanpham() As DataSet
        Dim chuoiketnoi As String = "workstation id=phucnlvps03027.mssql.somee.com;packet size=4096;user id=phucnlvps03027_SQLLogin_1;pwd=s3p639p8me;data source=phucnlvps03027.mssql.somee.com;persist security info=False;initial catalog=phucnlvps03027"
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim LoadSP As New SqlDataAdapter("select SANPHAMps03027.MASP as 'Mã sản phẩm',SANPHAMps03027.TENSP as 'Tên sản phẩm', LOAISANPHAMps03027.MALOAI as 'Mã Loại', LOAISANPHAMps03027.TENLOAI as 'Tên Loại',SANPHAMps03027.SOLUONG as 'Số lượng' from SANPHAMps03027 inner join LOAISANPHAMps03027 on SANPHAMps03027.MASP = LOAISANPHAMps03027.MASP", conn)
        Dim db As New DataSet
        conn.Open()
        LoadSP.Fill(db)
        conn.Close()
        Return db
    End Function
End Class
