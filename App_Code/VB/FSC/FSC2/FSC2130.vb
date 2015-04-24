Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2130
        Private DAO As FSC2130DAO

        Public Sub New()
            DAO = New FSC2130DAO()
        End Sub

        Public Function getSumData(ByVal employee_type As String, ByVal yyymm As String) As DataTable
            Return DAO.getSumData(employee_type, yyymm)
        End Function

        Public Function getData(ByVal id_card As String, ByVal yyymm As String) As DataTable
            Return DAO.getData(id_card, yyymm)
        End Function
    End Class
End Namespace