Imports System.Data
Imports SAL.Logic

Partial Class SAL_SAL2_SAL2214_01
    Inherits BaseWebForm

#Region " PageLoad"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack Then
            Bind()
        End If
    End Sub

    Protected Sub Bind()
        Dim strYear As String = Me.UcROCYear.Year
        If "" = strYear Then
            strYear = CommonFun.getYYYMMDD().Substring(0, 3)
        End If
        Dim bll As New SAL2214()
        Dim dt As DataTable = bll.getData(strYear, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
        Me.gvList.DataSource = dt
        Me.gvList.DataBind()
    End Sub

#End Region

#Region " Button"
    Protected Sub Button_search_Click(sender As Object, e As System.EventArgs) Handles Button_search.Click
        Bind()
    End Sub
#End Region


End Class
