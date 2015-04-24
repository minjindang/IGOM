Imports System.Data
Imports MAT.Logic
Imports System.Transactions
Imports System.IO
Partial Class MAT2_MAT2109_01
    Inherits BaseWebForm
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id))
        'Dim md As MAT2109 = New MAT2109()
        'Dim db As DataTable = New DataTable
        'db = md.MAT2109Select("", "", "", "")
        'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, db.Rows.Count)
    End Sub
#End Region
#Region " 重置"
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub
#End Region
#Region "列印"
    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim pagerowcnt As Integer = 25
        If Not CommonFun.IsNum(Approved_idS.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        If Not CommonFun.IsNum(Approved_idE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "物料編號只能輸入數字")
            Return
        End If
        Dim url As String = "MAT2109_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode(DirectCast(Ucpager1.FindControl("tbRowOfPage"), TextBox).Text)
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ReceiveDayS.Text)) Then
            url &= "&ReceiveDayS=" & Server.HtmlEncode(ReceiveDayS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(ReceiveDayE.Text)) Then
            url &= "&ReceiveDayE=" & Server.HtmlEncode(ReceiveDayE.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Approved_idS.Text)) Then
            url &= "&Approved_idS=" & Server.HtmlEncode(Approved_idS.Text)
        End If
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Approved_idE.Text)) Then
            url &= "&Approved_idE=" & Server.HtmlEncode(Approved_idE.Text)
        End If
        '觸發列印按鈕
        'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>")
        Response.Redirect(url)
    End Sub
#End Region
End Class


