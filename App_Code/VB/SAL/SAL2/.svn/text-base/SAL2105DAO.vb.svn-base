Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace SALARY.Logic
    Public Class SAL2105DAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetDataByQuery(ByVal v_startYYMM As String, ByVal v_base_prono As String) As DataTable

            Dim Sql As String
            '內文
            Sql = " declare @v_pay_ym varchar(6)"
            Sql &= " set @v_pay_ym='" & v_startYYMM & "'"  '（發放工餉年月）
            Sql &= " declare @v_PRONO  varchar(3)"
            Sql &= " set @v_PRONO='" & v_base_prono & "'" '（人員類別）
            Sql &= " declare @v_PAYO_KIND  varchar(3)"
            Sql &= " set @v_PAYO_KIND='001'" '（計算類型：工餉）
            Sql &= " declare @v_other_code varchar(3)"
            Sql &= " set @v_other_code='023'" '(協查研究費)
            Sql &= " DECLARE @v_curr_last_day  decimal(5,1) "
            Sql &= " DECLARE @v_curr_last_dayS varchar(10)"
            Sql &= " SET @v_curr_last_day = dbo.Last_day(@v_pay_ym)"
            Sql &= " SET @v_curr_last_dayS = ltrim(str(@v_curr_last_day))"

            If "001".Equals(v_base_prono) Then '政務人員
                Sql &= " select  c1.CODE_DESC1 as '職稱',base_name as '姓名',"
                Sql &= " d0.PAYOD_AMT as '月俸',"
                Sql &= " d2.PAYOD_AMT as '公費',"
                Sql &= " isnull(d3.PAYOD_AMT,0) as '調查研究費',"
                Sql &= " 0 as '調整待遇-月俸',"
                Sql &= " 0 as '調整待遇-公費',"
                Sql &= " 0 as '實物代金',"
                Sql &= " 0 as '交通費',"
                Sql &= " d5.PAYOD_AMT as '應發數',"
                Sql &= " isnull(m.MEMO_DESCRIPTION,'&nbsp;') as '備註'"
                Sql &= " from sal_sabase a"
                'd0薪給總額
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='001' ) d0 on a.base_Seqno=d0.PAYOD_SEQNO and BASE_ORGID=d0.PAYOD_ORGID"
                'd2工作補助費
                Sql &= " inner join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='003' ) d2 on a.base_Seqno=d2.PAYOD_SEQNO and BASE_ORGID=d2.PAYOD_ORGID"
                'd3協查研究費
                Sql &= " left outer join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='006' and PAYOD_CODE=@v_other_code ) d3 on a.base_Seqno=d3.PAYOD_SEQNO and BASE_ORGID=d3.PAYOD_ORGID"
                'd5應發合計
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='003' and PAYOD_CODE_NO='001' ) d5 on a.base_Seqno=d5.PAYOD_SEQNO and BASE_ORGID=d5.PAYOD_ORGID"
                '職稱
                Sql &= " inner  join sys_code c1 on c1.CODE_SYS='002' and c1.CODE_KIND='P' and c1.CODE_TYPE='002' and c1.CODE_NO=BASE_DCODE"
                '俸階
                Sql &= " left outer  join sys_code c3 on c3.CODE_SYS='002' and c3.CODE_KIND='P' and c3.CODE_TYPE='009' and c3.CODE_NO=BASE_ORG_L2"
                '備註
                Sql &= " left outer join (select MEMO_DESCRIPTION,MEMO_ORGID,MEMO_SEQNO from SAL_SAMEMO where MEMO_YM=@v_pay_ym and MEMO_KIND=@v_PAYO_KIND) m on BASE_ORGID=m.MEMO_ORGID and base_Seqno=m.MEMO_SEQNO"
            ElseIf "002".Equals(v_base_prono) Or "003".Equals(v_base_prono) Then '一般行政人員  監察調查人員
                Sql &= " select  c1.CODE_DESC1 as '職稱',base_name as '姓名',SUBSTRING(BASE_ORG_L1,2,2) "
                Sql &= " +c3.CODE_DESC2 as '職級',ISNULL(SUBSTRING(BASE_IN_L1,2,2) +c4.CODE_DESC2,'&nbsp;') as '權理',"
                Sql &= " base_ptb as '俸點',"
                Sql &= " d0.PAYOD_AMT as '俸額',"
                Sql &= " d2.PAYOD_AMT as '專業加給',"
                Sql &= " d4.PAYOD_AMT as '主管加給',"
                Sql &= " isnull(d3.PAYOD_AMT,0) as '協查研究費',"
                Sql &= " 0 as '調整待遇-俸額',"
                Sql &= " 0 as '調整待遇-專業加給',"
                Sql &= " 0 as '調整待遇-主管加給',"
                Sql &= " 0 as '實物代金',"
                Sql &= " 0 as '交通費',"
                Sql &= " d5.PAYOD_AMT as '應發數',"
                Sql &= " isnull(m.MEMO_DESCRIPTION,'&nbsp;') as '備註'"
                Sql &= " from sal_sabase a"
                'd0薪給總額
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='001' ) d0 on a.base_Seqno=d0.PAYOD_SEQNO and BASE_ORGID=d0.PAYOD_ORGID"
                'd2工作補助費
                Sql &= " inner join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='003' ) d2 on a.base_Seqno=d2.PAYOD_SEQNO and BASE_ORGID=d2.PAYOD_ORGID"
                'd3協查研究費
                Sql &= " left outer join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='006' and PAYOD_CODE=@v_other_code ) d3 on a.base_Seqno=d3.PAYOD_SEQNO and BASE_ORGID=d3.PAYOD_ORGID"
                'd4主管加給
                Sql &= " inner join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P' and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='004' ) d4 on a.base_Seqno=d4.PAYOD_SEQNO and BASE_ORGID=d4.PAYOD_ORGID"
                'd5應發合計
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='003' and PAYOD_CODE_NO='001' ) d5 on a.base_Seqno=d5.PAYOD_SEQNO and BASE_ORGID=d5.PAYOD_ORGID"
                '職稱
                Sql &= " inner  join sys_code c1 on c1.CODE_SYS='002' and c1.CODE_KIND='P' and c1.CODE_TYPE='002' and c1.CODE_NO=BASE_DCODE"
                '俸階
                Sql &= " inner  join sys_code c3 on c3.CODE_SYS='002' and c3.CODE_KIND='P' and c3.CODE_TYPE='009' and c3.CODE_NO=BASE_ORG_L2"
                '權理職等
                Sql &= " left outer  join sys_code c4 on c4.CODE_SYS='002' and c4.CODE_KIND='P' and c4.CODE_TYPE='006' and c4.CODE_NO=BASE_IN_L1"
                '備註
                Sql &= " left outer join (select MEMO_DESCRIPTION,MEMO_ORGID,MEMO_SEQNO from SAL_SAMEMO where MEMO_YM=@v_pay_ym and MEMO_KIND=@v_PAYO_KIND) m on a.BASE_ORGID=m.MEMO_ORGID and a.base_Seqno=m.MEMO_SEQNO"
            ElseIf "004".Equals(v_base_prono) Then '約聘僱人員
                Sql &= " select  c1.CODE_DESC1 as '職稱',base_name as '姓名',"
                Sql &= " base_ptb as '實支薪點',"
                Sql &= " d0.PAYOD_AMT as '薪資',"
                Sql &= " 0 as '調整待遇數',"
                Sql &= " isnull(d3.PAYOD_AMT,0) as '協查研究費',"
                Sql &= " 0 as '交通費',"
                Sql &= " d5.PAYOD_AMT as '應發數',"
                Sql &= " isnull(m.MEMO_DESCRIPTION,'&nbsp;') as '備註'"
                Sql &= " from sal_sabase a"
                'd0薪給總額
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='001' ) d0 on a.base_Seqno=d0.PAYOD_SEQNO and BASE_ORGID=d0.PAYOD_ORGID"
                'd3協查研究費
                Sql &= " left outer join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='006' and PAYOD_CODE=@v_other_code ) d3 on a.base_Seqno=d3.PAYOD_SEQNO and BASE_ORGID=d3.PAYOD_ORGID"
                'd5應發合計
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='003' and PAYOD_CODE_NO='001' ) d5 on a.base_Seqno=d5.PAYOD_SEQNO and BASE_ORGID=d5.PAYOD_ORGID"
                '職稱
                Sql &= " inner  join sys_code c1 on c1.CODE_SYS='002' and c1.CODE_KIND='P' and c1.CODE_TYPE='002' and c1.CODE_NO=BASE_DCODE"
                '備註
                Sql &= " left outer join (select MEMO_DESCRIPTION,MEMO_ORGID,MEMO_SEQNO from SAL_SAMEMO where MEMO_YM=@v_pay_ym and MEMO_KIND=@v_PAYO_KIND) m on BASE_ORGID=m.MEMO_ORGID and base_Seqno=m.MEMO_SEQNO"
            ElseIf "005".Equals(v_base_prono) Then '駐衛警察
                Sql &= " select  c1.CODE_DESC1 as '職別',base_name as '姓名',"
                Sql &= " base_ptb as '薪點',"
                Sql &= " d0.PAYOD_AMT as '薪俸',"
                Sql &= " d2.PAYOD_AMT as '專業加給',"
                Sql &= " d4.PAYOD_AMT as '主管加給',"
                Sql &= " isnull(d3.PAYOD_AMT,0) as '勤務補助費',"
                Sql &= " 0 as '調整待遇-薪俸',"
                Sql &= " 0 as '調整待遇-專業加給',"
                Sql &= " 0 as '調整待遇-主管加給',"
                Sql &= " 0 as '交通費',"
                Sql &= " d5.PAYOD_AMT as '應發數',"
                Sql &= " isnull(m.MEMO_DESCRIPTION,'&nbsp;') as '備註'"
                Sql &= " from sal_sabase a"
                'd0薪給總額
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='001' ) d0 on a.base_Seqno=d0.PAYOD_SEQNO and BASE_ORGID=d0.PAYOD_ORGID"
                'd2工作補助費
                Sql &= " inner join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='003' ) d2 on a.base_Seqno=d2.PAYOD_SEQNO and BASE_ORGID=d2.PAYOD_ORGID"
                'd3協查研究費
                Sql &= " left outer join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='006' and PAYOD_CODE=@v_other_code ) d3 on a.base_Seqno=d3.PAYOD_SEQNO and BASE_ORGID=d3.PAYOD_ORGID"
                '主管加給
                Sql &= " inner join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P' and PAYOD_CODE_TYPE='001' and PAYOD_CODE_NO='004' ) d4 on a.base_Seqno=d4.PAYOD_SEQNO and BASE_ORGID=d4.PAYOD_ORGID"
                'd5應發合計
                Sql &= " inner  join (select PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date from sal_SAPAYOD where PAYOD_YM=@v_pay_ym and  PAYOD_KIND=@v_PAYO_KIND and PAYOD_CODE_SYS='003' and PAYOD_CODE_KIND='P'  and PAYOD_CODE_TYPE='003' and PAYOD_CODE_NO='001' ) d5 on a.base_Seqno=d5.PAYOD_SEQNO and BASE_ORGID=d5.PAYOD_ORGID"
                '職稱
                Sql &= " inner  join sys_code c1 on c1.CODE_SYS='002' and c1.CODE_KIND='P' and c1.CODE_TYPE='002' and c1.CODE_NO=BASE_DCODE"
                '備註
                Sql &= " left outer join (select MEMO_DESCRIPTION,MEMO_ORGID,MEMO_SEQNO from SAL_SAMEMO where MEMO_YM=@v_pay_ym and MEMO_KIND=@v_PAYO_KIND) m on BASE_ORGID=m.MEMO_ORGID and base_Seqno=m.MEMO_SEQNO"
            End If

            Sql &= " where BASE_PRONO=@v_PRONO and"
            Sql &= " ((base_bdate <=  @v_pay_ym+@v_curr_last_dayS )  and  "
            Sql &= " (left(base_edate,6) >=  @v_pay_ym  or  isnull(BASE_EDATE,'')  =  ''  )   and  base_status  =  'Y') "
            Sql &= "  and not((BASE_QUIT_REZN = '001') and (BASE_QUIT_DATE <> '') and (left(BASE_QUIT_DATE,6) < @v_pay_ym))"
            Sql &= " order by a.BASE_PRTS"


            Using ta As New DB_TableAdapters.DB_TableAdapter
                Using t As DataTable = ta.spExeSQLGetDataTable(Sql)
                    Return t
                End Using
            End Using
        End Function


    End Class
End Namespace

