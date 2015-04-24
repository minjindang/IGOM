Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports NLog
Imports System.Collections
Imports System
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPYYYS
        Private DAO As CPAPYYYSDAO

#Region "property"
        Private _PYIDNO As String
        Private _PYNAME As String
        Private _PYCARD As String
        Private _PYVTYPE As String
        Private _PYMON1 As String
        Private _PYMON2 As String
        Private _PYMON3 As String
        Private _PYMON4 As String
        Private _PYMON5 As String
        Private _PYMON6 As String
        Private _PYMON7 As String
        Private _PYMON8 As String
        Private _PYMON9 As String
        Private _PYMON10 As String
        Private _PYMON11 As String
        Private _PYMON12 As String
        Private _PYTOT As String
        Private _PYUSERID As String
        Private _PYUPDATE As String
        Public Property PYIDNO() As String
            Get
                Return _PYIDNO
            End Get
            Set(value As String)
                _PYIDNO = value
            End Set
        End Property
        Public Property PYNAME() As String
            Get
                Return _PYNAME
            End Get
            Set(value As String)
                _PYNAME = value
            End Set
        End Property
        Public Property PYCARD() As String
            Get
                Return _PYCARD
            End Get
            Set(value As String)
                _PYCARD = value
            End Set
        End Property
        Public Property PYVTYPE() As String
            Get
                Return _PYVTYPE
            End Get
            Set(value As String)
                _PYVTYPE = value
            End Set
        End Property
        Public Property PYMON1() As String
            Get
                Return _PYMON1
            End Get
            Set(value As String)
                _PYMON1 = value
            End Set
        End Property
        Public Property PYMON2() As String
            Get
                Return _PYMON2
            End Get
            Set(value As String)
                _PYMON2 = value
            End Set
        End Property
        Public Property PYMON3() As String
            Get
                Return _PYMON3
            End Get
            Set(value As String)
                _PYMON3 = value
            End Set
        End Property
        Public Property PYMON4() As String
            Get
                Return _PYMON4
            End Get
            Set(value As String)
                _PYMON4 = value
            End Set
        End Property
        Public Property PYMON5() As String
            Get
                Return _PYMON5
            End Get
            Set(value As String)
                _PYMON5 = value
            End Set
        End Property
        Public Property PYMON6() As String
            Get
                Return _PYMON6
            End Get
            Set(value As String)
                _PYMON6 = value
            End Set
        End Property
        Public Property PYMON7() As String
            Get
                Return _PYMON7
            End Get
            Set(value As String)
                _PYMON7 = value
            End Set
        End Property
        Public Property PYMON8() As String
            Get
                Return _PYMON8
            End Get
            Set(value As String)
                _PYMON8 = value
            End Set
        End Property
        Public Property PYMON9() As String
            Get
                Return _PYMON9
            End Get
            Set(value As String)
                _PYMON9 = value
            End Set
        End Property
        Public Property PYMON10() As String
            Get
                Return _PYMON10
            End Get
            Set(value As String)
                _PYMON10 = value
            End Set
        End Property
        Public Property PYMON11() As String
            Get
                Return _PYMON11
            End Get
            Set(value As String)
                _PYMON11 = value
            End Set
        End Property
        Public Property PYMON12() As String
            Get
                Return _PYMON12
            End Get
            Set(value As String)
                _PYMON12 = value
            End Set
        End Property
        Public Property PYTOT() As String
            Get
                Return _PYTOT
            End Get
            Set(value As String)
                _PYTOT = value
            End Set
        End Property
        Public Property PYUSERID() As String
            Get
                Return _PYUSERID
            End Get
            Set(value As String)
                _PYUSERID = value
            End Set
        End Property
        Public Property PYUPDATE() As String
            Get
                Return _PYUPDATE
            End Get
            Set(value As String)
                _PYUPDATE = value
            End Set
        End Property
#End Region

#Region "Log"
        Private _log As Logger
        Public Property Log As Logger
            Get
                Return _log
            End Get
            Set(value As Logger)
                _log = value
            End Set
        End Property
