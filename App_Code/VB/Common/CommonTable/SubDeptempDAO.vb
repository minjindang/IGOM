Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class SubDeptempDAO
        Inherits BaseDAO
        Dim ConnectionString As String = ""
        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function DeleteDataByMember_id(ByVal Member_id As Integer) As String
            Dim StrSQL As String = "delete from Sub_deptemp where Member_id=@Member_id"
            Dim param As SqlParameter = New SqlParameter("@Member_id", SqlDbType.Int)
            param.Value = Member_id
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataByMember_id(ByVal Member_id As Integer) As DataSet
            Dim StrSQL As String = "select * from Sub_deptemp where Member_id=@Member_id"
            Dim param As SqlParameter = New SqlParameter("@Member_id", SqlDbType.Int)
            param.Value = Member_id
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Id_card As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from Sub_deptemp where 1=1 "

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= " and Orgcode=@Orgcode "
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                StrSQL &= " and Id_card=@Id_card "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetOrgcode(ByVal Orgcode As String, ByVal Id_card As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = " select distinct Orgcode, Orgcode_name, Orgcode_shortname, Orgcode_shortname AS OrgcodeName from FSCorg "
            StrSQL &= " where Orgcode in (select Orgcode from Sub_deptemp where Member_id in ( "
            StrSQL &= " select id from member where 1=1 and Quit_job_flag <> 'Y' "

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= " and Orgcode=@Orgcode "
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                StrSQL &= " and Id_card=@Id_card "
            End If

            StrSQL &= ")) or Orgcode=@Orgcode "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetDataByOrgcode(ByVal Orgcode As String, ByVal Id_card As String, ByVal Depart_id As String, ByVal ddlOrgcode As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine(" select *,(select top 1 seq from FSCorg sf where db1.Orgcode=sf.Orgcode and db1.Depart_id=sf.Depart_id and visable_flag='Y') as seq ")
            sql.AppendLine(" from (select Distinct Orgcode_shortname as OrgcodeName, Orgcode_name as LongOrgcodeName, Orgcode_name, ")
            sql.AppendLine("       Orgcode, Depart_id as DepartID, Depart_id, Depart_name as DepartName, Depart_name from FSCorg where visable_flag='Y') as db1 ")
            sql.AppendLine(" where 1=1 ")


            If Not String.IsNullOrEmpty(ddlOrgcode) Then
                sql.AppendLine(" and Orgcode = @ddlOrgcode  ")
            End If

            sql.AppendLine(" and (Orgcode in (select Orgcode from Sub_deptemp where Member_id in ( ")
            sql.AppendLine(" select id from member where 1=1  and Quit_job_flag <> 'Y' ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and Id_card=@Id_card ")
            End If
            sql.AppendLine(" )) or Orgcode=@Orgcode) ")

            sql.AppendLine(" and (Depart_id in (select Depart_id from Sub_deptemp where Member_id in ( ")
            sql.AppendLine(" select id from member where 1=1  and Quit_job_flag <> 'Y' ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and Id_card=@Id_card ")
            End If
            sql.AppendLine(" ) and Orgcode=@ddlOrgcode ) or Depart_id=@Depart_id ) ")

            sql.AppendLine(" order by seq ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@ddlOrgcode", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card
            params(2).Value = Depart_id
            params(3).Value = ddlOrgcode

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)

        End Function

        Public Function GetSub_depart(ByVal Orgcode As String, ByVal Id_card As String, ByVal Depart_id As String, ByVal Sub_Depart_id As String, ByVal ddlOrgcode As String, ByVal ddlDepart_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.Append("SELECT distinct Orgcode, Sub_depart_id, Sub_depart_name FROM FSCOrg ")
            sql.Append("WHERE  Sub_depart_id<>'' ")
            If Not String.IsNullOrEmpty(ddlOrgcode) Then
                sql.Append(" AND Orgcode=@ddlOrgcode ")
            End If
            If Not String.IsNullOrEmpty(ddlDepart_id) Then
                sql.Append(" AND Depart_id=@ddlDepart_id ")
            End If

            sql.AppendLine(" and (Orgcode in (select Orgcode from Sub_deptemp where Member_id in ( ")
            sql.AppendLine(" select id from member where 1=1  and Quit_job_flag <> 'Y' ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and Id_card=@Id_card ")
            End If
            sql.AppendLine(" )) or Orgcode=@Orgcode) ")

            sql.AppendLine(" and (Depart_id in (select Depart_id from Sub_deptemp where Member_id in ( ")
            sql.AppendLine(" select id from member where 1=1  and Quit_job_flag <> 'Y' ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and Id_card=@Id_card ")
            End If
            sql.AppendLine(" ) and Orgcode=@ddlOrgcode ) or Depart_id=@Depart_id ) ")

            'sql.AppendLine(" and (Sub_depart_id in (select Sub_depart_id from Sub_deptemp where Member_id in ( ")
            'sql.AppendLine(" select id from member where 1=1  and Quit_job_flag <> 'Y' ")
            'If Not String.IsNullOrEmpty(Orgcode) Then
            '    sql.AppendLine(" and Orgcode=@Orgcode ")
            'End If
            'If Not String.IsNullOrEmpty(Id_card) Then
            '    sql.AppendLine(" and Id_card=@Id_card ")
            'End If
            'sql.AppendLine(" ) and Depart_id=@ddlDepart_id ) or Sub_depart_id=@Sub_depart_id )")

            sql.Append(" GROUP BY Orgcode, Sub_depart_id, Sub_depart_name ")
            sql.Append(" order by Sub_depart_id ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@ddlOrgcode", SqlDbType.VarChar), _
            New SqlParameter("@ddlDepart_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_Depart_id", SqlDbType.VarChar)}
            params(0).Value = ddlOrgcode
            params(1).Value = ddlDepart_id
            params(2).Value = Orgcode
            params(3).Value = Id_card
            params(4).Value = Depart_id
            params(5).Value = Sub_Depart_id

            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function
    End Class
End Namespace
