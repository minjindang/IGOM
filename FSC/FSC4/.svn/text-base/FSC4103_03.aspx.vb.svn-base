Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports FSC.Logic

Partial Class FSC4103_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            initData()
            QueryData()
        End If

    End Sub

    Protected Sub initData()
        hfOrgcode.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        hfLoginCardId.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    End Sub
    Protected Sub QueryData()
        Dim PropertyA As FSC.Logic.FSC4103_01 = New FSC.Logic.FSC4103_01()
        Dim ds As DataSet = New DataSet()
        ds = PropertyA.DAO.GetData(hfOrgcode.Value)

        If (ds.Tables(0).Rows.Count > 0) Then
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim lbl2 As String = DirectCast(dr.Item(2).ToString, String) 'Unlimited_time
                Dim lbl3 As String = DirectCast(dr.Item(3).ToString, String) '(case Year_time when '0' then '' else Year_time end )
                Dim hf1 As String = DirectCast(dr.Item(1).ToString, String) '(case Month_time when '0' then '' else Month_time end )
                If hf1 = "0" Then
                    rdbIsSelect1.Checked = True

                    txtItem2YearTimes.Text = ""
                    txtItem2MonthTimes.Text = ""

                    txtItem3YearTimes.Text = ""
                    txtItem4MonthTimes.Text = ""
                ElseIf hf1 = "1" Then
                    If (lbl2 <> "0" And IsNumeric(lbl2)) And (lbl3 <> "0" And IsNumeric(lbl3)) Then
                        rdbIsSelect2.Checked = True
                        txtItem2YearTimes.Text = lbl2
                        txtItem2MonthTimes.Text = lbl3

                        txtItem3YearTimes.Text = ""
                        txtItem4MonthTimes.Text = ""
                    ElseIf lbl2 <> "0" And IsNumeric(lbl2) Then
                        rdbIsSelect3.Checked = True
                        txtItem3YearTimes.Text = lbl2

                        txtItem2YearTimes.Text = ""
                        txtItem2MonthTimes.Text = ""
                        txtItem4MonthTimes.Text = ""
                    ElseIf lbl3 <> "0" And IsNumeric(lbl3) Then
                        rdbIsSelect4.Checked = True
                        txtItem4MonthTimes.Text = lbl3

                        txtItem2YearTimes.Text = ""
                        txtItem2MonthTimes.Text = ""
                        txtItem3YearTimes.Text = ""
                    End If
                End If


            Next

        Else
        End If
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

        PropertyA.Orgcode = hfOrgcode.Value.Trim()                      '機關代碼 : 新增時，當做條件用
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

        PropertyA.Change_userid = hfLoginCardId.Value.Trim()
        PropertyA.Change_date = DateTime.Now()
        MessageInfo = PropertyA.DAO.UpdateForgetBrushCardRef(PropertyA)
        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, MessageInfo)
        Response.Redirect("FSC4103_01.aspx")
    End Sub

End Class