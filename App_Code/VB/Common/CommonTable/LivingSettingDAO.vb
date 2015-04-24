Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class LivingSettingDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function InsertData(ByVal ls As LivingSetting) As Integer
            Dim StrSQL As New StringBuilder
            StrSQL.Append("INSERT INTO Living_setting ")
            StrSQL.Append("     (Orgcode, Master_code, Detail_code) ")
            StrSQL.Append(" VALUES ")
            StrSQL.Append("     (@Orgcode, @Master_code, @Detail_code) ")
            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = ls.Orgcode
            params(1) = New SqlParameter("@Master_code", SqlDbType.VarChar)
            params(1).Value = ls.Master_code
            params(2) = New SqlParameter("@Detail_code", SqlDbType.VarChar)
            params(2).Value = ls.Detail_code
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function GetDataByMasterCode(ByVal Orgcode As String, ByVal Master_code As String) As DataSet
            Dim sql As String = "SELECT ls.*, dc.detail_code_name FROM Living_setting ls inner join detail_code dc on ls.detail_code=dc.detail_code_id and dc.master_code_id='1005' WHERE Orgcode=@Orgcode AND Master_code=@Master_code "
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Master_code", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Master_code
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, params)
        End Function


        Public Function GetDataByDetailCode(ByVal Orgcode As String, ByVal Master_code As String) As DataSet
            Dim sql As String = "SELECT * FROM Detail_code dc WHERE Master_code_id='1005' AND Delete_flag='N' AND Detail_code_id NOT IN (SELECT Detail_code FROM Living_setting WHERE Orgcode=@Orgcode AND Master_code=@Master_code) "
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Master_code", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Master_code
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, params)
        End Function

        Public Function DeleteById(ByVal id As String) As Integer
            Dim sql As String = "DELETE FROM Living_setting WHERE id=@id "
            Dim params() As SqlParameter = { _
            New SqlParameter("@id", SqlDbType.Int)}
            params(0).Value = id
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, params)
        End Function
    End Class
End Namespace
