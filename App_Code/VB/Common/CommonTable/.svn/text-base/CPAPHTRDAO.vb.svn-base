Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class CPAPHTRDAO
        Inherits BaseDAO


        Public Function GetDataByFlow_id(ByVal Flow_id As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM CPAPHTR WHERE PHGUID=@PHGUID ")
            Dim param As SqlParameter = New SqlParameter("@PHGUID", SqlDbType.VarChar)
            param.Value = Flow_id
            Return Query(StrSQL.ToString(), param)
        End Function
    End Class
End Namespace