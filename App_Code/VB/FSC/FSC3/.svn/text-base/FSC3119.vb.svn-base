Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC3119
        Private DAO As FSC3119DAO

        Public Sub New()
            DAO = New FSC3119DAO()
        End Sub

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, _
                                        ByVal Apply_date As String, ByVal isReword As String) As DataTable
            Return DAO.getData(Orgcode, Depart_id, id_card, Apply_date, isReword)
        End Function
    End Class
End Namespace
