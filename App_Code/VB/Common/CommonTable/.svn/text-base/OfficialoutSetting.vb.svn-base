Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class OfficialoutSetting
        Public DAO As OfficialoutSettingDAO

        Public Sub New()
            DAO = New OfficialoutSettingDAO()
        End Sub

#Region "fields"
        Private _Id As Integer
        Private _Orgcode As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _User_name As String
        Private _Start_date As String = String.Empty
        Private _End_date As String = String.Empty
        Private _Start_time As String = String.Empty
        Private _End_time As String = String.Empty
        Private _Limit_date As String = String.Empty
        Private _Change_userid As String
        Private _Change_date As System.Nullable(Of Date)
#End Region

#Region "Property"
        Public Property Id() As Integer
            Get
                Return Me._Id
            End Get
            Set(value As Integer)
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
        Public Property User_Name() As String
            Get
                Return _User_name
            End Get
            Set(ByVal value As String)
                _User_name = value
            End Set
        End Property
        Public Property Start_Date() As String
            Get
                Return _Start_date
            End Get
            Set(ByVal value As String)
                _Start_date = value
            End Set
        End Property
        Public Property End_Date() As String
            Get
                Return _End_date
            End Get
            Set(ByVal value As String)
                _End_date = value
            End Set
        End Property
        Public Property Start_time() As String
            Get
                Return _Start_time
            End Get
            Set(ByVal value As String)
                _Start_time = value
            End Set
        End Property
        Public Property End_time() As String
            Get
                Return _End_time
            End Get
            Set(ByVal value As String)
                _End_time = value
            End Set
        End Property
        Public Property Limit_date() As String
            Get
                Return _Limit_date
            End Get
            Set(value As String)
                _Limit_date = value
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
#End Region

        Public Function getDataById(ByVal id As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.GetDataByExample("Officialout_setting", d)
        End Function

        Public Function Insert() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("User_name", User_Name)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Start_Date", Start_Date)
            d.Add("End_Date", End_Date)
            d.Add("Limit_date", Limit_date)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            Return DAO.insertByExample("Officialout_setting", d)
        End Function


        Public Function Update() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("User_name", User_Name)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Start_Date", Start_Date)
            d.Add("End_Date", End_Date)
            d.Add("Limit_date", Limit_date)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Id", id)
            Return DAO.updateByExample("Officialout_setting", d, cd)
        End Function


        Public Function deleteDataById(ByVal id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.deleteByExample("Officialout_setting", d)
        End Function

    End Class
End Namespace