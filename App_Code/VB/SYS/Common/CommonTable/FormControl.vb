Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class FormControl
        Public DAO As FormControlDAO

        Public Sub New()
            DAO = New FormControlDAO
        End Sub

#Region "property"
        Private _Form_id As String
        Public Property Form_id() As String
            Get
                Return _Form_id
            End Get
            Set(ByVal value As String)
                _Form_id = value
            End Set
        End Property

        Private _isCancel As String
        Public Property isCancel() As String
            Get
                Return _isCancel
            End Get
            Set(ByVal value As String)
                _isCancel = value
            End Set
        End Property

        Private _isBossApprove As String
        Public Property isBossApprove() As String
            Get
                Return _isBossApprove
            End Get
            Set(ByVal value As String)
                _isBossApprove = value
            End Set
        End Property

        Private _isDelete As String
        Public Property isDelete() As String
            Get
                Return _isDelete
            End Get
            Set(ByVal value As String)
                _isDelete = value
            End Set
        End Property

#End Region

        Public Function getDataByFormId(ByVal Form_id As String) As DataTable
            Return DAO.getDataByFormId(Form_id)
        End Function

        Public Function getObject(ByVal Form_id As String) As FormControl
            Dim dt As DataTable = DAO.getDataByFormId(Form_id)
            Dim list As List(Of FormControl) = CommonFun.ConvertToList(Of FormControl)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If
            Return Nothing
        End Function
    End Class
End Namespace
