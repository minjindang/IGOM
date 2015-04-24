Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic
    Public Class TemporarilyTransfe
        Private DAO As TemporarilyTransfeDAO

        Public Sub New()
            DAO = New TemporarilyTransfeDAO
        End Sub

#Region "property"
        Private _id As Integer
        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Private _id_card As String
        Public Property id_card() As String
            Get
                Return _id_card
            End Get
            Set(ByVal value As String)
                _id_card = value
            End Set
        End Property

        Private _Start_date As String
        Public Property Start_date() As String
            Get
                Return _Start_date
            End Get
            Set(ByVal value As String)
                _Start_date = value
            End Set
        End Property

        Private _End_date As String
        Public Property End_date() As String
            Get
                Return _End_date
            End Get
            Set(ByVal value As String)
                _End_date = value
            End Set
        End Property

        Private _Memo As String
        Public Property Memo() As String
            Get
                Return _Memo
            End Get
            Set(ByVal value As String)
                _Memo = value
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

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id_card", id_card)
            d.Add("Start_date", Start_date)
            d.Add("End_date", End_date)
            d.Add("Memo", Memo)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_temporarily_transfe", d)
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id_card", id_card)
            d.Add("Start_date", Start_date)
            d.Add("End_date", End_date)
            d.Add("Memo", Memo)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("FSC_temporarily_transfe", d, cd)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return DAO.DeleteByExample("FSC_temporarily_transfe", d)
        End Function

        Public Function getDataByIdcard(ByVal id_card As String) As DataTable
            Return DAO.getDataByIdcard(id_card)
        End Function

        Public Function getData(ByVal id_card As String, ByVal currentDate As String) As DataTable
            Return DAO.getData(id_card, currentDate)
        End Function

        Public Function getCount(ByVal id_card As String, ByVal currentDate As String) As Integer
            Dim dt As DataTable = DAO.getData(id_card, currentDate)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows.Count
            End If

            Return 0
        End Function
    End Class
End Namespace
