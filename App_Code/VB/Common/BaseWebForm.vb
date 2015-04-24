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
                'Me.Title = "�H�Ʈt�Ժ޲z�t��"

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

            '�L�o��CommonForms�ؿ��U���{�����P�_�O�_���v���ϥ�, �]��CommonForms�̪����O�Ѧ@�Ϊ�, �ҥH�|���ܦh���{���@�Ψ�, �]�����k�q��@�ӧP�_
            If LCase(aryPageName(aryPageName.Length - 2)) <> "Common" Then
                If (Not LoginManager.IsAdmininsrator) And (Not LoginManager.ISHasPermission(strProgramName)) Then
                    'ShowLoginMsg("�ܩ�p�A�z�S���ϥΦ��{���\�઺�v���A�Y�ݨ�U�Ь��t�κ޲z��!")
                    'Response.End()
                End If
            End If

        Else '�|���n�J�t��

            DoLogOut()
        End If
    End Sub
#End Region

#Region "��ܵn�J���A���v���P�_�������T��"
    Sub ShowLoginMsg(ByVal Msg As String)

        Dim context As HttpContext = HttpContext.Current

        Try

            context.Response.Write( _
                                "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                      "<h2><font color='red'>�t�ΰ���ɳQ�j��_</h2></font><hr/>" & _
                        "<pre>" & Msg & "</pre>")

        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "Page_Error"
    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error

        '���o���~����
        Dim currentError As Exception = Server.GetLastError()

        '���ͦ������~�����~�s��
        Dim strErrorCode As String = Now.Year & Right("00" & Now.Month, 2) & Right("00" & Now.Day, 2) & Right("00" & Now.Hour, 2) & Right("00" & Now.Minute, 2) & Right("00" & Now.Second, 2) & Right("00" & Now.Millisecond, 2)

        '�N���~�T���g�JLog�O���ɤ�
        If Not (TypeOf currentError Is AppException) Then
            AppException.WriteErrorLog(currentError.StackTrace, strErrorCode)
        End If

        '��ܦۭq�����~�T��
        ShowError(currentError, strErrorCode)

        '�M�����~�T�A�~���|�X�{���͵����C�����~�T����User�ݨ�
        Server.ClearError()

    End Sub
#End Region

#Region "ShowError"
    Public Shared Sub ShowError(ByVal currentError As Exception, ByVal ErrorCode As String)

        Dim context As HttpContext = HttpContext.Current
        Try

            '���o���~�T���n��ܪ��Ҧ�
            Dim strShowErrorMode As String = ConfigurationManager.AppSettings("ShowErrorMode").ToString

            If strShowErrorMode = "On" Then '��ܸԲӪ��t�ο��~��T

                'context.Response.Write( _
                '                        "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                '              "<h2>�t�ΰ���ɵo�Ϳ��~</h2><hr/>" & _
                '              "�������b����ɵo�ͤF���w�������~�F���~�T���w�g�Q�O������~�O���ɡA���~�s�����G" & ErrorCode & "�C<br/>" & _
                '              "<br/><b>���~�o�ͦb�G</b>" & _
                '                "<pre>" & context.Request.Url.ToString & "</pre>")
                context.Response.Write( _
                                    "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                          "<h2>�t�ΰ���ɵo�Ϳ��~</h2><hr/>" & _
                          "�������b����ɵo�ͤF���w�������~�F���~�T���w�g�Q�O������~�O���ɡA���~�s�����G" & ErrorCode & "�C<br/>" & _
                          "<br/><b>���~�o�ͦb�G</b>" & _
                            "<pre>" & context.Request.Url.ToString & "</pre>" & _
                          "<br/><b>���~�T���G</b>" & _
                            "<pre>" & currentError.Message.ToString & "</pre>" & _
                          "<br/><b>���~���|�T���G</b>" & _
                           "<pre>" & currentError.ToString & "</pre>")

            Else '�u��ܵo�Ϳ��~�A������ܸԲӪ��t�ο��~��T
                context.Response.Write( _
                                    "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                          "<h2>�t�ΰ���ɵo�Ϳ��~</h2><hr/>" & _
                          "<pre>�������b����ɵo�ͤF���w�������~�A�гq���t�κ޲z�̡C</pre><br/>")

            End If

        Catch ex As Exception

            AppException.WriteErrorLog(ex.ToString, Now.Year & Now.Month & Now.Day & Now.Hour & Now.Minute & Now.Second & Now.Millisecond)

            context.Response.Write( _
                                    "<link rel=""stylesheet"" href=""" & HttpContext.Current.Request.ApplicationPath & "/ErrorLog/error.css"">" & _
                                    "<h2>�t�ΰ���ɵo�Ϳ��~</h2><hr/>" & _
                                    "<pre>�t�γ]�w�ɪ���T�����T�A�ХߧY�q���t�κ޲z���C</pre><br/>")
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

    '#Region "�]�w�ݩʦW��(WebControl�άOHtmlControl) �P ���o�ݩʦW��"

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
    '    Private _FormType As String = String.Empty                      ' ������:�D��Z,�p:�s�а���, ��Z


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