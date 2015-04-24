Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC2131
        Private DAO As FSC2131DAO

        Public Sub New()
            DAO = New FSC2131DAO()
        End Sub

        Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal POIDNO As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Return DAO.GetQueryData(Orgcode, Depart_id, POIDNO, StartDate, EndDate)
        End Function

        Function getDetailData(ByVal IdCard As String, ByVal StartDate As String, ByVal EndDate As String) As DataTable
            Return DAO.GetQueryDetailData(IdCard, StartDate, EndDate)
        End Function

        Function GetWorkDays(ByVal StartDate As String, ByVal EndDate As String) As String
            Dim obj As Object = DAO.GetWorkDays(StartDate, EndDate)

            If obj Is Nothing Then Return "0"

            Return CType(obj, String).ToString()
        End Function
    End Class
End Namespace