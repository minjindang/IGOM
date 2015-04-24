Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class LeaveMainDetailDAO
        Inherits BaseDAO

        Public Function getDataByFid(ByVal Flow_id As String) As DataTable
            Dim sql As String = " select * from FSC_Leave_main_detail where flow_id=@flow_id order by Start_date "

            Dim param() As SqlParameter = {New SqlParameter("flow_id", Flow_id)}

            Return Query(sql, param)
        End Function

        Public Function getData(ByVal Flow_id As String, ByVal Officialout_date As String) As DataTable
            Dim sql As String = " select * from FSC_Leave_main_detail where flow_id=@flow_id and @Officialout_date between Start_date and End_date "

            Dim params() As SqlParameter = { _
            New SqlParameter("flow_id", Flow_id), _
            New SqlParameter("Officialout_date", Officialout_date)}

            Return Query(sql, params)
        End Function
    End Class
End Namespace
