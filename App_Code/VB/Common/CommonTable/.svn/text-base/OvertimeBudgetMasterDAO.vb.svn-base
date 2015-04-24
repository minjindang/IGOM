Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace SAL.Logic
    Public Class OvertimeBudgetMasterDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetBudget_year(ByVal Orgcode As String) As DataSet
            Dim StrSQL As String = "SELECT budget_year FROM Overtime_budget_master WHERE Orgcode=@Orgcode GROUP BY budget_year ORDER BY budget_year DESC"
            Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param.Value = Orgcode

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetRemaining_applyIsNData(ByVal Orgcode As String, ByVal Budget_year As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT * " & _
                        "FROM Overtime_budget_Master WHERE Orgcode=@Orgcode AND budget_year=@budget_year AND Remaining_Apply='N' "

            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar), New SqlParameter("@budget_year", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Budget_year

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal Budget_year As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine("SELECT *, ")
            sql.AppendLine("isnull((Select Sum(budget) from Overtime_budget where Orgcode=@Orgcode and budget_year=@budget_year and budget_type='1'),0) AS Assign_public, ")
            sql.AppendLine("isnull((Select Sum(budget) from Overtime_budget where Orgcode=@Orgcode and budget_year=@budget_year and budget_type='2'),0) AS Assign_fund ")
            sql.AppendLine("FROM Overtime_budget_Master WHERE Orgcode=@Orgcode AND budget_year=@budget_year ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@budget_year", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Budget_year

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function


        Public Function InsertData(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String, ByVal budget_public As Integer, _
                                     ByVal budget_fund As Integer, ByVal close_date As String, ByVal Remaining_apply As String, ByVal UnAnnualFee_lock As String, ByVal create_userid As String) As Integer
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO Overtime_budget_master (Orgcode, budget_year, budget_type, budget_public, budget_fund, close_date, " & _
                                                        "Remaining_apply, UnAnnualFee_lock, create_date, create_userid) " & _
                                                "VALUES (@Orgcode, @budget_year, @budget_type, @budget_public, @budget_fund, @close_date, " & _
                                                        "@Remaining_apply, @UnAnnualFee_lock, @create_date, @create_userid)"
            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar), _
                                            New SqlParameter("@budget_year", SqlDbType.VarChar), _
                                            New SqlParameter("@budget_type", SqlDbType.VarChar), _
                                            New SqlParameter("@budget_public", SqlDbType.Int), _
                                            New SqlParameter("@budget_fund", SqlDbType.Int), _
                                            New SqlParameter("@close_date", SqlDbType.VarChar), _
                                            New SqlParameter("@Remaining_apply", SqlDbType.VarChar), _
                                            New SqlParameter("@UnAnnualFee_lock", SqlDbType.VarChar), _
                                            New SqlParameter("@create_date", SqlDbType.DateTime), _
                                            New SqlParameter("@create_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = budget_year
            params(2).Value = budget_type
            params(3).Value = budget_public
            params(4).Value = budget_fund
            params(5).Value = close_date
            params(6).Value = Remaining_apply
            params(7).Value = UnAnnualFee_lock
            params(8).Value = Now.ToString("yyyy/MM/dd HH:mm:ss")
            params(9).Value = create_userid

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function


        Public Function UpdateData(ByVal Orgcode As String, ByVal budget_year As String, ByVal budget_type As String, ByVal budget_public As Integer, _
                                    ByVal budget_fund As Integer, ByVal close_date As String, ByVal Remaining_apply As String, _
                                    ByVal UnAnnualFee_lock As String, ByVal update_userid As String) As Integer
            Dim StrSQL As String = ""
            StrSQL = "UPDATE Overtime_budget_master SET budget_type=@budget_type, budget_public=@budget_public, budget_fund=@budget_fund, " & _
                                                        "close_date=@close_date, Remaining_apply=@Remaining_apply, UnAnnualFee_lock=@UnAnnualFee_lock, " & _
                                                        "update_date=@update_date, update_userid=@update_userid " & _
                                                    "WHERE Orgcode=@Orgcode AND budget_year=@budget_year"

            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar), _
                                            New SqlParameter("@Budget_year", SqlDbType.VarChar), _
                                            New SqlParameter("@Budget_type", SqlDbType.VarChar), _
                                            New SqlParameter("@budget_public", SqlDbType.Int), _
                                            New SqlParameter("@budget_fund", SqlDbType.Int), _
                                            New SqlParameter("@close_date", SqlDbType.VarChar), _
                                            New SqlParameter("@Remaining_apply", SqlDbType.VarChar), _
                                            New SqlParameter("@UnAnnualFee_lock", SqlDbType.VarChar), _
                                            New SqlParameter("@update_date", SqlDbType.DateTime), _
                                            New SqlParameter("@update_userid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = budget_year
            params(2).Value = budget_type
            params(3).Value = budget_public
            params(4).Value = budget_fund
            params(5).Value = close_date
            params(6).Value = Remaining_apply
            params(7).Value = UnAnnualFee_lock
            params(8).Value = Now.ToString("yyyy/MM/dd HH:mm:ss")
            params(9).Value = update_userid

            Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

    End Class
End Namespace