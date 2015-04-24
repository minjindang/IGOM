Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class UnusualCorrect
        Private DAO As UnusualCorrectDAO

#Region "fields"
        Private _orgcode As String
        Private _id_card As String
        Private _pkwdate As String
        Private _pkwktpe As String
        Private _reason As String
        Private _change_userid As String
#End Region

#Region "property"
        Public Property orgcode() As String
            Get
                Return Me._orgcode
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._orgcode, value) = False) Then
                    Me._orgcode = value
                End If
            End Set
        End Property
        Public Property id_card() As String
            Get
                Return Me._id_card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._id_card, value) = False) Then
                    Me._id_card = value
                End If
            End Set
        End Property
        Public Property pkwdate() As String
            Get
                Return _pkwdate
            End Get
            Set(value As String)
                _pkwdate = value
            End Set
        End Property
        Public Property pkwktpe As String
            Get
                Return _pkwktpe
            End Get
            Set(value As String)
                _pkwktpe = value
            End Set
        End Property
        Public Property reason() As String
            Get
                Return _reason
            End Get
            Set(value As String)
                _reason = value
            End Set
        End Property

        Public Property change_userid() As String
            Get
                Return Me._change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._change_userid, value) = False) Then
                    Me._change_userid = value
                End If
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New UnusualCorrectDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("orgcode", orgcode)
            d.Add("id_card", id_card)
            d.Add("pkwdate", pkwdate)
            d.Add("pkwktpe", pkwktpe)
            d.Add("reason", reason)
            d.Add("change_userid", change_userid)
            d.Add("change_date", Now)
            Return DAO.InsertByExample("FSC_Unusual_correct", d) > 0
        End Function

        Public Function getLastData(ByVal id_card As String, ByVal pkwdate As String) As DataTable
            Return DAO.getLastData(id_card, pkwdate)
        End Function

    End Class
End Namespace
