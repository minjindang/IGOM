Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPP16M
        Public DAO As CPAPP16MDAO

#Region "Property"
        Private _Orgcode As String
        Private _departId As String
        Private _PPIDNO As String
        Private _PPNAME As String
        Private _PPCARD As String
        Private _PPBUSTYPE As String
        Private _PPBUSDATEB As String
        Private _PPTIMEB As String
        Private _PPBUSDATEE As String
        Private _PPTIMEE As String
        Private _PPBUSDH As Double
        Private _PPHOLIDAY As String
        Private _PPBUSPLACE As String
        Private _PPREASON As String
        Private _PPHDAY As Double
        Private _PPBEFOREM As Double
        Private _PPREMARK As String
        Private _PPPAYH As Double
        Private _PPGUID As String
        Private _PPUSERID As String
        Private _PPUPDATE As String
        Private _PPHDATEB As String
        Private _PPHTIMEB As String
        Private _PPHDATEE As String
        Private _PPHTIMEE As String
        Private _ISNIGHT As Boolean

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
                Return _departId
            End Get
            Set(ByVal value As String)
                _departId = value
            End Set
        End Property

        ''' <summary>
        ''' 身分證字號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPIDNO() As String
            Get
                Return _PPIDNO
            End Get
            Set(ByVal value As String)
                _PPIDNO = value
            End Set
        End Property
        ''' <summary>
        ''' 姓名
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPNAME() As String
            Get
                Return _PPNAME
            End Get
            Set(ByVal value As String)
                _PPNAME = value
            End Set
        End Property
        ''' <summary>
        ''' 員工代號
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPCARD() As String
            Get
                Return _PPCARD
            End Get
            Set(ByVal value As String)
                _PPCARD = value
            End Set
        End Property
        ''' <summary>
        ''' 出差類別
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPBUSTYPE() As String
            Get
                Return _PPBUSTYPE
            End Get
            Set(ByVal value As String)
                _PPBUSTYPE = value
            End Set
        End Property
        ''' <summary>
        ''' 開始日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPBUSDATEB() As String
            Get
                Return _PPBUSDATEB
            End Get
            Set(ByVal value As String)
                _PPBUSDATEB = value
            End Set
        End Property
        ''' <summary>
        ''' 開始時間
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPTIMEB() As String
            Get
                Return _PPTIMEB
            End Get
            Set(ByVal value As String)
                _PPTIMEB = value
            End Set
        End Property
        ''' <summary>
        ''' 結束日期
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPBUSDATEE() As String
            Get
                Return _PPBUSDATEE
            End Get
            Set(ByVal value As String)
                _PPBUSDATEE = value
            End Set
        End Property
        ''' <summary>
        ''' 結束時間
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPTIMEE() As String
            Get
                Return _PPTIMEE
            End Get
            Set(ByVal value As String)
                _PPTIMEE = value
            End Set
        End Property
        ''' <summary>
        ''' 合計日時數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPBUSDH() As Double
            Get
                Return _PPBUSDH
            End Get
            Set(ByVal value As Double)
                _PPBUSDH = value
            End Set
        End Property
        ''' <summary>
        ''' 合計是否含假日
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPHOLIDAY() As String
            Get
                Return _PPHOLIDAY
            End Get
            Set(ByVal value As String)
                _PPHOLIDAY = value
            End Set
        End Property
        ''' <summary>
        ''' 出差地點
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPBUSPLACE() As String
            Get
                Return _PPBUSPLACE
            End Get
            Set(ByVal value As String)
                _PPBUSPLACE = value
            End Set
        End Property
        ''' <summary>
        ''' 出差事由
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPREASON() As String
            Get
                Return _PPREASON
            End Get
            Set(ByVal value As String)
                _PPREASON = value
            End Set
        End Property
        ''' <summary>
        ''' 出差含假日日時數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPHDAY() As Double
            Get
                Return _PPHDAY
            End Get
            Set(ByVal value As Double)
                _PPHDAY = value
            End Set
        End Property
        ''' <summary>
        ''' 預支費用
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPBEFOREM() As Double
            Get
                Return _PPBEFOREM
            End Get
            Set(ByVal value As Double)
                _PPBEFOREM = value
            End Set
        End Property
        ''' <summary>
        ''' 出差費已領註記
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPREMARK() As String
            Get
                Return _PPREMARK
            End Get
            Set(ByVal value As String)
                _PPREMARK = value
            End Set
        End Property
        ''' <summary>
        ''' 已領已休時數
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPPAYH() As Double
            Get
                Return _PPPAYH
            End Get
            Set(ByVal value As Double)
                _PPPAYH = value
            End Set
        End Property
        Public Property PPGUID() As String
            Get
                Return _PPGUID
            End Get
            Set(ByVal value As String)
                _PPGUID = value
            End Set
        End Property
        ''' <summary>
        ''' 異動者
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property PPUSERID() As String
            Get
                Return _PPUSERID
            End Get
            Set(ByVal value As String)
                _PPUSERID = value
            End Set
        End Property

        Public Property PPHDATEB() As String
            Get
                Return _PPHDATEB
            End Get
            Set(ByVal value As String)
                _PPHDATEB = value
            End Set
        End Property

        Public Property PPHTIMEB() As String
            Get
                Return _PPHTIMEB
            End Get
            Set(ByVal value As String)
                _PPHTIMEB = value
            End Set
        End Property

        Public Property PPHDATEE() As String
            Get
                Return _PPHDATEE
            End Get
            Set(ByVal value As String)
                _PPHDATEE = value
            End Set
        End Property

        Public Property PPHTIMEE() As String
            Get
                Return _PPHTIMEE
            End Get
            Set(ByVal value As String)
                _PPHTIMEE = value
            End Set
        End Property

        Public Property ISNIGHT() As Boolean
            Get
                Return _ISNIGHT
            End Get
            Set(value As Boolean)
                _ISNIGHT = value
            End Set
        End Property

        Public Property PPUPDATE() As String
            Get
                Return _PPUPDATE
            End Get
            Set(ByVal value As String)
                _PPUPDATE = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New CPAPP16MDAO()
        End Sub

        Public Function GetAllYearData(ByVal PPIDNO As String, ByVal YYY As String) As DataTable
            Return DAO.GetAllYearData(PPIDNO, YYY)
        End Function

        Public Function CheckInsertDataHolidayDate() As String

            If String.IsNullOrEmpty(Me.PPHDATEB) OrElse String.IsNullOrEmpty(Me.PPHDATEE) OrElse _
                String.IsNullOrEmpty(Me.PPHTIMEB) OrElse String.IsNullOrEmpty(Me.PPHTIMEE) Then
                Return "假日執行公務起迄日期不可空白!"
            End If


            If (Double.Parse(Me.PPHDATEB & Me.PPHTIMEB) < Double.Parse(Me.PPBUSDATEB & Me.PPTIMEB)) Or _
                (Double.Parse(Me.PPHDATEE & Me.PPHTIMEE) > Double.Parse(Me.PPBUSDATEE & Me.PPTIMEE)) Then

                Return "假日執行公務起迄日超出公務起迄範圍，不可指定為假日執行公務!"
            End If

            Dim hdb As Date = DateTimeInfo.GetPublicDate(Me.PPHDATEB & Me.PPHTIMEB)
            Dim hde As Date = DateTimeInfo.GetPublicDate(Me.PPHDATEE & Me.PPHTIMEE)

            Dim pb02m As New CPAPB02M

            Dim hasHoliday As Boolean = False
            Dim offday As Boolean = False
            Do
                Dim PBDDATE As String = (hdb.Year - 1911).ToString().PadLeft(3, "0") & hdb.ToString("MMdd")

                Dim ht As Hashtable = Content.getWorkTime(Me.PPIDNO, PBDDATE)
                If ht IsNot Nothing AndAlso ht.Count > 0 Then
                    offday = CType(ht.Item("OFFDAY"), Boolean)
                End If

                If offday Then
                    hasHoliday = True
                End If
                If hdb.Date = hde.Date Then Exit Do
                hdb = hdb.AddDays(1)
            Loop

            If Not hasHoliday Then
                Return "假日執行公務起迄日期內無假日!不可指定為假日執行公務!"
            End If

            Me.PPHOLIDAY = "1"

            Return String.Empty
        End Function

        Public Function checkInsertData() As String

            'If String.IsNullOrEmpty(Me.PPREASON) Then
            '    Return "事由為必填欄位!"
            'End If

            'If Me.PPBUSDATEE < Me.PPBUSDATEB Then
            '    Return "申請日期起日不可大於迄日，請重新輸入!"
            'Else
            '    If Me.PPBUSDATEE = Me.PPBUSDATEB Then
            '        If Me.PPTIMEE < Me.PPTIMEB Then
            '            Return "申請日期起日不可大於迄日，請重新輸入!"
            '        End If
            '    End If
            'End If

            'If Me.PPHDATEE < Me.PPHDATEB Then
            '    Return "假日執行公務申請日期起日不可大於迄日，請重新輸入!"
            'Else
            '    If Me.PPHDATEE = Me.PPHDATEB Then
            '        If Me.PPHTIMEE < Me.PPHTIMEB Then
            '            Return "假日執行公務申請日期起日不可大於迄日，請重新輸入!"
            '        End If
            '    End If
            'End If

            'If Me.ISNIGHT Then
            '    If Me.PPBUSDATEB <> Me.PPBUSDATEE Then
            '        Throw New FlowException("夜間公差，起迄日需為同一天!")
            '    End If
            'End If

            ''If Me.Orgcode = "367030000D" Then
            ''    Dim ydate As Date = Now.AddDays(-1)
            ''    '昨天民國年日期
            ''    Dim yest As String = (ydate.Year - 1911).ToString.PadLeft(3, "0") & ydate.ToString("MMdd")
            ''    If Me.PPBUSDATEB < DateTimeInfo.GetRocDate(Now) And Content.computeDays(Me.PPBUSDATEB, yest) > 3 Then
            ''        Return "公差/公出需於差假發生日後3天內申請!"
            ''    End If
            ''ElseIf Me.Orgcode = "367000000D" Then
            ''Else
            ''    If Integer.Parse(Me.PPBUSDATEB) < (Integer.Parse(Now.ToString("yyyyMMdd")) - 19110000) Then
            ''        Return "非當日(或事前)申請之公差，請改以紙本假單申請!"
            ''    End If
            ''End If

            ''取得申請者的Metadb_id, 用來判斷連線的資料庫
            'Dim Metadb_id As String = New Member().GetColumnValue("Metadb_id", Me.PPIDNO)
            'Dim p2kconnstr As String = ConnectDB.GetCPADBString(Metadb_id)

            'Dim PEMEMCOD As String = New FSCPLM.Logic.CPAPE05M(p2kconnstr).GetColumnValue("PEMEMCOD", Me.PPIDNO)
            ''臨時人員
            'If PEMEMCOD = "4" Then
            '    Dim bll As New FSCPLM.Logic.FSC3710()
            '    Dim ofdt As DataTable = bll.getData(Orgcode, Me.PPIDNO, Me.PPBUSDATEB, Me.PPBUSDATEE)

            '    If ofdt Is Nothing Or ofdt.Rows.Count <= 0 Then
            '        Return "公出差日期起迄不在簽淮範圍內，請洽人事管理人員"
            '    End If
            'End If

            'Dim hours As Integer = 0
            'Dim Hhours As Integer = 0

            'If Me.PPHOLIDAY = "1" And ISNIGHT = False Then
            '    '有勾選假日執行公務
            '    Hhours = Content.computeHolidayWorkHour(Me.PPHDATEB, Me.PPHDATEE, Me.PPHTIMEB, Me.PPHTIMEE, Me.PPIDNO)
            '    Me.PPREASON = "「假日執行公務」" & Hhours & "小時，" & Me.PPREASON
            '    Me.PPBUSDH = Content.ConvertDayHours(hours + Hhours)

            'ElseIf ISNIGHT Then
            '    '夜間公差
            '    Hhours = Content.computeHourForBusiness(Me.PPBUSDATEB, Me.PPBUSDATEE, Me.PPTIMEB, Me.PPTIMEE, Me.PPIDNO)
            '    Me.PPBUSDH = Content.ConvertDayHours(hours + Hhours)
            'ElseIf Me.PPREASON.IndexOf("#奉(指)派上課#") >= 0 And Me.PPBUSPLACE.IndexOf("[公假]") >= 0 Then
            '    Hhours = Content.computeHolidayWorkHour(Me.PPHDATEB, Me.PPHDATEE, Me.PPHTIMEB, Me.PPHTIMEE, Me.PPIDNO)
            '    If Hhours > 0 Then
            '        Me.PPREASON = "「假日執行公務」" & Hhours & "小時，" & Me.PPREASON
            '        Me.PPBUSDH = Content.ConvertDayHours(hours + Hhours)
            '        Me.PPHOLIDAY = "1"
            '    Else
            '        Me.PPBUSDH = Content.ConvertDayHours(hours)
            '    End If
            'Else
            '    Me.PPBUSDH = Content.ConvertDayHours(hours)
            'End If

            'Me.PPHDAY = Content.ConvertDayHours(Hhours)

            'If PPBUSDH = 0.0 Then
            '    Return "公出差時數不可為0"
            'End If

            'Dim cpaDAO As New CPAPP16MDAO()

            'If (UpdateStatus) Then
            'Else
            '    Dim p2kdt As DataTable = cpaDAO.GetDataByDateTime(Me.PPBUSDATEB & Me.PPTIMEB, Me.PPBUSDATEE & Me.PPTIMEE, Me.PPIDNO, True)
            '    'p2k
            '    If p2kdt.Rows.Count > 0 Then
            '        Dim ss As String = String.Empty
            '        For Each dr As DataRow In p2kdt.Rows
            '            ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & "\n"
            '        Next
            '        ss = Mid(ss, 1, ss.Length - 1)
            '        Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重覆申請!"
            '    End If

            '    Dim plmdt As DataTable = DAO.GetDataByDateTime(Me.PPBUSDATEB & Me.PPTIMEB, Me.PPBUSDATEE & Me.PPTIMEE, Me.PPIDNO, False)
            '    'plm
            '    If plmdt.Rows.Count > 0 Then
            '        Dim ss As String = String.Empty
            '        For Each dr As DataRow In plmdt.Rows
            '            ss &= DateTimeInfo.ToDisplay(dr("dateb"), dr("timeb")) & "~" & DateTimeInfo.ToDisplay(dr("datee"), dr("timee")) & ","
            '        Next
            '        ss = Mid(ss, 1, ss.Length - 1)
            '        Return "您於請假日期期間已申請其它差假\n(" & ss & ")，\n不可重覆申請!"
            '    End If
            '    Return String.Empty
            'End If
            Return ""
        End Function

        Public Function GetData(PPIDNO As String, PPBUSTYPE As String, ByVal YearMonth As String) As DataTable
            Return DAO.GetQueryData(PPIDNO, PPBUSTYPE, YearMonth)
        End Function

        Public Function GetData(ByVal PPBUSTYPE As String, ByVal PPIDNO As String, ByVal PPBUSDATEB_S As String, ByVal PPBUSDATEB_E As String) As DataTable
            Dim dt As DataTable = DAO.getData(PPBUSTYPE, PPIDNO, PPBUSDATEB_S, PPBUSDATEB_E)
            Return dt
        End Function

        Public Function GetCPAPP16MByFlow_id(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As DataTable
            Return DAO.GetDataByFlow_id(Flow_id, Orgcode)
        End Function

        Public Function GetTimeIntervalByPPGUID(ByVal PPGUID As String) As DataTable
            Return DAO.GetTimeIntervalByPPGUID(PPGUID)
        End Function


        Public Function GetDataByPK(ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPBUSDATEB As String, ByVal PPTIMEB As String, ByVal PPREMARK As String) As DataTable
            Return DAO.GetDataByPK(PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB, PPREMARK)
        End Function

        Public Sub UpdateReMarkByCondition(ByVal PPBEFOREM As Integer, ByVal PPREMARK As String, ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPBUSDATEB As String, ByVal PPTIMEB As String)
            DAO.UpdateReMarkByCondition(PPBEFOREM, PPREMARK, PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB)
        End Sub

        Public Sub UpdateReMarkByGUID(ByVal PPGUID As String, ByVal PPREMARK As String)
            DAO.UpdateReMarkByGUID(PPGUID, PPREMARK)
        End Sub

        Public Function InsertCPAPP16M() As Integer
            Return DAO.InsertData(Me) = 1
        End Function

        ''' <summary>
        ''' for修改重送使用 jessica add 20131220
        ''' </summary>
        ''' <param name="isP2K"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateCPAPP16M(Optional ByVal isP2K As Boolean = False) As Integer
            Return DAO.UpdateCPAPP16M(Me, isP2K) = 1
        End Function
        '人立新增0710 for FSC3104_01
        Public Function GetDataByPpguid(ByVal flow_id As String) As DataTable
            Return DAO.GetDataByPpguid(flow_id)
        End Function

        Public Function DeleteCPAPP16MByGUID(ByVal Flow_id As String, Optional ByVal Orgcode As String = Nothing) As Boolean
            Return DAO.DeleteDataByGUID(Flow_id, Orgcode) = 1
        End Function

        Public Function UpdatePPPAYH(ByVal PPPAYH As Integer, ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPBUSDATEB As String, ByVal PPTIMEB As String) As Boolean
            Return DAO.UpdatePPPAYH(PPPAYH, PPIDNO, PPBUSTYPE, PPBUSDATEB, PPTIMEB) > 0
        End Function

        Public Function GetDataByOfficialFee(ByVal PPIDNO As String, ByVal PPBUSTYPE As String, ByVal PPGUID As String) As DataTable
            Return DAO.GetDataByOfficialFee(PPIDNO, PPBUSTYPE, PPGUID)
        End Function

    End Class
End Namespace