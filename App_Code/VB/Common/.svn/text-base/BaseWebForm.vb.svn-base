Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System
Imports System.Configuration

Public Class BaseWebForm
    Inherits System.Web.UI.Page

#Region "Page_Load"
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If Not Me.IsPostBack Then
                'Me.Title = "人事差勤管理系統"

                If Not Request.UrlReferrer Is Nothing Then
                    Dim url As String = Request.UrlReferrer.ToString()
                    If url.Contains("FSC0102_01") Then
                        url = "~/FSC/FSC0/FSC0102_01.aspx?t=q"
                    End If
                    ViewState("BackUrl") = url
                End If
            End If

        Catch ex As Exception
            DoLogOut()
        End Try

    End Sub
#End Region

#Region "Page_PreLoad"
    Private Sub BasePage_PreLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreLoad

        If HttpContext.Current.User.Identity.IsAuthenticated Then

            Dim aryPageName As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
            Dim aryProgramName As String() = Split(aryPageName(aryPageName.Length - 1).Replace(".aspx", ""), "_")
            Dim strProgramName As String = aryProgramName(0)

            '過濾掉CommonForms目錄下的程式不判斷是否有權限使用, 因為CommonForms裡的表單是供共用的, 所以會有很多隻程式共用到, 因此為法從單一來判斷
            If LCase(aryPageName(aryPageName.Length - 2)) <> "Common" Then
                If (Not LoginManager.IsAdmininsrator) And (Not LoginManager.ISHasPermission(strProgramName)) Then
                    'ShowLoginMsg("很抱歉，您沒有使用此程式功能的權限，若需協助請洽系統管理者!")
                    'Response.End()
                End If
            End If

        Else '尚未登入系統

            DoLogOut()
        End If
    End Sub
#End Region

#Region "顯示登入狀態及權限判斷的相關訊息"
    Sub ShowLoginMsg(ByVal Msg As String)

        Dim context As HttpContext = HttpContext.Current

        Try

            context.Response.Write( _
                                "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                      "<h2><font color='red'>系統執行時被強制中斷</h2></font><hr/>" & _
                        "<pre>" & Msg & "</pre>")

        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "Page_Error"
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error

        '取得錯誤物件
        Dim currentError As Exception = Server.GetLastError()

        '產生此次錯誤的錯誤編號
        Dim strErrorCode As String = Now.Year & Right("00" & Now.Month, 2) & Right("00" & Now.Day, 2) & Right("00" & Now.Hour, 2) & Right("00" & Now.Minute, 2) & Right("00" & Now.Second, 2) & Right("00" & Now.Millisecond, 2)

        '將錯誤訊息寫入Log記錄檔中
        If Not (TypeOf currentError Is AppException) Then
            AppException.WriteErrorLog(currentError.StackTrace, strErrorCode)
        End If

        '顯示自訂的錯誤訊息
        ShowError(currentError, strErrorCode)

        '清掉錯誤訊，才不會出現不友善的低階錯誤訊息給User看到
        Server.ClearError()

    End Sub
#End Region

