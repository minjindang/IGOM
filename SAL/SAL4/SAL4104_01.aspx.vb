Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class SAL4104_01
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim Case_status As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        'UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '有這行才會load進UcDDLDepart

        Dim dt As DataTable = New FSCPLM.Logic.SACode().GetData("002", "003")
        ddlJob_type.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlJob_type.DataValueField = "code_no"     '所代表的value
        ddlJob_type.DataSource = dt                '指定datatable給ddl
        ddlJob_type.DataBind()                     'ddl進行Databind
        ddlJob_type.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"
        Dim dt1 As DataTable = New FSCPLM.Logic.SACode().GetData("002", "006")
        ddlLevel_type.DataTextField = "code_desc1"   '顯示的中文名稱
        ddlLevel_type.DataValueField = "code_no"     '所代表的value
        ddlLevel_type.DataSource = dt1                '指定datatable給ddl
        ddlLevel_type.DataBind()                     'ddl進行Databind
        ddlLevel_type.Items.Insert(0, New ListItem("請選擇", "")) 'Index=0，插入"請選擇"

    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim Jobtype As String = ddlJob_type.SelectedValue
        Dim Leveltype As String = ddlLevel_type.SelectedValue
        Dim bll As New SAL4104()
        Dim dt As DataTable = New DataTable

        'If String.IsNullOrEmpty(Apply_sTime) Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「起日」欄位為必填。")
        '    Return
        'End If

        Try
            dt = bll.getQueryData(Jobtype, Leveltype, orgcode, "")
            dt.Columns.Add("L3")
            dt.Columns.Add("L1")
            For Each dr As DataRow In dt.Rows
                Select Case (dr("LEVCOM_ORG_L3"))
                    Case "001"
                        dr("L3") = "簡任" + "(" + dr("LEVCOM_ORG_L3") + ")"
                    Case "002"
                        dr("L3") = "薦任" + "(" + dr("LEVCOM_ORG_L3") + ")"
                    Case "003"
                        dr("L3") = "委任" + "(" + dr("LEVCOM_ORG_L3") + ")"
                    Case "004"
                        dr("L3") = "技工" + "(" + dr("LEVCOM_ORG_L3") + ")"
                    Case "005"
                        dr("L3") = "工友" + "(" + dr("LEVCOM_ORG_L3") + ")"

                End Select
            Next
            For Each dr As DataRow In dt.Rows
                Select Case (dr("LEVCOM_ORG_L1"))
                    Case "001"
                        dr("L1") = "1職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "002"
                        dr("L1") = "2職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "003"
                        dr("L1") = "3職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "004"
                        dr("L1") = "4職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "005"
                        dr("L1") = "5職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "006"
                        dr("L1") = "6職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "007"
                        dr("L1") = "7職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "008"
                        dr("L1") = "8職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "009"
                        dr("L1") = "9職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "010"
                        dr("L1") = "10職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "011"
                        dr("L1") = "11職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "012"
                        dr("L1") = "12職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "013"
                        dr("L1") = "13職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "014"
                        dr("L1") = "14職等" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "015"
                        dr("L1") = "本餉" + "(" + dr("LEVCOM_ORG_L1") + ")"
                    Case "016"
                        dr("L1") = "年功餉" + "(" + dr("LEVCOM_ORG_L1") + ")"
                End Select
            Next
            'For Each dr As DataRow In dt.Rows
            '    dr("L3") = dr("L3").ToString() + "(" + ddlJob_type.SelectedValue + ")"
            'Next
            If dt IsNot Nothing Then
                tbq.Visible = True
            End If
            ViewState("dt") = dt
            Me.gvlist.DataSource = dt
            Me.gvlist.DataBind()
            dt.Dispose()

            'btnPrint.Enabled = True
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
    Protected Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Response.Redirect("SAL4104_02.aspx")
    End Sub

    Protected Sub btnModify_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim lbL3 As String = CType(gvr.FindControl("lbL3"), Label).Text
        Dim lbL1 As String = CType(gvr.FindControl("lbL1"), Label).Text
        Dim lbPTB As String = CType(gvr.FindControl("lbPTB"), Label).Text
        Dim lbL2 As String = CType(gvr.FindControl("lbL2"), Label).Text
        lbL3 = Left(Right(lbL3, 4), 3)
        lbL1 = Left(Right(lbL1, 4), 3)
        Response.Redirect("SAL4104_03.aspx?lbL3=" + lbL3 + "&lbL1=" + lbL1 + "&lbPTB=" + lbPTB + "&lbL2=" + lbL2)
    End Sub
    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)
        Dim bll As New SAL4104()
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim btnDelete As Button = CType(gvr.FindControl("btnDelete"), Button)
        Dim lbL3 As String = CType(gvr.FindControl("lbL3"), Label).Text
        Dim lbL1 As String = CType(gvr.FindControl("lbL1"), Label).Text
        Dim lbPTB As String = CType(gvr.FindControl("lbPTB"), Label).Text
        Dim lbL2 As String = CType(gvr.FindControl("lbL2"), Label).Text
        lbL3 = Left(Right(lbL3, 4), 3)
        lbL1 = Left(Right(lbL1, 4), 3)
        If (bll.Delete(lbL3, lbL1, lbPTB, lbL2)) = True Then
            btnDelete.Attributes.Add("onclick", "if(!confirm('" + "確定刪除？" + "\n'))return false;")
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「刪除成功」", "SAL4104_01.aspx")

        End If
    End Sub

    'Protected Sub gvlist_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvlist.RowDataBound
    '    For Each gvr As GridViewRow In gvlist.Rows
    '        Dim btnDelete As Button = CType(gvr.FindControl("btnDelete"), Button)
    '        Dim id As String = CType(gvr.FindControl("lbid"), Label).Text
    '        Dim Apply_type As String = CType(gvr.FindControl("lbApply_type"), Label).Text
    '        'Select Case Apply_type
    '        '    Case "子女教育補助費"
    '        '        Apply_type = "001"
    '        '    Case "勞 健公 健保繳納證明申請"
    '        '        Apply_type = "002"
    '        '    Case "未休假加班費申請"
    '        '        Apply_type = "003"
    '        'End Select
    '        Dim dt As DataTable = New DataTable
    '        Dim bll As New SAL4106()
    '        dt = bll.getDeleteSelectData(Apply_type, id)
    '        btnDelete.Attributes.Add("onclick", "if(!confirm('" + "刪除後，開放申請時間會變為" + DateTimeInfo.ToDisplay(dt.Rows(0)("Apply_sDate").ToString) + _
    '                                  DateTimeInfo.ToDisplayTime(dt.Rows(0)("Apply_sTime").ToString) + " 至 " + _
    '                                  DateTimeInfo.ToDisplay(dt.Rows(0)("Apply_eDate").ToString) + DateTimeInfo.ToDisplayTime(dt.Rows(0)("Apply_eTime").ToString) + _
    '                                 "\n確定刪除？'))return false;")
    '    Next
    'End Sub
End Class
