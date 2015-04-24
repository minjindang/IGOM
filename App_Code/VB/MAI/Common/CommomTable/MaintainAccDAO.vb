Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainAccDAO
        Inherits BaseDAO

        Public Function InsertData(acc As MaintainAcc) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", acc.Main_id)
            d.Add("Orgcode", acc.Orgcode)
            d.Add("Flow_id", acc.Flow_id)
            d.Add("Use_sdate", acc.Use_sdate)
            d.Add("Use_edate", acc.Use_edate)
            d.Add("Apply_type", acc.Apply_type)
            d.Add("User_name", acc.User_name)
            d.Add("Account", acc.Account)

            d.Add("Change_userid", acc.Change_userid)
            d.Add("Change_date", acc.Change_date)

            Return InsertByExample("MAI_Maintain_acc", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_acc", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_acc", d)
        End Function
    End Class
End Namespace