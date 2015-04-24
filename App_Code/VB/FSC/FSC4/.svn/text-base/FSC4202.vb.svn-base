Imports Microsoft.VisualBasic
Imports System.Data
Imports FSCPLM.Logic
Imports NLog
Imports System.Text
Imports System.Collections
Imports System

Namespace FSC.Logic

    Public Class FSC4202

        Private logger As Logger = LogManager.GetLogger("FSC4202")


        Public Sub Transfer(ByVal orgcode As String, _
                            ByVal departId As String, _
                            ByVal idCard As String, _
                            ByVal card As String, _
                            ByVal begintime As String, _
                            ByVal endtime As String, _
                            Optional ByVal transauto As Boolean = False)

            'Using plmconn As New SqlClient.SqlConnection(ConnectDB.GetDBString())

            Dim transall As Boolean = True

            Dim org As New FSC.Logic.Org()
            Dim depEmp As New FSC.Logic.DepartEmp()

            Dim report As New FSC.Logic.Report() '報表物件
            Dim pc03m As New FSC.Logic.CPAPC03M()
            Dim pb02m As New FSC.Logic.CPAPB02M()
            Dim normal As New FSC.Logic.TransferNormal()
            Dim flexible As New FSC.Logic.TransferFlexible()
            'Dim shift As New FSC.Logic.TransferShift()

            Dim pc03mht As Hashtable = pc03m.GetHashTableData()
            Dim psn As New FSC.Logic.Personnel()

            Dim pdt As DataTable
            If Not String.IsNullOrEmpty(departId) Or Not String.IsNullOrEmpty(idCard) Then
                pdt = psn.GetDataByQuery(orgcode, departId, "", idCard)
            Else
                pdt = psn.GetOnJobData()
            End If

            If pdt Is Nothing Or pdt.Rows.Count <= 0 Then
                Throw New Exception("無人員資料")
            End If

            While (endtime >= begintime)
                Dim currentDate As String = begintime
                Dim phyymm As New FSC.Logic.CPAPHYYMM(currentDate.Substring(0, 5))

                report.Report(currentDate, orgcode, "IGSSDBP")


                logger.Info("====" & currentDate & "====")

                For Each pr As DataRow In pdt.Rows
                    idCard = pr("id_card").ToString()
                    Dim yoyoCard As String = pr("Yoyo_card").ToString().Trim()
                    Dim userName As String = pr("User_name").ToString().Trim()
                    Dim pekind As String = pr("PEKIND").ToString().Trim()               '差勤規定組別
                    Dim shiftType As String = pr("Shift_type").ToString().Trim()         '上班別
                    Dim leftDate As String = pr("Left_date").ToString().Trim()         '離職日期
                    Dim actDate As String = pr("Act_date").ToString().Trim()         '到職日期

                    '轉出勤程式要判斷如果轉出勤日期小於人員資料設定的到職日
                    '則該員就不進行轉出勤
                    If CommonFun.getInt(actDate) > CommonFun.getInt(currentDate) Then
                        Continue For
                    End If

                    '判斷該人員當天是否在職中
                    If leftDate.Length > 0 Or CommonFun.getInt(actDate) > CommonFun.getInt(currentDate) Then
                        Continue For
                    End If

                    Try
                        If String.IsNullOrEmpty(departId) Then
                            departId = depEmp.GetDepartId(idCard)
                        End If

                        '開始取得cpapc03m資料
                        Dim hash As Hashtable = pc03mht.Item(pekind)

                        Dim offday As Boolean = pb02m.IsHoliday(currentDate)
                        Dim scheht As Hashtable = Content.GetWorkTime(orgcode, idCard, pekind, currentDate, hash)
                        If scheht Is Nothing Then
                            Continue For
                        End If

                        Dim reportDetail As FSC.Logic.ReportDetail = New FSC.Logic.ReportDetail()
                        reportDetail.department = org.GetDepartName(orgcode, departId)
                        reportDetail.peidno = idCard
                        reportDetail.pename = userName
                        reportDetail.pecard = yoyoCard
                        reportDetail.pekind = pekind
                        reportDetail.pewktype = shiftType
                        reportDetail.setPewkType(shiftType)


                        '取得刷卡資料
                        Dim phdt As DataTable = phyymm.GetData(idCard, currentDate)

                        '上班別：正常班、免刷卡
                        If (shiftType.Equals("0") Or shiftType.Equals("3")) Then

                            normal.Init(hash, phdt, pr, currentDate, offday, scheht)
                            normal.transfer(reportDetail, orgcode)

                            report.writeIn(reportDetail)
                        End If

                        '上班別：彈性
                        If (shiftType.Equals("1")) Then

                            flexible.Init(hash, phdt, pr, currentDate, offday, scheht)
                            flexible.transfer(reportDetail, orgcode)

                            report.writeIn(reportDetail)
                        End If

                        ''上班別：輪班
                        'If (pewktype.Equals("2")) Then

                        '    Dim pm13mdt As DataTable = New CPAPM13M().getDataByQuery(peorg, peunit, peidno, currentDate)
                        '    Dim pmstype As String = pm13mdt.Rows(0)("Pmstype").ToString()

                        '    If String.IsNullOrEmpty(pmstype) Or pmstype = "4" Then
                        '        Continue For
                        '    End If

                        '    shift.Init(hash, phyymm, pr, currentDate, pmstype)
                        '    shift.transfer(reportDetail)
                        '    report.writeIn(reportDetail)
                        'End If

                        logger.Info(userName & "(" & idCard & ") : done !")

                    Catch ex As Exception
                        logger.Info(userName & "(" & idCard & ") : " & ex.Message)
                    End Try

                Next

                If Not "".Equals(begintime.Trim()) Then
                    begintime = DateTimeInfo.GetRocDate(DateTimeInfo.GetPublicDate(begintime).AddDays(1))
                End If

            End While

            'End Using

        End Sub

    End Class

End Namespace