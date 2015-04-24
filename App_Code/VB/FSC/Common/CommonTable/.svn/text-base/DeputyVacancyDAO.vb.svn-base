Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class DeputyVacancyDAO
        Inherits BaseDAO

        Public Function getDataByid(ByVal id As String) As DataTable
            Dim sql As String = " select * from FSC_Deputy_vacancy where id=@id "

            Dim param() As SqlParameter = {New SqlParameter("@id", id)}

            Return Query(sql, param)
        End Function

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Boss_level_id As String, ByVal Title_no As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from FSC_Deputy_vacancy where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Boss_level_id) Then
                sql.AppendLine(" and Boss_level_id=@Boss_level_id ")
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                sql.AppendLine(" and Title_no=@Title_no ")
            End If

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Boss_level_id", SqlDbType.VarChar)
            params(2).Value = Boss_level_id
            params(3) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            params(3).Value = Title_no

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
