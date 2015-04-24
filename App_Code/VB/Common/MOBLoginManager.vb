Imports Microsoft.VisualBasic
Imports System.Web.Configuration
Imports System.Web
Imports System
Imports System.Web.Security
Imports IGOM.Logic
Imports System.Security.Cryptography
Imports System.Security.Principal

Public Class MOBLoginManager

    '登入管理者物件

    '#Region "模組權限列舉"
    '    '//這裡的列舉ID必須和模組設定檔(SysModules.xml)裡的ID一致
    '    Enum ModulesPermission

    '        RolesManage = 1         '角色維護
    '        ManagersManage = 2      '管理者維護

    '    End Enum
    '#End Region

#Region "登入者驗證裡的Data列舉"
    Enum LoginUserData

        Account = 0     '登入者員工編號
        User_name = 1   '姓名
        Id_card = 2     '當下使用者員工編號

        Title_no = 3    '職稱代碼
        Orgcode = 4     '機關代碼
        Depart_id = 5   '單位代碼
        DepartName = 6 '單位名稱
        Email = 7       'email
        RoleId = 8      '角色
        IsAdministrator = 9
        Personnel_id = 10
        Service_type = 11
        Boss_Level_id = 14

        '以下預計刪除
        MetadbID = 12
        FromAD = 13
        'Subdepartment = 14
        Id_number = 15
        isGeneral = 16

    End Enum
#End Region

#Region "Property"
    Public Shared ReadOnly Property OrgCode() As String
        Get
            Return GetTicketUserData(LoginUserData.Orgcode)
        End Get
    End Property

    Public Shared ReadOnly Property Depart_id() As String
        Get
            Return GetTicketUserData(LoginUserData.Depart_id)
            'Dim departId As String = GetTicketUserData(LoginUserData.Depart_id)
            'If Not String.IsNullOrEmpty(departId) AndAlso departId.Length >= 6 Then
            '    Return departId.Substring(0, 2)
            'Else
            '    Return ""
            'End If
        End Get
    End Property

    Public Shared ReadOnly Property UserId() As String
        Get
            Return GetTicketUserData(LoginUserData.Id_card)
            'Dim user_id As String = GetTicketUserData(LoginUserData.Id_card)
            'If Not String.IsNullOrEmpty(user_id) AndAlso user_id.Length >= 6 Then
            '    Return user_id.Substring(0, 6)
            'Else
            '    Return ""
            'End If
        End Get
    End Property

    Public Shared ReadOnly Property UserName() As String
        Get
            Return GetTicketUserData(LoginUserData.User_name)
        End Get
    End Property

    Public Shared ReadOnly Property TitleNo() As String
        Get
            Return GetTicketUserData(LoginUserData.Title_no)
        End Get
    End Property

    Public Shared ReadOnly Property Account() As String
        Get
            Return GetTicketUserData(LoginUserData.Account)
        End Get
    End Property


    Public Shared ReadOnly Property RoleId() As String
        Get
            Return GetTicketUserData(LoginUserData.RoleId)
        End Get
    End Property


    Public Shared ReadOnly Property BossLevelId() As String
        Get
            Return GetTicketUserData(LoginUserData.Boss_Level_id)
        End Get
    End Property
#End Region

#Region "檢查是否有登入系統"
    Public Shared Sub IsLogined(ByVal JsRedirectCode As String)
        Dim blnFlag As Boolean = False
        If Not HttpContext.Current.User.Identity.IsAuthenticated Then '沒有登入 
            HttpContext.Current.Response.Write("<script language='javascript'>" & JsRedirectCode & "</script>")
            HttpContext.Current.Response.End()
        End If
    End Sub
