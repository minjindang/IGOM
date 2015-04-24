Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports CommonLib

Partial Class SAL_SAL2_SAL2111
    Inherits BaseWebForm


#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Me.Page.IsPostBack Then
        '    Me.TextBox_orgid.Text = Me.LoginManager.UserData.v_ROLE_ORGID.ToString
        '    Me.TextBox_mid.Text = Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString
        '    Dim y As String = Now.ToString("yyyyMM")
        '    'Me.UcSaProj_proj_code.Orgid = Me.TextBox_orgid.Text
        '    'Me.UcSaProj_proj_code.LimitShowRole = "Y"
        '    'Me.UcSaProj_proj_code.Role = "006"

        '    Me.UcDateDropDownList_YM_Start.Kind = "YM"
        '    Me.UcDateDropDownList_YM_Start.year_s = CInt(Now.ToString("yyyy")) - 2
        '    Me.UcDateDropDownList_YM_Start.DateStr = y
        'End If

    End Sub

#End Region

    Protected Sub Button_report_Click(sender As Object, e As EventArgs) Handles Button_report.Click

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Type As String = ddlType.SelectedValue.ToString
        Dim Payo_ym As String = UcDate1.Year.ToString & UcDate1.Month.ToString()


        '取得資料
        Dim sapayo As New SAPAYO()

        Dim dt As DataTable = sapayo.GetDataByOption(Orgcode, Type, Payo_ym)


        '產報表
        export_report(dt)
    End Sub

    Sub export_report(ByVal dt As DataTable)
        'dtreport 報表



    End Sub
End Class
