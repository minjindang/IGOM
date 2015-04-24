Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class PaperForm
        Private DAO As PaperFormDAO

        Public Sub New()
            DAO = New PaperFormDAO()
        End Sub

#Region "Properity"
        Private _FlowId As String
        Public Property FlowId() As String
            Get
                Return _FlowId
            End Get
            Set(ByVal value As String)
                _FlowId = value
            End Set
        End Property
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Private _DepartId As String
        Public Property DepartId() As String
            Get
                Return _DepartId
            End Get
            Set(ByVal value As String)
                _DepartId = value
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

        Private _reason As String
        Public Property Reason() As String
            Get
                Return _reason
            End Get
            Set(ByVal value As String)
                _reason = value
            End Set
        End Property
        Private _paperId As String
        Public Property PaperId() As String
            Get
                Return _paperId
            End Get
            Set(ByVal value As String)
                _paperId = value
            End Set
        End Property
        Private _paperName As String
        Public Property PaperName() As String
            Get
                Return _paperName
            End Get
            Set(ByVal value As String)
                _paperName = value
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
        Private _FilePath As String
        Public Property FilePath() As String
            Get
                Return _FilePath
            End Get
            Set(ByVal value As String)
                _FilePath = value
            End Set
        End Property
        Private _FileName As String
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property

#End Region

        Public Function InsertData() As Boolean
            Return DAO.InsertData(Me) > 0
        End Function

        Public Function UpdateData() As Boolean
            Return DAO.UpdateData(Me) > 0
        End Function

        Public Function getDataByOrgFid() As DataTable
            Return DAO.getDataByOrgFid(Me)
        End Function
    End Class
End Namespace