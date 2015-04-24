Imports System.Data
Imports System.Transactions

Partial Class UControl_MAI_UcAttachment
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Return

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("id")
        ViewState("dt") = dt
    End Sub

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
        Set(ByVal value As String)
            hfFlowId.Value = value
        End Set
    End Property

    Public Property MainId() As String
        Get
            Return hfMainId.Value
        End Get
        Set(ByVal value As String)
            hfMainId.Value = value
        End Set
    End Property

    Public Property isUpload() As Boolean
        Get
            Return isUpload
        End Get
        Set(ByVal value As Boolean)
            If Not value Then
                div11.Visible = False
                div2.Visible = False

                BindUploadFile(hfOrgcode.Value, hfFlowId.Value)

                If gvAtt.Rows.Count > 0 Then
                    gvAtt.Columns(0).Visible = False
                    gvAtt.Columns(2).Visible = False
                    gvAtt.HeaderRow.Visible = False
                End If
            End If
        End Set
    End Property

    Public Property isBind() As Boolean
        Get
            Return isUpload
        End Get
        Set(ByVal value As Boolean)
            If value Then
                BindUploadFile(hfOrgcode.Value, hfFlowId.Value)
            End If
        End Set
    End Property


    Public Sub BindUploadFile(orgcode As String, flowId As String)
        If String.IsNullOrEmpty(flowId) Then Return

        Dim dt As DataTable = New MAI.Logic.Attachment().GetAttachByFlowId(flowId)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvAtt.DataSource = dt
            gvAtt.DataBind()
            gvAtt.Visible = True
        Else
            gvAtt.Visible = False
        End If
    End Sub


    Protected Sub gv_lcbDel_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim attName As String = CType(gvr.FindControl("gv_hdfileRealName"), HiddenField).Value
        Dim attPath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & attName
        Dim Id As String = CType(gvr.FindControl("gv_hfId"), HiddenField).Value
        Dim att As New MAI.Logic.Attachment()

        Try
            Using scope As New TransactionScope
                If att.DeleteAttachById(Id) AndAlso CommonFun.DeleteFile(attPath) Then

                Else
                    Throw New FlowException("刪除附件失敗!")
                End If

                scope.Complete()
            End Using

            BindUploadFile(hfOrgcode.Value, hfFlowId.Value)

        Catch ex As FlowException
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

    Protected Sub gv_lbtnAttachFile_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim Flow_id As String = hfFlowId.Value
        Dim attName As String = CType(gvr.FindControl("gv_hdfileRealName"), HiddenField).Value
        Dim attPath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & "/" & attName
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim a() As Byte = wc.DownloadData(attPath)
        Dim FileName As String = CType(gvr.FindControl("gv_lbtnAttachFile"), LinkButton).Text
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(FileName)))
        Response.BinaryWrite(a)
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim att As New MAI.Logic.Attachment()

        att.Orgcode = hfOrgcode.Value
        att.Flow_id = hfFlowId.Value
        att.Main_id = hfMainId.Value

        Try
            Dim dt As DataTable = CType(ViewState("dt"), DataTable)
            Dim dr As DataRow = dt.NewRow

            att.SaveFile(fuFile1)
            
            BindUploadFile(hfOrgcode.Value, hfFlowId.Value)
        Catch ex As Exception
            Throw New FlowException("新增附件失敗!")
        End Try
    End Sub
End Class
