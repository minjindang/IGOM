Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic


Partial Class SYS3111_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub
#End Region


    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Try
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim dt As DataTable = New Personnel().GetDataByQuery(Orgcode, UcDDLDepart.SelectedValue, "", UcDDLMember.SelectedValue)
            dt.Columns.Add("Role_name")
            For Each dr As DataRow In dt.Rows
                For Each role In dr("Role_id").ToString().Split(",")
                    If Not String.IsNullOrEmpty(dr("Role_name").ToString()) Then dr("Role_name") += ","
                    Dim rdt As DataTable = New SYS.Logic.Role().GetDataByOrgRid(Orgcode, role)
                    If rdt IsNot Nothing AndAlso rdt.Rows.Count > 0 Then
                        dr("Role_name") += rdt.Rows(0)("Role_name").ToString()
                    End If
                Next
            Next

            gvlist.DataSource = dt
            gvlist.DataBind()

            ViewState("dt") = dt

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
            Else
                Ucpager.Visible = False
            End If
            tbq.Visible = True
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

    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim id_card As String = CType(gvr.FindControl("lbId_card"), Label).Text

        Response.Redirect("SYS3111_02.aspx?idcard=" + id_card)
    End Sub

End Class
