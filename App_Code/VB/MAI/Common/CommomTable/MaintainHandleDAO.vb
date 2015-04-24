Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainHandleDAO
        Inherits BaseDAO

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_handle", d)
        End Function

        Public Function InsertData(handle As MaintainHandle) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", handle.Main_id)
            d.Add("Orgcode", handle.Orgcode)
            d.Add("Flow_id", handle.Flow_id)
            d.Add("Confirm_idcard", handle.Confirm_idcard)
            d.Add("Confirm_ext", handle.Confirm_ext)
            d.Add("Problem_analyze", handle.Problem_analyze)
            d.Add("Predict_date", handle.Predict_date)
            d.Add("Handle_idcard", handle.Handle_idcard)
            d.Add("Handle_name", handle.Handle_name)
            d.Add("Handle_ext", handle.Handle_ext)
            d.Add("Operate_type", handle.Operate_type)
            d.Add("Service_type", handle.Service_type)
            d.Add("Status_type", handle.Status_type)
            d.Add("Handle_type", handle.Handle_type)
            d.Add("Handle_desc", handle.Handle_desc)
            d.Add("Handle_sdate", handle.Handle_sdate)
            d.Add("Handle_stime", handle.Handle_stime)
            d.Add("Handle_edate", handle.Handle_edate)
            d.Add("Handle_etime", handle.Handle_etime)
            d.Add("Handle_hours", handle.Handle_hours)
            d.Add("Reply_date", handle.Reply_date)
            d.Add("Case_status", handle.Case_status)
            d.Add("Comment", handle.Comment)
            d.Add("Maintain_code", handle.Maintain_code)
            d.Add("Change_userid", handle.Change_userid)
            d.Add("Change_date", handle.Change_date)

            Return InsertByExample("MAI_Maintain_handle", d)
        End Function

        Public Function UpdateData(handle As MaintainHandle) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Confirm_idcard", handle.Confirm_idcard)
            d.Add("Confirm_name", handle.Confirm_name)
            d.Add("Confirm_ext", handle.Confirm_ext)
            d.Add("Problem_analyze", handle.Problem_analyze)
            d.Add("Predict_date", handle.Predict_date)
            d.Add("Handle_idcard", handle.Handle_idcard)
            d.Add("Handle_name", handle.Handle_name)
            d.Add("Handle_ext", handle.Handle_ext)
            d.Add("Operate_type", handle.Operate_type)
            d.Add("Service_type", handle.Service_type)
            d.Add("Status_type", handle.Status_type)
            d.Add("Handle_type", handle.Handle_type)
            d.Add("Handle_desc", handle.Handle_desc)
            d.Add("Handle_sdate", handle.Handle_sdate)
            d.Add("Handle_stime", handle.Handle_stime)
            d.Add("Handle_edate", handle.Handle_edate)
            d.Add("Handle_etime", handle.Handle_etime)
            d.Add("Handle_hours", handle.Handle_hours)
            d.Add("Reply_date", handle.Reply_date)
            d.Add("Case_status", handle.Case_status)
            d.Add("Comment", handle.Comment)
            d.Add("Maintain_code", handle.Maintain_code)
            d.Add("Change_userid", handle.Change_userid)
            d.Add("Change_date", handle.Change_date)

            Dim c As New Dictionary(Of String, Object)
            c.Add("id", handle.Id)

            Return UpdateByExample("MAI_Maintain_handle", d, c)
        End Function

    End Class
End Namespace