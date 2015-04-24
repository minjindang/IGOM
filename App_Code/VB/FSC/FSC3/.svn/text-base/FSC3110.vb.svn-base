Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC3110
        Private DAO As FSC3110DAO

        Public Sub New()
            DAO = New FSC3110DAO()
        End Sub

        Public Function getQueryData(ByVal Orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Id_card As String, _
                                     ByVal dateb As String, _
                                     ByVal datee As String, _
                                     ByVal case_status As String, _
                                     ByVal praytype As String) As DataTable

            Return DAO.getQueryData(Orgcode, Depart_id, Id_card, dateb, datee, case_status, praytype)
        End Function


    End Class
End Namespace