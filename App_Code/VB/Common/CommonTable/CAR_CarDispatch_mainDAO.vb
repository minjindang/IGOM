Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class CAR_CarDispatch_mainDAO
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


            StrSQL.Append(" INSERT INTO CAR_CarDispatch_main ( ")
            StrSQL.Append(" OrgCode,Flow_id,Car_type,Car_name,Passenger_cnt, ")
            StrSQL.Append(" Start_date,End_date,Start_time,End_time,Departure_date, ")
            StrSQL.Append(" Departure_time,Reason_desc,Use_type,Urgent_type,Unit_code, ")
            StrSQL.Append(" User_id,Phone_nos,Destination_desc,ModUser_id,Mod_date, ")
            StrSQL.Append(" Location,Use_frequency,Repeat_weekday,Repeat_day ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@Car_type,@Car_name,@Passenger_cnt, ")
            StrSQL.Append(" @Start_date,@End_date,@Start_time,@End_time,@Departure_date, ")
            StrSQL.Append(" @Departure_time,@Reason_desc,@Use_type,@Urgent_type,@Unit_code, ")
            StrSQL.Append(" @User_id,@Phone_nos,@Destination_desc,@ModUser_id,@Mod_date, ")
            StrSQL.Append(" @Location,@Use_frequency,@Repeat_weekday,@Repeat_day ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE CAR_CarDispatch_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,Car_type=@Car_type,Car_name=@Car_name,Passenger_cnt=@Passenger_cnt, ")
            StrSQL.Append(" Start_date=@Start_date,End_date=@End_date,Start_time=@Start_time,End_time=@End_time,Departure_date=@Departure_date, ")
            StrSQL.Append(" Departure_time=@Departure_time,Reason_desc=@Reason_desc,Use_type=@Use_type,Urgent_type=@Urgent_type,Unit_code=@Unit_code, ")
            StrSQL.Append(" User_id=@User_id,Phone_nos=@Phone_nos,Destination_desc=@Destination_desc,ModUser_id=@ModUser_id,Mod_date=@Mod_date, ")
            StrSQL.Append(" Location=@Location,Use_frequency=@Use_frequency,Repeat_weekday=@Repeat_weekday,Repeat_day=@Repeat_day ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional Start_date As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Car_type,Car_name,Passenger_cnt, ")
            StrSQL.Append(" Start_date,End_date,Start_time,End_time,Departure_date, ")
            StrSQL.Append(" Departure_time,Reason_desc,Use_type,Urgent_type,Unit_code, ")
            StrSQL.Append(" User_id,Phone_nos,Destination_desc,ModUser_id,Mod_date ")
            StrSQL.Append(" ,Location,Use_frequency,Repeat_weekday,Repeat_day ")
            StrSQL.Append("  FROM CAR_CarDispatch_main  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(Start_date) Then
                StrSQL.Append(" AND Start_date=@Start_date ")
            End If

            Dim ps() As SqlParameter = { _
              New SqlParameter("@OrgCode", OrgCode), _
              New SqlParameter("@Start_date", Start_date)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Flow_id As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Car_type,Car_name,Passenger_cnt, ")
            StrSQL.Append(" Start_date,End_date,Start_time,End_time,Departure_date, ")
            StrSQL.Append(" Departure_time,Reason_desc,Use_type,Urgent_type,Unit_code, ")
            StrSQL.Append(" User_id,Phone_nos,Destination_desc,ModUser_id,Mod_date ")
            StrSQL.Append(" ,Location,Use_frequency,Repeat_weekday,Repeat_day ")
            StrSQL.Append("  FROM CAR_CarDispatch_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Flow_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM CAR_CarDispatch_main WHERE  Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace