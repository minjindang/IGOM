Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SALARY.Logic
    Public Class SAL3130DAO
        Inherits BaseDAO

        
        Public Function getQueryData(ByVal orgcode As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select Send_orgcode, Send_departid, Send_idcard ")
            sql.AppendLine(" from SAL_PaySalChgNotic_SendList ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sql.AppendLine(" and Send_orgcode = @orgcode ")
            End If


            Dim aryParms(0) As SqlParameter
            aryParms(0) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            aryParms(0).Value = orgcode

            Return Query(sql.ToString(), aryParms)
        End Function

    End Class
End Namespace