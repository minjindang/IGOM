Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class PAY_ExamineIncome_detDAO
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


            StrSQL.Append(" INSERT INTO PAY_ExamineIncome_det ( ")
            StrSQL.Append(" OrgCode,ExamineIncome_type,ReceiptStart_id,ReceiptEnd_id,Receipt_date, ")
            StrSQL.Append(" Payer_id,Payer_name,Examine_cnt,UnitPrice_amt,TotalPrice_amt, ")
            StrSQL.Append(" PayMode_type,KeyIn_type,ReceiptScrap_type,Check1_nos,Check2_nos, ")
            StrSQL.Append(" ModUser_id,Mod_date ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@ExamineIncome_type,@ReceiptStart_id,@ReceiptEnd_id,@Receipt_date, ")
            StrSQL.Append(" @Payer_id,@Payer_name,@Examine_cnt,@UnitPrice_amt,@TotalPrice_amt, ")
            StrSQL.Append(" @PayMode_type,@KeyIn_type,@ReceiptScrap_type,@Check1_nos,@Check2_nos, ")
            StrSQL.Append(" @ModUser_id,@Mod_date ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_ExamineIncome_det SET  ")
            StrSQL.Append(" Receipt_date=@Receipt_date, ")
            StrSQL.Append(" Payer_id=@Payer_id,Payer_name=@Payer_name, ")
            StrSQL.Append(" PayMode_type=@PayMode_type,KeyIn_type=@KeyIn_type,ReceiptScrap_type=@ReceiptScrap_type,Check1_nos=@Check1_nos,Check2_nos=@Check2_nos, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND ReceiptStart_id=@ReceiptStart_id AND ReceiptEnd_id=@ReceiptEnd_id ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(OrgCode As String, ExamineIncome_type As String, Receipt_id As String, Receipt_date As String, _
                                  Payer_id As String, PayMode_type As String, ReceiptScrap_type As String, Check1_nos As String, _
                                  Check2_nos As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,ExamineIncome_type,ReceiptStart_id,ReceiptEnd_id,Receipt_date, ")
            StrSQL.Append(" Payer_id,Payer_name,Examine_cnt,UnitPrice_amt,TotalPrice_amt, ")
            StrSQL.Append(" PayMode_type,KeyIn_type,ReceiptScrap_type,Check1_nos,Check2_nos ")
            StrSQL.Append("  FROM PAY_ExamineIncome_det  ")
            StrSQL.Append("  WHERE OrgCode=@OrgCode  ")

            If Not String.IsNullOrEmpty(ExamineIncome_type) Then
                StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")
            End If

            If Not String.IsNullOrEmpty(Receipt_id) Then
                StrSQL.Append("  AND (ReceiptStart_id >= @Receipt_id OR ReceiptEnd_id <= @Receipt_id)  ")
            End If

            If Not String.IsNullOrEmpty(Receipt_date) Then
                StrSQL.Append("  AND Receipt_date=@Receipt_date  ")
            End If

            If Not String.IsNullOrEmpty(Payer_id) Then
                StrSQL.Append("  AND Payer_id=@Payer_id  ")
            End If

            If Not String.IsNullOrEmpty(ReceiptScrap_type) Then
                StrSQL.Append("  AND ReceiptScrap_type=@ReceiptScrap_type  ")
            End If

            If Not String.IsNullOrEmpty(PayMode_type) Then
                StrSQL.Append("  AND PayMode_type=@PayMode_type  ")
            End If

            If Not String.IsNullOrEmpty(Check1_nos) Then
                StrSQL.Append("  AND Check1_nos=@Check1_nos  ")
            End If

            If Not String.IsNullOrEmpty(Check2_nos ) Then
                StrSQL.Append("  AND Check2_nos=@Check2_nos  ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@OrgCode", OrgCode), _
          New SqlParameter("@ExamineIncome_type", ExamineIncome_type), _
          New SqlParameter("@Receipt_id", Receipt_id), _
          New SqlParameter("@Receipt_date", Receipt_date), _
          New SqlParameter("@Payer_id", Payer_id), _
          New SqlParameter("@PayMode_type", PayMode_type), _
          New SqlParameter("@ReceiptScrap_type", ReceiptScrap_type), _
          New SqlParameter("@Check1_nos", Check1_nos), _
          New SqlParameter("@Check2_nos", Check2_nos)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(ExamineIncome_type As String, OrgCode As String, ReceiptStart_id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" OrgCode,ExamineIncome_type,ReceiptStart_id,ReceiptEnd_id,Receipt_date, ")
            StrSQL.Append(" Payer_id,Payer_name,Examine_cnt,UnitPrice_amt,TotalPrice_amt, ")
            StrSQL.Append(" PayMode_type,KeyIn_type,ReceiptScrap_type,Check1_nos,Check2_nos ")
            StrSQL.Append("  FROM PAY_ExamineIncome_det  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND ExamineIncome_type=@ExamineIncome_type  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND ReceiptStart_id=@ReceiptStart_id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@ExamineIncome_type", ExamineIncome_type), _
         New SqlParameter("@OrgCode", OrgCode), _
         New SqlParameter("@ReceiptStart_id", ReceiptStart_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(ExamineIncome_type As String, OrgCode As String, ReceiptStart_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM PAY_ExamineIncome_det WHERE  ExamineIncome_type=@ExamineIncome_type AND OrgCode=@OrgCode AND ReceiptStart_id=@ReceiptStart_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@ExamineIncome_type", ExamineIncome_type), New SqlParameter("@OrgCode", OrgCode), New SqlParameter("@ReceiptStart_id", ReceiptStart_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace