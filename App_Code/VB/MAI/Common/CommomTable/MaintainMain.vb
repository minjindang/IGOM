Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainMain
        Private DAO As MaintainMainDAO

#Region "Property"
        Private _Id As Integer
        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value
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
        Private _Flow_id As String
        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property
        Private _Apply_ext As String
        Public Property Apply_ext() As String
            Get
                Return _Apply_ext
            End Get
            Set(ByVal value As String)
                _Apply_ext = value
            End Set
        End Property
        Private _Apply_idcard As String
        Public Property Apply_idcard() As String
            Get
                Return _Apply_idcard
            End Get
            Set(ByVal value As String)
                _Apply_idcard = value
            End Set
        End Property
        Private _Apply_name As String
        Public Property Apply_name() As String
            Get
                Return _Apply_name
            End Get
            Set(ByVal value As String)
                _Apply_name = value
            End Set
        End Property
        Private _Maintain_kind As String
        Public Property Maintain_kind() As String
            Get
                Return _Maintain_kind
            End Get
            Set(ByVal value As String)
                _Maintain_kind = value
            End Set
        End Property
        Private _Maintain_type As String
        Public Property Maintain_type() As String
            Get
                Return _Maintain_type
            End Get
            Set(ByVal value As String)
                _Maintain_type = value
            End Set
        End Property
        Private _Problem_desc As String
        Public Property Problem_desc() As String
            Get
                Return _Problem_desc
            End Get
            Set(ByVal value As String)
                _Problem_desc = value
            End Set
        End Property
        Private _Apply_departid As String
        Public Property Apply_departid() As String
            Get
                Return _Apply_departid
            End Get
            Set(ByVal value As String)
                _Apply_departid = value
            End Set
        End Property
        Private _Apply_date As String
        Public Property Apply_date() As String
            Get
                Return _Apply_date
            End Get
            Set(ByVal value As String)
                _Apply_date = value
            End Set
        End Property
        Private _Writer_ext As String
        Public Property Writer_ext() As String
            Get
                Return _Writer_ext
            End Get
            Set(ByVal value As String)
                _Writer_ext = value
            End Set
        End Property
        Private _Writer_departid As String
        Public Property Writer_departid() As String
            Get
                Return _Writer_departid
            End Get
            Set(ByVal value As String)
                _Writer_departid = value
            End Set
        End Property
        Private _Writer_idcard As String
        Public Property Writer_idcard() As String
            Get
                Return _Writer_idcard
            End Get
            Set(ByVal value As String)
                _Writer_idcard = value
            End Set
        End Property
        Private _Writer_name As String
        Public Property Writer_name() As String
            Get
                Return _Writer_name
            End Get
            Set(ByVal value As String)
                _Writer_name = value
            End Set
        End Property

        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Private _Change_date As Date = Now
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
        Private _Maintain_step As Integer?
        Public Property Maintain_step() As Integer?
            Get
                Return _Maintain_step
            End Get
            Set(ByVal value As Integer?)
                _Maintain_step = value
            End Set
        End Property

#End Region

        Public Sub New()
            DAO = New MaintainMainDAO()
        End Sub

        Public Function Insert() As Boolean
            Id = DAO.InsertData(Me)
            Return Id > 0
        End Function

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Return DAO.GetDataByOrgFid(orgcode, flowId)
        End Function

        Public Function GetObject(orgcode As String, flowId As String) As MaintainMain
            Dim dt As DataTable = GetDataByOrgFid(orgcode, flowId)

            Dim list As List(Of MaintainMain) = CommonFun.ConvertToList(Of MaintainMain)(dt)

            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If

            Return Nothing
        End Function

        Public Function Update() As Boolean
            Return DAO.UpdateData(Me) > 0
        End Function

        Public Function Update(Maintain_kind As String, Maintain_type As String, Id As Integer) As Boolean
            Return DAO.UpdateData(Maintain_kind, Maintain_type, Id) > 0
        End Function

        Public Function Update(Maintain_step As Integer, Id As Integer) As Boolean
            Return DAO.UpdateData(Maintain_step, Id) > 0
        End Function

    End Class
End Namespace