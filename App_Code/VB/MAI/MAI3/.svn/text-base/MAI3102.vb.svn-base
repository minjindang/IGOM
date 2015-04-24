Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace MAI.Logic
    Public Class MAI3102
        Private DAO As MAI3102DAO

        Public Sub New()
            DAO = New MAI3102DAO()
        End Sub

        Public Function getData(ByVal Orgcode As String, ByVal maintain_type As String, ByVal Apply_dateS As String, ByVal Apply_dataE As String, _
                        ByVal Apply_name As String, ByVal Apply_ext As String, ByVal Depart_id As String, ByVal Case_status As String) As DataTable
            Return DAO.getData(Orgcode, maintain_type, Apply_dateS, Apply_dataE, Apply_name, Apply_ext, Depart_id, Case_status)
        End Function
    End Class
End Namespace