Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL3124DAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function getUnit(ByVal unit_no As String) As DataTable
            Dim sql = " select * from SAL_saunit where unit_no = @unit_no "

            Dim param(0) As SqlParameter
            param(0) = New SqlParameter("unit_no", SqlDbType.VarChar)
            param(0).Value = unit_no

            Return MyBase.Query(sql, param)
        End Function

        Public Function getEmail(ByVal v_UserId As String) As DataTable
            Dim sql = " select * from FSC_PERSONNEL where id_card = @v_UserId "

            Dim param(0) As SqlParameter
            param(0) = New SqlParameter("v_UserId", SqlDbType.VarChar)
            param(0).Value = v_UserId

            Return MyBase.Query(sql, param)
        End Function

        Public Function getinco62(ByVal v_orgid As String, ByVal v_ym As String) As DataTable
            '' 所得類別 inco_icode = 50(001) ,且員工非兼職
            Dim code_no As String = "001"
            Dim Sql As String = ""

            Sql &= " select a.inco_seqno, a.inco_prikey, inco_code, a.inco_date, a.inco_amt, a.inco_health_ext "
            Sql &= " , a.inco_code, a.inco_kind_code "
            Sql &= " , c.base_idno, c.base_name "
            Sql &= " , it.code_desc1 as icode_name "
            Sql &= " , bc.code_desc1 as budget_code , inco_no "
            Sql &= " , ( "
            Sql &= " 	select isnull(sum(b.inco_amt),0) from sal_sainco b "
            Sql &= " 	where b.inco_orgid = a.inco_orgid "
            Sql &= " 	and b.inco_seqno = a.inco_seqno "
            Sql &= "    and b.inco_date like @YY + '%' "
            Sql &= " 	and  "
            Sql &= " 	( "
            Sql &= " 		(b.inco_code in ('002','003','004')) "
            Sql &= " 		or  "
            Sql &= " 		( "
            Sql &= " 			b.inco_code = '005' "
            Sql &= " 			and b.inco_icode = '001' "
            Sql &= " 			and exists "
            Sql &= " 			( "
            Sql &= " 				select 1 "
            Sql &= " 				from sal_saitem "
            Sql &= " 				where item_orgid = b.inco_orgid "
            Sql &= " 				and item_code = b.inco_kind_code "
            Sql &= " 				and ITEM_ADD_HealthPlus='Y' "
            Sql &= "                and ITEM_ADD_HealthPlusbonus='Y' "
            Sql &= " 			) "
            Sql &= " 		) "
            Sql &= " 	) "
            Sql &= " 	and "
            Sql &= " 	( "
            Sql &= " 		(b.inco_date < a.inco_date) "
            Sql &= " 		or "
            Sql &= " 		( "
            Sql &= " 			b.inco_date = a.inco_date "
            Sql &= " 			and b.inco_code <= a.inco_code "
            Sql &= " 		) "
            Sql &= " 	) "
            Sql &= " ) as inco_sum "
            Sql &= " , isnull(( "
            Sql &= " select sum( cast(isnull(PAYO_FINS_SERIES,0) as int))  "
            Sql &= " from sal_sapayo p "
            Sql &= " where p.payo_orgid = a.inco_orgid "
            Sql &= " and p.payo_seqno = a.inco_seqno "
            Sql &= " and p.payo_kind ='001' "
            Sql &= " and p.payo_yymm = substring(a.inco_date,1,6) "
            Sql &= " ),0) as fins_series "
            Sql &= " from sal_sainco a "
            Sql &= " inner join sal_sabase c "
            Sql &= " on c.base_orgid = a.inco_orgid "
            Sql &= " and c.base_seqno = a.inco_seqno "
            Sql &= " and c.base_status = 'Y' and c.base_parttime = 'N' "
            Sql &= " left outer join sys_code it "
            Sql &= " on it.code_sys = '003' and it.code_type = '004' and it.code_no = inco_icode "
            Sql &= " left outer join sys_code bc "
            Sql &= " on bc.code_sys = '002' and bc.code_type = '018' and bc.code_no = inco_budget_code "
            Sql &= " where a.inco_orgid = @ORGID "
            Sql &= " and a.inco_date like @YM "
            Sql &= " and inco_icode = '001'  "
            Sql &= " and a.inco_health_ext > 0 "
            Sql &= " order by inco_budget_code, inco_icode, base_name, inco_date "

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("ORGID", SqlDbType.VarChar)
            params(0).Value = v_orgid
            params(1) = New SqlParameter("YM", SqlDbType.VarChar)
            params(1).Value = v_ym + "%"
            params(2) = New SqlParameter("YY", SqlDbType.VarChar)
            params(2).Value = v_ym.Substring(0, 4)

            Return MyBase.Query(Sql, params)
        End Function

        Public Function getinco63(ByVal v_orgid As String, ByVal v_ym As String) As DataTable
            '' 兼職所得 inco_icode = 50(001) ,且非員工 or 兼職
            Dim code_no As String = "001"
            Dim Sql As String = ""

            Sql &= " select a.inco_seqno, a.inco_prikey, inco_code, a.inco_date, a.inco_amt, a.inco_health_ext "
            Sql &= " , a.inco_code, a.inco_kind_code "
            Sql &= " , c.base_idno, c.base_name "
            Sql &= " , it.code_desc1 as icode_name "
            Sql &= " , bc.code_desc1 as budget_code , inco_no "
            Sql &= " from sal_sainco a "
            Sql &= " inner join sal_sabase c "
            Sql &= " on c.base_orgid = a.inco_orgid "
            Sql &= " and c.base_seqno = a.inco_seqno "
            Sql &= " and ( "
            Sql &= "   c.base_status = 'N' "
            Sql &= "   or ( c.base_status = 'Y' and c.base_parttime = 'Y' ) "
            Sql &= " ) "
            Sql &= " left outer join sys_code it "
            Sql &= " on it.code_sys = '003' and it.code_type = '004' and it.code_no = inco_icode "
            Sql &= " left outer join sys_code bc "
            Sql &= " on bc.code_sys = '002' and bc.code_type = '018' and bc.code_no = inco_budget_code "
            Sql &= " where a.inco_orgid = @ORGID "
            Sql &= " and a.inco_date like @YM "
            Sql &= " and inco_icode = '001'  "
            Sql &= " and a.inco_health_ext > 0 "
            Sql &= " order by inco_budget_code, inco_icode, base_name, inco_date "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("ORGID", SqlDbType.VarChar)
            params(0).Value = v_orgid
            params(1) = New SqlParameter("YM", SqlDbType.VarChar)
            params(1).Value = v_ym + "%"

            Return MyBase.Query(Sql, params)
        End Function

        Public Function getinco65(ByVal v_orgid As String, ByVal v_ym As String) As DataTable
            '' 執行業務 inco_icode = 9A(013), 9B(014)

            Dim code_no As String = "013,014"
            Dim Sql As String = ""

            Sql &= " select a.inco_seqno, a.inco_prikey, inco_code, a.inco_date, a.inco_amt, a.inco_health_ext "
            Sql &= " , a.inco_code, a.inco_kind_code "
            Sql &= " , c.base_idno, c.base_name "
            Sql &= " , it.code_desc1 as icode_name "
            Sql &= " , bc.code_desc1 as budget_code , inco_no "
            Sql &= " from sal_sainco a "
            Sql &= " inner join sal_sabase c "
            Sql &= " on c.base_orgid = a.inco_orgid "
            Sql &= " and c.base_seqno = a.inco_seqno "
            Sql &= " left outer join sys_code it "
            Sql &= " on it.code_sys = '003' and it.code_type = '004' and it.code_no = inco_icode "
            Sql &= " left outer join sys_code bc "
            Sql &= " on bc.code_sys = '002' and bc.code_type = '018' and bc.code_no = inco_budget_code "
            Sql &= " where a.inco_orgid = @ORGID "
            Sql &= " and a.inco_date like @YM "
            Sql &= " and inco_icode in ( '013', '014' ) "
            Sql &= " and a.inco_health_ext > 0 "
            Sql &= " order by inco_budget_code, inco_icode, base_name, inco_date "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("ORGID", SqlDbType.VarChar)
            params(0).Value = v_orgid
            params(1) = New SqlParameter("YM", SqlDbType.VarChar)
            params(1).Value = v_ym + "%"

            Return MyBase.Query(Sql, params)
        End Function

        Public Function getinco67(ByVal v_orgid As String, ByVal v_ym As String) As DataTable
            '' 利息 inco_icode = 5A(006), 5B(007), 5C(---), 52(003)

            Dim code_no As String = "006,007,003"
            Dim Sql As String = ""

            Sql &= " select a.inco_seqno, a.inco_prikey, inco_code, a.inco_date, a.inco_amt, a.inco_health_ext "
            Sql &= " , a.inco_code, a.inco_kind_code "
            Sql &= " , c.base_idno, c.base_name "
            Sql &= " , it.code_desc1 as icode_name "
            Sql &= " , bc.code_desc1 as budget_code , inco_no "
            Sql &= " from sal_sainco a "
            Sql &= " inner join sal_sabase c "
            Sql &= " on c.base_orgid = a.inco_orgid "
            Sql &= " and c.base_seqno = a.inco_seqno "
            Sql &= " left outer join sys_code it "
            Sql &= " on it.code_sys = '003' and it.code_type = '004' and it.code_no = inco_icode "
            Sql &= " left outer join sys_code bc "
            Sql &= " on bc.code_sys = '002' and bc.code_type = '018' and bc.code_no = inco_budget_code "
            Sql &= " where a.inco_orgid = @ORGID "
            Sql &= " and a.inco_date like @YM "
            Sql &= " and inco_icode in ( '006', '007', '003' ) "
            Sql &= " and a.inco_health_ext > 0 "
            Sql &= " order by inco_budget_code, inco_icode, base_name, inco_date "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("ORGID", SqlDbType.VarChar)
            params(0).Value = v_orgid
            params(1) = New SqlParameter("YM", SqlDbType.VarChar)
            params(1).Value = v_ym + "%"

            Return MyBase.Query(Sql, params)
        End Function

        Public Function getinco68(ByVal v_orgid As String, ByVal v_ym As String) As DataTable
            '' 租金 inco_icode = 51(002, 016, 017, 018, 019, 020)

            Dim code_no As String = "002"
            Dim Sql As String = ""

            Sql &= " select a.inco_seqno, a.inco_prikey, inco_code, a.inco_date, a.inco_amt, a.inco_health_ext "
            Sql &= " , a.inco_code, a.inco_kind_code "
            Sql &= " , c.base_idno, c.base_name "
            Sql &= " , it.code_desc1 as icode_name "
            Sql &= " , bc.code_desc1 as budget_code , inco_no "
            Sql &= " from sal_sainco a "
            Sql &= " inner join sal_sabase c "
            Sql &= " on c.base_orgid = a.inco_orgid "
            Sql &= " and c.base_seqno = a.inco_seqno "
            Sql &= " left outer join sys_code it "
            Sql &= " on it.code_sys = '003' and it.code_type = '004' and it.code_no = inco_icode "
            Sql &= " left outer join sys_code bc "
            Sql &= " on bc.code_sys = '002' and bc.code_type = '018' and bc.code_no = inco_budget_code "
            Sql &= " where a.inco_orgid = @ORGID "
            Sql &= " and a.inco_date like @YM "
            Sql &= " and inco_icode = '002' "
            Sql &= " and a.inco_health_ext > 0 "
            Sql &= " order by inco_budget_code, inco_icode, base_name, inco_date "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("ORGID", SqlDbType.VarChar)
            params(0).Value = v_orgid
            params(1) = New SqlParameter("YM", SqlDbType.VarChar)
            params(1).Value = v_ym + "%"

            Return MyBase.Query(Sql, params)
        End Function
    End Class
End Namespace

