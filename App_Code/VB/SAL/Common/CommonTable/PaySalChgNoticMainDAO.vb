Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace SAL.Logic
    Public Class PaySalChgNoticMainDAO
        Inherits BaseDAO

        Public Function Insert(ByVal main As PaySalChgNoticMain) As Integer
            Dim d As New Dictionary(Of String, Object)

            d.Add("Employee_type", main.Employee_type)
            d.Add("Id_card", main.Id_card)
            d.Add("User_name", main.User_name)
            d.Add("Org_code", main.Org_code)
            d.Add("Depart_id", main.Depart_id)
            d.Add("Title_code", main.Title_code)
            d.Add("Assign_date", main.Assign_date)
            d.Add("Assign_no", main.Assign_no)
            d.Add("Join_date", main.Join_date)
            d.Add("L3_code", main.L3_code)
            d.Add("L1_code", main.L1_code)
            d.Add("L2_code", main.L2_code)
            d.Add("PtbPoint_nos", main.PtbPoint_nos)
            d.Add("Ptb_amt", main.Ptb_amt)
            d.Add("Salary_point", main.Salary_point)
            d.Add("Salary_amt", main.Salary_amt)
            d.Add("Rate_nos", main.Rate_nos)
            d.Add("Month_pay", main.Month_pay)
            d.Add("Fin_month", main.Fin_month)
            d.Add("Fin_amt", main.Fin_amt)
            d.Add("Fin_people", main.Fin_people)
            d.Add("Fin_people_amt", main.Fin_people_amt)
            d.Add("Fund_month", main.Fund_month)
            d.Add("Fund_day", main.Fund_day)
            d.Add("Fund_amt", main.Fund_amt)
            d.Add("Safety_month", main.Safety_month)
            d.Add("Safety_day", main.Safety_day)
            d.Add("Safety_amt", main.Safety_amt)
            d.Add("Mutual_month", main.Mutual_month)
            d.Add("Mutual_amt", main.Mutual_amt)
            d.Add("House_type", main.House_type)
            d.Add("Law_prof_plus", main.Law_prof_plus)
            d.Add("General_prof_plus", main.General_prof_plus)
            d.Add("Enviprotec_prof_plus", main.Enviprotec_prof_plus)
            d.Add("Operator_prof_plus", main.Operator_prof_plus)
            d.Add("East_taiwan_plus", main.East_taiwan_plus)
            d.Add("Natimajproj_post_plus", main.Natimajproj_post_plus)
            d.Add("Technical_staff", main.Technical_staff)
            d.Add("Promo_desc", main.Promo_desc)
            d.Add("Send_status", main.Send_status)
            d.Add("Change_userid", main.Change_userid)
            d.Add("Change_date", main.Change_date)

            Return InsertByExample("SAL_PaySalChgNotic_main", d)
        End Function


        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return GetDataByExample("SAL_PaySalChgNotic_main", d)
        End Function

        Public Function UpdateSendStatus(ByVal id As Integer, ByVal sendStatus As String) As Integer
            Dim c As New Dictionary(Of String, Object)
            c.Add("id", id)

            Dim d As New Dictionary(Of String, Object)
            d.Add("Send_status", sendStatus)
            d.Add("Change_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))

            Return UpdateByExample("SAL_PaySalChgNotic_main", d, c)
        End Function
    End Class
End Namespace