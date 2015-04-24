Imports System.Data
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Transactions
Imports System.IO
Partial Class SAL_SAL3203
    Inherits System.Web.UI.Page
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitDB()
        End If
    End Sub
    Protected Sub InsertButton(sender As Object, e As EventArgs) Handles InsertBtn.Click
        'Dim cpdt As DataTable = New CPAPE05M().GetCPAPE05MByPEIDNO(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        'Dim cpdr As DataRow = cpdt.Rows(0)
        Dim db As DataTable = New DataTable
        Dim r As DataRow
        If Not Session("db") Is Nothing Then
            db = Session("db")
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Apply_desc.Text)) And _
                Not String.IsNullOrEmpty(Server.HtmlEncode(Cost_date.Text)) And _
                Not String.IsNullOrEmpty(Server.HtmlEncode(Apply_amt.Text)) Then '檢核資料是否正確輸入
                If IntJudge(Server.HtmlEncode(Apply_amt.Text)) = True And _
                    DateJudge(Server.HtmlEncode(Cost_date.Text)) = True Then '檢核費用與日期格式
                    r = db.NewRow() '初始空白列
                    r("Flow_id") = ""
                    r("Depart_name") = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)) '單位別
                    'r("PEMEMCOD") = New CODE5().GetDataDESCR("POTPE", Server.HtmlEncode(cpdr("PEMEMCOD").ToString()))
                    r("User_name") = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '申請人員工姓名
                    r("Apply_desc") = Server.HtmlEncode(Apply_desc.Text) '請領事由說明
                    r("Cost_date") = Server.HtmlEncode(Cost_date.Text) '乘車日期
                    r("Apply_amt") = Server.HtmlEncode(Apply_amt.Text) '請領金額
                    db.Rows.Add(r)
                    div1.Visible = True
                    GridViewA.DataSource = db
                    GridViewA.DataBind()
                    GridViewA.Visible = True
                    Apply_desc.Enabled = False '事由不得更改0205
                    Cost_date.Text = ""
                    Apply_amt.Text = ""
                    Session("db") = db
                    Session("InsertResetBtn") = True
                Else
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查日期格式且申請車資須為大於0之整數")
                End If
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查資料是否正確輸入")
            End If
            div2.Visible = False
            GridViewB.Visible = False
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請重新整理頁面")
        End If
    End Sub
    Protected Sub GridView_SaTEL_RowCommand(ByVal sender As Object, _
        ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand '新增用
        Dim myButton As Button = CType(e.CommandSource, Button)
        Dim myRow As GridViewRow = CType(myButton.NamingContainer, GridViewRow)
        Dim db As New DataTable
        db = Session("db")
        If e.CommandName = "DeleteButton" Then '觸發刪除按鈕
            db.Rows.RemoveAt(myRow.RowIndex)
            GridViewA.DataSource = db
            GridViewA.DataBind()
            If db.Rows.Count = 0 Then
                Apply_desc.Enabled = True
            End If
        ElseIf e.CommandName = "EditorButton" Then '觸發維護按鈕
            '開啟TextBox編輯
            CType(GridViewA.Rows(myRow.RowIndex).FindControl("Cost_date"), TextBox).Enabled = True
            CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_amt"), TextBox).Enabled = True
            For i As Integer = 0 To db.Rows.Count - 1 '除了點選維護的資料列外，其他資料列都隱藏儲存與刪除按鈕。
                If i = myRow.RowIndex Then
                    GridViewA.Rows(myRow.RowIndex).FindControl("StoreButton").Visible = True
                    GridViewA.Rows(myRow.RowIndex).FindControl("EditorButton").Visible = False
                Else
                    GridViewA.Rows(i).FindControl("EditorButton").Visible = False
                    GridViewA.Rows(i).FindControl("DeleteButton").Visible = False
                End If
            Next
        ElseIf e.CommandName = "StoreButton" Then '觸發儲存按鈕
            If Not String.IsNullOrEmpty(Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_desc"), Label).Text)) And _
                Not String.IsNullOrEmpty(Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Cost_date"), TextBox).Text)) And _
                Not String.IsNullOrEmpty(Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_amt"), TextBox).Text)) Then '檢核資料是否正確輸入
                If DateJudge(Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Cost_date"), TextBox).Text)) = True Then '檢核日期格式
                    If IntJudge(Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_amt"), TextBox).Text)) = True Then '檢核費用為數字
                        GridViewA.Rows(myRow.RowIndex).FindControl("StoreButton").Visible = False
                        GridViewA.Rows(myRow.RowIndex).FindControl("EditorButton").Visible = True
                        CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_desc"), Label).Enabled = False
                        CType(GridViewA.Rows(myRow.RowIndex).FindControl("Cost_date"), TextBox).Enabled = False
                        CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_amt"), TextBox).Enabled = False
                        db.Rows(myRow.RowIndex).Item("Apply_desc") = Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_desc"), Label).Text)
                        db.Rows(myRow.RowIndex).Item("Cost_date") = Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Cost_date"), TextBox).Text)
                        db.Rows(myRow.RowIndex).Item("Apply_amt") = Server.HtmlEncode(CType(GridViewA.Rows(myRow.RowIndex).FindControl("Apply_amt"), TextBox).Text)
                        GridViewA.DataSource = db
                        GridViewA.DataBind()
                    Else
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查申請車資須為大於0之正整數")
                    End If
                Else
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查日期格式")
                End If
            Else '檢查空值
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查資料是否輸入")
            End If
        End If
        GridViewA.Visible = True
        div1.Visible = True
        Session("db") = db
        div2.Visible = False
        GridViewB.Visible = False
    End Sub
    Protected Sub Flow_idCheckBox_CheckedChanged(sender As Object, e As EventArgs) '查詢結果選取方塊(任何一筆資料被勾選，其他同Flow_id視同選取)
        Dim db As New DataTable
        Dim r As DataRow
        Dim md As SAL3203 = New SAL3203()
        db.Columns.Add("Flow_id", GetType(System.String))
        For i As Integer = 0 To GridViewB.Rows.Count - 1
            If CType(GridViewB.Rows(i).FindControl("Flow_idCheckBox"), CheckBox).Checked = True Then
                r = db.NewRow() '初始空白列
                r("Flow_id") = CType(GridViewB.Rows(i).FindControl("Flow_id"), Label).Text
                db.Rows.Add(r)
            End If
        Next
        Session("Printdb") = db
    End Sub
    Protected Sub SubmitButton(sender As Object, e As EventArgs) Handles SubmitBtn.Click '送出申請
        If GridViewA.Rows.Count > 0 Then
            'Dim cpdt As DataTable = New CPAPE05M().GetCPAPE05MByPEIDNO(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
            ' Dim cpdr As DataRow = cpdt.Rows(0)
            Dim md As SAL3203 = New SAL3203()
            'Dim mc As Flow = New Flow()
            Dim db As New DataTable
            Dim Write_time As String = Date.Now '資料庫異動時間
            'Dim GetFlowID As String = mc.GetFlow_id("42") '取得新FlowID
            Dim Merge_flow_id As String = "" '申請案件批號空值
            Dim Pay_date As String = "" '空值
            Dim TRAFFIC_FEEChangeNum As Integer = 0 'TRAFFIC_FEETable資料異動數量
            Dim url As String = "SAL3203.aspx"
            If Not Session("db") Is Nothing Then
                db = Session("db")
                'TRAFFIC_FEEChangeNum = md.SAL3203DAOInsertTRAFFIC_FEEData(GetFlowID, _
                'Merge_flow_id, _
                'Server.HtmlEncode( LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)), _
                'Server.HtmlEncode(Convert.ToInt32(Year(Date.Today())) - 1911 & Right("0" & Month(Date.Today()), 2)), _
                'db, _
                'Pay_date, _
                'Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)), _
                'Server.HtmlEncode( LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)), _
                'Server.HtmlEncode(Date.Now))
                '加入Flow資料表
                Try
                    Dim orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                    Dim f As New SYS.Logic.Flow()
                    f.Orgcode = orgcode
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.FormId = "002003"

                    Using trans As New TransactionScope
                        '新增Flow
                        f.FlowId = New SYS.Logic.FlowId().GetFlowId(orgcode, f.FormId)
                        SYS.Logic.CommonFlow.AddFlow(f)
                        trans.Complete()

                        Session("TRAFFIC_FEEChangeNum") = TRAFFIC_FEEChangeNum
                        Session("GetFlowID") = f.FlowId
                        Session("InsertResetBtn") = False
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "新增" + Session("TRAFFIC_FEEChangeNum").ToString + "筆資料成功!")
                    End Using
                Catch fex As FlowException
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
                Catch ex As Exception
                    AppException.WriteErrorLog(ex.StackTrace, ex.Message)
                    CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
                End Try
                SelectButton(sender, e) '新增資料後觸發查詢按鈕
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請新增短程車費資料")
            End If
        End If
    End Sub
    Protected Sub SelectButton(sender As Object, e As EventArgs) Handles SelectBtn.Click
        'Dim cpdt As DataTable = New CPAPE05M().GetCPAPE05MByPEIDNO(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        'Dim cpdr As DataRow = cpdt.Rows(0)
        div1.Visible = False
        GridViewA.Visible = False
        Dim md As SAL3203 = New SAL3203()
        Dim db As New DataTable
        If Not String.IsNullOrEmpty(Server.HtmlEncode(Session("GetFlowID"))) Then '新增後查詢
            db = md.SAL3203DAOSelectTRAFFIC_FEEData(Server.HtmlEncode( LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)), Server.HtmlEncode(Cost_date.Text), Server.HtmlEncode(Session("GetFlowID").ToString), db)
            Session("GetFlowID") = ""
        Else '普通查詢
            If DateJudge(Server.HtmlEncode(Cost_date.Text)) Then '檢核日期格式
                db = md.SAL3203DAOSelectTRAFFIC_FEEData(Server.HtmlEncode( LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)), Server.HtmlEncode(Cost_date.Text), "", db)
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查查詢日期格式")
                Return
            End If
        End If
        db = md.SAL3203DAOSelectTRAFFIC_FEEData(Server.HtmlEncode( LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)), Server.HtmlEncode(Cost_date.Text), "", db)
        db.Columns.Add("Depart_name", GetType(System.String))
        db.Columns.Add("PEMEMCOD", GetType(System.String))
        db.Columns.Add("User_name", GetType(System.String))
        For i As Integer = 0 To db.Rows.Count - 1
            db.Rows(i).Item("Depart_name") = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)) '單位別
            'db.Rows(i).Item("PEMEMCOD") = New CODE5().GetDataDESCR("POTPE", Server.HtmlEncode(cpdr("PEMEMCOD").ToString()))
            db.Rows(i).Item("User_name") = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '申請人員工姓名
        Next
        Apply_desc.Enabled = True
        GridViewB.DataSource = db
        GridViewB.DataBind()
        div2.Visible = True
        GridViewB.Visible = True
        db.Clear()
        Session("db") = db
    End Sub
    Protected Sub PrintButton(sender As Object, e As EventArgs) Handles PrintBtn.Click '加總查詢結果的金額並送出DataTable
        Dim SelectOrgcode As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
        Dim SelectDepart_id As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id))
        Dim SelectId_card As String = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        Dim mbdt As DataTable = New Member().GetDataByIdcard(SelectOrgcode, SelectDepart_id, SelectId_card)
        Dim mbdr As DataRow = mbdt.Rows(0)
        Dim db As New DataTable
        Dim md As SAL3203 = New SAL3203()
        Dim url As String = "SAL3203_02.aspx"
        url &= "?pagerowcnt=" & Server.HtmlEncode("1") '每頁一筆
            If Not Session("Printdb") Is Nothing And _
               Not String.IsNullOrEmpty(Server.HtmlEncode(mbdr("Personnel_id").ToString())) Then
                db = Session("Printdb")
                If db.Rows.Count > 0 Then
                    db = md.SAL3203DAOPrintTRAFFIC_FEEData(Server.HtmlEncode(mbdr("Personnel_id").ToString()), db)
                    Session("SunPrintdb") = db
                    Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")
                    Session("Printdb") = New DataTable
                ResetButton(sender, e)
                    Session("Selectdb") = New DataTable
                Else
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請查詢並選取列印資料")
                End If
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "123")
            End If
    End Sub
    Protected Sub ResetButton(sender As Object, e As EventArgs) Handles ResetBtn.Click
        If Session("InsertResetBtn") = True Then
            Cost_date.Text = ""
            Apply_amt.Text = ""
        Else
            Cost_date.Text = ""
            Apply_amt.Text = ""
            Apply_desc.Text = ""
        End If
    End Sub
    Protected Function IntJudge(ByVal Judgetxt As String) As Boolean '判斷數字型態與大於0
        Try
            Dim i As Integer = Convert.ToInt32(Judgetxt)
            Return i > 0
        Catch e As Exception
            Return False
        End Try
    End Function
    Protected Function DateJudge(ByVal Datetxt As String) As Boolean '判斷日期格式
        If Datetxt = "" Then
            Return True
        Else
            Try
                Dim i As Integer = Convert.ToInt32(Datetxt) '型態檢核
                Dim dt As DateTime = New DateTime(Convert.ToInt32(Datetxt.Substring(0, 3)) + 1911, _
                                                   Convert.ToInt32(Datetxt.Substring(3, 2)), _
                                                  Convert.ToInt32(Datetxt.Substring(5, 2))) '格式檢核
                Return True
            Catch
                Return False
            End Try
        End If
    End Function
    Private Sub InitDB()
        Session.Clear()
        Dim db As DataTable = New DataTable '初始化DataTable
        db.Columns.Add("Flow_id", GetType(System.String))
        db.Columns.Add("Depart_name", GetType(System.String))
        db.Columns.Add("PEMEMCOD", GetType(System.String))
        db.Columns.Add("User_name", GetType(System.String))
        db.Columns.Add("Apply_desc", GetType(System.String))
        db.Columns.Add("Cost_date", GetType(System.String))
        db.Columns.Add("Apply_amt", GetType(System.String))
        Session("db") = db
        div2.Visible = False
        GridViewB.Visible = False
        GridViewB.PageSize = 25
    End Sub
End Class


