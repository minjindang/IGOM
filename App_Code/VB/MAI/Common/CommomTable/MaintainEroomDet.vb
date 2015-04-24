﻿Imports Microsoft.VisualBasic
Imports System.Data

Namespace MAI.Logic
    Public Class MaintainEroomDet
        Private DAO As MaintainEroomDetDAO
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
        Private _Main_id As Integer
        Public Property Main_id() As Integer
            Get
                Return _Main_id
            End Get
            Set(ByVal value As Integer)
                _Main_id = value
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
        Private _Company As String
        Public Property Company() As String
            Get
                Return _Company
            End Get
            Set(ByVal value As String)
                _Company = value
            End Set
        End Property
        Private _User_name As String
        Public Property User_name() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property
        Private _Phone As String
        Public Property Phone() As String
            Get
                Return _Phone
            End Get
            Set(ByVal value As String)
                _Phone = value
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
#End Region

        Public Sub New()
            DAO = New MaintainEroomDetDAO()
        End Sub

        Public Function Insert() As Boolean
            Return DAO.InsertData(Me) > 0
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Return DAO.GetDataByMainId(mainId)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Boolean
            Return DAO.DeleteDataByMainId(mainId) > 0
        End Function
    End Class
End Namespace