Imports System.Data

Partial Class UControl_SYS_UcAttachUploadButton
    Inherits System.Web.UI.UserControl
    Public Event FileUploaded(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(ByVal value As String)
            hfFlowId.Value = value
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


    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim att As New SYS.Logic.Attachment()
        Try
            att.SaveFile(fuFile1, hfFlowId.Value)

            btnQuery_ModalPopupExtender.Hide()

            RaiseEvent FileUploaded(sender, e)
        Catch fex As FlowException
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, fex.Message)
        End Try
    End Sub


    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
    End Sub
End Class
