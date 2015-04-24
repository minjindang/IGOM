Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class Personnel
        Public DAO As PersonnelDAO

        Public Sub New()
            DAO = New PersonnelDAO()
        End Sub

#Region "Property"
        Private _Id_card As String
        Private _Title_no As String
        Private _User_name As String
        Private _AD_id As String
        Private _Employee_type As String
        Private _Boss_level_id As String
        Private _On_Duty As String
        Private _Degree_code As String
        Private _Level As String
        Private _Act_date As String
        Private _Fisrt_gov_date As String
        Private _Left_date As String
        Private _Email As String
        Private _Leave_yr_add As Integer
        Private _Leave_yr_bdate As String
        Private _Shift_type As String
        Private _PESEX As String
        Private _PEHYEAR As String
        Private _PEHDAY As Double
        Private _PEHDAY2 As Double
        Private _PEHDAY3 As Double
        Private _PEKIND As String
        Private _PEOVERHFEE As Integer
        Private _PEOVERDATE As String
        Private _PEOLDFEE As Integer
        Private _PEPOINT As String
        Private _PEPROFESS As Integer
        Private _PECHIEF As Integer
        Private _PEYKIND As String
        Private _PERDAY As Double
        Private _PERDAY1 As Double
        Private _PERDAY2 As Double
        Private _PEALIMT As Double
        Private _PEBLIMT As Double
        Private _PEPAYDAYA As Double
        Private _PEPAYDAYB As Double
        Private _PEPAYHDAY As Integer
        Private _PERDAYK As String
        Private _Role_id As String
        Private _Login_status As Integer
        Private _Message_YN As String
        Private _Email_YN As String
        Private _Send_time1 As String
        Private _Send_time2 As String
        Private _Send_time3 As String
        Private _Send_time4 As String
        Private _Send_time5 As String
        Private _Send_time6 As String
        Private _Quit_job_flag As String
        Private _Change_userid As String
        Private _Change_date As System.Nullable(Of Date)
        Private _Birth_date As String
        Private _frequency As String
        Private _Init_flag As String
        Private _Id_number As String
        Private _MutiDepartDeputy_flag As String
        Private _Deputy_active As String
        Private _Deputy_active_idcard As String
        Private _Deputy_active_sdate As String
        Private _Deputy_active_stime As String
        Private _Deputy_active_edate As String
        Private _Deputy_active_etime As String
        Private _Service_year As String
        Private _YoyoCard_Change_flag As String
        Private _Depart_Change_flag As String
        Private _Yoyo_card As String

        Public Property IdCard() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property

        Public Property ADId() As String
            Get
                Return _AD_id
            End Get
            Set(ByVal value As String)
                _AD_id = value
            End Set
        End Property

        Public Property TitleNo() As String
            Get
                Return _Title_no
            End Get
            Set(ByVal value As String)
                _Title_no = value
            End Set
        End Property

        Public Property UserName() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property

        Public Property Boss_level_id() As String
            Get
                Return _Boss_level_id
            End Get
            Set(ByVal value As String)
                _Boss_level_id = value
            End Set
        End Property

        Public Property EmployeeType() As String
            Get
                Return _Employee_type
            End Get
            Set(ByVal value As String)
                _Employee_type = value
            End Set
        End Property

        Public Property On_Duty() As String
            Get
                Return _On_Duty
            End Get
            Set(ByVal value As String)
                _On_Duty = value
            End Set
        End Property

        Public Property Degree_code() As String
            Get
                Return _Degree_code
            End Get
            Set(ByVal value As String)
                _Degree_code = value
            End Set
        End Property

        Public Property Level() As String
            Get
                Return _Level
            End Get
            Set(ByVal value As String)
                _Level = value
            End Set
        End Property

        Public Property Act_date() As String
            Get
                Return _Act_date
            End Get
            Set(ByVal value As String)
                _Act_date = value
            End Set
        End Property

        Public Property Fisrt_gov_date() As String
            Get
                Return _Fisrt_gov_date
            End Get
            Set(ByVal value As String)
                _Fisrt_gov_date = value
            End Set
        End Property

        Public Property Left_date() As String
            Get
                Return _Left_date
            End Get
            Set(ByVal value As String)
                _Left_date = value
            End Set
        End Property

        Public Property LeaveYrAdd() As Integer
            Get
                Return _Leave_yr_add
            End Get
            Set(ByVal value As Integer)
                _Leave_yr_add = value
            End Set
        End Property

        Public Property LeaveYrBdate() As String
            Get
                Return _Leave_yr_bdate
            End Get
            Set(ByVal value As String)
                _Leave_yr_bdate = value
            End Set
        End Property

        Public Property ShiftType() As String
            Get
                Return _Shift_type
            End Get
            Set(ByVal value As String)
                _Shift_type = value
            End Set
        End Property

        Public Property Pesex() As String
            Get
                Return _PESEX
            End Get
            Set(ByVal value As String)
                _PESEX = value
            End Set
        End Property

        Public Property Pehyear() As String
            Get
                Return _PEHYEAR
            End Get
            Set(ByVal value As String)
                _PEHYEAR = value
            End Set
        End Property

        Public Property Pehday() As Double
            Get
                Return _PEHDAY
            End Get
            Set(ByVal value As Double)
                _PEHDAY = value
            End Set
        End Property

        Public Property Pehday2() As Double
            Get
                Return _PEHDAY2
            End Get
            Set(ByVal value As Double)
                _PEHDAY2 = value
            End Set
        End Property

        Public Property Pehday3() As Double
            Get
                Return _PEHDAY3
            End Get
            Set(ByVal value As Double)
                _PEHDAY3 = value
            End Set
        End Property

        Public Property Pekind() As String
            Get
                Return _PEKIND
            End Get
            Set(ByVal value As String)
                _PEKIND = value
            End Set
        End Property

        Public Property Peoverhfee() As Integer
            Get
                Return _PEOVERHFEE
            End Get
            Set(ByVal value As Integer)
                _PEOVERHFEE = value
            End Set
        End Property

        Public Property Peoverdate() As String
            Get
                Return _PEOVERDATE
            End Get
            Set(ByVal value As String)
                _PEOVERDATE = value
            End Set
        End Property

        Public Property Peoldfee() As Integer
            Get
                Return _PEOLDFEE
            End Get
            Set(ByVal value As Integer)
                _PEOLDFEE = value
            End Set
        End Property

        Public Property Pepoint() As String
            Get
                Return _PEPOINT
            End Get
            Set(ByVal value As String)
                _PEPOINT = value
            End Set
        End Property

        Public Property Peprofess() As Integer
            Get
                Return _PEPROFESS
            End Get
            Set(ByVal value As Integer)
                _PEPROFESS = value
            End Set
        End Property

        Public Property Pechief() As Integer
            Get
                Return _PECHIEF
            End Get
            Set(ByVal value As Integer)
                _PECHIEF = value
            End Set
        End Property

        Public Property Peykind() As String
            Get
                Return _PEYKIND
            End Get
            Set(ByVal value As String)
                _PEYKIND = value
            End Set
        End Property

        Public Property Perday() As Double
            Get
                Return _PERDAY
            End Get
            Set(ByVal value As Double)
                _PERDAY = value
            End Set
        End Property

        Public Property Perday1() As Double
            Get
                Return _PERDAY1
            End Get
            Set(ByVal value As Double)
                _PERDAY1 = value
            End Set
        End Property

        Public Property Perday2() As Double
            Get
                Return _PERDAY2
            End Get
            Set(ByVal value As Double)
                _PERDAY2 = value
            End Set
        End Property

        Public Property Peblimt() As Double
            Get
                Return _PEBLIMT
            End Get
            Set(ByVal value As Double)
                _PEBLIMT = value
            End Set
        End Property

        Public Property Pepaydaya() As Double
            Get
                Return _PEPAYDAYA
            End Get
            Set(ByVal value As Double)
                _PEPAYDAYA = value
            End Set
        End Property

        Public Property Pealimt() As Double
            Get
                Return _PEALIMT
            End Get
            Set(ByVal value As Double)
                _PEALIMT = value
            End Set
        End Property

        Public Property Pepaydayb() As Double
            Get
                Return _PEPAYDAYB
            End Get
            Set(ByVal value As Double)
                _PEPAYDAYB = value
            End Set
        End Property

        Public Property Pepayhday() As Integer
            Get
                Return _PEPAYHDAY
            End Get
            Set(ByVal value As Integer)
                _PEPAYHDAY = value
            End Set
        End Property

        Public Property ChangeDate() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property

        Public Property ChangeUserid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property

        Public Property SendTime6() As String
            Get
                Return _Send_time6
            End Get
            Set(ByVal value As String)
                _Send_time6 = value
            End Set
        End Property

        Public Property SendTime5() As String
            Get
                Return _Send_time5
            End Get
            Set(ByVal value As String)
                _Send_time5 = value
            End Set
        End Property

        Public Property SendTime4() As String
            Get
                Return _Send_time4
            End Get
            Set(ByVal value As String)
                _Send_time4 = value
            End Set
        End Property

        Public Property SendTime3() As String
            Get
                Return _Send_time3
            End Get
            Set(ByVal value As String)
                _Send_time3 = value
            End Set
        End Property

        Public Property SendTime2() As String
            Get
                Return _Send_time2
            End Get
            Set(ByVal value As String)
                _Send_time2 = value
            End Set
        End Property

        Public Property SendTime1() As String
            Get
                Return _Send_time1
            End Get
            Set(ByVal value As String)
                _Send_time1 = value
            End Set
        End Property

        Public Property EmailYN() As String
            Get
                Return _Email_YN
            End Get
            Set(ByVal value As String)
                _Email_YN = value
            End Set
        End Property

        Public Property MessageYN() As String
            Get
                Return _Message_YN
            End Get
            Set(ByVal value As String)
                _Message_YN = value
            End Set
        End Property

        Public Property LoginStatus() As Integer
            Get
                Return _Login_status
            End Get
            Set(ByVal value As Integer)
                _Login_status = value
            End Set
        End Property

        Public Property RoleId() As String
            Get
                Return _Role_id
            End Get
            Set(ByVal value As String)
                _Role_id = value
            End Set
        End Property

        Public Property Perdayk() As String
            Get
                Return _PERDAYK
            End Get
            Set(ByVal value As String)
                _PERDAYK = value
            End Set
        End Property

        Public Property Quit_job_flag() As String
            Get
                Return _Quit_job_flag
            End Get
            Set(ByVal value As String)
                _Quit_job_flag = value
            End Set
        End Property

        Public Property Birth_date() As String
            Get
                Return _Birth_date
            End Get
            Set(ByVal value As String)
                _Birth_date = value
            End Set
        End Property

        Public Property Frequency() As String
            Get
                Return _frequency
            End Get
            Set(ByVal value As String)
                _frequency = value
            End Set
        End Property

        Public Property Init_flag() As String
            Get
                Return _Init_flag
            End Get
            Set(ByVal value As String)
                _Init_flag = value
            End Set
        End Property

        Public Property Id_number() As String
            Get
                Return _Id_number
            End Get
            Set(ByVal value As String)
                _Id_number = value
            End Set
        End Property

        Public Property MutiDepartDeputy_flag() As String
            Get
                Return _MutiDepartDeputy_flag
            End Get
            Set(ByVal value As String)
                _MutiDepartDeputy_flag = value
            End Set
        End Property

        Public Property Deputy_active() As String
            Get
                Return _Deputy_active
            End Get
            Set(ByVal value As String)
                _Deputy_active = value
            End Set
        End Property

        Public Property Deputy_active_idcard() As String
            Get
                Return _Deputy_active_idcard
            End Get
            Set(ByVal value As String)
                _Deputy_active_idcard = value
            End Set
        End Property


        Public Property Deputy_active_sdate() As String
            Get
                Return _Deputy_active_sdate
            End Get
            Set(ByVal value As String)
                _Deputy_active_sdate = value
            End Set
        End Property

        Public Property Deputy_active_stime() As String
            Get
                Return _Deputy_active_stime
            End Get
            Set(ByVal value As String)
                _Deputy_active_stime = value
            End Set
        End Property

        Public Property Deputy_active_edate() As String
            Get
                Return _Deputy_active_edate
            End Get
            Set(ByVal value As String)
                _Deputy_active_edate = value
            End Set
        End Property

        Public Property Deputy_active_etime() As String
            Get
                Return _Deputy_active_etime
            End Get
            Set(ByVal value As String)
                _Deputy_active_etime = value
            End Set
        End Property

        Public Property Service_year() As String
            Get
                Return _Service_year
            End Get
            Set(ByVal value As String)
                _Service_year = value
            End Set
        End Property

        Public Property YoyoCard_Change_flag() As String
            Get
                Return _YoyoCard_Change_flag
            End Get
            Set(ByVal value As String)
                _YoyoCard_Change_flag = value
            End Set
        End Property

        Public Property Depart_Change_flag() As String
            Get
                Return _Depart_Change_flag
            End Get
            Set(ByVal value As String)
                _Depart_Change_flag = value
            End Set
        End Property

        Public Property Yoyo_card() As String
            Get
                Return _Yoyo_card
            End Get
            Set(ByVal value As String)
                _Yoyo_card = value
            End Set
        End Property
