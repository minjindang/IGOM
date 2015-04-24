Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class RoleFunctionDetailDAO
        Inherits BaseDAO
        Dim ConnectionString As String = ""
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function DeleteDataByrfid(ByVal rfid As Integer) As String
            Dim StrSQL As String = "delete from Role_function_detail where Role_function_id=@rfid"
            Dim param As SqlParameter = New SqlParameter("@rfid", SqlDbType.Int)
            param.Value = rfid
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataByrfid(ByVal rfid As Integer) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select * from Role_function_detail where Role_function_id=@rfid "
            Dim param As SqlParameter = New SqlParameter("@rfid", SqlDbType.Int)
            param.Value = rfid
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL, param)
        End Function

    End Class
End Namespace
