Imports System.Data.SqlClient
Imports System.Data.DataSet
Public Class Xemsanpham_PS03027
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=phucnlvps03027.mssql.somee.com;packet size=4096;user id=phucnlvps03027_SQLLogin_1;pwd=s3p639p8me;data source=phucnlvps03027.mssql.somee.com;persist security info=False;initial catalog=phucnlvps03027"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnXemall_Click(sender As Object, e As EventArgs) Handles btnXemall.Click
        Dim hienthi As New Class1
        dgvXemsp.DataSource = hienthi.Loadsanpham.Tables(0)
    End Sub

    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim timkiem As SqlDataAdapter = New SqlDataAdapter("select SANPHAMps03027.MASP as 'Mã sản phẩm',SANPHAMps03027.TENSP as 'Tên sản phẩm', LOAISANPHAMps03027.MALOAI as 'Mã Loại', LOAISANPHAMps03027.TENLOAI as 'Tên Loại',SANPHAMps03027.SOLUONG as 'Số lượng' from SANPHAMps03027 inner join LOAISANPHAMps03027 on SANPHAMps03027.MASP = LOAISANPHAMps03027.MASP where SANPHAMps03027.MASP ='" & txtMASP.Text & "' ", connect)
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                db.Clear()
                dgvXemsp.DataSource = Nothing
                timkiem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvXemsp.DataSource = db.DefaultView
                    txtMASP.Text = Nothing
                Else
                    MessageBox.Show("Không tìm được")
                    txtMASP.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
        Me.Close()
    End Sub

    Private Sub Xemsanpham_PS03027_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class