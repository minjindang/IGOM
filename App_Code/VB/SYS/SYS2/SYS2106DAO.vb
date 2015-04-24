Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS2106DAO
        Inherits BaseDAO

       
        Public Function getQueryData(ByVal message As String, _
                                     ByVal year As String, _
                                     ByVal month As String, _
                                     ByVal day As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT * from SYS_Errorlog")
            sql.AppendLine(" WHERE 1=1")


            If Not String.IsNullOrEmpty(message) Then
                sql.AppendLine(" AND message like @message ")
            End If

            If Not String.IsNullOrEmpty(year) Then
                sql.AppendLine(" AND Year(create_date) = @year And Month(create_date) = @month And Day(create_date) = @day ")
            End If


            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@message", SqlDbType.VarChar)
            aryParms(0).Value = message
            aryParms(1) = New SqlParameter("@year", SqlDbType.VarChar)
            aryParms(1).Value = year
            aryParms(2) = New SqlParameter("@month", SqlDbType.VarChar)
            aryParms(2).Value = month
            aryParms(3) = New SqlParameter("@day", SqlDbType.VarChar)
            aryParms(3).Value = day

            Return Query(sql.ToString(), aryParms)
        End Function

    End Class
End Namespace
