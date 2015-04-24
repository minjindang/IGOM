Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports FSC.Logic

Partial Class FSC4102_01
    Inherits BaseWebForm


#Region "Page_Load"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        If Not Me.IsPostBack Then
            ShowDepartName()
            ShowName()
            Me.pTB2.Visible = False
            Me.pTB1.Visible = True
        End If

    End Sub
#End Region

#Region "查詢"
    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Dim fsc4102 As New FSC4102()
        Dim dt As DataTable

        Try
            If String.IsNullOrEmpty(UcDDLDepart.SelectedValue) Then
                'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇單位!")
                alert("請選擇單位!")
                Exit Sub
            End If
            If String.IsNullOrEmpty(ddlName.SelectedValue) Then
                'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇人員!")
                alert("請選擇人員!")
                Exit Sub
            End If

            dt = fsc4102.getData(Orgcode, UcDDLDepart.SelectedValue, ddlName.SelectedValue)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Me.pTB2.Visible = True
                Me.pTB1.Visible = False

                For Each row As DataRow In dt.Rows

                    Me.lbDepart_name.Text = Convert.ToString(row.Item("Depart_name"))
                    Me.lbTitleName.Text = Convert.ToString(row.Item("Title_Name"))
                    Me.lbUser_name.Text = Convert.ToString(row.Item("User_name"))

                    If Convert.ToString(row.Item("Email_YN")) <> "" Then Me.rblEmail_YN.SelectedValue = row.Item("Email_YN") Else Me.rblEmail_YN.SelectedIndex = -1
                    If Me.rblEmail_YN.SelectedValue = "Y" Then
                        setForm("1")
                    Else
                        setForm("0")
                    End If

                    If Convert.ToString(row.Item("Frequency")) <> "" Then Me.ddlFrequency.SelectedValue = row.Item("Frequency") 'Else ddlFrequency.SelectedIndex = -1
                    If Me.ddlFrequency.SelectedValue <> "2" Then
                        Me.tr1.Visible = False
                    Else
                        Me.tr1.Visible = True

                        For i As Integer = 1 To 6
                            Dim txt As TextBox = CType(Me.tr1.FindControl("txtSend_time" & i), TextBox)
                            If txt.Text.Length = 4 Then
                                If Left(txt.Text, 2) > 20 Or Left(txt.Text, 2) < 8 Or Right(txt.Text, 2) > 30 Or Right(txt.Text, 2) < 0 Or txt.Text = "2030" Then '
                                    txt.ForeColor = Color.Red
                                Else
                                    txt.ForeColor = Color.Black
                                End If
                            End If
                        Next
                    End If

                    Me.txtSend_time1.Text = Convert.ToString(row.Item("Send_time1"))
                    Me.txtSend_time2.Text = Convert.ToString(row.Item("Send_time2"))
                    Me.txtSend_time3.Text = Convert.ToString(row.Item("Send_time3"))
                    Me.txtSend_time4.Text = Convert.ToString(row.Item("Send_time4"))
                    Me.txtSend_time5.Text = Convert.ToString(row.Item("Send_time5"))
                    Me.txtSend_time6.Text = Convert.ToString(row.Item("Send_time6"))
                    Me.HidDepartID.Value = Convert.ToString(row.Item("Depart_id"))
                    Me.HidID_card.Value = Convert.ToString(row.Item("id_card"))
                    Exit For
                Next
            Else
                Me.lbDepart_name.Text = ""
                Me.lbTitleName.Text = ""
                Me.lbUser_name.Text = ""
                Me.rblEmail_YN.SelectedIndex = -1
                Me.ddlFrequency.SelectedIndex = -1
                Me.txtSend_time1.Text = ""
                Me.txtSend_time2.Text = ""
                Me.txtSend_time3.Text = ""
                Me.txtSend_time4.Text = ""
                Me.txtSend_time5.Text = ""
                Me.txtSend_time6.Text = ""
            End If

            dt.Dispose()
        Catch ex As Exception
            'CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "系統發生錯誤，請稍候再試或通知系統管理者")
            alert("系統發生錯誤，請稍候再試或通知系統管理者!")
        End Try

    End Sub
#End Region

#Region "顯示下拉選單"
    Public Sub ShowDepartName()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLDepart.Orgcode = orgcode
    End Sub

    Public Sub ShowName()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable
        Try
            dt = New Member().GetDataByOrgDep(orgcode, UcDDLDepart.SelectedValue)
            Me.ddlName.DataTextField = "full_name"
            Me.ddlName.DataValueField = "id_Card"
            Me.ddlName.DataSource = dt
            Me.ddlName.DataBind()

            ddlName.Items.Insert(0, New ListItem("請選擇", ""))
            dt.Dispose()
            dt = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        ShowName()
    End Sub
#End Region

#Region "畫面資料檢核"
    Public Sub setForm(ByVal m As String)
        If Me.rblEmail_YN.SelectedValue = "N" Then
            Me.ddlFrequency.Items.Clear()
            Dim lt As New ListItem
            lt.Value = "0"
            lt.Text = "無"
            Me.ddlFrequency.Items.Add(lt)
            Me.ddlFrequency.SelectedValue = "0"
        Else
            If m = "1" Then
                Me.ddlFrequency.Items.Clear()
                Dim Str As String() = {"隨時", "指定時間"}
                For i As Integer = 0 To CInt(Str.Length) - 1
                    Dim lt As New ListItem
                    lt.Value = i + 1
                    lt.Text = Str(i)
                    Me.ddlFrequency.Items.Add(lt)
                Next

            End If
        End If
        If Me.ddlFrequency.SelectedValue <> "2" Then
            Me.tr1.Visible = False
        Else
            Me.tr1.Visible = True

            For i As Integer = 1 To 6
                Dim txt As TextBox = CType(Me.tr1.FindControl("txtSend_time" & i), TextBox)
                If txt.Text.Length = 4 Then
                    If Left(txt.Text, 2) > 20 Or Left(txt.Text, 2) < 8 Or Right(txt.Text, 2) > 30 Or Right(txt.Text, 2) < 0 Or txt.Text = "2030" Then '
                        txt.ForeColor = Color.Red
                    Else
                        txt.ForeColor = Color.Black
                    End If
                End If
            Next
        End If

    End Sub

    Protected Sub ddlFrequency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        setForm("0")

    End Sub

    Protected Sub rblEmail_YN_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        setForm("1")
    End Sub

    Protected Sub txtSend_time1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        setForm("0")
    End Sub
#End Region

#Region "確認"
    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sedcount As Integer = 0
        For i As Integer = 1 To 6
            Dim txt As TextBox = CType(Me.tr1.FindControl("txtSend_time" & i), TextBox)
            If txt.Text.Length < 4 And txt.Text.Length <> 0 Then
                'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "接收時間為只能輸4位時間(24小時制)，且必須以30分鐘為單位。")
                alert("接收時間為只能輸4位時間(24小時制)，且必須以30分鐘為單位。")
                Exit Sub
            ElseIf txt.Text <> "" Then
                If Left(txt.Text, 2) > 20 Or Left(txt.Text, 2) < 8 Or Right(txt.Text, 2) > 30 Or Right(txt.Text, 2) < 0 Or txt.Text = "2030" Then
                    'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "接收時間為只能輸4位時間(24小時制)，且必須以30分鐘為單位。")
                    alert("接收時間為只能輸4位時間(24小時制)，且必須以30分鐘為單位。")
                    Exit Sub
                Else
                    sedcount += 1
                End If
            End If
        Next
        If sedcount = 0 And rblEmail_YN.SelectedValue = "Y" And ddlFrequency.SelectedValue = 2 Then
            'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請填寫預接收MAIL時間，至少一個時段以上。")
            alert("請填寫預接收MAIL時間，至少一個時段以上。")
            Exit Sub
        End If

        Try
            Dim fsc4102 As New FSC4102

            fsc4102.updateEmailConfig(HidID_card.Value, rblEmail_YN.SelectedValue, ddlFrequency.SelectedValue, _
                                            txtSend_time1.Text.Trim(), txtSend_time2.Text.Trim(), txtSend_time3.Text.Trim(), _
                                            txtSend_time4.Text.Trim(), txtSend_time5.Text.Trim(), txtSend_time6.Text.Trim())


            Me.pTB1.Visible = True
            Me.pTB2.Visible = False

            'CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            alert("更新成功!")

        Catch ex As Exception
            'CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            alert("系統發生錯誤，請稍候再試或通知系統管理者!")
            AppException.WriteErrorLog(ex.StackTrace, ex.Message())
        End Try
    End Sub
#End Region

#Region "回上一頁"
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Me.pTB1.Visible = True
        Me.pTB2.Visible = False
    End Sub
#End Region

#Region "重填"
    Protected Sub btnReSet2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReSet2.Click
        clearFrom()
        setForm("0")
    End Sub
    Sub clearFrom()
        'Me.lbDepart_name.Text = ""
        'Me.lbTitleName.Text = ""
        'Me.lbUser_name.Text = ""
        Me.rblEmail_YN.SelectedIndex = -1
        'Me.rblMessage_YN.SelectedIndex = -1
        Me.ddlFrequency.SelectedIndex = -1
        Me.txtSend_time1.Text = ""
        Me.txtSend_time2.Text = ""
        Me.txtSend_time3.Text = ""
        Me.txtSend_time4.Text = ""
        Me.txtSend_time5.Text = ""
        Me.txtSend_time6.Text = ""
    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Me.ddlName.SelectedIndex = -1
    End Sub
#End Region

    Protected Sub btnToFSC4102_02_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToFSC4102_02.Click
        Response.Redirect("FSC4102_02.aspx")
    End Sub

    Protected Sub alert(ByVal msg As String)
        ScriptManager.RegisterStartupScript(Me, Me.GetType, Guid.NewGuid().ToString(), "alert('" + msg + "');", True)
    End Sub
End Class
