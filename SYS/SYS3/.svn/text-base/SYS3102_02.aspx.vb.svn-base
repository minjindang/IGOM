Imports System.Data
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3102_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        bind()
    End Sub

    Protected Sub bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = Request.QueryString("d")

        If String.IsNullOrEmpty(depart_id) Then
            Return
        End If

        Dim dt As DataTable = New EMP.Logic.Org().getDataByDid(orgcode, depart_id)
        For Each dr As DataRow In dt.Rows
            tbOrgcode.Text = dr("Orgcode").ToString()
            tbOrgcode_name.Text = dr("Orgcode_name").ToString()
            tbOrgcode_shortname.Text = dr("Orgcode_shortname").ToString()
            tbDepart_id.Text = dr("Depart_id").ToString()
            tbDepart_name.Text = dr("Depart_name").ToString()
            tbParent_Depart_id.Text = dr("Parent_Depart_id").ToString()
            tbSeq.Text = dr("Seq").ToString()
            ddlVisable_flag.SelectedValue = dr("Visable_flag").ToString()
            ddlDepart_Level.SelectedValue = dr("Depart_Level").ToString()
            tbChangeCode.Text = dr("ChangeCode").ToString()
        Next

    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("SYS3102_01.aspx")
    End Sub

    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click

        Try
            Dim iSeq As Integer = Integer.Parse(Me.tbSeq.Text)
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "【排序】請輸入數字。")
            Return
        End Try

        If Not String.IsNullOrEmpty(tbChangeCode.Text.Trim) AndAlso Not CommonFun.IsNum(tbChangeCode.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "【銀行轉換代號】請輸入數字。")
            Return
        End If

        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim depart_id As String = Request.QueryString("d")

        Try
            Dim eo As New EMP.Logic.Org()
            eo.Orgcode = tbOrgcode.Text.Trim()
            eo.OrgcodeName = tbOrgcode_name.Text.Trim()
            eo.OrgcodeShortname = tbOrgcode_shortname.Text.Trim()
            eo.DepartId = tbDepart_id.Text.Trim()
            eo.DepartName = tbDepart_name.Text.Trim()
            eo.ParentDepartId = tbParent_Depart_id.Text.Trim()
            eo.Seq = IIf(String.IsNullOrEmpty(tbSeq.Text.Trim()), Nothing, tbSeq.Text.Trim())
            eo.VisableFlag = ddlVisable_flag.SelectedValue()
            eo.DepartLevel = ddlDepart_Level.SelectedValue
            eo.ChangeCode = tbChangeCode.Text.Trim()
            eo.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Dim fo As New FSC.Logic.Org()
            fo.Orgcode = tbOrgcode.Text.Trim()
            fo.OrgcodeName = tbOrgcode_name.Text.Trim()
            fo.OrgcodeShortname = tbOrgcode_shortname.Text.Trim()
            fo.DepartId = tbDepart_id.Text.Trim()
            fo.DepartName = tbDepart_name.Text.Trim()
            fo.ParentDepartId = tbParent_Depart_id.Text.Trim()
            fo.Seq = IIf(String.IsNullOrEmpty(tbSeq.Text.Trim()), Nothing, tbSeq.Text.Trim())
            fo.VisableFlag = ddlVisable_flag.SelectedValue()
            fo.DepartLevel = ddlDepart_Level.SelectedValue
            fo.ChangeCode = tbChangeCode.Text.Trim()
            fo.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Using trans As New TransactionScope()
                If String.IsNullOrEmpty(depart_id) Then
                    eo.insertData()
                    fo.insertData()
                    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "SYS3102_01.aspx")
                Else
                    eo.updateData(orgcode, depart_id)
                    fo.updateData(orgcode, depart_id)
                    CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "SYS3102_01.aspx")
                End If
                trans.Complete()
            End Using
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
End Class
