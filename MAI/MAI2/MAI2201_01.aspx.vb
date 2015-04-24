Imports System.Data
Imports FSCPLM.Logic
Imports System.Transactions
Imports System.IO
Partial Class MAI_MAI2201
    Inherits System.Web.UI.Page
    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
        End If
    End Sub
    Protected Sub SelectButton(sender As Object, e As EventArgs) Handles SelectBtn.Click
        div01.Visible = False
        div02.Visible = False
        div03.Visible = False
        div04.Visible = False
        div05.Visible = False
        div06.Visible = False
        DivDate.Visible = False
        Select Case StatisticalCategories.SelectedValue
            Case "01" '報修類別
                Dim md As SACode = New SACode()
                Dim sacode As New DataTable
                Dim Total As Integer = 0
                sacode = md.GetData("019", "008") '查出水電報修類別 
                sacode.Columns.Add("Num", GetType(System.String))
                sacode.Columns.Add("proportion", GetType(System.String))
                Dim ElecMaintain_det As MAI2201_01 = New MAI2201_01()
                Dim db As DataTable
                db = ElecMaintain_det.MAI3202_01_01(ApplyTimeS.Text, ApplyTimeE.Text)
                For i As Integer = 0 To db.Rows.Count - 1
                    Total = Total + CType(db.Rows(i).Item("Countnum"), Integer)
                Next
                For i As Integer = 0 To sacode.Rows.Count - 1
                    For j As Integer = 0 To db.Rows.Count - 1
                        If sacode.Rows(i).Item("CODE_NO") = db.Rows(j).Item("MtClass_type") Then
                            sacode.Rows(i).Item("Num") = db.Rows(j).Item("Countnum").ToString
                            sacode.Rows(i).Item("proportion") = FormatNumber((CType(db.Rows(j).Item("Countnum"), Integer) / Total * 100), 2).ToString
                        End If
                    Next
                    If sacode.Rows(i).Item("Num").ToString = "" Then
                        sacode.Rows(i).Item("Num") = "0"
                    End If
                    If sacode.Rows(i).Item("proportion").ToString = "" Then
                        sacode.Rows(i).Item("proportion") = "0"
                    End If
                Next
                GridView01.DataSource = sacode
                GridView01.DataBind()
                div01.Visible = True
                GridView01.Visible = True
                DivDate.Visible = True
            Case "02" '處室報修次數
                '各處室報修次數統計結果------------------------------------------------------------------------
                Dim md As MAI2201_01 = New MAI2201_01()
                Dim FSCorg As New DataTable
                Dim db As New DataTable
                Dim dc As New DataTable
                Dim Total As Integer = 0
                FSCorg = md.MAI3202_01_02FSCorg(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
                db = md.MAI3202_01_02Maintain_mainJoinMAI_ElecMaintain_det(ApplyTimeS.Text, ApplyTimeE.Text, "1") '報修單位
                dc = md.MAI3202_01_02Maintain_mainJoinMAI_ElecMaintain_det(ApplyTimeS.Text, ApplyTimeE.Text, "2") '報修明細
                db.Columns.Add("Complete", GetType(System.String)) '完成比數
                db.Columns.Add("CompleteProportion", GetType(System.String)) '完成比例
                db.Columns.Add("NonCompleteNum", GetType(System.String)) '未完成筆數
                db.Columns.Add("NonCompleteProportion", GetType(System.String)) '未完成比例
                For i As Integer = 0 To db.Rows.Count - 1
                    db.Rows(i).Item("Complete") = "0"
                    db.Rows(i).Item("CompleteProportion") = "0"
                    db.Rows(i).Item("NonCompleteNum") = "0"
                    db.Rows(i).Item("NonCompleteProportion") = "0"
                Next
                For i As Integer = 0 To db.Rows.Count - 1
                    For j As Integer = 0 To dc.Rows.Count - 1
                        If db.Rows(i).Item("Unit_code") = dc.Rows(j).Item("Unit_code") Then
                            If dc.Rows(j).Item("CaseClose_type").ToString = "Y" Then
                                db.Rows(i).Item("Complete") = CType(db.Rows(i).Item("Complete") + 1, Integer).ToString
                            Else
                                db.Rows(i).Item("NonCompleteNum") = CType(db.Rows(i).Item("NonCompleteNum") + 1, Integer).ToString
                            End If
                        End If
                    Next
                Next
                For i As Integer = 0 To db.Rows.Count - 1
                    db.Rows(i).Item("CompleteProportion") = CType(db.Rows(i).Item("Complete") / db.Rows(i).Item("Total") * 100, Integer)
                    db.Rows(i).Item("NonCompleteProportion") = CType((db.Rows(i).Item("NonCompleteNum") / db.Rows(i).Item("Total")) * 100, Integer)
                Next
                '完成案件處室滿意度統計表-----------------------------------------------------------------------
                Dim mc As SACode = New SACode()
                Dim mf As MAI2201_01 = New MAI2201_01()
                Dim sacode As New DataTable
                Dim Satisfaction_main As New DataTable
                Dim Satisfaction_det As New DataTable
                Dim Satisfaction_Tatle As New DataTable
                Satisfaction_main = mf.MAI3202_01_02Satisfaction(ApplyTimeS.Text, ApplyTimeE.Text, "0") '查報修單位
                Satisfaction_det = mf.MAI3202_01_02Satisfaction(ApplyTimeS.Text, ApplyTimeE.Text, "1") '查單位與滿意度
                Satisfaction_main.Columns.Add("Complete000", GetType(System.String)) '未填寫
                Satisfaction_main.Columns.Add("Complete000Proportion", GetType(System.String)) '未填寫比例
                Satisfaction_main.Columns.Add("Complete001", GetType(System.String)) '非常滿意
                Satisfaction_main.Columns.Add("Complete001Proportion", GetType(System.String)) '非常滿意比例
                Satisfaction_main.Columns.Add("Complete002", GetType(System.String)) '滿意
                Satisfaction_main.Columns.Add("Complete002Proportion", GetType(System.String)) '滿意比例
                Satisfaction_main.Columns.Add("Complete003", GetType(System.String)) '普通
                Satisfaction_main.Columns.Add("Complete003Proportion", GetType(System.String)) '普通比例
                Satisfaction_main.Columns.Add("Complete004", GetType(System.String)) '不滿意
                Satisfaction_main.Columns.Add("Complete004Proportion", GetType(System.String)) '不滿意比例
                Satisfaction_main.Columns.Add("Complete005", GetType(System.String)) '非常不滿意
                Satisfaction_main.Columns.Add("Complete005Proportion", GetType(System.String)) '非常不滿意比例
                Satisfaction_main.Columns.Add("Total", GetType(System.String)) '總數
                For i As Integer = 0 To Satisfaction_main.Rows.Count - 1 '滿意度預設數量
                    Satisfaction_main.Rows(i).Item("Complete000") = "0"
                    Satisfaction_main.Rows(i).Item("Complete001") = "0"
                    Satisfaction_main.Rows(i).Item("Complete002") = "0"
                    Satisfaction_main.Rows(i).Item("Complete003") = "0"
                    Satisfaction_main.Rows(i).Item("Complete004") = "0"
                    Satisfaction_main.Rows(i).Item("Complete005") = "0"
                    For j As Integer = 0 To db.Rows.Count - 1 '帶入各單位報修總數
                        If Satisfaction_main.Rows(i).Item("Unit_code") = db.Rows(j).Item("Unit_code") Then
                            Satisfaction_main.Rows(i).Item("Total") = db.Rows(i).Item("Total")
                        End If
                    Next
                Next
                For i As Integer = 0 To Satisfaction_main.Rows.Count - 1 '統計各滿意度數量
                    For j As Integer = 0 To Satisfaction_det.Rows.Count - 1
                        If Satisfaction_main.Rows(i).Item("Unit_code") = Satisfaction_det.Rows(j).Item("Unit_code") Then
                            If String.IsNullOrEmpty(Satisfaction_det.Rows(j).Item("Satisfaction_type").ToString) Then '未填寫
                                Satisfaction_main.Rows(i).Item("Complete000") = CType(Satisfaction_main.Rows(i).Item("Complete000"), Integer) + 1
                            End If
                            If Satisfaction_det.Rows(j).Item("Satisfaction_type").ToString = "001" Then '未填寫
                                Satisfaction_main.Rows(i).Item("Complete001") = CType(Satisfaction_main.Rows(i).Item("Complete001"), Integer) + 1
                            End If
                            If Satisfaction_det.Rows(j).Item("Satisfaction_type").ToString = "002" Then '未填寫
                                Satisfaction_main.Rows(i).Item("Complete002") = CType(Satisfaction_main.Rows(i).Item("Complete002"), Integer) + 1
                            End If
                            If Satisfaction_det.Rows(j).Item("Satisfaction_type").ToString = "003" Then '未填寫
                                Satisfaction_main.Rows(i).Item("Complete003") = CType(Satisfaction_main.Rows(i).Item("Complete003"), Integer) + 1
                            End If
                            If Satisfaction_det.Rows(j).Item("Satisfaction_type").ToString = "004" Then '未填寫
                                Satisfaction_main.Rows(i).Item("Complete004") = CType(Satisfaction_main.Rows(i).Item("Complete004"), Integer) + 1
                            End If
                            If Satisfaction_det.Rows(j).Item("Satisfaction_type").ToString = "005" Then '未填寫
                                Satisfaction_main.Rows(i).Item("Complete005") = CType(Satisfaction_main.Rows(i).Item("Complete005"), Integer) + 1
                            End If
                        End If
                    Next
                Next
                For i As Integer = 0 To Satisfaction_main.Rows.Count - 1
                    Satisfaction_main.Rows(i).Item("Complete000Proportion") = FormatNumber(CType(Satisfaction_main.Rows(i).Item("Complete000") / Satisfaction_main.Rows(i).Item("Total") * 100, Integer), 0).ToString
                    Satisfaction_main.Rows(i).Item("Complete001Proportion") = FormatNumber(CType(Satisfaction_main.Rows(i).Item("Complete001") / Satisfaction_main.Rows(i).Item("Total") * 100, Integer), 0).ToString
                    Satisfaction_main.Rows(i).Item("Complete002Proportion") = FormatNumber(CType(Satisfaction_main.Rows(i).Item("Complete002") / Satisfaction_main.Rows(i).Item("Total") * 100, Integer), 0).ToString
                    Satisfaction_main.Rows(i).Item("Complete003Proportion") = FormatNumber(CType(Satisfaction_main.Rows(i).Item("Complete003") / Satisfaction_main.Rows(i).Item("Total") * 100, Integer), 0).ToString
                    Satisfaction_main.Rows(i).Item("Complete004Proportion") = FormatNumber(CType(Satisfaction_main.Rows(i).Item("Complete004") / Satisfaction_main.Rows(i).Item("Total") * 100, Integer), 0).ToString
                    Satisfaction_main.Rows(i).Item("Complete005Proportion") = FormatNumber(CType(Satisfaction_main.Rows(i).Item("Complete005") / Satisfaction_main.Rows(i).Item("Total") * 100, Integer), 0).ToString
                Next
                For i As Integer = 0 To db.Rows.Count - 1 '單位代碼轉中文
                    For j As Integer = 0 To FSCorg.Rows.Count - 1
                        If db.Rows(i).Item("Unit_code") = FSCorg.Rows(j).Item("Depart_id") Then
                            db.Rows(i).Item("Unit_code") = FSCorg.Rows(j).Item("Depart_name")
                        End If
                    Next
                Next
                For i As Integer = 0 To Satisfaction_main.Rows.Count - 1 '單位代碼轉中文
                    For j As Integer = 0 To FSCorg.Rows.Count - 1
                        If Satisfaction_main.Rows(i).Item("Unit_code") = FSCorg.Rows(j).Item("Depart_id") Then
                            Satisfaction_main.Rows(i).Item("Unit_code") = FSCorg.Rows(j).Item("Depart_name")
                        End If
                    Next
                Next
                GridView02_01.DataSource = db
                GridView02_01.DataBind()
                GridView02_01.Visible = True
                GridView02_02.DataSource = Satisfaction_main
                GridView02_02.DataBind()
                GridView02_02.Visible = True
                div02.Visible = True
                DivDate.Visible = True
            Case "03" '個人報修次數
                Dim md As MAI2201_01 = New MAI2201_01()
                Dim FSCorg As New DataTable
                Dim db As New DataTable
                Dim dc As New DataTable
                Dim Total As Integer = 0
                FSCorg = md.MAI3202_01_02FSCorg(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
                db = md.MAI3202_01_02Personal(ApplyTimeS.Text, ApplyTimeE.Text, "0") '查出報修人與總數
                db.Columns.Add("Complete", GetType(System.String)) '完成比數
                db.Columns.Add("CompleteProportion", GetType(System.String)) '完成比例
                db.Columns.Add("NonCompleteNum", GetType(System.String)) '未完成筆數
                db.Columns.Add("NonCompleteProportion", GetType(System.String)) '未完成比例
                db.Columns.Add("Unit_code", GetType(System.String)) '單位別
                For i As Integer = 0 To db.Rows.Count - 1
                    db.Rows(i).Item("Complete") = "0"
                    db.Rows(i).Item("CompleteProportion") = "0"
                    db.Rows(i).Item("NonCompleteNum") = "0"
                    db.Rows(i).Item("NonCompleteProportion") = "0"
                Next
                dc = md.MAI3202_01_02Personal(ApplyTimeS.Text, ApplyTimeE.Text, "1") '查出是否結案
                For i As Integer = 0 To db.Rows.Count - 1
                    For j As Integer = 0 To dc.Rows.Count - 1
                        If db.Rows(i).Item("User_id") = dc.Rows(j).Item("User_id") Then
                            If dc.Rows(j).Item("CaseClose_type").ToString = "Y" Then
                                db.Rows(i).Item("Complete") = CType(db.Rows(i).Item("Complete") + dc.Rows(j).Item("Total"), Integer).ToString
                                db.Rows(i).Item("CompleteProportion") = FormatNumber(CType(db.Rows(i).Item("Complete") / db.Rows(i).Item("Total") * 100, Integer), 0).ToString
                            Else
                                db.Rows(i).Item("NonCompleteNum") = CType(db.Rows(i).Item("NonCompleteNum") + dc.Rows(j).Item("Total"), Integer).ToString
                                db.Rows(i).Item("NonCompleteProportion") = FormatNumber(CType(db.Rows(i).Item("NonCompleteNum") / db.Rows(i).Item("Total") * 100, Integer), 0).ToString
                            End If
                            db.Rows(i).Item("Unit_code") = dc.Rows(j).Item("Unit_code")
                        End If
                    Next
                Next
                For i As Integer = 0 To db.Rows.Count - 1 '單位代碼轉中文
                    For j As Integer = 0 To FSCorg.Rows.Count - 1
                        If db.Rows(i).Item("Unit_code") = FSCorg.Rows(j).Item("Depart_id") Then
                            db.Rows(i).Item("Unit_code") = FSCorg.Rows(j).Item("Depart_name")
                        End If
                    Next
                Next
                GridView03.DataSource = db
                GridView03.DataBind()
                GridView03.Visible = True
                div03.Visible = True
                DivDate.Visible = True
            Case "04" '依時限完成率
                Dim md As MAI2201_01 = New MAI2201_01()
                Dim db As New DataTable
                Dim Total As Integer = 0
                db = md.MAI3202_01_02MtTime(ApplyTimeS.Text, ApplyTimeE.Text)
                db.Columns.Add("Proportion", GetType(System.String)) '比例
                For i As Integer = 0 To db.Rows.Count - 1 '算出總數
                    Total = CType(Total + db.Rows(i).Item("MaintainDayNum"), Integer)
                Next
                If Total = 0 Then '沒資料就顯示空表
                    db.Clear()
                    GridView04.DataSource = db
                    GridView04.DataBind()
                    GridView04.Visible = True
                    GridView04_01.DataSource = db
                    GridView04_01.DataBind()
                    GridView04_01.Visible = True
                    div04.Visible = True
                    DivDate.Visible = True
                    Return
                End If
                If db.Rows.Count > 0 Then '如果有資料在往下做
                    For i As Integer = 0 To db.Rows.Count - 1
                        If db.Rows(i).Item("Day") = "001" Then '一天內
                            db.Rows(i).Item("Day") = "一天內完成之報修筆數及比率"
                            If Not String.IsNullOrEmpty(db.Rows(i).Item("MaintainDayNum").ToString) Then
                                db.Rows(i).Item("Proportion") = CType(db.Rows(i).Item("MaintainDayNum") / Total * 100, Integer)
                            Else
                                db.Rows(i).Item("Proportion") = "0"
                            End If
                        End If
                        If db.Rows(i).Item("Day") = "002" Then '二天內
                            db.Rows(i).Item("Day") = "兩天內完成之報修筆數及比率"
                            If Not String.IsNullOrEmpty(db.Rows(i).Item("MaintainDayNum").ToString) Then
                                db.Rows(i).Item("Proportion") = CType(db.Rows(i).Item("MaintainDayNum") / Total * 100, Integer)
                            Else
                                db.Rows(i).Item("Proportion") = "0"
                            End If
                        End If
                        If db.Rows(i).Item("Day") = "003" Then '三天內
                            db.Rows(i).Item("Day") = "三天內完成之報修筆數及比率"
                            If Not String.IsNullOrEmpty(db.Rows(i).Item("MaintainDayNum").ToString) Then
                                db.Rows(i).Item("Proportion") = CType(db.Rows(i).Item("MaintainDayNum") / Total * 100, Integer)
                            Else
                                db.Rows(i).Item("Proportion") = "0"
                            End If
                        End If
                        If db.Rows(i).Item("Day") = "004" Then '超過三天
                            db.Rows(i).Item("Day") = "超過三天完成之報修筆數及比率"
                            If Not String.IsNullOrEmpty(db.Rows(i).Item("MaintainDayNum").ToString) Then
                                db.Rows(i).Item("Proportion") = CType(db.Rows(i).Item("MaintainDayNum") / Total * 100, Integer)
                            Else
                                db.Rows(i).Item("Proportion") = "0"
                            End If
                        End If
                    Next
                    Dim r As DataRow
                    r = db.NewRow()
                    r("Day") = "完成之報修總比數"
                    r("MaintainDayNum") = Total
                    r("Proportion") = "100"
                    If Total = 0 Then
                        r("Proportion") = "0"
                    End If

                    db.Rows.Add(r)
                    GridView04.DataSource = db
                    GridView04.DataBind()
                    GridView04.Visible = True
                    Dim dc As New DataTable
                    dc = md.MAI3202_01_02Average(ApplyTimeS.Text, ApplyTimeE.Text)
                    If Not String.IsNullOrEmpty(dc.Rows(0).Item("Average").ToString) Then
                        dc.Rows(0).Item("Average") = FormatNumber(dc.Rows(0).Item("Average"), 2).ToString()
                    Else
                        dc.Rows(0).Item("Average") = "0"
                    End If
                    GridView04_01.DataSource = dc
                    GridView04_01.DataBind()
                    GridView04_01.Visible = True
                    div04.Visible = True
                    DivDate.Visible = True
                End If

            Case "05" '待料狀態
                Dim md As MAI2201_01 = New MAI2201_01()
                Dim db As New DataTable
                Dim Total As Integer = 0
                db = md.MAI3202_01_02Queliao(ApplyTimeS.Text, ApplyTimeE.Text)
                GridView05.DataSource = db
                GridView05.DataBind()
                GridView05.Visible = True
                div05.Visible = True
                DivDate.Visible = True
            Case "06" '排修人員處理次數
                Dim md As MAI2201_01 = New MAI2201_01()
                Dim db As New DataTable
                Dim dc As New DataTable
                Dim Total As Integer = 0
                db = md.MAI3202_01_02Process(ApplyTimeS.Text, ApplyTimeE.Text, "0") '維修人員
                dc = md.MAI3202_01_02Process(ApplyTimeS.Text, ApplyTimeE.Text, "1") '維修明細
                For i As Integer = 0 To db.Rows.Count - 1
                    Total = CType(Total + db.Rows(i).Item("Total"), Integer) '維修人員維修明細統計
                Next
                For i As Integer = 0 To db.Rows.Count - 1 '維修人員
                    For j As Integer = 0 To dc.Rows.Count - 1 '維修明細
                        If db.Rows(i).Item("MtUser_id") = dc.Rows(j).Item("MtUser_id") Then
                            If dc.Rows(j).Item("MtStatus_type").ToString = "001" Then '完成
                                db.Rows(i).Item("Complete") = dc.Rows(j).Item("Num") '完成數
                                db.Rows(i).Item("CompleteProportion") = CType(dc.Rows(j).Item("Num") / db.Rows(i).Item("Total") * 100, Integer) '比例
                            Else
                                db.Rows(i).Item("NonCompleteNum") = dc.Rows(j).Item("Num") '未完成數
                                db.Rows(i).Item("NonCompleteProportion") = CType(dc.Rows(j).Item("Num") / db.Rows(i).Item("Total") * 100, Integer) '比例
                            End If
                            db.Rows(i).Item("TotalPercentage") = FormatNumber(CType(db.Rows(i).Item("Total") / Total * 100, Integer), 0) '排休比例
                        End If
                    Next
                Next
                GridView06.DataSource = db
                GridView06.DataBind()
                GridView06.Visible = True
                '完成案件排休人員處裡滿意度統計結果________________________________________________________________________________________________________
                '找出所有完成的明細並統計其滿意度
                db = New DataTable
                dc = New DataTable
                db = md.MAI3202_01_02SatisfactoryCompletion(ApplyTimeS.Text, ApplyTimeE.Text, "0") '維修人員與完成總數
                dc = md.MAI3202_01_02SatisfactoryCompletion(ApplyTimeS.Text, ApplyTimeE.Text, "1") '維修明細與滿意度
                For i As Integer = 0 To db.Rows.Count - 1
                    For j As Integer = 0 To dc.Rows.Count - 1
                        If db.Rows(i).Item("MtUser_id") = dc.Rows(j).Item("MtUser_id") Then
                            If dc.Rows(j).Item("Satisfaction_type").ToString = "001" Then '非常滿意
                                db.Rows(i).Item("Complete001") = dc.Rows(j).Item("Satisfaction_typeNum")
                                db.Rows(i).Item("Complete001Proportion") = FormatNumber(CType(dc.Rows(j).Item("Satisfaction_typeNum") / db.Rows(i).Item("Total") * 100, Integer), 0) '非常滿意比例
                            ElseIf dc.Rows(j).Item("Satisfaction_type").ToString = "002" Then '滿意
                                db.Rows(i).Item("Complete002") = dc.Rows(j).Item("Satisfaction_typeNum")
                                db.Rows(i).Item("Complete002Proportion") = FormatNumber(CType(dc.Rows(j).Item("Satisfaction_typeNum") / db.Rows(i).Item("Total") * 100, Integer), 0) '滿意比例
                            ElseIf dc.Rows(j).Item("Satisfaction_type").ToString = "003" Then '普通
                                db.Rows(i).Item("Complete003") = dc.Rows(j).Item("Satisfaction_typeNum")
                                db.Rows(i).Item("Complete003Proportion") = FormatNumber(CType(dc.Rows(j).Item("Satisfaction_typeNum") / db.Rows(i).Item("Total") * 100, Integer), 0) '普通比例
                            ElseIf dc.Rows(j).Item("Satisfaction_type").ToString = "004" Then '不滿意
                                db.Rows(i).Item("Complete004") = dc.Rows(j).Item("Satisfaction_typeNum")
                                db.Rows(i).Item("Complete004Proportion") = FormatNumber(CType(dc.Rows(j).Item("Satisfaction_typeNum") / db.Rows(i).Item("Total") * 100, Integer), 0) '不滿意比例
                            ElseIf dc.Rows(j).Item("Satisfaction_type").ToString = "005" Then '非常不滿意
                                db.Rows(i).Item("Complete005") = dc.Rows(j).Item("Satisfaction_typeNum")
                                db.Rows(i).Item("Complete005Proportion") = FormatNumber(CType(dc.Rows(j).Item("Satisfaction_typeNum") / db.Rows(i).Item("Total") * 100, Integer), 0) '非常不滿意比例

                            End If
                            '未填寫
                            db.Rows(i).Item("Complete000") = CType(db.Rows(i).Item("Total") - db.Rows(i).Item("Complete001") - db.Rows(i).Item("Complete002") - db.Rows(i).Item("Complete003") - db.Rows(i).Item("Complete004") - db.Rows(i).Item("Complete005"), Integer)
                            db.Rows(i).Item("Complete000Proportion") = FormatNumber(CType(db.Rows(i).Item("Complete000") / db.Rows(i).Item("Total") * 100, Integer), 0) '未填寫比例
                        End If
                    Next
                Next
                GridView06_01.DataSource = db
                GridView06_01.DataBind()
                GridView06_01.Visible = True

                div06.Visible = True
                DivDate.Visible = True
        End Select
        GridView1Label.Text = "時間："
        If Not String.IsNullOrEmpty(ApplyTimeS.Text) Then
            GridView1Label.Text &= ApplyTimeS.Text.Substring(0, 3) & "/" & ApplyTimeS.Text.Substring(3, 2) & "/" & ApplyTimeS.Text.Substring(5, 2)
        End If
        GridView1Label.Text &= "-"
        If Not String.IsNullOrEmpty(ApplyTimeE.Text) Then
            GridView1Label.Text &= ApplyTimeE.Text.Substring(0, 3) & "/" & ApplyTimeE.Text.Substring(3, 2) & "/" & ApplyTimeE.Text.Substring(5, 2)
        End If
    End Sub
    Protected Sub ResetButton(sender As Object, e As EventArgs) Handles ResetBtn.Click '重置按鈕
        ApplyTimeS.Text = ""
        ApplyTimeE.Text = ""
        StatisticalCategories.SelectedValue = "01"
        div01.Visible = False
        div02.Visible = False
        div03.Visible = False
        div04.Visible = False
        div05.Visible = False
        div06.Visible = False
        DivDate.Visible = False
    End Sub
End Class


