Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Namespace FSCPLM.Logic
    Public Class SAL_EDU_SettingDAO
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


            StrSQL.Append(" INSERT INTO SAL_EDU_Setting ( ")
            StrSQL.Append(" Apply_type,AcademicYear,Semester,Apply_sDate,Apply_sTime, ")
            StrSQL.Append(" Apply_eDate,Apply_eTime,Status,ModUser_id,Mod_date, ")
            StrSQL.Append(" Org_code ")
            StrSQL.Append(") VALUES ( ")
            StrSQL.Append(" @Apply_type,@AcademicYear,@Semester,@Apply_sDate,@Apply_sTime, ")
            StrSQL.Append(" @Apply_eDate,@Apply_eTime,@Status,@ModUser_id,@Mod_date, ")
            StrSQL.Append(" @Org_code ")
            StrSQL.Append(" ) ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'Update
        Public Sub Update(ps() As SqlParameter)
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" UPDATE SAL_EDU_Setting SET  ")
            StrSQL.Append(" Apply_type=@Apply_type,AcademicYear=@AcademicYear,Semester=@Semester,Apply_sDate=@Apply_sDate,Apply_sTime=@Apply_sTime, ")
            StrSQL.Append(" Apply_eDate=@Apply_eDate,Apply_eTime=@Apply_eTime,Status=@Status,ModUser_id=@ModUser_id,Mod_date=@Mod_date, ")
            StrSQL.Append(" Org_code=@Org_code ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Execute(StrSQL.ToString(), ps)
        End Sub

        'SELECT ALL
        Public Function SelectAll(Org_code As String, Optional Apply_Type As String = "") As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Apply_type,AcademicYear,Semester,Apply_sDate,Apply_sTime, ")
            StrSQL.Append(" Apply_eDate,Apply_eTime,Status,ModUser_id,Mod_date ")
            StrSQL.Append(" ,Org_code ")
            StrSQL.Append("  FROM SAL_EDU_Setting  ")
            StrSQL.Append("  WHERE Org_code=@Org_code ")

            If String.IsNullOrEmpty(Apply_Type) = False Then
                StrSQL.Append("  AND Apply_Type=@Apply_Type  ")
            End If

            StrSQL.Append("  ORDER BY Apply_eDate desc ")

            Dim ps() As SqlParameter = { _
          New SqlParameter("@Org_code", Org_code), _
          New SqlParameter("@Apply_Type", Apply_Type)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'SELECT ONE
        Public Function SelectOne(Id As Integer) As DataTable
            Dim StrSQL As New System.Text.StringBuilder


            StrSQL.Append(" SELECT  ")
            StrSQL.Append(" Apply_type,AcademicYear,Semester,Apply_sDate,Apply_sTime, ")
            StrSQL.Append(" Apply_eDate,Apply_eTime,Status,ModUser_id,Mod_date ")
            StrSQL.Append(" ,Org_code ")
            StrSQL.Append("  FROM SAL_EDU_Setting  ")
            StrSQL.Append("  WHERE 1=1  ")
            StrSQL.Append("  AND Id=@Id  ")

            Dim ps() As SqlParameter = { _
         New SqlParameter("@Id", Id)}

            Return Query(StrSQL.ToString(), ps)
        End Function

        'DELETE
        Public Sub Delete(Id As Integer)
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append(" DELETE FROM SAL_EDU_Setting WHERE  Id=@Id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Id", Id)}

            Execute(StrSQL.ToString(), ps)
        End Sub


    End Class
End Namespace