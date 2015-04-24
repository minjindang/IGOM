Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web

Namespace FSCPLM.Logic
    Public Class ApplyOtherMtrMain

        Public DAO As ApplyOtherMtrMainDAO

        Public Sub New()
            DAO = New ApplyOtherMtrMainDAO()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            DAO = New ApplyOtherMtrMainDAO(conn)
        End Sub

        Public Function GetOne(ByVal FormID As Integer) As DataRow
            Dim dt As DataTable = DAO.GetOne(FormID)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
            Return Nothing
        End Function

        Public Sub Update(ByVal Form_id As String, ByVal Flow_id As String, ByVal Apply_date As String, ByVal Unit_Code As String, ByVal User_id As String, ByVal TotalPrice_amt As Integer _
                      , ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String)
            Dim pMain As New PurchaseMain
            'If pMain.GetCountByFlowId(Flow_id) = 1 Then
            '    pMain.UpdateImportOtMtr("", Flow_id)
            'End If

            DAO.Update(Form_id, Flow_id, Apply_date, Unit_Code, User_id, TotalPrice_amt, ModUser_id, Mod_date, OrgCode)
        End Sub

        Public Function Insert(ByVal Flow_id As String, ByVal Apply_date As String, ByVal Unit_Code As String, ByVal User_id As String, ByVal TotalPrice_amt As Integer _
                      , ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String) As Integer
            Dim pMain As New PurchaseMain
            If Not String.IsNullOrEmpty(Flow_id) Then
                pMain.UpdateImportOtMtr("Y", Flow_id)
            End If
            Return DAO.Insert(Flow_id, Apply_date, Unit_Code, User_id, TotalPrice_amt, ModUser_id, Mod_date, OrgCode)
        End Function

        Public Function GetData(ByVal Apply_DateS As String, ByVal Apply_DateE As String, ByVal User_id As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Apply_DateS, Apply_DateE, User_id)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Sub Delete(ByVal Form_Id As Integer)
            DAO.Delete(Form_Id)
        End Sub

    End Class
End Namespace

