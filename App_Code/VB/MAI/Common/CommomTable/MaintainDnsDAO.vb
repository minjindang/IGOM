Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainDnsDAO
        Inherits BaseDAO

        Public Function InsertData(dns As MaintainDns) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", dns.Main_id)
            d.Add("Orgcode", dns.Orgcode)
            d.Add("Flow_id", dns.Flow_id)
            d.Add("Use_sdate", dns.Use_sdate)
            d.Add("Use_edate", dns.Use_edate)
            d.Add("Apply_type", dns.Apply_type)
            d.Add("Server_name", dns.Server_name)
            d.Add("Server_ip", dns.Server_ip)
            d.Add("Dns_name", dns.Dns_name)
            d.Add("Firewall_port", dns.Firewall_port)
            d.Add("Change_userid", dns.Change_userid)
            d.Add("Change_date", dns.Change_date)

            Return InsertByExample("MAI_Maintain_dns", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_dns", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_dns", d)
        End Function
    End Class
End Namespace