Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.SqlClient
Imports SAL.Logic
Imports System.Transactions
Imports System.Drawing
Imports NPOI.Util
Imports NPOI.SS

Partial Class FSC1_FSC13_FSC1306_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

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

        Dim guids() As String = Request.QueryString("guidlist").Split(",")

        Dim bll As New SAL1113()
        Dim dt As New DataTable
        'Dim metadb_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.MetadbID)
        'Dim pp16m As New CPAPP16M(ConnectDB.GetCPADBString(metadb_id))
        Try

            For Each guid As String In guids

                Dim PPIDNO As String = guid.Split("|")(0).ToString()
                Dim PPBUSTYPE As String = guid.Split("|")(1).ToString()
                Dim PPBUSDATEB As String = guid.Split("|")(2).ToString()
                Dim PPTIMEB As String = guid.Split("|")(3).ToString()
                Dim PPGUID As String = guid.Split("|")(4).ToString()

                'Dim tmp_dt As DataTable = bll.GetFSC1306_02Data(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB, PPGUID)
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

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub
#End Region

#Region "初始化控制項"
    Protected Sub InitControl()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim idcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

        Me.hfAction.Value = "add"
        Me.tbRecipnumber.Text = ""
        Me.tbNote.Text = ""
        Me.tbPlane.Text = ""
        Me.tbBoat.Text = ""
        Me.tbLong_traffic.Text = ""
        Me.tbLife_fee.Text = ""
        Me.tbFee.Text = ""
        Me.tbInsurance.Text = ""
        Me.tbAdministrative_costs.Text = ""
        Me.tbGift_entertainment_expenses.Text = ""
        Me.tbIncidentals.Text = ""
        Me.tbRecipnumber.Text = ""

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

        Dim guids() As String = Request.QueryString("guidlist").Split(",")
        Dim pp16m As New FSC.Logic.CPAPP16M()

        ddlGuid.Items.Clear()
        For Each guid As String In guids
            Dim PPGUID As String = guid.Split("|")(4).ToString()

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

        'If Orgcode = "367040000D" Then
        '    '檢查局, 顯示複製前筆按鈕
        '    cbCopy.Visible = True
        'End If
    End Sub

    Protected Sub ddlGuid_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlGuid.SelectedIndexChanged
        Dim guid As String = ddlGuid.SelectedValue()
        InitInput(guid)
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

        Dim dt As DataTable = pp16m.GetCPAPP16MByFlow_id(PPGUID)
        'Dim dt As DataTable = pp16m.GetDataByPK(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB)

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
                    Dim drs() As DataRow = tmp_dt.Select("Officialout_date='" & sd & "'")
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
                tbPlace_start.Text = "臺灣"
                tbPlace_end.Text = dr("PPBUSPLACE").ToString()
                tbIntroduction.Text = dr("PPREASON").ToString()

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
                    ddlGuid.SelectedValue = dt.Rows(0)("id_card").ToString() & "|" & dt.Rows(0)("Officialout_type") & "|" & dt.Rows(0)("Officialout_dateb") & "|" & dt.Rows(0)("Officialout_timeb") & "|" & dt.Rows(0)("ppguid").ToString()
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
                tbBoat.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Boat"))

                tbLong_traffic.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Long_traffic"))
                tbLife_fee.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Life_fee"))
                tbFee.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Fee"))
                tbInsurance.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Insurance"))
                tbAdministrative_costs.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Administrative_costs"))
                tbGift_entertainment_expenses.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Gift_entertainment_expenses"))
                tbIncidentals.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Incidentals"))
                tbRecipnumber.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Recipnumber"))
                tbNote.Text = CastTypeFun.CastObjectToString(dt.Rows(0)("Note"))


                Me.hfSerial_nos.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Serial_nos"))
                Me.hdFlow_ID.Value = CastTypeFun.CastObjectToString(dt.Rows(0)("Flow_id"))
            End If
        End If
    End Sub
#End Region

