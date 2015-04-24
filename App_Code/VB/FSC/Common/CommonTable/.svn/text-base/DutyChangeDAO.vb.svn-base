Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class DutyChangeDAO
        Inherits BaseDAO

        Public Sub New()
        End Sub

        Public Function getNotSendData() As DataTable
            Dim sql As String = " select *, "
            sql &= " (select top 1 Name from FSC_Schedule s where s.orgcode=dc.Apply_Orgcode and s.Schedule_id=dc.Schedule_id) as Schedule_Name, "
            sql &= " (select top 1 Name from FSC_Schedule s where s.orgcode=dc.Shift_Orgcode and s.Schedule_id=dc.Shift_Schedule_id) as Shift_Schedule_Name "
            sql &= " from FSC_Duty_change dc where Duty_Sendtype = '0' "

            Return Query(sql)
        End Function

        Public Function getDataByShift_Dutydate(ByVal Original_Dutydate As String, ByVal Shift_Dutydate As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select dc.* from FSC_Duty_change dc ")
            sql.AppendLine(" inner join sys_flow f on f.flow_id = dc.flow_id and f.case_status in (0,1,2) and f.Last_pass=0 ")
            sql.AppendLine(" where ((Original_Dutydate=@Original_Dutydate and Original_Dutydate <>'') or Shift_Dutydate=@Shift_Dutydate ")
            sql.AppendLine(" or Original_Dutydate=@Shift_Dutydate or Shift_Dutydate=@Original_Dutydate )")
            sql.AppendLine(" and Duty_Sendtype='1' ")

            Dim para(1) As SqlParameter
            para(0) = New SqlParameter("@Original_Dutydate", SqlDbType.VarChar)
            para(0).Value = Original_Dutydate
            para(1) = New SqlParameter("@Shift_Dutydate", SqlDbType.VarChar)
            para(1).Value = Shift_Dutydate

            Return Query(sql.ToString, para)
        End Function
    End Class
End Namespace
