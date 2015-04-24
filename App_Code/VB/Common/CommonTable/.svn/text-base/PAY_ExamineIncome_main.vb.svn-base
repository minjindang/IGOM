Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_ExamineIncome_main
        Public DAO As PAY_ExamineIncome_mainDAO

        Public Sub New()
            DAO = New PAY_ExamineIncome_mainDAO()
        End Sub

        Public Function GetOne(ExamineIncome_type As String, OrgCode As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(ExamineIncome_type, OrgCode)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(Optional ExamineIncome_type As String = "", Optional notShow1220 As Boolean = False) As DataTable
            Dim dt As DataTable = DAO.SelectAll(LoginManager.OrgCode, ExamineIncome_type, notShow1220)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, ExamineIncome_type As String, ExamineIncome_name As String, PaymentCode As String, Unit As String, UnitPrice_amt As Double, LatestReceipt_nos As String, ModUser_id As String, Mod_date As DateTime)
            Dim psList As New List(Of SqlParameter)

            If Not String.IsNullOrEmpty(OrgCode) Then
                psList.Add(New SqlParameter("@OrgCode", OrgCode))
            Else
                psList.Add(New SqlParameter("@OrgCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ExamineIncome_type) Then
                psList.Add(New SqlParameter("@ExamineIncome_type", ExamineIncome_type))
            Else
                psList.Add(New SqlParameter("@ExamineIncome_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ExamineIncome_name) Then
                psList.Add(New SqlParameter("@ExamineIncome_name", ExamineIncome_name))
            Else
                psList.Add(New SqlParameter("@ExamineIncome_name", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PaymentCode) Then
                psList.Add(New SqlParameter("@PaymentCode", PaymentCode))
            Else
                psList.Add(New SqlParameter("@PaymentCode", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Unit) Then
                psList.Add(New SqlParameter("@Unit", Unit))
            Else
                psList.Add(New SqlParameter("@Unit", DBNull.Value))
            End If
            If Not UnitPrice_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@UnitPrice_amt", UnitPrice_amt))
            Else
                psList.Add(New SqlParameter("@UnitPrice_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(LatestReceipt_nos) Then
                psList.Add(New SqlParameter("@LatestReceipt_nos", LatestReceipt_nos))
            Else
                psList.Add(New SqlParameter("@LatestReceipt_nos", DBNull.Value))
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


            DAO.Insert(psList.ToArray())
        End Sub

        Public Sub Modify(OrgCode As String, ExamineIncome_type As String, ExamineIncome_name As String, PaymentCode As String, Unit As String, UnitPrice_amt As Double, LatestReceipt_nos As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(ExamineIncome_type, OrgCode)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@ExamineIncome_type", ExamineIncome_type))

            'If Not String.IsNullOrEmpty(ExamineIncome_name) Then
            psList.Add(New SqlParameter("@ExamineIncome_name", ExamineIncome_name))
            'Else
            '    psList.Add(New SqlParameter("@ExamineIncome_name", dr("ExamineIncome_name")))
            'End If
            'If Not String.IsNullOrEmpty(PaymentCode) Then
            psList.Add(New SqlParameter("@PaymentCode", PaymentCode))
            'Else
            '    psList.Add(New SqlParameter("@PaymentCode", dr("PaymentCode")))
            'End If
            'If Not String.IsNullOrEmpty(Unit) Then
            psList.Add(New SqlParameter("@Unit", Unit))
            'Else
            '    psList.Add(New SqlParameter("@Unit", dr("Unit")))
            'End If
            'If Not UnitPrice_amt = Double.MinValue Then
            psList.Add(New SqlParameter("@UnitPrice_amt", UnitPrice_amt))
            'Else
            '    psList.Add(New SqlParameter("@UnitPrice_amt", dr("UnitPrice_amt")))
            'End If
            'If Not String.IsNullOrEmpty(LatestReceipt_nos) Then
            psList.Add(New SqlParameter("@LatestReceipt_nos", LatestReceipt_nos))
            'Else
            '    psList.Add(New SqlParameter("@LatestReceipt_nos", dr("LatestReceipt_nos")))
            'End If
            'If Not String.IsNullOrEmpty(ModUser_id) Then
            psList.Add(New SqlParameter("@ModUser_id", ModUser_id))
            'Else
            '    psList.Add(New SqlParameter("@ModUser_id", dr("ModUser_id")))
            'End If
            'If Not Mod_date = DateTime.MinValue Then
            psList.Add(New SqlParameter("@Mod_date", Mod_date))
            'Else
            '    psList.Add(New SqlParameter("@Mod_date", dr("Mod_date")))
            'End If


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(ExamineIncome_type As String, OrgCode As String)
            DAO.Delete(ExamineIncome_type, OrgCode)
        End Sub

        Public Function CopySelect(Optional OrgCode As String = "", Optional ExamineIncome_type As String = "", Optional notShow1220 As Boolean = False) As DataTable
            Dim dt As DataTable = DAO.CopySelect(OrgCode, ExamineIncome_type, notShow1220)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

    End Class
End Namespace
