Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports FSCPLM.Logic

Namespace SYS.Logic
    Public Class ProcessSAL
        Inherits Process

        Public Overrides Sub RunAgreeFlow(ByVal flow As Flow)
            RunLastApply(flow, True)
        End Sub

        Public Overrides Sub RunCancelFlow(ByVal flow As SYS.Logic.Flow)
            RunLastApply(flow, False)
        End Sub

        Public Overrides Sub RunDeleteFlow(ByVal flow As SYS.Logic.Flow)
            ''取消加班費申請
            If flow.FormId = "002001" Then
                DeleteOvertimeFeeApply(flow.Orgcode, flow.FlowId)
                DeleteLabOvertimeFeeApply(flow.Orgcode, flow.FlowId)
            End If

            'by jessica add 1030509
            '差旅費申請, 按下取消時, 要一併把SAL_officialout_fee的資料刪除
            If flow.FormId = "002002" Then
                Dim ofee As New SAL.Logic.SAL_OfficialoutFee()
                Dim dt As DataTable = ofee.GetDataByOrgFid(flow.Orgcode, flow.FlowId)
                For Each dr As DataRow In dt.Rows
                    Dim bll As New FSC.Logic.CPAPP16M
                    bll.UpdateReMarkByGUID(dr("PPGUID").ToString(), "0")
                Next
                ofee.deleteDataBySYS_FlowId(flow.Orgcode, flow.FlowId)
            End If
        End Sub


        Public Overrides Sub RunRejectFlow(ByVal flow As SYS.Logic.Flow)
            'by jessica modi
            '差旅費申請退回，也需要一併更新SAL_officialout_fee.status = 'apply'
            If flow.FormId = "002002" Then
                Dim ofee As New SAL.Logic.SAL_OfficialoutFee()
                If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                    Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                    Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                    For Each f As SYS.Logic.Flow In list
                        Dim dt As DataTable = ofee.GetDataByOrgFid(f.Orgcode, f.FlowId)
                        For Each dr As DataRow In dt.Rows
                            Dim bll As New FSC.Logic.CPAPP16M
                            bll.UpdateReMarkByGUID(dr("PPGUID").ToString(), "0")
                        Next
                        ofee.UpdateStatusBySysFlowID(f.FlowId, "apply")
                    Next
                Else
                    Dim dt As DataTable = ofee.GetDataByOrgFid(flow.Orgcode, flow.FlowId)
                    For Each dr As DataRow In dt.Rows
                        Dim bll As New FSC.Logic.CPAPP16M
                        bll.UpdateReMarkByGUID(dr("PPGUID").ToString(), "0")
                    Next
                    ofee.UpdateStatusBySysFlowID(flow.FlowId, "apply")
                End If
            End If

        End Sub

        Public Sub RunLastApply(ByVal flow As SYS.Logic.Flow, ByVal isPlus As Boolean)
            Dim Form_id As String = flow.FormId

            If Not isPlus Then '撤銷

                '費用不可撤銷

                'If Form_id = "002001" Then '加班費請領
                '    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                '        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                '        Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                '        For Each f As SYS.Logic.Flow In list
                '            DeleteOvertimeFeeApply(f.Orgcode, f.FlowId)
                '        Next
                '    Else
                '        DeleteOvertimeFeeApply(flow.Orgcode, flow.FlowId)
                '    End If
                '
                '    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                '        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                '        Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                '        For Each f As SYS.Logic.Flow In list
                '            DeleteLabOvertimeFeeApply(f.Orgcode, f.FlowId)
                '        Next
                '    Else
                '        DeleteLabOvertimeFeeApply(flow.Orgcode, flow.FlowId)
                '    End If
                'End If

            Else
                If Form_id = "002001" Then '加班費請領

                    Dim ofm As SAL.Logic.OvertimeFeeMaster = New SAL.Logic.OvertimeFeeMaster
                    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                        Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                        For Each f As SYS.Logic.Flow In list
                            ofm.updatePayMark(f.Orgcode, f.FlowId, "Y")

                            Dim dt As DataTable = ofm.getDataByFlowid(f.Orgcode, f.FlowId)
                            Dim pay_amt As Integer = (Convert.ToInt32(dt.Rows(0)("Normal_Hour")) + Convert.ToInt32(dt.Rows(0)("Project_Hour"))) * Convert.ToInt32(dt.Rows(0)("Hour_Pay"))
                            Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                            payDAO.Add(f.Orgcode, f.ApplyIdcard, f.FlowId, f.MergeFlowid, "005", "D", "001", "601", "010", _
                                   "", "", f.Budget_code, pay_amt, LoginManager.UserId, Now, "")
                        Next
                    Else
                        ofm.updatePayMark(flow.Orgcode, flow.FlowId, "Y")

                        Dim dt As DataTable = ofm.getDataByFlowid(flow.Orgcode, flow.FlowId)
                        Dim pay_amt As Integer = (Convert.ToInt32(dt.Rows(0)("Normal_Hour")) + Convert.ToInt32(dt.Rows(0)("Project_Hour"))) * Convert.ToInt32(dt.Rows(0)("Hour_Pay"))
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(flow.Orgcode, flow.ApplyIdcard, flow.FlowId, flow.FlowId, "005", "D", "001", "601", "010", _
                               "", "", flow.Budget_code, pay_amt, LoginManager.UserId, Now, "")
                    End If


                    Dim labofm As SAL.Logic.LabOvertimeFeeMaster = New SAL.Logic.LabOvertimeFeeMaster
                    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                        Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                        For Each f As SYS.Logic.Flow In list
                            labofm.updatePayMark(f.Orgcode, f.FlowId, "Y")

                            Dim dt As DataTable = labofm.getDataByFlowid(f.Orgcode, f.FlowId)
                            Dim pay_amt As Integer = Convert.ToInt32(dt.Rows(0)("Overtime_Fee"))
                            Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                            payDAO.Add(f.Orgcode, f.ApplyIdcard, f.FlowId, f.FlowId, "005", "D", "001", "601", "010", _
                                   "", "", f.Budget_code, pay_amt, LoginManager.UserId, Now, "")
                        Next
                    Else
                        labofm.updatePayMark(flow.Orgcode, flow.FlowId, "Y")

                        Dim dt As DataTable = labofm.getDataByFlowid(flow.Orgcode, flow.FlowId)
                        Dim pay_amt As Integer = Convert.ToInt32(dt.Rows(0)("Overtime_Fee"))
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(flow.Orgcode, flow.ApplyIdcard, flow.FlowId, flow.MergeFlowid, "005", "D", "001", "601", "010", _
                               "", "", flow.Budget_code, pay_amt, LoginManager.UserId, Now, "")
                    End If


                ElseIf Form_id = "002002" Then '差旅費
                    Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                    Dim outfee As New SAL.Logic.SAL_OfficialoutFee()

                    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then

                        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                        Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                        For Each f As SYS.Logic.Flow In list
                            Dim pay_amt As Integer = 0
                            Dim dt As DataTable = outfee.GetDataByOrgFid(f.Orgcode, f.FlowId)
                            For Each dr As DataRow In dt.Rows
                                pay_amt += dr("plane") + dr("car") + dr("train") + dr("boat") + dr("bus") + dr("mrt") + dr("othertraffic") + dr("live") + dr("food") + dr("sudden") + dr("others")
                            Next

                            payDAO.Add(f.Orgcode, f.ApplyIdcard, f.FlowId, f.MergeFlowid, "005", "D", "001", "406", "027", _
                              "", "", f.Budget_code, pay_amt, LoginManager.UserId, Now, "")

                            outfee.UpdateStatus(f.Orgcode, f.FlowId, "done")
                        Next

                    Else

                        Dim pay_amt As Integer = 0
                        Dim dt As DataTable = outfee.GetDataByOrgFid(flow.Orgcode, flow.FlowId)
                        For Each dr As DataRow In dt.Rows
                            pay_amt += dr("plane") + dr("car") + dr("train") + dr("boat") + dr("bus") + dr("mrt") + dr("othertraffic") + dr("live") + dr("food") + dr("sudden") + ("others")
                        Next

                        payDAO.Add(flow.Orgcode, flow.ApplyIdcard, flow.FlowId, flow.FlowId, "005", "D", "001", "406", "027", _
                            "", "", flow.Budget_code, pay_amt, LoginManager.UserId, Now, "")

                        outfee.UpdateStatus(flow.Orgcode, flow.FlowId, "done")
                    End If


                ElseIf Form_id = "002003" Then '短程車費


                    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                        Dim list As IList(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                        For Each f As SYS.Logic.Flow In list
                            UpdateTrafficPAYITEM(f)
                        Next
                    Else
                        flow.MergeFlowid = flow.FlowId
                        UpdateTrafficPAYITEM(flow)
                    End If


                ElseIf Form_id = "002011" Then '結婚生育及喪葬補助費

                    Dim trDAO As New SAL_ALLOWANCE_fee
                    Dim dr As DataRow = trDAO.GetAll(flow.Orgcode, "", flow.FlowId).Rows(0)
                    Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()

                    Dim code_no As String = ""
                    Dim code As String = ""

                    If dr("Apply_type").ToString().Equals("001") Then
                        code_no = "502"
                        code = "007"
                    ElseIf dr("Apply_type").ToString().Equals("002") Then
                        code_no = "503"
                        code = "008"
                    ElseIf dr("Apply_type").ToString().Equals("003") Then
                        code_no = "504"
                        code = "009"
                    End If


                    payDAO.Add(flow.Orgcode, dr("User_id").ToString(), flow.FlowId, IIf(String.IsNullOrEmpty(flow.MergeFlowid), flow.FlowId, flow.MergeFlowid), "005", "D", "001", code_no, code, _
                                "", "", flow.Budget_code, Convert.ToInt32(dr("Apply_amt")), LoginManager.UserId, Now, "")
                ElseIf Form_id = "002007" Then '健檢補助費

                    Dim trDAO As New SAL_HealthSubsidy_fee
                    Dim dr As DataRow = trDAO.GetAll(flow.Orgcode, "", flow.FlowId).Rows(0)
                    Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()


                    payDAO.Add(flow.Orgcode, dr("User_id").ToString(), flow.FlowId, IIf(String.IsNullOrEmpty(flow.MergeFlowid), flow.FlowId, flow.MergeFlowid), "005", "D", "001", "454", "005", _
                                "", "", flow.Budget_code, Convert.ToInt32(dr("Apply_amt")), LoginManager.UserId, Now, "")
                ElseIf Form_id = "002006" Then '評審委員出席審查費、講師鐘點費

                    Dim trDAO As New SAL_EXAMINE_fee
                    'Dim dr As DataRow = trDAO.GetAll(flow.Orgcode, flow.FlowId).Rows(0)
                    'Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()

                    'Dim code As String = String.Empty

                    'If dr("Item_code") = "605" Then
                    '    code = "013"
                    'ElseIf dr("Item_code") = "606" Then
                    '    code = "014"
                    'ElseIf dr("Item_code") = "604" Then
                    '    code = "012"
                    'ElseIf dr("Item_code") = "608" Then
                    '    code = "015"
                    'End If


                    'payDAO.Add(flow.Orgcode, dr("User_id").ToString(), flow.FlowId, flow.MergeFlowid, "024", "P", "002", "006", code, _
                    '            "", "", flow.Budget_code, Convert.ToInt32(dr("Apply_amt")), LoginManager.UserId, Now, "")
                    Dim dt As DataTable = trDAO.GetAll(flow.Orgcode, flow.FlowId)
                    For Each dr As DataRow In dt.Rows
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()

                        Dim code As String = String.Empty

                        If dr("Item_code") = "605" Then
                            code = "013"
                        ElseIf dr("Item_code") = "606" Then
                            code = "014"
                        ElseIf dr("Item_code") = "604" Then
                            code = "012"
                        ElseIf dr("Item_code") = "608" Then
                            code = "015"
                        End If

                        If (String.IsNullOrEmpty(flow.MergeFlowid)) Then
                            flow.MergeFlowid = flow.FlowId
                        End If
                        payDAO.Add(flow.Orgcode, dr("SEQNO").ToString(), flow.FlowId, flow.MergeFlowid, "005", "D", "001", dr("item_code").ToString(), code, _
                                    "", "", flow.Budget_code, Convert.ToInt32(dr("Apply_amt")), LoginManager.UserId, Now, "")
                    Next


                ElseIf Form_id = "002005" Then '子女教育補助津貼

                    Dim trDAO As New SAL_EDU_fee
                    Dim trdDAO As New SAL_EDU_feeDtl
                    Dim list As IList(Of SYS.Logic.Flow) = New List(Of SYS.Logic.Flow)

                    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                        Dim fdt As DataTable = New SYS.Logic.Flow().GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                        list = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
                    Else
                        list.Add(New SYS.Logic.Flow().GetObject(flow.Orgcode, flow.FlowId))
                    End If

                    For Each f As SYS.Logic.Flow In list
                        Dim dr As DataRow = trDAO.GetAll(f.Orgcode, Flow_id:=f.FlowId).Rows(0)
                        Dim drt As DataTable = trdDAO.GetAll(Convert.ToInt32(dr("id")))

                        Dim pay_amt As Integer = drt.Compute("sum(Apply_amt)", "")

                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(f.Orgcode, dr("User_id").ToString(), f.FlowId, IIf(String.IsNullOrEmpty(f.MergeFlowid), f.FlowId, f.MergeFlowid), "005", "D", "001", "501", "006", _
                                    "", "", f.Budget_code, pay_amt, LoginManager.UserId, Now, "")
                    Next
                ElseIf Form_id = "002009" Then '替代役交通費申請

                    Dim trDAO As New SAL_TRANS_fee
                    Dim trdDAO As New SAL_TRANS_feeDtl
                    Dim dr As DataRow = trDAO.GetAll(flow.Orgcode, Flow_id:=flow.FlowId).Rows(0)
                    Dim drt As DataTable = trdDAO.GetAll(Convert.ToInt32(dr("id")))

                    For Each ddr As DataRow In drt.Rows
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(flow.Orgcode, ddr("Non_id").ToString(), flow.FlowId, IIf(String.IsNullOrEmpty(flow.MergeFlowid), flow.FlowId, flow.MergeFlowid), "005", "D", "001", "451", "002", _
                                    "", "", flow.Budget_code, Convert.ToInt32(ddr("Apply_amt")), LoginManager.UserId, Now, "")
                    Next

                ElseIf Form_id = "002010" Then '環保志工服務申請

                    Dim trDAO As New SAL_VOL_fee
                    Dim trdDAO As New SAL_VOL_feeDtl
                    Dim dr As DataRow = trDAO.GetAll(flow.Orgcode, Flow_id:=flow.FlowId).Rows(0)
                    Dim drt As DataTable = trdDAO.GetAll(Convert.ToInt32(dr("id")))

                    For Each ddr As DataRow In drt.Rows
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(flow.Orgcode, ddr("vol_user_id").ToString(), flow.FlowId, IIf(String.IsNullOrEmpty(flow.MergeFlowid), flow.FlowId, flow.MergeFlowid), "005", "D", "001", "453", "004", _
                                    "", "", flow.Budget_code, Convert.ToInt32(ddr("Apply_amt")), LoginManager.UserId, Now, "")
                    Next

                ElseIf Form_id = "002004" Then '值班費申請

                    Dim trDAO As New SAL_DUTY_fee
                    Dim trdDAO As New SAL_DUTY_feeDtl
                    Dim mdr As DataRow = trDAO.GetAll(flow.Orgcode, Flow_id:=flow.FlowId).Rows(0)
                    Dim drt As DataTable = trdDAO.GetAll(Convert.ToInt32(mdr("id")))

                    For Each dr As DataRow In drt.Rows
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(dr("Org_code").ToString(), dr("Duty_userId").ToString(), flow.FlowId, IIf(String.IsNullOrEmpty(flow.MergeFlowid), flow.FlowId, flow.MergeFlowid), "005", "D", "001", _
                                   "602", "011", "", "", flow.Budget_code, Convert.ToInt32(dr("Apply_amt")), LoginManager.UserId, Now, "")

                        Dim ss As New FSC.Logic.ScheduleSetting()
                        ss.updateSchedulehours(Convert.ToInt32(dr("ApplyHour_cnt")), dr("Duty_date").ToString(), dr("Duty_userId").ToString())
                    Next
                ElseIf Form_id = "002008" OrElse Form_id = "002018" Then '未休假加班費申請
                    Dim sa As FSC.Logic.SettlementAnnual = New FSC.Logic.SettlementAnnual
                    Dim dt As DataTable = sa.getDataByOrgFid(flow.Orgcode, flow.FlowId)
                    For Each dr As DataRow In dt.Rows
                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(dr("Orgcode").ToString(), dr("Id_card").ToString(), flow.FlowId, IIf(String.IsNullOrEmpty(flow.MergeFlowid), flow.FlowId, flow.MergeFlowid), _
                                    "005", "D", "001", "655", "016", "", "", flow.Budget_code, Convert.ToInt32(dr("Apply_fee")), LoginManager.UserId, Now, "")
                    Next
                End If

            End If
        End Sub

        Protected Sub DeleteOvertimeFeeApply(ByVal Orgcode As String, ByVal flow_id As String)
            Dim ofm As SAL.Logic.OvertimeFeeMaster = New SAL.Logic.OvertimeFeeMaster

            Dim mdt As DataTable = ofm.getDataByFlowid(Orgcode, flow_id)
            If mdt IsNot Nothing AndAlso mdt.Rows.Count > 0 Then
                Dim ofd As SAL.Logic.OvertimeFeeDetail = New SAL.Logic.OvertimeFeeDetail
                Dim pr18m As FSC.Logic.CPAPR18M = New FSC.Logic.CPAPR18M

                'Dim Orgcode As String = mdt.Rows(0)("Orgcode").ToString()
                Dim Depart_id As String = mdt.Rows(0)("Depart_id").ToString()
                Dim Id_card As String = mdt.Rows(0)("Id_card").ToString()
                Dim Fee_YM As String = mdt.Rows(0)("Fee_YM").ToString()
                Dim Hour_Pay As String = mdt.Rows(0)("Hour_Pay").ToString()
                Dim Apply_Seq As String = mdt.Rows(0)("Apply_Seq").ToString()

                Dim ddt As DataTable = ofd.GetDataByFeeYm(Orgcode, Depart_id, Id_card, Fee_YM)
                For Each dr As DataRow In ddt.Rows
                    Dim Overtime_Date As String = dr("Overtime_Date").ToString()
                    Dim Overtime_Start As String = dr("Overtime_Start").ToString()
                    Dim Orig_applyhour As String = dr("Apply_Hour").ToString()
                    Dim Apply_Seq2 As String = dr("Apply_Seq").ToString()

                    Dim result As Boolean = pr18m.UpdatePRMNYH(Id_card, Overtime_Date, Overtime_Start, Orig_applyhour, 0, Hour_Pay, Now.ToString("yyyyMMddHHmm"))

                    ofd.DeleteOvertimeFeeDetail(Orgcode, Depart_id, Id_card, Fee_YM, Apply_Seq2)
                Next

                ofm.DeleteOvertimeFeeMaster(Orgcode, Depart_id, Id_card, Fee_YM, Apply_Seq)
            End If
        End Sub

        Protected Sub DeleteLabOvertimeFeeApply(ByVal Orgcode As String, ByVal flow_id As String)
            Dim ofm As SAL.Logic.LabOvertimeFeeMaster = New SAL.Logic.LabOvertimeFeeMaster

            Dim mdt As DataTable = ofm.getDataByFlowid(Orgcode, flow_id)
            If mdt IsNot Nothing AndAlso mdt.Rows.Count > 0 Then
                Dim ofd As SAL.Logic.LabOvertimeFeeDetailDAO = New SAL.Logic.LabOvertimeFeeDetailDAO
                Dim pr18m As FSC.Logic.CPAPR18M = New FSC.Logic.CPAPR18M

                'Dim Orgcode As String = mdt.Rows(0)("Orgcode").ToString()
                Dim Depart_id As String = mdt.Rows(0)("Depart_id").ToString()
                Dim Id_card As String = mdt.Rows(0)("Id_card").ToString()
                Dim Fee_YM As String = mdt.Rows(0)("Fee_YM").ToString()
                Dim Hour_Pay As String = mdt.Rows(0)("Hour_Pay").ToString()

                Dim ddt As DataTable = ofd.GetDataByFeeYm(Orgcode, Depart_id, Id_card, Fee_YM)
                For Each dr As DataRow In ddt.Rows
                    Dim Overtime_Date As String = dr("Overtime_Date").ToString()
                    Dim Overtime_Start As String = dr("Overtime_Start").ToString()
                    Dim Orig_applyhour As String = Convert.ToInt32(dr("Apply_Hour_1")) + Convert.ToInt32(dr("Apply_Hour_2")) + Convert.ToInt32(dr("Apply_Hour_3"))

                    Dim result As Boolean = pr18m.UpdatePRMNYH(Id_card, Overtime_Date, Overtime_Start, Orig_applyhour, 0, Hour_Pay, Now.ToString("yyyyMMddHHmm"))

                    ofd.deleteData(Orgcode, Depart_id, Fee_YM, Id_card)
                Next

                ofm.deleteData(Orgcode, Depart_id, Fee_YM, Id_card)
            End If
        End Sub


        ''' <summary>
        ''' 寫入補發代扣檔
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <remarks></remarks>
        Protected Sub UpdateTrafficPAYITEM(ByVal flow As SYS.Logic.Flow)
            Dim trDAO As New SAL_TRAFFIC_FEE

            Dim dt As DataTable = trDAO.GetAll(flow.Orgcode, "", flow.FlowId)

            If dt IsNot Nothing Then
                Dim pay_amt As Integer = dt.Compute("sum(Apply_amt)", "")

                Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                payDAO.Add(flow.Orgcode, flow.ApplyIdcard, flow.FlowId, flow.MergeFlowid, "005", "D", "001", "450", "001", _
                           "", "", flow.Budget_code, pay_amt, LoginManager.UserId, Now, "")
            End If

        End Sub

    End Class
End Namespace