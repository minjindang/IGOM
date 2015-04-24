Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT4102_03
    Inherits BaseWebForm
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim flag As String = 0
#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            MaterialClass_idTb.Text = Server.HtmlEncode(Request("tb1"))
            Dim db As New DataTable
            Dim mc As MaterialClass_data = New MaterialClass_data()
            db = mc.SelectData(Server.HtmlEncode(MaterialClass_idTb.Text), "", orgcode)
            Status.Text = Server.HtmlEncode(db.Rows.Count.ToString)
            Me.GridViewA.DataSource = db
            Me.GridViewA.DataBind()
            MaterialClass_nameTb.Text = Server.HtmlEncode(CType(GridViewA.Rows(0).FindControl("Label_tabid"), Label).Text)
        End If
    End Sub
#End Region
#Region " ConfirmBtn_Click"
    Protected Sub ConfirmBtn_Click(sender As Object, e As EventArgs) Handles ConfirmBtn.Click
        If String.IsNullOrEmpty(MaterialClass_nameTb.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入物料分類名稱!")
            Return
        End If

        Dim SelectOrgcode As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
        Dim SelectDepart_id As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id))
        Dim SelectId_card As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        Dim mbdt As DataTable = New FSC.Logic.Personnel().GetDataByQuery(SelectOrgcode, SelectDepart_id, "", SelectId_card)
        Dim mbdr As DataRow = mbdt.Rows(0)
        If Server.HtmlEncode(MaterialClass_idTb.Text) <> "" And Server.HtmlEncode(MaterialClass_nameTb.Text) <> "" Then
            Dim Next_id As String = Server.HtmlEncode(mbdr("id_card").ToString())
            Dim Next_date As Date = Date.Now
            Dim Org_code As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
            Dim db As New DataTable
            Dim md As MaterialClass_data = New MaterialClass_data()
            Dim memo As String = ""
            Dim Index As String = Server.HtmlEncode(MaterialClass_idTb.Text)
            memo = Server.HtmlEncode(md.MaintainData(Index, Server.HtmlEncode(MaterialClass_nameTb.Text), Next_id, Next_date, Org_code))
            Status.Text = memo
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Server.HtmlEncode(Status.Text))
            If memo = "修改成功" Then
                SelectBtn_Click(Index, MaterialClass_nameTb.Text)
            Else
                Me.div1.Visible = False
            End If
        ElseIf Server.HtmlEncode(MaterialClass_idTb.Text) = "" Or Server.HtmlEncode(MaterialClass_nameTb.Text) = "" Then
            Status.Text = "欄位輸入不完整"
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Server.HtmlEncode(Status.Text))
        End If
    End Sub
#End Region
#Region "SelectBtn_Click"
    Protected Sub SelectBtn_Click(ByVal MaterialClass_idTbMaterial As String, ByVal MaterialClass_nameMaterial As String)
        Response.Redirect("~/MAT/MAT4/MAT4102_01.aspx?MaterialClass_idTbMaterial=" + MaterialClass_idTbMaterial + "&MaterialClass_nameMaterial=" + MaterialClass_nameMaterial)
    End Sub
#End Region
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        MaterialClass_nameTb.Text = Server.HtmlEncode(CType(GridViewA.Rows(0).FindControl("Label_tabid"), Label).Text)
    End Sub
    Protected Sub back()
        Dim idTbMaterial = Server.HtmlEncode(Request("tb1"))
        Dim nameMaterial = Server.HtmlEncode(CType(GridViewA.Rows(0).FindControl("Label_tabid"), Label).Text)
        flag = "1"
        Response.Redirect("~/MAT/MAT4/MAT4102_01.aspx?MaterialClass_idTbMaterial=" + idTbMaterial + "&MaterialClass_nameMaterial=" + nameMaterial + "&flag=" + flag)
    End Sub
End Class


