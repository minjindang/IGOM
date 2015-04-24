Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class PaperFormDAO
        Inherits BaseDAO

        Public Function InsertData(ByVal pf As PaperForm) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", pf.Orgcode)
            d.Add("Depart_id", pf.DepartId)
            d.Add("Flow_id", pf.FlowId)
            d.Add("Id_card", pf.IdCard)
            d.Add("Apply_name", pf.ApplyName)
            d.Add("Apply_date", pf.ApplyDate)
            d.Add("Reason", pf.Reason)
            d.Add("Paper_id", pf.PaperId)
            d.Add("Paper_Name", pf.PaperName)
            d.Add("File_Path", pf.FilePath)
            d.Add("File_Name", pf.FileName)
            d.Add("Change_userid", pf.ChangeUserid)
            d.Add("Change_date", pf.ChangeDate)

            Return InsertByExample("FSC_Paper_form", d)
        End Function

        Public Function UpdateData(ByVal pf As PaperForm) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Depart_id", pf.DepartId)
            d.Add("Id_card", pf.IdCard)
            d.Add("Apply_name", pf.ApplyName)
            d.Add("Apply_date", pf.ApplyDate)
            d.Add("Reason", pf.Reason)
            d.Add("Paper_id", pf.PaperId)
            d.Add("Paper_Name", pf.PaperName)
            d.Add("File_Path", pf.FilePath)
            d.Add("File_Name", pf.FileName)
            d.Add("Change_userid", pf.ChangeUserid)
            d.Add("Change_date", pf.ChangeDate)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", pf.Orgcode)
            cd.Add("Flow_id", pf.FlowId)

            Return UpdateByExample("FSC_Paper_form", d, cd)
        End Function

        Public Function getDataByOrgFid(ByVal pf As PaperForm) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", pf.Orgcode)
            d.Add("Flow_id", pf.FlowId)

            Return GetDataByExample("FSC_Paper_form", d)
        End Function
    End Class
End Namespace