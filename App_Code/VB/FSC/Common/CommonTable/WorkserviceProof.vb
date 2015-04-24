Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class WorkserviceProof
        Dim DAO As WorkserviceProofDAO

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
        Private _idCard As String
        Public Property IdCard() As String
            Get
                Return _idCard
            End Get
            Set(ByVal value As String)
                _idCard = value
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
        Private _applyDate As String
        Public Property ApplyDate() As String
            Get
                Return _applyDate
            End Get
            Set(ByVal value As String)
                _applyDate = value
            End Set
        End Property
        Private _applyType As String
        Public Property ApplyType() As String
            Get
                Return _applyType
            End Get
            Set(ByVal value As String)
                _applyType = value
            End Set
        End Property
        Private _applyCopies As String
        Public Property ApplyCopies() As String
            Get
                Return _applyCopies
            End Get
            Set(ByVal value As String)
                _applyCopies = value
            End Set
        End Property
        Private _purpose As String
        Public Property Purpose() As String
            Get
                Return _purpose
            End Get
            Set(ByVal value As String)
                _purpose = value
            End Set
        End Property
        Private _notes As String
        Public Property Notes() As String
            Get
                Return _notes
            End Get
            Set(ByVal value As String)
                _notes = value
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

#End Region

        Public Sub New()
            DAO = New WorkserviceProofDAO
        End Sub

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Return DAO.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function GetObjects(orgcode As String, flowId As String) As List(Of WorkserviceProof)
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)
            Return CommonFun.ConvertToList(Of WorkserviceProof)(dt)
        End Function

        Public Function UpdateData() As Boolean
            Return DAO.UpdateData(Me)
        End Function
    End Class
End Namespace