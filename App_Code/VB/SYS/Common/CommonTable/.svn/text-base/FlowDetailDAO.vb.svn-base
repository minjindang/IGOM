Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text

Namespace SYS.Logic
    Public Class FlowDetailDAO
        Inherits BaseDAO

        Public Function GetDataByFlow_id(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine("SELECT f.* ")
            StrSQL.AppendLine("FROM SYS_Flow_detail f WITH(NOLOCK)")
            StrSQL.AppendLine("WHERE Flow_id=@Flow_id AND Orgcode=@Orgcode ORDER BY Agree_time")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetDataByQuery(ByVal Flow_id As String, ByVal Orgcode As String, ByVal Last_id As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select * from SYS_Flow_detail ")
            sql.AppendLine(" where Flow_id=@Flow_id and Orgcode=@Orgcode and Last_id=@Last_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Last_id", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            params(2).Value = Last_id
            Return Query(sql.ToString, params)
        End Function


        Public Function GetMaxDataByFlow_id(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM SYS_Flow_detail fd ")
            StrSQL.Append("     WHERE fd.Flow_id=@Flow_id AND fd.Orgcode=@Orgcode AND Last_pass='1' ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function InsertData(ByVal fd As FlowDetail) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", fd.Orgcode)
            d.Add("Flow_id", fd.FlowId)
            d.Add("Last_orgcode", fd.LastOrgcode)
            d.Add("Last_departid", fd.LastDepartid)
            d.Add("Last_posid", fd.LastPosid)
            d.Add("Last_idcard", fd.LastIdcard)
            d.Add("Last_name", fd.LastName)
            d.Add("Agree_time", fd.AgreeTime)
            d.Add("Agree_flag", fd.AgreeFlag)
            d.Add("Agree_step", fd.AgreeStep)
            d.Add("Replace_orgcode", fd.ReplaceOrgcode)
            d.Add("Replace_departid", fd.ReplaceDepartid)
            d.Add("Replace_posid", fd.ReplacePosid)
            d.Add("Replace_idcard", fd.ReplaceIdcard)
            d.Add("Replace_name", fd.ReplaceName)
            d.Add("Deputy_flag", fd.DeputyFlag)
            d.Add("Resend_flag", fd.ResendFlag)
            d.Add("Comment", fd.Comment)
            If fd.LastDate.HasValue Then
                d.Add("Last_date", fd.LastDate)
                d.Add("Last_pass", fd.LastPass)
            End If
            d.Add("Change_userid", fd.ChangeUserid)
            d.Add("Change_date", fd.ChangeDate)

            Return InsertByExample("SYS_Flow_detail", d)
        End Function

        Public Function DeleteData(ByVal Orgcode As String, ByVal Flow_id As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine("delete from SYS_flow_detail where flow_id=@flow_id and orgcode=@orgcode ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            Return Execute(sql.ToString(), params)
        End Function

        Public Function UpdateFlowDetailForFeb(ByVal Flow_id As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal Last_id As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update SYS_flow_detail ")
            sql.AppendLine(" set Last_date=null, Last_pass=0 ")
            sql.AppendLine(" where ")
            sql.AppendLine("    flow_id=@flow_id ")
            sql.AppendLine("    and orgcode=@orgcode ")
            sql.AppendLine("    and depart_id=@depart_id ")
            sql.AppendLine("    and last_id=@last_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@depart_id", SqlDbType.VarChar), _
            New SqlParameter("@last_id", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            params(2).Value = Depart_id
            params(3).Value = Last_id
            Return Execute(sql.ToString(), params)
        End Function

        Public Function CancelLastData(ByVal Orgcode As String, ByVal Flow_id As String) As Object
            Dim sql As New StringBuilder()
            sql.AppendLine(" update SYS_Flow_detail set Last_date='', Last_pass='0' ")
            sql.AppendLine(" where Flow_id=@Flow_id and Orgcode=@Orgcode ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            Return Execute(sql.ToString(), params)
        End Function

        ''' <summary>
        ''' 修改重送
        ''' </summary>
        ''' <param name="Flow_id"></param>
        ''' <param name="Orgcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateLastData(ByVal Orgcode As String, ByVal Flow_id As String) As Boolean
            Dim sql As New StringBuilder()
            sql.AppendLine(" update SYS_Flow_detail set Last_date='', Last_pass='0', Agree_flag=null,Agree_time=null ")
            sql.AppendLine(" where Flow_id=@Flow_id and Orgcode=@Orgcode ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", SqlDbType.VarChar), _
            New SqlParameter("@orgcode", SqlDbType.VarChar)}
            params(0).Value = Flow_id
            params(1).Value = Orgcode
            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetDataByAgreeStep(orgcode As String, flowId As String, agreeStep As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)
            d.Add("Agree_step", agreeStep)

            Return GetDataByExample("SYS_Flow_detail", d)
        End Function
    End Class
End Namespace
