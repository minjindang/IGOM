Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections

Namespace FSC.Logic
    Public Class CPAPHYYMM
        Public DAO As CPAPHYYMMDAO

        Public Sub New(ByVal yymm As String)
            DAO = New CPAPHYYMMDAO("FSC_CPAPH" & yymm)
        End Sub

        Public Function GetFirstCard(ByVal PHICARD As String, ByVal IDNO As String, ByVal PHIDATE As String) As DataTable
            Return DAO.GetFirstCard(PHICARD, IDNO, PHIDATE)
            
        End Function

        Public Function GetListData(ByVal PHICARD As String, ByVal IDNO As String, ByVal PHIDATE As String) As DataTable
            Return DAO.GetListData(PHICARD, IDNO, PHIDATE)
           
        End Function

        Public Function GetUnNoramlData(ByVal PKCARD As String) As DataTable
            Return DAO.GetUnNoramlData(PKCARD)
           
        End Function

        Public Function DeleteCPAPKYYMM(ByVal PKCARD As String, ByVal PKWDATE As String) As Boolean
            Return DAO.DeleteData(PKCARD, PKWDATE) = 1
        End Function


        Public Function InsertCPAPHYYMM(ByVal PHADDR As String, ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHITIME As String, _
                                        ByVal PHITYPE As String, ByVal PHCARDVER As String) As Boolean
            Return DAO.InsertData(PHADDR, PHCARD, PHIDATE, PHITIME, PHITYPE, PHCARDVER) >= 1
        End Function

        Public Function UpdateDataOut(ByVal PHCARD As String, ByVal PHIDATE As String) As Boolean

            Return DAO.UpdateDataOut(PHCARD, PHIDATE) >= 1
        End Function


        Public Function DeleteCPAPHYYMM(ByVal PHADDR As String, _
                                        ByVal PHCARD As String, _
                                        ByVal PHIDATE As String, _
                                        ByVal PHITIME As String, _
                                        ByVal PHITYPE As String, _
                                        ByVal PHCARDVER As String) As Boolean

            Return DAO.DeleteData(PHADDR, PHCARD, PHIDATE, PHITIME, PHITYPE, PHCARDVER) >= 1
        End Function

        Public Function getAddWorkCardTime(ByVal PRIDNO As String, ByVal PRCARD As String, ByVal YM As String, ByVal PRADATE As String, ByVal STARTTIME As String, ByVal ENDTIME As String) As String()
            '先取得上,下時間
            Dim ht As Hashtable = Content.getWorkTime(PRIDNO, PRADATE)
            Dim offday As Boolean = False

            ' Dim PHITIME As String = ""
            Dim ADDSTIME As String = "未刷卡" '加班進
            Dim ADDETIME As String = "未刷卡" '加班出

            If ht IsNot Nothing Then
                Dim WORKTIMES As String = ht("WORKTIMEB").ToString() '上班時間
                Dim WORKTIMEE As String = ht("WORKTIMEE").ToString() '下班時間
                Dim NOONTIMEB As String = ht("NOONTIMEB").ToString() '午休起時間
                Dim NOONTIMEE As String = ht("NOONTIMEE").ToString() '午休迄時間
                '取得當日刷卡記錄
                Dim ph As New CPAPHYYMM(YM)
                Dim phdt As DataTable = ph.GetListData(PRCARD, PRIDNO, PRADATE)

                '例假日
                offday = CType(ht("OFFDAY"), Boolean)
                If offday Then
                    If phdt IsNot Nothing AndAlso phdt.Rows.Count > 0 Then
                        ADDSTIME = phdt.Rows(0)("PHITIME").ToString()
                        ADDETIME = phdt.Rows(phdt.Rows.Count - 1)("PHITIME").ToString()
                    End If
                Else
                    '平常日
                    Dim cnt As Integer = 0
                    Dim index As Integer = 0
                    Dim rowCnt As Integer = 0
                    For Each phdr As DataRow In phdt.Rows
                        rowCnt += 1
                        '取加班時間,從下班時間後的時間為主
                        If Content.getNumberTime(phdr("PHITIME").ToString()) >= Content.getNumberTime(WORKTIMEE) And Content.getNumberTime(STARTTIME) >= Content.getNumberTime(WORKTIMEE) Then
                            'And Content.getNumberTime(phdr("PHITIME").ToString()) >= Content.getNumberTime(STARTTIME) 
                            '第一筆為加班進
                            '第二筆為加班出
                            If cnt = 0 Then
                                '若為最後一筆
                                If rowCnt = phdt.Rows.Count Then
                                    'PHITIME 大於申請加班結束時間
                                    If Content.getNumberTime(phdr("PHITIME").ToString()) >= Content.getNumberTime(ENDTIME) Then
                                        ADDETIME = phdr("PHITIME").ToString()
                                    ElseIf Content.getNumberTime(phdr("PHITIME").ToString()) < Content.getNumberTime(ENDTIME) Then
                                        'PHITIME 小於申請加班結束時間
                                        ADDSTIME = phdr("PHITIME").ToString()
                                    End If
                                Else
                                    '若為第一筆大於下班時間的刷卡時間
                                    '先看是不是倒數第2筆,若是就認定為加班起時
                                    If index = 0 Then
                                        '下一筆小於申請時間
                                        Dim NextTime As String = phdt.Rows(rowCnt)("PHITIME").ToString()
                                        If Content.getNumberTime(STARTTIME) >= Content.getNumberTime(NextTime) Then

                                        Else
                                            'If (phdt.Rows.Count - rowCnt) = 1 Then
                                            ADDSTIME = phdr("PHITIME").ToString()
                                            cnt += 1
                                            'End If
                                        End If
                                    Else
                                        '排除掉下班和加班進同時間的問題
                                        '若同時間應捉第2筆的加班進
                                        If Content.getNumberTime(phdr("PHITIME").ToString()) = Content.getNumberTime(WORKTIMEE) Then
                                            If index > 0 Then
                                                ADDSTIME = phdr("PHITIME").ToString()
                                                cnt += 1
                                            End If
                                        Else
                                            ADDSTIME = phdr("PHITIME").ToString()
                                            cnt += 1
                                        End If
                                    End If
                                End If
                            ElseIf cnt = 1 Then

                                ADDETIME = phdr("PHITIME").ToString()
                                'cnt += 1

                            End If
                            index += 1
                            '20130402 Elbert上班前加班的案例
                            '上班前的第一卡為加班時間的進
                        ElseIf Content.getNumberTime(STARTTIME) <= Content.getNumberTime(WORKTIMES) Then
                            If cnt = 0 Then
                                '抓第一卡為加班進的時間,但必須比加班單迄的時間小
                                If Content.getNumberTime(phdr("PHITIME").ToString()) <= Content.getNumberTime(ENDTIME) Then
                                    ADDSTIME = phdr("PHITIME").ToString()
                                    cnt += 1
                                End If
                                '先抓大於加班單迄的第一卡當出,抓不到在以小於上班時間的前一卡當出
                            ElseIf Content.getNumberTime(phdr("PHITIME").ToString()) <= Content.getNumberTime(WORKTIMES) And cnt = 1 Then
                                '最後一卡
                                If (rowCnt = phdt.Rows.Count) Then
                                    ADDETIME = phdr("PHITIME").ToString()
                                ElseIf Content.getNumberTime(phdr("PHITIME").ToString()) > Content.getNumberTime(ENDTIME) Then
                                    ADDETIME = phdr("PHITIME").ToString()
                                    cnt += 1
                                ElseIf Content.getNumberTime(phdt.Rows(rowCnt)("PHITIME").ToString()) > Content.getNumberTime(WORKTIMES) Then
                                    ADDETIME = phdr("PHITIME").ToString()
                                    cnt += 1
                                End If
                            End If
                            '20130503 Elbert1200~1330中午加班的案例,詢問人事盧小姐,大於等於1200的第一張卡為進,小於等於1330的最後一卡為出
                        ElseIf (Content.getNumberTime(STARTTIME) >= Content.getNumberTime(NOONTIMEB)) And _
                            (Content.getNumberTime(ENDTIME) <= Content.getNumberTime(NOONTIMEE)) Then
                            If cnt = 0 Then
                                '抓大於午休時間第一卡為加班進的時間
                                If Content.getNumberTime(phdr("PHITIME").ToString()) >= Content.getNumberTime(NOONTIMEB) Then
                                    ADDSTIME = phdr("PHITIME").ToString()
                                    cnt += 1
                                End If
                                '以小於午休時間的最近的一張卡當出
                            ElseIf Content.getNumberTime(phdr("PHITIME").ToString()) <= Content.getNumberTime(NOONTIMEE) And cnt = 1 Then
                                '最後一卡
                                ADDETIME = phdr("PHITIME").ToString()
                            End If
                        End If
                    Next
                End If

            End If
            Dim reValue() As String = {ADDSTIME, ADDETIME}
            Return reValue
        End Function

        Public Function GetData(ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHITYPE As String) As DataTable
            Return DAO.getData(PHCARD, PHIDATE, PHITYPE)
        End Function

        Public Function GetData(ByVal PHCARD As String, ByVal PHIDATE As String) As DataTable
            Return DAO.GetData(PHCARD, PHIDATE)
        End Function

        Public Function get2122Data(ByVal orgcode As String, ByVal deaprt_id As String, ByVal PHCARD As String, _
                            ByVal PHCARD2 As String, ByVal Sdate As String, ByVal Edate As String) As DataTable
            Return DAO.get2122Data(orgcode, deaprt_id, PHCARD, PHCARD2, Sdate, Edate)
        End Function
    End Class
End Namespace