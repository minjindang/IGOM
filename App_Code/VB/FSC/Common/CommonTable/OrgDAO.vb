Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class OrgDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal conn As System.Data.SqlClient.SqlConnection)
            MyBase.New(conn)
        End Sub

        Public Function updateData(ByVal o As Org, ByVal UOrgcode As String, ByVal UDepart_id As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" update FSC_Org set ")
            sql.AppendLine(" Orgcode=@Orgcode, Orgcode_name=@Orgcode_name, Orgcode_shortname=@Orgcode_shortname, ")
            sql.AppendLine(" Depart_id=@Depart_id, Depart_name=@Depart_name, Parent_Depart_id=@Parent_Depart_id, ")
            sql.AppendLine(" Seq=@Seq, Visable_flag=@Visable_flag, Change_userid=@Change_userid, change_date=@change_date, ")
            sql.AppendLine(" Depart_Level=@Depart_Level, ChangeCode=@ChangeCode ")
            sql.AppendLine(" where ")
            sql.AppendLine(" Orgcode=@UOrgcode and Depart_id=@UDepart_id ")

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

        Public Function GetOrgocde() As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select Orgcode, Orgcode_name, Orgcode_shortname from FSC_Org ")
            sql.AppendLine(" group by Orgcode, Orgcode_name, Orgcode_shortname ")
            Return Query(sql.ToString())
        End Function

        Public Function GetDataByDid(ByVal orgcode As String, ByVal Depart_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("select * from FSC_Org where Orgcode=@Orgcode and Depart_id = @Depart_id ")


            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@Depart_id", Depart_id)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function GetDataByPdid(ByVal orgcode As String, ByVal parentDepartId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("select * from FSC_Org where Orgcode=@Orgcode ")

            If "" <> parentDepartId Then
                sql.AppendLine(" and Parent_depart_id=@parentDepartId ")
            Else
                sql.AppendLine(" and (Parent_depart_id=@parentDepartId or Parent_depart_id is null ) ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@parentDepartId", parentDepartId)}
            Return Query(sql.ToString(), param)
        End Function


        Public Function GetData(ByVal orgcode As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select Orgcode, Orgcode_name, Orgcode_shortname from FSC_Org ")
            sql.AppendLine(" where Orgcode=@Orgcode ")
            sql.AppendLine(" group by Orgcode, Orgcode_name, Orgcode_shortname ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function GetData(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("select * from FSC_Org where Orgcode=@Orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and Depart_id=@departId ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@departId", departId)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function GetDataWithSubDepart(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("select * from FSC_Org where Orgcode=@Orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (Depart_id=@departId or parent_depart_id =@departId ) and len(Depart_id) = 6 ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@departId", departId)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function GetDataWithSubDepart(ByVal orgcode As String, ByVal departId As String, ByVal Depart_Level As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("select * from FSC_Org where Orgcode=@Orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and (Depart_id=@departId or parent_depart_id =@departId ) and len(Depart_id) = 6 ")
            End If
            If Not String.IsNullOrEmpty(Depart_Level) Then
                sql.AppendLine(" and Depart_Level=@Depart_Level ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@Depart_Level", Depart_Level)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function GetDataByOrgAndParentId(ByVal orgcode As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * from FSC_Org ")
            sql.AppendLine(" where Orgcode=@Orgcode AND Parent_depart_id is Null")

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode)}
            Return Query(sql.ToString(), param)
        End Function

        Public Function getDataWithoutParentId(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("select * from FSC_Org where Orgcode=@Orgcode AND Parent_depart_id is Null ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and substring(Depart_id,1,2) like substring(@departId,1,2) ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@Orgcode", orgcode), _
            New SqlParameter("@departId", departId)}
            Return Query(sql.ToString(), param)
        End Function
    End Class
End Namespace