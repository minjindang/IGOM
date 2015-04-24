Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT4102_01
    Inherits BaseWebForm
    Dim MaterialClass_idTbInsert As String = ""
    Dim MaterialClass_nameTbInsert As String = ""
    Dim MaterialClass_idTbMaterial As String = ""
    Dim MaterialClass_nameMaterial As String = ""
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("MaterialClass_idTbInsert"))) And Not String.IsNullOrEmpty(Server.HtmlEncode(Request("MaterialClass_nameTbInsert"))) Then
                MaterialClass_idTbInsert = Server.HtmlEncode(Request("MaterialClass_idTbInsert").ToString())
                MaterialClass_nameTbInsert = Server.HtmlEncode(Request("MaterialClass_nameTbInsert").ToString())
                InsertAndMaterial_Select(MaterialClass_idTbInsert, MaterialClass_nameTbInsert)
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增成功")
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("MaterialClass_idTbMaterial"))) And Not String.IsNullOrEmpty(Server.HtmlEncode(Request("MaterialClass_nameMaterial"))) Then
                MaterialClass_idTbMaterial = Server.HtmlEncode(Request("MaterialClass_idTbMaterial").ToString())
                MaterialClass_nameMaterial = Server.HtmlEncode(Request("MaterialClass_nameMaterial").ToString())
                InsertAndMaterial_Select(MaterialClass_idTbMaterial, MaterialClass_nameMaterial)
                If Not Server.HtmlEncode(Request("flag")) = 1 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改成功")
                End If
            End If
        End If
    End Sub
#End Region
    Protected Sub GridView_SaTEL_RowCommand(ByVal sender As Object, _
        ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        If e.CommandName = "remove" Then '觸發刪除功能
            Dim db As New DataTable
            Dim Selectdb As New DataTable
            Dim mc As Material_main = New Material_main()
            Dim md As MaterialClass_data = New MaterialClass_data()
            Dim memo As String = ""
            Dim Index As String = Server.HtmlEncode(e.CommandArgument)
            memo = mc.MAT1105SelectData(Index)
            If memo = False Then '不可刪除
                Status.Text = "此分類號已使用於物料基本資料，不可刪除。"
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Status.Text)
            ElseIf memo Then '可刪除
                Index = Server.HtmlEncode(e.CommandArgument)
                db = md.DeleteData(Index, Server.HtmlEncode(MaterialClass_idTb.Text), Server.HtmlEncode(MaterialClass_nameTb.Text), orgcode)
                Me.GridViewA.DataSource = db
                Me.GridViewA.DataBind()
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "刪除成功")
                Me.div1.Visible = True
            End If
        ElseIf e.CommandName = "editor" Then '觸發維護按鈕
            Dim tb1 As String = Server.HtmlEncode(e.CommandArgument)
            'Dim tb1 As String = Server.HtmlEncode(MaterialClass_nameTb.Text)
            Response.Redirect("~/MAT/MAT4/MAT4102_03.aspx?tb1=" + tb1 + "")
        End If
    End Sub

#Region " InsertBtn_Click"
    Protected Sub InsertBtn_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/MAT/MAT4/MAT4102_02.aspx")
    End Sub
#End Region
#Region " SelectBtn_Click"
    Protected Sub SelectBtn_Click(sender As Object, e As EventArgs)
        Dim db As New DataTable
        Dim mc As MaterialClass_data = New MaterialClass_data()
        If Not CommonFun.IsNum(MaterialClass_idTb.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「分類編號」欄位為數字。")
            Return
        End If
        'If String.IsNullOrEmpty(MaterialClass_nameTb.Text) Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "「物料分類名稱」欄位為必填。")
        '    Return
        'End If
        db = mc.SelectData(Server.HtmlEncode(MaterialClass_idTb.Text), Server.HtmlEncode(MaterialClass_nameTb.Text), orgcode)
        Status.Text = Server.HtmlEncode(db.Rows.Count.ToString)
        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        Me.div1.Visible = True
    End Sub
#End Region
#Region " ResetBtn_Click"
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        MaterialClass_idTb.Text = ""
        MaterialClass_nameTb.Text = ""
        Me.div1.Visible = False
    End Sub
#End Region
#Region " InsertAndMaterial_Select"
    Protected Sub InsertAndMaterial_Select(ByVal MaterialClass_idTbInsert As String, ByVal MaterialClass_nameTbInsert As String)
        Dim db As New DataTable
        Dim mc As MaterialClass_data = New MaterialClass_data()
        MaterialClass_idTb.Text = MaterialClass_idTbInsert
        MaterialClass_nameTb.Text = MaterialClass_nameTbInsert
        db = mc.SelectData(MaterialClass_idTbInsert, MaterialClass_nameTbInsert, orgcode)
        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        Me.div1.Visible = True
    End Sub
#End Region
End Class


