Imports System.Data
Imports System.IO
Imports FSC.Logic
Imports System.Transactions
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC1108_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        initData()
    End Sub

#Region "初始化"
    Protected Sub initData()

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        ddlDept.DataTextField = "Depart_Name"
        ddlDept.DataValueField = "Depart_id"
        ddlDept.DataSource = New Org().GetDataByParentDepartid(Orgcode, "")
        ddlDept.DataBind()
        ddlDept.Items.Insert(0, New ListItem("請選擇", ""))

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") < 0 Then
            ddlDept.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id).Substring(0, 2)
            ddlDept.Enabled = False
        End If

        tbLastdatereason.Text = "xxx年xx月xx日事由："
        UcApplyDate.Text = DateTimeInfo.GetRocTodayString("yyyyMMdd")

        gvBind()
        BindTempData()
    End Sub

    Protected Function initDt() As DataTable
        Dim dt As DataTable = CType(ViewState("gv"), DataTable)

        If dt Is Nothing Then
            dt = New DataTable()
            dt.Columns.Add("Depart_id")
            dt.Columns.Add("id_card")
            dt.Columns.Add("TitleName")
            dt.Columns.Add("Employee_type_name")
            dt.Columns.Add("Level")
            dt.Columns.Add("Level_name")
            dt.Columns.Add("Reword_type")
            dt.Columns.Add("According_Clause")
            dt.Columns.Add("Specific_facts")
            dt.Columns.Add("Reword_note")

            Dim dr As DataRow = dt.NewRow
            dt.Rows.InsertAt(dr, dt.Rows.Count + 1)
        End If

        ViewState("gv") = dt
        Return dt
    End Function
#End Region

#Region "送出申請"
    Protected Sub cbSubmit_Click(sender As Object, e As EventArgs) Handles cbSubmit.Click
        Dim msg As String = checkMsg()
        If Not String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
            Return
        End If

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow()

        Try
            f.Orgcode = Orgcode
            f.DepartId = Depart_id
            f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
            f.WriterOrgcode = Orgcode
            f.WriterDepartid = Depart_id
            f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            f.WriteTime = Date.Now
            f.FormId = "001008"
            f.Reason = tbReason.Text.Trim()
            f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)


            Using trans As New TransactionScope
                Dim flow_id As String = New SYS.Logic.FlowId().GetFlowId(Orgcode, "001008", Nothing)
                f.FlowId = flow_id

                SYS.Logic.CommonFlow.AddFlow(f)

                SaveReword(flow_id)

                trans.Complete()
            End Using

            SendNotice.send(f.Orgcode, f.FlowId)
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "../FSC0/FSC0101_01.aspx")
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

