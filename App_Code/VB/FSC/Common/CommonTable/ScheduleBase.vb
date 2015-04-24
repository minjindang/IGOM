Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class ScheduleBase
        Private DAO As ScheduleBaseDAO

#Region "property"
        Private _Orgcode As String
        Private _Depart_id As String
        Private _Sub_depart_id As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _User_name As String
        Private _Sche_date As String
        Private _Sche_type As String
        Private _Schedule_id As String
        Private _Change_userid As String
        Private _Change_date As Date = Now
        Public Property Orgcode() As String
            Get
                Return Me._Orgcode
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Orgcode, value) = False) Then
                    Me._Orgcode = value
                End If
            End Set
        End Property
        Public Property Depart_id() As String
            Get
                Return Me._Depart_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Depart_id, value) = False) Then
                    Me._Depart_id = value
                End If
            End Set
        End Property
        Public Property Id_card() As String
            Get
                Return Me._Id_card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Id_card, value) = False) Then
                    Me._Id_card = value
                End If
            End Set
        End Property
        Property User_name() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property
        Property Sche_date() As String
            Get
                Return _Sche_date
            End Get
            Set(ByVal value As String)
                _Sche_date = value
            End Set
        End Property
        Property Sche_type() As String
            Get
                Return _Sche_type
            End Get
            Set(ByVal value As String)
                _Sche_type = value
            End Set
        End Property
        Property Schedule_id() As String
            Get
                Return _Schedule_id
            End Get
            Set(ByVal value As String)
                _Schedule_id = value
            End Set
        End Property
        Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New ScheduleBaseDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Me.Orgcode)
            d.Add("Depart_id", Me.Depart_id)
            d.Add("Id_card", Me.Id_card)
            d.Add("User_name", Me.User_name)
            d.Add("Sche_date", Me.Sche_date)
            d.Add("Sche_type", Me.Sche_type)
            d.Add("Schedule_id", Me.Schedule_id)
            d.Add("Change_userid", Me.Change_userid)
            d.Add("Change_date", Me.Change_date)
            Return DAO.InsertByExample("FSC_Schedule_base", d) > 0
        End Function

        Public Function DeleteData(ByVal orgcode As String, ByVal yyymm As String, ByVal scheduleId As String) As Boolean
            Return DAO.DeleteData(orgcode, yyymm, scheduleId) > 0
        End Function

    End Class
End Namespace