Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Collections
Imports System.Text
Imports CommonLib
Imports NLog

Namespace SYS.Logic
    Public Class Flow
        Dim DAO As FlowDAO
        Public Sub New()
            DAO = New FlowDAO()
        End Sub

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
        Private _departId As String
        Public Property DepartId() As String
            Get
                Return _departId
            End Get
            Set(ByVal value As String)
                _departId = value
            End Set
        End Property
        Private _applyPosid As String
        Public Property ApplyPosid() As String
            Get
                Return _applyPosid
            End Get
            Set(ByVal value As String)
                _applyPosid = value
            End Set
        End Property
        Private _applyIdcard As String
        Public Property ApplyIdcard() As String
            Get
                Return _applyIdcard
            End Get
            Set(ByVal value As String)
                _applyIdcard = value
            End Set
        End Property
        Private _applyName As String
        Public Property ApplyName() As String
            Get
                Return _applyName
            End Get
            Set(ByVal value As String)
                _applyName = value
            End Set
        End Property
        Private _applyStype As String
        Public Property ApplyStype() As String
            Get
                Return _applyStype
            End Get
            Set(ByVal value As String)
                _applyStype = value
            End Set
        End Property
        Private _deputyFlag As String
        Public Property DeputyFlag() As String
            Get
                Return _deputyFlag
            End Get
            Set(ByVal value As String)
                _deputyFlag = value
            End Set
        End Property
        Private _deputyOrgcode As String
        Public Property DeputyOrgcode() As String
            Get
                Return _deputyOrgcode
            End Get
            Set(ByVal value As String)
                _deputyOrgcode = value
            End Set
        End Property
        Private _deputyDepartid As String
        Public Property DeputyDepartid() As String
            Get
                Return _deputyDepartid
            End Get
            Set(ByVal value As String)
                _deputyDepartid = value
            End Set
        End Property
        Private _deputyPosid As String
        Public Property DeputyPosid() As String
            Get
                Return _deputyPosid
            End Get
            Set(ByVal value As String)
                _deputyPosid = value
            End Set
        End Property
        Private _deputyIdcard As String
        Public Property DeputyIdcard() As String
            Get
                Return _deputyIdcard
            End Get
            Set(ByVal value As String)
                _deputyIdcard = value
            End Set
        End Property
        Private _deputyName As String
        Public Property DeputyName() As String
            Get
                Return _deputyName
            End Get
            Set(ByVal value As String)
                _deputyName = value
            End Set
        End Property
        Private _levelDeputy As String
        Public Property LevelDeputy() As String
            Get
                Return _levelDeputy
            End Get
            Set(ByVal value As String)
                _levelDeputy = value
            End Set
        End Property
        Private _writerOrgcode As String
        Public Property WriterOrgcode() As String
            Get
                Return _writerOrgcode
            End Get
            Set(ByVal value As String)
                _writerOrgcode = value
            End Set
        End Property
        Private _writerDepartid As String
        Public Property WriterDepartid() As String
            Get
                Return _writerDepartid
            End Get
            Set(ByVal value As String)
                _writerDepartid = value
            End Set
        End Property
        Private _writerPosid As String
        Public Property WriterPosid() As String
            Get
                Return _writerPosid
            End Get
            Set(ByVal value As String)
                _writerPosid = value
            End Set
        End Property
        Private _writerIdcard As String
        Public Property WriterIdcard() As String
            Get
                Return _writerIdcard
            End Get
            Set(ByVal value As String)
                _writerIdcard = value
            End Set
        End Property
        Private _writerName As String
        Public Property WriterName() As String
            Get
                Return _writerName
            End Get
            Set(ByVal value As String)
                _writerName = value
            End Set
        End Property
        Private _writeTime As Date
        Public Property WriteTime() As Date
            Get
                Return _writeTime
            End Get
            Set(ByVal value As Date)
                _writeTime = value
            End Set
        End Property
        Private _lastDate As Date
        Public Property LastDate() As Date
            Get
                Return _lastDate
            End Get
            Set(ByVal value As Date)
                _lastDate = value
            End Set
        End Property
        Private _lastPass As Integer
        Public Property LastPass() As Integer
            Get
                Return _lastPass
            End Get
            Set(ByVal value As Integer)
                _lastPass = value
            End Set
        End Property
        Private _cancelFlowid As String
        Public Property CancelFlowid() As String
            Get
                Return _cancelFlowid
            End Get
            Set(ByVal value As String)
                _cancelFlowid = value
            End Set
        End Property
        Private _cancelDate As Date
        Public Property CancelDate() As Date
            Get
                Return _cancelDate
            End Get
            Set(ByVal value As Date)
                _cancelDate = value
            End Set
        End Property
        Private _cancelFlag As String
        Public Property CancelFlag() As String
            Get
                Return _cancelFlag
            End Get
            Set(ByVal value As String)
                _cancelFlag = value
            End Set
        End Property
        Private _caseStatus As Integer
        Public Property CaseStatus() As Integer
            Get
                Return _caseStatus
            End Get
            Set(ByVal value As Integer)
                _caseStatus = value
            End Set
        End Property
        Private _reason As String
        Public Property Reason() As String
            Get
                Return _reason
            End Get
            Set(ByVal value As String)
                _reason = value
            End Set
        End Property
        Private _oldFlowid As String
        Public Property OldFlowid() As String
            Get
                Return _oldFlowid
            End Get
            Set(ByVal value As String)
                _oldFlowid = value
            End Set
        End Property
        Private _mergeFlag As String
        Public Property MergeFlag() As String
            Get
                Return _mergeFlag
            End Get
            Set(ByVal value As String)
                _mergeFlag = value
            End Set
        End Property
        Private _mergeOrgcode As String
        Public Property MergeOrgcode() As String
            Get
                Return _mergeOrgcode
            End Get
            Set(ByVal value As String)
                _mergeOrgcode = value
            End Set
        End Property
        Private _mergeFlowid As String
        Public Property MergeFlowid() As String
            Get
                Return _mergeFlowid
            End Get
            Set(ByVal value As String)
                _mergeFlowid = value
            End Set
        End Property
        Private _mergeDate As Date
        Public Property MergeDate() As Date
            Get
                Return _mergeDate
            End Get
            Set(ByVal value As Date)
                _mergeDate = value
            End Set
        End Property
        Private _mergeUorgcode As String
        Public Property MergeUorgcode() As String
            Get
                Return _mergeUorgcode
            End Get
            Set(ByVal value As String)
                _mergeUorgcode = value
            End Set
        End Property
        Private _mergeUdepartid As String
        Public Property MergeUdepartid() As String
            Get
                Return _mergeUdepartid
            End Get
            Set(ByVal value As String)
                _mergeUdepartid = value
            End Set
        End Property
        Private _mergeUserid As String
        Public Property MergeUserid() As String
            Get
                Return _mergeUserid
            End Get
            Set(ByVal value As String)
                _mergeUserid = value
            End Set
        End Property
        Private _shiftFlag As String
        Public Property ShiftFlag() As String
            Get
                Return _shiftFlag
            End Get
            Set(ByVal value As String)
                _shiftFlag = value
            End Set
        End Property
        Private _docDeputyFlag As String
        Public Property DocDeputyFlag() As String
            Get
                Return _docDeputyFlag
            End Get
            Set(ByVal value As String)
                _docDeputyFlag = value
            End Set
        End Property
        Private _formId As String
        Public Property FormId() As String
            Get
                Return _formId
            End Get
            Set(ByVal value As String)
                _formId = value
            End Set
        End Property
        Private _changeUserid As String
        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(value As String)
                _changeUserid = value
            End Set
        End Property
        Private _changeDate As Date = Now
        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(value As Date)
                _changeDate = value
            End Set
        End Property
        Private _isLast As Boolean
        Public Property IsLast() As Boolean
            Get
                Return _isLast
            End Get
            Set(ByVal value As Boolean)
                _isLast = value
            End Set
        End Property
        Private _Budget_code As String
        Public Property Budget_code() As String
            Get
                Return _Budget_code
            End Get
            Set(ByVal value As String)
                _Budget_code = value
            End Set
        End Property

#End Region

        Public Shared Function HasMergeFlowId(flow_id As String) As Boolean
            Return Not String.IsNullOrEmpty(Flow.GetMergeFlowId(flow_id))
        End Function

        Public Shared Function GetMergeFlowId(flow_id As String) As String
            Return New FlowDAO().GetMergeFid(flow_id)
        End Function



        Public Function Insert() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function Update() As Boolean
            Return DAO.UpdateData(Me) = 1
        End Function

        Public Function UpdateLast(ByVal orgcode As String, ByVal flowId As String, ByVal caseStatus As String, ByVal lastPass As String, ByVal lastDate As Date) As Boolean
            Return DAO.UpdateLast(orgcode, flowId, caseStatus, lastPass, lastDate) > 0
        End Function

        Public Function UpdateMergedFlow(ByVal orgcode As String, ByVal flowId As String, ByVal mergeFlag As String, _
                                         ByVal mergeOrgcode As String, ByVal mergeFlowid As String, ByVal mergeDate As Date, _
                                         ByVal mergeUorgcode As String, ByVal mergeUdepartid As String, ByVal mergeUserid As String, _
                                         ByVal lastPass As String, ByVal lastDate As Date) As Boolean
            Return DAO.UpdateMergedFlow(orgcode, flowId, mergeFlag, mergeOrgcode, mergeFlowid, mergeDate, mergeUorgcode, mergeUdepartid, mergeUserid, lastPass, lastDate) > 0
        End Function

        Public Function UpdateCancel(ByVal orgcode As String, ByVal flowId As String, ByVal caseStatus As String, ByVal cancelFlag As String) As Boolean
            Return DAO.UpdateCancel(orgcode, flowId, caseStatus, cancelFlag) > 0
        End Function

        Public Function UpdateCaseStatus(ByVal orgcode As String, ByVal flowId As String, ByVal caseStatus As String) As Boolean
            Return DAO.UpdateCaseStatus(orgcode, flowId, caseStatus) > 0
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Return DAO.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function UpdateMergedFlag(ByVal orgcode As String, ByVal flowId As String, ByVal mergedFlag As String) As Boolean
            Return DAO.UpdateMergedFlag(orgcode, flowId, mergedFlag)
        End Function

        Public Function GetObject(ByVal orgcode As String, ByVal flowId As String) As Flow
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Me.Orgcode = r("Orgcode").ToString()
                Me.FlowId = r("Flow_id").ToString()
                Me.DepartId = r("Depart_id").ToString()
                Me.ApplyPosid = r("Apply_posid").ToString()
                Me.ApplyIdcard = r("Apply_idcard").ToString()
                Me.ApplyName = r("Apply_name").ToString()
                Me.ApplyStype = r("Apply_stype").ToString()
                Me.DeputyFlag = r("Deputy_flag").ToString()
                Me.DeputyOrgcode = r("Deputy_orgcode").ToString()
                Me.DeputyDepartid = r("Deputy_departid").ToString()
                Me.DeputyPosid = r("Deputy_posid").ToString()
                Me.DeputyIdcard = r("Deputy_idcard").ToString()
                Me.DeputyName = r("Deputy_name").ToString()
                Me.WriterOrgcode = r("Writer_orgcode").ToString()
                Me.WriterDepartid = r("Writer_departid").ToString()
                Me.WriterPosid = r("Writer_posid").ToString()
                Me.WriterIdcard = r("Writer_idcard").ToString()
                Me.WriterName = r("Writer_name").ToString()
                Me.WriteTime = IIf(IsDBNull(r("Write_time")), Nothing, r("Write_time"))
                Me.LastDate = IIf(IsDBNull(r("Last_date")), Nothing, r("Last_date"))
                Me.LastPass = r("Last_pass").ToString()
                Me.CancelFlowid = r("Cancel_flowid").ToString()
                Me.CancelDate = IIf(IsDBNull(r("Cancel_date")), Nothing, r("Cancel_date"))
                Me.CancelFlag = r("Cancel_flag").ToString()
                Me.CaseStatus = r("Case_status").ToString()
                Me.Reason = r("Reason").ToString()
                Me.OldFlowid = r("Old_flowid").ToString()
                Me.MergeFlag = r("Merge_flag").ToString()
                Me.MergeOrgcode = r("Merge_orgcode").ToString()
                Me.MergeFlowid = r("Merge_flowid").ToString()
                Me.MergeDate = IIf(IsDBNull(r("Merge_date")), Nothing, r("Merge_date"))
                Me.MergeUorgcode = r("Merge_uorgcode").ToString()
                Me.MergeUdepartid = r("Merge_udepartid").ToString()
                Me.MergeUserid = r("Merge_userid").ToString()
                Me.ShiftFlag = r("Shift_flag").ToString()
                Me.FormId = r("Form_id").ToString()
                Me.ChangeUserid = r("Change_userid").ToString()
                Me.ChangeDate = IIf(IsDBNull(r("Change_date")), Nothing, r("Change_date"))
                Me.Budget_code = r("Budget_code").ToString()
            End If

            Return Me
        End Function

        Public Function GetDataByOrgMergeFid(ByVal orgcode As String, ByVal MergeflowId As String) As DataTable
            Return DAO.GetDataByOrgMergeFid(orgcode, MergeflowId)
        End Function

        Public Function UpdateMAT_ApplyOutdateByMergeFid(ByVal orgcode As String, ByVal MergeflowId As String) As Boolean
            Return DAO.UpdateMAT_ApplyOutdateByMergeFid(orgcode, MergeflowId) > 0
        End Function

        Public Function GetDataByCancelFlowid(orgcode As String, cancelFlowid As String) As DataTable
            Return DAO.GetDataByCancelFlowid(orgcode, cancelFlowid)
        End Function

        Public Function UpdateBudgetType(orgcode As String, flowId As String, budgetType As String) As Boolean
            Return DAO.UpdateBudgetType(orgcode, flowId, budgetType) > 0
        End Function
    End Class
End Namespace
