Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Collections.Generic

' 2014/7/19
' 增加欄位 For 廣播申請排序

Namespace FSC.Logic
    Public Class FSC0101DAO
        Inherits BaseDAO

        Dim sbSQL As New StringBuilder()
        Dim szSQL As String

        Public Function GetNextCount(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT COUNT(1) FROM SYS_Flow_next a WITH(NOLOCK) ")
            sbSQL.AppendLine("    INNER JOIN SYS_Flow b WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" ((a.Next_orgcode=@orgcode AND a.Next_departid=@departId AND a.Next_idcard=@idCard)  ")
            sbSQL.AppendLine(" or (a.Replace_orgcode=@orgcode AND a.Replace_departid=@departId AND a.Replace_idcard=@idCard)) ")
            sbSQL.AppendLine(" AND b.Last_pass=0 ")
            sbSQL.AppendLine(" AND b.case_status in (0,1) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard)}

            Return Scalar(sbSQL.ToString(), params)
        End Function

        Public Function GetDeputyData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT b.* FROM SYS_Flow b ")
            sbSQL.AppendLine(" inner join FSC_Leave_main a WITH(NOLOCK) on a.flow_id=b.flow_id and a.orgcode=b.orgcode ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" b.Deputy_orgcode=@orgcode AND b.Deputy_departid=@departId AND b.Deputy_idcard=@idCard ")
            'sbSQL.AppendLine(" AND b.Last_pass=1 ")
            sbSQL.AppendLine(" AND b.case_status=1 ")
            sbSQL.AppendLine(" AND a.start_date<=@nowdate ")
            sbSQL.AppendLine(" AND a.end_date>=@nowdate ")
            sbSQL.AppendLine(" AND a.start_time<=@nowtime ")

            Dim nowdate As String = DateTimeInfo.GetRocDateTime(Now)
            Dim d As String = nowdate.Substring(0, 7)
            Dim t As String = nowdate.Substring(7, 4)

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard), _
            New SqlParameter("@nowdate", d), _
            New SqlParameter("@nowtime", t)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetNextCount(ByVal AD_id As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT COUNT(1) FROM SYS_Flow_next a WITH(NOLOCK) ")
            sbSQL.AppendLine("    INNER JOIN SYS_Flow b WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" (a.Next_idcard in (select id_card from FSC_Personnel where AD_id=@AD_id) ")
            sbSQL.AppendLine(" or a.Replace_idcard in (select id_card from FSC_Personnel where AD_id=@AD_id) ) ")
            sbSQL.AppendLine(" AND b.Last_pass=0 ")
            sbSQL.AppendLine(" AND b.case_status in (0,1) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@AD_id", AD_id)}

            Return Scalar(sbSQL.ToString(), params)
        End Function

        Public Function GetNextData(ByVal formId As String, ByVal flowId As String, ByVal dispatchDate As String, ByVal nextOrgcode As String, ByVal nextDepartId As String, ByVal nextIdcard As String, _
                                    Optional ByVal Leave_type As String = "", Optional ByVal InterTravelFlag As String = "") As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT distinct ")
            sbSQL.AppendLine("    a.id as next_id, ")
            sbSQL.AppendLine("    b.id, ")
            sbSQL.AppendLine("    b.Flow_id, ")
            sbSQL.AppendLine("    b.Orgcode, ")
            sbSQL.AppendLine("    b.depart_id, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.orgcode AND depart_id=b.depart_id) Depart_name, ")
            sbSQL.AppendLine("    b.Apply_idcard, ")
            sbSQL.AppendLine("    b.Apply_name, ")
            sbSQL.AppendLine("    dbo.udfTaiwanDateFormat(b.write_time,'yyymmdd') write_time , ")
            sbSQL.AppendLine("    b.Reason, ")
            sbSQL.AppendLine("    b.form_id, ")
            sbSQL.AppendLine("    b.merge_flag, ")
            sbSQL.AppendLine("    b.budget_code, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='006' AND code_type='018' AND code_no=b.budget_code) as budget_code_name, ")
            sbSQL.AppendLine("    a.group_id, ")
            sbSQL.AppendLine("    a.group_step, ")
            sbSQL.AppendLine("    a.next_step ")

            ' 2014/7/19 Eliot Chen
            ' 增加欄位 For 廣播申請排序
            sbSQL.AppendLine(" ,(select broadcast_date1 from  OTH_Broadcast_main where OTH_Broadcast_main.OrgCode=b.Orgcode and OTH_Broadcast_main.Flow_id=b.Flow_id) broadcast_date1  ")
            sbSQL.AppendLine(" ,(select broadcast_time1 from  OTH_Broadcast_main where OTH_Broadcast_main.OrgCode=b.Orgcode and OTH_Broadcast_main.Flow_id=b.Flow_id) broadcast_time1  ")



            sbSQL.AppendLine(" FROM SYS_Flow_next a WITH(NOLOCK) ")
            sbSQL.AppendLine("    INNER JOIN SYS_Flow b WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")

            If Not String.IsNullOrEmpty(dispatchDate) Then
                sbSQL.AppendLine("    INNER JOIN CAR_CarDispatch_det c WITH(NOLOCK) on b.flow_id=c.flow_id ")
            End If

            If Not String.IsNullOrEmpty(Leave_type) Then
                sbSQL.AppendLine(" INNER JOIN FSC_Leave_main lm WITH(NOLOCK) on b.flow_id=lm.flow_id ")
            End If

            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" ((a.Next_orgcode=@nextOrgcode AND a.Next_departid=@nextDepartId AND a.Next_idcard=@nextIdcard)  ")
            sbSQL.AppendLine(" or (a.Replace_orgcode=@nextOrgcode AND a.Replace_departid=@nextDepartId AND a.Replace_idcard=@nextIdcard)) ")
            sbSQL.AppendLine(" AND b.Last_pass=0 ")
            sbSQL.AppendLine(" AND b.case_status in (0,1) ")

            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 3 Then
                    formId = formId & "%"
                    sbSQL.AppendLine(" AND b.form_id like @formId ")
                Else
                    sbSQL.AppendLine(" AND b.form_id=@formId ")
                End If
            End If
            If Not String.IsNullOrEmpty(flowId) Then
                sbSQL.AppendLine(" AND b.flow_id=@flowId ")
            End If
            If Not String.IsNullOrEmpty(dispatchDate) Then
                sbSQL.AppendLine(" AND c.dispatch_date=@dispatchDate ")
            End If
            If Not String.IsNullOrEmpty(Leave_type) Then
                sbSQL.AppendLine(" AND lm.Leave_type = @Leave_type ")
                If Not String.IsNullOrEmpty(InterTravelFlag) Then
                    sbSQL.AppendLine(" AND lm.Inter_Travel_Flag = @InterTravelFlag ")
                End If
            End If

            ' 2014/7/19 Eliot Chen
            ' 廣播申請排序
            If formId = "003010" Then
                sbSQL.AppendLine(" order by broadcast_date1,broadcast_time1 ")
            Else
                sbSQL.AppendLine(" order by b.Form_id,Depart_name,b.Flow_id") 'ted add 20140724
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@nextOrgcode", nextOrgcode), _
            New SqlParameter("@nextDepartId", nextDepartId), _
            New SqlParameter("@nextIdcard", nextIdcard), _
            New SqlParameter("@formId", formId), _
            New SqlParameter("@flowId", flowId), _
            New SqlParameter("@dispatchDate", dispatchDate), _
            New SqlParameter("@Leave_type", Leave_type), _
            New SqlParameter("@InterTravelFlag", InterTravelFlag)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetExistsCars(endDate As String, unitCode As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT car_id FROM car_car_main ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" (scrap_date > @endDate  or Scrap_date = '' or Scrap_date is null) ")
            sbSQL.AppendLine(" AND Status_type='001' ")
            sbSQL.AppendLine(" AND (UsedUnit_code like @unitCode or UsedUnit_code = '*')  ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@endDate", endDate), _
            New SqlParameter("@unitCode", "%" & unitCode & "%")}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetDrivers() As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT id_card, user_name FROM FSC_personnel ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" employee_type='8' ")

            Return Query(sbSQL.ToString())
        End Function

        Public Function UpdateCarModData(orgcode As String, flowId As String, isReturn As String, carId As String, driverUserId As String, Car_shortage As Boolean) As Integer
            Dim d As New Dictionary(Of String, Object)
            Dim v As New Dictionary(Of String, Object)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            v.Add("Is_return", isReturn)
            v.Add("Car_id", carId)
            v.Add("DriverUser_id", driverUserId)
            v.Add("Car_shortage", Car_shortage)

            Return UpdateByExample("CAR_CarDispatch_det", v, d)
        End Function

        Public Function GetEDUFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.Append("SELECT ")
            sbSQL.AppendLine("    (SELECT user_name FROM fsc_personnel WHERE id_card=b.user_id) as user_name, ")
            sbSQL.AppendLine("    b.flow_id, ")
            sbSQL.AppendLine("    a.Child_id, ")
            sbSQL.AppendLine("    a.Child_name, ")
            sbSQL.AppendLine("    b.Apply_yy + b.Period_type as Apply_Period, ")
            sbSQL.AppendLine("    a.ChildBirth_date, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='006' AND code_type='011' AND code_no=a.School_type) as School_type_name, ")
            sbSQL.AppendLine("    a.School_name, ")
            sbSQL.AppendLine("    a.StudyLimit_nos, ")
            sbSQL.AppendLine("    a.Study_nos, ")
            sbSQL.AppendLine("    a.Apply_amt ")
            sbSQL.AppendLine("FROM   SAL_EDU_FEEDtl a ")
            sbSQL.AppendLine("       LEFT JOIN SAL_EDU_FEE b ")
            sbSQL.AppendLine("              ON a.main_id = b.id ")
            sbSQL.AppendLine("WHERE  b.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")

            sbSQL.AppendLine("       AND b.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetEXAMINEFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.Append("SELECT ")
            sbSQL.AppendLine("    (SELECT User_name FROM FSC_Personnel WHERE Id_card=a.BASE_IDNO) as User_name, ")
            sbSQL.AppendLine("    a.BASE_NAME, ")
            sbSQL.AppendLine("    a.BASE_IDNO, ")
            sbSQL.AppendLine("    a.BASE_SERVICE_PLACE_DESC, ")
            sbSQL.AppendLine("    a.BASE_DCODE_NAME, ")
            sbSQL.AppendLine("    a.Meeting_date, ")
            sbSQL.AppendLine("    a.Apply_amt, ")
            sbSQL.AppendLine("    a.BASE_ADDR, ")
            sbSQL.AppendLine("    a.Pay_type, ")
            sbSQL.AppendLine("    a.BASE_BANK_NO, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='006' AND code_type='018' AND code_no=a.Budget_code) as Budget_code, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='005' AND code_type='001' AND code_no=a.Item_code) as Item_code ")
            sbSQL.AppendLine("FROM   SAL_EXAMINE_fee a ")
            sbSQL.AppendLine("WHERE  a.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")
            sbSQL.AppendLine("       AND a.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetAllowanceFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.Append("SELECT ")
            sbSQL.AppendLine("    a.Apply_type, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='006' AND code_type='015' AND code_no=a.Apply_type) as Apply_type_name, ")
            sbSQL.AppendLine("    a.Apply_amt, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='006' AND code_type='016' AND code_no=a.Relation_type) as Relation_type_name ")
            sbSQL.AppendLine("FROM   SAL_ALLOWANCE_fee a ")
            sbSQL.AppendLine("WHERE  a.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")
            sbSQL.AppendLine("       AND a.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetDUTYFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine("SELECT   ")
            sbSQL.AppendLine("    (SELECT Depart_name FROM FSC_ORG WHERE Depart_id=a.Duty_userUnit) as Duty_userUnit, ")
            sbSQL.AppendLine("    (SELECT User_name FROM FSC_Personnel WHERE Id_card=a.Duty_userId) as Duty_userId, ")
            sbSQL.AppendLine("       a.Duty_date, ")
            sbSQL.AppendLine("       a.Duty_sTime, ")
            sbSQL.AppendLine("       a.Duty_eTime, ")
            sbSQL.AppendLine("       a.Is_rest, ")
            sbSQL.AppendLine("       a.ApplyHour_cnt,")
            sbSQL.AppendLine("       a.Apply_amt, ")
            sbSQL.AppendLine("       a.MEMO ")
            sbSQL.AppendLine("FROM   SAL_DUTY_feeDtl a ")
            sbSQL.AppendLine("       LEFT JOIN SAL_DUTY_fee b ")
            sbSQL.AppendLine("              ON a.main_id = b.id ")

            sbSQL.AppendLine("WHERE  b.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")
            sbSQL.AppendLine("       AND b.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function


        Public Function GetVOLFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine("SELECT   ")
            sbSQL.AppendLine("    (SELECT BASE_NAME FROM SAL_SABASE WHERE BASE_SEQNO=a.vol_user_id) as BASE_NAME, ")
            sbSQL.AppendLine("       b.Apply_ym, ")
            sbSQL.AppendLine("       a.apply_amt ")
            sbSQL.AppendLine("FROM   SAL_VOL_feeDtl a ")
            sbSQL.AppendLine("       LEFT JOIN SAL_VOL_fee b ")
            sbSQL.AppendLine("              ON a.main_id = b.id ")

            sbSQL.AppendLine("WHERE  b.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")
            sbSQL.AppendLine("       AND b.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetTRANSFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine("SELECT (SELECT user_name ")
            sbSQL.AppendLine("        FROM   fsc_personnel ")
            sbSQL.AppendLine("        WHERE  id_card = a.Non_id) AS [User_name], ")
            sbSQL.AppendLine("       (SELECT TOP 1 d.Depart_name ")
            sbSQL.AppendLine("        FROM   FSC_Depart_EMP c ")
            sbSQL.AppendLine("               LEFT JOIN FSC_ORG d ")
            sbSQL.AppendLine("                      ON c.Depart_id = d.Depart_id ")
            sbSQL.AppendLine("        WHERE  id_card = a.Non_id) AS Depart_name, ")
            sbSQL.AppendLine("       b.Apply_date, ")
            sbSQL.AppendLine("       b.Apply_ym, ")
            sbSQL.AppendLine("       a.apply_amt ")
            sbSQL.AppendLine("FROM   SAL_TRANS_feeDtl a ")
            sbSQL.AppendLine("       LEFT JOIN SAL_TRANS_fee b ")
            sbSQL.AppendLine("              ON a.main_id = b.id ")

            sbSQL.AppendLine("WHERE  b.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")
            sbSQL.AppendLine("       AND b.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetTrafficFeeData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.Append("SELECT ")
            sbSQL.AppendLine("    b.org_code, ")
            sbSQL.AppendLine("    b.unit_code, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.org_code AND depart_id=b.unit_code) as depart_name, ")
            sbSQL.AppendLine("    b.user_id, ")
            sbSQL.AppendLine("    (SELECT user_name FROM fsc_personnel WHERE id_card=b.user_id) as user_name, ")
            sbSQL.AppendLine("    b.flow_id, ")
            sbSQL.AppendLine("    b.apply_ymd, ")
            sbSQL.AppendLine("    b.cost_date, ")
            sbSQL.AppendLine("    b.apply_desc, ")
            sbSQL.AppendLine("    b.apply_amt ")
            sbSQL.AppendLine("FROM  SAL_TRAFFIC_FEE b ")
            sbSQL.AppendLine("WHERE  b.flow_id in ")
            sbSQL.AppendLine("  (		SELECT Flow_id FROM SYS_FLOW WHERE Flow_id = @flow_id OR Merge_flowid =  @flow_id)    ")
            sbSQL.AppendLine("       AND b.org_code = @orgCode ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetApplyMaterialData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT ")
            sbSQL.AppendLine("    a.orgcode, ")
            sbSQL.AppendLine("    a.form_type, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='014' AND code_type='001' AND code_no=a.form_type) as form_name, ")
            sbSQL.AppendLine("    a.unit_code, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=a.orgcode AND depart_id=a.unit_code) as depart_name, ")
            sbSQL.AppendLine("    a.user_id, ")
            sbSQL.AppendLine("    (SELECT user_name FROM fsc_personnel WHERE id_card=a.user_id) as user_name, ")
            sbSQL.AppendLine("    a.flow_id, ")
            sbSQL.AppendLine("    b.material_id, ")
            sbSQL.AppendLine("    d.material_name, ")
            sbSQL.AppendLine("    b.apply_cnt, ")
            sbSQL.AppendLine("    b.out_cnt, ")
            sbSQL.AppendLine("    d.unit, ")
            sbSQL.AppendLine("    b.memo ")
            sbSQL.AppendLine(" FROM [MAT_ApplyMaterial_main] a ")
            sbSQL.AppendLine("    INNER JOIN MAT_ApplyMaterial_det b on a.flow_id=b.flow_id AND a.orgcode=b.orgcode ")
            sbSQL.AppendLine("    INNER JOIN SYS_flow c on a.flow_id=c.flow_id AND a.orgcode=c.orgcode ")
            sbSQL.AppendLine("    INNER JOIN MAT_material_main d on d.material_id=b.material_id")
            sbSQL.AppendLine(" WHERE (a.flow_id = @flow_id AND a.OrgCode = @orgCode) or c.merge_flowid=@flow_id ")
            sbSQL.AppendLine(" order by a.form_type desc ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flowId), _
            New SqlParameter("@orgCode", orgcode)}
            Return Query(sbSQL.ToString(), params)
        End Function




        Public Function GetPropertyData(orgcode As String, flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)

            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("PRO_PropertyScrap_main", d)
        End Function
        Public Function GetPropertyDataNew(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT *,  ")
            sbSQL.AppendLine(" (select CODE_DESC1 from SYS_CODE as i where i.CODE_NO=a.Property_type AND i.CODE_SYS='016' AND i.code_type ='006') as Property_type_New")
            sbSQL.AppendLine(" FROM PRO_PropertyScrap_main as a ")
            sbSQL.AppendLine(" WHERE orgcode=@orgcode AND flow_id=@flowId ")
            sbSQL.AppendLine(" order by orgcode, flow_id, property_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetPropertyTrANData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT *,  ")
            sbSQL.AppendLine("  (select depart_name from fsc_org a where a.orgcode=orgcode and a.depart_id=OldUnit_code) as OldUnit_name,  ")
            sbSQL.AppendLine("  (select depart_name from fsc_org a where a.orgcode=orgcode and a.depart_id=NewUnit_code) as NewUnit_name  ")
            sbSQL.AppendLine(" FROM PRO_PropertyTran_det ")
            sbSQL.AppendLine(" WHERE orgcode=@orgcode AND flow_id=@flowId ")
            sbSQL.AppendLine(" order by orgcode, flow_id, property_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetSwRegisterData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT *  ")
            sbSQL.AppendLine(" FROM PRO_SwRegister_main ")
            sbSQL.AppendLine(" WHERE orgcode=@orgcode AND flow_id=@flowId ")
            sbSQL.AppendLine(" order by orgcode, flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetSwMaintainData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT *  ")
            sbSQL.AppendLine(" FROM MAI_SwMaintain_main ")
            sbSQL.AppendLine(" WHERE orgcode=@orgcode AND flow_id=@flowId ")
            sbSQL.AppendLine(" order by orgcode, flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetElecMaintainData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT b.*,  ")
            sbSQL.AppendLine("    (SELECT user_name FROM fsc_personnel WHERE id_card=a.user_id) user_name, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE depart_id=a.Unit_code) depart_name, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='019' AND code_type='001' AND code_no=b.MtClass_type) MtClass_type_name, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='019' AND code_type='005' AND code_no=b.ElecExpect_type) ElecExpect_type_name ")
            sbSQL.AppendLine(" FROM MAI_ElecMaintain_main a ")
            sbSQL.AppendLine("    INNER JOIN MAI_ElecMaintain_det b on a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine(" WHERE a.orgcode=@orgcode AND a.flow_id=@flowId ")
            sbSQL.AppendLine(" order by a.orgcode, a.flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function UpdateElecMaintainDetData(orgcode As String, flowId As String, mtClassType As String, mtStatusDesc As String, mtStatusType As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" update MAI_ElecMaintain_det ")
            sbSQL.AppendLine(" Set ")
            sbSQL.AppendLine("    MtStatus_desc=@mtStatusDesc, MtStatus_type=@mtStatusType ")
            sbSQL.AppendLine(" WHERE orgcode=@orgcode AND flow_id=@flowId AND MtClass_type=@mtClassType ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId), _
            New SqlParameter("@mtClassType", mtClassType), _
            New SqlParameter("@mtStatusDesc", mtStatusDesc), _
            New SqlParameter("@mtStatusType", mtStatusType)}

            Return Execute(sbSQL.ToString(), params)
        End Function

        Public Function UpdateElecMaintainMainData(orgcode As String, flowId As String, caseCloseType As String) As Integer
            sbSQL.Length = 0
            sbSQL.AppendLine(" update MAI_ElecMaintain_main ")
            sbSQL.AppendLine(" Set ")
            sbSQL.AppendLine("    CaseClose_type=@caseCloseType ")
            sbSQL.AppendLine(" WHERE orgcode=@orgcode AND flow_id=@flowId ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId), _
            New SqlParameter("@caseCloseType", caseCloseType)}

            Return Execute(sbSQL.ToString(), params)
        End Function

        Public Function GetInfoNetServiceMainData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT a.* ")
            sbSQL.AppendLine(" FROM OTH_InfoNet_Service_main a ")
            sbSQL.AppendLine(" WHERE a.orgcode=@orgcode AND a.flow_id=@flowId ")
            sbSQL.AppendLine(" order by a.orgcode, a.flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetInfoNetServiceDetData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT a.* ")
            sbSQL.AppendLine(" FROM OTH_InfoNet_Service_det a ")
            sbSQL.AppendLine(" WHERE a.orgcode=@orgcode AND a.flow_id=@flowId ")
            sbSQL.AppendLine(" order by a.orgcode, a.flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetOTHBroadcastMainData(orgcode As String, flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT a.* ")
            sbSQL.AppendLine(" FROM OTH_Broadcast_main a ")
            sbSQL.AppendLine(" WHERE a.orgcode=@orgcode AND a.flow_id=@flowId ")
            sbSQL.AppendLine(" order by a.orgcode, a.flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetApplyData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal dates As String, ByVal datee As String, ByVal formId As String, ByVal caseStatus As String, ByVal lastpass As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine(" SELECT  ")
            sbSQL.AppendLine("    b.flow_id, ")
            sbSQL.AppendLine("    b.Orgcode, ")
            sbSQL.AppendLine("    b.depart_id, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.orgcode AND depart_id=b.depart_id) Depart_name, ")
            sbSQL.AppendLine("    b.Apply_idcard, ")
            sbSQL.AppendLine("    b.Apply_name, ")
            sbSQL.AppendLine("    b.write_time, ")
            sbSQL.AppendLine("    b.Reason, ")
            sbSQL.AppendLine("    b.form_id, ")
            sbSQL.AppendLine("    b.case_status, ")
            sbSQL.AppendLine("    b.last_pass, ")
            sbSQL.AppendLine("    b.merge_flag, ")
            sbSQL.AppendLine("    (select c.depart_name from fsc_org c where c.orgcode=a.next_orgcode and c.depart_id=a.next_departid) next_departname, ")
            sbSQL.AppendLine("    a.next_idcard, ")
            sbSQL.AppendLine("    a.next_name, ")
            sbSQL.AppendLine("    (SELECT top 1 agree_time FROM SYS_Flow_detail d WHERE d.orgcode=b.orgcode AND d.flow_id=b.flow_id order by agree_time ) agree_time, ")
            sbSQL.AppendLine("    b.Last_date ")
            sbSQL.AppendLine(" FROM SYS_Flow b WITH(NOLOCK) ")
            sbSQL.AppendLine("    LEFT JOIN SYS_Flow_next a WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine("    and a.id = (select max(id) from SYS_Flow_next s where a.orgcode = s.orgcode and a.flow_id = s.flow_id)")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" ((a.Next_orgcode=@orgcode AND a.Next_departid=@departId AND a.Next_idcard=@idCard AND b.merge_flag='1' AND b.Case_status=2 )  ")
            sbSQL.AppendLine("   OR (b.orgcode=@orgcode AND b.depart_id=@departId AND b.apply_idcard=@idCard AND b.Merge_flowid is null)) ")

            Dim caseStatus1 As String = ""
            Dim caseStatus2 As String = ""
            If caseStatus.IndexOf(",") >= 0 Then
                sbSQL.AppendLine("AND b.case_status in (@caseStatus1, @caseStatus2) ")
                caseStatus1 = caseStatus.Split(",")(0)
                caseStatus2 = caseStatus.Split(",")(1)
            Else
                sbSQL.AppendLine("AND b.case_status=@caseStatus1 ")
                caseStatus1 = caseStatus
            End If

            sbSQL.AppendLine(" AND b.last_pass=@lastPass ")

            If Not String.IsNullOrEmpty(dates) Then
                dates = dates.Substring(0, 3) + 1911 & dates.Substring(3)
                sbSQL.Append(" AND CONVERT(varchar(100), b.write_time, 112)>=@dates ")
            End If

            If Not String.IsNullOrEmpty(datee) Then
                datee = datee.Substring(0, 3) + 1911 & datee.Substring(3)
                sbSQL.Append(" AND CONVERT(varchar(100), b.write_time, 112)<=@datee ")
            End If

            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 3 Then
                    formId = formId & "%"
                    sbSQL.AppendLine(" AND b.form_id like @formId ")
                Else
                    sbSQL.AppendLine(" AND b.form_id=@formId ")
                End If
            End If

            sbSQL.AppendLine(" UNION ")

            sbSQL.AppendLine(" SELECT  ")
            sbSQL.AppendLine("    b.flow_id, ")
            sbSQL.AppendLine("    b.Orgcode, ")
            sbSQL.AppendLine("    b.depart_id, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.orgcode AND depart_id=b.depart_id) Depart_name, ")
            sbSQL.AppendLine("    b.Apply_idcard, ")
            sbSQL.AppendLine("    b.Apply_name, ")
            sbSQL.AppendLine("    b.write_time, ")
            sbSQL.AppendLine("    b.Reason, ")
            sbSQL.AppendLine("    b.form_id, ")
            sbSQL.AppendLine("    b.case_status, ")
            sbSQL.AppendLine("    b.last_pass, ")
            sbSQL.AppendLine("    b.merge_flag, ")
            sbSQL.AppendLine("    (select c.depart_name from fsc_org c where c.orgcode=a.next_orgcode and c.depart_id=a.next_departid) next_departname, ")
            sbSQL.AppendLine("    a.next_idcard, ")
            sbSQL.AppendLine("    a.next_name, ")
            sbSQL.AppendLine("    (SELECT top 1 agree_time FROM SYS_Flow_detail d WHERE d.orgcode=b.orgcode AND d.flow_id=b.flow_id order by agree_time) agree_time, ")
            sbSQL.AppendLine("    b.Last_date ")
            sbSQL.AppendLine(" FROM SYS_Flow b WITH(NOLOCK) ")
            sbSQL.AppendLine("    INNER JOIN SYS_Flow c WITH(NOLOCK) ON b.orgcode=c.Merge_orgcode AND b.Flow_id=c.Merge_flowid ")
            sbSQL.AppendLine("    LEFT JOIN SYS_Flow_next a WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine("    and a.id = (select max(id) from SYS_Flow_next s where a.orgcode = s.orgcode and a.flow_id = s.flow_id)")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine("    c.orgcode=@orgcode AND c.depart_id=@departId AND c.apply_idcard=@idCard AND c.Merge_flowid is not null ")

            If caseStatus.IndexOf(",") >= 0 Then
                sbSQL.AppendLine("AND b.case_status in (@caseStatus1, @caseStatus2) ")
                caseStatus1 = caseStatus.Split(",")(0)
                caseStatus2 = caseStatus.Split(",")(1)
            Else
                sbSQL.AppendLine("AND b.case_status=@caseStatus1 ")
                caseStatus1 = caseStatus
            End If

            sbSQL.AppendLine(" AND b.last_pass=@lastPass ")

            If Not String.IsNullOrEmpty(dates) Then
                'dates = dates.Substring(0, 3) + 1911 & dates.Substring(3)
                sbSQL.Append(" AND CONVERT(varchar(100), b.write_time, 112)>=@dates ")
            End If

            If Not String.IsNullOrEmpty(datee) Then
                'datee = datee.Substring(0, 3) + 1911 & datee.Substring(3)
                sbSQL.Append(" AND CONVERT(varchar(100), b.write_time, 112)<=@datee ")
            End If

            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 3 Then
                    formId = formId & "%"
                    sbSQL.AppendLine(" AND b.form_id like @formId ")
                Else
                    sbSQL.AppendLine(" AND b.form_id=@formId ")
                End If
            End If

            sbSQL.AppendLine(" ORDER BY b.Last_date desc ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard), _
            New SqlParameter("@dates", dates), _
            New SqlParameter("@datee", datee), _
            New SqlParameter("@caseStatus1", caseStatus1), _
            New SqlParameter("@caseStatus2", caseStatus2), _
            New SqlParameter("@lastPass", lastpass), _
            New SqlParameter("@formId", formId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetMergedData(ByVal orgcode As String, ByVal flowId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT  ")
            sbSQL.AppendLine("    b.Flow_id, ")
            sbSQL.AppendLine("    b.Orgcode, ")
            sbSQL.AppendLine("    b.depart_id, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.orgcode AND depart_id=b.depart_id) Depart_name, ")
            sbSQL.AppendLine("    b.Apply_idcard, ")
            sbSQL.AppendLine("    b.Apply_name, ")
            sbSQL.AppendLine("    b.write_time, ")
            sbSQL.AppendLine("    b.Reason, ")
            sbSQL.AppendLine("    b.form_id, ")
            sbSQL.AppendLine("    b.case_status, ")
            sbSQL.AppendLine("    b.last_pass, ")
            sbSQL.AppendLine("    b.merge_flag, ")
            sbSQL.AppendLine("    (case when b.merge_flowid is null ")
            sbSQL.AppendLine("      then a.next_idcard ")
            sbSQL.AppendLine("      else (select top 1 next_idcard from sys_flow_next where orgcode=b.merge_orgcode AND flow_id=b.merge_flowid) ")
            sbSQL.AppendLine("    end) next_idcard, ")
            sbSQL.AppendLine("    (case when b.merge_flowid is null ")
            sbSQL.AppendLine("      then a.next_name ")
            sbSQL.AppendLine("      else (select top 1 next_name from sys_flow_next where orgcode=b.merge_orgcode AND flow_id=b.merge_flowid) ")
            sbSQL.AppendLine("    end) next_name, ")
            sbSQL.AppendLine("    (case when b.merge_flowid is null ")
            sbSQL.AppendLine("      then (SELECT top 1 agree_time FROM SYS_Flow_detail d WHERE d.orgcode=b.orgcode AND d.flow_id=b.flow_id order by agree_time )  ")
            sbSQL.AppendLine("      else (SELECT top 1 agree_time FROM SYS_Flow_detail d WHERE d.orgcode=b.merge_orgcode AND d.flow_id=b.merge_flowid order by agree_time ) ")
            sbSQL.AppendLine("    end) agree_time ")
            sbSQL.AppendLine(" FROM SYS_Flow b WITH(NOLOCK) ")
            sbSQL.AppendLine("    LEFT OUTER JOIN SYS_Flow_next a WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine(" WHERE b.Merge_Orgcode=@orgcode AND b.Merge_flowId=@flowId ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@flowId", flowId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetHasFlowDetailReplaceData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, _
                                                    ByVal replaceOrgcode As String, ByVal replaceDepartid As String, ByVal replaceIdcard As String, _
                                                    ByVal dates As String, ByVal datee As String, ByVal formId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT  ")
            sbSQL.AppendLine("    b.Flow_id, ")
            sbSQL.AppendLine("    b.Orgcode, ")
            sbSQL.AppendLine("    b.depart_id, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.orgcode AND depart_id=b.depart_id) Depart_name, ")
            sbSQL.AppendLine("    b.Apply_idcard, ")
            sbSQL.AppendLine("    b.Apply_name, ")
            sbSQL.AppendLine("    b.write_time, ")
            sbSQL.AppendLine("    b.Reason, ")
            sbSQL.AppendLine("    b.form_id, ")
            sbSQL.AppendLine("    b.case_status, ")
            sbSQL.AppendLine("    b.last_pass, ")
            sbSQL.AppendLine("    b.merge_flag, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='023' AND code_kind='P' AND code_type='003' AND code_no=a.agree_flag) agree_flag, ")
            sbSQL.AppendLine("    a.agree_time ")
            sbSQL.AppendLine(" FROM SYS_Flow_detail a WITH(NOLOCK) ")
            sbSQL.AppendLine("    INNER JOIN SYS_Flow b WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine("    a.Last_orgcode=@orgcode AND a.Last_departid=@departId AND a.Last_idcard=@idCard ")
            sbSQL.AppendLine("    and a.Replace_idcard is not null ")
            sbSQL.AppendLine("    and a.Replace_orgcode=@replaceOrgcode ")

            If Not String.IsNullOrEmpty(replaceDepartid) Then
                sbSQL.AppendLine("  and a.Replace_Departid=@replaceDepartid ")
            End If
            If Not String.IsNullOrEmpty(replaceIdcard) Then
                sbSQL.AppendLine("  and a.Replace_idcard=@replaceIdcard ")
            End If

            If Not String.IsNullOrEmpty(dates) Then
                sbSQL.Append(" AND cast(CONVERT(VARCHAR(10),a.Agree_time,112) as int ) - 19110000 >=@dates ")
            End If
            If Not String.IsNullOrEmpty(datee) Then
                sbSQL.Append(" AND cast(CONVERT(VARCHAR(10),a.Agree_time,112) as int ) - 19110000 <=@datee ")
            End If

            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 3 Then
                    formId = formId & "%"
                    sbSQL.AppendLine(" AND b.form_id like @formId ")
                Else
                    sbSQL.AppendLine(" AND b.form_id=@formId ")
                End If
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard), _
            New SqlParameter("@dates", dates), _
            New SqlParameter("@datee", datee), _
            New SqlParameter("@replaceOrgcode", replaceOrgcode), _
            New SqlParameter("@replaceDepartid", replaceDepartid), _
            New SqlParameter("@replaceIdcard", replaceIdcard), _
            New SqlParameter("@formId", formId)}

            Return Query(sbSQL.ToString(), params)
        End Function

        Public Function GetHasFlowDetailData(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal dates As String, ByVal datee As String, ByVal formId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT  ")
            sbSQL.AppendLine("    b.Flow_id, ")
            sbSQL.AppendLine("    b.Orgcode, ")
            sbSQL.AppendLine("    b.depart_id, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=b.orgcode AND depart_id=b.depart_id) Depart_name, ")
            sbSQL.AppendLine("    b.Apply_idcard, ")
            sbSQL.AppendLine("    b.Apply_name, ")
            sbSQL.AppendLine("    b.write_time, ")
            sbSQL.AppendLine("    b.Reason, ")
            sbSQL.AppendLine("    b.form_id, ")
            sbSQL.AppendLine("    b.case_status, ")
            sbSQL.AppendLine("    b.last_pass, ")
            sbSQL.AppendLine("    b.merge_flag, ")
            sbSQL.AppendLine("    (SELECT code_desc1 FROM sys_code WHERE code_sys='023' AND code_kind='P' AND code_type='003' AND code_no=a.agree_flag) agree_flag, ")
            sbSQL.AppendLine("    a.agree_time ")
            sbSQL.AppendLine(" FROM SYS_Flow_detail a WITH(NOLOCK) ")
            sbSQL.AppendLine("    INNER JOIN SYS_Flow b WITH(NOLOCK) ON a.orgcode=b.orgcode AND a.flow_id=b.flow_id ")
            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine("    a.Last_orgcode=@orgcode AND a.Last_departid=@departId AND a.Last_idcard=@idCard ")

            If Not String.IsNullOrEmpty(dates) Then
                sbSQL.Append(" AND cast(CONVERT(VARCHAR(10),a.Agree_time,112) as int ) - 19110000 >=@dates ")
            End If
            If Not String.IsNullOrEmpty(datee) Then
                sbSQL.Append(" AND cast(CONVERT(VARCHAR(10),a.Agree_time,112) as int ) - 19110000 <=@datee ")
            End If

            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 3 Then
                    formId = formId & "%"
                    sbSQL.AppendLine(" AND b.form_id like @formId ")
                Else
                    sbSQL.AppendLine(" AND b.form_id=@formId ")
                End If
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard), _
            New SqlParameter("@dates", dates), _
            New SqlParameter("@datee", datee), _
            New SqlParameter("@formId", formId)}

            Return Query(sbSQL.ToString(), params)
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
            Dim tablename As String = "FSC_CPAPK" & PKWDATE

            szSQL = String.Empty

            szSQL &= " SELECT '[異常]民國'+LEFT(PKWDATE,3)+'年'+SUBSTRING (PKWDATE,4,2)+'月'+SUBSTRING (PKWDATE,6,2) +'日出勤異常：' "
            szSQL &= " + (SELECT CODE_DESC1 FROM SYS_CODE WHERE CODE_SYS='023' AND CODE_TYPE='009' AND CODE_NO=PKWKTPE) ErrorData "
            szSQL &= " FROM " + tablename + " WITH(NOLOCK) "
            szSQL &= " WHERE 1 = 1"
            szSQL &= " AND PKWKTPE IN (" + PKWKTPE + ")"
            szSQL &= " AND PKCARD=@PKIDNO "
            szSQL &= " AND LEFT(PKWDATE,5)=@PKWDATE "
            szSQL &= " ORDER BY PKWDATE "

            Dim params() As SqlParameter = { _
            New SqlParameter("@PKIDNO", PKIDNO), _
            New SqlParameter("@PKWDATE", PKWDATE), _
            New SqlParameter("@PKWKTPE", PKWKTPE)}

            Return Query(szSQL.ToString(), params)
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
            szSQL = String.Empty

            szSQL &= " SELECT "
            szSQL &= " '值班日期：'+LEFT(Sche_date,3)+'/'+SUBSTRING(Sche_date,4,2)+'/'+SUBSTRING(Sche_date,6,2)"
            szSQL &= " +"
            szSQL &= " CASE WHEN Schedule_id='A00001' THEN ' 平日夜間(17:30~08:30）'"
            szSQL &= " WHEN Schedule_id='A00002' THEN ' 假日日間(08:30~17:30）'"
            szSQL &= " WHEN Schedule_id='A00003' THEN ' 假日夜間(17:30~08:30）'"
            szSQL &= " WHEN Schedule_id='A00004' THEN ' 農曆年假期間日間(08:30~17:30）'"
            szSQL &= " WHEN Schedule_id='A00005' THEN ' 農曆年假期間夜間(17:30~08:30）'"
            szSQL &= " WHEN Schedule_id='A00006' THEN ' 平日中午(12:30~13:30)' END ScheduleData"
            szSQL &= " FROM FSC_Schedule_setting WITH(NOLOCK) "
            szSQL &= " WHERE 1 = 1"
            szSQL &= " AND Orgcode=@Orgcode "
            szSQL &= " AND Depart_id=@Depart_id "
            szSQL &= " AND Id_card=@Id_card "
            szSQL &= " AND Sche_date BETWEEN @PKWDATE01 AND @PKWDATE02 "
            szSQL &= " ORDER BY Sche_date"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@PKWDATE01", PKWDATE01), _
            New SqlParameter("@PKWDATE02", PKWDATE02)}

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 回傳在職/服務中文證明資料檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWorkserviceData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            szSQL = String.Empty

            szSQL &= " SELECT * FROM FSC_Workservice_proof WHERE 1 = 1 AND Flow_id=@Flow_id AND Orgcode=@Orgcode "

            Dim params() As SqlParameter = { _
                  New SqlParameter("@Flow_id", Flow_id), _
                  New SqlParameter("@Orgcode", Orgcode)}

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 回傳 敍獎申請資料檔-主檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordMainData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            szSQL = String.Empty

            szSQL &= " SELECT O.Depart_name,RM.* "
            szSQL &= " FROM FSC_Reword_main RM LEFT JOIN FSC_ORG O ON RM.Depart_id=O.Depart_id "
            szSQL &= " WHERE 1 = 1 AND RM.Flow_id=@Flow_id AND RM.Orgcode=@Orgcode "

            Dim params() As SqlParameter = { _
                  New SqlParameter("@Flow_id", Flow_id), _
                  New SqlParameter("@Orgcode", Orgcode)}

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 回傳 敍獎申請資料檔-明細檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordDetailData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            szSQL = String.Empty

            szSQL &= " SELECT "
            szSQL &= " Row_Number() over (order by RD.ID) as RowNum,O.Depart_name "
            szSQL &= " ,C1.CODE_DESC1 AS Title_no "
            szSQL &= " ,C2.CODE_DESC1 AS Employee_type "
            szSQL &= " ,C3.CODE_DESC1 AS LevelS "
            szSQL &= " ,C4.CODE_DESC1 AS Ntype "
            szSQL &= " ,RD.* "
            szSQL &= " FROM FSC_Reword_det RD"
            szSQL &= " LEFT JOIN FSC_ORG O ON RD.Reword_departid=O.Depart_id"
            szSQL &= " LEFT JOIN SYS_CODE C1 ON RD.Reword_Title_no=C1.CODE_NO AND C1.CODE_SYS='023' AND C1.CODE_TYPE='012'"
            szSQL &= " LEFT JOIN SYS_CODE C2 ON RD.Reword_Employee_type=C2.CODE_NO AND C2.CODE_SYS='023' AND C2.CODE_TYPE='022'"
            szSQL &= " LEFT JOIN SYS_CODE C3 ON RD.Reword_Level=C3.CODE_NO AND C3.CODE_SYS='023' AND C3.CODE_TYPE='031'"
            szSQL &= " LEFT JOIN SYS_CODE C4 ON RD.Reword_type=C4.CODE_NO AND C4.CODE_SYS='023' AND C4.CODE_TYPE='028'"
            szSQL &= " WHERE 1 = 1 AND RD.Flow_id=@Flow_id AND RD.Reword_Orgcode=@Orgcode "

            Dim params() As SqlParameter = { _
                  New SqlParameter("@Flow_id", Flow_id), _
                  New SqlParameter("@Orgcode", Orgcode)}

            Return Query(szSQL.ToString(), params)
        End Function


        ''' <summary>
        ''' 回傳 值日(夜)代(換)值申請資料檔
        ''' </summary>
        ''' <param name="Flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDutyChangeData(ByVal Flow_id As String, ByVal Orgcode As String) As DataTable
            szSQL = String.Empty

            szSQL &= " SELECT *"
            szSQL &= " ,CASE WHEN Schedule_id='A00001' THEN '平日夜間(17:30~08:30）' "
            szSQL &= " WHEN Schedule_id='A00002' THEN '假日日間(08:30~17:30）'"
            szSQL &= " WHEN Schedule_id='A00003' THEN '假日夜間(17:30~08:30）'"
            szSQL &= " WHEN Schedule_id='A00004' THEN '農曆年假期間日間(08:30~17:30）'"
            szSQL &= " WHEN Schedule_id='A00005' THEN '農曆年假期間夜間(17:30~08:30）' END Schedule_Name"
            szSQL &= " ,CASE WHEN Shift_Schedule_id='A00001' THEN '平日夜間(17:30~08:30）' "
            szSQL &= " WHEN Shift_Schedule_id='A00002' THEN '假日日間(08:30~17:30）'"
            szSQL &= " WHEN Shift_Schedule_id='A00003' THEN '假日夜間(17:30~08:30）'"
            szSQL &= " WHEN Shift_Schedule_id='A00004' THEN '農曆年假期間日間(08:30~17:30）'"
            szSQL &= " WHEN Shift_Schedule_id='A00005' THEN '農曆年假期間夜間(17:30~08:30）' END Shift_Schedule_Name"
            szSQL &= " FROM FSC_Duty_change "
            szSQL &= " WHERE 1 = 1 AND Flow_id=@Flow_id AND Apply_Orgcode=@Orgcode "

            Dim params() As SqlParameter = { _
                  New SqlParameter("@Flow_id", Flow_id), _
                  New SqlParameter("@Orgcode", Orgcode)}

            Return Query(szSQL.ToString(), params)
        End Function

        Public Function getLeaveMainData(ByVal AD_id As String, ByVal yyymm As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select l.*, f.* ")
            sql.AppendLine(" from FSC_Leave_main l ")
            sql.AppendLine(" inner join SYS_Flow f on l.flow_id=f.flow_id ")
            sql.AppendLine(" where l.id_card in (select id_card from FSC_Personnel where AD_id=@AD_id) ")
            sql.AppendLine(" and (l.Start_date like @yyymm or End_date like @yyymm )")

            Dim params() As SqlParameter = { _
            New SqlParameter("@AD_id", AD_id), _
            New SqlParameter("@yyymm", yyymm + "%")}

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetInventoryData(ByVal Orgcode As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" SELECT top 1 * from MAT_Inventory_main WITH(NOLOCK) WHERE orgcode = @Orgcode ORDER BY InvStart_date DESC")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode)}
            Return Query(sql.ToString(), params)
        End Function
        Public Function Period(ByVal Orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select top 1 InvStart_date,Expected_date from MAT_Inventory_main WHERE orgcode = @Orgcode ORDER BY InvStart_date DESC")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard)}
            Return Query(sql.ToString(), params)
        End Function
        Public Function GetIneAdminData(ByVal Orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal roleid As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" SELECT * from FSC_Personnel WITH(NOLOCK) WHERE Role_id like @roleid AND Id_card = @idCard")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@roleid", "%" + roleid + "%"), _
            New SqlParameter("@idCard", idCard)}
            Return Query(sql.ToString(), params)
        End Function
        Public Function GetAvailableSafeData(ByVal Orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine("select count (Material_id) from MAT_Material_main WITH(NOLOCK) WHERE OrgCode = @Orgcode AND Available_cnt < Safe_cnt ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard)}
            Return Query(sql.ToString(), params)
        End Function

        Public Function getOfficialoutFee(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select distinct f.*, ")
            sql.AppendLine(" (select BANK_BANK_NO from SAL_SABANK ")
            sql.AppendLine(" inner join SAL_SATDPF on TDPF_SEQNO = BANK_TDPF_SEQNO ")
            sql.AppendLine(" inner join SAL_SATDPM on TDPF_SEQNO = TDPM_TDPF_SEQNO ")
            sql.AppendLine(" left outer join SYS_CODE on CODE_ORGID = TDPF_ORGID and CODE_SYS = '004' and CODE_TYPE = '002' and CODE_NO = TDPF_BANK ")
            sql.AppendLine(" where BANK_SEQNO = f.apply_idcard and TDPM_KIND = '005' and TDPM_CODE_SYS = '005' ")
            sql.AppendLine(" and TDPM_CODE_KIND = 'D' and TDPM_CODE_TYPE = '001' and TDPM_CODE_NO = '406' and TDPM_CODE = '027' )  Account,  ")
            sql.AppendLine(" o.Apply_date, ")
            sql.AppendLine(" pp.PPGUID, ")
            sql.AppendLine(" pp.PPBEFOREM, ")
            sql.AppendLine(" pp.PPBUSDATEB, ")
            sql.AppendLine(" pp.PPBUSDATEE ")
            sql.AppendLine(" from SYS_flow f ")
            sql.AppendLine(" inner join SAL_Officialout_Fee o on f.flow_id = o.flow_id ")
            sql.AppendLine(" inner join FSC_CPAPP16M pp on pp.PPGUID = o.PPGUID ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and f.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                sql.AppendLine(" and f.Flow_id=@Flow_id ")
            End If

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            params(1).Value = Flow_id

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace