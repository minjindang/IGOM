Imports System.Data

Partial Class UControl_UcAttach
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Flow_id() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(ByVal value As String)
            hfFlowId.Value = value
            Bind()
        End Set
    End Property
#End Region

    Protected Sub lbLook_Click(sender As Object, e As EventArgs)
        Bind()
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub Bind()
        Dim Flow_id As String = hfFlowId.Value
        If String.IsNullOrEmpty(Flow_id) Then Return
        Dim dt As DataTable = New SYS.Logic.Attachment().GetAttachByFlowId(Flow_id)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvAtt.DataSource = dt
            gvAtt.DataBind()

            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), Flow_id)
            If f.LastPass <> "1" And f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card) Then
                gvAtt.Columns(2).Visible = True
            End If

            table.Visible = True
        Else
            lbLook.Text = ""
            table.Visible = False
        End If
    End Sub

    Protected Sub gv_lbtnAttachFile_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim Flow_id As String = hfFlowId.Value

        Dim file_name As String = CType(gvr.FindControl("gv_lbtnAttachFile"), LinkButton).Text
        Dim real_name As String = CType(gvr.FindControl("gv_hdfileRealName"), HiddenField).Value

        Dim filepath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & "/" & real_name
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim file As New System.IO.FileInfo(filepath)
        If file.Exists Then
            Response.ContentType = "application/octet-stream"
            Dim a() As Byte = wc.DownloadData(filepath)
            'Dim FileName As String = System.IO.Path.GetFileName(filepath)
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(file_name)))
            Response.BinaryWrite(a)
            Response.Flush()
            Response.End()
        End If
    End Sub

    Protected Sub gv_lcbDel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim attName As String = CType(gvr.FindControl("gv_hdfileRealName"), HiddenField).Value
        Dim attPath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & "/" & attName
        Dim Id As String = CType(gvr.FindControl("gv_hfId"), HiddenField).Value
        Dim att As New SYS.Logic.Attachment()

        If att.DeleteAttachById(Id) Then
            CommonFun.DeleteFile(attPath)
        Else
            'Throw New FlowException("刪除附件失敗!")
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "刪除附件失敗!")
        End If

        Bind()
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
    End Sub

End Class
