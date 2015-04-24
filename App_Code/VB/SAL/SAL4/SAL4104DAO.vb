Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL4104DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal Jobtype As String, _
                                     ByVal Leveltype As String, _
                                     ByVal orgcode As String, _
                                     ByVal LEVCOM_MDATE As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT  *,isnull((select code_desc1 from sys_code where code_sys='002' and code_kind='P' and code_type='009' and code_no=LEVCOM_ORG_L2),'') as L2  from SAL_SALEVCOM ")
            'sql.AppendLine("(select code_desc1 'from SYS_CODE as b where code_sys = '002' and CODE_TYPE ='003' and CODE_NO=@Jobtype) as L3 ")
            'sql.AppendLine("(select code_desc1 'from SYS_CODE as b where code_sys = '002' and CODE_TYPE ='006' and CODE_NO=@Leveltype) as L1 ")
            sql.AppendLine(" WHERE 1=1")

            If Not String.IsNullOrEmpty(Jobtype) Then
                sql.AppendLine(" AND LEVCOM_ORG_L3 = @Jobtype ")
            End If
            If Not String.IsNullOrEmpty(Leveltype) Then
                sql.AppendLine(" AND LEVCOM_ORG_L1 = @Leveltype ")
            End If
            If Not String.IsNullOrEmpty(LEVCOM_MDATE) Then
                sql.AppendLine(" AND LEVCOM_MDATE = @LEVCOM_MDATE ")
            End If
            'sql.AppendLine(" ORDER BY AcademicYear")
            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Jobtype", SqlDbType.VarChar)
            aryParms(0).Value = Jobtype
            aryParms(1) = New SqlParameter("@Leveltype", SqlDbType.VarChar)
            aryParms(1).Value = Leveltype
            aryParms(2) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            aryParms(2).Value = orgcode
            aryParms(3) = New SqlParameter("@LEVCOM_MDATE", SqlDbType.VarChar)
            aryParms(3).Value = LEVCOM_MDATE

            Return Query(sql.ToString(), aryParms)
        End Function

    
        Public Function Insert(ByVal Jobtype As String, _
                             ByVal Leveltype As String, _
                             ByVal L3 As String, _
                             ByVal L1 As String, _
                             ByVal securityid As String, _
                             ByVal date1 As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" INSERT INTO SAL_SALEVCOM VALUES (@Jobtype, @Leveltype, @L3, @L1, @securityid, @date1 )")

            Dim aryParms(5) As SqlParameter
            aryParms(0) = New SqlParameter("@Jobtype", SqlDbType.VarChar)
            aryParms(0).Value = Jobtype
            aryParms(1) = New SqlParameter("@Leveltype", SqlDbType.VarChar)
            aryParms(1).Value = Leveltype
            aryParms(2) = New SqlParameter("@L3", SqlDbType.VarChar)
            aryParms(2).Value = L3
            aryParms(3) = New SqlParameter("@L1", SqlDbType.VarChar)
            aryParms(3).Value = L1
            aryParms(4) = New SqlParameter("@securityid", SqlDbType.VarChar)
            aryParms(4).Value = securityid
            aryParms(5) = New SqlParameter("@date1", SqlDbType.VarChar)
            aryParms(5).Value = date1
            Return Execute(sql.ToString(), aryParms)
        End Function

        Public Function Update(ByVal Jobtype As String, _
                                ByVal Leveltype As String, _
                                ByVal L3 As String, _
                                ByVal L1 As String, _
                                ByVal securityid As String, _
                                ByVal date1 As String, _
                                ByVal newL3 As String, _
                                ByVal newL1 As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine("UPDATE SAL_SALEVCOM SET LEVCOM_ORG_L3 = @Jobtype, LEVCOM_ORG_L1 = @Leveltype, LEVCOM_PTB = @newL3,")
            sql.AppendLine(" LEVCOM_ORG_L2 = @newL1, LEVCOM_MUSER = @securityid, LEVCOM_MDATE = @date1 ")
            sql.AppendLine(" WHERE LEVCOM_ORG_L3 = @Jobtype AND LEVCOM_ORG_L1 = @Leveltype AND LEVCOM_PTB = @L3")
            sql.AppendLine(" AND LEVCOM_ORG_L2 = @L1 ")

            Dim aryParms(7) As SqlParameter
            aryParms(0) = New SqlParameter("@Jobtype", SqlDbType.VarChar)
            aryParms(0).Value = Jobtype
            aryParms(1) = New SqlParameter("@Leveltype", SqlDbType.VarChar)
            aryParms(1).Value = Leveltype
            aryParms(2) = New SqlParameter("@L3", SqlDbType.VarChar)
            aryParms(2).Value = L3
            aryParms(3) = New SqlParameter("@L1", SqlDbType.VarChar)
            aryParms(3).Value = L1
            aryParms(4) = New SqlParameter("@date1", SqlDbType.VarChar)
            aryParms(4).Value = date1
            aryParms(5) = New SqlParameter("@securityid", SqlDbType.VarChar)
            aryParms(5).Value = securityid
            aryParms(6) = New SqlParameter("@newL3", SqlDbType.VarChar)
            aryParms(6).Value = newL3
            aryParms(7) = New SqlParameter("@newL1", SqlDbType.VarChar)
            aryParms(7).Value = newL1


            Return Execute(sql.ToString(), aryParms)
        End Function
        Public Function Delete(ByVal Jobtype As String, _
                   ByVal Leveltype As String, _
                   ByVal L3 As String, _
                   ByVal L1 As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine("Delete SAL_SALEVCOM where LEVCOM_ORG_L3=@Jobtype and LEVCOM_ORG_L1 = @Leveltype and LEVCOM_PTB=@L3")
            sql.AppendLine(" And LEVCOM_ORG_L2 =@L1  ")

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Jobtype", SqlDbType.VarChar)
            aryParms(0).Value = Jobtype
            aryParms(1) = New SqlParameter("@Leveltype", SqlDbType.VarChar)
            aryParms(1).Value = Leveltype
            aryParms(2) = New SqlParameter("@L3", SqlDbType.VarChar)
            aryParms(2).Value = L3
            aryParms(3) = New SqlParameter("@L1", SqlDbType.VarChar)
            aryParms(3).Value = L1

            Return Execute(sql.ToString(), aryParms)
        End Function
    
    End Class
End Namespace
