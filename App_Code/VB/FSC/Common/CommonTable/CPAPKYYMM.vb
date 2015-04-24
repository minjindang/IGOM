Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class CPAPKYYMM
        Private DAO As CPAPKYYMMDAO

        Public Sub New(ByVal yymm As String)
            DAO = New CPAPKYYMMDAO("CPAPK" & yymm)
        End Sub

        Public Sub New(ByVal yymm As String, ByVal conn As SqlConnection)
            DAO = New CPAPKYYMMDAO("CPAPK" & yymm, conn)
        End Sub

        Public Function HasTable() As Boolean
            Dim obj As Object = DAO.CheckHasTable()
            If obj Is Nothing Then Return False
            If CType(obj, Integer) <= 0 Then Return False
            Return True
        End Function

        Public Function GetDataByPKWDATE(ByVal PKIDNO As String, ByVal PKWDATE As String) As DataTable
            Return DAO.GetDataByPKWDATE(PKIDNO, PKWDATE)
        End Function

        Public Function GetUnNoramlData(ByVal PKIDNO As String) As DataTable
            Return DAO.GetUnNoramlData(PKIDNO)
        End Function


        Public Function GetUnNoramlData(ByVal PKCARD As String, ByVal PKWDATE As String) As DataTable
            Return DAO.GetUnNoramlData(PKCARD, PKWDATE)
        End Function

        Public Function DeleteCPAPKYYMM(ByVal PKCARD As String, ByVal PKWDATE As String) As Boolean
            Return DAO.DeleteData(PKCARD, PKWDATE) = 1
        End Function

        Public Function UpdateSTIME(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKSTIME As String, ByVal PKFORGET As String) As Boolean
            Return DAO.UpdateSTIME(PKIDNO, PKWDATE, PKSTIME, PKFORGET) = 1
        End Function

        Public Function UpdateETIME(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKETIME As String, ByVal PKFORGET As String) As Boolean
            Return DAO.UpdateETIME(PKIDNO, PKWDATE, PKETIME, PKFORGET) = 1
        End Function

        Public Function UpdateNTIME(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKNTIME As String, ByVal PKFORGET As String) As Boolean
            Return DAO.UpdateNTIME(PKIDNO, PKWDATE, PKNTIME, PKFORGET) = 1
        End Function

        Public Function GetCountByPKWDATE(ByVal PKWDATE As String, ByVal Card_type As String) As Integer
            Dim obj As Object = DAO.GetCountByPKWDATE(PKWDATE, Card_type)
            If obj Is Nothing Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetDataByPKIDNOandPKWDATE(ByVal PKIDNO As String, ByVal PKWDATE As String) As DataTable
            Return DAO.GetDataByPKIDNOandPKWDATE(PKIDNO, PKWDATE)
        End Function

        Public Function GetCountByPKWKTPE(ByVal PKCARD As String, ByVal PKWKTPE As String) As Integer
            Dim obj As Object = DAO.GetCountByPKWKTPE(PKCARD, PKWKTPE)
            If obj Is Nothing Then Return 0
            Return CType(obj, Integer)
        End Function
    End Class
End Namespace