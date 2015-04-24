Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class FSC1111_01
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        bind()
    End Sub

    Protected Sub bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

        Dim dt As DataTable = New SYS.Logic.PaperFile().GetData(Orgcode, departId.Substring(0, 2) & "0000")

        gvList.DataSource = dt
        gvList.DataBind()
    End Sub


    Protected Sub gvcbExample_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim path As String = CType(gvr.FindControl("gvhfPath"), HiddenField).Value
        Dim name As String = CType(gvr.FindControl("gvhfRealName"), HiddenField).Value
        Dim fileName As String = CType(gvr.FindControl("gvhfFileName"), HiddenField).Value

        Dim filepath As String = path & name
        Dim wc As System.Net.WebClient = New System.Net.WebClient()
        Dim b() As Byte = wc.DownloadData(filepath)

        Response.ContentType = "application/octet-stream"
        Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", Server.UrlEncode(fileName)))
        Response.BinaryWrite(b)
        Response.Flush()
        Response.End()
    End Sub
End Class
