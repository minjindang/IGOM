Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class PayWithDrawDAO
        Inherits BaseDAO

        Public Function InsertData(ByVal WithDraw As PayWithDraw) As Integer
            Dim sql As New StringBuilder()
            sql.Append(" INSERT INTO Pay_WithDraw ")
            sql.Append(" ( ")
            sql.Append(" Pay_No,FormID,FromDesNo,FromFormID,Apply_date, ")
            sql.Append(" Apply_depno,Card,UseTo,Remark,Stage, ")
            sql.Append(" Exception,ProjectNo,Total,Transfer,Dep_FundNo, ")
            sql.Append(" Project_FundNo,AccountingNo,SourceGroup,SourceType ")
            'sql.Append(" ,ApplyType,PayType, PayMan, PayManNo, PayLoanTotal, PayDate, PayTotal ")
            sql.Append("   ) ")
            sql.Append(" VALUES ")
            sql.Append(" ( ")
            sql.Append(" @PayNo,@FormID,@FromDesNo,@FromFormID,@Applydate, ")
            sql.Append(" @Applydepno,@Card,@UseTo,@Remark,@Stage, ")
            sql.Append(" @Exception,@ProjectNo,@Total,@Transfer,@DepFundNo, ")
            sql.Append(" @ProjectFundNo,@AccountingNo,@SourceGroup,@SourceType ")
            'sql.Append(" ,@ApplyType,@PayType, @PayMan, @PayManNo, @PayLoanTotal, @PayDate, @PayTotal ")
            sql.Append(" ) ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@PayNo", SqlDbType.VarChar), _
            New SqlParameter("@FormID", SqlDbType.VarChar), _
            New SqlParameter("@FromDesNo", SqlDbType.VarChar), _
            New SqlParameter("@FromFormID", SqlDbType.VarChar), _
            New SqlParameter("@Applydate", SqlDbType.DateTime), _
            New SqlParameter("@Applydepno", SqlDbType.VarChar), _
            New SqlParameter("@Card", SqlDbType.VarChar), _
            New SqlParameter("@UseTo", SqlDbType.VarChar), _
            New SqlParameter("@Remark", SqlDbType.VarChar), _
            New SqlParameter("@Stage", SqlDbType.TinyInt), _
            New SqlParameter("@Exception", SqlDbType.TinyInt), _
            New SqlParameter("@ProjectNo", SqlDbType.VarChar), _
            New SqlParameter("@Total", SqlDbType.Float), _
            New SqlParameter("@Transfer", SqlDbType.VarChar), _
            New SqlParameter("@DepFundNo", SqlDbType.VarChar), _
            New SqlParameter("@ProjectFundNo", SqlDbType.VarChar), _
            New SqlParameter("@AccountingNo", SqlDbType.VarChar), _
            New SqlParameter("@SourceGroup", SqlDbType.VarChar), _
            New SqlParameter("@SourceType", SqlDbType.VarChar) _
        }

            params(0).Value = WithDraw.PayNo
            params(1).Value = WithDraw.FormID
            params(2).Value = WithDraw.FromDesNo
            params(3).Value = WithDraw.FromFormID
            params(4).Value = WithDraw.Applydate
            params(5).Value = WithDraw.Applydepno
            params(6).Value = WithDraw.Card
            params(7).Value = WithDraw.UseTo
            params(8).Value = WithDraw.Remark
            params(9).Value = WithDraw.Stage
            params(10).Value = WithDraw.Exception
            params(11).Value = WithDraw.ProjectNo
            params(12).Value = WithDraw.Total
            params(13).Value = WithDraw.Transfer
            params(14).Value = WithDraw.DepFundNo
            params(15).Value = WithDraw.ProjectFundNo
            params(16).Value = WithDraw.AccountingNo
            params(17).Value = WithDraw.SourceGroup
            params(18).Value = WithDraw.SourceType
            'params(19).Value = WithDraw.ApplyType
            'params(20).Value = WithDraw.PayType
            'params(21).Value = WithDraw.PayMan
            'params(22).Value = WithDraw.PayManNo
            'params(23).Value = WithDraw.PayLoanTotal
            'params(24).Value = WithDraw.PayDate
            'params(25).Value = WithDraw.PayTotal

            Return Execute(sql.ToString, params)
        End Function
    End Class

End Namespace
