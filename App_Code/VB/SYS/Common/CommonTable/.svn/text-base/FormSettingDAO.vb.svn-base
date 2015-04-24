Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SYS.Logic
    Public Class FormSettingDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()

        End Sub


        Public Function GetDataByFormId(ByVal Orgcode As String, _
                                        ByVal Form_id As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" select *, (case when ifattach_flag='0' then '是' else '否' end) as ifattach_name, ")
            sql.AppendLine("    (select code_desc1 from sys_code where code_sys='024' and code_type=substring(form_id,1,3) and code_no=substring(form_id,4,6)) as form_name ")
            sql.AppendLine(" from SYS_Form_setting ")

            sql.AppendLine(" where Orgcode=@Orgcode ")

            If Not String.IsNullOrEmpty(Form_id) Then
                sql.AppendLine(" and Form_id=@Form_id ")
            End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgcode", Orgcode), _
                New SqlParameter("Form_id", Form_id)}

            Return Query(sql.ToString(), params)

        End Function
    End Class
End Namespace
