Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainEroomDetDAO
        Inherits BaseDAO

        Public Function InsertData(rdet As MaintainEroomDet) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", rdet.Main_id)
            d.Add("Orgcode", rdet.Orgcode)
            d.Add("Flow_id", rdet.Flow_id)
            d.Add("Company", rdet.Company)
            d.Add("User_name", rdet.User_name)
            d.Add("Phone", rdet.Phone)
            d.Add("Change_userid", rdet.Change_userid)
            d.Add("Change_date", rdet.Change_date)

            Return InsertByExample("MAI_Maintain_eroom_det", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_eroom_det", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_eroom_det", d)
        End Function
    End Class
End Namespace