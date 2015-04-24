Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_ExamineIncome_mainDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO PAY_ExamineIncome_main ( ")
            StrSQL.Append(" OrgCode,ExamineIncome_type,ExamineIncome_name,PaymentCode,Unit, ")
            StrSQL.Append(" UnitPrice_amt,LatestReceipt_nos,ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@ExamineIncome_type,@ExamineIncome_name,@PaymentCode,@Unit, ")
            StrSQL.Append(" @UnitPrice_amt,@LatestReceipt_nos,@ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_ExamineIncome_main SET  ")
            StrSQL.Append(" LatestReceipt_nos=@LatestReceipt_nos,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, Optional ExamineIncome_type As String = "", Optional notShow1220 As Boolean = False) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,ExamineIncome_type,ExamineIncome_name,PaymentCode,Unit ")
            StrSQL.Append(" ,UnitPrice_amt,LatestReceipt_nos,ModUser_id,Mod_date ")
            StrSQL.Append(" ,(SELECT TOP 1 RECEIPTEND_ID FROM PAY_ExamineIncome_det EID WHERE EID.OrgCode=PAY_ExamineIncome_main.OrgCode ")
            StrSQL.Append(" AND EID.ExamineIncome_type=PAY_ExamineIncome_main.ExamineIncome_type ")
            StrSQL.Append(" ORDER BY CONVERT(INT,RECEIPTEND_ID) DESC) LatestReceipt  ")
            StrSQL.Append("  FROM PAY_ExamineIncome_main  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(ExamineIncome_type) Then
                StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")
            End If

            If notShow1220 Then
                StrSQL.Append("  AND not (ExamineIncome_type between '12' and '20')  ")
            End If


            Dim ps() As SqlParameter = { _
           New SqlParameter("@OrgCode", OrgCode), _
           New SqlParameter("@ExamineIncome_type", ExamineIncome_type)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(ExamineIncome_type As String, OrgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,ExamineIncome_type,ExamineIncome_name,PaymentCode,Unit ")
            StrSQL.Append(" ,UnitPrice_amt,LatestReceipt_nos,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM PAY_ExamineIncome_main  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@ExamineIncome_type", ExamineIncome_type), _
         New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(ExamineIncome_type As String, OrgCode As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_ExamineIncome_main WHERE  ExamineIncome_type=@ExamineIncome_type AND OrgCode=@OrgCode  ")
            Dim ps() As SqlParameter = {New SqlParameter("@ExamineIncome_type", ExamineIncome_type), New SqlParameter("@OrgCode", OrgCode)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Function CopySelect(OrgCode As String, ExamineIncome_type As String, Optional notShow1220 As Boolean = False) As DataTable
            Dim StrSQL As New System.Text.StringBuilder

            StrSQL.Append(" SELECT TOP 1 ")
            StrSQL.Append(" REPLICATE('0',6-LEN(CONVERT(VARCHAR(6),(ReceiptEnd_id+1)))) + RTRIM(CAST(CONVERT(VARCHAR(6),(ReceiptEnd_id+1)) AS CHAR)) AS  NReceiptStart_id,  ")
            StrSQL.Append(" REPLICATE('0',6-LEN(CONVERT(VARCHAR(6),(ReceiptEnd_id+Examine_cnt)))) + RTRIM(CAST(CONVERT(VARCHAR(6),(ReceiptEnd_id+Examine_cnt)) AS CHAR)) AS  NReceiptEnd_id,  ")
            StrSQL.Append(" Receipt_date,  ")
            StrSQL.Append(" Payer_id,  ")
            StrSQL.Append(" Payer_name,  ")
            StrSQL.Append(" Examine_cnt,  ")
            StrSQL.Append(" UnitPrice_amt,  ")
            StrSQL.Append(" TotalPrice_amt,  ")
            StrSQL.Append(" PayMode_type,  ")
            StrSQL.Append(" ReceiptScrap_type  ")
            StrSQL.Append(" FROM PAY_ExamineIncome_det  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")

            If notShow1220 Then
                StrSQL.Append("  AND not (ExamineIncome_type between '12' and '20')  ")
            End If

            StrSQL.Append(" ORDER BY CONVERT(INT,ReceiptEnd_id) DESC  ")

            Dim ps() As SqlParameter = { _
                 New SqlParameter("@ExamineIncome_type", ExamineIncome_type), _
                 New SqlParameter("@OrgCode", OrgCode)}

            Return Query(StrSQL.ToString(), ps)
        End Function

    End Class
End Namespace