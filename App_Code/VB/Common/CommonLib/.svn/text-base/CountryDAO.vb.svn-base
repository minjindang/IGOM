Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class CountryDAO
    Inherits BaseDAO
    Private _conn As SqlConnection

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal conn As SqlConnection)
        MyBase.New(conn)
    End Sub

    Public Function getCountryList() As DataTable
        Dim strSQL As StringBuilder = New StringBuilder()
        strSQL.AppendLine(" SELECT CountryCode,CountryName FROM CountryList WITH(NOLOCK) ")
        Return Query(strSQL.ToString(), Nothing)
    End Function
End Class