#Region "刪除"
    Protected Sub gvList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvList.RowDeleting
        Dim row As GridViewRow = CType((CType(sender, GridView)).Rows(e.RowIndex), GridViewRow)
        Dim hfSerial_nos As HiddenField = CType(row.FindControl("hfSerial_nos"), HiddenField)

        Try
            Dim bll As New SAL_OfficialoutFee()
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
        Try
            Dim outfee As New SAL_OfficialoutFee()
            Dim m05 As New FSC.Logic.Personnel()
            Dim dt05 As DataTable
            Dim PPIDNO As String = ddlGuid.SelectedValue().Split("|")(0).ToString()
            Dim PPBUSTYPE As String = ddlGuid.SelectedValue().Split("|")(1).ToString()
            Dim PPBUSDATEB As String = ddlGuid.SelectedValue().Split("|")(2).ToString()
            Dim PPTIMEB As String = ddlGuid.SelectedValue().Split("|")(3).ToString()
            Dim PPGUID As String = ddlGuid.SelectedValue().Split("|")(4).ToString()

            '(0)檢查各項費用是否超過上限
            'Dim msg As String = CheckFeeLimit()
            'If msg <> "" Then
            '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
            '    Exit Sub
            'End If

            '(1)先由CPAPE05M抓取Title_no與Job_Level
            Dim titleNo As String = ""
            Dim jobLevel As String = ""
            Dim departID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id) '單位代號
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


            '(2)insert or update資料
            Dim nullDB As DBNull = DBNull.Value

            outfee.Officialoutfee_type = "2"

            outfee.Personnel_id = personnel_id
            outfee.Title_no = titleNo
            outfee.Job_Level = jobLevel
            outfee.Officialout_Date = ddlOfficialout_date.SelectedValue()
            outfee.Place_start = tbPlace_start.Text.Trim()
            outfee.Place_end = tbPlace_end.Text.Trim()
            outfee.Introduction = tbIntroduction.Text.Trim()
            outfee.Plane = CastTypeFun.CastObjectToInteger(tbPlane.Text, 0)
            outfee.Boat = CastTypeFun.CastObjectToInteger(tbBoat.Text, 0)

            outfee.Long_traffic = CastTypeFun.CastObjectToInteger(tbLong_traffic.Text, 0)
            outfee.Life_fee = CastTypeFun.CastObjectToInteger(tbLife_fee.Text, 0)
            outfee.fee = CastTypeFun.CastObjectToInteger(tbFee.Text, 0)
            outfee.Insurance = CastTypeFun.CastObjectToInteger(tbInsurance.Text, 0)
            outfee.Administrative_costs = CastTypeFun.CastObjectToInteger(tbAdministrative_costs.Text, 0)
            outfee.Gift_entertainment_expenses = CastTypeFun.CastObjectToInteger(tbGift_entertainment_expenses.Text, 0)
            outfee.Incidentals = CastTypeFun.CastObjectToInteger(tbIncidentals.Text, 0)


            outfee.Recipnumber = tbRecipnumber.Text.Trim()
            outfee.Note = tbNote.Text.Trim()
            outfee.Others = 0
            outfee.ppguid = PPGUID
            outfee.Status = ""
            outfee.Apply_date = ""
            outfee.Pay_Mark = "0"
            outfee.Officialoutfee_type = "2"    '國外差旅費
            outfee.Flow_ID = hdFlow_ID.Value

            Dim bll As New SAL1113()
            Dim dtData As DataTable = bll.GetSAL1113_02Data(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB, PPGUID)

            If Not isInit Then
                If outfee.Plane + outfee.Boat + outfee.Long_traffic + outfee.Life_fee + outfee.fee + outfee.Insurance + outfee.Administrative_costs + outfee.Gift_entertainment_expenses + outfee.Incidentals = 0 Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請至少填寫一個金額!")
                    Return
                End If
            End If

            '預算來源
            outfee.budget_type = New SAL1113().GetLastBudget(PPIDNO, outfee.Officialoutfee_type, PPGUID)
            hdbudget_type.Value = outfee.budget_type
            outfee.Total = outfee.Plane + outfee.Boat + outfee.Long_traffic + outfee.Life_fee + outfee.fee + outfee.Insurance + outfee.Administrative_costs + outfee.Gift_entertainment_expenses + outfee.Incidentals
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

        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

#End Region

