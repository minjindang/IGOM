Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace SAL.Logic
    Public Class OvertimeFeeDetailDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String, _
                                    ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Applytime_start As String, ByVal Applytime_end As String, _
                                    ByVal Overtime_start As String, ByVal Overtime_end As String, ByVal Overtime_hour As Integer, ByVal Apply_hour As Integer, _
                                    ByVal Reason As String, ByVal Create_userid As String) As Integer
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO SAL_Overtime_fee_detail (Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Overtime_type, Overtime_date, Applytime_start, Applytime_end, " & _
                                "Overtime_start, Overtime_end, Overtime_hour, Apply_hour, Reason, Create_date, Create_userid) " & _
                        "VALUES " & _
                                "(@Orgcode, @Depart_id, @Id_card, @Fee_ym, @Apply_seq, @Overtime_type, @Overtime_date, @Applytime_start, @Applytime_end, " & _
                                "@Overtime_start, @Overtime_end, @Overtime_hour, @Apply_hour, @Reason, @Create_date, @Create_userid)"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_type", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_date", SqlDbType.VarChar), _
            New SqlParameter("@Applytime_start", SqlDbType.VarChar), _
            New SqlParameter("@Applytime_end", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_Start", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_end", SqlDbType.VarChar), _
            New SqlParameter("@overtime_hour", SqlDbType.Int), _
            New SqlParameter("@Apply_hour", SqlDbType.Int), _
            New SqlParameter("@Reason", SqlDbType.VarChar), _
            New SqlParameter("@Create_date", SqlDbType.DateTime), _
            New SqlParameter("@Create_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = Overtime_type
            params(6).Value = Overtime_date
            params(7).Value = Applytime_start
            params(8).Value = Applytime_end
            params(9).Value = Overtime_start
            params(10).Value = Overtime_end
            params(11).Value = Overtime_hour
            params(12).Value = Apply_hour
            params(13).Value = Reason
            params(14).Value = Now
            params(15).Value = Create_userid

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As Object
            Dim sql As String = String.Empty
            sql = "  Select * from SAL_Overtime_Fee_Detail "
            sql &= " where Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym "
            sql &= "       and Overtime_Date=@Overtime_date and Overtime_Start=@Overtime_Start"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_date", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_Start", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Overtime_date
            params(5).Value = Overtime_start

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, params)
        End Function
        Public Function GetApplyHourData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As Object
            Dim sql As String = String.Empty
            sql = "  Select isnull(Apply_hour,'0') as Apply_hour from SAL_Overtime_Fee_Detail "
            sql &= " where Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym "
            sql &= "       and Overtime_Date=@Overtime_date and Overtime_Start=@Overtime_Start"

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_date", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_Start", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Overtime_date
            params(5).Value = Overtime_start

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, params)
        End Function

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                       ByVal Apply_seq As String, ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "Select * from SAL_Overtime_Fee_Detail " & _
                        "where Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym and " & _
                        "Apply_Seq=@Apply_seq and Overtime_type=@Overtime_type and Overtime_Date=@Overtime_date and Overtime_start=@Overtime_start "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_type", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_date", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_start", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = Overtime_type
            params(6).Value = Overtime_date
            params(7).Value = Overtime_start

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        Public Function UpdateApplyHour(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                        ByVal Apply_seq As String, ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Overtime_start As String, _
                                        ByVal Apply_hour As Integer, ByVal Update_userid As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" UPDATE SAL_Overtime_fee_detail ")
            sql.AppendLine(" SET Apply_hour=@Apply_hour, Update_date=@Update_date, Update_userid=@Update_userid ")
            sql.AppendLine(" WHERE Orgcode=@Orgcode AND Depart_id=@Depart_id AND Id_card=@Id_card AND Fee_ym=@Fee_ym AND ")
            sql.AppendLine("       Apply_seq=@Apply_seq AND Overtime_type=@Overtime_type AND Overtime_date=@Overtime_date and overtime_start=@Overtime_start ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_type", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_date", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_start", SqlDbType.VarChar), _
            New SqlParameter("@Apply_hour", SqlDbType.VarChar), _
            New SqlParameter("@Update_date", SqlDbType.DateTime), _
            New SqlParameter("@Update_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = Overtime_type
            params(6).Value = Overtime_date
            params(7).Value = Overtime_start
            params(8).Value = Apply_hour
            params(9).Value = Now.ToString("yyyy/MM/dd HH:mm:ss")
            params(10).Value = Update_userid
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function DeleteData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                ByVal Apply_seq As String, ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" DELETE FROM SAL_Overtime_fee_detail ")
            sql.AppendLine(" WHERE Orgcode=@Orgcode AND Depart_id=@Depart_id AND Id_card=@Id_card AND Fee_ym=@Fee_ym ")
            sql.AppendLine("       and Apply_seq=@Apply_seq AND Overtime_type=@Overtime_type AND Overtime_date=@Overtime_date")
            sql.AppendLine("       and Overtime_start=@Overtime_start ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_type", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_date", SqlDbType.VarChar), _
            New SqlParameter("@Overtime_start", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym
            params(4).Value = Apply_seq
            params(5).Value = Overtime_type
            params(6).Value = Overtime_date
            params(7).Value = Overtime_start
            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function DeleteData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" DELETE FROM SAL_Overtime_fee_detail ")
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


        Public Function GetFSC1301_02Data2(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT CASE WHEN ofd.Overtime_type='1' THEN '一般' WHEN ofd.Overtime_type='2' THEN '專案' ELSE '' END AS Overtime_type, ")
            sql.AppendLine("        ofd.Overtime_date, ofd.Overtime_start, ofd.Overtime_end, ofd.Overtime_hour, ofd.Apply_hour, ofd.Reason, ")
            sql.AppendLine("        ofd.Apply_hour, isnull((ofd.Apply_hour * ims.hour_pay),0) AS Apply_money ")
            sql.AppendLine(" FROM SAL_Overtime_Fee_detail ofd ")
            sql.AppendLine("        INNER JOIN Member m ON ofd.Orgcode=m.Orgcode AND ofd.Depart_id=m.Depart_id AND ofd.Id_card=m.Id_card ")
            sql.AppendLine("        LEFT OUTER JOIN Imp_Salary ims ON ims.Orgcode=ofd.Orgcode AND ims.Depart_id=ofd.Depart_id AND ims.emp_id=ofd.Id_card and ims.salyymm=ofd.fee_ym ")
            sql.AppendLine(" WHERE ofd.Orgcode=@Orgcode AND ofd.Id_card=@Id_card AND ofd.Fee_ym=@Fee_ym AND ofd.Apply_seq=@Apply_seq and ofd.Apply_hour<>0")
            sql.AppendLine(" order by ofd.Overtime_date, ofd.Overtime_start ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
            New SqlParameter("@Apply_seq", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card
            params(2).Value = Fee_ym
            params(3).Value = Apply_seq
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataByFeeYm(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataSet
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from SAL_Overtime_Fee_Detail where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and Id_card=@Id_card ")
            End If
            If Not String.IsNullOrEmpty(Fee_ym) Then
                sql.AppendLine(" and Fee_ym=@Fee_ym ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Fee_ym", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Id_card
            params(3).Value = Fee_ym

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function
    End Class
End Namespace