Imports System.Data
Imports System.Data.SqlClient
Imports SYS.Logic
Imports System.Transactions

Partial Class SYS3118_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        UcDDLDepart.Orgcode = LoginManager.OrgCode
        Bind()
    End Sub

    Protected Sub Bind()
        Dim id As String = Request.QueryString("id")
        Dim pf As New PaperFile()
        Dim dt As DataTable = pf.GetDataById(id)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            UcDDLDepart.SelectedValue = dt.Rows(0)("Depart_id").ToString()
            lbFile_name.Text = dt.Rows(0)("File_name").ToString()
            hfFile_name.Value = dt.Rows(0)("File_name").ToString()
            hfReal_name.Value = dt.Rows(0)("Real_name").ToString()
            hfPath.Value = dt.Rows(0)("Path").ToString()
            UcDate1.Text = dt.Rows(0)("Start_date").ToString()
            UcDate2.Text = dt.Rows(0)("End_date").ToString()
            rblFlag.SelectedValue = dt.Rows(0)("removed_flag").ToString()
        End If
    End Sub

    Protected Sub cbConfrim_Click(sender As Object, e As EventArgs)
        Dim id As String = Request.QueryString("id")
        Dim bll As New SYS.Logic.SYS3118()
        Dim orgcode As String = LoginManager.OrgCode
        Dim departId As String = UcDDLDepart.SelectedValue

        If String.IsNullOrEmpty(departId) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入單位!")
            Return
        End If

        If String.IsNullOrEmpty(id) And Not fuFile.HasFile Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇表單檔案!")
            Return
        End If

        If String.IsNullOrEmpty(UcDate1.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入上架日期(起)!")
            Return
        End If
        If String.IsNullOrEmpty(UcDate2.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入上架日期(迄)!")
            Return
        End If
        If UcDate1.Text > UcDate2.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上架日期(起)不可大於上架日期(迄)!")
            Return
        End If

        If departId.Length = 2 Then
            departId &= "0000"
        End If

        If String.IsNullOrEmpty(id) Then
            bll.Add(orgcode, departId, fuFile, UcDate1.Text, UcDate2.Text, rblFlag.SelectedValue)
            CommonFun.MsgShow(Me, CommonFun.Msg.uploadOK, "", "SYS3118_01.aspx")
        Else
            bll.Update(orgcode, departId, fuFile, hfFile_name.Value, hfReal_name.Value, hfPath.Value, UcDate1.Text, UcDate2.Text, rblFlag.SelectedValue, id)
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "SYS3118_01.aspx")
        End If

    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        Response.Redirect("SYS3118_01.aspx")
    End Sub
End Class
