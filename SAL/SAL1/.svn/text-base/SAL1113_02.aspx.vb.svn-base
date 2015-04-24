Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.SqlClient
Imports SAL.Logic
Imports System.Transactions
Imports System.Drawing

Partial Class SAL1113_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        hfGuidList.Value = Request.QueryString("guidlist")
        ShowReSendData()

        hdPID.Value = LoginManager.UserId
        ShowGridView()
        InitControl()
        initData()
    End Sub

    Protected Sub ShowReSendData()
        Dim org As String = Request.QueryString("org")
        Dim fid As String = Request.QueryString("fid")

        If Not String.IsNullOrEmpty(org) AndAlso Not String.IsNullOrEmpty(fid) Then
            Dim pp16m As New FSC.Logic.CPAPP16M()
            Dim outfee As New SAL_OfficialoutFee()
            Dim dt As DataTable = outfee.GetDataByOrgFid(org, fid)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                hdPID.Value = dt.Rows(0)("Id_card").ToString()

                'guidlist &= PPIDNO & "|" & PPBUSTYPE & "|" & PPBUSDATEB & "|" & PPTIMEB & "|" & PPGUID & ","
                Dim guidlist As String = ""
                For Each dr As DataRow In dt.Rows
                    Dim ppguid As String = dr("ppguid").ToString()
                    Dim pdt As DataTable = pp16m.GetDataByPpguid(ppguid)
                    If pdt IsNot Nothing AndAlso pdt.Rows.Count > 0 Then
                        Dim pdr As DataRow = pdt.Rows(0)
                        guidlist &= pdr("PPIDNO").ToString() & "|" & pdr("PPBUSTYPE").ToString() & "|" & pdr("PPBUSDATEB").ToString() & "|" & pdr("PPTIMEB").ToString() & "|" & pdr("ppguid").ToString() & ","
                    End If
                Next

                hfGuidList.Value = guidlist.TrimEnd(",")

                cbConfirm.Text = "確認"
            End If

        End If

    End Sub

    Protected Sub initData()
        Dim Officialout_dates As String = String.Empty

        For Each i As ListItem In ddlOfficialout_date.Items
            Officialout_dates += i.Value + ","
        Next

        If Not String.IsNullOrEmpty(Officialout_dates) Then
            For Each Officialout_date In Officialout_dates.TrimEnd(",").Split(",")
                Dim tmp As DataTable = New FSC.Logic.LeaveMainDetail().getData(ddlGuid.SelectedValue.Split("|")(4).ToString(), Officialout_date)
                ddlOfficialout_date.SelectedValue = Officialout_date
                If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                    tbPlace_start.Text = tmp.Rows(0)("Start_place").ToString
                    tbPlace_end.Text = tmp.Rows(0)("End_place").ToString
                    tbIntroduction.Text = tmp.Rows(0)("Reason").ToString
                End If

                Save(True)
            Next
        End If
    End Sub

#Region "顯示List資料"
    Protected Sub ShowGridView()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim idcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim guids() As String = hfGuidList.Value.Split(",")

        Dim pp16m As New FSC.Logic.CPAPP16M()
        Dim bll As New SAL1113()
        Dim dt As New DataTable

        For Each guid As String In guids
            'Dim ppdt As DataTable = pp16m.GetCPAPP16MByFlow_id(guid)
            'If ppdt Is Nothing OrElse ppdt.Rows.Count <= 0 Then
            '    Continue For
            'End If

            'Dim PPIDNO As String = ppdt.Rows(0)("PPIDNO").ToString()
            'Dim PPBUSTYPE As String = ppdt.Rows(0)("PPBUSTYPE").ToString()
            'Dim PPBUSDATEB As String = ppdt.Rows(0)("PPBUSDATEB").ToString()
            'Dim PPTIMEB As String = ppdt.Rows(0)("PPTIMEB").ToString()

            Dim PPIDNO As String = guid.Split("|")(0).ToString()
            Dim PPBUSTYPE As String = guid.Split("|")(1).ToString()
            Dim PPBUSDATEB As String = guid.Split("|")(2).ToString()
            Dim PPTIMEB As String = guid.Split("|")(3).ToString()
            Dim PPGUID As String = guid.Split("|")(4).ToString()

            Dim tmp_dt As DataTable = bll.GetSAL1113_02DataByPPGUID(PPIDNO, PPBUSTYPE, PPGUID)


            If dt Is Nothing Then
                dt = tmp_dt.Clone()
            End If
            dt.Merge(tmp_dt)
        Next

        gvList.DataSource = dt
        gvList.DataBind()

        '已送出申請，就不能再重複送出，除非被退回
        If dt.Rows.Count > 0 Then
            If dt.Rows(0)("Status").ToString() = "yet" Then
                cbConfirm.Visible = False
            End If
        End If

        tbList.Visible = IIf(gvList.Rows.Count > 0, True, False)
        cbBack2.Visible = IIf(gvList.Rows.Count > 0, False, True)


    End Sub
#End Region

#Region "初始化控制項"
    Protected Sub InitControl()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim idcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        Me.hfAction.Value = "add"
        Me.tbRecipnumber.Text = ""
        Me.tbSudden.Text = ""
        Me.tbTrain.Text = ""
        Me.tbPlane.Text = ""
        Me.tbNote.Text = ""
        Me.tbLive.Text = ""
        Me.tbFood.Text = ""
        Me.tbCar.Text = ""
        Me.tbBoat.Text = ""

        'Dim empType As String = New FSC.Logic.Personnel().GetColumnValue("Employee_type", idcard)
        'If empType = "1" Or empType = "5" Or empType = "10" Then
        '    'for正式職員(1)、約聘僱(5)、特約(10)
        '    hdFormID.Value = "002015"
        'ElseIf empType = "3" Then
        '    'for技工工友(3)
        '    hdFormID.Value = "002016"
        'ElseIf empType = "8" Then
        '    'for司機(8)
        '    hdFormID.Value = "002017"
        'End If
        hdFormID.Value = "002002"
        hdFlow_ID.Value = New SYS.Logic.FlowId().GetFlowId(Orgcode, hdFormID.Value)


        Dim guids() As String = hfGuidList.Value.Split(",")
        Dim pp16m As New FSC.Logic.CPAPP16M()

        ddlGuid.Items.Clear()
        For Each guid As String In guids
            Dim PPGUID As String = guid.Split("|")(4).ToString()

            '        '
            Dim dtOfee As DataTable = New SAL_OfficialoutFee().GetDataByPPGUID(PPGUID)
            If dtOfee.Rows.Count > 0 Then
                Select Case dtOfee.Rows(0)("Status").ToString()
                    Case "yet"
                        ApplyForm.Visible = False
                        cbConfirm.Visible = False
                    Case "done"
                        ApplyForm.Visible = False
                        cbConfirm.Visible = False
                    Case Else
                        ApplyForm.Visible = True
                        cbConfirm.Visible = True
                End Select
                hdFlow_ID.Value = dtOfee.Rows(0)("Flow_id").ToString()
            End If
            If Not ddlGuid.Items.Contains(New ListItem(PPGUID, guid)) Then
                ddlGuid.Items.Add(New ListItem(PPGUID, guid))
            End If
        Next

        For Each guid As String In guids
            InitInput(guid)
            Exit For
        Next

        btnSave.Text = "新增"
        cbCancel.Visible = False
        ddlGuid.Enabled = True
        ddlOfficialout_date.Enabled = True
        hdbudget_type.Value = "001"

        tbPlace_start.Text = ""
        tbPlace_end.Text = ""
        'If Orgcode = "367040000D" Then
        '    '檢查局, 顯示複製前筆按鈕
        '    cbCopy.Visible = True
        'End If

    End Sub

    Protected Sub ddlGuid_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGuid.SelectedIndexChanged
        Dim guid As String = ddlGuid.SelectedValue()
        InitInput(guid)
        initData()
    End Sub

    Protected Sub InitInput(ByVal guid As String)
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim idcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        Dim pp16m As New FSC.Logic.CPAPP16M()
        Dim bll As New SAL1113()

        ddlOfficialout_date.Items.Clear()

        Dim PPIDNO As String = guid.Split("|")(0).ToString()
        Dim PPBUSTYPE As String = guid.Split("|")(1).ToString()
        Dim PPBUSDATEB As String = guid.Split("|")(2).ToString()
        Dim PPTIMEB As String = guid.Split("|")(3).ToString()
        Dim PPGUID As String = guid.Split("|")(4).ToString()
        Dim PPHOLIDAY As String = ""
        Dim PPBUSDATEE As String = ""

        'Dim dt As DataTable = pp16m.GetDataByPK(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB)
        Dim dt As DataTable = pp16m.GetDataByOfficialFee(PPIDNO, PPBUSTYPE, PPGUID)

        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows

            PPBUSTYPE = dr("PPBUSTYPE").ToString()
            PPBUSDATEB = dr("PPBUSDATEB").ToString()
            PPBUSDATEE = dr("PPBUSDATEE").ToString()
            PPTIMEB = dr("PPTIMEB").ToString()
            PPHOLIDAY = dr("PPHOLIDAY").ToString() '合計是否含假日

            'hsien 20120822
            Dim tmp_dt As DataTable = bll.GetSAL1113_02Data(idcard, PPBUSTYPE, PPBUSDATEB, PPTIMEB, PPGUID)

            Dim dateb As Date = FSC.Logic.DateTimeInfo.GetPublicDate(PPBUSDATEB)
            Dim datee As Date = FSC.Logic.DateTimeInfo.GetPublicDate(PPBUSDATEE)
            Do
                Dim sd As String = FSC.Logic.DateTimeInfo.GetRocDate(dateb)

                If hfAction.Value <> "update" Then
                    Dim drs() As DataRow = tmp_dt.Select(String.Format("Officialout_date='{0}'", sd))
                    If drs.Length > 0 Then
                        If dateb = datee Then
                            Exit Do
                        End If

                        dateb = dateb.AddDays(1)
                        Continue Do '有申請過的日期不顯示 hsien 20120822
                    End If
                End If

                Dim ht As Hashtable = FSC.Logic.Content.getWorkTime(idcard, sd)

                'If "True".Equals(ht("OFFDAY").ToString()) And Not "1".Equals(PPHOLIDAY) Then
                '    If dateb = datee Then Exit Do
                '    dateb = dateb.AddDays(1)
                '    Continue Do
                'End If

                ddlOfficialout_date.Items.Add(New ListItem(sd, sd))

                If dateb = datee Then Exit Do
                dateb = dateb.AddDays(1)


            Loop

            If i = 0 Then
                'tbPlace_start.Text = "屏東市"
                'tbPlace_end.Text = dr("PPBUSPLACE").ToString()
                'tbPlace_start.Text = dr("PPBUSPLACE").ToString()
                'tbIntroduction.Text = dr("PPREASON").ToString()

                Dim tmp As DataTable = New FSC.Logic.LeaveMainDetail().getData(PPGUID, ddlOfficialout_date.SelectedValue)
                If tmp IsNot Nothing AndAlso tmp.Rows.Count > 0 Then
                    tbPlace_start.Text = tmp.Rows(0)("DetailPlace").ToString 'New SYS.Logic.CODE().GetDataDESC("023", "007", tmp.Rows(0)("City").ToString)
                    tbIntroduction.Text = tmp.Rows(0)("Reason").ToString
                Else
                    tbPlace_start.Text = ""
                    tbIntroduction.Text = ""
                End If

                hfOfficialout_dateb.Value = dr("PPBUSDATEB").ToString()
                hfOfficialout_timeb.Value = dr("PPTIMEB").ToString()
                hfOfficialout_type.Value = dr("PPBUSTYPE").ToString()
            End If
            i += 1
        Next
    End Sub

#End Region

#Region "每列資料特別處理"
    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim Status As String = CType(e.Row.FindControl("hfStatus"), HiddenField).Value

            'done:送出則不能再修改

            If Status = "done" Then
                CType(e.Row.FindControl("btnDelete"), Button).Enabled = False
                CType(e.Row.FindControl("cbUpdate"), Button).Enabled = False
            ElseIf Status = "yet" Then
                cbPrint.Visible = True
                CType(e.Row.FindControl("btnDelete"), Button).Enabled = False
                CType(e.Row.FindControl("cbUpdate"), Button).Enabled = False
            Else
                cbPrint.Visible = True
                CType(e.Row.FindControl("btnDelete"), Button).Enabled = True
                CType(e.Row.FindControl("cbUpdate"), Button).Enabled = True
                CType(e.Row.FindControl("btnDelete"), Button).OnClientClick = "return confirm('確定要刪除此筆嗎?');"
            End If



        End If
    End Sub
#End Region

#Region "取消修改動作"
    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        InitControl()
    End Sub
#End Region

#Region "點選修改後，將資料帶到下方維護欄"

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim row As GridViewRow = CType(sender, Button).NamingContainer
        ShowOne(row)
        btnSave.Text = "確認"
        cbCancel.Visible = True
    End Sub

    Protected Sub ShowOne(ByVal row As GridViewRow)
        Dim hfSerial_nos As HiddenField = CType(row.FindControl("hfSerial_nos"), HiddenField)

        Dim bll As New SAL_OfficialoutFee()
        Dim dt As DataTable = bll.GetDataByKeys(hfSerial_nos.Value)

        If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then

            If dt.Rows.Count > 0 Then
                Me.hfAction.Value = "update"

                Try
                    '不就只有一個guid？
                    'ddlGuid.SelectedValue = dt.Rows(0)("id_card").ToString() & "|" & dt.Rows(0)("Officialout_type") & "|" & dt.Rows(0)("Officialout_dateb") & "|" & dt.Rows(0)("Officialout_timeb") & "|" & dt.Rows(0)("ppguid").ToString()
                    ddlGuid.Enabled = False

                    InitInput(ddlGuid.SelectedValue())
                    ddlOfficialout_date.SelectedValue = CastTypeFun.CastObjectToString(dt.Rows(0)("Officialout_Date"))
                    ddlOfficialout_date.Enabled = False
                Catch ex As Exception
                    'ddlOfficialout_date.SelectedValue = "" '避免找不到選項, 而產生的exception
                End Try


                tbPlace_start.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Place_start"))
                tbPlace_end.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Place_end"))
                tbIntroduction.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Introduction"))
                tbPlane.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Plane"))
                tbCar.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Car"))
                tbTrain.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Train"))
                tbBoat.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Boat"))
                tbLive.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Live"))
                tbFood.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Food"))
                tbSudden.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Sudden"))
                tbRecipnumber.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Recipnumber"))
                tbNote.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Note"))

                'Me.hfOrgcode.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Orgcode"))
                'Me.hfDepart_id.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Depart_id"))
                'Me.hfId_card.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Id_card"))

                Me.hfSerial_nos.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Serial_nos"))
                Me.hdFlow_ID.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Flow_id"))



            End If
        End If
    End Sub
#End Region

#Region "刪除"
    Protected Sub gvList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvList.RowDeleting
        Dim row As GridViewRow = CType((CType(sender, GridView)).Rows(e.RowIndex), GridViewRow)
        'Dim hfOrgcode As HiddenField = CType(row.FindControl("hfOrgcode"), HiddenField)
        'Dim hfDepartId As HiddenField = CType(row.FindControl("hfDepartId"), HiddenField)
        'Dim hfIdCard As HiddenField = CType(row.FindControl("hfIdCard"), HiddenField)
        Dim hfSerial_nos As HiddenField = CType(row.FindControl("hfSerial_nos"), HiddenField)

        Try
            Dim bll As New SAL_OfficialoutFee
            bll.DeleteData(hfSerial_nos.Value)

            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            ShowGridView()

            InitControl()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteFail)
        End Try
    End Sub
#End Region

#Region "儲存"

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Save()
    End Sub

    Protected Sub Save(Optional ByVal isInit As Boolean = False)
        Dim outfee As New SAL.Logic.SAL_OfficialoutFee
        Dim m05 As New FSC.Logic.Personnel()
        Dim dt05 As DataTable
        Dim PPIDNO As String = ddlGuid.SelectedValue().Split("|")(0).ToString()
        Dim PPBUSTYPE As String = ddlGuid.SelectedValue().Split("|")(1).ToString()
        Dim PPBUSDATEB As String = ddlGuid.SelectedValue().Split("|")(2).ToString()
        Dim PPTIMEB As String = ddlGuid.SelectedValue().Split("|")(3).ToString()
        Dim PPGUID As String = ddlGuid.SelectedValue().Split("|")(4).ToString()

        '(0)檢查各項費用是否超過上限
        Dim msg As String = CheckFeeLimit()
        If msg <> "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
            Exit Sub
        End If

        '(1)先由CPAPE05M抓取Title_no與Job_Level
        Dim titleNo As String = ""
        Dim jobLevel As String = ""
        Dim departID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id) '單位代號
        'Dim sub_departID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Sub_DepartID)
        Dim DeparyName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName) '單位名稱
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)  '機關代碼
        Dim cardID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card) '身份証字號
        Dim personnel_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
        Dim ApplyName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        'dt05 = m05.GetDataByCondition(orgcode, departID, cardID)
        dt05 = m05.GetDataByIdCard(cardID)
        Try
            titleNo = CastTypeFun.CastObjectToString(dt05.Rows(0)("title_no"))
            jobLevel = CastTypeFun.CastObjectToString(dt05.Rows(0)("level"))

        Catch ex As Exception
        End Try

        If Not String.IsNullOrEmpty(tbTrain.Text) AndAlso Not CommonFun.IsNum(tbTrain.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "火車費需為數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbCar.Text) AndAlso Not CommonFun.IsNum(tbCar.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "汽車及捷運費需為數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbPlane.Text) AndAlso Not CommonFun.IsNum(tbPlane.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "飛機及高鐵費需為數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbBoat.Text) AndAlso Not CommonFun.IsNum(tbBoat.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "船舶費需為數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbFood.Text) AndAlso Not CommonFun.IsNum(tbFood.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "雜費費需為數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbLive.Text) AndAlso Not CommonFun.IsNum(tbLive.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "住宿費費需為數字!")
            Return
        End If
        If Not String.IsNullOrEmpty(tbSudden.Text) AndAlso Not CommonFun.IsNum(tbSudden.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "住宿加計交通費需為數字!")
            Return
        End If

        '(2)insert or update資料
        Dim nullDB As DBNull = DBNull.Value
        outfee.Depart_id = departID
        outfee.Title_no = titleNo
        outfee.Job_Level = jobLevel
        outfee.Officialout_Date = ddlOfficialout_date.SelectedValue()
        outfee.Place_start = tbPlace_start.Text.Trim()
        outfee.Place_end = tbPlace_end.Text.Trim()
        outfee.Introduction = tbIntroduction.Text.Trim()
        outfee.Plane = CastTypeFun.CastObjectToInteger(tbPlane.Text, 0)
        outfee.Car = CastTypeFun.CastObjectToInteger(tbCar.Text, 0)
        outfee.Train = CastTypeFun.CastObjectToInteger(tbTrain.Text, 0)
        outfee.Boat = CastTypeFun.CastObjectToInteger(tbBoat.Text, 0)
        outfee.Live = CastTypeFun.CastObjectToInteger(tbLive.Text, 0)
        outfee.Food = CastTypeFun.CastObjectToInteger(tbFood.Text, 0)
        outfee.Sudden = CastTypeFun.CastObjectToInteger(tbSudden.Text, 0)
        outfee.Recipnumber = tbRecipnumber.Text.Trim()
        outfee.Note = tbNote.Text.Trim()
        outfee.Others = 0
        outfee.ppguid = PPGUID
        outfee.Status = ""
        outfee.Pay_Mark = "0"
        outfee.Flow_ID = hdFlow_ID.Value

        Dim bll As New SAL1113()
        'Dim dtData As DataTable = bll.GetFSC1306_02Data(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB, PPGUID)
        Dim dtData As DataTable = bll.GetSAL1113_02DataByPPGUID(PPIDNO, PPBUSTYPE, PPGUID)

        outfee.Officialoutfee_type = "1"

        If Not isInit Then
            If outfee.Plane + outfee.Car + outfee.Train + outfee.Boat + outfee.Live + outfee.Food + outfee.Sudden = 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請至少填寫一個金額!")
                Return
            End If
        End If

        '預算來源
        outfee.budget_type = New SAL1113().GetLastBudget(PPIDNO, outfee.Officialoutfee_type, PPGUID)
        hdbudget_type.Value = outfee.budget_type

        If hfAction.Value = "update" Then
            outfee.Serial_nos = hfSerial_nos.Value
            outfee.UpdateData()
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
        Else
            outfee.Orgcode = orgcode
            outfee.Depart_id = departID
            outfee.Id_card = cardID
            outfee.Officialout_dateb = hfOfficialout_dateb.Value
            outfee.Officialout_timeb = hfOfficialout_timeb.Value
            outfee.Officialout_type = hfOfficialout_type.Value
            outfee.InsertData()

            If Not isInit Then
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            End If
        End If

        InitControl()
        ShowGridView() '更新清單資料
    End Sub

#End Region

#Region "儲存前, 檢核費用上限"

    Protected Function CheckFeeLimit() As String
        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))

        Dim msg As String = ""

        Dim liveLimit As Integer
        Dim foodLimit As Integer = 400

        If psn.Degree_code = "H40" Then '特任
            liveLimit = 2200
        ElseIf psn.Degree_code.IndexOf("P1") >= 0 Then '簡任10~14職等
            liveLimit = 1800
        Else
            liveLimit = 1600
        End If

        If CastTypeFun.CastObjectToInteger(tbLive.Text, 0) > liveLimit Then
            msg += "住宿費不得超過" & liveLimit & "。"
        End If

        If CastTypeFun.CastObjectToInteger(tbFood.Text, 0) > foodLimit Then
            msg += "雜費不得超過" & foodLimit & "。"
        End If

        Return msg

    End Function

#End Region

#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvList.PageIndex = e.NewPageIndex
        ShowGridView()
    End Sub
#End Region

