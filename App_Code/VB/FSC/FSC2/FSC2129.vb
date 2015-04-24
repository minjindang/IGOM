Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Namespace FSC.Logic
    Public Class FSC2129
        Private DAO As FSC2129DAO

        Public Sub New()
            DAO = New FSC2129DAO
        End Sub

        Function GetData(ByVal orgcode As String, _
                         ByVal idcard As String, _
                         ByVal yyy As String) As DataTable

            Return DAO.GetData(orgcode, idcard, yyy)

        End Function
    End Class
End Namespace