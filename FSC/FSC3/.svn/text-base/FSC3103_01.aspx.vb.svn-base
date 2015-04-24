Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports FSC.Logic

Partial Class FSC3103_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack Then

            ShowDepartName()
            ShowTitle()
            ShowName()
        End If
        reload()
    End Sub


    Protected Sub reload()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        '按了確定要執行的程式碼
        If target = "reload" Then
            If argument = "True" Then
                ShowGridView()
            End If
        End If
    End Sub

#Region "顯示下拉選單"

    Public Sub ShowDepartName()
        Try
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            UcDDLDepart.Orgcode = Orgcode
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ShowTitle()
        ddlTitle.DataValueField = "CODE_NO"
        ddlTitle.DataTextField = "CODE_DESC1"
        ddlTitle.DataSource = New SYS.Logic.CODE().GetData("023", "012")
        ddlTitle.DataBind()
        ddlTitle.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Public Sub ShowName()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New Personnel().GetDataByQuery(Orgcode, UcDDLDepart.SelectedValue(), ddlTitle.SelectedValue, tbIdcard.Text.Trim())

        dt.Columns.Add("FULL_Name")
        For Each dr As DataRow In dt.Rows
            dr("FULL_Name") = dr("Title_Name").ToString() + "/" + dr("User_name").ToString()
        Next

        ddlName.DataValueField = "id_card"
        ddlName.DataTextField = "FULL_Name"
        ddlName.DataSource = dt
        ddlName.DataBind()
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))

    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        ShowTitle()
        ShowName()
    End Sub

    Protected Sub ddlTitle_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTitle.SelectedIndexChanged
        ShowName()
    End Sub

#End Region

#Region "查詢"
    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        ShowGridView()
    End Sub
#End Region

#Region "建立列表"
    Public Sub ShowGridView()
        Dim strOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        '
        Dim fsc3103 As New FSC3103()
        Dim dt As DataTable

        Try
            Dim BOSS_Id_card As String = ddlName.SelectedValue

            dt = fsc3103.Get_Boss(strOrgcode, Me.UcDDLDepart.SelectedValue, Me.tbIdcard.Text.Trim(), Me.ddlTitle.SelectedValue.Trim, BOSS_Id_card)

            Me.gvList.DataSource = dt
            Me.gvList.DataBind()
            ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
            dt.Dispose()

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub
#End Region

#Region "維護"
    Protected Sub gvList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvList.RowCommand
        If e.CommandName = "Upd" Then '
            Dim Orgcode As String = Split(e.CommandArgument, "|")(0)
            Dim Depart_id As String = Split(e.CommandArgument, "|")(1)
            Dim Id_card As String = Split(e.CommandArgument, "|")(2)
            Response.Redirect("FSC3103_02.aspx?idcard=" & Id_card & "&org=" & Orgcode & "&did=" & Depart_id)
        End If
    End Sub
#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvList.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.gvList.DataBind()
    End Sub
#End Region

    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Btn As Button = CType(e.Row.Cells(2).Controls(1), Button)
            Btn.CommandArgument = e.Row.RowIndex.ToString()
        End If
    End Sub

End Class
