Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FlowOutpostMasterDAO
        Inherits BaseDAO

        Public Function GetOutpost(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Title_no As String, ByVal Leave_group_id As String, ByVal Outpost_seq As Integer) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine("SELECT fom.* FROM SYS_Flow_outpost_leave fol  ")
            sql.AppendLine("     INNER JOIN SYS_Flow_outpost_departtitle fod ON fol.Flow_outpost_id=fod.Flow_outpost_id ")
            sql.AppendLine("     INNER JOIN SYS_Flow_outpost_master fom ON fod.Flow_outpost_id=fom.Flow_outpost_id ")
            sql.AppendLine("WHERE fol.Orgcode=@Orgcode AND fol.Leave_group_id=@Leave_group_id AND ")
            sql.AppendLine("     fod.Title_no=@Title_no AND fod.Depart_id=@Depart_id  ")

            If Outpost_seq <> 0 Then
                sql.AppendLine(" AND fom.Outpost_seq=@Outpost_seq ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Title_no", SqlDbType.VarChar), _
            New SqlParameter("@Leave_group_id", SqlDbType.VarChar), _
            New SqlParameter("@Outpost_seq", SqlDbType.Int)}

            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Title_no
            params(3).Value = Leave_group_id
            params(4).Value = Outpost_seq
            Return Query(sql.ToString(), params)
        End Function

        Public Function UpdateDataById(id As String, outpostId As String, outpostOrgcode As String, outpostDepartid As String, outpostPosid As String) As Integer
            Dim v As New Dictionary(Of String, Object)
            v.Add("Outpost_id", outpostId)
            v.Add("Outpost_orgcode", outpostOrgcode)
            v.Add("Outpost_departid", outpostDepartid)
            v.Add("Outpost_posid", outpostPosid)

            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return UpdateByExample("SYS_Flow_Outpost_master", v, d)
        End Function

        Public Function GetDataByFlowOutpostID(ByVal fopID As String) As DataTable
            Dim sql As String = ""
            sql = "SELECT * FROM SYS_Flow_outpost_master WHERE Flow_outpost_id=@Flow_outpost_id ORDER BY Outpost_seq"

            Dim params() As SqlParameter = {New SqlParameter("@Flow_outpost_id", fopID)}
            Return Query(sql, params)
        End Function


        Public Function GetDataByFopIDHsID(ByVal fopID As String, ByVal Hoursetting_id As String) As DataTable
            Dim sql As String = String.Empty
            sql = "SELECT * FROM SYS_Flow_outpost_master WHERE Flow_outpost_id=@Flow_outpost_id "

            If Not String.IsNullOrEmpty(Hoursetting_id) Then
                sql &= "AND Hoursetting_id=@Hoursetting_id "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_outpost_id", fopID), _
            New SqlParameter("@Hoursetting_id", Hoursetting_id)}

            Return Query(sql, params)
        End Function


        Public Function InsertData(ByVal fom As FlowOutpostMaster) As Integer
            Dim d As New System.Collections.Generic.Dictionary(Of String, Object)
            d.Add("Orgcode", fom.Orgcode)
            d.Add("Flow_outpost_id", fom.Flow_outpost_id)
            d.Add("Outpost_id", fom.Outpost_id)
            d.Add("Outpost_Orgcode", fom.Outpost_orgcode)
            d.Add("Outpost_departid", fom.Outpost_departid)
            d.Add("Outpost_posid", fom.Outpost_posid)
            d.Add("Relate_flag", fom.Relate_flag)
            d.Add("Outpost_seq", fom.Outpost_seq)
            d.Add("Hoursetting_id", fom.Hoursetting_id)
            d.Add("Group_id", fom.Group_id)
            d.Add("Group_seq", fom.Group_seq)
            d.Add("Group_type", fom.Group_type)
            d.Add("Mail_flag", fom.Mail_flag)
            d.Add("Unit_flag", fom.Unit_flag)
            d.Add("Change_userid", fom.Change_userid)
            d.Add("Change_date", fom.Change_date)

            Return InsertByExample("SYS_Flow_outpost_master", d)
        End Function


        Public Function DeleteDataByfopID(ByVal Flow_outpost_id As String) As Integer
            Dim sql As String = ""
            sql = "DELETE FROM SYS_Flow_outpost_master WHERE Flow_outpost_id=@Flow_outpost_id "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_outpost_id", Flow_outpost_id)}

            Return Execute(sql, params)
        End Function


        Public Function GetData(ByVal orgcode As String, ByVal departId As String, ByVal target As String, ByVal targetType As String, ByVal formId As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select distinct a.* from SYS_Flow_outpost_master a with(nolock) ")
            sql.AppendLine(" inner join SYS_Flow_outpost_form b with(nolock) on a.flow_outpost_id=b.flow_outpost_id ")
            sql.AppendLine(" inner join SYS_Flow_outpost_target c with(nolock) on b.flow_outpost_id=c.flow_outpost_id ")
            sql.AppendLine(" where c.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and c.depart_id=@departId ")
            End If

            sql.AppendLine(" and c.target=@target and c.target_Type=@targetType and b.form_id=@formId ")
            sql.AppendLine(" order by a.outpost_seq ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@target", target), _
            New SqlParameter("@targetType", targetType), _
            New SqlParameter("@formId", formId)}

            Return Query(sql.ToString(), params)
        End Function

    End Class
End Namespace