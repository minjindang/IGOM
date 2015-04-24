Imports Microsoft.VisualBasic
Imports System.Text
Imports System.Web
Imports System

Namespace FSC.Logic
    Public Class DateTimeInfo

#Region "Check Method"
        Public Function ChkDateTimeFormate(ByVal DateTimeInfo As String, ByVal TitleName As String) As String
            Dim MessageInfo As String = ""
            Dim objDateTime As Date = Date.MinValue
            Try
                If Not Date.TryParse(Convert.ToDateTime(DateTimeInfo.ToString()), objDateTime) Then
                End If
            Catch ex As Exception
                MessageInfo = TitleName + "必須是日期!"
                Return MessageInfo
            End Try
            If Not DateTime.TryParse(Convert.ToDateTime(DateTimeInfo.ToString()), objDateTime) Then
                MessageInfo = TitleName + "必須是日期!"
            End If
            Return MessageInfo
        End Function

        Public Function ChkAtLeastEnterOneDateTime(ByVal StartDate As String, ByVal EndDate As String) As String
            Dim MessageInfo As String = ""
            If StartDate = "" And EndDate = "" Then
                MessageInfo = "請輸入至少一個日期!"
            End If
            Return MessageInfo
        End Function

        Public Function ChkCompareDateRange(ByVal StartDate As Date, ByVal EndDate As Date) As String
            Dim MessageInfo As String = ""
            If StartDate > EndDate Then
                MessageInfo = "起始日必須小於等於結束日!"
            End If
            Return MessageInfo
        End Function
#End Region

