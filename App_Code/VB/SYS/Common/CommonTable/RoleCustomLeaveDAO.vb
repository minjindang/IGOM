Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace SYS.Logic
    Public Class RoleCustomLeaveDAO
        Inherits BaseDAO
        Dim ConnectionString As String = ""
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function DeleteData(ByVal id As Integer) As String
            Dim StrSQL As String = "delete from SYS_Role_custom_leave where id=@id"
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function DeleteDataByCusId(ByVal Custom_leave_setting_id As Integer) As String
            Dim StrSQL As String = "delete from SYS_Role_custom_leave where Custom_leave_setting_id=@Custom_leave_setting_id"
            Dim param As SqlParameter = New SqlParameter("@Custom_leave_setting_id", SqlDbType.Int)
            param.Value = Custom_leave_setting_id
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from SYS_Role_custom_leave where id=@id "
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataByCusId(ByVal Custom_leave_setting_id As Integer) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from SYS_Role_custom_leave where Custom_leave_setting_id=@Custom_leave_setting_id "
            Dim param As SqlParameter = New SqlParameter("@Custom_leave_setting_id", SqlDbType.Int)
            param.Value = Custom_leave_setting_id
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function
    End Class
End Namespace
