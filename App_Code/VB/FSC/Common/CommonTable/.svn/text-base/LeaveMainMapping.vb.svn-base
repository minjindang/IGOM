Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic
    Public Class LeaveMainMapping
        Dim DAO As LeaveMainMappingDAO

#Region "Property"
        Private _flowId As String
        Public Property FlowId() As String
            Get
                Return _flowId
            End Get
            Set(ByVal value As String)
                _flowId = value
            End Set
        End Property
        Private _orgcode As String
        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(ByVal value As String)
                _orgcode = value
            End Set
        End Property
        Private _idCard As String
        Public Property Idcard() As String
            Get
                Return _idCard
            End Get
            Set(ByVal value As String)
                _idCard = value
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
        Private _startTime As String
        Public Property StartTime() As String
            Get
                Return _startTime
            End Get
            Set(ByVal value As String)
                _startTime = value
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
        Private _endTime As String
        Public Property EndTime() As String
            Get
                Return _endTime
            End Get
            Set(ByVal value As String)
                _endTime = value
            End Set
        End Property
        Private _leaveType As Integer
        Public Property LeaveType() As String
            Get
                Return _leaveType
            End Get
            Set(ByVal value As String)
                _leaveType = value
            End Set
        End Property
        Private _leaveHours As Double
        Public Property LeaveHours() As Double
            Get
                Return _leaveHours
            End Get
            Set(ByVal value As Double)
                _leaveHours = value
            End Set
        End Property
        Private _applyDateb As String
        Public Property ApplyDateb() As String
            Get
                Return _applyDateb
            End Get
            Set(ByVal value As String)
                _applyDateb = value
            End Set
        End Property
        Private _applyDatee As String
        Public Property ApplyDatee() As String
            Get
                Return _applyDatee
            End Get
            Set(ByVal value As String)
                _applyDatee = value
            End Set
        End Property
        Private _applyTimeb As String
        Public Property ApplyTimeb() As String
            Get
                Return _applyTimeb
            End Get
            Set(ByVal value As String)
                _applyTimeb = value
            End Set
        End Property
        Private _applyTimee As String
        Public Property ApplyTimee() As String
            Get
                Return _applyTimee
            End Get
            Set(ByVal value As String)
                _applyTimee = value
            End Set
        End Property
        Private _Change_userid As String
        Public Property ChangeUserid() As String
            Get
                Return Me._Change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Change_userid, value) = False) Then
                    Me._Change_userid = value
                End If
            End Set
        End Property
        Private _Change_date As Date = Now
        Public Property ChangeDate() As System.Nullable(Of Date)
            Get
                Return Me._Change_date
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                If (Me._Change_date.Equals(value) = False) Then
                    Me._Change_date = value
                End If
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New LeaveMainMappingDAO()
        End Sub

        Public Function InsertData() As Boolean
            Return DAO.InsertData(Me)
        End Function

        Public Function InsertData(ByVal checkData As Boolean) As Boolean
            If checkData Then
                CheckInsertData()
            End If

            Return DAO.InsertData(Me) >= 1
        End Function

        Public Function GetObjects(ByVal orgcode As String, ByVal flowId As String) As List(Of LeaveMainMapping)
            Dim list As New List(Of LeaveMainMapping)
            Dim dt As DataTable = DAO.GetDataByOrgFid(orgcode, flowId)
            For Each dr As DataRow In dt.Rows
                Dim lmm As New LeaveMainMapping
                lmm.Orgcode = dr("Orgcode").ToString()
                lmm.FlowId = dr("Flow_id").ToString()
                lmm.Idcard = dr("Id_card").ToString()
                lmm.StartDate = dr("Start_date").ToString()
                lmm.EndDate = dr("End_date").ToString()
                lmm.StartTime = dr("Start_time").ToString()
                lmm.EndTime = dr("End_time").ToString()
                lmm.LeaveType = CommonFun.getInt(dr("Leave_type").ToString())
                lmm.LeaveHours = CommonFun.getInt(dr("Leave_hours").ToString())
                lmm.ApplyDateb = dr("Apply_dateb").ToString()
                lmm.ApplyDatee = dr("Apply_datee").ToString()
                lmm.ApplyTimeb = dr("Apply_timeb").ToString()
                lmm.ApplyTimee = dr("Apply_timee").ToString()
                list.Add(lmm)
            Next
            Return list
        End Function

        Public Sub CheckInsertData()
            If DateTimeInfo.GetPublicDate(Me.StartDate) > DateTimeInfo.GetPublicDate(Me.ApplyDateb).AddMonths(6).AddDays(1) Then
                Throw New FlowException("補休日期已超過加班日期六個月，請重新申請!")
            End If

            If Me.LeaveType = "4" Then

                'Dim dt As DataTable = GetCPAPS19MByPSADDD(Me.PSIDNO, Me.PSADDD)

                'Dim f As New Flow
                'For Each dr As DataRow In dt.Rows
                '    Flow_id = dr("PSUSERID").ToString()
                '    Dim fdt As DataTable = f.GetFlowByFlow_id(Flow_id, Orgcode)
                '    For Each fdr As DataRow In fdt.Rows
                '        If fdr("Last_pass").ToString() = "0" Then
                '            Return Me.PSADDD & "的加班資料已經正在申請補休，須待批核完畢後再行申請!"
                '        End If
                '    Next
                'Next

            ElseIf Me.LeaveType = "20" Then

                'Dim Total_Hours As Double = 0
                ''p2k
                'Dim cpadt As DataTable = cpaDAO.GetDataByDateTime(Me.PXIDNO, Me.PXADDD, Me.Old_Flow_id, True)
                'For Each dr As DataRow In cpadt.Rows
                '    Total_Hours += Integer.Parse(dr("PXBREAKH").ToString())     '已存在p2k資料庫的時數
                'Next
                ''plm
                'Dim dt As DataTable = DAO.GetDataByDateTime(Me.PXIDNO, PXADDD, Me.Old_Flow_id, False)
                'For Each dr As DataRow In dt.Rows
                '    Total_Hours += Integer.Parse(dr("PXBREAKH").ToString())     '已存在plm資料庫的時數
                'Next

                ''加上這次請領的時數
                'Total_Hours += Me.PXBREAKH

                'If Total_Hours > LeftHour Then
                '    Return "出差日" & Me.PXADDD & "已超過可補休上限(" & Content.ConvertDayHours(LeftHour) & "天)!"
                'End If

            End If

        End Sub

        Public Function GetDataByApplyData(ByVal orgcode As String, ByVal idcard As String, ByVal leaveType As String, ByVal applyDateb As String, ByVal applyTimeb As String) As DataTable
            Return DAO.GetDataByApplyData(orgcode, idcard, leaveType, applyDateb, applyTimeb)
        End Function
    End Class
End Namespace

