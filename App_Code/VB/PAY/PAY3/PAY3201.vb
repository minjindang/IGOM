Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3201

        Public EIDDAO As PAY_ExamineIncome_det
        Public EIMDAO As PAY_ExamineIncome_main
        Public SCDAO As SACode

        Public Sub New()
            EIDDAO = New PAY_ExamineIncome_det()
            EIMDAO = New PAY_ExamineIncome_main()
            SCDAO = New SACode()
        End Sub

        Public Function Add(ExamineIncome_type As String, ReceiptStart_id As String, ReceiptEnd_id As String, Receipt_date As String, _
                        Payer_id As String, Payer_name As String, Examine_cnt As Double, UnitPrice_amt As Double, TotalPrice_amt As Double, _
                        PayMode_type As String, ReceiptScrap_type As Boolean, Check1_nos As String, Check2_nos As String) As String
            Try
                Dim msg As String = String.Empty

                EIDDAO.Add(LoginManager.OrgCode, ExamineIncome_type, ReceiptStart_id, ReceiptEnd_id, Receipt_date, _
                           Payer_id, Payer_name, Examine_cnt, UnitPrice_amt, TotalPrice_amt, _
                           PayMode_type, "", IIf(ReceiptScrap_type, "Y", "N"), Check1_nos, Check2_nos, _
                           LoginManager.UserId, Now)

                EIMDAO.Modify(LoginManager.OrgCode, ExamineIncome_type, "", "", "", Double.MinValue, ReceiptEnd_id, LoginManager.UserId, Now)

                Return msg
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Function Modify(ExamineIncome_type As String, ReceiptStart_id As String, ReceiptEnd_id As String, Receipt_date As String, _
                        Payer_id As String, Payer_name As String, Examine_cnt As Double, UnitPrice_amt As Double, TotalPrice_amt As Double, _
                        PayMode_type As String, ReceiptScrap_type As Boolean, Check1_nos As String, Check2_nos As String) As String
            Try
                Dim msg As String = String.Empty

                EIDDAO.Modify(LoginManager.OrgCode, ExamineIncome_type, ReceiptStart_id, ReceiptEnd_id, Receipt_date, _
                           Payer_id, Payer_name, Examine_cnt, UnitPrice_amt, TotalPrice_amt, _
                           PayMode_type, "", IIf(ReceiptScrap_type, "Y", "N"), Check1_nos, Check2_nos, _
                           LoginManager.UserId, Now)

                Return msg
            Catch ex As Exception
                Return ex.Message
            End Try
        End Function

        Public Function Remove(ExamineIncome_type As String, ReceiptStart_id As String) As String
            Dim msg As String = String.Empty
            Try
                EIDDAO.Remove(ExamineIncome_type, LoginManager.OrgCode, ReceiptStart_id)
            Catch ex As Exception
                msg = ex.Message
            End Try
            Return msg
        End Function

        Public Function GetAll(ExamineIncome_type As String, Receipt_id As String, Receipt_date As String, _
                                  Payer_id As String, PayMode_type As String, ReceiptScrap_type As Boolean, Check1_nos As String, _
                                  Check2_nos As String) As DataTable
            Dim dt As DataTable = EIDDAO.GetAll(LoginManager.OrgCode, ExamineIncome_type, Receipt_id, Receipt_date, _
                                               Payer_id, PayMode_type, IIf(ReceiptScrap_type, "Y", "N"), Check1_nos, Check2_nos)
            Dim newDT As New DataTable

            Try

                newDT.Columns.Add(New DataColumn("ExamineIncome_typeName"))
                newDT.Columns.Add(New DataColumn("ReceiptStart_id"))
                newDT.Columns.Add(New DataColumn("UnitPrice_amt"))
                newDT.Columns.Add(New DataColumn("Receipt_date"))
                newDT.Columns.Add(New DataColumn("Payer_id"))
                newDT.Columns.Add(New DataColumn("Payer_name"))
                newDT.Columns.Add(New DataColumn("PayMode_type"))
                newDT.Columns.Add(New DataColumn("Check1_nos"))
                newDT.Columns.Add(New DataColumn("Check2_nos"))
                newDT.Columns.Add(New DataColumn("ReceiptScrap_type"))
                newDT.Columns.Add(New DataColumn("ExamineIncome_type"))

                For Each dr As DataRow In dt.Rows
                    Dim newDR As DataRow = newDT.NewRow()

                    newDR("ExamineIncome_typeName") = CommonFun.SetDataRow(dr, "ExamineIncome_type") & " " & EIMDAO.GetOne(CommonFun.SetDataRow(dr, "ExamineIncome_type"), LoginManager.OrgCode)("ExamineIncome_name")
                    newDR("ReceiptStart_id") = CommonFun.SetDataRow(dr, "ReceiptStart_id")
                    newDR("UnitPrice_amt") = CommonFun.SetDataRow(dr, "UnitPrice_amt")
                    newDR("Receipt_date") = CommonFun.SetDataRow(dr, "Receipt_date")
                    newDR("Payer_id") = CommonFun.SetDataRow(dr, "Payer_id")
                    newDR("Payer_name") = CommonFun.SetDataRow(dr, "Payer_name")
                    newDR("PayMode_type") = SCDAO.GetCodeDesc("018", "003", CommonFun.SetDataRow(dr, "PayMode_type"))
                    newDR("Check1_nos") = CommonFun.SetDataRow(dr, "Check1_nos")
                    newDR("Check2_nos") = CommonFun.SetDataRow(dr, "Check2_nos")
                    newDR("ReceiptScrap_type") = IIf(CommonFun.SetDataRow(dr, "ReceiptScrap_type") = "Y", "已作廢", "")
                    newDR("ExamineIncome_type") = CommonFun.SetDataRow(dr, "ExamineIncome_type")
                    newDT.Rows.Add(newDR)
                Next
            Catch ex As Exception
                'CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
            End Try
            Return newDT
        End Function


    End Class
End Namespace
