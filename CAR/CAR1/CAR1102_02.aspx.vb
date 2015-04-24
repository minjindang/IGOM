Imports FSCPLM.Logic
Imports System.Data
Imports Common

Partial Class CAR1_CAR1102
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then Return
        ym_Create()
        Maintain()

    End Sub

    Protected Sub ym_Create()
        Dim Year As String = Now.Year - 2 - 1911
        For i As Integer = 0 To 4
            MA_Year.Items.Add((Year + i).ToString.PadLeft(3, "0"))
            BUY_Year.Items.Add((Year + i).ToString.PadLeft(3, "0"))
        Next
        For i As Integer = 1 To 12
            MA_Month.Items.Add(i.ToString.PadLeft(2, "0"))
            BUY_Month.Items.Add(i.ToString.PadLeft(2, "0"))
        Next
        MA_Year.SelectedValue = Now.Year - 1911
        BUY_Year.SelectedValue = Now.Year - 1911
        MA_Month.SelectedValue = Now.Month.ToString.PadLeft(2, "0")
        BUY_Month.SelectedValue = Now.Month.ToString.PadLeft(2, "0")

    End Sub

    Protected Sub Maintain()

        Dim db As New DataTable
        Dim Carmain As New Car_main
        Dim carid As String = ""
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request("tb1")) Then
                tbCarID.Text = Request("tb1")
                carid = Server.HtmlEncode(Request("tb1"))
            End If
            db = Carmain.CAR0301_GetCarData(carid)

            Me.GridViewA.DataSource = db
            Me.GridViewA.DataBind()
            div1.Visible = True

            tbCarID.Text = CType(GridViewA.Rows(0).FindControl("lblcarid"), Label).Text
            MA_Year.SelectedValue = (CType(GridViewA.Rows(0).FindControl("lblmadate"), Label).Text).Substring(1, 3)
            BUY_Year.SelectedValue = (CType(GridViewA.Rows(0).FindControl("lblbuydate"), Label).Text).Substring(1, 3)
            MA_Month.SelectedValue = (CType(GridViewA.Rows(0).FindControl("lblmadate"), Label).Text).Substring(3, 2)
            BUY_Month.SelectedValue = (CType(GridViewA.Rows(0).FindControl("lblbuydate"), Label).Text).Substring(3, 2)
            tbCCcnt.Text = CType(GridViewA.Rows(0).FindControl("lblCCcnt"), Label).Text
            tbbrandname.Text = CType(GridViewA.Rows(0).FindControl("lblbrandname"), Label).Text
            tbComInsurance.Text = CType(GridViewA.Rows(0).FindControl("lblcominsurancedate"), Label).Text
            tbInsurance.Text = CType(GridViewA.Rows(0).FindControl("lblinsurancedate"), Label).Text
            tbScrapDate.Text = CType(GridViewA.Rows(0).FindControl("lblscrapdate"), Label).Text

        End If
    End Sub


    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card) = "" Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('" + "請登入帳號" + "');void(0);", True)
        End If

        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main
        Dim carid As String = ""
        Dim madate As String = ""
        Dim buydate As String = ""
        Dim CCcnt As String = ""
        Dim brandname As String = ""
        Dim comInsurance As String = ""
        Dim insurance As String = ""
        Dim scrapdate As String = ""
        Dim moduserid As String = "" '" LoginManager.GetTicketUserData(LoginManager.LoginUserData.[Personnel_id])"
        Dim moddate As Date = Now.Date
        Dim modorg As String = "" '"LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)"

        If Not String.IsNullOrEmpty(tbCarID.Text) Then
            carid = Server.HtmlEncode(tbCarID.Text)
        End If
        If Not String.IsNullOrEmpty(MA_Year.SelectedValue.PadLeft(3, "0") & MA_Month.SelectedValue.PadLeft(2, "0")) Then
            madate = Server.HtmlEncode(MA_Year.SelectedValue.PadLeft(3, "0") & MA_Month.SelectedValue.PadLeft(2, "0"))
        End If
        If Not String.IsNullOrEmpty(BUY_Year.SelectedValue.PadLeft(3, "0") & BUY_Month.SelectedValue.PadLeft(2, "0")) Then
            buydate = Server.HtmlEncode(BUY_Year.SelectedValue.PadLeft(3, "0") & BUY_Month.SelectedValue.PadLeft(2, "0"))
        End If
        If Not String.IsNullOrEmpty(tbCCcnt.Text) Then
            CCcnt = Server.HtmlEncode(tbCCcnt.Text)
        End If
        If Not String.IsNullOrEmpty(tbbrandname.Text) Then
            brandname = Server.HtmlEncode(tbbrandname.Text)
        End If
        If Not String.IsNullOrEmpty(tbComInsurance.Text) Then
            comInsurance = Server.HtmlEncode(tbComInsurance.Text)
        End If
        If Not String.IsNullOrEmpty(tbInsurance.Text) Then
            insurance = Server.HtmlEncode(tbInsurance.Text)
        End If
        If Not String.IsNullOrEmpty(tbScrapDate.Text) Then
            scrapdate = Server.HtmlEncode(tbScrapDate.Text)
        End If

        If CarMain.CAR0301_update(carid, madate, buydate, CCcnt, brandname, comInsurance, insurance, scrapdate, moduserid, moddate, modorg) = 1 Then
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('" + "修改完成" + "');void(0);", True)

        End If

        buydate = Server.HtmlEncode(BUY_Year.SelectedValue.PadLeft(3, "0"))
        Response.Redirect("~/CAR/CAR1/CAR1102.aspx?buydatemaintain1=" + buydate + "&buydatemaintain2=" + buydate + "&brandnamemaintain=" + brandname + "&caridmaintain=" + carid + "&scrapdatemaintain=" + scrapdate)

    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        tbCarID.Text = ""
        MA_Year.SelectedValue = Now.Year - 1911
        BUY_Year.SelectedValue = Now.Year - 1911
        MA_Month.SelectedValue = Now.Month.ToString.PadLeft(2, "0")
        BUY_Month.SelectedValue = Now.Month.ToString.PadLeft(2, "0")
        tbCCcnt.Text = ""
        tbbrandname.Text = ""
        tbComInsurance.Text = ""
        tbInsurance.Text = ""
        tbScrapDate.Text = ""
    End Sub





End Class
