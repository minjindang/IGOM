Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL1102DAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub
        ''' <summary>
        ''' [取得列印資料]  值班費 依年月
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetApplyDataByDate(ByVal Apply_ym As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "select sb.BANK_BANK_NO,df.Flow_id, sa.BASE_NAME, df.Apply_amt, '' as memo  " + _
                    "from SAL_DUTY_fee df " + _
                    "left join SAL_SABASE sa on df.User_id = sa.BASE_SEQNO " + _
                    "left join sal_sabank sb on df.User_id = sb.BANK_SEQNO " + _
                    "where 1=1 "



            If Not String.IsNullOrEmpty(Apply_ym) Then
                StrSQL &= "and df.Apply_ym=@Apply_ym "
            End If

            Dim params() As SqlParameter = { _
                New SqlParameter("@Apply_ym", SqlDbType.VarChar)}

            params(0).Value = Apply_ym

            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

    End Class
End Namespace