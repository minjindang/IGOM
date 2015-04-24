Imports System.Data
Imports SAL.Logic
Imports System.Transactions
Imports CommonLib

Partial Class SAL1113_01
    Inherits BaseWebForm


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            InitContorl()
            tbList.Visible = False

            If Request.QueryString("ym") <> "" And Request.QueryString("ym1") <> "" Then

                UcDate1.Text = Request.QueryString("ym")
                UcDate2.Text = Request.QueryString("ym1")
                '秀敏add
                'jessica modi 20140109 若參數是空值時，指定給ddl會有問題
                If Not String.IsNullOrEmpty(Request.QueryString("ot")) Then
                    officeOuttype.SelectedValue = Request.QueryString("ot")
                End If
                ShowGridView()
            Else
                ShowGridView(True)
            End If


            If LoginManager.RoleId.IndexOf("Personnel") >= 0 Then
                tr2.Visible = True
                tr3.Visible = True
            End If
        End If
    End Sub

#Region "初始化控制項"

    Protected Sub InitContorl()
        UcDate1.Text = FSC.Logic.DateTimeInfo.GetRocDate(New Date(Now.AddMonths(-1).Year, Now.AddMonths(-1).Month, 1))
        UcDate2.Text = FSC.Logic.DateTimeInfo.GetRocDate(New Date(Now.AddMonths(-1).Year, Now.AddMonths(-1).Month, Date.DaysInMonth(Now.AddMonths(-1).Year, Now.AddMonths(-1).Month)))

        UcDDLDepart.Orgcode = LoginManager.OrgCode
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.Depart_id = LoginManager.Depart_id
        UcDDLDepart.SelectedValue = LoginManager.Depart_id
        UcDDLMember.SelectedValue = LoginManager.UserId

    End Sub


#End Region

#Region "查詢"
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇人員姓名")
            Return
        End If
        ShowGridView()
    End Sub
#End Region

#Region "繫結資料"
    Protected Sub ShowGridView(Optional ByVal isInit As Boolean = False)
        Dim bll As New SAL1113()
        Dim dt As DataTable
        Dim ot As String = officeOuttype.SelectedValue.ToString

        hfIsInit.Value = isInit

        If Not isInit Then
            dt = bll.doQuerySAL1113(UcDDLDepart.SelectedValue, UcDDLMember.SelectedValue, UcDate1.Text, UcDate2.Text, ot)
        Else
            dt = bll.doQuerySAL1113(UcDDLDepart.SelectedValue, UcDDLMember.SelectedValue, "", "", ot, isInit)
        End If

        gvList.DataSource = dt
        gvList.DataBind()

        Ucpager1.Visible = IIf(gvList.Rows.Count > 0, True, False)
        tbList.Visible = True

    End Sub
#End Region