#Region "送出"
    Protected Sub cbConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConfirm.Click
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id) '單位代號
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)  '機關代碼
        Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card) '身份証字號
        Dim guids() As Object = hfGuidList.Value.Split(",")
        Dim gids As New ArrayList()
        Dim bll As New SAL_OfficialoutFee
        Dim pp16m As New FSC.Logic.CPAPP16M
        Dim hash As New Hashtable()
        Dim PPBEFOREM As Integer = 0
        Dim totalFee As Integer = 0
        Dim PPBUSTYPE As String = ""
        Dim PPBUSDATEB As String = ""
        Dim PPTIMEB As String = ""
        Dim PPGUID As String = ""
        Dim isUpdate As Boolean = False

        Dim vorg As String = Request.QueryString("org")
        Dim vfid As String = Request.QueryString("fid")
        If Not String.IsNullOrEmpty(vorg) AndAlso Not String.IsNullOrEmpty(vfid) Then
            isUpdate = True
        End If

        For Each g As String In guids
            gids.Add(g.Split("|")(4))
        Next

        For Each gvr As GridViewRow In gvList.Rows
            Dim ht As New Hashtable()
            Depart_id = CType(gvr.FindControl("hfDepartId"), HiddenField).Value
            Id_card = CType(gvr.FindControl("hfIdCard"), HiddenField).Value
            PPBUSTYPE = CType(gvr.FindControl("hfOfficialout_type"), HiddenField).Value
            PPBUSDATEB = CType(gvr.FindControl("hfOfficialout_dateb"), HiddenField).Value
            PPTIMEB = CType(gvr.FindControl("hfOfficialout_timeb"), HiddenField).Value
            PPGUID = CType(gvr.FindControl("hfppguid"), HiddenField).Value
            '預支費用
            PPBEFOREM = CommonFun.ConvertToInt(CType(gvr.FindControl("lbSudden"), Label).Text) + _
                            CommonFun.ConvertToInt(gvr.Cells(3).Text) + CommonFun.ConvertToInt(gvr.Cells(4).Text) + _
                            CommonFun.ConvertToInt(gvr.Cells(5).Text) + CommonFun.ConvertToInt(gvr.Cells(6).Text) + _
                            CommonFun.ConvertToInt(gvr.Cells(7).Text) + CommonFun.ConvertToInt(gvr.Cells(8).Text)

            totalFee += PPBEFOREM

            ht.Add("Depart_id", Depart_id)
            ht.Add("Id_card", Id_card)
            ht.Add("PPBUSTYPE", PPBUSTYPE)
            ht.Add("PPBUSDATEB", PPBUSDATEB)
            ht.Add("PPTIMEB", PPTIMEB)
            ht.Add("PPBEFOREM", PPBEFOREM)

            If hash.ContainsKey(PPGUID) Then
                Dim h As Hashtable = hash(PPGUID)
                PPBEFOREM = CType(h("PPBEFOREM"), Integer) + PPBEFOREM
                h("PPBEFOREM") = PPBEFOREM
                hash(PPGUID) = h
            Else
                hash.Add(PPGUID, ht)
            End If

            gids.Remove(PPGUID)
        Next

        If gids.Count > 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "尚有公差單的差旅費未完成填寫")
            Return
        End If

        Dim status As String = "yet"
        If isUpdate Then
            status = "apply"
        End If
        Dim reason As String = "國內差旅費申請，共" & totalFee & "元"

        Using trans As New TransactionScope
            Try
                Dim key As ICollection = hash.Keys
                For Each k In key
                    Dim ht As Hashtable = hash(k)
                    'yet:送出申請後，就不可以再修改跟刪除，尚未核銷
                    'done:送出申請後，就不可以再修改跟刪除，已核銷
                    'apply:退回
                    'pay_mark：要等到實際核銷才會是1，其他皆為0
                    bll.UpdateStatus(Orgcode, ht("Depart_id"), ht("Id_card"), ht("PPBUSTYPE"), ht("PPBUSDATEB"), ht("PPTIMEB"), status, "0")
                    pp16m.UpdateReMarkByCondition(ht("PPBEFOREM"), "1", ht("Id_card"), ht("PPBUSTYPE"), ht("PPBUSDATEB"), ht("PPTIMEB"))
                Next

                '送出申請才寫到flow
                '差旅費申請需走電子流程
                If isUpdate Then
                    Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(vorg, vfid)
                    f.CaseStatus = "2"
                    f.Reason = reason
                    f.Update()
                Else
                    Dim f As New SYS.Logic.Flow()
                    f.Orgcode = Orgcode
                    f.DepartId = Depart_id
                    f.ApplyIdcard = Id_card
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.WriterOrgcode = Orgcode
                    f.WriterDepartid = Depart_id
                    f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.WriteTime = Date.Now
                    f.FlowId = hdFlow_ID.Value
                    f.FormId = hdFormID.Value
                    f.Reason = reason
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.Budget_code = hdbudget_type.Value
                    SYS.Logic.CommonFlow.AddFlow(f)

                    bll.UpdateApplyDate(Orgcode, hdFlow_ID.Value, FSC.Logic.DateTimeInfo.GetRocDate(Now))
                End If

                trans.Complete()
            Catch fex As FlowException
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message)
                Return
            End Try

        End Using

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "務必按【列印】鍵，列印『國外差旅費申請表』、『公差批示情形表』，並送至人事/庶務單位業務負責人員。")
        ShowGridView()

    End Sub
#End Region

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click, cbBack2.Click

        If ViewState("BackUrl") IsNot Nothing Then
            Response.Redirect(ViewState("BackUrl").ToString())
        Else
            Response.Redirect("SAL1113_01.aspx?ym=" & Request.QueryString("ym") & "&ym1=" & Request.QueryString("ym1"))
        End If

    End Sub

