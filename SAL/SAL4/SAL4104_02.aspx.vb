Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class SAL4104_02
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


    Protected Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim Jobtype As String = ddlJob_type.SelectedValue
        Dim Leveltype As String = ddlLevel_type.SelectedValue
        Dim L3 As String = txtL3.Text
        Dim L1 As String = txtL1.Text
        Dim securityid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_number) ' securityid
        Dim date1 As String = Date.Now.Year & Date.Now.Month & Date.Now.Day & Date.Now.Hour & Date.Now.Minute & Date.Now.Second

        Dim bll As New SAL4104()
        Dim dt As DataTable = New DataTable

        For Each s As String In securityid.Split(",")
            securityid = s
        Next

        If String.IsNullOrEmpty(Jobtype) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「官階」欄位為必填。")
            Return
        End If
        If String.IsNullOrEmpty(Leveltype) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「職等」欄位為必填。")
            Return
        End If
        If txtL3.Text.Length > 4 Or Not CommonFun.IsNum(txtL3.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「俸點」欄位為數字，請填寫!")
            Return
        End If
        If txtL1.Text.Length > 3 Or Not CommonFun.IsNum(txtL1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「年功俸」欄位為數字，請填寫!")
            Return
        End If

        Try
            If (bll.Insert(Jobtype, Leveltype, L3, L1, securityid, date1)) = True Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「新增成功」", "SAL4104_01.aspx")
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("SAL4104_01.aspx")
    End Sub
End Class
