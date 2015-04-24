Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports FSCPLM.Logic

Partial Class FSC3111_02
    Inherits BaseWebForm


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        bind()
    End Sub

    Protected Sub bind()
        Dim id As String = Request.QueryString("id")
        If String.IsNullOrEmpty(id) Then
            Return
        End If

        Try
            Dim dt As DataTable = New FSC.Logic.Schedule().GetDataById(id)

            If dt Is Nothing OrElse dt.Rows.Count < 1 Then
                Return
            End If

            Dim dr As DataRow = dt.Rows(0)
            tbName.Text = dr("Name").ToString()
            tbStart_time.Text = dr("Start_time").ToString()
            tbEnd_time.Text = dr("End_time").ToString()
            tbNoon_stime.Text = dr("Noon_stime").ToString()
            tbNoon_etime.Text = dr("Noon_etime").ToString()
            tbNooncard_stime.Text = dr("Nooncard_stime").ToString()
            tbNooncard_etime.Text = dr("Nooncard_etime").ToString()

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
        End Try
    End Sub



    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim id As String = Request.QueryString("id")

        If String.IsNullOrEmpty(tbName.Text.Trim()) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入班別名稱!")
            Return
        End If
        If String.IsNullOrEmpty(tbStart_time.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入上班時間(起)!")
            Return
        End If
        If String.IsNullOrEmpty(tbEnd_time.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入上班時間(迄)!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbStart_time.Text.Trim) AndAlso Not CommonFun.IsNum(tbStart_time.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上班時間(起)輸入格式不正確!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbEnd_time.Text.Trim) AndAlso Not CommonFun.IsNum(tbEnd_time.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "上班時間(迄)輸入格式不正確!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbNoon_stime.Text.Trim) AndAlso Not CommonFun.IsNum(tbNoon_stime.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "午休時間(起)輸入格式不正確!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbNoon_etime.Text.Trim) AndAlso Not CommonFun.IsNum(tbNoon_etime.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "午休時間(迄)輸入格式不正確!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbNooncard_stime.Text.Trim) AndAlso Not CommonFun.IsNum(tbNooncard_stime.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "中午刷卡時間(起)輸入格式不正確!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbNooncard_etime.Text.Trim) AndAlso Not CommonFun.IsNum(tbNooncard_etime.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "中午刷卡時間(迄)輸入格式不正確!")
            Return
        End If

        Try
            Dim sche As New FSC.Logic.Schedule()
            sche.Orgcode = Orgcode
            sche.Name = tbName.Text.Trim()
            sche.Start_time = tbStart_time.Text.Trim()
            sche.End_time = tbEnd_time.Text.Trim()
            sche.Noon_stime = tbNoon_stime.Text.Trim()
            sche.Noon_etime = tbNoon_etime.Text.Trim()
            sche.Nooncard_stime = tbNooncard_stime.Text.Trim()
            sche.Nooncard_etime = tbNooncard_etime.Text.Trim()
            sche.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            sche.Change_date = Now

            If String.IsNullOrEmpty(id) Then
                sche.Schedule_id = sche.GetMaxScheduleId(Orgcode)
                sche.insert()
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, , "FSC3111_01.aspx")
            Else
                sche.id = CommonFun.getInt(id)
                sche.update()
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, , "FSC3111_01.aspx")
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)

        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("FSC3111_01.aspx")
    End Sub
End Class
