Imports SAL.Logic
Imports System.Data
Imports System.Transactions
Imports NLog
Imports CommonLib

Partial Class SAL1111_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.OrgCode
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.Depart_id = LoginManager.Depart_id
        UcDDLDepart.SelectedValue = LoginManager.Depart_id
        UcDDLMember.SelectedValue = LoginManager.UserId

        If Request.QueryString("dep") IsNot Nothing AndAlso Request.QueryString("id") IsNot Nothing Then
            UcDDLDepart.SelectedValue = Request.QueryString("dep")
            UcDDLMember.SelectedValue = Request.QueryString("id")
        End If


        CheckEmployee()
        BindMonth()

        If Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            Bind(True)
        Else
            Bind()
        End If

        If LoginManager.RoleId.IndexOf("Personnel") >= 0 Then
            tr1.Visible = True
            tr2.Visible = True
        End If

    End Sub

    Public Sub CheckEmployee()
        hfEmployeeType.Value = New FSC.Logic.Personnel().GetColumnValue("employee_type", UcDDLMember.SelectedValue)
        If hfEmployeeType.Value <> "1" _
            And hfEmployeeType.Value <> "6" _
            And hfEmployeeType.Value <> "7" _
            And hfEmployeeType.Value <> "9" _
            And hfEmployeeType.Value <> "11" _
            And hfEmployeeType.Value <> "13" Then '2,3,4,5,8,10,12,14,15

            Response.Redirect("SAL1112_01.aspx?dep=" & UcDDLDepart.SelectedValue & "&id=" & UcDDLMember.SelectedValue)
        End If
    End Sub

    Public Sub BindMonth()
        For i As Integer = Now.Year - 1911 To 103 Step -1
            ddlYear.Items.Add(New ListItem(i.ToString.PadLeft(3, "0")))
        Next

        ddlMonth.Items.Clear()
        If (Now.Year - 1911) = Integer.Parse(ddlYear.SelectedValue) Then
            For i As Integer = 1 To Now.Month
                ddlMonth.Items.Add(New ListItem(i.ToString.PadLeft(2, "0")))
            Next
            ddlMonth.SelectedValue = (Now.Month - 1).ToString.PadLeft(2, "0")
        Else
            For i As Integer = 1 To 12
                ddlMonth.Items.Add(New ListItem(i.ToString.PadLeft(2, "0")))
            Next
        End If
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs) Handles cbQuery.Click
        If String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇人員姓名")
            Return
        End If
        Bind()
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl").ToString())
        End If
    End Sub

    Protected Sub Bind(Optional ByVal isUpdate As Boolean = False)
        Dim Orgcode As String = LoginManager.OrgCode
        Dim Depart_id As String = UcDDLDepart.SelectedValue 'hfDepart_id.Value
        Dim ID_card As String = UcDDLMember.SelectedValue 'hfPerId.Value
        Dim ym As String = ddlYear.SelectedValue & ddlMonth.SelectedValue
        Dim ymd As String = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMdd")   '系統日期
        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")

        InitData()
        CheckEmployee()

        If String.IsNullOrEmpty(ID_card) Then
            If Not String.IsNullOrEmpty(Depart_id) Then
                UcDDLMember.SelectedValue = LoginManager.UserId
            End If
            ID_card = LoginManager.UserId
        End If

        If Depart_id.Length < 6 AndAlso Not String.IsNullOrEmpty(ID_card) Then
            Depart_id = New FSC.Logic.DepartEmp().GetDepartId(ID_card)
            UcDDLDepart.SelectedValue = Depart_id
        End If

        hfDepart_id.Value = Depart_id
        hfId_card.Value = ID_card

        If isUpdate AndAlso Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            Dim odt As DataTable = New OvertimeFeeMaster().getDataByFlowid(u_org, u_fid)
            If odt IsNot Nothing AndAlso odt.Rows.Count > 0 Then
                ym = odt.Rows(0)("Fee_YM").ToString()
                ddlYear.SelectedValue = Left(ym, 3)
                ddlMonth.SelectedValue = Right(ym, 2)
            End If

            ViewState.Item("Status") = Nothing
            cbConfirm.Text = "確認"

            cbConfirm.Visible = True
            cbReset.Visible = False
            cbBack.Visible = True
            ddlYear.Enabled = False
            ddlMonth.Enabled = False
            cbQuery.Visible = False
        End If

        Dim dt As DataTable = New SAL1111().GetSAL1111Data(Orgcode, Depart_id, ID_card, ym, ymd)
        gv.DataSource = dt
        gv.DataBind()

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
            Return
        End If

        Dim Print_Mark As String = New SAL1111().GetFeeMasterPrintMark(Orgcode, Depart_id, ID_card, ym)
        If Print_Mark = "Y" Then
            Me.cbRTP2.Visible = False
        End If

        BindTip()
    End Sub

