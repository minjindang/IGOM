Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text


Namespace FSCPLM.Logic
    Public Class PayWithDrawsDAO
        Inherits BaseDAO

        Public Function InsertWithDrawsData(ByVal WithDraws As PayWithDraws) As Integer
            Dim sql As New StringBuilder()
            sql.Append(" INSERT INTO Pay_WithDraws ")
            sql.Append(" ( ")
            sql.Append(" Pay_no, Title, Card, Name, Addr, TaxNo ")
            sql.Append(" ,	Duration,	Description,	Qty,	Price,	Laborer_Insurance ")
            sql.Append(" ,	Health_Insurance,	HealthExt_Insurance,	RetirementPay,	IncomeTax ")
            sql.Append(" ,	ResidentFlag,	HealthExt_Dep ")
            sql.Append("   ) ")
            sql.Append(" VALUES ")
            sql.Append(" ( ")
            sql.Append(" @Pay_no, @Title, @Card, @Name, @Addr, @TaxNo ")
            sql.Append(" ,	@Duration,	@Description,	@Qty,	@Price,	@LaborerInsurance ")
            sql.Append(" ,	@HealthInsurance,	@HealthExtInsurance,	@RetirementPay,	@IncomeTax ")
            sql.Append(" ,	@ResidentFlag,	@HealthExtDep ")
            sql.Append(" ) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Pay_no", WithDraws.Payno), _
            New SqlParameter("@Title", WithDraws.Title), _
            New SqlParameter("@Card", WithDraws.Card), _
            New SqlParameter("@Name", WithDraws.Name), _
            New SqlParameter("@Addr", WithDraws.Addr), _
            New SqlParameter("@TaxNo", WithDraws.TaxNo), _
            New SqlParameter("@Duration", WithDraws.Duration), _
            New SqlParameter("@Description", WithDraws.Description), _
            New SqlParameter("@Qty", WithDraws.Qty), _
            New SqlParameter("@Price", WithDraws.Price), _
            New SqlParameter("@LaborerInsurance", WithDraws.LaborerInsurance), _
            New SqlParameter("@HealthInsurance", WithDraws.HealthInsurance), _
            New SqlParameter("@HealthExtInsurance", WithDraws.HealthExtInsurance), _
            New SqlParameter("@RetirementPay", WithDraws.RetirementPay), _
            New SqlParameter("@IncomeTax", WithDraws.IncomeTax), _
            New SqlParameter("@ResidentFlag", WithDraws.ResidentFlag), _
            New SqlParameter("@HealthExtDep", WithDraws.HealthExtDep) _
        }
            Return Execute(sql.ToString, params)
        End Function
    End Class
End Namespace
