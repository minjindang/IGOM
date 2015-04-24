Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class OvertimeTotalfeeDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, _
                                    ByVal budget_year As String, ByVal budget_type As String, _
                                    Optional ByVal fee1 As Integer = Nothing, Optional ByVal fee2 As Integer = Nothing, Optional ByVal fee3 As Integer = Nothing, _
                                    Optional ByVal fee4 As Integer = Nothing, Optional ByVal fee5 As Integer = Nothing, Optional ByVal fee6 As Integer = Nothing, _
                                    Optional ByVal fee7 As Integer = Nothing, Optional ByVal fee8 As Integer = Nothing, Optional ByVal fee9 As Integer = Nothing, _
                                    Optional ByVal fee10 As Integer = Nothing, Optional ByVal fee11 As Integer = Nothing, Optional ByVal fee12 As Integer = Nothing) As Integer

            Dim sql As New StringBuilder
            sql.AppendLine("INSERT INTO Overtime_totalfee ")
            sql.AppendLine("    (Orgcode, Depart_id, budget_year, budget_type, fee1, fee2, fee3, fee4, fee5, ")
            sql.AppendLine("    fee6, fee7, fee8, fee9, fee10, fee11, fee12, create_date, create_userid) ")
            sql.AppendLine("VALUES ")
            sql.AppendLine("    (@Orgcode, @Depart_id, @budget_year, @budget_type, @fee1, @fee2, @fee3, @fee4, @fee5, ")
            sql.AppendLine("    @fee6, @fee7, @fee8, @fee9, @fee10, @fee11, @fee12, @create_date, @create_userid) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@budget_year", budget_year), _
            New SqlParameter("@budget_type", budget_type), _
            New SqlParameter("@fee1", fee1), _
            New SqlParameter("@fee2", fee2), _
            New SqlParameter("@fee3", fee3), _
            New SqlParameter("@fee4", fee4), _
            New SqlParameter("@fee5", fee5), _
            New SqlParameter("@fee6", fee6), _
            New SqlParameter("@fee7", fee7), _
            New SqlParameter("@fee8", fee8), _
            New SqlParameter("@fee9", fee9), _
            New SqlParameter("@fee10", fee10), _
            New SqlParameter("@fee11", fee11), _
            New SqlParameter("@fee12", fee12), _
            New SqlParameter("@create_date", Now.ToString("yyyy/MM/dd HH:mm:ss")), _
            New SqlParameter("@create_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))}

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function UpdateData(ByVal Orgcode As String, ByVal Depart_id As String, _
                                    ByVal budget_year As String, ByVal budget_type As String, _
                                    ByVal fee1 As Integer, ByVal fee2 As Integer, ByVal fee3 As Integer, _
                                    ByVal fee4 As Integer, ByVal fee5 As Integer, ByVal fee6 As Integer, _
                                    ByVal fee7 As Integer, ByVal fee8 As Integer, ByVal fee9 As Integer, _
                                    ByVal fee10 As Integer, ByVal fee11 As Integer, ByVal fee12 As Integer) As Integer

            Dim sql As New StringBuilder
            sql.AppendLine("Update Overtime_totalfee ")
            sql.AppendLine("set ")
            If Not String.IsNullOrEmpty(fee1) Then
                sql.AppendLine("    fee1=@fee1, ")
            End If
            If Not String.IsNullOrEmpty(fee2) Then
                sql.AppendLine("    fee2=@fee2, ")
            End If
            If Not String.IsNullOrEmpty(fee3) Then
                sql.AppendLine("    fee3=@fee3, ")
            End If
            If Not String.IsNullOrEmpty(fee4) Then
                sql.AppendLine("    fee4=@fee4, ")
            End If
            If Not String.IsNullOrEmpty(fee5) Then
                sql.AppendLine("    fee5=@fee5, ")
            End If
            If Not String.IsNullOrEmpty(fee6) Then
                sql.AppendLine("    fee6=@fee6, ")
            End If
            If Not String.IsNullOrEmpty(fee7) Then
                sql.AppendLine("    fee7=@fee7, ")
            End If
            If Not String.IsNullOrEmpty(fee8) Then
                sql.AppendLine("    fee8=@fee8, ")
            End If
            If Not String.IsNullOrEmpty(fee9) Then
                sql.AppendLine("    fee9=@fee9, ")
            End If
            If Not String.IsNullOrEmpty(fee10) Then
                sql.AppendLine("    fee10=@fee10, ")
            End If
            If Not String.IsNullOrEmpty(fee11) Then
                sql.AppendLine("    fee11=@fee11, ")
            End If
            If Not String.IsNullOrEmpty(fee12) Then
                sql.AppendLine("    fee12=@fee12, ")
            End If

            sql.AppendLine("    update_date=@update_date, update_userid=@update_userid ")
            sql.AppendLine("where  ")
            sql.AppendLine("    Orgcode=@Orgcode and  Depart_id=@Depart_id and budget_year=@budget_year and budget_type=@budget_type ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@budget_year", budget_year), _
            New SqlParameter("@budget_type", budget_type), _
            New SqlParameter("@fee1", fee1), _
            New SqlParameter("@fee2", fee2), _
            New SqlParameter("@fee3", fee3), _
            New SqlParameter("@fee4", fee4), _
            New SqlParameter("@fee5", fee5), _
            New SqlParameter("@fee6", fee6), _
            New SqlParameter("@fee7", fee7), _
            New SqlParameter("@fee8", fee8), _
            New SqlParameter("@fee9", fee9), _
            New SqlParameter("@fee10", fee10), _
            New SqlParameter("@fee11", fee11), _
            New SqlParameter("@fee12", fee12), _
            New SqlParameter("@update_date", Now.ToString("yyyy/MM/dd HH:mm:ss")), _
            New SqlParameter("@update_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))}

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal budget_type As String, ByVal budget_year As String, ByVal Depart_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine("select ")
            sql.AppendLine("        case when (select top 1 depart_name from fscorg where Orgcode=@Orgcode and depart_id=@Depart_id) is null then '技工、工友、駕駛' ")
            sql.AppendLine("        else (select top 1 depart_name from fscorg where Orgcode=@Orgcode and depart_id=@Depart_id) end as Depart_name, ")
            sql.AppendLine("        ob.Budget, ob.depart_id, ob.budget_type, ")
            sql.AppendLine("        isnull(ot.fee1,0) as fee1, isnull(ot.fee2,0) as fee2, isnull(ot.fee3,0) as fee3, isnull(ot.fee4,0) as fee4, ")
            sql.AppendLine("        isnull(ot.fee5,0) as fee5, isnull(ot.fee6,0) as fee6, isnull(ot.fee7,0) as fee7, isnull(ot.fee8,0) as fee8, ")
            sql.AppendLine("        isnull(ot.fee9,0) as fee9, isnull(ot.fee10,0) as fee10, isnull(ot.fee11,0) as fee11, isnull(ot.fee12,0) as fee12, ")
            sql.AppendLine("        ob.Budget - (isnull(ot.fee1,0)+isnull(ot.fee2,0)+isnull(ot.fee3,0)+isnull(ot.fee4,0)+isnull(ot.fee5,0)+isnull(ot.fee6,0)+isnull(ot.fee7,0)+isnull(ot.fee8,0)+isnull(ot.fee9,0)+isnull(ot.fee10,0)+isnull(ot.fee11,0)+isnull(ot.fee12,0)) as [left] ")
            sql.AppendLine("from Overtime_budget ob ")
            sql.AppendLine("    left outer join Overtime_totalfee ot on ot.Orgcode=ob.Orgcode and ot.Depart_id=ob.Depart_id and ot.Budget_year=ob.Budget_year and ot.Budget_type=ob.Budget_type ")
            sql.AppendLine("where ob.Orgcode=@Orgcode and ob.Depart_id=@Depart_id and ob.budget_type=@budget_type and ob.budget_year=@budget_year ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@budget_type", budget_type), _
            New SqlParameter("@budget_year", budget_year), _
            New SqlParameter("@Depart_id", Depart_id)}
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function GetSumByYear(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String) As Object
            Dim sql As New StringBuilder
            sql.AppendLine("select sum(isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0)) as fee ")
            sql.AppendLine("from Overtime_totalfee ")
            sql.AppendLine("where Orgcode=@Orgcode and budget_type=@budget_type and budget_year=@budget_year ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@budget_year", budget_year), _
            New SqlParameter("@budget_type", budget_type)}
            Return SqlAccessHelper.ExecuteScalar(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function GetAllSumData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal budget_year As String, ByVal budget_type As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine("select sum(isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0)+isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0)+isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0)+isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0)) as fee, ")
            sql.AppendLine("        isnull(fee1,0)+isnull(fee2,0)+isnull(fee3,0) as feeA, isnull(fee4,0)+isnull(fee5,0)+isnull(fee6,0) as feeB, ")
            sql.AppendLine("        isnull(fee7,0)+isnull(fee8,0)+isnull(fee9,0) as feeC, isnull(fee10,0)+isnull(fee11,0)+isnull(fee12,0) as feeD, ")
            sql.AppendLine("        isnull(fee1,0), isnull(fee2,0), isnull(fee3,0), isnull(fee4,0), isnull(fee5,0), isnull(fee6,0), isnull(fee7,0), isnull(fee8,0), isnull(fee9,0), isnull(fee10,0), isnull(fee11,0), isnull(fee12,0) ")
            sql.AppendLine("from Overtime_totalfee ")
            sql.AppendLine("where Orgcode=@Orgcode and Depart_id=@Depart_id and budget_type=@budget_type and budget_year=@budget_year ")
            sql.AppendLine("group by ")
            sql.AppendLine("        fee1, fee2, fee3, fee4, fee5, fee6, fee7, fee8, fee9, fee10, fee11, fee12 ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@budget_year", budget_year), _
            New SqlParameter("@budget_type", budget_type)}
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function UpdateFee(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String, ByVal fee As Integer) As Integer
            Dim feeColumn As String = "fee" & CInt(Mid(ym, 4, 2)).ToString

            Dim sql As New StringBuilder
            sql.AppendLine("Update Overtime_totalfee set " & feeColumn & "= case when isnull(" & feeColumn & ",0)+@fee <= 0 then 0 else isnull(" & feeColumn & ",0)+@fee end ")
            sql.AppendLine("where Orgcode=@Orgcode and Depart_id=@Depart_id and budget_type=@budget_type and budget_year=@budget_year ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@budget_year", Mid(ym, 1, 3)), _
            New SqlParameter("@budget_type", budget_type), _
            New SqlParameter("@fee", fee)}
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function GetCount(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String) As Object
            Dim sql As New StringBuilder

            sql.AppendLine(" select count(*) ")
            sql.AppendLine(" from Overtime_totalfee ot ")
            sql.AppendLine(" where ot.Orgcode=@Orgcode and ot.Depart_id=@Depart_id and ot.budget_year=@budget_year and ot.budget_type=@budget_type ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@budget_year", Mid(ym, 1, 3)), _
            New SqlParameter("@budget_type", budget_type)}

            Return SqlAccessHelper.ExecuteScalar(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function


        Public Function InsertFee(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ym As String, ByVal budget_type As String, ByVal fee As Integer) As Integer
            Dim feeColumn As String = "fee" & CInt(Mid(ym, 4, 2)).ToString

            Dim sql As New StringBuilder
            sql.AppendLine("Insert into Overtime_totalfee ")
            sql.AppendLine("    (Orgcode, Depart_id, budget_year, budget_type, " & feeColumn & ") ")
            sql.AppendLine("values ")
            sql.AppendLine("    (@Orgcode, @Depart_id, @budget_year, @budget_type, @fee) ")


            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@budget_year", Mid(ym, 1, 3)), _
            New SqlParameter("@budget_type", budget_type), _
            New SqlParameter("@fee", fee)}
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        'Public Function GetSumBySession(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String) As DataSet
        '    Dim sql As New StringBuilder
        '    sql.AppendLine("select fee1+fee2+fee3 as feeA, fee4+fee5+fee6 as feeB, fee7+fee8+fee9 as feeC, fee10+fee11+fee12 as feeD ")
        '    sql.AppendLine("from Overtime_totalfee ")
        '    sql.AppendLine("where Orgcode=@Orgcode and Depart_id=@Depart_id and budget_year=@budget_year ")
        '    Dim params() As SqlParameter = { _
        '     New SqlParameter("@Orgcode", Orgcode), _
        '    New SqlParameter("@budget_year", budget_year), _
        '    New SqlParameter("@budget_type", budget_type)}
        '    Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        'End Function

        'Public Function GetSumByMonth(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String) As DataSet
        '    Dim sql As New StringBuilder
        '    sql.AppendLine("select fee1, fee2, fee3, fee4, fee5, fee6, fee7, fee8, fee9, fee10, fee11, fee12 ")
        '    sql.AppendLine("from Overtime_totalfee ")
        '    sql.AppendLine("where Orgcode=@Orgcode and Depart_id=@Depart_id and budget_year=@budget_year ")
        '    Dim params() As SqlParameter = { _
        '     New SqlParameter("@Orgcode", Orgcode), _
        '    New SqlParameter("@budget_year", budget_year), _
        '    New SqlParameter("@budget_type", budget_type)}
        '    Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        'End Function

    End Class
End Namespace