Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Transactions

Namespace FSC.Logic
    Public Class FSC3112
        Private DAO As FSC3112DAO

        Public Sub New()
            DAO = New FSC3112DAO()
        End Sub

        Function RunAutoSchedule(ByVal orgcode As String, ByVal yyymm As String, ByVal scheduleId As String, ByVal memList As ArrayList) As String
            Dim d As New FSC.Logic.DepartEmp()
            Dim psn As New FSC.Logic.Personnel()
            Dim pb02m As New FSC.Logic.CPAPB02M()
            Dim dt As DataTable = pb02m.getData(orgcode, yyymm)
            Dim i As Integer = 0

            If (scheduleId = "A00004" Or scheduleId = "A00005") Then
                Dim yearHoliday As Boolean = False
                For Each dr As DataRow In dt.Rows
                    If dr("PBDDESC").ToString().IndexOf("農曆過年") >= 0 Then
                        yearHoliday = True
                        Exit For
                    End If
                Next
                If Not yearHoliday Then
                    Return "該月份無農曆過年!"
                End If
            End If



            Using scope As New TransactionScope

                Try
                    Dim scheSetting As New FSC.Logic.ScheduleSetting()
                    Dim scheBase As New FSC.Logic.ScheduleBase()
                    scheSetting.DeleteData(orgcode, yyymm, scheduleId)
                    scheBase.DeleteData(orgcode, yyymm, scheduleId)

                    For Each dr As DataRow In dt.Rows
                        Dim PBDTYPE As String = dr("PBDTYPE").ToString()
                        Dim PBDDESC As String = dr("PBDDESC").ToString()
                        Dim PBDDATE As String = dr("PBDDATE").ToString()

                        If i >= memList.Count Then
                            i = 0
                        End If

                        scheSetting = New FSC.Logic.ScheduleSetting()
                        scheBase = New FSC.Logic.ScheduleBase()

                        scheSetting.Orgcode = orgcode
                        scheSetting.Schedule_hours = 8  '固定 8 hours
                        scheSetting.Schedule_id = scheduleId
                        scheSetting.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

                        If scheduleId = "A00001" And dr("PBDTYPE").ToString() = "0" Then
                            '全日上班
                            Dim idCard As String = memList(i)

                            scheSetting.Depart_id = d.GetDepartId(idCard)
                            scheSetting.User_name = psn.GetColumnValue("User_name", idCard)
                            scheSetting.Id_card = idCard
                            scheSetting.Sche_date = PBDDATE
                            scheSetting.Sche_type = "1"
                            scheSetting.insert()

                            'copy
                            scheBase.Orgcode = scheSetting.Orgcode
                            scheBase.Schedule_id = scheSetting.Schedule_id
                            scheBase.Depart_id = scheSetting.Depart_id
                            scheBase.User_name = scheSetting.User_name
                            scheBase.Id_card = scheSetting.Id_card
                            scheBase.Sche_date = scheSetting.Sche_date
                            scheBase.Sche_type = scheSetting.Sche_type
                            scheBase.Change_userid = scheSetting.Change_userid
                            scheBase.insert()
                            i += 1
                        End If

                        If (scheduleId = "A00002" Or scheduleId = "A00003") And PBDTYPE = "2" And PBDDESC.IndexOf("農曆過年") < 0 Then
                            '假日日間, 假日夜間
                            Dim idCard As String = memList(i)

                            scheSetting.Depart_id = d.GetDepartId(idCard)
                            scheSetting.User_name = psn.GetColumnValue("User_name", idCard)
                            scheSetting.Id_card = idCard
                            scheSetting.Sche_date = PBDDATE

                            scheSetting.Sche_type = "1"
                            scheSetting.insert()

                            'copy
                            scheBase.Orgcode = scheSetting.Orgcode
                            scheBase.Schedule_id = scheSetting.Schedule_id
                            scheBase.Depart_id = scheSetting.Depart_id
                            scheBase.User_name = scheSetting.User_name
                            scheBase.Id_card = scheSetting.Id_card
                            scheBase.Sche_date = scheSetting.Sche_date
                            scheBase.Sche_type = scheSetting.Sche_type
                            scheBase.insert()
                            i += 1
                        End If

                        If (scheduleId = "A00004" Or scheduleId = "A00005") And PBDTYPE = "2" And PBDDESC.IndexOf("農曆過年") >= 0 Then
                            '農曆年假期間日間, 農曆年假期間夜間
                            Dim idCard As String = memList(i)

                            scheSetting.Depart_id = d.GetDepartId(idCard)
                            scheSetting.User_name = psn.GetColumnValue("User_name", idCard)
                            scheSetting.Id_card = idCard
                            scheSetting.Sche_date = PBDDATE

                            scheSetting.Sche_type = "1"
                            scheSetting.insert()

                            'copy
                            scheBase.Orgcode = scheSetting.Orgcode
                            scheBase.Schedule_id = scheSetting.Schedule_id
                            scheBase.Depart_id = scheSetting.Depart_id
                            scheBase.User_name = scheSetting.User_name
                            scheBase.Id_card = scheSetting.Id_card
                            scheBase.Sche_date = scheSetting.Sche_date
                            scheBase.Sche_type = scheSetting.Sche_type
                            scheBase.insert()
                            i += 1
                        End If

                    Next

                    scope.Complete()

                Catch ex As Exception
                    AppException.WriteErrorLog(ex.StackTrace, ex.Message)
                    Return "系統發生錯誤!"
                End Try
            End Using

            Return sendNotice(Nothing, yyymm, scheduleId)
        End Function

        Function GetData(ByVal orgcode As String, _
                         ByVal departid As String, _
                         ByVal idcard As String, _
                         ByVal yyymm As String, _
                         ByVal scheduleId As String, _
                         ByVal quitJobFlag As String, _
                         ByVal employeeType As String, _
                         ByVal target As String) As DataTable

            Dim dt As DataTable = DAO.GetData(orgcode, departid, idcard, yyymm, scheduleId, quitJobFlag, employeeType, target)
            dt.Columns.Add("Week", GetType(String))

            Dim week() As String = {"日", "一", "二", "三", "四", "五", "六"}
            For Each dr As DataRow In dt.Rows
                Dim d As Date = DateTimeInfo.GetPublicDate(dr("sche_date").ToString())
                dr("Week") = week(d.DayOfWeek)
            Next

            Return dt
        End Function

        Public Function getFlowData(ByVal orgcode As String, ByVal id_card As String, ByVal sdate As String) As DataTable
            Return DAO.getFlowData(orgcode, id_card, sdate)
        End Function

        Function getDataByDate(ByVal cpadb As String, _
                                ByVal orgcode As String, _
                                ByVal departid As String, _
                                ByVal idcard As String, _
                                ByVal personnelid As String, _
                                ByVal yyymmdd As String) As DataTable
            Return DAO.getDataByDate(cpadb, orgcode, departid, idcard, personnelid, yyymmdd)
        End Function


        Public Function GetDataByOnDutySex(ByVal onDuty As String, ByVal sex As String) As DataTable
            Return DAO.GetDataByOnDutySex(onDuty, sex)
        End Function

        Public Function sendNotice(ByVal dt As DataTable, ByVal yyymm As String, ByVal scheduleId As String) As String
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                dt = GetData(Orgcode, "", "", yyymm, scheduleId, "", "", "")
            End If

            Dim errorMsg = ""
            Dim ws As GoogleCalendarWebService.GoogleAPI = New GoogleCalendarWebService.GoogleAPI
            For Each dr As DataRow In dt.Rows
                Try
                    Using trans As New TransactionScope
                        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(dr("Id_card").ToString)
                        'Dim strUserID As String = psn.ADId + "@epa.gov.tw"
                        Dim strUserID As String = "chotseng@epa.gov.tw"  '測試時使用承辦人的AD
                        Dim Sdate As String = 1911 + CommonFun.getInt(dr("Sche_date").ToString.Substring(0, 3)) & dr("Sche_date").ToString.Substring(3)
                        Dim strStartTime As String = FSC.Logic.DateTimeInfo.ConvertToDisplay(Sdate) + " " + FSC.Logic.DateTimeInfo.ToDisplayTime(dr("Start_time").ToString) + ":00"
                        Dim strEndTime As String = FSC.Logic.DateTimeInfo.ConvertToDisplay(Sdate) + " " + FSC.Logic.DateTimeInfo.ToDisplayTime(dr("End_time").ToString) + ":00"
                        Dim strTitle As String = "值班"
                        Dim strDesc As String = "值班"

                        If psn.ADId <> "nayu" Then '馬昱特別不寫入
                            ws.Post_Google_Calendar_Data(strUserID, strStartTime, strEndTime, strTitle, strDesc, "", "eod")
                        End If

                        Dim FromMail As String = ConfigurationManager.AppSettings("SysMail")
                        Dim ToMail As String = "chotseng@epa.gov.tw" 'psn.Email  '測試時使用承辦人的mail
                        Dim FromName As String = ConfigurationManager.AppSettings("SysName")
                        Dim ToName As String = psn.UserName
                        Dim Subject As String = "值班通知"
                        Dim MailContent As String = psn.UserName + "您好：您於" + FSC.Logic.DateTimeInfo.ConvertToDisplay(dr("Sche_date").ToString) + _
                            "值" + dr("name").ToString() + "(" + FSC.Logic.DateTimeInfo.ToDisplayTime(dr("Start_time").ToString()) + "~" + _
                            FSC.Logic.DateTimeInfo.ToDisplayTime(dr("End_time").ToString()) + ")"

                        CommonFun.SendMail(FromMail, ToMail, FromName, ToName, Subject, MailContent)

                        Dim f As New SYS.Logic.Flow
                        f.FlowId = New SYS.Logic.FlowId().GetFlowId(dr("Orgcode").ToString, "001016")
                        f.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                        f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                        f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                        f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                        f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                        f.ApplyStype = "0"
                        f.WriterOrgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                        f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                        f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                        f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                        f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                        f.WriteTime = Date.Now
                        f.FormId = "001016"
                        f.Reason = MailContent
                        f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                        f.CaseStatus = "0"
                        f.LastPass = "0"

                        Dim fn As New SYS.Logic.FlowNext()
                        fn.Orgcode = dr("Orgcode").ToString
                        fn.FlowId = f.FlowId
                        fn.NextOrgcode = dr("Orgcode").ToString
                        fn.NextDepartid = dr("Depart_id").ToString
                        fn.NextPosid = psn.TitleNo
                        fn.NextIdcard = dr("Id_card").ToString
                        fn.NextName = dr("User_name").ToString
                        fn.CustomFlag = "1"   '自訂關卡註記

                        SYS.Logic.CommonFlow.AddFlow(f, fn)

                        trans.Complete()
                    End Using

                    'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "通知成功!")
                Catch fex As FlowException
                    'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, fex.Message)
                    errorMsg &= fex.Message + "\n"
                Catch ex As Exception
                    errorMsg &= CommonFun.Msg.SystemError + "\n"
                    'CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
                    AppException.WriteErrorLog(ex.StackTrace, ex.Message)
                End Try

            Next

            Return errorMsg
        End Function
    End Class
End Namespace