Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace EMP.Logic
    Public Class OrgDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function updateData(ByVal o As Org, ByVal UOrgcode As String, ByVal UDepart_id As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" UPDATE EMP_Org SET ")
            sql.AppendLine(" Orgcode=@Orgcode, Orgcode_name=@Orgcode_name, Orgcode_shortname=@Orgcode_shortname, ")
            sql.AppendLine(" Depart_id=@Depart_id, Depart_name=@Depart_name, Parent_Depart_id=@Parent_Depart_id, ")
            sql.AppendLine(" Seq=@Seq, Visable_flag=@Visable_flag, Change_userid=@Change_userid, change_date=@change_date, ")
            sql.AppendLine(" Depart_Level=@Depart_Level, ChangeCode=@ChangeCode ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine(" Orgcode=@UOrgcode AND Depart_id=@UDepart_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode_name", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode_shortname", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Depart_name", SqlDbType.VarChar), _
            New SqlParameter("@Parent_Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Seq", SqlDbType.VarChar), _
            New SqlParameter("@Visable_flag", SqlDbType.VarChar), _
            New SqlParameter("@Depart_Level", SqlDbType.VarChar), _
            New SqlParameter("@ChangeCode", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar), _
            New SqlParameter("@Change_date", SqlDbType.DateTime), _
            New SqlParameter("@UOrgcode", SqlDbType.VarChar), _
            New SqlParameter("@UDepart_id", SqlDbType.VarChar)}
            params(0).Value = o.Orgcode
            params(1).Value = o.OrgcodeName
            params(2).Value = o.OrgcodeShortname
            params(3).Value = o.DepartId
            params(4).Value = o.DepartName
            params(5).Value = o.ParentDepartId
            params(6).Value = o.Seq
            params(7).Value = o.VisableFlag
            params(8).Value = o.DepartLevel
            params(9).Value = o.ChangeCode
            params(10).Value = o.ChangeUserid
            params(11).Value = Now
            params(12).Value = UOrgcode
            params(13).Value = UDepart_id

            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetData(ByVal orgcode As String, ByVal parentDepartId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("SELECT *,CASE WHEN Visable_flag='Y' THEN '顯示' WHEN Visable_flag='N' THEN '不顯示' END VisableFlag FROM EMP_Org WITH(NOLOCK) WHERE Orgcode=@Orgcode ")

            If "" <> parentDepartId Then
                sql.AppendLine(" AND Parent_depart_id=@parentDepartId ")
            Else
                sql.AppendLine(" AND (Parent_depart_id=@parentDepartId OR Parent_depart_id IS NULL ) ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@parentDepartId", parentDepartId)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function getDataByDid(ByVal orgcode As String, ByVal depart_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("SELECT *,CASE WHEN Visable_flag='Y' THEN '顯示' WHEN Visable_flag='N' THEN '不顯示' END VisableFlag FROM EMP_Org WITH(NOLOCK) WHERE Orgcode=@Orgcode ")

            If "" <> depart_id Then
                sql.AppendLine(" AND (depart_id=@depart_id OR parent_depart_id=@depart_id) ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@depart_id", depart_id)}
            Return Query(sql.ToString(), param)
        End Function
    End Class
End Namespace