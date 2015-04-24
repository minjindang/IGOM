Imports System.Data
Imports SALARY.Logic
Imports System.Transactions

Partial Class SAL3130_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        Bind()
    End Sub

    Protected Sub initData(Optional ByVal isAdd As Boolean = False)
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Send_orgcode")
        dt.Columns.Add("Send_departid")
        dt.Columns.Add("Send_idcard")

        If isAdd Then
            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
        End If

        ViewState("dt") = dt
    End Sub

    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim bll As New SAL3130()
        Dim dt As DataTable = New DataTable
        Try
            dt = bll.getQueryData(Orgcode)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                initData(True)
                dt = CType(ViewState("dt"), DataTable)
            End If

            tbq.Visible = True
            ViewState("dt") = dt
            gv_Bind()
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub

    Protected Sub gv_Bind()
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()

        'If gvlist.Rows.Count > 0 Then
        '    Ucpager1.Visible = True
        'Else
        '    Ucpager1.Visible = False
        'End If
    End Sub

    Protected Sub GridView_Grad_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        gv_Bind()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Try
            Dim bll As New PaySalChgNoticSendList

            Using trans As New TransactionScope
                bll.delete()

                GvToDt()
                Dim dt As DataTable = CType(ViewState("dt"), DataTable)
                For Each dr As DataRow In dt.Rows
                    If String.IsNullOrEmpty(dr("Send_departid")) OrElse String.IsNullOrEmpty(dr("Send_idcard")) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "尚有未選擇的發送人員!")
                        Return
                    End If

                    bll = New PaySalChgNoticSendList
                    bll.Send_orgcode = dr("Send_orgcode")
                    bll.Send_departid = dr("Send_departid")
                    bll.Send_idcard = dr("Send_idcard")
                    bll.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                    bll.insert()
                Next

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功!")
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles cbBack.Click
        Response.Redirect("SAL3130_01.aspx")
    End Sub

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs)
        GvToDt()

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
            Dim index As Integer = gvr.RowIndex
            Dim dr As DataRow = dt.NewRow
            dt.Rows.InsertAt(dr, index + 1)
        Else
            initData(True)
            dt = CType(ViewState("dt"), DataTable)
        End If

        ViewState("dt") = dt
        gv_Bind()

    End Sub

    Protected Sub btnDel_Click(sender As Object, e As EventArgs)
        GvToDt()

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Rows.Count = 1 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "必須至少設定一位人員!")
                Return
            End If
            Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
            Dim index As Integer = gvr.RowIndex
            dt.Rows.RemoveAt(index)
        Else
            initData(True)
            dt = CType(ViewState("dt"), DataTable)
        End If

        ViewState("dt") = dt
        gv_Bind()
    End Sub


    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, DropDownList).NamingContainer, UControl_UcDDLDepart).NamingContainer
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("UcDDLDepart"), UControl_UcDDLDepart)
        Dim UcDDLMember As UControl_UcDDLMember = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMember)

        UcDDLMember.Orgcode = Orgcode
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        For Each gvr As GridViewRow In gvlist.Rows
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("UcDDLDepart"), UControl_UcDDLDepart)
            Dim lbSend_departid As Label = CType(gvr.FindControl("lbSend_departid"), Label)
            Dim UcDDLMember As UControl_UcDDLMember = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMember)
            Dim lbSend_idcard As Label = CType(gvr.FindControl("lbSend_idcard"), Label)

            UcDDLDepart.Orgcode = Orgcode
            If Not String.IsNullOrEmpty(lbSend_departid.Text) Then
                UcDDLDepart.SelectedValue = lbSend_departid.Text
            End If

            UcDDLMember.Orgcode = Orgcode
            UcDDLMember.DepartId = UcDDLDepart.SelectedValue
            If Not String.IsNullOrEmpty(lbSend_idcard.Text) Then
                UcDDLMember.SelectedValue = lbSend_idcard.Text
            End If
        Next
    End Sub

    Protected Sub GvToDt()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        initData()
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        For Each gvr As GridViewRow In gvlist.Rows
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("UcDDLDepart"), UControl_UcDDLDepart)
            Dim UcDDLMember As UControl_UcDDLMember = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMember)

            Dim dr As DataRow = dt.NewRow
            dr("Send_orgcode") = Orgcode
            dr("Send_departid") = UcDDLDepart.SelectedValue
            dr("Send_idcard") = UcDDLMember.SelectedValue
            dt.Rows.Add(dr)
        Next

        ViewState("dt") = dt
    End Sub
End Class
