Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic
    Public Class CPAPD04MDAO
        Inherits BaseDAO

        Public Function update(ByVal Orgcode As String, ByVal Depart_id As String, ByVal PDYEARB As String, ByVal PDYEARE As String, _
                               ByVal PDDAYS As String, ByVal Change_userid As String, _
                               ByVal CPDKIND As String, ByVal CPDMEMCOD As String, ByVal CPDVTYPE As String, ByVal CPDYEARB As String) As Integer

            Dim sql As New StringBuilder()
            sql.AppendLine(" UPDATE FSC_CPAPD04M SET PDYEARB=@PDYEARB, PDYEARE=@PDYEARE, PDDAYS=@PDDAYS, Change_userid=@Change_userid, Change_date=@Change_date, ")
            sql.AppendLine(" Orgcode=@Orgcode, Depart_id=@Depart_id ")
            sql.AppendLine(" WHERE PDKIND=@CPDKIND AND PDMEMCOD=@CPDMEMCOD AND PDVTYPE=@CPDVTYPE AND PDYEARB=@CPDYEARB")

            Dim params() As SqlParameter = { _
             New SqlParameter("@PDYEARB", PDYEARB), _
             New SqlParameter("@PDYEARE", PDYEARE), _
             New SqlParameter("@PDDAYS", PDDAYS), _
             New SqlParameter("@Change_userid", Change_userid), _
             New SqlParameter("@Change_date", Now), _
             New SqlParameter("@CPDKIND", CPDKIND), _
             New SqlParameter("@CPDMEMCOD", CPDMEMCOD), _
             New SqlParameter("@CPDVTYPE", CPDVTYPE), _
             New SqlParameter("@CPDYEARB", CPDYEARB), _
             New SqlParameter("@Orgcode", Orgcode), _
             New SqlParameter("@Depart_id", Depart_id)}

            Return Execute(sql.ToString(), params)
        End Function

        Public Function GetDataByQuery(ByVal PDKIND As String, ByVal PDMEMCOD As String, ByVal PDVTYPE As String, ByVal PDYEARB As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPD04M WHERE PDKIND=@PDKIND    ")

            If Not String.IsNullOrEmpty(PDMEMCOD) Then
                StrSQL.AppendLine(" AND PDMEMCOD=@PDMEMCOD ")
            End If
            If Not String.IsNullOrEmpty(PDVTYPE) Then
                StrSQL.AppendLine(" AND PDVTYPE=@PDVTYPE ")
            End If
            If Not String.IsNullOrEmpty(PDYEARB) Then
                StrSQL.AppendLine(" AND PDYEARB=@PDYEARB ")
            End If
            StrSQL.AppendLine(" ORDER BY PDMEMCOD, PDVTYPE, PDYEARB")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@PDKIND", SqlDbType.VarChar)
            params(0).Value = PDKIND
            params(1) = New SqlParameter("@PDMEMCOD", SqlDbType.VarChar)
            params(1).Value = PDMEMCOD
            params(2) = New SqlParameter("@PDVTYPE", SqlDbType.VarChar)
            params(2).Value = PDVTYPE
            params(3) = New SqlParameter("@PDYEARB", SqlDbType.VarChar)
            params(3).Value = PDYEARB

            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetDataByQuery(ByVal PDKIND As String, ByVal PDMEMCOD As String, ByVal PDVTYPE As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM FSC_CPAPD04M WHERE PDKIND=@PDKIND  ")

            If Not String.IsNullOrEmpty(PDMEMCOD) Then
                StrSQL.AppendLine(" AND PDMEMCOD=@PDMEMCOD ")
            End If
            If Not String.IsNullOrEmpty(PDVTYPE) Then
                StrSQL.AppendLine(" AND PDVTYPE=@PDVTYPE ")
            End If

            StrSQL.AppendLine(" ORDER BY PDMEMCOD, PDVTYPE, PDYEARB")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@PDKIND", SqlDbType.VarChar)
            params(0).Value = PDKIND
            params(1) = New SqlParameter("@PDMEMCOD", SqlDbType.VarChar)
            params(1).Value = PDMEMCOD
            params(2) = New SqlParameter("@PDVTYPE", SqlDbType.VarChar)
            params(2).Value = PDVTYPE

            Return Query(StrSQL.ToString(), params)
        End Function


        Public Function GetPDDAYS(ByVal PEIDNO As String, ByVal PDVTYPE As String) As Object
            Dim sql As New StringBuilder
            sql.AppendLine("SELECT pd.PDDAYS ")
            sql.AppendLine("FROM FSC_CPAPD04M pd inner join CPAPE05M pe ON pd.PDKIND=pe.PEKIND and pd.PDMEMCOD=pe.PEMEMCOD ")
            sql.AppendLine("WHERE pe.PEIDNO=@PEIDNO AND pd.PDVTYPE=@PDVTYPE ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@PEIDNO", SqlDbType.VarChar)
            params(0).Value = PEIDNO
            params(1) = New SqlParameter("@PDVTYPE", SqlDbType.VarChar)
            params(1).Value = PDVTYPE

            Return Scalar(sql.ToString(), params)
        End Function

    End Class
End Namespace