Imports System.Data
Imports System.Transactions
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports CommonLib

Partial Class SAL_SAL2_SAL2110_02
    Inherits BaseWebForm

    Dim v_startYYMM, v_base_prono As String '查詢條件起迄時間
    Dim show_MM As String '顯示的月份
    Dim v_year, v_month, v_day As String '印表時間(年月日)
    Dim Sql As String '用到的sql語法
    Dim v_content, v_Report_Title, v_head As String '表單內文
    Dim pagelineHeight As Integer = 800 + 15    ' 每頁資料行高800(25筆資料 for A3)
    Dim lineHeight As Integer = 0    ' 目前資料行高
    Dim pageCount, totalCnt, totalAmt1, totalAmt2, totalAmt3, totalAmt4, totalAmt5, totalAmt6, totalAmt7, totalAmt8, totalAmt9, totalAmt10 As Integer '總人數及總計金額

    '============== 變數區 end===============

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '承接前一頁面Nreport_f020傳來的變數
        v_startYYMM = Request("startYYMM") '年yyyymm
        v_base_prono = Request("base_prono")

        show_MM = IIf(v_startYYMM.Substring(4, 2).StartsWith("0"), v_startYYMM.Substring(5, 1), v_startYYMM.Substring(4, 2))
        v_year = DateTime.Now.Year - 1911 '現在民國年
        v_month = DateTime.Now.Month '現在月份
        v_day = DateTime.Now.Day '現在日期

        Me.start()
    End Sub

    Protected Sub start()
        '內文
        Sql &= "DECLARE @v_pay_ym VARCHAR(6);SET @v_pay_ym='" & v_startYYMM & "'"  '（發放工餉年月）
        Sql &= "DECLARE @v_PRONO VARCHAR(3);SET @v_PRONO='" & v_base_prono & "'" '（人員類別）
        Sql &= "DECLARE @v_PAYO_KIND varchar(3);SET @v_PAYO_KIND='001'" '（計算類型：工餉）
        Sql &= "DECLARE @v_other_code varchar(3);SET @v_other_code='023'" '(協查研究費)
        Sql &= "DECLARE @v_curr_last_day decimal(5,1);SET @v_curr_last_day=dbo.Last_day(@v_pay_ym) "
        Sql &= "DECLARE @v_curr_last_dayS varchar(10);SET @v_curr_last_dayS=ltrim(str(@v_curr_last_day))"

        If "1".Equals(v_base_prono) Then '政務人員
            Sql &= " SELECT "
            Sql &= " c1.CODE_DESC1 AS '職稱',"
            Sql &= " base_name AS '姓名',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '月俸',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') AS '公費',"
            Sql &= " ISNULL(d3.PAYOD_AMT,0) AS '調查研究費',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'0') - dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '調整待遇-月俸',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'0') - dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') AS '調整待遇-公費',"
            Sql &= " 0 AS '實物代金',"
            Sql &= " 0 AS '交通費',"
            Sql &= " d5.PAYOD_AMT AS '應發數',"
            Sql &= " ISNULL(m.MEMO_DESCRIPTION,'&nbsp;') AS '備註'"
            Sql &= " FROM SAL_SABASE a "

            'd3協查研究費
            SQL_d3()

            'd5應發合計
            SQL_d5()

            '職稱
            SQL_01()

            '俸階
            SQL_02()

            '備註
            SQL_04()

        ElseIf "2".Equals(v_base_prono) Or "3".Equals(v_base_prono) Then '一般行政人員  監察調查人員
            Sql &= " SELECT "
            Sql &= " c1.CODE_DESC1 AS '職稱',"
            Sql &= " base_name AS '姓名',"
            Sql &= " SUBSTRING(BASE_ORG_L1,2,2)+c3.CODE_DESC2 AS '職級',"
            Sql &= " ISNULL(SUBSTRING(BASE_IN_L1,2,2) +c4.CODE_DESC2,'&nbsp;') AS '權理',"
            Sql &= " base_ptb AS '俸點',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '俸額',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') AS '專業加給',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('004' ,base_kdc,base_kdc_series,@v_pay_ym,'1') AS '主管加給',"
            Sql &= " ISNULL(d3.PAYOD_AMT,0) as '協查研究費',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'0') - dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '調整待遇-俸額',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'0') - dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') AS '調整待遇-專業加給',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('004' ,base_kdc,base_kdc_series,@v_pay_ym,'0') - dbo.get_kdc_kdp_kdo_up('004' ,base_kdc,base_kdc_series,@v_pay_ym,'1') AS '調整待遇-主管加給',"
            Sql &= " 0 AS '實物代金',"
            Sql &= " 0 AS '交通費',"
            Sql &= " d5.PAYOD_AMT AS '應發數',"
            Sql &= " ISNULL(m.MEMO_DESCRIPTION,'&nbsp;') AS '備註'"
            Sql &= " FROM SAL_SABASE a "

            'd3協查研究費
            SQL_d3()

            'd5應發合計
            SQL_d5()

            '職稱
            SQL_01()

            '俸階
            SQL_02()

            '權理職等
            SQL_03()

            '備註
            SQL_04()

        ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
            Sql &= " SELECT "
            Sql &= " c1.CODE_DESC1 AS '職稱',"
            Sql &= " base_name AS '姓名',"
            Sql &= " base_ptb as '實支薪點',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '薪資',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'0') - dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '調整待遇數',"
            Sql &= " ISNULL(d3.PAYOD_AMT,0) AS '協查研究費',"
            Sql &= " 0 AS '交通費',"
            Sql &= " d5.PAYOD_AMT AS '應發數',"
            Sql &= " ISNULL(m.MEMO_DESCRIPTION,'&nbsp;') AS '備註'"
            Sql &= " FROM SAL_SABASE a "

            'd3協查研究費
            SQL_d3()

            'd5應發合計
            SQL_d5()

            '職稱
            SQL_01()

            '備註
            SQL_04()

        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
            Sql &= " SELECT "
            Sql &= " c1.CODE_DESC1 AS '職稱',"
            Sql &= " base_name AS '姓名',"
            Sql &= " base_ptb AS '薪點',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '薪俸',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') AS '專業加給',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('004' ,base_kdc,base_kdc_series,@v_pay_ym,'1') AS '主管加給',"
            Sql &= " ISNULL(d3.PAYOD_AMT,0) AS '勤務補助費',"
            Sql &= " dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'0') - dbo.get_kdb_UP('001' ,BASE_KDB,BASE_ptb,@v_pay_ym,'1') AS '調整待遇-薪俸',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'0') - dbo.get_kdc_kdp_kdo_up('003' ,base_kdp,base_kdp_series,@v_pay_ym,'1') AS '調整待遇-專業加給',"
            Sql &= " dbo.get_kdc_kdp_kdo_up('004' ,base_kdc,base_kdc_series,@v_pay_ym,'0') - dbo.get_kdc_kdp_kdo_up('004' ,base_kdc,base_kdc_series,@v_pay_ym,'1') AS '調整待遇-主管加給',"
            Sql &= " 0 AS '交通費',"
            Sql &= " d5.PAYOD_AMT AS '應發數',"
            Sql &= " ISNULL(m.MEMO_DESCRIPTION,'&nbsp;') AS '備註'"
            Sql &= " FROM SAL_SABASE a "

            'd3協查研究費
            SQL_d3()

            'd5應發合計
            SQL_d5()

            '職稱
            SQL_01()

            '備註
            SQL_04()

        End If

        Sql &= " WHERE BASE_PRONO=@v_PRONO "
        Sql &= " AND "
        Sql &= " ("
        Sql &= " (base_bdate <= @v_pay_ym+@v_curr_last_dayS ) AND (left(base_edate,6) >= @v_pay_ym OR ISNULL(BASE_EDATE,'')='') AND base_status='Y'"
        Sql &= " ) "
        Sql &= " AND NOT"
        Sql &= " ("
        Sql &= " (BASE_QUIT_REZN='001') AND (BASE_QUIT_DATE <> '') AND (left(BASE_QUIT_DATE,6) < @v_pay_ym)"
        Sql &= " ) "
        Sql &= " ORDER BY a.BASE_PRTS"

        Using ta As New DB_TableAdapters.DB_TableAdapter
            Using t As DB_.DB_DataTable = ta.spExeSQLGetDataTable(Sql)
                totalCnt = t.Rows.Count
                If (totalCnt > 0) Then
                    For j As Int32 = 0 To totalCnt - 1
                        If j = 0 Then
                            PageStart()
                        End If

                        Dim Amt1 As Integer
                        Dim Amt2 As Integer
                        Dim Amt3 As Integer
                        Dim Amt4 As Integer
                        Dim Amt5 As Integer
                        Dim Amt6 As Integer
                        Dim Amt7 As Integer
                        Dim Amt8 As Integer
                        Dim Amt9 As Integer
                        Dim Amt10 As Integer

                        If "1".Equals(v_base_prono) Then '政務人員
                            Amt1 = t.Rows(j)("月俸")
                            Amt2 = t.Rows(j)("公費")
                            Amt3 = t.Rows(j)("調查研究費")
                            Amt4 = t.Rows(j)("調整待遇-月俸")
                            Amt5 = t.Rows(j)("調整待遇-公費")
                            Amt6 = t.Rows(j)("實物代金")
                            Amt7 = t.Rows(j)("交通費")
                            Amt8 = t.Rows(j)("應發數")

                        ElseIf "2".Equals(v_base_prono) Or "3".Equals(v_base_prono) Then '一般行政人員  監察調查人員
                            Amt1 = t.Rows(j)("俸額")
                            Amt2 = t.Rows(j)("專業加給")
                            Amt3 = t.Rows(j)("主管加給")
                            Amt4 = t.Rows(j)("協查研究費")
                            Amt5 = t.Rows(j)("調整待遇-俸額")
                            Amt6 = t.Rows(j)("調整待遇-專業加給")
                            Amt7 = t.Rows(j)("調整待遇-主管加給")
                            Amt8 = t.Rows(j)("實物代金")
                            Amt9 = t.Rows(j)("交通費")
                            Amt10 = t.Rows(j)("應發數")

                        ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
                            Amt1 = t.Rows(j)("薪資")
                            Amt2 = t.Rows(j)("調整待遇數")
                            Amt3 = t.Rows(j)("協查研究費")
                            Amt4 = t.Rows(j)("交通費")
                            Amt5 = t.Rows(j)("應發數")

                        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
                            Amt1 = t.Rows(j)("薪俸")
                            Amt2 = t.Rows(j)("專業加給")
                            Amt3 = t.Rows(j)("主管加給")
                            Amt4 = t.Rows(j)("勤務補助費")
                            Amt5 = t.Rows(j)("調整待遇-薪俸")
                            Amt6 = t.Rows(j)("調整待遇-專業加給")
                            Amt7 = t.Rows(j)("調整待遇-主管加給")
                            Amt8 = t.Rows(j)("交通費")
                            Amt9 = t.Rows(j)("應發數")

                        End If

                        totalAmt1 += Amt1
                        totalAmt2 += Amt2
                        totalAmt3 += Amt3
                        totalAmt4 += Amt4
                        totalAmt5 += Amt5
                        totalAmt6 += Amt6
                        totalAmt7 += Amt7
                        totalAmt8 += Amt8
                        totalAmt9 += Amt9
                        totalAmt10 += Amt10
                        v_content = "<tr>"

                        If "1".Equals(v_base_prono) Then '政務人員
                            v_content &= "<td align=center height=32>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("職稱") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("姓名") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt1) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt2) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt3) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt4) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt5) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt6) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt7) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt8) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=left id='en_newline'>" '設此id是為了讓英數字能滿長換行
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("備註") & "</font>"
                            v_content &= "</td>"

                        ElseIf "2".Equals(v_base_prono) Or "3".Equals(v_base_prono) Then '一般行政人員  監察調查人員
                            v_content &= "<td align=left height=32>"
                            v_content &= "<font face='標楷體' size='3'>&nbsp;" & t.Rows(j)("職稱") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("姓名") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("職級") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("權理") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("俸點") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt1) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt2) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt3) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt4) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt5) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt6) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt7) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt8) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt9) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt10) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=left id='en_newline'>" '設此id是為了讓英數字能滿長換行
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("備註") & "</font>"
                            v_content &= "</td>"

                        ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
                            v_content &= "<td align=left height=32>"
                            v_content &= "<font face='標楷體' size='3'>&nbsp;" & t.Rows(j)("職稱") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("姓名") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("實支薪點") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt1) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt2) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt3) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt4) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt5) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=left id='en_newline'>" '設此id是為了讓英數字能滿長換行
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("備註") & "</font>"
                            v_content &= "</td>"

                        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
                            v_content &= "<td align=center height=32>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("職別") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("姓名") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=center>"
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("薪點") & "</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt1) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt2) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt3) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt4) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt5) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt6) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt7) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt8) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=right>"
                            v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(Amt9) & "&nbsp;</font>"
                            v_content &= "</td>"
                            v_content &= "<td align=left id='en_newline'>" '設此id是為了讓英數字能滿長換行
                            v_content &= "<font face='標楷體' size='3'>" & t.Rows(j)("備註") & "</font>"
                            v_content &= "</td>"

                        End If

                        v_content &= "</tr>"

                        Dim dataHeight As Double = 0 '行高
                        Dim RemarkBits As Int32 = System.Text.Encoding.Default.GetBytes(t.Rows(j)("備註")).Length() '判斷備註的位元長度(中文兩位元 英數字一位元)
                        If "1".Equals(v_base_prono) Or "2".Equals(v_base_prono) Or "3".Equals(v_base_prono) Then '政務人員 一般行政人員 監察調查人員
                            If RemarkBits <= 16 Then '一行能容納8個中文字或16個半形英數字
                                dataHeight = 32 '若備註只有一行則行高設為32
                            Else
                                If RemarkBits Mod 16 = 0 Then
                                    dataHeight = (RemarkBits \ 16) * 18.85  '1行平均行高是18.85
                                Else
                                    dataHeight = (RemarkBits \ 16 + 1) * 18.85  '1行平均行高是18.85
                                End If
                            End If
                        ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
                            If RemarkBits <= 26 Then '一行能容納13個中文字或26個半形英數字
                                dataHeight = 32 '若備註只有一行則行高設為32
                            Else
                                If RemarkBits Mod 26 = 0 Then
                                    dataHeight = (RemarkBits \ 26) * 18.85  '1行平均行高是18.85
                                Else
                                    dataHeight = (RemarkBits \ 26 + 1) * 18.85  '1行平均行高是18.85
                                End If
                            End If
                        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
                            If RemarkBits <= 24 Then '一行能容納12個中文字或24個半形英數字
                                dataHeight = 32 '若備註只有一行則行高設為32
                            Else
                                If RemarkBits Mod 24 = 0 Then
                                    dataHeight = (RemarkBits \ 24) * 18.85  '1行平均行高是18.85
                                Else
                                    dataHeight = (RemarkBits \ 24 + 1) * 18.85  '1行平均行高是18.85
                                End If
                            End If
                        End If

                        lineHeight += dataHeight '表身資料高度
                        If lineHeight >= pagelineHeight Then
                            lineHeight = dataHeight
                            Me.Literal1.Text += "</table>"
                            PageSeprator() '加上分頁符號
                            PageStart()
                            Me.Literal1.Text += v_content
                        Else
                            Me.Literal1.Text += v_content
                        End If
                    Next

                    For i As Int32 = 0 To (pagelineHeight - lineHeight) / 32 - 1
                        v_content = "<tr>"
                        For k As Int32 = 0 To 8
                            v_content &= "<td align=left height=32>"
                            v_content &= "<font size='3'>&nbsp;</font>"
                            v_content &= "</td>"
                        Next

                        If "1".Equals(v_base_prono) Then '政務人員
                            commonString()
                            commonString()
                        ElseIf "2".Equals(v_base_prono) Or "003".Equals(v_base_prono) Then '一般行政人員 監察調查人員
                            commonString()
                            commonString()
                            commonString()
                            commonString()
                            commonString()
                            commonString()
                            commonString()
                        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
                            commonString()
                            commonString()
                            commonString()
                            commonString()
                        End If

                        v_content &= "</tr>"
                        Me.Literal1.Text += v_content
                    Next

                    v_content = "<tr>"
                    v_content &= "<td align=center height=32>"
                    v_content &= "<font face='標楷體' size='3'>總計</font>"
                    v_content &= "</td>"
                    v_content &= "<td align=center>"
                    v_content &= "<font face='標楷體' size='3'>" & totalCnt & "</font><font face='標楷體' size='3'>人</font>"
                    v_content &= "</td>"

                    If "1".Equals(v_base_prono) Then '政務人員
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt1) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt2) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt3) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt4) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt5) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt6) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt7) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt8) & "&nbsp;</font>"
                        v_content &= "</td>"
                        commonString()

                    ElseIf "2".Equals(v_base_prono) Or "003".Equals(v_base_prono) Then '一般行政人員 監察調查人員
                        commonString()
                        commonString()
                        commonString()
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt1) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt2) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt3) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt4) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt5) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt6) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt7) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt8) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt9) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt10) & "&nbsp;</font>"
                        v_content &= "</td>"
                        commonString()

                    ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
                        commonString()
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt1) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt2) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt3) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt4) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt5) & "&nbsp;</font>"
                        v_content &= "</td>"
                        commonString()

                    ElseIf "5".Equals(v_base_prono) Then '駐衛警察
                        commonString()
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt1) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt2) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt3) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt4) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt5) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt6) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt7) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt8) & "&nbsp;</font>"
                        v_content &= "</td>"
                        v_content &= "<td align=right>"
                        v_content &= "<font face='標楷體' size='3'>" & pub.NumberFommat(totalAmt9) & "&nbsp;</font>"
                        v_content &= "</td>"
                        commonString()

                    End If

                    v_content &= "</tr>"
                    Me.Literal1.Text += v_content
                    Me.Literal1.Text += "</table>"
                Else
                    ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "alert('查無資料');window.close(); void(0);", True)
                End If

            End Using
        End Using

    End Sub

    Protected Sub PageStart()
        pageCount += 1 '頁數加1
        v_Report_Title = "<style type='text/css'>"
        v_Report_Title &= " #en_newline{word-break:break-all;}"
        v_Report_Title &= "</style>"
        v_Report_Title &= "<table width=100% border='0' cellspacing='0' cellpadding='0'>"
        v_Report_Title &= "<tr>"
        v_Report_Title &= "<td width='20%' align=center></td>"
        v_Report_Title &= "<td width='60%' align=center>"
        If "1".Equals(v_base_prono) Then '政務人員
            v_Report_Title &= "<font face='標楷體' size='5'>監察院" & v_startYYMM.Substring(0, 4) - 1911 & "年" & show_MM & "月份各項調整薪差發放清冊</font>"
        ElseIf "2".Equals(v_base_prono) Then '一般行政人員
            v_Report_Title &= "<font face='標楷體' size='5'>監察院" & v_startYYMM.Substring(0, 4) - 1911 & "年" & show_MM & "月份各項調整薪差發放清冊</font>"
        ElseIf "3".Equals(v_base_prono) Then '監察調查人員
            v_Report_Title &= "<font face='標楷體' size='5'>監察院" & v_startYYMM.Substring(0, 4) - 1911 & "年" & show_MM & "月份各項調整薪差發放清冊</font>"
        ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
            v_Report_Title &= "<font face='標楷體' size='5'>監察院" & v_startYYMM.Substring(0, 4) - 1911 & "年" & show_MM & "月份各項調整薪差發放清冊</font>"
        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
            v_Report_Title &= "<font face='標楷體' size='5'>監察院" & v_startYYMM.Substring(0, 4) - 1911 & "年" & show_MM & "月份各項調整薪差發放清冊</font>"
        End If
        v_Report_Title &= "</td>"
        v_Report_Title &= "<td width='10%' align=center>"
        v_Report_Title &= "<font face='標楷體' size='2'>第" & pageCount & "頁</font>"
        v_Report_Title &= "</td>"
        v_Report_Title &= "<td width='10%' align=center>"
        v_Report_Title &= "<font face='標楷體' size='2'>" & v_year & "/" & v_month & "/" & v_day & "</font>"
        v_Report_Title &= "</td>"
        v_Report_Title &= "</tr>"
        v_Report_Title &= "</table>"
        v_head = "<table width=100% border='1' cellspacing='0' cellpadding='0'>"
        If "1".Equals(v_base_prono) Then '政務人員
            v_head &= "<tr>"
            v_head &= "<td rowspan=2 align=center width='8%'>"
            v_head &= "<font face='標楷體' size='3'>" & "職稱" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='8%'>"
            v_head &= "<font face='標楷體' size='3'>" & "姓名" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=3 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "原支數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=2 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "調整待遇數" & "</font>"
            v_head &= "</td>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='8.9%'>"
            v_head &= "<font face='標楷體' size='3'>" & "實物代金" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='8.9%'>"
            v_head &= "<font face='標楷體' size='3'>" & "交通費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='8.9%'>"
            v_head &= "<font face='標楷體' size='3'>" & "應發數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='9.3%'>"
            v_head &= "<font face='標楷體' size='3'>" & "備註" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"

            v_head &= "<tr>"
            v_head &= "<td align=center width='8%'>"
            v_head &= "<font face='標楷體' size='3'>" & "月俸" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='8%'>"
            v_head &= "<font face='標楷體' size='3'>" & "公費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='8%'>"
            v_head &= "<font face='標楷體' size='3'>" & "調查研究費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='12%'>"
            v_head &= "<font face='標楷體' size='3'>" & "月俸" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='12%'>"
            v_head &= "<font face='標楷體' size='3'>" & "公費" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"
        ElseIf "2".Equals(v_base_prono) Or "3".Equals(v_base_prono) Then '一般行政人員 監察調查人員
            v_head &= "<tr>"
            v_head &= "<td rowspan=2 align=center width='9.4%'>"
            v_head &= "<font face='標楷體' size='3'>" & "職稱" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='6.7%'>"
            v_head &= "<font face='標楷體' size='3'>" & "姓名" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=3 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "等級" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=4 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "原支數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=3 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "調整待遇數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "實物代金" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "交通費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='6.8%'>"
            v_head &= "<font face='標楷體' size='3'>" & "應發數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='9.2%'>"
            v_head &= "<font face='標楷體' size='3'>" & "備註" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"

            v_head &= "<tr>"
            v_head &= "<td align=center width='8.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "職級" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "權理" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='3.4%'>"
            v_head &= "<font face='標楷體' size='3'>" & "俸點" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "俸額" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "專業加給" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "主管加給" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='7.6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "協查研究費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "俸額" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "專業加給" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "主管加給" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"
        ElseIf "4".Equals(v_base_prono) Then '約聘僱人員
            v_head &= "<tr>"
            v_head &= "<td align=center width='15%'>"
            v_head &= "<font face='標楷體' size='3'>" & "職稱" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "姓名" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "實支薪點" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "薪資" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "調整待遇數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "協查研究費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "交通費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='10%'>"
            v_head &= "<font face='標楷體' size='3'>" & "應發數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='15%'>"
            v_head &= "<font face='標楷體' size='3'>" & "備註" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"
        ElseIf "5".Equals(v_base_prono) Then '駐衛警察
            v_head &= "<tr>"
            v_head &= "<td rowspan=2 align=center width='6.6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "職別" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='6.6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "姓名" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='6.6%'>"
            v_head &= "<font face='標楷體' size='3'>" & "薪點" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=4 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "工餉" & "</font>"
            v_head &= "</td>"
            v_head &= "<td colspan=3 align=center>"
            v_head &= "<font face='標楷體' size='3'>" & "調整待遇" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "交通費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='14%'>"
            v_head &= "<font face='標楷體' size='3'>" & "應發數" & "</font>"
            v_head &= "</td>"
            v_head &= "<td rowspan=2 align=center width='13.7%'>"
            v_head &= "<font face='標楷體' size='3'>" & "備註" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"

            v_head &= "<tr>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "薪俸" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "專業加給" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "主管加給" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "勤務補助費" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "薪俸" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "專業加給" & "</font>"
            v_head &= "</td>"
            v_head &= "<td align=center width='6.5%'>"
            v_head &= "<font face='標楷體' size='3'>" & "主管加給" & "</font>"
            v_head &= "</td>"
            v_head &= "</tr>"
        End If

        Me.Literal1.Text += v_Report_Title & v_head
    End Sub

    Protected Sub PageSeprator()
        Me.Literal1.Text += "<p style='page-break-before:always'>"
    End Sub

    ''' <summary>
    ''' d3協查研究費
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SQL_d3()
        Sql &= " LEFT OUTER JOIN "
        Sql &= " ("
        Sql &= " SELECT PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date "
        Sql &= " FROM SAL_SAPAYOD"
        Sql &= " WHERE PAYOD_YM=@v_pay_ym AND PAYOD_KIND=@v_PAYO_KIND AND PAYOD_CODE_SYS='003' AND PAYOD_CODE_KIND='P' AND PAYOD_CODE_TYPE='001' AND PAYOD_CODE_NO='006' AND PAYOD_CODE=@v_other_code "
        Sql &= " ) d3 "
        Sql &= " ON a.base_Seqno=d3.PAYOD_SEQNO AND BASE_ORGID=d3.PAYOD_ORGID"
    End Sub

    ''' <summary>
    ''' d5應發合計
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SQL_d5()
        Sql &= " INNER Join"
        Sql &= " ("
        Sql &= " SELECT PAYOD_AMT,PAYOD_SEQNO,PAYOD_ORGID,PAYOD_YM,PAYOD_Date "
        Sql &= " FROM SAL_SAPAYOD"
        Sql &= " WHERE PAYOD_YM=@v_pay_ym AND PAYOD_KIND=@v_PAYO_KIND AND PAYOD_CODE_SYS='003' AND PAYOD_CODE_KIND='P' AND PAYOD_CODE_TYPE='003' AND PAYOD_CODE_NO='001' "
        Sql &= " ) d5 "
        Sql &= " ON a.base_Seqno=d5.PAYOD_SEQNO AND BASE_ORGID=d5.PAYOD_ORGID "
    End Sub

    ''' <summary>
    ''' 職稱
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SQL_01()
        Sql &= " INNER JOIN SYS_CODE c1 "
        Sql &= " ON c1.CODE_SYS='002' AND c1.CODE_KIND='P' AND c1.CODE_TYPE='002' AND c1.CODE_NO=BASE_DCODE "
    End Sub

    ''' <summary>
    ''' 俸階
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SQL_02()
        Sql &= " INNER JOIN SYS_CODE c3 "
        Sql &= " ON c3.CODE_SYS='002' AND c3.CODE_KIND='P' AND c3.CODE_TYPE='009' AND c3.CODE_NO=BASE_ORG_L2 "
    End Sub

    ''' <summary>
    ''' 權理職等
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SQL_03()
        Sql &= " LEFT OUTER JOIN SYS_CODE c4 "
        Sql &= " ON c4.CODE_SYS='002' AND c4.CODE_KIND='P' AND c4.CODE_TYPE='006' AND c4.CODE_NO=BASE_IN_L1 "
    End Sub

    ''' <summary>
    ''' 備註
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub SQL_04()
        Sql &= " LEFT OUTER JOIN "
        Sql &= " ("
        Sql &= " SELECT MEMO_DESCRIPTION,MEMO_ORGID,MEMO_SEQNO "
        Sql &= " FROM SAL_SAMEMO"
        Sql &= " WHERE MEMO_YM=@v_pay_ym AND MEMO_KIND=@v_PAYO_KIND"
        Sql &= " ) m "
        Sql &= " ON BASE_ORGID=m.MEMO_ORGID AND base_Seqno=m.MEMO_SEQNO "
    End Sub

    ''' <summary>
    ''' 共用文字
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub commonString()
        v_content &= "<td align=left><font size='3'>&nbsp;</font></td>"
    End Sub
End Class
