Imports SALARY.Logic
Imports System.Data

Partial Class SAL3124_01
    Inherits BaseWebForm
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            For i As Integer = 103 To Now.Year - 1911
                DropDownList_year.Items.Add(i.ToString())
            Next
            DropDownList_month.SelectedIndex = Format(Now(), "MM") - 1 ' 設定現在月份 
            ' txtEmail.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Email)
            Dim v_UserId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            Using t As DataTable = New SAL3124().getEmail(v_UserId)
                Dim rs As DataRow = t.Rows(0)
                txtEmail.Text = rs("EMAIL").ToString
            End Using
        End If
    End Sub

    Protected Sub btnGen_Click(sender As Object, e As EventArgs) Handles btnGen.Click
        Media_Generate()
        ExportFile()
    End Sub

#Region "CreateMedia"

    Protected Sub Media_Generate()

        Dim v_UserId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim v_UserOrgId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Dim roc_ym As String = DropDownList_year.SelectedValue & DropDownList_month.SelectedValue

        Dim v_no As String = ""

        Dim v_unit_tax As String = ""
        Dim v_unit_hname As String = ""
        Dim v_unit_cname As String = ""
        Dim v_unit_tel As String = ""

        Using t As DataTable = New SAL3124().getUnit(v_UserOrgId)
            Dim rs As DataRow = t.Rows(0)
            v_unit_tax = pub.lpad(rs("unit_tax").ToString, 8, "0")
            v_unit_hname = pub.rpad(StrConv(Trim(rs("unit_hname").ToString), VbStrConv.Wide), 25, "　")
            v_unit_cname = pub.rpad(StrConv(Trim(rs("unit_cname").ToString), VbStrConv.Wide), 25, "　")
            v_unit_tel = pub.rpad(rs("unit_tel").ToString, 15, " ")
        End Using

        Dim v_date As String = pub.Nowdate
        Dim roc_date As String = pub.show_trn_date(v_date)
        Dim Filename As String = ""
        If (DropDownList_month.SelectedValue <> "") Then
            Filename = "DPR" & v_unit_tax & roc_date & pub.lpad(((DropDownList_year.SelectedValue - 1911).ToString() & DropDownList_month.SelectedValue).Substring(4, 2), 3, "0")
        Else
            Filename = "DPR" & v_unit_tax & roc_date & pub.lpad(((DropDownList_year.SelectedValue - 1911).ToString()), 3, "0")
        End If
        ''Dim Filename As String = "DPR" & v_unit_tax & roc_date & 
        ''    pub.lpad(((DropDownList_year.SelectedValue - 1911).ToString() & 
        ''              DropDownList_month.SelectedValue).Substring(4, 2), 3, "0")
        labelFilename.Text = Filename
        '' DPR + 統編(8) + 申報日期(7)


        '' 寫入媒體檔案開始


        '' 資料筆數
        Dim count62 As Integer = 0
        Dim count63 As Integer = 0
        Dim count65 As Integer = 0
        Dim count67 As Integer = 0
        Dim count68 As Integer = 0

        '' 所得總額
        Dim sum_inco_amt62 As Integer = 0
        Dim sum_inco_amt63 As Integer = 0
        Dim sum_inco_amt65 As Integer = 0
        Dim sum_inco_amt67 As Integer = 0
        Dim sum_inco_amt68 As Integer = 0

        '' 扣繳補充保費總額
        Dim sum_inco_ext62 As Integer = 0
        Dim sum_inco_ext63 As Integer = 0
        Dim sum_inco_ext65 As Integer = 0
        Dim sum_inco_ext67 As Integer = 0
        Dim sum_inco_ext68 As Integer = 0

        Dim file_header62 As String = ""
        Dim file_header63 As String = ""
        Dim file_header65 As String = ""
        Dim file_header67 As String = ""
        Dim file_header68 As String = ""

        Dim file_content62 As String = ""
        Dim file_content63 As String = ""
        Dim file_content65 As String = ""
        Dim file_content67 As String = ""
        Dim file_content68 As String = ""

        Dim file_tot62 As String = ""
        Dim file_tot63 As String = ""
        Dim file_tot65 As String = ""
        Dim file_tot67 As String = ""
        Dim file_tot68 As String = ""

        '' 以下為申報單位資料
        ''  ================       首行      ================
        '' 資料識別碼(1-1)    首行寫 1      
        file_header62 &= "1"
        file_header63 &= "1"
        file_header65 &= "1"
        file_header67 &= "1"
        file_header68 &= "1"

        '' 申報單位統一編號(2-9)
        file_header62 &= v_unit_tax
        file_header63 &= v_unit_tax
        file_header65 &= v_unit_tax
        file_header67 &= v_unit_tax
        file_header68 &= v_unit_tax

        '' 所得類別(10-11)
        file_header62 &= "62"
        file_header63 &= "63"
        file_header65 &= "65"
        file_header67 &= "67"
        file_header68 &= "68"

        '' 所得給付起始年月(12-16)
        file_header62 &= roc_ym
        file_header63 &= roc_ym
        file_header65 &= roc_ym
        file_header67 &= roc_ym
        file_header68 &= roc_ym

        '' 所得給付結束年月(17-21)
        file_header62 &= roc_ym
        file_header63 &= roc_ym
        file_header65 &= roc_ym
        file_header67 &= roc_ym
        file_header68 &= roc_ym

        '' 檔案製作日期(22-28
        file_header62 &= roc_date
        file_header63 &= roc_date
        file_header65 &= roc_date
        file_header67 &= roc_date
        file_header68 &= roc_date

        '' 總機構統一編號(29-36) 沒有總機構, 填空白
        file_header62 &= pub.rpad("", 8, " ")
        file_header63 &= pub.rpad("", 8, " ")
        file_header65 &= pub.rpad("", 8, " ")
        file_header67 &= pub.rpad("", 8, " ")
        file_header68 &= pub.rpad("", 8, " ")

        '' 申報單位電子信箱(37-66)
        file_header62 &= pub.rpad(txtEmail.Text.Trim, 30, " ")
        file_header63 &= pub.rpad(txtEmail.Text.Trim, 30, " ")
        file_header65 &= pub.rpad(txtEmail.Text.Trim, 30, " ")
        file_header67 &= pub.rpad(txtEmail.Text.Trim, 30, " ")
        file_header68 &= pub.rpad(txtEmail.Text.Trim, 30, " ")

        '' 扣費義務人名稱(67-116) 全型25個字
        file_header62 &= v_unit_hname
        file_header63 &= v_unit_hname
        file_header65 &= v_unit_hname
        file_header67 &= v_unit_hname
        file_header68 &= v_unit_hname

        '' 保留欄位(117-200) 空白
        file_header62 &= pub.rpad("", 84, " ")
        file_header63 &= pub.rpad("", 84, " ")
        file_header65 &= pub.rpad("", 84, " ")
        file_header67 &= pub.rpad("", 84, " ")
        file_header68 &= pub.rpad("", 84, " ")


        '' 取得機關基本資料

        Using ta As New DB_TableAdapters.DB_TableAdapter
            Dim v_ym As String = (DropDownList_year.SelectedValue + 1911).ToString & DropDownList_month.SelectedValue
            Dim bll As New SAL3124
            ''以下為扣費明細資料
            Using r62 As DataTable = bll.getinco62(v_UserOrgId, v_ym)
                For Each rs62 As DataRow In r62.Rows
                    If count62 > 0 Then
                        file_content62 &= Chr(13) & Chr(10)
                    End If
                    '' 資料筆數
                    count62 += 1

                    '所得(收入)給付金額
                    Dim data_amt As String = rs62("inco_amt").ToString
                    '扣繳補充保費金額
                    Dim data_ext As String = rs62("inco_health_ext").ToString
                    '同年度累計獎金金額
                    Dim data_sum As String = rs62("inco_sum").ToString
                    '所得給付日期
                    Dim data_date As String = pub.show_trn_date(rs62("inco_date").ToString)
                    '所得人身分證號
                    Dim data_idno As String = pub.rpad(rs62("base_idno").ToString, 10, " ")
                    '所得人姓名
                    Dim data_name As String = pub.rpad(StrConv(Trim(rs62("base_name").ToString), VbStrConv.Wide), 25, "　")
                    '投保單位代號
                    Dim data_code As String = pub.rpad(v_unit_tax, 9, " ")
                    '' 申報編號(39-68) 30碼 
                    '' 固定寫(inco_prikey(20) + inco_code(3) + inco_kind_code(3) + 流水號(4))
                    Dim data_prikey As String = pub.lpad(rs62("inco_prikey").ToString, 20, "0")
                    Dim data_kind_code As String = "000"
                    Dim data_kind_code_no As String = "000"
                    '扣費當月投保金額
                    Dim data_series As String = rs62("fins_series").ToString

                    ''  ================        資料行(62)      ================
                    '' 資料識別碼(1-1)    資料行寫 2
                    file_content62 &= "2"

                    '' 申報單位統一編號(2-9)
                    file_content62 &= v_unit_tax

                    '' 所得(收入)類別(10-11)
                    file_content62 &= "62"

                    '' 流水序號(12-20)
                    file_content62 &= pub.lpad(count62.ToString(), 9, "0")

                    '' 處理方式(21-21) I:新增  R:覆蓋,  統一使用R
                    file_content62 &= "R"

                    '' 所得給付日期(22-28)
                    file_content62 &= data_date

                    '' 所得人身分證號(29-38)
                    file_content62 &= data_idno

                    '' 申報編號(39-68) 30碼 
                    '' 固定寫(inco_prikey(20) + inco_code(3) + inco_kind_code(3) + 流水號(4))
                    file_content62 &= data_prikey & data_kind_code & data_kind_code_no & pub.lpad(count62.ToString(), 4, "0")

                    '' 所得(收入)給付金額(69-82)
                    file_content62 &= pub.lpad(CStr(data_amt), 14, "0")

                    '' 扣繳補充保費金額(83-92)
                    file_content62 &= pub.lpad(CStr(data_ext), 10, "0")

                    '' 共用欄位區(93-132)
                    ''     投保單位代號(93-101)
                    file_content62 &= data_code

                    ''     扣費當月投保金額(102-107)
                    file_content62 &= pub.lpad(CStr(data_series), 6, "0")

                    ''     同年度累計獎金金額(108-117)
                    file_content62 &= pub.lpad(CStr(data_sum), 10, "0")

                    ''     保留欄位(118-132)
                    file_content62 &= pub.rpad("", 15, " ")

                    '' 信託註記(133-133) 非信託所得 填寫空白
                    file_content62 &= " "

                    '' 所得人姓名(134-183)
                    file_content62 &= data_name

                    '' 保留欄位(184-200) 空白
                    file_content62 &= pub.rpad("", 17, " ")

                    '' 金額合計
                    sum_inco_amt62 += CInt(data_amt)
                    sum_inco_ext62 += CInt(data_ext)
                Next

            End Using

            Using r63 As DataTable = bll.getinco63(v_UserOrgId, v_ym)
                For Each rs63 As DataRow In r63.Rows
                    If count63 > 0 Then
                        file_content63 &= Chr(13) & Chr(10)
                    End If
                    '' 資料筆數
                    count63 += 1

                    Dim data_amt As String = rs63("inco_amt").ToString
                    Dim data_ext As String = rs63("inco_health_ext").ToString
                    Dim data_date As String = pub.show_trn_date(rs63("inco_date").ToString)
                    Dim data_idno As String = pub.rpad(rs63("base_idno").ToString, 10, " ")
                    Dim data_name As String = pub.rpad(StrConv(Trim(rs63("base_name").ToString), VbStrConv.Wide), 25, "　")
                    Dim data_prikey As String = pub.lpad(rs63("inco_prikey").ToString, 20, "0")
                    Dim data_kind_code As String = "000"
                    Dim data_kind_code_no As String = "000"



                    ''  ================        資料行(63)      ================
                    '' 資料識別碼(1-1)    資料行寫 2
                    file_content63 &= "2"

                    '' 申報單位統一編號(2-9)
                    file_content63 &= v_unit_tax

                    '' 所得(收入)類別(10-11)
                    file_content63 &= "63"

                    '' 流水序號(12-20)
                    file_content63 &= pub.lpad(count63.ToString(), 9, "0")

                    '' 處理方式(21-21) I:新增  R:覆蓋,  統一使用R
                    file_content63 &= "R"

                    '' 所得給付日期(22-28)
                    file_content63 &= data_date

                    '' 所得人身分證號(29-38)
                    file_content63 &= data_idno

                    '' 申報編號(39-68) 30碼 
                    '' 固定寫(inco_prikey(20) + inco_code(3) + inco_kind_code(3) + 流水號(4))
                    file_content63 &= data_prikey & data_kind_code & data_kind_code_no & pub.lpad(count63.ToString(), 4, "0")
                    '' 所得(收入)給付金額(69-82)
                    file_content63 &= pub.lpad(CStr(data_amt), 14, "0")

                    '' 扣繳補充保費金額(83-92)
                    file_content63 &= pub.lpad(CStr(data_ext), 10, "0")

                    '' 共用欄位區(93-132) 空白
                    file_content63 &= pub.rpad("", 40, " ")

                    '' 信託註記(133-133) 非信託所得 填寫空白
                    file_content63 &= " "

                    '' 所得人姓名(134-183)
                    file_content63 &= data_name

                    '' 保留欄位(184-200) 空白
                    file_content63 &= pub.rpad("", 17, " ")

                    '' 金額合計
                    sum_inco_amt63 += CInt(data_amt)
                    sum_inco_ext63 += CInt(data_ext)
                Next

            End Using

            Using r65 As DataTable = bll.getinco65(v_UserOrgId, v_ym)
                For Each rs65 As DataRow In r65.Rows
                    If count65 > 0 Then
                        file_content65 &= Chr(13) & Chr(10)
                    End If
                    '' 資料筆數
                    count65 += 1

                    Dim data_amt As String = rs65("inco_amt").ToString
                    Dim data_ext As String = rs65("inco_health_ext").ToString
                    Dim data_date As String = pub.show_trn_date(rs65("inco_date").ToString)
                    Dim data_idno As String = pub.rpad(rs65("base_idno").ToString, 10, " ")
                    Dim data_name As String = pub.rpad(StrConv(Trim(rs65("base_name").ToString), VbStrConv.Wide), 25, "　")
                    Dim data_prikey As String = pub.lpad(rs65("inco_prikey").ToString, 20, "0")
                    Dim data_kind_code As String = "000"
                    Dim data_kind_code_no As String = "000"


                    ''  ================        資料行(65)      ================
                    '' 資料識別碼(1-1)    資料行寫 2
                    file_content65 &= "2"

                    '' 申報單位統一編號(2-9)
                    file_content65 &= v_unit_tax

                    '' 所得(收入)類別(10-11)
                    file_content65 &= "65"

                    '' 流水序號(12-20)
                    file_content65 &= pub.lpad(count65.ToString(), 9, "0")

                    '' 處理方式(21-21) I:新增  R:覆蓋,  統一使用R
                    file_content65 &= "R"

                    '' 所得給付日期(22-28)
                    file_content65 &= data_date

                    '' 所得人身分證號(29-38)
                    file_content65 &= data_idno

                    '' 申報編號(39-68) 30碼 
                    '' 固定寫(inco_prikey(20) + inco_code(3) + inco_kind_code(3) + 流水號(4))
                    file_content65 &= data_prikey & data_kind_code & data_kind_code_no & pub.lpad(count65.ToString(), 4, "0")
                    '' 所得(收入)給付金額(69-82)
                    file_content65 &= pub.lpad(CStr(data_amt), 14, "0")

                    '' 扣繳補充保費金額(83-92)
                    file_content65 &= pub.lpad(CStr(data_ext), 10, "0")

                    '' 共用欄位區(93-132) 空白
                    file_content65 &= pub.rpad("", 40, " ")

                    '' 信託註記(133-133) 非信託所得 填寫空白
                    file_content65 &= " "

                    '' 所得人姓名(134-183)
                    file_content65 &= data_name

                    '' 保留欄位(184-200) 空白
                    file_content65 &= pub.rpad("", 17, " ")

                    '' 金額合計
                    sum_inco_amt65 += CInt(data_amt)
                    sum_inco_ext65 += CInt(data_ext)
                Next
            End Using

            Using r67 As DataTable = bll.getinco67(v_UserOrgId, v_ym)
                For Each rs67 As DataRow In r67.Rows
                    If count67 > 0 Then
                        file_content67 &= Chr(13) & Chr(10)
                    End If
                    '' 資料筆數
                    count67 += 1

                    Dim data_amt As String = rs67("inco_amt").ToString
                    Dim data_ext As String = rs67("inco_health_ext").ToString
                    Dim data_date As String = pub.show_trn_date(rs67("inco_date").ToString)
                    Dim data_idno As String = pub.rpad(rs67("base_idno").ToString, 10, " ")
                    Dim data_name As String = pub.rpad(StrConv(Trim(rs67("base_name").ToString), VbStrConv.Wide), 25, "　")
                    Dim data_prikey As String = pub.lpad(rs67("inco_prikey").ToString, 20, "0")
                    Dim data_kind_code As String = "000"
                    Dim data_kind_code_no As String = "000"


                    ''  ================        資料行(67)      ================
                    '' 資料識別碼(1-1)    資料行寫 2
                    file_content67 &= "2"

                    '' 申報單位統一編號(2-9)
                    file_content67 &= v_unit_tax

                    '' 所得(收入)類別(10-11)
                    file_content67 &= "67"

                    '' 流水序號(12-20)
                    file_content67 &= pub.lpad(count67.ToString(), 9, "0")

                    '' 處理方式(21-21) I:新增  R:覆蓋,  統一使用R
                    file_content67 &= "R"

                    '' 所得給付日期(22-28)
                    file_content67 &= data_date

                    '' 所得人身分證號(29-38)
                    file_content67 &= data_idno

                    '' 申報編號(39-68) 30碼 
                    '' 固定寫(inco_prikey(20) + inco_code(3) + inco_kind_code(3) + 流水號(4))
                    file_content67 &= data_prikey & data_kind_code & data_kind_code_no & pub.lpad(count67.ToString(), 4, "0")
                    '' 所得(收入)給付金額(69-82)
                    file_content67 &= pub.lpad(CStr(data_amt), 14, "0")

                    '' 扣繳補充保費金額(83-92)
                    file_content67 &= pub.lpad(CStr(data_ext), 10, "0")

                    '' 共用欄位區(93-132) 空白
                    file_content67 &= pub.rpad("", 40, " ")

                    '' 信託註記(133-133) 非信託所得 填寫空白
                    file_content67 &= " "

                    '' 所得人姓名(134-183)
                    file_content67 &= data_name

                    '' 保留欄位(184-200) 空白
                    file_content67 &= pub.rpad("", 17, " ")

                    '' 金額合計
                    sum_inco_amt67 += CInt(data_amt)
                    sum_inco_ext67 += CInt(data_ext)

                Next
            End Using


            Using r68 As DataTable = bll.getinco68(v_UserOrgId, v_ym)
                For Each rs68 As DataRow In r68.Rows
                    If count68 > 0 Then
                        file_content68 &= Chr(13) & Chr(10)
                    End If
                    '' 資料筆數
                    count68 += 1

                    Dim data_amt As String = rs68("inco_amt").ToString
                    Dim data_ext As String = rs68("inco_health_ext").ToString
                    Dim data_date As String = pub.show_trn_date(rs68("inco_date").ToString)
                    Dim data_idno As String = pub.rpad(rs68("base_idno").ToString, 10, " ")
                    Dim data_name As String = pub.rpad(StrConv(Trim(rs68("base_name").ToString), VbStrConv.Wide), 25, "　")
                    Dim data_prikey As String = pub.lpad(rs68("inco_prikey").ToString, 20, "0")
                    Dim data_kind_code As String = "000"
                    Dim data_kind_code_no As String = "000"


                    ''  ================        資料行(68)      ================
                    '' 資料識別碼(1-1)    資料行寫 2
                    file_content68 &= "2"

                    '' 申報單位統一編號(2-9)
                    file_content68 &= v_unit_tax

                    '' 所得(收入)類別(10-11)
                    file_content68 &= "68"

                    '' 流水序號(12-20)
                    file_content68 &= pub.lpad(count68.ToString(), 9, "0")

                    '' 處理方式(21-21) I:新增  R:覆蓋,  統一使用R
                    file_content68 &= "R"

                    '' 所得給付日期(22-28)
                    file_content68 &= data_date

                    '' 所得人身分證號(29-38)
                    file_content68 &= data_idno

                    '' 申報編號(39-68) 30碼 
                    '' 固定寫(inco_prikey(20) + inco_code(3) + inco_kind_code(3) + 流水號(4))
                    file_content68 &= data_prikey & data_kind_code & data_kind_code_no & pub.lpad(count68.ToString(), 4, "0")
                    '' 所得(收入)給付金額(69-82)
                    file_content68 &= pub.lpad(CStr(data_amt), 14, "0")

                    '' 扣繳補充保費金額(83-92)
                    file_content68 &= pub.lpad(CStr(data_ext), 10, "0")

                    '' 共用欄位區(93-132) 空白
                    file_content68 &= pub.rpad("", 40, " ")

                    '' 信託註記(133-133) 非信託所得 填寫空白
                    file_content68 &= " "

                    '' 所得人姓名(134-183)
                    file_content68 &= data_name

                    '' 保留欄位(184-200) 空白
                    file_content68 &= pub.rpad("", 17, " ")

                    '' 金額合計
                    sum_inco_amt68 += CInt(data_amt)
                    sum_inco_ext68 += CInt(data_ext)
                Next
            End Using

        End Using

        ''  ================        末行      ================
        '' 資料識別碼(1-1)    末行寫 3 
        file_tot62 &= "3"
        file_tot63 &= "3"
        file_tot65 &= "3"
        file_tot67 &= "3"
        file_tot68 &= "3"

        '' 申報單位統一編號(2-9)
        file_tot62 &= v_unit_tax
        file_tot63 &= v_unit_tax
        file_tot65 &= v_unit_tax
        file_tot67 &= v_unit_tax
        file_tot68 &= v_unit_tax

        '' 所得類別(10-11)
        file_tot62 &= "62"
        file_tot63 &= "63"
        file_tot65 &= "65"
        file_tot67 &= "67"
        file_tot68 &= "68"

        '' 申報總筆數(12-20)
        file_tot62 &= pub.lpad(CStr(count62), 9, "0")
        file_tot63 &= pub.lpad(CStr(count63), 9, "0")
        file_tot65 &= pub.lpad(CStr(count63), 9, "0")
        file_tot67 &= pub.lpad(CStr(count63), 9, "0")
        file_tot68 &= pub.lpad(CStr(count63), 9, "0")

        '' 所得給付總額(21-40)
        file_tot62 &= pub.lpad(CStr(sum_inco_amt62), 20, "0")
        file_tot63 &= pub.lpad(CStr(sum_inco_amt63), 20, "0")
        file_tot65 &= pub.lpad(CStr(sum_inco_amt63), 20, "0")
        file_tot67 &= pub.lpad(CStr(sum_inco_amt63), 20, "0")
        file_tot68 &= pub.lpad(CStr(sum_inco_amt63), 20, "0")

        '' 扣繳補充保費總額(41-56)
        file_tot62 &= pub.lpad(CStr(sum_inco_ext62), 16, "0")
        file_tot63 &= pub.lpad(CStr(sum_inco_ext63), 16, "0")
        file_tot65 &= pub.lpad(CStr(sum_inco_ext63), 16, "0")
        file_tot67 &= pub.lpad(CStr(sum_inco_ext63), 16, "0")
        file_tot68 &= pub.lpad(CStr(sum_inco_ext63), 16, "0")

        '' 聯絡電話(57-71)
        file_tot62 &= v_unit_tel
        file_tot63 &= v_unit_tel
        file_tot65 &= v_unit_tel
        file_tot67 &= v_unit_tel
        file_tot68 &= v_unit_tel

        '' 聯絡人姓名(72-121)
        file_tot62 &= v_unit_cname
        file_tot63 &= v_unit_cname
        file_tot65 &= v_unit_cname
        file_tot67 &= v_unit_cname
        file_tot68 &= v_unit_cname

        '' 保留欄位(122-200) 空白
        file_tot62 &= pub.rpad("", 79, " ")
        file_tot63 &= pub.rpad("", 79, " ")
        file_tot65 &= pub.rpad("", 79, " ")
        file_tot67 &= pub.rpad("", 79, " ")
        file_tot68 &= pub.rpad("", 79, " ")

        Dim orgString As String = ""

        '' 寫入檔案 createdFile.WriteLine
        If file_content62 <> "" Then
            orgString &= file_header62 & vbCrLf
            orgString &= file_content62 & vbCrLf
            orgString &= file_tot62 & vbCrLf
        End If

        If file_content63 <> "" Then

            orgString &= file_header63 & vbCrLf
            orgString &= file_content63 & vbCrLf
            orgString &= file_tot63 & vbCrLf

        End If

        If file_content65 <> "" Then
            orgString &= file_header65 & vbCrLf
            orgString &= file_content65 & vbCrLf
            orgString &= file_tot65 & vbCrLf

        End If

        If file_content67 <> "" Then
            orgString &= file_header67 & vbCrLf
            orgString &= file_content67 & vbCrLf
            orgString &= file_tot67 & vbCrLf
        End If

        If file_content68 <> "" Then
            orgString &= file_header68 & vbCrLf
            orgString &= file_content68 & vbCrLf
            orgString &= file_tot68 & vbCrLf

        End If

        '' 寫入媒體檔案結束
        Dim btnid As String = "" ' HttpUtility.HtmlEncode(Request("btn").ToString)
        Dim ddlyy As String = "" 'HttpUtility.HtmlEncode(Request("ddlyy").ToString)
        Dim ddlmm As String = "" ' HttpUtility.HtmlEncode(Request("ddlmm").ToString)
        Dim v_yy As String = roc_ym.Substring(0, 3)
        Dim v_mm = ""
        If (roc_ym.Length > 4) Then
            v_mm = roc_ym.Substring(3, 2)
        Else
            v_mm = ""
        End If

        'Dim v_mm As String = roc_ym.Substring(3, 2)


        If orgString <> "" Then
            Me.Label_download.Text &= orgString & vbCrLf

        End If
        ' Me.Label_download.Text &= v_email & ";" & v_rocym & ";" & v_ym
    End Sub
#End Region

#Region " ExportFile"
    Private Sub ExportFile()

        Try
            Dim s As New StringBuilder()
            s.Append(Me.Label_download.Text)
            Me.Label_download.Text = s.ToString

            Dim oStringWriter As New System.IO.StringWriter()
            Dim oHtmlTextWriter As New HtmlTextWriter(oStringWriter)
            Dim oExcelFileName As String = Me.labelFilename.Text

            Context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("big5")

            Context.Response.ContentType = "text/plain"
            Context.Response.AddHeader("Content-Disposition", "attachment;filename=" & oExcelFileName)
            Me.plExport1.RenderControl(oHtmlTextWriter)

            Context.Response.Write(s.ToString)
            Context.Response.End()

        Catch ex As Exception

        End Try
    End Sub

#End Region

    Protected Sub btnList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnList.Click
        Media_List()
    End Sub

#Region " Protected Sub Media_List()"

    Protected Sub Media_List()

        Dim v_UserId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim v_UserOrgId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Dim dtMediaList As New DataTable

        '' 取得機關基本資料

        Dim v_ym As String = (DropDownList_year.SelectedValue + 1911).ToString & DropDownList_month.SelectedValue
        Dim bll As New SAL3124

        '' 開始匯出

        Dim oExcelFileName As String = "補充保費轉檔明細表.xls"

        Context.Response.Write("<meta http-equiv=Content-Type content=text/html;charset=utf-8>")
        Context.Response.ContentType = "application/x-excel"
        Context.Response.AddHeader("content-disposition", "attachment;filename=" & Server.UrlEncode(oExcelFileName))

        ''以下為扣費明細資料
        'Using r62 As DataTable = bll.getinco62(v_UserOrgId, v_ym)
        '    dtMediaList.Merge(r62)
        'End Using

        Dim cnt As Integer = 0

        Using r63 As DataTable = bll.getinco63(v_UserOrgId, v_ym)
            Me.gvList63.DataSource = r63
            Me.gvList63.DataBind()

            If Me.gvList63.Rows.Count > 0 Then
                cnt += gvList63.Rows.Count
                Dim oStringWriter As New System.IO.StringWriter()
                Dim oHtmlTextWriter As New HtmlTextWriter(oStringWriter)
                Me.gvList63.RenderControl(oHtmlTextWriter)
                Context.Response.Write(oStringWriter)
            End If
        End Using

        Using r65 As DataTable = bll.getinco65(v_UserOrgId, v_ym)
            Me.gvList65.DataSource = r65
            Me.gvList65.DataBind()

            If Me.gvList65.Rows.Count > 0 Then
                cnt += gvList65.Rows.Count
                Dim oStringWriter As New System.IO.StringWriter()
                Dim oHtmlTextWriter As New HtmlTextWriter(oStringWriter)
                Me.gvList65.RenderControl(oHtmlTextWriter)
                Context.Response.Write(oStringWriter)
            End If
        End Using

        Using r67 As DataTable = bll.getinco67(v_UserOrgId, v_ym)
            Me.gvList67.DataSource = r67
            Me.gvList67.DataBind()

            If Me.gvList67.Rows.Count > 0 Then
                cnt += gvList67.Rows.Count
                Dim oStringWriter As New System.IO.StringWriter()
                Dim oHtmlTextWriter As New HtmlTextWriter(oStringWriter)
                Me.gvList67.RenderControl(oHtmlTextWriter)
                Context.Response.Write(oStringWriter)
            End If
        End Using

        Using r68 As DataTable = bll.getinco68(v_UserOrgId, v_ym)
            Me.gvList68.DataSource = r68
            Me.gvList68.DataBind()

            If Me.gvList68.Rows.Count > 0 Then
                cnt += gvList68.Rows.Count
                Dim oStringWriter As New System.IO.StringWriter()
                Dim oHtmlTextWriter As New HtmlTextWriter(oStringWriter)
                Me.gvList68.RenderControl(oHtmlTextWriter)
                Context.Response.Write(oStringWriter)
            End If
        End Using

        If cnt = 0 Then
            Context.Response.Write("無資料可列印")
        End If

        Context.Response.End()

    End Sub

#End Region


    ' 必要步驟
    ' 設定 EnableEventValidation="false" 
    ' 覆寫 VerifyRenderingInServerForm 方法
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
        '處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
    End Sub

End Class
