Imports SYS.Logic
Imports System.Data

Partial Class MasterPage_MasterPage_old
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "unblockUI", "$.unblockUI();", True)

        If IsPostBack Then Return

        Dim dao As New FuncDAO
        Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        dao.MenuItem(Menu1, Nothing, "IGSS1000", 0, idCard)
        dao.MenuItem(Menu2, Nothing, "IGSS2000", 0, idCard)
        dao.MenuItem(Menu3, Nothing, "IGSS3000", 0, idCard)
        dao.MenuItem(Menu4, Nothing, "IGSS4000", 0, idCard)
        'dao.MenuItem(Menu5, Nothing, "IGSS5000", 0, idCard)
        'dao.MenuItem(Menu6, Nothing, "IGSS6000", 0, idCard)
        dao.MenuItem(Menu7, Nothing, "IGSS5000", 0, idCard)
        dao.MenuItem(Menu8, Nothing, "IGSS6000", 0, idCard)

        dao.MenuItem(Menu9, Nothing, "IGSS7000", 0, idCard)
        dao.MenuItem(Menu10, Nothing, "IGSS8000", 0, idCard)
        'dao.MenuItem(Menu11, Nothing, "FSC4000", 0, idCard)

        If Menu1.Items.Count <= 0 Then Menu1_table.Visible = False Else Menu1_table.Visible = True
        If Menu2.Items.Count <= 0 Then Menu2_table.Visible = False Else Menu2_table.Visible = True
        If Menu3.Items.Count <= 0 Then Menu3_table.Visible = False Else Menu3_table.Visible = True
        If Menu4.Items.Count <= 0 Then Menu4_table.Visible = False Else Menu4_table.Visible = True
        'If Menu5.Items.Count <= 0 Then Menu5_table.Visible = False Else Menu5_table.Visible = True
        'If Menu6.Items.Count <= 0 Then Menu6_table.Visible = False Else Menu6_table.Visible = True
        If Menu7.Items.Count <= 0 Then Menu5_table.Visible = False Else Menu5_table.Visible = True
        If Menu8.Items.Count <= 0 Then Menu6_table.Visible = False Else Menu6_table.Visible = True

        If Menu9.Items.Count <= 0 Then Menu7_table.Visible = False Else Menu7_table.Visible = True
        If Menu10.Items.Count <= 0 Then Menu8_table.Visible = False Else Menu8_table.Visible = True
        'If Menu11.Items.Count <= 0 Then Menu11_table.Visible = False Else Menu11_table.Visible = True

        UcUsePDF.UrlName = System.IO.Path.GetFileName(Request.PhysicalPath)
        checkFreeze()
    End Sub

    Protected Sub ibOpen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("Menu") = "open"
    End Sub

    Protected Sub ibClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("Menu") = "close"
    End Sub

    Protected Sub checkFreeze()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim aryPageName As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
        Dim strProgramName As String = aryPageName(aryPageName.Length - 1)

        Dim ff As SYS.Logic.FreezeFunc = New SYS.Logic.FreezeFunc
        Dim dt As DataTable = ff.getFreezeData(Orgcode, Depart_id, strProgramName)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, dt.Rows(0)("Func_name").ToString() + "作業功能已鎖定，不開放使用。", "../../FSC/FSC0/FSC0101_01.aspx")
        End If
    End Sub
End Class

