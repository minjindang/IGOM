Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SAL.Logic
    Public Class SAL1113DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function doQuerySAL1113(ByVal departId As String, ByVal idNo As String, ByVal busDate As String, ByVal bueDate As String, ByVal officeOuttype As String, Optional ByVal isInit As Boolean = False) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.Append(" SELECT ")
            StrSQL.Append("      m16.*, lm.location_flag ")
            StrSQL.Append(" FROM ")
            StrSQL.Append("     FSC_CPAPP16M m16 WITH(NOLOCK) ")

            If Not String.IsNullOrEmpty(officeOuttype) Then
                If officeOuttype = 1 Then '國內
                    'location_flag = 0為國內出差
                    StrSQL.Append(" INNER JOIN FSC_Leave_main lm WITH(NOLOCK) ON m16.PPGUID=lm.Flow_id and lm.location_flag =0 ")
                Else '國外
                    ''location_flag = 0為國外出差
                    StrSQL.Append(" INNER JOIN FSC_Leave_main lm WITH(NOLOCK) ON m16.PPGUID=lm.Flow_id and lm.location_flag =1 ")
                End If
            Else
                StrSQL.Append(" INNER JOIN FSC_Leave_main lm WITH(NOLOCK) ON m16.PPGUID=lm.Flow_id ")
            End If

            StrSQL.Append(" WHERE PPBUSTYPE='1' AND PPBUSDATEE<@NOW ")

            If Not String.IsNullOrEmpty(departId) Then
                StrSQL.Append(" AND m16.Depart_id=@departId ")
            End If

            If Not String.IsNullOrEmpty(idNo) Then
                StrSQL.Append(" AND PPIDNO = @PPIDNO ")
            End If
            If Not String.IsNullOrEmpty(busDate) Then
                StrSQL.Append(" AND PPBUSDATEB>= @PPBUSDATEB and PPBUSDATEE <= @PPBUSDATEE ")
            End If
            If isInit Then
                StrSQL.Append(" AND PPGUID not in (select PPGUID from sal_Officialout_Fee where Status in ('yet','done')) ")
            End If

            StrSQL.AppendLine(" order by lm.location_flag, PPBUSDATEB, PPBUSDATEE")

            Dim params() As SqlParameter = { _
            New SqlParameter("@departId", SqlDbType.VarChar), _
            New SqlParameter("@PPIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PPBUSDATEB", SqlDbType.VarChar), _
            New SqlParameter("@PPBUSDATEE", SqlDbType.VarChar), _
            New SqlParameter("@NOW", SqlDbType.VarChar)}
            params(0).Value = departId
            params(1).Value = idNo
            params(2).Value = busDate
            params(3).Value = bueDate
            params(4).Value = FSC.Logic.DateTimeInfo.GetRocDate(Now)
            DBUtil.SetParamsNull(params)
            Return Query(StrSQL.ToString(), params)
        End Function

        Public Function GetSAL1113_02Data(ByVal Id_card As String, ByVal Officialout_type As String, ByVal Officialout_dateb As String, ByVal Officialout_timeb As String, ByVal ppguid As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine(" SELECT ")
            StrSQL.AppendLine("     *, ")
            StrSQL.AppendLine("     isnull(Plane,0)+isnull(Car,0)+isnull(Train,0)+isnull(Boat,0)+isnull(Live,0)+isnull(Food,0)+isnull(Sudden,0) AS Total ")
            StrSQL.AppendLine(" FROM ")
            StrSQL.AppendLine("     SAL_Officialout_Fee WITH(NOLOCK)    ")
            StrSQL.AppendLine(" WHERE ")
            StrSQL.AppendLine("     Id_card = @Id_card ")
            StrSQL.AppendLine("     AND Officialout_type = @Officialout_type ")
            StrSQL.AppendLine("     AND Officialout_dateb = @Officialout_dateb ")
            StrSQL.AppendLine("     AND Officialout_timeb = @Officialout_timeb ")
            StrSQL.AppendLine("     AND ppguid = @ppguid ")
            StrSQL.AppendLine(" order by officialout_date ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_type", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_dateb", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_timeb", SqlDbType.VarChar), _
            New SqlParameter("@ppguid", SqlDbType.VarChar)}
            params(0).Value = Id_card
            params(1).Value = Officialout_type
            params(2).Value = Officialout_dateb
            params(3).Value = Officialout_timeb
            params(4).Value = ppguid
            Return Query(StrSQL.ToString(), params)
        End Function


        Public Function GetSAL1113_02DataByPPGUID(ByVal Id_card As String, ByVal Officialout_type As String, ByVal ppguid As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine(" SELECT ")
            StrSQL.AppendLine("     *, ")
            StrSQL.AppendLine("     isnull(self_car,0)+isnull(Plane,0)+isnull(Car,0)+isnull(Train,0)+isnull(Boat,0)+isnull(Live,0)+isnull(Food,0)+isnull(Sudden,0)+isnull(Special_fee,0)+isnull(Long_traffic,0)+isnull(Life_fee,0)+isnull(Fee,0)+isnull(Insurance,0)+isnull(Administrative_costs,0)+isnull(Gift_entertainment_expenses,0)+isnull(Incidentals,0) AS Total ")
            StrSQL.AppendLine(" FROM ")
            StrSQL.AppendLine("     SAL_Officialout_Fee WITH(NOLOCK)    ")
            StrSQL.AppendLine(" WHERE ")
            StrSQL.AppendLine("     Id_card = @Id_card ")
            StrSQL.AppendLine("     AND Officialout_type = @Officialout_type ")
            StrSQL.AppendLine("     AND ppguid = @ppguid ")
            StrSQL.AppendLine(" order by officialout_date ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Officialout_type", SqlDbType.VarChar), _
            New SqlParameter("@ppguid", SqlDbType.VarChar)}
            params(0).Value = Id_card
            params(1).Value = Officialout_type
            params(2).Value = ppguid
            Return Query(StrSQL.ToString(), params)
        End Function


        Public Function GetFeeLimitByIdCard(ByVal IdCard As String) As DataTable
            Dim StrSQL As New StringBuilder

            Dim whereCondi As String = ""

            StrSQL.Append(" SELECT ")
            'StrSQL.Append("       code.descr pecrkcodDesc, m05.pememcod, m05.level, m05.pepoint, ")
            StrSQL.Append("       code.descr pecrkcodDesc, p.level, p.pepoint, ")
            StrSQL.Append("       code2.descr pepointDesc ")
            StrSQL.Append(" FROM ")
            StrSQL.Append("       FSC_Personnel p ")
            StrSQL.Append("       LEFT OUTER JOIN SYS_code code ON p.level = code.code_NO AND code.CODE_SYS = '002' ")
            StrSQL.Append("       LEFT OUTER JOIN SYS_code code2 ON m05.petit = code2.code_NO AND code2.CODE_SYS = '023' ")
            StrSQL.Append(" WHERE ")
            StrSQL.Append("      p.id_card = @IdCard ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@IdCard", SqlDbType.VarChar)}
            params(0).Value = IdCard
            Return Query(StrSQL.ToString(), params)
        End Function
        ''' <summary>
        ''' 取得該申請人上一次申請的預算來源
        ''' </summary>
        ''' <param name="id_card"></param>
        ''' <param name="Officialout_type"></param>
        ''' <param name="ppguid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLastBudget(ByVal id_card As String, ByVal Officialout_type As String, ByVal ppguid As String) As String
            Dim sql As New StringBuilder
            sql.AppendLine(" select top 1 * from SAL_Officialout_Fee WITH(NOLOCK) ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine("     Id_card = @Id_card ")
            sql.AppendLine("     AND Officialout_type = @Officialout_type ")
            sql.AppendLine("     AND ppguid = @ppguid ")
            sql.AppendLine(" order by officialout_date ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
                        New SqlParameter("@Officialout_type", SqlDbType.VarChar), _
            New SqlParameter("@ppguid", SqlDbType.VarChar)}
            params(0).Value = id_card
            params(1).Value = Officialout_type
            params(2).Value = ppguid

            Dim dt As DataTable = Query(sql.ToString(), params)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return dt.Rows(0)("Budget_type").ToString()
            Else
                Return "001"
            End If
        End Function

    End Class
End Namespace
