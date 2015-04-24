Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class FSC3120_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
        Bind()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Title_Bind()

        If Not LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") >= 0 Then
            UcDDLDepart.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            UcDDLDepart.Enabled = False
        End If

        UcDDLDeputyDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Name_Bind()
    End Sub

    Protected Sub Title_Bind()
        Dim dt As DataTable = New FSC3120().getTitle()
        dt.Columns.Add("cos")
        For Each dr As DataRow In dt.Rows
            dr("cos") = dr("CODE_NO").ToString + "," + dr("CODE_DESC2").ToString
        Next
        ddlBossTitle.DataValueField = "cos"
        ddlBossTitle.DataTextField = "CODE_DESC1"
        ddlBossTitle.DataSource = dt
        ddlBossTitle.DataBind()
        ddlBossTitle.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Name_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDeputyDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDeputyDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDeputyDepart.SelectedIndexChanged
        Name_Bind()
    End Sub
#End Region

    Protected Sub Bind()
        Dim id As String = Request.QueryString("id")

        If Not String.IsNullOrEmpty(id) Then
            Dim dv As New DeputyVacancy
            Dim dt As DataTable = dv.getDataByid(id)
            For Each dr As DataRow In dt.Rows
                UcDDLDepart.SelectedValue = dr("Depart_id").ToString
                UcDDLDepart.Enabled = False
                ddlBossTitle.SelectedValue = dr("Title_no").ToString + "," + dr("Boss_level_id").ToString
                ddlBossTitle.Enabled = False
                UcDDLDeputyDepart.SelectedValue = dr("Deputy_Depart_id").ToString
                Name_Bind()
                UcDDLMember.SelectedValue = dr("Deputy_id_card").ToString
                hfid.Value = dr("id").ToString
            Next
        End If
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("FSC3120_01.aspx")
    End Sub

    Protected Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim id As String = Request.QueryString("id")

        If String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇缺額單位!")
            Return
        End If
        If UcDDLDepart.SelectedValue.Length = 2 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "缺額單位請選擇至科室!")
            Return
        End If
        If String.IsNullOrEmpty(ddlBossTitle.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇缺額職稱!")
            Return
        End If
        If String.IsNullOrEmpty(UcDDLDeputyDepart.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇代理單位!")
            Return
        End If
        If String.IsNullOrEmpty(UcDDLMember.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇代理人!")
            Return
        End If

        Try
            Dim dv As New DeputyVacancy
            dv.Orgcode = Orgcode
            dv.Depart_id = UcDDLDepart.SelectedValue
            dv.Title_no = ddlBossTitle.SelectedValue.Split(",")(0)
            dv.Boss_level_id = ddlBossTitle.SelectedValue.Split(",")(1)
            dv.Deputy_Orgcode = Orgcode
            dv.Deputy_Depart_id = New DepartEmp().GetDepartId(UcDDLMember.SelectedValue)
            dv.Deputy_id_card = UcDDLMember.SelectedValue
            dv.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

            If String.IsNullOrEmpty(id) Then
                dv.insert()

                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "FSC3120_01.aspx")
            Else
                dv.id = id
                dv.update()

                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "FSC3120_01.aspx")
            End If

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
