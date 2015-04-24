Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic

    Public Class MailError
        Private DAO As MailErrorDAO

        Public Sub New()
            DAO = New MailErrorDAO()
        End Sub

#Region "Property"
        Private _FromName As String
        Public Property FromName() As String
            Get
                Return _FromName
            End Get
            Set(ByVal value As String)
                _FromName = value
            End Set
        End Property
        Private _FromMail As String
        Public Property FromMail() As String
            Get
                Return _FromMail
            End Get
            Set(ByVal value As String)
                _FromMail = value
            End Set
        End Property
        Private _ToName As String
        Public Property ToName() As String
            Get
                Return _ToName
            End Get
            Set(ByVal value As String)
                _ToName = value
            End Set
        End Property
        Private _ToMail As String
        Public Property ToMail() As String
            Get
                Return _ToMail
            End Get
            Set(ByVal value As String)
                _ToMail = value
            End Set
        End Property
        Private _Subject As String
        Public Property Subject() As String
            Get
                Return _Subject
            End Get
            Set(ByVal value As String)
                _Subject = value
            End Set
        End Property
        Private _MailContent As String
        Public Property MailContent() As String
            Get
                Return _MailContent
            End Get
            Set(ByVal value As String)
                _MailContent = value
            End Set
        End Property
        Private _Accessory As String
        Public Property Accessory() As String
            Get
                Return _Accessory
            End Get
            Set(ByVal value As String)
                _Accessory = value
            End Set
        End Property
        Private _FileName As String
        Public Property FileName() As String
            Get
                Return _FileName
            End Get
            Set(ByVal value As String)
                _FileName = value
            End Set
        End Property
        Private _SendDate As String
        Public Property SendDate() As String
            Get
                Return _SendDate
            End Get
            Set(ByVal value As String)
                _SendDate = value
            End Set
        End Property
        Private _ErrorMag As String
        Public Property ErrorMag() As String
            Get
                Return _ErrorMag
            End Get
            Set(ByVal value As String)
                _ErrorMag = value
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

        Public Function InsertData() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("FromName", FromName)
            d.Add("FromMail", FromMail)
            d.Add("ToName", ToName)
            d.Add("ToMail", ToMail)
            d.Add("Subject", Subject)
            d.Add("MailContent", MailContent)
            d.Add("ErrorMag", ErrorMag)
            d.Add("SendDate", SendDate)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Change_date)

            Return DAO.InsertByExample("SYS_MailError", d) > 0
        End Function

    End Class

End Namespace