#Region "每列資料特別處理"
    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lkbDateS As Label = CType(e.Row.FindControl("lkbDateS"), Label)
            'Dim lbDash As Label = CType(e.Row.FindControl("lbDash"), Label)
            Dim lbDateE As Label = CType(e.Row.FindControl("lbDateE"), Label)
            Dim lkbTimeS As Label = CType(e.Row.FindControl("lkbTimeS"), Label)
            Dim lbTimeE As Label = CType(e.Row.FindControl("lbTimeE"), Label)
            Dim lbMark As Label = CType(e.Row.FindControl("lbMark"), Label)
            Dim lbType As Label = CType(e.Row.FindControl("lbType"), Label)

            Dim dataRow As DataRowView = CType(e.Row.DataItem, DataRowView)

            lkbDateS.Text = FSC.Logic.DateTimeInfo.ToDisplay(CastTypeFun.CastObjectToString(dataRow("PPBUSDATEB")))
            lbDateE.Text = FSC.Logic.DateTimeInfo.ToDisplay(CastTypeFun.CastObjectToString(dataRow("PPBUSDATEE")))
            lkbTimeS.Text = FSC.Logic.DateTimeInfo.ToDisplayTime(CastTypeFun.CastObjectToString(dataRow("PPTIMEB")))
            lbTimeE.Text = FSC.Logic.DateTimeInfo.ToDisplayTime(CastTypeFun.CastObjectToString(dataRow("PPTIMEE")))

            If Not IsDBNull(dataRow("PPREMARK")) AndAlso dataRow("PPREMARK") = "1" Then
                lbMark.Text = "已領"
            Else
                lbMark.Text = "未領"
            End If

            Dim off As New SAL_OfficialoutFee()
            Dim dt As DataTable = off.GetDataByPPGUID(dataRow("PPGUID").ToString())
            Dim status As String = ""
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                status = dt.Rows(0)("Status").ToString()
            End If

            Select Case status
                Case "yet"
                    CType(e.Row.FindControl("lbStatus"), Label).Text = "己送出申請"
                Case "done"
                    CType(e.Row.FindControl("lbStatus"), Label).Text = "已核銷"
                Case "apply"
                    CType(e.Row.FindControl("lbStatus"), Label).Text = "人事退回"
                Case Else
                    CType(e.Row.FindControl("lbStatus"), Label).Text = ""
            End Select

            '已核銷(註記已領)
            If dataRow("PPREMARK").ToString() = "1" Then
                CType(e.Row.FindControl("gv_cbx"), CheckBox).Enabled = False
            End If

            'If Not IsDBNull(dataRow("PPBUSTYPE")) AndAlso dataRow("PPBUSTYPE") = "1" Then
            '    lbType.Text = "公差"
            'ElseIf Not IsDBNull(dataRow("PPBUSTYPE")) AndAlso dataRow("PPBUSTYPE") = "2" Then
            '    lbType.Text = "公出"
            'End If

            If Not IsDBNull(dataRow("location_flag")) AndAlso dataRow("location_flag") = "0" Then
                lbType.Text = "國內"
            ElseIf Not IsDBNull(dataRow("location_flag")) AndAlso dataRow("location_flag") = "1" Then
                lbType.Text = "國外"
            End If
        End If
    End Sub
#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowGridView(hfIsInit.Value)
    End Sub
#End Region

    Protected Sub cbApply_Click(sender As Object, e As System.EventArgs) Handles cbApply.Click
        Dim ym As String = UcDate1.Text '起始日
        Dim ym1 As String = UcDate2.Text '結束日
        Dim guidlist As String = ""
        Dim tmplocation_flag As String = ""

        For Each gvr As GridViewRow In gvList.Rows
            Dim cbx As CheckBox = CType(gvr.FindControl("gv_cbx"), CheckBox)
            If cbx.Checked Then

                Dim location_flag As String = CType(gvr.FindControl("lblocation_flag"), Label).Text

                If Not String.IsNullOrEmpty(tmplocation_flag) AndAlso tmplocation_flag <> location_flag Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "不可同時選取國內及國外出差!")
                    Return
                End If

                Dim PPIDNO As String = CType(gvr.FindControl("lbPPIDNO"), Label).Text
                Dim PPBUSTYPE As String = CType(gvr.FindControl("lbPPBUSTYPE"), Label).Text
                Dim PPBUSDATEB As String = CType(gvr.FindControl("lbPPBUSDATEB"), Label).Text
                Dim PPTIMEB As String = CType(gvr.FindControl("lbPPTIMEB"), Label).Text
                Dim PPGUID As String = gvr.Cells(8).Text.Trim()

                guidlist &= PPIDNO & "|" & PPBUSTYPE & "|" & PPBUSDATEB & "|" & PPTIMEB & "|" & PPGUID & ","
                'If guidlist.IndexOf(gvr.Cells(8).Text.Trim()) < 0 Then
                '    guidlist &= gvr.Cells(8).Text.Trim() & ","
                'End If

                tmplocation_flag = location_flag
            End If
        Next
        If String.IsNullOrEmpty(guidlist) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "您尚未選取公差單")
            Return
        End If

        Dim oy As String = tmplocation_flag 'officeOuttype.SelectedValue.ToString
        If oy = "0" Then
            Response.Redirect("SAL1113_02.aspx?ym=" & ym & "&guidlist=" & guidlist.TrimEnd(",") & "&ym1=" & ym1) ''ym是起始日ym1是結束日
        Else
            Response.Redirect("SAL1113_03.aspx?ym=" & ym & "&guidlist=" & guidlist.TrimEnd(",") & "&ym1=" & ym1) ''國外出差
        End If

    End Sub


    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub
End Class
