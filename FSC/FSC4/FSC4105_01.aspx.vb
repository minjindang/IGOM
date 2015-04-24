Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4105_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        ShowDepartName()
        ShowName()
    End Sub

#Region "顯示下拉選單"
    Public Sub ShowDepartName()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Public Sub ShowName()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlName.Orgcode = Orgcode
        ddlName.Depart_id = UcDDLDepart.SelectedValue
    End Sub

#End Region

#Region "查詢"
    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        If String.IsNullOrEmpty(tbUserName.Text) And String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇單位")
            Return
        End If
        Bind()
    End Sub
#End Region

#Region "建立列表"
    Public Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable

        Try
            Dim bll As FSC4105 = New FSC4105()
            dt = bll.getQueryData(Orgcode, UcDDLDepart.SelectedValue, ddlName.SelectedValue, ddlactive.SelectedValue, tbUserName.Text)

            Ucpager1.Visible = IIf(dt.Rows.Count > 0, True, False)

            tb.Visible = True
            Me.gvList.DataSource = dt
            Me.gvList.DataBind()

        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
        End Try

    End Sub
#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        Bind()
    End Sub
#End Region

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        ShowName()
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim thisTime As String = DateTimeInfo.GetRocTodayString("yyyyMMdd") & Now.Hour.ToString.PadLeft(2, "0") & Now.Minute.ToString.PadLeft(2, "0")
            Dim Deputy_date As UControl_UcLeaveDate = CType(e.Row.FindControl("UcLeaveDate"), UControl_UcLeaveDate)

            If CType(e.Row.FindControl("lbactive"), Label).Text = "Y" Then
                CType(e.Row.FindControl("cbactive"), Button).Enabled = False
                CType(e.Row.FindControl("cbinactive"), Button).Enabled = True
                CType(e.Row.FindControl("UcDeputyDialog"), UControl_DeputyDialog).Text = CType(e.Row.FindControl("ibDeputyName"), Label).Text

                If Not thisTime >= Deputy_date.Start_date & Deputy_date.Start_time OrElse Not thisTime <= Deputy_date.End_date & Deputy_date.End_time Then
                    Dim id_card As String = CType(e.Row.FindControl("lbID_card"), Label).Text
                    Dim bll As FSC4105 = New FSC4105
                    bll.updateDeputyactive(id_card, "N", "", "", "", "", "")

                    Dim lbactive As Label = CType(e.Row.FindControl("lbactive"), Label)
                    lbactive.Text = "N"
                End If
            End If

            If CType(e.Row.FindControl("lbactive"), Label).Text <> "Y" Then
                CType(e.Row.FindControl("cbactive"), Button).Enabled = True
                CType(e.Row.FindControl("cbinactive"), Button).Enabled = False

                Deputy_date.Start_date = DateTimeInfo.GetRocTodayString("yyyyMMdd")
                Deputy_date.Start_time = "0830"
                Deputy_date.End_date = DateTimeInfo.GetRocTodayString("yyyyMMdd")
                Deputy_date.End_time = "2400"

                Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                Dim id_card As String = CType(e.Row.FindControl("lbID_card"), Label).Text
                Dim UcDeputyDialog As UControl_DeputyDialog = CType(e.Row.FindControl("UcDeputyDialog"), UControl_DeputyDialog)
                Dim DAO As New FSC3102()
                Dim dt As DataTable = DAO.Get_Deputy(Orgcode, id_card)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Dim drs As DataRow() = dt.Select(" Deputy_flag = '1' ")
                    For Each dr As DataRow In drs
                        UcDeputyDialog.Text = dr("User_name").ToString() + "(" + New Org().GetDepartName(Orgcode, New DepartEmp().GetDepartId(dr("Id_card").ToString())) + ")"
                        UcDeputyDialog.Value = "3," & dr("Deputy_IDCard").ToString()
                    Next
                End If
            End If
        End If
    End Sub

    Protected Sub cbactive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
            Dim id_card As String = CType(gvr.FindControl("lbID_card"), Label).Text
            Dim Deputy_date As UControl_UcLeaveDate = CType(gvr.FindControl("UcLeaveDate"), UControl_UcLeaveDate)

            If String.IsNullOrEmpty(CType(gvr.FindControl("UcDeputyDialog"), UControl_DeputyDialog).Value) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇個人秘書!")
                Return
            End If

            Dim deputy_active_idcard As String = CType(gvr.FindControl("UcDeputyDialog"), UControl_DeputyDialog).Value.Split(",")(1)

            If String.IsNullOrEmpty(deputy_active_idcard) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇個人秘書!")
                Return
            End If
            If String.IsNullOrEmpty(Deputy_date.Start_date) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制代理日期(起)不可空白!")
                Return
            End If
            If String.IsNullOrEmpty(Deputy_date.Start_time) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制代理時間(起)不可空白!")
                Return
            End If
            If String.IsNullOrEmpty(Deputy_date.End_date) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制代理日期(迄)不可空白!")
                Return
            End If
            If String.IsNullOrEmpty(Deputy_date.End_time) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制代理時間(迄)不可空白!")
                Return
            End If
            If Deputy_date.Start_date & Deputy_date.Start_time > Deputy_date.End_date & Deputy_date.End_time Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制代理日期(起)不可大於強制代理日期(迄)!")
                Return
            End If


            Dim bll As FSC4105 = New FSC4105
            If Not bll.updateDeputyactive(id_card, "Y", deputy_active_idcard, Deputy_date.Start_date, Deputy_date.Start_time, Deputy_date.End_date, Deputy_date.End_time) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定失敗!")
                Return
            End If

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功!")
            Bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbinactive_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
            Dim id_card As String = CType(gvr.FindControl("lbID_card"), Label).Text
            Dim Deputy_date As UControl_UcLeaveDate = CType(gvr.FindControl("UcLeaveDate"), UControl_UcLeaveDate)

            Dim bll As FSC4105 = New FSC4105
            If Not bll.updateDeputyactive(id_card, "N", "", "", "", "", "") Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "刪除失敗!")
                Return
            End If

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "刪除成功!")
            Bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

End Class