#End Region

        Public Function GetData() As DataTable
            Return DAO.GetData()
        End Function


        Public Function GetOnJobData() As DataTable
            Return DAO.GetOnJobData()
        End Function

        Public Function GetDataByIdCard(ByVal idCard As String) As DataTable
            Return DAO.GetDataByIdcard(idCard)
        End Function

        Public Function GetColumnValue(ByVal columnName As String, ByVal idCard As String) As String
            Dim dt As DataTable = DAO.GetDataByIdcard(idCard)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)(columnName).ToString()
            End If
            Return ""
        End Function

        Public Function GetDataByEmployeeType(ByVal employeeType As String) As DataTable
            Return DAO.GetDataByEmployeeType(IdCard)
        End Function

        Public Function GetTitleDataByOrgDep(ByVal orgcode As String, ByVal departId As String) As DataTable
            Return DAO.GetTitleDataByOrgDep(orgcode, departId)
        End Function

        Public Function GetTitleDataByOrgDep(ByVal orgcode As String, ByVal departId As String, ByVal Depart_Level As String, ByVal Title_level As String) As DataTable
            Return DAO.GetTitleDataByOrgDep(orgcode, departId, Depart_Level, Title_level)
        End Function

        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String) As DataTable
            Return GetDataByQuery(orgcode, departId, "", "")
        End Function

        Public Function GetDataByOrgDep(ByVal orgcode As String, ByVal departId As String, ByVal Depart_Level As String) As DataTable
            Return DAO.GetDataByOrgDep(orgcode, departId, Depart_Level)
        End Function

        Public Function GetDataByQuery(ByVal orgcode As String, ByVal departId As String, ByVal titleNo As String, ByVal idCard As String) As DataTable
            Return DAO.GetDataByQuery(orgcode, departId, titleNo, idCard)
        End Function

        Public Function GetDataByOnDuty(ByVal orgcode As String, ByVal departId As String, ByVal onDuty As String) As DataTable
            Return DAO.GetDataByOnDuty(orgcode, departId, onDuty)
        End Function

        Public Function GetDataByRoleId(ByVal orgcode As String, ByVal departId As String, ByVal roleId As String) As DataTable
            Return DAO.GetDataByRoleId(orgcode, departId, roleId)
        End Function

        Public Function GetDataByBossLevelId(orgcode As String, departId As String, bossLevelId As String) As DataTable

            Return DAO.GetDataByBossLevelId(orgcode, departId, bossLevelId)
        End Function

        Public Function GetObject(ByVal Id_card As String) As Personnel
            Dim p As Personnel = New Personnel
            Dim dt As DataTable = GetDataByIdCard(Id_card)

            Dim list As List(Of Personnel) = CommonFun.ConvertToList(Of Personnel)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If

            Return Nothing
        End Function

        Public Function UpdateAnnel(Perday As Double, Perday1 As Double, Perday2 As Double, Pehyear As Double, Pehday As Double, IdCard As String) As Boolean
            Return DAO.UpdateAnnel(Perday, Perday1, Perday2, Pehyear, Pehday, IdCard) >= 1
        End Function

        Public Function GetDataByOnDuty(ByVal onDuty As String) As DataTable
            Return DAO.GetDataByOnDuty(onDuty)
        End Function

        Public Function GetDataByADid(ByVal AD_id As String) As DataTable
            Return DAO.GetDataByADid(AD_id)
        End Function

        Public Function UpdateInitFlag(ByVal Id_card As String) As Boolean
            Return DAO.UpdateInitFlag(Id_card) >= 1
        End Function

        Public Function GetDataByOrgDepWithOutNonMember(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim dt As DataTable = GetDataByQuery(orgcode, departId, "", "")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim rows() As DataRow = dt.Select(" employee_type not in ('13','14','15') ")
                If rows IsNot Nothing Then
                    Dim ndt As DataTable = dt.Clone()
                    For Each dr As DataRow In rows
                        ndt.ImportRow(dr)
                    Next

                    Return ndt
                End If
            End If

            Return Nothing
        End Function

        Public Function GetDataWithoutMaintainVendors(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim dt As DataTable = GetDataByQuery(orgcode, departId, "", "")
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim rows() As DataRow = dt.Select(" employee_type not in ('13') ")
                If rows IsNot Nothing Then
                    Dim ndt As DataTable = dt.Clone()
                    For Each dr As DataRow In rows
                        ndt.ImportRow(dr)
                    Next

                    Return ndt
                End If
            End If

            Return Nothing
        End Function

        Public Function UpdateRole(ByVal Id_card As String, ByVal Role_id As String) As Boolean
            Return DAO.UpdateRole(Id_card, Role_id) >= 1
        End Function

        Public Function getDeputyActive(ByVal Id_card As String) As DataTable
            Return DAO.getDeputyActive(Id_card)
        End Function

        Public Function UpdateYoyoCard_Change_flag(ByVal Id_card As String, ByVal YoyoCard_Change_flag As String) As Boolean
            Return DAO.UpdateYoyoCard_Change_flag(Id_card, YoyoCard_Change_flag)
        End Function

        Public Function UpdateDepart_Change_flag(ByVal Id_card As String, ByVal Depart_Change_flag As String) As Boolean
            Return DAO.UpdateDepart_Change_flag(Id_card, Depart_Change_flag)
        End Function
    End Class
End Namespace