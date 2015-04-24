Imports System.Data
Imports FSCPLM.Logic 

Partial Class MAT_MAT1_MAT1101_02
    Inherits BaseWebForm

    Public Sub confirm(ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        Me.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub


    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        '按了確定要執行的程式碼
        If target = "ApplyAgain" Then
            If argument = "Y" Then
                Response.Redirect("~/MAT/MAT1/MAT1101_01.aspx")
            Else
                DonBtn.Enabled = False
                ResetBtn.Enabled = False
                ddlUserId.Enabled = False
                For Each gr As GridViewRow In GridViewA.Rows
                    Dim btnDelete As Button = gr.FindControl("btnDelete")
                    Dim txtApplyCnt As TextBox = gr.FindControl("txtApplyCnt")
                    Dim txtMemo As TextBox = gr.FindControl("txtMemo")
                    btnDelete.Enabled = False
                    txtApplyCnt.Enabled = False
                    txtMemo.Enabled = False
                Next
            End If
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        checkConfirm()
        If Not Page.IsPostBack Then
            SetInitialRow()
            'Using plmconn As New SqlClient.SqlConnection(ConnectDB.GetDBString())
            '    Dim f As New Flow(plmconn)
            '    Me.txtFlowId.Text = f.GetFlow_id(f.Leave_type)
            'End Using
            Me.txtApplyDate.Text = CommonFun.getYYYMMDD()
            Me.txtModUserId.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            Dim materials As String = Request.QueryString("Materials")
            BindGV(materials)
            ResetBtn.PostBackUrl = "~/MAT/MAT1/MAT1101_01.aspx?Materials=" & materials
            Dim p As New FSC.Logic.Personnel
            Me.ddlUserId.DataSource = p.GetDataByOrgDep(LoginManager.OrgCode, LoginManager.Depart_id)
            Me.ddlUserId.DataTextField = "User_name"
            Me.ddlUserId.DataValueField = "Id_card"
            Me.ddlUserId.DataBind()
            Me.ddlUserId.SelectedValue = LoginManager.UserId
            'Dim f As New Flow()
            'txtFlowId.Text = f.GetFlow_id(51)

            ShowReSendData()
        End If

    End Sub


    Protected Sub ShowReSendData()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(org) AndAlso Not String.IsNullOrEmpty(fid) Then
            Dim bll As New FSC.Logic.FSC0101()
            Dim dt As DataTable = bll.GetApplyMaterialData(org, fid)
            dt.Columns.Add("Index")
            Dim i As Integer = 1
            For Each dr As DataRow In dt.Rows
                dr("Index") = i
                i += 1
            Next
            GridViewA.DataSource = dt
            GridViewA.DataBind()
            ViewState("CurrentTable") = dt
            txtFlowId.Text = fid
            DonBtn.Text = "確認"
            ResetBtn.Visible = False
            ddlUserId.Enabled = False
            BackBtn.Visible = True
        End If
    End Sub

    Private Sub BindGV(Materials As String)
        Dim material As New Material_main
        Dim dtResult As DataTable = material.GetDataByIds(Materials)
        If Not dtResult Is Nothing Then
            Dim dt As DataTable = ViewState("CurrentTable")
            If dt Is Nothing Then
                SetInitialRow()
                dt = ViewState("CurrentTable")
            End If
            Dim index As Integer = dt.Rows.Count
            For Each dr As DataRow In dtResult.Rows
                Dim newDr As DataRow = dt.NewRow() 
                newDr("Index") = index + 1
                newDr("Material_id") = CommonFun.SetDataRow(dr, "Material_id")
                newDr("Material_name") = CommonFun.SetDataRow(dr, "Material_name")
                newDr("Apply_cnt") = "1"
                newDr("Unit") = CommonFun.SetDataRow(dr, "Unit")
                newDr("Memo") = ""
                dt.Rows.Add(newDr)
                index += 1
            Next
            ViewState("CurrentTable") = dt
            Me.GridViewA.DataSource = dt
            Me.GridViewA.DataBind()
        End If

    End Sub

    Private Sub SetInitialRow()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Index"))
        dt.Columns.Add(New DataColumn("Material_id"))
        dt.Columns.Add(New DataColumn("Material_name"))
        dt.Columns.Add(New DataColumn("Apply_cnt"))
        dt.Columns.Add(New DataColumn("Unit"))
        dt.Columns.Add(New DataColumn("Memo"))

        ViewState("CurrentTable") = dt
    End Sub

    Private Sub GvToDt()
        SetInitialRow()
        Dim dt As DataTable = CType(ViewState("CurrentTable"), DataTable)

        For Each gvr As GridViewRow In GridViewA.Rows
            Dim dr As DataRow = dt.NewRow
            dr("Material_id") = CType(gvr.FindControl("hfMaterial_id"), HiddenField).Value
            dr("Material_name") = gvr.Cells(1).Text
            dr("Apply_cnt") = CType(gvr.FindControl("txtApplyCnt"), TextBox).Text
            dr("Unit") = gvr.Cells(3).Text
            dr("Memo") = CType(gvr.FindControl("txtMemo"), TextBox).Text
            dt.Rows.Add(dr)
        Next

        ViewState("CurrentTable") = dt
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs)
        Dim gr As GridViewRow = CType(sender, Button).NamingContainer
        GvToDt()
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
        'If dtCurrentTable.Rows.Count = 1 Then
        '    SetInitialRow()
        '    Return
        'End If

        dtCurrentTable.Rows.RemoveAt(gr.RowIndex)
        For i As Integer = 0 To dtCurrentTable.Rows.Count - 1
            dtCurrentTable.Rows(i)("Index") = i + 1
        Next
        ViewState("CurrentTable") = dtCurrentTable
        Me.GridViewA.DataSource = dtCurrentTable
        Me.GridViewA.DataBind()

    End Sub

    Protected Sub OkBtn_Click(sender As Object, e As EventArgs) Handles DonBtn.Click
        If Me.GridViewA.Rows.Count > 0 Then
            Dim detailDT As New DataTable
            detailDT.Columns.Add(New DataColumn("Flow_id"))
            detailDT.Columns.Add(New DataColumn("Material_id"))
            detailDT.Columns.Add(New DataColumn("Apply_cnt"))
            detailDT.Columns.Add(New DataColumn("Out_cnt"))
            detailDT.Columns.Add(New DataColumn("Out_date"))
            detailDT.Columns.Add(New DataColumn("Memo"))
            detailDT.Columns.Add(New DataColumn("ModUser_id"))
            detailDT.Columns.Add(New DataColumn("Mod_date"))
            detailDT.Columns.Add(New DataColumn("OrgCode"))
            For Each dr As GridViewRow In Me.GridViewA.Rows
                Dim detailDR As DataRow = detailDT.NewRow
                Dim box1 As HiddenField = dr.Cells(2).FindControl("hfMaterial_id")
                Dim box2 As TextBox = dr.Cells(2).FindControl("txtApplyCnt")
                Dim box3 As TextBox = dr.Cells(4).FindControl("txtMemo")
                If Not IsNumeric(box2.Text) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "申請數量必須為數字")
                    Return
                End If
                detailDR("Flow_id") = txtFlowId.Text
                detailDR("Material_id") = box1.Value
                detailDR("Apply_cnt") = box2.Text
                detailDR("Out_cnt") = ""
                detailDR("Out_date") = ""
                detailDR("Memo") = box3.Text
                detailDR("ModUser_id") = LoginManager.UserId
                detailDR("Mod_date") = DateTime.Now
                detailDR("OrgCode") = LoginManager.OrgCode
                detailDT.Rows.Add(detailDR)
            Next
            Dim dao As New MAT1101

            Dim fid As String = Request.QueryString("fid")
            Dim org As String = Request.QueryString("org")
            Dim isUpdate As Boolean = False
            If Not String.IsNullOrEmpty(org) AndAlso Not String.IsNullOrEmpty(fid) Then
                isUpdate = True
            End If

            If isUpdate Then
                Dim msg As String = dao.Update(txtApplyDate.Text, LoginManager.Depart_id, ddlUserId.SelectedValue, LoginManager.Account, LoginManager.OrgCode, fid, detailDT)
                If Not String.IsNullOrEmpty(msg) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                    Return
                End If
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "../../FSC/FSC0/FSC0102_01.aspx?t=q")
            Else
                Dim msg As String = dao.Insert(txtApplyDate.Text, LoginManager.Depart_id, ddlUserId.SelectedValue, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account), LoginManager.OrgCode, detailDT)
                If Not String.IsNullOrEmpty(msg) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                Else
                    'Response.Redirect("~/MAT/MAT1/MAT1101_01.aspx")
                    'CommonFun.MsgConfirm(Page, "", "", )
                    txtFlowId.Text = dao.FlowId()
                    CommonFun.MsgConfirm2(Me.Page, "領務申請案件已完成並送至審查,是否繼續其他領物申請案件?", "__doPostBack('ApplyAgain','Y')", "__doPostBack('ApplyAgain','N')")
                End If
            End If
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "至少要申請一筆物料")
        End If
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs)
        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl").ToString())
        End If
    End Sub
End Class
