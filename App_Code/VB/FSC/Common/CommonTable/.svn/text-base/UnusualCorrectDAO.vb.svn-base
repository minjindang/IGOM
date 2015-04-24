Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic
    Public Class UnusualCorrectDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub


        Public Function getLastData(ByVal id_card As String, ByVal pkwdate As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select top 1 * from FSC_Unusual_correct ")
            sql.AppendLine(" where id_card=@id_card and pkwdate=@pkwdate order by change_date desc ")
            Dim ps() As SqlParameter = { _
            New SqlParameter("@id_card", id_card), _
            New SqlParameter("@pkwdate", pkwdate)}
            Return Query(sql.ToString(), ps)
        End Function
    End Class
End Namespace
