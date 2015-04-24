Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic
    Public Class LeaveSettingDetailDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function DeleteData(ByVal id As Integer) As String
            Dim StrSQL As String = "delete from FSC_Leave_setting_detail where id=@id"
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from FSC_Leave_setting_detail where id=@id "
            Dim param As SqlParameter = New SqlParameter("@id", SqlDbType.Int)
            param.Value = id
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataByMasterId(ByVal MasterId As Integer) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from FSC_Leave_setting_detail where Leave_setting_id=@Leave_setting_id "
            Dim param As SqlParameter = New SqlParameter("@Leave_setting_id", SqlDbType.Int)
            param.Value = MasterId
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function
    End Class
End Namespace
