Imports Microsoft.VisualBasic

Imports System.Collections.Generic
Imports System.Web

'***自己宣告（加入）*****************************
Imports System.Text
Imports System.Collections
Imports System.Web.Security

Imports System.Security.Principal
Imports System.DirectoryServices  '需要先把DLL檔「加入參考」。
'***********************************************
Namespace FormsAuth
    Public Class LdapAuthentication
        Private _path As String
        Private _filterAttribute As String
        Private entry As DirectoryEntry

        Public Sub New(path As String)
            _path = path
        End Sub


        ' 此程式碼使用 LDAP目錄提供者。驗證成功傳回 true。
        ' Default_01_Login.aspx頁面中的程式碼會呼叫 .LdapAuthentication.IsAuthenticated()方法，並傳入從使用者收集的認證。
        ' 接著，會使用目錄服務的路徑、使用者名稱與密碼建立 DirectoryEntry物件。
        ' 使用者名稱的格式必須是 domain\username。
        Public Function IsAuthenticated(domain As String, username As String, pwd As String) As Boolean
            Dim domainAndUsername As String = domain & "\" & username
            entry = New DirectoryEntry(_path, domainAndUsername, pwd)

            Try
                'Bind to the native AdsObject to force authentication.
                Dim obj As Object = entry.NativeObject
                'DirectoryEntry 物件接著會取得 NativeObject屬性，以嘗試強制 AdsObject 進行繫結。
                '若此動作成功，會取得使用者的 CN屬性，方式是建立 DirectorySearcher物件並篩選 sAMAccountName。

                Dim search As New DirectorySearcher(entry)

                search.Filter = "(SAMAccountName=" & username & ")"
                search.PropertiesToLoad.Add("cn")
                Dim result As SearchResult = search.FindOne()

                If result Is Nothing Then
                    Return False
                End If

                'Update the new path to the user in the directory.
                _path = result.Path
                _filterAttribute = DirectCast(result.Properties("cn")(0), String)
            Catch ex As Exception
                Throw New Exception("Error authenticating user. " & ex.Message)
            End Try
            Return True
        End Function

        '取得使用者所屬的安全性與通訊群組清單，方式是建立 DirectorySearcher物件並根據 memberOf屬性進行篩選。
        '此方法會傳回由管道 (|) 分隔的群組清單。
        '每個群組的格式看起來像這樣 CN=...,...,DC=domain,DC=com
        Public Function GetGroups() As String
            Dim search As New DirectorySearcher(entry)
            search.Filter = "(cn=" & _filterAttribute & ")"
            search.PropertiesToLoad.Add("memberOf")
            Dim groupNames As New StringBuilder()

            Try
                Dim result As SearchResult = search.FindOne()
                Dim propertyCount As Integer = result.Properties("memberOf").Count
                Dim dn As String
                Dim equalsIndex As Integer, commaIndex As Integer

                For propertyCounter As Integer = 0 To propertyCount - 1
                    dn = DirectCast(result.Properties("memberOf")(propertyCounter), String)
                    equalsIndex = dn.IndexOf("=", 1)
                    commaIndex = dn.IndexOf(",", 1)
                    If -1 = equalsIndex Then
                        Return Nothing
                    End If
                    groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1))
                    '傳回由管道 (|) 分隔的群組清單。
                    groupNames.Append("|")
                Next
            Catch ex As Exception
                Throw New Exception("Error obtaining group names. " & ex.Message)
            End Try
            Return groupNames.ToString()
        End Function
    End Class
End Namespace
