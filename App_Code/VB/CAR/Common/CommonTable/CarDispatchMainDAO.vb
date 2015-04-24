Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class CarDispatchMainDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Function GetData(ByVal OrgCode As String, ByVal Start_date As String) As DataTable
            Dim sql As String = " select * from CAR_CarDispatch_main where user_id is not null  "

            If Not String.IsNullOrEmpty(OrgCode) Then
                sql &= " and OrgCode=@OrgCode "
            End If

            If Not String.IsNullOrEmpty(Start_date) Then
                sql &= " and Start_date=@Start_date "
            End If


            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Start_date", Start_date) _
                                        }

            Return Query(sql, ps)

        End Function


        Public Function GetDataByFlowId(ByVal OrgCode As String, ByVal flowId As String) As DataTable
            Dim sql As String = " select * from CAR_CarDispatch_main where 1=1  "

            If Not String.IsNullOrEmpty(OrgCode) Then
                sql &= " and OrgCode=@OrgCode "
            End If

            If Not String.IsNullOrEmpty(flowId) Then
                sql &= " and Flow_id=@flowId "
            End If


            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@flowId", flowId) _
                                        }

            Return Query(sql, ps)

        End Function

        Public Sub Insert(ByVal OrgCode As String, ByVal Flow_id As String, ByVal Car_type As String, ByVal Car_name As String, ByVal Passenger_cnt As Integer, _
                          ByVal Start_date As String, ByVal End_date As String, ByVal Start_time As String, ByVal End_time As String, ByVal Departure_time As String, _
                          ByVal Reason_desc As String, ByVal Use_type As String, ByVal Urgent_type As String, ByVal Unit_code As String, ByVal User_id As String, _
                          ByVal Phone_nos As String, ByVal Destination_desc As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal Location As String)
            Dim sql As New System.Text.StringBuilder
            sql.Append("INSERT INTO CAR_CarDispatch_main " & vbCrLf)
            sql.Append("            ([OrgCode], " & vbCrLf)
            sql.Append("             [Flow_id], " & vbCrLf)
            sql.Append("             [Car_type], " & vbCrLf)
            sql.Append("             [Car_name], " & vbCrLf)
            sql.Append("             [Passenger_cnt], " & vbCrLf)
            sql.Append("             [Start_date], " & vbCrLf)
            sql.Append("             [End_date], " & vbCrLf)
            sql.Append("             [Start_time], " & vbCrLf)
            sql.Append("             [End_time], " & vbCrLf)
            sql.Append("             [Departure_time], " & vbCrLf)
            sql.Append("             [Reason_desc], " & vbCrLf)
            sql.Append("             [Use_type], " & vbCrLf)
            sql.Append("             [Urgent_type], " & vbCrLf)
            sql.Append("             [Unit_code], " & vbCrLf)
            sql.Append("             [User_id], " & vbCrLf)
            sql.Append("             [Phone_nos], " & vbCrLf)
            sql.Append("             [Destination_desc], " & vbCrLf)
            sql.Append("             [ModUser_id], " & vbCrLf)
            sql.Append("             [Mod_date], " & vbCrLf)
            sql.Append("             [Location]) " & vbCrLf)
            sql.Append("VALUES      (@OrgCode, " & vbCrLf)
            sql.Append("             @Flow_id, " & vbCrLf)
            sql.Append("             @Car_type, " & vbCrLf)
            sql.Append("             @Car_name, " & vbCrLf)
            sql.Append("             @Passenger_cnt, " & vbCrLf)
            sql.Append("             @Start_date, " & vbCrLf)
            sql.Append("             @End_date, " & vbCrLf)
            sql.Append("             @Start_time, " & vbCrLf)
            sql.Append("             @End_time, " & vbCrLf)
            sql.Append("             @Departure_time, " & vbCrLf)
            sql.Append("             @Reason_desc, " & vbCrLf)
            sql.Append("             @Use_type, " & vbCrLf)
            sql.Append("             @Urgent_type, " & vbCrLf)
            sql.Append("             @Unit_code, " & vbCrLf)
            sql.Append("             @User_id, " & vbCrLf)
            sql.Append("             @Phone_nos, " & vbCrLf)
            sql.Append("             @Destination_desc, " & vbCrLf)
            sql.Append("             @ModUser_id, " & vbCrLf)
            sql.Append("             @Mod_date, " & vbCrLf)
            sql.Append("             @Location) ")
            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                   New SqlParameter("@Flow_id", Flow_id), _
                                   New SqlParameter("@Car_type", Car_type), _
                                   New SqlParameter("@Car_name", Car_name), _
                                   New SqlParameter("@Passenger_cnt", Passenger_cnt), _
                                   New SqlParameter("@Start_date", Start_date), _
                                   New SqlParameter("@End_date", End_date), _
                                   New SqlParameter("@Start_time", Start_time), _
                                   New SqlParameter("@End_time", End_time), _
                                   New SqlParameter("@Departure_time", Departure_time), _
                                   New SqlParameter("@Reason_desc", Reason_desc), _
                                   New SqlParameter("@Use_type", Use_type), _
                                   New SqlParameter("@Urgent_type", Urgent_type), _
                                   New SqlParameter("@Unit_code", Unit_code), _
                                   New SqlParameter("@User_id", User_id), _
                                   New SqlParameter("@Phone_nos", Phone_nos), _
                                   New SqlParameter("@Destination_desc", Destination_desc), _
                                   New SqlParameter("@ModUser_id", ModUser_id), _
                                   New SqlParameter("@Mod_date", Mod_date), _
                                   New SqlParameter("@Location", Location)}


            Execute(sql.ToString(), ps)

        End Sub

    End Class
End Namespace