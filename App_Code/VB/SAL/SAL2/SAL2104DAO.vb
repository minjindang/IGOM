Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL2104DAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function SQLs1(ByVal v_UserOrgId As String, ByVal ym As String, Optional ByVal code_no As String = "") As DataSet

            Dim rv As String = ""

            rv = _
            "SELECT DISTINCT  sl.* " & _
            "FROM SAL_SAFREEZLOG sl " & _
            "WHERE ( sl.FREEZ_ORGID =@Orgcode ) "
            '"WHERE (SABASE.BASE_ORGID = SAFREEZLOG.FREEZ_ORGID AND SABASE.BASE_IDNO = SAFREEZLOG.FREEZ_MUSER AND SABASE.BASE_ORGID ='" & v_UserOrgId & "') "

            '' 查詢年月
            rv &= " AND (SubString(sl.FREEZ_YM, 1, 6) = '" & ym & "') "
            If Not String.IsNullOrEmpty(code_no) Then
                rv &= " AND FREEZ_CODE_NO=@code_no "
            End If


            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgcode", SqlDbType.VarChar), _
                New SqlParameter("@ym", SqlDbType.VarChar), _
                New SqlParameter("@code_no", SqlDbType.VarChar)}
            params(0).Value = v_UserOrgId
            params(1).Value = ym
            params(2).Value = code_no

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, rv, params)

        End Function


    End Class
End Namespace

