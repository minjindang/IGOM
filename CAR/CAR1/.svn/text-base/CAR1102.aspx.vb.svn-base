Imports FSCPLM.Logic
Imports System.Data



Partial Class CAR1_CAR1102
    Inherits System.Web.UI.Page

    Dim ddlyy1 As String = ""
    Dim ddlyy2 As String = ""
    Dim brandname As String = ""
    Dim scrapdate As String = ""
    Dim carid As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ddl_yy1.Items.Add(New ListItem("請選擇", ""))
        ddl_yy2.Items.Add(New ListItem("請選擇", ""))
        For i As Integer = Now.Year - 1911 To 95 Step -1
            ddl_yy1.Items.Add(New ListItem(i.ToString.PadLeft(3, "0")))
            ddl_yy2.Items.Add(New ListItem(i.ToString.PadLeft(3, "0")))
        Next

        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request("buydateInsert1")) And Not String.IsNullOrEmpty(Request("buydateInsert2")) And _
                Not String.IsNullOrEmpty(Request("brandnameInsert")) And Not String.IsNullOrEmpty(Request("caridInsert")) And _
                Not String.IsNullOrEmpty(Request("scrapdateInsert")) Then

                ddlyy1 = Request("buydateInsert1").ToString()
                ddlyy2 = Request("buydateInsert2").ToString()
                brandname = Request("brandnameInsert").ToString()
                carid = Request("caridInsert").ToString()
                scrapdate = Request("scrapdateInsert").ToString()
                NewInsert()

            End If
            If Not String.IsNullOrEmpty(Request("buydatemaintain1")) And Not String.IsNullOrEmpty(Request("buydatemaintain2")) And _
             Not String.IsNullOrEmpty(Request("brandnamemaintain")) And Not String.IsNullOrEmpty(Request("caridmaintain")) And _
             Not String.IsNullOrEmpty(Request("scrapdatemaintain")) Then

                ddlyy1 = Request("buydatemaintain1").ToString()
                ddlyy2 = Request("buydatemaintain2").ToString()
                brandname = Request("brandnamemaintain").ToString()
                carid = Request("caridmaintain").ToString()
                scrapdate = Request("scrapdatemaintain").ToString()
                NewInsert()
            End If
        End If

        '  Response.Redirect("~/CAR/CAR1/CAR0301.aspx?buydatemaintain1=" + buydate + "&=" + buydate + "&=" + brandname + "&=" + carid + "&=" + scrapdate)

    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main
        Dim ddlyy1 As String = ""
        Dim ddlyy2 As String = ""
        Dim brandname As String = ""
        Dim scrapdate As String = ""
        Dim carid As String = ""

        If Not String.IsNullOrEmpty(ddl_yy1.SelectedValue) Then
            ddlyy1 = Server.HtmlEncode(ddl_yy1.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(ddl_yy2.SelectedValue) Then
            ddlyy2 = Server.HtmlEncode(ddl_yy2.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(tbBrandName.Text) Then
            brandname = Server.HtmlEncode(tbBrandName.Text)
        End If
        If Not String.IsNullOrEmpty(tbScrapDate.Text) Then
            scrapdate = Server.HtmlEncode(tbScrapDate.Text)
        End If
        If Not String.IsNullOrEmpty(tbCarID.Text) Then
            carid = Server.HtmlEncode(tbCarID.Text)
        End If

        db = CarMain.GetCarData(ddlyy1, ddlyy2, brandname, scrapdate, carid)

        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        div1.Visible = True

    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Response.Redirect("~/CAR/CAR1/CAR1102_01.aspx")
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ddl_yy1.SelectedValue = ""
        ddl_yy2.SelectedValue = ""
        tbBrandName.Text = ""
        tbCarID.Text = ""
        tbScrapDate.Text = ""
        div1.Visible = False
    End Sub

    Protected Sub GridViewA_RowCommand(ByVal sender As Object, _
                                        ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand

        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main
        Dim ddlyy1 As String = ""
        Dim ddlyy2 As String = ""
        Dim brandname As String = ""
        Dim scrapdate As String = ""
        Dim carid As String = ""
        Dim Index As String = e.CommandArgument

        If Not String.IsNullOrEmpty(ddl_yy1.SelectedValue) Then
            ddlyy1 = Server.HtmlEncode(ddl_yy1.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(ddl_yy2.SelectedValue) Then
            ddlyy2 = Server.HtmlEncode(ddl_yy2.SelectedValue)
        End If
        If Not String.IsNullOrEmpty(tbBrandName.Text) Then
            brandname = Server.HtmlEncode(tbBrandName.Text)
        End If
        If Not String.IsNullOrEmpty(tbScrapDate.Text) Then
            scrapdate = Server.HtmlEncode(tbScrapDate.Text)
        End If
        If Not String.IsNullOrEmpty(tbCarID.Text) Then
            carid = Server.HtmlEncode(tbCarID.Text)
        End If

        If e.CommandName = "remove" Then
            db = CarMain.getDeleteData(Index, ddlyy1, ddlyy2, brandname, scrapdate, carid)
            Me.GridViewA.DataSource = db
            Me.GridViewA.DataBind()
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('" + "刪除成功" + "');void(0);", True)
            Me.div1.Visible = True
        End If
        If e.CommandName = "editor" Then
            Dim tb1 As String = e.CommandArgument
            Response.Redirect("~/CAR/CAR1/CAR1102_02.aspx?tb1=" + tb1)
        End If
    End Sub

    Protected Sub NewInsert()
        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main


        ddl_yy1.SelectedValue = ddlyy1.ToString()
        ddl_yy2.SelectedValue = ddlyy2.ToString()
        tbBrandName.Text = brandname.ToString()
        tbCarID.Text = carid.ToString()
        tbScrapDate.Text = scrapdate.ToString()

        db = CarMain.CAR0301_GetCarData(tbCarID.Text)

        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        div1.Visible = True


    End Sub

End Class
