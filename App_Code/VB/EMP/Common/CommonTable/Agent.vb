Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace EMP.Logic
    Public Class Agent
        Public DAO As AgentDAO

        Public Sub New()
            DAO = New AgentDAO()
        End Sub

#Region "Property"
        Private _Agent_idcard As String
        Public Property Agent_idcard() As String
            Get
                Return _Agent_idcard
            End Get
            Set(ByVal value As String)
                _Agent_idcard = value
            End Set
        End Property

        Private _Agent_Orgcode As String
        Public Property Agent_Orgcode() As String
            Get
                Return _Agent_Orgcode
            End Get
            Set(ByVal value As String)
                _Agent_Orgcode = value
            End Set
        End Property

        Private _Id_card As String
        Public Property Id_card() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
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

        Private _Agent_sdate As String
        Public Property Agent_sdate() As String
            Get
                Return _Agent_sdate
            End Get
            Set(ByVal value As String)
                _Agent_sdate = value
            End Set
        End Property

        Private _Agent_stime As String
        Public Property Agent_stime() As String
            Get
                Return _Agent_stime
            End Get
            Set(ByVal value As String)
                _Agent_stime = value
            End Set
        End Property

        Private _Agent_edate As String
        Public Property Agent_edate() As String
            Get
                Return _Agent_edate
            End Get
            Set(ByVal value As String)
                _Agent_edate = value
            End Set
        End Property

        Private _Agent_etime As String
        Public Property Agent_etime() As String
            Get
                Return _Agent_etime
            End Get
            Set(ByVal value As String)
                _Agent_etime = value
            End Set
        End Property

        Private _Note_desc As String
        Public Property Note_desc() As String
            Get
                Return _Note_desc
            End Get
            Set(ByVal value As String)
                _Note_desc = value
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
            d.Add("Agent_idcard", Agent_idcard)
            d.Add("Agent_Orgcode", Agent_Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Orgcode", Orgcode)
            d.Add("Agent_sdate", Agent_sdate)
            d.Add("Agent_stime", Agent_stime)
            d.Add("Agent_edate", Agent_edate)
            d.Add("Agent_etime", Agent_etime)
            d.Add("Note_desc", Note_desc)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("EMP_Agent", d)
        End Function

    End Class
End Namespace