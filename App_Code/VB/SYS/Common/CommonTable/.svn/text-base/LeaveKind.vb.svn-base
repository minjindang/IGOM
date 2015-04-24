Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class LeaveKind

        Private _Orgcode As String
        Private _Leave_kind As String
        Private _Kind_name As String
        Private _Depart_id As String
        Private _Change_userid As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Leave_kind() As String
            Get
                Return _Leave_kind
            End Get
            Set(ByVal value As String)
                _Leave_kind = value
            End Set
        End Property
        Public Property Kind_name() As String
            Get
                Return _Kind_name
            End Get
            Set(ByVal value As String)
                _Kind_name = value
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property


        Public DAO As LeaveKindDAO

        Public Sub New()
            DAO = New LeaveKindDAO
        End Sub

        Public Sub New(ByVal constr As String)
            DAO = New LeaveKindDAO(constr)
        End Sub


        Public Function Insert() As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("Leave_kind", Leave_kind)
            d.Add("Kind_name", Kind_name)
            d.Add("Change_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
            d.Add("Change_date", Date.Now.ToString("yyyy/MM/dd HH:mm:ss"))

            Return DAO.InsertByExample("SYS_Leave_kind", d) >= 1

        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String) As DataTable

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)

            If Not String.IsNullOrEmpty(Depart_id) Then
                d.Add("Depart_id", Depart_id)
            End If

            Return DAO.GetDataByExample("SYS_Leave_kind", d)
        End Function

        Public Function DeleteById(ByVal id As String) As Boolean
            Return DAO.DeleteById(id) = 1
        End Function
    End Class
End Namespace
