Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text

Namespace SAL.Logic
    Public Class LabOvertimeFeeDetailDAO
        Inherits BaseDAO

        Public Sub doUpdate(ByVal ApplyHour1 As Integer, _
                            ByVal ApplyHour2 As Integer, _
                            ByVal ApplyHour3 As Integer, _
                            ByVal OvertimeHour As Integer, _
                            ByVal OvertimePay As Integer, _
                            ByVal SysDate As Date, _
                            ByVal UserId As String, _
                            ByVal OrgCode As String, _
                            ByVal Depart_Id As String, _
                            ByVal Id_Card As String, _
                            ByVal Fee_YM As String, _
                            ByVal Overtime_Date As String, _
                            ByVal Overtime_Start As String)

            Dim sSQL As New StringBuilder()
            sSQL.AppendLine(" Update SAL_Lab_Overtime_Fee_Detail ")
            sSQL.AppendLine(" Set ")
            sSQL.AppendLine("   Apply_Hour_1 = @ApplyHour1, ")
            sSQL.AppendLine("   Apply_Hour_2 = @ApplyHour2, ")
            sSQL.AppendLine("   Apply_Hour_3 = @ApplyHour3, ")
            sSQL.AppendLine("   Overtime_Hour = @OvertimeHour , ")
            sSQL.AppendLine("   Overtime_Pay = @OvertimePay, ")
            sSQL.AppendLine("   update_date =@SysDate, ")
            sSQL.AppendLine("   update_username = @UserId ")
            sSQL.AppendLine(" where Orgcode = @OrgCode ")
            sSQL.AppendLine("   and Depart_id = @Depart_Id  ")
            sSQL.AppendLine("   and Id_card = @Id_Card ")
            sSQL.AppendLine("   and Fee_YM = @Fee_YM  ")
            sSQL.AppendLine("   and Overtime_Date = @Overtime_Date ")
            sSQL.AppendLine("   and Overtime_Start = @Overtime_Start ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@ApplyHour1", ApplyHour1), _
            New SqlParameter("@ApplyHour2", ApplyHour2), _
            New SqlParameter("@ApplyHour3", ApplyHour3), _
            New SqlParameter("@OvertimeHour", OvertimeHour), _
            New SqlParameter("@OvertimePay", OvertimePay), _
            New SqlParameter("@SysDate", SysDate), _
            New SqlParameter("@UserId", UserId), _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Depart_Id", Depart_Id), _
            New SqlParameter("@Id_Card", Id_Card), _
            New SqlParameter("@Fee_YM", Fee_YM), _
            New SqlParameter("@Overtime_Date", Overtime_Date), _
            New SqlParameter("@Overtime_Start", Overtime_Start)}

            Execute(sSQL.ToString(), params)
        End Sub

        Public Sub doUpdatePrintMark(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Overtime_date As String)

        End Sub

        Public Sub doDelete(ByVal OrgCode As String, ByVal Depart_Id As String, ByVal Id_Card As String, ByVal Fee_YM As String, ByVal Overtime_Date As String, ByVal Overtime_Start As String)
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Delete from SAL_Lab_Overtime_Fee_Detail ")
            sSQL.Append(" where Orgcode = @OrgCode ")
            sSQL.Append(" and Depart_id = @Depart_id ")
            sSQL.Append(" and Id_card = @Id_card ")
            sSQL.Append(" and Fee_YM = @Fee_YM ")
            sSQL.Append(" and Overtime_Date = @Overtime_Date ")
            sSQL.Append(" and Overtime_Start = @Overtime_Start ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Depart_Id", Depart_Id), _
            New SqlParameter("@Id_Card", Id_Card), _
            New SqlParameter("@Fee_YM", Fee_YM), _
            New SqlParameter("@Overtime_Date", Overtime_Date), _
            New SqlParameter("@Overtime_Start", Overtime_Start)}
            Execute(sSQL.ToString(), params)
        End Sub

        Public Sub doDeleteFSC3206(ByVal PerId() As String, ByVal OrgCode As String, ByVal YearMonth As String)
            If Not PerId Is Nothing Then
                If PerId.Length > 0 Then
                    Dim sSQL As New StringBuilder()
                    sSQL.Append(" Delete from SAL_Lab_Overtime_Fee_Detail  ")
                    sSQL.Append(" where Orgcode = @OrgCode and  ")
                    sSQL.Append(" Fee_YM = @YearMonth ")
                    Dim params() As SqlParameter
                    params = New SqlParameter(1 + PerId.Length) {}
                    params(0) = New SqlParameter("@OrgCode", OrgCode)
                    params(1) = New SqlParameter("@YearMonth", YearMonth)
                    Dim i As Integer = 1
                    sSQL.Append("and Id_card in (")
                    For Each p As String In PerId
                        sSQL.Append("@PerId" & i)
                        params(i + 1) = New SqlParameter("@PerId" & i, p)
                        If i <> PerId.Length Then
                            sSQL.Append(",")
                            i = i + 1
                        End If
                    Next
                    sSQL.Append(")")
                    Execute(sSQL.ToString(), params)
                End If
            End If
        End Sub

        Public Sub deleteData(ByVal OrgCode As String, ByVal Depart_id As String, ByVal YearMonth As String, ByVal Id_card As String)
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Delete from SAL_Lab_Overtime_Fee_Detail  ")
            sSQL.Append(" where  ")
            sSQL.Append(" Orgcode = @OrgCode and Depart_id=@Depart_id and Fee_YM = @YearMonth and Id_card=@Id_card ")
            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@OrgCode", OrgCode)
            params(1) = New SqlParameter("@Depart_id", Depart_id)
            params(2) = New SqlParameter("@YearMonth", YearMonth)
            params(3) = New SqlParameter("@Id_card", Id_card)

            Execute(sSQL.ToString(), params)
        End Sub

        Public Sub Insert(ByVal Orgcode As String, _
                          ByVal Depart_id As String, _
                          ByVal Id_card As String, _
                          ByVal Fee_YM As String, _
                          ByVal Apply_Seq As String, _
                          ByVal Overtime_Date As String, _
                          ByVal Overtime_Start As String, _
                          ByVal Overtime_End As String, _
                          ByVal Overtime_Hour As String, _
                          ByVal Apply_Hour_1 As String, _
                          ByVal Apply_Hour_2 As String, _
                          ByVal Apply_Hour_3 As String, _
                          ByVal Apply_Hour_4 As String, _
                          ByVal Apply_Hour_5 As String, _
                          ByVal Overtime_Pay As String, _
                          ByVal Reason As String, _
                          ByVal flow_id As String)

            Dim sSQL As New StringBuilder()
            sSQL.Append(" Insert into SAL_Lab_Overtime_Fee_Detail ")
            sSQL.Append(" (Orgcode,Depart_id,Id_card,Fee_YM,Apply_Seq,Overtime_Date,Overtime_Start,Overtime_End,Overtime_Hour,Apply_Hour_1,Apply_Hour_2,Apply_Hour_3,Apply_Hour_4,Apply_Hour_5,Overtime_Pay,Reason,create_date,update_date,create_username,update_username,flow_id) ")
            sSQL.Append(" values")
            sSQL.Append(" (@Orgcode,")
            sSQL.Append("@Depart_id,")
            sSQL.Append("@Id_card,")
            sSQL.Append("@Fee_YM,")
            sSQL.Append("@Apply_Seq,")
            sSQL.Append("@Overtime_Date,")
            sSQL.Append("@Overtime_Start,")
            sSQL.Append("@Overtime_End,")
            sSQL.Append("@Overtime_Hour,")
            sSQL.Append("@Apply_Hour_1,")
            sSQL.Append("@Apply_Hour_2,")
            sSQL.Append("@Apply_Hour_3,")
            sSQL.Append("@Apply_Hour_4,")
            sSQL.Append("@Apply_Hour_5,")
            sSQL.Append("@Overtime_Pay,")
            sSQL.Append("@Reason,")
            sSQL.Append("@create_date,")
            sSQL.Append("@update_date,")
            sSQL.Append("@create_username,")
            sSQL.Append("@update_username, ")
            sSQL.Append("@flow_id) ")

            Dim params() As SqlParameter
            params = New SqlParameter() { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Fee_YM", Fee_YM), _
            New SqlParameter("@Apply_Seq", Apply_Seq), _
            New SqlParameter("@Overtime_Date", Overtime_Date), _
            New SqlParameter("@Overtime_Start", Overtime_Start), _
            New SqlParameter("@Overtime_End", Overtime_End), _
            New SqlParameter("@Overtime_Hour", Overtime_Hour), _
            New SqlParameter("@Apply_Hour_1", Apply_Hour_1), _
            New SqlParameter("@Apply_Hour_2", Apply_Hour_2), _
            New SqlParameter("@Apply_Hour_3", Apply_Hour_3), _
            New SqlParameter("@Apply_Hour_4", Apply_Hour_4), _
            New SqlParameter("@Apply_Hour_5", Apply_Hour_5), _
            New SqlParameter("@Overtime_Pay", Overtime_Pay), _
            New SqlParameter("@Reason", Reason), _
            New SqlParameter("@create_date", Now), _
            New SqlParameter("@update_date", Now), _
            New SqlParameter("@create_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
            New SqlParameter("@update_username", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
            New SqlParameter("@flow_id", flow_id)}

            Execute(sSQL.ToString(), params)
        End Sub

        Public Function doQuerySAL1112(ByVal OrgCode As String, ByVal Depart_id As String, ByVal Id_Card As String, ByVal Fee_YM As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Select Substring(Overtime_Date, 6, 2) as day ")
            sSQL.Append(" from SAL_Lab_Overtime_Fee_Detail ")
            sSQL.Append(" where Orgcode =@OrgCode and ")
            sSQL.Append(" Depart_id = @Depart_id and ")
            sSQL.Append(" Id_card = @Id_Card and ")
            sSQL.Append(" Fee_YM = @Fee_YM ")
            sSQL.Append(" group by Substring(Overtime_Date,6,2) ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", OrgCode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@Id_Card", Id_Card), _
            New SqlParameter("@Fee_YM", Fee_YM)}
            Return Query(sSQL.ToString(), params)
        End Function

        Public Function doQuerySAL1112_2(ByVal OrgCode As String, ByVal Depart_id As String, ByVal Id_Card As String, ByVal Fee_YM As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append(" Select Sum(Apply_Hour_1+ Apply_Hour_2 + Apply_Hour_3 + Apply_Hour_4 + Apply_Hour_5) as Hours , Sum(Overtime_Pay) as Overtime_Fee ")
            sSQL.Append(" from SAL_Lab_Overtime_Fee_Detail ")
            sSQL.Append(" where Orgcode =@OrgCode and ")
            sSQL.Append(" Depart_id = @Depart_id and ")
            sSQL.Append(" Id_card = @Id_Card and ")
            sSQL.Append(" Fee_YM = @Fee_YM ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", OrgCode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@Id_Card", Id_Card), _
            New SqlParameter("@Fee_YM", Fee_YM)}
            Return Query(sSQL.ToString(), params)
        End Function

        Public Function doQuerySAL1112(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, _
                                          ByVal Fee_ym As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select * from SAL_lab_overtime_fee_detail ")
            sql.AppendLine(" where Orgcode=@Orgcode and Depart_id=@Depart_id and Id_card=@Id_card ")
            sql.AppendLine("       and Fee_ym=@Fee_ym and Overtime_date=@Overtime_date and Overtime_start=@Overtime_start ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@Id_Card", Id_card), _
            New SqlParameter("@Fee_YM", Fee_ym), _
            New SqlParameter("@Overtime_date", Overtime_date), _
            New SqlParameter("@Overtime_start", Overtime_start)}
            Return Query(sql.ToString(), params)
        End Function

        Public Function GetDataByFeeYm(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from SAL_Lab_Overtime_Fee_Detail where 1=1 ")

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

            Return Query(sql.ToString, params)
        End Function

    End Class
End Namespace
