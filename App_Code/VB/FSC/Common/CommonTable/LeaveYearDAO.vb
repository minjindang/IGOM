Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic
Imports System.Text

Namespace FSC.Logic
    Public Class LeaveYearDAO
        Inherits BaseDAO


        Public Function GetData(ByVal Orgocde As String, ByVal Id_card As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select * from FSC_Leave_Year ")
            sql.AppendLine(" where ")
            sql.AppendLine(" Orgcode=@Orgcode and Id_card=@Id_card order by Year_sdate")

            Dim sp() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgocde), _
            New SqlParameter("@Id_card", Id_card)}

            Return Query(sql.ToString(), sp)
        End Function

        Public Function get01Data(ByVal id_card As String, ByVal currentDate As String) As DataTable
            Dim sql As String = " select * from FSC_leave_year where id_card=@id_card and @currentDate between Year_sdate and Year_edate and Reason = '01' "

            Dim param(1) As SqlParameter
            param(0) = New SqlParameter("@id_card", SqlDbType.VarChar)
            param(0).Value = id_card
            param(1) = New SqlParameter("@currentDate", SqlDbType.VarChar)
            param(1).Value = currentDate

            Return Query(sql, param)
        End Function
    End Class
End Namespace
