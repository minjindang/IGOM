Imports Microsoft.VisualBasic
Imports System.Data

Public Class SAL2117DAO


    Public Function GetStartData(v_startYYMM As String, strPayBudgeCode As String) As DataTable
        Dim sql As String = ""

        '內文
        sql = " declare @v_pay_ym varchar(6)"
        sql &= " set @v_pay_ym='" & v_startYYMM & "'"  '（發放工餉年月）
        sql &= " declare @strPayBudgeCode  varchar(3)"
        sql &= " set @strPayBudgeCode='" & strPayBudgeCode & "'"  '（預算來源）
        sql &= " declare @v_PRONO  varchar(3)"
        sql &= " set @v_PRONO='003'" '（技工工友）
        sql &= " declare @v_PAYO_KIND  varchar(3)"
        sql &= " set @v_PAYO_KIND='001'" '（計算類型：工餉）
        sql &= " declare @v_other_code varchar(3)"
        sql &= " set @v_other_code='023'" '(協查研究費)
        sql &= " DECLARE @v_curr_last_day  decimal(5,1) "
        sql &= " DECLARE @v_curr_last_dayS varchar(10)"
        sql &= " SET @v_curr_last_day = dbo.Last_day(@v_pay_ym)"
        sql &= " SET @v_curr_last_dayS = ltrim(str(@v_curr_last_day))"
        sql &= " select  c1.CODE_DESC1 as '職別',base_name as '姓名',SUBSTRING(BASE_ORG_L1,2,2) "
        sql &= " +c3.CODE_DESC2 as '餉級',"
        sql &= " base_ptb as '薪點',"
        sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') as '工餉',"
        sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') as '工作補助費',"
        sql &= " isnull(d3.PAYOD_AMT,0) as '協查研究費',"
        sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'0') - dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') as '調整待遇-工餉',"
        sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'0') - dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') as '調整待遇-工作補助費',"
        sql &= " 0 as '交通費',"
        sql &= " d5.PAYOD_AMT as '應發數',"
        sql &= " isnull(m.MEMO_DESCRIPTION,'&nbsp;') as '備註'"
        sql &= " from SAL_sabase a"
        'd3協查研究費
        sql &= " left outer join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from SAL_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='006' and PAYOD_CODE=@v_other_code ) d3 on a.base_Seqno=d3.PAYOD_SEQNO and BASE_ORGID=d3.PAYOD_ORGID"
        'd5應發合計
        sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from SAL_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='003' and PAYOD_CODE_NO='001' ) d5 on a.base_Seqno=d5.PAYOD_SEQNO and BASE_ORGID=d5.PAYOD_ORGID"
        '職稱
        sql &= " inner  join SYS_CODE c1 on c1.CODE_SYS='002' and c1.CODE_KIND='P' and c1.CODE_TYPE='002' and c1.CODE_NO=BASE_DCODE"
        '俸階
        sql &= " inner  join SYS_CODE c3 on c3.CODE_SYS='002' and c3.CODE_KIND='P' and c3.CODE_TYPE='009' and c3.CODE_NO=BASE_ORG_L2"
        '備註
        sql &= " left outer join (select MEMO_DESCRIPTION,MEMO_ORGID,MEMO_SEQNO from SAL_SAMEMO where MEMO_YM=@v_pay_ym and MEMO_KIND=@v_PAYO_KIND) m on BASE_ORGID=m.MEMO_ORGID and base_Seqno=m.MEMO_SEQNO"
        sql &= " where BASE_PRONO=@v_PRONO "

        If strPayBudgeCode <> "ALL" Then
            sql &= " and base_Budget_code = @strPayBudgeCode " '查詢畫面選擇之預算來源代碼
        End If

        sql &= " and ((base_bdate <=  @v_pay_ym+@v_curr_last_dayS )  and  "
        sql &= " (left(base_edate,6) >=  @v_pay_ym  or  isnull(BASE_EDATE,'')  =  ''  )   and  base_status  =  'Y') "
        sql &= " and not((BASE_QUIT_REZN = '001') and (BASE_QUIT_DATE <> '') and (left(BASE_QUIT_DATE,6) < @v_pay_ym))"
        sql &= " order by a.BASE_PRTS"

        Dim dt As New DataTable()
        Using ta As New DB_TableAdapters.DB_TableAdapter
            dt = ta.spExeSQLGetDataTable(sql)
        End Using

        Return dt
    End Function


End Class
