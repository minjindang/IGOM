Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SAL.Logic

    Public Class SAL3103
        Public DAO As SAL3103DAO
        Public Sub New()
            DAO = New SAL3103DAO()
        End Sub

        Public Function getList_Code(ByVal Orgcode As String, ByVal operation As String) As DataTable
            Return DAO.getList_Code(Orgcode, operation)
        End Function

        Public Function getData(ByVal Orgocde As String, ByVal Operate As String, ByVal Code As String, ByVal Suspend As String) As DataTable
            Return DAO.getData(Orgocde, Operate, Code, Suspend)
        End Function

        Public Function delete(ByVal Orgcode As String, ByVal item_code As String) As Boolean
            Return DAO.delete(Orgcode, item_code) > 0
        End Function

        Public Function deleteSuspend(ByVal Orgcode As String, ByVal item_code As String) As Boolean
            Return DAO.deleteSuspend(Orgcode, item_code) > 0
        End Function
    End Class

End Namespace
