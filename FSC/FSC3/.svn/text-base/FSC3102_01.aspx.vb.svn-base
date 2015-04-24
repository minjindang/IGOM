Imports FSC.Logic
Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient

Partial Class FSC3102_01
    Inherits BaseWebForm

    Const row_cnt As Integer = 3
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")

#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        If Not IsPostBack Then '第一次瀏覽網頁
            Dep_Bind()
            Name_Bind()
        End If
    End Sub
#End Region

#Region "顯示下拉選單"
    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Name_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        ddlName.Orgcode = Orgcode
        ddlName.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

#End Region

#Region "建立列表"
    Public Sub ShowGridView()
        Dim strOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim DAOFSC3102 As New FSC3102()
        Dim dt As DataTable
        Try
            dt = DAOFSC3102.Get_Member(strOrgcode, _
                                    UcDDLDepart.SelectedValue.ToString(), _
                                    ddlName.SelectedValue)

            DataList.Visible = True
            gvList.DataSource = dt
            gvList.DataBind()
            ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
            dt.Dispose()


        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "系統發生錯誤，請稍候再試或通知系統管理者" & ex.ToString)
        End Try

    End Sub

#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvList.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.gvList.DataBind()
    End Sub
#End Region

#Region "檢視"
    Protected Sub gvList_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvList.RowCommand

        If e.CommandName = "View" Then
            Dim str As String = e.CommandArgument
            Dim strs As String()
            Dim orgcode As String = ""
            Dim id_card As String = ""

            Try
                strs = str.Split(",")
                orgcode = strs(0).ToString
                id_card = strs(1).ToString

            Catch ex As Exception

            End Try

            Response.Redirect("FSC3102_02.aspx?org=" & orgcode & "&idno=" & id_card)
        End If
    End Sub
#End Region


    Protected Sub btnFind_Click(sender As Object, e As System.EventArgs) Handles btnFind.Click
        ShowGridView()
    End Sub

    Protected Sub btnNew_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Response.Redirect("FSC3102_03.aspx")
    End Sub

#Region "代理人清單"
    Public Function Get_Deputy_list(ByVal orgcode As String, ByVal ID_Card As String, Optional ByVal Deputy_Type As String = Nothing) As String
        Dim rv As String = ""
        Dim i As Integer = 0

        Dim deputy As New FSC3102
        Dim dt As DataTable = deputy.Get_Deputy(orgcode, ID_Card)

        For Each dr As DataRow In dt.Rows
            
            If i > 0 Then
                rv &= ", "
            End If

            '' 每3筆換行
            If (i Mod row_cnt = 0) And (i > 0) Then
                rv &= "<br />"
            End If

            If dr("Deputy_flag").ToString.Trim = "1" Then
                rv &= dr("user_name").ToString + "(預)"
            Else
                rv &= dr("user_name").ToString
            End If


            i = i + 1

        Next

        Return rv
    End Function
#End Region


    Protected Sub gvList_DataBound(sender As Object, e As EventArgs) Handles gvList.DataBound
        gvList.Columns(5).Visible = False
        gvList.Columns(6).Visible = False
        gvList.Columns(7).Visible = True
    End Sub
End Class
