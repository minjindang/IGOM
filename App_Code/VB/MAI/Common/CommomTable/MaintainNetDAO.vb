Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainNetDAO
        Inherits BaseDAO

        Public Function InsertData(net As MaintainNet) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", net.Main_id)
            d.Add("Orgcode", net.Orgcode)
            d.Add("Flow_id", net.Flow_id)
            d.Add("Use_sdate", net.Use_sdate)
            d.Add("Use_edate", net.Use_edate)
            d.Add("Apply_type", net.Apply_type)
            d.Add("User_unit", net.User_unit)
            d.Add("User_name", net.User_name)
            d.Add("User_phone", net.User_phone)
            d.Add("Mac_addr", net.Mac_addr)
            d.Add("Old_macaddr", net.Old_macaddr)
            d.Add("Change_userid", net.Change_userid)
            d.Add("Change_date", net.Change_date)

            Return InsertByExample("MAI_Maintain_net", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_net", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_net", d)
        End Function

    End Class
End Namespace