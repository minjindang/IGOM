Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class ApplyMaterialDetDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Sub Insert(ByVal Flow_id As String, ByVal Material_id As String, ByVal Apply_cnt As Integer, ByVal Out_cnt As Integer, ByVal Out_date As String, _
                          ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal Orgcode As String)

            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO MAT_ApplyMaterial_det (Flow_id,Material_id, Apply_cnt, Out_cnt,Out_date,Memo,ModUser_id,Mod_date, Orgcode) " & _
                     " VALUES (@Flow_id,@Material_id, @Apply_cnt, @Out_cnt,@Out_date,@Memo,@ModUser_id,@Mod_date, @Orgcode) "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Flow_id", Flow_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Apply_cnt", Apply_cnt), _
            New SqlParameter("@Out_cnt", Out_cnt), _
            New SqlParameter("@Out_date", Out_date), _
            New SqlParameter("@Memo", Memo), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", Orgcode)}
            Execute(StrSQL, ps)

        End Sub

        Public Function GetOne(flow_id As String, orgCode As String, detail_id As String) As DataTable
            Dim StrSQL As String = " SELECT * FROM [MAT_ApplyMaterial_det] where flow_id = @flow_id and OrgCode = @orgCode and details_id = @details_id "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@details_id", detail_id), _
            New SqlParameter("@orgCode", orgCode)}
            Return Query(StrSQL, ps)
        End Function

        Public Function GetByFlow(flow_id As String, orgCode As String) As DataTable
            Dim StrSQL As String = " SELECT * FROM [MAT_ApplyMaterial_det] where flow_id = @flow_id and OrgCode = @orgCode "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@orgCode", orgCode)}
            Return Query(StrSQL, ps)
        End Function

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return Scalar("SELECT COUNT(*) as Count FROM  MAT_ApplyMaterial_det where material_id = @Material_id", New SqlParameter("Material_id", Material_id))
        End Function

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE MAT_ApplyMaterial_det SET Material_id=@newMaterial_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date, Orgcode=@Orgcode WHERE Material_id=@Material_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@newMaterial_id", newMaterial_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", OrgCode)}
            Execute(StrSQL, ps)
        End Sub

        Public Function GetApplyCnt(Material_id As String, User_id As String, Apply_dateS As String, Apply_dateE As String) As Integer

            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.AppendLine("SELECT Isnull(Sum(Isnull(b.Apply_cnt, 0)), 0) ")
            StrSQL.AppendLine("FROM   MAT_ApplyMaterial_main a  ")
            StrSQL.AppendLine("     inner join MAT_ApplyMaterial_det b on a.orgcode=b.orgcode and a.flow_id=b.flow_id ")
            StrSQL.AppendLine("     left outer join sys_flow c on a.orgcode=c.orgcode and a.flow_id=c.flow_id ")
            StrSQL.AppendLine("WHERE  b.Material_id = @Material_id ")
            StrSQL.AppendLine("       AND a.User_id = @User_id ")
            StrSQL.AppendLine("       AND a.Apply_date BETWEEN @Apply_dateS AND @Apply_dateE ")
            StrSQL.AppendLine("       AND c.case_status not in (3,4) ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@User_id", User_id), _
            New SqlParameter("@Apply_dateS", Apply_dateS), _
            New SqlParameter("@Apply_dateE", Apply_dateE)}

            Return Scalar(StrSQL.ToString(), ps)
        End Function

        Public Function GetSumOutCnt(OrgCode As String, YearMonth As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT a .Material_id, " & vbCrLf)
            StrSQL.Append("       b.Unit_Code, " & vbCrLf)
            StrSQL.Append("       a. OrgCode, " & vbCrLf)
            StrSQL.Append("       Sum (a. Out_cnt) Out_cnt " & vbCrLf)
            StrSQL.Append("FROM   MAT_ApplyMaterial_det a " & vbCrLf)
            StrSQL.Append("       LEFT JOIN MAT_ApplyMaterial_main b " & vbCrLf)
            StrSQL.Append("              ON a.Flow_id = b.Flow_id " & vbCrLf)
            StrSQL.Append("WHERE  Substring (a. Out_date, 1, 5) = @Out_date " & vbCrLf)
            StrSQL.Append("       AND a. OrgCode = @OrgCode " & vbCrLf)
            StrSQL.Append("GROUP  BY a. Material_id, " & vbCrLf)
            StrSQL.Append("          b .Unit_Code, " & vbCrLf)
            StrSQL.Append("          a.OrgCode ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Out_date", YearMonth)}
            Return Query(StrSQL.ToString(), ps)
        End Function

        Public Function GetOut_cnt(orgCode As String, yearMonth As String) As DataTable

            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT Material_id, " & vbCrLf)
            StrSQL.Append("       Sum(Out_cnt) Out_cnt " & vbCrLf)
            StrSQL.Append("FROM   MAT_ApplyMaterial_det " & vbCrLf)
            StrSQL.Append("WHERE  Substring (Out_date, 1, 5) = @yearMonth " & vbCrLf)
            StrSQL.Append("       AND OrgCode = @Orgcode " & vbCrLf)
            StrSQL.Append("GROUP  BY Material_id ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@yearMonth", yearMonth), _
            New SqlParameter("@Orgcode", orgCode)}
            Return Query(StrSQL.ToString(), ps)
        End Function

        Public Function SelectDepartName(ByVal Orgcode As String) As DataTable
            Dim strSql As String = "select DISTINCT Depart_id,Depart_name from FSCORG "
            If Not String.IsNullOrEmpty(Orgcode) Then
                strSql &= " where  Orgcode = @Orgcode "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode)}
            Return Query(strSql, ps)
        End Function

        Public Function SelectUerName(ByVal Orgcode As String) As DataTable
            Dim strSql As String = "select Personnel_id,User_name from Member  "
            If Not String.IsNullOrEmpty(Orgcode) Then
                strSql &= " where  Orgcode = @Orgcode "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode)}
            Return Query(strSql, ps)
        End Function

        Public Function MAT2106_Print(ByVal ucType As String, ByVal Depart_id As String, ByVal User_id As String, ByVal OrgCode As String) As DataTable

            Dim strSql As String = "select "
            strSql &= " min(out_date) as Mindate,max(out_date) as Maxdate,"
            strSql &= "  s.CODE_DESC1, b.User_id, m.User_name,  f.Depart_name,a.Flow_id,"
            strSql &= "  a.Material_id,c.Material_name, c.Unit,a.OrgCode,  Out_cnt "
            strSql &= "  from MAT_ApplyMaterial_det a "
            strSql &= "  inner join MAT_ApplyMaterial_main b on a.Flow_id=b.Flow_id and a.OrgCode=b.OrgCode "
            strSql &= "  inner join FSC_Personnel m on b.User_id=m.id_card "
            strSql &= "  inner join FSC_org f on b.OrgCode=f.Orgcode and b.Unit_Code=f.Depart_id "
            strSql &= "  inner join MAT_Material_main c on a.Material_id=c.Material_id "
            strSql &= "  inner join sys_code s on b.Form_type=s.CODE_NO "
            strSql &= "  where 1=1 "
            strSql &= "  AND s.CODE_SYS='014' and s.CODE_TYPE='001 '"
            If Not String.IsNullOrEmpty(ucType) Then
                strSql &= " AND  b.form_type = @ucType "
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                strSql &= " and (f.Depart_id = @Depart_id or f.Depart_id  in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) "
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                strSql &= " AND  b.User_id = @User_id "
            End If
            If Not String.IsNullOrEmpty(OrgCode) Then
                strSql &= " AND  a.OrgCode = @OrgCode "
            End If
            strSql &= "  group by a.Material_id,s.CODE_DESC1,b.User_id,m.User_name,f.Depart_name,a.Flow_id,c.Material_name,c.Unit,a.OrgCode,Out_cnt "

            Dim ps() As SqlParameter = { _
                New SqlParameter("@ucType", ucType), _
                New SqlParameter("@Depart_id", Depart_id), _
                New SqlParameter("@User_id", User_id), _
                New SqlParameter("@OrgCode", OrgCode)}
            Return Query(strSql, ps)

        End Function

        Public Function SelectMaterialName(ByVal tbMaterial_id As String) As DataTable
            Dim strSql = "select distinct  b.Material_name from MAT_ApplyMaterial_det a inner join MAT_Material_main b on a.Material_id=b.Material_id where 1=1 	"
            If Not String.IsNullOrEmpty(tbMaterial_id) Then
                strSql &= " AND  a.Material_id = @tbMaterial_id "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@tbMaterial_id", tbMaterial_id)}
            Return Query(strSql, ps)
        End Function

        Public Function MAT2107_Print(ByVal tbMaterial_id As String, ByVal ddlUser_name As String, ByVal UcDateS As String, _
                      ByVal UcDateE As String, ByVal ddlDepart_id As String, ByVal OrgCode As String) As DataTable
            Dim strSql As String = "select distinct  a.Material_id,c.Material_name,"
            strSql &= "f.Depart_name,a.Flow_id,s.CODE_DESC1,b.User_id,"
            strSql &= " m.User_name, out_date, apply_cnt, c.Unit, Out_cnt  "
            strSql &= "from MAT_ApplyMaterial_det a   "
            strSql &= "inner join MAT_ApplyMaterial_main b on a.Flow_id=b.Flow_id and a.OrgCode=b.OrgCode  "
            strSql &= "inner join FSC_Personnel m on b.User_id=m.id_card   "
            strSql &= "inner join FSC_org f on b.OrgCode=f.Orgcode and b.Unit_Code=f.Depart_id   "
            strSql &= "inner join MAT_Material_main c on a.Material_id=c.Material_id   "
            strSql &= "inner join sys_code s on b.Form_type=s.CODE_NO   "
            strSql &= "where  1=1    "
            strSql &= "and  s.CODE_SYS='014' and s.CODE_TYPE='001'   "
            If Not String.IsNullOrEmpty(tbMaterial_id) Then
                strSql &= " AND a.Material_id = @tbMaterial_id  "
            End If
            If Not String.IsNullOrEmpty(ddlDepart_id) Then
                strSql &= " AND (f.Depart_id = @ddlDepart_id or f.Depart_id  in (select depart_id from fsc_org where parent_depart_id=@ddlDepart_id))  "
            End If
            If Not String.IsNullOrEmpty(ddlUser_name) Then
                strSql &= " AND  b.User_id = @ddlUser_name  "
            End If
            If Not String.IsNullOrEmpty(UcDateS) Then
                strSql &= " AND  out_date >= @UcDateS  "
            End If
            If Not String.IsNullOrEmpty(UcDateE) Then
                strSql &= " AND  out_date <= @UcDateE  "
            End If
            If Not String.IsNullOrEmpty(OrgCode) Then
                strSql &= " AND  a.OrgCode = @OrgCode "
            End If
            strSql &= "order by a.Material_id  "
            Dim ps() As SqlParameter = { _
         New SqlParameter("@tbMaterial_id", tbMaterial_id), _
         New SqlParameter("@ddlDepart_id", ddlDepart_id), _
         New SqlParameter("@ddlUser_name", ddlUser_name), _
          New SqlParameter("@UcDateS", UcDateS), _
          New SqlParameter("@UcDateE", UcDateE), _
         New SqlParameter("@OrgCode", OrgCode)}
            Return Query(strSql, ps)

        End Function


        Public Function DeleteByOrgFid(flow_id As String, orgCode As String) As Integer
            Dim StrSQL As String = " DELETE FROM [MAT_ApplyMaterial_det] where flow_id = @flow_id and OrgCode = @orgCode "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@orgCode", orgCode)}
            Return Execute(StrSQL, ps)
        End Function



        Public Function GetApplyCnt(Material_id As String, Flow_id As String, Orgcode As String) As Integer

            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT Isnull(Sum(Isnull(Apply_cnt, 0)), 0) " & vbCrLf)
            StrSQL.Append("FROM   MAT_ApplyMaterial_det " & vbCrLf)
            StrSQL.Append("WHERE  Material_id = @Material_id " & vbCrLf)
            StrSQL.Append("       AND Flow_id = @Flow_id " & vbCrLf)
            StrSQL.Append("       AND Orgcode = @Orgcode ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Flow_id", Flow_id), _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Scalar(StrSQL.ToString(), ps)
        End Function


        Public Function UpdateOutCnt(orgcode As String, flowId As String, outCnt As String, materialId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            Dim v As New Dictionary(Of String, Object)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)
            d.Add("Material_id", materialId)

            v.Add("Out_cnt", outCnt)
            v.Add("Out_date", DateTimeInfo.GetRocDate(Now))

            Return UpdateByExample("MAT_ApplyMaterial_det", v, d)
        End Function
    End Class

End Namespace
