Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC3108
        Private DAO As FSC3108DAO

        Public Sub New()
            DAO = New FSC3108DAO()
        End Sub

        Public Function getData(ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHIDATE2 As String, ByVal PHITYPE As String, ByVal PHITIME As String) As DataTable
            Return DAO.getData(PHCARD, PHIDATE, PHIDATE2, PHITYPE, PHITIME)
        End Function

        Public Sub update(ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHITYPE As String, ByVal PHITIME As String, _
                            ByVal MPHIDATE As String, ByVal MPHITYPE As String, ByVal MPHITIME As String)
            DAO.update(PHCARD, PHIDATE, PHITYPE, PHITIME, MPHIDATE, MPHITYPE, MPHITIME)
        End Sub
    End Class
End Namespace