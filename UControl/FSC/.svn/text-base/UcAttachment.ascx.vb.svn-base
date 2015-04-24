Imports System.Data

Partial Class UControl_FSC_UcAttachment
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Return

        Dim dt As DataTable = New DataTable
        dt.Columns.Add("id")
        ViewState("dt") = dt
    End Sub

    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(ByVal value As String)
            hfFlowId.Value = value
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

                BindUploadFile(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), hfFlowId.Value)

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
                BindUploadFile(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), hfFlowId.Value)
            End If
        End Set
    End Property

    Public Sub SaveFile()
        'Dim att As New SYS.Logic.Attachment()

        'If Not att.SaveFile(fuFile1, hfFlowId.Value) Then
        '    Throw New FlowException("新增附件1失敗!")
        'End If
        'If Not att.SaveFile(fuFile2, hfFlowId.Value) Then
        '    Throw New FlowException("新增附件2失敗!")
        'End If
        'If Not att.SaveFile(fuFile3, hfFlowId.Value) Then
        '    Throw New FlowException("新增附件3失敗!")
        'End If

        Dim tmpFolder As String = ViewState("tmpFolder")
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        For Each dr As DataRow In dt.Rows
            Dim att As New SYS.Logic.Attachment()
            att = att.GetObjectById(dr("id"))
            att.Id = dr("id").ToString()
            att.CopyFile(hfFlowId.Value, tmpFolder)
        Next
    End Sub

    Public Sub BindUploadFile(orgcode As String, flowId As String)
        If String.IsNullOrEmpty(flowId) Then Return
        hfFlowId.Value = flowId
        hfOrgcode.Value = orgcode
        Dim dt As DataTable = New SYS.Logic.Attachment().GetAttachByFlowId(flowId)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            gvAtt.DataSource = dt
            gvAtt.DataBind()
            gvAtt.Visible = True
        Else
            gvAtt.Visible = False
        End If
    End Sub

    Protected Sub BindAtt()
        Dim adt As DataTable = New DataTable
        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        For Each dr As DataRow In dt.Rows
            Dim att As New SYS.Logic.Attachment()
            att.Id = dr("id")

            Dim tmp As DataTable = att.getDataByid()
            adt.Merge(tmp)
        Next
        ViewState("dt") = adt
        gvAtt.DataSource = adt
        gvAtt.DataBind()
        gvAtt.Visible = True
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

        If String.IsNullOrEmpty(hfFlowId.Value) Then
            BindAtt()
        Else
            BindUploadFile(hfOrgcode.Value, hfFlowId.Value)
        End If
    End Sub

    Protected Sub gv_lbtnAttachFile_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, LinkButton).NamingContainer
        Dim Flow_id As String = hfFlowId.Value
        Dim attName As String = CType(gvr.FindControl("gv_hdfileRealName"), HiddenField).Value
        Dim attPath As String = CType(gvr.FindControl("gv_hdfilePath"), HiddenField).Value.Replace("\", "/") & "/" & attName
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim a() As Byte = wc.DownloadData(attPath)
        Dim FileName As String = System.IO.Path.GetFileName(attPath)
        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(FileName)))
        Response.BinaryWrite(a)
        Response.Flush()
        Response.End()
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim att As New SYS.Logic.Attachment()

        Dim tmpFolder As String = ViewState("tmpFolder")
        If String.IsNullOrEmpty(tmpFolder) Then
            tmpFolder = Guid.NewGuid.ToString()
            ViewState("tmpFolder") = tmpFolder
        End If

        Try
            Dim dt As DataTable = CType(ViewState("dt"), DataTable)
            Dim dr As DataRow = dt.NewRow
            dr("id") = att.SaveTempFile(fuFile1, tmpFolder)
            dt.Rows.Add(dr)
            ViewState("dt") = dt

            BindAtt()
        Catch fex As FlowException
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, fex.Message)
        Catch ex As Exception
            'Throw New FlowException("新增附件失敗!")
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "新增附件失敗!")
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub
End Class