#End Region

    '#Region "檢查是否有登入系統及是否有權限使用模組功能"
    '    Public Shared Function Check(ByVal mPermission As ModulesPermission, ByVal JsRedirectCode As String)
    '        Dim blnFlag As Boolean = False
    '        If Not HttpContext.Current.Request.IsAuthenticated Then '沒有登入
    '            HttpContext.Current.Response.Write("你沒有登入!")
    '            blnFlag = True
    '        Else
    '            '不是最高管理者，而且無權限使用該模組者
    '            If (Not LoginManager.IsAdmininsrator()) And (Not LoginManager.ISHasPermission(mPermission)) Then
    '                HttpContext.Current.Response.Write("很抱歉，您沒有權限使用此系統功能!")
    '                blnFlag = True
    '            End If
    '        End If
    '        If blnFlag = True Then
    '            HttpContext.Current.Response.Write("<script language='javascript'>" & JsRedirectCode & "</script>")
    '            HttpContext.Current.Response.End()
    '        End If
    '    End Function
    '#End Region

#Region "取得驗證票裡的UserData"
    '//經測試，UserData必須登入後，下次的頁面動作才有辨法取到，若是同時在登入時，要再取時
    '//則會有轉換錯誤的問題
    Public Shared Function GetTicketUserData(ByVal UserDataItem As LoginUserData) As String
        Dim strAryUserData() As String
        Try
            'strAryUserData = Split(CType(System.Web.HttpContext.Current.User.Identity, System.Web.Security.FormsIdentity).Ticket.UserData, ";")

            '
            Dim userDataCookie As HttpCookie = System.Web.HttpContext.Current.Request.Cookies("UserDataCookie")
            strAryUserData = HttpContext.Current.Server.UrlDecode(userDataCookie.Value).Split(";")

            Dim int As Integer = CType(UserDataItem, Integer)
            If CType(UserDataItem, Integer) <= strAryUserData.Length - 1 Then
                Return strAryUserData(UserDataItem)
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
#End Region

#Region "是否為最高管理者"
    Public Shared Function IsAdmininsrator() As Boolean
        Dim bteAdmin As Byte = GetTicketUserData(LoginUserData.IsAdministrator)
        If bteAdmin = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region "判斷是否有權限使用某一隻模組程式"
    Public Shared Function ISHasPermission(ByVal ProgramName As String) As Boolean

        '取得登入者可以使用的程式名稱
        Dim UserPrograms As String = LoginInfo.GetMemberModules(OrgCode, RoleId) 'HttpContext.Current.Session("ModulePrograms")

        If InStr(LCase(UserPrograms), LCase(ProgramName)) <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function
#End Region

#Region "設定驗證票"

    Shared Sub SetAuthenTicket(ByVal UserData As String, ByVal UserID As String)

        '宣告一個驗證票
        Dim ticket As New FormsAuthenticationTicket(1, UserID, DateTime.Now, DateTime.Now.AddHours(8), False, UserData)

        '加密驗證票
        Dim encryptedTicket As String = FormsAuthentication.Encrypt(ticket)

        '建立Cookie
        Dim authenticationcookie As New HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)

        '將Cookie寫入回應 (set HttpContext.Current.User)
        HttpContext.Current.Response.Cookies.Add(authenticationcookie)

        '
        Dim userDataCookie As New HttpCookie("UserDataCookie", HttpContext.Current.Server.UrlEncode(UserData))
        HttpContext.Current.Response.Cookies.Add(userDataCookie)

        SetOtherAuth(UserData)

    End Sub

#End Region

    Private Shared Sub SetOtherAuth(ByVal UserData As String)

        Dim Orgcode As String = UserData.Split(";")(LoginUserData.Orgcode)
        Dim DepartID As String = UserData.Split(";")(LoginUserData.Depart_id)
        Dim Id_card As String = UserData.Split(";")(LoginUserData.Id_card)
        Dim RoleId As String = UserData.Split(";")(LoginUserData.RoleId)

        '傳入模組權限，取得相對應能夠使用的程式名稱
        'Dim ModulePrograms As String = LoginInfo.GetMemberModules(Orgcode, RoleId)

        ''將目前登入者能夠使用的程式名稱放到Session（PS:Cookie由於有長度限制，所以不放到Cookie中)
        'HttpContext.Current.Session("ModulePrograms") = ModulePrograms

        '記錄登入時間 MOB 不使用
        'LoginInfo.RecordLogin(Orgcode, DepartID, Id_card, "1")
    End Sub

End Class
