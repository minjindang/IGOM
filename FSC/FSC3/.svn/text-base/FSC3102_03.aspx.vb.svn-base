Imports FSC.Logic
Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Transactions

Partial Class FSC3102_03
    Inherits BaseWebForm

    Dim bll As New FSC.Logic.FSC3102()
    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
    Dim Change_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
    Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)


#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then '第一次瀏覽網頁
            Dep_Bind()
            Name_Bind()

            Deputy_Dep_Bind()
            Deputy_Name_Bind()
        End If
    End Sub
#End Region

#Region "顯示下拉選單"
    Protected Sub Dep_Bind()
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Name_Bind()
        ddlName.Orgcode = LoginManager.OrgCode
        ddlName.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

    Protected Sub Deputy_Dep_Bind()
        UcDDLDeputy_Depart.Orgcode = Orgcode
        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") < 0 Then
            UcDDLDeputy_Depart.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
            If psn.MutiDepartDeputy_flag <> "1" Then
                UcDDLDeputy_Depart.Enabled = False
            End If
        End If
    End Sub

    Protected Sub Deputy_Name_Bind()
        ddlDeputy_Name.Items.Clear()
        If Not String.IsNullOrEmpty(LoginManager.OrgCode) AndAlso Not String.IsNullOrEmpty(UcDDLDeputy_Depart.SelectedValue) Then
            ddlDeputy_Name.DataSource = New Personnel().GetDataByOrgDepWithOutNonMember(LoginManager.OrgCode, UcDDLDeputy_Depart.SelectedValue)
            ddlDeputy_Name.DataBind()
        End If
        ddlDeputy_Name.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDeputy_Depart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDeputy_Depart.SelectedIndexChanged
        Deputy_Name_Bind()
    End Sub

#End Region

#Region " Button"

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        If String.IsNullOrEmpty(ddlName.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選人員!")
            Return
        End If

        If String.IsNullOrEmpty(ddlDeputy_Name.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇職務代理人!")
            Return
        End If


        Dim Id_card As String = ddlName.SelectedValue
        Dim Title_no As String = bll.Get_Title_no(Id_card)

        Dim deputy_idcard As String = ddlDeputy_Name.SelectedValue
        Dim deputy_orgcode As String = bll.Get_Orgcode(deputy_idcard)
        Dim deputy_titleno As String = bll.Get_Title_no(deputy_idcard)

        Dim dd As New DeputyDet
        Dim isDouble As Boolean = False

        isDouble = dd.ChkDefalutDeputy(Id_card, deputy_idcard)

        If isDouble Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "該職務代理人已存在，請重新設定!")
            Return
        End If

        Dim Deputy_flag As String
        If cbxDeputy_flag.Checked Then
            Deputy_flag = "1"
        Else
            Deputy_flag = "0"
        End If
        Dim Deputy_seq As Integer

        'Try
        '    Deputy_seq = Integer.Parse(Me.txtDeputSeq.Text)
        'Catch ex As Exception
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "【順序】請輸入數字")
        '    Return
        'End Try

        ' 順序如已存在，則繼續往下編號
        Dim dtTable As DataTable = New DataTable
        If lbtDeputSeq.Text = "1" Then
            dtTable = bll.GetDataExist(Orgcode, Id_card, lbtDeputSeq.Text.ToString())
        End If
        'Dim szMsg As String = "您輸入的【順序】：" + Deputy_seq.ToString() + "，資料已存在。已重新設定【順序】："

        'If dtTable.Rows.Count > 0 Then
        '    dtTable = bll.GetMaxDeputySeq(Orgcode, Id_card)

        '    For Each dr As DataRow In dtTable.Rows
        '        Deputy_seq = dr("MAXSEQ").ToString()
        '    Next

        '    szMsg &= Deputy_seq.ToString()
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, szMsg)
        'End If

        Try

            Using trans As New TransactionScope
                If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                    Dim ddt As DataTable = bll.GetMaxDeputySeq(Orgcode, Id_card)

                    For Each dr As DataRow In ddt.Rows
                        Deputy_seq = dr("MAXSEQ").ToString()
                    Next

                    bll.updateDefaultToMax(dtTable.Rows(0)("id"), Deputy_seq)
                End If

                '新增
                If Not dd.InsertDeputyDet(Orgcode, UcDDLDepart.SelectedValue, Id_card, deputy_orgcode, UcDDLDeputy_Depart.SelectedValue, deputy_titleno, deputy_idcard, Change_id, Deputy_flag, IIf(cbxDeputy_flag.Checked, 1, 2)) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定失敗")
                    Return
                End If

                '重新編號
                Dim dt As DataTable = dd.getNotDefaultData(Orgcode, Id_card)
                For i As Integer = 0 To dt.Rows.Count - 1
                    dd.UpdateSeq(dt.Rows(i)("id").ToString(), i + 2)
                Next

                trans.Complete()
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "FSC3102_01.aspx")
            End Using

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

    Protected Sub cbxDeputy_flag_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeputy_flag.CheckedChanged
        'Dim dtTable As DataTable = bll.GetMaxDeputySeq(Orgcode, Id_card)
        'If dtTable.Rows.Count > 0 Then
        '    For Each dr As DataRow In dtTable.Rows
        '        txtDeputSeq.Text = dr("MAXSEQ").ToString()
        '    Next
        'End If

        'If cbxDeputy_flag.Checked = True Then
        '    If txtDeputSeq.Text = "2" Then
        '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "您已設定預設代理人。")

        '        cbxDeputy_flag.Checked = False
        '        txtDeputSeq.Enabled = True
        '    Else
        '        txtDeputSeq.Text = "1"
        '        txtDeputSeq.Enabled = False
        '    End If
        'Else
        '    txtDeputSeq.Enabled = True
        'End If

        If cbxDeputy_flag.Checked = True Then
            lbtDeputSeq.Text = "1"
        Else
            lbtDeputSeq.Text = ""
        End If
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect("FSC3102_01.aspx")
    End Sub

    'Protected Sub txtDeputSeq_TextChanged(sender As Object, e As EventArgs)
    '    If txtDeputSeq.Text.Trim = "1" Then
    '        cbxDeputy_flag.Checked = True
    '    Else
    '        cbxDeputy_flag.Checked = False
    '    End If
    'End Sub
End Class
