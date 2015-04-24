Imports System.Data.SqlClient

'
' Class pub \ AppLog
'

Namespace SALARY.Logic
    Partial Public Class pub
        '
        ' public common library
        '

        '//現在日期 + 現在時間 
        Shared Function show_now() As String '//現在日期 + 現在時間 
            show_now = Convert.ToDateTime(Now()).ToString("yyyyMMddHHmmss")
        End Function
        '// 現在日期 
        Shared Function Nowdate() As String '// 現在日期 
            Nowdate = Convert.ToDateTime(Now()).ToString("yyyyMMdd")
        End Function

        Const rn As String = vbCrLf
        '顯示國曆日期	
        Shared Function show_date(ByVal only_date) As String '顯示國曆日期	
            If System.String.IsNullOrEmpty(only_date) Or Not IsNumeric(only_date) Then
                show_date = ""
            Else
                show_date = get_zero((Left(only_date, 4) - 1911), 3) & "/" & Mid(only_date, 5, 2)
                If Mid(only_date, 7, 2) <> "" Then
                    show_date = show_date & "/" & Mid(only_date, 7, 2)
                End If

            End If

        End Function
        '顯示國曆日期時間
        Shared Function show_date_time(ByVal date_time) As String '顯示國曆日期時間
            Dim tt = ""

            tt = date_time

            If System.String.IsNullOrEmpty(date_time.ToString) Then
                show_date_time = ""
            Else
                show_date_time = (Left(tt, 4) - 1911) & "&nbsp;/&nbsp;" & Mid(tt, 5, 2) & "&nbsp;/&nbsp;" & Mid(tt, 7, 2) & "&nbsp;&nbsp;" & Mid(tt, 9, 2) & ":" & Mid(tt, 11, 2) & ":" & Mid(tt, 13, 2)
            End If

        End Function


        Shared Function show_trn_date(ByVal only_date) As String '顯示國曆日期	

            If System.String.IsNullOrEmpty(only_date) Or Not IsNumeric(only_date) Then
                show_trn_date = ""
            Else
                show_trn_date = get_zero((Left(only_date, 4) - 1911), 3) & Mid(only_date, 5, 2)
                If Mid(only_date, 7, 2) <> "" Then
                    show_trn_date = show_trn_date & Mid(only_date, 7, 2)
                End If
            End If

        End Function
        '
        Public Shared Function AppName() As String
            Dim rv As String = ""
            Try
                rv = ConfigurationManager.AppSettings("AppName")
            Catch ex As Exception
                pub.TraceWarn("pub.AppName", ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function AppNameWebConfig() As String
            Return pub.AppName()
        End Function
        Public Shared Function AppNameReal() As String
            Dim rv As String = ""
            Try
                Dim a2 As String = HttpContext.Current.Request.ServerVariables("PATH_INFO")
                Dim a3 As String = a2.Substring(1, a2.IndexOf("/", 1) - 1)
                rv = a3
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function AppConnectionStringDefaultName() As String
            Return "salaryConnectionString"
        End Function
        Public Shared Function CPAConnectionStringDefaultName() As String
            Return "CPAConnectionString"
        End Function
        ' 傳回連線字串
        Public Shared Function AppConnectionString() As String
            '
            ' 傳回 Web.config <configuration> <connectionStrings> <add name="ConnectionString" connectionString="" ...
            ' 所指派的 connectionString 字串內容
            ' 這裡所指派的 connectionString 字串內容, 即是 Enterprise Library Data Access Layer 預設所使用的資料庫連線字串
            '
            Dim rv As String = ""
            Try
                rv = System.Web.Configuration.WebConfigurationManager.ConnectionStrings(pub.AppConnectionStringDefaultName()).ConnectionString
            Catch ex As Exception
                pub.TraceWarn("pub.AppConnectionString", ex.ToString)
            End Try
            Return rv
            ' Return ConfigurationManager.ConnectionStrings("ConnectionStrings").ConnectionString
        End Function

        ' 傳回CPA連線字串
        Public Shared Function CPAConnectionString() As String
            '
            ' 傳回 Web.config <configuration> <connectionStrings> <add name="ConnectionString" connectionString="" ...
            ' 所指派的 connectionString 字串內容
            ' 這裡所指派的 connectionString 字串內容, 即是 Enterprise Library Data Access Layer 預設所使用的資料庫連線字串
            '
            Dim rv As String = ""
            Try
                rv = System.Web.Configuration.WebConfigurationManager.ConnectionStrings(pub.CPAConnectionStringDefaultName()).ConnectionString
            Catch ex As Exception
                pub.TraceWarn("pub.CPAConnectionString", ex.ToString)
            End Try
            Return rv
            ' Return ConfigurationManager.ConnectionStrings("ConnectionStrings").ConnectionString
        End Function

        '
        Public Shared Function AppSettings(ByVal Key As String) As String
            '
            '
            '
            Dim rv As String = ""
            Try
                rv = ConfigurationManager.AppSettings(Key)
            Catch ex As Exception
                pub.TraceWarn("pub.AppSettings", ex.ToString)
            End Try
            Return rv
        End Function

        ' HttpContext.Current.Trace.Warn(Category, Message)
        Public Shared Sub TraceWarn(ByVal Category As String, ByVal Message As String)
            '
            '
            '
            HttpContext.Current.Trace.Warn(Category, Message)
        End Sub

        ' HttpContext.Current.Trace.Write(Category, Message)
        Public Shared Sub TraceWrite(ByVal Category As String, ByVal Message As String)
            '
            '
            '
            HttpContext.Current.Trace.Write(Category, Message)
        End Sub


#Region " < ConnectionString > "

        '
        ' < ConnectionString >
        '
        Public Shared Function GetConfConnString() As String
            Dim rv As String = ""
            Try
                rv = ConfigurationManager.ConnectionStrings(pub.AppConnectionStringDefaultName()).ToString()
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.GetConfConnString()", "Exception: " & ex.ToString)
                rv = ex.Message
            End Try
            Return rv
        End Function

        Public Shared Function GetConfConnString(ByVal pConnStringName As String) As String
            Dim rv As String = ""
            Try
                rv = ConfigurationManager.ConnectionStrings(pConnStringName).ToString()
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.GetConfConnString()", _
                    "pConnStringName=""" & pConnStringName & """, Exception: " & ex.ToString)
                rv = ex.Message
            End Try
            Return rv
        End Function

        '
        ' < ConnectionString in AppSettings >
        '
        Public Shared Function GetConnectionString() As String

            Return AppSetting(pub.AppConnectionStringDefaultName())

        End Function

        Public Shared Function GetConnectionString(ByVal pConnectionStringKey As String) As String

            Dim v As String = ""
            Try
                v = AppSetting(pConnectionStringKey)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.GetConnectionString()", _
                    "pConnectionStringKey=""" & pConnectionStringKey & """, Exception: " & ex.ToString)
                v = ex.Message
            End Try
            Return v

        End Function

#End Region


#Region " < AppSettings > "

        '
        ' < AppSettings >
        '
        ''Public Shared Function AppSettings(ByVal pKey As String) As String
        ''    Dim v As String = ""
        ''    Try
        ''        v = System.Configuration.ConfigurationManager.AppSettings(pKey)
        ''        ''  v = ConfigurationSettings.AppSettings(pKey) '' .NET 1.x
        ''    Catch ex As Exception
        ''        HttpContext.Current.Trace.Warn("pub.AppSetting()", "pKey=""" & pKey & """, Exception: " & ex.ToString)
        ''        v = ex.Message
        ''    End Try
        ''    Return v
        ''End Function

        Public Shared Function AppSetting(ByVal pKey As String) As String
            Return AppSettings(pKey)
        End Function

        Public Shared Function GetSettings(ByVal pKey As String) As String
            Return AppSettings(pKey)
        End Function

        Public Shared Function GetAppSettings(ByVal pKey As String) As String
            Return AppSettings(pKey)
        End Function

#End Region


#Region " < Print \ Trace > "

        '
        ' < Print \ Trace >
        '
        Public Shared Sub PrintException(ByVal ex As Exception)
            Try
                If (Not ex Is Nothing) Then
                    HttpContext.Current.Trace.Warn("*", "Exception: " & vbCrLf & ex.ToString & vbCrLf)
                End If
            Catch exz As Exception
            End Try
        End Sub

        Public Shared Sub PrintException(ByVal message As String, ByVal ex As Exception)
            Try
                If (Not ex Is Nothing) Then
                    HttpContext.Current.Trace.Warn("*", message & vbCrLf & "Exception: " & vbCrLf & ex.ToString & vbCrLf)
                End If
            Catch exz As Exception
            End Try
        End Sub

        Public Shared Sub MessageBox_ScriptManager(ByVal Message As String, ByRef page As Page)
            ScriptManager.RegisterClientScriptBlock(page, GetType(Page), "alert", " alert(""" & Message & """); ", True)
        End Sub

        Public Shared Sub MessageBox(ByVal pMessage As String)
            HttpContext.Current.Response.Write("<script type='text/javascript' language='javascript'> alert('" & pMessage & "'); </script>" & vbCrLf)
        End Sub

        Public Shared Sub TraceMessageBox(ByVal pMessage As String)
            If (HttpContext.Current.Trace.IsEnabled) Then
                pub.MessageBox(pMessage)
            End If
        End Sub

        Public Shared Sub PrintTrace(ByVal pString As String)
            HttpContext.Current.Trace.Write(pString)
        End Sub

        Public Shared Sub PrintTraceWarn(ByVal pString As String)
            HttpContext.Current.Trace.Warn(pString)
        End Sub

        Public Shared Sub PrintTraceSqlIfConfigTrue(ByVal SQL As String)
            If (AppSettings("PrintSqlTraceIfConfigTrue").ToLower = "true") Then
                HttpContext.Current.Trace.Write("SQL", SQL)
            End If
        End Sub

        Public Shared Sub PrintSqlTraceIfConfigTrue(ByVal SQL As String)
            PrintTraceSqlIfConfigTrue(SQL)
        End Sub

        Public Shared Sub Print(ByVal pString As String)
            If (HttpContext.Current.Trace.IsEnabled) Then
                HttpContext.Current.Response.Write(pString)
            End If
        End Sub

        Public Shared Sub PrintL(ByVal pString As String)
            Print(pString & "<br/>")
        End Sub

        Public Shared Sub PrintDiv(ByVal pString As String)
            Print("<div>" & pString & "</div>")
        End Sub

        Public Shared Sub IfTracePrint(ByVal pString As String)
            If (HttpContext.Current.Trace.IsEnabled) Then
                Print(pString)
            End If
        End Sub

        Public Shared Sub IfTraceIsEnabledThenPrint(ByVal pString As String)
            IfTracePrint(pString)
        End Sub

        Public Shared Sub IfTracePrintL(ByVal pString As String)
            If (HttpContext.Current.Trace.IsEnabled) Then
                PrintL(pString)
            End If
        End Sub

        Public Shared Sub IfTracePrintDiv(ByVal pString As String)
            If (HttpContext.Current.Trace.IsEnabled) Then
                PrintDiv(pString)
            End If
        End Sub

        Public Shared Function IfTraceReturn(ByVal pString As String) As String
            If (HttpContext.Current.Trace.IsEnabled) Then
                Return pString
            Else
                Return ""
            End If
        End Function

        Public Shared Function IfTraceIsEnabledThenReturn(ByVal pString As String) As String
            Return IfTraceReturn(pString)
        End Function

        Public Shared Sub PrintLog(ByVal Log As String)
            HttpContext.Current.Response.Write(Log.Replace(";", ";<br />"))
        End Sub

#End Region


#Region " < Parse > "

        '
        ' < Parse >
        '
        Public Shared Function ParseInteger(ByVal pInteger As String) As Integer
            Dim rv As Integer = 0
            Try
                rv = Integer.Parse(pInteger)
            Catch ex As System.FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function ParseIntegerElse(ByVal pParseInteger As String, ByVal pElseReturnN As Integer) As Integer
            Dim rv As Integer = pElseReturnN
            Try
                rv = Integer.Parse(pParseInteger)
            Catch ex As System.FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function ParseLong(ByVal pLong As String) As Long
            Dim rv As Long = 0
            Try
                rv = Long.Parse(pLong)
            Catch ex As System.FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function ParseLongElse(ByVal pParseLong As String, ByVal pElseReturnN As Long) As Long
            Dim rv As Long = pElseReturnN
            Try
                rv = Integer.Parse(pParseLong)
            Catch ex As System.FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

#End Region


#Region " < Format \ DateTime > "

        '
        ' < Format \ DateTime >
        '

        ' MonthFirstDay ' 傳回某月第一天的日期 '
        Public Shared Function MonthFirstDay(ByVal pDate As Date) As Date
            Return DateSerial(Year(pDate), Month(pDate) - 1, 1)
        End Function

        ' MonthLastDay  ' 傳回某月最後一天的日期 '
        Public Shared Function MonthLastDay(ByVal pDate As Date) As Date
            Return DateAdd("d", -1, DateSerial(Year(Now), Month(Now), 1))
        End Function

        '傳回兩個日期之間的所有日期（ARRAY）
        Public Shared Function DateArrBetween(ByVal pDateS As Date, ByVal pDateE As Date) As ArrayList
            If (pDateS > pDateE) Then
                Return Nothing
            End If
            Dim rtnArr As New ArrayList
            Dim pdateW As Date = pDateS
            rtnArr.Add(pDateS)
            While pdateW <> pDateE
                pdateW = pdateW.AddDays(1)
                rtnArr.Add(pdateW)
            End While

            Return rtnArr
        End Function



        ' FormatDateTime 
        Shared Function FormatDateTime(ByVal pDateTime As String) As String
            Dim rv As String = ""
            Try
                If (Not String.IsNullOrEmpty(pDateTime)) Then
                    rv = Format(Convert.ToDateTime(pDateTime), "yyyy-MM-dd HH:mm:ss")
                End If
            Catch ex As FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ' FormatDateTime 
        Shared Function FormatDateTime(ByVal pDateTime As DateTime) As String
            HttpContext.Current.Trace.Warn("(i)", "pub.FormatDateTime")
            Dim rv As String = ""
            Try
                rv = Format(Convert.ToDateTime(pDateTime), "yyyy-MM-dd HH:mm:ss")
            Catch ex As FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ' FormatDate 
        Shared Function FormatDate(ByVal pDate As String) As String
            Dim rv As String = ""
            Try
                If (Not String.IsNullOrEmpty(pDate)) Then
                    rv = Format(Convert.ToDateTime(pDate), "yyyy-MM-dd")
                End If
            Catch ex As FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ' FormatDate 
        Shared Function FormatDate(ByVal pDate As Date) As String
            Dim rv As String = ""
            Try
                rv = Format(Convert.ToDateTime(pDate), "yyyy-MM-dd")
            Catch ex As FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ' FormatDateTime 
        Shared Function FormatDateTime(ByVal pDateTime As String, ByVal pFormat As String) As String
            Dim rv As String = ""
            Try
                If (Not String.IsNullOrEmpty(pDateTime)) Then
                    If (String.IsNullOrEmpty(pFormat)) Then
                        rv = Format(Convert.ToDateTime(pDateTime), "yyyy-MM-dd HH:mm:ss")
                    Else
                        rv = Format(Convert.ToDateTime(pDateTime), pFormat)
                    End If
                End If
            Catch ex As FormatException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ' CheckDateTimeBeginEnd 
        Public Shared Function CheckDateTimeBeginEnd(ByVal pBegin As DateTime, ByVal pEnd As DateTime) As Boolean
            If (DateTime.Compare(pBegin, pEnd) <= 0) Then
                Return True
            Else
                Return False
            End If
        End Function

        ' CheckDateTimeBeginEnd 
        Public Shared Function CheckDateTimeBeginEnd(ByVal pBeginDateTime As String, ByVal pEndDateTime As String) As Boolean
            Dim rv As Boolean = False
            Try
                If ((Not String.IsNullOrEmpty(pBeginDateTime)) AndAlso (Not String.IsNullOrEmpty(pEndDateTime))) Then
                    rv = pub.CheckDateTimeBeginEnd(DateTime.Parse(pBeginDateTime), DateTime.Parse(pEndDateTime))
                End If
            Catch ex As FormatException
                rv = False
            Catch ex As Exception
                rv = False
            End Try
            Return rv
        End Function

#End Region


#Region " < hash \ encrypt - MD5 \ SHA1 > "

        '
        ' < hash \ encrypt - MD5 \ SHA1 >
        '
        Public Shared Function MD5(ByVal pText As String) As String
            Return pub.MD5(pText)
        End Function

        Public Shared Function SHA1(ByVal pText As String) As String
            Return pub.HashSHA1(pText)
        End Function

        Public Shared Function HashMD5(ByVal pText As String) As String
            Dim rv As String = ""
            If (pText = "") Then
                ''  rv = ""
            Else
                rv = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( _
                        pText, System.Web.Configuration.FormsAuthPasswordFormat.MD5.ToString())
                ''  Return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pText, "md5")
            End If
            Return rv
        End Function

        Public Shared Function HashSHA1(ByVal pText As String) As String
            Dim rv As String = ""
            If (pText = "") Then
                ''  rv = ""
            Else
                rv = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile( _
                        pText, System.Web.Configuration.FormsAuthPasswordFormat.SHA1.ToString())
                ''  Return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pText, "sha1")
            End If
            Return rv
        End Function

        Public Shared Function en(ByVal p As String) As String
            Return ""
        End Function

#End Region


#Region " < GUID \ SN > "

        '
        ' < GUID \ SN >
        '
        Public Shared Function NewGuid() As String
            Return System.Guid.NewGuid.ToString.Trim()
        End Function

        Public Shared Function GuidNewID() As String
            Return System.Guid.NewGuid.ToString.Trim()
        End Function

        Public Shared Function Guid() As String
            Return System.Guid.NewGuid.ToString.Trim()
        End Function

        Public Shared Function GuidUpperString() As String
            Return System.Guid.NewGuid.ToString.Trim.Replace("-", "").ToUpper
        End Function

        Public Shared Function NewTimeSN() As String
            Dim t As DateTime = Now
            Return Format(t, "yyyyMMddHHmmssffff")
        End Function

        Public Shared Function NewTimeSNint() As Int64
            Dim rv As Int64 = 0
            Try
                rv = Int64.Parse(pub.NewTimeSN())
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.NewTimeSNint()", ex.ToString)
                rv = -1
            End Try
            Return rv
        End Function

        Public Shared Function NowSN() As String
            Return pub.NewTimeSN()
        End Function

#End Region


#Region " < String \ Regex > "

        '
        ' < String >
        '
        Shared Function AppPathRoot() As String
            Return Microsoft.VisualBasic.Left(HttpContext.Current.Request.Path, InStr(2, HttpContext.Current.Request.Path, "/"))
        End Function

        Shared Function UrlRoot() As String
            Return AppPathRoot()
        End Function

        Public Shared Function Regex(ByVal pRegex As String, ByVal pString As String) As Boolean
            Dim rv As Boolean = False
            Try
                rv = New System.Text.RegularExpressions.Regex(pRegex).Match(pString).Success
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.Regex(pRegex,pString)", _
                    "pRegex=""" & pRegex & """, pString=""" & pString & """, Exception: " & ex.ToString)
                rv = False
            End Try
            Return rv
        End Function

        Public Shared Function IsIntegerUnsigned(ByVal pInteger As String) As Boolean
            Return pub.Regex("^[1-9]\d*$", pInteger)
        End Function

        Public Shared Function IsIntegerUnsigned(ByVal pInteger As Integer) As Boolean
            Return pub.IsIntegerUnsigned(pInteger.ToString)
        End Function

        Public Shared Function GetStringMaxLength(ByVal pString As String, ByVal pStringLength As Integer) As String
            '
            '
            '
            Dim rv As String = ""
            Try
                If (pStringLength >= pString.Length) Then
                    rv = pString
                Else
                    rv = pString.Substring(0, pStringLength)
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.GetStringMaxLength()", "Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function GetStringMarkBeginToMarkEnd(ByVal pString As String, ByVal pMarkBegin As String, ByVal pMarkEnd As String) As String
            '
            ' 截取 從 標記 pMarkBegin 到 pMarkEnd 的字串
            '
            Dim rv As String = ""
            Try
                Dim pos1 As Integer = pString.IndexOf(pMarkBegin) + pMarkBegin.Length
                Dim pos2 As Integer = pString.IndexOf(pMarkEnd, pos1)
                rv = pString.Substring(pos1, pos2 - pos1)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.GetStringMarkBeginToMarkEnd(pString,pMarkBegin,pMarkEnd)", _
                    "pString=""" & pub.GetStringMaxLength(pString, 10) & "..."", " & _
                    "pMarkBegin=""" & pMarkBegin & """, pMarkEnd=""" & pMarkEnd & """, Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

#End Region


#Region " < SqlX > "

        '
        ' < SqlX >
        '
        Public Shared Function ReportSqlCommandParameters(ByRef cmd As System.Data.SqlClient.SqlCommand) As String
            '
            ' 列出, 傳回, SqlCommand 的 Parameters 集合裡所有 SqlParameter 的資料
            '
            Dim sb As StringBuilder = New StringBuilder
            Try
                For Each c As SqlParameter In cmd.Parameters
                    sb.Append(c.ParameterName & "=""" & c.Value & """, (SqlDbType=" & c.SqlDbType.ToString() & ", Size=" & c.Size & "); ")
                Next
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.ReportSqlCommandParameters()", ex.ToString)
                sb.Append(ex.Message)
            End Try
            Return sb.ToString()
        End Function

        Public Shared Function SqlDateMinValue() As String
            Return Date.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString).ToString("yyyy/MM/dd")
        End Function

        Public Shared Function SqlDateMaxValue() As String
            Return Date.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString).ToString("yyyy/MM/dd")
        End Function

        Public Shared Function SqlDateTimeMinValue() As String
            Return Date.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString).ToString("yyyy/MM/dd HH:mm:ss")
        End Function
        Public Shared Function SqlDateTimeMinValue(ByVal DateTimeFormat As String) As String
            Return Date.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString).ToString(DateTimeFormat)
        End Function

        Public Shared Function SqlDateTimeMaxValue() As String
            Return Date.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString).ToString("yyyy/MM/dd HH:mm:ss")
        End Function
        Public Shared Function SqlDateTimeMaxValue(ByVal DateTimeFormat As String) As String
            Return Date.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString).ToString(DateTimeFormat)
        End Function

#End Region


#Region " < File > "

        '
        ' < File >
        '

        Public Shared Function GetFileExtensionName(ByVal FileName As String) As String
            Dim fi As New System.IO.FileInfo(FileName)
            Return fi.Extension
        End Function

        Public Shared Function ServerMapPath(ByVal pPath As String) As String
            '
            '
            '
            Dim rv As String = ""
            Try
                rv = HttpContext.Current.Server.MapPath(pPath)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.ServerMapPath(pPath)", _
                    "pPath=""" & pPath & """, Exception: " & ex.ToString)
                rv = "~/DefaultPath/"
            End Try
            Return rv
        End Function

        Public Shared Function IsHttpPostedFileUploaded(ByRef pUploadFile As HttpPostedFile) As Boolean
            '
            ' 檢查...
            '
            Dim rv As Boolean = False
            Try
                If (pUploadFile IsNot Nothing) AndAlso (pUploadFile.ContentLength > 0) Then
                    rv = True
                Else
                    rv = False
                End If
            Catch ex As NullReferenceException
                HttpContext.Current.Trace.Warn("pub.IsHttpPostedFileUploaded()", ex.ToString)
            Catch ex As Exception
                Try
                    HttpContext.Current.Trace.Warn("pub.IsHttpPostedFileUploaded()", _
                        "pUploadFile.FileName=""" & pUploadFile.FileName & """, Exception: " & ex.ToString)
                Catch ex2 As NullReferenceException
                    HttpContext.Current.Trace.Warn("pub.IsHttpPostedFileUploaded()", ex.ToString)
                Catch ex2 As Exception
                    HttpContext.Current.Trace.Warn("pub.IsHttpPostedFileUploaded()", ex.ToString)
                End Try
            End Try
            Return rv
        End Function

        Public Shared Function FileTextWrite(ByVal pText As String, ByVal pFileName As String) As Integer
            '
            ' 寫入文字檔, 以覆寫原檔案方式
            '
            Dim rv As Integer = 0
            Try
                My.Computer.FileSystem.WriteAllText(pFileName, pText, False)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileTextWrite()", _
                    "pFileName=""" & pFileName & """, pText=""" & Left(pText, 20) & "..."", Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function FileTextWriteAppend(ByVal pText As String, ByVal pFileName As String) As Integer
            '
            ' 寫入文字檔, 以附加至原檔案內容方式
            '
            Dim rv As Integer = 0
            Try
                My.Computer.FileSystem.WriteAllText(pFileName, pText, True)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileTextWriteAppend()", _
                    "pFileName=""" & pFileName & """, pText=""" & Left(pText, 20) & "..."", Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function FileTextUTF8Write(ByVal pText As String, ByVal pFileName As String) As Integer
            '
            ' 寫入 UTF8 文字檔, 以覆寫原檔案方式
            '
            Dim rv As Integer = 0
            Try
                My.Computer.FileSystem.WriteAllText(pFileName, pText, False, System.Text.Encoding.UTF8)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileTextUTF8Write()", _
                    "pFileName=""" & pFileName & """, pText=""" & Left(pText, 20) & "..."", Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function FileTextUTF8WriteAppend(ByVal pText As String, ByVal pFileName As String) As Integer
            '
            ' 寫入 UTF8 文字檔, 以附加至原檔案內容方式
            '
            Dim rv As Integer = 0
            Try
                My.Computer.FileSystem.WriteAllText(pFileName, pText, True, System.Text.Encoding.UTF8)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileTextUTF8WriteAppend()", _
                    "pFileName=""" & pFileName & """, pText=""" & Left(pText, 20) & "..."", Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function FileTextRead(ByVal pFileName As String) As String
            Dim rv As String = ""
            Try
                rv = My.Computer.FileSystem.ReadAllText(pFileName)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileTextRead()", _
                    "pFileName=""" & pFileName & """, Exception: " & ex.ToString)
                rv = ex.Message
            End Try
            Return rv
        End Function

        Public Shared Function FileTextUTF8Read(ByVal pFileName As String) As String
            Dim rv As String = ""
            Try
                rv = My.Computer.FileSystem.ReadAllText(pFileName, System.Text.Encoding.UTF8)
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileTextRead()", _
                    "pFileName=""" & pFileName & """, Exception: " & ex.ToString)
                rv = ex.Message
            End Try
            Return rv
        End Function

        Public Shared Function FileDelete(ByVal pFileName As String) As Integer
            '
            ' 刪除檔案
            '
            Dim rv As Integer = -1
            Try
                My.Computer.FileSystem.DeleteFile(pFileName)
                rv = 1
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.FileDelete()", _
                    "pFileName=""" & pFileName & """, Exception: " & ex.ToString)
                rv = -2
            End Try
            Return rv
        End Function

        Public Shared Function FileIsExist(ByVal pFileName As String) As Boolean
            '
            ' 檔案是否存在
            '
            Return My.Computer.FileSystem.FileExists(pFileName)
        End Function

        Public Shared Function IsImgFile(ByVal pFileName As String) As Boolean
            '
            ' 判斷 是否 圖檔 ( .jpg \ .gif \ .png \ .jpeg \ .bmp )
            '
            Dim rv As Boolean = False
            Try
                Dim F As System.IO.FileInfo = New System.IO.FileInfo(pFileName)
                If (F.Extension.ToLower.Equals(".jpg")) Or (F.Extension.ToLower.Equals(".gif")) Or (F.Extension.ToLower.Equals(".png")) _
                    Or (F.Extension.ToLower.Equals(".jpeg")) Or (F.Extension.ToLower.Equals(".bmp")) Then
                    rv = True
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.IsImgFile()", _
                    "Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Function IsFileExt(ByVal pFileName As String, ByVal pFileExt As String) As Boolean
            Dim rv As Boolean = False
            Try
                Dim F As System.IO.FileInfo = New System.IO.FileInfo(pFileName)
                If (F.Extension.ToLower.Equals(("." & pFileExt).Replace("..", "."))) Then
                    rv = True
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("pub.IsImgFile()", _
                    "Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

#End Region

        Public Shared Function IsImgFile(ByVal pFileName As String, ByVal pFileNameExtensionMatrix As String) As Boolean
            '
            ' ( not completed )
            '
            Dim rv As Boolean = False
            Return rv
        End Function


#Region " < Application Log > "

        '
        '
        '
        Public Shared Function AppLog(ByVal pLogText As String) As Integer
            Return -1
        End Function

        Public Shared Function AppLog(ByVal pLogText As String, ByVal pLogCategory As String) As Integer
            Return -1
        End Function

        Public Shared Function AppLog(ByVal pLogText As String, ByVal pLogCategory As String, ByVal pLogPriority As Byte) As Integer
            Return -1
        End Function

#End Region


#Region " < Application \ Session > "

        Public Shared Function ApplicationGet(ByVal pApplicationName As String) As String
            Dim rv As String = String.Empty
            Try
                rv = CType(HttpContext.Current.Application(pApplicationName), String)
            Catch ex As System.NullReferenceException
                pub.TraceWarn("pub", "ApplicationGet(ByVal pApplicationName As String) As String" & vbCrLf & "Exception: " & vbCrLf & ex.ToString & vbCrLf)
            Catch ex As Exception
                pub.TraceWarn("pub", "ApplicationGet(ByVal pApplicationName As String) As String" & vbCrLf & "Exception: " & vbCrLf & ex.ToString & vbCrLf)
            End Try
            Return rv
        End Function

        Public Shared Sub ApplicationSet(ByVal pApplicationName As String, ByVal pApplicationValue As String)
            Try
                HttpContext.Current.Application.Lock()
                HttpContext.Current.Application(pApplicationName) = pApplicationValue
                HttpContext.Current.Application.UnLock()
            Catch ex As System.NullReferenceException
                pub.TraceWarn("pub", "ApplicationSet(ByVal pApplicationName As String, ByVal pApplicationValue As String), Exception: " & ex.ToString)
            Catch ex As Exception
                pub.TraceWarn("pub", "ApplicationSet(ByVal pApplicationName As String, ByVal pApplicationValue As String), Exception: " & ex.ToString)
            End Try
        End Sub

        Public Shared Function SessionGet(ByVal pSessionName As String) As String
            Dim rv As String = String.Empty
            Try
                rv = CType(HttpContext.Current.Session(pSessionName), String)
            Catch ex As System.NullReferenceException
                pub.TraceWarn("pub", "SessionGet(ByVal pSessionName As String) As String, Exception: " & ex.ToString)
            Catch ex As Exception
                pub.TraceWarn("pub", "SessionGet(ByVal pSessionName As String) As String, Exception: " & ex.ToString)
            End Try
            Return rv
        End Function

        Public Shared Sub SessionSet(ByVal pSessionName As String, ByVal pSessionValue As String)
            Try
                HttpContext.Current.Session(pSessionName) = pSessionValue
            Catch ex As System.NullReferenceException
                pub.TraceWarn("pub", "SessionSet(ByVal pSessionName As String, ByVal pSessionValue As String), Exception: " & ex.ToString)
            Catch ex As Exception
                pub.TraceWarn("pub", "SessionSet(ByVal pSessionName As String, ByVal pSessionValue As String), Exception: " & ex.ToString)
            End Try
        End Sub

        Public Shared Sub SessionClear(ByVal pSessionName As String)
            Try
                HttpContext.Current.Session(pSessionName) = Nothing
            Catch ex As System.NullReferenceException
                pub.TraceWarn("pub", "SessionClear(ByVal pSessionName As String), Exception: " & ex.ToString)
            Catch ex As Exception
                pub.TraceWarn("pub", "SessionClear(ByVal pSessionName As String), Exception: " & ex.ToString)
            End Try
        End Sub

#End Region


#Region " < Miscellaneous > "

        ' This \ ThisPage \ GetThis \

        ' GetThisUrl
        ' http://        + thisHost1   + /test1/test2/      + this.aspx       + "/" + v=123&x=456
        ' GetThisUrlHttp + GetThisHost + GetThisPathFolders + GetThisFileName + "?" + GetThisParams

        Public Shared Function GetThisUrl() As String
            ' http://192.168.111.222/test1/test2/this.aspx?v=123
            Return HttpContext.Current.Request.Url.ToString
        End Function

        Public Shared Function GetThisUrlHttp() As String
            If (HttpContext.Current.Request.ServerVariables("HTTPS").ToString = "off") Then
                Return "http://"
            Else
                Return "https://"
            End If
        End Function

        Public Shared Function GetThisHost() As String
            ' = 192.168.111.222
            ' = thisServer1
            ' = www.this.com
            Return HttpContext.Current.Request.Url.Host
        End Function

        Public Shared Function GetThisPathFolders() As String
            Return HttpContext.Current.Request.FilePath.Replace(GetThisFileName, "")
        End Function

        Shared Function GetThisFileName() As String
            ' = this.aspx
            Return Microsoft.VisualBasic.Right(HttpContext.Current.Request.Path, HttpContext.Current.Request.Path.Length - InStrRev(HttpContext.Current.Request.Path, "/"))
        End Function

        Public Shared Function GetThisParams() As String
            ' = v=123&x=456
            Return HttpContext.Current.Request.ServerVariables("QUERY_STRING").ToString
        End Function

        '

        Shared Function GetThisLastFolderName() As String
            ' = ~/test1/test2/this.aspx ---> test2
            Return Microsoft.VisualBasic.Left(HttpContext.Current.Request.Path, InStrRev(HttpContext.Current.Request.Path, "/") - 1).Replace(Microsoft.VisualBasic.Left(HttpContext.Current.Request.Path, InStrRev(Microsoft.VisualBasic.Left(HttpContext.Current.Request.Path, InStrRev(HttpContext.Current.Request.Path, "/") - 1), "/")), "")
        End Function

        Public Shared Function GetThisApplicationPath() As String
            Return HttpContext.Current.Request.ApplicationPath
        End Function

        Public Shared Function GetThisApplicationPathName() As String
            Return HttpContext.Current.Request.ApplicationPath.Replace("/", "")
        End Function


#End Region



        Public Shared Function RequestQueryString(ByVal QueryName As String) As String
            Dim rv As String = ""
            Try
                rv = HttpContext.Current.Request.QueryString(QueryName)
            Catch ex As NullReferenceException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function RequestForm(ByVal name As String) As String
            Dim rv As String = ""
            Try
                rv = HttpContext.Current.Request.Form(name)
            Catch ex As NullReferenceException
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ' ParseX
        '   ParseDateTime, ParseInt, ParseBigInt
#Region " <  ' ParseX > "

        Public Shared Function ParseDate(ByVal s As String) As Date
            Dim rv As Date = Nothing
            Try
                rv = Date.Parse(s)
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function ParseDateNothing(ByVal s As String) As Date
            If (s = "") Then
                Return Nothing
            Else
                Dim rv As Date = Nothing
                Try
                    rv = Date.Parse(s)
                Catch ex As Exception
                End Try
                Return rv
            End If
        End Function

        Public Shared Function ParseIntNothing(ByVal i As String) As Integer
            If (i = "") Then
                Return Nothing
            Else
                Dim rv As Integer = Nothing
                Try
                    rv = Integer.Parse(i)
                Catch ex As Exception
                End Try
                Return rv
            End If
        End Function

#End Region


        '
        Public Shared Function DateADoROC(ByVal pNow As Date) As String
            Dim vYear As Integer = pNow.Year
            Dim rv As String = (vYear - 1911).ToString & pub.FormatDateTime(pNow, "/MM/dd HH:mm:ss")
            Return rv
        End Function
        Public Shared Function DateADoShortROC(ByVal pNow As Date) As String
            Dim vYear As Integer = pNow.Year
            Dim rv As String = (vYear - 1911).ToString & pub.FormatDateTime(pNow, "MMdd")
            Return rv
        End Function
        Public Shared Function DateROCoAD(ByVal pDate As String) As String

            Dim rv As String = String.Empty
            Dim date1 As Date = Nothing
            Dim yyyy As Integer = 0
            Dim a1 As Integer = 0
            Dim a2 As Integer = 0

            Try
                a1 = pDate.IndexOf("/")
                a2 = pDate.Length - a1
                yyyy = Integer.Parse(pDate.Substring(0, pDate.IndexOf("/"))) + 1911
                date1 = Date.Parse(yyyy.ToString & pDate.Substring(a1, a2))

                rv = pub.FormatDateTime(date1)

            Catch ex As Exception
                rv = String.Empty
            Finally
            End Try

            Return rv
        End Function


        ' GridView 內容輸出為 Excel 檔案下載 '
#Region "....' GridView 內容輸出為 Excel 檔案下載 ' "

        Public Shared Sub GridViewExporttoExcel(ByVal pExcelFileName As String, ByVal pGridView As GridView)

            Dim oStringWriter As New System.IO.StringWriter()
            Dim oHtmlTextWriter As New HtmlTextWriter(oStringWriter)
            Dim oExcelFileName As String = "test.xls"

            HttpContext.Current.Response.ContentType = "application/x-excel"
            '   Context.Response.ContentType = "application/x-excel"
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" & HttpContext.Current.Server.UrlEncode(oExcelFileName))
            '   Context.Response.AddHeader("content-disposition", "attachment;filename=" & Server.UrlEncode(oExcelFileName))
            pGridView.RenderControl(oHtmlTextWriter)
            HttpContext.Current.Response.Write(oStringWriter)
            '   Context.Response.Write(oStringWriter)
            HttpContext.Current.Response.End()
            '   Context.Response.End()

            '          '
            ' 必需步驟 '
            '          '
            '
            ' v 設定 .aspx EnableEventValidation="false"
            '
            ' v 覆寫 VerifyRenderingInServerForm 方法
            '   Public Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)
            '       ' MyBase.VerifyRenderingInServerForm(control)
            '   End Sub

        End Sub

#End Region


        ' GetAddressText '
        Public Shared Function GetAddressText(ByVal AddressMX As String, ByRef ReturnMessage As StringBuilder) As String

            ''( v 更改為新的地址格式判斷 , 加入"街"的資料 ; )
            Return "" '' AppCon.GetAddressText(AddressMX)

            ''Dim rv As String = ""
            ''Dim mxAddress As String() = AddressMX.Split("|")
            ''Dim mxAddressText As String() = {"路", "段", "巷", "弄", "號", "樓"}

            ''Try
            ''    If (mxAddress.Length <> mxAddressText.Length) Then
            ''        Throw New Exception("地址格式不正確, 正確格式應該為: ""aa路|bb段|cc巷|dd弄|ee號|ff樓"" ")
            ''    Else
            ''        For i As Integer = 0 To mxAddress.Length - 1
            ''            If (Not String.IsNullOrEmpty(mxAddress(i))) Then
            ''                rv &= mxAddress(i) & mxAddressText(i)
            ''            End If
            ''        Next
            ''    End If
            ''Catch ex As Exception
            ''    If (Not ReturnMessage Is Nothing) Then
            ''        ReturnMessage.Append("Exception||" & ex.ToString() & rn)
            ''    End If
            ''End Try

            ''Return rv
        End Function
        Public Shared Function GetAddressText(ByVal AddressMX As String) As String

            ''( v 更改為新的地址格式判斷 , 加入"街"的資料 ; )
            Return "" '' AppCon.GetAddressText(AddressMX)

            ''Dim rv As String = ""
            ''Dim mxAddress As String() = AddressMX.Split("|")
            ''Dim mxAddressText As String() = {"路", "段", "巷", "弄", "號", "樓"}
            ''Try
            ''    If (mxAddress.Length <> mxAddressText.Length) Then
            ''        rv = ""
            ''        ''Throw New Exception("地址格式不正確, 正確格式應該為: ""aa路|bb段|cc巷|dd弄|ee號|ff樓"" ")
            ''    Else
            ''        For i As Integer = 0 To mxAddress.Length - 1
            ''            If (Not String.IsNullOrEmpty(mxAddress(i))) Then
            ''                rv &= mxAddress(i) & mxAddressText(i)
            ''            End If
            ''        Next
            ''    End If
            ''Catch ex As Exception
            ''    rv = ""
            ''    ''If (Not ReturnMessage Is Nothing) Then
            ''    ''    ReturnMessage.Append("Exception||" & ex.ToString() & rn)
            ''    ''End If
            ''End Try

        End Function


        Public Shared Function IsProductionApplication() As Boolean
            Dim rv As Boolean = False
            Try
                If (pub.IsProductionServer() AndAlso pub.AppNameWebConfig.ToLower.Equals(pub.AppNameReal.ToLower())) Then
                    rv = True
                End If
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function IsProductionServer() As Boolean
            Dim rv As Boolean = False
            Try
                If (pub.GetProductionServerIP.Equals(pub.GetProductionServerIP_WebConfig())) Then
                    rv = True
                End If
            Catch ex As Exception
            End Try
            Return rv
        End Function

        Public Shared Function GetProductionServerIP() As String
            Dim rv As String = ""
            Try
                rv = HttpContext.Current.Request.ServerVariables("HTTP_HOST")
            Catch ex As Exception
            End Try
            Return rv
        End Function
        Public Shared Function GetProductionServerIP_WebConfig() As String
            Dim rv As String = ""
            Try
                rv = pub.AppSettings("ServerIP")
            Catch ex As Exception
            End Try
            Return rv
        End Function

        '===================================================================================================
        Public Shared Function SelectParamsText(ByVal p As String) As String
            Dim rv As String = "%"
            If (Not String.IsNullOrEmpty(p)) Then
                rv = p
            End If
            Return rv
        End Function
        Public Shared Function SelectParamsTextLike(ByVal p As String) As String
            Dim rv As String = "%"
            If (Not String.IsNullOrEmpty(p)) Then
                rv = "%" & p & "%"
            End If
            Return rv
        End Function

        '===================================================================================================

        Public Shared Function HtmltoText(ByVal pHtml As String) As String
            Dim rv As String = ""
            Dim re As New Regex("<[^>]+>")
            rv = re.Replace(pHtml, "")
            Return rv
        End Function

        '===================================================================================================
        Public Shared Function IsTodaySundayOrSaturday() As Boolean
            Dim rv As Boolean = False
            If (Now.DayOfWeek.ToString.ToLower.Equals("sunday") Or Now.DayOfWeek.ToString.ToLower.Equals("saturday")) Then
                rv = True
            End If
            Return rv
        End Function

        '===================================================================================================
        'Cookies
        Public Shared Function CookiesClear(ByVal name As String) As String
            Dim rv As String = ""
            Try
                HttpContext.Current.Response.Cookies(name).Value = ""
                HttpContext.Current.Response.Cookies(name).Expires = Now.AddSeconds(-1)
                rv = name
            Catch ex As Exception
                rv = ex.Message
            End Try
            Return rv
        End Function

        Public Shared Function CookiesWrite(ByVal name As String, ByVal value As String) As String
            Dim rv As String = ""
            Try
                HttpContext.Current.Response.Cookies(name).Value = value
                rv = name
            Catch ex As Exception
                rv = ex.Message
            End Try
            Return rv
        End Function

        Public Shared Function CookiesWrite(ByVal name As String, ByVal value As String, ByVal expires As Date) As String
            Dim rv As String = ""
            Try
                HttpContext.Current.Response.Cookies(name).Value = value
                HttpContext.Current.Response.Cookies(name).Expires = expires
                rv = name
            Catch ex As Exception
                rv = ex.Message
            End Try
            Return rv
        End Function

        Public Shared Function CookiesRead(ByVal name As String) As String
            Dim rv As String = ""
            Try
                rv = HttpContext.Current.Request.Cookies(name).Value
            Catch ex As Exception
                ''rv = ex.Message
            End Try
            Return rv
        End Function

        ''( * 如果 Integer Parse 失敗 , 則傳回 Nothing ; )
        Public Shared Function ParseNullableOfInteger(ByVal Value As String) As Nullable(Of Integer)
            Dim rv As Nullable(Of Integer) = -1
            Try
                If (Value.ToLower.Equals("true")) Then
                    rv = 1
                ElseIf (Value.ToLower.Equals("false")) Then
                    rv = 0
                Else
                    rv = Integer.Parse(Value)
                End If
            Catch ex As System.InvalidOperationException
                rv = Nothing
            Catch ex As Exception
                rv = Nothing
            End Try
            Return rv
        End Function
        Public Shared Function ParseNullableOfBoolean(ByVal Value As String) As Nullable(Of Boolean)
            Dim rv As Nullable(Of Boolean) = False
            Try
                rv = Boolean.Parse(Value)
            Catch ex As System.InvalidOperationException
                rv = Nothing
            Catch ex As Exception
                rv = Nothing
            End Try
            Return rv
        End Function
        Public Shared Function ParseNullableOfLong(ByVal Value As String) As Nullable(Of Long)
            Dim rv As Nullable(Of Long) = -1
            Try
                rv = Long.Parse(Value)
            Catch ex As System.InvalidOperationException
                rv = Nothing
            Catch ex As Exception
                rv = Nothing
            End Try
            Return rv
        End Function
        Public Shared Function ParseNullableOfDate(ByVal Value As String) As Nullable(Of Date)
            Dim rv As Nullable(Of Date) = Now
            Try
                rv = Date.Parse(Value)
            Catch ex As System.InvalidOperationException
                rv = Nothing
            Catch ex As Exception
                rv = Nothing
            End Try
            Return rv
        End Function

        Public Shared Sub JavaScript(ByVal pPage As System.Web.UI.Page, ByVal pName As String, ByVal pJavaScriptString As String)
            ScriptManager.RegisterClientScriptBlock(pPage, GetType(Page), pName, pJavaScriptString, True)
        End Sub

        Public Shared Function ConvertWideStringToNarrow(ByVal s As String) As String
            Return StrConv(s, VbStrConv.Narrow)
        End Function

        Public Shared Function CaseDataColumn(ByVal Text As String) As String ''( 全形轉半形 , 去除空白字元 )
            Return pub.ConvertWideStringToNarrow(Text.Trim.Replace(" ", ""))
        End Function

        Public Shared Function Convert01toFalseTrue(ByVal p As String) As String
            Dim rv As String = p
            Select Case p.ToLower
                Case "0" : rv = "False"
                Case "1" : rv = "True"
                Case Else : rv = p
            End Select
            Return rv
        End Function

        Public Shared Function ConvertTrueFalseTo10(ByVal p As String) As String
            Dim rv As String = ""
            Select Case p.ToLower
                Case "true" : rv = "1"
                Case "false" : rv = "0"
                Case Else : rv = ""
            End Select
            Return rv
        End Function

        Public Shared Function ConvertTrueFalseToYN(ByVal p As String) As String
            Dim rv As String = ""
            Select Case p.ToLower
                Case "true" : rv = "Y"
                Case "false" : rv = "N"
                Case Else : rv = ""
            End Select
            Return rv
        End Function

        Public Shared Function ConvertYNtoTrueFalse(ByVal p As String) As String
            Dim rv As String = ""
            Select Case p.ToLower
                Case "y" : rv = "True"
                Case "n" : rv = "False"
                Case Else : rv = ""
            End Select
            Return rv
        End Function

        Public Shared Function img00(ByVal Name As String) As String
            Return "<img src='" & pub.AppPathRoot & "img/00/" & Name & "' alt='' align='absmiddle' />&nbsp;"
        End Function
        Public Shared Function img00(ByVal Name As String, ByVal Alt As String) As String
            Return "<img src='" & pub.AppPathRoot & "img/00/" & Name & "' alt=' " & Alt & " ' align='absmiddle' />&nbsp;"
        End Function

        Public Shared Function ExceptionDiv(ByVal pExceptionMessage As String) As String
            Dim rv As String = ""
            If (Not String.IsNullOrEmpty(pExceptionMessage)) Then
                rv = "<div style='color:red;'>" & pExceptionMessage & "</div>"
            End If
            Return rv
        End Function


        Public Shared Function get_zero(ByVal num, ByVal lenth) As String
            Dim rv As String = ""
            Dim nums As String = CStr(num)

            If Len(nums) < lenth Then     '如果小於位數補0
                For add_count As Integer = 1 To lenth - Len(nums)
                    nums = "0" & nums
                Next
            End If

            Return Right(nums, lenth)  '如果大等於位數,從右取位數
        End Function

        Public Shared Sub GotoPage(ByVal URL As String)
            HttpContext.Current.Response.Write("<script type='text/javascript' language='javascript'> location.href='" & URL & "'; </script>" & vbCrLf)
        End Sub

        Public Shared Sub GotoPage(ByVal URL As String, ByVal message As String)
            HttpContext.Current.Response.Write("<script type='text/javascript' language='javascript'> alert('" & message & "'); location.href='" & URL & "'; </script>" & vbCrLf)
        End Sub

        Public Shared Sub GotoPage(ByVal p As Page, ByVal URL As String)
            pub.JavaScript(p, "GotoURL", "location.href='" & URL & "';")
        End Sub

        Public Shared Sub GotoPage(ByVal p As Page, ByVal URL As String, ByVal message As String)
            pub.JavaScript(p, "GotoURL", "alert('" & message & "'); location.href='" & URL & "';")
        End Sub

        Public Shared Function AppAspxURL(ByVal URL As String) As String
            Return URL.Replace("~", pub.AppPathRoot()).Replace("//", "/")
        End Function

        Public Shared Function SQLpar(ByVal parameter As String) As String
            Dim rv As String = ""
            rv = parameter.Replace("'", "&#39;").Replace("""", "&quot;").Replace("--", "&#45;&#45;")
            Return rv
        End Function
        Public Shared Function SQLp(ByVal parameter As String) As String
            Dim rv As String = ""
            rv = parameter _
                .Replace("'", "&#39;").Replace("""", "&quot;").Replace("--", "&#45;&#45;")
            Return rv
        End Function

        Public Shared Function SQLpp(ByVal parameter As String) As String
            Dim rv As String = ""
            rv = parameter _
                .Replace("'", "&#39;").Replace("""", "&quot;").Replace("--", "&#45;&#45;") _
                .Replace(";", "&#59;").Replace("*", "&#42;").Replace("/", "&#47;").Replace("@", "&#64;") _
                .Replace("sysobjects", "") _
                .Replace("syscolumns ", "")
            Return rv
        End Function

        Public Shared Function FormatDateString(ByVal DateString As String) As String
            Dim rv As String = ""
            Try
                If (DateString.Length.Equals(14)) Then
                    Dim dd As Date = Date.Parse(DateString.Substring(0, 4) & "/" & DateString.Substring(4, 2) & "/" & DateString.Substring(6, 2) & " " & DateString.Substring(8, 2) & ":" & DateString.Substring(10, 2) & ":" & DateString.Substring(12, 2))
                    rv = dd.ToString("yyyy/MM/dd HH:mm:ss")
                End If
            Catch ex As Exception
            End Try
            Return rv
        End Function

        ''取現在日期時間
        Public Shared Function Nowdatetime() As String
            Return Now.ToString("yyyyMMddHHmmss")
        End Function

        ''取現在日期時間
        Public Shared Function NowYM() As String
            Return Now.ToString("yyyyMM")
        End Function
        ''唯一序號，共20碼
        Public Shared Function sdno() As String

            Dim sequence_no As String = Nowdatetime() & Mid(CStr(Now.Ticks), 10, 6)

            Return sequence_no

        End Function

        '// 右補字串  
        Public Shared Function rpad(ByVal str, ByVal fulllen, ByVal fulltext)
            Dim rv As String = ""
            Dim strlen As Integer = Len(str)

            Dim Text As String = str

            While strlen < fulllen

                strlen = strlen + 1
                Text = Text & fulltext

            End While

            rv = Text

            Return rv

        End Function

        '// 左補字串 
        Public Shared Function lpad(ByVal str, ByVal fulllen, ByVal fulltext)
            Dim rv As String = ""
            Dim strlen As Integer = Len(str)

            Dim Text As String = str

            While strlen < fulllen

                strlen = strlen + 1
                Text = fulltext & Text

            End While

            rv = Text

            Return rv

        End Function

        Public Shared Sub Execute(ByVal SQLstr)
            Using ta As New DB_TableAdapters.DB_TableAdapter
                Try
                    ta.spExeSQLGetDataTable(SQLstr)
                Catch ex As Exception

                End Try
            End Using
        End Sub
        Public Shared Sub ExecuteCPA(ByVal SQLstr)
            Using ta As New DB_TableAdapters.DB_TableAdapter
                Try

                    ta.spExeSQLGetDataTable(SQLstr)
                Catch ex As Exception

                End Try
            End Using
        End Sub

        Public Shared Sub ExecuteLong(ByVal SQLstr As String)
            'Using _DB As New SqlServerDBv2()
            '    Using _cmd As New SqlCommand(SQLstr)
            '        _cmd.CommandTimeout = 0
            '        _DB.exeSQL_transaction(_cmd)
            '    End Using

            '    'Try

            '    '    Using _cmd As New SqlCommand(SQLstr)
            '    '        _cmd.CommandTimeout = 0
            '    '        Using t As DataTable = _DB.exeSQL_getDataTable(_cmd)

            '    '        End Using
            '    '    End Using
            '    'Catch ex As Exception

            '    'End Try
            'End Using
        End Sub


        '將數字轉為中文格式
        Public Shared Function toChNumber(ByVal varNum, ByVal Mode) As String
            Dim I, Total, tmp
            Dim cnnumArray() As String = {"零", "一", "二", "三", "四", "五", "六", "七", "八", "九"}
            Dim cbnumArray() As String = {"零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}
            Dim cndigiArray() As String = {"", "十", "百", "千", "萬", "十", "百", "千", "億", "十", "百", "千", "兆", "十", "百", "千", "京", "十", "百", "千", "正", "十", "百", "千"}
            Dim cbdigiArray() As String = {"", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟", "兆", "拾", "佰", "仟", "京", "拾", "佰", "仟", "正", "拾", "佰", "仟"}
            varNum = CStr(varNum)
            I = 0
            Total = Len(varNum)
            toChNumber = ""

            While Total > 0
                tmp = CByte(Mid(varNum, Total, 1))
                Select Case Mode
                    Case 1
                        toChNumber = cnnumArray(tmp) & cndigiArray(I) & toChNumber
                    Case 2
                        toChNumber = cbnumArray(tmp) & cbdigiArray(I) & toChNumber
                    Case 3
                        If (tmp <> 0) Or (I Mod 4 = 0) Then
                            If (Len(toChNumber) = 1) And (I Mod 4 = 0) Then
                                toChNumber = cndigiArray(I)
                            Else
                                toChNumber = cndigiArray(I) & toChNumber
                            End If
                        End If
                        If (tmp <> 0) Or (Mid(varNum, Total + 1, 1) <> "0") And (I <> 0) Then
                            If (tmp = 0) And (I Mod 4) = 0 Then
                                toChNumber = Left(toChNumber, 1) & cnnumArray(tmp) & Mid(toChNumber, 2, Len(varNum) - 1)
                            Else
                                toChNumber = cnnumArray(tmp) & toChNumber
                            End If
                        End If
                    Case 4
                        If (tmp <> 0) Or (I Mod 4 = 0) Then
                            If (Len(toChNumber) = 1) And (I Mod 4 = 0) Then
                                toChNumber = cbdigiArray(I)
                            Else
                                toChNumber = cbdigiArray(I) & toChNumber
                            End If
                        End If
                        If (tmp <> 0) Or (Mid(varNum, Total + 1, 1) <> "0") And (I <> 0) Then
                            If (tmp = 0) And (I Mod 4) = 0 Then
                                toChNumber = Left(toChNumber, 1) & cbnumArray(tmp) & Mid(toChNumber, 2, Len(varNum) - 1)
                            Else
                                toChNumber = cbnumArray(tmp) & toChNumber
                            End If
                        End If
                End Select
                I = I + 1
                Total = Total - 1
            End While

            If Mode = 3 And (Left(toChNumber, 2) = (cnnumArray(1) & cndigiArray(1))) Then toChNumber = Replace(toChNumber, cnnumArray(1) & cndigiArray(1), cndigiArray(1))
            If Mode = 4 And (Left(toChNumber, 2) = (cbnumArray(1) & cbdigiArray(1))) Then toChNumber = Replace(toChNumber, cbnumArray(1) & cbdigiArray(1), cbdigiArray(1))
        End Function

        '數字格式化
        Public Shared Function NumberFommat(num As Integer) As String
            If num > 999 Then
                Return String.Format("{0:#0,0}", num)
            Else
                Return num.ToString
            End If
        End Function

        '判斷日期為星期幾(格式為西元日期 例如:20131230)
        Public Shared Function getWeekDay(thisdate As String) As String
            thisdate = thisdate.Insert(4, "/")
            thisdate = thisdate.Insert(7, "/")
            Dim Day As String = ""
            Select Case Weekday(thisdate)
                Case 1 : Day = "日"
                Case 2 : Day = "一"
                Case 3 : Day = "二"
                Case 4 : Day = "三"
                Case 5 : Day = "四"
                Case 6 : Day = "五"
                Case 7 : Day = "六"
            End Select
            Return Day
        End Function

        Public Shared Function IsManager(v_ROLE_KIND As String) As Boolean
            Dim rv As Boolean = False
            If (v_ROLE_KIND = "001" Or v_ROLE_KIND = "002") Then '只要非院內人員 
                rv = True
            End If
            Return rv
        End Function

    End Class
End Namespace
'---------------------------------------------------------------------------------------------------
'===================================================================================================
'***************************************************************************************************