#Region "檢核"
    Protected Function checkMsg() As String
        If String.IsNullOrEmpty(ddlDept.SelectedValue) Then
            Return "提報單位為必填!"
        End If
        If String.IsNullOrEmpty(UcApplyDate.Text) Then
            Return "提報日期為必填!"
        End If
        If String.IsNullOrEmpty(tbReason.Text.Trim()) Then
            Return "敘獎事由為必填!"
        ElseIf tbReason.Text.Trim().Length > 150 Then
            Return "敘獎事由不可超過150字!"
        End If
        If rbReason_type1.Checked AndAlso (String.IsNullOrEmpty(tbReason_point.Text.Trim()) OrElse _
                                           String.IsNullOrEmpty(tbReason_section.Text.Trim())) Then
            Return "請輸入敘獎原則!"
        End If
        If String.IsNullOrEmpty(tbSelfpoint.Text.Trim()) Then
            Return "自評點數為必填!"
        End If
        If Not CommonFun.IsNum(tbSelfpoint.Text.Trim()) Then
            Return "自評點數請輸入數字!"
        End If
        If String.IsNullOrEmpty(tbLastpoint.Text.Trim()) Then
            Return "最近一次相關案例敘獎點數!"
        End If
        If String.IsNullOrEmpty(tbLastdatereason.Text.Trim()) Then
            Return "最近一次相關案例辦理日期及事由!"
        End If
        If String.IsNullOrEmpty(tbLastpoint.Text.Trim()) Then
            Return "敘獎點數為必填!"
        End If
        If Not CommonFun.IsNum(tbLastpoint.Text.Trim()) Then
            Return "敘獎點數請輸入數字!"
        End If
        If String.IsNullOrEmpty(tbLastdatereason.Text.Trim()) Then
            Return "相關案例辦理日期及事由為必填!"
        End If
        If String.IsNullOrEmpty(tbInput_manpower.Text.Trim()) Then
            Return "投入人數為必填!"
        End If
        If rbInput_manpower_type2.Checked AndAlso String.IsNullOrEmpty(tbInput_manpower_note.Text.Trim()) Then
            Return "辦理情形選擇委辦請填寫備註說明!"
        End If
        If String.IsNullOrEmpty(UcInput_sdate.Text) OrElse String.IsNullOrEmpty(UcInput_sdate.Text) Then
            Return "投入期間為必填!"
        End If
        If UcInput_sdate.Text > UcInput_sdate.Text Then
            Return "投入期間(起)不可大於投入期間(迄)!"
        End If
        If rbinput_conform2.Checked AndAlso String.IsNullOrEmpty(tbinput_notconform_reason.Text.Trim()) Then
            Return "選擇未符合提報敘獎期限請填寫理由!"
        End If
        If String.IsNullOrEmpty(tbInnovative_desc.Text.Trim()) Then
            Return "創新性為必填!"
        ElseIf tbInnovative_desc.Text.Trim().Length > 300 Then
            Return "創新性不可超過300字!"
        End If
        If String.IsNullOrEmpty(tbDifficulty_desc.Text.Trim()) Then
            Return "困難度為必填!"
        ElseIf tbDifficulty_desc.Text.Trim().Length > 300 Then
            Return "困難度不可超過300字!"
        End If
        If String.IsNullOrEmpty(tbContribution_desc.Text.Trim()) Then
            Return "貢獻度(成效)為必填!"
        ElseIf tbContribution_desc.Text.Trim().Length > 300 Then
            Return "貢獻度(成效)不可超過300字!"
        End If

        Dim nameList As New ArrayList()
        For Each gvr As GridViewRow In gv.Rows
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("gv_UcDDLDepart"), UControl_UcDDLDepart)
            Dim ddlName As DropDownList = CType(gvr.FindControl("gv_ddlName"), DropDownList)
            Dim ddlReword_type As DropDownList = CType(gvr.FindControl("gv_ddlReword_type"), DropDownList)
            Dim tbAccording_Clause As TextBox = CType(gvr.FindControl("gv_tbAccording_Clause"), TextBox)
            Dim tbSpecific_facts As TextBox = CType(gvr.FindControl("gv_tbSpecific_facts"), TextBox)
            'Dim tbReword_note As TextBox = CType(gvr.FindControl("gv_tbReword_note"), TextBox)
            Dim lbNum As Label = CType(gvr.FindControl("gv_lbNum"), Label)

            If String.IsNullOrEmpty(UcDDLDepart.SelectedValue) OrElse String.IsNullOrEmpty(ddlName.SelectedIndex) OrElse _
                String.IsNullOrEmpty(ddlReword_type.SelectedValue) OrElse String.IsNullOrEmpty(tbAccording_Clause.Text.Trim()) OrElse _
                String.IsNullOrEmpty(tbSpecific_facts.Text.Trim()) Then
                Return "項次" + lbNum.Text + "：獎懲建議有未輸入的欄位!"
            End If

            If nameList.Contains(ddlName.SelectedValue) Then
                Return "獎懲建議人員不可重覆!"
            Else
                nameList.Add(ddlName.SelectedValue)
            End If
        Next

        Return ""
    End Function
#End Region

