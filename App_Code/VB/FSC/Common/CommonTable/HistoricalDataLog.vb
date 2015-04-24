Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class HistoricalDataLog
        Public DAO As HistoricalDataLogDAO

#Region "property"
        Private _Orgcode As String
        Private _Depart_id As String
        Private _delete_sdate As String
        Private _delete_edate As String
        Private _delete_table As String
        Private _delete_count As Integer
        Private _Change_userid As String

        Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property

        Property delete_sdate() As String
            Get
                Return _delete_sdate
            End Get
            Set(ByVal value As String)
                _delete_sdate = value
            End Set
        End Property
        Property delete_edate() As String
            Get
                Return _delete_edate
            End Get
            Set(ByVal value As String)
                _delete_edate = value
            End Set
        End Property
        Property delete_table() As String
            Get
                Return _delete_table
            End Get
            Set(ByVal value As String)
                _delete_table = value
            End Set
        End Property
        Property delete_count() As Integer
            Get
                Return _delete_count
            End Get
            Set(ByVal value As Integer)
                _delete_count = value
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
#End Region

        Public Sub New()
            DAO = New HistoricalDataLogDAO()
        End Sub

        Public Function insert() As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Depart_id", Depart_id)
            d.Add("delete_sdate", delete_sdate)
            d.Add("delete_edate", delete_edate)
            d.Add("delete_table", delete_table)
            d.Add("delete_count", delete_count)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Historical_data_log", d)
        End Function


    End Class
End Namespace
