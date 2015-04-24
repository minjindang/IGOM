Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class FSC_Settlement_Annual
        Public DAO As FSC_Settlement_AnnualDAO

        Public Sub New()
            DAO = New FSC_Settlement_AnnualDAO()
        End Sub

        Public Function GetOne(id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional User_id As String = "", Optional Annual_year As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, User_id, Annual_year)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(ByVal OrgCode As String, ByVal User_id As String, ByVal Flow_id As String) As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, User_id, Flow_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function


        Public Sub Add(Flow_id As String, Orgcode As String, Depart_id As String, Id_card As String, User_name As String, _
Title_no As String, Annual_year As String, Apply_date As String, Login_user As String, Login_departid As String, _
Budget_fee As String, Annual_days As Double, Vacation_days As Double, Vacation_internal As Double, Vacation_card As Double, _
Abroad_days As Double, Usable_days As Double, Pay_days As Double, Base_day_sal As Double, Apply_fee As Double, _
Reserve_days As Double, Reserve_days1 As Double, Reserve_days2 As Double, Hour_pay As Double, Settle_date As String, History_mark As String, Trans_Flag As String, change_userid As String, change_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Orgcode) Then
                psList.Add(New SqlParameter("@Orgcode", Orgcode))
            Else
                psList.Add(New SqlParameter("@Orgcode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                psList.Add(New SqlParameter("@Depart_id", Depart_id))
            Else
                psList.Add(New SqlParameter("@Depart_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                psList.Add(New SqlParameter("@Id_card", Id_card))
            Else
                psList.Add(New SqlParameter("@Id_card", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                psList.Add(New SqlParameter("@User_name", User_name))
            Else
                psList.Add(New SqlParameter("@User_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                psList.Add(New SqlParameter("@Title_no", Title_no))
            Else
                psList.Add(New SqlParameter("@Title_no", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Annual_year) Then
                psList.Add(New SqlParameter("@Annual_year", Annual_year))
            Else
                psList.Add(New SqlParameter("@Annual_year", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                psList.Add(New SqlParameter("@Apply_date", Apply_date))
            Else
                psList.Add(New SqlParameter("@Apply_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Login_user) Then
                psList.Add(New SqlParameter("@Login_user", Login_user))
            Else
                psList.Add(New SqlParameter("@Login_user", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Login_departid) Then
                psList.Add(New SqlParameter("@Login_departid", Login_departid))
            Else
                psList.Add(New SqlParameter("@Login_departid", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Budget_fee) Then
                psList.Add(New SqlParameter("@Budget_fee", Budget_fee))
            Else
                psList.Add(New SqlParameter("@Budget_fee", DBNull.Value))
            End If
            If Not Annual_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Annual_days", Annual_days))
            Else
                psList.Add(New SqlParameter("@Annual_days", DBNull.Value))
            End If
            If Not Vacation_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Vacation_days", Vacation_days))
            Else
                psList.Add(New SqlParameter("@Vacation_days", DBNull.Value))
            End If
            If Not Vacation_internal = Double.MinValue Then
                psList.Add(New SqlParameter("@Vacation_internal", Vacation_internal))
            Else
                psList.Add(New SqlParameter("@Vacation_internal", DBNull.Value))
            End If
            If Not Vacation_card = Double.MinValue Then
                psList.Add(New SqlParameter("@Vacation_card", Vacation_card))
            Else
                psList.Add(New SqlParameter("@Vacation_card", DBNull.Value))
            End If
            If Not Abroad_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Abroad_days", Abroad_days))
            Else
                psList.Add(New SqlParameter("@Abroad_days", DBNull.Value))
            End If
            If Not Usable_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Usable_days", Usable_days))
            Else
                psList.Add(New SqlParameter("@Usable_days", DBNull.Value))
            End If
            If Not Pay_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Pay_days", Pay_days))
            Else
                psList.Add(New SqlParameter("@Pay_days", DBNull.Value))
            End If
            If Not Base_day_sal = Double.MinValue Then
                psList.Add(New SqlParameter("@Base_day_sal", Base_day_sal))
            Else
                psList.Add(New SqlParameter("@Base_day_sal", DBNull.Value))
            End If
            If Not Apply_fee = Double.MinValue Then
                psList.Add(New SqlParameter("@Apply_fee", Apply_fee))
            Else
                psList.Add(New SqlParameter("@Apply_fee", DBNull.Value))
            End If
            If Not Reserve_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Reserve_days", Reserve_days))
            Else
                psList.Add(New SqlParameter("@Reserve_days", DBNull.Value))
            End If
            If Not Reserve_days1 = Double.MinValue Then
                psList.Add(New SqlParameter("@Reserve_days1", Reserve_days1))
            Else
                psList.Add(New SqlParameter("@Reserve_days1", DBNull.Value))
            End If
            If Not Reserve_days2 = Double.MinValue Then
                psList.Add(New SqlParameter("@Reserve_days2", Reserve_days2))
            Else
                psList.Add(New SqlParameter("@Reserve_days2", DBNull.Value))
            End If
            If Not Hour_pay = Double.MinValue Then
                psList.Add(New SqlParameter("@Hour_pay", Hour_pay))
            Else
                psList.Add(New SqlParameter("@Hour_pay", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Settle_date) Then
                psList.Add(New SqlParameter("@Settle_date", Settle_date))
            Else
                psList.Add(New SqlParameter("@Settle_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(History_mark) Then
                psList.Add(New SqlParameter("@History_mark", History_mark))
            Else
                psList.Add(New SqlParameter("@History_mark", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Trans_Flag) Then
                psList.Add(New SqlParameter("@Trans_Flag", Trans_Flag))
            Else
                psList.Add(New SqlParameter("@Trans_Flag", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(change_userid) Then
                psList.Add(New SqlParameter("@change_userid", change_userid))
            Else
                psList.Add(New SqlParameter("@change_userid", DBNull.Value))
            End If
            If Not change_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@change_date", change_date))
            Else
                psList.Add(New SqlParameter("@change_date", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(id As Integer, Flow_id As String, Orgcode As String, Depart_id As String, Id_card As String, User_name As String, _
Title_no As String, Annual_year As String, Apply_date As String, Login_user As String, Login_departid As String, _
Budget_fee As String, Annual_days As Double, Vacation_days As Double, Vacation_internal As Double, Vacation_card As Double, _
Abroad_days As Double, Usable_days As Double, Pay_days As Double, Base_day_sal As Double, Apply_fee As Double, _
Reserve_days As Double, Reserve_days1 As Double, Reserve_days2 As Double, Hour_pay As Double, Settle_date As String, History_mark As String, Trans_Flag As String, change_userid As String, change_date As DateTime)

            Dim dr As DataRow = GetOne(id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@id", id))
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", dr("Flow_id")))
            End If
            If Not String.IsNullOrEmpty(Orgcode) Then
                psList.Add(New SqlParameter("@Orgcode", Orgcode))
            Else
                psList.Add(New SqlParameter("@Orgcode", dr("Orgcode")))
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                psList.Add(New SqlParameter("@Depart_id", Depart_id))
            Else
                psList.Add(New SqlParameter("@Depart_id", dr("Depart_id")))
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                psList.Add(New SqlParameter("@Id_card", Id_card))
            Else
                psList.Add(New SqlParameter("@Id_card", dr("Id_card")))
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                psList.Add(New SqlParameter("@User_name", User_name))
            Else
                psList.Add(New SqlParameter("@User_name", dr("User_name")))
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                psList.Add(New SqlParameter("@Title_no", Title_no))
            Else
                psList.Add(New SqlParameter("@Title_no", dr("Title_no")))
            End If
            If Not String.IsNullOrEmpty(Annual_year) Then
                psList.Add(New SqlParameter("@Annual_year", Annual_year))
            Else
                psList.Add(New SqlParameter("@Annual_year", dr("Annual_year")))
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                psList.Add(New SqlParameter("@Apply_date", Apply_date))
            Else
                psList.Add(New SqlParameter("@Apply_date", dr("Apply_date")))
            End If
            If Not String.IsNullOrEmpty(Login_user) Then
                psList.Add(New SqlParameter("@Login_user", Login_user))
            Else
                psList.Add(New SqlParameter("@Login_user", dr("Login_user")))
            End If
            If Not String.IsNullOrEmpty(Login_departid) Then
                psList.Add(New SqlParameter("@Login_departid", Login_departid))
            Else
                psList.Add(New SqlParameter("@Login_departid", dr("Login_departid")))
            End If
            If Not String.IsNullOrEmpty(Budget_fee) Then
                psList.Add(New SqlParameter("@Budget_fee", Budget_fee))
            Else
                psList.Add(New SqlParameter("@Budget_fee", dr("Budget_fee")))
            End If
            If Not Annual_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Annual_days", Annual_days))
            Else
                psList.Add(New SqlParameter("@Annual_days", dr("Annual_days")))
            End If
            If Not Vacation_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Vacation_days", Vacation_days))
            Else
                psList.Add(New SqlParameter("@Vacation_days", dr("Vacation_days")))
            End If
            If Not Vacation_internal = Double.MinValue Then
                psList.Add(New SqlParameter("@Vacation_internal", Vacation_internal))
            Else
                psList.Add(New SqlParameter("@Vacation_internal", dr("Vacation_internal")))
            End If
            If Not Vacation_card = Double.MinValue Then
                psList.Add(New SqlParameter("@Vacation_card", Vacation_card))
            Else
                psList.Add(New SqlParameter("@Vacation_card", dr("Vacation_card")))
            End If
            If Not Abroad_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Abroad_days", Abroad_days))
            Else
                psList.Add(New SqlParameter("@Abroad_days", dr("Abroad_days")))
            End If
            If Not Usable_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Usable_days", Usable_days))
            Else
                psList.Add(New SqlParameter("@Usable_days", dr("Usable_days")))
            End If
            If Not Pay_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Pay_days", Pay_days))
            Else
                psList.Add(New SqlParameter("@Pay_days", dr("Pay_days")))
            End If
            If Not Base_day_sal = Double.MinValue Then
                psList.Add(New SqlParameter("@Base_day_sal", Base_day_sal))
            Else
                psList.Add(New SqlParameter("@Base_day_sal", dr("Base_day_sal")))
            End If
            If Not Apply_fee = Double.MinValue Then
                psList.Add(New SqlParameter("@Apply_fee", Apply_fee))
            Else
                psList.Add(New SqlParameter("@Apply_fee", dr("Apply_fee")))
            End If
            If Not Reserve_days = Double.MinValue Then
                psList.Add(New SqlParameter("@Reserve_days", Reserve_days))
            Else
                psList.Add(New SqlParameter("@Reserve_days", dr("Reserve_days")))
            End If
            If Not Reserve_days1 = Double.MinValue Then
                psList.Add(New SqlParameter("@Reserve_days1", Reserve_days1))
            Else
                psList.Add(New SqlParameter("@Reserve_days1", dr("Reserve_days1")))
            End If
            If Not Reserve_days2 = Double.MinValue Then
                psList.Add(New SqlParameter("@Reserve_days2", Reserve_days2))
            Else
                psList.Add(New SqlParameter("@Reserve_days2", dr("Reserve_days2")))
            End If
            If Not Hour_pay = Double.MinValue Then
                psList.Add(New SqlParameter("@Hour_pay", Hour_pay))
            Else
                psList.Add(New SqlParameter("@Hour_pay", dr("Hour_pay")))
            End If
            If Not String.IsNullOrEmpty(Settle_date) Then
                psList.Add(New SqlParameter("@Settle_date", Settle_date))
            Else
                psList.Add(New SqlParameter("@Settle_date", dr("Settle_date")))
            End If
            If Not String.IsNullOrEmpty(History_mark) Then
                psList.Add(New SqlParameter("@History_mark", History_mark))
            Else
                psList.Add(New SqlParameter("@History_mark", dr("History_mark")))
            End If
            If Not String.IsNullOrEmpty(Trans_Flag) Then
                psList.Add(New SqlParameter("@Trans_Flag", Trans_Flag))
            Else
                psList.Add(New SqlParameter("@Trans_Flag", dr("Trans_Flag")))
            End If
            If Not String.IsNullOrEmpty(change_userid) Then
                psList.Add(New SqlParameter("@change_userid", change_userid))
            Else
                psList.Add(New SqlParameter("@change_userid", dr("change_userid")))
            End If
            If Not change_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@change_date", change_date))
            Else
                psList.Add(New SqlParameter("@change_date", dr("change_date")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(id As Integer)
            DAO.Delete(id)
        End Sub

        Public Function Delete(orgcode As String, flowId As String) As Boolean
            Return DAO.Delete(orgcode, flowId) > 0
        End Function

    End Class
End Namespace
