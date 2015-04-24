Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports SAL.Logic
Imports System.Text
Imports Pemis2009.SQLAdapter

Public Class LabOvertimeFeeMasterDAO
    Inherits BaseDAO

    Dim ConnectionString As String = String.Empty

    Public Sub New()
        ConnectionString = ConnectDB.GetDBString()
    End Sub

    Public Function GetDataByQuery(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataTable
        Dim sql As New StringBuilder
        sql.AppendLine(" Select * from SAL_Lab_Overtime_Fee_Master where ")
        sql.AppendLine(" Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@Depart_id", SqlDbType.VarChar), _
        New SqlParameter("@Id_card", SqlDbType.VarChar), _
        New SqlParameter("@Fee_ym", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        params(1).Value = Depart_id
        params(2).Value = Id_card
        params(3).Value = Fee_ym

        Return Query(sql.ToString(), params)
    End Function

    Public Function GetSumPay(ByVal Orgcode As String, ByVal Fee_ym As String) As Object
        Dim sql As New StringBuilder
        sql.AppendLine("Select IsNull(Sum(Overtime_fee),'0') from SAL_Lab_Overtime_Fee_Master ")
        sql.AppendLine("where Orgcode=@Orgcode and Fee_YM like @Fee_ym+'%' ")
        sql.AppendLine("     and Print_Mark='Y' ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@Fee_ym", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        params(1).Value = Fee_ym
        Return Scalar(sql.ToString(), params)
    End Function


    Public Function GetHadSumPay(ByVal Orgcode As String, ByVal Fee_ym As String) As Object
        Dim sql As New StringBuilder
        sql.AppendLine("Select IsNull(Sum(Overtime_fee),'0') from SAL_Lab_Overtime_Fee_Master ")
        sql.AppendLine("where Orgcode=@Orgcode and Fee_YM like @Fee_ym+'%' ")
        sql.AppendLine("     and Print_Mark='Y' and Sum_Date<>'' ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@Fee_ym", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        params(1).Value = Fee_ym
        Return Scalar(sql.ToString(), params)
    End Function

    Public Function GetSumPayS(ByVal Orgcode As String, ByVal Fee_ym As String) As Object
        Dim sql As New StringBuilder
        sql.AppendLine("Select isnull(Sum(Overtime_fee),'0') from SAL_Lab_Overtime_Fee_Master ")
        sql.AppendLine("where Orgcode=@Orgcode and Fee_YM IN (" & Fee_ym & ") ")
        sql.AppendLine("     and Print_Mark='Y' ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        Return Scalar(sql.ToString(), params)
    End Function


    Public Function GetHadSumPayS(ByVal Orgcode As String, ByVal Fee_ym As String) As Object
        Dim sql As New StringBuilder
        sql.AppendLine("Select isnull(Sum(Overtime_fee),'0') from SAL_Lab_Overtime_Fee_Master ")
        sql.AppendLine("where Orgcode=@Orgcode and Fee_YM IN (" & Fee_ym & ") ")
        sql.AppendLine("     and Print_Mark='Y' and Sum_Date<>'' ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        Return Scalar(sql.ToString(), params)
    End Function


    Public Function deleteData(ByVal OrgCode As String, ByVal Depart_id As String, ByVal YearMonth As String, ByVal Id_card As String) As Integer

        Dim sSQL As New StringBuilder()
        sSQL.Append(" Delete from SAL_Lab_Overtime_Fee_Master  ")
        sSQL.Append(" where Orgcode = @OrgCode and Depart_id=@Depart_id and ")
        sSQL.Append(" Fee_YM = @YearMonth and Id_card=@Id_card ")
        Dim params(3) As SqlParameter
        params(0) = New SqlParameter("@OrgCode", OrgCode)
        params(1) = New SqlParameter("@Depart_id", Depart_id)
        params(2) = New SqlParameter("@YearMonth", YearMonth)
        params(3) = New SqlParameter("@Id_card", Id_card)

        Return Execute(sSQL.ToString(), params)
    End Function

    Public Sub doUpdateSAL1112(ByVal Overtime_Date As String, ByVal Hours As String, ByVal hour_pay As Integer, _
                               ByVal Monthly_pay As Integer, ByVal Pro_sa As Integer, ByVal Overtime_Fee As String, _
                               ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_YM As String)
        Dim sql As New StringBuilder()
        sql.AppendLine(" Update SAL_Lab_Overtime_Fee_Master ")
        sql.AppendLine(" Set ")
        sql.AppendLine("    Overtime_Date = @Overtime_Date , ")
        sql.AppendLine("    Hours = @Hours, ")
        sql.AppendLine("    hour_pay = @hour_pay, ")
        sql.AppendLine("    Monthly_pay = @monthly_pay, ")
        sql.AppendLine("    pro_sa = @pro_sa, ")
        sql.AppendLine("    Overtime_Fee = @Overtime_Fee, ")
        sql.AppendLine("    update_date = @update_date, ")
        sql.AppendLine("    update_username = @update_username ")
        sql.AppendLine(" where Orgcode = @Orgcode and Depart_id = @Depart_id and Id_card = @Id_card and Fee_YM = @Fee_YM ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Overtime_Date", Overtime_Date), _
        New SqlParameter("@Hours", Hours), _
        New SqlParameter("@Overtime_Fee", Overtime_Fee), _
        New SqlParameter("@update_date", Now), _
        New SqlParameter("@update_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
        New SqlParameter("@Orgcode", Orgcode), _
        New SqlParameter("@Depart_id", Depart_id), _
        New SqlParameter("@Id_card", Id_card), _
        New SqlParameter("@Fee_YM", Fee_YM), _
        New SqlParameter("@Hour_pay", hour_pay), _
        New SqlParameter("@monthly_pay", Monthly_pay), _
        New SqlParameter("@pro_sa", Pro_sa)}
        Execute(sql.ToString(), params)
    End Sub

    Public Sub doUpdateFSC1307(ByVal Print_Mark As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_YM As String)
        Dim sql As New StringBuilder()
        sql.Append(" Update SAL_Lab_Overtime_Fee_Master Set ")
        sql.Append("    Print_Mark = @Print_Mark , ")
        sql.Append("    Sum_date=null, ")
        sql.Append("    update_date = @update_date , ")
        sql.Append("    update_username = @update_username ")
        sql.Append(" where Orgcode = @Orgcode and Depart_id = @Depart_id and Id_card = @Id_card and Fee_YM = @Fee_YM ")
        Dim params() As SqlParameter = { _
        New SqlParameter("@Print_Mark", Print_Mark), _
        New SqlParameter("@update_date", FSC.Logic.DateTimeInfo.GetRocDate(Now)), _
        New SqlParameter("@update_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
        New SqlParameter("@Orgcode", Orgcode), _
        New SqlParameter("@Depart_id", Depart_id), _
        New SqlParameter("@Id_card", Id_card), _
        New SqlParameter("@Fee_YM", Fee_YM)}
        Execute(sql.ToString(), params)
    End Sub

    Public Sub InsertData(ByVal Orgcode As String, ByVal flow_id As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_YM As String, ByVal Apply_Seq As String, ByVal Overtime_Date As String, ByVal Monthly_Pay As String, _
                          ByVal pro_sa As String, ByVal Hour_Pay As String, ByVal Print_Mark As String, ByVal Hours As String, ByVal Overtime_Fee As String, ByVal Budget_type As String)
        Dim sSQL As New StringBuilder()
        sSQL.Append(" insert into SAL_Lab_Overtime_Fee_Master ")
        sSQL.Append("       (Orgcode ,flow_id ,Depart_id ,Id_card,Fee_YM,Apply_Seq,Overtime_Date,Monthly_Pay ,pro_sa,Hour_Pay,Print_Mark,Hours,Overtime_Fee,create_date,update_date,create_username,update_username,Budget_type) ")
        sSQL.Append(" values ")
        sSQL.Append("       (@Orgcode ,@flow_id, @Depart_id ,@Id_card,@Fee_YM,@Apply_Seq,@Overtime_Date,@Monthly_Pay ,@pro_sa,@Hour_Pay,@Print_Mark,@Hours,@Overtime_Fee,@create_date,@update_date,@create_username,@update_username,@Budget_type) ")
        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", Orgcode), _
        New SqlParameter("@flow_id", flow_id), _
        New SqlParameter("@Depart_id", Depart_id), _
        New SqlParameter("@Id_card", Id_card), _
        New SqlParameter("@Fee_YM", Fee_YM), _
        New SqlParameter("@Apply_Seq", Apply_Seq), _
        New SqlParameter("@Overtime_Date", Overtime_Date), _
        New SqlParameter("@Monthly_Pay", Monthly_Pay), _
        New SqlParameter("@pro_sa", pro_sa), _
        New SqlParameter("@Hour_Pay", Hour_Pay), _
        New SqlParameter("@Print_Mark", Print_Mark), _
        New SqlParameter("@Hours", Hours), _
        New SqlParameter("@Overtime_Fee", Overtime_Fee), _
        New SqlParameter("@Budget_type", Budget_type), _
        New SqlParameter("@create_date", Now), _
        New SqlParameter("@update_date", Now), _
        New SqlParameter("@create_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
        New SqlParameter("@update_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))}
        Execute(sSQL.ToString(), params)
    End Sub

    Public Function GetMaxSum_seq(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String) As Object
        Dim StrSQL As String = String.Empty
        StrSQL = "Select Max(Sum_seq) from SAL_Lab_Overtime_Fee_Master " & _
                 "where Orgcode=@Orgcode and Depart_id=@Depart_id and Fee_YM=@Fee_ym "

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@Depart_id", SqlDbType.VarChar), _
        New SqlParameter("@Fee_ym", SqlDbType.VarChar)}

        params(0).Value = Orgcode
        params(1).Value = Depart_id
        params(2).Value = Fee_ym
        Return Scalar(StrSQL, params)
    End Function

    Public Function UpdateSumData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                                  ByVal Apply_seq As String, ByVal Sum_date As String, ByVal Sum_seq As String) As Integer
        Dim StrSQL As String = String.Empty
        StrSQL = "UPDATE SAL_Lab_Overtime_Fee_Master SET Sum_date=@Sum_date, Sum_seq=@Sum_seq WHERE " & _
                    "Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card and Fee_YM=@Fee_ym and Apply_seq=@Apply_seq "

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@Depart_id", SqlDbType.VarChar), _
        New SqlParameter("@Id_card", SqlDbType.VarChar), _
        New SqlParameter("@Fee_ym", SqlDbType.VarChar), _
        New SqlParameter("@Sum_date", SqlDbType.VarChar), _
        New SqlParameter("@Sum_seq", SqlDbType.VarChar), _
        New SqlParameter("@Apply_seq", SqlDbType.VarChar)}
        params(0).Value = Orgcode
        params(1).Value = Depart_id
        params(2).Value = Id_card
        params(3).Value = Fee_ym
        params(4).Value = Sum_date
        params(5).Value = Sum_seq
        params(6).Value = Apply_seq
        Return Execute(StrSQL, params)
    End Function

    Public Sub doUpdateFSC3206(ByVal Print_Mark As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_YM As String, ByVal Lock_Status As String)
        Dim sql As New StringBuilder()
        sql.Append(" Update SAL_Lab_Overtime_Fee_Master Set ")
        sql.Append("    Print_Mark = @Print_Mark , ")
        sql.Append("    Lock_Status = @Lock_Status , ")
        sql.Append("    Lock_Date = @Lock_Date , ")
        sql.Append("    Sum_date=null, ")
        sql.Append("    update_date = @update_date , ")
        sql.Append("    update_username = @update_username ")
        sql.Append(" where Orgcode = @Orgcode and Depart_id = @Depart_id and Id_card = @Id_card and Fee_YM = @Fee_YM ")
        Dim params() As SqlParameter = { _
        New SqlParameter("@Print_Mark", Print_Mark), _
        New SqlParameter("@Lock_Status", Lock_Status), _
        New SqlParameter("@Lock_Date", FSC.Logic.DateTimeInfo.GetRocDateTime(Now)), _
        New SqlParameter("@update_date", FSC.Logic.DateTimeInfo.GetRocDate(Now)), _
        New SqlParameter("@update_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
        New SqlParameter("@Orgcode", Orgcode), _
        New SqlParameter("@Depart_id", Depart_id), _
        New SqlParameter("@Id_card", Id_card), _
        New SqlParameter("@Fee_YM", Fee_YM)}
        Execute(sql.ToString(), params)
    End Sub


    Public Function UpdatePrintMark(ByVal Orgcode As String, _
                                ByVal Depart_id As String, _
                                ByVal Id_card As String, _
                                ByVal Fee_ym As String, _
                                ByVal Budget_type As String, _
                                ByVal Apply_seq As String, _
                                ByVal Print_mark As String) As Integer
        Dim StrSQL As String = String.Empty
        StrSQL = "UPDATE SAL_Lab_Overtime_Fee_Master SET Print_mark=@Print_mark, Sum_date=Null WHERE " & _
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

    Public Function getDataByFlowid(ByVal Orgcode As String, ByVal flow_id As String) As DataSet
        Dim sql As String = " select * from SAL_Lab_Overtime_Fee_Master where Orgcode=@Orgcode and flow_id=@flow_id "

        Dim para() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@flow_id", SqlDbType.VarChar)}
        para(0).Value = Orgcode
        para(1).Value = flow_id

        Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql, para)
    End Function

    Public Function updatePayMark(ByVal orgcode As String, ByVal flow_id As String, ByVal Pay_Mark As String) As Integer
        Dim sql As StringBuilder = New StringBuilder
        sql.AppendLine(" update SAL_Lab_Overtime_Fee_Master set ")
        sql.AppendLine(" Pay_Mark=@Pay_Mark, ")
        sql.AppendLine(" update_date=getDate(), ")
        sql.AppendLine(" update_username=@update_username ")
        sql.AppendLine(" where Orgcode=@Orgcode and flow_id=@flow_id ")

        Dim params() As SqlParameter = { _
        New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        New SqlParameter("@flow_id", SqlDbType.VarChar), _
        New SqlParameter("@Pay_Mark", SqlDbType.VarChar), _
        New SqlParameter("@update_username", SqlDbType.VarChar)}
        params(0).Value = orgcode
        params(1).Value = flow_id
        params(2).Value = Pay_Mark
        params(3).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

        Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString, params)
    End Function
End Class
