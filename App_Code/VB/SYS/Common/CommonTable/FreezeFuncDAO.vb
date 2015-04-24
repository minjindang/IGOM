Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace SYS.Logic
    Public Class FreezeFuncDAO
        Inherits BaseDAO

        Public Function getFreezeData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ProgramName As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select ff.*, f.Func_name from SYS_Freeze_Func ff ")
            sql.AppendLine(" inner join SYS_func f on ff.func_id=f.func_id ")
            sql.AppendLine(" where isFreeze = 1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and ff.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and ff.Depart_id like @Depart_id ")
                Depart_id = Depart_id.Substring(0, 2) + "%"
            End If
            If Not String.IsNullOrEmpty(ProgramName) Then
                sql.AppendLine(" and f.func_url like @ProgramName ")
            End If

            Dim para(2) As SqlParameter
            para(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            para(0).Value = Orgcode
            para(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            para(1).Value = Depart_id
            para(2) = New SqlParameter("@ProgramName", SqlDbType.VarChar)
            para(2).Value = "%" + ProgramName + "%"

            Return Query(sql.ToString(), para)
        End Function
    End Class
End Namespace
