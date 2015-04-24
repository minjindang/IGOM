Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3120
        Public DAO As FSC3120DAO

        Public Sub New()
            DAO = New FSC3120DAO
        End Sub

        Public Function getTitle() As DataTable
            Return DAO.getTitle()
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Title_no As String) As DataTable
            Return DAO.getData(Orgcode, Depart_id, Title_no)
        End Function
    End Class
End Namespace
