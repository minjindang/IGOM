Imports System.Data
Imports SAL.Logic
Imports System.Transactions
Imports CommonLib

Partial Class SAL1112_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
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
        If hfEmployeeType.Value = "1" _
            Or hfEmployeeType.Value = "6" _
            Or hfEmployeeType.Value = "7" _
            Or hfEmployeeType.Value = "9" _
            Or hfEmployeeType.Value = "11" _
            Or hfEmployeeType.Value = "13" Then '2,3,4,5,8,10,12,14,15

            Response.Redirect("SAL1111_01.aspx?dep=" & UcDDLDepart.SelectedValue & "&id=" & UcDDLMember.SelectedValue)
        End If
    End Sub

#Region "InitData"
    Protected Sub InitData()

        If Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(Request.QueryString("org"), Request.QueryString("fid"))
            If f IsNot Nothing Then
                UcDDLDepart.SelectedValue = f.DepartId
                UcDDLMember.SelectedValue = f.ApplyIdcard
            End If
        End If

        Dim Orgcode As String = LoginManager.OrgCode
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim ID_card As String = UcDDLMember.SelectedValue

        'Dim hour_pay As Integer = 0
        'Using sab As New SABASETableAdapters.SAL_SABASETableAdapter
        '    Dim dt As DataTable = sab.GetDataByBASE_SEQNO(hdPerId.Value)
        '    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
        '        hour_pay = CommonFun.ConvertToInt(dt.Rows(0)("BASE_HOUR_SAL").ToString())
        '    End If
        'End Using

        Dim sabase As New SAL.Logic.SABASE()
        Me.lbHourPay.Text = CommonFun.getInt(sabase.GetColumnValue("BASE_HOUR_SAL", ID_card))

        Dim pdt As DataTable = New FSC.Logic.Personnel().GetDataByQuery(Orgcode, Depart_id, "", ID_card)
        If Not pdt Is Nothing AndAlso pdt.Rows.Count > 0 Then
            Me.hfPESEX.Value = pdt.Rows(0)("PESEX").ToString()
            Me.hfPEKIND.Value = pdt.Rows(0)("PEKIND").ToString()
        End If


        Dim param As String = String.Empty
        Dim param1 As String = String.Empty
        Select Case Me.hfPESEX.Value
            Case "1"    '男
                param = "18"
                param1 = "20"
            Case "0"    '女
                param = "19"
                param1 = "21"
        End Select
        Dim pc03mdt As DataTable = New FSC.Logic.CPAPC03M().DAO.GetDataByKind(hfPEKIND.Value)
        For Each dr As DataRow In pc03mdt.Rows
            If param = dr("PCCODE").ToString() Then
                hfLimit.Value = CommonFun.ConvertToInt(dr("PCPARM1").ToString())
            End If
            If param1 = dr("PCCODE").ToString() Then
                hfLimit_H.Value = CommonFun.ConvertToInt(dr("PCPARM1").ToString())
            End If
        Next
        If String.IsNullOrEmpty(hfLimit_H.Value) Then
            '若含假日請領上限為空, 則同請領上限
            hfLimit_H.Value = hfLimit.Value
        End If

        '取得限制參數，至機關制度參數資料檔
        Dim dtCPAPC03M As DataTable = New FSC.Logic.CPAPC03M().DAO.GetDataByKind(hfPEKIND.Value)
        If Not dtCPAPC03M Is Nothing Then
            For Each rowCPAPC03M As DataRow In dtCPAPC03M.Rows
                'PCCODE = 15 : 加班前二小時倍數()
                'PCCODE = 16 : 加班後二小時後倍數()
                Select Case rowCPAPC03M("PCCODE").ToString()
                    Case "15"
                        hfF1.Value = rowCPAPC03M("PCPARM1")
                    Case "16"
                        hfF2.Value = rowCPAPC03M("PCPARM1")
                End Select
            Next
        End If


        Dim master As New SAL.Logic.LabOvertimeFeeMaster()
        Dim mdt As DataTable = master.GetLabOvertimeFeeMasterByQuery(Orgcode, Depart_id, ID_card, hfYear.Value & hfMonth.Value)
        If mdt IsNot Nothing AndAlso mdt.Rows.Count > 0 Then
            hfIsApply.Value = "true"
            toUpdate.Visible = False
            toReset.Visible = False
        Else
            hfIsApply.Value = "false"
            toUpdate.Visible = True
            toReset.Visible = True
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
#End Region

