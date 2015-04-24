Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_SASTANDAO
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


            StrSQL.Append(" INSERT INTO SAL_SASTAN ( ")
            StrSQL.Append(" STAN_YM,STAN_TYPE,STAN_NO,STAN_SAL_POINT,STAN_SAL, ")
            StrSQL.Append(" STAN_MUSER,STAN_MDATE ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @STAN_YM,@STAN_TYPE,@STAN_NO,@STAN_SAL_POINT,@STAN_SAL, ")
            StrSQL.Append(" @STAN_MUSER,@STAN_MDATE ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_SASTAN SET  ")
            StrSQL.Append(" STAN_YM=@STAN_YM,STAN_TYPE=@STAN_TYPE,STAN_NO=@STAN_NO,STAN_SAL_POINT=@STAN_SAL_POINT,STAN_SAL=@STAN_SAL, ")
            StrSQL.Append(" STAN_MUSER=@STAN_MUSER,STAN_MDATE=@STAN_MDATE ")
            StrSQL.Append("  WHERE 1=1  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional STAN_NO As String = "", Optional STAN_SAL_POINT As String = "", Optional STAN_YM As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" STAN_YM,STAN_TYPE,STAN_NO,STAN_SAL_POINT,STAN_SAL ")
            StrSQL.Append(" ,STAN_MUSER,STAN_MDATE ")
            StrSQL.Append("  FROM SAL_SASTAN  ")
            StrSQL.Append("  WHERE 1=1  ")

            If Not String.IsNullOrEmpty(STAN_NO) Then
                StrSQL.Append(" AND STAN_NO = @STAN_NO ")
            End If

            If Not String.IsNullOrEmpty(STAN_SAL_POINT) Then
                StrSQL.Append(" AND STAN_SAL_POINT = @STAN_SAL_POINT ")
            End If
            If Not String.IsNullOrEmpty(STAN_YM) Then
                StrSQL.Append(" AND STAN_YM <= @STAN_YM ")
            End If

            StrSQL.Append("ORDER BY STAN_YM DESC ")

            Dim ps() As SqlParameter = { _
          New SqlParameter("@STAN_NO", STAN_NO), _
          New SqlParameter("@STAN_SAL_POINT", STAN_SAL_POINT), _
          New SqlParameter("@STAN_YM", STAN_YM)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne() As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" STAN_YM,STAN_TYPE,STAN_NO,STAN_SAL_POINT,STAN_SAL ")
            StrSQL.Append(" ,STAN_MUSER,STAN_MDATE ")
            StrSQL.Append("  FROM SAL_SASTAN  ")
            StrSQL.Append("  WHERE 1=1  ")

            Dim ps() As SqlParameter = {}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete()
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_SASTAN WHERE  ")
            Dim ps() As SqlParameter = {}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace