Imports System.Data
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3119_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        bind()
    End Sub

    Protected Sub bind()
        Dim orgcode As String = Request.QueryString("org")


        Dim dt As DataTable = New SYS.Logic.Org().GetDataByQuery(orgcode, "")
        For Each dr As DataRow In dt.Rows
            tbOrgcode.Text = dr("Orgcode").ToString()
            tbOrgcode_name.Text = dr("Orgcode_name").ToString()
            tbOrgcode_shortname.Text = dr("Orgcode_shortname").ToString()
        Next

    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("SYS3119_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim orgcode As String = Request.QueryString("org")

        Try
            Dim org As New SYS.Logic.Org()
            org.Orgcode = tbOrgcode.Text.Trim()
            org.OrgcodeName = tbOrgcode_name.Text.Trim()
            org.OrgcodeShortname = tbOrgcode_shortname.Text.Trim()
            org.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            org.LogoFile = fuLogo.FileName

            If fuLogo.HasFile Then
                fuLogo.SaveAs(Server.MapPath("~/images/Logos/") & fuLogo.FileName)
            End If

            Dim dt As DataTable = org.GetDataByQuery(org.Orgcode, "")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有相同機關代碼!")
                Return
            End If


            Using trans As New TransactionScope()
                If String.IsNullOrEmpty(orgcode) Then
                    org.insertData()
                    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "SYS3119_01.aspx")
                Else
                    org.updateData(orgcode)
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "SYS3119_01.aspx")
                End If
                trans.Complete()
            End Using
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
