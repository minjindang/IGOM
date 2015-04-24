Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic

    Public Class PAY_ExamineIncome_det
        Public DAO As PAY_ExamineIncome_detDAO

        Public Sub New()
            DAO = New PAY_ExamineIncome_detDAO()
        End Sub

        Public Function GetOne(ExamineIncome_type As String, OrgCode As String, ReceiptStart_id As String) As DataRow
            Dim dt As DataTable = DAO.SelectOne(ExamineIncome_type, OrgCode, ReceiptStart_id)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)
            Else
                Return Nothing
            End If
        End Function

        Public Function GetAll(OrgCode As String, ExamineIncome_type As String, Receipt_id As String, Receipt_date As String, _
                                  Payer_id As String, PayMode_type As String, ReceiptScrap_type As String, Check1_nos As String, _
                                  Check2_nos As String) As DataTable
            Dim dt As DataTable = DAO.SelectAll(OrgCode, ExamineIncome_type, Receipt_id, Receipt_date, _
                                                Payer_id, PayMode_type, ReceiptScrap_type, Check1_nos, Check2_nos)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt
            Else
                Return Nothing
            End If
        End Function

        Public Sub Add(OrgCode As String, ExamineIncome_type As String, ReceiptStart_id As String, ReceiptEnd_id As String, Receipt_date As String, _
                        Payer_id As String, Payer_name As String, Examine_cnt As Double, UnitPrice_amt As Double, TotalPrice_amt As Double, _
                        PayMode_type As String, KeyIn_type As String, ReceiptScrap_type As String, Check1_nos As String, Check2_nos As String, ModUser_id As String, Mod_date As DateTime)
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
            If Not String.IsNullOrEmpty(ReceiptStart_id) Then
                psList.Add(New SqlParameter("@ReceiptStart_id", ReceiptStart_id))
            Else
                psList.Add(New SqlParameter("@ReceiptStart_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ReceiptEnd_id) Then
                psList.Add(New SqlParameter("@ReceiptEnd_id", ReceiptEnd_id))
            Else
                psList.Add(New SqlParameter("@ReceiptEnd_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Receipt_date) Then
                psList.Add(New SqlParameter("@Receipt_date", Receipt_date))
            Else
                psList.Add(New SqlParameter("@Receipt_date", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Payer_id) Then
                psList.Add(New SqlParameter("@Payer_id", Payer_id))
            Else
                psList.Add(New SqlParameter("@Payer_id", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Payer_name) Then
                psList.Add(New SqlParameter("@Payer_name", Payer_name))
            Else
                psList.Add(New SqlParameter("@Payer_name", DBNull.Value))
            End If
            If Not Examine_cnt = Double.MinValue Then
                psList.Add(New SqlParameter("@Examine_cnt", Examine_cnt))
            Else
                psList.Add(New SqlParameter("@Examine_cnt", DBNull.Value))
            End If
            If Not UnitPrice_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@UnitPrice_amt", UnitPrice_amt))
            Else
                psList.Add(New SqlParameter("@UnitPrice_amt", DBNull.Value))
            End If
            If Not TotalPrice_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@TotalPrice_amt", TotalPrice_amt))
            Else
                psList.Add(New SqlParameter("@TotalPrice_amt", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(PayMode_type) Then
                psList.Add(New SqlParameter("@PayMode_type", PayMode_type))
            Else
                psList.Add(New SqlParameter("@PayMode_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(KeyIn_type) Then
                psList.Add(New SqlParameter("@KeyIn_type", KeyIn_type))
            Else
                psList.Add(New SqlParameter("@KeyIn_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(ReceiptScrap_type) Then
                psList.Add(New SqlParameter("@ReceiptScrap_type", ReceiptScrap_type))
            Else
                psList.Add(New SqlParameter("@ReceiptScrap_type", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Check1_nos) Then
                psList.Add(New SqlParameter("@Check1_nos", Check1_nos))
            Else
                psList.Add(New SqlParameter("@Check1_nos", DBNull.Value))
            End If
            If Not String.IsNullOrEmpty(Check2_nos) Then
                psList.Add(New SqlParameter("@Check2_nos", Check2_nos))
            Else
                psList.Add(New SqlParameter("@Check2_nos", DBNull.Value))
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

        Public Sub Modify(OrgCode As String, ExamineIncome_type As String, ReceiptStart_id As String, ReceiptEnd_id As String, Receipt_date As String, _
                            Payer_id As String, Payer_name As String, Examine_cnt As Double, UnitPrice_amt As Double, TotalPrice_amt As Double, _
                            PayMode_type As String, KeyIn_type As String, ReceiptScrap_type As String, Check1_nos As String, Check2_nos As String, ModUser_id As String, Mod_date As DateTime)

            Dim dr As DataRow = GetOne(ExamineIncome_type, OrgCode, ReceiptStart_id)

            Dim psList As New List(Of SqlParameter)

            psList.Add(New SqlParameter("@ExamineIncome_type", ExamineIncome_type))
            psList.Add(New SqlParameter("@OrgCode", OrgCode))
            psList.Add(New SqlParameter("@ReceiptStart_id", ReceiptStart_id))
            If Not String.IsNullOrEmpty(ReceiptEnd_id) Then
                psList.Add(New SqlParameter("@ReceiptEnd_id", ReceiptEnd_id))
            Else
                psList.Add(New SqlParameter("@ReceiptEnd_id", dr("ReceiptEnd_id")))
            End If
            If Not String.IsNullOrEmpty(Receipt_date) Then
                psList.Add(New SqlParameter("@Receipt_date", Receipt_date))
            Else
                psList.Add(New SqlParameter("@Receipt_date", dr("Receipt_date")))
            End If
            If Not String.IsNullOrEmpty(Payer_id) Then
                psList.Add(New SqlParameter("@Payer_id", Payer_id))
            Else
                psList.Add(New SqlParameter("@Payer_id", dr("Payer_id")))
            End If
            If Not String.IsNullOrEmpty(Payer_name) Then
                psList.Add(New SqlParameter("@Payer_name", Payer_name))
            Else
                psList.Add(New SqlParameter("@Payer_name", dr("Payer_name")))
            End If
            If Not Examine_cnt = Double.MinValue Then
                psList.Add(New SqlParameter("@Examine_cnt", Examine_cnt))
            Else
                psList.Add(New SqlParameter("@Examine_cnt", dr("Examine_cnt")))
            End If
            If Not UnitPrice_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@UnitPrice_amt", UnitPrice_amt))
            Else
                psList.Add(New SqlParameter("@UnitPrice_amt", dr("UnitPrice_amt")))
            End If
            If Not TotalPrice_amt = Double.MinValue Then
                psList.Add(New SqlParameter("@TotalPrice_amt", TotalPrice_amt))
            Else
                psList.Add(New SqlParameter("@TotalPrice_amt", dr("TotalPrice_amt")))
            End If
            If Not String.IsNullOrEmpty(PayMode_type) Then
                psList.Add(New SqlParameter("@PayMode_type", PayMode_type))
            Else
                psList.Add(New SqlParameter("@PayMode_type", dr("PayMode_type")))
            End If
            If Not String.IsNullOrEmpty(KeyIn_type) Then
                psList.Add(New SqlParameter("@KeyIn_type", KeyIn_type))
            Else
                psList.Add(New SqlParameter("@KeyIn_type", dr("KeyIn_type")))
            End If
            If Not String.IsNullOrEmpty(ReceiptScrap_type) Then
                psList.Add(New SqlParameter("@ReceiptScrap_type", ReceiptScrap_type))
            Else
                psList.Add(New SqlParameter("@ReceiptScrap_type", dr("ReceiptScrap_type")))
            End If
            If Not String.IsNullOrEmpty(Check1_nos) Then
                psList.Add(New SqlParameter("@Check1_nos", Check1_nos))
            Else
                psList.Add(New SqlParameter("@Check1_nos", dr("Check1_nos")))
            End If
            If Not String.IsNullOrEmpty(Check2_nos) Then
                psList.Add(New SqlParameter("@Check2_nos", Check2_nos))
            Else
                psList.Add(New SqlParameter("@Check2_nos", dr("Check2_nos")))
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


            DAO.Update(psList.ToArray())


        End Sub

        Public Sub Remove(ExamineIncome_type As String, OrgCode As String, ReceiptStart_id As String)
            DAO.Delete(ExamineIncome_type, OrgCode, ReceiptStart_id)
        End Sub

    End Class
End Namespace
