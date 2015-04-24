
Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports CAR.Logic
Imports FSC.Logic

'Imports System.Linq

Partial Class CAR1101_01
    Inherits BaseWebForm

    Dim dictionary As New Dictionary(Of String, Integer) '= {"3,1", "3,2", "3,3", "1,6", "1,7", "1,8"}
    'Dim timeAry() As String = {"08:00", "08:30", "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30" _
    '    , "16:00", "16:30", "17:00", "17:30", "18:00"}
    Dim timeAryList As ArrayList
    Dim carDT As DataTable
    Dim carDispatchDT As DataTable

    Dim dao As New CAR1101

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master) 
        Use_frequencyView()
    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        'Dim ccdMain As New CAR_CarDispatch_main
        'Dim floaID As String = New Random().Next(1, 20)
        'ccdMain.Add(LoginManager.OrgCode, "", ucCarType.Code_no, ddlCarName.SelectedValue, txtPassengerCnt.Text, _
        '                   ucStartDate.Text, ucEndDate.Text, ucStartTime.Code_no, ucEndTime.Code_no, ucDepartureTime.Code_no, _
        '                   txtReasonDesc.Text, ucDepartureTime.Code_no, ucUrgentType.Code_no, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id), _
        '                   "", txtDestinationDesc.Text, txtLocationType.Text)
        Dim msg As String = String.Empty

        If ucStartTime.Code_no > ucEndTime.Code_no Then
            msg = "使用完畢時間不可小於使用起始時間\n"
        End If

         
        'Dim coorS As String = String.Format("{0},{1}", ddlCarName.SelectedIndex + 1, Convert.ToInt16(ucStartTime.Code_no))
        'Dim coorE As String = String.Format("{0},{1}", ddlCarName.SelectedIndex + 1, Convert.ToInt16(ucEndTime.Code_no))
        'If dictionary.ContainsKey(coorS) OrElse dictionary.ContainsKey(coorE) Then
        '    msg &= "時段已有人預約\n"
        'End If

        If String.IsNullOrEmpty(txtPassengerCnt.Text.Trim) Then 
            msg &= "用車人數不可空白\n"
        ElseIf Not CommonFun.IsNum(txtPassengerCnt.Text.Trim) Then 
            msg &= "用車人數請輸入數字\n"
        End If

        If String.IsNullOrEmpty(txtDepartureTimeS.Text) Then
            msg &= "出發時間(時)不可空白\n"
        ElseIf Not IsNumeric(txtDepartureTimeS.Text) Then
            msg &= "出發時間(時)必須為數字\n"
        ElseIf txtDepartureTimeS.Text > 23 OrElse txtDepartureTimeS.Text < 0 Then
            msg &= "出發時間(時)須介於0~23\n"
        End If

        If String.IsNullOrEmpty(txtDepartureTimeE.Text) Then
            msg &= "出發時間(分)不可空白\n"
        ElseIf Not IsNumeric(txtDepartureTimeE.Text) Then
            msg &= "出發時間(分)必須為數字\n"
        ElseIf txtDepartureTimeE.Text > 59 OrElse txtDepartureTimeE.Text < 0 Then
            msg &= "出發時間(分)須介於0~59\n"
        End If


        If String.IsNullOrEmpty(msg) Then
            Try
                dao.Apply(ucCarType.Code_no, ddlCarName.SelectedValue, ddlCarName.SelectedItem.Text, txtPassengerCnt.Text, _
                  ucStartDate.Text, ucEndDate.Text, ucStartTime.Code_no, ucEndTime.Code_no, ucDepartureDate.Text, _
                  txtDepartureTimeS.Text + ":" + txtDepartureTimeE.Text, txtReasonDesc.Text, ucUseType.Code_no, ucUrgentType.Code_no, txtDestinationDesc.Text, _
                  txtLocation.Text, ucUse_frequency.Code_no, ddlWeekday.SelectedValue, ddlDays.SelectedValue, Request.QueryString("fid"))

                BindDispatchInfo()
                AddBtn.Enabled = False
                ResetBtn.Enabled = False
                If (Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid"))) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "修改完成")
                Else
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "申請完成")
                End If
                 
            Catch ex As Exception
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
            End Try

        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''initfunction()

        'dictionary.Add("1,0", 0)
        'dictionary.Add("1,1", 0)
        'dictionary.Add("1,2", 0)
        'dictionary.Add("3,1", 1)
        'dictionary.Add("3,2", 1)
        'dictionary.Add("3,3", 1)
        'dictionary.Add("1,6", 2)
        'dictionary.Add("1,7", 2)
        'dictionary.Add("1,8", 2)

        timeAryList = New ArrayList()
        For Each dr As DataRow In dao.saCode.GetData("015", "006").Rows
            timeAryList.Add(dr("CODE_DESC1"))

        Next

        'Dim carMain As New Car_main()
        carDT = dao.saCode.GetData("015", "011") 'carMain.GetData(LoginManager.OrgCode)

        BindDispatchInfo()

        If Not (IsPostBack) Then
            ddlCarName.DataSource = carDT
            ddlCarName.DataTextField = "CODE_DESC1"
            ddlCarName.DataValueField = "CODE_NO"
            ddlCarName.DataBind()
            'BindGV()
            '
            'BindDate(Now)
            BindStartEndDate(Now)
            'ucDepartureDate.Text = CommonFun.getYYYMMDD()
            For index = 1 To 31
                ddlDays.Items.Add(New ListItem(index))
            Next
            Use_frequencyView()

            ucEndTime.Code_no = "021"

            Dim thisTime As String = Now.Hour.ToString.PadLeft(2, "0") + Now.Minute.ToString.PadLeft(2, "0")
            Dim dt As DataTable = New SYS.Logic.CODE().GetData("015", "006")
            For Each dr As DataRow In dt.Rows
                If dr("CODE_DESC1").ToString.Replace(":", "") > thisTime Then
                    ucStartTime.Code_no = dr("CODE_NO").ToString()
                    Exit For
                End If
            Next


            If (Not String.IsNullOrEmpty(Request.QueryString("org")) AndAlso Not String.IsNullOrEmpty(Request.QueryString("fid"))) Then
                ShowReSendData()
                Me.AddBtn.Text = "確認修改"
                ResetBtn.Visible = False
                BackBtn.Visible = True
            Else
                ResetBtn.Visible = True
                BackBtn.Visible = False
            End If
        End If
    End Sub

    Private Sub ShowReSendData()
        Dim dt As DataTable = dao.GetDataByOrgFid(Request.QueryString("org"), Request.QueryString("fid"))

        'dao.Apply(ucCarType.Code_no, ddlCarName.SelectedValue, ddlCarName.SelectedItem.Text, txtPassengerCnt.Text, _
        '          ucStartDate.Text, ucEndDate.Text, ucStartTime.Code_no, ucEndTime.Code_no, ucDepartureDate.Text, _
        '          txtDepartureTimeS.Text + ":" + txtDepartureTimeE.Text, txtReasonDesc.Text, ucUseType.Code_no, ucUrgentType.Code_no, txtDestinationDesc.Text, _
        '          txtLocation.Text, ucUse_frequency.Code_no, ddlWeekday.SelectedValue, ddlDays.SelectedValue)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)
            ucCarType.Code_no = CommonFun.SetDataRow(dr, "Car_type")
            ddlCarName.SelectedValue = CommonFun.SetDataRow(dr, "Car_name")
            txtPassengerCnt.Text = CommonFun.SetDataRow(dr, "Passenger_cnt")
            ucStartDate.Text = CommonFun.SetDataRow(dr, "Start_date")
            ucEndDate.Text = CommonFun.SetDataRow(dr, "End_date")
            ucStartTime.Code_no = CommonFun.SetDataRow(dr, "Start_time")
            ucEndTime.Code_no = CommonFun.SetDataRow(dr, "End_time")
            ucDepartureDate.Text = CommonFun.SetDataRow(dr, "Departure_date")
            txtDepartureTimeS.Text = CommonFun.SetDataRow(dr, "Departure_time").ToString().Split(":")(0)
            txtDepartureTimeE.Text = CommonFun.SetDataRow(dr, "Departure_time").ToString().Split(":")(1)
            txtReasonDesc.Text = CommonFun.SetDataRow(dr, "Reason_desc")
            ucUseType.Code_no = CommonFun.SetDataRow(dr, "Use_type")
            ucUrgentType.Code_no = CommonFun.SetDataRow(dr, "Urgent_type")
            txtDestinationDesc.Text = CommonFun.SetDataRow(dr, "Destination_desc")
            txtLocation.Text = CommonFun.SetDataRow(dr, "Location")
        End If


    End Sub

    Private Sub BindDispatchInfo()
        dictionary.Clear()
        If String.IsNullOrEmpty(lblNow.Text) Then
            BindDate(Now)
        Else
            BindDate(CommonFun.getYYYMMDD(lblNow.Text))
        End If

        Dim carDis As New CarDispatchMain()
        carDispatchDT = carDis.GetData(LoginManager.OrgCode, lblNow.Text)
        Dim carIDAry As New ArrayList

        For Each dr As DataRow In carDT.Rows
            carIDAry.Add(CommonFun.SetDataRow(dr, "CODE_NO"))
        Next

        Dim rowIndex As Integer
        For Each dr As DataRow In carDispatchDT.Rows
            Dim carId As String = CommonFun.SetDataRow(dr, "Car_name")
            Dim start_Time_Id As Integer = CommonFun.SetDataRow(dr, "Start_Time")
            Dim end_Time_Id As Integer = CommonFun.SetDataRow(dr, "End_Time")
            For i = start_Time_Id To end_Time_Id
                Dim key As String = String.Format("{0},{1}", carIDAry.IndexOf(carId) + 1, i)
                If Not dictionary.ContainsKey(key) Then
                    dictionary.Add(key, rowIndex)
                End If
            Next
            rowIndex = rowIndex + 1
        Next
        BindGV()
        MergeCells()
    End Sub

    Private Sub BindStartEndDate(ByVal myDt As DateTime)
        ucStartDate.Text = CommonFun.getYYYMMDD(myDt)
        ucEndDate.Text = CommonFun.getYYYMMDD(myDt)
    End Sub

    Private Sub BindDate(ByVal myDt As DateTime)
        lbPreDate.CommandArgument = CommonFun.getYYYMMDD(myDt.AddDays(-1))
        lblNow.Text = CommonFun.getYYYMMDD(myDt)
        lbNextDate.CommandArgument = CommonFun.getYYYMMDD(myDt.AddDays(1))
    End Sub

    Protected Sub lb_Command(ByVal sender As Object, ByVal e As CommandEventArgs) Handles lbPreDate.Command, lbNextDate.Command
        BindDate(CommonFun.getYYYMMDD(e.CommandArgument))
        'CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "")   Me.GridView1.DataBind()
        BindDispatchInfo()
    End Sub

    Private Sub BindGV()
        Dim db As New DataTable
        Dim dtResult As New DataTable
        dtResult.Columns.Add(New DataColumn("時間"))
        For Each dr As DataRow In carDT.Rows
            dtResult.Columns.Add(New DataColumn(CommonFun.SetDataRow(dr, "CODE_DESC1")))
        Next
        For index = 0 To timeAryList.Count - 1
            Dim newDR As DataRow = dtResult.NewRow()
            newDR("時間") = timeAryList(index)
            For Each dr As DataRow In carDT.Rows
                If Not String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "CODE_DESC1")) Then
                    newDR(dr("CODE_DESC1")) = "0"
                End If
            Next
            dtResult.Rows.Add(newDR)
        Next
        Me.GridView1.DataSource = dtResult
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim personnal As New Personnel
            Dim departEmp As New DepartEmp
            Dim org As New Org
            For index = 1 To e.Row.Cells.Count - 1
                Dim btn As New Button
                Dim hf As New HiddenField
                hf.ID = String.Format("hf_{0}_{1}", e.Row.RowIndex, index)
                Dim coor As String = String.Format("{0},{1}", index, e.Row.RowIndex)
                If dictionary.ContainsKey(coor) Then
                    hf.Value = dictionary(coor)
                    btn.TabIndex = dictionary(coor)
                    Dim dr As DataRow = carDispatchDT.Rows(hf.Value)
                    Dim lblUserID As New Label
                    'personnal.GetColumnValue("", CommonFun.SetDataRow(dr, "User_id"))
                    Dim id_card As String = CommonFun.SetDataRow(dr, "User_id")
                    'Dim d As New Dictionary(Of String, Object)
                    'd.Add("Id", ID)
                    'dao.GetDataByExample("Extension_setting", d)
                    Dim Depart_id As String = departEmp.GetDataByIdcard(id_card).Rows(0)("Depart_id")
                    Dim Orgcode As String = departEmp.GetDataByIdcard(id_card).Rows(0)("Orgcode")
                    Dim depar_name As String = org.GetDataByDepartid(Orgcode, Depart_id)("Depart_name")
                    lblUserID.Text = depar_name & "<br />" & personnal.GetColumnValue("USER_NAME", id_card) & "<br />"
                    e.Row.Cells(index).Controls.Add(lblUserID)
                     
                    btn.TabIndex = -1
                    btn.CommandArgument = btn.TabIndex
                    btn.ID = String.Format("booking_{0}_{1}", e.Row.RowIndex, index)
                    btn.Text = "預約" '& btn.TabIndex
                    AddHandler btn.Click, AddressOf ShowBookginDateTime
                    e.Row.Cells(index).Controls.Add(btn)
                Else
                    hf.Value = -1
                    btn.TabIndex = -1
                    btn.CommandArgument = btn.TabIndex
                    btn.ID = String.Format("booking_{0}_{1}", e.Row.RowIndex, index)
                    btn.Text = "預約" '& btn.TabIndex
                    AddHandler btn.Click, AddressOf ShowBookginDateTime
                    e.Row.Cells(index).Controls.Add(btn)
                End If
                e.Row.Cells(index).Controls.Add(hf)
            Next
        End If
    End Sub

    Protected Sub ShowBookginDateTime(sender As Object, e As EventArgs)
        Dim btn As Button = TryCast(sender, Button)
        Dim row As GridViewRow = TryCast(btn.NamingContainer, GridViewRow)
        Dim id As String = btn.CommandArgument
        'Dim name As String = row.Cells(0).Text
        'Dim country As String = TryCast(row.FindControl("txtCountry"), TextBox).Text
        'ClientScript.RegisterStartupScript(Me.[GetType](), "alert", (Convert.ToString((Convert.ToString((Convert.ToString("alert('Id: ") & id) + " Name: ") & name) + " Country: ") & country) + "')", True)
        'CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, String.Format("id:{0}", btn.ID))
        Dim info() As String = btn.ID.Replace("booking_", "").Split("_")
        Dim rowIndex As Integer = info(0)
        Dim colIndex As Integer = info(1)
        If id > 0 Then

            'CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, String.Format("Time:{0}", timeAry(rowIndex)))
            'CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, String.Format("CarName:{0}", carDT.Rows(colIndex)("Car_name")))
        Else
            'Dim startTimeAry() As String = timeAry(rowIndex).Split(":")
            'Me.txtStartTimeH.Text = startTimeAry(0)
            'Me.txtStartTimeM.Text = startTimeAry(1)
            ucStartTime.Code_no = rowIndex.ToString().PadLeft(3, "0")
            If rowIndex < timeAryList.Count - 1 Then '18:00不理
                'Dim endTimeAry() As String = timeAry(rowIndex + 1).Split(":")
                'Me.txtEndTimeH.Text = endTimeAry(0)
                'Me.txtEndTimeM.Text = endTimeAry(1)
                ucEndTime.Code_no = (rowIndex + 1).ToString().PadLeft(3, "0")
            End If
            ddlCarName.SelectedValue = carDT.Rows(colIndex - 1)("CODE_NO")
            BindStartEndDate(CommonFun.getYYYMMDD(Me.lblNow.Text))
        End If
    End Sub

    Private Sub MergeCells()
        Dim i As Integer = GridView1.Rows.Count - 2
        While i >= 0
            Dim curRow As GridViewRow = GridView1.Rows(i)
            Dim preRow As GridViewRow = GridView1.Rows(i + 1)

            Dim j As Integer = 1
            While j < curRow.Cells.Count
                Dim hfCur As HiddenField = CType(curRow.FindControl(String.Format("hf_{0}_{1}", i, j)), HiddenField)
                If hfCur.Value = -1 Then
                    j += 1
                    Continue While
                End If

                Dim hfPre As HiddenField = CType(preRow.FindControl(String.Format("hf_{0}_{1}", i + 1, j)), HiddenField)
                If hfCur.Value = hfPre.Value Then
                    If preRow.Cells(j).RowSpan < 2 Then
                        curRow.Cells(j).RowSpan = 2
                        preRow.Cells(j).Visible = False
                    Else
                        curRow.Cells(j).RowSpan = preRow.Cells(j).RowSpan + 1
                        preRow.Cells(j).Visible = False
                    End If
                End If
                j += 1
            End While
            i -= 1
        End While
    End Sub
    Protected Sub ucUse_frequency_CodeChanged(sender As Object, e As EventArgs)
        Use_frequencyView()
    End Sub

    Private Sub Use_frequencyView()
        If ucUse_frequency.Code_no = "001" Then '單日
            pWeekday.Visible = False
            pDays.Visible = False
            pEndDate.Visible = False
        ElseIf ucUse_frequency.Code_no = "002" Then '每日重覆
            pWeekday.Visible = False
            pDays.Visible = False
            pEndDate.Visible = True
        ElseIf ucUse_frequency.Code_no = "003" Then '每週重覆
            pWeekday.Visible = True
            pDays.Visible = False
            pEndDate.Visible = True
        ElseIf ucUse_frequency.Code_no = "004" Then '每月重覆
            pWeekday.Visible = False
            pDays.Visible = True
            pEndDate.Visible = True
        Else
            pWeekday.Visible = False
            pDays.Visible = False
            pEndDate.Visible = False
        End If

    End Sub

End Class


