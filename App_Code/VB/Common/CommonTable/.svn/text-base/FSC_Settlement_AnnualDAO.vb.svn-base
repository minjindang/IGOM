Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class FSC_Settlement_AnnualDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO FSC_Settlement_Annual ( ")
            StrSQL.Append(" Flow_id,Orgcode,Depart_id,Id_card,User_name, ")
            StrSQL.Append(" Title_no,Annual_year,Apply_date,Login_user,Login_departid, ")
            StrSQL.Append(" Budget_fee,Annual_days,Vacation_days,Vacation_internal,Vacation_card, ")
            StrSQL.Append(" Abroad_days,Usable_days,Pay_days,Base_day_sal,Apply_fee, ")
            StrSQL.Append(" Reserve_days,Reserve_days1,Reserve_days2,Hour_pay,Settle_date, ")
            StrSQL.Append(" History_mark,Trans_Flag,change_userid,change_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@Orgcode,@Depart_id,@Id_card,@User_name, ")
            StrSQL.Append(" @Title_no,@Annual_year,@Apply_date,@Login_user,@Login_departid, ")
            StrSQL.Append(" @Budget_fee,@Annual_days,@Vacation_days,@Vacation_internal,@Vacation_card, ")
            StrSQL.Append(" @Abroad_days,@Usable_days,@Pay_days,@Base_day_sal,@Apply_fee, ")
            StrSQL.Append(" @Reserve_days,@Reserve_days1,@Reserve_days2,@Hour_pay,@Settle_date, ")
            StrSQL.Append(" @History_mark,@Trans_Flag,@change_userid,@change_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE FSC_Settlement_Annual SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,Orgcode=@Orgcode,Depart_id=@Depart_id,Id_card=@Id_card,User_name=@User_name, ")
            StrSQL.Append(" Title_no=@Title_no,Annual_year=@Annual_year,Apply_date=@Apply_date,Login_user=@Login_user,Login_departid=@Login_departid, ")
            StrSQL.Append(" Budget_fee=@Budget_fee,Annual_days=@Annual_days,Vacation_days=@Vacation_days,Vacation_internal=@Vacation_internal,Vacation_card=@Vacation_card, ")
            StrSQL.Append(" Abroad_days=@Abroad_days,Usable_days=@Usable_days,Pay_days=@Pay_days,Base_day_sal=@Base_day_sal,Apply_fee=@Apply_fee, ")
            StrSQL.Append(" Reserve_days=@Reserve_days,Reserve_days1=@Reserve_days1,Reserve_days2=@Reserve_days2,Hour_pay=@Hour_pay,Settle_date=@Settle_date, ")
            StrSQL.Append(" History_mark=@History_mark,Trans_Flag=@Trans_Flag,change_userid=@change_userid,change_date=@change_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND id=@id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Annual_year As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,Orgcode,Depart_id,Id_card,User_name, ")
            StrSQL.Append(" Title_no,Annual_year,Apply_date,Login_user,Login_departid, ")
            StrSQL.Append(" Budget_fee,Annual_days,Vacation_days,Vacation_internal,Vacation_card, ")
            StrSQL.Append(" Abroad_days,Usable_days,Pay_days,Base_day_sal,Apply_fee, ")
            StrSQL.Append(" Reserve_days,Reserve_days1,Reserve_days2,Hour_pay,Settle_date ")
            StrSQL.Append(" ,History_mark,Trans_Flag,change_userid,change_date ")
            StrSQL.Append("  FROM FSC_Settlement_Annual  ")
            StrSQL.Append("  WHERE Orgcode=@Org_code  ")

            If Not String.IsNullOrEmpty(Annual_year) Then
                StrSQL.Append("  AND Annual_year=@Annual_year  ")
            End If

            Dim ps() As SqlParameter = { _
              New SqlParameter("@Org_code", OrgCode), _
              New SqlParameter("@Annual_year", Annual_year)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ALL
        Public Function SelectAll(ByVal Org_code As String, ByVal User_id As String, ByVal Flow_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT * ")
            StrSQL.Append("  FROM FSC_Settlement_Annual  ")
            StrSQL.Append("  WHERE Orgcode=@Org_code  ")

            If Not String.IsNullOrEmpty(User_id) Then
                StrSQL.Append("  AND Id_card=@User_id  ")
            End If

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If


            StrSQL.Append("  ORDER BY Annual_year DESC ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@User_id", User_id), _
         New SqlParameter("@Flow_id", Flow_id), _
          New SqlParameter("@Org_code", Org_code)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,Orgcode,Depart_id,Id_card,User_name, ")
            StrSQL.Append(" Title_no,Annual_year,Apply_date,Login_user,Login_departid, ")
            StrSQL.Append(" Budget_fee,Annual_days,Vacation_days,Vacation_internal,Vacation_card, ")
            StrSQL.Append(" Abroad_days,Usable_days,Pay_days,Base_day_sal,Apply_fee, ")
            StrSQL.Append(" Reserve_days,Reserve_days1,Reserve_days2,Hour_pay,Settle_date ")
            StrSQL.Append(" ,History_mark,Trans_Flag,change_userid,change_date ")
            StrSQL.Append("  FROM FSC_Settlement_Annual  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND id=@id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@id", id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM FSC_Settlement_Annual WHERE  id=@id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@id", id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


        Public Function Delete(orgcode As String, flowId As String) As Integer
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM FSC_Settlement_Annual WHERE  orgcode=@orgcode and flow_id=@flowId  ")
            Dim ps() As SqlParameter = { _
                New SqlParameter("@orgcode", orgcode), _
                New SqlParameter("@flowId", flowId)}

            Return Execute(StrSQL.ToString(), ps)
        End Function

    End Class
End Namespace