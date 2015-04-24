Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace MAI.Logic
    Public Class MAI2101DAO
        Inherits BaseDAO

        Public Function getTotalCount(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select count(*) from mai_maintain_main m ")
            sql.AppendLine(" left outer join mai_maintain_handle h on m.id=h.main_id ")
            sql.AppendLine(" where 1=1  ")
            sql.AppendLine(" and Maintain_Kind = '005' ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateS) Then
                sql.AppendLine(" and m.Apply_date >= @Apply_dateS ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateE) Then
                sql.AppendLine(" and m.Apply_date <= @Apply_dateE ")
            End If

            sql.AppendLine(" group by m.orgcode ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dateE", SqlDbType.VarChar)
            params(2).Value = Apply_dateE

            Return Scalar(sql.ToString(), params)
        End Function

        Public Function getData001(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='020' and s.code_type='005' and s.code_no=m.Maintain_type) as Maintain_type_name, ")
            sql.AppendLine(" count(*) as Num ")
            sql.AppendLine(" from mai_maintain_main m ")
            sql.AppendLine(" left outer join mai_maintain_handle h on m.id=h.main_id ")
            sql.AppendLine(" where 1= 1")
            sql.AppendLine(" and Maintain_Kind = '005' ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateS) Then
                sql.AppendLine(" and m.Apply_date >= @Apply_dateS ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateE) Then
                sql.AppendLine(" and m.Apply_date <= @Apply_dateE ")
            End If

            sql.AppendLine(" group by m.orgcode, m.Maintain_type ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dateE", SqlDbType.VarChar)
            params(2).Value = Apply_dateE

            Return Query(sql.ToString(), params)
        End Function

        Public Function getData002(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select a.Depart_Name, isnull(b.Done_Num,0) Done_Num, isnull(c.Un_Num,0) Un_Num, isnull(b.Done_Num,0) + isnull(c.Un_Num,0) as total_Num from ")
            sql.AppendLine(getSQL("002", "0") + " a ")
            sql.AppendLine(" left join ")
            sql.AppendLine(getSQL("002", "1") + " b on a.Depart_Name=b.Depart_Name ")
            sql.AppendLine(" left join ")
            sql.AppendLine(getSQL("002", "2") + " c on a.Depart_Name=c.Depart_Name ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dateE", SqlDbType.VarChar)
            params(2).Value = Apply_dateE

            Return Query(sql.ToString(), params)
        End Function

        Public Function getData003(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select a.Depart_Name, a.Apply_name, isnull(b.Done_Num,0) Done_Num, isnull(c.Un_Num,0) Un_Num, isnull(b.Done_Num,0) + isnull(c.Un_Num,0) as total_Num from ")
            sql.AppendLine(getSQL("003", "0") + " a ")
            sql.AppendLine(" left join ")
            sql.AppendLine(getSQL("003", "1") + " b on a.Depart_Name=b.Depart_Name and a.Apply_name=b.Apply_name ")
            sql.AppendLine(" left join ")
            sql.AppendLine(getSQL("003", "2") + " c on a.Depart_Name=c.Depart_Name and a.Apply_name=c.Apply_name ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dateE", SqlDbType.VarChar)
            params(2).Value = Apply_dateE

            Return Query(sql.ToString(), params)
        End Function

        Public Function getSQL(ByVal type As String, ByVal status As String) As String
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" (select ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=m.orgcode and f.depart_id=substring(m.apply_departid,1,2)) as Depart_Name ")
            sql.Append(IIf(type.Equals("003"), ", Apply_name", ""))

            If status.Equals("1") Then '已完成
                sql.AppendLine(" ,isnull(count(*),0) as Done_Num ")
            ElseIf status.Equals("2") Then '未完成
                sql.AppendLine(" ,isnull(count(*),0) as Un_Num ")
            End If

            sql.AppendLine(" from mai_maintain_main m  ")

            If status.Equals("1") Then '已完成
                sql.AppendLine(" inner join mai_maintain_handle h on h.main_id=m.id ")
            Else
                sql.AppendLine(" left outer join mai_maintain_handle h on h.main_id=m.id ")
            End If

            If status.Equals("1") Then '已完成
                sql.AppendLine(" and h.status_type = '003' ")
            ElseIf status.Equals("2") Then '未完成
                sql.AppendLine(" and h.status_type <> '003' ")
            End If

            sql.AppendLine(" where 1= 1")
            sql.AppendLine(" and Maintain_Kind = '005' ")

            sql.AppendLine(" and m.Orgcode=@Orgcode ")
            sql.AppendLine(" and m.Apply_date >= @Apply_dateS ")
            sql.AppendLine(" and m.Apply_date <= @Apply_dateE ")

            sql.AppendLine(" group by m.orgcode, substring(m.apply_departid,1,2) ").Append(IIf(type.Equals("003"), ", Apply_name)", ")"))

            Return sql.ToString()
        End Function

        Public Function getData0045(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String, ByVal type As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine(" isnull(count(*),0) as Num ")
            sql.AppendLine(" from mai_maintain_main m ")
            sql.AppendLine(" inner join mai_maintain_handle h on m.id=h.main_id ")
            sql.AppendLine(" where 1= 1")
            sql.AppendLine(" and Maintain_Kind = '005' ")
            sql.AppendLine(" and h.status_type = '003' ")

            If type.Equals("004") Then
                sql.AppendLine(" and cast(isnull(h.handle_hours,0) as integer) <= 4 ")
            ElseIf type.Equals("005") Then
                sql.AppendLine(" and m.Apply_date=h.handle_edate ")
            End If

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateS) Then
                sql.AppendLine(" and m.Apply_date >= @Apply_dateS ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateE) Then
                sql.AppendLine(" and m.Apply_date <= @Apply_dateE ")
            End If

            sql.AppendLine(" group by m.orgcode ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dateE", SqlDbType.VarChar)
            params(2).Value = Apply_dateE

            Return Query(sql.ToString(), params)

        End Function

        Public Function getData006(ByVal Orgcode As String, ByVal Apply_dateS As String, ByVal Apply_dateE As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * ")
            sql.AppendLine(" from mai_maintain_main m ")
            sql.AppendLine(" inner join mai_maintain_handle h on m.id=h.main_id ")
            sql.AppendLine(" where 1= 1")
            sql.AppendLine(" and Maintain_Kind = '005' ")
            sql.AppendLine(" and h.status_type = '003' ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateS) Then
                sql.AppendLine(" and m.Apply_date >= @Apply_dateS ")
            End If
            If Not String.IsNullOrEmpty(Apply_dateE) Then
                sql.AppendLine(" and m.Apply_date <= @Apply_dateE ")
            End If

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Apply_dateS", SqlDbType.VarChar)
            params(1).Value = Apply_dateS
            params(2) = New SqlParameter("@Apply_dateE", SqlDbType.VarChar)
            params(2).Value = Apply_dateE

            Return Query(Sql.ToString(), params)

        End Function
    End Class
End Namespace
