Imports FSCPLM.Logic

Partial Class MAT2110_01
    Inherits BaseWebForm

    Dim dao As New MAT2110

    Protected Sub CalBtn_Click(sender As Object, e As System.EventArgs) Handles CalBtn.Click
        Try
            Dim msg As String = dao.Cal(LoginManager.OrgCode, UcROCYearMonth1.ROCYear, UcROCYearMonth1.Month.ToString().PadLeft(2, "0"), False)
            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgConfirm2(Me.Page, msg, "__doPostBack('CalAgain','Y')", "__doPostBack('CalAgain','N')")
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message)
        End Try
    End Sub

    Protected Sub PrnBtnBtn_Click(sender As Object, e As System.EventArgs) Handles PrnBtn.Click
        Dim url As String = String.Format("MAT2110_02.aspx?year={0}&month={1}", UcROCYearMonth1.ROCYear, UcROCYearMonth1.Month.ToString().PadLeft(2, "0"))
        Response.Redirect(url)
        'Dim s As String = "window.open('" & url + "', 'popup_window', ' memubar=no, status=no, scrollbars=yes, top=100, left=200, toolbar=no, width=800, height=600 ');"
        'ClientScript.RegisterStartupScript(Me.GetType(), "script", s, True)
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As System.EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        checkConfirm()
        If Not Page.IsPostBack Then
            Dim imDAO As New InventoryMain()
            Dim msg As String = imDAO.GetMemoMsg(LoginManager.OrgCode)
            If Not String.IsNullOrEmpty(msg) Then
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
                CalBtn.Enabled = False
                PrnBtn.Enabled = False
                ResetBtn.Enabled = False
            End If
        End If
    End Sub

    Public Sub confirm(ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        Me.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub


    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        '按了確定要執行的程式碼
        If target = "CalAgain" Then
            If argument = "Y" Then
                'ViewState.Add("PASS_LIMIT", True)
                'Submit()
                dao.Cal(LoginManager.OrgCode, UcROCYearMonth1.ROCYear, UcROCYearMonth1.Month.ToString().PadLeft(2, "0"), True)
                CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "結算完成")
            End If
        End If
    End Sub
End Class
