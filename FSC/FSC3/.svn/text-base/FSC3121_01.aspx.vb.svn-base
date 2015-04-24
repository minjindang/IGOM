Imports System.Data
Imports SAL.Logic
Imports System.Transactions
Imports CommonLib

Partial Class FSC3121_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then
            Return
        End If

        hfOrgcode.Value = LoginManager.OrgCode
        BindYear()
        BindDepart()
        BindEmployee_type()
    End Sub

    Public Sub BindYear()
        For i As Integer = Now.Year - 1911 To 100 Step -1
            ddlYear.Items.Add(New ListItem(i.ToString.PadLeft(3, "0")))
        Next
    End Sub

    Public Sub BindDepart()
        Dim bll As New FSC3121()
        ddlDepart.DataSource = bll.GetDepart(LoginManager.OrgCode)
        ddlDepart.DataBind()
    End Sub

    Public Sub BindEmployee_type()
        ddlEmployee_type.Items.Insert(0, New ListItem("請選擇", ""))

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
            ddlEmployee_type.Items.Add(New ListItem("正式人員", "1"))
            ddlEmployee_type.Items.Add(New ListItem("雇員", "2"))
        End If
        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Sec_PerManager") >= 0 Then
            ddlEmployee_type.Items.Add(New ListItem("技工工友", "3"))
            ddlEmployee_type.Items.Add(New ListItem("司機", "5"))
        End If
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs) Handles cbQuery.Click
        Bind()
    End Sub

    Protected Sub Bind(Optional ByVal isUpdate As Boolean = False)
        Dim u_fid As String = Request.QueryString("fid")
        Dim u_org As String = Request.QueryString("org")
        hfYear.Value = ddlYear.SelectedValue
        hfDepart_id.Value = ddlDepart.SelectedValue

        Dim bll As New FSC3121()
        Dim dt As DataTable = bll.GetData(hfOrgcode.Value, hfDepart_id.Value, hfPerId.Value, hfYear.Value, ddlEmployee_type.SelectedValue)
        Me.gvList.DataSource = dt
        Me.gvList.DataBind()
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            cbUpdate.Enabled = False
            cbPrint.Enabled = False
        Else
            cbUpdate.Enabled = True
            cbPrint.Enabled = True
            ViewState("dt") = dt
        End If
        Table1.Visible = True
    End Sub


    Protected Sub toUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUpdate.Click
        If Me.gvList Is Nothing OrElse Me.gvList.Rows Is Nothing Then
            Return
        End If
        Dim orgcode As String = hfOrgcode.Value
        Dim i As Integer = 0
        Dim mergeFlowId As String = ""
        Dim msg As New StringBuilder()
        Dim vdt As DataTable = ViewState("dt")
        vdt.Columns.Add("Flow_id")

        Try
            Using trans As New TransactionScope

                For Each gvr As GridViewRow In gvList.Rows
                    If CType(gvr.FindControl("hfTotal_fee"), HiddenField).Value = 0 Then
                        Continue For
                    End If

                    Dim flowId As String = New SYS.Logic.FlowId().GetFlowId(orgcode, "00B001")
                    If i = 0 Then
                        mergeFlowId = flowId
                    End If

                    Dim va As New FSC.Logic.VacationAllowance()
                    va.Orgcode = orgcode
                    va.Id_card = CType(gvr.FindControl("hfId_card"), HiddenField).Value
                    va.Fee_year = hfYear.Value

                    Dim dt As DataTable = va.GetData(va.Orgcode, va.Id_card, va.Fee_year)
                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                        va.Inter_days = CType(gvr.FindControl("hfInter_days"), HiddenField).Value
                        va.Inter_days_card = CType(gvr.FindControl("hfInter_days_card"), HiddenField).Value
                        va.Outer_days = CType(gvr.FindControl("hfOuter_days"), HiddenField).Value
                        va.Pay_days = CType(gvr.FindControl("hfPay_days"), HiddenField).Value
                        va.Total_fee = CType(gvr.FindControl("hfTotal_fee"), HiddenField).Value
                        va.Holidays = CType(gvr.FindControl("hfHolidays"), HiddenField).Value
                        va.Leave_days = CType(gvr.FindControl("hfLeave_days"), HiddenField).Value
                        va.Left_days = CType(gvr.FindControl("hfLeft_days"), HiddenField).Value
                        va.Flow_id = flowId
                        va.insert()

                        Dim payDAO As New FSCPLM.Logic.SAL_PAYITEM()
                        payDAO.Add(orgcode, va.Id_card, flowId, mergeFlowId, "005", "D", "001", "656", "001", _
                               "", "", "001", va.Total_fee, LoginManager.UserId, Now, "")
                    Else
                        Dim user_name As String = CType(gvr.FindControl("hfUser_name"), HiddenField).Value
                        msg.Append(user_name).Append("已申請過").Append(hfYear.Value).Append("年度休假補假費\n")
                    End If

                    vdt.Rows(i)("Flow_id") = flowId

                    i += 1
                Next

                trans.Complete()
            End Using

            ViewState("dt") = vdt

            If Not String.IsNullOrEmpty(msg.ToString()) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg.ToString())
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            End If

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        End Try
    End Sub


    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        If Not dt.Columns.Contains("Flow_id") Then
            dt.Columns.Add("Flow_id")
        End If
        dt.Columns.Add("Memo")

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            Dim lm As New FSC.Logic.LeaveMain()

            For Each dr As DataRow In dt.Rows
                Dim ddt As DataTable = New FSC.Logic.VacationAllowance().GetData(dr("Orgcode"), dr("Id_card"), hfYear.Value)
                If ddt IsNot Nothing AndAlso ddt.Rows.Count > 0 Then
                    dr("Flow_id") = ddt.Rows(0)("Flow_id").ToString()
                End If
                Dim memo As New StringBuilder()
                Dim ldt As DataTable = lm.GetDataByYYYMM(dr("id_card").ToString(), "03", dr("yyy").ToString())
                For Each ldr As DataRow In ldt.Rows
                    memo.Append(ldr("Start_date").ToString().Substring(3)).Append("(").Append(ldr("Leave_hours").ToString()).Append(")-")
                Next
                dr("Memo") = memo.ToString()
            Next

            Dim theDTReport As CommonLib.DTReport

            Dim strParam(2) As String
            strParam(0) = New FSC.Logic.Org().GetOrgcodeName(LoginManager.OrgCode)
            strParam(1) = hfYear.Value

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC3107.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "休假補助印領清冊"
            theDTReport.ExportToWord()

            dt.Dispose()
        End If

    End Sub

End Class
