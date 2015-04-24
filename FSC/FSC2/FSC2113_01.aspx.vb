Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic

Partial Class FSC2213_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            Memcod_Bind()
            Dep_Bind()
            Name_Bind()
            Years_Bind()
        End If
    End Sub

#Region "顯示下拉選單"
    Protected Sub Years_Bind()
        For i As Integer = 103 To (Now.Year - 1911)
            ddlYear.Items.Insert(ddlYear.Items.Count, New ListItem(i, i))
        Next
        ddlYear.SelectedValue = (Now.Year - 1911)
    End Sub

    Protected Sub Memcod_Bind()
        ddlEmployee_Type.DataSource = New SYS.Logic.CODE().GetData("023", "022")
        ddlEmployee_Type.DataBind()
        ddlEmployee_Type.Items.Insert(0, New ListItem("請選擇", ""))

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
            tr1.Visible = False
        End If
    End Sub

    Protected Sub Dep_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = Orgcode
    End Sub

    Protected Sub Name_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLAuthorityMember.Orgcode = Orgcode
        UcDDLAuthorityMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

#End Region

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim dt As DataTable = ViewState("dt")
        If dt Is Nothing Then
            bind()
            dt = ViewState("dt")
        End If

        Dim path As String = String.Empty
        Dim theDTReport As CommonLib.DTReport

        If ddlQuery.SelectedValue = "01" Or ddlQuery.SelectedValue = "02" Then
            path = "../../Report/FSC/FSC2113_01_3.mht"
        ElseIf ddlQuery.SelectedValue = "N" Then
            path = "../../Report/FSC/FSC2113_01_1.mht"
        ElseIf ddlQuery.SelectedValue = "Y" Then
            path = "../../Report/FSC/FSC2113_01_2.mht"
        End If

        Dim para(0) As String
        para(0) = ddlQuery.SelectedItem.Text
        theDTReport = New CommonLib.DTReport(Server.MapPath(path), dt)
        theDTReport.Param = para
        theDTReport.ExportFileName = ddlQuery.SelectedItem.Text
        theDTReport.ExportToExcel()
    End Sub

#Region "查詢"
    Protected Sub bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim id_catd As String = UcDDLAuthorityMember.SelectedValue
        Dim departid As String = UcDDLDepart.SelectedValue
        Dim personnel_id As String = UcMember.PersonnelId.Trim()
        Dim employee_type As String = ddlEmployee_Type.SelectedValue()
        Dim yyy As String = ddlYear.SelectedValue
        Dim quit_job_flag As String = ddlQuit.SelectedValue
        Dim sex As String = ddlSex.SelectedValue
        Dim leave_type As String = ddlQuery.SelectedValue

        Try

            Dim bll As New FSC2113()
            Dim tmpdt As DataTable = New DataTable
            Dim dt As DataTable = New DataTable
            If ddlQuery.SelectedValue = "01" Or ddlQuery.SelectedValue = "02" Then
                tmpdt = bll.getData(orgcode, departid, id_catd, personnel_id, yyy, quit_job_flag, sex, employee_type, leave_type)
                tmpdt.Columns.Add("overday")
                dt = tmpdt.Clone()
                For Each dr As DataRow In tmpdt.Rows
                    If Convert.ToInt32(dr("limitday")) - Convert.ToInt32(dr("realday")) < 0 Then
                        dr("limitday") = Content.ConvertDayHours(Convert.ToInt32(dr("limitday")))
                        dr("realday") = Content.ConvertDayHours(Convert.ToInt32(dr("realday")))
                        dr("overday") = Convert.ToInt32(dr("realday")) - Convert.ToInt32(dr("limitday"))

                        dt.ImportRow(dr)
                    End If
                Next

                gv.DataSource = dt
                gv.DataBind()
            ElseIf ddlQuery.SelectedValue = "Y" Then
                dt = bll.getDataSettlementAnnual(orgcode, departid, id_catd, personnel_id, yyy, quit_job_flag, sex, employee_type)
                dt.Columns.Add("Ch_Case_status")

                For Each dr As DataRow In dt.Rows
                    If dr("Last_pass").ToString() = "0" AndAlso (dr("Case_status").ToString() = "0" OrElse dr("Case_status").ToString() = "1") Then
                        dr("Ch_Case_status") = "申請中"
                    ElseIf dr("Last_pass").ToString() = "1" AndAlso dr("Case_status").ToString() = "1" Then
                        dr("Ch_Case_status") = "已決行"
                    ElseIf dr("Last_pass").ToString() = "1" AndAlso dr("Case_status").ToString() = "3" Then
                        dr("Ch_Case_status") = "已撤銷"
                    End If
                Next

                gv2.DataSource = dt
                gv2.DataBind()
            ElseIf ddlQuery.SelectedValue = "N" Then
                dt = bll.getNonSettlementAnnual(orgcode, departid, id_catd, personnel_id, yyy, quit_job_flag, sex, employee_type)

                dt.Columns.Add("Usable_days")
                dt.Columns.Add("Pay_days")
                dt.Columns.Add("Ch_Case_status")
                For Each dr As DataRow In dt.Rows
                    dr("Vacation_days") = Content.ConvertDayHours(Convert.ToInt32(dr("Vacation_days")))
                    dr("Vocation_internal") = Content.ConvertDayHours(Convert.ToInt32(dr("Vocation_internal")))
                    dr("Usable_days") = Convert.ToInt32(dr("Annual_days")) - Convert.ToInt32(dr("Vacation_days")) + Convert.ToInt32(dr("Vocation_internal")) - 14
                    If Convert.ToInt32(dr("Usable_days")) < 0 Then
                        dr("Usable_days") = 0
                    End If
                Next

                gv2.DataSource = dt
                gv2.DataBind()
            End If

            ViewState("dt") = dt
            showTable()

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub showTable()
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If ddlQuery.SelectedValue = "01" Or ddlQuery.SelectedValue = "02" Then
                btnPrint.Enabled = True
                dataList.Visible = True
                dataList2.Visible = False
            Else
                btnPrint.Enabled = True
                dataList.Visible = False
                dataList2.Visible = True
                If ddlQuery.SelectedValue = "N" Then
                    gv2.Columns(7).Visible = False
                    gv2.Columns(8).Visible = False
                Else
                    gv2.Columns(6).Visible = False
                End If
            End If
        Else
            btnPrint.Enabled = False
            dataList.Visible = False
            dataList2.Visible = False
        End If
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        bind()
    End Sub

    Protected Sub gv_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        bind()
    End Sub

    Protected Sub gv2_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gv2.PageIndexChanging
        gv2.PageIndex = e.NewPageIndex
        bind()
    End Sub
#End Region

End Class
