Imports System.Data
Imports FSCPLM.Logic
Imports System.Transactions
Imports System.IO
Imports SYS.Logic

Partial Class PAY_PAY1_PAY1101_01
    Inherits BaseWebForm

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ApplyDate.Text = CommonFun.getYYYMMDD
            'SetInitialRow()
            initDB()
            ucSaCode1.Code_no = "001"
            PrintBtn.Enabled = False

            ShowReSendData()
        End If
    End Sub


    Protected Sub ShowReSendData()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then
            Dim main As New PurchaseMain()
            Dim det As New MAT.Logic.PurchaseDet()

            Dim dt As DataTable = main.GetDataByFlowId(org, fid)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                ApplyDate.Text = dt.Rows(0)("Apply_date").ToString()
                Use_desc.Text = dt.Rows(0)("Use_desc").ToString()
                ucSaCode1.SelectedValue = dt.Rows(0)("Purchase_type").ToString()
            End If
            UcAttachment.BindUploadFile(org, fid)

            Dim ddt As DataTable = det.GetDataByFlowId(org, fid)
            ddt.Columns.Add("No_id", GetType(System.String))
            For i As Integer = 0 To ddt.Rows.Count - 1
                ddt.Rows(i)("No_id") = i + 1
            Next
            GridViewA.DataSource = ddt
            GridViewA.DataBind()
            Session("db") = ddt

            BackBtn.Visible = True
            SubmitBtn.Text = "確認"
        End If
    End Sub


    Protected Sub SubmitBtn_Click(sender As Object, e As EventArgs) Handles SubmitBtn.Click
        Dim db As DataTable = New DataTable
        Dim mc As Flow = New Flow()
        Dim PAYvb As PAY1101 = New PAY1101()

        Dim Puchase_detReturnMessage As Integer = 0
        Dim Puchase_mainReturnMessage As Integer = 0
        Dim FlowReturnMessage As Integer = 0
        Dim userId As String = LoginManager.UserId
        Dim unitCode As String = LoginManager.Depart_id

        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")
        Dim isUpdate As Boolean = False
        If Not String.IsNullOrEmpty(fid) AndAlso Not String.IsNullOrEmpty(org) Then
            isUpdate = True
        End If

        '檔名
        'Dim fileName As String = Server.HtmlEncode(FileUpload_txt.FileName)
        'Dim extension As String = Server.HtmlEncode(System.IO.Path.GetExtension(fileName))
        'Dim fileSize As Integer = FileUpload_txt.PostedFile.ContentLength
        '存放路徑
        Dim url As String = "PAY1101_01.aspx"
        If Not Session("db") Is Nothing Then
            db = Session("db")
            For i As Integer = 0 To db.Rows.Count - 1 '刷新db值
                db.Rows(i).Item("No_id") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("No_id"), Label).Text)
                db.Rows(i).Item("Item_name") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Item_name"), TextBox).Text)
                db.Rows(i).Item("Specification_desc") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Specification_desc"), TextBox).Text)
                db.Rows(i).Item("Unit") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Unit"), TextBox).Text)
                db.Rows(i).Item("Apply_cnt") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Apply_cnt"), TextBox).Text)
                If Not IsNumeric(db.Rows(i).Item("Apply_cnt")) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "數量必須為數字")
                    Return
                End If
            Next

            If Not String.IsNullOrEmpty(Use_desc.Text) Then '檢查用途摘要不得為空值
                If Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("No_id")) And _
                Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Item_name")) And _
                Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Specification_desc")) And _
                Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Unit")) And _
                Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Apply_cnt")) Then
                    '加入Flow資料表
                    Try
                        Using trans As New TransactionScope
                            Dim f As New Flow()
                            Dim reason As String = "請購數量共" & db.Rows.Count & "件"
                            If isUpdate Then
                                f = f.GetObject(org, fid)
                                f.Reason = reason
                                f.Update()

                                userId = f.ApplyIdcard
                                unitCode = f.DepartId
                            Else
                                '新增Flow
                                f.Orgcode = LoginManager.OrgCode
                                f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                                f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                                f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                                f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                                f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                                If ucSaCode1.Code_no = "001" Then
                                    f.FormId = "003003"
                                ElseIf ucSaCode1.Code_no = "002" Then
                                    f.FormId = "003004"
                                Else
                                    f.FormId = "003005"
                                End If
                                f.FlowId = New SYS.Logic.FlowId().GetFlowId(LoginManager.OrgCode, f.FormId)
                                f.Reason = reason
                                SYS.Logic.CommonFlow.AddFlow(f)
                            End If

                            Me.UcAttachment.FlowId = f.FlowId
                            Me.UcAttachment.SaveFile()

                            'Puchase_detInsert明細
                            Puchase_detReturnMessage = PAYvb.PAY1101DAOInsertPurchase_detData(f.FlowId, _
                                                                                              db, _
                                                                                              Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)), _
                                                                                              Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)), _
                                                                                              Server.HtmlEncode(Date.Now))

                            Puchase_mainReturnMessage = PAYvb.PAY1101DAOInsertPurchase_mainData(f.FlowId, _
                                                                                                userId, _
                                                                                                unitCode, _
                                                                                                Server.HtmlEncode(ApplyDate.Text), _
                                                                                                Server.HtmlEncode(Use_desc.Text), _
                                                                                                Server.HtmlEncode(ucSaCode1.SelectedValue), _
                                                                                                Server.HtmlEncode(""), _
                                                                                                Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)), _
                                                                                                Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)), _
                                                                                                Server.HtmlEncode(Date.Now))


                            'If Puchase_detReturnMessage > 0 Then
                            '    'Puchase_mainInsert主檔
                            '    Puchase_mainReturnMessage = PAYvb.PAY1101DAOInsertPurchase_mainData(f.FlowId, _
                            '                                                                        Server.HtmlEncode(ApplyDate.Text), _
                            '                                                                        Server.HtmlEncode(Use_desc.Text), _
                            '                                                                        Server.HtmlEncode(ucSaCode1.SelectedValue), _
                            '                                                                        Server.HtmlEncode(""), _
                            '                                                                        Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)), _
                            '                                                                        Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)), _
                            '                                                                        Server.HtmlEncode(Date.Now))

                            'Else
                            '    Throw New FlowException("新增表單失敗!")
                            'End If
                            trans.Complete()
                            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "申請完成")
                            PrintBtn.Enabled = True
                        End Using
                        'If (FileUpload_txt.HasFile) Then '有無選擇檔案
                        '    If (fileSize < 1000000) Then '檔案大小
                        '        Dim savaPath As String = Server.MapPath("~/fileupload/Attachment/" & Server.HtmlEncode(f.Leave_type) & "/" & Server.HtmlEncode(f.Flow_id) & "/")
                        '        If Not Directory.Exists(savaPath) Then '檢查存放路徑是否缺少資料夾
                        '            Directory.CreateDirectory(savaPath) '新增空資料夾
                        '        End If
                        '        savaPath = savaPath & fileName
                        '        FileUpload_txt.PostedFile.SaveAs(savaPath)
                        '        Session("Puchase_detReturnMessage") = Puchase_detReturnMessage
                        '        Response.Redirect(url)

                        '    Else
                        '        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "檔案超過1MB限制")
                        '    End If
                        'Else '無檔案上傳直接跳轉頁面
                        '    Session("Puchase_detReturnMessage") = Puchase_detReturnMessage
                        '    Response.Redirect(url)
                        'End If
                    Catch fex As FlowException
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message())
                    Catch ex As Exception
                        AppException.WriteErrorLog(ex.StackTrace, ex.Message)
                        CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
                    End Try

                Else
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查資料是否輸入完全")
                End If
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入用途摘要")
            End If
        Else
            Response.Redirect(url)
        End If
    End Sub

    'Private Sub SetInitialRow()
    '    Dim dt As DataTable = New DataTable
    '    dt.Columns.Add(New DataColumn("No_id"))
    '    dt.Columns.Add(New DataColumn("Item_name"))
    '    dt.Columns.Add(New DataColumn("Specification_desc"))
    '    dt.Columns.Add(New DataColumn("Unit"))
    '    dt.Columns.Add(New DataColumn("Apply_cnt")) 

    '    ViewState("CurrentTable") = dt
    'End Sub

    Protected Sub InsertButton_Click(sender As Object, e As EventArgs)
        Dim db As DataTable = New DataTable
        Dim r As DataRow
        db = Session("db")
        For i As Integer = 0 To GridViewA.Rows.Count - 1 '刷新db值
            db.Rows(i).Item("No_id") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("No_id"), Label).Text)
            db.Rows(i).Item("Item_name") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Item_name"), TextBox).Text)
            db.Rows(i).Item("Specification_desc") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Specification_desc"), TextBox).Text)
            db.Rows(i).Item("Unit") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Unit"), TextBox).Text)
            db.Rows(i).Item("Apply_cnt") = Server.HtmlEncode(CType(GridViewA.Rows(i).FindControl("Apply_cnt"), TextBox).Text)
            If Not IsNumeric(db.Rows(i).Item("Apply_cnt")) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "數量必須為數字")
                Return
            End If
        Next
        If Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("No_id")) And _
            Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Item_name")) And _
            Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Specification_desc")) And _
            Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Unit")) And _
            Not String.IsNullOrEmpty(db.Rows(db.Rows.Count - 1).Item("Apply_cnt")) Then
            r = db.NewRow()
            r("No_id") = Server.HtmlEncode(db.Rows.Count.ToString + 1)
            r("Item_name") = ""
            r("Specification_desc") = ""
            r("Unit") = ""
            r("Apply_cnt") = ""
            db.Rows.Add(r)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請檢查資料是否輸入完全")
        End If
        GridViewA.DataSource = db
        GridViewA.DataBind()
        GridViewA.Rows(GridViewA.Rows.Count - 1).FindControl("InsertButton").Visible = True
        Session("db") = db
    End Sub

    Protected Sub GridView1_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim myButton As Button = CType(e.CommandSource, Button)
        Dim myRow As GridViewRow = CType(myButton.NamingContainer, GridViewRow)
        Dim db As DataTable = New DataTable
        Dim testInt As Integer = 0
        db = Session("db")
        If GridViewA.Rows.Count < 2 Then '只剩一筆資料時刪除按鈕功能改為清空
            GridViewA.Rows(0).FindControl("DeleteButton").Visible = True
            db.Rows(0).Item("Item_name") = ""
            db.Rows(0).Item("Specification_desc") = ""
            db.Rows(0).Item("Unit") = ""
            db.Rows(0).Item("Apply_cnt") = ""
        Else '刪除指定列
            db.Rows.RemoveAt(myRow.RowIndex)
            For i As Integer = 0 To db.Rows.Count - 1
                db.Rows(i).Item("No_id") = i + 1
                GridViewA.Rows(i).FindControl("DeleteButton").Visible = True
            Next
        End If
        GridViewA.DataSource = db
        GridViewA.DataBind()
        GridViewA.Rows(GridViewA.Rows.Count - 1).FindControl("InsertButton").Visible = True '最後一筆資料新增插入按鈕
        Session("db") = db
    End Sub
    Private Sub initDB()
        If Not Session("Puchase_detReturnMessage") Is Nothing Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請購申請" + Server.HtmlEncode(Session("Puchase_detReturnMessage").ToString) + "筆資料送出完成")
            Session.Clear()
        End If
        Dim db As DataTable = New DataTable
        Dim r As DataRow
        '申請日期民國年補0
        db.Columns.Add("No_id", GetType(System.String))
        db.Columns.Add("Item_name", GetType(System.String))
        db.Columns.Add("Specification_desc", GetType(System.String))
        db.Columns.Add("Unit", GetType(System.String))
        db.Columns.Add("Apply_cnt", GetType(System.String))
        r = db.NewRow() '初始空白列
        r("No_id") = db.Rows.Count.ToString + 1
        r("Item_name") = ""
        r("Specification_desc") = ""
        r("Unit") = ""
        r("Apply_cnt") = ""
        db.Rows.Add(r)
        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        GridViewA.EditIndex = 0
        GridViewA.Rows(GridViewA.Rows.Count - 1).FindControl("InsertButton").Visible = True
        Me.div1.Visible = True
        Session("db") = db
    End Sub

    Protected Sub PrintBtn_Click(sender As Object, e As EventArgs)
        Dim db As DataTable = Session("db")
       
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(4) As String '宣告字串陣列

        Dim reportUtil As New CommonLib.ReportUtil(db)
        reportUtil.SetCurrentPage(100)

        Dim totalPage As Integer = reportUtil.GetTotalPage(100)

        strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
        strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
        strParam(2) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)) '單位
        strParam(3) = totalPage '目前頁次


        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/PAY/PAY1101_01.mht"), db)
        'theDTReport.breakPage = "P4"
        theDTReport.Param = strParam
        theDTReport.ExportFileName = "支出憑證黏存單"
        theDTReport.PageGroupColumns = reportUtil.Group
        theDTReport.PageGroupKeyColumns = reportUtil.Group
        theDTReport.ExportToExcel()
        db.Dispose()

    End Sub

    Protected Sub BackBtn_Click(sender As Object, e As EventArgs)
        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl"))
        End If
    End Sub
End Class


