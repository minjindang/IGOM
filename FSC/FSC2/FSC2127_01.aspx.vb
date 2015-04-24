Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class FSC2127_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            InitControl()
        End If

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
        End If
    End Sub

    Protected Sub InitControl()
        UcDDLDepart.Orgcode = LoginManager.OrgCode
        BindMember()
        
        UcDateS.Text = DateTimeInfo.GetRocDate(Now).Substring(0, 5) & "01"
        UcDateE.Text = DateTimeInfo.GetRocDate(Now)
    End Sub

    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        ViewState("dt") = Nothing
        Bind()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        BindMember()
    End Sub

    Protected Sub BindMember()
        UcDDLMember.Orgcode = LoginManager.OrgCode
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub Bind()
        Dim departId As String = UcDDLDepart.SelectedValue
        If UcDateS.Text > UcDateE.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "起日不可大於迄日!")
            Return
        End If

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            departId = ""
        End If

        Dim bll As New FSC.Logic.FSC2127()
        Dim dt As DataTable = bll.GetData(LoginManager.OrgCode, departId, UcDDLMember.SelectedValue, UcDateS.Text, UcDateE.Text)
        gvList.DataSource = dt
        gvList.DataBind()
        ViewState("dt") = dt
        dataTable.Visible = True
        btnPrint.Enabled = gvList.Rows.Count > 0
    End Sub



#Region "列印"
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If ViewState("dt") Is Nothing Then
            Bind()
        End If

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
        Else

            dt.Columns.Add("NO", GetType(String))

            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("NO") = i + 1
            Next

            Dim theDTReport As CommonLib.DTReport

            Dim strParam(1) As String
            strParam(0) = UcDateS.Text & "至" & UcDateE.Text
            strParam(1) = Right("000" & Today.Year - 1911, 3) & "-" & Today.ToString("MM-dd")

            theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/FSC/FSC2127_01.mht"), dt)
            theDTReport.Param = strParam

            theDTReport.ExportFileName = "刷卡資料"
            theDTReport.ExportToExcel()

            dt.Dispose()
        End If
    End Sub

#End Region

    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        Bind()
    End Sub

End Class
