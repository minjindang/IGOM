Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections

Namespace FSC.Logic
    <System.ComponentModel.DataObject()> _
    Public Class CPAPR18M
        Private DAO As CPAPR18MDAO

#Region "Property"
        Private _Orgcode As String = String.Empty
        Private _Depart_id As String = String.Empty
        Private _PRNAME As String = String.Empty
        Private _PRIDNO As String = String.Empty
        Private _PRCARD As String = String.Empty
        Private _PRADDD As String = String.Empty
        Private _PRSTIME As String = String.Empty
        Private _PRETIME As String = String.Empty
        Private _PRADDH As Double = Nothing
        Private _PRATYPE As String = String.Empty
        Private _PRPAYH As Double = Nothing
        Private _PRPAYFEE As Double = Nothing
        Private _PRMNYH As Double = Nothing
        Private _PRGUID As String = String.Empty
        Private _PRUSERID As String = String.Empty
        Private _PRUPDATE As String = String.Empty
        Private _PRREASON As String = String.Empty
        Private _PRCHANGE_REASON As String = String.Empty
        Private _PRADDE As String = String.Empty
        Private _PRMEMO As String = String.Empty
        Private _isOnlyLeave As String = String.Empty
        Private _CheckType As String

        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property DepartId() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        Public Property PRNAME() As String
            Get
                Return _PRNAME
            End Get
            Set(ByVal value As String)
                _PRNAME = value
            End Set
        End Property
        Public Property PRIDNO() As String
            Get
                Return _PRIDNO
            End Get
            Set(ByVal value As String)
                _PRIDNO = value
            End Set
        End Property
        Public Property PRCARD() As String
            Get
                Return _PRCARD
            End Get
            Set(ByVal value As String)
                _PRCARD = value
            End Set
        End Property
        Public Property PRADDD() As String
            Get
                Return _PRADDD
            End Get
            Set(ByVal value As String)
                _PRADDD = value
            End Set
        End Property
        Public Property PRSTIME() As String
            Get
                Return _PRSTIME
            End Get
            Set(ByVal value As String)
                _PRSTIME = value
            End Set
        End Property
        Public Property PRETIME() As String
            Get
                Return _PRETIME
            End Get
            Set(ByVal value As String)
                _PRETIME = value
            End Set
        End Property
        Public Property PRADDH() As Double
            Get
                Return _PRADDH
            End Get
            Set(ByVal value As Double)
                _PRADDH = value
            End Set
        End Property
        Public Property PRATYPE() As String
            Get
                Return _PRATYPE
            End Get
            Set(ByVal value As String)
                _PRATYPE = value
            End Set
        End Property
        Public Property PRPAYH() As Double
            Get
                Return _PRPAYH
            End Get
            Set(ByVal value As Double)
                _PRPAYH = value
            End Set
        End Property
        Public Property PRPAYFEE() As Double
            Get
                Return _PRPAYFEE
            End Get
            Set(ByVal value As Double)
                _PRPAYFEE = value
            End Set
        End Property
        Public Property PRMNYH() As Double
            Get
                Return _PRMNYH
            End Get
            Set(ByVal value As Double)
                _PRMNYH = value
            End Set
        End Property
        Public Property PRGUID() As String
            Get
                Return _PRGUID
            End Get
            Set(ByVal value As String)
                _PRGUID = value
            End Set
        End Property
        Public Property PRUSERID() As String
            Get
                Return _PRUSERID
            End Get
            Set(ByVal value As String)
                _PRUSERID = value
            End Set
        End Property
        Public Property PRUPDATE() As String
            Get
                Return _PRUPDATE
            End Get
            Set(ByVal value As String)
                _PRUPDATE = value
            End Set
        End Property
        Public Property PRREASON() As String
            Get
                Return _PRREASON
            End Get
            Set(ByVal value As String)
                _PRREASON = value
            End Set
        End Property
        Public Property PRCHANGE_REASON() As String
            Get
                Return _PRCHANGE_REASON
            End Get
            Set(ByVal value As String)
                _PRCHANGE_REASON = value
            End Set
        End Property
        Public Property PRADDE() As String
            Get
                Return _PRADDE
            End Get
            Set(ByVal value As String)
                _PRADDE = value
            End Set
        End Property
        Public Property PRMEMO() As String
            Get
                Return _PRMEMO
            End Get
            Set(ByVal value As String)
                _PRMEMO = value
            End Set
        End Property
        Public Property isOnlyLeave() As String
            Get
                Return _isOnlyLeave
            End Get
            Set(ByVal value As String)
                _isOnlyLeave = value
            End Set
        End Property
        Public Property CheckType() As String
            Get
                Return _CheckType
            End Get
            Set(ByVal value As String)
                _CheckType = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPR18MDAO()
        End Sub

        Public Sub New(ByVal connstring As String)
            DAO = New CPAPR18MDAO(connstring)
        End Sub

        Public Sub New(ByVal conn As SqlClient.SqlConnection)
            DAO = New CPAPR18MDAO(conn)
        End Sub

        Public Function GetSumData(ByVal PRIDNO As String, ByVal PRADDD As String, Optional ByVal PRATYPE As String = Nothing) As DataTable
            Return DAO.GetSumData(PRIDNO, PRADDD, PRATYPE).Tables(0)
        End Function

        Public Function GetSumPrpayfee(ByVal PRIDNO As String, ByVal PRADDD As String) As Integer
            Dim Obj As Object = DAO.GetSumPrpayfee(PRIDNO, PRADDD)
            If IsDBNull(Obj) Then
                Return 0
            End If
            Return CInt(Obj)
        End Function

        Public Function GetSumPrpayfee(ByVal PRIDNO As String, ByVal PRADDD1 As String, ByVal PRADDD2 As String) As Integer
            Dim Obj As Object = DAO.GetSumPrpayfee(PRIDNO, PRADDD1, PRADDD2)
            If IsDBNull(Obj) Then
                Return 0
            End If
            Return CInt(Obj)
        End Function

        Public Function GetCPAPR18MByPK(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String) As DataTable
            Return DAO.GetDataByPK(PRIDNO, PRADDD, PRSTIME).Tables(0)
        End Function

        Public Function GetCPAPR18M(ByVal PRIDNO As String, ByVal ym As String, ByVal ymd As String) As DataTable
            Dim ds As DataSet = DAO.getData(PRIDNO, ym, ymd)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetSumPRMNYH(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRATYPE As String) As Integer
            Dim Obj As Object = DAO.GetSumPRMNYH(PRIDNO, PRADDD, PRATYPE)
            If IsDBNull(Obj) Then
                Return 0
            End If
            Return CInt(Obj)
        End Function

        Public Function GetCPAPR18MByFlow_id(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As DataTable
            Dim ds As DataSet = DAO.GetDataByFlow_id(Flow_id, Orgcode)
            Return ds.Tables(0)
        End Function


        Public Function CheckInsertData() As String
            ''加班申請時間不能超過加班日隔天中午十二點!(遇假日順延) 

            'Dim Metadb_id As String = New Member().GetColumnValue("Metadb_id", Me.PRIDNO)
            ''依申請者的Metadb_id, 取得資料庫連線
            'Dim p2kConn As String = ConnectDB.GetCPADBString(Metadb_id)

            'Dim worktimeb As String = "0000"
            'Dim worktimee As String = "0000"
            'Dim noontimeb As String = "0000"
            'Dim noontimee As String = "0000"
            'Dim offday As Boolean = False

            'Dim ht As Hashtable = Content.getWorkTime(Me.PRIDNO, Me.PRADDD)
            'If ht IsNot Nothing AndAlso ht.Count > 0 Then
            '    worktimeb = ht("WORKTIMEB").ToString()
            '    worktimee = ht("WORKTIMEE").ToString()
            '    noontimeb = ht("NOONTIMEB").ToString()
            '    noontimee = ht("NOONTIMEE").ToString()
            '    offday = CType(ht("OFFDAY").ToString(), Boolean)
            'End If

            'If Not offday Then
            '    '判斷加班時間是否為非上班時間

            '    'hsien 20120807
            '    If Me.PRSTIME < worktimeb And Me.PRETIME > worktimeb Then
            '        Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '    End If

            '    'hsien 20120807
            '    If Me.PRSTIME < worktimee And Me.PRETIME > worktimee Then
            '        Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '    End If

            '    'hsien 20120905 庶務科科長及考訓科科長都同意中午能開放同仁加班，所以系統要開放1200:1330能加班
            '    If Me.PRSTIME >= worktimeb And Me.PRETIME <= worktimee Then
            '        If Me.PRSTIME < noontimeb And Me.PRETIME > noontimeb Then
            '            Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '        End If
            '        If Me.PRSTIME < noontimee And Me.PRETIME > noontimee Then
            '            Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '        End If
            '    End If

            '    If noontimeb = noontimee Then
            '        If (Me.PRSTIME = worktimeb And Me.PRETIME = worktimee) Or _
            '            (Me.PRSTIME < worktimeb And Me.PRETIME > worktimeb) Or _
            '            (Me.PRSTIME < worktimee And Me.PRETIME > worktimee) Then
            '            Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '        End If
            '    End If

            '    'Elbert 20130607 增加上班起至中午起 及 中午迄至下班起不可加班的檢核
            '    If Me.PRSTIME >= worktimeb And Me.PRETIME <= noontimeb Then
            '        Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '    End If

            '    If Me.PRSTIME >= noontimee And Me.PRETIME <= worktimee Then
            '        Return Me.PRNAME & "的加班時間必需為非上班時間!"
            '    End If
            'Else
            '    '非上班時間

            '    'hsien 20130306
            '    If Metadb_id = "2" And Me.PRATYPE = "1" Then
            '        Return Me.PRNAME & "只能用專案加班申請(例)假日加班!"
            '    End If

            '    Dim plmbll As New CPAPP16M()
            '    Dim p2kbll As New CPAPP16M()

            '    Dim datacount As Integer = 0
            '    '' '' ''datacount += plmbll.GetCountByDateTime(Me.PRADDD & Me.PRSTIME, Me.PRADDE & Me.PRSTIME, Me.PRIDNO, False)
            '    '' '' ''datacount += p2kbll.GetCountByDateTime(Me.PRADDD & Me.PRSTIME, Me.PRADDE & Me.PRSTIME, Me.PRIDNO, True)
            '    '' '' ''If datacount > 0 Then
            '    '' '' ''    Return Me.PRNAME & "的加班時間已有出差資料!"
            '    '' '' ''End If

            'End If


            'If String.IsNullOrEmpty(Me.PRREASON) Then
            '    Return "事由為必填欄位!"
            'End If

            ''If Integer.Parse(Me.PRADDD) < (Integer.Parse(Now.ToString("yyyyMMdd")) - 19110000) Then
            ''    Return "加班日期不可小於今天日期，請重新填寫!"
            ''End If

            'If Me.PRSTIME > Me.PRETIME Then
            '    Return "加班起時不可大於加班迄時!"
            'End If

            ''If Me.PRETIME = "2400" Then
            ''    Return "加班迄時不可為明日00點00分!"
            ''End If

            'Dim hours As Integer = Content.computeHourForOvertime(Me.PRADDD & Me.PRSTIME, Me.PRADDD & Me.PRETIME, Me.PRIDNO)
            'If hours < 1 Then
            '    Return "加班時數不可小於1個小時!"
            'End If

            'Me.PRADDH = hours


            ''Dim sumday As Integer = 0, summonth As Integer = 0
            ''Dim obj As Object = Nothing
            ''Dim summonth As Integer
            ''obj = cpaDAO.GetSUNPRADDHByYMD(Me.PRCARD, Me.PRADDD, Me.PRATYPE)
            ''If Not IsDBNull(obj) Then _
            ''    sumday = CType(obj, Integer) '當日請假時數加總(依PRATYPE分別加總一般與專案加班)

            ''obj = cpaDAO.GetSUNPRADDHByYM(Me.PRCARD, Mid(Me.PRADDD, 1, 5), Me.PRATYPE)
            ''If Not IsDBNull(obj) Then _
            ''    summonth = CType(obj, Integer) '當月請假時數加總(依PRATYPE分別加總一般與專案加班)

            ''Dim pc03m As New CPAPC03M(p2kConn)

            ''Dim daylimit As String = String.Empty, monthlimit As String = String.Empty

            ''Dim PEKIND As String = New CPAPE05M(p2kConn).GetPEKIND(Me.PRIDNO)  '差勤規定組別

            ' ''每日加班時數上限
            ''daylimit = pc03m.GetPCPARM1(PEKIND, "limit", "2")

            ''If Me.PRATYPE = "1" Then
            ''    '一般加班每月時數上限
            ''    monthlimit = "20"
            ''Else
            ''    '每月上限時數(X)
            ''    Dim X As String = pt20m.GetPTHOUR(Me.PRIDNO, Mid(Me.PRADDD, 1, 5))

            ''    Dim B As String
            ''    '每月加班時數上限(B)(專案加班+一般加班) = 若查無資料，則X值即為B值(每月時數上限值為一般+專案總時數)
            ''    B = IIf(String.IsNullOrEmpty(X), pc03m.GetPCPARM1(PEKIND, "limit", "3"), X)
            ''    '專案加班每月時數上限 = 每月加班時數上限(B)(專案加班+一般加班) - 一般加班時數上限(20)
            ''    monthlimit = Integer.Parse(B) - 20
            ''End If

            ''If Me.PRATYPE = "1" AndAlso Not String.IsNullOrEmpty(daylimit) Then
            ''    If sumday + Me.PRADDH > Integer.Parse(daylimit) Then
            ''        Return "已超過每日加班上限!"
            ''    End If
            ''End If
            'Dim pt20m As New CPAPT20M(p2kConn)

            'Dim plmDAO As New CPAPR18MDAO(ConnectDB.GetDBString())
            'Dim p2kDAO As New CPAPR18MDAO(p2kConn)

            ''Dim PEMEMCOD As String = pe05m.GetColumnValue("PEMEMCOD", Me.PRIDNO)

            'Dim PRATYPENAME As String = ""
            'Dim monthLimit As Integer = 0
            'Dim monthLimitPay As Integer = 0
            'Dim sumHours As Integer = 0
            'Dim proSumHours As Integer = 0

            ''hsien 20120905
            'If Metadb_id = "1" Then
            '    '人事人員
            '    sumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, True))
            '    sumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, False))

            '    Dim pt20mdt As DataTable = pt20m.GetDataByPRADDD(Me.PRIDNO, Me.PRADDD)

            '    If Me.PRATYPE = "1" Then
            '        '一般加班
            '        monthLimit = 20

            '        If pt20mdt IsNot Nothing AndAlso pt20mdt.Rows.Count > 0 Then
            '            'hsien 20120927
            '            If pt20mdt.Rows(0)("PTFLAG2").ToString() = "1" Then
            '                Return "該時段只適用申請專案加班"
            '            End If
            '        End If

            '        If Me.PRMEMO = "2" Then
            '            '一般加班,大批加班
            '            proSumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "2", Me.PRMEMO, True))
            '            proSumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "2", Me.PRMEMO, False))
            '        End If

            '    ElseIf Me.PRATYPE = "2" Then
            '        '專案加班

            '        If pt20mdt IsNot Nothing AndAlso pt20mdt.Rows.Count > 0 Then
            '            'hsien 20120927
            '            If pt20mdt.Rows(0)("PTFLAG2").ToString() = "1" Then
            '                monthLimit = CommonFun.getInt(pt20mdt.Rows(0)("PTHOUR").ToString())         '專案加班時數
            '            Else
            '                monthLimit = CommonFun.getInt(pt20mdt.Rows(0)("PTHOUR").ToString()) - 20    '專案加班時數 - 20(一般加班時數)
            '            End If

            '            If Me.PRMEMO = "2" Then
            '                monthLimitPay = CommonFun.getInt(pt20mdt.Rows(0)("PTHOUR2").ToString())     '可領加班費時數

            '                '一般加班,大批加班
            '                proSumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "1", Me.PRMEMO, True))
            '                proSumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "1", Me.PRMEMO, False))

            '                proSumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, Me.PRMEMO, True))
            '                proSumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, Me.PRMEMO, False))

            '            End If
            '        Else
            '            Return Me.PRNAME & "沒有在申請專案加班人員檔內!"
            '        End If
            '    End If

            'ElseIf Metadb_id = "2" Then
            '    '庶務人員

            '    If Me.PRMEMO = "2" Then
            '        '申請加班費

            '        If offday And hours < 8 Then
            '            hours = 8
            '        End If
            '        Dim Sub_depart_id As String = New Member().GetColumnValue("Sub_depart_id", Me.PRIDNO)
            '        Dim week As String
            '        Dim dtpb As New DataTable()
            '        dtpb = New CPAPB02M().getData(Me.PRADDD.Substring(0, 7))
            '        For Each drpb As DataRow In dtpb.Rows
            '            week = drpb("pbdweek").ToString()
            '        Next
            '        'Elbert 20130607 庶務科李惠娟要求將(星期一)設為文化處(圖書資訊科) 技工.工友.駕駛及臨時人員之例假，
            '        '而其他技工.工友.駕駛及臨時人員之例假設為(星期日)，該等人員凡於例假出勤，
            '        '僅可申請補休不可請領加班費，但擔任縣長之三名駕駛:黃清俊，林慶成，江岳諭則不受限。
            '        If Not Me.PRIDNO.Equals("T102677042") And Not Me.PRIDNO.Equals("T121938328") _
            '            And Not Me.PRIDNO.Equals("T120968546") And Not Sub_depart_id.Equals("1710") _
            '            And week.Equals("日") Then
            '            Return "星期日加班僅可申請補休，不可請領加班費"
            '        ElseIf Sub_depart_id.Equals("1710") And week.Equals("一") Then
            '            Return "星期一加班僅可申請補休，不可請領加班費"
            '        End If

            '        Dim dt As New DataTable()
            '        dt = p2kDAO.GetDataByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, True)
            '        For Each dr As DataRow In dt.Rows
            '            Dim hour As Integer = CommonFun.getInt(dr("PRADDH").ToString())
            '            If dr("PRMEMO").ToString() = "2" Then
            '                Dim sht As Hashtable = Content.getWorkTime(dr("PRIDNO").ToString(), dr("PRADDD").ToString())
            '                If CType(sht("OFFDAY").ToString(), Boolean) And hour < 8 Then
            '                    hour = 8
            '                End If
            '            End If
            '            sumHours += hour
            '        Next

            '        dt = plmDAO.GetDataByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, False)
            '        For Each dr As DataRow In dt.Rows
            '            Dim hour As Integer = CommonFun.getInt(dr("PRADDH").ToString())
            '            If dr("PRMEMO").ToString() = "2" Then
            '                Dim sht As Hashtable = Content.getWorkTime(dr("PRIDNO").ToString(), dr("PRADDD").ToString())
            '                If CType(sht("OFFDAY").ToString(), Boolean) And hour < 8 Then
            '                    hour = 8
            '                End If
            '            End If
            '            sumHours += hour
            '        Next

            '    Else
            '        '申請補休
            '        sumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, True))
            '        sumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, False))
            '    End If


            '    Dim pt20mdt As DataTable = pt20m.GetDataByPRADDD(Me.PRIDNO, Me.PRADDD)

            '    If Me.PRATYPE = "1" Then
            '        '一般加班
            '        monthLimit = 20

            '        If Not offday And hours > 4 Then
            '            Return "加班時數不可大於4小時"
            '        End If


            '        If pt20mdt IsNot Nothing AndAlso pt20mdt.Rows.Count > 0 Then
            '            'hsien 20120927
            '            If pt20mdt.Rows(0)("PTFLAG2").ToString() = "1" Then
            '                Return "該時段只適用申請專案加班"
            '            End If
            '        End If

            '        If Me.PRMEMO = "2" Then
            '            '一般加班,大批加班
            '            proSumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "2", Me.PRMEMO, True))
            '            proSumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "2", Me.PRMEMO, False))
            '        End If

            '    ElseIf Me.PRATYPE = "2" Then
            '        '專案加班
            '        Dim ptflag As String = "1"

            '        If pt20mdt IsNot Nothing AndAlso pt20mdt.Rows.Count > 0 Then

            '            'hsien 20120927
            '            If pt20mdt.Rows(0)("PTFLAG2").ToString() = "1" Then
            '                monthLimit = CommonFun.getInt(pt20mdt.Rows(0)("PTHOUR").ToString())         '專案加班時數
            '            Else
            '                monthLimit = CommonFun.getInt(pt20mdt.Rows(0)("PTHOUR").ToString()) - 20    '專案加班時數 - 20(一般加班時數)
            '            End If

            '            If Me.PRMEMO = "2" Then
            '                monthLimitPay = CommonFun.getInt(pt20mdt.Rows(0)("PTHOUR2").ToString())     '可領加班費時數

            '                '一般加班,大批加班
            '                proSumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "1", Me.PRMEMO, True))
            '                proSumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), "1", Me.PRMEMO, False))

            '                proSumHours += CommonFun.getInt(p2kDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, Me.PRMEMO, True))
            '                proSumHours += CommonFun.getInt(plmDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, Me.PRMEMO, False))
            '            End If
            '            ptflag = pt20mdt.Rows(0)("PTFLAG").ToString()
            '        Else
            '            Return Me.PRNAME & "沒有在申請專案加班人員檔內!"
            '        End If

            '        If Not offday And hours > 4 And ptflag = "1" Then
            '            Return "加班時數不可大於4小時"
            '        End If
            '    End If

            'End If

            'If sumHours + hours > monthLimit Then
            '    Return PRATYPENAME & "已超過加班上限" & monthLimit & "小時!"
            'End If

            'If monthLimitPay > 0 And (proSumHours + hours > monthLimitPay) Then
            '    Return PRATYPENAME & "可領加班費時數已超過上限" & monthLimitPay & "小時!"
            'End If


            ''If Me.PRATYPE = "1" Then
            ''    '一般加班
            ''    PRATYPENAME = "一般加班"

            ''    If PEMEMCOD = "3" Or PEMEMCOD = "4" Or PEMEMCOD = "8" Then
            ''        '技工工友, 臨時人員, 駕駛
            ''        monthLimit = 20

            ''        If hours > 4 And Not offday Then
            ''            '若有在專案加班時間內, 則不限受
            ''            'Dim pt20mdt As DataTable = pt20m.GetDataByPRADDD(Me.PRIDNO, Me.PRADDD)
            ''            'If pt20mdt Is Nothing OrElse pt20mdt.Rows.Count <= 0 Then
            ''            Return "加班時數不可大於4小時"
            ''            'End If
            ''        End If

            ''    Else
            ''        monthLimit = 20
            ''    End If


            ''ElseIf Me.PRATYPE = "2" Then
            ''    '專案加班
            ''    PRATYPENAME = "專案加班"

            ''    'Dim cpadb As String = ConfigurationManager.AppSettings(Orgcode).ToString().Split(",")(CommonFun.getInt(Metadb_id) - 1)


            ''    If pt20m.GetCountByPRADDD(Me.PRIDNO, Me.PRADDD) <= 0 Then
            ''        Return Me.PRNAME & "沒有在申請專案加班人員檔內!"
            ''    End If

            ''    Dim pt20mdt As DataTable = pt20m.GetDataByPRADDD(Me.PRIDNO, Me.PRADDD)
            ''    If pt20mdt IsNot Nothing AndAlso pt20mdt.Rows.Count > 0 Then
            ''        Dim dr As DataRow = pt20mdt.Rows(0)
            ''        Dim PTHOUR As Integer = 0

            ''        If PEMEMCOD = "3" Or PEMEMCOD = "4" Or PEMEMCOD = "8" Then
            ''            '技工工友, 臨時人員, 駕駛
            ''            PTHOUR = CommonFun.getInt(dr("PTHOUR").ToString())
            ''            If PTHOUR > 46 Then
            ''                PTHOUR = 46
            ''            End If
            ''            monthLimit = CommonFun.getInt(dr("PTHOUR").ToString()) - 20 '專案加班時數 - 20(一般加班時數)
            ''        Else
            ''            monthLimit = CommonFun.getInt(dr("PTHOUR").ToString()) - 20 '專案加班時數 - 20(一般加班時數)
            ''        End If

            ''        monthLimitPay = CommonFun.getInt(dr("PTHOUR2").ToString())

            ''    End If

            ''    If Me.PRMEMO = "2" Then
            ''        '申請加班費 , 檢核專案加班的整月可領加班費時數

            ''        Dim o As Object = Nothing
            ''        Dim o2 As Object = Nothing
            ''        o = cpaDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, Me.PRMEMO, True)
            ''        o2 = DAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, Me.PRMEMO, False)

            ''        If Not IsDBNull(o) Then
            ''            sumHours += CType(o, Integer)     '當月請假時數加總(依PRATYPE分別加總一般與專案加班)
            ''        End If
            ''        If Not IsDBNull(o2) Then
            ''            sumHours += CType(o2, Integer)    '當月請假時數加總(依PRATYPE分別加總一般與專案加班)
            ''        End If

            ''        If sumHours + Me.PRADDH > monthLimitPay Then
            ''            Return PRATYPENAME & "可領加班費時數已超過上限" & monthLimitPay & "小時!"
            ''        End If
            ''    End If

            ''End If

            ''Dim obj As Object = cpaDAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, True)
            ''Dim obj2 As Object = DAO.GetSUNPRADDHByYM(Me.PRCARD, Me.PRADDD.Substring(0, 5), Me.PRATYPE, False)

            ''If Not IsDBNull(obj) Then
            ''    sumHours += CType(obj, Integer)     '當月請假時數加總(依PRATYPE分別加總一般與專案加班)
            ''End If
            ''If Not IsDBNull(obj2) Then
            ''    sumHours += CType(obj2, Integer)    '當月請假時數加總(依PRATYPE分別加總一般與專案加班)
            ''End If

            ''If sumHours + Me.PRADDH > monthLimit Then
            ''    Return PRATYPENAME & "已超過加班上限" & monthLimit & "小時!"
            ''End If


            ''p2k
            'If CType(p2kDAO.GetCountByPRSTIME(Me.PRIDNO, Me.PRADDD, Me.PRSTIME, Me.PRETIME), Integer) > 0 Then
            '    Return "已有該時段的加班記錄!"
            'End If

            ''plm
            'If CType(plmDAO.GetCountByPRSTIME(Me.PRIDNO, Me.PRADDD, Me.PRSTIME, Me.PRETIME), Integer) > 0 Then
            '    Return "已有該時段的加班申請記錄!"
            'End If

            Return String.Empty
        End Function


        Public Function GetCountByPRSTIME(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal PRETIME As String, ByVal isP2k As Boolean) As Object
            Return DAO.GetCountByPRSTIME(PRIDNO, PRADDD, PRSTIME, PRETIME)
        End Function


        Public Function InsertCPAPR18M() As Boolean
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function UpdateCPAPR18M() As Boolean
            Return DAO.UpdateData(Me)
        End Function
        Public Function UpdatePRMNYH(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal origApplyhour As Integer, ByVal Apply_hour As Integer, ByVal Hour_pay As Integer, ByVal PRUPDATE As String) As Boolean
            Return DAO.UpdatePRMNYH(PRIDNO, PRADDD, PRSTIME, origApplyhour, Apply_hour, Hour_pay, PRUPDATE) = 1
        End Function


        Public Function UpdatePRMNYH(ByVal PRIDNO As String, ByVal PRADDD As String, ByVal PRSTIME As String, ByVal Apply_hour As Integer, ByVal Hour_pay As Integer) As Boolean
            Return DAO.UpdatePRMNYH(PRIDNO, PRADDD, PRSTIME, Apply_hour, Hour_pay) = 1
        End Function

        Public Function UpdatePRPAYH(ByVal PRPAYH As Integer, ByVal PRCARD As String, ByVal PRADDD As String, ByVal PRSTIME As String) As Boolean
            Return DAO.UpdatePRPAYH(PRPAYH, PRCARD, PRADDD, PRSTIME) = 1
        End Function

        Public Function GetStatisticsData(ByVal nowDate As String, ByVal sixMonthBefore As String) As DataSet
            Return DAO.GetStatisticsData(nowDate, sixMonthBefore)
        End Function

        '人立新增0710 for FSC3104_01
        Function GetDataByPoguid(ByVal flow_id As String) As DataTable
            Return DAO.GetDataByPoguid(flow_id)
        End Function

        Public Function DeleteCPAPR18MByGUID(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As Boolean
            Return DAO.DeleteDataByGUID(Flow_id) = 1
        End Function

        Public Function UpatePRATYPEByGUID(ByVal PRATYPE As String, ByVal PRAGUID As String) As Boolean
            Return DAO.UpatePRATYPEByGUID(PRATYPE, PRAGUID) >= 1
        End Function

        Public Function GetDataFSC2209_02(ByVal PRIDNO As String, ByVal YYYMM As String) As DataTable
            Return DAO.GetDataFSC2209_02(PRIDNO, YYYMM).Tables(0)
        End Function

        Public Function UpdateFlag(ByVal PRGUID As String, ByVal STATUS As String) As Boolean
            Return DAO.UpdateFlag(PRGUID, STATUS) >= 1
        End Function

        Public Function GetQueryData00(ByVal year As String, ByVal idno As String) As DataTable
            Return DAO.GetQueryData00(year, idno)
        End Function

        Public Function GetQuery(ByVal ID_card As String, ByVal ym As String) As DataTable
            Return DAO.getData(ID_card, ym)
        End Function

        Public Function getAllDataByYm(ByVal Id_card As String, ByVal ym As String) As DataTable
            Return DAO.getAllDataByYm(Id_card, ym)
        End Function
    End Class
End Namespace
