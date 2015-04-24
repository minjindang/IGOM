Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT2106


        Public DAO As MAT2106DAO

        Public Sub New()
            DAO = New MAT2106DAO()
        End Sub

        Public Function MAT2106selectDepartName(ByVal Orgcode As String) As DataTable
            Return DAO.MAT2106selectDepartName(Orgcode)
        End Function

        Public Function MAT2106selectUerName(ByVal Orgcode As String) As DataTable
            Return DAO.MAT2106selectUerName(Orgcode)
        End Function

        Public Function MAT2106_Print(ByVal ucType As String, ByVal Depart_id As String, ByVal User_id As String, ByVal OrgCode As String) As DataTable
            Return DAO.MAT2106_Print(ucType, Depart_id, User_id, OrgCode)
        End Function


    End Class
End Namespace

