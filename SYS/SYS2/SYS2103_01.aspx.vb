Imports System
Imports System.Data
Imports FSCPLM.Logic
Imports SYS.Logic

Partial Class SYS2103_01
    Inherits BaseWebForm

    Dim dtData As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

#Region "下拉式選單"
    Protected Sub InitControl()
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)

        UcDDLDepart.orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMMdd") 'Date of Today 
        'UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")

        UserName_Bind()
    End Sub

#End Region
    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UserName_Bind()
    End Sub

    Private Sub UserName_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim idcard As String = UcDDLMember.SelectedValue
        Dim Start_date As Integer = UcDate1.Text
        'Dim End_date As String = CommonFun.getInt(UcDate2.Text)

        Dim bll As New SYS2103()
        Dim dt As DataTable
        'Dim syear As Integer = Left(Start_date, 3) + 1911
        'Dim smonth As Integer = Right(Left(Start_date, 5), 2)
        'Dim sday As Integer = Right(Start_date, 2)
        'Dim eyear As Integer = Left(End_date, 3) + 1911
        'Dim emonth As Integer = Right(Left(End_date, 5), 2)
        'Dim eday As Integer = Right(End_date, 2)
        Start_date = Start_date + 19110000

        If String.IsNullOrEmpty(idcard) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「員工姓名」必須選擇")
            Return
        End If

        Try
            dt = bll.getQueryData(idcard, Start_date)

            tbq.Visible = True 'feedback query result 
            ViewState("dt") = dt
            Me.gvList.DataSource = dt
            Me.gvList.DataBind()
            dt.Dispose()


        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

End Class
