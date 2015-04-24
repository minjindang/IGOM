Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL4106DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal Apply_type As String, _
                                     ByVal AcademicYear As String, _
                                     ByVal Apply_sTime As String, _
                                     ByVal Apply_eTime As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT a.Apply_type, ")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE AS i WHERE code_sys = '006' and CODE_TYPE ='019' AND i.CODE_NO = a.apply_type) AS Apply_typeName,")
            sql.AppendLine(" id,AcademicYear,Semester,Apply_sDate,Apply_sTime,Apply_eDate,Apply_eTime, Status")
            sql.AppendLine(" FROM SAL_EDU_Setting AS a")
            sql.AppendLine(" WHERE 1=1")
            If Not String.IsNullOrEmpty(Apply_type) Then
                sql.AppendLine(" and Apply_type = @Apply_type ")
            End If
            If Not String.IsNullOrEmpty(AcademicYear) Then
                sql.AppendLine(" and AcademicYear = @AcademicYear ")
            End If
            If Not String.IsNullOrEmpty(Apply_sTime) Then
                sql.AppendLine(" and Apply_sDate >= @Apply_sTime ")
            End If
            If Not String.IsNullOrEmpty(Apply_eTime) Then
                sql.AppendLine(" and Apply_eDate <= @Apply_eTime ")
            End If
            sql.AppendLine(" ORDER BY AcademicYear")
            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Apply_type", SqlDbType.VarChar)
            aryParms(0).Value = Apply_type
            aryParms(1) = New SqlParameter("@AcademicYear", SqlDbType.VarChar)
            aryParms(1).Value = AcademicYear
            aryParms(2) = New SqlParameter("@Apply_sTime", SqlDbType.VarChar)
            aryParms(2).Value = Apply_sTime
            aryParms(3) = New SqlParameter("@Apply_eTime", SqlDbType.VarChar)
            aryParms(3).Value = Apply_eTime
            Return Query(sql.ToString(), aryParms)
        End Function

        Public Function getQueryDataByID(ByVal id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT *,")
            sql.AppendLine(" (select CODE_DESC1 from SYS_CODE AS i WHERE code_sys = '006' and CODE_TYPE ='019' AND i.CODE_NO = a.apply_type) AS ApplyType")
            sql.AppendLine(" FROM SAL_EDU_Setting AS a")
            sql.AppendLine(" WHERE id = @id")
            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@id", SqlDbType.VarChar)
            aryParms(0).Value = id
            Return Query(sql.ToString(), aryParms)
        End Function
        Public Function getInsertData(ByVal Apply_type As String, _
                                 ByVal AcademicYear As String, _
                                 ByVal Semester As String, _
                                 ByVal Apply_sDate As String, _
                                 ByVal Apply_sTime As String, _
                                 ByVal Apply_eDate As String, _
                                 ByVal Apply_eTime As String, _
                                 ByVal Status As String, _
                                 ByVal ModUser_id As String, _
                                 ByVal orgcode As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" INSERT INTO SAL_EDU_Setting VALUES (@Apply_type, @AcademicYear, @Semester, @Apply_sDate, ")
            sql.AppendLine(" @Apply_sTime, @Apply_eDate, @Apply_eTime, @Status, @ModUser_id, getDate(), @orgcode)")

            Dim aryParms(9) As SqlParameter
            aryParms(0) = New SqlParameter("@Apply_type", SqlDbType.VarChar)
            aryParms(0).Value = Apply_type
            aryParms(1) = New SqlParameter("@AcademicYear", SqlDbType.VarChar)
            aryParms(1).Value = AcademicYear
            aryParms(2) = New SqlParameter("@Semester", SqlDbType.VarChar)
            aryParms(2).Value = Semester
            aryParms(3) = New SqlParameter("@Apply_sDate", SqlDbType.VarChar)
            aryParms(3).Value = Apply_sDate
            aryParms(4) = New SqlParameter("@Apply_sTime", SqlDbType.VarChar)
            aryParms(4).Value = Apply_sTime
            aryParms(5) = New SqlParameter("@Apply_eDate", SqlDbType.VarChar)
            aryParms(5).Value = Apply_eDate
            aryParms(6) = New SqlParameter("@Apply_eTime", SqlDbType.VarChar)
            aryParms(6).Value = Apply_eTime
            aryParms(7) = New SqlParameter("@Status", SqlDbType.VarChar)
            aryParms(7).Value = Status
            aryParms(8) = New SqlParameter("@ModUser_id", SqlDbType.VarChar)
            aryParms(8).Value = ModUser_id
            aryParms(9) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            aryParms(9).Value = orgcode

            Return Execute(sql.ToString(), aryParms)
        End Function

        Public Function getUpdateData(ByVal AcademicYear As String, _
                                ByVal Semester As String, _
                                ByVal Apply_sDate As String, _
                                ByVal Apply_sTime As String, _
                                ByVal Apply_eDate As String, _
                                ByVal Apply_eTime As String, _
                                ByVal Status As String, _
                                ByVal ModUser_id As String, _
                                ByVal orgcode As String, _
                                ByVal id As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine("UPDATE SAL_EDU_Setting SET AcademicYear = @AcademicYear, Semester = @Semester, Apply_sDate = @Apply_sDate,")
            sql.AppendLine(" Apply_sTime = @Apply_sTime, Apply_eDate = @Apply_eDate, Apply_eTime = @Apply_eTime, Status = @Status,")
            sql.AppendLine(" ModUser_id = @ModUser_id, Mod_date = getDate(), Org_code = @orgcode WHERE id = @id")

            Dim aryParms(9) As SqlParameter
            aryParms(0) = New SqlParameter("@AcademicYear", SqlDbType.VarChar)
            aryParms(0).Value = AcademicYear
            aryParms(1) = New SqlParameter("@Semester", SqlDbType.VarChar)
            aryParms(1).Value = Semester
            aryParms(2) = New SqlParameter("@Apply_sDate", SqlDbType.VarChar)
            aryParms(2).Value = Apply_sDate
            aryParms(3) = New SqlParameter("@Apply_sTime", SqlDbType.VarChar)
            aryParms(3).Value = Apply_sTime
            aryParms(4) = New SqlParameter("@Apply_eDate", SqlDbType.VarChar)
            aryParms(4).Value = Apply_eDate
            aryParms(5) = New SqlParameter("@Apply_eTime", SqlDbType.VarChar)
            aryParms(5).Value = Apply_eTime
            aryParms(6) = New SqlParameter("@Status", SqlDbType.VarChar)
            aryParms(6).Value = Status
            aryParms(7) = New SqlParameter("@ModUser_id", SqlDbType.VarChar)
            aryParms(7).Value = ModUser_id
            aryParms(8) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            aryParms(8).Value = orgcode
            aryParms(9) = New SqlParameter("@id", SqlDbType.VarChar)
            aryParms(9).Value = id

            Return Execute(sql.ToString(), aryParms)
        End Function
        Public Function getDeleteSelectData(ByVal Apply_type As String, _
                              ByVal id As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine("SELECT TOP 1 * FROM SAL_EDU_Setting WHERE Apply_type=@Apply_type AND id <> @id ORDER BY Apply_eDate DESC ")

            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Apply_type", SqlDbType.VarChar)
            aryParms(0).Value = Apply_type
            aryParms(1) = New SqlParameter("@id", SqlDbType.VarChar)
            aryParms(1).Value = id

            Return Query(sql.ToString(), aryParms)
        End Function
        Public Function getDeleteData(ByVal id As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine("DELETE FROM SAL_EDU_Setting WHERE id = @id")

            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@id", SqlDbType.VarChar)
            aryParms(0).Value = id

            Return Execute(sql.ToString(), aryParms)
        End Function

        Public Function getFlowData(ByVal Form_id As String, ByVal Sdate As String, ByVal Edate As String) As DataTable
            Dim tableName As String = ""
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from sys_flow f ")

            If Form_id = "002005" Then
                tableName = "SAL_EDU_fee"
            ElseIf Form_id = "002012" OrElse Form_id = "002013" Then
                tableName = "SAL_PROOF_rpt"
            ElseIf Form_id = "002008" OrElse Form_id = "002018" Then
                tableName = "FSC_Settlement_Annual"
            End If

            sql.AppendLine(" inner join " + tableName + " a on a.flow_id = f.flow_id and left(Apply_date,7) between @Sdate and @Edate ")
            sql.AppendLine(" where f.Form_id=@Form_id and f.Case_status not in (2,3,4) ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@Form_id", SqlDbType.VarChar)
            params(0).Value = Form_id
            params(1) = New SqlParameter("@Sdate", SqlDbType.VarChar)
            params(1).Value = Sdate
            params(2) = New SqlParameter("@Edate", SqlDbType.VarChar)
            params(2).Value = Edate

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
