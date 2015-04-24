Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class SAL_TRAFFIC_FEE
        Public DAO As SAL_TRAFFIC_FEEDAO

        Public Sub New()
            DAO = New SAL_TRAFFIC_FEEDAO()
        End Sub

        Public Function GetOne(Id As Integer) As DataRow
            Dim dt As DataTable = DAO.SelectOne(Id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetDataByNoFlowId(orgcode As String, userId As String) As DataTable
            Return DAO.GetDataByNoFlowId(orgcode, userId)
        End Function

        Public Function GetAll(OrgCode As String, Optional User_id As String = "", Optional Flow_id As String = "") As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, User_id, Flow_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Function Add(Flow_id As String, unit_code As String, User_id As String, Apply_ymd As String, Pay_date As String, Fee_source As String, Org_code As String, ModUser_id As String, Mod_date As DateTime, _
                            Cost_date As String, Apply_amt As Integer, Apply_desc As String) As Integer

            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(unit_code) Then
                psList.Add(New SqlParameter("@unit_code", unit_code))
            Else
                psList.Add(New SqlParameter("@unit_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Apply_ymd) Then
                psList.Add(New SqlParameter("@Apply_ymd", Apply_ymd))
            Else
                psList.Add(New SqlParameter("@Apply_ymd", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Pay_date) Then
                psList.Add(New SqlParameter("@Pay_date", Pay_date))
            Else
                psList.Add(New SqlParameter("@Pay_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Fee_source) Then
                psList.Add(New SqlParameter("@Fee_source", Fee_source))
            Else
                psList.Add(New SqlParameter("@Fee_source", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", DBNull.Value))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", DBNull.Value))
            End If

            psList.Add(New SqlParameter("@Cost_date", Cost_date))
            psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            psList.Add(New SqlParameter("@Apply_desc", Apply_desc))

            Return DAO.Insert(psList.ToArray())
        End Function

        Public Sub Modify(Id As Integer, Flow_id As String, unit_code As String, User_id As String, Apply_ymd As String, Pay_date As String, Fee_source As String, Org_code As String, ModUser_id As String, Mod_date As DateTime, _
                          Cost_date As String, Apply_amt As Integer, Apply_desc As String)

            Dim dr As DataRow = GetOne(Id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@Id", Id))
            If Not String.IsNullOrEmpty(Flow_id) Then
                psList.Add(New SqlParameter("@Flow_id", Flow_id))
            Else
                psList.Add(New SqlParameter("@Flow_id", dr("Flow_id")))
            End If
            If Not String.IsNullOrEmpty(unit_code) Then
                psList.Add(New SqlParameter("@unit_code", unit_code))
            Else
                psList.Add(New SqlParameter("@unit_code", dr("unit_code")))
            End If
            If Not String.IsNullOrEmpty(User_id) Then
                psList.Add(New SqlParameter("@User_id", User_id))
            Else
                psList.Add(New SqlParameter("@User_id", dr("User_id")))
            End If
            If Not String.IsNullOrEmpty(Apply_ymd) Then
                psList.Add(New SqlParameter("@Apply_ymd", Apply_ymd))
            Else
                psList.Add(New SqlParameter("@Apply_ymd", dr("Apply_ymd")))
            End If
            If Not String.IsNullOrEmpty(Pay_date) Then
                psList.Add(New SqlParameter("@Pay_date", Pay_date))
            Else
                psList.Add(New SqlParameter("@Pay_date", dr("Pay_date")))
            End If
            If Not String.IsNullOrEmpty(Fee_source) Then
                psList.Add(New SqlParameter("@Fee_source", Fee_source))
            Else
                psList.Add(New SqlParameter("@Fee_source", dr("Fee_source")))
            End If
            If Not String.IsNullOrEmpty(Org_code) Then
                psList.Add(New SqlParameter("@Org_code", Org_code))
            Else
                psList.Add(New SqlParameter("@Org_code", dr("Org_code")))
            End If
            If Not String.IsNullOrEmpty(ModUser_id) Then
                psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            Else
                psList.Add(New SqlParameter("@ModUser_id", dr("ModUser_id")))
            End If
            If Not Mod_date = DateTime.MinValue Then
                psList.Add(New SqlParameter("@Mod_date", Mod_date))
            Else
                psList.Add(New SqlParameter("@Mod_date", dr("Mod_date")))
            End If
            If Not String.IsNullOrEmpty(Cost_date) Then
                psList.Add(New SqlParameter("@Cost_date", Cost_date))
            Else
                psList.Add(New SqlParameter("@Cost_date", dr("Cost_date")))
            End If
            If Apply_amt >= 0 Then
                psList.Add(New SqlParameter("@Apply_amt", Apply_amt))
            Else
                psList.Add(New SqlParameter("@Apply_amt", dr("Apply_amt")))
            End If
            If Not String.IsNullOrEmpty(Apply_desc) Then
                psList.Add(New SqlParameter("@Apply_desc", Apply_desc))
            Else
                psList.Add(New SqlParameter("@Apply_desc", dr("Apply_desc")))
            End If

            DAO.Update(psList.ToArray())

        End Sub

        Public Sub Remove(Id As Integer)
            DAO.Delete(Id)
        End Sub


        Public Function Delete(orgcode As String, flowId As String) As Boolean
            Return DAO.Delete(orgcode, flowId) > 0
        End Function
    End Class
End Namespace
