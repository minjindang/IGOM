Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient

Partial Class FSC0101_07
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bind()
        End If
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fid")
        Dim Orgcode As String = Request.QueryString("org")
        Dim bll As New FSC.Logic.FSC0101()
        Dim code As New SACode()
        'Dim dt As DataTable = bll.GetPropertyDataNew(Orgcode, flowId)
        Dim dt As DataTable = bll.GetPropertyDataNew(Orgcode, flowId)

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()

        UcFlowDetail.Orgcode = Orgcode
        UcFlowDetail.FlowId = flowId

    End Sub

    Protected Sub cbBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Response.Redirect(ViewState("BackUrl"))
    End Sub
End Class
