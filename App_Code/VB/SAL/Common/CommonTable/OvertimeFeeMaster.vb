Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Namespace SAL.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OvertimeFeeMaster
        Public DAO As OvertimeFeeMasterDAO
        Public Sub New()
            DAO = New OvertimeFeeMasterDAO()
        End Sub

        Public Function GetOvertimeFeeMasterByQuery(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByQuery(Orgcode, Depart_id, Id_card, Fee_ym)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function InsertOvertimeFeeMaster(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String, _
                                ByVal budget_type As String, ByVal Normal_hour As Integer, ByVal Project_hour As Integer, ByVal Monthly_pay As Integer, ByVal hour_pay As Integer, _
                                ByVal Print_mark As String, ByVal flow_id As String) As Boolean

            Return DAO.InsertData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, budget_type, Normal_hour, Project_hour, Monthly_pay, hour_pay, Print_mark, flow_id) = 1
        End Function

        Public Function UpdateOvertimeFeeMaster(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                                ByVal Apply_seq As String, ByVal Normal_hour As Integer, ByVal Project_hour As Integer, _
                                                ByVal monthly_pay As Integer, ByVal hour_pay As Integer) As Boolean
            Return DAO.UpdateData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Normal_hour, Project_hour, monthly_pay, hour_pay) = 1
        End Function

        Public Function UpdatePrintMark(ByVal Orgcode As String, _
                                        ByVal Depart_id As String, _
                                        ByVal Id_card As String, _
                                        ByVal Fee_ym As String, _
                                        ByVal Apply_seq As String, _
                                        ByVal Print_mark As String) As Boolean

            Return DAO.UpdatePrintMark(Orgcode, Depart_id, Id_card, Fee_ym, "", Apply_seq, Print_mark) = 1
        End Function

        Public Function UpdatePrintMark2(ByVal Orgcode As String, _
                                         ByVal Depart_id As String, _
                                         ByVal Id_card As String, _
                                         ByVal Fee_ym As String, _
                                         ByVal Budget_type As String, _
                                         ByVal Apply_seq As String, _
                                         ByVal Print_mark As String) As Boolean

            Return DAO.UpdatePrintMark(Orgcode, Depart_id, Id_card, Fee_ym, Budget_type, Apply_seq, Print_mark) = 1
        End Function

        Public Function GetFSC130402OvertimeFee2(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As DataTable
            Dim ds As DataSet = DAO.GetFSC130402Data2(Orgcode, Depart_id, Fee_ym, Budget_type)
            If ds Is Nothing Then Return Nothing
            Dim dt As DataTable = ds.Tables(0)
            Dim B_Id_card As String = String.Empty, Id_card As String
            Dim i As Integer = 0, ndr As DataRow

            Dim Overtime_hour As Integer = 0, Apply_hour As Integer = 0

            Dim m As New FSC.Logic.Member
            'Dim c1 As New Code1

            dt.Columns.Add("User_name", GetType(String))
            dt.Columns.Add("Title_name", GetType(String))

            Dim pr18m As New FSC.Logic.CPAPR18M

            Dim ndt As New DataTable
            ndt = dt.Clone

            For Each dr As DataRow In dt.Rows
                Id_card = dr("Id_card").ToString()

                If B_Id_card <> Id_card And i <> 0 Then
                    ndr = ndt.NewRow
                    ndr("Overtime_End") = "合計"
                    ndr("Overtime_hour") = Overtime_hour
                    ndr("Apply_hour") = Apply_hour
                    Overtime_hour = 0
                    Apply_hour = 0
                    ndt.Rows.Add(ndr)
                End If

                B_Id_card = Id_card
                Overtime_hour += CommonFun.ConvertToInt(dr("Overtime_hour").ToString())
                Apply_hour += CommonFun.ConvertToInt(dr("Apply_hour").ToString())

                dr("User_name") = m.GetColumnValue("User_name", Id_card)
                'dr("Title_name") = c1.GetDataDESCR("EPT", m.GetColumnValue("Title_no", Id_card))

                ndt.ImportRow(dr)
                i += 1
            Next

            If i = dt.Rows.Count And i <> 0 Then
                ndr = ndt.NewRow
                ndr("Overtime_End") = "合計"
                ndr("Overtime_hour") = Overtime_hour
                ndr("Apply_hour") = Apply_hour
                ndt.Rows.Add(ndr)
            End If

            Return ndt
        End Function


        Public Function GetprpayfeeByYear(ByVal orgcode As String, ByVal budget_type As String, ByVal fee_ym As String, Optional ByVal Depart_id As String = Nothing) As Integer
            Dim obj As Object = DAO.GetprpayfeeByYear(orgcode, budget_type, fee_ym, Depart_id)
            If IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetprpayfeeBySession(ByVal orgcode As String, ByVal depart_id As String, ByVal budget_type As String, ByVal fee_ym As String) As DataTable
            Dim ds As DataSet = DAO.GetprpayfeeBySession(orgcode, depart_id, budget_type, fee_ym)
            Return ds.Tables(0)
        End Function

        Public Function GetprpayfeeByMonth(ByVal orgcode As String, ByVal depart_id As String, ByVal budget_type As String, ByVal fee_ym As String) As DataTable
            Dim ds As DataSet = DAO.GetprpayfeeByMonth(orgcode, depart_id, budget_type, fee_ym)
            Return ds.Tables(0)
        End Function

        Public Function GetSumPay(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Integer
            Dim obj As Object = DAO.GetSumPay(Orgcode, Depart_id, Fee_ym, Budget_type)
            If IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetHadSumPay(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Integer
            Dim obj As Object = DAO.GetHadSumPay(Orgcode, Depart_id, Fee_ym, Budget_type)
            If IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetSumPayS(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Integer
            Dim obj As Object = DAO.GetSumPayS(Orgcode, Depart_id, Fee_ym, Budget_type)
            If IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function


        Public Function GetHadSumPayS(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Integer
            Dim obj As Object = DAO.GetHadSumPayS(Orgcode, Depart_id, Fee_ym, Budget_type)
            If IsDBNull(obj) Then Return 0
            Return CType(obj, Integer)
        End Function

        Public Function GetSum_seq(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As String
            Dim obj As Object = DAO.GetMaxSum_seq(Orgcode, Depart_id, Fee_ym, Budget_type)
            If IsDBNull(obj) Then Return "1"
            Return Convert.ToString(CommonFun.ConvertToInt(CType(obj, String)) + 1)
        End Function


        Public Function UpdateSumData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                   ByVal Budget_type As String, ByVal Apply_seq As String, ByVal Sum_date As String, ByVal Sum_seq As String) As Boolean
            Return DAO.UpdateSumData(Orgcode, Depart_id, Id_card, Fee_ym, Budget_type, Apply_seq, Sum_date, Sum_seq) = 1
        End Function


        Public Function DeleteOvertimeFeeMaster(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As Boolean
            Return DAO.DeleteData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq) = 1
        End Function

        Public Function getDataByFlowid(ByVal Orgcode As String, ByVal flow_id As String) As DataTable
            Dim ds As DataSet = DAO.getDataByFlowid(Orgcode, flow_id)
            If ds Is Nothing Then Return Nothing

            Return ds.Tables(0)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal flow_id As String) As DataTable
            Return DAO.GetData(Orgcode, flow_id)
        End Function

        Public Function updateSumPrint(ByVal Orgcode As String, ByVal flow_id As String, ByVal Sum_Date As String, ByVal Print_Mark As String) As Boolean
            Return DAO.updateSumPrint(Orgcode, flow_id, Sum_Date, Print_Mark)
        End Function

        Public Function updatePayMark(ByVal orgcode As String, ByVal flow_id As String, ByVal Pay_Mark As String) As Boolean
            Return DAO.updatePayMark(orgcode, flow_id, Pay_Mark)
        End Function
    End Class
End Namespace