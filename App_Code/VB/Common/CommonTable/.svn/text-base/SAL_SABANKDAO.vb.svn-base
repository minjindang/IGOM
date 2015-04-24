Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_SABANKDAO
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


            StrSQL.Append(" INSERT INTO SAL_SABANK ( ")
            StrSQL.Append(" BANK_SEQNO,BANK_ORGID,BANK_SAL_ITEM,BANK_CODE,BANK_BANK_NO, ")
            StrSQL.Append(" BANK_MUSER,BANK_MDATE,BANK_TDPF_SEQNO ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @BANK_SEQNO,@BANK_ORGID,@BANK_SAL_ITEM,@BANK_CODE,@BANK_BANK_NO, ")
            StrSQL.Append(" @BANK_MUSER,@BANK_MDATE,@BANK_TDPF_SEQNO ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_SABANK SET  ")
            StrSQL.Append(" BANK_SEQNO=@BANK_SEQNO,BANK_ORGID=@BANK_ORGID,BANK_SAL_ITEM=@BANK_SAL_ITEM,BANK_CODE=@BANK_CODE,BANK_BANK_NO=@BANK_BANK_NO, ")
            StrSQL.Append(" BANK_MUSER=@BANK_MUSER,BANK_MDATE=@BANK_MDATE,BANK_TDPF_SEQNO=@BANK_TDPF_SEQNO ")
            StrSQL.Append("  WHERE 1=1  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional BANK_SEQNO As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" BANK_SEQNO,BANK_ORGID,BANK_SAL_ITEM,BANK_CODE,BANK_BANK_NO ")
            StrSQL.Append(" ,BANK_MUSER,BANK_MDATE,BANK_TDPF_SEQNO ")
            StrSQL.Append("  FROM SAL_SABANK  ")
            StrSQL.Append("  WHERE 1=1  ")

            If Not String.IsNullOrEmpty(BANK_SEQNO) Then
                StrSQL.Append(" AND BANK_SEQNO=@BANK_SEQNO ")
            End If


            Dim ps() As SqlParameter = { _
         New SqlParameter("@BANK_SEQNO", BANK_SEQNO), _
          New SqlParameter("@param2", "")}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" BANK_SEQNO,BANK_ORGID,BANK_SAL_ITEM,BANK_CODE,BANK_BANK_NO ")
            StrSQL.Append(" ,BANK_MUSER,BANK_MDATE,BANK_TDPF_SEQNO ")
            StrSQL.Append("  FROM SAL_SABANK  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = {}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete()
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_SABANK WHERE  ")
            Dim ps() As SqlParameter = {}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace