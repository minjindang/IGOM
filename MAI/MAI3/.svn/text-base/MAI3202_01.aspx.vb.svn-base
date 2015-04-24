Imports System.Data

Imports FSCPLM.Logic

Partial Class MAI_MAI3_MAI3202_01
    Inherits BaseWebForm

    Dim dao As New MAI3202

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            lblFlow_id.Text = Page.Request.QueryString("flow_id")
            If Not String.IsNullOrEmpty(lblFlow_id.Text) Then
                Bind()
            End If
        End If

    End Sub

    Private Sub Bind()
        Dim detDT As DataTable = Nothing
        Dim mainDR As DataRow = Nothing
        dao.GetBy(lblFlow_id.Text, detDT, mainDR)
        GridViewA.DataSource = detDT
        GridViewA.DataBind()

        lblPhone_nos.Text = CommonFun.SetDataRow(mainDR, "Phone_nos")
        lblUnit_code.Text = CommonFun.SetDataRow(mainDR, "Unit_code")
        lblUser_name.Text = CommonFun.SetDataRow(mainDR, "User_name")
        lblApplyTime.Text = CommonFun.getYYYMMDD(CommonFun.SetDataRow(mainDR, "ApplyTime"))
        ' lblMtStartTime.Text = CommonFun.getYYYMMDD(CommonFun.SetDataRow(mainDR, "MtStartTime "))

    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click

        Dim detDT As New DataTable
        detDT.Columns.Add(New DataColumn("Flow_id"))
        detDT.Columns.Add(New DataColumn("OrgCode"))
        detDT.Columns.Add(New DataColumn("MtClassType"))
        detDT.Columns.Add(New DataColumn("Satisfaction_type"))

        For Each gr As GridViewRow In GridViewA.Rows
            Dim hfMtClass_type As HiddenField = gr.FindControl("hfMtClass_type")
            Dim ucSatisfaction_type As uc_ucSaCode = gr.FindControl("ucSatisfaction_type")
            Dim dr As DataRow = detDT.NewRow()
            dr("Flow_id") = Me.lblFlow_id.Text
            dr("OrgCode") = LoginManager.OrgCode
            dr("MtClassType") = hfMtClass_type.Value
            dr("Satisfaction_type") = ucSatisfaction_type.Code_no
            detDT.Rows.Add(dr)
        Next
        dao.Done(detDT)
        Response.Redirect("~/FSC1/FSC11/FSC1101_01.aspx")
    End Sub

End Class
