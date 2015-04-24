Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS2103DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal idcard As String, _
                                    ByVal Start_date As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" SELECT")
            sql.AppendLine(" b.User_name, a.Notes, a.URL, a.Mod_date")
            sql.AppendLine(" from SYS_RecordSQL AS a")
            sql.AppendLine(" INNER JOIN FSC_Personnel AS b ON b.Id_card=a.Account")
            sql.AppendLine(" WHERE Account = @idcard")

            'If Not String.IsNullOrEmpty(syear) Then
            '    sql.AppendLine(" AND Year(create_date) = @syear And Month(create_date) = @smonth And Day(create_date) = @sday ")
            'End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sql.AppendLine(" AND SUBSTRING(Mod_date,0,9) = @Start_date ")
            End If



            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@idcard", SqlDbType.VarChar)
            aryParms(0).Value = idcard
            aryParms(1) = New SqlParameter("@Start_date", SqlDbType.VarChar)
            aryParms(1).Value = Start_date
            'aryParms(1) = New SqlParameter("@syear", SqlDbType.VarChar)
            'aryParms(1).Value = syear
            'aryParms(2) = New SqlParameter("@smonth", SqlDbType.VarChar)
            'aryParms(2).Value = smonth
            'aryParms(3) = New SqlParameter("@sday", SqlDbType.VarChar)
            'aryParms(3).Value = sday
            'aryParms(4) = New SqlParameter("@eyear", SqlDbType.VarChar)
            'aryParms(4).Value = eyear
            'aryParms(5) = New SqlParameter("@emonth", SqlDbType.VarChar)
            'aryParms(5).Value = emonth
            'aryParms(6) = New SqlParameter("@eday", SqlDbType.VarChar)
            'aryParms(6).Value = eday


            Return Query(sql.ToString(), aryParms)
        End Function

    End Class
End Namespace
