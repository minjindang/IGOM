Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Web
Imports System.Transactions
Imports FSCPLM.Logic

Namespace SAL.Logic
    Public Class SAL1112

        Dim DAO As SAL1112DAO

        Public Sub New()
            DAO = New SAL1112DAO
        End Sub

        Public Function GetTotalSA(idCard As String, yyymm As String) As Integer

            Dim obj As Object = DAO.GetTotalSA(idCard, yyymm + 191100)
            If obj IsNot Nothing Then
                Return Convert.ToInt32(obj)
            End If

            Return 0
        End Function

        Function doQuerySAL1112(ByVal OrgCode As String, ByVal Unit As String, ByVal yyymm As String, ByVal idCard As String) As DataTable

            Dim dt As DataTable = DAO.doQuerySAL1112(OrgCode, Unit, yyymm, idCard)
            Dim l As New FSC.Logic.LeaveMain
            Dim dti As New DateTimeInfo

            If Not dt Is Nothing Then
                Dim limitDays As Double = 20
                dt.Columns.Add("Start_time", GetType(String))
                dt.Columns.Add("End_time", GetType(String))
                dt.Columns.Add("PRADDD_name", GetType(String))
                dt.Columns.Add("PRADDE_name", GetType(String))
                dt.Columns.Add("PRSTIME_name", GetType(String))
                dt.Columns.Add("PRETIME_name", GetType(String))

                dt.Columns.Add(New DataColumn("Apply_Hour_1", GetType(String)))
                dt.Columns.Add(New DataColumn("Apply_Hour_2", GetType(String)))
                dt.Columns.Add(New DataColumn("Apply_Hour_3", GetType(String)))
                dt.Columns.Add(New DataColumn("Overtime_Pay", GetType(String)))
                For Each dr As DataRow In dt.Rows
                    'disply column
                    dr("PRADDD_name") = DateTimeInfo.ConvertToDisplay(dr("PRADDD").ToString())
                    dr("PRADDE_name") = DateTimeInfo.ConvertToDisplay(dr("PRADDE").ToString())
                    Dim fdt As DataTable = l.GetDataByOrgFid(OrgCode, dr("PRGUID").ToString().Trim())
                    If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
                        dr("Start_time") = dti.ConvertToDisplayTime(fdt.Rows(0)("Start_time").ToString().Trim())
                        dr("End_time") = dti.ConvertToDisplayTime(fdt.Rows(0)("End_time").ToString().Trim())
                    End If
                    dr("PRSTIME_name") = dti.ConvertToDisplayTime(dr("PRSTIME").ToString())
                    dr("PRETIME_name") = dti.ConvertToDisplayTime(dr("PRETIME").ToString())

                    ''����d�̫�ɶ������[�Z����
                    'Dim cpaph As New FSC.Logic.CPAPHYYMM(yyymm)
                    'Dim phdt As DataTable = cpaph.GetData(idCard, dr("PRADDD").ToString(), "E")
                    'If phdt IsNot Nothing AndAlso phdt.Rows.Count > 0 Then
                    '    For Each phdr As DataRow In phdt.Rows
                    '        dr("PRETIME_name") = dti.ConvertToDisplayTime(phdr("PHITIME").ToString())
                    '    Next
                    'End If

                    Dim dt2 As DataTable = DAO.doQueryDetail(OrgCode, yyymm, idCard, Unit, dr("PRADDD"), dr("PRSTIME"))
                    If Not dt2 Is Nothing And dt2.Rows.Count > 0 Then
                        Dim dr2 As DataRow = dt2.Rows(0)
                        dr("Apply_Hour_1") = dr2("Apply_Hour_1")
                        dr("Apply_Hour_2") = dr2("Apply_Hour_2")
                        dr("Apply_Hour_3") = dr2("Apply_Hour_3")
                        dr("Overtime_Pay") = dr2("Overtime_Pay")
                        If 0 < limitDays Then
                            If (limitDays Mod Double.Parse(dr2("Apply_Hour_3")) = limitDays) And (limitDays / Double.Parse(dr2("Apply_Hour_3"))) <> 0 Then
                                dr("Apply_Hour_3") = limitDays
                            Else
                                limitDays = limitDays - Double.Parse(dr2("Apply_Hour_3"))
                            End If
                        Else
                            dr("Apply_Hour_3") = "0"
                        End If

                    Else
                        dr("Apply_Hour_1") = "0"
                        dr("Apply_Hour_2") = "0"
                        dr("Apply_Hour_3") = "0"
                        dr("Overtime_Pay") = "0"
                    End If

                    dr("PRMNYH") = CommonFun.getInt(dr("PRMNYH").ToString()) - (CommonFun.getInt(dr("Apply_Hour_1").ToString()) + CommonFun.getInt(dr("Apply_Hour_2").ToString()) + CommonFun.getInt(dr("Apply_Hour_3").ToString()))
                Next
            End If
            Return dt
        End Function

        Public Function doUpdateDetailCheckInput(ByVal PRADDD As String, _
                                             ByVal Id_Card As String, _
                                             ByVal monthLimit As Integer, _
                                             ByVal total_hours As Integer, _
                                             ByVal project_total_hours As Integer) As String
            Dim str As New StringBuilder()
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

            Dim monthLimitPay As Integer = 0

            Dim rdt As DataTable = New FSC.Logic.ProjectOvertimeRule().getDataByYYYMM(Orgcode, Depart_id, Id_Card, Left(PRADDD, 5))
            If rdt IsNot Nothing AndAlso rdt.Rows.Count > 0 Then
                monthLimitPay = CommonFun.getInt(rdt.Rows(0)("MonOT_pay_hr"))
            End If

            '�`�ɼƤ��i�W�L�C��л�ƤW���C
            If monthLimit <> 0 And monthLimit < total_hours Then
                str.Append("�`�ɼƶW�L�C��W��").Append(monthLimit).Append("�p��!!\n")
            End If

            '�M�ץ[�Z�[�@��[�Z�ɼƤ��o�j��M�ץ[�Z������л�ɼ�
            If monthLimitPay <> 0 And monthLimitPay < total_hours + project_total_hours Then
                str.Append("�`�ɼƶW�L�M�ץ[�Z�i��[�Z�O�ɼƤW��").Append(monthLimitPay).Append("�p��!!\n")
            End If

            Return str.ToString()
        End Function

        Public Function CheckApplyHours(ByVal PRADDD As String, ByVal PRADDH As Integer, ByVal PRPAYH As Integer, _
                                        ByVal ApplyHour1 As Double, ByVal ApplyHour2 As Double, ByVal ApplyHour3 As Double) As String
            Dim DisplayDay As String = FSC.Logic.DateTimeInfo.ToDisplay(PRADDD)
            Dim msg As StringBuilder = New StringBuilder
            Dim pb02m As FSC.Logic.CPAPB02M = New FSC.Logic.CPAPB02M
            If pb02m.IsHoliday(PRADDD) Then
                If ApplyHour1 <> 0 OrElse ApplyHour2 <> 0 Then
                    msg.Append("�[�Z����G" + DisplayDay + "������A�ж�g�ܡu����[�Z1-8�p��(3)�v!\n")
                ElseIf ApplyHour3 > PRADDH - PRPAYH Then
                    msg.Append("�[�Z����G" + DisplayDay + "�A�л�ɼƤ��i�j���ڥi�л�ɼ�!\n")
                End If
            Else
                If ApplyHour3 <> 0 Then
                    msg.Append("�[�Z����G" + DisplayDay + "�D����A�ФŶ�g�ܡu����[�Z1-8�p��(3)�v!\n")
                ElseIf ApplyHour1 + ApplyHour2 > PRADDH - PRPAYH Then
                    msg.Append("�[�Z����G" + DisplayDay + "�A�л�ɼƤ��i�j���ڥi�л�ɼ�!\n")
                ElseIf ApplyHour1 > 2 Then
                    msg.Append("�[�Z����G" + DisplayDay + "����[�Z�ɼƤj��2�p�ɳ����A�ɼƽж�g�ܡu�����u��3-4�p��(2)�v!\n")
                ElseIf PRADDH - PRPAYH <= 2 AndAlso ApplyHour2 <> 0 Then
                    msg.Append("�[�Z����G" + DisplayDay + "����[�Z�ɼƤp��2�p�ɡA�ɼƽж�g�ܡu�����u��1-2�p��(1)�v!\n")
                ElseIf PRADDH - PRPAYH > 2 AndAlso ApplyHour1 <> 2 AndAlso ApplyHour2 <> 0 Then
                    msg.Append("�[�Z����G" + DisplayDay + "����[�Z�ɼƤp��2�p�ɡA�ɼƽж�g�ܡu�����u��1-2�p��(1)�v�A�ɼƤj��2�p�ɳ����A�ɼƽж�g�ܡu�����u��3-4�p��(2)�v!\n")
                End If
            End If

            Return msg.ToString
        End Function

        Public Sub doMasterUpdate(ByVal Orgcode As String, ByVal Depart_id As String, ByVal YearMonth As String, ByVal PRIDNO As String, ByVal flow_id As String)
            Dim detDAO As New LabOvertimeFeeDetailDAO()

            '���X�ӤH���Ӥ���л��Ƥ�����A�զ��@�r��A�Ҧp1,14,15,16,20
            Dim days As New StringBuilder()
            Dim dt As DataTable = detDAO.doQuerySAL1112(Orgcode, Depart_id, PRIDNO, YearMonth)
            If Not dt Is Nothing Then
                For Each row As DataRow In dt.Rows
                    If days.ToString() <> "" Then
                        days.Append(",")
                    End If
                    days.Append(row("day"))
                Next
            End If

            Dim overtime_Date As String = days.ToString()
            Dim Hours As Integer
            Dim Overtime_Fee As Double
            '���X�ӤH���Ӥ���л��Ƥ��ɼƤΪ��B�[�`
            dt = detDAO.doQuerySAL1112_2(Orgcode, Depart_id, PRIDNO, YearMonth)
            If Not dt Is Nothing Then
                For Each row As DataRow In dt.Rows

                    If DBNull.Value.Equals(row("Hours")) Then
                        Hours = 0
                    Else
                        Hours = row("Hours")
                    End If

                    If DBNull.Value.Equals(row("Overtime_Fee")) Then
                        Overtime_Fee = 0
                    Else
                        Overtime_Fee = row("Overtime_Fee")
                    End If

                Next
            End If

            Dim daoLabOvertimeFeeMaster As New LabOvertimeFeeMasterDAO()
            Dim dtFeeMaster As DataTable = daoLabOvertimeFeeMaster.GetDataByQuery(Orgcode, Depart_id, PRIDNO, YearMonth)
            Dim Budget_type As String = GetLastBudget(PRIDNO)

            '���o�ӤH���~����ơA��Ū���~����
            'Dim impdt As DataTable =New FSC3206DAO().doQueryImpSalary(Orgcode, YearMonth, id_card)
            Dim hour_pay As Integer = 0
            Dim main_sa As Integer = 0
            Dim pro_sa As Integer = 0
            Dim header_sa As Integer = 0
            Dim regin_sa As Integer = 0

            'If Not impdt Is Nothing And impdt.Rows.Count > 0 Then
            '    For Each row As DataRow In impdt.Rows
            '        main_sa = impdt.Rows(0)("main_sa").ToString
            '        pro_sa = impdt.Rows(0)("pro_sa").ToString
            '        header_sa = impdt.Rows(0)("header_sa").ToString
            '        regin_sa = impdt.Rows(0)("regin_sa").ToString
            '    Next
            'End If

            hour_pay = Math.Round(((main_sa + pro_sa + header_sa + regin_sa) / 240), MidpointRounding.AwayFromZero)

            If Not dtFeeMaster Is Nothing AndAlso dtFeeMaster.Rows.Count > 0 Then
                '���s�b,�s�WLab_Overtime_Fee_Master
                daoLabOvertimeFeeMaster.doUpdateSAL1112(overtime_Date, Hours, hour_pay, main_sa, pro_sa, Overtime_Fee, Orgcode, Depart_id, PRIDNO, YearMonth)
            Else
                '�w�s�b,��sLab_Overtime_Fee_Master
                daoLabOvertimeFeeMaster.InsertData(Orgcode, flow_id, Depart_id, PRIDNO, YearMonth, "1", overtime_Date, _
                                                    main_sa, pro_sa, hour_pay, "N", Hours, Overtime_Fee, Budget_type)
            End If

        End Sub

        Public Sub doDetailUpdate(ByVal Orgcode As String, _
                                  ByVal Depart_id As String, _
                                  ByVal YearMonth As String, _
                                  ByVal PRIDNO As String, _
                                  ByVal PRADDD As String, _
                                  ByVal PRSTIME As String, _
                                  ByVal PRETIME As String, _
                                  ByVal PRADDH As Integer, _
                                  ByVal PRUPDATE As String, _
                                  ByVal ApplyHour1 As Double, _
                                  ByVal ApplyHour2 As Double, _
                                  ByVal ApplyHour3 As Double, _
                                  ByVal Overtime_Pay As Double, _
                                  ByVal Reason As String, _
                                  ByVal flow_id As String)

            Dim ApplyHourSum As Double = (ApplyHour1 + ApplyHour2 + ApplyHour3)

            '��sCPAPR18M
            Dim dao As New FSC.Logic.CPAPR18MDAO()
            dao.UpdateSAL1112(PRIDNO, PRADDD, PRUPDATE, PRSTIME, ApplyHour1, ApplyHour2, ApplyHour3, Overtime_Pay)

            Dim detDAO As New LabOvertimeFeeDetailDAO()

            If ApplyHourSum = 0 Then
                '�Y�ӵ���ƮɼƩM��0�A�h�ݧR��
                detDAO.doDelete(Orgcode, Depart_id, PRIDNO, YearMonth, PRADDD, PRSTIME)

            ElseIf ApplyHourSum > 0 Then
                Dim labdt As DataTable = detDAO.doQuerySAL1112(Orgcode, Depart_id, PRIDNO, YearMonth, PRADDD, PRSTIME)

                If labdt IsNot Nothing AndAlso labdt.Rows.Count > 0 Then
                    '�w�s�b,��s
                    detDAO.doUpdate(ApplyHour1, ApplyHour2, ApplyHour3, ApplyHourSum, Overtime_Pay, _
                                    Date.Now, PRIDNO, Orgcode, Depart_id, PRIDNO, YearMonth, PRADDD, PRSTIME)
                Else
                    '���s�b,�s�W
                    detDAO.Insert(Orgcode, Depart_id, PRIDNO, YearMonth, "1", PRADDD, PRSTIME, PRETIME, PRADDH, _
                                    ApplyHour1, ApplyHour2, ApplyHour3, 0, 0, Overtime_Pay, Reason, flow_id)
                End If

            End If

        End Sub

        Public Function CountOvertimePay(ByVal Apply_Hour_1 As Integer, _
                                         ByVal Apply_Hour_2 As Integer, _
                                         ByVal Apply_Hour_3 As Integer, _
                                         ByVal F1 As Double, _
                                         ByVal F2 As Double, _
                                         ByVal total_sa As Integer, _
                                         ByVal PEMEMCOD As String) As Integer

            '        Overtime_Pay = A + B + C
            '        A = Apply_Hour_1 * hour_pay * F1
            '        B = Apply_Hour_2 * hour_pay * F2
            '        
            '        �H�W�|�ˤ��J�ܾ�Ʀ�
            Dim Overtime_Pay As Integer
            Dim hour_pay As Double

            hour_pay = Math.Round((total_sa / 240), MidpointRounding.AwayFromZero)
            'Dim A As Double = Math.Round((Apply_Hour_1 * Math.Round(hour_pay, MidpointRounding.AwayFromZero) * F1), MidpointRounding.AwayFromZero)
            'Dim A As Double = Math.Round((Apply_Hour_1 * hour_pay * F1), MidpointRounding.AwayFromZero)
            Dim A As Double = Apply_Hour_1 * (Math.Round((hour_pay * F1), MidpointRounding.AwayFromZero))
            'Dim B As Double = Math.Round((Apply_Hour_2 * Math.Round(hour_pay, MidpointRounding.AwayFromZero) * F2), MidpointRounding.AwayFromZero)
            Dim B As Double = Apply_Hour_2 * (Math.Round((hour_pay * F2), MidpointRounding.AwayFromZero))
            Dim C As Double = 0

            'chihliwang mod in 20120815
            '�p�ⰲ��[�Z8�p��,10�p�ɤ�12�p�ɪ��[�Z�O
            If Apply_Hour_3 >= 1 And Apply_Hour_3 <= 8 Then
                'C = Math.Round((8 * hour_pay), MidpointRounding.AwayFromZero)
                '�p����~
                C = Math.Round(total_sa / 30, MidpointRounding.AwayFromZero)
            ElseIf Apply_Hour_3 > 8 And Apply_Hour_3 <= 10 Then
                'C = Math.Round(((8 * hour_pay) + ((Apply_Hour_3 - 8) * Math.Round(hour_pay, MidpointRounding.AwayFromZero) * F1)), MidpointRounding.AwayFromZero)
                C = Math.Round(((Math.Round(total_sa / 30, MidpointRounding.AwayFromZero)) + ((Apply_Hour_3 - 8) * Math.Round((hour_pay * F1), MidpointRounding.AwayFromZero))), MidpointRounding.AwayFromZero)
            ElseIf Apply_Hour_3 > 10 And Apply_Hour_3 <= 12 Then
                'C = Math.Round(((8 * hour_pay) + (2 * Math.Round(hour_pay, MidpointRounding.AwayFromZero) * F1) + ((Apply_Hour_3 - 10) * Math.Round(hour_pay, MidpointRounding.AwayFromZero) * F2)), MidpointRounding.AwayFromZero)
                C = Math.Round(((Math.Round(total_sa / 30, MidpointRounding.AwayFromZero)) + (2 * Math.Round((hour_pay * F1), MidpointRounding.AwayFromZero)) + ((Apply_Hour_3 - 10) * Math.Round((hour_pay * F2), MidpointRounding.AwayFromZero))), MidpointRounding.AwayFromZero)
            End If

            Overtime_Pay = A + B + C

            Return Overtime_Pay
        End Function

        Public Sub doConfirm(ByVal OrgCode As String, ByVal Depart_id As String, ByVal YearMonth As String, ByVal PerId() As String, ByVal isUpdate As Boolean, ByVal flow_id As String)

            'If PerId Is Nothing OrElse PerId.Length <= 0 Then
            '    Return
            'End If

            'Dim dao As New SAL1112DAO()
            'Dim daoLabOvertimeFeeMaster As New LabOvertimeFeeMasterDAO()

            'For Each Id_Card As String In PerId

            '    Using trans As New TransactionScope
            '        'Init
            '        Dim PENAME As String = ""
            '        Dim PEKIND As String = ""
            '        Dim PESEX As String = ""
            '        Dim PEMEMCOD As String = ""

            '        Dim dtCPAPE05M As DataTable = New FSC.Logic.Personnel().GetDataByIdCard(Id_Card)
            '        If Not dtCPAPE05M Is Nothing Then
            '            If dtCPAPE05M.Rows.Count > 0 Then
            '                PENAME = dtCPAPE05M.Rows(0)("PENAME").ToString()
            '                PEKIND = dtCPAPE05M.Rows(0)("PEKIND").ToString()
            '                PESEX = dtCPAPE05M.Rows(0)("PESEX").ToString()
            '                PEMEMCOD = dtCPAPE05M.Rows(0)("Employee_type").ToString()
            '            End If
            '        End If

            '        '1.���o�ӤH���~����ơA��Ū���~����
            '        Dim dt As DataTable = New DataTable 'dao.doQueryImpSalary(OrgCode, YearMonth, Id_Card)
            '        Dim hour_pay As Double = 0
            '        Dim main_sa As Integer = 0
            '        Dim pro_sa As Integer = 0
            '        Dim header_sa As Integer = 0
            '        Dim regin_sa As Integer = 0

            '        If Not dt Is Nothing And dt.Rows.Count > 0 Then
            '            'hour_pay = row("hour_pay")
            '            'main_sa = dt.Rows(0)("main_sa")
            '            'pro_sa = dt.Rows(0)("pro_sa")
            '            'header_sa = dt.Rows(0)("header_sa")
            '            'regin_sa = dt.Rows(0)("regin_sa")
            '        End If

            '        '�C�p�ɥ[�Z�O
            '        hour_pay = (main_sa + pro_sa + header_sa + regin_sa) / 240

            '        'PCCODE:         �C��W��(����[�Z)
            '        'PCCODE_H:       �C��W��(�t����)
            '        Dim PCCODE As Double
            '        Dim PCCODE_H As Double

            '        Dim F1 As Double
            '        Dim F2 As Double
            '        Dim F3 As Double

            '        '2.���o����ѼơA�ܾ�����װѼƸ����
            '        Dim dtCPAPC03M As DataTable = New FSC.Logic.CPAPC03M().DAO.GetDataByKind(PEKIND)
            '        If Not dtCPAPC03M Is Nothing Then
            '            For Each rowCPAPC03M As DataRow In dtCPAPC03M.Rows
            '                'PCCODE = 15 : �[�Z�e�G�p�ɭ���()
            '                'PCCODE = 16 : �[�Z��G�p�ɫ᭿��()
            '                'PCCODE = 17 : �[�Z�C��л�W���ɼ�()
            '                'PCCODE = 18 : ����[�Z�C��л�W���ɼ�(�k)
            '                'PCCODE = 19 : ����[�Z�C��л�W���ɼ�(�k)
            '                'PCCODE = 20 : �t����[�Z�C��л�W���ɼ�(�k)
            '                'PCCODE = 21 : �t����[�Z�C��л�W���ɼ�(�k)
            '                Select Case rowCPAPC03M("PCCODE").ToString()
            '                    Case "15"
            '                        F1 = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                    Case "16"
            '                        F2 = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                    Case "17"
            '                        F3 = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                    Case "18"
            '                        If PESEX = "1" Then
            '                            PCCODE = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                        End If
            '                    Case "19"
            '                        If PESEX = "2" Then
            '                            PCCODE = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                        End If
            '                    Case "20"
            '                        If PESEX = "1" Then
            '                            PCCODE_H = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                        End If
            '                    Case "21"
            '                        If PESEX = "2" Then
            '                            PCCODE_H = CommonFun.ConvertToDouble(rowCPAPC03M("PCPARM1").ToString())
            '                        End If

            '                End Select
            '            Next
            '        End If


            '        '3.���N�ҿ�����H���л�����M��(�ޤu�u�ͥ[�Z�O�л�J�`��,�ޤu�u�ͥ[�Z�O�л������,�[�Z�ӽг�����(P2K))
            '        '�ޤu�u�ͥ[�Z�O�л�J�`��
            '        'daoLabOvertimeFeeMaster.deleteFSC3206(PerId, OrgCode, YearMonth)

            '        '�ޤu�u�ͥ[�Z�O�л������
            '        Dim ofdDAO As New LabOvertimeFeeDetailDAO()
            '        ofdDAO.doDeleteFSC3206(PerId, OrgCode, YearMonth)

            '        '�[�Z�ӽг�����(P2K), �NPRPAYFEE,PRMNYH��s��0
            '        Dim pr18mDAO As New FSC.Logic.CPAPR18MDAO()
            '        pr18mDAO.UpdateSAL1112(PerId, OrgCode, YearMonth)

            '        '==========================================����[�Z Start ========================================================

            '        Dim X As Integer
            '        Dim Hours As Integer '�i��ɼ�
            '        Dim Apply_Hour_1 As Integer = 0
            '        Dim Apply_Hour_2 As Integer = 0
            '        Dim Apply_Hour_3 As Integer = 0
            '        Dim Apply_Hour_4 As Integer = 0
            '        Dim Apply_Hour_5 As Integer = 0
            '        Dim Overtime_Pay As Integer = 0

            '        '�t�~���X����[�Z���
            '        Dim dt_H As DataTable = pr18mDAO.doQueryFSC3206(Id_Card, YearMonth)

            '        ''���P�_�O�_�t������[�Z���, �S���Ȧ槽��, �W���אּ�t����[�Z�л�W��
            '        'If OrgCode = "367010000D" And dt_H.Rows.Count > 0 Then
            '        '    PCCODE = PCCODE_H
            '        'End If

            '        '���X�@���[�Z�W�L2�p�ɸ��
            '        Dim dt_02 As DataTable = pr18mDAO.doQueryFSC3206_02(Id_Card, YearMonth)

            '        If Not dt_02 Is Nothing Then

            '            For Each row As DataRow In dt_02.Rows
            '                Apply_Hour_1 = 0
            '                Apply_Hour_2 = 0
            '                Apply_Hour_3 = 0
            '                Apply_Hour_4 = 0
            '                Apply_Hour_5 = 0
            '                Overtime_Pay = 0

            '                Hours = row("PRADDH") - row("PRPAYH")     '�[�Z�ɼ� - �w��ɼ�

            '                '���륭��[�Z�ɼƲ֭p�٦b�B�פ�
            '                If (X + Hours) <= PCCODE Then
            '                    If Hours < 3 Then
            '                        Apply_Hour_1 = Hours
            '                    Else
            '                        Apply_Hour_1 = 2
            '                        Apply_Hour_2 = Hours - 2
            '                    End If
            '                    X = X + Hours
            '                    Overtime_Pay = CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, hour_pay, PEMEMCOD)

            '                    '�s�WLab_Overtime_Fee_Detail
            '                    ofdDAO.Insert(OrgCode, Depart_id, Id_Card, YearMonth, "1", row("PRADDD"), row("PRSTIME"), row("PRETIME"), row("PRADDH"), _
            '                                  Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, 0, 0, Overtime_Pay, row("PRREASON"), flow_id)

            '                    '��sCPAPR18M
            '                    pr18mDAO.UpdateSAL1112(Id_Card, row("PRADDD"), System.DateTime.Now.ToString("yyyMMddHHmm"), row("PRSTIME"), _
            '                                           Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay)

            '                Else '���륭��[�Z�ɼƲ֭p���B��

            '                    If (PCCODE - X) < 3 Then
            '                        Apply_Hour_1 = PCCODE - X
            '                    Else
            '                        Apply_Hour_1 = 2
            '                        Apply_Hour_2 = PCCODE - 2 - X
            '                    End If
            '                    X = PCCODE
            '                    Overtime_Pay = CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, hour_pay, PEMEMCOD)

            '                    '�s�WLab_Overtime_Fee_Detail
            '                    ofdDAO.Insert(OrgCode, Depart_id, Id_Card, YearMonth, "1", row("PRADDD"), row("PRSTIME"), row("PRETIME"), row("PRADDH"), _
            '                                  Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Apply_Hour_4, Apply_Hour_5, Overtime_Pay, row("PRREASON"), flow_id)

            '                    '��sCPAPR18M
            '                    pr18mDAO.UpdateSAL1112(Id_Card, row("PRADDD"), System.DateTime.Now.ToString("yyyMMddHHmm"), row("PRSTIME"), _
            '                                           Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay)

            '                    Exit For '�����j��(�ɼƤw�쭭�B)
            '                End If

            '            Next
            '        End If

            '        '�Y X < PCCODE ��(���W�L�W����)
            '        If X < PCCODE Then

            '            '���X�@���[�Z���W�L2�p�ɸ��
            '            Dim dt_03 As DataTable = pr18mDAO.doQueryFSC3206_03(Id_Card, YearMonth)

            '            If Not dt_03 Is Nothing Then
            '                For Each row As DataRow In dt_03.Rows
            '                    Apply_Hour_1 = 0
            '                    Apply_Hour_2 = 0
            '                    Apply_Hour_3 = 0
            '                    Apply_Hour_4 = 0
            '                    Apply_Hour_5 = 0
            '                    Overtime_Pay = 0
            '                    Hours = row("PRADDH") - row("PRPAYH")

            '                    If (X + Hours) <= PCCODE Then
            '                        '�٦b�C�륭��[�Z���B��
            '                        Apply_Hour_1 = Hours
            '                        X = X + Hours
            '                        Overtime_Pay = CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, hour_pay, PEMEMCOD)

            '                        '�s�WLab_Overtime_Fee_Detail
            '                        ofdDAO.Insert(OrgCode, Depart_id, Id_Card, YearMonth, "1", row("PRADDD"), row("PRSTIME"), row("PRETIME"), row("PRADDH"), _
            '                                      Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, 0, 0, Overtime_Pay, row("PRREASON"), flow_id)
            '                        '��sCPAPR18M
            '                        pr18mDAO.UpdateSAL1112(Id_Card, row("PRADDD"), System.DateTime.Now.ToString("yyyMMddHHmm"), row("PRSTIME"), _
            '                                               Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay)

            '                    Else    '�W�L�C�륭��[�Z���B

            '                        Apply_Hour_1 = PCCODE - X
            '                        X = PCCODE
            '                        Overtime_Pay = CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, hour_pay, PEMEMCOD)

            '                        '�s�WLab_Overtime_Fee_Detail
            '                        ofdDAO.Insert(OrgCode, Depart_id, Id_Card, YearMonth, "1", row("PRADDD"), row("PRSTIME"), row("PRETIME"), row("PRADDH"), _
            '                                      Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, 0, 0, Overtime_Pay, row("PRREASON"), flow_id)

            '                        '��sCPAPR18M
            '                        pr18mDAO.UpdateSAL1112(Id_Card, row("PRADDD"), System.DateTime.Now.ToString("yyyMMddHHmm"), row("PRSTIME"), _
            '                                               Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay)
            '                        Exit For '�����j��(�ɼƨ쭭�B)
            '                    End If

            '                Next
            '            End If
            '        End If

            '        '=========================================����[�Z End =========================================================

            '        '=========================================����[�Z Start =========================================================
            '        '�t�~���X����[�Z���
            '        'Dim dtCPAPR18M As DataTable = daoCPAPR18M.doQueryFSC3206(Id_Card, YearMonth)

            '        '�Y X < PCCODE ��(���W�L�W����)
            '        If X < PCCODE Then

            '            Dim tmpHours As Integer = 0  '�i��ɼ�

            '            If Not dt_H Is Nothing Then

            '                For Each row As DataRow In dt_H.Rows
            '                    Apply_Hour_1 = 0
            '                    Apply_Hour_2 = 0
            '                    Apply_Hour_3 = 0
            '                    Apply_Hour_4 = 0
            '                    Apply_Hour_5 = 0
            '                    Overtime_Pay = 0
            '                    tmpHours = row("PRADDH") - row("PRPAYH")

            '                    If tmpHours >= 1 Then
            '                        tmpHours = 8
            '                    End If

            '                    'If OrgCode = "367000000D" Or OrgCode = "367020000D" Then
            '                    '    '���|���Ҵ���

            '                    '    If tmpHours < 4 And tmpHours <> 0 Then
            '                    '        tmpHours = 4
            '                    '    ElseIf tmpHours > 4 Then
            '                    '        tmpHours = 8
            '                    '    End If

            '                    'ElseIf OrgCode = "367010000D" Then
            '                    '    '�Ȧ槽

            '                    '    If tmpHours > 8 Then
            '                    '        If tmpHours - 8 > 2 Then
            '                    '            Apply_Hour_1 = 2
            '                    '            Apply_Hour_2 = tmpHours - 8 - 2
            '                    '        Else
            '                    '            Apply_Hour_1 = tmpHours - 8
            '                    '        End If
            '                    '        Apply_Hour_3 = 8

            '                    '        tmpHours = Apply_Hour_3
            '                    '    End If
            '                    'Else
            '                    '    '�䥦�G��
            '                    'End If

            '                    If PCCODE_H = 0 Then
            '                        PCCODE_H = PCCODE
            '                    End If

            '                    If (X + tmpHours) <= PCCODE_H Then
            '                        Apply_Hour_3 = tmpHours
            '                        X = X + tmpHours

            '                        Overtime_Pay = CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, hour_pay, PEMEMCOD)

            '                        '�s�WLab_Overtime_Fee_Detail
            '                        ofdDAO.Insert(OrgCode, _
            '                                      Depart_id, _
            '                                      Id_Card, _
            '                                      YearMonth, _
            '                                      "1", _
            '                                      row("PRADDD").ToString(), _
            '                                      row("PRSTIME").ToString(), _
            '                                      row("PRETIME").ToString(), _
            '                                      row("PRADDH").ToString(), _
            '                                      Apply_Hour_1, _
            '                                      Apply_Hour_2, _
            '                                      Apply_Hour_3, _
            '                                      0, _
            '                                      0, _
            '                                      Overtime_Pay, _
            '                                      row("PRREASON").ToString(), flow_id)

            '                        '��sCPAPR18M
            '                        pr18mDAO.UpdateSAL1112(Id_Card, row("PRADDD"), System.DateTime.Now.ToString("yyyMMddHHmm"), row("PRSTIME"), _
            '                                               Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay)
            '                    Else
            '                        '�w�W�L�q���t����[�Z�C��W���ɼ�
            '                        Apply_Hour_3 = PCCODE_H - X
            '                        Apply_Hour_1 = 0
            '                        Apply_Hour_2 = 0

            '                        'If OrgCode = "367000000D" Or OrgCode = "367020000D" Then
            '                        '    '���|���Ҵ���
            '                        '    If tmpHours < 4 And tmpHours <> 0 Then
            '                        '        Apply_Hour_3 = 4
            '                        '    ElseIf tmpHours > 4 Then
            '                        '        Apply_Hour_3 = 8
            '                        '    End If
            '                        'ElseIf OrgCode = "367010000D" Then
            '                        '    '�Ȧ槽
            '                        '    If Apply_Hour_3 > 8 Then
            '                        '        If Apply_Hour_3 - 8 > 2 Then
            '                        '            Apply_Hour_1 = 2
            '                        '            Apply_Hour_2 = Apply_Hour_3 - 8 - 2
            '                        '        Else
            '                        '            Apply_Hour_1 = Apply_Hour_3 - 8
            '                        '        End If
            '                        '        Apply_Hour_3 = 8
            '                        '    End If
            '                        'Else
            '                        '    '�䥦�G��
            '                        'End If

            '                        Overtime_Pay = CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, F1, F2, hour_pay, PEMEMCOD)

            '                        '�s�WLab_Overtime_Fee_Detail
            '                        ofdDAO.Insert(OrgCode, Depart_id, Id_Card, YearMonth, "1", row("PRADDD"), row("PRSTIME"), row("PRETIME"), row("PRADDH"), _
            '                                      Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, 0, 0, Overtime_Pay, row("PRREASON"), flow_id)

            '                        '��sCPAPR18M
            '                        pr18mDAO.UpdateSAL1112(Id_Card, row("PRADDD"), System.DateTime.Now.ToString("yyyMMddHHmm"), row("PRSTIME"), _
            '                                               Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, Overtime_Pay)
            '                        Exit For '�����j��(�ɼƨ쭭�B)
            '                    End If

            '                Next
            '            End If
            '        End If

            '        '���X�ӤH���Ӥ���л��Ƥ�����A�զ��@�r��A�Ҧp1,14,15,16,20
            '        Dim days As New StringBuilder()
            '        Dim dtFeeDetailTmp As DataTable = ofdDAO.doQuerySAL1112(OrgCode, Depart_id, Id_Card, YearMonth)
            '        If Not dtFeeDetailTmp Is Nothing Then
            '            For Each row As DataRow In dtFeeDetailTmp.Rows
            '                If days.ToString() <> "" Then
            '                    days.Append(",")
            '                End If
            '                days.Append(row("day"))
            '            Next
            '        End If

            '        Dim overtime_Date As String = days.ToString()
            '        Dim tmpHours2 As Integer
            '        Dim Overtime_Fee As Double
            '        '���X�ӤH���Ӥ���л��Ƥ��ɼ�r�Ϊ��B�[�`
            '        dtFeeDetailTmp = ofdDAO.doQuerySAL1112_2(OrgCode, Depart_id, Id_Card, YearMonth)
            '        If Not dtFeeDetailTmp Is Nothing Then
            '            For Each row As DataRow In dtFeeDetailTmp.Rows
            '                If DBNull.Value.Equals(row("Hours")) Then
            '                    tmpHours2 = 0
            '                Else
            '                    tmpHours2 = row("Hours")
            '                End If

            '                If DBNull.Value.Equals(row("Overtime_Fee")) Then
            '                    Overtime_Fee = 0
            '                Else
            '                    Overtime_Fee = row("Overtime_Fee")
            '                End If
            '            Next
            '        End If

            '        flow_id = IIf(isUpdate, flow_id, New SYS.Logic.FlowId().GetFlowId(OrgCode, "002001"))
            '        Dim Budget_type As String = GetLastBudget(Id_Card)

            '        '�s�W��D��
            '        Dim dtFeeMaster As DataTable = daoLabOvertimeFeeMaster.GetDataByQuery(OrgCode, Depart_id, Id_Card, YearMonth)
            '        If Not dtFeeMaster Is Nothing AndAlso dtFeeMaster.Rows.Count > 0 Then
            '            daoLabOvertimeFeeMaster.doUpdateSAL1112(overtime_Date, tmpHours2, hour_pay, main_sa, pro_sa, Overtime_Fee, OrgCode, Depart_id, Id_Card, YearMonth)
            '        Else
            '            daoLabOvertimeFeeMaster.InsertData(OrgCode, Depart_id, Id_Card, YearMonth, "1", overtime_Date, _
            '                                                main_sa, pro_sa, hour_pay, "N", tmpHours2, Overtime_Fee, flow_id, Budget_type)
            '        End If

            '        Dim f As SYS.Logic.Flow = New SYS.Logic.Flow
            '        f.FlowId = flow_id
            '        f.Orgcode = OrgCode
            '        f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            '        f.ApplyIdcard = Id_Card
            '        f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            '        f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            '        f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
            '        f.WriterOrgcode = OrgCode
            '        f.WriterDepartid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
            '        f.WriterIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            '        f.WriterName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            '        f.WriterPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
            '        f.WriteTime = Date.Now
            '        f.FormId = "002001"
            '        f.Reason = ""
            '        f.Budget_code = Budget_type
            '        f.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            '        If isUpdate Then
            '            f.CaseStatus = "2"
            '            f.Update()
            '        Else
            '            SYS.Logic.CommonFlow.AddFlow(f)
            '        End If

            '        trans.Complete()
            '    End Using

            'Next
        End Sub

        Public Sub doExportRpt(ByVal OrgCode As String, ByVal Unit As String, ByVal Year As String, ByVal Month As String, ByVal PerId As String)

            '��PerId ��ӤH���� metadb_id 
            'Dim Metadb_id As String = New Member().GetColumnValue("Metadb_id", PerId)
            'Dim p2kconnstr As String = ConnectDB.GetCPADBString(Metadb_id)


            'Dim PENAME As String = ""
            'Dim PEKIND As String = ""
            'Dim PESEX As String = ""
            'Dim PEMEMCOD As String = ""

            'Dim dtCPAPE05M As DataTable = doQuery01(OrgCode, Year & Month, PerId)
            'If Not dtCPAPE05M Is Nothing Then
            '    If dtCPAPE05M.Rows.Count > 0 Then
            '        PENAME = dtCPAPE05M.Rows(0)("PENAME").ToString()
            '        PEKIND = dtCPAPE05M.Rows(0)("PEKIND").ToString()
            '        PESEX = dtCPAPE05M.Rows(0)("PESEX").ToString()
            '        PEMEMCOD = dtCPAPE05M.Rows(0)("PEMEMCOD").ToString()
            '    End If
            'End If

            'Dim daoFSC3206 As New FSC3206DAO()

            'Dim dtSalary As DataTable = daoFSC3206.doQueryImpSalary(OrgCode, Year & Month, PerId)
            'Dim hour_pay As Double = 0
            'Dim main_sa As Integer = 0
            'Dim pro_sa As Integer = 0
            'Dim header_sa As Integer = 0
            'Dim regin_sa As Integer = 0

            'If Not dtSalary Is Nothing And dtSalary.Rows.Count > 0 Then
            '    main_sa = dtSalary.Rows(0)("main_sa")
            '    pro_sa = dtSalary.Rows(0)("pro_sa")
            '    header_sa = dtSalary.Rows(0)("header_sa")
            '    regin_sa = dtSalary.Rows(0)("regin_sa")
            'End If
            'hour_pay = (main_sa + pro_sa + header_sa + regin_sa) / 240

            ''==================0980815===�H����PAG�ӷ�??=================================
            'Dim RNK As String = String.Empty  '�x¾��
            'Dim PAG As String = String.Empty  '�į�
            'Dim C1 As New Code1()
            'Dim bt02mdt As DataTable = New CPABT02M().GetBT02MByB02IDNO(PerId)
            'If bt02mdt.Rows.Count > 0 Then
            '    RNK = C1.GetDataDESCR("RNK", bt02mdt.Rows(0)("B02CRKCOD").ToString())
            '    PAG = C1.GetDataDESCR("PAG", bt02mdt.Rows(0)("B02OGRCOD").ToString())
            'End If

            'Dim user_name As String = String.Empty
            'Dim title_name As String = String.Empty
            'Dim mdt As DataTable = New Member().GetDataByIdcard(PerId)
            'If mdt.Rows.Count > 0 Then
            '    user_name = mdt.Rows(0)("User_name").ToString()
            '    title_name = mdt.Rows(0)("title_name").ToString()
            'End If

            'Dim theDTReport As CommonLib.DTReport
            ''==================0980815===================================
            'Dim strParam(13) As String
            'strParam(0) = New FSCorg().GetOrgcodeName(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode))
            'strParam(1) = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)
            'strParam(2) = DateTimeInfo.GetRocTodayString("yyyy/MM/dd")
            'strParam(3) = user_name
            'strParam(4) = title_name
            'strParam(5) = RNK
            'strParam(6) = PAG
            'strParam(7) = Month
            'strParam(8) = main_sa
            'strParam(9) = pro_sa
            'strParam(10) = header_sa

            'Dim dt As DataTable = doQueryFSC1307(OrgCode, Unit, Year & Month, PerId)

            'If Not dt Is Nothing AndAlso Not dt.Rows Is Nothing Then

            '    dt.Columns.Add(New DataColumn("HourFee", GetType(String)))
            '    dt.Columns.Add(New DataColumn("HourPrice", GetType(Double)))
            '    dt.Columns.Add(New DataColumn("Apply_Hour", GetType(Double)))

            '    Dim bll As New FSC3206Bll()

            '    '===============0980815=====================================================
            '    Dim tempData As DataTable = dt.Clone
            '    Dim PRADDH As Double = 0
            '    Dim TotalApply_Hour As Double = 0
            '    Dim TotalPrice As Integer = 0

            '    Dim i As Integer = 0
            '    For Each row As DataRow In dt.Rows
            '        Dim HourFee As Double = 0
            '        Dim HourPrice As Double = 0
            '        Dim Apply_Hour As Double = 0
            '        Dim Apply_Hour_1 As Double = row("Apply_Hour_1")
            '        Dim Apply_Hour_2 As Double = row("Apply_Hour_2")
            '        Dim Apply_Hour_3 As Double = row("Apply_Hour_3")

            '        'Dim PEKIND As String = GetDataByColumn(OrgCode, Year & Month, PerId, "PEKIND")
            '        Dim A As Double = New CPAPC03M(p2kconnstr).GetCPAPC03M(PEKIND, "15")
            '        Dim B As Double = New CPAPC03M(p2kconnstr).GetCPAPC03M(PEKIND, "16")
            '        Dim C As Double = 1

            '        Apply_Hour = Apply_Hour_1 + Apply_Hour_2 + Apply_Hour_3

            '        Dim dti As New DateTimeInfo
            '        row("PRADDD") = dti.ConvertToDisplay(row("PRADDD"))
            '        row("PRSTIME") = dti.ConvertToDisplayTime(row("PRSTIME")) & " �� "
            '        row("PRETIME") = dti.ConvertToDisplayTime(row("PRETIME"))

            '        row("Apply_Hour") = Apply_Hour
            '        row("HourFee") = bll.CountOvertimePayString(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, A, B, hour_pay, PEMEMCOD)

            '        If Apply_Hour = 0 Then
            '            row("HourPrice") = "0"
            '        Else
            '            row("HourPrice") = Convert.ToString(bll.CountOvertimePay(Apply_Hour_1, Apply_Hour_2, Apply_Hour_3, A, B, hour_pay, PEMEMCOD))
            '        End If

            '        '==========================0980815=============================================
            '        If Not DBNull.Value.Equals(row("PRADDH")) Then
            '            PRADDH = row("PRADDH")
            '        End If
            '        If 0 < Apply_Hour Then
            '            Dim tempRow As DataRow = tempData.NewRow()
            '            tempRow.ItemArray = row.ItemArray
            '            tempData.Rows.Add(tempRow)
            '            i += 1
            '        End If
            '        TotalApply_Hour += Apply_Hour
            '        TotalPrice += CommonFun.ConvertToInt(row("HourPrice"))
            '    Next

            '    '�]�w�@�������
            '    Dim lineNum As Integer = 16

            '    If i > lineNum Then
            '        For j As Integer = 0 To lineNum - (i Mod lineNum)
            '            tempData.Rows.Add(tempData.NewRow)
            '        Next
            '    ElseIf lineNum - i <> 0 Then
            '        For j As Integer = 0 To lineNum - i - 1
            '            tempData.Rows.Add(tempData.NewRow)
            '        Next
            '    End If

            '    'Excel �ϥ�Functiop HTML�榡�n x:fmla=3D"=3DSUM(A1:A7)"
            '    ' <td class=3Dxl35 style=3D'border-top:none;border-left:none' x:num x:fmla=3D"=3D##P30##"></td>
            '    '==========================0980815=============================================
            '    strParam(11) = TotalApply_Hour
            '    strParam(12) = TotalPrice
            '    '==================0980815===================================
            '    strParam(13) = TotalApply_Hour

            '    theDTReport = New CommonLib.DTReport(HttpContext.Current.Server.MapPath("../../Report/FSC1/FSC1307_RPT1.mht"), tempData)
            '    theDTReport.Param = strParam
            '    theDTReport.ExportFileName = "�[�Z�O����"
            '    theDTReport.ExportToExcel()

            'End If
        End Sub

        Sub doUpdateOvertimeFeeMaster(ByVal OrgCode As String, ByVal Depart_id As String, ByVal PEIDNO As String, ByVal YearMonth As String)

            '��sLab_Overtime_Fee_Master
            'Dim daoLabOvertimeFeeMaster As New LabOvertimeFeeMasterDAO()
            'daoLabOvertimeFeeMaster.doUpdateFSC1307("Y", OrgCode, Depart_id, PEIDNO, YearMonth)
        End Sub

        Public Function GetLastBudget(ByVal id_card As String) As String
            Return DAO.GetLastBudget(id_card)
        End Function
    End Class
End Namespace
