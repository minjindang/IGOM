Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC2133_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return

        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        UcDDLAuthorityDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Name_bind()

        UcDateS.Text = (Now.Year - 1911).ToString.PadLeft(3, "0") + Now.Month.ToString.PadLeft(2, "0") + "01"
        UcDateE.Text = (Now.Year - 1911).ToString.PadLeft(3, "0") + Now.Month.ToString.PadLeft(2, "0") + Date.DaysInMonth(Now.Year, Now.Month).ToString

        ddlEmployeetype.DataTextField = "CODE_DESC1"
        ddlEmployeetype.DataValueField = "CODE_NO"
        ddlEmployeetype.DataSource = New SYS.Logic.CODE().GetData("023", "022")
        ddlEmployeetype.DataBind()
        ddlEmployeetype.Items.Insert(0, New ListItem("請選擇", ""))

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr1.Visible = False
            tr2.Visible = False
        End If
    End Sub

    Protected Sub Name_bind()
        UcDDLAuthorityMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLAuthorityMember.Depart_id = UcDDLAuthorityDepart.SelectedValue
    End Sub

    Protected Sub UcDDLAuthorityDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLAuthorityDepart.SelectedIndexChanged
        Name_bind()
    End Sub
#End Region

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = UcDDLAuthorityDepart.SelectedValue
        Dim id_card As String = UcDDLAuthorityMember.SelectedValue
        Dim id_card2 As String = UcMember.PersonnelId
        Dim Employee_type As String = ddlEmployeetype.SelectedValue
        Dim Start_date As String = UcDateS.Text
        Dim End_date As String = UcDateE.Text

        Dim bll As New FSC2133

        Try
            Dim dt As DataTable = bll.getData(Orgcode, Depart_id, id_card, id_card2, Employee_type)
            dt.Columns.Add("Total_Pehday")
            dt.Columns.Add("Total_hours")

            For Each dr As DataRow In dt.Rows
                dr("Total_Pehday") = CommonFun.getInt(dr("PEHDAY").ToString) + CommonFun.getInt(dr("PERDAY1").ToString) + CommonFun.getInt(dr("PERDAY2").ToString)
                dr("Total_hours") = Content.ConvertDayHours(bll.getLeaveHours(dr("Orgcode"), dr("depart_id"), dr("Id_card"), Start_date, End_date))
            Next

            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()

            If gvlist.Rows.Count > 0 Then
                Ucpager.Visible = True
                btnExport.Enabled = True
            Else
                Ucpager.Visible = False
                btnExport.Enabled = False
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

#Region "報表"
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else
            dt.Columns.Add(New DataColumn("no", GetType(String)))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("no") = i + 1
            Next

            Dim params(1) As String
            params(0) = DateTimeInfo.ConvertToDisplay(UcDateS.Text)
            params(1) = DateTimeInfo.ConvertToDisplay(UcDateE.Text)

            Dim theDTReport As CommonLib.DTReport

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2133_RPT.mht"), dt)
            theDTReport.ExportFileName = "可休假天數統計表"
            theDTReport.Param = params
            theDTReport.ExportToExcel()
            dt.Dispose()
        End If
    End Sub
#End Region

End Class
