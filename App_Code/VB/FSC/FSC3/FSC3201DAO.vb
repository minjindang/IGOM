Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3201DAO
        Inherits BaseDAO

        Public Function DoDeleteOldData(ByVal Orgcode As String, ByVal Depart_id As String, _
                                        ByVal id_card As String, ByVal Sdate As String, ByVal Edate As String) As Boolean
            Dim count As Integer = 0
            Dim h As HistoricalDataLog

            Dim params() As SqlParameter = { _
            New SqlParameter("@Sdate", SqlDbType.VarChar), _
            New SqlParameter("@Edate", SqlDbType.VarChar)}
            params(0).Value = Sdate
            params(1).Value = Edate

            Dim SYSTable As String() = {"SYS_Flow", "SYS_Flow_next", "SYS_Flow_detail"}

            For Each Table As String In SYSTable
                Dim sql As StringBuilder = New StringBuilder
                sql.AppendLine(" delete from " + Table)
                sql.AppendLine(" where flow_id in ")
                sql.AppendLine(" (select flow_id from FSC_Leave_main where ")
                sql.AppendLine(" Start_date >= @Sdate and End_date <= @Edate ) ")

                count = Execute(sql.ToString(), params)

                h = New HistoricalDataLog
                h.Orgcode = Orgcode
                h.Depart_id = Depart_id
                h.delete_sdate = Sdate
                h.delete_edate = Edate
                h.delete_table = Table
                h.delete_count = count
                h.Change_userid = id_card

                h.insert()
            Next


            Dim FSCTables As String() = {"FSC_Leave_main,Start_date,End_date", _
                                         "FSC_CPAPO15M,POVDATEB,POVDATEB", _
                                         "FSC_CPAPP16M,PPBUSDATEB,PPBUSDATEE", _
                                         "FSC_CPAPR18M,PRADDD,PRADDD", _
                                         "FSC_CPAPS19M,PSBREAKD,PSBREAKD", _
                                         "FSC_CPAPX24M,PXBREAKD,PXBREAKD", _
                                         "FSC_Project_overtime_rule,Start_date,End_date", _
                                         "FSC_Paper_form,apply_date,apply_date"}


            For Each Table As String In FSCTables
                Dim sql As StringBuilder = New StringBuilder
                sql.AppendLine(" delete from " + Table.Split(",")(0))
                sql.AppendLine(" where " + Table.Split(",")(1) + ">=@Sdate ")
                sql.AppendLine(" and " + Table.Split(",")(2) + "<=@Edate ")

                count = Execute(sql.ToString(), params)

                h = New HistoricalDataLog
                h.Orgcode = Orgcode
                h.Depart_id = Depart_id
                h.delete_sdate = Sdate
                h.delete_edate = Edate
                h.delete_table = Table.Split(",")(0)
                h.delete_count = count
                h.Change_userid = id_card

                h.insert()
            Next

            Return True
        End Function

    End Class
End Namespace