#Region "ShowError"
    Public Shared Sub ShowError(ByVal currentError As Exception, ByVal ErrorCode As String)

        Dim context As HttpContext = HttpContext.Current
        Try

            '取得錯誤訊息要顯示的模式
            Dim strShowErrorMode As String = ConfigurationManager.AppSettings("ShowErrorMode").ToString

            If strShowErrorMode = "On" Then '顯示詳細的系統錯誤資訊

                'context.Response.Write( _
                '                        "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                '              "<h2>系統執行時發生錯誤</h2><hr/>" & _
                '              "此頁面在執行時發生了未預期的錯誤；錯誤訊息已經被記錄於錯誤記錄檔，錯誤編號為：" & ErrorCode & "。<br/>" & _
                '              "<br/><b>錯誤發生在：</b>" & _
                '                "<pre>" & context.Request.Url.ToString & "</pre>")
                context.Response.Write( _
                                    "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                          "<h2>系統執行時發生錯誤</h2><hr/>" & _
                          "此頁面在執行時發生了未預期的錯誤；錯誤訊息已經被記錄於錯誤記錄檔，錯誤編號為：" & ErrorCode & "。<br/>" & _
                          "<br/><b>錯誤發生在：</b>" & _
                            "<pre>" & context.Request.Url.ToString & "</pre>" & _
                          "<br/><b>錯誤訊息：</b>" & _
                            "<pre>" & currentError.Message.ToString & "</pre>" & _
                          "<br/><b>錯誤堆疊訊息：</b>" & _
                           "<pre>" & currentError.ToString & "</pre>")

            Else '只顯示發生錯誤，但不顯示詳細的系統錯誤資訊
                context.Response.Write( _
                                    "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                          "<h2>系統執行時發生錯誤</h2><hr/>" & _
                          "<pre>此頁面在執行時發生了未預期的錯誤，請通知系統管理者。</pre><br/>")

            End If

        Catch ex As Exception

            AppException.WriteErrorLog(ex.ToString, Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond)

            context.Response.Write( _
                                    "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                                    "<h2>系統執行時發生錯誤</h2><hr/>" & _
                                    "<pre>系統設定檔的資訊不正確，請立即通知系統管理員。</pre><br/>")
        End Try


    End Sub
#End Region

