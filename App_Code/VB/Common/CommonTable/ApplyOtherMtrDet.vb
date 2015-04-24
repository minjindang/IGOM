Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web

Namespace FSCPLM.Logic
    Public Class ApplyOtherMtrDet
        Public DAO As ApplyOtherMtrDetDAO

        Public Sub New()
            DAO = New ApplyOtherMtrDetDAO()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            DAO = New ApplyOtherMtrDetDAO(conn)
        End Sub 

        Public Function GetCountByFomID(ByVal Form_Id As Integer) As Integer
            Return DAO.GetCountByFomID(Form_Id)
        End Function

        Public Function GetOne(ByVal details_id As Integer) As DataRow
            Dim dt As DataTable = DAO.GetOne(details_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            End If
            Return Nothing
        End Function

        Public Sub Update(ByVal Details_id As Integer, ByVal Form_id As Integer, ByVal Material_name As String, ByVal Unit As String, ByVal Out_cnt As Double, ByVal TotalPrice_amt As Double _
                      , ByVal Company_name As String, ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String)
            DAO.Update(Details_id, Form_id, Material_name, Unit, Out_cnt, TotalPrice_amt, Company_name, Memo, ModUser_id, Mod_date, OrgCode)
        End Sub

        Public Sub Insert(ByVal Form_id As Integer, ByVal Material_name As String, ByVal Unit As String, ByVal Out_cnt As Double, ByVal TotalPrice_amt As Double _
                      , ByVal Company_name As String, ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal OrgCode As String)
            DAO.Insert(Form_id, Material_name, Unit, Out_cnt, TotalPrice_amt, Company_name, Memo, ModUser_id, Mod_date, OrgCode)
        End Sub

        Public Sub Delete(ByVal Details_id As Integer)
            Dim main As New ApplyOtherMtrMain
            Dim drDetail As DataRow = GetOne(Details_id)
            Dim formID As Integer = drDetail("Form_id")
            Dim drMain As DataRow = main.GetOne(formID)
            Dim flowID As String = drMain("Flow_id")

            Dim pMain As New PurchaseMain
            If Not drDetail Is Nothing Then
                '若此主檔只有此明細檔 須將主檔一併移除
                If GetCountByFomID(formID) = 1 Then
                    main.Delete(formID)
                    '更新ImportOtMtr = ''
                    pMain.UpdateImportOtMtr("", flowID)
                End If
                'MAT_Purchase_main 的 flow_id count  = 1 則更新ImportOtMtr = ''
                'If pMain.GetCountByFlowId(flowID) = 1 Then
                '    pMain.UpdateImportOtMtr("", flowID)
                'End If
                DAO.Delete(Details_id)
            End If
        End Sub


    End Class
End Namespace

