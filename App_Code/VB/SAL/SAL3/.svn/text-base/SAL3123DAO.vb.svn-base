Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL3123DAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function getSeqno(ByVal orgid As String, ByVal idno As String) As String
            Dim rv As String = ""
            Dim tmpsql As String = ""
            tmpsql = "select base_seqno from sal_sabase where base_orgid=@orgid and base_idno=@idno "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("orgid", SqlDbType.VarChar)
            params(0).Value = orgid
            params(1) = New SqlParameter("idno", SqlDbType.VarChar)
            params(1).Value = idno

            Using t As DataTable = MyBase.Query(tmpsql, params)
                If t.Rows.Count > 0 Then
                    rv = t.Rows(0)("base_seqno").ToString
                End If
            End Using

            Return rv
        End Function

        Public Function delete() As Integer
            Dim sql As String = "delete SAL_safamily; "

            Return MyBase.Execute(sql)
        End Function

        Public Function insert(ByVal family_orgid As String, ByVal family_seqno As String, ByVal family_id As String, _
                               ByVal family_name As String, ByVal family_amt As String, ByVal family_muser As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" insert into SAL_safamily( ")
            sql.AppendLine(" family_orgid, ")
            sql.AppendLine(" family_seqno, ")
            sql.AppendLine(" family_id, ")
            sql.AppendLine(" family_name, ")
            sql.AppendLine(" family_amt, ")
            sql.AppendLine(" family_muser, ")
            sql.AppendLine(" family_mdate) ")
            sql.AppendLine(" values( ")
            sql.AppendLine(" @family_orgid, ")
            sql.AppendLine(" @family_seqno, ")
            sql.AppendLine(" @family_id, ")
            sql.AppendLine(" @family_name, ")
            sql.AppendLine(" @family_amt, ")
            sql.AppendLine(" @family_muser, ")
            sql.AppendLine(" @family_mdate )")

            Dim params(6) As SqlParameter
            params(0) = New SqlParameter("family_orgid", SqlDbType.VarChar)
            params(0).Value = family_orgid
            params(1) = New SqlParameter("family_seqno", SqlDbType.VarChar)
            params(1).Value = family_seqno
            params(2) = New SqlParameter("family_id", SqlDbType.VarChar)
            params(2).Value = family_id
            params(3) = New SqlParameter("family_name", SqlDbType.VarChar)
            params(3).Value = family_name
            params(4) = New SqlParameter("family_amt", SqlDbType.VarChar)
            params(4).Value = family_amt
            params(5) = New SqlParameter("family_muser", SqlDbType.VarChar)
            params(5).Value = family_muser
            params(6) = New SqlParameter("family_mdate", SqlDbType.VarChar)
            params(6).Value = DateTime.Now.ToString("yyyyMMddHHmmss")

            Return MyBase.Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace

