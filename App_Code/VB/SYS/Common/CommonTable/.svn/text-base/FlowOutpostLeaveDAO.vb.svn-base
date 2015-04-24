Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FlowOutpostLeaveDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' 取得簽核流程關卡檔
        ''' </summary>
        ''' <param name="flowOutpostId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByfopid(ByVal flowOutpostId As String) As DataTable
            Dim sql As String = String.Empty
            sql = "SELECT * FROM SYS_Flow_outpost_leave WHERE Flow_outpost_id=@flow_outpost_id"
            Dim param As SqlParameter = New SqlParameter("@flow_outpost_Id", SqlDbType.VarChar)
            param.Value = flowOutpostId
            Return Query(sql, param)
        End Function


        ''' <summary>
        ''' 新增
        ''' </summary>
        ''' <param name="flowOutpostId"></param>
        ''' <param name="leaveGroupId"></param>
        ''' <param name="changeUserid"></param>
        ''' <param name="changeDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertData(ByVal flowOutpostId As String, ByVal leaveGroupId As String, ByVal changeUserid As String, ByVal changeDate As Date) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_outpost_id", flowOutpostId)
            d.Add("Leave_Group_id", leaveGroupId)
            d.Add("Change_Userid", changeUserid)
            d.Add("Change_Date", changeDate)
            Return insertByExample("SYS_Flow_outpost_leave", d)
        End Function


        Public Function DeleteData(ByVal flowOutpostId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_outpost_id", flowOutpostId)
            Return deleteByExample("SYS_Flow_outpost_leave", d)
        End Function

        Public Function GetLeaveGroupIdByQuery(ByVal Flow_outpost_id As String, ByVal orgcode As String, ByVal Depart_id As String) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select distinct fol.Leave_group_id, lg.Leave_group_name ")
            sql.AppendLine(" from ")
            sql.AppendLine(" SYS_Flow_outpost_master fom ")
            sql.AppendLine(" inner join SYS_Flow_outpost_departtitle fod on fom.flow_outpost_id=fod.flow_outpost_id ")
            sql.AppendLine(" inner join SYS_Flow_outpost_leave fol on fod.Flow_outpost_id=fol.Flow_outpost_id ")
            sql.AppendLine(" inner join SYS_Leave_group lg on fom.orgcode=lg.orgcode and fol.leave_group_id=lg.leave_group_id ")
            sql.AppendLine(" where fom.orgcode=@orgcode and fod.flow_outpost_id=@flow_outpost_id ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and fod.depart_id=@depart_id ")
            End If

            sql.AppendLine(" order by fol.Leave_group_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_outpost_Id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@depart_id", SqlDbType.VarChar)}
            params(0).Value = Flow_outpost_id
            params(1).Value = orgcode
            params(2).Value = Depart_id

            Return Query(sql.ToString, params)
        End Function
    End Class
End Namespace
