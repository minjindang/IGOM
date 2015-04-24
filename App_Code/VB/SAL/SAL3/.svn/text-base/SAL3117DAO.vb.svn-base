Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL3117DAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function SQLs1(ByVal v_freeze_time As String, ByVal v_UserId As String, ByVal v_orgid As String, ByVal code_no As String, ByVal yy As String, ByVal ym As String) As DataSet

            Dim Sql As String = ""

            Sql = ""
            Sql = Sql & " update SAL_sapayo set "
            Sql = Sql & " payo_freeze = 'Y' "
            Sql = Sql & " ,payo_freeze_time = @v_freeze_time "
            '991231 modify orgid
            'Sql = Sql & " where payo_orgid = '" & vv_UserId & "' "
            Sql = Sql & " where payo_orgid = @v_orgid "

            '991231 modify date
            'If code_no = "002" Or code_no = "003" Or code_no = "004" Then
            '    Sql = Sql & " and left(payo_date,6) = '" & (Val(DropDownList_year.SelectedValue) + 1911).ToString() & DropDownList_month.SelectedValue & "' "
            'Else
            '    Sql = Sql & " and left(payo_date,6) = '" & (Val(DropDownList_year.SelectedValue) + 1911).ToString() & "' "
            'End If
            Sql = Sql & " and left(payo_date,6) = @ym "

            Sql = Sql & " and ( payo_freeze <> 'Y' or payo_freeze is null )"

            '991231 modify payo_kind
            'Sql = Sql & " and payo_kind_code_no = '" & Me.UcSaCode1.Code_no & "' "
            Sql = Sql & " and payo_kind = @code_no "

            Sql = Sql & ""
            Sql = Sql & " update SAL_sainco set "
            Sql = Sql & " inco_freeze = 'Y' "
            Sql = Sql & " ,inco_freeze_time = @v_freeze_time "
            Sql = Sql & " where inco_orgid = @v_orgid "
            If code_no = "002" Or code_no = "003" Or code_no = "004" Then
                Sql = Sql & " and left(inco_date,6) = @yy "
            Else
                Sql = Sql & " and left(inco_date,6) = @ym "
            End If

            Sql = Sql & " and ( inco_freeze <> 'Y' or inco_freeze is null )"

            '991231 modify inco_code
            'Sql = Sql & " and inco_kind_code_no = '" & Me.UcSaCode1.Code_no & "' "
            Sql = Sql & " and inco_code = @code_no "

            Sql = Sql & ""
            Sql = Sql & " insert into SAL_SAFREEZLOG "
            Sql = Sql & " (freez_orgid,freez_ym,freez_muser,freez_mdate,freez_code_no)"
            '					機關	,	凍結年月	,操作人員	,操作時間
            Sql = Sql & " values( "
            Sql = Sql & " @v_orgid,"

            '991231 modify date
            'If code_no = "002" Or code_no = "003" Or code_no = "004" Then
            '    Sql = Sql & " '" & (Val(DropDownList_year.SelectedValue) + 1911).ToString() & "' " & ","
            'Else
            '    Sql = Sql & " '" & (Val(DropDownList_year.SelectedValue) + 1911).ToString() & DropDownList_month.SelectedValue & "' " & ","
            'End If
            Sql = Sql & " @ym,"
            Sql = Sql & " @v_UserId,"
            Sql = Sql & " @v_freeze_time,"
            Sql = Sql & " @code_no "
            Sql = Sql & " )"
            'Response.Write(Sql)

            Dim params() As SqlParameter = { _
                New SqlParameter("@v_freeze_time", SqlDbType.VarChar), _
                New SqlParameter("@v_orgid", SqlDbType.VarChar), _
                New SqlParameter("@v_UserId", SqlDbType.VarChar), _
                New SqlParameter("@code_no", SqlDbType.VarChar), _
                New SqlParameter("@yy", SqlDbType.VarChar), _
                New SqlParameter("@ym", SqlDbType.VarChar)}
            params(0).Value = v_freeze_time
            params(1).Value = v_orgid
            params(2).Value = v_UserId
            params(3).Value = code_no
            params(4).Value = yy
            params(5).Value = ym


            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, Sql, params)

        End Function


    End Class
End Namespace

