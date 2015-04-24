Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FlowOutpostFormDAO
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
            sql = "SELECT * FROM SYS_Flow_outpost_form WHERE Flow_outpost_id=@flow_outpost_id"
            Dim param As SqlParameter = New SqlParameter("@flow_outpost_Id", SqlDbType.VarChar)
            param.Value = flowOutpostId
            Return Query(sql, param)
        End Function


        Public Function InsertData(ByVal fom As FlowOutpostForm) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", fom.Orgcode)
            d.Add("Flow_outpost_id", fom.Flow_outpost_id)
            d.Add("Form_id", fom.Form_id)
            d.Add("Change_Userid", fom.Change_userid)
            d.Add("Change_Date", fom.Change_date)
            Return insertByExample("SYS_Flow_outpost_form", d)
        End Function


        Public Function DeleteData(ByVal flowOutpostId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_outpost_id", flowOutpostId)
            Return deleteByExample("SYS_Flow_outpost_form", d)
        End Function

        Public Function GetformIdByQuery(ByVal Flow_outpost_id As String, ByVal orgcode As String, ByVal Depart_id As String) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select distinct fom.* ")
            sql.AppendLine(" from ")
            sql.AppendLine(" SYS_Flow_outpost_form fom ")
            sql.AppendLine(" inner join SYS_Flow_outpost_target fot on fom.Flow_outpost_id=fot.Flow_outpost_id ")
            sql.AppendLine(" where fom.flow_outpost_id=@flow_outpost_id ")
            sql.AppendLine(" and fot.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (fot.depart_id=@depart_id or fot.depart_id in (select depart_id from fsc_org where parent_depart_id=@depart_id)) ")
            End If

            sql.AppendLine(" order by fom.Form_id ")

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
