Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FlowOutpostTargetDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetTargetByQuery(ByVal Flow_outpost_id As String, ByVal orgcode As String, ByVal Depart_id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select * ")
            sql.AppendLine(" from SYS_Flow_outpost_target fot ")
            sql.AppendLine(" where fot.flow_outpost_id=@flow_outpost_id ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and fot.orgcode=@orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (fot.depart_id=@depart_id or fot.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If

            sql.AppendLine(" order by orgcode, depart_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_outpost_Id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@depart_id", SqlDbType.VarChar)}
            params(0).Value = Flow_outpost_id
            params(1).Value = orgcode
            params(2).Value = Depart_id

            Return Query(sql.ToString, params)
        End Function

        Public Function InsertData(ByVal flowOutpostId As String, ByVal orgcode As String, ByVal departId As String, ByVal target As String, ByVal targetType As String, ByVal changeUserid As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_outpost_id", flowOutpostId)
            d.Add("Orgcode", orgcode)
            d.Add("Depart_id", departId)
            d.Add("Target", target)
            d.Add("Target_type", targetType)
            d.Add("Change_userid", changeUserid)
            d.Add("Change_date", Now)

            Return insertByExample("SYS_Flow_outpost_target", d)
        End Function

        Public Function DeleteData(ByVal Flow_outpost_id As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_outpost_id", Flow_outpost_id)
            Return deleteByExample("SYS_Flow_outpost_target", d)
        End Function


        Public Function DeleteData(ByVal orgcode As String, ByVal departId As String, ByVal Flow_outpost_id As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            If Not String.IsNullOrEmpty(departId) Then
                d.Add("Depart_id", departId)
            End If
            d.Add("Flow_outpost_id", Flow_outpost_id)
            Return DeleteByExample("SYS_Flow_outpost_target", d)
        End Function
    End Class
End Namespace