﻿Imports System.Data.SqlClient
Imports System.Data
Public Class Xemkhachhang_PS03027
    Dim db As New DataTable
    Dim chuoiketnoi As String = "workstation id=phucnlvps03027.mssql.somee.com;packet size=4096;user id=phucnlvps03027_SQLLogin_1;pwd=s3p639p8me;data source=phucnlvps03027.mssql.somee.com;persist security info=False;initial catalog=phucnlvps03027"
    Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
    Private Sub btnXem_Click(sender As Object, e As EventArgs) Handles btnXem.Click
        Dim connect As SqlConnection = New SqlConnection(chuoiketnoi)
        connect.Open()
        Dim xem As SqlDataAdapter = New SqlDataAdapter("select MAKH as 'Mã KH' ,TENKH as 'Tên Khách Hàng', DIACHI as 'Địa chỉ', SDT as 'SĐT', EMAIL from KHACHHANGps03027 where MAKH='" & txtMAKH.Text & "'", connect)
        Try
            If txtMAKH.Text = "" Then
                MessageBox.Show("Bạn cần nhập MAKH", "Nhập thiếu", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)

            Else
                db.Clear()
                dgvXemkh.DataSource = Nothing
                xem.Fill(db)
                If db.Rows.Count > 0 Then
                    dgvXemkh.DataSource = db.DefaultView
                    txtMAKH.Text = Nothing
                Else
                    MessageBox.Show("Không tìm thấy")
                    txtMAKH.Text = Nothing
                End If
            End If
            connect.Close()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub btnXemall_Click(sender As Object, e As EventArgs) Handles btnXemall.Click
        Dim hienthi As New Class1
        dgvXemkh.DataSource = hienthi.Loadkhachang.Tables(0)
    End Sub

    Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
        Me.Close()
    End Sub

    Private Sub Xemkhachhang_PS03027_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtMAKH_TextChanged(sender As Object, e As EventArgs) Handles txtMAKH.TextChanged

    End Sub
End Class