#Region "匯出"
    Protected Sub cbExcel_Click(sender As Object, e As EventArgs) Handles cbExcel.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = GvToDt()

        Dim strParam(14) As String
        strParam(0) = ddlDept.SelectedItem.Text
        strParam(1) = tbReason.Text.Trim()
        If rbReason_type1.Checked Then
            strParam(2) = "■ 依「行政院環境保護署所屬人員提報敘獎原則」第" + tbReason_point.Text.Trim() + "點 第" + _
                    tbReason_section.Text.Trim() + "項 第" + tbReason_item.Text.Trim() + "款規定辦理"
        Else
            strParam(2) = "□ 依「行政院環境保護署所屬人員提報敘獎原則」第__點 第__項 第__款規定辦理"
        End If
        strParam(3) = IIf(rbReason_type1.Checked, "□", "■") + "其他〈相關法令、計畫或評比定有明確獎勵標準者，請檢附相關規定並敘明〉"
        strParam(4) = tbSelfpoint.Text.Trim() + "點"
        strParam(5) = tbLastpoint.Text.Trim() + "點"
        strParam(6) = "一、人數：" + tbInput_manpower.Text.Trim() + "人"
        strParam(7) = IIf(rbInput_manpower_type1.Checked, "■", "□") + "自辦"
        strParam(8) = IIf(rbInput_manpower_type2.Checked, "■", "□") + "委辦〈請說明分工項目，例：場地佈置委由廠商辦理，餘自辦〉"
        strParam(9) = "一、投入期間：" + Left(UcInput_sdate.Text, 3) + "年" + Mid(UcInput_sdate.Text, 4, 2) + "月" + Right(UcInput_sdate.Text, 2) + "日至" + _
                    Left(UcInput_edate.Text, 3) + "年" + Mid(UcInput_edate.Text, 4, 2) + "月" + Right(UcInput_edate.Text, 2) + "日"
        strParam(10) = If(rbinput_conform1.Checked, "■", "□") + "符合〈敘獎原則第五點〉"
        strParam(11) = IIf(rbinput_conform2.Checked, "■", "□") + "未符合〈請敘明理由〉 理由：" + tbinput_notconform_reason.Text.Trim
        strParam(12) = tbInnovative_desc.Text.Trim()
        strParam(13) = tbDifficulty_desc.Text.Trim()
        strParam(14) = tbContribution_desc.Text.Trim()

        Try
            dt.Columns.Add("DepTitle")
            dt.Columns.Add("User_Name")
            dt.Columns.Add("ChReword_type")
            For Each dr As DataRow In dt.Rows
                dr("DepTitle") = New Org().GetDepartName(Orgcode, dr("Depart_id").ToString()) + "<br />" + dr("TitleName").ToString()
                dr("User_Name") = New Personnel().GetColumnValue("User_Name", dr("id_card").ToString())
                dr("ChReword_type") = New SYS.Logic.CODE().GetDataDESC("023", "028", dr("Reword_type").ToString().Split(",")(0))
            Next

            Dim dv As DataView = dt.DefaultView
            dt.DefaultView.Sort = "Depart_id, Level DESC"
            Dim theDTReport As CommonLib.DTReport
            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC1108_01.mht"), dv.ToTable)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "敘獎申請作業"
            theDTReport.ExportToExcel()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.ExportFail)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

        dt.Dispose()
    End Sub
#End Region

