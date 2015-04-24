Imports System.Data
Imports System.Transactions
Imports FSC.Logic
Imports SAL.Logic

Partial Class SAL4108_02
    Inherits BaseWebForm

    Dim dtData As DataTable
    Dim bll As New SAL4108()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        ' 繫結【種類】
        dtData = New FSCPLM.Logic.SACode().GetData("001", "001")
        ddlApply_type.DataTextField = "code_desc1"
        ddlApply_type.DataValueField = "code_no"
        ddlApply_type.DataSource = dtData
        ddlApply_type.DataBind()

        ' 繫結【實施日期】
        dtData = bll.getQueryData("001", "001")
        ddlYM.DataTextField = "ymstr"
        ddlYM.DataValueField = "stan_ym"
        ddlYM.DataSource = dtData
        ddlYM.DataBind()
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("SAL4108_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        '年月
        Dim STAN_YM As String = ddlYM.SelectedValue
        '類別
        Dim STAN_TYPE As String = "001"
        '明細
        Dim STAN_NO As String = ddlApply_type.SelectedValue
        '俸點、薪點
        Dim STAN_SAL_POINT As String = tbStan_Sal_Point.Text
        '金額
        Dim STAN_SAL As String = tbStan_Sal.Text
        '異動人員
        Dim STAN_MUSER As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        '建立時間
        Dim STAN_MDATE As String = DateTime.Now.ToString("yyyyMMddHHmmss")

        Try
            bll.Insert(STAN_YM, STAN_TYPE, STAN_NO, STAN_SAL_POINT, Stan_Sal, STAN_MUSER, STAN_MDATE)
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增成功", "SAL4108_01.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
End Class
