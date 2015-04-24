Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic

    Public Class FlowDetail
        Dim DAO As FlowDetailDAO

#Region "Property"
        Private _Orgcode As String
        Private _flowId As String
        Private _LastOrgcode As String
        Private _lastDepartid As String
        Private _lastPosid As String
        Private _lastIdcard As String
        Private _lastName As String
        Private _agreeTime As Date? = Nothing
        Private _agreeFlag As Integer
        Private _Comment As String
        Private _lastDate As Date? = Nothing
        Private _lastPass As Integer
        Private _replaceOrgcode As String
        Private _replaceDepartid As String
        Private _replacePosid As String
        Private _replaceIdcard As String
        Private _replaceName As String
        Private _replaceflag As String
        Private _deputyFlag As String
        Private _changeUserid As String
        Private _changeDate As Date = Now

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

        Public Property FlowId() As String
            Get
                Return _flowId
            End Get
            Set(ByVal value As String)
                _flowId = value
            End Set
        End Property

        Public Property LastOrgcode() As String
            Get
                Return _LastOrgcode
            End Get
            Set(ByVal value As String)
                _LastOrgcode = value
            End Set
        End Property

        Public Property LastDepartid() As String
            Get
                Return _lastDepartid
            End Get
            Set(ByVal value As String)
                _lastDepartid = value
            End Set
        End Property

        Public Property LastPosid() As String
            Get
                Return _lastPosid
            End Get
            Set(ByVal value As String)
                _lastPosid = value
            End Set
        End Property

        Public Property LastIdcard() As String
            Get
                Return _lastIdcard
            End Get
            Set(ByVal value As String)
                _lastIdcard = value
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return _lastName
            End Get
            Set(ByVal value As String)
                _lastName = value
            End Set
        End Property

        Public Property AgreeTime() As Date?
            Get
                Return _agreeTime
            End Get
            Set(ByVal value As Date?)
                _agreeTime = value
            End Set
        End Property

        Public Property AgreeFlag() As Integer
            Get
                Return _agreeFlag
            End Get
            Set(ByVal value As Integer)
                _agreeFlag = value
            End Set
        End Property

        Public Property Comment() As String
            Get
                Return _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property

        Public Property LastDate() As Date?
            Get
                Return _lastDate
            End Get
            Set(ByVal value As Date?)
                _lastDate = value
            End Set
        End Property

        Public Property LastPass() As Integer
            Get
                Return _lastPass
            End Get
            Set(ByVal value As Integer)
                _lastPass = value
            End Set
        End Property

        Public Property ReplaceOrgcode() As String
            Get
                Return _replaceOrgcode
            End Get
            Set(ByVal value As String)
                _replaceOrgcode = value
            End Set
        End Property

        Public Property ReplaceDepartid() As String
            Get
                Return _replaceDepartid
            End Get
            Set(ByVal value As String)
                _replaceDepartid = value
            End Set
        End Property

        Public Property ReplacePosid() As String
            Get
                Return _replacePosid
            End Get
            Set(ByVal value As String)
                _replacePosid = value
            End Set
        End Property

        Public Property ReplaceIdcard() As String
            Get
                Return _replaceIdcard
            End Get
            Set(ByVal value As String)
                _replaceIdcard = value
            End Set
        End Property

        Public Property ReplaceName() As String
            Get
                Return _replaceName
            End Get
            Set(ByVal value As String)
                _replaceName = value
            End Set
        End Property

        Public Property ReplaceFlag() As String
            Get
                Return _replaceflag
            End Get
            Set(ByVal value As String)
                _replaceflag = value
            End Set
        End Property

        Public Property DeputyFlag() As String
            Get
                Return _deputyFlag
            End Get
            Set(ByVal value As String)
                _deputyFlag = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>            ' 
        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(ByVal value As String)
                _changeUserid = value
            End Set
        End Property
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks> 
        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal value As Date)
                _changeDate = value
            End Set
        End Property

        Private _AgreeStep As Integer
        Public Property AgreeStep() As Integer
            Get
                Return _AgreeStep
            End Get
            Set(ByVal value As Integer)
                _AgreeStep = value
            End Set
        End Property

        Private _ResendFlag As String
        Public Property ResendFlag() As String
            Get
                Return _ResendFlag
            End Get
            Set(ByVal value As String)
                _ResendFlag = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New FlowDetailDAO
        End Sub

        Public Function GetDataByFlow_id(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByFlow_id(Orgcode, Flow_id)
            Return dt
        End Function

        Public Function GetDataByQuery(ByVal Flow_id As String, ByVal Orgcode As String, ByVal Last_id As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByQuery(Flow_id, Orgcode, Last_id)
            Return dt
        End Function

        Public Function GetLastDataByFlow_id(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim dt As DataTable = DAO.GetMaxDataByFlow_id(Orgcode, Flow_id)
            Return dt
        End Function

        Public Function InsertFlowDetail() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function UpdateFlowDetailForFeb(ByVal Flow_id As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal Last_id As String) As Boolean
            Return DAO.UpdateFlowDetailForFeb(Flow_id, Orgcode, Depart_id, Last_id) >= 1
        End Function

        Public Function CancelLastData(ByVal Orgcode As String, ByVal Flow_id As String) As Boolean
            Return DAO.CancelLastData(Orgcode, Flow_id) >= 1
        End Function

        ''' <summary>
        ''' 修改重送
        ''' </summary>
        ''' <param name="Flow_id"></param>
        ''' <param name="Orgcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateLastData(ByVal Orgcode As String, ByVal Flow_id As String) As Boolean
            Return DAO.UpdateLastData(Orgcode, Flow_id)
        End Function

        Public Function GetDataByAgreeStep(orgcode As String, flowId As String, agreeStep As Integer) As DataTable
            Return DAO.GetDataByAgreeStep(orgcode, flowId, agreeStep)
        End Function

        Public Function GetObjects(orgcode As String, flowId As String) As List(Of SYS.Logic.FlowDetail)
            Dim dt As DataTable = GetDataByFlow_id(orgcode, flowId)

            Dim list As List(Of SYS.Logic.FlowDetail) = CommonFun.ConvertToList(Of SYS.Logic.FlowDetail)(dt)

            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list
            End If

            Return Nothing
        End Function
    End Class
End Namespace