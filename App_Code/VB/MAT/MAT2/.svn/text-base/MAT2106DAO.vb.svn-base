Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MAT2106DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function MAT2106selectDepartName(ByVal Orgcode As String) As DataTable
            Dim strSql As String = "select DISTINCT Depart_id,Depart_name from FSCORG "
            If Not String.IsNullOrEmpty(Orgcode) Then
                strSql &= " where  Orgcode = @Orgcode "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode)}
            Return Query(strSql, ps)
        End Function

        Public Function MAT2106selectUerName(ByVal Orgcode As String) As DataTable
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
            strSql &= "  inner join Member m on b.User_id=m.Personnel_id "
            strSql &= "  inner join FSCorg f on b.Unit_Code=f.Depart_id "
            strSql &= "  inner join MAT_Material_main c on a.Material_id=c.Material_id "
            strSql &= "  inner join SACODE s on b.Form_type=s.CODE_NO "
            strSql &= "  where 1=1 "
            strSql &= "  AND s.CODE_SYS='014' and s.CODE_TYPE='001 '"
            If Not String.IsNullOrEmpty(ucType) Then
                strSql &= " AND  b.form_type = @ucType "
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                strSql &= " and (f.Depart_id = @Depart_id or f.Depart_id  in (select depart_id from fsc_org where parent_depart_id=@Depart_id) "
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


    End Class
End Namespace




