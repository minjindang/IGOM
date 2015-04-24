Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class CAR_CarDispatch_main
        Public DAO As CAR_CarDispatch_mainDAO

        Public Sub New()
            DAO = New CAR_CarDispatch_mainDAO()
        End Sub

        Public Function GetOne(Flow_id As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Flow_id, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional Start_date As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, Start_date)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, Flow_id As String, Car_type As String, Car_name As String, Passenger_cnt As Integer, _
Start_date As String, End_date As String, Start_time As String, End_time As String, Departure_date As String, _
Departure_time As String, Reason_desc As String, Use_type As String, Urgent_type As String, Unit_code As String, _
User_id As String, Phone_nos As String, Destination_desc As String, ModUser_id As String, Mod_date As DateTime, Location As String, Use_frequency As String, Repeat_weekday As String, Repeat_day As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Car_type) Then
                psList.Add(New SqlParameter("@Car_type", Car_type))
            Else
                psList.Add(New SqlParameter("@Car_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Car_name) Then
                psList.Add(New SqlParameter("@Car_name", Car_name))
            Else
                psList.Add(New SqlParameter("@Car_name", DBNull.Value))
            End If
            If Not Passenger_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Passenger_cnt", Passenger_cnt))
            Else
                psList.Add(New SqlParameter("@Passenger_cnt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                psList.Add(New SqlParameter("@Start_date", Start_date))
            Else
                psList.Add(New SqlParameter("@Start_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                psList.Add(New SqlParameter("@End_date", End_date))
            Else
                psList.Add(New SqlParameter("@End_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Start_time) Then
                psList.Add(New SqlParameter("@Start_time", Start_time))
            Else
                psList.Add(New SqlParameter("@Start_time", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(End_time) Then
                psList.Add(New SqlParameter("@End_time", End_time))
            Else
                psList.Add(New SqlParameter("@End_time", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Departure_date) Then
                psList.Add(New SqlParameter("@Departure_date", Departure_date))
            Else
                psList.Add(New SqlParameter("@Departure_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Departure_time) Then
                psList.Add(New SqlParameter("@Departure_time", Departure_time))
            Else
                psList.Add(New SqlParameter("@Departure_time", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Reason_desc) Then
                psList.Add(New SqlParameter("@Reason_desc", Reason_desc))
            Else
                psList.Add(New SqlParameter("@Reason_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Use_type) Then
                psList.Add(New SqlParameter("@Use_type", Use_type))
            Else
                psList.Add(New SqlParameter("@Use_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Urgent_type) Then
                psList.Add(New SqlParameter("@Urgent_type", Urgent_type))
            Else
                psList.Add(New SqlParameter("@Urgent_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Phone_nos) Then
                psList.Add(New SqlParameter("@Phone_nos", Phone_nos))
            Else
                psList.Add(New SqlParameter("@Phone_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Destination_desc) Then
                psList.Add(New SqlParameter("@Destination_desc", Destination_desc))
            Else
                psList.Add(New SqlParameter("@Destination_desc", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", DBNull.Value))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Location) Then
                psList.Add(New SqlParameter("@Location", Location))
            Else
                psList.Add(New SqlParameter("@Location", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Use_frequency) Then
                psList.Add(New SqlParameter("@Use_frequency", Use_frequency))
            Else
                psList.Add(New SqlParameter("@Use_frequency", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Repeat_weekday) Then
                psList.Add(New SqlParameter("@Repeat_weekday", Repeat_weekday))
            Else
                psList.Add(New SqlParameter("@Repeat_weekday", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Repeat_day) Then
                psList.Add(New SqlParameter("@Repeat_day", Repeat_day))
            Else
                psList.Add(New SqlParameter("@Repeat_day", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(Flow_id As String, OrgCode As String, Car_type As String, Car_name As String, Passenger_cnt As Integer, _
Start_date As String, End_date As String, Start_time As String, End_time As String, Departure_date As String, _
Departure_time As String, Reason_desc As String, Use_type As String, Urgent_type As String, Unit_code As String, _
User_id As String, Phone_nos As String, Destination_desc As String, ModUser_id As String, Mod_date As DateTime, Location As String, Use_frequency As String, Repeat_weekday As String, Repeat_day As String)

            Dim dr As DataRow = GetOne(Flow_id, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Flow_id", Flow_id))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            If Not String.IsNullOrEmpty(Car_type) Then
                psList.Add(New SqlParameter("@Car_type", Car_type))
            Else
                psList.Add(New SqlParameter("@Car_type", dr("Car_type")))
            End If
            If Not String.IsNullOrEmpty(Car_name) Then
                psList.Add(New SqlParameter("@Car_name", Car_name))
            Else
                psList.Add(New SqlParameter("@Car_name", dr("Car_name")))
            End If
            If Not Passenger_cnt = Integer.MinValue Then
                psList.Add(New SqlParameter("@Passenger_cnt", Passenger_cnt))
            Else
                psList.Add(New SqlParameter("@Passenger_cnt", dr("Passenger_cnt")))
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                psList.Add(New SqlParameter("@Start_date", Start_date))
            Else
                psList.Add(New SqlParameter("@Start_date", dr("Start_date")))
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                psList.Add(New SqlParameter("@End_date", End_date))
            Else
                psList.Add(New SqlParameter("@End_date", dr("End_date")))
            End If
            If Not String.IsNullOrEmpty(Start_time) Then
                psList.Add(New SqlParameter("@Start_time", Start_time))
            Else
                psList.Add(New SqlParameter("@Start_time", dr("Start_time")))
            End If
            If Not String.IsNullOrEmpty(End_time) Then
                psList.Add(New SqlParameter("@End_time", End_time))
            Else
                psList.Add(New SqlParameter("@End_time", dr("End_time")))
            End If
            If Not String.IsNullOrEmpty(Departure_date) Then
                psList.Add(New SqlParameter("@Departure_date", Departure_date))
            Else
                psList.Add(New SqlParameter("@Departure_date", dr("Departure_date")))
            End If
            If Not String.IsNullOrEmpty(Departure_time) Then
                psList.Add(New SqlParameter("@Departure_time", Departure_time))
            Else
                psList.Add(New SqlParameter("@Departure_time", dr("Departure_time")))
            End If
            If Not String.IsNullOrEmpty(Reason_desc) Then
                psList.Add(New SqlParameter("@Reason_desc", Reason_desc))
            Else
                psList.Add(New SqlParameter("@Reason_desc", dr("Reason_desc")))
            End If
            If Not String.IsNullOrEmpty(Use_type) Then
                psList.Add(New SqlParameter("@Use_type", Use_type))
            Else
                psList.Add(New SqlParameter("@Use_type", dr("Use_type")))
            End If
            If Not String.IsNullOrEmpty(Urgent_type) Then
                psList.Add(New SqlParameter("@Urgent_type", Urgent_type))
            Else
                psList.Add(New SqlParameter("@Urgent_type", dr("Urgent_type")))
            End If
            If Not String.IsNullOrEmpty(Unit_code) Then
                psList.Add(New SqlParameter("@Unit_code", Unit_code))
            Else
                psList.Add(New SqlParameter("@Unit_code", dr("Unit_code")))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(Phone_nos) Then
                psList.Add(New SqlParameter("@Phone_nos", Phone_nos))
            Else
                psList.Add(New SqlParameter("@Phone_nos", dr("Phone_nos")))
            End If
            If Not String.IsNullOrEmpty(Destination_desc) Then
                psList.Add(New SqlParameter("@Destination_desc", Destination_desc))
            Else
                psList.Add(New SqlParameter("@Destination_desc", dr("Destination_desc")))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", dr("ModUser_id")))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", dr("Mod_date")))
            End If
            If Not String.IsNullOrEmpty(Location) Then
                psList.Add(New SqlParameter("@Location", Location))
            Else
                psList.Add(New SqlParameter("@Location", dr("Location")))
            End If
            If Not String.IsNullOrEmpty(Use_frequency) Then
                psList.Add(New SqlParameter("@Use_frequency", Use_frequency))
            Else
                psList.Add(New SqlParameter("@Use_frequency", dr("Use_frequency")))
            End If
            If Not String.IsNullOrEmpty(Repeat_weekday) Then
                psList.Add(New SqlParameter("@Repeat_weekday", Repeat_weekday))
            Else
                psList.Add(New SqlParameter("@Repeat_weekday", dr("Repeat_weekday")))
            End If
            If Not String.IsNullOrEmpty(Repeat_day) Then
                psList.Add(New SqlParameter("@Repeat_day", Repeat_day))
            Else
                psList.Add(New SqlParameter("@Repeat_day", dr("Repeat_day")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(Flow_id As String, OrgCode As String)
            DAO.Delete(Flow_id, OrgCode)
        End Sub

    End Class
End Namespace
