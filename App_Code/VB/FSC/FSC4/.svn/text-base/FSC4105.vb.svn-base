Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC4105
        Private DAO As FSC4105DAO

        Public Sub New()
            DAO = New FSC4105DAO()
        End Sub

        Public Function getQueryData(ByVal Orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Id_card As String, _
                                     ByVal Deputy_active As String, _
                                     ByVal user_name As String) As DataTable
            Return DAO.getQueryData(Orgcode, Depart_id, Id_card, Deputy_active, user_name)
        End Function

        Public Function updateDeputyactive(ByVal Id_card As String, ByVal Deputy_active As String, ByVal Deputy_active_idcard As String, _
                                           ByVal Deputy_active_sdate As String, ByVal Deputy_active_stime As String, _
                                           ByVal Deputy_active_edate As String, ByVal Deputy_active_etime As String) As Boolean
            Return DAO.updateDeputyactive(Id_card, Deputy_active, Deputy_active_idcard, Deputy_active_sdate, Deputy_active_stime, Deputy_active_edate, Deputy_active_etime) > 0
        End Function
    End Class
End Namespace
