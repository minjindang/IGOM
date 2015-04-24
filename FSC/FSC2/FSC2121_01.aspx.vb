Imports System.Data
Imports FSC.Logic
Partial Class FSC2121_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return
        Dept_Bind()
        DD_Create()
        getData()
    End Sub

    Protected Sub Dept_Bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
    End Sub

    Protected Sub DD_Create()
        DD_Year.Items.Add((Now.Year - 1911).ToString.PadLeft(3, "0"))

        For i As Integer = Now.Month To Now.Month + 1
            DD_Month.Items.Add(i.ToString().PadLeft(2, "0"))
        Next

        DD_Month.SelectedValue = Now.Month.ToString.PadLeft(2, "0")
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        getData()
        cal.VisibleDate = New Date(CommonFun.getInt(DD_Year.SelectedValue) + 1911, CommonFun.getInt(DD_Month.SelectedValue()), 1)
    End Sub

    Protected Sub getData()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Try
            Dim bll As New FSC2121()

            Dim Sche_month As String = DD_Year.SelectedValue().ToString.PadLeft(3, "0") & DD_Month.SelectedValue()

            Dim dt As DataTable = bll.getData(orgcode, UcDDLDepart.SelectedValue, Sche_month)
            ViewState("dt") = dt

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub cal_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs)
        Try
            DD_Year.SelectedValue = (e.NewDate.Year - 1911).ToString().PadLeft(3, "0")
            DD_Month.SelectedValue = e.NewDate.Month.ToString().PadLeft(2, "0")
            getData()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub cal_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs)

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        Dim show As New StringBuilder()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim drs() As DataRow = dt.Select("Sche_date='" & DateTimeInfo.GetRocDate(e.Day.Date) & "'")

            For Each dr As DataRow In drs

                show.AppendLine("<div style=""color:blue;font-size:15px;cursor:pointer;""> ")
                show.AppendLine(dr("User_name").ToString() + "(" + dr("Sche_Name").ToString() + ")")
                show.AppendLine("</div>")

            Next
        End If

        e.Cell.Controls.Add(New LiteralControl(show.ToString()))
    End Sub
End Class
