Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Configuration
Imports System.Web
Imports System
Imports System.Text

Namespace FSC.Logic

    Public Class Report

        Dim fileName As String = String.Empty
        Dim abFileName As String = String.Empty
        Dim deleteFileName As String = String.Empty
        Dim abDeleteFileName As String = String.Empty
        Dim currentDate As String = String.Empty
        Dim deleteDate As String = String.Empty

        Public Sub Report(ByVal sCurrentDate As String, ByVal Orgcode As String, ByVal dbname As String)
            Dim dateInfo As New FSCPLM.Logic.DateTimeInfo()
            currentDate = sCurrentDate
            abFileName = dbname & "-" & Now.ToString("yyyyMMddHHmm") & ".html"

            Dim today As Date = System.DateTime.Now
            Dim vDeleteDate As Date = today.AddDays(-20)
            deleteDate = FSCPLM.Logic.DateTimeInfo.GetRocDate(vDeleteDate)

            abDeleteFileName = deleteDate & "-" & dbname & ".html"

            Dim yearFolder As String = (Now.Year - 1911).ToString()
            Dim reportPath As String = ConfigurationManager.AppSettings("PKReportPath").ToString() & yearFolder & "\\" & currentDate & "\\"

            '將PhToPkReport建置與Server同一層
            'Dim realPath As String = HttpContext.Current.Server.MapPath("~")
            Dim realPath As String = HttpRuntime.AppDomainAppPath
            Dim folder As New DirectoryInfo(realPath)

            fileName = folder.FullName & reportPath & abFileName
            deleteFileName = folder.FullName & reportPath & yearFolder & abDeleteFileName

            create()
            delete()

        End Sub

        Public Sub create()
            Dim s As String = "<html><head><title>刷卡轉出勤報表</title></head><body><font color='#003399' size='4'>" + currentDate + "刷卡轉出勤報表</font>" + "<hr width='600' align='left'>"
            Try
                CommonFun.SaveFile(s, fileName)
            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            End Try
        End Sub

        Public Sub writeIn(ByVal reportDetail As ReportDetail)
            Dim leaveCondition As String = ""
            If Not reportDetail.list Is Nothing Then
                For Each c As String In reportDetail.list
                    leaveCondition = leaveCondition + c
                Next
            End If
            Dim s As New StringBuilder()
            s.Append("<table width='600' border='1' cellpadding='0' cellspacing='2'>")
            s.Append("<tr align='center' valign='middle' bgcolor='#000000'>")
            s.Append("<td width='100'><font color='#FFFFFF' size='2'>單位</font></td>")
            s.Append("<td width='100'><font color='#FFFFFF' size='2'>姓名</font></td>")
            s.Append("<td width='100'><font color='#FFFFFF' size='2'>卡號</font></td>")
            s.Append("<td width='100'><font color='#FFFFFF' size='2'>差勤組別</font></td>")
            s.Append("<td width='100'><font color='#FFFFFF' size='2'>上班別</font></td>")
            s.Append("<td width='100'><font color='#FFFFFF' size='2'>需刷中午卡</font></td>")
            s.Append("</tr>")
            s.Append("<tr align='center' valign='middle'>")
            s.Append("<td width='100'><font size='2'>&nbsp;" + reportDetail.department + "</font></td>")
            s.Append("<td width='100'><font size='2'>&nbsp;" + reportDetail.pename + "</font></td>")
            s.Append("<td width='100'><font size='2'>&nbsp;" + reportDetail.pecard + "</font></td>")
            s.Append("<td width='100'><font size='2'>&nbsp;" + reportDetail.pekind + "</font></td>")
            s.Append("<td width='100'><font size='2'>&nbsp;" + reportDetail.pewktype + "</font></td>")
            s.Append("<td width='100'><font size='2'>&nbsp;" + reportDetail.needNoonCard + "</font></td>")
            s.Append("</tr>")
            s.Append("<tr align='center' valign='middle'>")
            s.Append("<td width='100' bgcolor='#C8D7C6'><font size='2'>上班卡</font></td>")
            s.Append("<td width='100' bgcolor='#C8D7C6'><font size='2'>中午卡</font></td>")
            s.Append("<td width='100' bgcolor='#C8D7C6'><font size='2'>下班卡</font></td>")
            s.Append("<td width='100' bgcolor='#C8D7C6'><font size='2'>出勤時數</font></td>")
            s.Append("<td width='100' bgcolor='#C8D7C6'><font size='2'>應上班時數</font></td>")
            s.Append("<td width='100' bgcolor='#C8D7C6'><font size='2'>出勤狀況</font></td>")
            s.Append("</tr>")
            s.Append("<tr align='center' valign='middle'>")
            s.Append("<td><font size='2'>&nbsp;" + reportDetail.pkstime + "</font></td>")
            s.Append("<td><font size='2'>&nbsp;" + reportDetail.pkntime + "</font></td>")
            s.Append("<td><font size='2'>&nbsp;" + reportDetail.pketime + "</font></td>")
            s.Append("<td><font size='2'>&nbsp;" + Convert.ToString(reportDetail.actualWorkHour) + "</font></td>")
            s.Append("<td><font size='2'>&nbsp;" + Convert.ToString(reportDetail.workHour) + "</font></td>")
            s.Append("<td><font size='2'>&nbsp;" + reportDetail.pkwktpe + "</font></td>")
            s.Append("</tr>")
            s.Append("<tr valign='middle'>")
            s.Append("<td bgcolor='#C8D7C6' align='center'><font size='2'>差假狀況</font></td>")
            s.Append("<td colspan='5'><font size='2'>" + leaveCondition + "&nbsp;</font></td>")
            s.Append("</tr>")
            s.Append("</table>")
            s.Append("<br>")
            Try
                CommonFun.SaveFile(s.ToString(), fileName, FileMode.Append)
            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            End Try
        End Sub

        Public Sub delete()
            Try
                CommonFun.DeleteFile(deleteFileName)
            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace, ex.Message)
            End Try
        End Sub


    End Class

End Namespace