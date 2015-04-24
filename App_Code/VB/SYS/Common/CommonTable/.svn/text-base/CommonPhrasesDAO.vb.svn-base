Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace SYS.Logic
    Public Class CommonPhrasesDAO
        Inherits BaseDAO

        Public Function getData(ByVal Orgcode As String, ByVal phrases_kind As String, ByVal phrases_type As String, _
                                ByVal phrases As String, ByVal visable_flag As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select cp.*, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where CODE_SYS='024' and CODE_TYPE='**' and CODE_NO=cp.phrases_kind) as Kind_Name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_CODE where CODE_SYS='024' and CODE_TYPE=cp.phrases_kind and CODE_NO=cp.phrases_type) as Type_Name, ")
            sql.AppendLine(" case when visable_flag = '1' then '啟用' when visable_flag = '0' then '停用' end as visable ")
            sql.AppendLine(" from SYS_common_phrases cp ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and cp.Orgcode = @Orgcode")
            End If
            If Not String.IsNullOrEmpty(phrases_kind) Then
                sql.AppendLine(" and cp.phrases_kind = @phrases_kind")
            End If
            If Not String.IsNullOrEmpty(phrases_type) Then
                sql.AppendLine(" and cp.phrases_type = @phrases_type")
            End If
            If Not String.IsNullOrEmpty(phrases) Then
                sql.AppendLine(" and cp.phrases like '%" + phrases + "%'")
            End If
            If Not String.IsNullOrEmpty(visable_flag) Then
                sql.AppendLine(" and cp.visable_flag = @visable_flag")
            End If

            Dim para(3) As SqlParameter
            para(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            para(0).Value = Orgcode
            para(1) = New SqlParameter("@phrases_kind", SqlDbType.VarChar)
            para(1).Value = phrases_kind
            para(2) = New SqlParameter("@phrases_type", SqlDbType.VarChar)
            para(2).Value = phrases_type
            para(3) = New SqlParameter("@visable_flag", SqlDbType.VarChar)
            para(3).Value = visable_flag

            Return Query(sql.ToString(), para)
        End Function
    End Class
End Namespace
