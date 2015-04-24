Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class NocardSetting
        Public DAO As NocardSettingDAO

        Public Sub New()
            DAO = New NocardSettingDAO()
        End Sub

#Region "fields"
        Private _Id As Integer
        Private _Orgcode As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _Start_date As String = String.Empty
        Private _End_date As String = String.Empty
        Private _Start_time As String = String.Empty
        Private _End_time As String = String.Empty
        Private _Nocard_type As String = String.Empty
        Private _Change_userid As String
        Private _Change_date As System.Nullable(Of Date)
        Private _Reason As String = String.Empty
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
        Public Property Nocard_type() As String
            Get
                Return _Nocard_type
            End Get
            Set(ByVal value As String)
                _Nocard_type = value
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
#End Region

        Public Function getDataById(ByVal id As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.GetDataByExample("Nocard_setting", d)
        End Function

        Public Function Insert() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Start_Date", Start_Date)
            d.Add("End_Date", End_Date)
            d.Add("Nocard_type", Nocard_type)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            d.Add("Reason", Reason)
            Return DAO.insertByExample("Nocard_setting", d)
        End Function

        Public Function Update() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Start_Date", Start_Date)
            d.Add("End_Date", End_Date)
            d.Add("Nocard_type", Nocard_type)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            d.Add("Reason", Reason)
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Id", id)
            Return DAO.updateByExample("Nocard_setting", d, cd)
        End Function

        Public Function deleteDataById(ByVal id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.deleteByExample("Nocard_setting", d)
        End Function


        Public Function getDataByQuery(ByVal Orgcode As String, _
                                       ByVal Id_card As String, _
                                       ByVal sdate As String) As DataTable
            Return DAO.getDataByQuery(Orgcode, Id_card, sdate)
        End Function

    End Class
End Namespace