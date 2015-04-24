Imports System.Data
Imports System.Data.SqlClient
Imports FSC.Logic
Imports System.Transactions

Partial Class FSC4109_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        showDLL()

    End Sub

    Public Sub showDLL()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim dt As DataTable
        Try
            dt = New SYS.Logic.LeaveType().GetLeaveType(Orgcode)
            ddlPDVTYPE.DataTextField = "Leave_name"
            ddlPDVTYPE.DataValueField = "Leave_type"
            ddlPDVTYPE.DataSource = dt
            ddlPDVTYPE.DataBind()
            ddlPDVTYPE.Items.Insert(0, New ListItem("請選擇", ""))

            Dim lk As New SYS.Logic.LeaveKind()

            dt = lk.GetData(Orgcode, "")
            ddlPDKIND.DataTextField = "Kind_name"
            ddlPDKIND.DataValueField = "Leave_kind"
            ddlPDKIND.DataSource = dt
            ddlPDKIND.DataBind()


            '職務類別
            Dim c As New SYS.Logic.CODE
            dt = c.GetData("023", "022")
            ddlPEMEMCOD.DataTextField = "CODE_DESC1"
            ddlPEMEMCOD.DataValueField = "CODE_NO"
            ddlPEMEMCOD.DataSource = dt
            ddlPEMEMCOD.DataBind()
            ddlPEMEMCOD.Items.Insert(0, New ListItem("請選擇", ""))

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub cbQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbQuery.Click
        bind()
    End Sub

    Protected Sub bind()
        Dim PDKIND As String = ddlPDKIND.SelectedValue()
        Dim PDMEMCODE As String = ddlPEMEMCOD.SelectedValue().Trim()
        Dim PDVTYPE As String = ddlPDVTYPE.SelectedValue()
        Try
            If Not String.IsNullOrEmpty(PDVTYPE) Then
                PDVTYPE = PDVTYPE.PadLeft(2, "0")
            End If

            Dim dt As DataTable = New CPAPD04M().GetDataByQuery(PDKIND, PDMEMCODE, PDVTYPE)
            dt.Columns.Add("PDMEMCODNAME", GetType(String))
            dt.Columns.Add("PDVTYPENAME", GetType(String))
            For Each dr As DataRow In dt.Rows
                dr("PDMEMCODNAME") = New SYS.Logic.CODE().GetDataDESC("023", "022", dr("PDMEMCOD").ToString())
                dr("PDVTYPENAME") = New SYS.Logic.LeaveType().GetLeaveName(dr("PDVTYPE").ToString())
            Next
            gvList.DataSource = dt
            gvList.DataBind()
            ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
            DataList.Visible = True

        Catch ex As Exception
            AppException.ShowError_ByPage(ex)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Response.Redirect("FSC4109_02.aspx")
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim PDKIND As String = CType(gvr.FindControl("lbPDKIND"), Label).Text
        Dim PDMEMCOD As String = CType(gvr.FindControl("lbPDMEMCOD"), Label).Text
        Dim PDVTYPE As String = CType(gvr.FindControl("lbPDVTYPE"), Label).Text
        Dim PDYEARB As String = CType(gvr.FindControl("lbPDYEARB"), Label).Text
        Response.Redirect("FSC4109_02.aspx?PDKIND=" & PDKIND & "&PDMEMCOD=" & PDMEMCOD & "&PDVTYPE=" & PDVTYPE & "&PDYEARB=" & PDYEARB)
    End Sub


    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim PDKIND As String = CType(gvr.FindControl("lbPDKIND"), Label).Text
        Dim PDMEMCOD As String = CType(gvr.FindControl("lbPDMEMCOD"), Label).Text
        Dim PDVTYPE As String = CType(gvr.FindControl("lbPDVTYPE"), Label).Text
        Dim PDYEARB As String = CType(gvr.FindControl("lbPDYEARB"), Label).Text
        Try
            Dim pd04m As New CPAPD04M()
            pd04m.PDKIND = PDKIND
            pd04m.PDMEMCOD = PDMEMCOD
            pd04m.PDVTYPE = PDVTYPE
            pd04m.PDYEARB = PDYEARB
            pd04m.delete()
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            bind()
        Catch ex As Exception
            AppException.ShowError_ByPage(ex)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex

        Me.gvList.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.gvList.DataBind()
    End Sub
#End Region
End Class
