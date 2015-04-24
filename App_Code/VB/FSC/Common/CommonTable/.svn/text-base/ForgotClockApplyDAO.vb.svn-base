Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections.Generic
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class ForgotClockApplyDAO
        Inherits BaseDAO

        ''' <summary>
        ''' 取得資料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByFlow_id(ByVal Flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("select * from FSC_Forgot_clock_apply where Flow_id=@Flow_id ")
            Dim param As SqlParameter = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            param.Value = Flow_id
            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetCountByYear(ByVal Apply_id As String, ByVal Year As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine(" select COUNT(*) from FSC_Forgot_clock_apply fca inner join SYS_flow f on fca.flow_id=f.flow_id ")
            StrSQL.AppendLine(" where fca.Apply_idcard=@Apply_id AND SUBSTRING(fca.Forgot_date,1,3)=@Year and f.case_status in (0, 1, 2) ")
            'StrSQL.AppendLine(" group by fca.Forgot_date ")
            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Apply_id", SqlDbType.VarChar)
            params(0).Value = Apply_id
            params(1) = New SqlParameter("@Year", SqlDbType.VarChar)
            params(1).Value = Year
            Return Scalar(StrSQL.ToString(), params)
        End Function

        Public Function GetCountByMonth(ByVal Apply_id As String, ByVal Month As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine(" select COUNT(*) from FSC_Forgot_clock_apply fca inner join SYS_flow f on fca.flow_id=f.flow_id ")
            StrSQL.AppendLine(" where fca.Apply_idcard=@Apply_id AND SUBSTRING(fca.Forgot_date,4,2)=@Month and f.case_status in (0, 1, 2) ")
            'StrSQL.AppendLine(" group by fca.Forgot_date ")
            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Apply_id", SqlDbType.VarChar)
            params(0).Value = Apply_id
            params(1) = New SqlParameter("@Month", SqlDbType.VarChar)
            params(1).Value = Month
            Return Scalar(StrSQL.ToString(), params)
        End Function

        Public Function InsertData(ByVal fca As ForgotClockApply) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", fca.Orgcode)
            d.Add("Flow_id", fca.Flow_id)
            d.Add("Depart_id", fca.Depart_id)
            d.Add("Apply_idcard", fca.Apply_idcard)
            d.Add("Apply_posid", fca.Apply_posid)
            d.Add("Apply_name", fca.Apply_Name)
            d.Add("Forgot_date", fca.Forgot_Date)
            d.Add("Forgot_time", fca.Forgot_time)
            d.Add("Card_type", fca.Card_type)
            d.Add("Reason", fca.Reason)
            d.Add("Case_status", fca.Case_status)
            d.Add("Change_userid", fca.Change_userid)
            d.Add("Change_date", fca.Change_date)
            Return InsertByExample("FSC_Forgot_clock_apply", d)
        End Function

        Public Function UpdateData(ByVal fca As ForgotClockApply) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Depart_id", fca.Depart_id)
            d.Add("Apply_idcard", fca.Apply_idcard)
            d.Add("Apply_posid", fca.Apply_posid)
            d.Add("Apply_name", fca.Apply_name)
            d.Add("Forgot_date", fca.Forgot_date)
            d.Add("Forgot_time", fca.Forgot_time)
            d.Add("Card_type", fca.Card_type)
            d.Add("Reason", fca.Reason)
            d.Add("Case_status", fca.Case_status)
            d.Add("Change_userid", fca.Change_userid)
            d.Add("Change_date", fca.Change_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", fca.Orgcode)
            cd.Add("Flow_id", fca.Flow_id)

            Return UpdateByExample("FSC_Forgot_clock_apply", d, cd)
        End Function

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)
            Return GetDataByExample("FSC_Forgot_clock_apply", d)
        End Function

        Public Function getData(ByVal Apply_idcard As String, ByVal forgot_date As String, ByVal card_type As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from FSC_Forgot_clock_apply a ")
            sql.AppendLine(" inner join sys_flow f on a.flow_id=f.flow_id ")
            sql.AppendLine(" where a.Apply_idcard=@Apply_idcard ")
            sql.AppendLine(" and a.forgot_date=@forgot_date ")
            sql.AppendLine(" and a.card_type=@card_type ")
            sql.AppendLine(" and f.case_status in (0, 1, 2) ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Apply_idcard", SqlDbType.VarChar)
            params(0).Value = Apply_idcard
            params(1) = New SqlParameter("@forgot_date", SqlDbType.VarChar)
            params(1).Value = forgot_date
            params(2) = New SqlParameter("@card_type", SqlDbType.VarChar)
            params(2).Value = card_type

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
