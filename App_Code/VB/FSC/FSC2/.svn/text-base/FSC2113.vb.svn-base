Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2113
        Private DAO As FSC2113DAO

        Public Sub New()
            DAO = New FSC2113DAO()
        End Sub

        Public Function getData(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal yyy As String, ByVal Quit_job_flag As String, ByVal PESEX As String, ByVal Employee_type As String, _
                                ByVal Leave_type As String) As DataTable
            Return DAO.getData(orgcode, depart_id, id_card, id_card2, yyy, Quit_job_flag, PESEX, Employee_type, Leave_type)
        End Function

        Public Function getDataSettlementAnnual(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal yyy As String, ByVal Quit_job_flag As String, ByVal PESEX As String, ByVal Employee_type As String) As DataTable
            Return DAO.getDataSettlementAnnual(orgcode, depart_id, id_card, id_card2, yyy, Quit_job_flag, PESEX, Employee_type)
        End Function

        Public Function getNonSettlementAnnual(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                        ByVal yyy As String, ByVal Quit_job_flag As String, ByVal PESEX As String, ByVal Employee_type As String) As DataTable
            Return DAO.getNonSettlementAnnual(orgcode, depart_id, id_card, id_card2, yyy, Quit_job_flag, PESEX, Employee_type)
        End Function
    End Class
End Namespace
