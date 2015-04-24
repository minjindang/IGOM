Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class PayTrips
        Public DAO As PayTripsDAO
        Public Sub New()
            DAO = New PayTripsDAO()
        End Sub

#Region "fields"
        Private _Pay_no As String
        Private _ArrangedDate As DateTime
        Private _Job As String
        Private _Place As String
        Private _Airfare As Integer
        Private _TrainTicketFare As Integer
        Private _BusTicketFare As Integer
        Private _BoatTicketFare As Integer
        Private _HSRailFare As Integer
        Private _BoardingFee As Integer
        Private _BoardingTransportation As Integer
        Private _IncidentalExpense As Integer
        Private _SubTotal As Integer
        Private _Note As String
        Private _Long_traffic As Integer
        Private _Life_fee As Integer
        Private _Fee As Integer
        Private _Insurance As Integer
        Private _Administrative_costs As Integer
        Private _Gift_entertainment_expenses As Integer
        Private _Incidentals As Integer

#End Region
        Public Property Pay_no() As String
            Get
                Return Me._Pay_no
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Pay_no, value) = False) Then
                    Me._Pay_no = value
                End If
            End Set
        End Property
        Public Property ArrangedDate() As DateTime
            Get
                Return Me._ArrangedDate
            End Get
            Set(ByVal value As DateTime)
                If (String.Equals(Me._ArrangedDate, value) = False) Then
                    Me._ArrangedDate = value
                End If
            End Set
        End Property

        Public Property Job  () As string
            Get
                Return Me._Job
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Job, value) = False) Then
                    Me._Job = value
                End If
            End Set
        End Property

        Public Property Place  () As string
            Get
                Return Me._Place
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Place, value) = False) Then
                    Me._Place = value
                End If
            End Set
        End Property

        Public Property Airfare () As  Integer 
            Get
                Return Me._Airfare
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Airfare, value) = False) Then
                    Me._Airfare = value
                End If
            End Set
        End Property

        Public Property TrainTicketFare() As Integer
            Get
                Return Me._TrainTicketFare
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._TrainTicketFare, value) = False) Then
                    Me._TrainTicketFare = value
                End If
            End Set
        End Property

        Public Property BusTicketFare () As  Integer  
            Get
                Return Me._BusTicketFare
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._BusTicketFare, value) = False) Then
                    Me._BusTicketFare = value
                End If
            End Set
        End Property

        Public Property BoatTicketFare  () As Integer  
            Get
                Return Me._BoatTicketFare
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._BoatTicketFare, value) = False) Then
                    Me._BoatTicketFare = value
                End If
            End Set
        End Property

        Public Property HSRailFare () As  Integer  
            Get
                Return Me._HSRailFare
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._HSRailFare, value) = False) Then
                    Me._HSRailFare = value
                End If
            End Set
        End Property

        Public Property BoardingFee  () As Integer  
            Get
                Return Me._BoardingFee
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._BoardingFee, value) = False) Then
                    Me._BoardingFee = value
                End If
            End Set
        End Property

        Public Property BoardingTransportation  () As Integer  
            Get
                Return Me._BoardingTransportation
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._BoardingTransportation, value) = False) Then
                    Me._BoardingTransportation = value
                End If
            End Set
        End Property

        Public Property IncidentalExpense () As  Integer  
            Get
                Return Me._IncidentalExpense
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._IncidentalExpense, value) = False) Then
                    Me._IncidentalExpense = value
                End If
            End Set
        End Property

        Public Property SubTotal () As  Integer  
            Get
                Return Me._SubTotal
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._SubTotal, value) = False) Then
                    Me._SubTotal = value
                End If
            End Set
        End Property

        Public Property Note  () As string
            Get
                Return Me._Note
            End Get
            Set(ByVal value As String)
                If (String.Equals(Me._Note, value) = False) Then
                    Me._Note = value
                End If
            End Set
        End Property

        Public Property Long_traffic () As  Integer  
            Get
                Return Me._Long_traffic
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Long_traffic, value) = False) Then
                    Me._Long_traffic = value
                End If
            End Set
        End Property

        Public Property Life_fee () As  Integer  
            Get
                Return Me._Life_fee
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Life_fee, value) = False) Then
                    Me._Life_fee = value
                End If
            End Set
        End Property

        Public Property Fee  () As Integer  
            Get
                Return Me._Fee
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Fee, value) = False) Then
                    Me._Fee = value
                End If
            End Set
        End Property

        Public Property Insurance () As  Integer  
            Get
                Return Me._Insurance
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Insurance, value) = False) Then
                    Me._Insurance = value
                End If
            End Set
        End Property

        Public Property Administrative_costs () As  Integer  
            Get
                Return Me._Administrative_costs
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Administrative_costs, value) = False) Then
                    Me._Administrative_costs = value
                End If
            End Set
        End Property

        Public Property Gift_entertainment_expenses  () As Integer  
            Get
                Return Me._Gift_entertainment_expenses
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Gift_entertainment_expenses, value) = False) Then
                    Me._Gift_entertainment_expenses = value
                End If
            End Set
        End Property

        Public Property Incidentals () As  Integer  
            Get
                Return Me._Incidentals
            End Get
            Set(ByVal value As Integer)
                If (String.Equals(Me._Incidentals, value) = False) Then
                    Me._Incidentals = value
                End If
            End Set
        End Property


        Public Function InsertTripsData() As Integer
            Return DAO.InsertTripsData(Me)
        End Function
    End Class

End Namespace
