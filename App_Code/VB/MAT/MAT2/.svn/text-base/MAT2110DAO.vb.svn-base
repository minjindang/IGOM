Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSCPLM.Logic
    Public Class MAT2110DAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Function getPrintData(orgCode As String, yearMonth As String) As DataTable

            Dim strSQL As New System.Text.StringBuilder
            strSQL.Append("SELECT b.Material_id, " & vbCrLf)
            strSQL.Append("       b.Material_name, " & vbCrLf)
            strSQL.Append("       b.Unit, " & vbCrLf)
            strSQL.Append("       a.MAccu_remain, " & vbCrLf)
            strSQL.Append("       a.MAccu_in, " & vbCrLf)
            strSQL.Append("       a.MAccu_out, " & vbCrLf)
            strSQL.Append("       a.MAccu_modify, " & vbCrLf)
            strSQL.Append("       a.MAccu_store " & vbCrLf)
            strSQL.Append("FROM   MAT_MaterialAccu_det a " & vbCrLf)
            strSQL.Append("       LEFT JOIN dbo.MAT_Material_main b " & vbCrLf)
            strSQL.Append("              ON a.MAccu_mtrid = b.Material_id " & vbCrLf)
            strSQL.Append("WHERE  a.OrgCode = @OrgCode " & vbCrLf)
            strSQL.Append("       AND MAccu_yyymm = @MAccu_yyymm ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@MAccu_yyymm", yearMonth), _
            New SqlParameter("@orgCode", orgCode)}
            Return Query(strSQL.ToString(), ps)

        End Function
    End Class
End Namespace
