Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MaterialClass_data
        Public DAO As MaterialClass_dataDAO

        Public Sub New()
            DAO = New MaterialClass_dataDAO()
        End Sub


        Public Function GetData(ByVal item As String, ByVal code As String) As DataTable
            Dim dt As DataTable
            dt = DAO.GetData(item, code)
            'dt = DAO.GetData(item, code)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataByOrgCode(OrgCode As String) As DataTable
            If String.IsNullOrEmpty(OrgCode) Then Return Nothing
            Dim dt As DataTable = DAO.GetDataByOrgCode(OrgCode)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then Return Nothing
            Return dt
        End Function

        Public Function SelectData(ByVal item As String, ByVal code As String, ByVal orgcode As String) As DataTable
            Dim dt As DataTable
            dt = DAO.MAT0305SelectData(item, code, orgcode)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataDESCR(ByVal item As String, ByVal code As String, ByVal orgcode As String) As String
            Dim dt As DataTable = SelectData(item, code, orgcode)
            If dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)("DESCR").ToString
        End Function

        Public Function DeleteData(ByVal Index As String, ByVal item As String, ByVal code As String, ByVal orgcode As String) As DataTable
            Dim dt As DataTable
            Dim memo As String = ""
            dt = DAO.MAT0305DeleteData(Index, item, code, orgcode)
            Return dt
        End Function
        Public Function InsertGetData(ByVal Index As String, ByVal item As String, ByVal Next_id As String, ByVal Next_date As Date, ByVal Org_code As String) As String
            Dim dt As DataTable
            Dim memo As String = ""
            dt = SelectData(Index, memo, Org_code)
            If dt.Rows.Count > 0 Then
                memo = "分類號編號不可重複輸入。"
            Else
                memo = DAO.MAT0305InsertGetData(Index, item, Next_id, Next_date, Org_code)
            End If
            Return memo
        End Function
        Public Function MaintainData(ByVal Index As String, ByVal item As String, ByVal Next_id As String, ByVal Next_date As Date, ByVal Org_code As String) As String
            Dim dt As DataTable
            Dim memo As String = ""
            memo = DAO.MAT0305MaintainData(Index, item, Next_id, Next_date, Org_code)
            Return memo
        End Function
    End Class
End Namespace