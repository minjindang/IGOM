Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class ImgMappingDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            Me.ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetDataByQuery(ByVal Func_id As String, ByVal Func_program_name As String) As DataSet
            Dim StrSQl As String = String.Empty
            StrSQl = "SELECT * FROM Img_mapping WHERE Func_id=@Func_id AND Func_program_name=@Func_program_name "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Func_id", SqlDbType.VarChar)
            params(0).Value = Func_id
            params(1) = New SqlParameter("@Func_Program_Name", SqlDbType.VarChar)
            params(1).Value = Func_Program_Name

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQl, params)
        End Function
    End Class
End Namespace