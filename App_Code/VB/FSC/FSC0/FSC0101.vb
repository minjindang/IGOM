Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System
Imports System.Transactions

Namespace FSC.Logic
    Public Class FSC0101
        Private DAO As FSC0101DAO

        Public Sub New()
            DAO = New FSC0101DAO()
        End Sub

        Public Function GetNextCount(ByVal orgcode As String, ByVal departId As String, ByVal nextIdcard As String) As Integer
            Dim n As Integer = DAO.GetNextCount(orgcode, departId, nextIdcard)
            Dim dt As DataTable = DAO.GetDeputyData(orgcode, departId, nextIdcard)
            For Each dr As DataRow In dt.Rows
                n += DAO.GetNextCount(dr("orgcode").ToString(), dr("depart_id").ToString(), dr("apply_idcard").ToString())
            Next

            Dim deputy As DataTable = New Personnel().getDeputyActive(nextIdcard)
            For Each dr As DataRow In deputy.Rows
                n += DAO.GetNextCount(dr("Orgcode"), dr("Depart_id"), dr("id_card"))
                Dim ddt As DataTable = DAO.GetDeputyData(dr("Orgcode"), dr("Depart_id"), dr("id_card"))
                For Each ddr As DataRow In ddt.Rows
                    n += DAO.GetNextCount(ddr("orgcode").ToString(), ddr("depart_id").ToString(), ddr("apply_idcard").ToString())
                Next
            Next
            Return n
        End Function

        Public Function GetNextCount(ByVal AD_id As String) As Integer
            Return DAO.GetNextCount(AD_id)
        End Function

        Public Function GetNextData(ByVal formId As String, ByVal flowId As String, ByVal dispathDate As String, ByVal nextOrgcode As String, ByVal nextDepartId As String, ByVal nextIdcard As String, _
                                    Optional ByVal Leave_type As String = "", Optional ByVal InterTravelFlag As String = "") As DataTable
            Dim rdt As DataTable = DAO.GetNextData(formId, flowId, dispathDate, nextOrgcode, nextDepartId, nextIdcard, Leave_type, InterTravelFlag)
            Dim dt As DataTable = DAO.GetDeputyData(nextOrgcode, nextDepartId, nextIdcard)
            For Each dr As DataRow In dt.Rows
                rdt.Merge(DAO.GetNextData(formId, flowId, dispathDate, dr("orgcode").ToString(), dr("depart_id").ToString(), dr("apply_idcard").ToString(), Leave_type, InterTravelFlag))
            Next

            Dim deputy As DataTable = New Personnel().getDeputyActive(nextIdcard)
            For Each dr As DataRow In deputy.Rows
                rdt.Merge(DAO.GetNextData(formId, flowId, dispathDate, dr("Orgcode"), dr("Depart_id"), dr("id_card"), Leave_type, InterTravelFlag))
                Dim ddt As DataTable = DAO.GetDeputyData(dr("Orgcode"), dr("Depart_id"), dr("id_card"))
                For Each ddr As DataRow In ddt.Rows
                    rdt.Merge(DAO.GetNextData(formId, flowId, dispathDate, ddr("orgcode").ToString(), ddr("depart_id").ToString(), ddr("apply_idcard").ToString(), Leave_type, InterTravelFlag))
                Next
            Next

            Return rdt
        End Function

        Public Function GetExistsCars(endDate As String, unitCode As String) As DataTable
            Return DAO.GetExistsCars(endDate, unitCode)
        End Function

        Public Function GetDrivers() As DataTable
            Return DAO.GetDrivers()
        End Function

        Public Sub ConfirmCarData(orgcode As String, flowId As String, caseStatus As String, comment As String, isReturn As String, carId As String, driverUserId As String)
            Using trans As New TransactionScope

                ConfirmFlow(orgcode, flowId, caseStatus, comment)

                'If caseStatus <> "2" Then
                '    If DAO.UpdateCarModData(orgcode, flowId, isReturn, carId, driverUserId, caseStatus = 0) >= 1 Then
                '        Throw New FlowException("更新失敗!")
                '    End If

                '    If caseStatus = "0" Then '無車可派 寄信告知申請人
                '        Dim SysMail As String = ConfigurationManager.AppSettings("SysMail").ToString()
                '        Dim SysName As String = ConfigurationManager.AppSettings("SysName").ToString()
                '        CommonFun.SendMail(SysMail, CCMemberEmail, SysName, CCMember, Subject, mailContent.ToString())
                '    End If


                'End If
                DAO.UpdateCarModData(orgcode, flowId, isReturn, carId, driverUserId, caseStatus = 2)
                'If DAO.UpdateCarModData(orgcode, flowId, isReturn, carId, driverUserId, caseStatus = 2) >= 1 Then
                '    Throw New FlowException("更新失敗!")
                'End If

                If isReturn = "0" OrElse caseStatus = "2" Then '無車可派 寄信告知申請人
                    'Dim flow As New SYS.Logic.Flow()
                    'flow.GetObject(orgcode, flowId)
                    Dim ccdmDAO As New FSCPLM.Logic.CAR_CarDispatch_main
                    Dim drCDM As DataRow = ccdmDAO.GetOne(flowId, orgcode)
                    Dim SysMail As String = ConfigurationManager.AppSettings("SysMail").ToString()
                    Dim SysName As String = ConfigurationManager.AppSettings("SysName").ToString()
                    Dim content As String = IIf(isReturn = "0", "無車接回", IIf(caseStatus = "2", "無車可派", ""))
                    Dim mailContent As New StringBuilder
                    'mailContent.Append(String.Format("<p>你所申請的派車申請單號 : {0}</p>", flowId))
                    'mailContent.Append(String.Format("<p>用車日期 : {0} {1} ~ {2} {3} 目前無車可派</p>", CommonFun.SetDataRow(drCDM, "Start_date"), CommonFun.SetDataRow(drCDM, "Start_time"), CommonFun.SetDataRow(drCDM, "End_Date"), CommonFun.SetDataRow(drCDM, "End_time")))
                    'mailContent.Append("<p>煩請調整預約時間或將此案件進行取消，進行短程車費之申請。謝謝。</p>")
                    'mailContent.Append(String.Format("<p>派車管理員 {0} 敬上</p>", LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)))

                    mailContent.Append(drCDM("User_id").ToString + "您好：<br />")
                    mailContent.Append("您所申請的車輛" + drCDM("Car_name").ToString + "目前" + content + "。")
                    Dim applyUserId As String = CommonFun.SetDataRow(drCDM, "User_id")

                    Dim pDAO As New Personnel
                    Dim personnelDT As DataTable = pDAO.GetDataByIdCard(applyUserId)
                    If personnelDT IsNot Nothing AndAlso personnelDT.Rows.Count > 0 Then
                        Dim email As String = IIf(IsDBNull(personnelDT.Rows(0)("Email")), "", personnelDT.Rows(0)("Email"))
                        Dim name As String = IIf(IsDBNull(personnelDT.Rows(0)("User_name")), "", personnelDT.Rows(0)("User_name")) 'User_name
                        If Not String.IsNullOrEmpty(email) Then
                            CommonFun.SendMail(SysMail, email, SysName, name, content + "通知", mailContent.ToString())
                        End If
                    End If
                End If

                trans.Complete()
            End Using

        End Sub

        Public Sub ConfirmApplyMaterialData(orgcode As String, flowId As String, detList As List(Of String()))
            Dim main As New FSCPLM.Logic.Material_main()
            Dim applyDet As New FSCPLM.Logic.ApplyMaterialDet()

            Using trans As New TransactionScope

                ConfirmFlow(orgcode, flowId, "1", "")

                For Each arr As Array In detList
                    Dim org As String = arr(0)
                    Dim fid As String = arr(1)
                    Dim outCnt As String = arr(2)
                    Dim materialId As String = arr(3)
                    Dim applyCnt As String = arr(4)

                    'update 領用數量
                    applyDet.UpdateOutCnt(org, fid, outCnt, materialId)

                    'update 可用餘額 Available_cnt 庫存量 Reserve_cnt
                    main.updateAvailableCntReserveCnt(applyCnt, outCnt, materialId, org)
                Next

                trans.Complete()
            End Using

        End Sub

        Protected Sub ConfirmFlow(orgcode As String, flowId As String, caseStatus As String, comment As String)
            Dim lastOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim lastDepartId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            Dim lastPosid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            Dim lastIdcard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            Dim lastName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)

            Dim fd As New SYS.Logic.FlowDetail()
            fd.Orgcode = orgcode
            fd.FlowId = flowId
            fd.LastOrgcode = lastOrgcode
            fd.LastDepartid = lastDepartId
            fd.LastPosid = lastPosid
            fd.LastIdcard = lastIdcard
            fd.LastName = lastName
            fd.AgreeFlag = IIf(caseStatus <> "1", "2", caseStatus)
            fd.AgreeTime = Now
            fd.Comment = comment
            fd.ChangeDate = Now
            fd.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            SYS.Logic.CommonFlow.RunFlow(fd)
        End Sub

        Public Function GetEXAMINEFeeData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetEXAMINEFeeData(orgcode, flowId)
        End Function

        Public Function GetDUTYFeeData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetDUTYFeeData(orgcode, flowId)
        End Function

        Public Function GetVOLFeeData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetVOLFeeData(orgcode, flowId)
        End Function

        Public Function GetTRANSFeeData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetTRANSFeeData(orgcode, flowId)
        End Function


        Public Function GetEDUFeeData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetEDUFeeData(orgcode, flowId)
        End Function

        Public Function GetAllowanceFeeData(orgcode As String, flowId As String) As DataTable
            Dim dt As DataTable = DAO.GetAllowanceFeeData(orgcode, flowId)
            dt.Columns.Add("Apply_desc")
            For Each dr As DataRow In dt.Rows
                Dim Apply_type As String = dr("Apply_type")
                If "001" = Apply_type Then
                    dr("Apply_desc") = "戶籍謄本(戶口名簿)正本暨結婚證書"
                ElseIf "002" = Apply_type Then
                    dr("Apply_desc") = "戶籍謄本(戶口名簿)正本暨出生證明書"
                ElseIf "003" = Apply_type Then
                    dr("Apply_desc") = "戶籍謄本(戶口名簿)正本暨死亡證明書"
                End If


            Next
            dt.AcceptChanges()
            Return dt
        End Function

        Public Function GetTrafficFeeData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetTrafficFeeData(orgcode, flowId)
        End Function

        Public Function GetApplyMaterialData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetApplyMaterialData(orgcode, flowId)
        End Function


        Public Function GetPropertyData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetPropertyData(orgcode, flowId)
        End Function
        '1030529_Ray
        Public Function GetPropertyDataNew(orgcode As String, flowId As String) As DataTable
            Return DAO.GetPropertyDataNew(orgcode, flowId)
        End Function

        Public Function GetPropertyTranData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetPropertyTranData(orgcode, flowId)
        End Function

        Public Function GetSwRegisterData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetSwRegisterData(orgcode, flowId)
        End Function

        Public Function GetSwMaintainData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetSwMaintainData(orgcode, flowId)
        End Function

        Public Function GetElecMaintainData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetElecMaintainData(orgcode, flowId)
        End Function

        Public Sub ConfirmElecMaintainData(orgcode As String, flowId As String, detList As List(Of Hashtable))
            Dim caseCloseType As String = "Y"

            Using trans As New TransactionScope

                ConfirmFlow(orgcode, flowId, "1", "")

                For Each ht As Hashtable In detList

                    Dim mtClassType As String = ht("MtClass_type")
                    Dim mtStatusDesc As String = ht("MtStatus_desc")
                    Dim mtStatusType As String = ht("MtStatus_type")

                    If ("003,005,006").IndexOf(mtStatusType) < 0 Then
                        caseCloseType = ""
                    End If

                    DAO.UpdateElecMaintainDetData(orgcode, flowId, mtClassType, mtStatusDesc, mtStatusType)

                Next

                DAO.UpdateElecMaintainMainData(orgcode, flowId, caseCloseType)

                trans.Complete()
            End Using
        End Sub

        Public Function GetInfoNetServiceMainData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetInfoNetServiceMainData(orgcode, flowId)
        End Function

        Public Function GetInfoNetServiceDetData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetInfoNetServiceDetData(orgcode, flowId)
        End Function

        Public Sub ConfirmInfoNetServicenData(orgcode As String, flowId As String)
            Using trans As New TransactionScope
                ConfirmFlow(orgcode, flowId, "1", "")
            End Using
        End Sub

        Public Function GetOTHBroadcastMainData(orgcode As String, flowId As String) As DataTable
            Return DAO.GetOTHBroadcastMainData(orgcode, flowId)
        End Function

        Public Sub ConfirmOTHBroadcastData(orgcode As String, flowId As String)
            Using trans As New TransactionScope
                ConfirmFlow(orgcode, flowId, "1", "")
            End Using
        End Sub

        Public Function GetApplyData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, _
                                     ByVal dates As String, ByVal datee As String, ByVal formId As String, ByVal caseStatus As String, ByVal lastPass As String) As DataTable
            Return DAO.GetApplyData(orgcode, departId, idCard, dates, datee, formId, caseStatus, lastPass)
        End Function

        Public Function GetMergedData(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Return DAO.GetMergedData(orgcode, flowId)
        End Function

        Public Function GetHasFlowDetailData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal dates As String, ByVal datee As String, ByVal formId As String) As DataTable
            Return DAO.GetHasFlowDetailData(orgcode, departId, idCard, dates, datee, formId)
        End Function


        Public Function GetHasFlowDetailReplaceData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, _
                                                    ByVal replaceOrgcode As String, ByVal replaceDepartid As String, ByVal replaceIdcard As String, _
                                                    ByVal dates As String, ByVal datee As String, ByVal formId As String) As DataTable
            Return DAO.GetHasFlowDetailReplaceData(orgcode, departId, idCard, replaceOrgcode, replaceDepartid, replaceIdcard, dates, datee, formId)
        End Function

        ''' <summary>
        ''' 回傳當月份刷卡異常資料
        ''' </summary>
        ''' <param name="PKIDNO">員工編號</param>
        ''' <param name="PKWDATE">出勤日期</param>
        ''' <param name="PKWKTPE">上下班狀態</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCPAPK_ERROR(ByVal PKIDNO As String, ByVal PKWDATE As String, ByVal PKWKTPE As String) As DataTable
            Return DAO.GetCPAPK_ERROR(PKIDNO, PKWDATE, PKWKTPE)
        End Function

        ''' <summary>
        ''' 回傳排班資料
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="Id_card">員工編號</param>
        ''' <param name="PKWDATE01">排班日期(起)</param>
        ''' <param name="PKWDATE02">排班日期(迄)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetScheduleData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal PKWDATE01 As String, ByVal PKWDATE02 As String) As DataTable
            Return DAO.GetScheduleData(Orgcode, Depart_id, Id_card, PKWDATE01, PKWDATE02)
        End Function

        ''' <summary>
        ''' 回傳在職/服務中文證明資料檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWorkserviceData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            Return DAO.GetWorkserviceData(Flow_id, Orgcode)
        End Function

        ''' <summary>
        ''' 回傳 敍獎申請資料檔-主檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordMainData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            Return DAO.GetRewordMainData(Flow_id, Orgcode)
        End Function

        ''' <summary>
        ''' 回傳 敍獎申請資料檔-明細檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordDetailData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            Return DAO.GetRewordDetailData(Flow_id, Orgcode)
        End Function

        ''' <summary>
        ''' 回傳 值日(夜)代(換)值申請資料檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDutyChangeData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            Return DAO.GetDutyChangeData(Flow_id, Orgcode)
        End Function

        Public Function getLeaveMainData(ByVal AD_id As String, ByVal yyymm As String) As DataTable
            Return DAO.getLeaveMainData(AD_id, yyymm)
        End Function
        Public Function GetInventoryData(ByVal Orgcode As String) As DataTable
            Return DAO.GetInventoryData(Orgcode)
        End Function
        Public Function Period(ByVal Orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            Return DAO.Period(Orgcode, departId, idCard)
        End Function
        Public Function GetIneAdminData(ByVal Orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal roleid As String) As DataTable
            Return DAO.GetIneAdminData(Orgcode, departId, idCard, roleid)
        End Function
        Public Function GetAvailableSafeData(ByVal Orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            Return DAO.GetAvailableSafeData(Orgcode, departId, idCard)
        End Function

        Public Sub SetBudgetType(orgcode As String, flowId As String, formId As String, budgetType As String)
            Dim flow As New SYS.Logic.Flow()
            Dim outfee As New SAL.Logic.SAL_OfficialoutFee()

            Using scope As New TransactionScope

                If formId = "002002" Then   '差旅費

                    Dim dt As DataTable = flow.GetDataByOrgMergeFid(orgcode, flowId)

                    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

                        Dim list As List(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(dt)
                        For Each f As SYS.Logic.Flow In list
                            flow.UpdateBudgetType(f.Orgcode, f.FlowId, budgetType)
                            outfee.UpdateBudgetType(f.Orgcode, f.FlowId, budgetType)
                        Next

                    Else

                        flow.UpdateBudgetType(orgcode, flowId, budgetType)
                        outfee.UpdateBudgetType(orgcode, flowId, budgetType)

                    End If

                End If

                scope.Complete()
            End Using
        End Sub

        Public Function getOfficialoutFee(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Return DAO.getOfficialoutFee(Orgcode, Flow_id)
        End Function
    End Class
End Namespace
