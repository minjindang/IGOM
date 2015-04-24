Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web.Mail
Imports System.Net.Configuration
Imports System.Web.Configuration
Imports System.Net.Mail
Imports System.Drawing
Imports System.Text
Imports System.Web.UI.WebControls
Imports System
Imports System.Data
Imports System.Collections.Generic
Imports System.Reflection

Public Class CommonFun

    Public Shared Function GetAppSetting(v As String) As String
        Try
            Return ConfigurationManager.AppSettings(v).ToString()
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function ConvertToList(Of T)(table As DataTable) As IList(Of T)
        If table Is Nothing Then
            Return Nothing
        End If
        Dim rows As New List(Of DataRow)()
        For Each row As DataRow In table.Rows
            rows.Add(row)
        Next
        Return ConvertTo(Of T)(rows)
    End Function

    Public Shared Function ConvertTo(Of T)(rows As IList(Of DataRow)) As IList(Of T)
        Dim list As IList(Of T) = Nothing
        If rows IsNot Nothing Then
            list = New List(Of T)()
            For Each row As DataRow In rows
                Dim item As T = CreateItem(Of T)(row)
                list.Add(item)
            Next
        End If
        Return list
    End Function

    Public Shared Function CreateItem(Of T)(row As DataRow) As T
        Dim columnName As String
        Dim obj As T = Nothing
        If row IsNot Nothing Then

            obj = Activator.CreateInstance(Of T)()
            For Each column As DataColumn In row.Table.Columns
                columnName = column.ColumnName

                Dim prop As PropertyInfo = obj.[GetType]().GetProperty(columnName)

                If prop Is Nothing Then
                    prop = obj.[GetType]().GetProperty(columnName.Replace("_", ""))

                    If prop Is Nothing Then
                        For i As Integer = 0 To columnName.Length - 1
                            If columnName.Length - 1 > i AndAlso columnName.Substring(i, 1) = "_" Then
                                columnName = columnName.Substring(0, i) & columnName.Substring(i + 1, 1).ToUpper() & columnName.Substring(i + 2)
                            End If
                        Next
                        prop = obj.[GetType]().GetProperty(columnName)

                        If prop Is Nothing Then
                            columnName = columnName.Substring(0, 1) & columnName.Substring(1).ToLower()
                            prop = obj.[GetType]().GetProperty(columnName)
                        End If

                    End If
                End If

                If prop IsNot Nothing Then
                    Try
                        Dim value As Object = IIf(IsDBNull(row(column.ColumnName)), Nothing, row(column.ColumnName))
                        prop.SetValue(obj, value, Nothing)
                    Catch
                        Throw
                    End Try
                End If
            Next
        End If
        Return obj
    End Function

    Public Shared Function CombineString(ByVal str() As String, ByVal symbol As String) As String
        Dim txt As New StringBuilder()
        For Each s As String In str
            txt.Append(s).Append(symbol)
        Next
        Return txt.ToString().TrimEnd(symbol)
    End Function

    Public Shared Function getShowDayHours(ByVal dayhour As String) As String
        Dim day As String = "0"
        Dim hour As String = "0"

        If dayhour.IndexOf(".") > 0 Then
            day = Mid(dayhour, 1, dayhour.IndexOf("."))
            hour = Mid(dayhour, dayhour.IndexOf(".") + 2, dayhour.Length - dayhour.IndexOf("."))
            Return IIf(day = "0", "", day & " 天 ") & IIf(hour = "0", "", hour & " 小時")
        Else
            Return dayhour & " 天"
        End If

    End Function

    Public Shared Function getYYYMMDD() As String
        Return getYYYMMDD(Now)
    End Function

    Public Shared Function getYYYMMDD(ByVal myDtStr As String) As DateTime
        If myDtStr.Length < 7 Then
            Return Now
        Else
            Return New DateTime(ConvertToInt(myDtStr.Substring(0, 3)) + 1911, myDtStr.Substring(3, 2), myDtStr.Substring(5, 2))
        End If
    End Function

    Public Shared Function getYYYMMDD(ByVal myDt As DateTime) As String
        Dim strYY As String
        Dim strMM As String
        Dim strDD As String
        strYY = System.Convert.ToString(myDt.Year - 1911).PadLeft(3, "0")
        strMM = System.Convert.ToString(myDt.Month).PadLeft(2, "0")
        strDD = System.Convert.ToString(myDt.Day).PadLeft(2, "0")
        Return strYY & strMM & strDD
    End Function

    Public Shared Function getYYYMMDD2(ByVal myDt As DateTime) As String
        Dim strYY As String
        Dim strMM As String
        Dim strDD As String
        strYY = System.Convert.ToString(myDt.Year - 1911).PadLeft(3, "0") & "/"
        strMM = System.Convert.ToString(myDt.Month).PadLeft(2, "0") & "/"
        strDD = System.Convert.ToString(myDt.Day).PadLeft(2, "0")
        Return strYY & strMM & strDD
    End Function


    Public Shared Function SetDataRow(ByRef dr As DataRow, ByVal col As String)
        If dr IsNot Nothing Then
            If Not IsDBNull(dr(col)) Then
                Return dr(col)
            End If
        End If

        Return ""
    End Function

    ''' <summary>
    ''' 清空重填
    ''' </summary>
    Public Shared Sub ClearContentPlaceHolder(ByRef Master As System.Web.UI.MasterPage)
        ClearContentPlaceHolder(Master, "ContentPlaceHolder1")
    End Sub


    ''' <summary>
    ''' 清空重填
    ''' </summary>
    Public Shared Sub ClearContentPlaceHolder(ByRef Master As System.Web.UI.MasterPage, ByVal contentPlaceHolderID As String)
        Dim mpHolder As ContentPlaceHolder = Master.FindControl(contentPlaceHolderID)
        For Each ctrl As Control In mpHolder.Controls
            ClearControl(ctrl)
        Next
    End Sub

    Private Shared Sub ClearControl(ByVal control As Control)

        If TypeOf (control) Is TextBox Then
            Dim textbox = CType(control, TextBox)
            textbox.Text = String.Empty
        ElseIf TypeOf (control) Is DropDownList Then
            Dim dropDownList = CType(control, DropDownList)
            dropDownList.SelectedIndex = -1
        ElseIf TypeOf (control) Is CheckBox Then
            Dim checkBox = CType(control, CheckBox)
            checkBox.Checked = False
        ElseIf TypeOf (control) Is RadioButton Then
            Dim radioButton = CType(control, RadioButton)
            radioButton.Checked = False
        Else
            For Each childControl As Control In control.Controls
                ClearControl(childControl)
            Next
        End If

    End Sub

