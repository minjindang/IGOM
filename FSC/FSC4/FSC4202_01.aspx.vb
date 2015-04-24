Imports System.IO
Imports System.Data
Imports FSCPLM.Logic

Partial Class FSC4202_01
    Inherits BaseWebForm

    Dim realPath As String = HttpContext.Current.Server.MapPath("~")
    Dim folder As New DirectoryInfo(realPath)
    Dim reportPath As String = ConfigurationManager.AppSettings("PKReportPath").ToString()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then
            ShowDLL()
            Me.tbStartDate.Text = DateTimeInfo.ToDisplay(DateTimeInfo.GetRocDate(Now.AddDays(-1)))
            Me.tbEndDate.Text = DateTimeInfo.ToDisplay(DateTimeInfo.GetRocDate(Now.AddDays(-1)))
        End If
    End Sub

#Region "下拉式選單"
    Protected Sub ShowDLL()
        UcDDLDepart.Orgcode = LoginManager.OrgCode
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

#End Region

    Protected Sub btTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btTransfer.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sDate As String = tbStartDate.Text
        Dim eDate As String = tbEndDate.Text
        Dim dept As String = UcDDLDepart.SelectedValue
        Dim idno As String = UcDDLMember.SelectedValue
        Dim card As String = UcMember.PersonnelId

        If sDate > eDate Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢起日不可大於迄日!")
            Return
        End If

        If Integer.Parse(sDate) > Integer.Parse(DateTimeInfo.GetRocDate(Now)) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "轉出勤日期不可大於今日!")
            Return
        End If

        Try
            Dim bll As New FSC.Logic.FSC4202()
            bll.Transfer(Orgcode, dept, idno, card, sDate, eDate)

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "刷卡轉出勤結束")

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        btQuery_Click(sender, e)
    End Sub
#End Region

    Protected Sub btQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btQuery.Click
        If String.IsNullOrEmpty(tbQryDate.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查詢報表日期為必填")
            Return
        End If

        Dim path As String = reportPath & tbQryDate.Text.Substring(0, 3) & "\\" & tbQryDate.Text
        Dim reportFolder As New DirectoryInfo(folder.FullName & path)
        Dim role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)


        If Me.tbQryDate.Text <> "" Then
            If reportFolder.Exists Then


                Dim filesInfo() As FileInfo = reportFolder.GetFiles()

                If Not filesInfo Is Nothing Then
                    Dim dt As New DataTable()
                    dt.Columns.Add(New DataColumn("NAME", GetType(String)))
                    dt.Columns.Add(New DataColumn("URL", GetType(String)))
                    For Each fileInfo As FileInfo In filesInfo
                        Dim nr As DataRow = dt.NewRow
                        nr("NAME") = fileInfo.Name
                        nr("URL") = "~/" & path & "/" & fileInfo.Name
                        dt.Rows.Add(nr)
                    Next
                    Me.gvList.DataSource = dt
                    Me.gvList.DataBind()
                    Me.gvList.Visible = True
                    Me.showTable.Visible = True

                Else
                    Me.gvList.Visible = False
                    Me.showTable.Visible = False

                End If
            Else
                Me.gvList.Visible = False
                Me.showTable.Visible = False
            End If
        Else

        End If
    End Sub

End Class
