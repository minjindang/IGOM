Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SALARY.Logic
    <System.ComponentModel.DataObject()> _
    Public Class SAL3110
        Public DAO As SAL3110DAO
        Public Sub New()
            DAO = New SAL3110DAO()
        End Sub

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDataByMonthRange(ByVal Orgcode As String, ByVal sMonth As String, ByVal eMonth As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByMonthRange(Orgcode, sMonth, eMonth)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        '<System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function CheckInsert(ByVal UserId As String) As Integer
            Dim ds As DataSet = DAO.CheckInsert(UserId)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0).Rows.Count
        End Function


    End Class
End Namespace