#Region "載入XML文件-Use System.Xml NameSpace"
    Public Shared Function LoadXML(ByVal strXmlFile As String) As System.Xml.XmlDocument

        '建立供載入XML文件的XMLDocument
        Dim objXML As New System.Xml.XmlDocument
        objXML.Load(strXmlFile)
        Return objXML
    End Function
#End Region

#Region "儲存檔案"

    Public Shared Sub SaveFile(ByVal strContent As String, ByVal strPath As String, ByVal strFileName As String)
        Dim fileStream As System.IO.Stream
        Dim streamWriter As System.IO.StreamWriter

        Dim foldInfo As New DirectoryInfo(strPath)
        If Not foldInfo.Exists Then
            CreateDir(strPath)
        End If

        fileStream = IO.File.Open(strPath & "/" & strFileName, IO.FileMode.Create, IO.FileAccess.Write)
        streamWriter = New System.IO.StreamWriter(fileStream, System.Text.Encoding.UTF8)
        Call streamWriter.Write(strContent)
        streamWriter.Close()
        fileStream.Close()
    End Sub

#End Region

#Region "儲存檔案"

    Public Shared Sub SaveFile(ByVal strContent As String, ByVal strFileName As String)
        Dim fileStream As System.IO.Stream
        Dim streamWriter As System.IO.StreamWriter

        Dim fileInfo As New FileInfo(strFileName)
        If Not fileInfo.Directory.Exists Then
            CreateDir(fileInfo.Directory.FullName)
        End If

        fileStream = IO.File.Open(strFileName, IO.FileMode.Create, IO.FileAccess.Write)
        streamWriter = New System.IO.StreamWriter(fileStream, System.Text.Encoding.UTF8)
        Call streamWriter.Write(strContent)
        streamWriter.Close()
        fileStream.Close()
    End Sub

#End Region

    Public Shared Sub SaveFile(ByVal strContent As String, ByVal strFileName As String, ByVal mode As IO.FileMode)
        Dim fileStream As System.IO.Stream
        Dim streamWriter As System.IO.StreamWriter

        Dim fileInfo As New FileInfo(strFileName)
        If Not fileInfo.Directory.Exists Then
            CreateDir(fileInfo.Directory.FullName)
        End If

        fileStream = IO.File.Open(strFileName, mode, IO.FileAccess.Write)
        streamWriter = New System.IO.StreamWriter(fileStream, System.Text.Encoding.UTF8)
        Call streamWriter.Write(strContent)
        streamWriter.Close()
        fileStream.Close()
    End Sub

