Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class LeaveYear
        Private DAO As LeaveYearDAO

#Region "property"
        Private _Id As Integer
        Private _Orgcode As String
        Private _Id_card As String
        Private _Year_sdate As String
        Private _Year_edate As String
        Private _Note As String
        Private _Change_userid As String
        Private _Change_date As String
        Private _Year_flag As String
        Private _Reason As String
        Private _Year_days As Integer = 0
        Private _Years As Integer = 0
        Private _Months As Integer = 0
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(value As Integer)
                _id = value
            End Set
        End Property
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Id_card() As String
            Get
                Return _Id_card
            End Get
            Set(ByVal value As String)
                _Id_card = value
            End Set
        End Property
        Public Property Year_sdate() As String
            Get
                Return _Year_sdate
            End Get
            Set(ByVal value As String)
                _Year_sdate = value
            End Set
        End Property
        Public Property Note() As String
            Get
                Return _Note
            End Get
            Set(ByVal value As String)
                _Note = value
            End Set
        End Property
        Public Property Year_edate() As String
            Get
                Return _Year_edate
            End Get
            Set(ByVal value As String)
                _Year_edate = value
            End Set
        End Property
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
        Public Property Year_flag() As String
            Get
                Return _Year_flag
            End Get
            Set(ByVal value As String)
                _Year_flag = value
            End Set
        End Property
        Public Property Reason() As String
            Get
                Return _Reason
            End Get
            Set(value As String)
                _Reason = value
            End Set
        End Property
        Public Property Year_days() As Integer
            Get
                Return _Year_days
            End Get
            Set(value As Integer)
                _Year_days = value
            End Set
        End Property
        Public Property Years As Integer
            Get
                Return _Years
            End Get
            Set(value As Integer)
                _Years = value
            End Set
        End Property
        Public Property Months As Integer
            Get
                Return _Months
            End Get
            Set(value As Integer)
                _Months = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New LeaveYearDAO
        End Sub


        Public Function Insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Year_sdate", Year_sdate)
            d.Add("Year_edate", Year_edate)
            d.Add("Note", Note)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)
            d.Add("Year_flag", Year_flag)
            d.Add("Reason", Reason)
            d.Add("Year_days", Year_days)
            d.Add("Years", Years)
            d.Add("Months", Months)
            Return DAO.insertByExample("FSC_Leave_Year", d) >= 1
        End Function

        Public Function Update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Id_card", Id_card)
            d.Add("Year_sdate", Year_sdate)
            d.Add("Year_edate", Year_edate)
            d.Add("Note", Note)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)
            d.Add("Year_flag", Year_flag)
            d.Add("Reason", Reason)
            d.Add("Year_days", Year_days)
            d.Add("Years", Years)
            d.Add("Months", Months)
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("Id", Id)
            Return DAO.updateByExample("FSC_Leave_Year", d, cd) >= 1
        End Function

        Public Function GetDataById(ByVal Id As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", Id)
            Return DAO.GetDataByExample("FSC_Leave_Year", d)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Id_card As String) As DataTable
            'Dim d As New Dictionary(Of String, Object)
            'd.Add("Orgcode", Orgcode)
            'd.Add("Id_card", Id_card)
            'Return DAO.GetDataByExample("FSC_Leave_Year", d)

            Return DAO.getData(Orgcode, Id_card)
        End Function

        Public Function DeleteById(ByVal id As String) As Boolean

            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)

            Return DAO.deleteByExample("FSC_Leave_Year", d) = 1
        End Function

        Public Function getCount(ByVal id_card As String, ByVal currentDate As String) As Integer
            Dim dt As DataTable = DAO.get01Data(id_card, currentDate)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows.Count
            End If

            Return 0
        End Function
    End Class
End Namespace