#Region "連繫資料"
    Protected Sub gv_DataBinding(sender As Object, e As EventArgs) Handles gv.DataBound
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim num As Integer = 1
        For Each gvr As GridViewRow In gv.Rows
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("gv_UcDDLDepart"), UControl_UcDDLDepart)
            Dim ddlName As DropDownList = CType(gvr.FindControl("gv_ddlName"), DropDownList)
            Dim ddlReword_type As DropDownList = CType(gvr.FindControl("gv_ddlReword_type"), DropDownList)
            Dim lbDepart As Label = CType(gvr.FindControl("gv_lbDepart"), Label)
            Dim lbIdcard As Label = CType(gvr.FindControl("gv_lbIdcard"), Label)
            Dim lbReword_type As Label = CType(gvr.FindControl("gv_lbReword_type"), Label)
            Dim lbNum As Label = CType(gvr.FindControl("gv_lbNum"), Label)
            Dim tbAccording_Clause As TextBox = CType(gvr.FindControl("gv_tbAccording_Clause"), TextBox)
            lbNum.Text = num
            num = num + 1

            UcDDLDepart.Orgcode = Orgcode
            UcDDLDepart.SelectedValue = lbDepart.Text
            UcDDLDepart.Sub_Visible = False

            BindName(UcDDLDepart.SelectedValue, ddlName)
            ddlName.SelectedValue = lbIdcard.Text

            BindReword_type(ddlReword_type)
            ddlReword_type.SelectedValue = lbReword_type.Text
        Next
    End Sub

    Protected Sub BindName(ByVal Depart_id As String, ByVal ddlName As DropDownList)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        ddlName.Items.Clear()
        If Not String.IsNullOrEmpty(Depart_id) Then
            ddlName.DataTextField = "Full_Name"
            ddlName.DataValueField = "Id_card"
            ddlName.DataSource = New Personnel().GetDataWithoutMaintainVendors(Orgcode, Depart_id)
            ddlName.DataBind()
        End If
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindReword_type(ByVal ddlReword_type As DropDownList)
        Dim dt As DataTable = New SYS.Logic.CODE().GetData("023", "028")
        dt.Columns.Add("col")

        For Each dr As DataRow In dt.Rows
            dr("col") = dr("CODE_NO").ToString() + "," + dr("CODE_DESC2").ToString()
        Next

        ddlReword_type.DataTextField = "CODE_DESC1"
        ddlReword_type.DataValueField = "col"
        ddlReword_type.DataSource = dt
        ddlReword_type.DataBind()

        ddlReword_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub gvddlDepart_id_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvddlDepartID As DropDownList = CType(sender, DropDownList)
        Dim index As Integer = CType(CType(gvddlDepartID.NamingContainer, UControl_UcDDLDepart).NamingContainer, GridViewRow).RowIndex

        Dim ddlName As DropDownList = CType(gv.Rows(index).FindControl("gv_ddlName"), DropDownList)
        BindName(gvddlDepartID.SelectedValue, ddlName)
    End Sub

    Protected Sub gvddlName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvddlName As DropDownList = CType(sender, DropDownList)
        Dim index As Integer = CType(gvddlName.NamingContainer, GridViewRow).RowIndex

        Dim lbTitleName As Label = CType(gv.Rows(index).FindControl("gv_lbTitleName"), Label)
        Dim lbEmployee_type As Label = CType(gv.Rows(index).FindControl("gv_lbEmployee_type"), Label)
        Dim lblevel As Label = CType(gv.Rows(index).FindControl("gv_lblevel"), Label)
        Dim lblevel_name As Label = CType(gv.Rows(index).FindControl("gv_lblevel_name"), Label)

        lbTitleName.Text = New SYS.Logic.CODE().GetFSCTitleName(New Personnel().GetColumnValue("TiTle_No", gvddlName.SelectedValue))
        lbEmployee_type.Text = New SYS.Logic.CODE().GetDataDESC("023", "022", New Personnel().GetColumnValue("Employee_type", gvddlName.SelectedValue))
        lblevel.Text = New Personnel().GetColumnValue("Degree_code", gvddlName.SelectedValue)
        lblevel_name.Text = New SYS.Logic.CODE().GetDataDESC("023", "031", New Personnel().GetColumnValue("Degree_code", gvddlName.SelectedValue))
    End Sub

    Protected Sub gvddlReword_type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ddlReword_type As DropDownList = CType(sender, DropDownList)
        Dim index As Integer = CType(ddlReword_type.NamingContainer, GridViewRow).RowIndex

        Dim tbAccording_Clause As TextBox = CType(gv.Rows(index).FindControl("gv_tbAccording_Clause"), TextBox)
        If Not String.IsNullOrEmpty(ddlReword_type.SelectedValue) Then
            tbAccording_Clause.Text = ddlReword_type.SelectedValue.Split(",")(1)
        End If
    End Sub

    Protected Sub doJoin(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim btnJoin As Button = CType(sender, Button)
        Dim cell As DataControlFieldCell = CType(btnJoin.Parent, DataControlFieldCell)
        Dim row As GridViewRow = CType(cell.Parent, GridViewRow)
        Dim index As Integer = row.RowIndex

        Dim dt As DataTable = GvToDt()

        dt.Rows.InsertAt(dt.NewRow(), index + 1)
        ViewState("gv") = dt
        gvBind()

    End Sub

    Protected Sub doDelete(ByVal sender As Object, ByVal e As System.EventArgs)
        If gv.Rows.Count = 1 Then
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), Guid.NewGuid.ToString(), "alert('必須填寫獎懲建議!');", True)
            Return
        End If

        Dim btnDel As Button = CType(sender, Button)
        Dim cell As DataControlFieldCell = CType(btnDel.Parent, DataControlFieldCell)
        Dim row As GridViewRow = CType(cell.Parent, GridViewRow)
        Dim index As Integer = row.RowIndex

        Dim dt As DataTable = GvToDt()

        dt.Rows.Remove(dt.Rows(index))
        ViewState("gv") = dt
        gvBind()
    End Sub

    Protected Function GvToDt() As DataTable
        Dim dt As DataTable = initDt()
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gv.Rows(i).FindControl("gv_UcDDLDepart"), UControl_UcDDLDepart)
            Dim ddlName As DropDownList = CType(gv.Rows(i).FindControl("gv_ddlName"), DropDownList)
            Dim ddlReword_type As DropDownList = CType(gv.Rows(i).FindControl("gv_ddlReword_type"), DropDownList)
            Dim lbTitleName As Label = CType(gv.Rows(i).FindControl("gv_lbTitleName"), Label)
            Dim lbEmployee_type As Label = CType(gv.Rows(i).FindControl("gv_lbEmployee_type"), Label)
            Dim gv_lblevel_name As Label = CType(gv.Rows(i).FindControl("gv_lblevel_name"), Label)
            Dim gv_lblevel As Label = CType(gv.Rows(i).FindControl("gv_lblevel"), Label)
            Dim tbAccording_Clause As TextBox = CType(gv.Rows(i).FindControl("gv_tbAccording_Clause"), TextBox)
            Dim tbSpecific_facts As TextBox = CType(gv.Rows(i).FindControl("gv_tbSpecific_facts"), TextBox)
            Dim tbReword_note As TextBox = CType(gv.Rows(i).FindControl("gv_tbReword_note"), TextBox)

            Dim dr As DataRow = dt.Rows(i)
            dr("Depart_id") = UcDDLDepart.SelectedValue
            dr("id_card") = ddlName.SelectedValue
            dr("TitleName") = lbTitleName.Text
            dr("Employee_type_name") = lbEmployee_type.Text
            dr("Level") = gv_lblevel.Text
            dr("Level_name") = gv_lblevel_name.Text
            dr("Reword_type") = ddlReword_type.SelectedValue
            dr("According_Clause") = tbAccording_Clause.Text.Trim()
            dr("Specific_facts") = tbSpecific_facts.Text.Trim()
            dr("Reword_note") = tbReword_note.Text.Trim()
        Next

        Return dt
    End Function

    Protected Sub gvBind()
        gv.DataSource = initDt()
        gv.DataBind()
    End Sub
