Imports FSCPLM.Logic
Imports System.Data
Imports Common

Partial Class CAR3101_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        ym_Create()
    End Sub

    Protected Sub ym_Create()
        Dim Year As String = Now.Year - 20 - 1911
        For i As Integer = 0 To 24
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


    Protected Function CheckFields() As Boolean

        If String.IsNullOrEmpty(tbCarID.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "車牌必需輸入")
            Return False
        End If
        If Not CommonFun.IsNum(tbCCcnt.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "汽缸容量應為數字")
            Return False
        End If

        If String.IsNullOrEmpty(tbComInsurance.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，請輸入4位數字。")
            Return False
        End If
        If Not CommonFun.IsNum(tbComInsurance.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，請輸入數字")
            Return False
        End If
        If (Integer.Parse(Left(tbComInsurance.Text, 2)) - 13 >= 1) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，前2碼請輸入 13以下之數字")
            Return False
        End If
        If (Integer.Parse(Right(tbComInsurance.Text, 2)) - 32 >= 1) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，後2碼請輸入 32以下之數字")
            Return False
        End If

        Return True
    End Function

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click

        If Not CheckFields() Then
            Return
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
        Dim moduserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
        Dim moddate As Date = Now.Date
        Dim modorg As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim memo As String = ""

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

        memo = CarMain.CAR0301_insertData(carid, madate, buydate, CCcnt, brandname, comInsurance, insurance, scrapdate, moduserid, moddate, modorg)

        If memo = "新增成功" Then
            buydate = Server.HtmlEncode(BUY_Year.SelectedValue.PadLeft(3, "0"))
            Response.Redirect("CAR3101_01.aspx?op=A&result=true&buydateInsert1=" + buydate + "&buydateInsert2=" + buydate + "&brandnameInsert=" + brandname + "&caridInsert=" + carid + "&scrapdateInsert=" + scrapdate)
        Else
            Response.Redirect("CAR3101_01.aspx?op=A&result=false&buydateInsert1=" + buydate + "&buydateInsert2=" + buydate + "&brandnameInsert=" + brandname + "&caridInsert=" + carid + "&scrapdateInsert=" + scrapdate)

        End If

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

    Protected Sub tbComInsurance_TextChanged(sender As Object, e As EventArgs) Handles tbComInsurance.TextChanged
        If tbComInsurance.Text.Length <> 4 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，請輸入4位數字。")
            Return
        End If
        If Not CommonFun.IsNum(tbComInsurance.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，請輸入數字")
            Return
        End If
        If (Integer.Parse(Left(tbComInsurance.Text, 2)) - 13 >= 1) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，前2碼請輸入 13以下之數字")
            Return
        End If
        If (Integer.Parse(Right(tbComInsurance.Text, 2)) - 32 >= 1) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "強制險日期(每年)，後2碼請輸入 32以下之數字")
            Return
        End If
    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Response.Redirect("CAR3101_01.aspx")
    End Sub
End Class
