Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Partial Class FSC0101_03
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Bind()
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fId")
        Dim orgcode As String = Request.QueryString("org")

        Dim flow As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)

        If flow Is Nothing Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無資料!", ViewState("BackUrl"))
            Return
        End If

        Dim lmList As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(orgcode, flowId)
        Dim lmmList As List(Of FSC.Logic.LeaveMainMapping) = New FSC.Logic.LeaveMainMapping().GetObjects(orgcode, flowId)
        Dim lt As New SYS.Logic.LeaveType()
        Dim fd As New SYS.Logic.FlowDetail()
        Dim fdList As List(Of SYS.Logic.FlowDetail) = CommonFun.ConvertToList(Of SYS.Logic.FlowDetail)(fd.GetDataByFlow_id(orgcode, flowId))
        Dim i As Integer = 1
        Dim hours As Integer = 0
        Dim ld As New StringBuilder()

        lbFlow_id.Text = flowId
        lbApply_name.Text = GetMemberInfo(flow.Orgcode, flow.DepartId, flow.ApplyPosid, flow.ApplyName)
        lbWrite_name.Text = GetMemberInfo(flow.WriterOrgcode, flow.WriterDepartid, flow.WriterPosid, flow.WriterName)
        lbWrite_time.Text = flow.WriteTime
        lbReason.Text = flow.Reason


        If Not String.IsNullOrEmpty(flow.CancelFlowid) Then
            lbCancel_flowid.Text = True
            lbCancel_flowid.Text = "(原表單)"
            lbCancel_flowid.PostBackUrl = "FSC0101_03.aspx?org=" + flow.Orgcode + "&fid=" + flow.CancelFlowid
        End If


        For Each fdetail As SYS.Logic.FlowDetail In fdList
            lbAgree_time.Text = fdetail.AgreeTime
        Next

        For Each lm As FSC.Logic.LeaveMain In lmList
            hours += lm.LeaveHours

            ld.AppendLine(DateTimeInfo.ToDisplay(lm.StartDate, lm.StartTime)).Append(" ~ ")
            ld.AppendLine(DateTimeInfo.ToDisplay(lm.EndDate, lm.EndTime)).Append("<br/>")

            If i >= lmList.Count Then

                lbLeave_name.Text = lt.GetLeaveName(lm.LeaveType)
                If lm.LeaveType = "04" Then
                    '加班假
                    lbLeave_text.Text = "加班"
                    If lmmList IsNot Nothing Then
                        For Each lmm As FSC.Logic.LeaveMainMapping In lmmList
                            lbLeave_text2.Text &= "加班日" & lmm.ApplyDateb & "，補休" & lmm.LeaveHours & "小時" & "<br />"
                        Next
                        lbLeave_text2.Text.TrimEnd("<br />")
                    End If

                ElseIf lm.LeaveType = "08" Then
                    lbDate_type.Text = "婚假"
                    lbTDATE.Text = lm.OccurDate

                ElseIf lm.LeaveType = "10" Then
                    lbDate_type.Text = "喪假"
                    lbTDATE.Text = lm.OccurDate

                ElseIf lm.LeaveType = "20" Then
                    '出差補休
                    lbLeave_text.Text = "公差"
                    If lmmList IsNot Nothing Then
                        For Each lmm As FSC.Logic.LeaveMainMapping In lmmList
                            lbLeave_text2.Text &= "公差日" & lmm.ApplyDateb & "，補休" & lmm.LeaveHours & "小時" & "<br />"
                        Next
                        lbLeave_text2.Text.TrimEnd("<br />")
                    End If

                ElseIf lm.LeaveType = "57" Then
                    lb.Visible = False
                    UcShowDayHours.Visible = False
                    lbdatename.Text = "忘刷卡時間"

                ElseIf lm.LeaveType = "80" Or lm.LeaveType = "82" Then

                    'If "Y".Equals(Nocard_flag) Then
                    '    'tb.Rows(9).Visible = True
                    '    tbOTNoCardReason.Visible = True
                    '    lbNocard_reason.Text = Nocard_reason
                    'End If
                End If


                If lm.LeaveType = "08" Or lm.LeaveType = "10" Then
                    tbTdate.Visible = True
                End If

                If lm.LeaveType = "04" Or lm.LeaveType = "20" Then
                    tbOtherLT.Visible = True
                End If

                If lm.LeaveType = "05" Or lm.LeaveType = "07" Or lm.LeaveType = "27" Then
                    'tbPlace.Visible = True
                End If

                If lm.LeaveType = "05" Or lm.LeaveType = "07" Then
                    lbPlaceType.Text = "差假"
                    'lbPlace.Text = lm.Place
                    'If lm.LocationFlag = "1" Then
                    '    tbPlace.Visible = False
                    'End If
                    tbDetailPlace.Visible = True

                    Dim lmd As New FSC.Logic.LeaveMainDetail
                    Dim dt As DataTable = lmd.getDataByFid(flowId)
                    For Each dr As DataRow In dt.Rows
                        'If Not String.IsNullOrEmpty(dr("city").ToString) Then
                        '    If dr("Start_date").ToString = dr("End_date").ToString Then
                        '        lbPlace.Text = lbPlace.Text + FSC.Logic.DateTimeInfo.ToDisplay(dr("Start_date").ToString) + " " + _
                        '            New SYS.Logic.CODE().GetDataDESC("023", "007", dr("city").ToString) + "<br />"
                        '    Else
                        '        lbPlace.Text = lbPlace.Text + FSC.Logic.DateTimeInfo.ToDisplay(dr("Start_date").ToString) + "~" + _
                        '            FSC.Logic.DateTimeInfo.ToDisplay(dr("End_date").ToString) + " " + _
                        '            New SYS.Logic.CODE().GetDataDESC("023", "007", dr("city").ToString) + "<br />"
                        '    End If
                        'End If

                        If Not String.IsNullOrEmpty(dr("DetailPlace").ToString) Then
                            If dr("Start_date").ToString = dr("End_date").ToString Then
                                lbDetailPlace.Text = lbDetailPlace.Text + FSC.Logic.DateTimeInfo.ToDisplay(dr("Start_date").ToString) + " " + _
                                    dr("DetailPlace").ToString + "<br />"
                            Else
                                lbDetailPlace.Text = lbDetailPlace.Text + FSC.Logic.DateTimeInfo.ToDisplay(dr("Start_date").ToString) + "~" + _
                                    FSC.Logic.DateTimeInfo.ToDisplay(dr("End_date").ToString) + " " + dr("DetailPlace").ToString + "<br />"
                            End If
                        End If
                    Next
                ElseIf lm.LeaveType = "27" Then
                    lbPlaceType.Text = "出國"
                End If
            End If

            i += 1
        Next

        UcShowDayHours.Leave_hours = hours
        lbLeaveDate.Text = ld.ToString()

        UcFlowDetail.Orgcode = orgcode
        UcFlowDetail.FlowId = flowId


        'If leaveMain.LeaveType = "85" Then
        '    '撤銷差假 
        '    UcLeaveType.Visible = True
        '    UcLeaveType.Flow_id = ""
        '    UcLeaveType.Leave_name = "(原假單)"

        '    'hsien 20130223
        '    gvCard.Visible = True
        '    Dim sdate As DateTime = DateTimeInfo.GetPublicDate(ucsld.Start_date)
        '    Dim edate As DateTime = DateTimeInfo.GetPublicDate(ucsld.End_date)

        '    Dim connstring As String = ConnectDB.GetCPADBString(New Member().GetColumnValue("metadb_id", Apply_id))
        '    Dim phyyymm As New CPAPHYYMM((sdate.Year - 1911).ToString().PadLeft(3, "0") & sdate.Month.ToString().PadLeft(2, "0"), connstring)

        '    Dim tmpdt As New DataTable()
        '    tmpdt.Columns.Add("tdate", GetType(String))
        '    tmpdt.Columns.Add("tcard", GetType(String))

        '    Dim personnel_id As String = New Member().GetColumnValue("Personnel_id", Apply_id)
        '    Do
        '        Dim tmpdr As DataRow = tmpdt.NewRow()
        '        Dim tdate As String = DateTimeInfo.GetRocDate(sdate)
        '        Dim phdt As DataTable = phyyymm.GetListData(personnel_id, Apply_id, tdate)

        '        tmpdr("tdate") = tdate
        '        For Each phdr As DataRow In phdt.Rows
        '            If tmpdr("tcard").ToString() <> "" Then
        '                tmpdr("tcard") &= ","
        '            End If
        '            tmpdr("tcard") &= DateTimeInfo.ToDisplayTime(phdr("PHITIME").ToString())
        '        Next

        '        tmpdt.Rows.Add(tmpdr)
        '        If sdate >= edate Then
        '            Exit Do
        '        End If
        '        sdate = sdate.AddDays(1)
        '    Loop
        '    gvCard.DataSource = tmpdt
        '    gvCard.DataBind()

        'End If

        'If leaveMain.LeaveType = "84" Then
        '    '代理移轉 
        '    UcLeaveType.Visible = True
        '    UcLeaveType.Flow_id = ""
        '    UcLeaveType.Leave_name = "(原假單)"
        'End If


        'lbLeave_name.Text = ""


        'Dim dti As New DateTimeInfo

        'lbWrite_time.Text = flow.WriteTime
        'lbAgree_time.Text = ""

        'ucsld.Flow_id = Request.QueryString("fId")
        'ucsld.Orgcode = Request.QueryString("Org")
        'ucsld.Leave_ngroup = dr("Leave_ngroup").ToString()
        'ucsld.Start_date = dr("Start_date").ToString()
        'ucsld.Start_time = dr("Start_time").ToString()

        'ucsld.End_date = dr("End_date").ToString()
        'ucsld.End_time = dr("End_time").ToString()

        'UcShowDayHours.leaveMain.LeaveType = CommonFun.getInt(dr("leaveMain.LeaveType").ToString())
        'UcShowDayHours.Leave_hours = CommonFun.getInt(dr("Leave_hours").ToString())

        'Select Case dr("Case_status").ToString()
        '    Case "0"
        '        lbCase_status.Text = "等待批核中"
        '    Case "1"
        '        If dr("Last_pass").ToString() = "1" Then
        '            lbCase_status.Text = "完成且核准"
        '        Else
        '            lbCase_status.Text = "等待批核中"
        '        End If
        '    Case "2"
        '        lbCase_status.Text = "完成但不同意"
        '    Case "4"
        '        lbCase_status.Text = "已刪除"
        '    Case Else

        'End Select

        'lbReason.Text = dr("Reason").ToString()

        'If dr("flow.CancelFlag").ToString() = "Y" Then
        '    '撤銷表單
        '    lbReason.Text = "[已撤銷]"
        'End If

        'Dim places() As String = dr("Place").ToString().Split("|")
        'lbPlace.Text = places(0)

        'If places.Length > 1 Then
        '    lbDetailPlace.Text = places(1)
        '    tbDetailPlace.Visible = True
        '    'tb.Rows(14).Visible = True
        'End If

        'If places.Length > 2 Then
        '    lbTransport.Text = places(2)
        '    tbTransport.Visible = True
        '    'tb.Rows(15).Visible = True
        'End If
    End Sub

    Public Function GetMemberInfo(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Apply_posid As String, ByVal User_name As String) As String
        Dim name As New StringBuilder
        Dim org As New FSC.Logic.Org()
        Dim code As New FSCPLM.Logic.SACode()

        name.Append(org.GetDepartName(Orgcode, Depart_id))
        name.Append("：")
        name.Append("(" & code.GetCodeDesc("023", "012", Apply_posid) & ")")
        name.Append(User_name)

        Return name.ToString()
    End Function

    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Dim url As String = ViewState("BackUrl")
        Response.Redirect(url)
    End Sub
End Class
