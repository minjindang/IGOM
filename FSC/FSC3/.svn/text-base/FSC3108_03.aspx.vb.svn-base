Imports FSC.Logic
Imports System.Transactions
Imports System.Data

Partial Class FSC3108_03
    Inherits BaseWebForm

    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Member_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        lbUnSelectMember.DataSource = New FSC.Logic.Personnel().GetDataByOrgDep(Orgcode, UcDDLDepart.SelectedValue())
        lbUnSelectMember.DataBind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Member_Bind()
    End Sub

    Protected Sub toConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toConfirm.Click

        Dim msg As String = ""
        If String.IsNullOrEmpty(Me.UcPHIDATE.Text) Then
            msg += "刷卡日期不可為空白!請重新輸入\n"
        End If
        If String.IsNullOrEmpty(Me.ddlPHITYPE.SelectedValue) Then
            msg += "進出種類不可為空白!請重新輸入\n"
        End If
        If String.IsNullOrEmpty(Me.tbPHITIME.Text) Then
            msg += "刷卡時間不可為空白!請重新輸入\n"
        End If

        If Not String.IsNullOrEmpty(msg) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
            Return
        End If

        Try
            Dim isSelected As Boolean = False
            Dim fsc3108 As New FSC3108DAO()
            Dim ph As New CPAPHYYMM(Left(UcPHIDATE.Text, 5))

            Using trans As New TransactionScope()

                For Each item As ListItem In lbMember.Items
                    isSelected = True
                    Dim PHCARD As String = item.Value

                    Dim dt As DataTable = ph.GetData(PHCARD, UcPHIDATE.Text, ddlPHITYPE.SelectedValue)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        fsc3108.update(PHCARD, UcPHIDATE.Text, ddlPHITYPE.SelectedValue, tbPHITIME.Text, UcPHIDATE.Text, ddlPHITYPE.SelectedValue, "")
                    Else
                        ph.InsertCPAPHYYMM("L1", PHCARD, UcPHIDATE.Text, tbPHITIME.Text, ddlPHITYPE.SelectedValue, "")
                    End If
                Next

                trans.Complete()
            End Using

            If isSelected Then
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "FSC3108_03.aspx")
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請至少選擇一位人員!")
            End If
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbToR_Click(sender As Object, e As System.EventArgs) Handles cbToR.Click
        Dim list As New System.Collections.Generic.List(Of ListItem)
        For Each item As ListItem In lbUnSelectMember.Items
            If item.Selected Then
                If lbMember.Items.Count <= 0 Then
                    list.Add(item)
                Else
                    Dim had As Boolean = False
                    For Each sitem As ListItem In lbMember.Items
                        If item.Value = sitem.Value Then
                            had = True
                        End If
                    Next
                    If Not had Then
                        list.Add(item)
                    End If
                End If
            End If
        Next
        For Each item As ListItem In list
            lbMember.Items.Add(item)
        Next
        lbUnSelectMember.SelectedIndex = -1
        lbMember.SelectedIndex = -1
    End Sub

    Protected Sub cbToL_Click(sender As Object, e As System.EventArgs) Handles cbToL.Click
        Dim list As New System.Collections.Generic.List(Of ListItem)
        For Each item As ListItem In lbMember.Items
            If item.Selected Then
                list.Add(item)
            End If
        Next
        For Each item As ListItem In list
            lbMember.Items.Remove(item)
        Next
        lbUnSelectMember.SelectedIndex = -1
        lbMember.SelectedIndex = -1
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack Then Return

        Dep_Bind()
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC3108_01.aspx")
    End Sub
End Class
