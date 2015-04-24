Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC3201
        Private DAO As FSC3201DAO

        Public Sub New()
            DAO = New FSC3201DAO()
        End Sub

        Public Function DoDeleteOldData(ByVal Orgcode As String, ByVal Depart_id As String, _
                                        ByVal id_card As String, ByVal Sdate As String, ByVal Edate As String) As Boolean
            Return DAO.DoDeleteOldData(Orgcode, Depart_id, id_card, Sdate, Edate)
        End Function
    End Class
End Namespace
