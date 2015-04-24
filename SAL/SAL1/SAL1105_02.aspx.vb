Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports CommonLib
Partial Class SAL1105_02
    Inherits System.Web.UI.Page

#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        checkConfirm()

        If Not Page.IsPostBack Then
            ' 判斷職等帶入預設金額
            ' 12職等以上  14000, 一般人員3500
            Dim Userid As String =  LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

            Dim SAL1105 As New SAL1105()
            Dim db As DataTable = SAL1105.GetValiDataByUserId(Orgcode, Userid)

            If IsNumeric(db.Rows(0)("BASE_ORG_L1")) Then
                Dim plevel As Integer = db.Rows(0)("BASE_ORG_L1")
                If (plevel > 11) Then
                    ddlamt.SelectedValue = 14000
                Else
                    ddlamt.SelectedValue = 3500
                End If
            Else
                ddlamt.SelectedValue = 3500
            End If


        End If
    End Sub
#End Region

#Region "查詢資料"
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim Userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Apply_yy As String = UcDate1.Year.ToString

        Dim SAL1105 As New SAL1105()
        Dim db As DataTable = SAL1105.GetDataByUserId(Orgcode, Userid, Apply_yy)

        Me.gvList.DataSource = db
        Me.gvList.DataBind()
    End Sub
#End Region

#Region "送出申請"
    Protected Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        '檢核
        '0. 健檢日期不為空值
        '1. 該年度是否申請過
        '2. 未達１２職等且４０歳以上之正職人員，二年只有一次健檢補助申請
        Dim Userid As String =  LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Apply_yy As String = UcDate1.Year.ToString
        Dim SAL1105 As New SAL1105()

        Try
            If String.IsNullOrEmpty(Apply_yy) Then
                Throw New FlowException("請輸入健檢日期")
            End If

            Dim db As DataTable = SAL1105.GetValiDataByUserId(Orgcode, Userid)


            If IsNumeric(db.Rows(0)("BASE_ORG_L1")) Then
                Dim plevel As Integer = db.Rows(0)("BASE_ORG_L1")
                Dim age As Integer = 0
                If String.IsNullOrEmpty(db.Rows(0)("BASE_BirthDay").ToString()) Then
                    Throw New FlowException("您的生日並未紀錄於系統中，請洽人事處理")
                Else
                    age = Convert.ToInt16(DateTimeInfo.GetRocTodayString("yyy")) - Convert.ToInt16(db.Rows(0)("BASE_BirthDay").ToString.Substring(0, 3))
                End If

                '未達１２職等且４０歳以上，二年只有一次健檢補助申請
                If (plevel < 12) And (age > 39) Then
                    If SAL1105.CheckInsert(Orgcode, Userid, Convert.ToInt16(Apply_yy) - 1) > 0 Then
                        Throw New FlowException("您" + Apply_yy + "年已申請過健檢費補助，該年度不得再提出申請")
                    End If
                    If SAL1105.CheckInsert(Orgcode, Userid, Apply_yy) > 0 Then
                        Throw New FlowException("您" + Apply_yy + "年已申請過健檢費補助，該年度不得再提出申請")
                    End If
                    If SAL1105.CheckInsert(Orgcode, Userid, Convert.ToInt16(Apply_yy) + 1) > 0 Then
                        Throw New FlowException("您" + Apply_yy + "年已申請過健檢費補助，該年度不得再提出申請")
                    End If
                Else
                    '其餘 一年一次
                    If SAL1105.CheckInsert(Orgcode, Userid, Apply_yy) > 0 Then
                        Throw New FlowException("您" + Apply_yy + "年已申請過健檢費補助，該年度不得再提出申請")
                    End If
                End If

                '送出
                '選擇其它年度，需跳出警示視窗
                If (Apply_yy <> DateTimeInfo.GetRocTodayString("yyy")) Then
                    confirm("輸入之健檢日期非本年度，請確認資料是否正確？", "__doPostBack('checkConfirm','True')", "__doPostBack('checkConfirm','False')")
                    'btn_submit.Attributes.Add("onclick ", "return confirm( '輸入之健檢日期非本年度，請確認資料是否正確？');")
                    'Response.Write("")
                Else
                    Submit()
                End If
            Else
                ' 沒有職等...
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
    '送出
    Public Sub Submit()
     
        Try
            Dim Apply_yy As String = UcDate1.Year
            Dim Check_date As String = UcDate2.Text
            Dim Apply_amt As String = ddlamt.SelectedValue

            Dim Userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            Dim Username As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

            'FLOW
            Dim f As New SYS.Logic.Flow()
            f.Orgcode = orgcode
            f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
            f.FormId = "002007"

            'SAL1105
            Dim SAL1105 As New SAL1105()

            SAL1105.User_id = Userid
            SAL1105.Apply_yy = Apply_yy
            SAL1105.Check_date = Check_date
            SAL1105.Apply_amt = Apply_amt
            SAL1105.Org_code = f.Orgcode

            SAL1105.ModUser_id = Userid
            'Using trans As New TransactionScope

            '新增Flow
            f.FlowId = New SYS.Logic.FlowId().GetFlowId(orgcode, f.FormId)
            SYS.Logic.CommonFlow.AddFlow(f)

            '新增SAL1105
            SAL1105.Flow_id = f.FlowId
            Dim bResult As Boolean
            Dim sErrMsg As String = ""
            bResult = SAL1105.insertData()
            sErrMsg = "新增失敗!"

            If Not bResult Then
                Throw New FlowException(sErrMsg)
            End If

            printing()
            'trans.Complete()
            'End Using

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

#End Region

#Region "confirm 判斷"
    Protected Sub checkConfirm()
        Dim target As String = Me.Request.Form("__EVENTTARGET")
        Dim argument As String = Me.Request.Form("__EVENTARGUMENT")

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim ym As String = Request.QueryString("ym")

        '按了確定要執行的程式碼
        If target = "checkConfirm" Then
            If argument = "True" Then
                ViewState.Add("PASS_LIMIT", True)
                Submit()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Postback的詢問視窗
    ''' </summary>
    ''' <param name="Message">訊息文字</param>
    ''' <param name="TrueScript">回應 true 時要執行的用戶端指令碼</param>
    ''' <param name="FalseScript">回應 false 時要執行的用戶端指令碼</param>
    Public Sub confirm(ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        Me.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub
#End Region

#Region "列印"
    Protected Sub btn_print_Click(sender As Object, e As EventArgs) Handles btn_print.Click
        printing()
    End Sub

    Protected Sub printing()

        Dim Username As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim userid As String = LoginManager.GetTicketUserData(LoginManager.UserId)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Apply_yy As String = UcDate1.Year

        Dim SAL1105 As New SAL1105()
        Dim dt As DataTable = SAL1105.GetDataByUserId(Orgcode, userid, Apply_yy)

        If (dt.Rows.Count) > 0 Then
            Dim url As String = "SAL1105_02a.aspx"
            url &= "?Apply_yy=" & UcDate1.Year.ToString
            Response.Redirect(url)
            'Dim script As String = "window.open( '{0}' ); "
            'ScriptManager.RegisterClientScriptBlock( _
            '    Me, _
            '    GetType(Page), _
            '    "WindowOpenz", _
            '    String.Format(script, url), _
            '    True)

        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Apply_yy & "年度並無任何申請資料")
        End If


    End Sub
#End Region

End Class


