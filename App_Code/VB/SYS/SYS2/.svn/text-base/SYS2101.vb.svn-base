Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class SYS2101
        Private DAO As SYS2101DAO

        Public Sub New()
            DAO = New SYS2101DAO()
        End Sub

        Public Function GetFormKind(ByVal orgcode As String, ByVal codeNos As String) As DataTable
            Return DAO.GetFormKind(orgcode, codeNos)
        End Function

        Public Function GetFormType(ByVal orgcode As String, ByVal codeType As String, ByVal codeNos As String) As DataTable
            Return DAO.GetFormType(orgcode, codeType, codeNos)
        End Function


        Public Function GetFormData(ByVal orgcode As String, ByVal Start_date As String, ByVal End_date As String, ByVal formId As String, ByVal codeNos As String, ByVal caseStatus As String, _
                                    ByVal lastPass As String, ByVal Depart_id As String, ByVal id_card As String, ByVal id_card2 As String) As DataTable
            Return DAO.GetFormData(orgcode, Start_date, End_date, formId, codeNos, caseStatus, lastPass, Depart_id, id_card, id_card2)
        End Function
    End Class
End Namespace
