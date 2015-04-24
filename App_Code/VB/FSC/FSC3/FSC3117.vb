Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class FSC3117
        Private DAO As FSC3117DAO

        Public Sub New()
            DAO = New FSC3117DAO()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sdate As String, ByVal Edate As String, _
                                ByVal id_card As String, ByVal id_card2 As String, ByVal Quit_job_flag As String, _
                                ByVal Employee_type As String, ByVal yyymm As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, Depart_id, Sdate, Edate, id_card, id_card2, Quit_job_flag, Employee_type, yyymm)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function updatePK(ByVal yyymm As String, ByVal PKCARD As String, ByVal PKWDATE As String, ByVal PKSTIME As String, _
                                 ByVal PKETIME As String, ByVal PKWKTPE As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("PKSTIME", PKSTIME)
            d.Add("PKETIME", PKETIME)
            d.Add("PKWKTPE", PKWKTPE)
            d.Add("PKUSERID", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
            d.Add("PKUPDATE", DateTimeInfo.GetRocDateTime(Now))

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("PKCARD", PKCARD)
            cd.Add("PKWDATE", PKWDATE)

            Return DAO.UpdateByExample("FSC_CPAPK" + yyymm, d, cd)
        End Function
    End Class
End Namespace
