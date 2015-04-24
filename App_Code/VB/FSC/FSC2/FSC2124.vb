Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class FSC2124
        Private DAO As FSC2124DAO

        Public Sub New()
            DAO = New FSC2124DAO()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal id_card As String, ByVal id_card2 As String, ByVal Quit_job_flag As String, _
                                ByVal Employee_type As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, Depart_id, Sdate, Edate, id_card, id_card2, Quit_job_flag, Employee_type)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace
