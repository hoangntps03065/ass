﻿Imports System.Data.SqlClient
Imports System.Data.DataTable
Public Class Dieuchinhsanpham_PS03027
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=phucnlvps03027.mssql.somee.com;packet size=4096;user id=phucnlvps03027_SQLLogin_1;pwd=s3p639p8me;data source=phucnlvps03027.mssql.somee.com;persist security info=False;initial catalog=phucnlvps03027"
    Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim xem As SqlDataAdapter = New SqlDataAdapter("select SANPHAMps03027.MASP as 'Mã sản phẩm',SANPHAMps03027.TENSP as 'Tên sản phẩm', LOAISANPHAMps03027.MALOAI as 'Mã Loại', LOAISANPHAMps03027.TENLOAI as 'Tên Loại',SANPHAMps03027.SOLUONG as 'Số lượng' from SANPHAMps03027 inner join LOAISANPHAMps03027 on SANPHAMps03027.MASP = LOAISANPHAMps03027.MASP where SANPHAMps03027.MASP='" & txtMASP.Text & "'", connect)
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

            Else
                db.Clear()
                dgvSanpham.DataSource = Nothing
                xem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvSanpham.DataSource = db.DefaultView
                    txtMASP.Text = Nothing

                Else
                    MessageBox.Show("Không tìm thấy")
                    txtMASP.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmCapnhatsanpham_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgvSanpham_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSanpham.CellContentClick
        Dim click As Integer = dgvSanpham.CurrentCell.RowIndex
        txtMASP.Text = dgvSanpham.Item(0, click).Value
        txtTENSP.Text = dgvSanpham.Item(1, click).Value
        txtMALOAI.Text = dgvSanpham.Item(2, click).Value
        txtTENLOAI.Text = dgvSanpham.Item(3, click).Value
        txtSOLUONG.Text = dgvSanpham.Item(4, click).Value
    End Sub
    'sự kiện làm mới
    Private Sub LoadData()
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim load As SqlDataAdapter = New SqlDataAdapter("select SANPHAMps03027.MASP as 'Mã sản phẩm',SANPHAMps03027.TENSP as 'Tên sản phẩm', LOAISANPHAMps03027.MALOAI as 'Mã Loại', LOAISANPHAMps03027.TENLOAI as 'Tên Loại',SANPHAMps03027.SOLUONG as 'Số lượng' from SANPHAMps03027 inner join LOAISANPHAMps03027 on SANPHAMps03027.MASP = LOAISANPHAMps03027.MASP", conn)

        'conn.Open()
        load.Fill(db)
        dgvSanpham.DataSource = db.DefaultView
    End Sub
    Private Sub btnCapnhat_Click(sender As Object, e As EventArgs) Handles btnCapnhat.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim updatequery As String = "update SANPHAMps03027 set MASP=@MASP, TENSP=@TENSP, SOLUONG=@SOLUONG where MASP=@MASP update LOAISANPHAMps03027 set MALOAI=@MALOAI, MASP=@MASP, TENLOAI=@TENLOAI where MASP=@MASP"
        Dim addupdate As SqlCommand = New SqlCommand(updatequery, conn)
        conn.Open()
        Try
            txtMASP.Focus()
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMASP.Focus()
                If txtTENSP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTENSP.Focus()
                    If txtMALOAI.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập mã loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtMALOAI.Focus()
                        If txtSOLUONG.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập số lượng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            addupdate.Parameters.AddWithValue("@MASP", txtMASP.Text)
                            addupdate.Parameters.AddWithValue("@TENSP", txtTENSP.Text)
                            addupdate.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                            addupdate.Parameters.AddWithValue("@TENLOAI", txtTENLOAI.Text)
                            addupdate.Parameters.AddWithValue("@SOLUONG", txtSOLUONG.Text)
                            addupdate.ExecuteNonQuery()
                            conn.Close() 'đóng kết nối
                            MessageBox.Show("Cập nhật thành công")
                            txtMASP.Text = Nothing
                            txtTENSP.Text = Nothing
                            txtMALOAI.Text = Nothing
                            txtTENLOAI.Text = Nothing
                            txtSOLUONG.Text = Nothing
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Không thành công", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        'Sau khi cập nhật xong sẽ tự làm mới lại bảng
        db.Clear()
        dgvSanpham.DataSource = db
        dgvSanpham.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
        Dim delquery As String = "delete from SANPHAMps03027 where MASP=@MASP delete from LOAISANPHAMps03027 where MASP=@MASP"
        Dim delete As SqlCommand = New SqlCommand(delquery, conn)
        Dim resulft As DialogResult = MessageBox.Show("Bạn muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        conn.Open()
        Try
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn cần nhập mã khách hàng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                txtMASP.Focus()
            Else
                If resulft = Windows.Forms.DialogResult.Yes Then
                    delete.Parameters.AddWithValue("@MASP", txtMASP.Text)
                    delete.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Xóa thành công")
                    'Sau khi xóa thành công, tự động làm mới các khung textbox
                    txtMASP.Text = Nothing
                    txtTENSP.Text = Nothing
                    txtMALOAI.Text = Nothing
                    txtTENLOAI.Text = Nothing
                    txtSOLUONG.Text = Nothing
                    txtMASP.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Nhập đúng mã sản phẩm cần xóa", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        'làm mới bảng
        db.Clear()
        dgvSanpham.DataSource = db
        dgvSanpham.DataSource = Nothing
        LoadData()
    End Sub

    Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
        Dim conn As SqlConnection = New SqlConnection(chuoiketnoi)
        Dim query As String = "insert into SANPHAMps03027 values(@MASP,@TENSP,@SOLUONG) insert into LOAISANPHAMps03027 values(@MALOAI,@MASP,@TENLOAI)"
        Dim save As SqlCommand = New SqlCommand(query, conn)
        conn.Open()
        Try
            txtMASP.Focus()
            If txtMASP.Text = "" Then
                MessageBox.Show("Bạn chưa nhập mã sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Else
                txtMASP.Focus()
                If txtTENSP.Text = "" Then
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                Else
                    txtTENSP.Focus()
                    If txtMALOAI.Text = "" Then
                        MessageBox.Show("Bạn chưa nhập mã loại", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                    Else
                        txtMALOAI.Focus()
                        If txtSOLUONG.Text = "" Then
                            MessageBox.Show("Bạn chưa nhập số lượng", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
                        Else
                            save.Parameters.AddWithValue("@MASP", txtMASP.Text)
                            save.Parameters.AddWithValue("@TENSP", txtTENSP.Text)
                            save.Parameters.AddWithValue("@MALOAI", txtMALOAI.Text)
                            save.Parameters.AddWithValue("@TENLOAI", txtTENLOAI.Text)
                            save.Parameters.AddWithValue("@SOLUONG", txtSOLUONG.Text)
                            save.ExecuteNonQuery()
                            MessageBox.Show("Lưu thành công")
                            'Sau khi nhập thành công, tự động làm mới các khung textbox, combox và date....
                            txtMASP.Text = Nothing
                            txtMALOAI.Text = Nothing
                            txtSOLUONG.Text = Nothing
                            txtTENSP.Text = Nothing
                            txtTENLOAI.Text = Nothing

                        End If
                    End If
                End If
            End If
        Catch ex As Exception  'Ngược lại báo lỗi
            MessageBox.Show("Không được trùng mã sản phẩm", "Lỗi", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
        End Try

        'Làm mới lại bảng sau khi lưu thành công
        Dim refesh As SqlDataAdapter = New SqlDataAdapter("select SANPHAMps03027.MASP as 'Mã sản phẩm',SANPHAMps03027.TENSP as 'Tên sản phẩm', LOAISANPHAMps03027.MALOAI as 'Mã Loại', LOAISANPHAMps03027.TENLOAI as 'Tên Loại',SANPHAMps03027.SOLUONG as 'Số lượng' from SANPHAMps03027 inner join LOAISANPHAMps03027 on SANPHAMps03027.MASP = LOAISANPHAMps03027.MASP", conn)
        db.Clear()
        refesh.Fill(db)
        dgvSanpham.DataSource = db.DefaultView
    End Sub

    Private Sub btndong_Click(sender As Object, e As EventArgs) Handles btndong.Click
        Me.Close()
    End Sub
End Class