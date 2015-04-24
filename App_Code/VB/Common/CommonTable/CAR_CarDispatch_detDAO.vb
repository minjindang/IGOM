Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class CAR_CarDispatch_detDAO
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


            StrSQL.Append(" INSERT INTO CAR_CarDispatch_det ( ")
            StrSQL.Append(" OrgCode,Flow_id,Car_id,Dispatch_date,Start_time, ")
            StrSQL.Append(" End_time,Is_return,DriverUser_id,ModUser_id,Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@Flow_id,@Car_id,@Dispatch_date,@Start_time, ")
            StrSQL.Append(" @End_time,@Is_return,@DriverUser_id,@ModUser_id,@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE CAR_CarDispatch_det SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,Flow_id=@Flow_id,Car_id=@Car_id,Dispatch_date=@Dispatch_date,Start_time=@Start_time, ")
            StrSQL.Append(" End_time=@End_time,Is_return=@Is_return,DriverUser_id=@DriverUser_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND DispatchRecords_id=@DispatchRecords_id  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Car_id,Dispatch_date,Start_time, ")
            StrSQL.Append(" End_time,Is_return,DriverUser_id,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM CAR_CarDispatch_det  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(DispatchRecords_id As String, Flow_id As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,Flow_id,Car_id,Dispatch_date,Start_time, ")
            StrSQL.Append(" End_time,Is_return,DriverUser_id,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM CAR_CarDispatch_det  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND DispatchRecords_id=@DispatchRecords_id  ")
            StrSQL.Append("  AND Flow_id=@Flow_id  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@DispatchRecords_id", DispatchRecords_id), _
         New SqlParameter("@Flow_id", Flow_id), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(DispatchRecords_id As String, Flow_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM CAR_CarDispatch_det WHERE  DispatchRecords_id=@DispatchRecords_id AND Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@DispatchRecords_id", DispatchRecords_id), New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        'DeleteByFlow_id
        Public Sub DeleteByFlow_id(Flow_id As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM CAR_CarDispatch_det WHERE Flow_id=@Flow_id AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Flow_id", Flow_id), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub

    End Class
End Namespace