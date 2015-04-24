Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4107_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        showDLL()

        tbSetting.Visible = False
    End Sub

    Public Sub showDLL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable
        Try
            Dim lk As New SYS.Logic.LeaveKind()

            dt = lk.GetData(Orgcode, Depart_id)
            ddlPDKIND.DataTextField = "Kind_name"
            ddlPDKIND.DataValueField = "Leave_kind"
            ddlPDKIND.DataSource = dt
            ddlPDKIND.DataBind()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim ltdt As DataTable
        Dim regdt As DataTable
        Dim wtdt As DataTable

        Dim pc03m As New CPAPC03M()

        ltdt = pc03m.GetData(Orgcode, "", ddlPDKIND.SelectedValue(), "limit")
        regdt = pc03m.GetData(Orgcode, "", ddlPDKIND.SelectedValue(), "regulation")
        wtdt = pc03m.GetData(Orgcode, "", ddlPDKIND.SelectedValue(), "worktime")

        ltgv.DataSource = ltdt
        ltgv.DataBind()

        reggv.DataSource = regdt
        reggv.DataBind()

        wtgv.DataSource = wtdt
        wtgv.DataBind()

        tbSetting.Visible = True

    End Sub


    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Try
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            Dim pc03m As New CPAPC03M()

            For Each dr As GridViewRow In ltgv.Rows
                pc03m.Orgcode = Orgcode
                pc03m.DepartId = Depart_id
                pc03m.PCKIND = CType(dr.FindControl("lbPCKIND"), Label).Text.Trim()
                pc03m.PCITEM = CType(dr.FindControl("lbPCITEM"), Label).Text.Trim()
                pc03m.PCCODE = CType(dr.FindControl("lbPCCODE"), Label).Text.Trim()

                Dim PCPARM1 As String = CType(dr.FindControl("tbPCPARM1"), TextBox).Text.Trim()
                If Not String.IsNullOrEmpty(PCPARM1) Then
                    For Each s As String In PCPARM1.Split(".")
                        If Not CommonFun.IsNum(s) Then
                            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上限設定「值」請輸入數字")
                            Return
                        End If
                    Next
                End If

                pc03m.PCPARM1 = CType(dr.FindControl("tbPCPARM1"), TextBox).Text.Trim()
                pc03m.PCPARM2 = ""
                pc03m.updateData()
            Next

            For Each dr As GridViewRow In reggv.Rows
                pc03m.Orgcode = Orgcode
                pc03m.DepartId = Depart_id
                pc03m.PCKIND = CType(dr.FindControl("lbPCKIND"), Label).Text.Trim()
                pc03m.PCITEM = CType(dr.FindControl("lbPCITEM"), Label).Text.Trim()
                pc03m.PCCODE = CType(dr.FindControl("lbPCCODE"), Label).Text.Trim()
                pc03m.PCPARM1 = CType(dr.FindControl("tbPCPARM1"), TextBox).Text.Trim()

                Dim PCPARM1 As String = CType(dr.FindControl("tbPCPARM1"), TextBox).Text.Trim()
                If PCPARM1 <> "1" AndAlso PCPARM1 <> "2" Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "刷卡設定「值」請輸入1或2 !")
                    Return
                End If

                pc03m.PCPARM2 = ""
                pc03m.updateData()
            Next

            For Each dr As GridViewRow In wtgv.Rows
                pc03m.Orgcode = Orgcode
                pc03m.DepartId = Depart_id
                pc03m.PCKIND = CType(dr.FindControl("lbPCKIND"), Label).Text.Trim()
                pc03m.PCITEM = CType(dr.FindControl("lbPCITEM"), Label).Text.Trim()
                pc03m.PCCODE = CType(dr.FindControl("lbPCCODE"), Label).Text.Trim()

                Dim PCPARM1 As String = CType(dr.FindControl("tbPCPARM1"), TextBox).Text.Trim()
                If Not String.IsNullOrEmpty(PCPARM1) Then
                    'For Each s As String In PCPARM1.Split(".")
                    '    If Not CommonFun.IsNum(s) Then
                    '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "班別設定「起」請輸入數字")
                    '        Return
                    '    End If
                    'Next
                    If Not CommonFun.IsNum(PCPARM1) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "班別設定「起」請輸入數字")
                        Return
                    End If
                End If

                Dim PCPARM2 As String = CType(dr.FindControl("tbPCPARM2"), TextBox).Text.Trim()
                If Not String.IsNullOrEmpty(PCPARM2) Then
                    'For Each s As String In PCPARM2.Split(".")
                    '    If Not CommonFun.IsNum(s) Then
                    '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "班別設定「迄」請輸入數字")
                    '        Return
                    '    End If
                    'Next
                    If Not CommonFun.IsNum(PCPARM2) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "班別設定「迄」請輸入數字")
                        Return
                    End If
                End If

                pc03m.PCPARM1 = CType(dr.FindControl("tbPCPARM1"), TextBox).Text.Trim()
                pc03m.PCPARM2 = CType(dr.FindControl("tbPCPARM2"), TextBox).Text.Trim()
                pc03m.updateData()
            Next

            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateFail)
        End Try
    End Sub
End Class
