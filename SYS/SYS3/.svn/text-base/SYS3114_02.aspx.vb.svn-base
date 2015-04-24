Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3114_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        ddlphrases_kind_Bind()
        ddlphrases_type_Bind()
        bind()
    End Sub

    Protected Sub ddlphrases_kind_Bind()
        Dim c As CODE = New CODE()
        ddlphrases_kind.DataSource = c.GetData("024", "**")
        ddlphrases_kind.DataBind()
        ddlphrases_kind.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlphrases_type_Bind()
        Dim c As CODE = New CODE()
        ddlphrases_type.DataSource = c.GetData("024", ddlphrases_kind.SelectedValue)
        ddlphrases_type.DataBind()
        ddlphrases_type.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlphrases_kind_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlphrases_kind.SelectedIndexChanged
        ddlphrases_type_Bind()
    End Sub

    Protected Sub bind()
        Dim id As String = Request.QueryString("id")
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        Dim cp As CommonPhrases = New CommonPhrases

        Try
            cp.id = id
            Dim dt As DataTable = cp.getDataByid()

            For Each dr As DataRow In dt.Rows
                ddlphrases_kind.SelectedValue = dr("phrases_kind").ToString()
                ddlphrases_type_Bind()
                ddlphrases_type.SelectedValue = dr("phrases_type").ToString()
                tbphrases.Text = dr("Phrases").ToString()
                ddlvisable_flag.SelectedValue = dr("visable_flag").ToString()
            Next

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim id As String = Request.QueryString("id")

        If String.IsNullOrEmpty(ddlphrases_kind.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇申請種類!")
            Return
        End If
        If String.IsNullOrEmpty(ddlphrases_type.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇申請項目!")
            Return
        End If
        If String.IsNullOrEmpty(tbphrases.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入常用片語!")
            Return
        End If

        Dim isAdd As Boolean = False
        If String.IsNullOrEmpty(id) Then
            isAdd = True
        End If

        Try
            Dim cp As CommonPhrases = New CommonPhrases
            cp.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            cp.phrases_kind = ddlphrases_kind.SelectedValue
            cp.phrases_type = ddlphrases_type.SelectedValue
            cp.phrases = tbphrases.Text.Trim()
            cp.visable_flag = ddlvisable_flag.SelectedValue
            cp.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            If isAdd Then
                cp.insert()
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "SYS3114_01.aspx")
            Else
                cp.id = id
                cp.update()
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "SYS3114_01.aspx")
            End If

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("SYS3114_01.aspx")
    End Sub
End Class
