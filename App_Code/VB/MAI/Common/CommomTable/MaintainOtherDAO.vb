Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainOtherDAO
        Inherits BaseDAO

        Public Function InsertData(oth As MaintainOther) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", oth.Main_id)
            d.Add("Orgcode", oth.Orgcode)
            d.Add("Flow_id", oth.Flow_id)
            d.Add("Use_sdate", oth.Use_sdate)
            d.Add("Use_edate", oth.Use_edate)
            d.Add("Apply_type", oth.Apply_type)
            d.Add("User_name", oth.User_name)
            d.Add("Memo", oth.Memo)

            d.Add("Change_userid", oth.Change_userid)
            d.Add("Change_date", oth.Change_date)

            Return InsertByExample("MAI_Maintain_other", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_other", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_other", d)
        End Function
    End Class
End Namespace