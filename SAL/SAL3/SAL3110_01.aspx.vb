Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports CommonLib

Partial Class SAL3110_01
    Inherits BaseWebForm


#Region " PageLoad"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

        End If
    End Sub

#End Region


    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sMonth As String = UcDate1.Month.ToString.PadLeft(2, "0")
        Dim eMonth As String = UcDate2.Month.ToString.PadLeft(2, "0")

        Dim sal3110 As New SAL3110()


        Dim db As DataTable = sal3110.GetDataByMonthRange(Orgcode, sMonth, eMonth)

        Me.gv.DataSource = db
        Me.gv.DataBind()
    End Sub

    Protected Sub btn_submit_Click(sender As Object, e As EventArgs) Handles btn_submit.Click
        Try


            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

            Dim chk As Boolean = False
            For Each gvr As GridViewRow In gv.Rows

                If Not CType(gvr.FindControl("gv_cbx"), CheckBox).Checked Then
                    Continue For
                Else
                    Dim pay_amt As String = CType(gvr.FindControl("txtamt"), TextBox).Text.Trim
                    If String.IsNullOrEmpty(pay_amt) OrElse pay_amt = "0" Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "有未輸入金額之選取項目!")
                        Return
                    Else
                        Dim user_id As String = CType(gvr.FindControl("lbPersonnel_id"), Label).Text.Trim()
                        Dim user_name As String = CType(gvr.FindControl("lbUser_name"), Label).Text.Trim()
                        Dim sal3110 As New SAL3110()
                        If (sal3110.CheckInsert(user_id) = 0) Then
                            chk = True
                        Else
                            Throw New FlowException(user_name & "(員工編號:" & user_id & ")今年度已申請過，不得重複申請。")
                        End If

                    End If
                End If


                Dim p As New PAYITEM()

                p.Org_code = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                p.User_id = CType(gvr.FindControl("lbPersonnel_id"), Label).Text.Trim()
                p.Flow_id = ""
                p.CodeSys = "5"
                p.CodeKind = "D"
                p.CodeType = "001"
                p.CodeNo = "412"
                p.Code = "015"
                p.Pay_ym = DateTimeInfo.GetRocTodayString("yyy").ToString   '不確定 需再詢問
                p.Pay_date = DateTimeInfo.GetRocTodayString("yyyMMdd").ToString
                p.Budget_code = "" '不確定 需再詢問
                p.Pay_amt = CType(gvr.FindControl("txtamt"), TextBox).Text.Trim()
                p.ModUser_id = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)

                Using trans As New TransactionScope
                    Dim bResult As Boolean
                    Dim sErrMsg As String = ""
                    bResult = p.insertData()
                    sErrMsg = "新增失敗!"

                    If Not bResult Then
                        Throw New FlowException(sErrMsg)
                    End If

                    trans.Complete()
                    CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
                End Using
            Next

            If chk = False Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請至少勾選一筆資料!")
            End If
        Catch fex As FlowException
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub btn_set_Click(sender As Object, e As EventArgs) Handles btn_set.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sMonth As String = UcDate1.Month.ToString.PadLeft(2, "0")
        Dim eMonth As String = UcDate2.Month.ToString.PadLeft(2, "0")

        Dim sal3110 As New SAL3110()


        Dim db As DataTable = sal3110.GetDataByMonthRange(Orgcode, sMonth, eMonth)

        For i As Integer = 0 To db.Rows.Count - 1
            db.Rows(i)("pay_amt") = txtamt.Text
        Next

        Me.gv.DataSource = db
        Me.gv.DataBind()

    End Sub

    Protected Sub bntPrint_Click(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim pay_amt As String = CType(gvr.FindControl("txtamt"), TextBox).Text.Trim
        Dim User_name As String = CType(gvr.FindControl("lbUser_name"), Label).Text.Trim
        Dim Depart_name As String = CType(gvr.FindControl("lbDepart_name"), Label).Text.Trim

        Dim dt As DataTable = getTable()
        Dim dr As DataRow = dt.NewRow
        dr("Depart_name") = Depart_name
        dr("User_name") = User_name
        dr("pay_amt") = pay_amt

        dt.Rows.Add(dr)

        Print(dt)
    End Sub

    Protected Sub btn_Excel_Click(sender As Object, e As EventArgs) Handles btn_Excel.Click
        Dim dt As DataTable = getTable()
        For Each gvr As GridViewRow In gv.Rows
            Dim cb As CheckBox = CType(gvr.FindControl("gv_cbx"), CheckBox)
            Dim pay_amt As String = CType(gvr.FindControl("txtamt"), TextBox).Text.Trim
            Dim User_name As String = CType(gvr.FindControl("lbUser_name"), Label).Text.Trim
            Dim Depart_name As String = CType(gvr.FindControl("lbDepart_name"), Label).Text.Trim
            If cb.Checked Then
                If String.IsNullOrEmpty(pay_amt) OrElse pay_amt = "0" Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "有未輸入金額之選取項目!")
                    Return
                Else
                    Dim dr As DataRow = dt.NewRow
                    dr("Depart_name") = Depart_name
                    dr("User_name") = User_name
                    dr("pay_amt") = pay_amt

                    dt.Rows.Add(dr)
                End If
            End If
        Next

        Print(dt)
    End Sub

    Protected Function getTable() As DataTable
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Depart_name")
        dt.Columns.Add("User_name")
        dt.Columns.Add("pay_amt")

        Return dt
    End Function

    Private Sub Print(ByVal dt As DataTable)

    End Sub
End Class