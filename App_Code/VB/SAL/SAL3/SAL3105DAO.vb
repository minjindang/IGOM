Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL3105DAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function SQLs1( _
            ByVal v_UserOrgId As String, _
            ByVal v_Search_edate As String, _
            ByVal v_Search_prono As String, _
            ByVal v_Search_year As String, _
            ByVal v_Search_str As String, _
            ByVal v_Search_dept As String, _
            ByVal v_Search_id_card As String _
            ) As DataSet

            Dim rv As String = ""


            rv = " select  Base_Seqno,Base_Idno,Base_Orgid,Base_Name, @Year as Grad_Year,isnull(Grad_Brot,0) as Grad_Brot,isnull(Grad_Prot,0) as Grad_Prot "
            rv &= ",base_job, base_dep "
            rv &= ",(select code_desc1 from SYS_CODE where code_sys='002' and code_kind='P' and code_type='002' and code_no=BASE_DCODE) as base_DCODE_name"
            rv &= ",(select code_desc1 from SYS_CODE where code_sys='002' and code_kind='P' and code_type='001' and code_no=base_job) as base_job_name"
            rv &= ",(select code_desc1 from SYS_CODE where code_sys='002' and code_kind='P' and code_type='017' and code_no=base_prono) as base_prono_name"
            rv &= " FROM SAL_SABASE LEFT JOIN SAL_SAGRAD ON BASE_SEQNO = GRAD_SEQNO  "
            rv &= " and base_orgid = grad_orgid "
            rv &= " and GRAD_YEAR = @Year "
            rv &= " where base_orgid = @Orgcode and  base_status = 'Y' and (base_bdate <= @Year + '1231' or  base_bdate = '' ) "
            Select Case v_Search_edate
                Case "1"   '在職
                    rv &= " and (base_edate='' or base_edate is null) "
                Case "2"   '離職
                    rv &= " and base_edate <> '' "
                Case Else
                    rv &= " and (base_edate >= @Year +'1202' or base_edate is null or base_edate = '' or base_edate='99999999' ) "
            End Select

            If Not String.IsNullOrEmpty(v_Search_prono) Then
                rv &= " and base_prono = @prono "
            End If

            If Not String.IsNullOrEmpty(v_Search_str) Then
                rv &= " and base_seqno =@str "
            End If

            If Not String.IsNullOrEmpty(v_Search_dept) Then
                rv &= " and (base_dep =@dept or base_dep in (select depart_id from FSC_Org where parent_depart_id = @dept )) "
            End If

            If Not String.IsNullOrEmpty(v_Search_id_card) Then
                rv &= " and base_seqno =@id_card "
            End If

            rv &= " order by cast(base_prts as float)"


            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgcode", SqlDbType.VarChar), _
                New SqlParameter("@prono", SqlDbType.VarChar), _
                New SqlParameter("@Year", SqlDbType.VarChar), _
                New SqlParameter("@Str", SqlDbType.VarChar), _
                New SqlParameter("@dept", SqlDbType.VarChar), _
                New SqlParameter("@id_card", SqlDbType.VarChar)}
            params(0).Value = v_UserOrgId
            params(1).Value = v_Search_prono
            params(2).Value = v_Search_year
            params(3).Value = v_Search_str
            params(4).Value = v_Search_dept
            params(5).Value = v_Search_id_card
            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, rv, params)


        End Function


        Public Function Query_Base(ByVal v_orgid As String, ByVal v_year As String, ByVal v_prono As String, ByVal v_dept As String, ByVal v_id_card As String) As DataSet

            Dim sql_str As String = ""
            sql_str = " select Base_Seqno "
            sql_str &= " from Sal_SaBase "
            sql_str &= " where base_orgid = @orgid and  base_status = 'Y' and (base_bdate <= @Year + '1231' or  base_bdate = '' ) "
            sql_str &= " and (base_edate >=  @Year + '1202' or base_edate is null or base_edate = '' or base_edate='99999999' ) "

            If Not String.IsNullOrEmpty(v_prono) Then
                sql_str &= " and base_prono = @prono "
            End If
            If Not String.IsNullOrEmpty(v_dept) Then
                sql_str &= " and (base_dep = @dept or base_dep in (select depart_id from fsc_org where parent_depart_id=@dept)) "
            End If
            If Not String.IsNullOrEmpty(v_id_card) Then
                sql_str &= " and base_seqno = @id_card "
            End If


            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgid", SqlDbType.VarChar), _
                New SqlParameter("@Year", SqlDbType.VarChar), _
                New SqlParameter("@prono", SqlDbType.VarChar), _
                New SqlParameter("@dept", SqlDbType.VarChar), _
                New SqlParameter("@id_card", SqlDbType.VarChar)}
            params(0).Value = v_orgid
            params(1).Value = v_year
            params(2).Value = v_prono
            params(3).Value = v_dept
            params(4).Value = v_id_card

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql_str, params)


        End Function

    End Class
End Namespace

