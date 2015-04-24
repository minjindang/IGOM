Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS3108DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        ''' <summary>
        ''' 簽核流程設定的查詢
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="Depart_id"></param>
        ''' <param name="target"></param>
        ''' <param name="targetType"></param>
        ''' <param name="Form_id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal target() As String, ByVal targetType() As String, ByVal Form_id As String) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select distinct flow_outpost_id ")
            sql.AppendLine(" from SYS_Flow_outpost_master a ")
            sql.AppendLine(" where a.orgcode=@orgcode ")


            Dim k As Integer = 0
            If Not String.IsNullOrEmpty(Form_id) Then
                k += 1
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                k += 1
            End If

            Dim params(k + target.Length + targetType.Length) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode


            k = 0

            If Not String.IsNullOrEmpty(Form_id) Then
                sql.AppendLine(" and a.flow_outpost_id in (select b.flow_outpost_id from SYS_Flow_outpost_form b where b.form_id like @Form_id ) ")

                k += 1
                params(k) = New SqlParameter("@Form_id", SqlDbType.VarChar)
                params(k).Value = Form_id & "%"
            End If


            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and a.flow_outpost_id in ( ")
                sql.AppendLine(" select c.flow_outpost_id from SYS_Flow_outpost_target c where c.depart_id=@Depart_id or c.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")

                k += 1
                params(k) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
                params(k).Value = Depart_id

            End If


            If target IsNot Nothing AndAlso target.Length > 0 Then

                sql.AppendLine(" and a.flow_outpost_id in ( ")
                sql.AppendLine("    select c.flow_outpost_id from SYS_Flow_outpost_target c where 1=1 ")

                sql.AppendLine("    and ( ")
                For i As Integer = 0 To target.Length - 1
                    If i <> 0 Then
                        sql.Append(" or ")
                    End If

                    If Not String.IsNullOrEmpty(target(i)) Then
                        sql.AppendLine(" (c.target=@target" & i & " and c.target_type=@targetType" & i & ") ")
                    End If

                    k += 1
                    params(k + i) = New SqlParameter("@target" & i, SqlDbType.VarChar)
                    params(k + i).Value = target(i)

                    k += 1
                    params(k + i) = New SqlParameter("@targetType" & i, SqlDbType.VarChar)
                    params(k + i).Value = targetType(i)


                Next
                sql.AppendLine("    ) ")
                sql.AppendLine(" ) ")
            End If


            'sql.AppendLine(" SELECT distinct ")
            'sql.AppendLine("    fof.form_id, ")
            'sql.AppendLine("    fof.Flow_outpost_id ")
            'sql.AppendLine(" FROM SYS_Flow_outpost_target fot ")
            'sql.AppendLine(" inner join SYS_Flow_outpost_form fof on fot.flow_outpost_id=fof.flow_outpost_id ")
            'sql.AppendLine(" WHERE fot.Orgcode=@Orgcode  ")

            'If Not String.IsNullOrEmpty(Depart_id) Then
            '    sql.AppendLine(" and (fot.Depart_id=@Depart_id or fot.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            'End If
            'If Not String.IsNullOrEmpty(formId) Then
            '    If formId.Length = 3 Then
            '        sql.AppendLine(" and fof.form_id like @formId ")
            '        formId = formId & "%"
            '    Else
            '        sql.AppendLine(" and fof.form_id=@formId ")
            '    End If
            'End If

            'Dim params(2 + target.Length + targetType.Length) As SqlParameter
            'params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            'params(0).Value = Orgcode
            'params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            'params(1).Value = Depart_id
            'params(2) = New SqlParameter("@formId", SqlDbType.VarChar)
            'params(2).Value = formId

            'If target IsNot Nothing AndAlso target.Length > 0 Then
            '    Dim j As Integer = 0

            '    sql.AppendLine(" and ( ")
            '    For i As Integer = 0 To target.Length - 1
            '        If i <> 0 Then
            '            sql.Append(" or ")
            '        End If

            '        If Not String.IsNullOrEmpty(target(i)) Then
            '            sql.AppendLine(" (fot.target=@target" & i & " and fot.target_type=@targetType" & i & ") ")
            '        End If

            '        params(3 + j) = New SqlParameter("@target" & i, SqlDbType.VarChar)
            '        params(3 + j).Value = target(i)
            '        params(4 + j) = New SqlParameter("@targetType" & i, SqlDbType.VarChar)
            '        params(4 + j).Value = targetType(i)

            '        j += 2
            '    Next
            '    sql.AppendLine(" ) ")
            'End If
            'sql.AppendLine(" order by fof.form_id, fof.flow_outpost_id ")

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetData2(ByVal orgcode As String, ByVal departId As String, ByVal target As String, ByVal targetType As String, ByVal formId As String) As DataTable
            Dim sql As New StringBuilder

            sql.AppendLine(" select b.* from SYS_Flow_outpost_target a ")
            sql.AppendLine(" inner join SYS_Flow_outpost_form b on a.Flow_outpost_id=b.Flow_outpost_id ")
            sql.AppendLine(" where ")
            sql.AppendLine(" a.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and a.depart_id=@departId")
            End If

            sql.AppendLine(" and a.target=@target and a.target_type=@targetType ")

            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 6 Then
                    sql.AppendLine(" and b.form_id=@formId ")
                Else
                    sql.AppendLine(" and b.form_id like @formId ")
                    formId = formId & "%"
                End If
            End If

            sql.AppendLine(" order by b.flow_outpost_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@target", target), _
            New SqlParameter("@targetType", targetType), _
            New SqlParameter("@formId", formId)}

            Return Query(sql.ToString(), params)
        End Function


        Public Function GetData3(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String, ByVal formId As String) As DataTable
            Dim sql As New StringBuilder


            sql.AppendLine(" SELECT ")
            sql.AppendLine("    Distinct fot.Depart_id, ")
            sql.AppendLine("    (select top 1 Depart_name from fsc_org f where fot.Orgcode=f.Orgcode AND fot.depart_id=f.depart_id) as Depart_name, ")
            sql.AppendLine("    fot.Flow_outpost_id, fof.form_id, fom.id ")
            sql.AppendLine(" FROM SYS_Flow_outpost_target fot ")
            sql.AppendLine(" inner join SYS_Flow_outpost_form fof on fot.flow_outpost_id=fof.flow_outpost_id ")
            sql.AppendLine(" inner join SYS_Flow_outpost_master fom on fot.flow_outpost_id=fom.flow_outpost_id ")
            sql.AppendLine(" WHERE fot.Orgcode=@Orgcode  ")


            If Not String.IsNullOrEmpty(departId) Then
                sql.AppendLine(" and fom.outpost_departid=@departId")
            End If

            If Not String.IsNullOrEmpty(idCard) Then
                sql.AppendLine(" and fom.outpost_id=@idCard")
            End If


            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 6 Then
                    sql.AppendLine(" and fof.form_id=@formId ")
                Else
                    sql.AppendLine(" and fof.form_id like @formId ")
                    formId = formId & "%"
                End If
            End If

            sql.AppendLine(" order by fot.flow_outpost_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@idCard", idCard), _
            New SqlParameter("@formId", formId)}

            Return Query(sql.ToString(), params)
        End Function
    End Class

End Namespace
