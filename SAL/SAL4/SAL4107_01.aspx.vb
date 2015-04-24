Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class SAL4107_01
    Inherits BaseWebForm

    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
    Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
    Dim dtData As DataTable
    Dim bll As New SAL4107()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        '日期欄位預設有填寫這月的日期
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMMdd")

        dtData = New FSCPLM.Logic.SACode().GetData("009", "**")
        ddlApply_type.DataTextField = "code_desc1"
        ddlApply_type.DataValueField = "code_no"
        ddlApply_type.DataSource = dtData
        ddlApply_type.DataBind()
        ddlApply_type.Items.Insert(0, New ListItem("全部", ""))
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim JOB_ITEM As String = ddlApply_type.SelectedValue
        Dim PAY_DATE As String = UcDate1.Text

        Try
            dtData = bll.getQueryData(orgcode, JOB_ITEM, PAY_DATE)

            tbq.Visible = True
            ViewState("dt") = dtData
            Me.gvlist.DataSource = dtData
            Me.gvlist.DataBind()
            dtData.Dispose()

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

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub

    Protected Function Time_Name(ByVal time) As String
        Dim rv As String = ""
        time = time.ToString
        If Len(time) = 14 Then
            rv = CStr(CInt(Mid(time, 1, 4)) - 1911) & "年" & Mid(time, 5, 2) & "月" & Mid(time, 7, 2) & "日<br />" & Mid(time, 9, 2) & "時" & Mid(time, 11, 2) & "分" & Mid(time, 13, 2) & "秒"
        Else
            rv = time
        End If
        Return rv
    End Function

End Class
