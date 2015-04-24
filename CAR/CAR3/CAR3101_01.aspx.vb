Imports FSCPLM.Logic
Imports System.Data



Partial Class CAR3101_01
    Inherits BaseWebForm

    Dim ddlyy1 As String = ""
    Dim ddlyy2 As String = ""
    Dim brandname As String = ""
    Dim scrapdate As String = ""
    Dim carid As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request("result")) Then
                If Request("op") = "U" Then
                    If Convert.ToBoolean(Request("result")) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改完成")
                    Else
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改失敗")
                    End If
                ElseIf Request("op") = "A" Then
                    If Convert.ToBoolean(Request("result")) Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增完成")
                    Else
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增失敗")
                    End If
                End If
            End If

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

    End Sub

    Protected Sub btnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main
        Dim ddlyy1 As String = ""
        Dim ddlyy2 As String = ""
        Dim brandname As String = ""
        Dim scrapdate As String = ""
        Dim carid As String = ""

        If Not String.IsNullOrEmpty(ddl_yy1.Year) Then
            ddlyy1 = Server.HtmlEncode(ddl_yy1.Year)
        End If
        If Not String.IsNullOrEmpty(ddl_yy2.Year) Then
            ddlyy2 = Server.HtmlEncode(ddl_yy2.Year)
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
        Response.Redirect("CAR3101_02.aspx")
        'Response.Redirect("~/CAR/CAR1/CAR1102_01.aspx")
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ddl_yy1.Year = Now.Year
        ddl_yy2.Year = Now.Year
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

        If Not String.IsNullOrEmpty(ddl_yy1.Year) Then
            ddlyy1 = Server.HtmlEncode(ddl_yy1.Year)
        End If
        If Not String.IsNullOrEmpty(ddl_yy2.Year) Then
            ddlyy2 = Server.HtmlEncode(ddl_yy2.Year)
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
            Response.Redirect("CAR3101_03.aspx?tb1=" + tb1)
            'Response.Redirect("~/CAR/CAR1/CAR1102_02.aspx?tb1=" + tb1)
        End If
    End Sub

    Protected Sub NewInsert()
        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main


        ddl_yy1.Year = Convert.ToInt16(ddlyy1)
        ddl_yy2.Year = Convert.ToInt16(ddlyy2)
        tbBrandName.Text = brandname.ToString()
        tbCarID.Text = carid.ToString()
        tbScrapDate.Text = scrapdate.ToString()

        db = CarMain.CAR0301_GetCarData(tbCarID.Text)

        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        div1.Visible = True


    End Sub

End Class