#End Region

        Public Sub New(ByVal yyy As String)
            DAO = New CPAPYYYSDAO("FSC_CPAP" & yyy & "S")
        End Sub


        Public Function GetData(ByVal pyidno As String, ByVal pyvtype As String) As DataTable
            Return DAO.GetQueryData(pyidno, pyvtype)
        End Function

        Public Function GetDataByIdno(ByVal Id_card As String, ByVal PYVTYPE As String) As DataTable
            Return DAO.GetQueryByIdno(Id_card, PYVTYPE)
        End Function

        Public Function Delete(ByVal YYY As String, ByVal PYIDNO As String, ByVal PYVTYPE As String) As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("PYIDNO", PYIDNO)
            If Not String.IsNullOrEmpty(PYVTYPE) Then
                d.Add("PYVTYPE", PYVTYPE)
            End If
            Return DAO.DeleteByExample("FSC_CPAP" & YYY & "S", d) >= 1
        End Function

        Public Function Insert(ByVal YYY As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("PYIDNO", PYIDNO)
            d.Add("PYNAME", PYNAME)
            d.Add("PYCARD", PYCARD)
            d.Add("PYVTYPE", PYVTYPE)
            d.Add("PYMON1", PYMON1)
            d.Add("PYMON2", PYMON2)
            d.Add("PYMON3", PYMON3)
            d.Add("PYMON4", PYMON4)
            d.Add("PYMON5", PYMON5)
            d.Add("PYMON6", PYMON6)
            d.Add("PYMON7", PYMON7)
            d.Add("PYMON8", PYMON8)
            d.Add("PYMON9", PYMON9)
            d.Add("PYMON10", PYMON10)
            d.Add("PYMON11", PYMON11)
            d.Add("PYMON12", PYMON12)
            d.Add("PYTOT", PYTOT)
            d.Add("PYUSERID", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
            d.Add("PYUPDATE", DateTimeInfo.GetRocDateTime(Now))
            Return DAO.InsertByExample("FSC_CPAP" & YYY & "S", d) >= 1
        End Function

        Public Function Update(ByVal YYY As String) As Boolean
            Dim cd As New Dictionary(Of String, Object)
            cd.Add("PYIDNO", PYIDNO)
            cd.Add("PYVTYPE", PYVTYPE)

            Dim d As New Dictionary(Of String, Object)
            d.Add("PYMON1", PYMON1)
            d.Add("PYMON2", PYMON2)
            d.Add("PYMON3", PYMON3)
            d.Add("PYMON4", PYMON4)
            d.Add("PYMON5", PYMON5)
            d.Add("PYMON6", PYMON6)
            d.Add("PYMON7", PYMON7)
            d.Add("PYMON8", PYMON8)
            d.Add("PYMON9", PYMON9)
            d.Add("PYMON10", PYMON10)
            d.Add("PYMON11", PYMON11)
            d.Add("PYMON12", PYMON12)
            d.Add("PYTOT", PYTOT)
            d.Add("PYUSERID", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
            d.Add("PYUPDATE", DateTimeInfo.GetRocDateTime(Now))
            Return DAO.UpdateByExample("FSC_CPAP" & YYY & "S", d, cd) >= 1
        End Function

        Public Function InsertProcess(ByVal idCard As String, _
                                      ByVal leaveType As String, _
                                      ByVal dateb As String, _
                                      ByVal TIMEB As String, _
                                      ByVal DATEE As String, _
                                      ByVal TIMEE As String, _
                                      ByVal isPlus As Boolean, _
                                      Optional ByVal Flow_id As String = Nothing) As Boolean

            Dim personnel As New FSC.Logic.Personnel()

            Dim PYIDNO As String = idCard
            Dim PYCARD As String = idCard
            Dim PYNAME As String = personnel.GetColumnValue("User_name", idCard).ToString()
            Dim PYMON As Double = 0.0
            Dim hours As Integer = 0

            Dim PYMON1 As Double = 0, PYMON2 As Double = 0, PYMON3 As Double = 0, PYMON4 As Double = 0, PYMON5 As Double = 0, PYMON6 As Double = 0
            Dim PYMON7 As Double = 0, PYMON8 As Double = 0, PYMON9 As Double = 0, PYMON10 As Double = 0, PYMON11 As Double = 0, PYMON12 As Double = 0
            Dim PYTOT As Double = 0

            If DAO.CheckHasTable() <= 0 Then
                DAO.CreateTABLE()
            End If

            If DAO.CheckHasData(PYIDNO) <= 0 Then
                DAO.InsertDefaultData(PYIDNO, PYCARD, PYNAME)
            End If

            If String.IsNullOrEmpty(DATEE) Then
                DATEE = dateb
            End If
            If String.IsNullOrEmpty(TIMEE) Then
                TIMEE = TIMEB
            End If

            Dim sdate As Date = DateTimeInfo.GetPublicDate(dateb & TIMEB)
            Dim edate As Date = DateTimeInfo.GetPublicDate(DATEE & TIMEE)

            Dim Start_date As String
            Dim Start_time As String
            Dim End_date As String
            Dim End_time As String


            Dim worktimeb As String = String.Empty
            Dim worktimee As String = String.Empty

            'If ht IsNot Nothing AndAlso ht.Count > 0 Then
            '    worktimeb = ht("WORKTIMEB").ToString()
            '    worktimee = ht("WORKTIMEE").ToString()
            'Else
            '    worktimeb = "0830"
            '    worktimee = "1730"
            'End If

            Dim tdate As Date = sdate

            Do
                Dim ht As Hashtable = Content.getWorkTime(idCard, DateTimeInfo.GetRocDate(tdate))
                If ht IsNot Nothing AndAlso ht.Count > 0 Then
                    worktimeb = ht("WORKTIMEB").ToString()
                    worktimee = ht("WORKTIMEE").ToString()
                End If

                Start_date = (tdate.Year - 1911).ToString.PadLeft(3, "0") & tdate.ToString("MMdd")
                End_date = (tdate.Year - 1911).ToString.PadLeft(3, "0") & tdate.ToString("MMdd")
                Start_time = IIf(tdate.Date = sdate.Date, tdate.ToString("HHmm"), worktimeb)
                End_time = IIf(tdate.Date = edate.Date, edate.ToString("HHmm"), worktimee)

                If leaveType = "05" Then
                    '公差時, 要計算假日的時間    
                    PYMON = Content.computeWorkHourIncludeHolidy(Start_date, End_date, Start_time, End_time, idCard)
                ElseIf leaveType = "57" Then
                    '忘刷卡
                    PYMON = 1
                Else
                    PYMON = Content.computeNotWorkHour(Start_date, End_date, Start_time, End_time, idCard)
                End If

                Select Case tdate.Month
                    Case 1
                        PYMON1 += PYMON
                    Case 2
                        PYMON2 += PYMON
                    Case 3
                        PYMON3 += PYMON
                    Case 4
                        PYMON4 += PYMON
                    Case 5
                        PYMON5 += PYMON
                    Case 6
                        PYMON6 += PYMON
                    Case 7
                        PYMON7 += PYMON
                    Case 8
                        PYMON8 += PYMON
                    Case 9
                        PYMON9 += PYMON
                    Case 10
                        PYMON10 += PYMON
                    Case 11
                        PYMON11 += PYMON
                    Case 12
                        PYMON12 += PYMON
                End Select

                If tdate.Date = edate.Date Then Exit Do
                tdate = tdate.AddDays(1)
            Loop

            If Not isPlus Then
                PYMON1 = 0 - PYMON1
                PYMON2 = 0 - PYMON2
                PYMON3 = 0 - PYMON3
                PYMON4 = 0 - PYMON4
                PYMON5 = 0 - PYMON5
                PYMON6 = 0 - PYMON6
                PYMON7 = 0 - PYMON7
                PYMON8 = 0 - PYMON8
                PYMON9 = 0 - PYMON9
                PYMON10 = 0 - PYMON10
                PYMON11 = 0 - PYMON11
                PYMON12 = 0 - PYMON12
            End If

            Dim dt As DataTable = DAO.GetDataByIdnoType(idCard, leaveType.PadLeft(2, "0"))

            If leaveType = "57" Then

                If dt.Rows.Count > 0 Then
                    PYMON1 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON1").ToString)
                    PYMON2 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON2").ToString)
                    PYMON3 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON3").ToString)
                    PYMON4 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON4").ToString)
                    PYMON5 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON5").ToString)
                    PYMON6 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON6").ToString)
                    PYMON7 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON7").ToString)
                    PYMON8 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON8").ToString)
                    PYMON9 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON9").ToString)
                    PYMON10 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON10").ToString)
                    PYMON11 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON11").ToString)
                    PYMON12 += CommonFun.ConvertToInt(dt.Rows(0)("PYMON12").ToString)
                End If

                PYTOT = PYMON1 + PYMON2 + PYMON3 + PYMON4 + PYMON5 + PYMON6 + PYMON7 + PYMON8 + PYMON9 + PYMON10 + PYMON11 + PYMON12

            Else

                If dt.Rows.Count > 0 Then
                    PYMON1 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON1").ToString))
                    PYMON2 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON2").ToString))
                    PYMON3 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON3").ToString))
                    PYMON4 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON4").ToString))
                    PYMON5 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON5").ToString))
                    PYMON6 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON6").ToString))
                    PYMON7 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON7").ToString))
                    PYMON8 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON8").ToString))
                    PYMON9 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON9").ToString))
                    PYMON10 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON10").ToString))
                    PYMON11 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON11").ToString))
                    PYMON12 += Content.ConvertToHours(Double.Parse(dt.Rows(0)("PYMON12").ToString))
                End If

                PYTOT = PYMON1 + PYMON2 + PYMON3 + PYMON4 + PYMON5 + PYMON6 + PYMON7 + PYMON8 + PYMON9 + PYMON10 + PYMON11 + PYMON12

                PYTOT = Content.ConvertDayHours(PYTOT)
                PYMON1 = Content.ConvertDayHours(PYMON1)
                PYMON2 = Content.ConvertDayHours(PYMON2)
                PYMON3 = Content.ConvertDayHours(PYMON3)
                PYMON4 = Content.ConvertDayHours(PYMON4)
                PYMON5 = Content.ConvertDayHours(PYMON5)
                PYMON6 = Content.ConvertDayHours(PYMON6)
                PYMON7 = Content.ConvertDayHours(PYMON7)
                PYMON8 = Content.ConvertDayHours(PYMON8)
                PYMON9 = Content.ConvertDayHours(PYMON9)
                PYMON10 = Content.ConvertDayHours(PYMON10)
                PYMON11 = Content.ConvertDayHours(PYMON11)
                PYMON12 = Content.ConvertDayHours(PYMON12)

            End If

            Dim PYVTYPE As String = leaveType.PadLeft(2, "0")
            Dim affact As Integer = 0

            Dim pydt As DataTable = DAO.GetQueryByIdno(idCard, PYVTYPE)

            If pydt IsNot Nothing AndAlso pydt.Rows.Count > 0 Then
                affact = DAO.UpdateData(PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYIDNO, leaveType.PadLeft(2, "0"))
            Else
                Dim d As New Dictionary(Of String, Object)
                d.Add("PYIDNO", PYIDNO)
                d.Add("PYNAME", PYNAME)
                d.Add("PYCARD", PYCARD)
                d.Add("PYVTYPE", PYVTYPE)
                d.Add("PYMON1", PYMON1)
                d.Add("PYMON2", PYMON2)
                d.Add("PYMON3", PYMON3)
                d.Add("PYMON4", PYMON4)
                d.Add("PYMON5", PYMON5)
                d.Add("PYMON6", PYMON6)
                d.Add("PYMON7", PYMON7)
                d.Add("PYMON8", PYMON8)
                d.Add("PYMON9", PYMON9)
                d.Add("PYMON10", PYMON10)
                d.Add("PYMON11", PYMON11)
                d.Add("PYMON12", PYMON12)
                d.Add("PYTOT", PYTOT)
                d.Add("PYUSERID", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                d.Add("PYUPDATE", DateTimeInfo.GetRocDateTime(Now))
                affact = DAO.InsertByExample("FSC_CPAP" & dateb.Substring(0, 3) & "S", d)
            End If

            Return affact = 1


        End Function


        Public Function UpdateDataByColumn(ByVal column As String, ByVal value As Double, ByVal pyidno As String, ByVal pyvtype As String) As Boolean

            Return DAO.UpdateDataByColumn(column, value, pyidno, pyvtype) = 1

        End Function


        Public Sub UpdateCPAPYYYS(ByVal YYY As String, _
                                  ByVal Orgcode As String, _
                                  ByVal Depart_id As String, _
                                  ByVal Sub_depart_id As String, _
                                  ByVal Id_card As String, _
                                  ByVal Personnel_id As String, _
                                  ByVal metadb_id As String)

            Log.Info("[CPAPYYYS][UpdateCPAPYYYS]")

            Dim po15m As New CPAPO15M()
            Dim pp16m As New CPAPP16M()

            Dim mem As DataTable = New FSC.Logic.Personnel().GetDataByIdCard(Id_card)

            For Each dr As DataRow In mem.Rows
                Log.Info("[NAME:" & dr("User_name").ToString() & "]")

                delete(YYY, dr("id_card").ToString(), "")

                Dim po15mdt As DataTable = po15m.GetAllYearData(dr("Id_card").ToString(), YYY)
                For Each podr As DataRow In po15mdt.Rows
                    Dim Idcard As String = podr("POIDNO").ToString()
                    Dim Leave_type As String = podr("POVTYPE").ToString()
                    Dim dateb As String = podr("POVDATEB").ToString()
                    Dim timeb As String = podr("POVTIMEB").ToString()
                    Dim datee As String = podr("POVDATEE").ToString()
                    Dim timee As String = podr("POVTIMEE").ToString()
                    InsertProcess(Idcard, Leave_type, dateb, timeb, datee, timee, True)
                Next


                Dim pp16mdt As DataTable = pp16m.GetAllYearData(dr("Id_card").ToString(), YYY)
                For Each ppdr As DataRow In pp16mdt.Rows
                    Dim Idcard As String = ppdr("PPIDNO").ToString()
                    Dim Leave_type As String = ppdr("PPBUSTYPE").ToString()
                    If Leave_type = "1" Then
                        Leave_type = "05"
                    ElseIf Leave_type = "2" Then
                        Leave_type = "07"
                    End If
                    Dim dateb As String = ppdr("PPBUSDATEB").ToString()
                    Dim timeb As String = ppdr("PPTIMEB").ToString()
                    Dim datee As String = ppdr("PPBUSDATEE").ToString()
                    Dim timee As String = ppdr("PPTIMEE").ToString()
                    InsertProcess(Idcard, Leave_type, dateb, timeb, datee, timee, True)
                Next

                If po15mdt.Rows.Count <= 0 And pp16mdt.Rows.Count <= 0 Then
                    '請改為如果沒有請任何的差假, 不要顯示查無資料, 其他欄位的日時數顯示為0
                    'hsien 102/2/1 無請假資料新增預設值
                    InsertDefValue(YYY, dr("Id_card").ToString(), dr("Personnel_id").ToString(), dr("User_name").ToString())
                End If

                'by jessica modi 20140107因造目前月份產生，而不是直接一次產生12月份
                ' For mm As Integer = 1 To 12
                For mm As Integer = 1 To Now.Month
                    Dim pk As New CPAPKYYMM(YYY & mm.ToString().PadLeft(2, "0"))
                    Dim num As Integer = pk.GetCountByPKWKTPE(dr("Personnel_id").ToString(), "3")
                    UpdateDataByColumn("PYMON" & mm, num, dr("Id_card").ToString(), "53")
                Next

            Next

        End Sub


        Public Sub InsertDefValue(ByVal YYY As String, _
                                  ByVal Id_card As String, _
                                  ByVal Personnel_id As String, _
                                  ByVal User_name As String)

            Dim defpy As New FSC.Logic.CPAPYYYS(YYY)

            defpy.PYIDNO = Id_card
            defpy.PYNAME = User_name
            defpy.PYCARD = Personnel_id
            defpy.PYMON1 = 0
            defpy.PYMON2 = 0
            defpy.PYMON3 = 0
            defpy.PYMON4 = 0
            defpy.PYMON5 = 0
            defpy.PYMON6 = 0
            defpy.PYMON7 = 0
            defpy.PYMON8 = 0
            defpy.PYMON9 = 0
            defpy.PYMON10 = 0
            defpy.PYMON11 = 0
            defpy.PYMON12 = 0
            defpy.PYTOT = 0
            defpy.PYUSERID = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            defpy.PYUPDATE = DateTimeInfo.GetRocDateTime(Now)

            For i As Integer = 1 To 25
                defpy.PYVTYPE = i.ToString().PadLeft(2, "0")
                defpy.Insert(YYY)
            Next

            defpy.PYVTYPE = "28"
            defpy.Insert(YYY)

            For i As Integer = 30 To 31
                defpy.PYVTYPE = i.ToString().PadLeft(2, "0")
                defpy.Insert(YYY)
            Next

            For i As Integer = 51 To 53
                defpy.PYVTYPE = i.ToString().PadLeft(2, "0")
                defpy.Insert(YYY)
            Next

            defpy.PYVTYPE = "55"
            defpy.Insert(YYY)

            defpy.PYVTYPE = "57"
            defpy.Insert(YYY)

        End Sub

    End Class
End Namespace