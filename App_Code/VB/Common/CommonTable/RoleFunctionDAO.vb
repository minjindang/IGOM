Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class RoleFunctionDAO
        Inherits BaseDAO
        Dim ConnectionString As String = ""
        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Role_id As String, ByVal Func_id As String) As DataSet
            Dim StrSQL As StringBuilder = New StringBuilder
            StrSQL.AppendLine(" select * from Role_function where 1= 1")

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Role_id) Then
                StrSQL.AppendLine(" and Role_id=@Role_id ")
            End If
            If Not String.IsNullOrEmpty(Func_id) Then
                StrSQL.AppendLine(" and Func_id=@Func_id ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Role_id", SqlDbType.VarChar), _
            New SqlParameter("@Func_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Role_id
            params(2).Value = Func_id

            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

    End Class
End Namespace