#Region "confirm 判斷"
    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        'Dim OrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        'Dim Depart_id As String = IIf(String.IsNullOrEmpty(Request.QueryString("Unit")), LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), Request.QueryString("Unit"))
        'Dim PerId As String = IIf(String.IsNullOrEmpty(Request.QueryString("PerId")), LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card), Request.QueryString("PerId"))

        ''按了確定要執行的程式碼
        'If target = "PrintConfirm" Then
        '    If argument = "True" Then
        '        '列印完報表後將OvertimeFeeMaster的PrintMark註記為Y
        '        Dim bll1307 As New FSC1307Bll()
        '        bll1307.doUpdateOvertimeFeeMaster(OrgCode, Depart_id, PerId, Me.hdYear.Value & Me.hdMonth.Value)

        '    End If
        '    isUpdate = True
        '    ShowList()
        'End If
    End Sub

    ''' <summary>
    ''' Postback的詢問視窗
    ''' </summary>
    ''' <param name="Message">訊息文字</param>
    ''' <param name="TrueScript">回應 true 時要執行的用戶端指令碼</param>
    ''' <param name="FalseScript">回應 false 時要執行的用戶端指令碼</param>
    Public Sub confirm(ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        Me.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub
#End Region

#Region "RowCreated"
    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated

        'If e.Row.RowType = DataControlRowType.Header Then

        '    Dim A As Double = New FSC.Logic.CPAPC03M().GetCPAPC03M(Me.hdPEKIND.Value, "15")
        '    Dim B As Double = New FSC.Logic.CPAPC03M().GetCPAPC03M(Me.hdPEKIND.Value, "16")
        '    Dim C As Double = 1

        '    Dim header As TableCellCollection = e.Row.Cells
        '    header(0).Visible = False
        '    header(1).Visible = False
        '    header(2).Visible = False
        '    header(5).Visible = False
        '    header(6).Visible = False
        '    header(7).Visible = False
        '    header(11).Text = "(1)*" & Convert.ToString(A) & "+(2)*" & Convert.ToString(B) & "+(3)*" & Convert.ToString(C)

        '    Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)
        '    Dim tc1 As New TableCell()
        '    Dim tc2 As New TableCell()
        '    Dim tc3 As New TableCell()
        '    Dim tc4 As New TableCell()
        '    Dim tc5 As New TableCell()
        '    Dim tc6 As New TableCell()
        '    Dim tc7 As New TableCell()
        '    Dim tc8 As New TableCell()
        '    Dim tc9 As New TableCell()

        '    tc1.Text = "開始日期"
        '    tc1.RowSpan = 2
        '    tc1.CssClass = "th"
        '    tc1.HorizontalAlign = HorizontalAlign.Center

        '    tc9.Text = "結束日期"
        '    tc9.RowSpan = 2
        '    tc9.CssClass = "th"
        '    tc9.HorizontalAlign = HorizontalAlign.Center

        '    tc2.Text = "事由"
        '    tc2.RowSpan = 2
        '    tc2.CssClass = "th"
        '    tc2.HorizontalAlign = HorizontalAlign.Center

        '    tc3.Text = "加班時間"
        '    tc3.ColumnSpan = 2
        '    tc3.CssClass = "th"
        '    tc3.HorizontalAlign = HorizontalAlign.Center

        '    tc4.Text = "加班<br />時數"
        '    tc4.ColumnSpan = 1
        '    tc4.RowSpan = 2
        '    tc4.CssClass = "th"
        '    tc4.HorizontalAlign = HorizontalAlign.Center

        '    tc5.Text = "已休<br/>時數"
        '    tc5.ColumnSpan = 1
        '    tc5.RowSpan = 2
        '    tc5.CssClass = "th"
        '    tc5.HorizontalAlign = HorizontalAlign.Center

        '    tc6.Text = "已領<br/>時數"
        '    tc6.ColumnSpan = 1
        '    tc6.RowSpan = 2
        '    tc6.CssClass = "th"
        '    tc6.HorizontalAlign = HorizontalAlign.Center

        '    tc7.Text = "加班時數"
        '    tc7.ColumnSpan = 3
        '    tc7.CssClass = "th"
        '    tc7.HorizontalAlign = HorizontalAlign.Center

        '    tc8.Text = "加班費"
        '    tc8.CssClass = "th"
        '    tc8.HorizontalAlign = HorizontalAlign.Center



        '    row.Cells.Add(tc1)
        '    row.Cells.Add(tc9)
        '    row.Cells.Add(tc2)
        '    row.Cells.Add(tc3)
        '    row.Cells.Add(tc4)
        '    row.Cells.Add(tc5)
        '    row.Cells.Add(tc6)
        '    row.Cells.Add(tc7)
        '    row.Cells.Add(tc8)


        '    Me.gvList.Controls(0).Controls.AddAt(0, row)

        'ElseIf e.Row.RowType = DataControlRowType.Footer Then
        '    Dim footer As TableCellCollection = e.Row.Cells
        '    footer.Clear()

        '    Dim tc1 As New TableCell()
        '    tc1.Text = "總計"
        '    tc1.ColumnSpan = 5
        '    tc1.HorizontalAlign = HorizontalAlign.Right
        '    tc1.CssClass = "Row"
        '    footer.Add(tc1)

        '    Dim tc2 As New TableCell()
        '    tc2.CssClass = "Row"
        '    footer.Add(tc2)
        '    Dim tc3 As New TableCell()
        '    tc3.CssClass = "Row"
        '    footer.Add(tc3)
        '    Dim tc4 As New TableCell()
        '    tc4.CssClass = "Row"
        '    footer.Add(tc4)
        '    Dim tc5 As New TableCell()
        '    tc5.CssClass = "Row"
        '    footer.Add(tc5)
        '    Dim tc6 As New TableCell()
        '    tc6.CssClass = "Row"
        '    footer.Add(tc6)
        '    Dim tc7 As New TableCell()
        '    tc7.CssClass = "Row"
        '    footer.Add(tc7)
        '    Dim tc8 As New TableCell()
        '    tc8.CssClass = "Row"
        '    footer.Add(tc8)
        'End If
    End Sub
#End Region

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs) Handles cbQuery.Click
        If String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇人員姓名")
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind(Optional ByVal isUpdate As Boolean = False)
        hfYear.Value = ddlYear.SelectedValue
        hfMonth.Value = ddlMonth.SelectedValue
        Dim ym As String
        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim Orgcode As String = LoginManager.OrgCode
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim Id_card As String = UcDDLMember.SelectedValue

        InitData()
        CheckEmployee()

        If String.IsNullOrEmpty(Id_card) Then
            If Not String.IsNullOrEmpty(Depart_id) Then
                UcDDLMember.SelectedValue = LoginManager.UserId
            End If
            Id_card = LoginManager.UserId
        End If

        If Depart_id.Length < 6 AndAlso Not String.IsNullOrEmpty(Id_card) Then
            Depart_id = New FSC.Logic.DepartEmp().GetDepartId(Id_card)
            UcDDLDepart.SelectedValue = Depart_id
        End If

        hfDepart_id.Value = Depart_id
        hfId_card.Value = Id_card

        If isUpdate AndAlso Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            Dim odt As DataTable = New LabOvertimeFeeMaster().getDataByFlowid(u_org, u_fid)
            If odt IsNot Nothing AndAlso odt.Rows.Count > 0 Then
                ym = odt.Rows(0)("Fee_YM").ToString()
                ddlYear.SelectedValue = Left(ym, 3)
                ddlMonth.SelectedValue = Right(ym, 2)
                hfYear.Value = ddlYear.SelectedValue
                hfMonth.Value = ddlMonth.SelectedValue
                
            End If
            toUpdate.Text = "確認"

            toCancel.Visible = True
            ddlYear.Enabled = False
            ddlMonth.Enabled = False
            toReset.Visible = False
            cbQuery.Visible = False
        End If

        Dim bll As New SAL1112()
        Dim dt As DataTable = bll.doQuerySAL1112(Orgcode, Depart_id, hfYear.Value & hfMonth.Value, Id_card)
        Me.gvList.DataSource = dt
        Me.gvList.DataBind()

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
            Return
        End If

    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim PRADDH As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("lbPRADDH"), Label).Text)     '加班時數
            Dim PRPAYH As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("lbPRPAYH"), Label).Text)     '已休
            Dim PRMNYH As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("lbPRMNYH"), Label).Text)     '已領
            Dim lbPRMNYH As Label = e.Row.FindControl("lbPRMNYH")
            Dim tbApplyHour As TextBox = e.Row.FindControl("tbApply_hour")

            Dim applyHour1 As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("tbApplyHour1"), TextBox).Text)
            Dim applyHour2 As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("tbApplyHour2"), TextBox).Text)
            Dim applyHour3 As Integer = CommonFun.ConvertToInt(CType(e.Row.FindControl("tbApplyHour3"), TextBox).Text)

            tbApplyHour.Text = applyHour1 + applyHour2 + applyHour3

            If PRADDH - PRPAYH - CommonFun.getInt(lbPRMNYH.Text) <= 0 Then
                tbApplyHour.Enabled = False
            End If

            If hfIsApply.Value = "true" Then
                tbApplyHour.Enabled = False
            End If
        End If
    End Sub

    Protected Sub toCount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toCount.Click
        Dim OrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim strs() As String = {LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)}

        Dim bll As New SAL1112
        Dim isUpdate As Boolean = False
        If Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            isUpdate = True
        End If
        bll.doConfirm(LoginManager.OrgCode, UcDDLDepart.SelectedValue, hfYear.Value & hfMonth.Value, strs, isUpdate, Request.QueryString("fid"))

        Bind()
    End Sub


    Protected Sub SetOtherApplyHours()
        Dim pb02m As New FSC.Logic.CPAPB02M()

        For Each gvr As GridViewRow In Me.gvList.Rows
            Dim PRADDD As String = CType(gvr.FindControl("hfPRADDD"), HiddenField).Value
            Dim applyHour As Integer = CommonFun.ConvertToInt(CType(gvr.FindControl("tbApply_hour"), TextBox).Text)

            Dim tbApplyHour1 As TextBox = gvr.FindControl("tbApplyHour1")
            Dim tbApplyHour2 As TextBox = gvr.FindControl("tbApplyHour2")
            Dim tbApplyHour3 As TextBox = gvr.FindControl("tbApplyHour3")

            If pb02m.IsHoliday(PRADDD) Then
                '假日
                If applyHour <= 8 Then
                    tbApplyHour3.Text = 8
                Else
                    tbApplyHour3.Text = 8

                    If applyHour <= 10 Then
                        tbApplyHour1.Text = 10 - applyHour
                    Else
                        tbApplyHour1.Text = 2
                        tbApplyHour2.Text = applyHour - 10
                    End If
                End If
            Else
                applyHour = IIf(applyHour > 4, 4, applyHour)
                If applyHour <= 2 Then
                    tbApplyHour1.Text = applyHour
                Else
                    tbApplyHour1.Text = 2
                    tbApplyHour2.Text = applyHour - 2
                End If
            End If
        Next
    End Sub


    Protected Sub toUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toUpdate.Click
        If Me.gvList Is Nothing OrElse Me.gvList.Rows Is Nothing Then
            Return
        End If

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim YearMonth As String = hfYear.Value & hfMonth.Value
        Dim Depart_id As String = hfDepart_id.Value
        Dim ID_card As String = hfId_card.Value


        Dim total_hours As Integer = 0          '加班總時數
        Dim project_total_hour As Integer = 0   '專案加班總時數
        Dim limit As Integer = CommonFun.getInt(hfLimit.Value) '上限時數
        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False
        Dim flow_id As String = ""
        Dim TotalMsg As StringBuilder = New StringBuilder
        Dim formId As String = "002001"
        Dim F1 As Double = CommonFun.ConvertToDouble(hfF1.Value)
        Dim F2 As Double = CommonFun.ConvertToDouble(hfF2.Value)
        Dim PEMEMCOD As String = New FSC.Logic.Personnel().GetColumnValue("Employee_type", Id_Card)   '職務類別
        Dim totalOvertimePay As Integer = 0
        Dim bll As New SAL1112

        If Not String.IsNullOrEmpty(u_fid) AndAlso Not String.IsNullOrEmpty(u_org) Then
            isUpdate = True
        End If

        'set apply_hour to apply_hour_1, apply_hour_2, apply_hour_3
        SetOtherApplyHours()

        Try
            Using trans As New TransactionScope
                flow_id = IIf(isUpdate, u_fid, New SYS.Logic.FlowId().GetFlowId(Orgcode, formId))

                For Each gvr As GridViewRow In Me.gvList.Rows
                    Dim hourPay As Integer = 0
                    Dim totalSa As Integer = 0  '月薪
                    Dim OvertimePay As Double = 0

                    Dim PRADDD As String = CType(gvr.FindControl("hfPRADDD"), HiddenField).Value
                    Dim PRADDE As Integer = CType(gvr.FindControl("hfPRADDE"), HiddenField).Value
                    Dim PRADDH As Integer = CType(gvr.FindControl("lbPRADDH"), Label).Text
                    Dim PRPAYH As Integer = CType(gvr.FindControl("lbPRPAYH"), Label).Text
                    Dim PRSTIME As String = CType(gvr.FindControl("hfPRSTIME"), HiddenField).Value
                    Dim PRETIME As String = CType(gvr.FindControl("hfPRETIME"), HiddenField).Value
                    Dim PRATYPE As String = CType(gvr.FindControl("hfPRATYPE"), HiddenField).Value
                    Dim REASON As String = CType(gvr.FindControl("lbPRREASON"), Label).Text

                    Dim applyHour1 As Integer = CommonFun.getInt(CType(gvr.FindControl("tbApplyHour1"), TextBox).Text)
                    Dim applyHour2 As Integer = CommonFun.getInt(CType(gvr.FindControl("tbApplyHour2"), TextBox).Text)
                    Dim applyHour3 As Integer = CommonFun.getInt(CType(gvr.FindControl("tbApplyHour3"), TextBox).Text)

                    If CType(gvr.FindControl("hfCheckType"), HiddenField).Value = "1" Then
                        PRATYPE = "1"
                    End If

                    '檢核時數
                    Dim msg As String = ""
                    If applyHour1 <> 0 Or applyHour2 <> 0 Or applyHour3 <> 0 Then

                        Dim tmp_hours As Integer = 0
                        If applyHour3 >= 1 And applyHour3 <= 8 Then
                            tmp_hours += (applyHour1 + applyHour2 + 8)
                        Else
                            tmp_hours += (applyHour1 + applyHour2 + applyHour3)
                        End If

                        If PRATYPE = "2" Then
                            project_total_hour += tmp_hours     '專案加班
                        ElseIf PRATYPE = "1" And (PEMEMCOD.Equals("3") Or PEMEMCOD.Equals("4") Or PEMEMCOD.Equals("8")) Then
                            total_hours += tmp_hours            '技工工友、臨時人員、駕駛一般加班要納入請領上限,大批加班不用納入請領上限
                        ElseIf Not (PEMEMCOD.Equals("3") Or PEMEMCOD.Equals("4") Or PEMEMCOD.Equals("8")) Then
                            total_hours += tmp_hours            '人事人員一般加班、大批加班皆要納入請領上限
                        End If

                        'msg = bll.CheckApplyHours(PRADDD, PRADDH, PRPAYH, applyHour1, applyHour2, applyHour3)

                        msg += bll.doUpdateDetailCheckInput(PRADDD, Id_Card, limit, total_hours, project_total_hour)
                    End If

                    If msg = "" Then

                        '取申請時, 當下的月薪, 時薪
                        Dim sadt As DataTable = New SAL1111().getSALData(Orgcode, Id_Card, (ddlYear.SelectedValue + 1911).ToString & ddlMonth.SelectedValue)
                        If sadt IsNot Nothing AndAlso sadt.Rows.Count > 0 Then
                            totalSa = CommonFun.getInt(sadt.Rows(0)("month_pay").ToString())
                            hourPay = CommonFun.getInt(sadt.Rows(0)("BASE_HOUR_SAL").ToString())
                        End If

                        OvertimePay = bll.CountOvertimePay(applyHour1, applyHour2, applyHour3, F1, F2, totalSa, PEMEMCOD)

                        totalOvertimePay += OvertimePay

                        bll.doDetailUpdate(Orgcode, Depart_id, YearMonth, Id_Card, PRADDD, PRSTIME, PRETIME, PRADDH, _
                                            FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd"), applyHour1, applyHour2, applyHour3, OvertimePay, REASON, flow_id)

                    Else
                        TotalMsg.Append(msg).Append("\n")
                    End If
                Next

                bll.doMasterUpdate(Orgcode, Depart_id, YearMonth, Id_Card, flow_id)

                If Not String.IsNullOrEmpty(TotalMsg.ToString()) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, TotalMsg.ToString())
                    trans.Dispose()
                    Return
                End If

                Dim f As SYS.Logic.Flow = New SYS.Logic.Flow
                Dim flowReason As String = "請領加班費：" + totalOvertimePay.ToString() + "元"

                If isUpdate Then
                    f = New SYS.Logic.Flow().GetObject(u_org, u_fid)
                    f.Reason = flowReason
                    f.CaseStatus = "2"
                    f.Update()

                Else
                    f.FlowId = flow_id
                    f.Orgcode = Orgcode
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.ApplyIdcard = Id_Card
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FormId = formId
                    f.Reason = flowReason
                    f.Budget_code = New SAL1112().GetLastBudget(Id_Card)
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    SYS.Logic.CommonFlow.AddFlow(f)
                End If

                trans.Complete()
            End Using

            SendNotice.send(Orgcode, flow_id)
            If isUpdate Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "../../FSC/FSC0/FSC0102_01.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            End If
            Bind()

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

