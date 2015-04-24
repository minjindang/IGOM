Imports FSCPLM.Logic
Imports System.Data
Imports Common

Partial Class CAR1_CAR1102
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return
        ym_Create()
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
        Dim moduserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
        Dim moddate As Date = Now.Date
        Dim modorg As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim memo As String = ""

        If tbCarID.Text <> "" Then
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
            'If CarMain.checkCaridData(carid) = 1 Then
            '    ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('車牌不可重覆');void(0);", True)
            'End If
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('" + memo + "');void(0);", True)
            If memo = "新增成功" Then
                ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert(alert('" + memo + "');void(0);", True)
                InsertData(memo, carid, madate, buydate, CCcnt, brandname, comInsurance, insurance, scrapdate, moduserid, moddate, modorg)
            Else
                Me.div1.Visible = False
            End If

        ElseIf tbCarID.Text = "" Then

            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert(' 欄位輸入不完整');void(0);", True)
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

    Protected Sub InsertData(ByVal memo As String, ByVal carid As String, ByVal madate As String, ByVal buydate As String, ByVal CCcnt As String, _
                                      ByVal brandname As String, ByVal comInsurance As String, ByVal insurance As String, ByVal scrapdate As String, _
                                       ByVal moduserid As String, ByVal moddate As Date, ByVal modorg As String)


        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('" + memo + "');void(0);", True)
        buydate = Server.HtmlEncode(BUY_Year.SelectedValue.PadLeft(3, "0"))
        Response.Redirect("~/CAR/CAR1/CAR1102.aspx?buydateInsert1=" + buydate + "&buydateInsert2=" + buydate + "&brandnameInsert=" + brandname + "&caridInsert=" + carid + "&scrapdateInsert=" + scrapdate)

    End Sub




End Class
