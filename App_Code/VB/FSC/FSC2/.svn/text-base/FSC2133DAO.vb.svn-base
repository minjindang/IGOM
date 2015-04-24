Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2133DAO
        Inherits BaseDAO

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal id_card2 As String, _
                                ByVal Employee_type As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select p.*, d.Orgcode, d.depart_id, ")
            sql.AppendLine(" (select top 1 Depart_name from fSC_org f where f.orgcode=d.orgcode and f.depart_id=d.depart_id) as Depart_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from sys_code s where s.code_sys='023' and s.code_type='012' and s.code_no=p.title_no) as Title_name ")
            sql.AppendLine(" from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_Depart_emp d on p.id_card=d.id_card ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and d.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (d.Depart_id = @Depart_id or d.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and p.id_card = @id_card ")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sql.AppendLine(" and p.id_card = @id_card2 ")
            End If
            If Not String.IsNullOrEmpty(Employee_type) Then
                sql.AppendLine(" and p.Employee_type = @Employee_type ")
            End If

            Dim params(4) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(2).Value = id_card
            params(3) = New SqlParameter("@id_card2", SqlDbType.VarChar)
            params(3).Value = id_card2
            params(4) = New SqlParameter("@Employee_type", SqlDbType.VarChar)
            params(4).Value = Employee_type

            Return Query(sql.ToString, params)
        End Function

        Public Function getLeaveHours(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal Start_date As String, _
                                      ByVal End_date As String) As Object
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select sum(isnull(leave_hours,0)) as leave_hours ")
            sql.AppendLine(" from FSC_leave_main l ")
            sql.AppendLine(" inner join sys_flow f on f.flow_id =l.flow_id ")
            sql.AppendLine(" where l.leave_type = '03' ")
            sql.AppendLine(" and f.case_status = 1 and f.last_pass = 1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and l.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (l.Depart_id = @Depart_id or l.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and l.id_card = @id_card ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" and l.Start_date >= @Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sql.AppendLine(" and l.End_date <= @End_date ")
            End If

            Dim params(4) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(2).Value = id_card
            params(3) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            params(3).Value = Start_date
            params(4) = New SqlParameter("@End_date", SqlDbType.VarChar)
            params(4).Value = End_date

            Return Scalar(sql.ToString, params)
        End Function
    End Class
End Namespace
