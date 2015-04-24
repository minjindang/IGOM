Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient

Partial Class FSC0101_08
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()

        gv.DataSource = bll.GetPropertyTranData(Orgcode, flowId)
        gv.databind()

        UcFlowDetail.Orgcode = Orgcode
        UcFlowDetail.FlowId = flowId

    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Response.Redirect(ViewState("BackUrl"))
    End Sub
End Class