#Region "儲存前, 檢核費用上限"

    Protected Function CheckFeeLimit() As String
        Dim idcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card) '身份証字號
        Dim bll As New SAL1113()
        Dim dt As DataTable = bll.GetFeeLimitByIdCard(idcard)

        Dim pecrkcodDesc As String = Nothing
        Dim pememcod As String = Nothing
        Dim pecrkcod As String = Nothing
        Dim pepoint As String = Nothing
        Dim pepointDesc As String = Nothing

        Dim msg As String = ""

        'Dim liveLimit As Integer
        'Dim foodLimit As Integer

        Try
            pecrkcodDesc = CastTypeFun.CastObjectToString(dt.Rows(0)("pecrkcodDesc"))
            'pememcod = CastTypeFun.CastObjectToString(dt.Rows(0)("pememcod"))
            pecrkcod = CastTypeFun.CastObjectToString(dt.Rows(0)("pecrkcod"))
            pepoint = CastTypeFun.CastObjectToString(dt.Rows(0)("pepoint"))
            pepointDesc = CastTypeFun.CastObjectToString(dt.Rows(0)("pepointDesc"))
        Catch ex As Exception
            '發生例外, 代表抓不到資料
            pecrkcodDesc = ""
            pememcod = ""
            pecrkcod = ""
            pepoint = ""
            pepointDesc = ""
        End Try

        'If pecrkcodDesc.IndexOf("特任") > 0 Then
        '    liveLimit = 2000
        'ElseIf pecrkcodDesc.IndexOf("簡任") > 0 OrElse (pecrkcod = "P09" AndAlso CastTypeFun.CastObjectToInteger(pepoint, 0) > 590) Then
        '    liveLimit = 1600
        'ElseIf (pecrkcodDesc.IndexOf("薦任") > 0 OrElse pememcod <> "3") AndAlso pecrkcod <> "K72" _
        '    AndAlso (pecrkcodDesc <> "null" OrElse pecrkcodDesc <> "") OrElse pepointDesc = "約聘人員" Then
        '    liveLimit = 1400
        'ElseIf pecrkcodDesc.IndexOf("薦任第九職等") > 0 OrElse pecrkcod = "K72" Then
        '    liveLimit = 1600
        'Else
        '    liveLimit = 1200
        'End If


        'If pecrkcodDesc.IndexOf("特任") > 0 Then
        '    foodLimit = 650
        'ElseIf pecrkcodDesc.IndexOf("簡任") > 0 OrElse (pecrkcod = "P09" AndAlso CastTypeFun.CastObjectToInteger(pepoint, 0) > 590) Then
        '    foodLimit = 550
        'ElseIf (pecrkcodDesc.IndexOf("薦任") > 0 OrElse pememcod <> "3") _
        '    AndAlso (pecrkcodDesc <> "null" OrElse pecrkcodDesc <> "") OrElse pepointDesc = "約聘人員" Then

        '    If pecrkcodDesc.IndexOf("九職等") > 0 Then
        '        foodLimit = 550
        '    Else
        '        foodLimit = 500
        '    End If
        'Else
        '    foodLimit = 450
        'End If


        'If CastTypeFun.CastObjectToInteger(tbLive.Text, 0) > liveLimit Then
        '    msg += "住宿費不得超過" & liveLimit & "。"
        'End If

        'If CastTypeFun.CastObjectToInteger(tbFood.Text, 0) > foodLimit Then
        '    msg += "膳雜費不得超過" & foodLimit & "。"
        'End If

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
        Dim guids() As Object = Request.QueryString("guidlist").Split(",")
        Dim gids As New ArrayList()
        Dim bll As New SAL_OfficialoutFee()
        Dim pp16m As New FSC.Logic.CPAPP16M()
        Dim hash As New Hashtable()
        Dim PPBEFOREM As Integer = 0
        Dim totalFee As Integer = 0
        Dim PPBUSTYPE As String = ""
        Dim PPBUSDATEB As String = ""
        Dim PPTIMEB As String = ""
        Dim isUpdate As Boolean = False
        Dim PPGUID As String = ""

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
            PPBEFOREM = CommonFun.ConvertToInt(gvr.Cells(5).Text) + _
                        CommonFun.ConvertToInt(gvr.Cells(6).Text) + CommonFun.ConvertToInt(gvr.Cells(7).Text) + _
                        CommonFun.ConvertToInt(gvr.Cells(8).Text) + CommonFun.ConvertToInt(gvr.Cells(9).Text) + _
                        CommonFun.ConvertToInt(gvr.Cells(10).Text) + CommonFun.ConvertToInt(gvr.Cells(11).Text) + _
                        CommonFun.ConvertToInt(gvr.Cells(12).Text) + CommonFun.ConvertToInt(gvr.Cells(13).Text)

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
        Dim reason As String = "國外差旅費申請，共" & totalFee & "元"


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
                    f.Reason = "國外差旅費申請"
                    f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                    f.Budget_code = hdbudget_type.Value
                    SYS.Logic.CommonFlow.AddFlow(f)

                    bll.UpdateApplyDate(Orgcode, hdFlow_ID.Value, FSC.Logic.DateTimeInfo.GetRocDate(Now))
                End If

                trans.Complete()
            Catch fex As Exception
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
            Response.Redirect("SAL1113_01.aspx?ym=" & Request.QueryString("ym") & "&ym1=" & Request.QueryString("ym1") & "&ot=2")
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
        Dim rptFile As String = "../../Report/SAL/SAL1113_03.mht"

        Try
            'If Metadb_id = "2" Then
            '    rptFile = "~\Report\FSC1\FSC1306_02.xls"
            'End If

            Dim OrgcodeName As String = New FSC.Logic.Org().GetOrgcodeName(Orgcode)
            Dim DepartName As String = New FSC.Logic.Org().GetDepartName(Orgcode, Depart_id)
            Dim TitleName As String = New SYS.Logic.CODE().GetFSCTitleName(Title_no)
            Dim UserNames As String = Personnel_id & User_name

            Dim pp16m As New FSC.Logic.CPAPP16M()
            Dim guids() As String = Request.QueryString("guidlist").Split(",")


            '公差資料
            'Dim rpt As CommonLib.DTReport
            Dim outfeeCounts As Integer = 1
            Dim book As NPOI.HSSF.UserModel.HSSFWorkbook
            Dim ms As New System.IO.MemoryStream()
            Using file As New FileStream(Server.MapPath("../../Report/SAL/SAL1113_03.xls"), FileMode.Open, FileAccess.Read)
                book = New NPOI.HSSF.UserModel.HSSFWorkbook(file)

                '設定報表字型
                Dim Style As NPOI.HSSF.UserModel.HSSFCellStyle = book.CreateCellStyle()
                Dim xls_Font As NPOI.HSSF.UserModel.HSSFFont = book.CreateFont()
                xls_Font.FontName = "新細明體"
                xls_Font.FontHeightInPoints = 10
                Style.SetFont(xls_Font)
                Style.BorderBottom = UserModel.BorderStyle.Thin
                Style.BorderLeft = UserModel.BorderStyle.Thin
                Style.BorderRight = UserModel.BorderStyle.Thin
                Style.BorderTop = UserModel.BorderStyle.Thin
                Style.WrapText = True

                Dim cell0 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell1 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell2 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell3 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell4 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell5 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell6 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell7 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell8 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell9 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell10 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell11 As NPOI.HSSF.UserModel.HSSFCell
                Dim cell12 As NPOI.HSSF.UserModel.HSSFCell

                For Each guid As String In guids
                    Dim dt As New DataTable

                    Dim PPIDNO As String = guid.Split("|")(0).ToString()
                    Dim PPBUSTYPE As String = guid.Split("|")(1).ToString()
                    Dim PPBUSDATEB As String = guid.Split("|")(2).ToString()
                    Dim PPTIMEB As String = guid.Split("|")(3).ToString()
                    Dim PPGUID As String = guid.Split("|")(4).ToString()

                    'Dim tmpdt As DataTable = pp16m.GetDataByPK(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB, "")
                    Dim tmpdt As DataTable = New SAL1113().GetSAL1113_02DataByPPGUID(PPIDNO, PPBUSTYPE, PPGUID)
                    If dt Is Nothing Then
                        dt = tmpdt.Clone()
                    End If
                    dt.Merge(tmpdt)

                    'rpt = New CommonLib.DTReport(Server.MapPath("../../Report/SAL/SAL1113_03.mht"), dt)

                    Dim plane_total As Integer = 0
                    Dim Boat_total As Integer = 0
                    Dim Long_traffic_total As Integer = 0
                    Dim Fee_total As Integer = 0
                    Dim insurance_total As Integer = 0
                    Dim Administrative_costs_total As Integer = 0
                    Dim Gift_entertainment_expenses_total As Integer = 0
                    Dim Life_fee_total As Integer = 0
                    Dim T_total As Integer = 0
                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            plane_total += CommonFun.ConvertToInt(dt.Rows(i)("Plane").ToString())
                            Boat_total += CommonFun.ConvertToInt(dt.Rows(i)("Boat").ToString())
                            Long_traffic_total += CommonFun.ConvertToInt(dt.Rows(i)("Long_traffic").ToString())
                            Fee_total += CommonFun.ConvertToInt(dt.Rows(i)("Fee").ToString())
                            insurance_total += CommonFun.ConvertToInt(dt.Rows(i)("insurance").ToString())
                            Administrative_costs_total += CommonFun.ConvertToInt(dt.Rows(i)("Administrative_costs").ToString())
                            Gift_entertainment_expenses_total += CommonFun.ConvertToInt(dt.Rows(i)("Gift_entertainment_expenses").ToString())
                            Life_fee_total += CommonFun.ConvertToInt(dt.Rows(i)("Life_fee").ToString())
                            T_total += CommonFun.ConvertToInt(dt.Rows(i)("total").ToString())
                        Next
                    End If


                    Dim sheet As NPOI.HSSF.UserModel.HSSFSheet = book.GetSheetAt(0)

                    If outfeeCounts > 1 Then
                        sheet = book.CloneSheet(0)
                        '要刪除sheet1複製過來的資料
                        For j As Integer = 17 To book.GetSheetAt(0).LastRowNum
                            sheet.ShiftRows(j, j, 1)
                        Next
                    End If

                    '工作計劃
                    sheet.GetRow(3).GetCell(2).SetCellValue("")
                    '費用科目
                    sheet.GetRow(4).GetCell(2).SetCellValue("")
                    '支出用途
                    sheet.GetRow(5).GetCell(2).SetCellValue("國外旅費")
                    '金額
                    Dim pageTotal_str As String = T_total.ToString().PadLeft(6, "0")
                    sheet.GetRow(4).GetCell(3).SetCellValue(pageTotal_str.Substring(0, 1))
                    sheet.GetRow(4).GetCell(4).SetCellValue(pageTotal_str.Substring(1, 1))
                    sheet.GetRow(4).GetCell(5).SetCellValue(pageTotal_str.Substring(2, 1))
                    sheet.GetRow(4).GetCell(6).SetCellValue(pageTotal_str.Substring(3, 1))
                    sheet.GetRow(4).GetCell(7).SetCellValue(pageTotal_str.Substring(4, 1))
                    sheet.GetRow(4).GetCell(8).SetCellValue(pageTotal_str.Substring(5, 1))
                    '用途說明
                    sheet.GetRow(3).GetCell(9).SetCellValue("國　外　旅　費")

                    'OrgCodeName
                    sheet.GetRow(13).GetCell(0).SetCellValue(sheet.GetRow(13).GetCell(0).StringCellValue.Replace("{0}", OrgcodeName))
                    '填報日期
                    sheet.GetRow(13).GetCell(10).SetCellValue(sheet.GetRow(13).GetCell(10).StringCellValue.Replace("{0}", (Now.Year - 1911).ToString.PadLeft(3, "0") & "/" & Now.ToString("MM/dd")))

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim row2 As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(i + 16)
                        cell0 = row2.CreateCell(0)
                        cell1 = row2.CreateCell(1)
                        cell2 = row2.CreateCell(2)
                        cell3 = row2.CreateCell(3)
                        cell4 = row2.CreateCell(4)
                        cell5 = row2.CreateCell(5)
                        cell6 = row2.CreateCell(6)
                        cell7 = row2.CreateCell(7)
                        cell8 = row2.CreateCell(8)
                        cell9 = row2.CreateCell(9)
                        cell10 = row2.CreateCell(10)
                        cell11 = row2.CreateCell(11)
                        cell12 = row2.CreateCell(12)

                        cell0.CellStyle = Style
                        cell0.SetCellValue(dt.Rows(i)("Officialout_Date").ToString())
                        cell1.CellStyle = Style
                        cell1.SetCellValue(dt.Rows(i)("Place_start").ToString() & "～" & dt.Rows(i)("Place_end").ToString())
                        cell2.CellStyle = Style
                        cell2.SetCellValue(dt.Rows(i)("Introduction").ToString())
                        cell3.CellStyle = Style
                        cell3.SetCellValue(CType(dt.Rows(i)("Plane").ToString(), Integer))
                        cell4.CellStyle = Style
                        cell4.SetCellValue(CType(dt.Rows(i)("Boat").ToString(), Integer))
                        cell5.CellStyle = Style
                        cell5.SetCellValue(CType(dt.Rows(i)("Long_traffic").ToString(), Integer))
                        cell6.CellStyle = Style
                        cell6.SetCellValue(CType(dt.Rows(i)("fee").ToString(), Integer))
                        cell7.CellStyle = Style
                        cell7.SetCellValue(CType(dt.Rows(i)("Insurance").ToString(), Integer))
                        cell8.CellStyle = Style
                        cell8.SetCellValue(CType(dt.Rows(i)("Administrative_costs").ToString(), Integer))
                        cell9.CellStyle = Style
                        cell9.SetCellValue(CType(dt.Rows(i)("Gift_entertainment_expenses").ToString(), Integer))
                        cell10.CellStyle = Style
                        cell10.SetCellValue(CType(dt.Rows(i)("Life_fee").ToString(), Integer))

                        Dim recipnumber As Integer = 0
                        If dt.Rows(i)("recipnumber").ToString().Length > 0 Then
                            recipnumber = CType(dt.Rows(i)("recipnumber").ToString(), Integer)
                        End If
                        cell11.CellStyle = Style
                        cell11.SetCellValue(recipnumber)
                        cell12.CellStyle = Style
                        cell12.SetCellValue(CType(dt.Rows(i)("Total").ToString(), Integer))
                    Next

                    '合計
                    Dim rowTotal As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 16)
                    Dim RegionTotal As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 16, dt.Rows.Count + 16, 0, 2)
                    sheet.AddMergedRegion(RegionTotal)
                    cell0 = rowTotal.CreateCell(0)
                    cell1 = rowTotal.CreateCell(1)
                    cell2 = rowTotal.CreateCell(2)
                    cell3 = rowTotal.CreateCell(3)
                    cell4 = rowTotal.CreateCell(4)
                    cell5 = rowTotal.CreateCell(5)
                    cell6 = rowTotal.CreateCell(6)
                    cell7 = rowTotal.CreateCell(7)
                    cell8 = rowTotal.CreateCell(8)
                    cell9 = rowTotal.CreateCell(9)
                    cell10 = rowTotal.CreateCell(10)
                    cell11 = rowTotal.CreateCell(11)
                    cell12 = rowTotal.CreateCell(12)

                    cell0.SetCellValue("合　　計")
                    cell0.CellStyle = Style
                    cell1.CellStyle = Style
                    cell2.CellStyle = Style
                    cell3.CellStyle = Style
                    cell4.CellStyle = Style
                    cell5.CellStyle = Style
                    cell6.CellStyle = Style
                    cell7.CellStyle = Style
                    cell8.CellStyle = Style
                    cell9.CellStyle = Style
                    cell10.CellStyle = Style
                    cell11.CellStyle = Style
                    cell12.CellStyle = Style
                    cell3.SetCellValue(plane_total)
                    cell4.SetCellValue(Boat_total)
                    cell5.SetCellValue(Long_traffic_total)
                    cell6.SetCellValue(Fee_total)
                    cell7.SetCellValue(insurance_total)
                    cell8.SetCellValue(Administrative_costs_total)
                    cell9.SetCellValue(Gift_entertainment_expenses_total)
                    cell10.SetCellValue(Life_fee_total)
                    cell11.SetCellValue("")
                    cell12.SetCellValue(T_total)

                    rowTotal.GetCell(0).CellStyle.Alignment = UserModel.HorizontalAlignment.Center
                    rowTotal.GetCell(0).CellStyle.VerticalAlignment = UserModel.VerticalAlignment.Center


                    Dim RowMoney As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 17)
                    Dim RegionMoney As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 17, dt.Rows.Count + 17, 0, 12)
                    sheet.AddMergedRegion(RegionMoney)
                    '[DBNum2]"上列出差旅費新台幣[b]"G/通用格式"元""如數領訖"
                    Dim chName() As String = {"零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}
                    Dim chName2() As String = {"", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}
                    Dim MoneyValue As String = IIf(Not String.IsNullOrEmpty(chName2(CommonFun.getInt((pageTotal_str.Substring(0, 1))))), chName2(CommonFun.getInt((pageTotal_str.Substring(0, 1)))) & "拾", chName2(CommonFun.getInt((pageTotal_str.Substring(0, 1)))))
                    Dim CellMoney As NPOI.HSSF.UserModel.HSSFCell = RowMoney.CreateCell(0)
                    CellMoney.CellStyle = Style
                    CellMoney.SetCellValue("上列出差旅費新台幣" & _
                                                         MoneyValue & _
                                                         chName(CommonFun.getInt((pageTotal_str.Substring(1, 1)))) & "萬" & _
                                                         chName(CommonFun.getInt((pageTotal_str.Substring(2, 1)))) & "千" & _
                                                         chName(CommonFun.getInt((pageTotal_str.Substring(3, 1)))) & "百" & _
                                                         chName(CommonFun.getInt((pageTotal_str.Substring(4, 1)))) & "拾" & _
                                                         chName(CommonFun.getInt((pageTotal_str.Substring(5, 1)))) & _
                                                          "元如數領訖")
                    CellMoney.SetCellType(UserModel.CellType.String)
                    CellMoney.CellStyle.Alignment = UserModel.HorizontalAlignment.Center
                    CellMoney.CellStyle.VerticalAlignment = UserModel.VerticalAlignment.Center

                    '備考
                    Dim RowNote As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 18)
                    RowNote.CreateCell(0).SetCellValue("備　考")
                    Dim RegionNote As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 18, dt.Rows.Count + 18, 1, 12)
                    sheet.AddMergedRegion(RegionNote)

                    '出差核准資料
                    Dim RowFlowID As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 19)
                    RowFlowID.CreateCell(0).SetCellValue("出差序號：")
                    RowFlowID.CreateCell(1).SetCellValue(dt.Rows(0)("Flow_id").ToString())
                    Dim RegionFlowTitle As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 19, dt.Rows.Count + 19, 2, 12)
                    sheet.AddMergedRegion(RegionFlowTitle)
                    RowFlowID.CreateCell(2).SetCellValue("出差核准資料(　層決行)")

                    '服務單位
                    Dim RowDepartID As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 20)
                    RowDepartID.CreateCell(0).SetCellValue("服務單位")
                    RowDepartID.CreateCell(1).SetCellValue(DepartName)
                    RowDepartID.CreateCell(2).SetCellValue("官職等")
                    Dim RegionJobLevel As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 20, dt.Rows.Count + 20, 3, 5)
                    sheet.AddMergedRegion(RegionJobLevel)

                    Dim dtJobLevel As DataTable = New FSCPLM.Logic.SACode().GetData("002", "006")
                    If dtJobLevel.Rows.Count > 0 Then
                        For Each drJ As DataRow In dtJobLevel.Rows
                            If CType(drJ("CODE_NO").ToString(), Integer) = dt.Rows(0)("Job_Level").ToString() Then
                                RowDepartID.CreateCell(3).SetCellValue(drJ("CODE_DESC1").ToString())
                                Exit For
                            End If
                        Next
                    End If

                    RowDepartID.CreateCell(6).SetCellValue("職稱")
                    RowDepartID.CreateCell(7).SetCellValue(TitleName)
                    Dim RegionUserName As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 20, dt.Rows.Count + 20, 8, 9)
                    sheet.AddMergedRegion(RegionUserName)
                    RowDepartID.CreateCell(8).SetCellValue("出差人姓名")
                    Dim RegionUserNameValue As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 20, dt.Rows.Count + 20, 10, 12)
                    sheet.AddMergedRegion(RegionUserNameValue)
                    RowDepartID.CreateCell(10).SetCellValue(New FSC.Logic.Member().GetColumnValue("User_Name", dt.Rows(0)("id_card").ToString()) & dt.Rows(0)("id_card").ToString())

                    '事由
                    Dim dtF As DataTable = New FSC.Logic.LeaveMain().GetDataByOrgFid(Orgcode, PPGUID)
                    Dim RowIntroduction As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 21)
                    RowIntroduction.CreateCell(0).SetCellValue("事由")
                    Dim RegionIntroduction As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 21, dt.Rows.Count + 21, 1, 12)
                    sheet.AddMergedRegion(RegionIntroduction)
                    If dtF.Rows.Count > 0 Then
                        RowIntroduction.CreateCell(1).SetCellValue(dtF.Rows(0)("Reason").ToString())
                    End If


                    '起迄日
                    Dim RowOfficialout_Date As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 22)
                    RowOfficialout_Date.CreateCell(0).SetCellValue("起迄日")
                    Dim RegionOfficialout_Date As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 22, dt.Rows.Count + 22, 1, 12)
                    sheet.AddMergedRegion(RegionOfficialout_Date)
                    RowOfficialout_Date.CreateCell(1).SetCellValue(dt.Rows(0)("Officialout_Date").ToString() & "～" & dt.Rows(dt.Rows.Count - 1)("Officialout_Date").ToString() & "　　共計" & dt.Rows.Count & "天")
                    '備考
                    Dim RowNote1 As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 23)
                    RowNote1.CreateCell(0).SetCellValue("備　考")
                    Dim RegionNote1 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 23, dt.Rows.Count + 23, 1, 12)
                    sheet.AddMergedRegion(RegionNote1)

                    '預定行程
                    Dim RowPP16M As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 24)
                    RowPP16M.CreateCell(0).SetCellValue("預　定　行　程")
                    Dim RegionPP16M As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 24, dt.Rows.Count + 24, 0, 12)
                    sheet.AddMergedRegion(RegionPP16M)

                    Dim RowPP16M_t As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 25)
                    RowPP16M_t.CreateCell(0).SetCellValue("日　期")
                    Dim RowPP16M_value1 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 25, dt.Rows.Count + 25, 0, 2)
                    sheet.AddMergedRegion(RowPP16M_value1)

                    RowPP16M_t.CreateCell(3).SetCellValue("地點(起迄)")
                    Dim RowPP16M_value2 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 25, dt.Rows.Count + 25, 3, 6)
                    sheet.AddMergedRegion(RowPP16M_value2)

                    RowPP16M_t.CreateCell(7).SetCellValue("工作內容")
                    Dim RowPP16M_value3 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 25, dt.Rows.Count + 25, 7, 12)
                    sheet.AddMergedRegion(RowPP16M_value3)

                    '出差申請單資料
                    Dim PP16M_v As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 26)
                    If dtF.Rows.Count > 0 Then
                        PP16M_v.CreateCell(0).SetCellValue(dtF.Rows(0)("Start_date").ToString() & "～" & dtF.Rows(0)("End_date").ToString())
                        Dim p1 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 26, dt.Rows.Count + 26, 0, 2)
                        sheet.AddMergedRegion(p1)

                        PP16M_v.CreateCell(3).SetCellValue("臺灣～" & dtF.Rows(0)("Place").ToString())
                        Dim p2 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 26, dt.Rows.Count + 26, 3, 6)
                        sheet.AddMergedRegion(p2)

                        PP16M_v.CreateCell(7).SetCellValue(dtF.Rows(0)("Reason").ToString())
                        Dim p3 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 26, dt.Rows.Count + 26, 7, 12)
                        sheet.AddMergedRegion(p3)
                    End If

                    '簽核人員
                    Dim dtProcess As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(Orgcode, PPGUID)
                    Dim RowProcess As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 27)
                    Dim RowProcessV As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 28)
                    If dtProcess.Rows.Count > 0 Then

                        Dim RowCount As Integer = 8
                        Dim RowCountNext As Integer = 0
                        For i As Integer = 0 To dtProcess.Rows.Count - 1

                            If i = dtProcess.Rows.Count - 1 And dtProcess.Rows.Count < 5 Then
                                RowCount = 0
                                RowCountNext = 11 - (dtProcess.Rows.Count * 2)
                            Else
                                RowCountNext = RowCount + 1
                            End If

                            If RowCountNext < 0 Then '避免負值時出現錯誤
                                Exit For
                            End If

                            Dim ProcessTitleName As String = IIf(i = 0, "職務代理人", New SYS.Logic.CODE().GetFSCTitleName(dtProcess.Rows(i)("Last_posid").ToString()))
                            RowProcess.CreateCell(RowCount).SetCellValue(ProcessTitleName)

                            Dim title1 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 27, dt.Rows.Count + 27, RowCount, RowCountNext)
                            sheet.AddMergedRegion(title1)

                            RowProcessV.CreateCell(RowCount).SetCellValue(dtProcess.Rows(i)("Last_Name").ToString())
                            Dim p1 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 28, dt.Rows.Count + 28, RowCount, RowCountNext)
                            sheet.AddMergedRegion(p1)
                            RowCount -= 2
                        Next
                    End If

                    RowProcess.CreateCell(10).SetCellValue("出差人")
                    Dim t1 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 27, dt.Rows.Count + 27, 10, 12)
                    sheet.AddMergedRegion(t1)

                    RowProcessV.CreateCell(10).SetCellValue(New FSC.Logic.Member().GetColumnValue("User_Name", dt.Rows(0)("id_card").ToString()) & dt.Rows(0)("id_card").ToString())
                    Dim p6 As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 28, dt.Rows.Count + 28, 10, 12)

                    sheet.AddMergedRegion(p6)

                    Dim RowFooter As NPOI.HSSF.UserModel.HSSFRow = sheet.CreateRow(dt.Rows.Count + 29)
                    RowFooter.CreateCell(0).SetCellValue("注意：一.出差人員出國前未辦理結匯者,出差旅費應以出國前一日(如逢假日往前推)臺灣銀行賣出即期美元參考匯" + Chr(10) + "價為依據辦理報支。" + Chr(10) + "二.請於備註欄填明各外幣兌換匯率(例如美元：台幣=1：xx)。" + Chr(10) + "三.相關經費憑證請依順序編號，並於「列印報告表後」在填列金額上方註明憑證號碼；並請依序黏貼於" + Chr(10) + "空白A4紙上。")
                    Dim rf As New NPOI.SS.Util.CellRangeAddress(dt.Rows.Count + 29, dt.Rows.Count + 32, 0, 12)

                    sheet.AddMergedRegion(rf)

                    outfeeCounts += 1

                Next
            End Using
            book.Write(ms)
            '写入到客户端
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename=支出憑證黏存單.xls"))
            Response.BinaryWrite(ms.ToArray())
            book = Nothing
            ms.Close()
            ms.Dispose()




        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
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
        '    Dim fdt As DataTable = New Flow().GetLastDataByFlow_id(dr("PPGUID"), Orgcode)
        '    For Each fdr As DataRow In fdt.Rows
        '        dr("Agree_time") = fdr("Agree_time").ToString()
        '        dr("Last_name") = fdr("Last_name").ToString()
        '        dr("Replace_name") = IIf(Not String.IsNullOrEmpty(fdr("Replace_name").ToString()), fdr("Replace_name").ToString(), fdr("Last_name").ToString())
        '        dr("Agree_flag") = New Flow().GetCase_status(fdr("Agree_flag").ToString())
        '        dr("Comment") = fdr("Comment").ToString()
        '    Next
        '    i += 1
        'Next

        'Dim rpt As CommonLib.DTReport = New CommonLib.DTReport(Server.MapPath("~/Report/FSC1/FSC1306_RPT2.mht"), dt)
        'Dim params(1) As String
        'params(0) = New FSCorg().GetOrgcodeName(Orgcode)

        'rpt.ExportFileName = "公差批示情形表("")"
        'rpt.Param = params
        'rpt.ExportToExcel()
    End Sub

    Protected Sub Report()
        Dim idno As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim guids() As String = Request.QueryString("guidlist").Split(",")

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
            tbBoat.Text = dr("Boat").ToString
            tbLong_traffic.Text = dr("Long_traffic").ToString
            tbLife_fee.Text = dr("Life_fee").ToString
            tbFee.Text = dr("Fee").ToString
            tbInsurance.Text = dr("Insurance").ToString
            tbAdministrative_costs.Text = dr("Administrative_costs").ToString
            tbGift_entertainment_expenses.Text = dr("Gift_entertainment_expenses").ToString
            tbIncidentals.Text = dr("Incidentals").ToString
            tbRecipnumber.Text = dr("Recipnumber").ToString
            tbNote.Text = dr("Note").ToString
        End If

    End Sub
#End Region

End Class