#End Region

    Protected Sub cbSaave_Click(sender As Object, e As EventArgs)
        
        SaveReword(LoginManager.UserId)
    End Sub

    Protected Sub BindTempData()
        If Not String.IsNullOrEmpty(Request.QueryString("org")) Or Not String.IsNullOrEmpty(Request.QueryString("fid")) Then
            Return
        End If

        Dim orgcode As String = LoginManager.OrgCode
        Dim r As RewordMain = New RewordMain()
        Dim rd As RewordDet = New RewordDet()
        Dim list As New List(Of RewordDet)

        Dim rdt As DataTable = r.GetTempData(orgcode, LoginManager.UserId)
        If rdt IsNot Nothing AndAlso rdt.Rows.Count > 0 Then

            Dim dr As DataRow = rdt.Rows(0)
            ddlDept.SelectedValue = dr("Depart_id").ToString()
            UcApplyDate.Text = dr("Apply_date").ToString()
            tbReason.Text = dr("Reason").ToString()

            tbReason_point.Text = dr("Reason_point").ToString()
            tbReason_section.Text = dr("Reason_section").ToString()
            tbReason_item.Text = dr("Reason_item").ToString()
            tbReason_list.Text = dr("Reason_list").ToString()

            If Not String.IsNullOrEmpty(dr("Reason_point").ToString()) Then
                rbReason_type1.Checked = True
            Else
                rbReason_type2.Checked = True
            End If

            tbSelfpoint.Text = dr("Self_ssessment_point").ToString()
            tbLastpoint.Text = dr("Last_point").ToString()
            tbLastdatereason.Text = dr("Last_datereason").ToString()
            tbInput_manpower.Text = dr("Input_manpower").ToString()

            If dr("Input_manpower_type").ToString() = "1" Then
                rbInput_manpower_type1.Checked = True
            Else
                rbInput_manpower_type2.Checked = True
            End If

            tbInput_manpower_note.Text = dr("Input_manpower_note").ToString()
            UcInput_sdate.Text = dr("Input_sdate").ToString()
            UcInput_edate.Text = dr("Input_edate").ToString()

            If dr("input_conform").ToString() = "1" Then
                rbinput_conform1.Checked = True
            Else
                rbinput_conform2.Checked = True
            End If

            tbinput_notconform_reason.Text = dr("input_notconform_reason").ToString()
            tbInnovative_desc.Text = dr("Innovative_desc").ToString()
            tbDifficulty_desc.Text = dr("Difficulty_desc").ToString()
            tbContribution_desc.Text = dr("Contribution_desc").ToString()
        End If

        Dim rddt As DataTable = rd.GetTempData(orgcode, LoginManager.UserId)
        If rddt IsNot Nothing AndAlso rddt.Rows.Count > 0 Then
            Dim gvdt As DataTable = ViewState("gv")
            Dim dt As DataTable = gvdt.Clone()
            Dim code As New FSCPLM.Logic.SACode()

            For Each rddr As DataRow In rddt.Rows
                Dim ndr As DataRow = dt.NewRow
                ndr("Depart_id") = rddr("Reword_departid").ToString()
                ndr("id_card") = rddr("Reword_Idcard").ToString()
                ndr("TitleName") = code.GetCodeDesc("023", "012", rddr("Reword_Title_no").ToString())
                ndr("Employee_type_name") = code.GetCodeDesc("023", "022", rddr("Reword_Employee_type").ToString())
                ndr("Level") = rddr("Reword_Level").ToString()
                ndr("Level_name") = code.GetCodeDesc("023", "031", rddr("Reword_Level").ToString())
                ndr("Reword_type") = rddr("Reword_type").ToString() + "," + rddr("According_Clause").ToString()
                ndr("According_Clause") = rddr("According_Clause").ToString()
                ndr("Specific_facts") = rddr("Specific_facts").ToString()
                ndr("Reword_note") = rddr("Reword_note").ToString()
                dt.Rows.Add(ndr)
            Next

            ViewState("gv") = dt
            gv.DataSource = dt
            gv.DataBind()
        End If

    End Sub

    Protected Sub SaveReword(ByVal flow_id As String)
        Dim orgcode As String = LoginManager.OrgCode
        Dim r As RewordMain = New RewordMain()
        Dim rd As RewordDet = New RewordDet()
        Dim list As New List(Of RewordDet)

        r.Orgcode = orgcode
        r.Depart_id = ddlDept.SelectedValue
        r.Id_card = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        r.Apply_name = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        r.Apply_date = UcApplyDate.Text
        r.Reason = tbReason.Text.Trim()
        r.Reason_type = IIf(rbReason_type1.Checked, "1", "2")
        If rbReason_type1.Checked Then
            r.Reason_point = tbReason_point.Text.Trim()
            r.Reason_section = tbReason_section.Text.Trim()
            r.Reason_item = tbReason_item.Text.Trim()
            r.Reason_list = tbReason_list.Text.Trim()
        End If
        r.Self_ssessment_point = tbSelfpoint.Text.Trim()
        r.Last_point = tbLastpoint.Text.Trim()
        r.Last_datereason = tbLastdatereason.Text.Trim()
        r.Input_manpower = tbInput_manpower.Text.Trim()
        r.Input_manpower_type = IIf(rbInput_manpower_type1.Checked, "1", "2")
        If rbInput_manpower_type1.Checked Then
            r.Input_manpower_note = tbInput_manpower_note.Text.Trim()
        End If
        r.Input_sdate = UcInput_sdate.Text
        r.Input_edate = UcInput_edate.Text
        r.input_conform = IIf(rbinput_conform1.Checked, "1", "2")
        If rbinput_conform1.Checked Then
            r.input_notconform_reason = tbinput_notconform_reason.Text.Trim()
        End If
        r.Innovative_desc = tbInnovative_desc.Text.Trim()
        r.Difficulty_desc = tbDifficulty_desc.Text.Trim()
        r.Contribution_desc = tbContribution_desc.Text.Trim()
        r.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        For Each gvr As GridViewRow In gv.Rows
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("gv_UcDDLDepart"), UControl_UcDDLDepart)
            Dim ddlName As DropDownList = CType(gvr.FindControl("gv_ddlName"), DropDownList)
            Dim ddlReword_type As DropDownList = CType(gvr.FindControl("gv_ddlReword_type"), DropDownList)
            Dim tbAccording_Clause As TextBox = CType(gvr.FindControl("gv_tbAccording_Clause"), TextBox)
            Dim tbSpecific_facts As TextBox = CType(gvr.FindControl("gv_tbSpecific_facts"), TextBox)
            Dim tbReword_note As TextBox = CType(gvr.FindControl("gv_tbReword_note"), TextBox)

            Dim dt As DataTable = New Personnel().GetDataByIdCard(ddlName.SelectedValue)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無獎懲人員!")
                Exit Sub
            End If
            rd = New RewordDet()
            rd.Reword_departid = UcDDLDepart.SelectedValue
            rd.Reword_Idcard = ddlName.SelectedValue
            rd.Reword_username = dt.Rows(0)("User_Name").ToString()
            rd.Reword_Title_no = dt.Rows(0)("TiTle_no").ToString()
            rd.Reword_Employee_type = dt.Rows(0)("Employee_type").ToString()
            rd.Reword_Level = dt.Rows(0)("Degree_code").ToString()
            rd.Specific_facts = tbSpecific_facts.Text.Trim()
            rd.According_Clause = tbAccording_Clause.Text.Trim()
            rd.Reword_type = ddlReword_type.SelectedValue().Split(",")(0)
            rd.Reword_note = tbReword_note.Text.Trim()
            rd.Reword_Orgcode = orgcode
            rd.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            list.Add(rd)
        Next

        Using trans As New TransactionScope

            r.DeletTempData(orgcode, LoginManager.UserId)
            rd.DeletTempData(orgcode, LoginManager.UserId)


            r.flow_id = flow_id
            r.insert()
            For Each Reword As RewordDet In list
                Reword.flow_id = flow_id
                Reword.insert()
            Next

            trans.Complete()
        End Using
    End Sub

End Class