#Region "##上傳檔案"
    'fileObj:檔案物件,strSavePath:儲存路徑
    '傳回值：上傳檔案的檔名
    Public Shared Function UploadLoadFile(ByVal fileObj As System.Web.UI.HtmlControls.HtmlInputFile, ByVal strSavePath As String, Optional ByVal strSaveName As String = "") As String
        If fileObj.PostedFile.FileName <> "" Then '如果上傳檔案物件的FileName不為空，表示有上傳檔案
            Dim strFileName As String = ""
            If strSaveName = "" Then '若儲存檔名為空，則以時間命名
                '檔名以(年,月,日,時,分,秒,毫秒)為名
                strFileName = Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond & Path.GetExtension(fileObj.PostedFile.FileName)
            Else '若不為空則以傳入之檔名存檔
                strFileName = strSaveName & Path.GetExtension(fileObj.PostedFile.FileName)
            End If
            Try
                '上傳
                fileObj.PostedFile.SaveAs(strSavePath & "\" & strFileName)
            Catch ex As Exception '若發生錯誤、回傳空字串
                Return ""
            End Try
            Return strFileName '上傳成功，回傳檔名
        Else '否則傳回空字串
            Return ""
        End If
    End Function
#End Region

#Region "##刪除指定的檔案"
    Public Shared Function DeleteFile(ByVal strSavePath As String, Optional ByVal strFileName As String = "") As Boolean

        If Not strSavePath & strFileName = "" Then

            If Not IO.File.Exists(strSavePath & strFileName) Then Return False '該檔案不存在，回傳失敗

            Try
                IO.File.Delete(strSavePath & strFileName)
            Catch ex As Exception
                Return False
            End Try

            Return True
        End If

    End Function
#End Region

#Region "##刪除指定的目錄"
    Public Shared Function DeleteDir(ByVal strDirPath As String) As Boolean

        If strDirPath <> "" Then

            Try
                Directory.Delete(strDirPath, True)
            Catch ex As Exception
                Return False
            End Try

            Return True

        End If

    End Function
#End Region

#Region "建立目錄"
    Public Shared Function CreateDir(ByVal strDirPath As String) As Boolean

        If strDirPath <> "" Then

            Try
                Directory.CreateDirectory(strDirPath)
            Catch ex As Exception
                Return False
            End Try

            Return True

        End If
        Return False
    End Function
#End Region

#Region "讀取檔案"
    Public Shared Function ReadFile(ByVal strFilePath As String, ByVal strFileName As String) As String

        Dim fileStream As System.IO.Stream
        Dim fileStreamReader As System.IO.StreamReader

        '判斷檔案是否存在
        If IO.File.Exists(strFilePath & strFileName) Then
            fileStream = IO.File.OpenRead(strFilePath & strFileName)
            fileStreamReader = New System.IO.StreamReader(fileStream, System.Text.Encoding.Default)
            Dim strFileContent As String = fileStreamReader.ReadToEnd
            fileStreamReader.Close()
            fileStream.Close()
            Return strFileContent
        Else
            Return ""
        End If

    End Function
#End Region

#Region "讀取檔案"
    Public Shared Function ReadFile(ByVal strFileName As String) As String

        Dim fileStream As System.IO.Stream
        Dim fileStreamReader As System.IO.StreamReader

        '判斷檔案是否存在
        If IO.File.Exists(strFileName) Then
            fileStream = IO.File.OpenRead(strFileName)
            fileStreamReader = New System.IO.StreamReader(fileStream, System.Text.Encoding.Default)
            Dim strFileContent As String = fileStreamReader.ReadToEnd
            fileStreamReader.Close()
            fileStream.Close()
            Return strFileContent
        Else
            Return ""
        End If

    End Function
#End Region

#Region "取得檔案Reader物件"
    Public Shared Function GetFileReader(ByVal strFileName As String) As System.IO.StreamReader

        Dim fileStream As System.IO.Stream
        Dim fileStreamReader As System.IO.StreamReader

        'Try

        '判斷檔案是否存在
        If IO.File.Exists(strFileName) Then
            fileStream = IO.File.OpenRead(strFileName)
            fileStreamReader = New System.IO.StreamReader(fileStream, System.Text.Encoding.Default)
            'fileStream.Close()
            Return fileStreamReader
        Else
            Return Nothing
        End If

        'Catch ex As Exception
        'Return Nothing
        'End Try

    End Function

#End Region

#Region "取得檔案Writer物件"
    Public Shared Function GetFileWriter(ByVal strFileName As String) As System.IO.StreamWriter

        Dim fileStream As System.IO.Stream
        Dim fileStreamWriter As System.IO.StreamWriter

        'Try

        '判斷檔案是否存在
        If IO.File.Exists(strFileName) Then
            fileStream = IO.File.OpenWrite(strFileName)
            fileStreamWriter = New System.IO.StreamWriter(fileStream, System.Text.Encoding.Default)
            Return fileStreamWriter
        Else
            Return Nothing
        End If

        'Catch ex As Exception
        'Return Nothing
        'End Try

    End Function

#End Region

#Region "判斷某一檔案是否存在"
    Public Shared Function DoesFileExists(ByVal strFilePath As String, Optional ByVal strFileName As String = "") As Boolean

        '判斷檔案是否存在
        If IO.File.Exists(strFilePath & strFileName) Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region

#Region "取得檔案的副檔名"
    ''' <summary>
    ''' 取得檔案的副檔名
    ''' </summary>
    ''' <param name="FileName">包含路徑的完整名稱</param>
    ''' <returns>表示檔案的副檔名部份</returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileExtension(ByVal FileName As String) As String
        Try
            Dim info As New System.IO.FileInfo(FileName)
            Return info.Extension
        Catch ex As Exception
            Return ""
        End Try
    End Function
#End Region

#Region "字元轉換"

    Public Shared Function ChrtoAsc(ByVal strOriginal As String) As String

        '字元轉換成代碼
        Dim MyNumber As String
        MyNumber = Asc(strOriginal)

        Return MyNumber

    End Function

    Public Shared Function AsctoChr(ByVal strOriginal As String) As String

        '字元轉換成代碼
        Dim Mychr As String
        Mychr = Chr(strOriginal)

        Return Mychr

    End Function

#End Region

#Region "複製檔案"
    Public Shared Sub CopyFile(ByVal SourceFileName As String, ByVal DestFileName As String)
        IO.File.Copy(SourceFileName, DestFileName, True)
    End Sub
#End Region

#Region "將傳入的DropDown下拉選單的Text設為Value + . + Text"
    Public Shared Sub DropDownTextWithValue(ByRef ddlDrop As DropDownList)
        For Each item As ListItem In ddlDrop.Items
            item.Text = item.Value & "." & item.Text
        Next
    End Sub
#End Region

#Region "寄送Email郵件"
    Public Shared Function SendMail(ByVal FromMail As String, ByVal ToMail As String, ByVal FromName As String, ByVal ToName As String, ByVal Subject As String, ByVal MailContent As String, Optional ByVal Host As String = "", Optional ByVal CC As String = "") As Boolean

        If ToMail Is Nothing OrElse ToMail.Trim() = "" Then '無寄件者信箱
            Dim e As New SYS.Logic.MailError()
            e.FromMail = FromMail
            e.FromName = FromName
            e.ToMail = ToMail
            e.ToName = ToName
            e.Subject = Subject
            e.MailContent = MailContent
            e.ErrorMag = "1"
            e.SendDate = FSCPLM.Logic.DateTimeInfo.GetRocDate(Now)
            e.InsertData()
            Return False
        End If

        Dim config As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath)
        Dim netSmtpMailSection As MailSettingsSectionGroup = CType(config.GetSectionGroup("system.net/mailSettings"), MailSettingsSectionGroup)
        Dim smtpClnt As New SmtpClient(netSmtpMailSection.Smtp.Network.Host)
        Dim isSSL As String = ConfigurationManager.AppSettings("isSSL").ToString()

        If 0 < netSmtpMailSection.Smtp.Network.Port Then
            smtpClnt.Port = netSmtpMailSection.Smtp.Network.Port
        End If

        If "" <> netSmtpMailSection.Smtp.Network.UserName And "" <> netSmtpMailSection.Smtp.Network.Password Then
            Dim mailCredentials = New System.Net.NetworkCredential(netSmtpMailSection.Smtp.Network.UserName, netSmtpMailSection.Smtp.Network.Password)
            smtpClnt.Credentials = mailCredentials
        End If

        If "true" = isSSL Then
            smtpClnt.EnableSsl = True
        End If


        Dim mailMsg As New System.Net.Mail.MailMessage
        Dim mailFromAddr As MailAddress
        Dim mailToAddr As MailAddress

        Try

            mailMsg.IsBodyHtml = True '設定為HTML格式的mail
            mailFromAddr = New MailAddress(FromMail, FromName)  '設定寄件者EMail,Name   
            mailMsg.From = mailFromAddr  '設定寄件者 
            mailMsg.Subject = Subject '設定主旨
            mailMsg.Body = MailContent '設定內文
            mailToAddr = New MailAddress(ToMail, ToName) '設定收件者EMail,Name   
            mailMsg.To.Add(mailToAddr) '設定收件者
            mailMsg.SubjectEncoding = System.Text.Encoding.UTF8 '設定主旨的編碼
            mailMsg.BodyEncoding = System.Text.Encoding.UTF8 '設定內文編碼 

            If Not String.IsNullOrEmpty(CC) Then
                mailMsg.CC.Add(CC)
            End If

            '寄送mail
            smtpClnt.Send(mailMsg)

        Catch ex As Exception
            Dim e As New SYS.Logic.MailError()
            e.FromMail = FromMail
            e.FromName = FromName
            e.ToMail = ToMail
            e.ToName = ToName
            e.Subject = Subject
            e.MailContent = MailContent
            e.ErrorMag = "2"
            e.SendDate = FSCPLM.Logic.DateTimeInfo.GetRocDate(Now)
            e.InsertData()
            Return False
        Finally

            '釋放物件
            mailMsg.Dispose()
            mailMsg = Nothing
            mailMsg = Nothing

        End Try

        Return True

    End Function
#End Region

#Region "寄送Email郵件(可加一個附件)"
    Public Shared Function SendMailWithAttachment(ByVal FromMail As String, ByVal ToMail As String, ByVal FromName As String, ByVal ToName As String, _
                                                    ByVal Subject As String, ByVal MailContent As String, ByVal AttachFileName As String, _
                                                    Optional ByVal Host As String = "") As Boolean

        'mail錯誤訊息紀錄------------------------------------------------------------------------------------------------------
        If ToMail.Trim = "" Then '無寄件者信箱
            Dim conn As Data.SqlClient.SqlConnection = New Data.SqlClient.SqlConnection(ConnectDB.GetDBString())
            'Dim DAOFSC4204 As New FSC4204(conn)
            Dim fileContents As Byte() = {}
            Dim fileName As String = ""

            '判斷檔案是否存在
            If CommonFun.DoesFileExists(AttachFileName) Then
                fileContents = My.Computer.FileSystem.ReadAllBytes(AttachFileName)
                Dim ary() As String = AttachFileName.Split("\")
                fileName = ary(ary.Length - 1)
            End If
            '無寄件者信箱
            'DAOFSC4204.MailErrorAdd(FromName, FromMail, ToName, ToMail, Subject, _
            '                         MailContent, FSC4204.ErrorMag.No_ToMail, fileName, fileContents)
            Return False
        End If '-----------------------------------------------------------------------------------------------------------------

        Dim blnFlag As Boolean = False
        Dim config As System.Configuration.Configuration = WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath)
        Dim netSmtpMailSection As MailSettingsSectionGroup = CType(config.GetSectionGroup("system.net/mailSettings"), MailSettingsSectionGroup)
        Dim smtpClnt As New SmtpClient(netSmtpMailSection.Smtp.Network.Host)
        Dim mailMsg As New System.Net.Mail.MailMessage
        Dim mailFromAddr As MailAddress
        Dim mailToAddr As MailAddress
        Dim isSSL As String = ConfigurationManager.AppSettings("isSSL").ToString()
        Try
            If 0 < netSmtpMailSection.Smtp.Network.Port Then
                smtpClnt.Port = netSmtpMailSection.Smtp.Network.Port
            End If

            If "" <> netSmtpMailSection.Smtp.Network.UserName And "" <> netSmtpMailSection.Smtp.Network.Password Then
                Dim mailCredentials = New System.Net.NetworkCredential(netSmtpMailSection.Smtp.Network.UserName, netSmtpMailSection.Smtp.Network.Password)
                smtpClnt.Credentials = mailCredentials
            End If

            If "true" = isSSL Then
                smtpClnt.EnableSsl = True
            End If

            mailFromAddr = New MailAddress(FromMail, FromName)  '設定寄件者EMail,Name
            mailMsg.From = mailFromAddr  '設定寄件者
            mailMsg.Subject = Subject '設定主旨
            mailMsg.Body = MailContent '設定內文
            mailToAddr = New MailAddress(ToMail, ToName) '設定收件者EMail,Name 
            mailMsg.To.Add(mailToAddr) '設定收件者
            mailMsg.SubjectEncoding = System.Text.Encoding.UTF8  '設定主旨的編碼
            mailMsg.BodyEncoding = System.Text.Encoding.UTF8 '設定內文編碼
            mailMsg.IsBodyHtml = True '設定為HTML格式的mail

            '檔案有存在才可以加入附件
            If CommonFun.DoesFileExists(AttachFileName) Then
                '加入附件
                Dim matt As Attachment
                matt = New Attachment(AttachFileName)
                mailMsg.Attachments.Add(matt)
            End If

            '寄送mail
            smtpClnt.Send(mailMsg)

            blnFlag = True '寄送成功

        Catch ex As Exception

            'mail錯誤訊息紀錄------------------------------------------------------------------------------------------------------ 
            Dim conn As Data.SqlClient.SqlConnection = New Data.SqlClient.SqlConnection(ConnectDB.GetDBString())
            'Dim DAOFSC4204 As New FSC4204(conn)
            Dim fileContents As Byte() = {}
            Dim fileName As String = ""

            '判斷檔案是否存在
            If CommonFun.DoesFileExists(AttachFileName) Then
                fileContents = My.Computer.FileSystem.ReadAllBytes(AttachFileName)
                Dim ary() As String = AttachFileName.Split("\")
                fileName = ary(ary.Length - 1)
            End If
            '電子郵件退件
            'DAOFSC4204.MailErrorAdd(FromName, FromMail, ToName, ToMail, Subject, _
            '                         MailContent, FSC4204.ErrorMag.SendBack, fileName, fileContents)

            '-----------------------------------------------------------------------------------------------------------------

            blnFlag = False
        Finally

            '釋放物件
            mailMsg.Dispose()
            mailMsg = Nothing
            mailMsg = Nothing

        End Try

        Return blnFlag

    End Function
#End Region

#Region "Show訊息"
    '=====================參數:   呼叫的Page網頁  ,             與需要顯示的訊息
    Public Shared Sub MsgShow(ByRef P As System.Web.UI.Page, ByVal M As Msg, Optional ByVal Other As String = " !", Optional ByVal Callback As String = "" _
                              , Optional ByVal SetFouceByName As String = "")

        'SetFouceByName是要放ｉｄ的值，如果發生某些情況，需要將滑鼠游標指定在某個物件上時

        Dim AMsg() As String = {"查無任何資料", "新增成功", "新增失敗", "更新成功", "更新失敗", "刪除成功", _
                                "刪除失敗", "您未選取資料", "匯出成功", "匯出失敗", "匯入成功", "匯入失敗", "", "資料重複", _
                                "系統發生錯誤，請稍候再試或通知系統管理者", "異動成功", "上傳成功", "上傳失敗"}
        If Callback <> "" Then
            If Callback <> "window.parent.window.close();" Or Callback <> "ReturnAttachID();" Then
                Callback = "location = '" + Callback + "';"
            End If
        End If

        Dim key As String = Guid.NewGuid.ToString()
        Dim script As String = "alert('" + AMsg(M) + Escape(Other) + "'); " + Callback


        If SetFouceByName <> "" Then script += "eval(document.getElementById('form1')." & SetFouceByName & ").focus();"

        'P.ClientScript().RegisterStartupScript(P.GetType(), Guid.NewGuid().ToString(), script)


        If ScriptManager.GetCurrent(P) IsNot Nothing AndAlso ScriptManager.GetCurrent(P).IsInAsyncPostBack Then
            ScriptManager.RegisterStartupScript(P, P.GetType(), Guid.NewGuid().ToString(), script, True)
        Else
            ScriptManager.RegisterStartupScript(P, P.GetType(), key, vbCrLf + "if(window.setMsg) { setMsg(""" + AMsg(M) + Escape(Other) + """, """ + Callback + """);} else {" + script + "}" + vbCrLf, True)
        End If

    End Sub

    Protected Shared Function Escape(ByVal m As String) As String
        m = m.Replace("'", "")
        Return m
    End Function


    Public Enum Msg
        QueryNothing = 0
        InsertOK = 1
        InsertFail = 2
        UpdateOK = 3
        UpdateFail = 4
        DeleteOK = 5
        DeleteFail = 6
        NotSelectItem = 7
        ExportOK = 8
        ExportFail = 9
        ImportOK = 10
        ImportFail = 11
        Custom = 12
        RepeatData = 13
        SystemError = 14
        changeOK = 15
        uploadOK = 16
        uploadFail = 17
    End Enum

    Public Shared Sub MsgConfirm2(ByRef P As System.Web.UI.Page, ByVal Message As String, ByVal TrueScript As String, ByVal FalseScript As String)
        Dim sScript As String
        sScript = String.Format("if (confirm('{0}')){{ {1} }} else {{ {2} }};", Message, TrueScript, FalseScript)
        P.ClientScript.RegisterStartupScript(GetType(String), "confirm", sScript, True)
    End Sub

    Public Shared Sub MsgConfirm(ByRef P As System.Web.UI.Page, Optional ByVal Other As String = "", Optional ByVal CallbackY As String = "", Optional ByVal SetFouceByNameY As String = "", _
    Optional ByVal CallbackN As String = "", Optional ByVal SetFouceByNameN As String = "")

        If CallbackY <> "" Then CallbackY = "location = '" + CallbackY + "';"
        If CallbackN <> "" Then CallbackN = "location = '" + CallbackN + "';"

        Dim key As String = ""
        Dim script As String = "<script>if (confirm('" + Other + "')) {"

        If SetFouceByNameY <> "" Then script += "eval(document.getElementById('form1')." & SetFouceByNameY & ").focus();"
        script += CallbackY + "} else {"

        If SetFouceByNameN <> "" Then script += "eval(document.getElementById('form1')." & SetFouceByNameN & ").focus();"
        script += CallbackN + "}"

        script += "</script>"

        P.ClientScript.RegisterStartupScript(GetType(String), "", script)
    End Sub

#End Region

#Region "GridView修改時無法按其他的修改小圖示"

    Public Shared Sub EditGridView(ByRef GView As GridView, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs)

        For Each row As GridViewRow In GView.Rows
            If row.RowIndex <> GView.Rows(e.NewEditIndex).RowIndex Then

                GView.Rows(row.RowIndex).Enabled = False

            End If
        Next

    End Sub
#End Region

#Region "將畫面上的文字方塊清空與下拉選單回到第一個選項和將所選取過的RadioButton清空"
    Public Shared Sub cleanControl(ByRef P As System.Web.UI.Page)

        For Each control As Control In P.Page.Form.FindControl("ContentPlaceHolder1").Controls
            If TypeName(control) = "TextBox" Then
                Dim txt As TextBox = CType(control, TextBox)
                If txt.Visible = True And txt.Enabled = True And txt.ReadOnly = False Then
                    txt.Text = ""
                End If

            ElseIf TypeName(control) = "DropDownList" Then
                Dim ddl As DropDownList = CType(control, DropDownList)
                ddl.SelectedIndex = 0

            ElseIf TypeName(control) = "RadioButton" Then
                Dim radbtn As RadioButton = CType(control, RadioButton)
                radbtn.Checked = False
            End If
            If TypeName(control) = "CheckBox" Then
                Dim chb As CheckBox = CType(control, CheckBox)
                chb.Checked = False
            End If
        Next
    End Sub
#End Region

#Region "檢查整個網頁的TextBox是否出現UNI碼"
    Public Shared Function isPageTextBoxsUnicode(ByRef Page As System.Web.UI.Page) As Boolean
        Dim ValidUnicode As Boolean = False
        For Each control As WebControl In Page.Form.Controls
            If TypeName(control) = "TextBox" Then
                Dim txt As TextBox = CType(control, TextBox)
                Dim str As String = txt.Text.Trim
                '驗證是否出現UNICODE 如果有文字以紅色顯示
                If CommonFun.CheckExistUnicode(str) Then
                    ValidUnicode = True
                    Exit For
                End If
            End If
        Next
        Return ValidUnicode
    End Function

#End Region

#Region "檢查是否出現UNI碼"

    '檢查是否出現UNI碼
    Public Shared Function CheckExistUnicode(ByVal strInput As String) As Boolean

        Dim i As Integer = strInput.Length
        If i = 0 Then
            Return False
        End If
        Dim utf8 As String = strInput
        Dim big5 As String = System.Text.Encoding.GetEncoding(950).GetString(Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.GetEncoding(950), Encoding.UTF8.GetBytes(strInput)))
        If (strInput <> big5) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "取得遠端使用者的 IP 位址"
    Public Shared Function GetClientIP()
        '下面筆者就使用一個函式來展示如何取得遠端使用者的 IP 位址。程式的邏輯為，如果不能取客戶端真實 IP，就會取客戶端的代理IP。 
        Dim strIPAddr As String
        Dim request As Web.HttpRequest = Web.HttpContext.Current.Request

        If request.ServerVariables("HTTP_X_FORWARDED_FOR") = "" Or InStr(request.ServerVariables("HTTP_X_FORWARDED_FOR"), "unknown") > 0 Then
            strIPAddr = request.ServerVariables("REMOTE_ADDR")
        ElseIf InStr(request.ServerVariables("HTTP_X_FORWARDED_FOR"), ",") > 0 Then
            strIPAddr = Mid(request.ServerVariables("HTTP_X_FORWARDED_FOR"), 1, InStr(request.ServerVariables("HTTP_X_FORWARDED_FOR"), ",") - 1)
        ElseIf InStr(request.ServerVariables("HTTP_X_FORWARDED_FOR"), ";") > 0 Then
            strIPAddr = Mid(request.ServerVariables("HTTP_X_FORWARDED_FOR"), 1, InStr(request.ServerVariables("HTTP_X_FORWARDED_FOR"), ";") - 1)
        Else
            strIPAddr = request.ServerVariables("HTTP_X_FORWARDED_FOR")
        End If
        Return Mid(strIPAddr, 1, 30).Trim
    End Function
#End Region

#Region "判斷輸入的字串，檢核字元長度，若超過最大值，則回傳ｔｒｕｅ"
    Public Shared Function CheckVarcharLenth(ByVal strContent As String, ByVal intMaxLenth As Integer, ByVal txtName As String) As String
        'strContent => 傳入的資料內容
        'intMaxLenth => 限制此資料內容的最大字元長度 
        Dim bytes As Byte() = Encoding.Default.GetBytes(strContent)
        If bytes.Length > intMaxLenth Then
            Return txtName & "全名只予許輸入" & intMaxLenth & "個字元數!\n" '超過長度
        Else
            Return ""
        End If
    End Function
#End Region

    Public Shared Sub OpenWindow(ByVal P As System.Web.UI.Page, ByVal Url As String, Optional ByVal param As String = Nothing)
        Dim script As String
        If param Is Nothing Then
            param = "height=500, width=800, top=0, left=0, toolbar=yes, menubar=no, scrollbars=yes, resizable=no,location=no, status=no"
        End If
        script = String.Format("<script type='text/javascript'>window.open('{0}','{1}','{2}');</script>", Url, "", param)
        P.ClientScript.RegisterStartupScript(GetType(String), "", script)
    End Sub

    '將阿拉伯數字改成中文
    Public Shared Function NumToChinese(ByVal Num As Long) As String

        Dim lsChinese() As String = {"零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖"}

        If Num < 0 Or Num > 9 Then
            Return Num.ToString
        End If
        Return lsChinese(Num)
    End Function

    Public Shared Function ConvertToInt(ByVal s As Object) As Integer
        If s Is Nothing OrElse IsDBNull(s) OrElse String.IsNullOrEmpty(s) OrElse "&nbsp;".Equals(s) Then Return 0
        Return Convert.ToInt32(getDouble(s))
    End Function

    Public Shared Function getInt(ByVal s As Object) As Integer
        If s Is Nothing OrElse IsDBNull(s) OrElse String.IsNullOrEmpty(s) OrElse "&nbsp;".Equals(s) Then Return 0
        Return Convert.ToInt32(getDouble(s))
    End Function

    Public Shared Function ConvertToDouble(ByVal s As Object) As Double
        If s Is Nothing OrElse IsDBNull(s) OrElse String.IsNullOrEmpty(s) OrElse "&nbsp;".Equals(s) Then Return 0
        Return Double.Parse(s)
    End Function
    Public Shared Function getDouble(ByVal s As Object) As Double
        If s Is Nothing OrElse IsDBNull(s) OrElse String.IsNullOrEmpty(s) OrElse "&nbsp;".Equals(s) Then Return 0
        Return Double.Parse(s)
    End Function
    Public Shared Function getDouble(ByVal s As String) As Double
        If s Is Nothing OrElse IsDBNull(s) OrElse String.IsNullOrEmpty(s) OrElse "&nbsp;".Equals(s) Then Return 0
        Return Double.Parse(s)
    End Function

    Public Shared Function IsNum(ByVal s As String) As Boolean
        If s Is Nothing Then Return False
        s = s.Trim()
        For i As Integer = 1 To s.Length
            If Asc(Mid(s, i, 1)) <= 47 Or Asc(Mid(s, i, 1)) >= 58 Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Shared Sub KillProcess(ByVal ProcName As String)
        Dim thisProc As System.Diagnostics.Process
        Dim allRelationalProcs() As Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName(ProcName)
        For Each thisProc In allRelationalProcs
            Try
                If Not thisProc.CloseMainWindow() Then
                    thisProc.Kill()
                End If
            Catch ex As Exception
                'lblErrMsg.Text = ex.GetBaseException.ToString
            End Try
        Next
    End Sub

    ''' <summary>
    ''' 加1後回傳CodeID
    ''' </summary>
    ''' <param name="StrObject"></param>
    ''' <param name="INum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMaxValueAddOne(ByVal StrObject As String, ByVal INum As Integer) As String
        Dim StrMaxValue As String = ""
        StrMaxValue = StrObject.Substring(0, StrObject.Trim().Length - INum) & _
            GetInt32ValueAddOne(StrObject.Substring(StrObject.Trim().Length - INum, INum), INum)
        Return StrMaxValue
    End Function

    ''' <summary>
    ''' 加1後回傳數字
    ''' </summary>
    ''' <param name="StrMaxValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInt32ValueAddOne(ByVal StrMaxValue As String, ByVal INum As Integer) As String
        Dim SAddOne As String = ""
        Dim SAddZero As String = ""
        SAddOne = (Convert.ToInt32(StrMaxValue) + 1).ToString()
        For i As Integer = 0 To INum - 1 - SAddOne.Length
            SAddZero = "0" & SAddZero
        Next
        SAddOne = SAddZero & SAddOne
        Return SAddOne
    End Function


    Public Shared Function checkPassword(ByVal pwd As String) As Boolean
        Dim a As Integer
        Dim b As String = ""

        Dim isAll As Boolean = False
        Dim isNum As Boolean = False
        Dim isEng As Boolean = False

        If pwd <> "" Then     '如果text不是空字串的話進行判斷
            a = Len(pwd)       '令a=字串長度
            For i As Integer = 1 To a          '用For 來配合Mid 來一個一個抓字串
                b = Mid(pwd, i, 1)      '一個一個抓字串
                Select Case Asc(b)     '用Select Case判斷抓下字串的asc碼
                    Case 48 To 57       '抓數字的asc碼48~57
                        isNum = True
                    Case 65 To 90        '抓大寫英文的asc碼65~90
                        isEng = True
                    Case 97 To 122       '抓小寫英文的asc碼97~122
                        isEng = True
                    Case Else      '如果都不在以上條件就執行此條件
                        'm = m & b   '到此條件的都是英、數以外，把它拼成新的字串
                End Select

                If Encoding.Unicode.GetBytes(b)(1) = 255 Then
                    isAll = True
                End If
            Next
        End If

        If isAll Then
            Return False
        End If
        If Not isNum Or Not isEng Then
            Return False
        End If
        Return True
    End Function


    Public Shared Function CheckNumEng(ByVal pwd As String) As String
        Dim a As Integer
        Dim b As String = ""

        Dim isAll As Boolean = False
        Dim isNum As Boolean = False
        Dim isEng As Boolean = False

        If pwd <> "" Then     '如果text不是空字串的話進行判斷
            a = Len(pwd)       '令a=字串長度
            For i As Integer = 1 To a          '用For 來配合Mid 來一個一個抓字串
                b = Mid(pwd, i, 1)      '一個一個抓字串
                Select Case Asc(b)     '用Select Case判斷抓下字串的asc碼
                    Case 48 To 57       '抓數字的asc碼48~57
                        isNum = True
                    Case 65 To 90        '抓大寫英文的asc碼65~90
                        isEng = True
                    Case 97 To 122       '抓小寫英文的asc碼97~122
                        isEng = True
                    Case Else      '如果都不在以上條件就執行此條件
                        'm = m & b   '到此條件的都是英、數以外，把它拼成新的字串
                End Select

                If Encoding.Unicode.GetBytes(b)(1) = 255 Then
                    isAll = True
                End If
            Next
        End If

        If isAll Then
            Return "不可有全形字"
        End If
        If Not isNum And Not isEng Then
            Return "需由英數字組成"
        End If
        Return ""
    End Function

End Class


Public Class OCT
    Public Shared Function COct(ByVal dd As Double) As Double
        If CStr(dd).IndexOf(".") > 0 Then
            Dim d As Double = Mid(CStr(dd), CStr(dd).IndexOf(".") + 1)
            If d > 0 Then
                dd = dd + 0.1
            End If
        End If

        Return dd
    End Function

    Public Shared Function DOct(ByVal dd As Double) As Double
        If CStr(dd).IndexOf(".") > 0 Then
            Dim d As Double = Mid(CStr(dd), CStr(dd).IndexOf(".") + 1)
            If d > 0 Then
                dd = dd - 0.1
            End If
        End If

        Return dd
    End Function


    Public Function countAddRowNum(ByVal rownum As Integer, ByVal datarownum As Integer) As Integer


        'datarownum / rownum


    End Function


    Public Shared Sub cleanControl(ByRef P As System.Web.UI.Page)

        For Each control As Control In P.Page.Form.Controls

            If TypeName(control) = "TextBox" Then
                Dim txt As TextBox = CType(control, TextBox)
                If txt.Visible = True And txt.Enabled = True And txt.ReadOnly = False Then
                    txt.Text = ""
                End If
            ElseIf TypeName(control) = "DropDownList" Then
                Dim ddl As DropDownList = CType(control, DropDownList)
                If 0 < ddl.Items.Count And ddl.Enabled = True Then
                    ddl.SelectedIndex = 0
                End If
            ElseIf TypeName(control) = "RadioButton" Then
                Dim radbtn As RadioButton = CType(control, RadioButton)
                If radbtn.Enabled = True Then
                    radbtn.Checked = False
                End If
            End If
            If TypeName(control) = "CheckBox" Then
                Dim chb As CheckBox = CType(control, CheckBox)
                If chb.Enabled = True Then
                    chb.Checked = False
                End If
            End If
        Next

    End Sub

End Class