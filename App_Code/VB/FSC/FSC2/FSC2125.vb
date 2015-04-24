Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class FSC2125
        Private DAO As FSC2125DAO

        Public Sub New()
            DAO = New FSC2125DAO()
        End Sub

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal yyymm As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, Depart_id, id_card, yyymm)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace
