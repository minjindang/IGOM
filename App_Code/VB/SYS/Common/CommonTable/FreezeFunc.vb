Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class FreezeFunc

#Region "property"
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

        Private _Depart_id As String
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property

        Private _Func_id As String
        Public Property Func_id() As String
            Get
                Return _Func_id
            End Get
            Set(ByVal value As String)
                _Func_id = value
            End Set
        End Property

        Private _isFreeze As String
        Public Property isFreeze() As String
            Get
                Return _isFreeze
            End Get
            Set(ByVal value As String)
                _isFreeze = value
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
#End Region
        
        Public DAO As FreezeFuncDAO
        Public Sub New()
            DAO = New FreezeFuncDAO()
        End Sub

        Public Function getFreezeData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ProgramName As String) As DataTable
            Return DAO.getFreezeData(Orgcode, Depart_id, ProgramName)
        End Function
    End Class
End Namespace
