Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class VacationAllowance
        Private DAO As VacationAllowanceDAO

#Region "Property"
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Private _Flow_id As String
        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
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
        Private _Fee_year As String
        Public Property Fee_year() As String
            Get
                Return _Fee_year
            End Get
            Set(ByVal value As String)
                _Fee_year = value
            End Set
        End Property
        Private _Holidays As String
        Public Property Holidays() As String
            Get
                Return _Holidays
            End Get
            Set(ByVal value As String)
                _Holidays = value
            End Set
        End Property
        Private _Leave_days As String
        Public Property Leave_days() As String
            Get
                Return _Leave_days
            End Get
            Set(ByVal value As String)
                _Leave_days = value
            End Set
        End Property
        Private _Left_days As String
        Public Property Left_days() As String
            Get
                Return _Left_days
            End Get
            Set(ByVal value As String)
                _Left_days = value
            End Set
        End Property
        Private _Inter_days As String
        Public Property Inter_days() As String
            Get
                Return _Inter_days
            End Get
            Set(ByVal value As String)
                _Inter_days = value
            End Set
        End Property
        Private _Inter_days_card As String
        Public Property Inter_days_card() As String
            Get
                Return _Inter_days_card
            End Get
            Set(ByVal value As String)
                _Inter_days_card = value
            End Set
        End Property
        Private _Outer_days As String
        Public Property Outer_days() As String
            Get
                Return _Outer_days
            End Get
            Set(ByVal value As String)
                _Outer_days = value
            End Set
        End Property
        Private _Pay_days As String
        Public Property Pay_days() As String
            Get
                Return _Pay_days
            End Get
            Set(ByVal value As String)
                _Pay_days = value
            End Set
        End Property
        Private _Total_fee As String
        Public Property Total_fee() As String
            Get
                Return _Total_fee
            End Get
            Set(ByVal value As String)
                _Total_fee = value
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
            DAO = New VacationAllowanceDAO()
        End Sub

        Public Function insert() As Boolean
            Return DAO.insert(Me) > 0
        End Function

        Public Function delete() As Boolean
            Return DAO.delete(Me) > 0
        End Function

        Public Function GetData(Orgcode As String, Id_card As String, Fee_year As String) As DataTable
            Return DAO.GetData(Orgcode, Id_card, Fee_year)
        End Function

    End Class
End Namespace