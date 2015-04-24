Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_EXAMINE_feeDAO
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
            StrSQL.Append(" INSERT INTO SAL_EXAMINE_fee ( ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,BASE_IDNO, ")
            StrSQL.Append(" BASE_NAME,BASE_SERVICE_PLACE_DESC,BASE_DCODE_NAME,Meeting_pos,Meeting_date, ")
            StrSQL.Append(" Meeting_content,BASE_ADDR,Pay_type,BASE_BANK_CODE,BASE_BANK_NO, ")
            StrSQL.Append(" BANK_TDPF_SEQNO,Budget_code,Item_code,Apply_amt,Health_Insurance, ")
            StrSQL.Append(" Receive_fee,Pay_date,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Flow_id,@User_id,@Unit_code,@Apply_date,@BASE_IDNO, ")
            StrSQL.Append(" @BASE_NAME,@BASE_SERVICE_PLACE_DESC,@BASE_DCODE_NAME,@Meeting_pos,@Meeting_date, ")
            StrSQL.Append(" @Meeting_content,@BASE_ADDR,@Pay_type,@BASE_BANK_CODE,@BASE_BANK_NO, ")
            StrSQL.Append(" @BANK_TDPF_SEQNO,@Budget_code,@Item_code,@Apply_amt,@Health_Insurance, ")
            StrSQL.Append(" @Receive_fee,@Pay_date,@Org_code,@ModUser_id,@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" UPDATE SAL_EXAMINE_fee SET  ")
            StrSQL.Append(" Flow_id=@Flow_id,User_id=@User_id,Unit_code=@Unit_code,Apply_date=@Apply_date,BASE_IDNO=@BASE_IDNO, ")
            StrSQL.Append(" BASE_NAME=@BASE_NAME,BASE_SERVICE_PLACE_DESC=@BASE_SERVICE_PLACE_DESC,BASE_DCODE_NAME=@BASE_DCODE_NAME,Meeting_pos=@Meeting_pos,Meeting_date=@Meeting_date, ")
            StrSQL.Append(" Meeting_content=@Meeting_content,BASE_ADDR=@BASE_ADDR,Pay_type=@Pay_type,BASE_BANK_CODE=@BASE_BANK_CODE,BASE_BANK_NO=@BASE_BANK_NO, ")
            StrSQL.Append(" BANK_TDPF_SEQNO=@BANK_TDPF_SEQNO,Budget_code=@Budget_code,Item_code=@Item_code,Apply_amt=@Apply_amt,Health_Insurance=@Health_Insurance, ")
            StrSQL.Append(" Receive_fee=@Receive_fee,Pay_date=@Pay_date,Org_code=@Org_code,ModUser_id=@ModUser_id,Mod_date=@Mod_date ")
            StrSQL.Append("  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Optional Flow_id As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,BASE_IDNO, ")
            StrSQL.Append(" BASE_NAME,BASE_SERVICE_PLACE_DESC,BASE_DCODE_NAME,Meeting_pos,Meeting_date, ")
            StrSQL.Append(" Meeting_content,BASE_ADDR,Pay_type,BASE_BANK_CODE,BASE_BANK_NO, ")
            StrSQL.Append(" BANK_TDPF_SEQNO,Budget_code,Item_code,Apply_amt,Health_Insurance, ")
            StrSQL.Append(" Receive_fee,Pay_date,Org_code,ModUser_id,Mod_date, ")
            StrSQL.Append(" (select top 1 BASE_SEQNO from SAL_SABASE as i where  SAL_EXAMINE_fee.BASE_IDNO = i.BASE_IDNO) as SEQNO")
            StrSQL.Append("  FROM SAL_EXAMINE_fee  ")
            StrSQL.Append("  WHERE Org_code=@Org_code  ")

            If Not String.IsNullOrEmpty(Flow_id) Then
                StrSQL.Append("  AND Flow_id=@Flow_id  ")
            End If

            Dim ps() As SqlParameter = { _
                New SqlParameter("@Org_code", Org_code), _
                New SqlParameter("@Flow_id", Flow_id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ALL
        Public Function SelectAll(BASE_IDNO As String, Meeting_date As String, Meeting_content As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" SELECT a.BASE_IDNO ")
            StrSQL.Append(" FROM SAL_EXAMINE_fee a inner join SYS_Flow b on a.Flow_id=b.Flow_id ")
            StrSQL.Append("  WHERE a.BASE_IDNO=@BASE_IDNO AND a.Meeting_date=@Meeting_date AND a.Meeting_content=@Meeting_content AND b.Case_status in ('0','1','2')")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@BASE_IDNO", BASE_IDNO), _
                New SqlParameter("@Meeting_date", Meeting_date), _
                New SqlParameter("@Meeting_content", Meeting_content)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Flow_id,User_id,Unit_code,Apply_date,BASE_IDNO, ")
            StrSQL.Append(" BASE_NAME,BASE_SERVICE_PLACE_DESC,BASE_DCODE_NAME,Meeting_pos,Meeting_date, ")
            StrSQL.Append(" Meeting_content,BASE_ADDR,Pay_type,BASE_BANK_CODE,BASE_BANK_NO, ")
            StrSQL.Append(" BANK_TDPF_SEQNO,Budget_code,Item_code,Apply_amt,Health_Insurance, ")
            StrSQL.Append(" Receive_fee,Pay_date,Org_code,ModUser_id,Mod_date ")
            StrSQL.Append("  FROM SAL_EXAMINE_fee  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        '1030617
        Public Function SelectID(count As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            Dim a As Integer = count
            StrSQL.Append(" SELECT TOP " & a & " * FROM SAL_EXAMINE_fee ORDER BY Flow_id DESC ")
            Dim ps() As SqlParameter = { _
                New SqlParameter("@count", count)}
            Return Query(StrSQL.ToString(), ps)
        End Function
        Public Function SelectIDData(Id As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" SELECT * FROM SAL_EXAMINE_fee WHERE Id = @Id ")
            Dim ps() As SqlParameter = { _
                New SqlParameter("@Id", Id)}
            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_EXAMINE_fee WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = { _
                New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub

        Public Sub DeleteByFid(ByVal flow_id As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_EXAMINE_fee WHERE  flow_id=@flow_id  ")

            Dim ps() As SqlParameter = { _
                New SqlParameter("@flow_id", flow_id)}

            Execute(StrSQL.ToString(), ps)
        End Sub
    End Class
End Namespace