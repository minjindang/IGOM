Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2133
        Private DAO As FSC2133DAO

        Public Sub New()
            DAO = New FSC2133DAO()
        End Sub

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal Employee_type As String) As DataTable
            Return DAO.getData(Orgcode, Depart_id, id_card, id_card2, Employee_type)
        End Function

        Public Function getLeaveHours(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal Start_date As String, _
                              ByVal End_date As String) As Integer
            Return CommonFun.getInt(DAO.getLeaveHours(Orgcode, Depart_id, id_card, Start_date, End_date))
        End Function
    End Class
End Namespace