#Region "列印"
    'Protected Sub toPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toPrint.Click
    '    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    '    Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    '    Dim Sub_depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Subdepartment)
    '    Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

    '    If "FSC3206_03" = Request("FORWARD") Then
    '        Depart_id = Request.QueryString("Unit")
    '        Id_card = Request.QueryString("PerId")
    '        Sub_depart_id = New Member().GetColumnValue("Sub_depart_id", Id_card)
    '    End If

    '    Dim Idcards() As String = {Id_card}
    '    Dim bll As New FSC3206Bll()
    '    Dim dt As DataTable = bll.doQuery02(Orgcode, Depart_id, Sub_depart_id, Me.hdYear.Value & Me.hdMonth.Value, Idcards, "", "")

    '    If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
    '        Try
    '            bll.doExportRpt(dt, Orgcode, Me.hdYear.Value, Me.hdMonth.Value)
    '        Catch ex As Exception
    '            AppException.WriteErrorLog(ex.Message & ex.ToString(), CommonFun.Msg.ExportFail)
    '            'AppException.ShowError_ByPage(ex)
    '        End Try
    '    Else
    '        CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
    '    End If
    'End Sub


    'Protected Sub cbRTP2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbRTP2.Click
    '    '加班單明細
    '    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    '    Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    '    Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    '    Dim Metadb_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.MetadbID)

    '    Dim ym As String = Request.QueryString("Year") & Request.QueryString("Month")

    '    If "FSC3206_03" = Request("FORWARD") Then
    '        Depart_id = Request.QueryString("Unit")
    '        ID_card = Request.QueryString("PerId")
    '        Metadb_id = New Member().GetColumnValue("Metadb_id", ID_card)
    '    End If

    '    Dim pr18m As New CPAPR18M(ConnectDB.GetCPADBString(Metadb_id))
    '    Dim dt As DataTable = pr18m.GetQuery(ID_card, ym)
    '    dt.Columns.Add("DEP", GetType(String))
    '    dt.Columns.Add("Write_time", GetType(String))
    '    dt.Columns.Add("PHITIME", GetType(String))

    '    Dim cpaph As New CPAPHYYMM(ym)
    '    For Each dr As DataRow In dt.Rows
    '        dr("DEP") = New FSCorg().GetDepartName(Orgcode, Depart_id)

    '        If dr("PRATYPE") = 1 Then
    '            dr("PRATYPE") = "一般"
    '        ElseIf dr("PRATYPE") = 2 Then
    '            dr("PRATYPE") = "專案"
    '        ElseIf dr("PRATYPE") = 3 Then
    '            dr("PRATYPE") = "大批"
    '        End If

    '        dr("PRSTIME") = dr("PRADDD").ToString & dr("PRSTIME").ToString
    '        dr("PRETIME") = dr("PRADDE").ToString & dr("PRETIME").ToString

    '        'Dim ht As Hashtable = Content.getWorkTime(dr("PRIDNO").ToString(), dr("PRADDD").ToString())
    '        'Dim stime As String = ""
    '        'Dim etime As String = ""
    '        'Dim offday As Boolean = False

    '        'If ht IsNot Nothing Then
    '        '    Dim ph As New CPAPHYYMM(ym)
    '        '    Dim phdt As DataTable = ph.GetListData(dr("PRCARD").ToString(), dr("PRIDNO").ToString(), dr("PRADDD").ToString())
    '        '    If phdt IsNot Nothing And phdt.Rows.Count > 0 Then
    '        '        stime = phdt.Rows(0)("PHITIME").ToString()
    '        '        etime = phdt.Rows(phdt.Rows.Count - 1)("PHITIME").ToString()
    '        '    End If
    '        '    offday = ht("OFFDAY").ToString()
    '        '    If Not offday Then
    '        '        'If Content.getNumberTime(etime) > Content.getNumberTime(stime) Then
    '        '        '    stime = ht("WORKTIMEE").ToString()
    '        '        'End If
    '        '        For Each phdr As DataRow In phdt.Rows
    '        '            If Content.getNumberTime(phdr("PHITIME").ToString()) >= Content.getNumberTime(ht("WORKTIMEE").ToString()) Then
    '        '                stime = phdr("PHITIME").ToString()
    '        '                Exit For
    '        '            End If
    '        '        Next
    '        '    End If
    '        'End If
    '        Dim startTime As String = ""
    '        Dim endTime As String = ""
    '        Dim fdt As DataTable = New Flow().GetFlowByFlow_id(dr("PRGUID").ToString(), Orgcode)
    '        If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
    '            startTime = fdt.Rows(0)("Start_time").ToString().Trim()
    '            endTime = fdt.Rows(0)("End_time").ToString().Trim()
    '        End If

    '        Dim cardTime() As String = cpaph.getAddWorkCardTime(dr("PRIDNO").ToString(), dr("PRCARD").ToString(), ym, dr("PRADDD").ToString(), dr("PRADDE").ToString(), startTime, endTime)
    '        Dim stime As String = cardTime(0)
    '        Dim etime As String = cardTime(1)
    '        dr("PHITIME") = stime & "~" & etime

    '        If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
    '            dr("Write_time") = DateTimeInfo.GetRocDate(fdt.Rows(0)("write_time").ToString())

    '            If fdt.Rows(0)("Nocard_flag").ToString() = "Y" Then
    '                dr("PHITIME") = fdt.Rows(0)("Nocard_reason").ToString()
    '            End If
    '        End If
    '    Next

    '    Dim f As New FSCorg()
    '    Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("~/Report/FSC1/FSC1307_RPT3.mht"), dt)
    '    Dim params(3) As String
    '    params(0) = f.GetOrgcodeName(Orgcode)
    '    params(1) = DateTimeInfo.GetRocTodayString("yyyy/MM/dd")    '印表日期
    '    params(2) = New Member().GetColumnValue("User_name", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))  '印表人員
    '    params(3) = ym.Substring(0, 3) & "年" & ym.Substring(3) & "月"  '查詢區間


    '    rpt.ExportFileName = "加班單明細"
    '    rpt.Param = params
    '    rpt.ExportToExcel()
    'End Sub
#End Region


    Protected Sub toCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toCancel.Click
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) AndAlso Not String.IsNullOrEmpty(org) Then
            If ViewState("BackUrl") IsNot Nothing Then
                Response.Redirect(ViewState("BackUrl").ToString())
            End If
        Else
            Response.Redirect("SAL1112_01.aspx")
        End If

    End Sub


    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub
End Class
