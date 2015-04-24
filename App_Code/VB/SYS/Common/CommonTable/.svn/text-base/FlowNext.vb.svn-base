Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FlowNext
        Dim DAO As FlowNextDAO

        Public Sub New()
            DAO = New FlowNextDAO()
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
        Private _nextOrgcode As String
        Public Property NextOrgcode() As String
            Get
                Return _nextOrgcode
            End Get
            Set(ByVal value As String)
                _nextOrgcode = value
            End Set
        End Property
        Private _nextDepartid As String
        Public Property NextDepartid() As String
            Get
                Return _nextDepartid
            End Get
            Set(ByVal value As String)
                _nextDepartid = value
            End Set
        End Property
        Private _nextPosid As String
        Public Property NextPosid() As String
            Get
                Return _nextPosid
            End Get
            Set(ByVal value As String)
                _nextPosid = value
            End Set
        End Property
        Private _nextIdcard As String
        Public Property NextIdcard() As String
            Get
                Return _nextIdcard
            End Get
            Set(ByVal value As String)
                _nextIdcard = value
            End Set
        End Property
        Private _nextName As String
        Public Property NextName() As String
            Get
                Return _nextName
            End Get
            Set(ByVal value As String)
                _nextName = value
            End Set
        End Property
        Private _nextStep As Integer
        Public Property NextStep() As Integer
            Get
                Return _nextStep
            End Get
            Set(ByVal value As Integer)
                _nextStep = value
            End Set
        End Property
        Private _groupId As Integer
        Public Property GroupId() As Integer
            Get
                Return _groupId
            End Get
            Set(ByVal value As Integer)
                _groupId = value
            End Set
        End Property
        Private _groupStep As Integer
        Public Property GroupStep() As Integer
            Get
                Return _groupStep
            End Get
            Set(ByVal value As Integer)
                _groupStep = value
            End Set
        End Property
        Private _customFlag As String
        Public Property CustomFlag() As String
            Get
                Return _customFlag
            End Get
            Set(ByVal value As String)
                _customFlag = value
            End Set
        End Property
        Private _replaceFlag As String
        Public Property ReplaceFlag() As String
            Get
                Return _replaceFlag
            End Get
            Set(ByVal value As String)
                _replaceFlag = value
            End Set
        End Property
        Private _replaceOrgcode As String
        Public Property ReplaceOrgcode() As String
            Get
                Return _replaceOrgcode
            End Get
            Set(ByVal value As String)
                _replaceOrgcode = value
            End Set
        End Property
        Private _replaceDepartid As String
        Public Property ReplaceDepartid() As String
            Get
                Return _replaceDepartid
            End Get
            Set(ByVal value As String)
                _replaceDepartid = value
            End Set
        End Property
        Private _replacePosid As String
        Public Property ReplacePosid() As String
            Get
                Return _replacePosid
            End Get
            Set(ByVal value As String)
                _replacePosid = value
            End Set
        End Property
        Private _replaceIdcard As String
        Public Property ReplaceIdcard() As String
            Get
                Return _replaceIdcard
            End Get
            Set(ByVal value As String)
                _replaceIdcard = value
            End Set
        End Property
        Private _replaceName As String
        Public Property ReplaceName() As String
            Get
                Return _replaceName
            End Get
            Set(ByVal value As String)
                _replaceName = value
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
        Private _mailFlag As String
        Public Property MailFlag() As String
            Get
                Return _mailFlag
            End Get
            Set(ByVal value As String)
                _mailFlag = value
            End Set
        End Property
        Private _DeputyFlag As String
        Public Property DeputyFlag() As String
            Get
                Return _DeputyFlag
            End Get
            Set(ByVal value As String)
                _DeputyFlag = value
            End Set
        End Property

#End Region

        Public Function Insert() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function GetData(orgcode As String, flowId As String, nextOrgcode As String, nextDepartid As String, nextIdcard As String, nextStep As String) As DataTable
            Return DAO.GetData(orgcode, flowId, nextOrgcode, nextDepartid, nextIdcard, nextStep)
        End Function

        Public Function GetDataByOrgFid(ByVal orgcode As String, ByVal flowId As String) As DataTable
            Return DAO.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function GetObjects(ByVal orgcode As String, ByVal flowId As String) As List(Of SYS.Logic.FlowNext)
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)
            Return CommonFun.ConvertToList(Of SYS.Logic.FlowNext)(dt)
        End Function

        Public Function GetObject(orgcode As String, flowId As String, nextOrgcode As String, nextDepartid As String, nextIdcard As String, nextStep As String) As FlowNext
            Dim dt As DataTable = GetData(orgcode, flowId, nextOrgcode, nextDepartid, nextIdcard, nextStep)
            Dim list As List(Of SYS.Logic.FlowNext) = CommonFun.ConvertToList(Of SYS.Logic.FlowNext)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If
            Return Nothing
        End Function

        Public Function Delete(ByVal orgcode As String, ByVal flowId As String) As Boolean
            Return DAO.DeleteData(orgcode, flowId)
        End Function

        Public Function Delete(ByVal orgcode As String, ByVal departId As String, ByVal groupId As String) As Boolean
            Return DAO.DeleteData(orgcode, departId, groupId)
        End Function

        Public Function getDataByFid(ByVal flow_id As String) As DataTable
            Return DAO.getDataByFid(flow_id)
        End Function

        Public Function UpdateNextById(id As Integer, nextOrgcode As String, nextDepartid As String, nextIdcard As String, nextPosid As String, nextName As String) As Boolean
            Return DAO.UpdateNextById(id, nextOrgcode, nextDepartid, nextIdcard, nextPosid, nextName) > 0
        End Function
    End Class
End Namespace