#Region "列印"

    Protected Sub cbPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPrint.Click
        'Response.Redirect("FSC1306_RPT.aspx?guidlist=" & Request.QueryString("guidlist"))
        Printall()

    End Sub

    Protected Sub Printall()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim ID_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim Title_no As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
        Dim Personnel_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
        Dim User_name As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
        Dim rptFile As String = "~\Report\FSC\FSC1306_01.xls"

        Try
            'If Metadb_id = "2" Then
            '    rptFile = "~\Report\FSC\FSC1306_02.xls"
            'End If

            Dim OrgcodeName As String = New FSC.Logic.Org().GetOrgcodeName(Orgcode)
            Dim DepartName As String = New FSC.Logic.Org().GetDepartName(Orgcode, Depart_id)
            Dim TitleName As String = New SYS.Logic.CODE().GetDataDESC("023", "012", Title_no)
            Dim UserNames As String = Personnel_id & User_name

            Dim ap As New Excel.Application
            Dim wb As Excel.Workbook
            Dim ws As Excel.Worksheet

            ap.DisplayAlerts = False

            wb = ap.Workbooks.Add(HttpContext.Current.Server.MapPath(rptFile))

            Dim pp16m As New FSC.Logic.CPAPP16M()
            Dim guids() As String = hfGuidList.Value.Split(",")


            '公差資料
            Dim dt As New DataTable
            For Each guid As String In guids

                Dim PPIDNO As String = guid.Split("|")(0).ToString()
                Dim PPBUSTYPE As String = guid.Split("|")(1).ToString()
                Dim PPBUSDATEB As String = guid.Split("|")(2).ToString()
                Dim PPTIMEB As String = guid.Split("|")(3).ToString()

                Dim tmpdt As DataTable = pp16m.GetDataByPK(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB, "")
                If dt Is Nothing Then
                    dt = tmpdt.Clone()
                End If
                dt.Merge(tmpdt)
            Next

            Dim addCount As Integer = 0     '增加的列數
            Dim pageCount As Integer = 0    '頁數
            Dim rowIndex As Integer = 0
            Dim paperHeadCnt As Integer = 0 '需增加頁頭的數量

            '計算要補列數          
            Dim pageRowCount As Integer = 5
            If dt.Rows.Count Mod pageRowCount = 0 Then
                pageCount = (dt.Rows.Count \ pageRowCount)
            Else
                pageCount = (dt.Rows.Count \ pageRowCount) + 1
            End If
            addCount = pageCount * pageRowCount - dt.Rows.Count
            rowIndex = dt.Rows.Count
            For z As Integer = 1 To addCount
                Dim nRow As DataRow = dt.NewRow
                dt.Rows.InsertAt(nRow, rowIndex)
                rowIndex += 1
            Next

            '需增加頁頭的數量
            paperHeadCnt = (dt.Rows.Count \ 5) - 1

            '批核資料
            dt.Columns.Add("NO", GetType(String))
            dt.Columns.Add("Agree_time", GetType(String))
            dt.Columns.Add("Last_name", GetType(String))
            dt.Columns.Add("Replace_name", GetType(String))
            dt.Columns.Add("Agree_flag", GetType(String))
            dt.Columns.Add("Comment", GetType(String))

            Dim i As Integer = 1
            For Each dr As DataRow In dt.Rows

                If String.IsNullOrEmpty(dr("PPGUID").ToString()) Then
                    Continue For
                End If

                dr("NO") = i.ToString()
                'Dim fdt As DataTable = New Flow().GetLastDataByFlow_id(dr("PPGUID").ToString(), Orgcode)
                'For Each fdr As DataRow In fdt.Rows
                '    dr("Agree_time") = fdr("Agree_time").ToString()
                '    dr("Last_name") = fdr("Last_name").ToString()
                '    dr("Replace_name") = IIf(Not String.IsNullOrEmpty(fdr("Real_name").ToString()), fdr("Real_name").ToString(), fdr("Last_name").ToString())
                '    dr("Agree_flag") = New Flow().GetCase_status(fdr("Agree_flag").ToString())
                '    dr("Comment") = fdr("Comment").ToString()

                '    Dim carNote As String = dr("PPREASON").ToString()
                '    If Not String.IsNullOrEmpty(fdr("Place").ToString()) Then
                '        If fdr("Place").ToString().IndexOf("高鐵") > 0 Then
                '            carNote = carNote & "【請准來回搭乘高鐵】"
                '        ElseIf fdr("Place").ToString().IndexOf("公務車") > 0 Then
                '            carNote = carNote & "【搭乘公務車】"
                '        End If
                '    End If
                '    dr("PPREASON") = carNote
                'Next

                i += 1
            Next

            ws = CType(wb.Worksheets(2), Excel.Worksheet)
            ws.Name = "公差批示情形表"

            Dim j As Integer = 3
            Dim cnt As Integer = 1
            For Each dr As DataRow In dt.Rows

                If Not String.IsNullOrEmpty(dr("PPGUID").ToString()) Then
                    ws.Cells(j, 1).Value = dr("NO").ToString()
                    ws.Cells(j, 2).Value = dr("PPGUID").ToString()
                    ws.Cells(j, 3).Value = User_name
                    ws.Cells(j, 4).Value = FSC.Logic.DateTimeInfo.ToDisplay(dr("PPBUSDATEB").ToString()) & "~" & FSC.Logic.DateTimeInfo.ToDisplay(dr("PPBUSDATEE").ToString())
                    ws.Cells(j, 5).Value = CommonFun.getShowDayHours(dr("PPBUSDH").ToString())
                    ws.Cells(j, 6).Value = dr("PPREASON").ToString()
                    ws.Cells(j, 7).Value = dr("PPBUSPLACE").ToString()
                    ws.Cells(j, 8).Value = dr("Agree_time").ToString()
                    ws.Cells(j, 9).Value = dr("Last_name").ToString()
                    ws.Cells(j, 10).Value = dr("Replace_name").ToString()
                    ws.Cells(j, 11).Value = dr("Agree_flag").ToString()
                    ws.Cells(j, 12).Value = dr("Comment").ToString()
                End If

                j += 1
                ws.Rows(j).insert()

                If cnt Mod 5 = 0 Then
                    If paperHeadCnt > 0 Then
                        '頁頭
                        ws.Rows("1:2").Copy()
                        ws.Rows(j).insert()
                        ws.Cells(j, 1).value = Replace(ws.Cells(j, 1).value, "##P1##", OrgcodeName)
                        ws.Range(ws.Cells(j - 5, 1), ws.Cells(j - 1, 12)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                        j += 2
                        paperHeadCnt -= 1
                    End If
                End If

                cnt += 1
            Next
            ws.Cells(1, 1).value = Replace(ws.Cells(1, 1).value, "##P1##", OrgcodeName)
            ws.Range(ws.Cells(j - 5, 1), ws.Cells(j - 1, 12)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            'sheet 2 end


            'sheet 1 start 出差國內旅費表及收據
            Dim chName() As String = {"零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}
            Dim chName2() As String = {"", "壹拾", "貳拾", "參拾", "肆拾", "伍拾", "陸拾", "柒拾", "捌拾", "玖拾"}

            Dim dt2 As New DataTable()

            For Each guid2 As String In guids

                Dim PPIDNO As String = guid2.Split("|")(0).ToString()
                Dim PPBUSTYPE As String = guid2.Split("|")(1).ToString()
                Dim PPBUSDATEB As String = guid2.Split("|")(2).ToString()
                Dim PPTIMEB As String = guid2.Split("|")(3).ToString()
                Dim PPGUID As String = guid2.Split("|")(4).ToString()

                'Dim tmp_dt As DataTable = New FSC3207Bll().GetDataByIdCardAndPK(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB)
                'If dt2 Is Nothing Then
                '    dt2 = tmp_dt.Clone()
                'End If
                'dt2.Merge(tmp_dt)

                Dim tmp_dt As DataTable = New SAL1113().GetSAL1113_02DataByPPGUID(PPIDNO, PPBUSTYPE, PPGUID)


                If dt2 Is Nothing Then
                    dt2 = tmp_dt.Clone()
                End If
                dt2.Merge(tmp_dt)
            Next


            addCount = 0
            pageCount = 0
            rowIndex = 0
            paperHeadCnt = 0

            '計算要補列數  
            If dt2.Rows.Count Mod pageRowCount = 0 Then
                pageCount = (dt2.Rows.Count \ pageRowCount)
            Else
                pageCount = (dt2.Rows.Count \ pageRowCount) + 1
            End If
            addCount = pageCount * pageRowCount - dt2.Rows.Count
            rowIndex = dt2.Rows.Count
            For z As Integer = 1 To addCount
                Dim nRow As DataRow = dt2.NewRow
                dt2.Rows.InsertAt(nRow, rowIndex)
                rowIndex += 1
            Next

            ws = CType(wb.Worksheets(1), Excel.Worksheet)
            ws.Name = "國內差旅費申請表"

            Dim total As Integer = 0
            Dim total2 As Integer = 0
            Dim pageTotal As Integer = 0
            Dim k As Integer = 8

            Dim ws3 As Excel.Worksheet
            ws3 = CType(wb.Worksheets(3), Excel.Worksheet)

            'Dim paperHeadCnt As Integer = ((dt2.Rows.Count / (k - 1)) - 1)
            'If dt2.Rows.Count > 5 And 0 < (dt2.Rows.Count Mod (k - 1)) Then
            '    paperHeadCnt += 1
            'End If

            '需增加頁頭的數量
            paperHeadCnt = (dt2.Rows.Count \ 5) - 1

            cnt = 1
            pageCount = 0

            For Each dr As DataRow In dt2.Rows

                Dim car_note As String = ""
                'Dim fdt As DataTable = New Flow().GetLastDataByFlow_id(dr("PPGUID").ToString(), Orgcode)
                'If fdt IsNot Nothing Then
                '    For Each fdr As DataRow In fdt.Rows
                '        'hsien 20120810
                '        If Not String.IsNullOrEmpty(fdr("Place").ToString()) Then
                '            If fdr("Place").ToString().IndexOf("高鐵") > 0 Then
                '                car_note = "【請准來回搭乘高鐵】"
                '            ElseIf fdr("Place").ToString().IndexOf("公務車") > 0 Then
                '                car_note = "【搭乘公務車】"
                '            End If
                '        End If
                '    Next
                'End If


                If k <> 8 Then
                    ws.Rows(k).insert()
                    ws.Range(ws.Cells(k, 13), ws.Cells(k, 15)).Merge()
                    ws.Range(ws.Cells(k, 16), ws.Cells(k, 17)).Merge()
                    ws.Rows(k).Font.Size = 10
                    ws.Rows(k).RowHeight = 60
                    ws.Cells(k, 5).HorizontalAlignment = HorizontalAlign.Left
                End If

                ws.Cells(1, 1).value = Replace(ws.Cells(1, 1).value, "##P1##", OrgcodeName)
                ws.Cells(2, 4).value = Replace(ws.Cells(2, 4).value, "##P2##", DepartName)
                ws.Cells(2, 8).value = Replace(ws.Cells(2, 8).value, "##P3##", TitleName)
                ws.Cells(2, 13).value = Replace(ws.Cells(2, 13).value, "##P4##", "")
                ws.Cells(2, 19).value = Replace(ws.Cells(2, 19).value, "##P5##", UserNames)

                If Not String.IsNullOrEmpty(dr("Officialout_Date").ToString()) Then
                    ws.Cells(k, 1).value = dr("Officialout_Date").ToString().Substring(3, 2)
                    ws.Cells(k, 2).value = dr("Officialout_Date").ToString().Substring(5, 2)
                End If

                ws.Cells(k, 3).Value = dr("Place_start").ToString()
                ws.Cells(k, 4).Value = dr("Place_end").ToString()
                ws.Cells(k, 5).Value = dr("Introduction").ToString() & IIf(dr("Introduction").ToString() <> "", car_note, "")
                ws.Cells(k, 6).Value = dr("Self_car").ToString()
                ws.Cells(k, 7).Value = dr("Train").ToString()
                ws.Cells(k, 8).Value = dr("Car").ToString()
                ws.Cells(k, 9).Value = dr("Plane").ToString()
                ws.Cells(k, 10).Value = dr("Live").ToString()
                ws.Cells(k, 11).Value = dr("Sudden").ToString()
                ws.Cells(k, 12).Value = dr("Food").ToString()
                ws.Cells(k, 13).Value = dr("Special_note").ToString()
                ws.Cells(k, 16).Value = dr("Special_fee").ToString()

                total = CommonFun.getInt(dr("Train").ToString()) + CommonFun.getInt(dr("Self_car").ToString()) + CommonFun.getInt(dr("Car").ToString()) + _
                          CommonFun.getInt(dr("Plane").ToString()) + CommonFun.getInt(dr("Live").ToString()) + _
                          CommonFun.getInt(dr("Sudden").ToString()) + CommonFun.getInt(dr("Food").ToString()) + _
                          CommonFun.getInt(dr("Special_fee").ToString())
                total2 += CommonFun.getInt(total)
                pageTotal += CommonFun.getInt(total)

                If total <> 0 Then
                    ws.Cells(k, 18).Value = total
                End If

                ws.Cells(k, 19).Value = dr("Recipnumber").ToString()
                ws.Cells(k, 20).Value = dr("Note").ToString()

                '差旅費筆數5筆以上。
                If cnt Mod 5 = 0 Then
                    k += 1
                    ws.Range(ws.Cells(k - 5, 1), ws.Cells(k - 1, 20)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                    '頁尾
                    ws3.Rows("9:10").Copy()
                    ws.Rows(k).insert()

                    Dim pageTotal_str As String = pageTotal.ToString().PadLeft(6, "0")
                    Dim s1 As String = pageTotal_str.Substring(0, 1)
                    Dim s2 As String = pageTotal_str.Substring(1, 1)
                    Dim s3 As String = pageTotal_str.Substring(2, 1)
                    Dim s4 As String = pageTotal_str.Substring(3, 1)
                    Dim s5 As String = pageTotal_str.Substring(4, 1)
                    Dim s6 As String = pageTotal_str.Substring(5, 1)

                    ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P11##", chName2(CommonFun.getInt((s1))))
                    ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P6##", chName(CommonFun.getInt((s2))))
                    ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P7##", chName(CommonFun.getInt((s3))))
                    ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P8##", chName(CommonFun.getInt((s4))))
                    ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P9##", chName(CommonFun.getInt((s5))))
                    ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P10##", chName(CommonFun.getInt((s6))))

                    'PaperHead金額	
                    Dim showZero As Boolean = False
                    For X As Integer = 1 To 5
                        Dim C As Integer = X + 12
                        Dim S As String = pageTotal_str.Substring(X, 1)

                        If S <> "0" Then
                            showZero = True
                        End If

                        If showZero = True Then
                            ws.Cells(5 + (pageCount * 14), C).value = S
                        Else
                            ws.Cells(5 + (pageCount * 14), C).value = IIf(S = "0", "", S)
                        End If
                    Next
                    pageTotal = 0

                    If paperHeadCnt > 0 Then
                        k += 2
                        '頁首
                        ws3.Rows("1:7").Copy()
                        ws.Rows(k).insert()

                        ws.Cells(k, 1).value = Replace(ws.Cells(k, 1).value, "##P1##", OrgcodeName)
                        ws.Cells(k + 1, 4).value = Replace(ws.Cells(k + 1, 4).value, "##P2##", DepartName)
                        ws.Cells(k + 1, 8).value = Replace(ws.Cells(k + 1, 8).value, "##P3##", TitleName)
                        ws.Cells(k + 1, 13).value = Replace(ws.Cells(k + 1, 13).value, "##P4##", "")
                        ws.Cells(k + 1, 19).value = Replace(ws.Cells(k + 1, 19).value, "##P5##", UserNames)

                        k += 6
                        paperHeadCnt -= 1
                        pageCount += 1
                    End If

                    cnt = 0
                End If

                k += 1
                cnt += 1

            Next

            'Dim total_tmp As String = String.Empty
            'total_tmp = total2.ToString().PadLeft(6, "0")

            'Dim v As Boolean = False
            'For X As Integer = 1 To 5
            '    Dim C As Integer = X + 12

            '    Dim S As String = total_tmp.Substring(X, 1)

            '    If S <> "0" Then
            '        v = True
            '    End If

            '    If v = True Then
            '        ws.Cells(5, C).value = S
            '    Else
            '        ws.Cells(5, C).value = IIf(S = "0", "", S)
            '    End If
            'Next

            'Dim s1 As String = total_tmp.Substring(0, 1)
            'Dim s2 As String = total_tmp.Substring(1, 1)
            'Dim s3 As String = total_tmp.Substring(2, 1)
            'Dim s4 As String = total_tmp.Substring(3, 1)
            'Dim s5 As String = total_tmp.Substring(4, 1)
            'Dim s6 As String = total_tmp.Substring(5, 1)

            'ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P11##", chName2(CommonFun.getInt((s1))))
            'ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P6##", chName(CommonFun.getInt((s2))))
            'ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P7##", chName(CommonFun.getInt((s3))))
            'ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P8##", chName(CommonFun.getInt((s4))))
            'ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P9##", chName(CommonFun.getInt((s5))))
            'ws.Cells(k, 4).value = Replace(ws.Cells(k, 4).value, "##P10##", chName(CommonFun.getInt((s6))))

            'ws.Range(ws.Cells(8, 1), ws.Cells(k - 2, 20)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
            ws3.Delete()


            Dim ws4 As Excel.Worksheet


            Dim ws1 As Excel.Worksheet
            ws1 = CType(wb.Worksheets(1), Excel.Worksheet)

            Dim ws2 As Excel.Worksheet
            ws2 = CType(wb.Worksheets(2), Excel.Worksheet)

            Dim ws1Rows As Integer = ws1.UsedRange.Rows.Count / 14
            Dim ws2Rows As Integer = ws2.UsedRange.Rows.Count / 7
            Dim index As Integer = 0

            For i = 0 To ws1Rows - 1
                ws1.Copy(Type.Missing, wb.Sheets(wb.Sheets.Count))
                ws4 = CType(wb.Sheets(wb.Sheets.Count), Excel.Worksheet)
                ws4.Cells.Clear()

                'If "11.1" = ap.Version Then
                '    ws4.PageSetup.Orientation = ws1.PageSetup.Orientation
                '    ws4.PageSetup.PaperSize = ws1.PageSetup.PaperSize
                '    ws4.PageSetup.HeaderMargin = ws1.PageSetup.HeaderMargin
                '    ws4.PageSetup.PrintNotes = ws1.PageSetup.PrintNotes
                '    ws4.PageSetup.PrintComments = ws1.PageSetup.PrintComments
                'End If

                ws1.Rows((1 + (i * 14)) & ":" & ((i + 1) * 14)).Copy()
                ws4.Rows(1).insert()
                index = index + 14
                If i <= (ws2Rows - 1) Then


                    ws2.Copy(Type.Missing, wb.Sheets(wb.Sheets.Count))
                    ws4 = CType(wb.Sheets(wb.Sheets.Count), Excel.Worksheet)
                    ws4.Cells.Clear()

                    ws2.Rows((1 + (i * 7)) & ":" & ((i + 1) * 7)).Copy()
                    ws4.Rows(1).insert()
                End If
                index = index + 7
            Next
            If ws1Rows < ws2Rows Then
                For i = ws1Rows To ws2Rows - 1
                    ws2.Copy(Type.Missing, wb.Sheets(wb.Sheets.Count))
                    ws4 = CType(wb.Sheets(wb.Sheets.Count), Excel.Worksheet)
                    ws4.Cells.Clear()

                    ws2.Rows((1 + (i * 7)) & ":" & ((i + 1) * 7)).Copy()
                    ws4.Rows(1).insert()
                    index = index + 7
                Next
            End If






            'Dim index As Integer = 1
            'Dim step2 As Integer = 0
            'For i = 1 To ws1Rows
            '    Dim ws4Range As Excel.Range = ws4.Range(ws4.Cells(index, 1), ws4.Cells(index, 12))
            '    Dim ws1Range As Excel.Range = ws1.Range(ws1.Cells(i, 1), ws1.Cells(i, 12))
            '    ws4Range.Value = ws1Range.Value
            '    ws4Range.Borders.LineStyle = ws1Range.Borders.LineStyle
            '    ws4Range.Font.FontStyle = ws1Range.Font.FontStyle

            '    index = index + 1
            '    If (i Mod 14) = 0 Then
            '        If ws2Rows > ((step2 - 1) * 7) Then
            '            For k = 1 + (7 * step2) To (7 * (step2 + 1))
            '                ws4.Range(ws4.Cells(index, 1), ws4.Cells(index, 12)).Value = ws2.Range(ws2.Cells(k, 1), ws2.Cells(k, 12)).Value
            '                If (k Mod 7) = 0 Then
            '                    Exit For
            '                End If
            '                index = index + 1
            '            Next
            '            step2 = step2 + 1
            '        End If
            '    End If
            'Next
            'If ws2Rows > ((step2 - 1) * 7) Then
            '    For k = 1 + (7 * step2) To (7 * (step2 + 1))
            '        ws4.Range(ws4.Cells(index, 1), ws4.Cells(index, 12)).Value = ws2.Range(ws2.Cells(k, 1), ws2.Cells(k, 12)).Value
            '        If (k Mod 7) = 0 Then
            '            Exit For
            '        End If
            '        index = index + 1
            '    Next
            'End If

            ws1.Delete()
            ws2.Delete()
            wb.Worksheets(1).Activate()
            ExcelUtil.toFile(ap, wb, "國內差旅費申請表及公差批示情形表")
        Catch ex As Exception
            'AppException.ShowError_ByPage(ex)
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.ExportFail)
        End Try
    End Sub


#End Region

#Region "列印(未用)"
    Protected Sub cbPrint2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbPrint2.Click
        Report2()
    End Sub

    Protected Sub Report2()
        'Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        'Dim pp16m As New FSC.Logic.CPAPP16M()
        'Dim guids() As String = Request.QueryString("guidlist").Split(",")

        'Dim dt As New DataTable

        'For Each guid As String In guids
        '    Dim tmpdt As DataTable = pp16m.GetCPAPP16MByFlow_id(guid)
        '    If dt Is Nothing Then
        '        dt = tmpdt.Clone()
        '    End If
        '    dt.Merge(tmpdt)
        'Next

        'dt.Columns.Add("NO", GetType(String))
        'dt.Columns.Add("Agree_time", GetType(String))
        'dt.Columns.Add("Last_name", GetType(String))
        'dt.Columns.Add("Replace_name", GetType(String))
        'dt.Columns.Add("Agree_flag", GetType(String))
        'dt.Columns.Add("Comment", GetType(String))

        'Dim i As Integer = 1
        'For Each dr As DataRow In dt.Rows
        '    dr("NO") = i.ToString()
        '    Dim fdt As DataTable = New SYS.Logic.Flow().GetLastDataByFlow_id(dr("PPGUID"), Orgcode)
        '    For Each fdr As DataRow In fdt.Rows
        '        dr("Agree_time") = fdr("Agree_time").ToString()
        '        dr("Last_name") = fdr("Last_name").ToString()
        '        dr("Replace_name") = IIf(Not String.IsNullOrEmpty(fdr("Replace_name").ToString()), fdr("Replace_name").ToString(), fdr("Last_name").ToString())
        '        dr("Agree_flag") = New SYS.Logic.Flow().GetCase_status(fdr("Agree_flag").ToString())
        '        dr("Comment") = fdr("Comment").ToString()
        '    Next
        '    i += 1
        'Next

        'Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("~/Report/FSC1/FSC1306_RPT2.mht"), dt)
        'Dim params(1) As String
        'params(0) = New SYS.Logic.FSCorg().GetOrgcodeName(Orgcode)

        'rpt.ExportFileName = "公差批示情形表("")"
        'rpt.Param = params
        'rpt.ExportToExcel()
    End Sub

    Protected Sub Report()
        Dim idno As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim guids() As String = hfGuidList.Value.Split(",")

        Dim metadb_id As String = New FSC.Logic.Member().GetColumnValue("Metadb_id", idno)
        Dim pp16m As New FSC.Logic.CPAPP16M()

        Dim ap As New Excel.Application
        Dim wb As Excel.Workbook
        Dim ws As New Excel.Worksheet

        wb = ap.Workbooks.Add(Server.MapPath("~\Report\FSC1\FSC1306_RPT3.xls"))
        ws = CType(wb.Worksheets(1), Excel.Worksheet)

        '請假資料表頭
        ws.Range(ws.Cells(1, 1), ws.Cells(1, 9)).Merge()
        ws.Cells(1, 1) = "個人請假資料查詢列印"
        'ws.Cells(2, 1) = "起始日期：" & dateb
        'ws.Cells(2, 5) = "結束日期：" & datee
        ws.Cells(3, 1) = "姓名：" & New FSC.Logic.Member().GetColumnValue("User_name", idno)

        '請假資料
        Dim dt15 As New DataTable()

        For Each guid As String In guids
            Dim dt As DataTable = pp16m.GetCPAPP16MByFlow_id(guid)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Exit For
            End If
            Dim PPBUSDATEB As String = dt.Rows(0)("PPBUSDATEB").ToString()
            Dim PPBUSDATEE As String = dt.Rows(0)("PPBUSDATEE").ToString()
            Dim tmp_dt As DataTable = New FSC.Logic.CPAPO15M().getData(idno, PPBUSDATEB, PPBUSDATEE)
            If dt15 Is Nothing Then
                dt15 = tmp_dt.Clone()
            End If
            dt15.Merge(tmp_dt)
        Next

        Dim i As Integer = 7
        Dim total_hour As Integer = 0
        For Each dr15 As DataRow In dt15.Rows
            ws.Cells(i, 1) = dr15("POVDATEB")
            ws.Cells(i, 2) = dr15("POVTIMEB")
            ws.Cells(i, 3) = dr15("POVDATEE")
            ws.Cells(i, 4) = dr15("POVTIMEE")
            ws.Cells(i, 5) = dr15("DESCR")
            ws.Cells(i, 6) = dr15("POREMARK")
            ws.Range(ws.Cells(i, 6), ws.Cells(i, 6)).WrapText = True

            ws.Range(ws.Cells(i, 8), ws.Cells(i, 9)).Merge()
            ws.Cells(i, 8) = dr15("POVDAYS")
            total_hour += FSC.Logic.Content.ConvertToHours(dr15("POVDAYS"))
            ws.Rows(i + 1).insert()
            i += 1
        Next

        ws.Range(ws.Cells(7, 1), ws.Cells(i, 8)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

        If dt15.Rows.Count <= 0 Then
            ws.Range(ws.Cells(i, 1), ws.Cells(i, 9)).Merge()
            ws.Cells(i, 1) = "此區間無請假記錄!"
        Else
            ws.Range(ws.Cells(i, 1), ws.Cells(i, 7)).Merge()
            ws.Cells(i, 1) = "合計"
            ws.Range(ws.Cells(i, 8), ws.Cells(i, 9)).Merge()
            ws.Cells(i, 8) = FSC.Logic.Content.ConvertDayHours(total_hour)
            ws.Range(ws.Cells(i, 1), ws.Cells(i, 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
        End If

        '請假資料的格線及對齊
        ws.Range(ws.Cells(7, 1), ws.Cells(i, 9)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        '公出差的起始資料列
        Dim j As Integer = i + 3

        '公出差資料表頭
        ws.Range(ws.Cells(j, 1), ws.Cells(j, 9)).Merge()
        ws.Cells(j, 1) = "個人公差資料查詢列印"
        'ws.Cells(j + 1, 1) = "起始日期：" & dateb
        'ws.Cells(j + 1, 5) = "結束日期：" & datee
        ws.Cells(j + 2, 1) = "姓名：" & New FSC.Logic.Member().GetColumnValue("User_name", idno)

        '公出差資料
        Dim dt16 As New DataTable()

        For Each guid As String In guids
            Dim dt As DataTable = pp16m.GetCPAPP16MByFlow_id(guid)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Exit For
            End If
            Dim PPBUSDATEB As String = dt.Rows(0)("PPBUSDATEB").ToString()
            Dim PPBUSDATEE As String = dt.Rows(0)("PPBUSDATEE").ToString()
            Dim tmp_dt As DataTable = New FSC.Logic.CPAPP16M().GetData(idno, PPBUSDATEB, PPBUSDATEE)
            If dt16 Is Nothing Then
                dt16 = tmp_dt.Clone()
            End If
            dt16.Merge(tmp_dt)
        Next

        Dim x As Integer = j + 6
        Dim total_days As Integer = 0, total_hours As Integer = 0
        For Each dr16 As DataRow In dt16.Rows
            ws.Cells(x, 1) = dr16("PPBUSDATEB")
            ws.Cells(x, 2) = dr16("PPTIMEB")
            ws.Cells(x, 3) = dr16("PPBUSDATEE")
            ws.Cells(x, 4) = dr16("PPTIMEE")
            If dr16("PPBUSTYPE") = "1" Then
                ws.Cells(x, 5) = "公差"
            ElseIf dr16("PPBUSTYPE") = "2" Then
                ws.Cells(x, 5) = "公出"
            End If
            ws.Cells(x, 6) = dr16("PPBUSPLACE")
            ws.Cells(x, 7) = dr16("PPREASON")
            ws.Range(ws.Cells(x, 7), ws.Cells(x, 7)).WrapText = True

            Dim PPBUSDH As Double = dr16("PPBUSDH")
            Dim days As Integer = Fix(PPBUSDH).ToString()
            Dim hours As Integer = (PPBUSDH - Fix(PPBUSDH)) * 10

            ws.Cells(x, 8) = days
            ws.Cells(x, 9) = hours

            total_days += days
            total_hours += hours

            ws.Rows(x + 1).insert()
            x += 1
        Next

        If dt16.Rows.Count <= 0 Then
            ws.Range(ws.Cells(x, 1), ws.Cells(x, 9)).Merge()
            ws.Cells(x, 1) = "此區間無公差記錄!"
        Else
            ws.Range(ws.Cells(x, 1), ws.Cells(x, 7)).Merge()
            ws.Cells(x, 1) = "合計"

            ws.Cells(x, 8) = total_days
            ws.Cells(x, 9) = total_hours
        End If

        '請假資料的格線及對齊
        ws.Range(ws.Cells(j + 6, 1), ws.Cells(x, 9)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        ws.Range(ws.Cells(j + 6, 1), ws.Cells(x, 9)).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        ws.Range(ws.Cells(x, 1), ws.Cells(x, 7)).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

        ExcelUtil.toFile(ap, wb, "個人請假及公差資料")

    End Sub
#End Region

#Region "複製上筆(未用)"
    Protected Sub cbCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCopy.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)  '機關代碼
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim PPIDNO As String = Request.QueryString("PPIDNO")
        Dim PPBUSTYPE As String = Request.QueryString("PPBUSTYPE")
        Dim PPBUSDATEB As String = Request.QueryString("PPBUSDATEB")
        Dim PPTIMEB As String = Request.QueryString("PPTIMEB")

        Dim off As New SAL_OfficialoutFee()
        Dim dt As DataTable = off.GetDataByQuery(Orgcode, PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB)

        dt.DefaultView.Sort = " Serial_nos desc "

        If dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            ddlOfficialout_date.SelectedValue = dr("Officialout_Date").ToString
            tbPlace_start.Text = dr("place").ToString
            tbIntroduction.Text = dr("Introduction").ToString
            tbPlane.Text = dr("Plane").ToString
            tbCar.Text = dr("Car").ToString
            tbTrain.Text = dr("Train").ToString
            tbBoat.Text = dr("Boat").ToString
            tbLive.Text = dr("Live").ToString
            tbFood.Text = dr("food").ToString
            tbSudden.Text = dr("Sudden").ToString
            tbRecipnumber.Text = dr("Recipnumber").ToString
            tbNote.Text = dr("Note").ToString
        End If

    End Sub
#End Region


End Class


