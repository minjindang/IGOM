Imports FSC.Logic
Imports SAL.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel


Partial Class SAL4104_03
    Inherits BaseWebForm
    Dim OrgType As String = System.Configuration.ConfigurationManager.AppSettings("OrgType")
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '有這行才會load進UcDDLDepart
    Dim securityid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_number) ' securityid
    Dim date1 As String = Date.Now.Year & Date.Now.Month & Date.Now.Day & Date.Now.Hour & Date.Now.Minute & Date.Now.Second

    Dim bll As New SAL4104()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub

    Protected Sub InitControl()
        Dim lbL3 As String = Request.QueryString("lbL3")
        Dim lbL1 As String = Request.QueryString("lbL1")
        Dim lbPTB As String = Request.QueryString("lbPTB")
        Dim lbL2 As String = Request.QueryString("lbL2")
        Dim dt As DataTable = New DataTable
        'dt = bll.getQueryData("", "", orgcode, LEVCOM_MDATE)

        ddlJob_type.Text = lbL3
        ddlLevel_type.Text = lbL1
        txtL3.Text = lbPTB
        txtL1.Text = lbL2
    End Sub

    Protected Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim Jobtype As String = ddlJob_type.Text
        Dim Leveltype As String = ddlLevel_type.Text
        Dim lbL3 As String = Request.QueryString("lbPTB")
        Dim lbL1 As String = Request.QueryString("lbL2")
        Dim newL3 As String = txtL3.Text
        Dim newL1 As String = txtL1.Text
        Try
            If (bll.Update(Jobtype, Leveltype, lbL3, lbL1, securityid, date1, newL3, newL1)) = True Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「修改成功」", "SAL4104_01.aspx")
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
