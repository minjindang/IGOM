Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports FSCPLM.Logic

Namespace SYS.Logic
    Public Class Outpost


        ''' <summary>
        ''' 取得簽核流程字串
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDisplayOutpost(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal flow_outpost_id As String, Optional ByVal hasHoursetting As Boolean = False) As String
            Dim Outpost As String = String.Empty

            If String.IsNullOrEmpty(flow_outpost_id) Then Return String.Empty

            Dim dt As DataTable = New FlowOutpostMaster().GetDataByFlowOutpostID(Orgcode, flow_outpost_id)

            For Each fo_dr As DataRow In dt.Rows
                If hasHoursetting Then
                    Outpost &= "(" & GetOutpostIdNameWithHoursetting(Orgcode, Depart_id, Id_card, fo_dr("Outpost_id").ToString(), fo_dr("Outpost_orgcode").ToString(), fo_dr("Outpost_departid").ToString(), fo_dr("Outpost_posid").ToString(), fo_dr("Relate_flag").ToString(), fo_dr("Hoursetting_id").ToString()) & ")-"
                Else
                    Outpost &= "(" & GetOutpostIdName(Orgcode, fo_dr("Outpost_id"), fo_dr("Outpost_orgcode"), fo_dr("Outpost_departid"), fo_dr("Outpost_posid"), fo_dr("Relate_flag"), fo_dr("Unit_flag").ToString()) & ")-"
                End If
            Next
            Return Outpost & "(結束)"
        End Function


        ''' <summary>
        ''' 取得簽核流程字串
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDisplayOutpost(ByVal Orgcode As String, ByVal list As List(Of FlowOutpostMaster)) As String
            Dim Outpost As String = String.Empty

            For i As Integer = 0 To list.Count - 1
                Dim fom As FlowOutpostMaster = list(i)
                Outpost &= "(" & GetOutpostIdNameWithHoursetting(Orgcode, "", "", fom.Outpost_id, fom.Outpost_orgcode, fom.Outpost_departid, fom.Outpost_posid, fom.Relate_flag, fom.Hoursetting_id) & ")-"
            Next
            Return Outpost & "(結束)"
        End Function

        ''' <summary>
        ''' 取Outpost_id的中文字串
        ''' </summary>
        ''' <param name="Outpost_id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetOutpostIdName(ByVal Orgcode As String, _
                                         ByVal Outpost_id As String, _
                                         ByVal Outpost_orgcode As String, _
                                         ByVal Outpost_departid As String, _
                                         ByVal Outpost_posid As String, _
                                         ByVal Relate_flag As String, _
                                         ByVal Unit_flag As String) As String
            Dim code As New SACode()
            Dim org As New FSC.Logic.Org()
            Dim orgcodeName As String = org.GetOrgcodeSName(Outpost_orgcode)
            Dim departName As String = IIf(String.IsNullOrEmpty(Outpost_departid), "", org.GetDepartName(Outpost_orgcode, Outpost_departid))

            Dim suf As String = ""
            If Relate_flag = "5" Or Relate_flag = "6" Or Relate_flag = "7" Then
                suf = "(會)"
            End If

            If Relate_flag = "0" Then   '主管別

                Return code.GetCodeDesc("023", "015", Outpost_id)

            ElseIf Relate_flag = "1" Then   '簽核關卡

                Return code.GetCodeDesc("023", "011", Outpost_id)

            ElseIf Relate_flag = "2" Or Relate_flag = "5" Then   '指定職稱

                Dim titleName As String = code.GetCodeDesc("023", "012", Outpost_id)
                Return titleName & "(" & orgcodeName & departName & ")" & suf

            ElseIf Relate_flag = "3" Or Relate_flag = "6" Then   '指定人員

                Dim titleName As String = code.GetCodeDesc("023", "012", Outpost_id)
                Dim userName As String = New FSC.Logic.Personnel().GetColumnValue("User_name", Outpost_id)
                Return userName & "(" & orgcodeName & departName & titleName & ")" & suf

            ElseIf Relate_flag = "4" Or Relate_flag = "7" Then   '指定角色

                Dim role As New SYS.Logic.Role()
                Dim dt As DataTable = role.GetRole(Outpost_orgcode, Outpost_id)
                Dim roleName As String = ""
                If dt IsNot Nothing Then
                    roleName = dt.Rows(0)("Role_name").ToString()
                End If

                Return roleName & IIf(Unit_flag = "1", "(依申請單位)", "") & "(" & orgcodeName & departName & ")" & suf
            End If

            Return "error"
        End Function

        ''' <summary>
        ''' 取Outpost_id的中文字串，含時數條件
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetOutpostIdNameWithHoursetting(ByVal Orgcode As String, _
                                                        ByVal Depart_id As String, _
                                                        ByVal Id_card As String, _
                                                        ByVal Outpost_id As String, _
                                                        ByVal Outpost_orgcode As String, _
                                                        ByVal Outpost_departid As String, _
                                                        ByVal Outpost_posid As String, _
                                                        ByVal Relate_flag As String, _
                                                        ByVal Hoursetting_id As String) As String

            Dim userName As String = ""
            Dim titleName As String = ""
            Dim orgcodeName As String = ""
            Dim departName As String = ""
            Dim quitJob As String = ""
            Dim roleName As String = ""

            Dim code As New SACode()
            Dim psn As New FSC.Logic.Personnel()
            Dim org As New FSC.Logic.Org()

            '人立修改0980715 測試記錄編號TC0980714003,TC0980714004
            Dim Hoursetting As String = GetDisplayHourSetting(Hoursetting_id)

            '主管別
            If Relate_flag = "0" Then
                Dim code_name As String = New SACode().GetCodeDesc("023", "015", Outpost_id)
                Return String.Format(Hoursetting, code_name)
            End If

            '簽核關卡
            If Relate_flag = "1" Then
                Dim code_name As String = New SACode().GetCodeDesc("023", "011", Outpost_id)
                Return String.Format(Hoursetting, code_name)

                'If String.IsNullOrEmpty(Id_card) Then
                '    Return String.Format(Hoursetting, code_name)
                'Else
                '    '針對人
                '    If Outpost_id = "001" Then
                '        '代理人
                '        Return String.Format(Hoursetting, code_name)
                '    Else
                '        '直屬主管

                '        Dim pboss As New FSC.Logic.PersonnelBoss()
                '        Dim level As Integer = CType(Outpost_id, Integer) - 1
                '        Dim dt As DataTable = pboss.GetData(Orgcode, Depart_id, Id_card, "", level)
                '        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                '            userName = psn.GetColumnValue("User_name", dt.Rows(0)("Boss_idcard").ToString())
                '            Dim titleNo As String = psn.GetColumnValue("Title_no", dt.Rows(0)("Boss_idcard").ToString())
                '            titleName = code.GetCodeDesc("023", "012", titleNo)
                '        End If

                '    End If

                '    If String.IsNullOrEmpty(userName) Then
                '        Return String.Format(Hoursetting, code_name & "(<span style='color:red'>無設定或查無此人</span>)")
                '    End If
                '    Return String.Format(Hoursetting, code_name & "<span style='color:blue'>" & userName & "</span>(" & titleName & ")" & quitJob)
                'End If

            End If

            '指定職務
            If Relate_flag = "2" Or Relate_flag = "5" Then
                Dim dt As DataTable = psn.GetTitleDataByOrgDep(Outpost_orgcode, Outpost_departid)

                For Each dr As DataRow In dt.Rows
                    If Outpost_id = dr("Title_no").ToString() Then
                        titleName = code.GetCodeDesc("023", "012", Outpost_id)
                        Exit For
                    End If
                Next
                orgcodeName = org.GetOrgcodeName(Outpost_orgcode)
                departName = org.GetDepartName(Outpost_orgcode, Outpost_departid)

                If String.IsNullOrEmpty(titleName) Then
                    Return String.Format(Hoursetting, titleName & "(<span style='color:red'>查無此人</span>)")
                End If

                Return String.Format(Hoursetting, "<span style='color:blue'>" & titleName & "</span>(" & orgcodeName & departName & ")" & quitJob)
            End If

            '指定人員
            If Relate_flag = "3" Or Relate_flag = "6" Then

                userName = psn.GetColumnValue("User_name", Outpost_id)
                titleName = code.GetCodeDesc("023", "012", psn.GetColumnValue("Title_no", Outpost_id))
                orgcodeName = org.GetOrgcodeName(Outpost_orgcode)
                departName = org.GetDepartName(Outpost_orgcode, Outpost_departid)

                If String.IsNullOrEmpty(userName) Then
                    Return String.Format(Hoursetting, "<span style='color:red'>查無此人</span>")
                End If

                Return String.Format(Hoursetting, "<span style='color:blue'>" & userName & "</span>(" & orgcodeName & departName & titleName & ")" & quitJob)
            End If

            '指定角色
            If Relate_flag = "4" Or Relate_flag = "7" Then

                Dim role As New SYS.Logic.Role()
                Dim dt As DataTable = role.GetRole(Outpost_orgcode, Outpost_id)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    roleName = dt.Rows(0)("Role_name").ToString()
                End If

                orgcodeName = org.GetOrgcodeName(Outpost_orgcode)
                If Not String.IsNullOrEmpty(Outpost_departid) Then
                    departName = org.GetDepartName(Outpost_orgcode, Outpost_departid)
                End If

                If String.IsNullOrEmpty(roleName) Then
                    Return String.Format(Hoursetting, "<span style='color:red'>查無此角色</span>")
                End If

                Return String.Format(Hoursetting, "<span style='color:blue'>" & roleName & "</span>(" & orgcodeName & departName & ")" & quitJob)

            End If

            Return "error"
        End Function

        ''' <summary>
        ''' 組合時數限制中文表示字串
        ''' </summary>
        ''' <param name="Hoursetting_id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetDisplayHourSetting(ByVal Hoursetting_id As String) As String

            If String.IsNullOrEmpty(Hoursetting_id) Then Return "{0}"

            Dim DetailCodeName As String = New SACode().GetCodeDesc("023", "006", Hoursetting_id)

            Dim Setting As String = String.Empty

            If Mid(DetailCodeName, 1, 1) = "<" Then
                Setting = "小於"
            ElseIf Mid(DetailCodeName, 1, 1) = ">" Then
                Setting = "超過"
            End If
            If Mid(DetailCodeName, 2, 1) = "=" Then
                Setting &= "等於"
            End If

            Dim Hour As String = DetailCodeName.Replace(">", "").Replace("<", "").Replace("=", "")

            If DetailCodeName = "<=3" Then
                Return "時數小於或等於3小時，直接送至{0}"
            End If

            Return "時數" & Setting & Hour & "小時送至{0}，未" & Setting & "送至結束"

        End Function

        Public Shared Function GetJoinOutpost(ByVal Outpost_id As String, _
                                               ByVal Outpost_orgcode As String, _
                                               ByVal Outpost_departid As String, _
                                               ByVal Outpost_posid As String, _
                                               ByVal Relate_flag As String, _
                                               ByVal Unit_flag As String) As String

            '簽核關卡
            If Relate_flag = "1" Then
                Return Relate_flag & "," & Outpost_id
            End If

            '主管別
            If Relate_flag = "0" Then
                Return Relate_flag & "," & Outpost_id
            End If

            '指定職務
            If Relate_flag = "2" Or Relate_flag = "5" Then
                Return Relate_flag & "," & Outpost_id & "," & Outpost_orgcode & "," & Outpost_departid
            End If

            '指定人員
            If Relate_flag = "3" Or Relate_flag = "6" Then
                Return Relate_flag & "," & Outpost_id & "," & Outpost_orgcode & "," & Outpost_departid
            End If

            '指定角色
            If Relate_flag = "4" Or Relate_flag = "7" Then
                Return Relate_flag & "," & Outpost_id & "," & Outpost_orgcode & "," & Outpost_departid & "," & unit_flag
            End If

            Return ""
        End Function


        Public Shared Function GetTargetName(ByVal target As String, ByVal targetType As String) As String
            Dim code As New SACode()
            Dim targetName As String = ""

            If "1".Equals(targetType) Then
                '職稱
                targetName &= code.GetCodeDesc("023", "012", target)

            ElseIf "2".Equals(targetType) Then
                '人員
                targetName &= New FSC.Logic.Personnel().GetColumnValue("User_name", target)

            ElseIf "3".Equals(targetType) Then
                '員工類別
                targetName &= code.GetCodeDesc("023", "022", target)

            End If

            Return targetName
        End Function


        Public Shared Function GetFormName(ByVal formId As String) As String
            Dim code As New FSCPLM.Logic.SACode()
            Dim formName As String = ""
            If formId.Length = 6 Then
                'formName = code.GetCodeDesc("024", "**", formId.Substring(0, 3))
                formName &= code.GetCodeDesc("024", formId.Substring(0, 3), formId.Substring(3))
            End If
            Return formName
        End Function



#Region "取關卡DataTable"
        Public Shared Function GetFlowOutpost(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal formId As String) As DataTable
            Dim fom As New SYS.Logic.FlowOutpostMaster()
            Dim personnel As New FSC.Logic.Personnel()

            '依人員找關卡檔
            Dim dt As DataTable = fom.GetData(orgcode, departId, idCard, "2", formId)

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '若無關卡檔,再依職稱找關卡檔
                Dim titleNo As String = personnel.GetColumnValue("Title_no", idCard)
                dt = fom.GetData(orgcode, departId, titleNo, "1", formId)
            End If

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '若無關卡檔,再依職務別找關卡檔
                Dim employeeType As String = personnel.GetColumnValue("Employee_type", idCard)
                dt = fom.GetData(orgcode, departId, employeeType, "3", formId)
            End If

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                '沒有對應的關卡檔
                Throw New FlowException("沒有對應的關卡檔!請通知人事管理員或系統管理員設定相關流程!")
            End If

            Return dt
        End Function
#End Region

    End Class
End Namespace