Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainServerDAO
        Inherits BaseDAO

        Public Function InsertData(serv As MaintainServer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", serv.Main_id)
            d.Add("Orgcode", serv.Orgcode)
            d.Add("Flow_id", serv.Flow_id)
            d.Add("Use_sdate", serv.Use_sdate)
            d.Add("Use_edate", serv.Use_edate)
            d.Add("Apply_type", serv.Apply_type)
            d.Add("Server_name", serv.Server_name)
            d.Add("Cpu_nos", serv.Cpu_nos)
            d.Add("Ram_size", serv.Ram_size)
            d.Add("Hd_size", serv.Hd_size)
            d.Add("Windows_ver", serv.Windows_ver)
            d.Add("Other_ver", serv.Other_ver)
            d.Add("Intra_flag", serv.Intra_flag)
            d.Add("Outer_flag", serv.Outer_flag)
            d.Add("Change_userid", serv.Change_userid)
            d.Add("Change_date", serv.Change_date)

            Return InsertByExample("MAI_Maintain_server", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_server", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_server", d)
        End Function
    End Class
End Namespace