#Region "InitData"
    Protected Sub InitData()
        hfEmployeeType.Value = New FSC.Logic.Personnel().GetColumnValue("Employee_type", UcDDLMember.SelectedValue)

        If Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(Request.QueryString("org"), Request.QueryString("fid"))
            If f IsNot Nothing Then
                UcDDLDepart.SelectedValue = f.DepartId
                UcDDLMember.SelectedValue = f.ApplyIdcard
                hfEmployeeType.Value = New FSC.Logic.Personnel().GetColumnValue("Employee_type", f.ApplyIdcard)
            End If
        End If

        Dim Orgcode As String = LoginManager.OrgCode
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim ID_card As String = UcDDLMember.SelectedValue
        Dim ym As String = ddlYear.SelectedValue & ddlMonth.SelectedValue

        Dim Apply_seq As String = String.Empty
        Dim Print_Mark As String = String.Empty
        Dim Sum_date As String = String.Empty

        '判斷案件目前請領狀態
        Dim omdt As DataTable = New OvertimeFeeMaster().GetOvertimeFeeMasterByQuery(Orgcode, Depart_id, ID_card, ym)

        If omdt.Rows.Count <= 0 Then
            '若查無資料，則表示尚未申請過，狀態為新增(Apply_Seq = ‘1’)

            Apply_seq = "1"
            ViewState.Item("Status") = "Add"
            cbConfirm.Visible = True
            cbReset.Visible = True
        Else
            Apply_seq = omdt.Rows(0)("Apply_seq").ToString()
            Print_Mark = omdt.Rows(0)("Print_Mark").ToString()
            Sum_date = omdt.Rows(0)("Sum_date").ToString()

            'If Print_Mark <> "Y" Then
            '    '已經申請過，但尚未鎖定
            '    Apply_seq = Apply_seq
            '    'cbRTP2.Visible = True
            'ElseIf Print_Mark = "Y" Then
            '    '已經申請過，並鎖定
            '    cbConfirm.Visible = False
            '    cbReset.Visible = False
            '    'cbRTP2.Visible = True
            '    ViewState.Item("Status") = "Lock"
            'End If

            ViewState.Item("Status") = "Lock"
            cbConfirm.Visible = False
            cbReset.Visible = False
        End If

        ViewState.Item("Apply_seq") = Apply_seq


    End Sub
#End Region

