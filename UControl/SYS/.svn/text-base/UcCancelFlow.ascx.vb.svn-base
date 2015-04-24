Imports System.Data

Partial Class UControl_UcCancelFlow
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property Text() As String
        Get
            Return UcTextBox.Text
        End Get
        Set(ByVal value As String)
            UcTextBox.Text = value
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
        End Set
    End Property

    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(value As String)
            hfFlowId.Value = value
            SetAuthority()
        End Set
    End Property

    Protected Sub SetAuthority()
        Dim f As New SYS.Logic.Flow()
        Dim dt As DataTable = f.GetDataByCancelFlowid(Orgcode, FlowId)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            If dt.Rows(0)("Last_pass").ToString() <> "1" Then
                cb.Enabled = False
            End If
        End If

        f = f.GetObject(Orgcode, FlowId)
        If Not String.IsNullOrEmpty(f.CancelFlowid) Then
            cb.Enabled = False
        End If
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        RaiseEvent Click(sender, e)
    End Sub
End Class
