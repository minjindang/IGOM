Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAT1122


        Public DAO As MAT1122DAO

        Public Sub New()
            DAO = New MAT1122DAO()
        End Sub

        Public Function MAT1122selectDepartName(ByVal Orgcode As String) As DataTable
            Return DAO.MAT1122selectDepartName(Orgcode)
        End Function

        Public Function MAT1122selectUerName(ByVal Orgcode As String) As DataTable
            Return DAO.MAT1122selectUerName(Orgcode)
        End Function

        Public Function MAT1122_Print(ByVal ucType As String, ByVal Depart_id As String, ByVal User_id As String, ByVal OrgCode As String) As DataTable
            Return DAO.MAT1122_Print(ucType, Depart_id, User_id, OrgCode)
        End Function


    End Class
End Namespace

