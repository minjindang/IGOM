Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class CommonFlow
        Private Shared process As SYS.Logic.Process

        ''' <summary>
        ''' 新增流程
        ''' </summary>
        ''' <param name="flow">表單資料</param>
        ''' <remarks></remarks>
        Public Shared Sub AddFlow(ByVal flow As SYS.Logic.Flow)
            ChkFlow(flow)
            SetProcess(flow.FormId)
            process.InitFlow(flow)
        End Sub


        ''' <summary>
        ''' 新增流程
        ''' </summary>
        ''' <param name="flow">表單資料</param>
        ''' <param name="flowNext">下關人員資料</param>
        ''' <remarks></remarks>
        Public Shared Sub AddFlow(ByVal flow As SYS.Logic.Flow, ByVal flowNext As SYS.Logic.FlowNext)
            ChkFlow(flow)
            SetProcess(flow.FormId)
            process.InitFlow(flow, flowNext)
        End Sub

        ''' <summary>
        ''' 新增流程(差假)
        ''' </summary>
        ''' <param name="flow">表單資料</param>
        ''' <param name="LeaveMain">差假資料</param>
        ''' <remarks></remarks>
        Public Shared Sub AddFlow(ByVal flow As SYS.Logic.Flow, ByVal LeaveMain As FSC.Logic.LeaveMain)
            Dim leaveMainList As New List(Of FSC.Logic.LeaveMain)
            leaveMainList.Add(LeaveMain)
            AddFlow(flow, leaveMainList)
        End Sub

        ''' <summary>
        ''' 新增流程(差假)
        ''' </summary>
        ''' <param name="flow">表單資料</param>
        ''' <param name="leaveMainList">差假資料</param>
        ''' <remarks></remarks>
        Public Shared Sub AddFlow(ByVal flow As SYS.Logic.Flow, ByVal leaveMainList As List(Of FSC.Logic.LeaveMain))
            ChkFlow(flow)
            Dim process As New ProcessFSC()
            process.InitFlow(flow, leaveMainList, Nothing)
        End Sub

        ''' <summary>
        ''' 新增流程(差假)
        ''' </summary>
        ''' <param name="flow">表單資料</param>
        ''' <param name="leaveMainList">差假資料</param>
        ''' <remarks></remarks>
        Public Shared Sub AddFlow(ByVal flow As SYS.Logic.Flow, ByVal leaveMainList As List(Of FSC.Logic.LeaveMain), ByVal leaveMainMappingList As List(Of FSC.Logic.LeaveMainMapping))
            ChkFlow(flow)
            Dim process As New ProcessFSC()
            process.InitFlow(flow, leaveMainList, leaveMainMappingList)
        End Sub

        ''' <summary>
        ''' 批核流程
        ''' </summary>
        ''' <param name="flowDetail"></param>
        ''' <remarks></remarks>
        Public Shared Sub RunFlow(ByVal flowDetail As FlowDetail)
            ChkFlowDetail(flowDetail)

            Dim flow As SYS.Logic.Flow = GetFlowObject(flowDetail.Orgcode, flowDetail.FlowId)
            SetProcess(flow.FormId)

            If flowDetail.ResendFlag = "1" Then '修改重送
                process.RunResendFlow(flow, flowDetail)
            Else
                process.RunFlow(flow, flowDetail)
            End If



            If flow.CaseStatus = "1" Then
                '確認/同意

                If flow.IsLast Then

                    If String.IsNullOrEmpty(flow.CancelFlowid) Then
                        '流程跑完後處理動作
                        process.RunAgreeFlow(flow)
                    Else
                        '撤銷表單處理
                        process.RunCancelFlow(flow)
                    End If

                End If

            ElseIf flow.CaseStatus = "2" Then
                '退回/不同意
                process.RunRejectFlow(flow)

            ElseIf flow.CaseStatus = "4" Then
                '取消

                If flow.IsLast Then
                    '取消流程處理動作
                    process.RunDeleteFlow(flow)
                End If

            End If

        End Sub

        ''' <summary>
        ''' 批核流程(自訂下關)
        ''' </summary>
        ''' <param name="flowDetail"></param>
        ''' <param name="flowNext"></param>
        ''' <remarks></remarks>
        Public Shared Sub RunFlow(ByVal flowDetail As FlowDetail, ByVal flowNext As FlowNext)
            ChkFlowDetail(flowDetail)
            ChkFlowNext(flowNext)

            Dim flow As SYS.Logic.Flow = GetFlowObject(flowDetail.Orgcode, flowDetail.FlowId)
            SetProcess(flow.FormId)

            process.RunFlow(flow, flowDetail, flowNext, 1)
        End Sub


        ''' <summary>
        ''' 撤銷差假
        ''' </summary>
        ''' <param name="flow">撤銷表單</param>
        ''' <param name="flowDetail"></param>
        ''' <remarks></remarks>
        Public Shared Sub RunCancel(ByVal flow As Flow, ByVal flowDetail As FlowDetail)
            ChkFlowDetail(flowDetail)
            SetProcess(flow.FormId)

            Dim lmList As List(Of FSC.Logic.LeaveMain) = New FSC.Logic.LeaveMain().GetObjects(flow.Orgcode, flow.CancelFlowid)
            If lmList IsNot Nothing AndAlso lmList.Count > 0 Then
                Dim processFsc As New ProcessFSC()
                Dim nlmList As New List(Of FSC.Logic.LeaveMain)
                For Each lm As FSC.Logic.LeaveMain In lmList
                    lm.Orgcode = flow.Orgcode
                    lm.FlowId = flow.FlowId
                    lm.Reason = flow.Reason
                    lm.LeaveType = "85"
                    nlmList.Add(lm)
                Next
                processFsc.InitFlow(flow, nlmList, Nothing)
            Else
                process.InitFlow(flow)
            End If

            Dim oFlow As Flow = New Flow().GetObject(flow.Orgcode, flow.CancelFlowid)
            process.RunFlow(oFlow, flowDetail)

        End Sub



        ''' <summary>
        ''' 批核流程(轉分)
        ''' </summary>
        ''' <param name="flowDetail"></param>
        ''' <param name="flowNext"></param>
        ''' <remarks></remarks>
        Public Shared Sub TransFlow(ByVal flowDetail As FlowDetail, ByVal flowNext As FlowNext)
            ChkFlowDetail(flowDetail)
            ChkFlowNext(flowNext)

            Dim flow As SYS.Logic.Flow = GetFlowObject(flowDetail.Orgcode, flowDetail.FlowId)
            SetProcess(flow.FormId)

            process.RunFlow(flow, flowDetail, flowNext, 0)
        End Sub


        ''' <summary>
        ''' 手動結束流程
        ''' </summary>
        ''' <param name="flowDetail"></param>
        ''' <remarks></remarks>
        Public Shared Sub RunSelfClose(ByVal flowDetail As FlowDetail)
            ChkFlowDetail(flowDetail)

            Dim flow As SYS.Logic.Flow = GetFlowObject(flowDetail.Orgcode, flowDetail.FlowId)
            SetProcess(flow.FormId)

            process.RunSelfCloseFlow(flow, flowDetail)
        End Sub

        ''' <summary>
        ''' 成批/造冊
        ''' </summary>
        ''' <param name="list"></param>
        ''' <remarks></remarks>
        Public Shared Sub MergeFlow(list As List(Of Hashtable))
            Dim orgcode As String = LoginManager.OrgCode
            Dim departId As String = LoginManager.Depart_id
            Dim userId As String = LoginManager.UserId

            Dim f As New SYS.Logic.Flow()
            Dim fn As New SYS.Logic.FlowNext()
            Dim flowIdList As New ArrayList()
            For Each ht As Hashtable In list
                flowIdList.Add(ht("Flow_id"))
            Next
            flowIdList.Sort()
            Dim minOrgcode As String = ""
            Dim minFlowId As String = flowIdList(0)
            For Each ht As Hashtable In list
                If ht("Flow_id") = minFlowId Then
                    minOrgcode = ht("Orgcode")
                    Exit For
                End If
            Next

            For Each ht As Hashtable In list
                Dim mergeFlag As String = "2"
                If ht("Flow_id") = minFlowId Then
                    mergeFlag = "1"
                Else
                    fn.Delete(ht("Orgcode"), ht("Flow_id"))     'delete flow_next
                End If

                f.UpdateMergedFlow(ht("Orgcode"), ht("Flow_id"), mergeFlag, minOrgcode, minFlowId, Now, orgcode, departId, userId, "0", Now)
            Next
        End Sub


        ''' <summary>
        ''' 手動新增(大批請假, 大批加班)
        ''' </summary>
        ''' <param name="flow"></param>
        ''' <param name="flowDetail"></param>
        ''' <param name="LeaveMain"></param>
        ''' <remarks></remarks>
        Public Shared Sub AddSelfFlow(ByVal flow As SYS.Logic.Flow, ByVal flowDetail As SYS.Logic.FlowDetail, ByVal LeaveMain As FSC.Logic.LeaveMain)
            Dim process As New ProcessFSC()

            '新增Flow
            If Not flow.Insert() Then
                Throw New FlowException("新增表單失敗!")
            End If

            '新增至 Flow_detail
            If Not flowDetail.InsertFlowDetail() Then
                Throw New FlowException("新增表單記錄失敗!")
            End If

            '新增'FSC_Leave_Main
            If Not LeaveMain.InsertLeaveMain() Then
                Throw New FlowException("新增差假主檔失敗!")

                If LeaveMain.LeaveType <> "80" Then
                    process.insertAgent(LeaveMain)
                End If

            End If

            Dim leaveTable As String = New SYS.Logic.LeaveType().GetLeaveTable(LeaveMain.LeaveType)

            If leaveTable = LeaveType.LeaveTable.CPAPO15M Then    '大批請假

                'FSC_CPAPO15M
                Dim po15m As New FSC.Logic.CPAPO15M()
                po15m.POGUID = LeaveMain.FlowId
                po15m.POIDNO = LeaveMain.IdCard
                po15m.PONAME = LeaveMain.UserName
                po15m.POCARD = LeaveMain.IdCard
                po15m.Orgcode = LeaveMain.Orgcode
                po15m.DepartId = LeaveMain.DepartId
                po15m.POVTYPE = LeaveMain.LeaveType
                po15m.POVDATEB = LeaveMain.StartDate
                po15m.POVDATEE = LeaveMain.EndDate
                po15m.POVTIMEB = LeaveMain.StartTime
                po15m.POVTIMEE = LeaveMain.EndTime
                po15m.POREMARK = LeaveMain.Reason
                po15m.POUSERID = flow.ChangeUserid
                po15m.POUPDATE = FSCPLM.Logic.DateTimeInfo.GetRocDateTime(Now)
                po15m.POVDAYS = FSC.Logic.Content.ConvertDayHours(LeaveMain.LeaveHours)

                '新增'FSC_CPAPO15M
                If Not po15m.InsertCPAPO15M() Then
                    Throw New FlowException("新增失敗!")
                End If

            ElseIf leaveTable = LeaveType.LeaveTable.CPAPR18M Then

                'FSC_CPAPR18M
                Dim pr18m As New FSC.Logic.CPAPR18M()
                pr18m.PRGUID = LeaveMain.FlowId
                pr18m.Orgcode = LeaveMain.Orgcode
                pr18m.PRNAME = LeaveMain.UserName
                pr18m.PRIDNO = LeaveMain.IdCard
                pr18m.PRCARD = LeaveMain.IdCard
                pr18m.DepartId = LeaveMain.DepartId
                pr18m.PRADDD = LeaveMain.StartDate
                pr18m.PRADDE = LeaveMain.EndDate
                pr18m.PRSTIME = LeaveMain.StartTime
                pr18m.PRETIME = LeaveMain.EndTime
                pr18m.PRREASON = LeaveMain.Reason

                pr18m.PRATYPE = LeaveMain.LeaveNgroup.Substring(1)
                pr18m.PRMEMO = LeaveMain.OvertimeFlag
                pr18m.PRADDH = LeaveMain.LeaveHours
                pr18m.PRUSERID = flow.ChangeUserid
                pr18m.PRUPDATE = FSCPLM.Logic.DateTimeInfo.GetRocDateTime(Now)

                Dim dao As New FSC.Logic.CPAPR18MDAO()

                If CType(dao.GetCountByPRSTIME(pr18m.PRIDNO, pr18m.PRADDD, pr18m.PRSTIME, pr18m.PRETIME), Integer) > 0 Then
                    Throw New FlowException(LeaveMain.UserName & "已有該時段的加班記錄!")
                End If

                '新增P2K.CPAPR18M
                If Not pr18m.InsertCPAPR18M() Then
                    Throw New FlowException("新增失敗!")
                End If
            End If

            process.RunAgreeFlow(flow)
        End Sub


        ''' <summary>
        ''' 手動撤銷(無流程, 直接更新原表單為撤銷狀態)
        ''' </summary>
        ''' <param name="flowDetail"></param>
        ''' <remarks></remarks>
        Public Shared Sub RunSelfCancel(ByVal flowDetail As FlowDetail)
            ChkFlowDetail(flowDetail)

            Dim flow As SYS.Logic.Flow = GetFlowObject(flowDetail.Orgcode, flowDetail.FlowId)
            process = New ProcessFSC()

            'hsien 移至 xxx 處理
            'Dim off As New OfficialoutFee()
            '
            'If f.Leave_type = "5" Then
            '    '刪除之前申請的差旅費資料
            '    off.deleteDataByFlowId(f.Orgcode, f.Flow_id)
            'End If

            flowDetail.CancelLastData(flow.Orgcode, flow.FlowId)

            '新增flow_detail
            flowDetail.InsertFlowDetail()

            '模擬為撤銷
            flow.CaseStatus = "3"

            '模擬為撤銷表單
            flow.CancelFlowid = flow.FlowId

            '更新flow 狀態
            flow.UpdateLast(flow.Orgcode, flow.FlowId, flow.CaseStatus, "1", Now)

            process.RunAgreeFlow(flow)
        End Sub

        Private Shared Function GetFlowObject(orgcode As String, flowId As String) As SYS.Logic.Flow
            Dim flow As New SYS.Logic.Flow()
            Return flow.GetObject(orgcode, flowId)
        End Function

        Protected Shared Sub SetProcess(ByVal flowId As String)
            Dim flowKind As String = flowId.Substring(0, 3)
            Dim flowType As String = flowId.Substring(3)

            Select Case flowKind
                Case "002"
                    process = New ProcessSAL()
                Case "003"
                    Select Case flowType
                        Case "001", "002", "003", "004", "005"
                            process = New ProcessMAT()
                        Case "006"
                            process = New ProcessCAR()
                        Case "007", "008", "009", "010"
                            process = New ProcessMAI()
                        Case Else
                            process = New ProcessFSC()
                    End Select
                Case "004"
                    process = New ProcessPRO()
                Case "005"
                    process = New ProcessOTH()
                Case Else
                    process = New ProcessFSC()
            End Select

        End Sub

        Private Shared Sub ChkFlow(f As Flow)
            If String.IsNullOrEmpty(f.Orgcode) Then
                Throw New FlowException("未設定表單機關")
            End If
            If String.IsNullOrEmpty(f.FlowId) Then
                Throw New FlowException("未設定表單編號")
            End If
            If String.IsNullOrEmpty(f.DepartId) Then
                Throw New FlowException("未設定申請者單位")
            End If
            If String.IsNullOrEmpty(f.ApplyPosid) Then
                Throw New FlowException("未設定申請者職稱")
            End If
            If String.IsNullOrEmpty(f.ApplyIdcard) Then
                Throw New FlowException("未設定申請者員編")
            End If
            If String.IsNullOrEmpty(f.ApplyName) Then
                Throw New FlowException("未設定申請者姓名")
            End If
            'If String.IsNullOrEmpty(f.ApplyStype) Then
            '    Throw New FlowException("未設定申請者服務類別")
            'End If
            If String.IsNullOrEmpty(f.FormId) Then
                Throw New FlowException("未設定表單類型編號")
            End If
        End Sub

        Private Shared Sub ChkFlowDetail(fd As FlowDetail)
            If String.IsNullOrEmpty(fd.Orgcode) Then
                Throw New FlowException("未設定表單機關")
            End If
            If String.IsNullOrEmpty(fd.FlowId) Then
                Throw New FlowException("未設定表單編號")
            End If
            If String.IsNullOrEmpty(fd.AgreeFlag) Then
                Throw New FlowException("未設定是否同意")
            End If
            If String.IsNullOrEmpty(fd.LastOrgcode) Then
                Throw New FlowException("未設定批核者機關")
            End If
            If String.IsNullOrEmpty(fd.LastDepartid) Then
                Throw New FlowException("未設定批核者單位")
            End If
            If String.IsNullOrEmpty(fd.LastPosid) Then
                Throw New FlowException("未設定批核者職稱")
            End If
            If String.IsNullOrEmpty(fd.LastIdcard) Then
                Throw New FlowException("未設定批核者員編")
            End If
            If String.IsNullOrEmpty(fd.LastName) Then
                Throw New FlowException("未設定批核者姓名")
            End If
        End Sub

        Private Shared Sub ChkFlowNext(fn As FlowNext)
            If String.IsNullOrEmpty(fn.Orgcode) Then
                Throw New FlowException("未設定表單機關")
            End If
            If String.IsNullOrEmpty(fn.FlowId) Then
                Throw New FlowException("未設定表單編號")
            End If
            If String.IsNullOrEmpty(fn.NextOrgcode) Then
                Throw New FlowException("未設定下關批核者機關")
            End If
            If String.IsNullOrEmpty(fn.NextDepartid) Then
                Throw New FlowException("未設定下關批核者單位")
            End If
            If String.IsNullOrEmpty(fn.NextPosid) Then
                Throw New FlowException("未設定下關批核者職稱")
            End If
            If String.IsNullOrEmpty(fn.NextIdcard) Then
                Throw New FlowException("未設定下關批核者員編")
            End If
            If String.IsNullOrEmpty(fn.NextName) Then
                Throw New FlowException("未設定下關批核者姓名")
            End If
        End Sub
    End Class
End Namespace