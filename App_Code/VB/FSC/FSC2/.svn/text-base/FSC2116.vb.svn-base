Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2116
        Private DAO As FSC2116DAO

        Public Sub New()
            DAO = New FSC2116DAO()
        End Sub

        Public Function getQueryData(ByVal orgcode As String, _
                                 ByVal Depart_id As String, _
                                 ByVal Id_card As String, _
                                 ByVal Start_date As String, _
                                 ByVal End_date As String) As DataTable

            Return DAO.getQueryData(orgcode, Depart_id, Id_card, Start_date, End_date)
        End Function


    End Class
End Namespace