#Region "Calculate Method"

        Public Shared Function ToDisplay(ByVal sdate As String, _
                                         Optional ByVal stime As String = "", _
                                         Optional ByVal symbol As String = "/") As String

            'If String.IsNullOrEmpty(sdate) Then _
            '    Return String.Empty

            Dim datetime As String = String.Empty

            ' 0980101 -> 098/01/01
            If sdate.Length = 7 Then _
                datetime = Mid(sdate, 1, 3) & symbol & Mid(sdate, 4, 2) & symbol & Mid(sdate, 6, 2)

            ' 20090101 -> 2009/01/01
            If sdate.Length = 8 Then _
                datetime = Mid(sdate, 1, 4) & symbol & Mid(sdate, 5, 2) & symbol & Mid(sdate, 7, 2)

            ' 0830 -> 08:30
            If stime.Length = 4 Then _
                datetime &= " " & Mid(stime, 1, 2) & ":" & Mid(stime, 3, 2)

            ' 09902 -> 099/02
            If sdate.Length = 5 Then _
                datetime = Mid(sdate, 1, 3) & symbol & Mid(sdate, 4, 2)

            Return datetime
        End Function

        Public Shared Function ToDisplayTime(ByVal stime As String, _
                                         Optional ByVal symbol As String = ":") As String

            'If String.IsNullOrEmpty(sdate) Then _
            '    Return String.Empty

            Dim datetime As String = String.Empty
            ' 0830 -> 08:30
            If stime.Length = 4 Then _
                datetime &= " " & Mid(stime, 1, 2) & symbol & Mid(stime, 3, 2)

            Return datetime
        End Function
        Public Shared Function formatDateTime(ByVal yyyMMddHHMMSS As String, Optional ByVal symbol As String = "/") As String
            If String.IsNullOrEmpty(yyyMMddHHMMSS) Then _
                Return String.Empty

            If yyyMMddHHMMSS.Length >= 11 Then
                Return ToDisplay(Mid(yyyMMddHHMMSS, 1, 7), symbol) & ToDisplayTime(Mid(yyyMMddHHMMSS, 8, 4))
            End If
            If yyyMMddHHMMSS.Length = 7 Then
                Return ConvertToDisplay(Mid(yyyMMddHHMMSS, 1, 7), symbol)
            End If

            Return String.Empty
        End Function

        Public Shared Function ConvertToDisplay(ByVal sdate As String, Optional ByVal symbol As String = "/") As String
            If String.IsNullOrEmpty(sdate) Then _
                Return String.Empty

            ' 0980101 -> 098/01/01
            If sdate.Length = 7 Then _
                Return Mid(sdate, 1, 3) & symbol & Mid(sdate, 4, 2) & symbol & Mid(sdate, 6, 2)

            ' 20090101 -> 2009/01/01
            If sdate.Length = 8 Then _
                Return Mid(sdate, 1, 4) & symbol & Mid(sdate, 5, 2) & symbol & Mid(sdate, 7, 2)

            Return String.Empty
        End Function

        Public Function ConvertToData(ByVal sdate As String, Optional ByVal symbol As String = "/") As String
            If String.IsNullOrEmpty(sdate) Then _
                Return String.Empty

            Dim datelist() As String = sdate.Split(symbol)

            If datelist.Length = 3 Then _
                Return datelist(0) & datelist(1) & datelist(2)

            Return String.Empty
        End Function

        Public Function ConvertToDisplayTime(ByVal sTime As String, Optional ByVal symbol As String = ":") As String
            If String.IsNullOrEmpty(sTime) Then _
                Return String.Empty

            If sTime.Length = 4 Then _
                Return Mid(sTime, 1, 2) & symbol & Mid(sTime, 3, 2)

            Return String.Empty
        End Function

        ''' <summary>
        ''' 將098/02/11的格式轉成日期, 可自訂splitter字元
        ''' </summary>
        ''' <param name="rocDate"></param>
        ''' <param name="splitter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetPublicDate(ByVal rocDate As String, Optional ByVal splitter As String = Nothing) As Date
            If String.IsNullOrEmpty(rocDate) Then
                Return Nothing
            End If
            Dim returnDate As Date

            If "" <> splitter Then
                Dim dateToken As String() = rocDate.Split(splitter)
                returnDate = New Date(1911 + Convert.ToInt32(dateToken(0)), Convert.ToInt32(dateToken(1)), Convert.ToInt32(dateToken(2)))

            ElseIf rocDate.Length = 11 Then

                returnDate = New Date(Integer.Parse(Mid(rocDate, 1, 3)) + 1911, Mid(rocDate, 4, 2), Mid(rocDate, 6, 2), Mid(rocDate, 8, 2), Mid(rocDate, 10, 2), 0)

            ElseIf rocDate.Length = 7 Then

                returnDate = New Date(1911 + Convert.ToInt32(rocDate.Substring(0, 3)), Convert.ToInt32(rocDate.Substring(3, 2)), Convert.ToInt32(rocDate.Substring(5, 2)))
            End If

            Return returnDate
        End Function

        ''' <summary>
        ''' 將098/02/11的格式轉成日期, 預設以/為splitter
        ''' </summary>
        ''' <param name="rocDate"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConvertRepublicStringToDate(ByVal rocDate As String) As Date
            Return GetPublicDate(rocDate, "/")
        End Function

        Public Shared Function GetTodayString() As String
            Return System.DateTime.Today.ToString("yyyy/MM/dd")
        End Function

        Public Shared Function GetRocTodayString(ByVal pattern As String) As String
            Dim dateStr As String = System.DateTime.Now.ToString(pattern)
            Dim year As String = (Integer.Parse(dateStr.Substring(0, 4)) - 1911).ToString()
            If Integer.Parse(year) < 100 Then
                year = "0" + year
            End If
            dateStr = year + dateStr.Substring(4, dateStr.Length - 4)
            Return dateStr
        End Function

        Public Shared Function GetRocDate(ByVal publicdate As Date) As String
            Return (publicdate.Year - 1911).ToString.PadLeft(3, "0") & publicdate.ToString("MMdd")
        End Function

        Public Shared Function GetRocDateTime(ByVal publicdatetime As Date) As String
            Return (publicdatetime.Year - 1911).ToString.PadLeft(3, "0") & publicdatetime.ToString("MMddHHmmss")
        End Function

#End Region

    End Class
End Namespace