Imports MAI.Logic
Imports System.Data
Imports System.Collections.Generic


Partial Class MAI3102_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        InitControl()
    End Sub

    Protected Sub InitControl()
        cblMaintain_type.DataSource = New SYS.Logic.CODE().GetData("020", "005")
        cblMaintain_type.DataBind()
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departid As String = UcDDLDepart.SelectedValue
        Dim Apply_dateS As String = UcDateS.Text
        Dim Apply_dateE As String = UcDateE.Text
        Dim Apply_name As String = tbApply_name.Text.Trim
        Dim Apply_ext As String = tbApply_ext.Text.Trim
        Dim Maintain_type As String = String.Empty
        Dim Case_status As String = String.Empty

        For Each i As ListItem In cblMaintain_type.Items
            If i.Selected Then
                If Not String.IsNullOrEmpty(Maintain_type) Then Maintain_type &= ","
                Maintain_type &= i.Value
            End If
        Next

        If cbDone.Checked AndAlso Not cbUnDone.Checked Then
            Case_status = "003"
        ElseIf Not cbDone.Checked AndAlso cbUnDone.Checked Then
            Case_status = "other"
        End If

        Dim dt As DataTable = New DataTable
        Try
            dt = New MAI3102().getData(orgcode, Maintain_type, Apply_dateS, Apply_dateE, Apply_name, Apply_ext, departid, Case_status)
            tbq.Visible = True
            ViewState("dt") = dt
            gvlist.DataSource = dt
            gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnExport.Enabled = True
            Else
                Ucpager.Visible = False
                btnExport.Enabled = False
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex

        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

#Region "報表"
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
            Return
        Else
            Dim theDTReport As CommonLib.DTReport

            dt.Columns.Add("Num")
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("Num") = i + 1
                dt.Rows(i)("Apply_date") = FSC.Logic.DateTimeInfo.ToDisplay(dt.Rows(i)("Apply_date").ToString())
            Next

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/MAI/MAI3102_01.mht"), dt)
            theDTReport.ExportFileName = "水電報修紀錄"
            theDTReport.ExportToExcel()
        End If
    End Sub

#End Region
    Protected Sub cbType_All_CheckedChanged(sender As Object, e As EventArgs)
        For Each i As ListItem In cblMaintain_type.Items
            i.Selected = cbType_All.Checked
        Next
    End Sub

    Protected Sub cbAll_CheckedChanged(sender As Object, e As EventArgs)
        cbDone.Checked = cbAll.Checked
        cbUnDone.Checked = cbAll.Checked
    End Sub

    Protected Sub lbtFlow_id_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim flow_id As String = CType(sender, LinkButton).Text
        Response.Redirect("../../FSC/FSC0/FSC0101_10.aspx?org=" + Orgcode + "&fid=" + flow_id)
    End Sub
End Class
