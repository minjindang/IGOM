Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports SAL.Logic

Partial Class SAL4108_03
    Inherits BaseWebForm

    Dim bll As New SAL4108()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        bind()
    End Sub

    Protected Sub bind()
        Dim STAN_YM As String = Request.QueryString("STAN_YM")
        Dim STAN_TYPE As String = Request.QueryString("STAN_TYPE")
        Dim STAN_NO As String = Request.QueryString("STAN_NO")
        Dim Stan_Sal_Point As String = Request.QueryString("Stan_Sal_Point")

        'If String.IsNullOrEmpty(STAN_ID) Then
        'Return
        'End If

        Dim dt As DataTable = bll.getQueryData(STAN_YM, STAN_TYPE, STAN_NO, Stan_Sal_Point)
        For Each dr As DataRow In dt.Rows
            tbcode_no.Text = dr("CODE_DESC1").ToString()
            tbymstr.Text = dr("ymstr").ToString()
            tbStan_Sal_Point.Text = dr("Stan_Sal_Point").ToString()
            tbStan_Sal.Text = CInt(dr("Stan_Sal").ToString())
        Next

    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("SAL4108_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim STAN_YM As String = Request.QueryString("STAN_YM")
        Dim STAN_TYPE As String = Request.QueryString("STAN_TYPE")
        Dim STAN_NO As String = Request.QueryString("STAN_NO")
        Dim Stan_Sal_Point As String = Request.QueryString("Stan_Sal_Point")

        Dim Stan_Sal As String = tbStan_Sal.Text
        Dim STAN_MUSER As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim STAN_MDATE As String = DateTime.Now.ToString("yyyyMMddHHmmss")
        Try
            bll.Update(STAN_YM, STAN_TYPE, STAN_NO, Stan_Sal_Point, Stan_Sal, STAN_MUSER, STAN_MDATE)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改成功", "SAL4108_01.aspx")

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
