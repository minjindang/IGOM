Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC3119_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Name_Bind()
    End Sub

    Protected Sub Name_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = UcDDLDepart.SelectedValue
        Dim id_card As String = UcDDLMember.SelectedValue
        Dim Apply_date As String = UcDate1.Text
        Dim isReword As String = ddlisReword.SelectedValue
        Dim bll As New FSC3119()
        Dim dt As DataTable = New DataTable

        Try
            dt = bll.getData(orgcode, depart_id, id_card, Apply_date, isReword)

            For Each dr As DataRow In dt.Rows
                If String.IsNullOrEmpty(dr("Council_approve").ToString()) Then
                    dr("Council_approve") = ""
                ElseIf dr("Council_approve").ToString().Equals("1") Then
                    dr("Council_approve") = "通過"
                ElseIf dr("Council_approve").ToString().Equals("2") Then
                    dr("Council_approve") = "不通過"
                End If
            Next

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
            Else
                Ucpager.Visible = False
            End If
            tbq.Visible = True
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

    Protected Sub UcReword_Click(sender As Object, e As EventArgs)
        Dim msg As StringBuilder = New StringBuilder
        Dim isChecked As Boolean = False
        For Each gvr As GridViewRow In gvlist.Rows
            Dim flow_id As String = CType(gvr.FindControl("lbFlow_id"), Label).Text
            Try
                If CType(gvr.FindControl("cbx"), CheckBox).Checked Then
                    isChecked = True
                    Dim rm As FSC.Logic.RewordMain = New FSC.Logic.RewordMain

                    rm.Council_name = UcReword.Council_name
                    rm.Council_date = UcReword.Council_date
                    rm.Council_approve = UcReword.Council_approve
                    rm.Reword_date = UcReword.Reword_date
                    rm.Reword_Doc = UcReword.Reword_Doc
                    rm.flow_id = flow_id

                    rm.updateReword()
                End If
            Catch ex As Exception
                msg.Append("表單編號：" + flow_id + "發佈獎懲令發生錯誤! \n")
            End Try
        Next

        If Not isChecked Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "至少需勾選一筆敘獎申請。")
            Return
        End If

        If Not String.IsNullOrEmpty(msg.ToString()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg.ToString())
            Return
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "發佈成功!")
            Bind()
        End If
    End Sub
End Class
