Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Namespace FSCPLM.Logic
    Public Class PAY3103DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function SelectLastBalances_amt(OrgCode As String, FiscalYear_id As String) As Double
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As New System.Text.StringBuilder
            'strSQL.AppendLine("SELECT Isnull(Max(a.YearInitial_amt) - Sum(b.PayBalances_amt), 0) AS LastBalances_amt " )
            'strSQL.AppendLine("FROM   PAY_PettyReturn_main a " )
            'strSQL.AppendLine("       INNER JOIN PAY_PettyList_main b " )
            'strSQL.AppendLine("               ON a.PettyCashInventory_id = b.PCList_id " )
            'strSQL.AppendLine("WHERE  b.FiscalYear_id = @FiscalYear_id " )
            'strSQL.AppendLine("       AND a.OrgCode = @OrgCode " )
            'strSQL.AppendLine("       AND b. OrgCode = @OrgCode ")


            strSQL.AppendLine(" select ")
            strSQL.AppendLine("     isnull((select MAX(YearInitial_amt) + SUM(Balances_amt) from PAY_PettyReturn_main where FiscalYear_id = @FiscalYear_id and OrgCode = @OrgCode),0) ")
            strSQL.AppendLine("     - ")
            strSQL.AppendLine("     isnull((select SUM(a.PayBalances_amt) from PAY_PettyList_main a ")
            strSQL.AppendLine("             inner join PAY_PettyReturn_main b on a.FiscalYear_id=b.FiscalYear_id and a.PCList_id=b.PettyCashInventory_id ")
            strSQL.AppendLine("             where a.FiscalYear_id = @FiscalYear_id and a.OrgCode = @OrgCode ),0) ")


            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@FiscalYear_id", FiscalYear_id)}
            Return Scalar(strSQL.ToString(), ps)
        End Function

        Public Function SelectPAY310101(OrgCode As String, FiscalYear_id As String, PettyCash_type As String, PCList_id As String, _
                                        PettyCashStart_nos As String, PettyCashEnd_nos As String, PrepayStart_nos As String, PrepayEnd_nos As String, _
                                        WriteOff_date As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As New System.Text.StringBuilder
            strSQL.AppendLine("SELECT isnull(a.PurchaseTotal_amt,0) PurchaseTotal_amt1,isnull(a.Income_amt,0) Income_amt1,* ")
            strSQL.AppendLine("FROM   PAY_LendPetty_main a ")
            strSQL.AppendLine("       INNER JOIN PAY_PettyList_main b ")
            strSQL.AppendLine("               ON a.FiscalYear_id = b.FiscalYear_id ")
            strSQL.AppendLine("                  AND a.OrgCode = b.OrgCode ")
            strSQL.AppendLine("                  AND a.PCList_id = b.PCList_id ")
            strSQL.AppendLine("       LEFT OUTER JOIN PAY_PettyReturn_main c ")
            strSQL.AppendLine("              ON b.PCList_id = c.PettyCashInventory_id ")
            strSQL.AppendLine("                 AND a.FiscalYear_id = b.FiscalYear_id ")
            strSQL.AppendLine("                 AND a.OrgCode = b.OrgCode ")
            strSQL.AppendLine("WHERE  a.OrgCode = @OrgCode AND a.FiscalYear_id=@FiscalYear_id ")

            If Not String.IsNullOrEmpty(PettyCash_type) Then
                strSQL.AppendLine(" AND b.PettyCash_type=@PettyCash_type ")
            End If

            If Not String.IsNullOrEmpty(PCList_id) Then
                strSQL.AppendLine(" AND b.PCList_id=@PCList_id ")
            End If

            If Not String.IsNullOrEmpty(PettyCashStart_nos) Then
                strSQL.AppendLine(" AND b.PettyCashStart_nos=@PettyCashStart_nos ")
            End If

            If Not String.IsNullOrEmpty(PettyCashEnd_nos) Then
                strSQL.AppendLine(" AND b.PettyCashEnd_nos=@PettyCashEnd_nos ")
            End If

            If Not String.IsNullOrEmpty(PrepayStart_nos) Then
                strSQL.AppendLine(" AND b.PrepayStart_nos=@PrepayStart_nos  ")
            End If

            If Not String.IsNullOrEmpty(PrepayEnd_nos) Then
                strSQL.AppendLine(" AND b.PrepayEnd_nos=@PrepayEnd_nos  ")
            End If

            If Not String.IsNullOrEmpty(WriteOff_date) Then
                strSQL.AppendLine(" AND a.WriteOff_date=@WriteOff_date ")
            End If

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@FiscalYear_id", FiscalYear_id), _
            New SqlParameter("@PettyCash_type", PettyCash_type), _
            New SqlParameter("@PCList_id", PCList_id), _
            New SqlParameter("@PettyCashStart_nos", PettyCashStart_nos), _
            New SqlParameter("@PettyCashEnd_nos", PettyCashEnd_nos), _
            New SqlParameter("@PrepayStart_nos", PrepayStart_nos), _
            New SqlParameter("@PrepayEnd_nos", PrepayEnd_nos), _
            New SqlParameter("@WriteOff_date", WriteOff_date)}

            Return Query(strSQL.ToString(), ps)
        End Function


        Public Function GetPCList_id(FiscalYear_id As String) As DataTable
            Dim szSQL As New System.Text.StringBuilder
            szSQL.AppendLine("SELECT TOP 1 REPLICATE('0',5-LEN(CONVERT(INT,PCList_id)+1)) + RTRIM(CAST(CONVERT(INT,PCList_id)+1 AS CHAR)) PCList_id ")
            szSQL.AppendLine(" FROM PAY_PettyList_main WHERE FiscalYear_id=@FiscalYear_id ORDER BY PCList_id DESC ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@FiscalYear_id", FiscalYear_id)}

            Return Query(szSQL.ToString(), ps)
        End Function


        Public Function GetAll(Orgocde As String, fiscalYear_id As String, Prepay_id_S As String, Prepay_id_E As String, _
                               pettyCash_nos_S As String, pettyCash_nos_E As String, PettyCash_type As String) As DataTable

            Dim sql As New StringBuilder()

            sql.AppendLine(" select isnull(PurchaseTotal_amt,0) PurchaseTotal_amt1,isnull(Income_amt,0) Income_amt2,* ")
            sql.AppendLine(" from PAY_LendPetty_main a left join PAY_Beneficiary_data b on a.OrgCode = b.OrgCode and a.Beneficiary_id=b.Beneficiary_id ")
            sql.AppendLine(" where ")
            sql.AppendLine(" a.Orgcode=@Orgcode and a.PCList_id is null ")
            If Not String.IsNullOrEmpty(fiscalYear_id) Then
                sql.AppendLine(" and a.fiscalYear_id=@fiscalYear_id  ")
            End If
            If Not String.IsNullOrEmpty(Prepay_id_S) Then
                sql.AppendLine(" and a.Prepay_id >=@Prepay_id_S  ")
            End If
            If Not String.IsNullOrEmpty(Prepay_id_E) Then
                sql.AppendLine(" and a.Prepay_id <=@Prepay_id_E  ")
            End If

            If Not String.IsNullOrEmpty(pettyCash_nos_S) Then
                sql.AppendLine(" and a.pettyCash_nos >=@pettyCash_nos_S  ")
            End If
            If Not String.IsNullOrEmpty(pettyCash_nos_E) Then
                sql.AppendLine(" and a.pettyCash_nos <=@pettyCash_nos_E  ")
            End If
            If Not String.IsNullOrEmpty(PettyCash_type) Then
                sql.AppendLine(" and a.PettyCash_type =@PettyCash_type  ")
            End If

            sql.AppendLine(" order by a.PettyCash_nos, a.Prepay_id ")

            Dim sp() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgocde), _
            New SqlParameter("@fiscalYear_id", fiscalYear_id), _
            New SqlParameter("@Prepay_id_S", Prepay_id_S), _
            New SqlParameter("@Prepay_id_E", Prepay_id_E), _
            New SqlParameter("@pettyCash_nos_S", pettyCash_nos_S), _
            New SqlParameter("@pettyCash_nos_E", pettyCash_nos_E), _
            New SqlParameter("@PettyCash_type", PettyCash_type)}

            Return Query(sql.ToString(), sp)
        End Function
    End Class

End Namespace
