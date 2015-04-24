Imports Microsoft.VisualBasic
Imports FSCPLM.Logic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public MustInherit Class Process

        ''' <summary>
        ''' 初始流程
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <remarks></remarks>
        Public Sub InitFlow(ByVal flow As SYS.Logic.Flow)
            InitFlow(flow, Nothing)
        End Sub


        ''' <summary>
        ''' 初始流程
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <param name="flowNext"></param>
        ''' <remarks></remarks>
        Public Sub InitFlow(ByVal flow As SYS.Logic.Flow, ByVal flowNext As SYS.Logic.FlowNext)
            If flow Is Nothing Then
                Throw New FlowException("尚未設定表單資料!")
            End If

            Dim fopdt As DataTable = Outpost.GetFlowOutpost(flow.Orgcode, flow.DepartId, flow.ApplyIdcard, flow.FormId)
            If fopdt Is Nothing OrElse fopdt.Rows.Count <= 0 Then
                '沒有對應的關卡檔
                Throw New FlowException("沒有對應的關卡檔!請通知人事管理員或系統管理員設定相關流程!")
            End If

            flow.LastPass = 0
            flow.CaseStatus = 0
            flow.WriteTime = Now

            If String.IsNullOrEmpty(flow.WriterIdcard) Then
                '無填寫人資料, 帶申請人資料
                flow.WriterOrgcode = flow.Orgcode
                flow.WriterDepartid = flow.DepartId
                flow.WriterPosid = flow.ApplyPosid
                flow.WriterIdcard = flow.ApplyIdcard
                flow.WriterName = flow.ApplyName
            End If

            Dim fnbool As Boolean = False
            If flowNext IsNot Nothing Then
                flowNext.NextStep = 1
                flowNext.CustomFlag = "1"   '自訂關卡註記
                fnbool = flowNext.Insert()
            Else
                fnbool = InsertFlowNext(flow, fopdt, 1)
            End If

            If Not fnbool Then
                Throw New FlowException("新增批核人員時發生錯誤!")
            End If

            If Not flow.Insert() Then
                Throw New FlowException("新增流程時發生錯誤!")
            End If
        End Sub

        ''' <summary>
        ''' 批核流程
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <param name="flowDetail"></param>
        ''' <remarks></remarks>
        Public Sub RunFlow(ByVal flow As SYS.Logic.Flow, ByVal flowDetail As SYS.Logic.FlowDetail)
            If flowDetail Is Nothing Then
                Throw New FlowException("尚未設定表單明細資料!")
            End If

            Dim nowStep As Integer = 1
            Dim nextStep As Integer = 0

            Dim nowFlowNext As FlowNext = New FlowNext().GetObject(flowDetail.Orgcode, flowDetail.FlowId, _
                                                                   flowDetail.LastOrgcode, flowDetail.LastDepartid, flowDetail.LastIdcard, flowDetail.AgreeStep)
            If nowFlowNext IsNot Nothing Then
                nowStep = nowFlowNext.NextStep
            Else
                '自已刪除時
                Dim fnlist As List(Of FlowNext) = New FlowNext().GetObjects(flow.Orgcode, flow.FlowId)
                If fnlist IsNot Nothing AndAlso fnlist.Count > 0 Then
                    nowFlowNext = fnlist(0)
                End If
            End If
            nextStep = nowStep + 1
            flow.CaseStatus = flowDetail.AgreeFlag

            Dim fopdt As DataTable = Outpost.GetFlowOutpost(flow.Orgcode, flow.DepartId, flow.ApplyIdcard, flow.FormId)
            If fopdt Is Nothing OrElse fopdt.Rows.Count <= 0 Then
                '沒有對應的關卡檔
                Throw New FlowException("沒有對應的關卡檔!請通知人事管理員或系統管理員設定相關流程!")
            End If
            Dim lastRow As DataRow = fopdt.Rows(fopdt.Rows.Count - 1)
            Dim lastStep As Integer = CommonFun.getInt(lastRow("Outpost_seq").ToString())   '最後一關step

            If flowDetail.AgreeFlag = 1 Then
                '同意

                '最後step<=現在step, 則為最後一關
                If lastStep <= nowStep Then
                    flow.IsLast = True
                End If

                Dim foprs() As DataRow = fopdt.Select(" outpost_seq = " & nextStep)
                If foprs IsNot Nothing AndAlso foprs.Length > 0 AndAlso "999" = foprs(0)("outpost_id") Then
                    '限制為自訂關卡人員, 才可結束流程
                    If "1" <> nowFlowNext.CustomFlag Then
                        Throw New FlowException("下關為自訂關卡，請先設定人員!")
                    End If
                End If

                If Not flow.IsLast Then
                    Dim hoursettingId As String = foprs(0)("Hoursetting_id").ToString()

                    'If IsNotOverHours(flow, hoursettingId) Then
                    '    flow.IsLast = True

                    '    '最後一關
                    '    RunFlowToLast(flow, flowDetail, nowFlowNext)
                    'Else
                    '    '下一關
                    '    RunFlowToNext(flow, fopdt, nextStep)
                    'End If

                    '跑時數限制條件
                    If IsNotOverHours(flow, hoursettingId) Then
                        nextStep = lastStep     '設為最後一關
                    End If

                    '檢核最後一關是否為時數限制
                    foprs = fopdt.Select(" outpost_seq = " & nextStep)
                    hoursettingId = foprs(0)("Hoursetting_id").ToString()

                    If IsNotOverHours(flow, hoursettingId) Then
                        '最後一關
                        flow.IsLast = True
                        RunFlowToLast(flow, flowDetail, nowFlowNext)
                    Else
                        '下一關
                        RunFlowToNext(flow, fopdt, nextStep)
                    End If
                Else

                    '最後一關
                    RunFlowToLast(flow, flowDetail, nowFlowNext)
                End If

            ElseIf flowDetail.AgreeFlag = 2 Then
                '退回/不同意

                RunFlowToBack(flow, flowDetail, fopdt, nextStep)

            ElseIf flowDetail.AgreeFlag = 3 Then
                '撤銷

                'flow.IsLast = True

                ''最後一關
                'RunFlowToLast(flow, flowDetail, nowFlowNext)

            ElseIf flowDetail.AgreeFlag = 4 Then
                '取消

                flow.IsLast = True

                '最後一關
                RunFlowToLast(flow, flowDetail, nowFlowNext)
            End If

            '新增至flow_detail 
            If Not InsertFlowDetal(flowDetail, nowFlowNext) Then
                Throw New FlowException("新增至表單明細時發生錯誤!")
            End If

        End Sub


        Public Sub RunSelfCloseFlow(flow As SYS.Logic.Flow, flowDetail As SYS.Logic.FlowDetail)
            flow.IsLast = True

            Dim nowFlowNext As FlowNext = New FlowNext().GetObject(flowDetail.Orgcode, flowDetail.FlowId, _
                                                                   flowDetail.LastOrgcode, flowDetail.LastDepartid, flowDetail.LastIdcard, flowDetail.AgreeStep)

            '最後一關
            RunFlowToLast(flow, flowDetail, nowFlowNext)

            '刪除此關批核人員
            DeleteFlowNext(flow.Orgcode, flow.FlowId, 0)

            '新增至flow_detail 
            If Not InsertFlowDetal(FlowDetail, nowFlowNext) Then
                Throw New FlowException("新增至表單明細時發生錯誤!")
            End If
        End Sub

        ''' <summary>
        ''' 重送
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <param name="flowDetail"></param>
        ''' <remarks></remarks>
        Public Sub RunResendFlow(ByVal flow As SYS.Logic.Flow, ByVal flowDetail As SYS.Logic.FlowDetail)
            If flowDetail Is Nothing Then
                Throw New FlowException("尚未設定表單明細資料!")
            End If

            '刪除此關批核人員
            DeleteFlowNext(flow.Orgcode, flow.FlowId, 0)

            Dim nowFlowNext As FlowNext = New FlowNext()
            Dim fddt As DataTable = New SYS.Logic.FlowDetail().GetDataByFlow_id(flow.Orgcode, flow.FlowId)

            If fddt IsNot Nothing AndAlso fddt.Rows.Count > 0 Then
                Dim i As Integer = fddt.Rows.Count - 1 '取最後一筆

                nowFlowNext.Orgcode = fddt.Rows(i)("Orgcode").ToString()
                nowFlowNext.FlowId = fddt.Rows(i)("Flow_id").ToString()
                nowFlowNext.NextOrgcode = fddt.Rows(i)("last_orgcode").ToString()
                nowFlowNext.NextDepartid = fddt.Rows(i)("last_Departid").ToString()
                nowFlowNext.NextPosid = fddt.Rows(i)("last_posid").ToString()
                nowFlowNext.NextIdcard = fddt.Rows(i)("last_idcard").ToString()
                nowFlowNext.NextName = fddt.Rows(i)("last_name").ToString()
                nowFlowNext.NextStep = fddt.Rows(i)("agree_step").ToString()
                nowFlowNext.GroupId = 0
                nowFlowNext.Insert()
            Else
                Throw New FlowException("查無批核資料!")
            End If

            flow.CaseStatus = flowDetail.AgreeFlag

            '更新flow狀態
            flow.UpdateCaseStatus(flow.Orgcode, flow.FlowId, flow.CaseStatus)

            '新增至flow_detail 
            If Not InsertFlowDetal(flowDetail, nowFlowNext) Then
                Throw New FlowException("新增至表單明細時發生錯誤!")
            End If
        End Sub

        ''' <summary>
        ''' 批核流程, 自訂下關
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <param name="flowDetail"></param>
        ''' <param name="flowNext"></param>
        ''' <param name="addStep">增加關卡的step</param>
        ''' <remarks></remarks>
        ''' 
        Public Sub RunFlow(ByVal flow As SYS.Logic.Flow, ByVal flowDetail As SYS.Logic.FlowDetail, ByVal flowNext As SYS.Logic.FlowNext, ByVal addStep As Integer)
            Dim nowFlowNext As FlowNext = New FlowNext().GetObject(flowDetail.Orgcode, flowDetail.FlowId, _
                                                                   flowDetail.LastOrgcode, flowDetail.LastDepartid, flowDetail.LastIdcard, flowDetail.AgreeStep)
            Dim nowStep As Integer = nowFlowNext.NextStep

            Dim fopdt As DataTable = Outpost.GetFlowOutpost(flow.Orgcode, flow.DepartId, flow.ApplyIdcard, flow.FormId)
            If fopdt Is Nothing OrElse fopdt.Rows.Count <= 0 Then
                '沒有對應的關卡檔
                Throw New FlowException("沒有對應的關卡檔!請通知人事管理員或系統管理員設定相關流程!")
            End If
            Dim foprs() As DataRow = fopdt.Select(" outpost_seq = " & nowStep + addStep)

            If "0" = nowFlowNext.GroupId Then
                If foprs.Length <> 0 Then
                    If "300" <> foprs(0)("outpost_id").ToString() And "301" <> foprs(0)("outpost_id").ToString() Then
                        If "999" <> foprs(0)("outpost_id").ToString() Then
                            Throw New FlowException("非自訂關卡!")
                        End If
                    End If
                End If
            End If

            '更新flow狀態
            flow.CaseStatus = flowDetail.AgreeFlag
            flow.UpdateCaseStatus(flow.Orgcode, flow.FlowId, flow.CaseStatus)

            '1.刪除此關批核人員
            DeleteFlowNext(flow.Orgcode, flow.FlowId, nowFlowNext.GroupId)

            '2.新增批核人員
            flowNext.NextStep = nowStep + addStep
            flowNext.GroupId = nowFlowNext.GroupId
            flowNext.GroupStep = flowNext.GroupStep + 1
            flowNext.CustomFlag = "1"   '自訂關卡註記
            flowNext.Insert()

            '新增至flow_detail 
            If Not InsertFlowDetal(flowDetail, nowFlowNext) Then
                Throw New FlowException("新增至表單明細時發生錯誤!")
            End If
        End Sub

        '確認後處理
        Public MustOverride Sub RunAgreeFlow(ByVal flow As SYS.Logic.Flow)

        '退件後處理
        Public MustOverride Sub RunRejectFlow(ByVal flow As SYS.Logic.Flow)

        '撤銷後處理
        Public MustOverride Sub RunCancelFlow(ByVal flow As SYS.Logic.Flow)

        '取消後處理
        Public MustOverride Sub RunDeleteFlow(ByVal flow As SYS.Logic.Flow)


        Protected Sub RunFlowToNext(flow As SYS.Logic.Flow, fopdt As DataTable, nextStep As Integer)
            '設定批核人員
            If Not InsertFlowNext(flow, fopdt, nextStep) Then
                Throw New FlowException("更新批核人員時發生錯誤!")
            End If

            '更新flow狀態
            flow.UpdateCaseStatus(flow.Orgcode, flow.FlowId, flow.CaseStatus)
        End Sub

        Protected Sub RunFlowToBack(flow As SYS.Logic.Flow, flowDetail As SYS.Logic.FlowDetail, fopdt As DataTable, nextStep As Integer)
            Dim rows() As DataRow = fopdt.Select(" outpost_seq = " & nextStep - 1)
            Dim groupId As String = rows(0)("Group_id").ToString()
            Dim groupStep As String = rows(0)("Group_seq").ToString()
            Dim Back_step As Integer = CommonFun.getInt(rows(0)("Back_Step"))

            '1.刪除此關批核人員
            DeleteFlowNext(flow.Orgcode, flow.FlowId, groupId)

            '2.設定下個批核人員
            Dim flowNext As New FlowNext()
            flowNext.Orgcode = flow.Orgcode
            flowNext.FlowId = flow.FlowId

            If flow.MergeFlag = "1" Then
                Dim psn As New FSC.Logic.Personnel()
                flowNext.NextOrgcode = flow.MergeUorgcode
                flowNext.NextDepartid = flow.MergeUdepartid
                flowNext.NextIdcard = flow.MergeUserid
                flowNext.NextName = psn.GetColumnValue("User_name", flow.MergeUserid)
                flowNext.NextPosid = psn.GetColumnValue("Title_no", flow.MergeUserid)
            Else
                If Back_step <> 0 Then
                    flow.CaseStatus = "1"
                    RunFlowToNext(flow, fopdt, Back_step)    '回指定關卡
                End If

                flowNext.NextOrgcode = flow.Orgcode
                flowNext.NextDepartid = flow.DepartId
                flowNext.NextIdcard = flow.ApplyIdcard
                flowNext.NextName = flow.ApplyName
                flowNext.NextPosid = flow.ApplyPosid

            End If
            flowNext.NextStep = nextStep - 2
            flowNext.GroupId = groupId
            flowNext.GroupStep = groupStep

            If Not flowNext.Insert() Then
                Throw New FlowException("更新批核人員時發生錯誤!")
            End If

            '更新flow狀態
            flow.UpdateCaseStatus(flow.Orgcode, flow.FlowId, flow.CaseStatus)
        End Sub

        Protected Sub RunFlowToLast(flow As SYS.Logic.Flow, flowDetail As SYS.Logic.FlowDetail, nowFlowNext As SYS.Logic.FlowNext)
            Dim groupId As Integer = 0
            If nowFlowNext IsNot Nothing Then
                groupId = nowFlowNext.GroupId
            End If

            '刪除批核人員
            If Not DeleteFlowNext(flow.Orgcode, flow.FlowId, groupId) Then
                'Throw New FlowException("更新批核人員時發生錯誤!")
            End If

            If groupId = 0 Then
                '更新flow狀態
                flow.CaseStatus = flowDetail.AgreeFlag

                If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                    '更新成批其它表單
                    Dim dt As DataTable = flow.GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                    Dim fList As List(Of Flow) = CommonFun.ConvertToList(Of Flow)(dt)
                    For Each f As Flow In fList
                        flow.UpdateLast(f.Orgcode, f.FlowId, flow.CaseStatus, "1", Now)
                    Next
                Else
                    flow.UpdateLast(flow.Orgcode, flow.FlowId, flow.CaseStatus, "1", Now)
                End If
            Else
                '會辦需所以待批者皆完成批核才可結束表單
                Dim fndt As DataTable = New FlowNext().GetDataByOrgFid(flow.Orgcode, flow.FlowId)
                If fndt Is Nothing OrElse fndt.Rows.Count <= 0 Then
                    If Not String.IsNullOrEmpty(flow.MergeFlowid) Then
                        '更新成批其它表單
                        Dim dt As DataTable = flow.GetDataByOrgMergeFid(flow.MergeOrgcode, flow.MergeFlowid)
                        Dim fList As List(Of Flow) = CommonFun.ConvertToList(Of Flow)(dt)
                        For Each f As Flow In fList
                            flow.UpdateLast(f.Orgcode, f.FlowId, flow.CaseStatus, "1", Now)
                        Next
                    Else
                        flow.UpdateLast(flow.Orgcode, flow.FlowId, flow.CaseStatus, "1", Now)
                    End If
                End If
            End If

            flowDetail.LastPass = 1
            flowDetail.LastDate = Now
        End Sub


#Region "設定下個批核人員"
        Protected Function DeleteFlowNext(ByVal orgcode As String, ByVal flowId As String, ByVal groupId As String) As Boolean
            Dim fn As New FlowNext()
            Return fn.Delete(orgcode, flowId, groupId)
        End Function

        Protected Function InsertFlowNext(ByVal flow As SYS.Logic.Flow, ByVal fopdt As DataTable, ByVal nextStep As Integer) As Boolean
            Dim flowNextList As New List(Of FlowNext)

            Dim rows() As DataRow = fopdt.Select(" outpost_seq = " & nextStep)
            For Each crow As DataRow In rows

                Dim relateFlag As String = crow("Relate_flag").ToString()                 '關卡種類
                Dim outpostId As String = crow("Outpost_id").ToString()
                Dim outpostPosid As String = crow("Outpost_posid").ToString()
                Dim outpostOrgcode As String = crow("Outpost_orgcode").ToString()
                Dim OutpostDepartid As String = crow("Outpost_departid").ToString()
                Dim groupId As String = crow("Group_id").ToString()
                Dim groupStep As String = crow("Group_seq").ToString()
                Dim mailFlag As String = crow("Mail_flag").ToString()
                Dim unitFlag As String = crow("Unit_flag").ToString()

                '1.刪除此關批核人員
                DeleteFlowNext(flow.Orgcode, flow.FlowId, groupId)

                '2.設定下個批核人員
                Dim list As List(Of FlowNext) = GetFlowNext(flow, fopdt, outpostId, outpostOrgcode, OutpostDepartid, outpostPosid, relateFlag, groupId, groupStep, nextStep, mailFlag, unitFlag)
                flowNextList.AddRange(list)

            Next

            '3.新增下關批核人員
            For Each FlowNext As FlowNext In flowNextList
                If Not FlowNext.Insert() Then
                    Return False
                End If
            Next

            Return True
        End Function


        Protected Function GetFlowNext(ByVal flow As SYS.Logic.Flow, _
                                       ByVal fopdt As DataTable, _
                                       ByVal outpostId As String, _
                                       ByVal outpostOrgcode As String, _
                                       ByVal outpostDepartid As String, _
                                       ByVal outpostPosid As String, _
                                       ByVal relateFlag As String, _
                                       ByVal groupId As String, _
                                       ByVal groupStep As String, _
                                       ByVal nextStep As Integer, _
                                       ByVal mailFlag As String, _
                                       ByVal unitFlag As String) As List(Of FlowNext)

            Dim flowNextList As New List(Of FlowNext)
            Dim psn As New FSC.Logic.Personnel()
            Dim code As New FSCPLM.Logic.SACode()
            Dim dv As New FSC.Logic.DeputyVacancy

            If relateFlag = "0" Then
                '主管別
                Dim pdt As DataTable = Nothing

                If outpostId = "001" Then
                    '三層主管
                    pdt = psn.GetDataByBossLevelId(flow.Orgcode, flow.DepartId, "3")

                    If pdt Is Nothing OrElse pdt.Rows.Count <= 0 Then
                        pdt = dv.getData(flow.Orgcode, flow.DepartId, "3", "")
                    End If
                ElseIf outpostId = "002" Then
                    '二層主管
                    pdt = psn.GetDataByBossLevelId(flow.Orgcode, flow.DepartId.Substring(0, 2) & "0000", "2")

                    If pdt Is Nothing OrElse pdt.Rows.Count <= 0 Then
                        pdt = dv.getData(flow.Orgcode, flow.DepartId.Substring(0, 2) & "0000", "2", "")
                    End If
                ElseIf outpostId = "003" Then
                    '一層主管
                    pdt = psn.GetDataByBossLevelId(flow.Orgcode, "", "1")

                    If pdt Is Nothing OrElse pdt.Rows.Count <= 0 Then
                        pdt = dv.getData(flow.Orgcode, "", "1", "")
                    End If
                End If

                If pdt Is Nothing OrElse pdt.Rows.Count <= 0 Then
                    Throw New FlowException("無批核關卡人員，請洽人事管理人員!")
                Else
                    For Each pdr As DataRow In pdt.Rows
                        Dim flowNext As New FlowNext()
                        flowNext.Orgcode = flow.Orgcode
                        flowNext.FlowId = flow.FlowId
                        flowNext.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                        flowNext.GroupId = groupId
                        flowNext.GroupStep = "1"

                        flowNext.NextOrgcode = pdr("orgcode").ToString()
                        flowNext.NextDepartid = pdr("depart_id").ToString()
                        flowNext.NextIdcard = pdr("id_card").ToString()
                        flowNext.NextPosid = pdr("title_no").ToString()
                        flowNext.NextName = pdr("user_name").ToString()

                        flowNext.NextStep = nextStep
                        flowNext.MailFlag = mailFlag
                        flowNext.ChangeDate = Now
                        flowNextList.Add(flowNext)
                    Next
                End If

            ElseIf relateFlag = "1" Then
                '簽核關卡

                Dim flowNext As New FlowNext()
                flowNext.Orgcode = flow.Orgcode
                flowNext.FlowId = flow.FlowId
                flowNext.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                flowNext.GroupId = groupId
                flowNext.GroupStep = "1"

                If outpostId = "000" Then
                    '申請人

                    flowNext.NextOrgcode = flow.Orgcode
                    flowNext.NextDepartid = flow.DepartId
                    flowNext.NextIdcard = flow.ApplyIdcard
                    flowNext.NextPosid = flow.ApplyPosid
                    flowNext.NextName = flow.ApplyName

                ElseIf outpostId = "001" Then
                    '代理人關卡

                    Dim nextName As String = psn.GetColumnValue("User_name", flow.DeputyIdcard)

                    If String.IsNullOrEmpty(nextName) Then
                        Throw New FlowException("找不到批核關卡的代理人資料，請洽人事管理人員!")
                    End If

                    flow.DeputyFlag = "1"    '設為需要代理人(做為代理的判斷)
                    flowNext.NextOrgcode = flow.DeputyOrgcode
                    flowNext.NextDepartid = flow.DeputyDepartid
                    flowNext.NextIdcard = flow.DeputyIdcard
                    flowNext.NextPosid = flow.DeputyPosid
                    flowNext.NextName = nextName
                    flowNext.DeputyFlag = "1"

                    If flow.FlowId = "001002" Then
                        '需在設定 Next_id 之後，因Method裡面會判斷，如果為最後一筆代理人簽核順序時，會將其取代，回傳False 跑流程關卡。
                        'setNextByOutside()
                    Else
                        flowNext.NextStep += 1
                    End If

                ElseIf outpostId = "300" Then
                    '負責承辦人 
                    Dim dt As DataTable = New MAI.Logic.MaintainMain().GetDataByOrgFid(flow.Orgcode, flow.FlowId)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim sd As DataTable = New SYS.Logic.CODE().GetData(flow.Orgcode, "020", dt.Rows(0)("maintain_kind").ToString(), dt.Rows(0)("maintain_type").ToString())
                        Dim id_card As String = sd.Rows(0)("CODE_REMARK1").ToString()

                        If String.IsNullOrEmpty(id_card) Then
                            Throw New FlowException("查無負責承辦人!")
                        End If

                        Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(id_card)
                        Dim d As DataTable = New FSC.Logic.DepartEmp().GetDataByIdcard(id_card)

                        If p IsNot Nothing AndAlso d.Rows.Count > 0 Then
                            flowNext.NextOrgcode = d.Rows(0)("Orgcode").ToString()
                            flowNext.NextDepartid = d.Rows(0)("Depart_id").ToString()
                            flowNext.NextIdcard = p.IdCard
                            flowNext.NextPosid = p.TitleNo
                            flowNext.NextName = p.UserName
                        Else
                            Throw New FlowException("查無負責承辦人 !")
                        End If
                    Else
                        Throw New FlowException("查無負責承辦人 !")
                    End If

                ElseIf outpostId = "301" Then
                    '負責廠商
                    Dim dt As DataTable = New MAI.Logic.MaintainMain().GetDataByOrgFid(flow.Orgcode, flow.FlowId)
                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                        Dim sd As DataTable = New SYS.Logic.CODE().GetData(flow.Orgcode, "020", dt.Rows(0)("maintain_kind").ToString(), dt.Rows(0)("maintain_type").ToString())
                        If sd IsNot Nothing AndAlso sd.Rows.Count > 0 Then
                            Dim roleId As String = sd.Rows(0)("CODE_REMARK2").ToString()

                            If String.IsNullOrEmpty(roleId) Then
                                Throw New FlowException("查無負責廠商!")
                            End If

                            Dim p As New FSC.Logic.Personnel()
                            Dim pdt As DataTable = p.GetDataByRoleId(flow.Orgcode, "", roleId)
                            If pdt IsNot Nothing AndAlso pdt.Rows.Count > 0 Then
                                For Each pdr As DataRow In pdt.Rows
                                    Dim fn As New FlowNext()
                                    fn.Orgcode = flow.Orgcode
                                    fn.FlowId = flow.FlowId
                                    fn.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                                    fn.GroupId = groupId
                                    fn.GroupStep = "1"

                                    fn.NextOrgcode = pdr("orgcode").ToString()
                                    fn.NextDepartid = pdr("depart_id").ToString()
                                    fn.NextIdcard = pdr("id_card").ToString()
                                    fn.NextPosid = pdr("title_no").ToString()
                                    fn.NextName = pdr("user_name").ToString()

                                    fn.NextStep = nextStep
                                    fn.MailFlag = mailFlag
                                    fn.ChangeDate = Now
                                    flowNextList.Add(fn)
                                Next
                            Else
                                Throw New FlowException("查無負責廠商!")
                            End If

                            Return flowNextList
                        Else
                            Throw New FlowException("查無負責廠商!")
                        End If
                    Else
                        Throw New FlowException("查無負責廠商!")
                    End If

                ElseIf outpostId = "400" Then
                    '新保管人
                    Dim pt As PRO_PropertyTran_main = New PRO_PropertyTran_main
                    Dim dr As DataRow = pt.GetOne(flow.FlowId, flow.Orgcode)

                    If dr IsNot Nothing Then
                        Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(dr("NewKeeper_id").ToString())
                        If p IsNot Nothing Then
                            flowNext.NextOrgcode = dr("Orgcode").ToString()
                            flowNext.NextDepartid = dr("NewUnit_Name").ToString()
                            flowNext.NextIdcard = dr("NewKeeper_id").ToString()
                            flowNext.NextPosid = p.TitleNo
                            flowNext.NextName = p.UserName
                        Else
                            Throw New FlowException("查無新保管人!")
                        End If
                    Else
                        Throw New FlowException("查無新保管人!")
                    End If

                Else
                    '主管關卡
                    Dim personnelBoss As New FSC.Logic.PersonnelBoss()

                    '依代碼檔裡的Outpost_id編號取level(減掉代碼檔裡第一層的代理人)
                    '代碼編號: 01-代理人, 02-直屬主管(level=1), 03-第二層主管(level=2)
                    Dim level As Integer = CType(outpostId, Integer) - 1
                    Dim dt As DataTable = personnelBoss.GetData(flow.Orgcode, flow.DepartId, flow.ApplyIdcard, flow.ApplyStype, level)

                    If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                        '沒有主管
                        Throw New FlowException("找不到批核關卡的主管資料，請洽人事管理人員!")
                    End If

                    'Dim quitJobFlag As String = ""
                    ''若主管為離職狀態, 將代批指定為主管的預設代理人
                    'If "Y" = quitJobFlag Then

                    '    flowNext.ReplaceFlag = "Y"

                    '    '取預設的職務代理人
                    '    Dim ddt As DataTable = New DeputyDet().GetDeputyDetByID_card(row("Id_card").ToString(), "1")   'Deputy_flag=1 取預設職務代理人

                    '    If ddt.Rows.Count <= 0 Then
                    '        Throw New FlowException("批核關卡人員為離職狀態，且找不到預設的職務代理人，請洽人事管理人員!")
                    '    End If

                    '    flowNext.ReplaceFlag = "Y"       '需要代批
                    '    flowNext.ReplaceIdcard = ddt.Rows(0)("Id_card").ToString()
                    '    flowNext.ReplacePosid = ddt.Rows(0)("Title_no").ToString()
                    '    'flowNext.Replacename = ddt.Rows(0)("User_name").ToString()

                    'End If

                    flowNext.NextOrgcode = dt.Rows(0)("Boss_orgcode").ToString()
                    flowNext.NextDepartid = dt.Rows(0)("Boss_departid").ToString()
                    flowNext.NextIdcard = dt.Rows(0)("Boss_idcard").ToString()
                    flowNext.NextPosid = dt.Rows(0)("Boss_posid").ToString
                    flowNext.NextName = psn.GetColumnValue("User_name", flowNext.NextIdcard)
                End If
                flowNext.NextStep = nextStep
                flowNext.MailFlag = mailFlag
                flowNext.ChangeDate = Now
                flowNextList.Add(flowNext)

            ElseIf relateFlag = "2" Or relateFlag = "5" Then
                '指定職務關卡

                Dim posdt As DataTable = psn.GetDataByQuery(outpostOrgcode, outpostDepartid, outpostId, "")

                If posdt Is Nothing OrElse posdt.Rows.Count <= 0 Then
                    posdt = dv.getData(outpostOrgcode, outpostDepartid, "", outpostId)
                End If

                If posdt Is Nothing OrElse posdt.Rows.Count <= 0 Then
                    Throw New FlowException("無批核關卡人員，請洽人事管理人員!")
                Else

                    For Each posdr As DataRow In posdt.Rows

                        Dim flowNext As New FlowNext()
                        flowNext.Orgcode = flow.Orgcode
                        flowNext.FlowId = flow.FlowId
                        flowNext.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                        flowNext.GroupId = groupId
                        flowNext.GroupStep = "1"

                        flowNext.NextOrgcode = outpostOrgcode
                        flowNext.NextDepartid = outpostDepartid
                        flowNext.NextPosid = outpostId
                        flowNext.NextIdcard = posdr("id_card").ToString()
                        flowNext.NextName = psn.GetColumnValue("User_name", flowNext.NextIdcard)
                        flowNext.NextStep = nextStep
                        flowNext.MailFlag = mailFlag
                        flowNext.ChangeDate = Now
                        flowNextList.Add(flowNext)

                    Next

                End If

            ElseIf relateFlag = "3" Or relateFlag = "6" Then
                '指定人員關卡

                Dim dt As DataTable = psn.GetDataByQuery(outpostOrgcode, outpostDepartid, "", outpostId)
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    Throw New FlowException("無批核關卡人員，請洽人事管理人員!")
                End If

                Dim flowNext As New FlowNext()
                flowNext.Orgcode = flow.Orgcode
                flowNext.FlowId = flow.FlowId
                flowNext.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                flowNext.GroupId = groupId
                flowNext.GroupStep = "1"
                flowNext.NextOrgcode = outpostOrgcode
                flowNext.NextDepartid = outpostDepartid
                flowNext.NextPosid = outpostPosid
                flowNext.NextIdcard = outpostId
                flowNext.NextName = psn.GetColumnValue("User_name", flowNext.NextIdcard)
                flowNext.NextStep = nextStep
                flowNext.MailFlag = mailFlag
                flowNext.ChangeDate = Now
                flowNextList.Add(flowNext)


            ElseIf relateFlag = "4" Or relateFlag = "7" Then
                '指定角色

                '依申請單位取單位中的角色
                If unitFlag = "1" Then
                    Dim org As New FSC.Logic.Org()
                    Dim row As DataRow = org.GetDataByDepartid(flow.Orgcode, flow.DepartId)
                    Dim departId As String = ""
                    If row IsNot Nothing Then
                        departId = row("Parent_depart_id").ToString()
                    End If
                    outpostDepartid = departId
                End If

                '關卡為 預算來源單位 特別處理
                If outpostId = "BudgetUnit" Then
                    Dim r As DataRow = code.GetRow("006", "018", flow.Budget_code)
                    If r IsNot Nothing Then
                        outpostId = r("code_remark1").ToString()

                        If flow.Budget_code = "001" Then

                            '公務預算(單位窗口時, 依申請者單位抓時單位窗口) and 評審委員出席審查費、講師鐘點費申請作業
                            If outpostId = "Apply_UnitWindow" And flow.FormId = "002006" Then
                                Dim org As New FSC.Logic.Org()
                                Dim row As DataRow = org.GetDataByDepartid(flow.Orgcode, flow.DepartId)
                                Dim departId As String = ""
                                If row IsNot Nothing Then
                                    departId = row("Parent_depart_id").ToString()
                                End If
                                outpostDepartid = departId

                            Else

                                '強制前往下關
                                nextStep += 1
                                Dim rows() As DataRow = fopdt.Select(" outpost_seq = " & nextStep)
                                For Each crow As DataRow In rows
                                    relateFlag = crow("Relate_flag").ToString()
                                    outpostId = crow("Outpost_id").ToString()
                                    outpostPosid = crow("Outpost_posid").ToString()
                                    outpostOrgcode = crow("Outpost_orgcode").ToString()
                                    outpostDepartid = crow("Outpost_departid").ToString()
                                    groupId = crow("Group_id").ToString()
                                    groupStep = crow("Group_seq").ToString()
                                    mailFlag = crow("Mail_flag").ToString()
                                    unitFlag = crow("Unit_flag").ToString()

                                    '2.設定下個批核人員
                                    Dim list As List(Of FlowNext) = GetFlowNext(flow, fopdt, outpostId, outpostOrgcode, outpostDepartid, outpostPosid, relateFlag, groupId, groupStep, nextStep, mailFlag, unitFlag)
                                    flowNextList.AddRange(list)
                                Next
                                Return flowNextList

                            End If

                        End If

                    Else
                        Throw New FlowException("無批核關卡人員，請洽人事管理人員!")
                    End If
                End If

                Dim dt As DataTable = psn.GetDataByRoleId(outpostOrgcode, outpostDepartid, outpostId)
                If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                    Throw New FlowException("無批核關卡人員，請洽人事管理人員!")
                Else

                    For Each dr As DataRow In dt.Rows
                        Dim flowNext As New FlowNext()
                        flowNext.Orgcode = flow.Orgcode
                        flowNext.FlowId = flow.FlowId
                        flowNext.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                        flowNext.GroupId = groupId
                        flowNext.GroupStep = "1"
                        flowNext.NextOrgcode = outpostOrgcode
                        flowNext.NextDepartid = dr("Depart_id").ToString()
                        flowNext.NextPosid = dr("Title_no").ToString()
                        flowNext.NextIdcard = dr("Id_card").ToString()
                        flowNext.NextName = dr("User_name").ToString()
                        flowNext.NextStep = nextStep
                        flowNext.MailFlag = mailFlag
                        flowNext.ChangeDate = Now
                        flowNextList.Add(flowNext)
                    Next

                End If

            End If
            Return flowNextList
        End Function
#End Region

#Region "新增Flow_detail"
        Protected Function InsertFlowDetal(ByVal flowDetail As SYS.Logic.FlowDetail, ByVal nowFlowNext As SYS.Logic.FlowNext) As Boolean

            flowDetail.AgreeTime = Now
            flowDetail.ChangeDate = Now

            If nowFlowNext IsNot Nothing Then
                flowDetail.AgreeStep = nowFlowNext.NextStep

                're-send
                'If flowDetail.ResendFlag = "1" Then
                '    flowDetail.AgreeStep = nowFlowNext.NextStep + 1
                'End If

                flowDetail.DeputyFlag = nowFlowNext.DeputyFlag
            End If


            If nowFlowNext IsNot Nothing AndAlso _
                (nowFlowNext.ReplaceFlag = "1" Or nowFlowNext.NextIdcard <> flowDetail.LastIdcard) Then

                '設定代批核者
                flowDetail.ReplaceOrgcode = flowDetail.LastOrgcode
                flowDetail.ReplaceDepartid = flowDetail.LastDepartid
                flowDetail.ReplacePosid = flowDetail.LastPosid
                flowDetail.ReplaceIdcard = flowDetail.LastIdcard
                flowDetail.ReplaceName = flowDetail.LastName

                If nowFlowNext IsNot Nothing Then
                    flowDetail.LastOrgcode = nowFlowNext.NextOrgcode
                    flowDetail.LastDepartid = nowFlowNext.NextDepartid
                    flowDetail.LastPosid = nowFlowNext.NextPosid
                    flowDetail.LastIdcard = nowFlowNext.NextIdcard
                    flowDetail.LastName = nowFlowNext.NextName
                End If
            End If

            '新增至 Flow_detail
            Return flowDetail.InsertFlowDetail()

        End Function
#End Region

#Region "跑時數限制條件"
        Protected Function IsNotOverHours(ByVal flow As SYS.Logic.Flow, ByVal hoursettingId As String) As Boolean

            '除人事之外不跑
            If "001" <> flow.FormId.Substring(0, 3) Then
                Return False
            End If

            Dim leaveHours As Integer = 0
            Dim leaveMain As New FSC.Logic.LeaveMain()
            Dim dt As DataTable = leaveMain.GetDataByOrgFid(flow.Orgcode, flow.FlowId)
            For Each dr As DataRow In dt.Rows
                leaveHours += CommonFun.getInt(dr("Leave_hours").ToString())
            Next

            '這個關卡有時數限制
            If Not String.IsNullOrEmpty(hoursettingId) Then
                Dim hoursText As String = New FSCPLM.Logic.SACode().GetCodeDesc("023", "006", hoursettingId)
                Dim hours As Integer = CType(Mid(hoursText, 2), Integer)

                If Mid(hoursText, 1, 1) <> ">" Then
                    Return False
                End If

                'Select Case CType(Mid(hour_text, 2), Integer)    '限制時數
                '    Case 3
                '        hour = 0.3
                '    Case 7
                '        hour = 0.7
                '    Case 23
                '        hour = 3.0
                '    Case 55
                '        hour = 7.0
                'End Select

                If leaveHours <= hours Then
                    Return True
                End If
            End If
            Return False
        End Function
#End Region

    End Class
End Namespace