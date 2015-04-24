Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_SYS_UcDDLForm
    Inherits System.Web.UI.UserControl

    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(value As String)
            hfOrgcode.Value = value
            BindType()
            BindFormId()
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            If Not String.IsNullOrEmpty(ddlForm.SelectedValue) Then
                Return ddlForm.SelectedValue
            End If
            Return ddlCodeType.SelectedValue
        End Get
        Set(value As String)
            BindType()
            If Not String.IsNullOrEmpty(value) Then
                ddlCodeType.SelectedValue = value.Substring(0, 3)
            End If
            BindFormId()
            If Not String.IsNullOrEmpty(value) Then
                ddlForm.SelectedValue = value
            End If
        End Set
    End Property

    Public Property Enabled() As String
        Get
            Return ddlForm.Enabled
        End Get
        Set(value As String)
            ddlCodeType.Enabled = value
            ddlForm.Enabled = value
        End Set
    End Property

    Protected Sub BindType()
        Dim saCode As New SACode()
        Dim saCodedt As DataTable = saCode.GetData2("024", "P", "**")
        saCodedt.DefaultView.Sort = "code_no"
        ddlCodeType.DataSource = saCodedt.DefaultView
        ddlCodeType.DataBind()
        ddlCodeType.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindFormId()
        Dim orgcode As String = hfOrgcode.Value
        Dim codeType As String = ddlCodeType.SelectedValue

        Dim saCode As New SACode()
        Dim saCodedt As DataTable = saCode.GetData2("024", "P", codeType)

        Dim dt As New DataTable()
        dt.Columns.Add("formName")
        dt.Columns.Add("formId")

        Dim leaveType As New SYS.Logic.LeaveType()
        For Each saCodedr As DataRow In saCodedt.Rows
            Dim dr As DataRow = dt.NewRow
            dr("formId") = codeType & saCodedr("code_no")       ' formId : code_type + code_no
            dr("formName") = saCodedr("code_desc1")
            dt.Rows.Add(dr)
        Next
        ddlForm.DataSource = dt
        ddlForm.DataBind()
        ddlForm.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlCodeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCodeType.SelectedIndexChanged
        BindFormId()
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub ddlForm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlForm.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
End Class
