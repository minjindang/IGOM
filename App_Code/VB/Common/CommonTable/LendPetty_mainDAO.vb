Imports Microsoft.VisualBasic

Imports System
Imports System.Data
Imports System.Data.SqlClient

Namespace FSCPLM.Logic
    Public Class PAY_LendPetty_mainDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal connstr As String)
            MyBase.New(connstr)
        End Sub

        Public Function GetMaxPettyCash_nos(Orgocde As String) As Integer
            Return Scalar("SELECT MAX(PettyCash_nos) FROM PAY_LendPetty_main WHERE Orgcode=@Orgcode", New SqlParameter("@Orgcode", Orgocde))
        End Function

        Public Function GetMaxPrePayID(Orgocde As String, rocYear As String) As Integer
            Dim sp() As SqlParameter = { _
              New SqlParameter("@Orgcode", Orgocde), _
              New SqlParameter("@rocYear", rocYear)}
            Return Scalar("SELECT Count(Prepay_id) FROM PAY_LendPetty_main WHERE Orgcode=@Orgcode and Prepay_id like @rocYear + '%'", sp)
        End Function

        Public Function CheckData(Orgcode As String, beneficiary_id As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" select Count(*) ")
            sql.AppendLine(" from PAY_LendPetty_main a, PAY_PettyList_main b ")
            sql.AppendLine(" where a.PCList_id=b.PCList_id ")
            sql.AppendLine("    and a.Orgcode=@Orgcode ")
            sql.AppendLine("    and a.beneficiary_id=@beneficiary_id and is_pay='0' ")

            Dim sp() As SqlParameter = { _
              New SqlParameter("@Orgcode", Orgcode), _
              New SqlParameter("@beneficiary_id", beneficiary_id)}

            Return Scalar(sql.ToString(), sp)
        End Function

        Public Function GetAll(Orgocde As String, fiscalYear_id As String, Prepay_id_S As String, Prepay_id_E As String, PCList_id As String _
                               , writeOff_date As String, borrow_date_S As String, borrow_date_E As String, pettyCash_nos_S As String, pettyCash_nos_E As String _
                               , beneficiary_id As String, use_type As String, invoice_date As String, paymentVoucher_id As String, PettyCash_type As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select isnull(PurchaseTotal_amt,0) PurchaseTotal_amt1,isnull(Income_amt,0) Income_amt2,* ")
            sql.AppendLine(" from PAY_LendPetty_main a left join PAY_Beneficiary_data b on a.OrgCode = b.OrgCode and a.Beneficiary_id=b.Beneficiary_id ")
            sql.AppendLine(" where ")
            sql.AppendLine(" a.Orgcode=@Orgcode ")
            If Not String.IsNullOrEmpty(fiscalYear_id) Then
                sql.AppendLine(" and a.fiscalYear_id=@fiscalYear_id  ")
            End If
            If Not String.IsNullOrEmpty(Prepay_id_S) Then
                sql.AppendLine(" and a.Prepay_id >=@Prepay_id_S  ")
            End If
            If Not String.IsNullOrEmpty(Prepay_id_E) Then
                sql.AppendLine(" and a.Prepay_id <=@Prepay_id_E  ")
            End If
            If Not String.IsNullOrEmpty(PCList_id) Then
                sql.AppendLine(" and a.PCList_id =@PCList_id  ")
            End If
            If Not String.IsNullOrEmpty(writeOff_date) Then
                If writeOff_date = "Y" Then
                    sql.AppendLine(" and (a.writeOff_date is not null and a.writeOff_date <> '') ")
                ElseIf writeOff_date = "N" Then
                    sql.AppendLine(" and (a.writeOff_date is null or a.writeOff_date = '') ")
                Else
                    sql.AppendLine(" and a.writeOff_date =@writeOff_date  ")
                End If
            End If
            If Not String.IsNullOrEmpty(borrow_date_S) Then
                sql.AppendLine(" and a.borrow_date >=@borrow_date_S  ")
            End If
            If Not String.IsNullOrEmpty(borrow_date_E) Then
                sql.AppendLine(" and a.borrow_date >=@borrow_date_E  ")
            End If
            If Not String.IsNullOrEmpty(pettyCash_nos_S) Then
                sql.AppendLine(" and a.pettyCash_nos >=@pettyCash_nos_S  ")
            End If
            If Not String.IsNullOrEmpty(pettyCash_nos_E) Then
                sql.AppendLine(" and a.pettyCash_nos <=@pettyCash_nos_E  ")
            End If
            If Not String.IsNullOrEmpty(beneficiary_id) Then
                sql.AppendLine(" and a.beneficiary_id =@beneficiary_id  ")
            End If
            If Not String.IsNullOrEmpty(use_type) Then
                sql.AppendLine(" and a.use_type =@use_type  ")
            End If
            If Not String.IsNullOrEmpty(invoice_date) Then
                sql.AppendLine(" and a.invoice_date=@invoice_date ")
            End If
            If Not String.IsNullOrEmpty(paymentVoucher_id) Then
                sql.AppendLine(" and a.paymentVoucher_id =@paymentVoucher_id  ")
            End If
            If Not String.IsNullOrEmpty(PettyCash_type) Then
                sql.AppendLine(" and a.PettyCash_type =@PettyCash_type  ")
            End If

            sql.Append(" order by a.PettyCash_nos, a.Prepay_id ")

            Dim sp() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgocde), _
            New SqlParameter("@fiscalYear_id", fiscalYear_id), _
            New SqlParameter("@Prepay_id_S", Prepay_id_S), _
            New SqlParameter("@Prepay_id_E", Prepay_id_E), _
            New SqlParameter("@PCList_id", PCList_id), _
            New SqlParameter("@writeOff_date", writeOff_date), _
            New SqlParameter("@borrow_date_S", borrow_date_S), _
            New SqlParameter("@borrow_date_E", borrow_date_E), _
            New SqlParameter("@pettyCash_nos_S", pettyCash_nos_S), _
            New SqlParameter("@pettyCash_nos_E", pettyCash_nos_E), _
            New SqlParameter("@beneficiary_id", beneficiary_id), _
            New SqlParameter("@use_type", use_type), _
            New SqlParameter("@invoice_date", invoice_date), _
            New SqlParameter("@paymentVoucher_id", paymentVoucher_id), _
            New SqlParameter("@PettyCash_type", PettyCash_type)}

            Return Query(sql.ToString(), sp)
        End Function

        Public Function GetOne(Orgocde As String, SerialNumber_id As Integer) As DataTable

            Dim sql As New StringBuilder()

            sql.AppendLine(" select * from PAY_LendPetty_main a left join PAY_Beneficiary_data b on a.OrgCode = b.OrgCode and a.Beneficiary_id=b.Beneficiary_id ")
            sql.AppendLine(" where ")
            sql.AppendLine(" a.Orgcode=@Orgcode and  a.SerialNumber_id=@SerialNumber_id  ")

            Dim sp() As SqlParameter = { _
         New SqlParameter("@Orgcode", Orgocde), _
         New SqlParameter("@SerialNumber_id", SerialNumber_id)}

            Return Query(sql.ToString(), sp)

        End Function

        Public Sub Delete(orgCode As String, SerialNumber_id As String)
            Dim sp() As SqlParameter = { _
           New SqlParameter("@orgCode", orgCode), _
           New SqlParameter("@SerialNumber_id", SerialNumber_id)}
            Execute(" DELETE FROM PAY_LendPetty_main WHERE orgCode=@orgCode and SerialNumber_id=@SerialNumber_id ", sp)
        End Sub

        'Insert
        Public Sub Insert(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" INSERT INTO PAY_LendPetty_main ( ")
            StrSQL.Append(" OrgCode,PettyCash_type,FiscalYear_id,PettyCash_nos,Prepay_id, ")
            StrSQL.Append(" PCList_id,PurchaseForm_id,Invoice_date,Beneficiary_id,Middleman_name, ")
            StrSQL.Append(" Use_type,Receipt_cnt,PurchaseTotal_amt,PurchaseAbstract_desc,Balance_amt, ")
            StrSQL.Append(" WriteOff_date,PaymentVoucher_id,Income_date,Income_amt,Borrow_date, ")
            StrSQL.Append(" ModUser_id,Mod_date,PurchaseForm_sn,Middleman_id ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @OrgCode,@PettyCash_type,@FiscalYear_id,@PettyCash_nos,@Prepay_id, ")
            StrSQL.Append(" @PCList_id,@PurchaseForm_id,@Invoice_date,@Beneficiary_id,@Middleman_name, ")
            StrSQL.Append(" @Use_type,@Receipt_cnt,@PurchaseTotal_amt,@PurchaseAbstract_desc,@Balance_amt, ")
            StrSQL.Append(" @WriteOff_date,@PaymentVoucher_id,@Income_date,@Income_amt,@Borrow_date, ")
            StrSQL.Append(" @ModUser_id,@Mod_date,@PurchaseForm_sn,@Middleman_id ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Function Update(ps() As SqlParameter) As Integer
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE PAY_LendPetty_main SET  ")
            StrSQL.Append(" OrgCode=@OrgCode,PettyCash_type=@PettyCash_type,FiscalYear_id=@FiscalYear_id,PettyCash_nos=@PettyCash_nos,Prepay_id=@Prepay_id, ")
            StrSQL.Append(" PCList_id=@PCList_id,PurchaseForm_id=@PurchaseForm_id,Invoice_date=@Invoice_date,Beneficiary_id=@Beneficiary_id,Middleman_name=@Middleman_name,Middleman_id=@Middleman_id,  ")
            StrSQL.Append(" Use_type=@Use_type,Receipt_cnt=@Receipt_cnt,PurchaseTotal_amt=@PurchaseTotal_amt,PurchaseAbstract_desc=@PurchaseAbstract_desc,Balance_amt=@Balance_amt, ")
            StrSQL.Append(" WriteOff_date=@WriteOff_date,PaymentVoucher_id=@PaymentVoucher_id,Income_date=@Income_date,Income_amt=@Income_amt,Borrow_date=@Borrow_date, ")
            StrSQL.Append(" ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND OrgCode=@OrgCode  ")
            StrSQL.Append("  AND SerialNumber_id=@SerialNumber_id  ")

            Return Execute(StrSQL.ToString(), ps)
        End Function

    End Class
End Namespace

