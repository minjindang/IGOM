Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class ProjectOvertimeRule
        Private DAO As ProjectOvertimeRuleDAO

        Public Sub New()
            DAO = New ProjectOvertimeRuleDAO()
        End Sub
#Region "Property"
        Private _orgcode As String
        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(ByVal value As String)
                _orgcode = value
            End Set
        End Property
        Private _flowId As String
        Public Property FlowId() As String
            Get
                Return _flowId
            End Get
            Set(ByVal value As String)
                _flowId = value
            End Set
        End Property
        Private _projectCode As String
        Public Property ProjectCode() As String
            Get
                Return _projectCode
            End Get
            Set(ByVal value As String)
                _projectCode = value
            End Set
        End Property
        Private _projectName As String
        Public Property ProjectName() As String
            Get
                Return _projectName
            End Get
            Set(ByVal value As String)
                _projectName = value
            End Set
        End Property
        Private _projectKind As String
        Public Property ProjectKind() As String
            Get
                Return _projectKind
            End Get
            Set(ByVal value As String)
                _projectKind = value
            End Set
        End Property
        Private _projectDesc As String
        Public Property ProjectDesc() As String
            Get
                Return _projectDesc
            End Get
            Set(ByVal value As String)
                _projectDesc = value
            End Set
        End Property
        Private _startDate As String
        Public Property StartDate() As String
            Get
                Return _startDate
            End Get
            Set(ByVal value As String)
                _startDate = value
            End Set
        End Property
        Private _endDate As String
        Public Property EndDate() As String
            Get
                Return _endDate
            End Get
            Set(ByVal value As String)
                _endDate = value
            End Set
        End Property
        Private _departId As String
        Public Property DepartId() As String
            Get
                Return _departId
            End Get
            Set(ByVal value As String)
                _departId = value
            End Set
        End Property
        Private _idCard As String
        Public Property IdCard() As String
            Get
                Return _idCard
            End Get
            Set(ByVal value As String)
                _idCard = value
            End Set
        End Property
        Private _userName As String
        Public Property UserName() As String
            Get
                Return _userName
            End Get
            Set(ByVal value As String)
                _userName = value
            End Set
        End Property
        Private _titleNo As String
        Public Property TitleNo() As String
            Get
                Return _titleNo
            End Get
            Set(ByVal value As String)
                _titleNo = value
            End Set
        End Property
        Private _dailyOTHr As String
        Public Property DailyOTHr() As String
            Get
                Return _dailyOTHr
            End Get
            Set(ByVal value As String)
                _dailyOTHr = value
            End Set
        End Property
        Private _dailyOTPayHr As String
        Public Property DailyOTPayHr() As String
            Get
                Return _dailyOTPayHr
            End Get
            Set(ByVal value As String)
                _dailyOTPayHr = value
            End Set
        End Property
        Private _monOTHr As String
        Public Property MonOTHr() As String
            Get
                Return _monOTHr
            End Get
            Set(ByVal value As String)
                _monOTHr = value
            End Set
        End Property
        Private _monOTPayHr As String
        Public Property MonOTPayHr() As String
            Get
                Return _monOTPayHr
            End Get
            Set(ByVal value As String)
                _monOTPayHr = value
            End Set
        End Property
        Private _approveFlag As String
        Public Property ApproveFlag() As String
            Get
                Return _approveFlag
            End Get
            Set(ByVal value As String)
                _approveFlag = value
            End Set
        End Property

        Private _changeUserid As String
        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(ByVal value As String)
                _changeUserid = value
            End Set
        End Property
        Private _changeDate As Date = Now
        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal value As Date)
                _changeDate = value
            End Set
        End Property
        Private _Start_time As String
        Public Property Start_time() As String
            Get
                Return _Start_time
            End Get
            Set(ByVal value As String)
                _Start_time = value
            End Set
        End Property
        Private _End_time As String
        Public Property End_time() As String
            Get
                Return _End_time
            End Get
            Set(ByVal value As String)
                _End_time = value
            End Set
        End Property
        Private _CheckType As String
        Public Property CheckType() As String
            Get
                Return _CheckType
            End Get
            Set(ByVal value As String)
                _CheckType = value
            End Set
        End Property
        Private _Location As String
        Public Property Location() As String
            Get
                Return _Location
            End Get
            Set(ByVal value As String)
                _Location = value
            End Set
        End Property
        Private _isCard As String
        Public Property isCard() As String
            Get
                Return _isCard
            End Get
            Set(ByVal value As String)
                _isCard = value
            End Set
        End Property
        Private _isOnlyLeave As String
        Public Property isOnlyLeave() As String
            Get
                Return _isOnlyLeave
            End Get
            Set(ByVal value As String)
                _isOnlyLeave = value
            End Set
        End Property
        Private _LeaveHours As Double
        Public Property LeaveHours() As Double
            Get
                Return _LeaveHours
            End Get
            Set(ByVal value As Double)
                _LeaveHours = value
            End Set
        End Property
        Private _isShow As String
        Public Property isShow() As String
            Get
                Return _isShow
            End Get
            Set(ByVal value As String)
                _isShow = value
            End Set
        End Property

#End Region

        Public Function InsertData() As Boolean
            Return DAO.InsertData(Me) >= 1
        End Function

        Public Function UpdateData() As Boolean
            Return DAO.UpdateData(Me) >= 1
        End Function

        Public Function DeleteData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("flow_id", FlowId)

            Return DAO.DeleteByExample("fsc_Project_Overtime_Rule", d)
        End Function

        Public Function UpdateApproveFlag(orgcode As String, flowId As String, approveFlag As String) As Boolean
            Return DAO.UpdateApproveFlag(orgcode, flowId, approveFlag) >= 1
        End Function

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Return DAO.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function GetObjects(orgcode As String, flowId As String) As List(Of ProjectOvertimeRule)
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)
            Return CommonFun.ConvertToList(Of ProjectOvertimeRule)(dt)
        End Function

        Public Function GetDataByIdCard(orgcode As String, departId As String, idCard As String) As DataTable
            Return DAO.GetDataByIdCard(orgcode, departId, idCard, "", "")
        End Function

        Public Function GetDataByIdCard(orgcode As String, departId As String, idCard As String, approveFlag As String, isShow As String) As DataTable
            Return DAO.GetDataByIdCard(orgcode, departId, idCard, approveFlag, isShow)
        End Function

        Public Function GetDataByDate(orgcode As String, departId As String, idCard As String, sdate As String) As DataTable
            Return DAO.GetDataByDate(orgcode, departId, idCard, sdate)
        End Function

        Public Function getDataByYYYMM(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal yyymm As String) As DataTable
            Return DAO.getDataByYYYMM(orgcode, depart_id, id_card, yyymm)
        End Function

        Public Function getDataByCode(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal Project_code As String) As DataTable
            Return DAO.getDataByCode(orgcode, depart_id, id_card, Project_code)
        End Function

        Public Function getDataByCode(ByVal orgcode As String, ByVal depart_id As String, ByVal id_card As String, ByVal date_time As String, ByVal Project_code As String) As DataTable
            Return DAO.getDataByCode(orgcode, depart_id, id_card, date_time, Project_code)
        End Function

        Public Function GetDistinctDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Return DAO.GetDistinctDataByOrgFid(orgcode, flowId)
        End Function
    End Class
End Namespace

