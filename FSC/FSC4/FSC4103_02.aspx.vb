Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports FSC.Logic

Partial Class FSC4103_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return
    End Sub

    Protected Sub QueryData()
        Dim PropertyA As FSC.Logic.FSC4103_01 = New FSC.Logic.FSC4103_01()
        Dim ds As DataSet = New DataSet()
        ds = PropertyA.DAO.GetData(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
    End Sub

    ''' <summary>
    ''' 忘刷卡次數設定-回上一頁
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        Response.Redirect("FSC4103_01.aspx")
    End Sub

    ''' <summary>
    ''' 確定--新增、修改
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim PropertyA As FSC.Logic.FSC4103_01 = New FSC.Logic.FSC4103_01()
        Dim BFlag As Boolean = False
        Dim MessageInfo As String = ""

        PropertyA.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)  '機關代碼 : 新增時，當做條件用
        PropertyA.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)  '機關代碼 : 新增時，當做條件用
        If rdbIsSelect1.Checked Then
            PropertyA.Unlimited_time = "0"                              '不限次數

            PropertyA.Year_time = "0"                                   '每年次數
            PropertyA.Month_time = "0"                                  '每月次數
        Else
            PropertyA.Unlimited_time = "1"                              '有限次數

            If rdbIsSelect2.Checked Then

                If txtItem2YearTimes.Text.Trim() = "" Then
                    MessageInfo = "請輸入每年上限次數!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                ElseIf Not CommonFun.IsNum(txtItem2YearTimes.Text.Trim()) Then
                    MessageInfo = "每年上限次數請輸入數字!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                End If
                If MessageInfo <> "" Then
                    Exit Sub
                End If
                If txtItem2MonthTimes.Text.Trim() = "" Then
                    MessageInfo = "請輸入每月上限次數!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                ElseIf Not CommonFun.IsNum(txtItem2MonthTimes.Text.Trim()) Then
                    MessageInfo = "每月上限次數請輸入數字!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                End If
                If MessageInfo <> "" Then
                    Exit Sub
                End If

                If txtItem2YearTimes.Text.Trim() = "" Then
                    txtItem2YearTimes.Text = "0"
                End If
                If txtItem2MonthTimes.Text.Trim() = "" Then
                    txtItem2MonthTimes.Text = "0"
                End If
                MessageInfo = PropertyA.CompareNumberValue(Convert.ToInt32(txtItem2YearTimes.Text.Trim()), Convert.ToInt32(txtItem2MonthTimes.Text.Trim()))
                If MessageInfo <> "" Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                    Exit Sub
                End If
                PropertyA.Year_time = txtItem2YearTimes.Text.Trim()     '每年次數
                PropertyA.Month_time = txtItem2MonthTimes.Text.Trim()   '每月次數
            ElseIf rdbIsSelect3.Checked Then
                If txtItem3YearTimes.Text.Trim() = "" Then
                    MessageInfo = "請輸入每年上限次數!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                ElseIf Not CommonFun.IsNum(txtItem3YearTimes.Text.Trim()) Then
                    MessageInfo = "每年上限次數請輸入數字!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                End If
                If MessageInfo <> "" Then
                    Exit Sub
                End If

                If txtItem3YearTimes.Text.Trim() = "" Then
                    txtItem3YearTimes.Text = "0"
                End If
                PropertyA.Year_time = txtItem3YearTimes.Text.Trim()     '每年次數
                PropertyA.Month_time = "0"                              '每月次數
            ElseIf rdbIsSelect4.Checked Then
                If txtItem4MonthTimes.Text.Trim() = "" Then
                    MessageInfo = "請輸入每月上限次數!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                ElseIf Not CommonFun.IsNum(txtItem4MonthTimes.Text.Trim()) Then
                    MessageInfo = "每月上限次數請輸入數字!"
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
                End If
                If MessageInfo <> "" Then
                    Exit Sub
                End If

                If txtItem4MonthTimes.Text.Trim() = "" Then
                    txtItem4MonthTimes.Text = "0"
                End If
                PropertyA.Year_time = "0"                               '每年次數
                PropertyA.Month_time = txtItem4MonthTimes.Text.Trim()   '每月次數
            End If
        End If

        PropertyA.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        PropertyA.Change_date = DateTime.Now()
        MessageInfo = PropertyA.DAO.InsertForgetBrushCardRef(PropertyA)
        Label1.Text = MessageInfo
        CommonFun.MsgShow(Me, CommonFun.Msg.ImportOK, "", "FSC4103_01.aspx")

    End Sub
End Class