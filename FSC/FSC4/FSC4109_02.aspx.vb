Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4109_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        showDLL()
        bind()
    End Sub

    Protected Sub showDLL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable
        Try
            dt = New SYS.Logic.LeaveType().GetLeaveType(Orgcode)
            ddlPDVTYPE.DataTextField = "Leave_name"
            ddlPDVTYPE.DataValueField = "Leave_type"
            ddlPDVTYPE.DataSource = dt
            ddlPDVTYPE.DataBind()
            ddlPDVTYPE.Items.Insert(0, New ListItem("請選擇", ""))

            Dim lk As New SYS.Logic.LeaveKind()

            dt = lk.GetData(Orgcode, "")
            ddlPDKIND.DataTextField = "Kind_name"
            ddlPDKIND.DataValueField = "Leave_kind"
            ddlPDKIND.DataSource = dt
            ddlPDKIND.DataBind()


            '職務類別
            Dim c As New SYS.Logic.CODE
            dt = c.GetData("023", "022")
            ddlPEMEMCOD.DataTextField = "CODE_DESC1"
            ddlPEMEMCOD.DataValueField = "CODE_NO"
            ddlPEMEMCOD.DataSource = dt
            ddlPEMEMCOD.DataBind()
            ddlPEMEMCOD.Items.Insert(0, New ListItem("請選擇", ""))

        Catch ex As Exception
            AppException.ShowError_ByPage(ex)
        End Try
    End Sub

    Protected Sub bind()
        Dim PDKIND As String = Request.QueryString("PDKIND")
        Dim PDMEMCOD As String = Request.QueryString("PDMEMCOD")
        Dim PDVTYPE As String = Request.QueryString("PDVTYPE")
        Dim PDYEARB As String = Request.QueryString("PDYEARB")

        If String.IsNullOrEmpty(PDKIND) Or String.IsNullOrEmpty(PDMEMCOD) Or String.IsNullOrEmpty(PDVTYPE) Or String.IsNullOrEmpty(PDYEARB) Then
            Return
        End If

        ddlPDKIND.SelectedValue = PDKIND
        ddlPDKIND.Enabled = False
        ddlPEMEMCOD.SelectedValue = PDMEMCOD
        ddlPEMEMCOD.Enabled = False
        ddlPDVTYPE.SelectedValue = PDVTYPE
        ddlPDVTYPE.Enabled = False

        Try
            Dim dt As DataTable = New CPAPD04M().GetDataByQuery(PDKIND, PDMEMCOD, PDVTYPE, PDYEARB)

            For Each dr As DataRow In dt.Rows
                hfPDYEARB.value = dr("PDYEARB").ToString()
                tbPDYEARB.Text = dr("PDYEARB").ToString()
                tbPDYEARE.Text = dr("PDYEARE").ToString()
                tbPDDAYS.Text = dr("PDDAYS").ToString()
            Next

        Catch ex As Exception
            AppException.ShowError_ByPage(ex)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Deaprt_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        Dim PDKIND As String = Request.QueryString("PDKIND")
        Dim PDMEMCOD As String = Request.QueryString("PDMEMCOD")
        Dim PDVTYPE As String = Request.QueryString("PDVTYPE")
        Dim PDYEARB As String = Request.QueryString("PDYEARB")

        If tbPDDAYS.Text.Trim().Length > 2 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上限天數不可超過99日!")
            Return
        End If
        If ddlPDVTYPE.SelectedValue = "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇假別!")
            Return
        End If
        If ddlPEMEMCOD.SelectedValue = "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇職務類別!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbPDYEARB.Text.Trim()) AndAlso Not CommonFun.IsNum(tbPDYEARB.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "休假年資(起)請輸入數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbPDYEARE.Text.Trim()) AndAlso Not CommonFun.IsNum(tbPDYEARE.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "休假年資(迄)請輸入數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbPDDAYS.Text.Trim()) AndAlso Not CommonFun.IsNum(tbPDDAYS.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上限天數請輸入數字!")
            Return
        End If

        Dim isAdd As Boolean = False
        If String.IsNullOrEmpty(PDKIND) Or String.IsNullOrEmpty(PDMEMCOD) Or String.IsNullOrEmpty(PDVTYPE) Or String.IsNullOrEmpty(PDYEARB) Then
            isAdd = True
        End If

        Try
            Dim pd04m As New CPAPD04M()
            pd04m.Orgcode = Orgcode
            pd04m.Depart_id = Deaprt_id
            pd04m.PDKIND = ddlPDKIND.SelectedValue()
            pd04m.PDMEMCOD = ddlPEMEMCOD.SelectedValue()
            pd04m.PDVTYPE = ddlPDVTYPE.SelectedValue().PadLeft(2, "0")
            pd04m.PDYEARB = tbPDYEARB.Text.Trim()
            pd04m.PDYEARE = tbPDYEARE.Text.Trim()
            pd04m.PDDAYS = tbPDDAYS.Text.Trim()
            pd04m.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            If isAdd Then
                Dim dt As DataTable = New CPAPD04M().GetDataByQuery(pd04m.PDKIND, pd04m.PDMEMCOD, pd04m.PDVTYPE, "")
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "資料庫內已有此設定!")
                    Return
                End If

                pd04m.insert()
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "FSC4109_01.aspx")
            Else
                pd04m.update(pd04m.PDKIND, pd04m.PDMEMCOD, PDVTYPE, hfPDYEARB.Value)
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "FSC4109_01.aspx")
            End If

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC4109_01.aspx")
    End Sub
End Class
