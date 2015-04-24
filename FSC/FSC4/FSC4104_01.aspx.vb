Imports System.Data
Imports FSC.Logic

Partial Class FSC4104_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return
        DD_Create()

        '高雄大學新增匯入與xls格式下載 by jessica add 20140103
        Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
        Dim i As Integer = 0
        If OrgType.ToLower().Contains("nuk") Then
            btnImport.Visible = True
            lbtnSample.Visible = True
        Else
            btnImport.Visible = False
            lbtnSample.Visible = False
        End If
    End Sub

    Protected Sub DD_Create()
        Dim Year As String = Now.Year - 2 - 1911
        For i As Integer = 0 To 3
            DD_Year.Items.Add(Year + i)
        Next
        For i As Integer = 1 To 12
            DD_Month.Items.Add(i.ToString().PadLeft(2, "0"))
        Next
        DD_Year.SelectedValue = Now.Year - 1911
        DD_Month.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        ShowList()
    End Sub

    Protected Sub ShowList()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim pb02m As New CPAPB02M()
        Dim dt As DataTable
        Try
            Dim yyymm As String = DD_Year.SelectedValue() & DD_Month.SelectedValue()
            dt = pb02m.getData(Orgcode, "", yyymm)
            ViewState("dt") = dt
            gvList.DataSource = dt
            gvList.DataBind()
            tbQ.Visible = True
            btnPrint.Enabled = True

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.ShowError_ByPage(ex)
        End Try
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click, cbConfirm2.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim pb02m As New CPAPB02M()


        Try
            Dim yyymm As String = DD_Year.SelectedValue() & DD_Month.SelectedValue()

            For Each gvr As GridViewRow In gvList.Rows
                pb02m.Orgcode = Orgcode
                pb02m.DepartId = Depart_id
                pb02m.PBDDATE = CType(gvr.FindControl("lbDATE"), Label).Text.Trim()
                pb02m.PBDTYPE = CType(gvr.FindControl("ddlTYPE"), DropDownList).SelectedValue()
                pb02m.PBDDESC = CType(gvr.FindControl("tbDESC"), TextBox).Text.Trim()
                pb02m.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                Dim PBDTYPE As String = CType(gvr.FindControl("lbTYPE"), Label).Text.Trim()
                Dim PBDDESC As String = CType(gvr.FindControl("lbDESC"), Label).Text.Trim()
                If pb02m.PBDDESC.Length > 40 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「說明」欄位字數不能超過40個字。")
                    Return
                End If
                If Not PBDTYPE.Equals(pb02m.PBDTYPE) Or Not PBDDESC.Equals(pb02m.PBDDESC) Then
                    pb02m.update()
                End If
            Next
            ShowList()

            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateFail)
        End Try
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("FSC4104_02.aspx")
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            Dim theDTReport As CommonLib.DTReport

            For Each dr As DataRow In dt.Rows
                If dr("PBDTYPE").ToString() = "0" Then
                    dr("PBDTYPE") = "全日上班"
                ElseIf dr("PBDTYPE").ToString() = "1" Then
                    dr("PBDTYPE") = "上班半日"
                Else
                    dr("PBDTYPE") = "放假"
                End If
            Next

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC4104_01.mht"), dt)

            theDTReport.ExportFileName = "年度行事曆"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub

    Protected Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Response.Redirect("FSC4104_03.aspx")
    End Sub
End Class
