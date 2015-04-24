Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace SAL.Logic
    Public Class OvertimeFeeMasterDAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String, _
                                ByVal budget_type As String, ByVal Normal_hour As Integer, ByVal Project_hour As Integer, ByVal Monthly_pay As Integer, ByVal hour_pay As Integer, _
                                ByVal Print_mark As String, ByVal flow_id As String) As Integer
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO SAL_Overtime_fee_master (Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Budget_type, Normal_hour, Project_hour, Monthly_pay, Hour_pay, Print_mark, " & _
                                "Create_date, Create_userid, flow_id) " & _
                        "VALUES " & _
                                "(@Orgcode, @Depart_id, @Id_card, @Fee_ym, @Apply_seq, @Budget_type, @Normal_hour, @Project_hour, @Monthly_pay, @Hour_pay, @Print_mark, " & _
                                "@Create_date, @Create_userid, @flow_id)  "
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar), _
            New SqlParameter("@Normal_hour", SqlDbType.Int), _
            New SqlParameter("@Project_hour", SqlDbType.Int), _
            New SqlParameter("@Monthly_pay", SqlDbType.Int), _
            New SqlParameter("@Hour_pay", SqlDbType.Int), _
            New SqlParameter("@Print_mark", SqlDbType.VarChar), _
            New SqlParameter("@Create_date", SqlDbType.VarChar), _
            New SqlParameter("@Create_userid", SqlDbType.VarChar), _
            New SqlParameter("@flow_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = budget_type
            params(6).Value = Normal_hour
            params(7).Value = Project_hour
            params(8).Value = Monthly_pay
            params(9).Value = hour_pay
            params(10).Value = Print_mark
            params(11).Value = Now.ToString("yyyy/MM/dd HH:mm:ss")
            params(12).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(13).Value = flow_id

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function UpdateData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                    ByVal Apply_seq As String, ByVal Normal_hour As Integer, ByVal Project_hour As Integer, _
                                    ByVal monthly_pay As Integer, ByVal hour_pay As Integer) As Integer
            Dim StrSQL As String = String.Empty
            StrSQL = "  UPDATE SAL_Overtime_Fee_Master "
            StrSQL &= " SET "
            StrSQL &= " Normal_hour=@Normal_hour, Project_hour=@Project_hour, monthly_pay=@monthly_pay, hour_pay=@hour_pay, "
            StrSQL &= " Update_date=@Update_date, Update_userid=@Update_userid "
            StrSQL &= " WHERE "
            StrSQL &= " Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym and Apply_Seq=@Apply_seq "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Normal_hour", SqlDbType.Int), _
            New SqlParameter("@Project_hour", SqlDbType.Int), _
            New SqlParameter("@monthly_pay", SqlDbType.Int), _
            New SqlParameter("@hour_pay", SqlDbType.Int), _
            New SqlParameter("@update_date", SqlDbType.VarChar), _
            New SqlParameter("@Update_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = Normal_hour
            params(6).Value = Project_hour
            params(7).Value = monthly_pay
            params(8).Value = hour_pay
            params(9).Value = Now.ToString("yyyy/MM/dd HH:mm:ss")
            params(10).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function UpdatePrintMark(ByVal Orgcode As String, _
                                        ByVal Depart_id As String, _
                                        ByVal Id_card As String, _
                                        ByVal Fee_ym As String, _
                                        ByVal Budget_type As String, _
                                        ByVal Apply_seq As String, _
                                        ByVal Print_mark As String) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = "UPDATE SAL_Overtime_Fee_Master SET Print_mark=@Print_mark, Sum_date=Null WHERE " & _
                    "Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym and Apply_seq=@Apply_seq"

            If Not String.IsNullOrEmpty(Budget_type) Then
                StrSQL &= " and Budget_type=@Budget_type  "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar), _
            New SqlParameter("@Print_mark", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Budget_type
            params(5).Value = Print_mark
            params(6).Value = Apply_seq

            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" Select * from SAL_Overtime_Fee_Master where ")
            sql.AppendLine(" Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym order by Apply_Seq Desc ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function



        Public Function GetFSC130402Data2(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine(" Select m.Id_card, ")
            sql.AppendLine("    Max(ofm.Apply_seq) as Apply_seq, ")
            sql.AppendLine("    CASE WHEN ofd.Overtime_type='1' THEN '一般' WHEN ofd.Overtime_type='2' THEN '專案' ELSE '' END AS Overtime_type, ")
            sql.AppendLine("    ofd.Overtime_date, ")
            sql.AppendLine("    ofd.Overtime_start, ")
            sql.AppendLine("    ofd.Overtime_end, ")
            sql.AppendLine("    ofd.Overtime_hour, ")
            sql.AppendLine("    ofd.Apply_hour, ")
            sql.AppendLine("    ofd.Reason, ")
            sql.AppendLine("    m.sub_depart_id ")

            sql.AppendLine(" from SAL_Overtime_Fee_Master ofm ")
            sql.AppendLine("    inner join Overtime_Fee_Detail ofd ")
            sql.AppendLine("                 on ofd.Orgcode=ofm.Orgcode and ofd.Depart_id=ofm.Depart_id and ofd.Id_card=ofm.Id_card and ofd.Fee_YM=ofm.Fee_YM and ofd.Apply_Seq=ofm.Apply_Seq ")
            sql.AppendLine("    inner join Member m ")
            sql.AppendLine("                 on ofd.Id_card=m.Id_card and ofd.Orgcode=m.Orgcode ")
            sql.AppendLine("    left outer join detail_code dc ")
            sql.AppendLine("                 on m.Title_no=dc.detail_code_id and dc.Master_code_id='1012' ")
            sql.AppendLine(" where ")
            sql.AppendLine("    ofm.Budget_type=@Budget_type ")
            sql.AppendLine("    and ofm.Print_Mark='Y' ")
            sql.AppendLine("    and ofm.Orgcode=@Orgcode ")
            sql.AppendLine("    and ofm.Depart_id=@Depart_id ")
            sql.AppendLine("    and ofm.Fee_YM=@Fee_ym ")

            sql.AppendLine(" group by ")
            sql.AppendLine("    m.Id_card, ")
            sql.AppendLine("    Overtime_type, ")
            sql.AppendLine("    ofd.Overtime_date, ")
            sql.AppendLine("    ofd.Overtime_start, ")
            sql.AppendLine("    ofd.Overtime_end, ")
            sql.AppendLine("    ofd.Overtime_hour, ")
            sql.AppendLine("    ofd.Apply_hour, ")
            sql.AppendLine("    ofd.Reason, ")
            sql.AppendLine("    m.sub_depart_id ")

            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" ,dc.Fsc_flag  ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" ,dc.Bank_flag  ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" ,dc.sfb_flag  ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" ,dc.Ib_flag  ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" ,dc.Feb_flag ")
            Else
                sql.AppendLine(" ,m.Title_no ")
            End If

            sql.AppendLine(" order by isNull(m.sub_depart_id,'0') ")

            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" ,dc.Fsc_flag  ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" ,dc.Bank_flag  ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" ,dc.sfb_flag  ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" ,dc.Ib_flag  ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" ,dc.Feb_flag ")
            Else
                sql.AppendLine(" ,m.Title_no ")
            End If

            sql.AppendLine(" ,m.id_card, ofd.overtime_date ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Fee_ym
            params(3).Value = Budget_type
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetprpayfeeByYear(ByVal orgcode As String, ByVal budget_type As String, ByVal Fee_ym As String, ByVal Depart_id As String) As Object
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT SUM((Normal_hour+Project_hour)*Hour_pay) ")
            StrSQL.Append("     FROM SAL_Overtime_fee_master WHERE Orgcode=@Orgcode AND Budget_type=@Budget_type AND Fee_ym like @Fee_ym+'%' AND Print_mark='Y' ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                StrSQL.Append(" AND Depart_id=@Depart_id ")
            End If

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = orgcode
            params(1) = New SqlParameter("@Budget_type", SqlDbType.VarChar)
            params(1).Value = budget_type
            params(2) = New SqlParameter("@Fee_ym", SqlDbType.VarChar)
            params(2).Value = Fee_ym
            params(3) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(3).Value = Depart_id

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function GetprpayfeeBySession(ByVal orgcode As String, ByVal Depart_id As String, ByVal budget_type As String, ByVal Fee_ym As String) As DataSet
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT SUM(CASE WHEN Fee_ym>=@Fee_ym+'01' AND Fee_ym<=@Fee_ym+'03' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS Q1, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym>=@Fee_ym+'04' AND Fee_ym<=@Fee_ym+'06' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS Q2, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym>=@Fee_ym+'07' AND Fee_ym<=@Fee_ym+'09' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS Q3, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym>=@Fee_ym+'10' AND Fee_ym<=@Fee_ym+'12' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS Q4 ")
            StrSQL.Append(" FROM SAL_Overtime_fee_master WHERE Orgcode=@Orgcode AND Depart_id=@Depart_id AND Budget_type=@Budget_type AND Fee_ym like @Fee_ym+'%' AND Print_mark='Y' ")
            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = orgcode
            params(1) = New SqlParameter("@Budget_type", SqlDbType.VarChar)
            params(1).Value = budget_type
            params(2) = New SqlParameter("@Fee_ym", SqlDbType.VarChar)
            params(2).Value = Fee_ym
            params(3) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(3).Value = Depart_id
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function GetprpayfeeByMonth(ByVal orgcode As String, ByVal Depart_id As String, ByVal budget_type As String, ByVal Fee_ym As String) As DataSet
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT SUM(CASE WHEN Fee_ym=@Fee_ym+'01' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M1, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'02' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M2, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'03' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M3, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'04' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M4, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'05' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M5, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'06' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M6, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'07' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M7, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'08' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M8, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'09' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M9, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'10' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M10, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'11' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M11, ")
            StrSQL.Append("       SUM(CASE WHEN Fee_ym=@Fee_ym+'12' THEN (Normal_hour+Project_hour)*Hour_pay ELSE 0 END ) AS M12 ")
            StrSQL.Append(" FROM SAL_Overtime_fee_master WHERE Orgcode=@Orgcode AND Depart_id=@Depart_id AND Budget_type=@Budget_type AND Fee_ym like @Fee_ym+'%' AND Print_mark='Y' ")
            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = orgcode
            params(1) = New SqlParameter("@Budget_type", SqlDbType.VarChar)
            params(1).Value = budget_type
            params(2) = New SqlParameter("@Fee_ym", SqlDbType.VarChar)
            params(2).Value = Fee_ym
            params(3) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(3).Value = Depart_id
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function


        Public Function GetSumPay(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Object
            Dim sql As String = String.Empty
            sql = "  Select Sum((Normal_Hour + Project_Hour) * Hour_Pay) "
            sql &= " from SAL_Overtime_Fee_Master "
            sql &= " where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM like @Fee_ym+'%' and Budget_type=@Budget_type "
            sql &= " and Print_Mark='Y' "
            sql &= " and apply_seq=(select max(apply_seq) from Overtime_Fee_Master where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM like @Fee_ym+'%' and Budget_type=@Budget_type ) "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Fee_ym
            params(3).Value = Budget_type
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql, params)
        End Function

        Public Function GetHadSumPay(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Object
            Dim sql As String = String.Empty
            sql = "Select Sum((Normal_Hour + Project_Hour) * Hour_Pay) from SAL_Overtime_Fee_Master "
            sql &= "where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM like @Fee_ym+'%' and Budget_type=@Budget_type "
            sql &= "     and Print_Mark='Y' and Sum_date<>'' "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Fee_ym
            params(3).Value = Budget_type
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql, params)
        End Function

        Public Function GetSumPayS(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Object
            Dim StrSQL As String = String.Empty
            StrSQL = "Select Sum((Normal_Hour + Project_Hour) * Hour_Pay) from SAL_Overtime_Fee_Master "
            StrSQL &= "where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM IN (" & Fee_ym & ") and Budget_type=@Budget_type "
            StrSQL &= "     and Print_Mark='Y' "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Budget_type
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetHadSumPayS(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Object
            Dim sql As New StringBuilder
            sql.AppendLine(" Select Sum((Normal_Hour + Project_Hour) * Hour_Pay) ")
            sql.AppendLine(" from SAL_Overtime_Fee_Master ")
            sql.AppendLine(" where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM IN (" & Fee_ym & ") and Budget_type=@Budget_type ")
            sql.AppendLine("        and Print_Mark='Y' and Sum_Date<>''")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Budget_type
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function GetMaxSum_seq(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String, ByVal Budget_type As String) As Object
            Dim sql As New StringBuilder
            sql.AppendLine(" Select Max(Sum_seq) from SAL_Overtime_Fee_Master ")
            sql.AppendLine(" where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM=@Fee_ym and Budget_type=@Budget_type")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Fee_ym
            params(3).Value = Budget_type
            Return SqlAccessHelper.ExecuteScalar(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function UpdateSumData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                      ByVal Budget_type As String, ByVal Apply_seq As String, ByVal Sum_date As String, ByVal Sum_seq As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" UPDATE SAL_Overtime_Fee_Master SET Sum_date=@Sum_date, Sum_seq=@Sum_seq WHERE ")
            sql.AppendLine(" Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym and Budget_type=@Budget_type and Apply_seq=@Apply_seq ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar), _
            New SqlParameter("@Sum_date", SqlDbType.VarChar), _
            New SqlParameter("@Sum_seq", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Budget_type
            params(5).Value = Sum_date
            params(6).Value = Sum_seq
            params(7).Value = Apply_seq
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function


        Public Function DeleteData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                        ByVal Apply_seq As String, ByVal Print_mark As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" Delete from SAL_Overtime_Fee_Master ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine(" Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym and Apply_Seq=@Apply_seq")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Print_mark", SqlDbType.VarChar)}

            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = Print_mark
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function


        Public Function DeleteData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" DELETE FROM SAL_Overtime_fee_master ")
            sql.AppendLine(" WHERE Orgcode=@Orgcode AND Depart_id=@Depart_id AND Id_card=@Id_card")
            sql.AppendLine("       and Fee_ym=@Fee_ym and Apply_seq=@Apply_seq ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function getDataByFlowid(ByVal Orgcode As String, ByVal flow_id As String) As DataSet
            Dim sql As String = " select * from SAL_Overtime_Fee_Master where Orgcode=@Orgcode and flow_id=@flow_id "

            Dim para() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@flow_id", SqlDbType.VarChar)}
            para(0).Value = Orgcode
            para(1).Value = flow_id

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, para)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal flow_id As String) As DataTable

            Dim sql As New StringBuilder
            sql.AppendLine("Select   ")
            sql.AppendLine("         o.Orgcode, ")
            sql.AppendLine("         o.Depart_id, ")
            sql.AppendLine("         o.Id_card, ")
            sql.AppendLine("         p.User_name, ")
            sql.AppendLine("         cd.CODE_DESC1 as Title_name, ")
            sql.AppendLine("         o.Normal_Hour, ")
            sql.AppendLine("         o.Monthly_Pay, ")
            sql.AppendLine("         o.Hour_Pay, ")
            sql.AppendLine("         o.Project_Hour + o.Normal_Hour as Total_hour, ")
            sql.AppendLine("         (o.Project_Hour + o.Normal_Hour) * o.Hour_Pay as Total_pay, ")
            sql.AppendLine("         o.Sum_date, ")
            sql.AppendLine("         o.Apply_seq, ")
            'sql.AppendLine("         s.main_sa, ")
            'sql.AppendLine("         s.pro_sa, ")
            'sql.AppendLine("         s.header_sa, ")
            sql.AppendLine("         o.Print_mark, ")
            sql.AppendLine("         o.Fee_ym, ")
            sql.AppendLine("         max(s.BASE_HOUR_SAL) ")
            sql.AppendLine("from SAL_Overtime_Fee_Master o ")
            sql.AppendLine("         inner join SAL_SABASE s on o.Id_card = s.BASE_SEQNO and o.Orgcode = s.BASE_ORGID ")
            sql.AppendLine("         inner join FSC_Personnel p on o.Id_card=p.Id_card ")
            sql.AppendLine("         inner join FSC_Depart_emp d on o.Id_card=d.Id_card and o.Orgcode = d.Orgcode ")
            sql.AppendLine("         left outer join SYS_CODE cd on p.Title_no=cd.CODE_NO and cd.CODE_SYS='023' and cd.CODE_TYPE='012' ")
            sql.AppendLine("where    o.Orgcode = @Orgcode and o.flow_id = @flow_id ")
            sql.AppendLine("         and o.Apply_seq=(select Max(Apply_seq) from SAL_overtime_fee_master where orgcode=o.orgcode and depart_id=o.depart_id and id_card=o.id_card and fee_ym=o.fee_ym and budget_type=o.budget_type) ")

            sql.AppendLine("group by ")
            sql.AppendLine("         o.Orgcode, ")
            sql.AppendLine("         o.Depart_id, ")
            sql.AppendLine("         o.Id_card, ")
            sql.AppendLine("         p.User_name, ")
            sql.AppendLine("         cd.CODE_DESC1, ")
            sql.AppendLine("         o.Normal_Hour, ")
            sql.AppendLine("         o.Project_Hour, ")
            sql.AppendLine("         o.Monthly_Pay, ")
            sql.AppendLine("         o.Hour_Pay, ")
            sql.AppendLine("         o.Sum_date, ")
            sql.AppendLine("         o.Apply_seq, ")
            'sql.AppendLine("         s.main_sa,  ")
            'sql.AppendLine("         s.pro_sa,  ")
            'sql.AppendLine("         s.header_sa,  ")
            sql.AppendLine("         o.Print_mark, ")
            sql.AppendLine("         o.Fee_ym, ")
            sql.AppendLine("         p.Title_no, ")
            sql.AppendLine("         p.id_card  ")
            sql.AppendLine(" order by  ")
            sql.AppendLine("         p.Title_no, ")
            sql.AppendLine("         p.id_card ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@flow_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = flow_id

            Return Query(sql.ToString(), params)
        End Function

        Public Function updateSumPrint(ByVal Orgcode As String, ByVal flow_id As String, ByVal Sum_Date As String, ByVal Print_Mark As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update SAL_Overtime_Fee_Master set ")
            sql.AppendLine(" Print_Mark=@Print_Mark, ")
            sql.AppendLine(" Sum_Date=@Sum_Date, ")
            sql.AppendLine(" update_date=getDate(), ")
            sql.AppendLine(" update_userid=@update_userid ")
            sql.AppendLine(" where Orgcode=@Orgcode and flow_id=@flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Sum_Date", SqlDbType.VarChar), _
            New SqlParameter("@Print_Mark", SqlDbType.VarChar), _
            New SqlParameter("@update_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = flow_id
            params(2).Value = Sum_Date
            params(3).Value = Print_Mark
            params(4).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function updatePayMark(ByVal orgcode As String, ByVal flow_id As String, ByVal Pay_Mark As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update SAL_Overtime_Fee_Master set ")
            sql.AppendLine(" Pay_Mark=@Pay_Mark, ")
            sql.AppendLine(" update_date=getDate(), ")
            sql.AppendLine(" update_userid=@update_userid ")
            sql.AppendLine(" where Orgcode=@Orgcode and flow_id=@flow_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@flow_id", SqlDbType.VarChar), _
            New SqlParameter("@Pay_Mark", SqlDbType.VarChar), _
            New SqlParameter("@update_userid", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = flow_id
            params(2).Value = Pay_Mark
            params(3).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function
    End Class
End Namespace