#Region ""

    'Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
    '    ChangeInputLayout(Me)
    '    MyBase.Render(writer)
    'End Sub

    '#Region "ChangeInputLayout"
    '    Private Sub ChangeInputLayout(ByVal parent As Control)
    '        Dim i As Integer

    '        For i = 0 To parent.Controls.Count - 1 Step 1
    '            Dim control As Control = parent.Controls(i)
    '            Dim attr As String = GetAttribute(control, "XReadOnly")
    '            If attr = "true" Then
    '                Dim text As String = String.Empty
    '                Dim replace As Boolean = True
    '                Dim showtext As Boolean = True

    '                If TypeOf (control) Is TextBox Then
    '                    text = CType(control, TextBox).Text
    '                    If CType(control, TextBox).TextMode = TextBoxMode.MultiLine Then
    '                        text = text.Replace(vbCrLf, "<BR>")
    '                    End If
    '                ElseIf TypeOf (control) Is RadioButton Then
    '                    text = IIf(CType(control, RadioButton).Checked, CType(control, RadioButton).Text, "")
    '                ElseIf TypeOf (control) Is CheckBox Then
    '                    text = IIf(CType(control, CheckBox).Checked, CType(control, CheckBox).Text, "")
    '                ElseIf TypeOf (control) Is RadioButtonList Then

    '                    If CType(control, RadioButtonList).SelectedIndex > -1 Then
    '                        text = CType(control, RadioButtonList).SelectedItem.Text
    '                    Else
    '                        text = ""
    '                    End If


    '                ElseIf TypeOf (control) Is DropDownList Then
    '                    If CType(control, DropDownList).SelectedIndex > -1 Then
    '                        text = CType(control, DropDownList).SelectedItem.Text
    '                    Else
    '                        text = ""
    '                    End If
    '                ElseIf TypeOf (control) Is CheckBoxList Then
    '                    Dim item As ListItem
    '                    For Each item In CType(control, CheckBoxList).Items
    '                        text = text & item.Text & "<br>"
    '                    Next

    '                ElseIf TypeOf (control) Is ImageButton Then
    '                    showtext = False
    '                ElseIf TypeOf (control) Is HtmlImage Then
    '                    showtext = False
    '                Else
    '                    replace = False

    '                End If

    '                If replace Then
    '                    SetAttribute(control, "style", "display:none")
    '                    If showtext Then
    '                        Dim label As Literal = New Literal
    '                        label.ID = "x" & control.ID
    '                        label.Text = text
    '                        parent.Controls.AddAt(i + 1, label)
    '                    End If
    '                Else
    '                End If

    '            End If
    '            If control.HasControls Then
    '                ChangeInputLayout(control)
    '            End If

    '        Next
    '    End Sub
    '#End Region

    '#Region "設定屬性名稱(WebControl或是HtmlControl) 與 取得屬性名稱"

    '    Private Sub SetAttribute(ByVal control As Control, ByVal name As String, ByVal value As String)
    '        If TypeOf (control) Is WebControl Then
    '            CType(control, WebControl).Attributes(name) = value
    '        ElseIf TypeOf (control) Is HtmlControl Then
    '            CType(control, HtmlControl).Attributes(name) = value
    '        End If

    '    End Sub

    '    Private Function GetAttribute(ByVal control As Control, ByVal name As String) As String
    '        Dim attr As String = String.Empty
    '        If TypeOf (control) Is WebControl Then
    '            attr = CType(control, WebControl).Attributes(name)
    '        ElseIf TypeOf (control) Is HtmlControl Then
    '            attr = CType(control, HtmlControl).Attributes(name)
    '        End If
    '        If attr <> String.Empty Then
    '            attr = attr.Trim().ToLower()
    '        End If
    '        Return attr

    '    End Function

    '#End Region

    '    Private _ResourceID As String = String.Empty 
    '    Private _AppName As String = String.Empty 

    '    Private _currentState As String = String.Empty
    '    Private _FlowSystemName As String = String.Empty
    '    Private _instanceID As Guid = Guid.Empty
    '    Private _Did As Guid = Guid.Empty
    '    Private _FormDid As Guid = Guid.Empty
    '    Private _plurAlismID As String = String.Empty
    '    Private _FileUploadPath As String = String.Empty
    '    Private _FormType As String = String.Empty                      ' 表單種類:非草稿,如:新請假單, 草稿


    '#Region "Get"
    '    Public Property AppName() As String
    '        Get
    '            Return _AppName
    '        End Get
    '        Set(ByVal value As String)
    '            _AppName = value
    '        End Set
    '    End Property

    '    Public ReadOnly Property FlowSystemName() As String
    '        Get
    '            Return _FlowSystemName
    '        End Get

    '    End Property

    '    Public ReadOnly Property ResourceId() As String
    '        Get
    '            If _ResourceID = String.Empty Then
    '                If _AppName <> String.Empty Then
    '                    'Dim myRightManager As RightManager = New RightManager()

    '                    '_ResourceID = myRightManager.GetFunctionID(_AppName)
    '                End If
    '            End If
    '            Return _ResourceID
    '        End Get

    '    End Property

    '    Public Property DID() As Guid
    '        Get
    '            Return _Did
    '        End Get
    '        Set(ByVal value As Guid)
    '            _Did = value
    '        End Set
    '    End Property

    '    Public Property FormDID() As Guid
    '        Get
    '            Return _FormDid
    '        End Get
    '        Set(ByVal value As Guid)
    '            _FormDid = value
    '        End Set
    '    End Property

    '    Public Property InstanceID() As Guid
    '        Get
    '            Return _instanceID
    '        End Get
    '        Set(ByVal value As Guid)
    '            _instanceID = value
    '        End Set
    '    End Property

    '    Public ReadOnly Property FileUploadPath()
    '        Get
    '            If _FileUploadPath = String.Empty Then
    '                If ConfigurationManager.AppSettings("FileuploadPath") IsNot Nothing Then
    '                    _FileUploadPath = ConfigurationManager.AppSettings("FileuploadPath").ToString()
    '                End If
    '            End If
    '            Return _FileUploadPath

    '        End Get
    '    End Property

    '    Public Property FormType() As String
    '        Get
    '            Return _FormType
    '        End Get
    '        Set(ByVal value As String)
    '            _FormType = value
    '        End Set
    '    End Property

    '#End Region

#End Region

#Region "LogOut"
    Sub DoLogOut()
        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.FromAD) = "1" Then
            Response.Write("<script>window.opener = null; window.open('','_self'); window.close();</script>")
        Else
            Response.Redirect("~/login.aspx")
        End If
    End Sub
#End Region

End Class