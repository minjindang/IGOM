Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class TemporarilyTransfeDAO
        Inherits BaseDAO

        Public Function getDataByIdcard(ByVal id_card As String) As DataTable
            Dim sql As String = " select * from FSC_temporarily_transfe where id_card=@id_card "

            Dim param(0) As SqlParameter
            param(0) = New SqlParameter("@id_card", SqlDbType.VarChar)
            param(0).Value = id_card

            Return Query(sql, param)
        End Function

        Public Function getData(ByVal id_card As String, ByVal currentDate As String) As DataTable
            Dim sql As String = " select * from FSC_temporarily_transfe where id_card=@id_card and @currentDate between Start_date and End_date "

            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@id_card", SqlDbType.VarChar)
            param(0).Value = id_card
            param(1) = New SqlParameter("@currentDate", SqlDbType.VarChar)
            param(1).Value = currentDate

            Return Query(sql, param)
        End Function
    End Class
End Namespace
