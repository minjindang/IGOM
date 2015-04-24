Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text


Namespace FSCPLM.Logic

    Public Class PayTripDAO
        Inherits BaseDAO

        Public Function InsertTripData(ByVal outfee As PayTrip) As Integer
            Dim sql As New StringBuilder()
            sql.Append(" INSERT INTO Pay_Trip ")
            sql.Append(" ( ")
            sql.Append(" Pay_No,FormID,FromFormID,FromDesNo,UseTo ")
            sql.Append(" ,Reason,ProjectNo,Dep_FundNo,Project_FundNo,AccountingNo ")
            sql.Append(" ,SourceGroup,SourceType,ApplyType,Place,DateB ")
            sql.Append(" ,DateE,Attach,AttachCount,Total,ApplierNo ")
            sql.Append(" ,Applier,App_Dep,App_DepCName,App_Date,Note,RankName ")
            'sql.Append(" ,PayType,PayMan,PayManNo,Stage ")
            'sql.Append(" ,transfer,BillDate,VoucherNo,Exception,AgentNo ")
            'sql.Append(" ,PayDate,PayTotal ")
            sql.Append("   ) ")
            sql.Append(" VALUES ")
            sql.Append(" ( ")
            sql.Append(" @PayNo,@FormID,@FromFormID,@FromDesNo,@UseTo ")
            sql.Append(" ,@Reason,@ProjectNo,@DepFundNo,@ProjectFundNo,@AccountingNo ")
            sql.Append(" ,@SourceGroup,@SourceType,@ApplyType,@Place,@DateB ")
            sql.Append(" ,@DateE,@Attach,@AttachCount,@Total,@ApplierNo ")
            sql.Append(" ,@Applier,@AppDep,@AppDepCName,@AppDate,@Note,@RankName ")
            'sql.Append(" ,@PayType,@PayMan,@PayManNo,@Stage ")
            'sql.Append(" ,@transfer,@BillDate,@VoucherNo,@Exception,@AgentNo ")
            'sql.Append(" ,@PayDate,@PayTotal ")
            sql.Append(" ) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PayNo", outfee.PayNo), _
            New SqlParameter("@FormID", outfee.FormID), _
            New SqlParameter("@FromFormID", outfee.FromFormID), _
            New SqlParameter("@FromDesNo", outfee.FromDesNo), _
            New SqlParameter("@UseTo", outfee.UseTo), _
            New SqlParameter("@Reason", outfee.Reason), _
            New SqlParameter("@ProjectNo", outfee.ProjectNo), _
            New SqlParameter("@DepFundNo", outfee.DepFundNo), _
            New SqlParameter("@ProjectFundNo", outfee.ProjectFundNo), _
            New SqlParameter("@AccountingNo", outfee.AccountingNo), _
            New SqlParameter("@SourceGroup", outfee.SourceGroup), _
            New SqlParameter("@SourceType", outfee.SourceType), _
            New SqlParameter("@ApplyType", outfee.ApplyType), _
            New SqlParameter("@Place", outfee.Place), _
            New SqlParameter("@DateB", outfee.DateB), _
            New SqlParameter("@DateE", outfee.DateE), _
            New SqlParameter("@Attach", outfee.Attach), _
            New SqlParameter("@AttachCount", outfee.AttachCount), _
            New SqlParameter("@Total", outfee.Total), _
            New SqlParameter("@ApplierNo", outfee.ApplierNo), _
            New SqlParameter("@Applier", outfee.Applier), _
            New SqlParameter("@AppDep", outfee.AppDep), _
            New SqlParameter("@AppDepCName", outfee.AppDepCName), _
            New SqlParameter("@AppDate", outfee.AppDate), _
            New SqlParameter("@Note", outfee.Note), _
            New SqlParameter("@RankName", outfee.RankName) _
        }
            'New SqlParameter("@PayType", outfee.PayType), _
            'New SqlParameter("@PayMan", outfee.PayMan), _
            'New SqlParameter("@PayManNo", outfee.PayManNo), _
            'New SqlParameter("@Stage", outfee.Stage), _
            'New SqlParameter("@transfer", outfee.transfer), _
            'New SqlParameter("@BillDate", outfee.BillDate), _
            'New SqlParameter("@VoucherNo", outfee.VoucherNo), _
            'New SqlParameter("@Exception", outfee.Exception), _
            'New SqlParameter("@AgentNo", outfee.AgentNo), _
            'New SqlParameter("@PayDate", outfee.PayDate), _
            'New SqlParameter("@PayTotal", outfee.PayTotal) _

            Return Execute(sql.ToString, params)
        End Function

    End Class
End Namespace
