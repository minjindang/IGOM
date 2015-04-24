Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_SAPARAMETERDAO
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


            StrSQL.Append(" INSERT INTO SAL_SAPARAMETER ( ")
            StrSQL.Append(" PARAMETER_YM,PARAMETER_CODE_SYS,PARAMETER_CODE_KIND,PARAMETER_CODE_TYPE,PARAMETER_CODE_NO, ")
            StrSQL.Append(" PARAMETER_VALUE,PARAMETER_MUSER,PARAMETER_MDATE ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @PARAMETER_YM,@PARAMETER_CODE_SYS,@PARAMETER_CODE_KIND,@PARAMETER_CODE_TYPE,@PARAMETER_CODE_NO, ")
            StrSQL.Append(" @PARAMETER_VALUE,@PARAMETER_MUSER,@PARAMETER_MDATE ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_SAPARAMETER SET  ")
            StrSQL.Append(" PARAMETER_YM=@PARAMETER_YM,PARAMETER_CODE_SYS=@PARAMETER_CODE_SYS,PARAMETER_CODE_KIND=@PARAMETER_CODE_KIND,PARAMETER_CODE_TYPE=@PARAMETER_CODE_TYPE,PARAMETER_CODE_NO=@PARAMETER_CODE_NO, ")
            StrSQL.Append(" PARAMETER_VALUE=@PARAMETER_VALUE,PARAMETER_MUSER=@PARAMETER_MUSER,PARAMETER_MDATE=@PARAMETER_MDATE ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND PARAMETER_CODE_KIND=@PARAMETER_CODE_KIND  ")
            StrSQL.Append("  AND PARAMETER_CODE_NO=@PARAMETER_CODE_NO  ")
            StrSQL.Append("  AND PARAMETER_CODE_SYS=@PARAMETER_CODE_SYS  ")
            StrSQL.Append("  AND PARAMETER_CODE_TYPE=@PARAMETER_CODE_TYPE  ")
            StrSQL.Append("  AND PARAMETER_YM=@PARAMETER_YM  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Optional PARAMETER_CODE_KIND As String = "", Optional PARAMETER_CODE_NO As String = "", _
                                  Optional PARAMETER_CODE_SYS As String = "", Optional PARAMETER_CODE_TYPE As String = "", _
                                  Optional PARAMETER_YM As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" PARAMETER_YM,PARAMETER_CODE_SYS,PARAMETER_CODE_KIND,PARAMETER_CODE_TYPE,PARAMETER_CODE_NO ")
            StrSQL.Append(" ,PARAMETER_VALUE,PARAMETER_MUSER,PARAMETER_MDATE ")
            StrSQL.Append("  FROM SAL_SAPARAMETER  ")
            StrSQL.Append("  WHERE 1=1  ")

            If Not String.IsNullOrEmpty(PARAMETER_CODE_KIND) Then
                StrSQL.Append("  AND  PARAMETER_CODE_KIND = @PARAMETER_CODE_KIND ")
            End If

            If Not String.IsNullOrEmpty(PARAMETER_CODE_NO) Then
                StrSQL.Append("  AND  PARAMETER_CODE_NO = @PARAMETER_CODE_NO ")
            End If

            If Not String.IsNullOrEmpty(PARAMETER_CODE_SYS) Then
                StrSQL.Append("  AND  PARAMETER_CODE_SYS = @PARAMETER_CODE_SYS ")
            End If

            If Not String.IsNullOrEmpty(PARAMETER_CODE_TYPE) Then
                StrSQL.Append("  AND  PARAMETER_CODE_TYPE = @PARAMETER_CODE_TYPE ")
            End If

            If Not String.IsNullOrEmpty(PARAMETER_YM) Then
                StrSQL.Append("  AND  PARAMETER_YM <= @PARAMETER_YM ")
            End If
             
            StrSQL.Append("  ORDER BY PARAMETER_YM DESC ")

            Dim ps() As SqlParameter = { _
        New SqlParameter("@PARAMETER_CODE_KIND", PARAMETER_CODE_KIND), _
        New SqlParameter("@PARAMETER_CODE_NO", PARAMETER_CODE_NO), _
        New SqlParameter("@PARAMETER_CODE_SYS", PARAMETER_CODE_SYS), _
        New SqlParameter("@PARAMETER_CODE_TYPE", PARAMETER_CODE_TYPE), _
        New SqlParameter("@PARAMETER_YM", PARAMETER_YM)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(PARAMETER_CODE_KIND As String, PARAMETER_CODE_NO As String, PARAMETER_CODE_SYS As String, PARAMETER_CODE_TYPE As String, PARAMETER_YM As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" PARAMETER_YM,PARAMETER_CODE_SYS,PARAMETER_CODE_KIND,PARAMETER_CODE_TYPE,PARAMETER_CODE_NO ")
            StrSQL.Append(" ,PARAMETER_VALUE,PARAMETER_MUSER,PARAMETER_MDATE ")
            StrSQL.Append("  FROM SAL_SAPARAMETER  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND PARAMETER_CODE_KIND=@PARAMETER_CODE_KIND  ")
            StrSQL.Append("  AND PARAMETER_CODE_NO=@PARAMETER_CODE_NO  ")
            StrSQL.Append("  AND PARAMETER_CODE_SYS=@PARAMETER_CODE_SYS  ")
            StrSQL.Append("  AND PARAMETER_CODE_TYPE=@PARAMETER_CODE_TYPE  ")
            StrSQL.Append("  AND PARAMETER_YM=@PARAMETER_YM  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@PARAMETER_CODE_KIND", PARAMETER_CODE_KIND), _
         New SqlParameter("@PARAMETER_CODE_NO", PARAMETER_CODE_NO), _
         New SqlParameter("@PARAMETER_CODE_SYS", PARAMETER_CODE_SYS), _
         New SqlParameter("@PARAMETER_CODE_TYPE", PARAMETER_CODE_TYPE), _
         New SqlParameter("@PARAMETER_YM", PARAMETER_YM)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(PARAMETER_CODE_KIND As String, PARAMETER_CODE_NO As String, PARAMETER_CODE_SYS As String, PARAMETER_CODE_TYPE As String, PARAMETER_YM As String)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_SAPARAMETER WHERE  PARAMETER_CODE_KIND=@PARAMETER_CODE_KIND AND PARAMETER_CODE_NO=@PARAMETER_CODE_NO AND PARAMETER_CODE_SYS=@PARAMETER_CODE_SYS AND PARAMETER_CODE_TYPE=@PARAMETER_CODE_TYPE AND PARAMETER_YM=@PARAMETER_YM  ")
            Dim ps() As SqlParameter = {New SqlParameter("@PARAMETER_CODE_KIND", PARAMETER_CODE_KIND), New SqlParameter("@PARAMETER_CODE_NO", PARAMETER_CODE_NO), New SqlParameter("@PARAMETER_CODE_SYS", PARAMETER_CODE_SYS), New SqlParameter("@PARAMETER_CODE_TYPE", PARAMETER_CODE_TYPE), New SqlParameter("@PARAMETER_YM", PARAMETER_YM)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace