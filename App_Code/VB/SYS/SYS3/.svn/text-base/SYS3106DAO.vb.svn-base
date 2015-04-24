Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace SYS.Logic

    Public Class SYS3106DAO
        Inherits BaseDAO

        Public Function GetFormData(orgcode As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" select a.*, a.code_type+a.code_no as form_id, ")
            sql.AppendLine(" (select code_desc1 from sys_code where code_sys='024' and code_type='**' and code_no=a.code_type) as form_name1, a.code_desc1 as form_name2 ")
            sql.AppendLine(" from sys_code a ")
            sql.AppendLine(" where a.CODE_ORGID=@orgcode and a.code_sys='024' and a.code_type<>'**' ")
            sql.AppendLine(" order by a.code_sys, a.code_type, a.code_no ")


            Dim p As New SqlParameter("@orgcode", orgcode)

            Return Query(sql.ToString(), p)

        End Function

    End Class
End Namespace