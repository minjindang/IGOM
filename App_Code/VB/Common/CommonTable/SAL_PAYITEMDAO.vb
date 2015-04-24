Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_PAYITEMDAO
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


            StrSQL.Append(" INSERT INTO SAL_PAYITEM ( ")
            StrSQL.Append(" PAYITEM_Org_Code,PAYITEM_User_id,PAYITEM_Flow_id,PAYITEM_Merge_flow_id,PAYITEM_CodeSys, ")
            StrSQL.Append(" PAYITEM_CodeKind,PAYITEM_CodeType,PAYITEM_CodeNo,PAYITEM_Code,PAYITEM_Pay_ym, ")
            StrSQL.Append(" PAYITEM_Pay_date,PAYITEM_Budget_code,PAYITEM_Pay_amt,PAYITEM_ModUser_id,PAYITEM_Mod_date, ")
            StrSQL.Append(" PAYITEM_Memo ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @PAYITEM_Org_Code,@PAYITEM_User_id,@PAYITEM_Flow_id,@PAYITEM_Merge_flow_id,@PAYITEM_CodeSys, ")
            StrSQL.Append(" @PAYITEM_CodeKind,@PAYITEM_CodeType,@PAYITEM_CodeNo,@PAYITEM_Code,@PAYITEM_Pay_ym, ")
            StrSQL.Append(" @PAYITEM_Pay_date,@PAYITEM_Budget_code,@PAYITEM_Pay_amt,@PAYITEM_ModUser_id,@PAYITEM_Mod_date, ")
            StrSQL.Append(" @PAYITEM_Memo ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_PAYITEM SET  ")
            StrSQL.Append(" PAYITEM_Org_Code=@PAYITEM_Org_Code,PAYITEM_User_id=@PAYITEM_User_id,PAYITEM_Flow_id=@PAYITEM_Flow_id,PAYITEM_Merge_flow_id=@PAYITEM_Merge_flow_id,PAYITEM_CodeSys=@PAYITEM_CodeSys, ")
            StrSQL.Append(" PAYITEM_CodeKind=@PAYITEM_CodeKind,PAYITEM_CodeType=@PAYITEM_CodeType,PAYITEM_CodeNo=@PAYITEM_CodeNo,PAYITEM_Code=@PAYITEM_Code,PAYITEM_Pay_ym=@PAYITEM_Pay_ym, ")
            StrSQL.Append(" PAYITEM_Pay_date=@PAYITEM_Pay_date,PAYITEM_Budget_code=@PAYITEM_Budget_code,PAYITEM_Pay_amt=@PAYITEM_Pay_amt,PAYITEM_ModUser_id=@PAYITEM_ModUser_id,PAYITEM_Mod_date=@PAYITEM_Mod_date, ")
            StrSQL.Append(" PAYITEM_Memo=@PAYITEM_Memo ")
            StrSQL.Append("  WHERE 1=1  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" PAYITEM_Org_Code,PAYITEM_User_id,PAYITEM_Flow_id,PAYITEM_Merge_flow_id,PAYITEM_CodeSys, ")
            StrSQL.Append(" PAYITEM_CodeKind,PAYITEM_CodeType,PAYITEM_CodeNo,PAYITEM_Code,PAYITEM_Pay_ym, ")
            StrSQL.Append(" PAYITEM_Pay_date,PAYITEM_Budget_code,PAYITEM_Pay_amt,PAYITEM_ModUser_id,PAYITEM_Mod_date ")
            StrSQL.Append(" ,PAYITEM_Memo ")
            StrSQL.Append("  FROM SAL_PAYITEM  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@param1", ""), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" PAYITEM_Org_Code,PAYITEM_User_id,PAYITEM_Flow_id,PAYITEM_Merge_flow_id,PAYITEM_CodeSys, ")
            StrSQL.Append(" PAYITEM_CodeKind,PAYITEM_CodeType,PAYITEM_CodeNo,PAYITEM_Code,PAYITEM_Pay_ym, ")
            StrSQL.Append(" PAYITEM_Pay_date,PAYITEM_Budget_code,PAYITEM_Pay_amt,PAYITEM_ModUser_id,PAYITEM_Mod_date ")
            StrSQL.Append(" ,PAYITEM_Memo ")
            StrSQL.Append("  FROM SAL_PAYITEM  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = {}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete()
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_PAYITEM WHERE  ")
            Dim ps() As SqlParameter = {}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace