Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class NotInPerson
        Inherits BaseDAO
        Public DAO As NotInPersonDAO
        Dim ConnectionString As String = String.Empty
        Public Sub New()
            DAO = New NotInPersonDAO()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            DAO = New NotInPersonDAO(conn)
        End Sub

        Public Sub New(ByVal conn As String)
            MyBase.New(conn)
            Me.ConnectionString = conn
        End Sub

#Region "fields"
        Private _Id As Integer
        Private _Orgcode As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _Not_in_date As String = String.Empty
        Private _Not_in_stime As String = String.Empty
        Private _Not_in_etime As String = String.Empty
        Private _Not_in_hour As Integer
        Private _Change_userid As String
        Private _Change_date As System.Nullable(Of Date)
        Private _Reason As String = String.Empty
        Private _Cancle_flag As String
#End Region

#Region "Property"
        Public Property Id() As Integer
            Get
                Return Me._Id
            End Get
            Set(ByVal value As Integer)
                Me._Id = value
            End Set
        End Property
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
        Public Property Personnel_id() As String
            Get
                Return Me._Personnel_id
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Personnel_id, value) = False) Then
                    Me._Personnel_id = value
                End If
            End Set
        End Property
        Public Property Not_in_date() As String
            Get
                Return _Not_in_date
            End Get
            Set(ByVal value As String)
                _Not_in_date = value
            End Set
        End Property

        Public Property Not_in_stime() As String
            Get
                Return _Not_in_stime
            End Get
            Set(ByVal value As String)
                _Not_in_stime = value
            End Set
        End Property

        Public Property Not_in_etime() As String
            Get
                Return _Not_in_etime
            End Get
            Set(ByVal value As String)
                _Not_in_etime = value
            End Set
        End Property

        Public Property Not_in_hour() As Integer
            Get
                Return _Not_in_hour
            End Get
            Set(ByVal value As Integer)
                _Not_in_hour = value
            End Set
        End Property

        Public Property Change_userid() As String
            Get
                Return Me._Change_userid
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Change_userid, value) = False) Then
                    Me._Change_userid = value
                End If
            End Set
        End Property

        Public Property Change_date() As System.Nullable(Of Date)
            Get
                Return Me._Change_date
            End Get
            Set(ByVal value As System.Nullable(Of Date))
                If (Me._Change_date.Equals(value) = False) Then
                    Me._Change_date = value
                End If
            End Set
        End Property

        Public Property Reason() As String
            Get
                Return Me._Reason
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Reason, value) = False) Then
                    Me._Reason = value
                End If
            End Set
        End Property

        Public Property Cancle_flag() As String
            Get
                Return Me._Cancle_flag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me.Cancle_flag, value) = False) Then
                    Me._Cancle_flag = value
                End If
            End Set
        End Property
#End Region

        Public Function getDataById(ByVal id As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.GetDataByExample("Not_In_Person", d)
        End Function

        Public Function Insert() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Not_in_date", Not_in_date)
            d.Add("Not_in_stime", Not_in_stime)
            d.Add("Not_in_etime", Not_in_etime)
            d.Add("Not_in_hour", Not_in_hour)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            d.Add("Reason", Reason)
            d.Add("Cancle_flag", "N")
            Return DAO.insertByExample("Not_In_Person", d)
        End Function

        Public Function Update() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Not_in_date", Not_in_date)
            d.Add("Not_in_stime", Not_in_stime)
            d.Add("Not_in_etime", Not_in_etime)
            d.Add("Not_in_hour", Not_in_hour)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            d.Add("Reason", Reason)
            d.Add("Cancle_flag", Cancle_flag)
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Id", Id)
            Return DAO.updateByExample("Not_In_Person", d, cd)
        End Function

        Public Function deleteDataById(ByVal id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.deleteByExample("Not_In_Person", d)
        End Function


        Public Function getDataByQuery(ByVal Orgcode As String, _
                                       ByVal Id_card As String, _
                                       ByVal sdate As String) As DataTable
            Return DAO.getDataByQuery(Orgcode, Id_card, sdate)
        End Function

        Public Function GetCountByNotInStime(ByVal Orgcode As String, _
                               ByVal Id_card As String, _
                               ByVal Not_in_date As String, _
                               ByVal Not_in_stime As String, _
                               ByVal Not_in_etime As String) As Object
            Return DAO.GetCountByNotInStime(Orgcode, Id_card, Not_in_date, Not_in_stime, Not_in_etime)
        End Function

        Public Function UpdateCancleFlag(ByVal Orgcode As String, _
                               ByVal Id As String) As Object
            Return DAO.UpdateCancleFlag(Orgcode, Id)
        End Function

    End Class
End Namespace