Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports CommonLib

Partial Class SAL1102_02
    Inherits System.Web.UI.Page

#Region " PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

        End If
    End Sub

#End Region

#Region "查詢資料"
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click

        Dim Userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Apply_ym As String = UcDate1.ROCYear.ToString + UcDate1.Month.ToString.PadLeft(2, "0")

        Dim DUTY_fee As New DUTY_fee()
        Dim db As DataTable = DUTY_fee.GetDataByUserId(Orgcode, "", Apply_ym)

        Me.gvList.DataSource = db
        Me.gvList.DataBind()
    End Sub
#End Region

#Region "送出申請"
    '按鈕 - 送出
    Protected Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        '檢核
        Dim DUTY_fee As New DUTY_fee()
        Dim Userid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Apply_ym As String = UcDate1.ROCYear.ToString + UcDate1.Month.ToString.PadLeft(2, "0")

        Try
            If DUTY_fee.CheckInsert(Orgcode, Userid, Apply_ym) > 0 Then
                Throw New FlowException("該年月已申請過")
            Else
                '送出
                Submit()
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
            'Dim apply_ym As String = DateTimeInfo.GetRocTodayString("yyyMM")
            Dim Apply_ym As String = UcDate1.ROCYear.ToString + UcDate1.Month.ToString.PadLeft(2, "0")
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
            f.FormId = "002004"


            'DUTY_fee
            Dim DUTY_fee As New DUTY_fee()
            DUTY_fee.Apply_ym = Apply_ym
            DUTY_fee.Org_code = f.Orgcode
            DUTY_fee.ModUser_id = Userid

            DUTY_fee.Pay_date = ""

            Using trans As New TransactionScope

                '新增Flow
                f.FlowId = New SYS.Logic.FlowId().GetFlowId(orgcode, f.FormId)
                SYS.Logic.CommonFlow.AddFlow(f)

                '新增DUTY_fee
                DUTY_fee.Flow_id = f.FlowId
                For i As Integer = 0 To gvList.Rows.Count - 1
                    DUTY_fee.User_id = CType(gvList.Rows.Item(i).FindControl("hfId_card"), HiddenField).Value
                    'CType(gvList.Rows.Item(i).FindControl("txtmemo"), textbox).Text
                    DUTY_fee.Duty_date = CType(gvList.Rows.Item(i).FindControl("lbSche_date"), Label).Text
                    DUTY_fee.ApplyHour_cnt = CType(gvList.Rows.Item(i).FindControl("lbhours2"), TextBox).Text
                    DUTY_fee.Apply_amt = CType(gvList.Rows.Item(i).FindControl("lbamt"), Label).Text
                    DUTY_fee.MEMO = CType(gvList.Rows.Item(i).FindControl("txtmemo"), TextBox).Text

                    Dim bResult As Boolean
                    Dim sErrMsg As String = ""
                    bResult = DUTY_fee.insertData()
                    sErrMsg = "新增失敗!"

                    '更新已領時數 (預扣) 流程同意核可完  需更新Pay_mark,
                    'DUTY_fee.updatehours(DUTY_fee.Org_code, DUTY_fee.User_id, DUTY_fee.Duty_date, DUTY_fee.ApplyHour_cnt)

                    If Not bResult Then
                        Throw New FlowException(sErrMsg)
                    End If
                Next

                trans.Complete()
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)

            End Using
            printing()

        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
#End Region

#Region "列印"

    '若報表查無此人名，可能為 SABASE 尚未與人事資料同步。
    Protected Sub printing()
        Dim Apply_ym As String = UcDate1.ROCYearMonth
        Session.Remove("dt")
        Dim url As String = "SAL1108_02a.aspx"
        'Dim sal1102 As New SAL1102()
        'Dim dt As DataTable = sal1102.GetApplyDataByDate(Apply_ym)
        'dt.Columns.Add("titlename")
        'dt.Columns.Add("titlecode")
        'dt.Columns.Add("merge_flow_id")

        'If (dt.Rows.Count > 0) Then
        '    dt.Rows(0)("titlename") = "值班費"
        '    dt.Rows(0)("titlecode") = "SAL1102"
        'Else
        '    dt.Rows.Add(dt.NewRow)
        '    dt.Rows(0)("titlename") = "值班費"
        '    dt.Rows(0)("titlecode") = "SAL1102"
        'End If

        'Session("dt") = dt

        If gvList.Rows.Count > 0 Then

            url &= "?Type=1"
        Else
            '印空表
            url &= "?Type=0"
        End If

        Dim script As String = "window.open( '{0}' ); "
        ScriptManager.RegisterClientScriptBlock( _
            Me, _
            GetType(Page), _
            "WindowOpenz", _
            String.Format(script, url), _
            True)
        'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, Apply_yy & "年度並無任何申請資料")

    End Sub
#End Region


    Protected Sub lbhours2_TextChanged(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, TextBox).NamingContainer
        Dim Used_hour As String = CType(gvList.Rows.Item(gvr.RowIndex).FindControl("hfusedhours"), HiddenField).Value
        Dim lbhours2 As String = CType(gvList.Rows.Item(gvr.RowIndex).FindControl("lbhours2"), TextBox).Text
        Dim lbhours As String = CType(gvList.Rows.Item(gvr.RowIndex).FindControl("lbhours"), Label).Text

        If (CInt(Used_hour) + CInt(lbhours2) > CInt(lbhours)) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請時數大於可請時數，請重新輸入")
            CType(gvList.Rows.Item(gvr.RowIndex).FindControl("lbhours2"), TextBox).Text = 0
        End If

    End Sub
End Class


