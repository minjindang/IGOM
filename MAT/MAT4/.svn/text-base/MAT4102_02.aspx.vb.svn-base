Imports System.Data
Imports FSCPLM.Logic

Partial Class MAT4102_02
    Inherits BaseWebForm
    Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
#End Region
#Region " ConfirmBtn_Click"
    Protected Sub ConfirmBtn_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(MaterialClass_idTb.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入分類編號!")
            Return
        End If
        If Not CommonFun.IsNum(MaterialClass_idTb.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "分類編號請輸入數字!")
            Return
        End If
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
            memo = md.InsertGetData(Index, Server.HtmlEncode(MaterialClass_nameTb.Text), Next_id, Next_date, Org_code)
            Status.Text = memo
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Server.HtmlEncode(Status.Text))
            If memo = "新增成功" Then
                SelectBtn_Click(Index, Server.HtmlEncode(MaterialClass_nameTb.Text))
            Else
                Me.div1.Visible = False
            End If
        ElseIf Server.HtmlEncode(MaterialClass_idTb.Text) = "" Or Server.HtmlEncode(MaterialClass_nameTb.Text) = "" Then
            Status.Text = "欄位輸入不完整"
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Server.HtmlEncode(Status.Text))
        End If
    End Sub
#End Region
#Region " SelectBtn_Click"
    Protected Sub SelectBtn_Click(ByVal Index As String, ByVal MaterialClass_nameTb As String)
        Response.Redirect("~/MAT/MAT4/MAT4102_01.aspx?MaterialClass_idTbInsert=" + Index + "&MaterialClass_nameTbInsert=" + MaterialClass_nameTb)
    End Sub
#End Region
    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs)
        MaterialClass_idTb.Text = ""
        MaterialClass_nameTb.Text = ""
    End Sub

End Class


