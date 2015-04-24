Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    Public Class ExtensionSetting
        Public DAO As ExtensionSettingDAO

        Public Sub New()
            DAO = New ExtensionSettingDAO()
        End Sub

#Region "fields"
        Private _Id As Integer
        Private _Orgcode As String
        Private _Id_card As String
        Private _Personnel_id As String
        Private _Occurred_date As String = String.Empty
        Private _Extension_date As String = String.Empty
        Private _Extension_reason As String = String.Empty
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
        Public Property Occurred_date() As String
            Get
                Return _Occurred_date
            End Get
            Set(ByVal value As String)
                _Occurred_date = value
            End Set
        End Property
        Public Property Extension_date() As String
            Get
                Return _Extension_date
            End Get
            Set(ByVal value As String)
                _Extension_date = value
            End Set
        End Property
        Public Property Extension_reason() As String
            Get
                Return _Extension_reason
            End Get
            Set(ByVal value As String)
                _Extension_reason = value
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
            Return DAO.GetDataByExample("Extension_setting", d)
        End Function


        Public Function getData(ByVal Orgcode As String, _
                                ByVal Id_card As String, _
                                ByVal Occurred_date As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Occurred_date", Occurred_date)
            Return DAO.GetDataByExample("Extension_setting", d)
        End Function

        Public Function Insert() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Occurred_date", Occurred_date)
            d.Add("Extension_date", Extension_date)
            d.Add("Extension_reason", Extension_reason)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            Return DAO.insertByExample("Extension_setting", d)
        End Function


        Public Function Update() As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Personnel_id", Personnel_id)
            d.Add("Occurred_date", Occurred_date)
            d.Add("Extension_date", Extension_date)
            d.Add("Extension_reason", Extension_reason)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Id", Id)
            Return DAO.updateByExample("Extension_setting", d, cd)
        End Function


        Public Function deleteDataById(ByVal id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)
            Return DAO.deleteByExample("Extension_setting", d)
        End Function

    End Class
End Namespace