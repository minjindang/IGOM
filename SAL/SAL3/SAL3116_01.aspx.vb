Imports System.Data
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Transactions
Imports System.IO

Partial Class SAL_SAL3_SAL3116_01
    Inherits System.Web.UI.Page

    Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    Dim bll As New SAL3116()
    Dim dtData As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Page.Form.DefaultButton = Me.btnUpdate.UniqueID

        If Not Page.IsPostBack Then

            Me.Label_orgid.Text = szOrgcode
            Me.Label_orgname.Text = "行政院環境保護署"
            Me.gvData.DataSource = bll.GetData(szOrgcode, "1")
            Me.gvData.DataBind()
        End If
    End Sub

    Protected Sub ddlKind_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlKind.SelectedIndexChanged
        Me.gvData.DataSource = bll.GetData(szOrgcode, Me.ddlKind.SelectedValue)
        Me.gvData.DataBind()

        If Me.gvData.Rows.Count = 0 Then
            Me.btnUpdate.Visible = False
        Else
            Me.btnUpdate.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' 【儲存變更】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            For Each gvr As GridViewRow In Me.gvData.Rows
                Dim szTDPM_ORGID As String = CType(gvr.FindControl("tb_payod_orgid"), TextBox).Text
                Dim szTDPM_KIND As String = CType(gvr.FindControl("tb_payod_kind"), TextBox).Text
                Dim szTDPM_CODE_SYS As String = CType(gvr.FindControl("tb_payod_code_sys"), TextBox).Text
                Dim szTDPM_CODE_KIND As String = CType(gvr.FindControl("tb_payod_code_kind"), TextBox).Text
                Dim szTDPM_CODE_TYPE As String = CType(gvr.FindControl("tb_payod_code_type"), TextBox).Text
                Dim szTDPM_CODE_NO As String = CType(gvr.FindControl("tb_payod_code_no"), TextBox).Text
                Dim szTDPM_CODE As String = CType(gvr.FindControl("tb_payod_code"), TextBox).Text
                Dim szTDPM_TDPF_SEQNO As String = CType(gvr.FindControl("ddlBankName"), DropDownList).SelectedValue
                Dim szTDPM_MUSER As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                Dim szTDPM_MDATE As String = DateTimeInfo.GetRocTodayString("yyyyMMddHHmmss")

                If szTDPM_TDPF_SEQNO <> "" Then
                    bll.InsertOrUpdate(szTDPM_ORGID, szTDPM_KIND, szTDPM_CODE_SYS, szTDPM_CODE_KIND, szTDPM_CODE_TYPE, szTDPM_CODE_NO, szTDPM_CODE, szTDPM_TDPF_SEQNO, szTDPM_MUSER, szTDPM_MDATE)
                End If
            Next

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "儲存完畢!!")
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

    Protected Sub gvData_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvData.RowDataBound
        ' 繫結銀行名稱
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim _ddlBankName As DropDownList = CType(e.Row.FindControl("ddlBankName"), DropDownList)
            Dim _TDPM_TDPF_SEQNO As TextBox = CType(e.Row.FindControl("tbtdpm_tdpf_seqno"), TextBox)
            Dim dt As DataTable
            dt = bll.GetBankData(szOrgcode)
            _ddlBankName.DataValueField = "tdpf_seqno"
            _ddlBankName.DataTextField = "text"
            _ddlBankName.DataSource = dt
            _ddlBankName.DataBind()
            _ddlBankName.Items.Insert(0, New ListItem("請選擇", ""))

            If _TDPM_TDPF_SEQNO.Text <> "" Then ' Initial DDL
                _ddlBankName.SelectedValue = _TDPM_TDPF_SEQNO.Text
            End If
        End If
    End Sub

    Protected Sub ddlBankName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each r As GridViewRow In gvData.Rows
            Dim _ddlBankName As DropDownList = CType(r.FindControl("ddlBankName"), DropDownList)
            Dim _tb_BANK_BANK_NO As TextBox = CType(r.FindControl("tb_BANK_BANK_NO"), TextBox)
            Dim _tb_BANK_MEMO As TextBox = CType(r.FindControl("tb_BANK_MEMO"), TextBox)

            dtData = bll.GetBankNOData(_ddlBankName.SelectedValue)
            If dtData.Rows.Count <> 0 Then
                _tb_BANK_BANK_NO.Text = dtData.Rows(0)("TDPF_BANK_NO").ToString()
                _tb_BANK_MEMO.Text = dtData.Rows(0)("tdpf_memo").ToString()
            Else
                _tb_BANK_BANK_NO.Text = ""
                _tb_BANK_MEMO.Text = ""
            End If
        Next
    End Sub

End Class
