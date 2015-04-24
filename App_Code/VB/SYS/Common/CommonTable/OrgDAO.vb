Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SYS.Logic
    Public Class OrgDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub


        Public Function updateData(ByVal o As Org, ByVal UOrgcode As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" UPDATE SYS_Org SET ")
            sql.AppendLine(" Orgcode=@Orgcode, Orgcode_name=@Orgcode_name, Orgcode_shortname=@Orgcode_shortname, Logo_file=@Logo_file, Change_userid=@Change_userid, change_date=@change_date ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine(" Orgcode=@UOrgcode  ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode_name", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode_shortname", SqlDbType.VarChar), _
            New SqlParameter("@Logo_file", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar), _
            New SqlParameter("@Change_date", SqlDbType.DateTime), _
            New SqlParameter("@UOrgcode", SqlDbType.VarChar)}
            params(0).Value = o.Orgcode
            params(1).Value = o.OrgcodeName
            params(2).Value = o.OrgcodeShortname
            params(3).Value = o.ChangeUserid
            params(4).Value = o.LogoFile
            params(5).Value = Now
            params(6).Value = UOrgcode

            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetDataByQuery(orgcode As String, orgcodeName As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from SYS_Org where 1=1 ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and orgcode = @orgcode ")
            End If
            If Not String.IsNullOrEmpty(orgcodeName) Then
                sql.AppendLine(" and orgcode_name like @orgcodeName ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@orgcodeName", "%" + orgcodeName + "%")}
            Return Query(sql.ToString(), param)
        End Function

        Public Function deleteByOrgcode(orgcode As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" delete from SYS_Org where orgcode = @orgcode ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode)}
            Return Execute(sql.ToString(), param)
        End Function
    End Class
End Namespace