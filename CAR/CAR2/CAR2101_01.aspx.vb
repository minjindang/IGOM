Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class CAR_CAR2_CAR2101_01
    Inherits System.Web.UI.Page

    Dim carMain As New Car_main

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            BindCarname()
            BindCarID()
            ddlCarName.Items.Insert(0, New ListItem("請選擇", ""))
            ddlCarId.Items.Insert(0, New ListItem("請選擇車輛代號", ""))
        End If

    End Sub

    Protected Sub BindCarname()
        Dim sysCodeDAO As New SACode
        Dim carDT As DataTable = sysCodeDAO.GetData("015", "011")
        ddlCarName.DataSource = carDT
        ddlCarName.DataTextField = "CODE_DESC1"
        ddlCarName.DataValueField = "CODE_NO"
        ddlCarName.DataBind()
    End Sub

    Protected Sub BindCarID()
        Dim DT = carMain.GetcarId("")
        ddlCarId.DataSource = DT
        ddlCarId.DataTextField = "Car_id"
        ddlCarId.DataValueField = "Car_id"
        ddlCarId.DataBind()
    End Sub

    Private Sub BindGV()
        Dim dt As DataTable = carMain.Car_1104Select(Server.HtmlEncode(Start_date.Text), Server.HtmlEncode(End_date.Text), _
                                        Server.HtmlEncode(ddlCarName.SelectedValue), Server.HtmlEncode(ddlCarId.SelectedValue), _
                                        Server.HtmlEncode(Sort_Style1.Code_no), Server.HtmlEncode(Sort_Style2.Code_no))
       
        div1.Visible = True
        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose()
    End Sub

    Protected Sub SelectBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectBtn.Click
        BindGV()
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

End Class
