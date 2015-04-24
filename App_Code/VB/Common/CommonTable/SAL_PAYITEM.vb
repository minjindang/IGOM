Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_PAYITEM
        Public DAO As SAL_PAYITEMDAO

        Public Sub New()
            DAO = New SAL_PAYITEMDAO()
        End Sub

        Public Function GetOne() As DataRow
            Dim dt As DataTable = DAO.SelectOne()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll() As DataTable
            Dim dt As DataTable = DAO.SelectAll()
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(PAYITEM_Org_Code As String, PAYITEM_User_id As String, PAYITEM_Flow_id As String, PAYITEM_Merge_flow_id As String, PAYITEM_CodeSys As String, _
PAYITEM_CodeKind As String, PAYITEM_CodeType As String, PAYITEM_CodeNo As String, PAYITEM_Code As String, PAYITEM_Pay_ym As String, _
PAYITEM_Pay_date As String, PAYITEM_Budget_code As String, PAYITEM_Pay_amt As Double, PAYITEM_ModUser_id As String, PAYITEM_Mod_date As DateTime, PAYITEM_Memo As String)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(PAYITEM_Org_Code) Then
                psList.Add(New SqlParameter("@PAYITEM_Org_Code", PAYITEM_Org_Code))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Org_Code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_User_id) Then
                psList.Add(New SqlParameter("@PAYITEM_User_id", PAYITEM_User_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Flow_id) Then
                psList.Add(New SqlParameter("@PAYITEM_Flow_id", PAYITEM_Flow_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Merge_flow_id) Then
                psList.Add(New SqlParameter("@PAYITEM_Merge_flow_id", PAYITEM_Merge_flow_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Merge_flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeSys) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeSys", PAYITEM_CodeSys))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeSys", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeKind) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeKind", PAYITEM_CodeKind))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeKind", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeType) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeType", PAYITEM_CodeType))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeType", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeNo) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeNo", PAYITEM_CodeNo))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeNo", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Code) Then
                psList.Add(New SqlParameter("@PAYITEM_Code", PAYITEM_Code))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Pay_ym) Then
                psList.Add(New SqlParameter("@PAYITEM_Pay_ym", PAYITEM_Pay_ym))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Pay_ym", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Pay_date) Then
                psList.Add(New SqlParameter("@PAYITEM_Pay_date", PAYITEM_Pay_date))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Pay_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Budget_code) Then
                psList.Add(New SqlParameter("@PAYITEM_Budget_code", PAYITEM_Budget_code))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Budget_code", DBNull.Value))
            End If
            If Not PAYITEM_Pay_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@PAYITEM_Pay_amt", PAYITEM_Pay_amt))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Pay_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_ModUser_id) Then
                psList.Add(New SqlParameter("@PAYITEM_ModUser_id", PAYITEM_ModUser_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_ModUser_id", DBNull.Value))
            End If
            If Not PAYITEM_Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@PAYITEM_Mod_date", PAYITEM_Mod_date))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Mod_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Memo) Then
                psList.Add(New SqlParameter("@PAYITEM_Memo", PAYITEM_Memo))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Memo", DBNull.Value))
            End If


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(PAYITEM_Org_Code As String, PAYITEM_User_id As String, PAYITEM_Flow_id As String, PAYITEM_Merge_flow_id As String, PAYITEM_CodeSys As String, _
PAYITEM_CodeKind As String, PAYITEM_CodeType As String, PAYITEM_CodeNo As String, PAYITEM_Code As String, PAYITEM_Pay_ym As String, _
PAYITEM_Pay_date As String, PAYITEM_Budget_code As String, PAYITEM_Pay_amt As Double, PAYITEM_ModUser_id As String, PAYITEM_Mod_date As DateTime, PAYITEM_Memo As String)

            Dim dr As DataRow = GetOne()

            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(PAYITEM_Org_Code) Then
                psList.Add(New SqlParameter("@PAYITEM_Org_Code", PAYITEM_Org_Code))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Org_Code", dr("PAYITEM_Org_Code")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_User_id) Then
                psList.Add(New SqlParameter("@PAYITEM_User_id", PAYITEM_User_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_User_id", dr("PAYITEM_User_id")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Flow_id) Then
                psList.Add(New SqlParameter("@PAYITEM_Flow_id", PAYITEM_Flow_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Flow_id", dr("PAYITEM_Flow_id")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Merge_flow_id) Then
                psList.Add(New SqlParameter("@PAYITEM_Merge_flow_id", PAYITEM_Merge_flow_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Merge_flow_id", dr("PAYITEM_Merge_flow_id")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeSys) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeSys", PAYITEM_CodeSys))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeSys", dr("PAYITEM_CodeSys")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeKind) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeKind", PAYITEM_CodeKind))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeKind", dr("PAYITEM_CodeKind")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeType) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeType", PAYITEM_CodeType))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeType", dr("PAYITEM_CodeType")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_CodeNo) Then
                psList.Add(New SqlParameter("@PAYITEM_CodeNo", PAYITEM_CodeNo))
            Else
                psList.Add(New SqlParameter("@PAYITEM_CodeNo", dr("PAYITEM_CodeNo")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Code) Then
                psList.Add(New SqlParameter("@PAYITEM_Code", PAYITEM_Code))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Code", dr("PAYITEM_Code")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Pay_ym) Then
                psList.Add(New SqlParameter("@PAYITEM_Pay_ym", PAYITEM_Pay_ym))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Pay_ym", dr("PAYITEM_Pay_ym")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Pay_date) Then
                psList.Add(New SqlParameter("@PAYITEM_Pay_date", PAYITEM_Pay_date))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Pay_date", dr("PAYITEM_Pay_date")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Budget_code) Then
                psList.Add(New SqlParameter("@PAYITEM_Budget_code", PAYITEM_Budget_code))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Budget_code", dr("PAYITEM_Budget_code")))
            End If
            If Not PAYITEM_Pay_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@PAYITEM_Pay_amt", PAYITEM_Pay_amt))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Pay_amt", dr("PAYITEM_Pay_amt")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_ModUser_id) Then
                psList.Add(New SqlParameter("@PAYITEM_ModUser_id", PAYITEM_ModUser_id))
            Else
                psList.Add(New SqlParameter("@PAYITEM_ModUser_id", dr("PAYITEM_ModUser_id")))
            End If
            If Not PAYITEM_Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@PAYITEM_Mod_date", PAYITEM_Mod_date))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Mod_date", dr("PAYITEM_Mod_date")))
            End If
            If Not String.IsNullOrEmpty(PAYITEM_Memo) Then
                psList.Add(New SqlParameter("@PAYITEM_Memo", PAYITEM_Memo))
            Else
                psList.Add(New SqlParameter("@PAYITEM_Memo", dr("PAYITEM_Memo")))
            End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove()
            DAO.Delete()
        End Sub

    End Class
End Namespace
