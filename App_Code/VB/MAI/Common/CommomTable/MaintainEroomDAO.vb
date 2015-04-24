Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainEroomDAO
        Inherits BaseDAO

        Public Function InsertData(room As MaintainEroom) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", room.Main_id)
            d.Add("Orgcode", room.Orgcode)
            d.Add("Flow_id", room.Flow_id)
            d.Add("Enter_date", room.Enter_date)
            d.Add("Enter_time", room.Enter_time)
            d.Add("Server_name", room.Server_name)
            d.Add("Application_name", room.Application_name)
            d.Add("Card_type", room.Card_type)
            d.Add("Card_nos", room.Card_nos)
            d.Add("Desc_flag", room.Desc_flag)
            d.Add("Describe", room.Describe)
            d.Add("Equipment_desc", room.Equipment_desc)
            d.Add("Enter_realdate", room.Enter_realdate)
            d.Add("Enter_realtime", room.Enter_realtime)
            d.Add("Enter_signidcard", room.Enter_signidcard)
            d.Add("Enter_signname", room.Enter_signname)
            d.Add("Left_realdate", room.Left_realdate)
            d.Add("Left_realtime", room.Left_realtime)
            d.Add("Left_signidcard", room.Left_signidcard)
            d.Add("Left_signname", room.Left_signname)

            d.Add("Change_userid", room.Change_userid)
            d.Add("Change_date", room.Change_date)

                Return InsertByExample("MAI_Maintain_eroom", d)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return GetDataByExample("MAI_Maintain_eroom", d)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Main_id", mainId)

            Return DeleteByExample("MAI_Maintain_eroom", d)
        End Function

    End Class
End Namespace