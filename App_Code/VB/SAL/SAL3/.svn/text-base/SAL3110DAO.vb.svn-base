Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL3110DAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' [取得] 生日禮金發放 人員資料
        ''' </summary>
        ''' <returns></returns>
        ''' <CodeSys> 5 </CodeSys>
        ''' <CodeKind> D </CodeKind>
        ''' <CodeType> 001 </CodeType>
        ''' <CodeNo> 412 </CodeNo>
        ''' <Code> 015 </Code>
        Public Function GetDataByMonthRange(ByVal Orgcode As String, ByVal sMonth As String, ByVal eMonth As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "select f.Orgcode_name,f.Depart_name, " + _
                    "m.User_name, m.id_card, m.birth_date, " + _
                    "isnull(p.payitem_Pay_amt,0) as pay_amt " + _
                    "from FSC_Personnel m " + _
                    "inner join FSC_Depart_emp d on m.id_card=d.id_card " + _
                    "left join fsc_org f on d.Orgcode=f.Orgcode and d.Depart_id = f.Depart_id " + _
                    "left join SAL_payitem p on m.id_card = p.payitem_User_id and p.payitem_CodeSys='5' and p.payitem_CodeKind='D' and p.payitem_CodeType='001' and p.payitem_CodeNo='412' and p.payitem_Code='015' and substring(p.payitem_Pay_ym,1,3) = (datepart(year, GETDATE())-1911) " + _
                    "where 1=1 " + _
                    "AND (m.left_date is null or m.left_date ='') "


            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "AND d.Orgcode = @Orgcode "
            End If
            If Not (String.IsNullOrEmpty(sMonth) And String.IsNullOrEmpty(eMonth)) Then
                StrSQL &= "AND substring(m.Birth_date,4,2) between @sMonth and @eMonth "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@sMonth", SqlDbType.VarChar), _
            New SqlParameter("@eMonth", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = sMonth
            params(2).Value = eMonth
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

        ''' <summary>
        ''' [檢核重複]  生日禮金發放
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckInsert(ByVal UserId As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "SELECT * FROM SAL_payitem p  Where 1=1 " + _
                    "AND substring(p.payitem_Pay_ym,1,3) = (datepart(year, GETDATE())-1911) " + _
                    "AND p.payitem_CodeSys='5' and p.payitem_CodeKind='D' and p.payitem_CodeType='001' and p.payitem_CodeNo='412' and p.payitem_Code='015' "

            If Not String.IsNullOrEmpty(UserId) Then
                StrSQL &= "AND p.payitem_User_Id = @UserId "
            End If

            Dim params() As SqlParameter = { _
                        New SqlParameter("@UserId", SqlDbType.VarChar)}

            params(0).Value = UserId
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)

        End Function

    End Class
End Namespace