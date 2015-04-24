Imports FSC.Logic
Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Transactions

Partial Class FSC3102_04
    Inherits BaseWebForm

    Dim bll As New FSC.Logic.FSC3102()
    Dim Change_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
    Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)


#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then '第一次瀏覽網頁
            Dep_Bind()

            Bind()
        End If
    End Sub

    Protected Sub Bind()
        Dim dt As DataTable = New DeputyDet().GetDeputyDetBySerial_nos(p_id)

        Dim FSC3102 As New FSC3102

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            UcDDLDepart.SelectedValue = FSC3102.Get_Depart_id(dt.Rows(0)("Deputy_idcard").ToString)
            Name_Bind()

            ddlName.SelectedValue = dt.Rows(0)("Deputy_idcard").ToString

            If dt.Rows(0)("Deputy_flag").ToString.Trim = "1" Then
                Me.cbxDeputy_flag.Checked = True
            Else
                Me.cbxDeputy_flag.Checked = False
            End If

            'Me.txtDeputSeq.Text = dt.Rows(0)("Deputy_seq").ToString
        End If

    End Sub
#End Region

#Region "顯示下拉選單"
    Protected Sub Dep_Bind()
        UcDDLDepart.Orgcode = Orgcode

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Personnel") < 0 Then
            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(Id_card)
            If psn.MutiDepartDeputy_flag <> "1" Then
                UcDDLDepart.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                UcDDLDepart.Enabled = False
            End If
        End If
    End Sub

    Protected Sub Name_Bind()
        ddlName.Items.Clear()
        If Not String.IsNullOrEmpty(Orgcode) AndAlso Not String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
            ddlName.DataSource = New Personnel().GetDataByOrgDepWithOutNonMember(Orgcode, UcDDLDepart.SelectedValue)
            ddlName.DataBind()
        End If
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub
#End Region

#Region " Button"

    Protected Sub btnModify_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Dim Id_card As String = p_idcard
        Dim orgcode As String = bll.Get_Orgcode(p_idcard)
        Dim depart_id As String = bll.Get_Depart_id(p_idcard)
        Dim Title_no As String = bll.Get_Title_no(p_idcard)
        Dim deputy_orgcode As String = bll.Get_Orgcode(ddlName.SelectedValue)
        Dim deputy_title As String = bll.Get_Title_no(ddlName.SelectedValue)

        If String.IsNullOrEmpty(ddlName.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇職務代理人!")
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
        If lbDeputSeq.Text = "1" Then
            dtTable = bll.GetDataExist(orgcode, Id_card, lbDeputSeq.Text.ToString())
        End If
        'Dim szMsg As String = "您輸入的【順序】：" + Deputy_seq.ToString() + "，資料已存在。已重新設定【順序】："

        'If dtTable.Rows.Count > 0 Then
        '    dtTable = bll.GetMaxDeputySeq(orgcode, Id_card)

        '    For Each dr As DataRow In dtTable.Rows
        '        Deputy_seq = dr("MAXSEQ").ToString()
        '    Next

        '    szMsg &= Deputy_seq.ToString()
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, szMsg)
        'End If

        Try

            Using trans As New TransactionScope
                If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                    Dim ddt As DataTable = bll.GetMaxDeputySeq(orgcode, Id_card)

                    For Each dr As DataRow In ddt.Rows
                        Deputy_seq = dr("MAXSEQ").ToString()
                    Next

                    bll.updateDefaultToMax(dtTable.Rows(0)("id"), Deputy_seq)
                End If

                Dim dd As New DeputyDet
                '更新
                If Not dd.UpdateDeputyDet(orgcode, depart_id, Id_card, deputy_orgcode, UcDDLDepart.SelectedValue, deputy_title, ddlName.SelectedValue, Change_id, p_id, Deputy_flag, IIf(cbxDeputy_flag.Checked, 1, 2)) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定失敗")
                    Return
                End If

                '重新編號
                Dim dt As DataTable = dd.getNotDefaultData(orgcode, Id_card)
                For i As Integer = 0 To dt.Rows.Count - 1
                    dd.UpdateSeq(dt.Rows(i)("id").ToString(), i + 2)
                Next

                trans.Complete()
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "FSC3102_02.aspx?org=" & p_orgcode & "&idno=" & p_idcard)
            End Using

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
#End Region

#Region " Property "

    Protected ReadOnly Property p_orgcode() As String
        Get
            Dim rv As String = ""

            If Not String.IsNullOrEmpty(Request.QueryString("org")) Then
                rv = Request.QueryString("org")
            End If

            Return rv
        End Get
    End Property

    Protected ReadOnly Property p_idcard() As String
        Get
            Dim rv As String = ""

            If Not String.IsNullOrEmpty(Request.QueryString("idno")) Then
                rv = Request.QueryString("idno")
            End If

            Return rv
        End Get
    End Property

    Protected ReadOnly Property p_id() As String
        Get
            Dim rv As String = ""

            If Not String.IsNullOrEmpty(Request.QueryString("id")) Then
                rv = Request.QueryString("id")
            End If

            Return rv
        End Get
    End Property


#End Region

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC3102_02.aspx?org=" & p_orgcode & "&idno=" & p_idcard)
    End Sub

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
            lbDeputSeq.Text = "1"
        Else
            lbDeputSeq.Text = ""
        End If
    End Sub

    'Protected Sub txtDeputSeq_TextChanged(sender As Object, e As EventArgs)
    '    If txtDeputSeq.Text.Trim = "1" Then
    '        cbxDeputy_flag.Checked = True
    '    Else
    '        cbxDeputy_flag.Checked = False
    '    End If
    'End Sub
End Class
