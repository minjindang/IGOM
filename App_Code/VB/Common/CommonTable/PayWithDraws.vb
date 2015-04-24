Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic


Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class PayWithDraws
        Public DAO As PayWithDrawsDAO
        Public Sub New()
            DAO = New PayWithDrawsDAO()
        End Sub

#Region "fields"
        Private _Payno As String
        Private _Title As String
        Private _Card As String
        Private _Name As String
        Private _Addr As String
        Private _TaxNo As String
        Private _Duration As String
        Private _Description As String
        Private _Qty As Integer
        Private _Price As Integer
        Private _LaborerInsurance As Integer
        Private _HealthInsurance As Integer
        Private _HealthExtInsurance As Integer
        Private _RetirementPay As Integer
        Private _IncomeTax As Integer
        Private _ResidentFlag As Integer
        Private _HealthExtDep As Integer
#End Region

#Region "Property"
        Public Property Payno() As String
            Get
                Return Me._Payno
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Payno, value) = False) Then
                    Me._Payno = value
                End If
            End Set
        End Property
        Public Property Title() As String
            Get
                Return Me._Title
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Title, value) = False) Then
                    Me._Title = value
                End If
            End Set
        End Property
        Public Property Card() As String
            Get
                Return Me._Card
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Card, value) = False) Then
                    Me._Card = value
                End If
            End Set
        End Property
        Public Property Name() As String
            Get
                Return Me._Name
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Name, value) = False) Then
                    Me._Name = value
                End If
            End Set
        End Property
        Public Property Addr() As String
            Get
                Return Me._Addr
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Addr, value) = False) Then
                    Me._Addr = value
                End If
            End Set
        End Property
        Public Property TaxNo() As String
            Get
                Return Me._TaxNo
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._TaxNo, value) = False) Then
                    Me._TaxNo = value
                End If
            End Set
        End Property
        Public Property Duration() As String
            Get
                Return Me._Duration
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Duration, value) = False) Then
                    Me._Duration = value
                End If
            End Set
        End Property
        Public Property Description() As String
            Get
                Return Me._Description
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Description, value) = False) Then
                    Me._Description = value
                End If
            End Set
        End Property
        Public Property Qty() As String
            Get
                Return Me._Qty
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Qty, value) = False) Then
                    Me._Qty = value
                End If
            End Set
        End Property
        Public Property Price() As String
            Get
                Return Me._Price
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Price, value) = False) Then
                    Me._Price = value
                End If
            End Set
        End Property
        Public Property LaborerInsurance() As String
            Get
                Return Me._LaborerInsurance
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._LaborerInsurance, value) = False) Then
                    Me._LaborerInsurance = value
                End If
            End Set
        End Property
        Public Property HealthInsurance() As String
            Get
                Return Me._HealthInsurance
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._HealthInsurance, value) = False) Then
                    Me._HealthInsurance = value
                End If
            End Set
        End Property
        Public Property HealthExtInsurance() As String
            Get
                Return Me._HealthExtInsurance
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._HealthExtInsurance, value) = False) Then
                    Me._HealthExtInsurance = value
                End If
            End Set
        End Property
        Public Property RetirementPay() As String
            Get
                Return Me._RetirementPay
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._RetirementPay, value) = False) Then
                    Me._RetirementPay = value
                End If
            End Set
        End Property
        Public Property IncomeTax() As String
            Get
                Return Me._IncomeTax
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._IncomeTax, value) = False) Then
                    Me._IncomeTax = value
                End If
            End Set
        End Property
        Public Property ResidentFlag() As String
            Get
                Return Me._ResidentFlag
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._ResidentFlag, value) = False) Then
                    Me._ResidentFlag = value
                End If
            End Set
        End Property
        Public Property HealthExtDep() As String
            Get
                Return Me._HealthExtDep
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._HealthExtDep, value) = False) Then
                    Me._HealthExtDep = value
                End If
            End Set
        End Property

#End Region


        Public Function InsertWithDrawsData() As Integer
            Return DAO.InsertWithDrawsData(Me)
        End Function
    End Class
End Namespace
