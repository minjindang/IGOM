Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace SYS.Logic
    Public Class FormSetting
        Public DAO As FormSettingDAO

#Region "Property"
        Private _ID As Integer
        Public Property id() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal value As Integer)
                _ID = value
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

        Private _Describe As String
        Public Property Describe() As String
            Get
                Return _Describe
            End Get
            Set(ByVal value As String)
                _Describe = value
            End Set
        End Property

        Private _Ifattach_flag As String
        Public Property Ifattach_flag() As String
            Get
                Return _Ifattach_flag
            End Get
            Set(ByVal value As String)
                _Ifattach_flag = value
            End Set
        End Property

        Private _Form_id As String
        Public Property Form_id() As String
            Get
                Return _Form_id
            End Get
            Set(ByVal value As String)
                _Form_id = value
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
            DAO = New FormSettingDAO
        End Sub

        Public Function Insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Form_id", Form_id)
            d.Add("Describe", Describe)
            d.Add("Ifattach_flag", Ifattach_flag)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)

            Return DAO.InsertByExample("SYS_Form_setting", d) >= 1
        End Function

        Public Function Update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Describe", Describe)
            d.Add("Ifattach_flag", Ifattach_flag)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Form_id", Form_id)

            Return DAO.UpdateByExample("SYS_Form_setting", d, cd) >= 1
        End Function

        Public Function delete() As Boolean

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Orgcode", Orgcode)
            cd.Add("Form_id", Form_id)

            Return DAO.DeleteByExample("SYS_Form_setting", cd) >= 1
        End Function

        Public Function GetDataByFormId(ByVal Orgcode As String, _
                                        ByVal Form_id As String) As DataTable

            Return DAO.GetDataByFormId(Orgcode, Form_id)
        End Function

    End Class
End Namespace
