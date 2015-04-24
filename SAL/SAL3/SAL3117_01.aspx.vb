Imports SALARY.Logic
Imports System.Data

Partial Class SAL3117_01
    Inherits BaseWebForm
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Page.Form.DefaultButton = Me.btnUpdate.UniqueID

        ' 第一次進頁
        If Not Page.IsPostBack Then
            For i As Integer = 103 To Now.Year - 1911
                DropDownList_year.Items.Add(i.ToString())
            Next
            DropDownList_month.SelectedIndex = Format(Now(), "MM") - 1 ' 設定現在月份
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim ym As String = (Val(DropDownList_year.SelectedValue) + 1911).ToString() & DropDownList_month.SelectedValue
        Dim yy As String = (Val(DropDownList_year.SelectedValue) + 1911).ToString()
        Dim code_no As String = Me.UcSaCode1.Code_no
        Dim userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim sal2104 As New SAL2104()
        Try
            Dim dt As DataTable = sal2104.GetDataByQuery(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), ym, code_no)

            If (dt.Rows.Count = 0) Then
                Dim sal3117 As New SAL3117()
                sal3117.SQLs1(Now.ToString("yyyyMMddHHmmss"), _
                      userid, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), _
                      code_no, yy, ym)
                CommonFun.MsgShow(Me, CommonFun.Msg.changeOK)
            Else
                Throw New FlowException("該資料已經凍結")
            End If

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
