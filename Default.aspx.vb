﻿Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.VisualBasic
 
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim strSQLConn As SqlConnection
    Dim strDataAdapter As SqlDataAdapter
    Dim strCmd As SqlCommand
    Dim dt As DataTable

    Public Sub Connect()
        strSQLConn = New SqlConnection("Server=e999680e-694b-4afe-8465-a53600d2b292.sqlserver.sequelizer.com;Database=dbe999680e694b4afe8465a53600d2b292;User ID=ilquyjjkyafakuae;Password=P6ntqkUCKCUj8AaB8e42UDNpcRKgYUwC2cdbuYeiNinDJoAEaSbt4hyjq7rFHNMX;")
    End Sub
    Public Sub ExecuteSQL(ByVal pstrSQL As String)
        
Label1.Text = pstrSQL
            Connect()
            strSQLConn.Open()
            strCmd = New SqlCommand(pstrSQL, strSQLConn)
            strCmd.ExecuteNonQuery()
            strSQLConn.Close()

 
       
    End Sub
    Public Function GetDataTable(ByVal pstrSQL As String) As DataTable
       
            Connect()
            strSQLConn.Open()
            dt = New DataTable()
            strCmd = New SqlCommand(pstrSQL, strSQLConn)
            strDataAdapter = New SqlDataAdapter(strCmd)
            strDataAdapter.Fill(dt)
            strSQLConn.Close()
            Return dt
       
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ExecuteSQL("insert into tbl_stud (name,age,email,pass) values('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')")
        Label1.Text = "Insert Successfully"

        disp()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            disp()
        End If

    End Sub

    Public Sub disp()
        GridView1.DataSource = GetDataTable("select * from tbl_stud")
        GridView1.DataBind()

    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ExecuteSQL("update tbl_stud set name = '" + TextBox2.Text + "',age = '" + TextBox3.Text + "',email ='" + TextBox4.Text + "', pass = '" + TextBox5.Text + "' where Id ='" + TextBox1.Text + "'")
        Label1.Text = "Update Successfully"
        disp()
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ExecuteSQL("delete from tbl_stud where Id ='" + TextBox1.Text + "'")
        Label1.Text = "Delete Successfully"
        disp()
    End Sub
End Class
