Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class InventoryMainDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Function GetMemoStar(orgCode As String) As DataTable
            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.AppendLine(" SELECT * ")
            sqlStr.AppendLine(" FROM   MAT_Inventory_main a ")
            sqlStr.AppendLine(" WHERE  a.OrgCode = @OrgCode AND a.InvMemo like '%*%' ")
            sqlStr.AppendLine(" and InvStart_date <= @SYSDATE and Expected_date >= @SYSDATE and InvEnd_date is null ")

            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgcode", orgCode), _
                New SqlParameter("@SYSDATE", DateTimeInfo.GetRocDate(Now))}

            Return Query(sqlStr.ToString(), params)

        End Function

        Public Sub Insert(ps() As SqlParameter)
            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("INSERT INTO MAT_Inventory_main " & vbCrLf)
            sqlStr.Append("            ([OrgCode], " & vbCrLf)
            sqlStr.Append("             [InvStart_date], " & vbCrLf)
            sqlStr.Append("             [Expected_date], " & vbCrLf)
            sqlStr.Append("             [InvEnd_date], " & vbCrLf)
            sqlStr.Append("             [InvMemo], " & vbCrLf)
            sqlStr.Append("             [InvClosing_ym], " & vbCrLf)
            sqlStr.Append("             [ModUser_id], " & vbCrLf)
            sqlStr.Append("             [Mod_date]) " & vbCrLf)
            sqlStr.Append("VALUES      (@OrgCode, " & vbCrLf)
            sqlStr.Append("             @InvStart_date, " & vbCrLf)
            sqlStr.Append("             @Expected_date, " & vbCrLf)
            sqlStr.Append("             @InvEnd_date, " & vbCrLf)
            sqlStr.Append("             @InvMemo, " & vbCrLf)
            sqlStr.Append("             @InvClosing_ym, " & vbCrLf)
            sqlStr.Append("             @ModUser_id, " & vbCrLf)
            sqlStr.Append("             @Mod_date) ")

            Execute(sqlStr.ToString(), ps)
        End Sub

        Public Sub Update(ps() As SqlParameter)
            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("Update MAT_Inventory_main SET " & vbCrLf)
            sqlStr.Append("             [InvStart_date]=@InvStart_date, " & vbCrLf)
            sqlStr.Append("             [Expected_date]=@Expected_date, " & vbCrLf)
            sqlStr.Append("             [InvEnd_date]=@InvEnd_date, " & vbCrLf)
            sqlStr.Append("             [InvMemo]=@InvMemo, " & vbCrLf)
            sqlStr.Append("             [InvClosing_ym]=@InvClosing_ym, " & vbCrLf)
            sqlStr.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
            sqlStr.Append("             [Mod_date]=@Mod_date " & vbCrLf)
            sqlStr.Append("  WHERE    OrgCode=@OrgCode " & vbCrLf)
            sqlStr.Append("  AND      Inventory_id=@Inventory_id " & vbCrLf)

            Execute(sqlStr.ToString(), ps)
        End Sub

    End Class
End Namespace