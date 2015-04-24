Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2110
        Private DAO As FSC2110DAO

        Public Sub New()
            DAO = New FSC2110DAO()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Id_card2 As String, _
                                ByVal Q_job As String, ByVal Sex As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal LeaveType As String, ByVal Employee_type As String, ByVal status As String, ByVal lastpass As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, Depart_id, Id_card, Id_card2, Q_job, Sex, Sdate, Edate, LeaveType, Employee_type, status, lastpass)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

    End Class
End Namespace