#Region "Tip"
    Protected Sub BindTip()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim ym As String = ddlYear.SelectedValue & ddlMonth.SelectedValue

        Dim PEKIND As String = New FSC.Logic.Personnel().GetDataByIdCard(ID_card).Rows(0)("PEKIND").ToString()     '差勤組別

        '每日加班時數上限(A)
        Dim A As Integer = 4 'CommonFun.ConvertToInt(New CPAPC03M().GetPCPARM1(PEKIND, "limit", "2"))
        hfA.Value = A

        '專案加班時數上限(X) (專案加班檔)
        Dim X As Integer = 0 'CommonFun.ConvertToInt(New FSC.Logic.CPAPT20M().GetPTHOUR(ID_card, ym))

        Dim rdt As DataTable = New FSC.Logic.ProjectOvertimeRule().getDataByYYYMM(Orgcode, Depart_id, ID_card, ym)
        If rdt IsNot Nothing AndAlso rdt.Rows.Count > 0 Then
            X = CommonFun.getInt(rdt.Rows(0)("MonOT_pay_hr"))
        End If

        Dim Y As Integer = CommonFun.ConvertToInt(New FSC.Logic.CPAPC03M().GetPCPARM1(PEKIND, "limit", "3"))

        '每月加班時數上限(B)(專案加班+一般加班) = 若查無資料(專案加班檔裡無資料)，則X值即為B值(每月時數上限值為一般+專案總時數)
        Dim B As Integer = IIf(X = 0, Y, X)
        hfb.value = B

        '若查無資料(專案加班檔裡無資料)，則X值即為B值
        If X = 0 Then X = B
        hfX.Value = X

        '一般加班可用餘額(C) = 20 - 該人員該年月之一般加班已領總和
        'Dim C As String = Convert.ToString(20 - New CPAPR18M().GetSumPRMNYH(ID_card, ym, "1"))
        'hfC.Value = C

        Dim pr18m As New FSC.Logic.CPAPR18M

        '當月一般加班可用餘額(C) = 當月的加班數 - 已休時數 - 已領時數
        Dim C As Integer = 0
        Dim tdt As DataTable = pr18m.GetSumData(ID_card, ym, "1")
        If tdt IsNot Nothing And tdt.Rows.Count > 0 Then
            Dim praddh As Integer = CommonFun.ConvertToInt(tdt.Rows(0)("praddh").ToString)
            Dim prpayh As Integer = CommonFun.ConvertToInt(tdt.Rows(0)("prpayh").ToString())
            Dim prmnyh As Integer = CommonFun.ConvertToInt(tdt.Rows(0)("prmnyh").ToString())

            hfC_prmnyh.Value = prmnyh

            If praddh - prpayh > 20 Then
                C = 20 - prmnyh
            Else
                C = praddh - prpayh - prmnyh
            End If
        Else
            C = 0
        End If
        hfC.Value = C

        '專案加班可用餘額(D) = 每月加班時數上限(B) - 一般加班時數上限(20) - 該人員該年月之專案加班已領總和
        'Dim D As String = Convert.ToString(CommonFun.ConvertToInt(B) - 20 - New CPAPR18M().GetSumPRMNYH(ID_card, ym, "2"))
        'hfD.Value = D

        '當月專案加班可用餘額(D) = 當月專案加班數 - 已休時數 - 已領時數
        Dim D As Integer = 0
        Dim tdt2 As DataTable = pr18m.GetSumData(ID_card, ym, "2")
        If tdt2 IsNot Nothing And tdt2.Rows.Count > 0 Then
            Dim praddh As Integer = CommonFun.ConvertToInt(tdt2.Rows(0)("praddh").ToString)
            Dim prpayh As Integer = CommonFun.ConvertToInt(tdt2.Rows(0)("prpayh").ToString())
            Dim prmnyh As Integer = CommonFun.ConvertToInt(tdt2.Rows(0)("prmnyh").ToString())

            hfD_prmnyh.Value = prmnyh

            If praddh - prpayh > X Then
                D = X - prmnyh
            Else
                D = praddh - prpayh - prmnyh
            End If
        Else
            D = 0
        End If
        hfD.Value = D

        Dim sdt As DataTable = pr18m.GetSumData(ID_card, ym)
        Dim total_praddh As Integer = 0
        Dim total_prpayh As Integer = 0
        Dim total_prmnyh As Integer = 0

        If sdt.Rows.Count > 0 Then
            total_praddh = CommonFun.ConvertToInt(sdt.Rows(0)("praddh").ToString())
            total_prpayh = CommonFun.ConvertToInt(sdt.Rows(0)("prpayh").ToString())
            total_prmnyh = CommonFun.ConvertToInt(sdt.Rows(0)("prmnyh").ToString())
        End If
        hftotal_prmnyh.Value = total_prmnyh

        Dim tip As New StringBuilder
        tip.AppendLine("<div style='line-height:20px; color:blue; '>")
        tip.AppendLine("<ul>")
        tip.AppendLine("<li>加班費計算方式：一般/專案加班費合併計算，且一般加班請領不大於一般加班月上限</li>")
        tip.AppendLine("<li>一般加班上限：20小時</li>")
        tip.AppendLine("<li>專案加班上限：{2}小時</li>")
        tip.AppendLine("<li><span style='color:red'>加班總數：{3} &nbsp;&nbsp;已休：{4} &nbsp;&nbsp;己領：{5} </span></li>")
        tip.AppendLine("<li><span style='color:red'>補休時數不列入加班費時數計算</span></li>")
        tip.AppendLine("<li>一般加班可領餘額：{6}小時</li>")
        tip.AppendLine("<li>專案加班可請領餘額：{7}小時</li>")
        tip.AppendLine("<li>總加加班可請領餘額：{8}小時</li>")
        tip.AppendLine("</ul>")
        tip.AppendLine("</div>")

    End Sub
