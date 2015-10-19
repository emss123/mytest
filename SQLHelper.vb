Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Module SQLHelper

    Dim strSQLConn As SqlConnection
    Dim strDataAdapter As SqlDataAdapter
    Dim strCmd As SqlCommand
    Dim dt As DataTable

    Public Sub MySub()
        strSQLConn = New SqlConnection("Server=ad9bac96-f2b6-430b-b12a-a53600b9860b.sqlserver.sequelizer.com;Database=dbad9bac96f2b6430bb12aa53600b9860b;User ID=zwhhrolrvhskkmrj;Password=tkAewWe5xmzaiXvGy7iRiFKDofS7TKY8hJEHKfxfWv2CiyEa5jaAu8mVH5YregkU;")
    End Sub

    Public Sub ExecuteSQL(ByVal pstrSQL As String)
        Try
            strSQLConn.Open()
            strCmd = New SqlCommand(pstrSQL)
            strCmd.CommandText = pstrSQL
            strCmd.ExecuteNonQuery()
            strSQLConn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetDataTable(ByVal pstrSQL As String) As DataTable
        Try
            strSQLConn.Open()
            dt = New DataTable()
            strCmd = New SqlCommand(pstrSQL)
            strDataAdapter = New SqlDataAdapter(strCmd)
            strDataAdapter.Fill(dt)
            strSQLConn.Close()
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
