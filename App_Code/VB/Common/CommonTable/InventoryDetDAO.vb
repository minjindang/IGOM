Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class InventoryDetDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub
        Public Function Delete(ByVal orgcode As String, ByVal Inventory_id As String, ByVal Material_id As String) As Integer
            Dim StrSQL As String = String.Empty
            StrSQL = " DELETE FROM MAT_Inventory_det WHERE  orgcode=@orgcode and Inventory_id=@Inventory_id and Material_id=@Material_id"

            Dim ps() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@Inventory_id", Inventory_id), _
            New SqlParameter("@Material_id", Material_id)}
            Return Execute(StrSQL, ps)
        End Function
        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE MAT_Inventory_det SET Material_id=@newMaterial_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date, Orgcode=@Orgcode WHERE Material_id=@Material_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@newMaterial_id", newMaterial_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", OrgCode)}
            Execute(StrSQL, ps)
        End Sub

        Public Sub Insert(OrgCode As String, Inventory_id As Integer, Material_id As String, Inv_date As String, InvBefore_cnt As Integer, _
                          InvAfter_cnt As Integer, InvModify_cnt As Integer, Diff_desc As String, ModUser_id As String, Mod_date As DateTime)
            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("INSERT INTO MAT_Inventory_det " & vbCrLf)
            sqlStr.Append("            (OrgCode, " & vbCrLf)
            sqlStr.Append("             Inventory_id, " & vbCrLf)
            sqlStr.Append("             Material_id, " & vbCrLf)
            sqlStr.Append("             Inv_date, " & vbCrLf)
            sqlStr.Append("             InvBefore_cnt, " & vbCrLf)
            sqlStr.Append("             InvAfter_cnt, " & vbCrLf)
            sqlStr.Append("             InvModify_cnt, " & vbCrLf)
            sqlStr.Append("             Diff_desc, " & vbCrLf)
            sqlStr.Append("             ModUser_id, " & vbCrLf)
            sqlStr.Append("             Mod_date) " & vbCrLf)
            sqlStr.Append("VALUES      (@OrgCode, " & vbCrLf)
            sqlStr.Append("             @Inventory_id, " & vbCrLf)
            sqlStr.Append("             @Material_id, " & vbCrLf)
            sqlStr.Append("             @Inv_date, " & vbCrLf)
            sqlStr.Append("             @InvBefore_cnt, " & vbCrLf)
            sqlStr.Append("             @InvAfter_cnt, " & vbCrLf)
            sqlStr.Append("             @InvModify_cnt, " & vbCrLf)
            sqlStr.Append("             @Diff_desc, " & vbCrLf)
            sqlStr.Append("             @ModUser_id, " & vbCrLf)
            sqlStr.Append("             @Mod_date) ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Inventory_id", Inventory_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Inv_date", Inv_date), _
            New SqlParameter("@InvBefore_cnt", InvBefore_cnt), _
            New SqlParameter("@InvAfter_cnt", InvAfter_cnt), _
            New SqlParameter("@InvModify_cnt", InvModify_cnt), _
            New SqlParameter("@Diff_desc", Diff_desc), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date)}
            Execute(sqlStr.ToString(), ps)
        End Sub

        Public Sub Update(OrgCode As String, Inventory_id As Integer, Material_id As String, Inv_date As String, InvBefore_cnt As Integer, _
                          InvAfter_cnt As Integer, InvModify_cnt As Integer, Diff_desc As String, ModUser_id As String, Mod_date As DateTime)
            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("UPDATE MAT_Inventory_det SET " & vbCrLf)
            sqlStr.Append("             Inv_date=@Inv_date, " & vbCrLf)
            sqlStr.Append("             InvBefore_cnt=@InvBefore_cnt, " & vbCrLf)
            sqlStr.Append("             InvAfter_cnt=@InvAfter_cnt, " & vbCrLf)
            sqlStr.Append("             InvModify_cnt=@InvModify_cnt, " & vbCrLf)
            sqlStr.Append("             Diff_desc=@Diff_desc, " & vbCrLf)
            sqlStr.Append("             ModUser_id=@ModUser_id, " & vbCrLf)
            sqlStr.Append("             Mod_date=@Mod_date  " & vbCrLf)
            sqlStr.Append(" WHERE       OrgCode=@OrgCode AND Inventory_id=@Inventory_id AND Material_id=@Material_id " & vbCrLf)


            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Inventory_id", Inventory_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Inv_date", Inv_date), _
            New SqlParameter("@InvBefore_cnt", InvBefore_cnt), _
            New SqlParameter("@InvAfter_cnt", InvAfter_cnt), _
            New SqlParameter("@InvModify_cnt", InvModify_cnt), _
            New SqlParameter("@Diff_desc", Diff_desc), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date)}
            Execute(sqlStr.ToString(), ps)
        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return Scalar("SELECT COUNT(*) as Count FROM  MAT_Inventory_det where material_id = @Material_id", New SqlParameter("Material_id", Material_id))
        End Function

        Public Function GetData(Material_id As String, Inv_date As String, orgCode As String, inventory_id As Integer) As DataTable
            Dim sqlStr As New System.Text.StringBuilder
            sqlStr.Append("SELECT * " & vbCrLf)
            sqlStr.Append("FROM   MAT_Inventory_det a " & vbCrLf)
            sqlStr.Append("       LEFT JOIN MAT_Inventory_main b " & vbCrLf)
            sqlStr.Append("              ON a.Inventory_id = b.Inventory_id " & vbCrLf)
            sqlStr.Append("       LEFT JOIN MAT_Material_main c " & vbCrLf)
            sqlStr.Append("              ON a.Material_id = c.Material_id " & vbCrLf)
            sqlStr.Append("WHERE  a.OrgCode = @OrgCode ")

            If Not String.IsNullOrEmpty(Material_id) Then
                sqlStr.Append(" AND  a.Material_id = @Material_id ")
            End If
            If Not String.IsNullOrEmpty(Inv_date) Then
                sqlStr.Append(" AND  a.Inv_date = @Inv_date ")
            End If

            If inventory_id <> 0 Then
                sqlStr.Append(" AND  a.Inventory_id = @Inventory_id ")
            End If


            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Inv_date", Inv_date), _
            New SqlParameter("@Inventory_id", inventory_id), _
            New SqlParameter("@Orgcode", orgCode)}
            Return Query(sqlStr.ToString(), ps)

        End Function

        Public Function GetOut_cnt(orgCode As String, yearMonth As String) As DataTable

            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT Material_id, " & vbCrLf)
            StrSQL.Append("       Sum(InvModify_cnt) Out_cnt " & vbCrLf)
            StrSQL.Append("FROM   MAT_Inventory_det a " & vbCrLf)
            StrSQL.Append("       LEFT JOIN dbo.MAT_Inventory_main b " & vbCrLf)
            StrSQL.Append("              ON a.orgCode = b.OrgCode " & vbCrLf)
            StrSQL.Append("                 AND a.Inventory_id = b.inventory_id " & vbCrLf)
            StrSQL.Append("WHERE  (b.invMemo <> '*' or b.invMemo is null ) " & vbCrLf)
            StrSQL.Append("       AND Substring (Inv_date, 1, 5) = @yearMonth " & vbCrLf)
            StrSQL.Append("       AND a.OrgCode = @OrgCode " & vbCrLf)
            StrSQL.Append("GROUP  BY Material_id ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@yearMonth", yearMonth), _
            New SqlParameter("@Orgcode", orgCode)}
            Return Query(StrSQL.ToString(), ps)
        End Function

        Public Function MAT2202select(ByVal tbMaterial_id1 As String, ByVal tbMaterial_id2 As String, ByVal UcDate1 As String, _
                                      ByVal UcDate2 As String) As DataTable

            'Dim strSql As String = "declare @mindate nvarchar(50) "
            'strSql &= "set @mindate = (select MIN(Inv_date) from MAT_Inventory_det) "
            'strSql &= "declare @maxdate nvarchar(50) "
            'strSql &= "set @maxdate = (select max(Inv_date) from MAT_Inventory_det) "
            Dim strSql As String = "select inv.Material_id,"
            strSql &= "Material_name,"
            strSql &= "(select MIN(Inv_date) from MAT_Inventory_det) as mindate, "
            strSql &= "(select max(Inv_date) from MAT_Inventory_det) as maxdate, "
            strSql &= "InvBefore_cnt,"
            strSql &= "InvAfter_cnt,"
            strSql &= "InvModify_cnt,"
            strSql &= "Diff_desc "
            strSql &= "from  MAT_Inventory_det  inv  inner  join  MAT_Material_main mat  on  inv.Material_id=mat.Material_id  and  inv.OrgCode=mat.OrgCode "
            strSql &= "  where 1=1 "
            If Not String.IsNullOrEmpty(tbMaterial_id1) Then
                strSql &= " AND  inv.Material_id >= @tbMaterial_id1 "
            End If
            If Not String.IsNullOrEmpty(tbMaterial_id2) Then
                strSql &= " AND  inv.Material_id <= @tbMaterial_id2 "
            End If
            If Not String.IsNullOrEmpty(UcDate1) Then
                strSql &= " AND  Inv_date >= @UcDate1 "
            End If
            If Not String.IsNullOrEmpty(UcDate2) Then
                strSql &= " AND  Inv_date <= @UcDate2 "
            End If

            Dim ps() As SqlParameter = { _
                New SqlParameter("@tbMaterial_id1", tbMaterial_id1), _
                New SqlParameter("@tbMaterial_id2", tbMaterial_id2), _
                New SqlParameter("@UcDate1", UcDate1), _
                New SqlParameter("@UcDate2", UcDate2)}
            Return Query(strSql, ps)
        End Function

        Public Function FindMinDate() As DataTable
            Dim strSql As String = "select MIN(Inv_date) as mindate "
            strSql &= "from  Inventory_det  inv  inner  join  MAT_Material_main mat  on  inv.Material_id=mat.Material_id  and  inv.OrgCode=mat.OrgCode "
            Return Query(strSql)
        End Function

    End Class
End Namespace