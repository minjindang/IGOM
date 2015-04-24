Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class CommonPhrases

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

        Private _phrases_kind As String
        Public Property phrases_kind() As String
            Get
                Return _phrases_kind
            End Get
            Set(ByVal value As String)
                _phrases_kind = value
            End Set
        End Property

        Private _phrases_type As String
        Public Property phrases_type() As String
            Get
                Return _phrases_type
            End Get
            Set(ByVal value As String)
                _phrases_type = value
            End Set
        End Property

        Private _phrases As String
        Public Property phrases() As String
            Get
                Return _phrases
            End Get
            Set(ByVal value As String)
                _phrases = value
            End Set
        End Property

        Private _phrases_seq As Integer
        Public Property phrases_seq() As String
            Get
                Return _phrases_seq
            End Get
            Set(ByVal value As String)
                _phrases_seq = value
            End Set
        End Property

        Private _visable_flag As String
        Public Property visable_flag() As String
            Get
                Return _visable_flag
            End Get
            Set(ByVal value As String)
                _visable_flag = value
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

        Public DAO As CommonPhrasesDAO
        Public Sub New()
            DAO = New CommonPhrasesDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("phrases_kind", phrases_kind)
            d.Add("phrases_type", phrases_type)
            d.Add("phrases", phrases)
            d.Add("phrases_seq", phrases_seq)
            d.Add("visable_flag", visable_flag)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("SYS_Common_phrases", d)
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("phrases_kind", phrases_kind)
            d.Add("phrases_type", phrases_type)
            d.Add("phrases", phrases)
            d.Add("phrases_seq", phrases_seq)
            d.Add("visable_flag", visable_flag)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("SYS_Common_phrases", d, cd)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return DAO.DeleteByExample("SYS_Common_phrases", d)
        End Function

        Public Function getDataByid() As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return DAO.GetDataByExample("SYS_Common_phrases", d)
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal phrases_kind As String, ByVal phrases_type As String, _
                                ByVal phrases As String, ByVal visable_flag As String) As DataTable
            Return DAO.getData(Orgcode, phrases_kind, phrases_type, phrases, visable_flag)
        End Function
    End Class
End Namespace