#End Region

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.OrgCode
        Dim Depart_id As String = hfDepart_id.Value
        Dim ID_card As String = hfId_card.Value
        Dim Account As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim ym As String = ddlYear.SelectedValue & ddlMonth.SelectedValue
        Dim PRADDH As Integer, PRPAYH As Integer, PRMNYH As Integer, Apply_hour As Integer
        Dim overtime_type As String, overtime_date As String, overtime_end_date As String, Applytime_start As String, Applytime_end As String
        Dim Overtime_start As String, Overtime_end As String, reason As String, budget_type As String = String.Empty
        Dim Normal_hour As Integer, Project_hour As Integer, Monthly_pay As Integer, Hour_pay As Integer
        Dim origApplyhour As Integer
        Dim result As Boolean = False
        Dim sabase As New SAL.Logic.SABASE()
        Dim ofm As OvertimeFeeMaster = New OvertimeFeeMaster
        Dim ofd As OvertimeFeeDetail = New OvertimeFeeDetail

        Dim Apply_seq As String = ViewState.Item("Apply_seq")

        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False
        Dim flow_id As String = ""

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(u_org, u_fid)
            ID_card = f.ApplyIdcard
        End If

        'Monthly_pay = New SAL1112().GetTotalSA(ID_card, ym)
        'Hour_pay = CommonFun.getInt(sabase.GetColumnValue("BASE_HOUR_SAL", ID_card))

        Try
            Using trans As New TransactionScope

                Dim sadt As DataTable = New SAL1111().getSALData(Orgcode, ID_card, (ddlYear.SelectedValue + 1911).ToString & ddlMonth.SelectedValue)
                If sadt IsNot Nothing AndAlso sadt.Rows.Count > 0 Then
                    Monthly_pay = CommonFun.ConvertToInt(sadt.Rows(0)("month_pay").ToString())
                    Hour_pay = CommonFun.ConvertToInt(sadt.Rows(0)("BASE_HOUR_SAL").ToString())
                End If

                For Each gvr As GridViewRow In gv.Rows

                    PRADDH = CommonFun.ConvertToInt(CType(gvr.FindControl("lbPRADDH"), Label).Text.Trim())                   '加班時數
                    PRPAYH = CommonFun.ConvertToInt(CType(gvr.FindControl("lbPRPAYH"), Label).Text.Trim())                   '已休時數
                    PRMNYH = CommonFun.ConvertToInt(CType(gvr.FindControl("lbPRMNYH"), Label).Text.Trim())                   '已領時數
                    overtime_type = CType(gvr.FindControl("lbPRATYPE"), Label).Text.Trim()                                   '加班類別
                    overtime_date = CType(gvr.FindControl("lbPRADDD"), Label).Text.Trim()                                    '加班日期
                    overtime_end_date = CType(gvr.FindControl("lbPRADDE"), Label).Text.Trim()                                    '加班日期迄
                    Applytime_start = CType(gvr.FindControl("lbStart_time"), Label).Text.Replace(":", "")                    '加班申請時間起
                    Applytime_end = CType(gvr.FindControl("lbEnd_time"), Label).Text.Replace(":", "")                        '加班申請時間迄
                    Overtime_start = CType(gvr.FindControl("lbPRSTIME"), Label).Text.Trim()                                  '加班時間起
                    Overtime_end = CType(gvr.FindControl("lbPRETIME"), Label).Text.Trim()                                    '加班時迄
                    reason = CType(gvr.FindControl("lbPRREASON"), Label).Text.Trim()                                         '事由
                    origApplyhour = CType(gvr.FindControl("hfApply_hour"), HiddenField).Value


                    'hours = CommonFun.ConvertToInt(CType(gvr.FindControl("ddlApply_hour"), DropDownList).Text.Trim())        '請領時數

                    'If hours < 0 Then
                    '    '欲請領的時數小於零時
                    '    Apply_hour = hours + Orig_applyhour
                    'ElseIf hours > 0 Then
                    '    '欲請領的時數大於零時
                    '    Apply_hour = hours
                    'ElseIf hours = 0 Then
                    '    '欲請領的時數等於零時
                    '    Apply_hour = Orig_applyhour
                    'End If


                    If Not CommonFun.IsNum(CType(gvr.FindControl("tbApply_hour"), TextBox).Text) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請領時數需為數字!")
                        Return
                    End If

                    Apply_hour = CommonFun.ConvertToInt(CType(gvr.FindControl("tbApply_hour"), TextBox).Text)

                    If Apply_hour > PRADDH - PRPAYH - PRMNYH Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請領時數需小於等於(加班時數-已休時數-已領時數)!")
                        Return
                    End If

                    If overtime_type = "1" Then
                        Normal_hour += Apply_hour       '一般時數請領加總
                    ElseIf overtime_type = "2" Then
                        'Project_hour += Apply_hour      '專案時數請領加總
                        If CType(gvr.FindControl("hfCheckType"), HiddenField).Value = "1" Then
                            Normal_hour += Apply_hour
                        ElseIf CType(gvr.FindControl("hfCheckType"), HiddenField).Value = "2" Then
                            Project_hour += Apply_hour
                        End If
                    End If

                    If ViewState("Status") = "Add" Then
                        '新申請

                        '請領時數為0時，不新增，前往下一筆
                        If Apply_hour <= 0 Then Continue For

                        result = ofd.InsertOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, _
                                             Applytime_start, Applytime_end, Overtime_start, Overtime_end, PRADDH, Apply_hour, reason, Account)
                    Else
                        '修改資料

                        If ofd.GetCount(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start) > 0 Then
                            '存在明細檔裡

                            If Apply_hour = 0 Then
                                '請領時數為0時，刪除明細檔
                                result = ofd.DeleteOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start)
                            Else
                                '更新明細檔
                                result = ofd.UpdateApply_hour(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, Overtime_start, Apply_hour, Account)
                            End If

                        Else
                            '不存在明細檔裡，新增明細檔

                            '請領時數為0時，不新增，前往下一筆
                            If Apply_hour <= 0 Then
                                Continue For
                            End If

                            result = ofd.InsertOvertimeFeeDetail(Orgcode, Depart_id, ID_card, ym, Apply_seq, overtime_type, overtime_date, _
                                            Applytime_start, Applytime_end, Overtime_start, Overtime_end, PRADDH, Apply_hour, reason, ID_card)
                        End If
                    End If

                    '更新回P2K
                    result = New FSC.Logic.CPAPR18M().UpdatePRMNYH(ID_card, overtime_date, Overtime_start, origApplyhour, Apply_hour, Hour_pay, Now.ToString("yyyyMMddHHmm"))

                Next

                If Normal_hour > 20 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "超過一般加班上限!")
                    trans.Dispose()
                    Return
                End If

                If Project_hour > CommonFun.ConvertToInt(hfX.Value) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "超過專案加班上限!")
                    trans.Dispose()
                    Return
                End If

                If Normal_hour + Project_hour > CommonFun.ConvertToInt(hfB.Value) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "超過每月請領加班上限!")
                    trans.Dispose()
                    Return
                End If

                Dim f As SYS.Logic.Flow = New SYS.Logic.Flow
                flow_id = IIf(isUpdate, u_fid, New SYS.Logic.FlowId().GetFlowId(Orgcode, "002001", Nothing))
                budget_type = New SAL1111().GetLastBudget(ID_card)

                If ViewState("Status") = "Add" Then
                    '新申請
                    result = ofm.InsertOvertimeFeeMaster(Orgcode, Depart_id, ID_card, ym, Apply_seq, budget_type, Normal_hour, Project_hour, Monthly_pay, Hour_pay, "N", flow_id)
                Else
                    result = ofm.UpdateOvertimeFeeMaster(Orgcode, Depart_id, ID_card, ym, Apply_seq, Normal_hour, Project_hour, Monthly_pay, Hour_pay)
                End If

                Dim freason As String = "請領加班時數:" & (Normal_hour + Project_hour) & "小時"

                If isUpdate Then
                    f = f.GetObject(u_org, u_fid)
                    f.CaseStatus = "2"
                    f.Reason = freason
                    f.Update()
                Else
                    f.FlowId = flow_id
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = ID_card
                    f.ApplyName = New FSC.Logic.Personnel().GetColumnValue("User_name", ID_card)
                    f.ApplyPosid = New FSC.Logic.Personnel().GetColumnValue("Title_no", ID_card)
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = "002001"
                    f.Reason = freason
                    f.Budget_code = budget_type
                    f.ChangeUserid = Account

                    SYS.Logic.CommonFlow.AddFlow(f)
                End If

                trans.Complete()

            End Using

            SendNotice.send(Orgcode, flow_id)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../../FSC/FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
                ViewState.Item("Status") = "Lock"
                cbConfirm.Visible = False
                cbReset.Visible = False
            End If
            Bind(isUpdate)

            'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請列印加班單明細!", "../../FSC/FSC0/FSC0101_01.aspx")
            'Bind()
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        End Try
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        Dim Orgcode As String = LoginManager.OrgCode
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim ID_card As String = UcDDLMember.SelectedValue
        Dim ym As String = ddlYear.SelectedValue & ddlMonth.SelectedValue

        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim Overtime_type As String = CType(e.Row.FindControl("lbPRATYPE"), Label).Text.Trim()

            Dim PRADDD As String = CType(e.Row.FindControl("lbPRADDD"), Label).Text.Trim()
            Dim PRADDE As String = CType(e.Row.FindControl("lbPRADDE"), Label).Text.Trim()
            Dim PRSTIME As String = CType(e.Row.FindControl("lbPRSTIME"), Label).Text.Trim()
            Dim Apply_seq As String = ViewState.Item("Apply_seq")

            Dim PRADDH As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("lbPRADDH"), Label).Text.Trim())           '加班時數
            Dim PRPAYH As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("lbPRPAYH"), Label).Text.Trim())           '已休時數
            Dim PRMNYH As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("lbPRMNYH"), Label).Text.Trim())          '已領時數
            hfC.Value = IIf(CommonFun.ConvertToInt(hfC.Value) > 20, 20, hfC.Value)

            Dim ofd As New OvertimeFeeDetail

            Dim origApplyhour As Integer = 0       '本次請領時數
            Dim oldApplyhour As Integer = 0        '非本次請領時數

            '取出本次請領的原本時數 及 上次請領的時數
            Dim dt As DataTable = ofd.GetData(Orgcode, Depart_id, ID_card, ym, PRADDD, PRSTIME)
            For Each dr As DataRow In dt.Rows
                If dr("Apply_seq").ToString() = Apply_seq Then
                    origApplyhour += dr("Apply_hour").ToString()
                Else
                    oldApplyhour += dr("Apply_hour").ToString()
                End If
            Next

            CType(e.Row.FindControl("tbApply_hour"), TextBox).Text = origApplyhour          '本次請領時數
            CType(e.Row.FindControl("hfOldApply_hour"), HiddenField).Value = oldApplyhour

            Dim tbApplyHour As TextBox = CType(e.Row.FindControl("tbApply_hour"), TextBox)

            If ViewState.Item("Status") = "Lock" Then
                tbApplyHour.Enabled = False
            End If

            If PRADDH <= PRPAYH + PRMNYH Then
                tbApplyHour.Enabled = False
            End If

            tbApplyHour.Attributes.Add("onchange", "checkApplyHour('" & PRADDH & "', '" & PRPAYH & "', '" & PRMNYH & "', this.id, '" & Overtime_type & "');")

            CType(e.Row.FindControl("lbNo"), Label).Text = e.Row.DataItemIndex + 1
        End If
    End Sub


