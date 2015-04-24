Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic
    Public Class VacationAllowanceDAO
        Inherits BaseDAO


        Public Function insert(va As VacationAllowance) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", va.Orgcode)
            d.Add("Flow_id", va.Flow_id)
            d.Add("Id_card", va.Id_card)
            d.Add("Fee_year", va.Fee_year)
            d.Add("Holidays", va.Holidays)
            d.Add("Leave_days", va.Leave_days)
            d.Add("Left_days", va.Left_days)
            d.Add("Inter_days", va.Inter_days)
            d.Add("Inter_days_card", va.Inter_days_card)
            d.Add("Outer_days", va.Outer_days)
            d.Add("Pay_days", va.Pay_days)
            d.Add("Total_fee", va.Total_fee)
            d.Add("Change_userid", va.Change_userid)
            d.Add("Change_date", va.Change_date)

            Return InsertByExample("FSC_Vacation_allowance", d)
        End Function


        Public Function delete(va As VacationAllowance) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", va.Orgcode)
            d.Add("Flow_id", va.Flow_id)
            d.Add("Id_card", va.Id_card)
            d.Add("Fee_year", va.Fee_year)

            Return DeleteByExample("FSC_Vacation_allowance", d)
        End Function


        Public Function GetData(Orgcode As String, Id_card As String, Fee_year As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Fee_year", Fee_year)

            Return GetDataByExample("FSC_Vacation_allowance", d)
        End Function
    End Class
End Namespace