Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic

    Public Class PayTripsDAO
        Inherits BaseDAO

        Public Function InsertTripsData(ByVal outfee As PayTrips) As Integer
            Dim sql As New StringBuilder()
            sql.Append(" INSERT INTO Pay_Trips ")
            sql.Append(" ( ")
            sql.Append(" Pay_no, ArrangedDate ,Job  ,Place  ,Airfare ,TrainTicketFare  ")
            sql.Append(" ,BusTicketFare ,BoatTicketFare  ,HSRailFare ,BoardingFee  ,BoardingTransportation   ")
            sql.Append(" ,IncidentalExpense ,SubTotal ,Note  ,Long_traffic ,Life_fee  ")
            'sql.Append(", Fee, Insurance, Administrative_costs, Gift_entertainment_expenses, Incidentals ")
            sql.Append("   ) ")
            sql.Append(" VALUES ")
            sql.Append(" ( ")
            sql.Append(" @Pay_no, @ArrangedDate ,@Job  ,@Place  ,@Airfare ,@TrainTicketFare  ")
            sql.Append(" ,@BusTicketFare ,@BoatTicketFare  ,@HSRailFare ,@BoardingFee  ,@BoardingTransportation   ")
            sql.Append(" ,@IncidentalExpense ,@SubTotal ,@Note  ,@Long_traffic ,@Life_fee  ")
            'sql.Append(" ,@Fee, @Insurance, @Administrative_costs, @Gift_entertainment_expenses, @Incidentals ")
            sql.Append(" ) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Pay_no", outfee.Pay_no), _
            New SqlParameter("@ArrangedDate", outfee.ArrangedDate), _
            New SqlParameter("@Job", outfee.Job), _
            New SqlParameter("@Place", outfee.Place), _
            New SqlParameter("@Airfare", outfee.Airfare), _
            New SqlParameter("@TrainTicketFare", outfee.TrainTicketFare), _
            New SqlParameter("@BusTicketFare", outfee.BusTicketFare), _
            New SqlParameter("@BoatTicketFare", outfee.BoatTicketFare), _
            New SqlParameter("@HSRailFare", outfee.HSRailFare), _
            New SqlParameter("@BoardingFee", outfee.BoardingFee), _
            New SqlParameter("@BoardingTransportation", outfee.BoardingTransportation), _
            New SqlParameter("@IncidentalExpense", outfee.IncidentalExpense), _
            New SqlParameter("@SubTotal", outfee.SubTotal), _
            New SqlParameter("@Note", outfee.Note), _
            New SqlParameter("@Long_traffic", outfee.Long_traffic), _
            New SqlParameter("@Life_fee", outfee.Life_fee), _
            New SqlParameter("@Fee", outfee.Fee), _
            New SqlParameter("@Insurance", outfee.Insurance), _
            New SqlParameter("@Administrative_costs", outfee.Administrative_costs), _
            New SqlParameter("@Gift_entertainment_expenses", outfee.Gift_entertainment_expenses), _
            New SqlParameter("@Incidentals", outfee.Incidentals)}

            Return Execute(sql.ToString, params)
        End Function

    End Class
 End Namespace