#Region "列印報表"
    '    Protected Sub cbRTP1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRTP1.Click
    '        '支領單

    '        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    '        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    '        Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    '        Dim ym As String = Request.QueryString("ym")
    '        Dim Apply_seq As String = ViewState("Apply_seq")

    '        Dim ymd As String = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMdd")

    '        Dim dt As DataTable = New OvertimeFeeDetail().GetFSC1301_02Data2(Orgcode, Depart_id, ID_card, ym, Apply_seq)

    '        dt.Columns.Add("hour_pay", GetType(Integer))
    '        dt.Columns.Add("total_pay", GetType(Integer))

    '        Dim ofd As New OvertimeFeeDetail
    '        Dim isdt As DataTable = New ImpSalary().GetLastSalaryData(Orgcode, Depart_id, ID_card, ym)
    '        Dim hour_pay As Integer = 0, pro_sa As Integer = 0, header_sa As Integer = 0, main_sa As Integer = 0
    '        If isdt.Rows.Count > 0 Then
    '            hour_pay = CommonFun.ConvertToInt(isdt.Rows(0)("hour_pay").ToString())
    '            main_sa = CommonFun.ConvertToInt(isdt.Rows(0)("main_sa").ToString())
    '            pro_sa = CommonFun.ConvertToInt(isdt.Rows(0)("pro_sa").ToString())
    '            header_sa = CommonFun.ConvertToInt(isdt.Rows(0)("header_sa").ToString())
    '        End If

    '        Dim i As Integer = 0
    '        Dim total_hour As Integer = 0, total_money As Integer = 0

    '        For Each dr As DataRow In dt.Rows
    '            dr("Overtime_date") = DateTimeInfo.ToDisplay(dr("Overtime_date").ToString, "-")
    '            dr("Overtime_start") = DateTimeInfo.ToDisplayTime(dr("Overtime_start").ToString()) & " 至 "
    '            dr("Overtime_end") = DateTimeInfo.ToDisplayTime(dr("Overtime_end").ToString())
    '            dr("hour_pay") = hour_pay
    '            dr("total_pay") = CommonFun.ConvertToInt(dr("Apply_hour").ToString) * hour_pay
    '            total_hour += CommonFun.ConvertToInt(dr("Apply_hour").ToString())
    '            total_money += CommonFun.ConvertToInt(dr("total_pay").ToString())
    '            i += 1
    '        Next

    '        '設定一頁的行數
    '        Dim lineNum As Integer = 16

    '        If i > lineNum Then
    '            For j As Integer = 0 To lineNum - (i Mod lineNum)
    '                dt.Rows.Add(dt.NewRow)
    '            Next
    '        ElseIf lineNum - i <> 0 Then
    '            For j As Integer = 0 To lineNum - i - 1
    '                dt.Rows.Add(dt.NewRow)
    '            Next
    '        End If

    '        Dim f As New FSCorg
    '        Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("~/Report/FSC1/FSC1301_RPT.mht"), dt)
    '        Dim params(15) As String
    '        params(0) = f.GetOrgcodeName(Orgcode)   'P1
    '        params(1) = f.GetDepartName(Orgcode, Depart_id) 'P2
    '        params(2) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name) 'P3

    '        Dim C1 As New Code1

    '        params(3) = C1.GetDataDESCR("EPT", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)) 'P4

    '        Dim bt02mdt As DataTable = New CPABT02M().GetBT02MByB02IDNO(ID_card)

    '        If bt02mdt.Rows.Count > 0 Then
    '            params(4) = C1.GetDataDESCR("RNK", bt02mdt.Rows(0)("B02CRKCOD").ToString()) 'P5
    '            params(5) = C1.GetDataDESCR("PAG", bt02mdt.Rows(0)("B02OGRCOD").ToString()) 'P6
    '        Else
    '            params(4) = ""
    '            params(5) = ""
    '        End If

    '        params(6) = main_sa     'P7
    '        params(7) = pro_sa      'P8
    '        params(8) = header_sa   'P9

    '        Dim m As New Member
    '        Dim Budget_type As String = m.GetColumnValue("Budget_type", ID_card)

    '        If Budget_type = "1" Then
    '            params(9) = "■"    'P10
    '            params(10) = "□"   'P11
    '        ElseIf Budget_type = "2" Then
    '            params(9) = "□"    'P10
    '            params(10) = "■"   'P11
    '        End If

    '        params(11) = Mid(ym, 4) 'P12
    '        params(12) = total_hour 'P13
    '        params(13) = total_hour     'P14
    '        params(14) = total_money    'P15
    '        params(15) = (Now.Year - 1911).ToString.PadLeft(3, "0") & "/" & Now.ToString("MM/dd")  'P16

    '        rpt.ExportFileName = "加班費支領單"
    '        rpt.Param = params
    '        rpt.ExportToExcel()

    '    End Sub

    '    Protected Sub cbRTP2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRTP2.Click
    '        '加班單明細

    '        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    '        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    '        Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    '        Dim ym As String = Request.QueryString("ym")
    '        Dim Apply_seq As String = ViewState("Apply_seq")
    '        Dim ymd As String = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMdd")

    '        Dim dt As DataTable = New FSC1301().GetFSC1301_02Data(Orgcode, Depart_id, ID_card, ym, Apply_seq)
    '        'If Orgcode = "367030000D" Then
    '        '    '保險局
    '        '    Report_FSC1301_RPT2(dt)
    '        'Else
    '        '    '本會、檢察局、證期局
    '        '    Report_FSC1301_RPT1(dt)
    '        'End If

    '        Report_FSC1301_RPT(dt)
    '    End Sub

    '    Protected Sub Report_FSC1301_RPT(ByVal dt As DataTable)
    '        Try
    '            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    '            Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    '            Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    '            Dim ym As String = Request.QueryString("ym")
    '            Dim Apply_seq As String = ViewState.Item("Apply_seq")

    '            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
    '                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無資料!")
    '                Return
    '            End If

    '            Dim pr18m As New CPAPR18M()

    '            dt.Columns.Add("DEP", GetType(String))
    '            dt.Columns.Add("PRCARD", GetType(String))
    '            dt.Columns.Add("PRNAME", GetType(String))
    '            dt.Columns.Add("Write_time", GetType(String))
    '            dt.Columns.Add("PRPAYH", GetType(String))
    '            dt.Columns.Add("PRMNYH", GetType(String))
    '            dt.Columns.Add("PHITIME", GetType(String))

    '            Dim ofd As New OvertimeFeeDetail
    '            Dim cpaph As New CPAPHYYMM(ym)
    '            For Each dr As DataRow In dt.Rows

    '                Dim pr18mdt As DataTable = pr18m.GetCPAPR18MByPK(ID_card, dr("Overtime_Date").ToString(), dr("Overtime_Start").ToString())
    '                If pr18mdt.Rows.Count > 0 Then
    '                    Dim pr18mdr As DataRow = pr18mdt.Rows(0)

    '                    dr("DEP") = New FSCorg().GetDepartName(Orgcode, Depart_id)
    '                    dr("PRCARD") = pr18mdr("PRCARD").ToString()
    '                    dr("PRNAME") = pr18mdr("PRNAME").ToString()
    '                    dr("PRPAYH") = pr18mdr("PRPAYH").ToString()
    '                    '取得本次請領外已領時數
    '                    Dim ofddt As DataTable = ofd.GetData(Orgcode, Depart_id, ID_card, ym, dr("Overtime_date").ToString(), dr("Overtime_start").ToString())
    '                    For Each ofddr As DataRow In ofddt.Rows
    '                        If ofddr("Apply_seq").ToString() <> Apply_seq Then
    '                            dr("PRMNYH") += ofddr("Apply_hour").ToString()
    '                        End If
    '                    Next
    '                    dr("PRMNYH") = CommonFun.getInt(pr18mdr("PRMNYH").ToString())

    '                    'Dim ht As Hashtable = Content.getWorkTime(pr18mdr("PRIDNO").ToString(), pr18mdr("PRADDD").ToString())
    '                    'Dim offday As Boolean = False
    '                    'Dim PHITIME As String = ""
    '                    'Dim stime As String = ""
    '                    'Dim etime As String = ""

    '                    'If ht IsNot Nothing Then
    '                    '    Dim ph As New CPAPHYYMM(ym)
    '                    '    Dim phdt As DataTable = ph.GetListData(pr18mdr("PRCARD").ToString(), pr18mdr("PRIDNO").ToString(), pr18mdr("PRADDD").ToString())
    '                    '    If phdt IsNot Nothing And phdt.Rows.Count > 0 Then
    '                    '        stime = phdt.Rows(0)("PHITIME").ToString()
    '                    '        etime = phdt.Rows(phdt.Rows.Count - 1)("PHITIME").ToString()
    '                    '    End If
    '                    '    offday = ht("OFFDAY").ToString()
    '                    '    If Not offday Then
    '                    '        'If Content.getNumberTime(etime) > Content.getNumberTime(stime) Then
    '                    '        '    stime = ht("WORKTIMEE").ToString()
    '                    '        'End If
    '                    '        For Each phdr As DataRow In phdt.Rows
    '                    '            If Content.getNumberTime(phdr("PHITIME").ToString()) >= Content.getNumberTime(ht("WORKTIMEE").ToString()) Then
    '                    '                stime = phdr("PHITIME").ToString()
    '                    '                Exit For
    '                    '            End If
    '                    '        Next
    '                    '    End If
    '                    'End If

    '                    Dim startTime As String = ""
    '                    Dim endTime As String = ""
    '                    Dim fdt As DataTable = New Flow().GetFlowByFlow_id(pr18mdr("PRGUID").ToString(), Orgcode)
    '                    If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
    '                        startTime = fdt.Rows(0)("Start_time").ToString().Trim()
    '                        endTime = fdt.Rows(0)("End_time").ToString().Trim()
    '                    End If

    '                    Dim cardTime() As String = cpaph.getAddWorkCardTime(ID_card, pr18mdr("PRCARD").ToString(), ym, pr18mdr("PRADDD").ToString(), pr18mdr("PRADDE").ToString(), startTime, endTime)
    '                    Dim stime As String = cardTime(0)
    '                    Dim etime As String = cardTime(1)
    '                    dr("PHITIME") = stime & "~" & etime

    '                    'hsien 20120710
    '                    If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
    '                        dr("Write_time") = DateTimeInfo.GetRocDate(fdt.Rows(0)("write_time").ToString())
    '                        If fdt.Rows(0)("Nocard_flag").ToString() = "Y" Then
    '                            dr("PHITIME") = fdt.Rows(0)("Nocard_reason").ToString()
    '                        End If
    '                    End If

    '                End If
    '            Next

    '            Dim f As New FSCorg()
    '            Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("~/Report/FSC1/FSC1301_RPT1.mht"), dt)
    '            Dim params(3) As String
    '            params(0) = f.GetOrgcodeName(Orgcode)
    '            params(1) = DateTimeInfo.GetRocTodayString("yyyy/MM/dd")    '印表日期
    '            params(2) = New Member().GetColumnValue("User_name", ID_card)  '印表人員
    '            params(3) = ym.Substring(0, 3) & "年" & ym.Substring(3) & "月"  '查詢區間


    '            rpt.ExportFileName = "加班單明細"
    '            rpt.Param = params
    '            rpt.ExportToExcel()
    '        Catch ex As Exception
    '            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
    '        End Try
    '    End Sub
#End Region

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub
End Class