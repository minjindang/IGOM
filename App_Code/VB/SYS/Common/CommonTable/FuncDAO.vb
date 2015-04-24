Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.UI.WebControls
Imports System.Text
Imports System

Namespace SYS.Logic
    Public Class FuncDAO
        Inherits BaseDAO

        Dim sbSQL As New StringBuilder()

        Public Function GetFunc() As DataTable
            Dim SQL As String = " select * from SYS_func order by func_id,parent_func_id,func_sort "
            Return Query(SQL)
        End Function

        Public Function getDataByUrl(ByVal Func_url As String) As DataTable
            Dim sql As String = " select * from SYS_func where Func_url like @Func_url "

            Dim param(0) As SqlParameter
            param(0) = New SqlParameter("@Func_url", SqlDbType.VarChar)
            param(0).Value = "%" + Func_url + "%"

            Return Query(sql, param)
        End Function

#Region "依FuncId取得選單"
        Function getDataMenuByFuncId(ByVal funcId As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append("Select * From SYS_Func WHERE (Func_id  = @Func_id ) and Func_type <> 'N' ORDER BY  Func_sort , Func_id, Func_type ")
            Dim params() As SqlParameter = {New SqlParameter("@Func_id", funcId)}
            Return Query(sSQL.ToString, params)
        End Function
#End Region

#Region "依父層取得選單"
        Function getDataMenuByParentFuncId(ByVal parentFuncId As String) As DataTable
            Dim sSQL As New StringBuilder()
            sSQL.Append("Select * From SYS_Func WHERE (Parent_func_id  = @Parent_func_id ) and Func_type <> 'N' ORDER BY  Func_sort , Func_id, Func_type ")
            Dim params() As SqlParameter = {New SqlParameter("@Parent_func_id", parentFuncId)}
            Return Query(sSQL.ToString, params)
        End Function
#End Region

#Region "依人員及父層取得選單"
        Function getDataMenuByPersonelId(ByVal ParentFuncId As String, ByVal Id_card As String, ByVal Orgcode As String) As DataTable
            Dim sql As String = ""
            Dim dt As DataTable = New FSC.Logic.Personnel().GetDataByIdCard(Id_card)
            For i As Integer = 0 To dt.Rows.Count - 1
                For Each role As String In dt.Rows(i)("role_id").ToString().Split(",")
                    sql += "'" + role.Trim() + "',"
                Next
            Next
            Dim sSQL As New StringBuilder()
            sSQL.AppendLine(" Select distinct fc.* From SYS_Func fc , SYS_Role_function rf , FSC_Personnel p ")
            sSQL.AppendLine(" Where fc.Func_id = rf.Func_id ")
            sSQL.AppendLine(" And p.id_Card = @Id_card ")
            sSQL.AppendLine(" And rf.Role_id in ( " + sql.TrimEnd(",") + ")")
            sSQL.AppendLine(" And (fc.Parent_func_id  = @ParentFuncId ) and fc.Func_type <> 'N' ")
            sSQL.AppendLine(" ORDER BY  fc.Func_sort , fc.Func_id, fc.Func_type ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@ParentFuncId", ParentFuncId), _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Orgcode", Orgcode)}
            Return Query(sSQL.ToString, params)
        End Function
#End Region


#Region "依人員及父層取得選單"
        Function getDataMenuByPersonelId(ByVal ParentFuncId As String, ByVal Id_card As String, ByVal Orgcode As String, ByVal roleSql As String) As DataTable

            Dim sSQL As New StringBuilder()
            sSQL.AppendLine(" Select distinct fc.* From SYS_Func fc , SYS_Role_function rf , FSC_Personnel p ")
            sSQL.AppendLine(" Where fc.Func_id = rf.Func_id ")
            sSQL.AppendLine(" And p.id_Card = @Id_card ")
            sSQL.AppendLine(" And rf.Role_id in ( " + roleSql + ")")
            sSQL.AppendLine(" And (fc.Parent_func_id  = @ParentFuncId ) and fc.Func_type <> 'N' ")
            sSQL.AppendLine(" ORDER BY  fc.Func_sort , fc.Func_id, fc.Func_type ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@ParentFuncId", ParentFuncId), _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Orgcode", Orgcode)}
            Return Query(sSQL.ToString, params)
        End Function
#End Region

#Region "By DAO"
        Sub MenuItem(ByVal menu As Menu, ByVal mu As MenuItem, ByVal FuncId As String, ByVal Level As Integer, ByVal PersonnelId As String)
            Dim tmp As MenuItem
            'Using dao As New FuncTableAdapters.FuncTableAdapter
            '取得ParentFuncId 為 funcId的資料
            Dim dao As FuncDAO = New FuncDAO()
            Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Dim id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

            Dim dt As DataTable = dao.getDataMenuByPersonelId(FuncId, PersonnelId, Orgcode)
            If Not dt Is Nothing Then
                Dim text As String = String.Empty
                Dim value As String = String.Empty
                Dim url As String = String.Empty
                For Each row As DataRow In dt.Rows
                    tmp = New MenuItem()

                    If Not row("Func_name") Is Nothing And Not DBNull.Value.Equals(row("Func_name")) Then
                        text = row("Func_name")
                    Else
                        text = String.Empty
                    End If
                    If Not row("Func_url") Is Nothing And Not DBNull.Value.Equals(row("Func_url")) Then
                        url = row("Func_url")
                    Else
                        url = String.Empty
                    End If
                    If Not row("Func_id") Is Nothing And Not DBNull.Value.Equals(row("Func_id")) Then
                        value = row("Func_id")
                    Else
                        value = String.Empty
                    End If


                    tmp.Text = text
                    tmp.Value = value
                    tmp.NavigateUrl = url

                    MenuItem(menu, tmp, value, Level + 1, PersonnelId)
                    If Level = 0 Then

                        Select Case tmp.Value
                            Case "FSC1600" '變更密碼
                                If Not "1".Equals(LoginManager.GetTicketUserData(LoginManager.LoginUserData.FromAD)) Then
                                    menu.Items.Add(tmp)
                                End If
                            Case Else
                                menu.Items.Add(tmp)
                        End Select

                    Else

                        ''0980901人立  TC09808280001	加班補休/公差補休（檢查局）
                        ''1.	檢查局不能有「公差補休」的功能，只能顯示「加班補休」。
                        'If Orgcode.Trim.Equals("367040000D") And tmp.Value.Trim.Equals("FSC1204") Then
                        '    tmp.Text = tmp.Text.Replace("/公差補休", "")
                        'End If
                        'Select Case tmp.Value
                        '    Case "FSC1207" '忘帶卡
                        '        If Orgcode = "367030000D" Then  '保險局
                        '            mu.ChildItems.Add(tmp)
                        '        End If
                        '        'Case "FSC3302", "FSC3303" '刷卡資料更新,刷卡記錄更新維護
                        '        '    If Orgcode = "367020000D" Then  '證期局
                        '        '        mu.ChildItems.Add(tmp)
                        '        '    End If
                        '    Case Else
                        '        mu.ChildItems.Add(tmp)
                        'End Select

                        Select Case tmp.Value

                            Case "FSC1303"  '公差/出
                                'Dim p2kconnstr As String = ConnectDB.GetCPADBString(LoginManager.GetTicketUserData(LoginManager.LoginUserData.MetadbID))
                                'Dim PEMEMCOD As String = New FSCPLM.Logic.CPAPE05M(p2kconnstr).GetColumnValue("PEMEMCOD", id_card)
                                ''臨時人員
                                'If PEMEMCOD = "4" Then
                                '    Dim bll As New FSCPLM.Logic.FSC3710()
                                '    Dim ofdt As DataTable = bll.getData(Orgcode, id_card, FSCPLM.Logic.DateTimeInfo.GetRocDate(Now))

                                '    If ofdt IsNot Nothing AndAlso ofdt.Rows.Count > 0 Then
                                '        mu.ChildItems.Add(tmp)
                                '    End If
                                'Else
                                '    mu.ChildItems.Add(tmp)
                                'End If

                            Case Else
                                mu.ChildItems.Add(tmp)
                        End Select


                    End If
                Next
            End If
            'End Using
        End Sub
#End Region

        ''' <summary>
        ''' 取得一階清單
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="Id_card"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function getFavoriteMenu(ByVal Orgcode As String, ByVal Id_card As String, ByVal roleSql As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine(" SELECT DISTINCT FC.Func_id, FC.Func_name, FC.Func_url ")
            sbSQL.AppendLine(" FROM SYS_Func FC, SYS_Role_function RF, FSC_Personnel P, SYS_Favorite F ")
            sbSQL.AppendLine(" WHERE FC.Func_id=RF.Func_id ")
            sbSQL.AppendLine(" AND F.Func_id=FC.Func_id ")
            sbSQL.AppendLine(" AND F.Id_card=P.Id_card ")
            sbSQL.AppendLine(" AND F.Orgcode=RF.Orgcode ")
            sbSQL.AppendLine(" AND RF.Role_id in ( " + roleSql + ")")
            sbSQL.AppendLine(" AND P.id_Card=@Id_card ")
            sbSQL.AppendLine(" AND RF.Orgcode=@Orgcode ")
            sbSQL.AppendLine(" AND FC.Func_type <> 'N' ")
            sbSQL.AppendLine(" AND FC.Visable_type='Y' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Query(sbSQL.ToString, params)
        End Function

        ''' <summary>
        ''' 取得一階清單
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="Id_card"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function getMenu001(ByVal Orgcode As String, ByVal Id_card As String, ByVal roleSql As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine(" SELECT DISTINCT FC.Func_id,FC.Func_name,RIGHT(FC.Func_id,4) FUNCNUM, FC.Func_url, FC.Func_sort ")
            sbSQL.AppendLine(" FROM SYS_Func FC ,SYS_Role_function RF,FSC_Personnel P ")
            sbSQL.AppendLine(" WHERE FC.Func_id=RF.Func_id ")
            sbSQL.AppendLine(" AND RF.Role_id in ( " + roleSql + ")")
            sbSQL.AppendLine(" And P.id_Card=@Id_card ")
            sbSQL.AppendLine(" AND RIGHT(FC.Func_id,3)='000' AND RIGHT(FC.Func_id,4)<>'0000' ")
            sbSQL.AppendLine(" AND FC.Func_type='G' ")
            sbSQL.AppendLine(" AND FC.Func_type <> 'N' ")
            sbSQL.AppendLine(" AND FC.Visable_type='Y' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Query(sbSQL.ToString, params)
        End Function

        Function getMenu002(ByVal Orgcode As String, ByVal Id_card As String, ByVal Parent_func_id As String, ByVal roleSql As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine(" SELECT  DISTINCT fc.func_id,fc.Parent_func_id,Func_name,FC.FUNC_URL,(select count(*) FROM SYS_Func FC1 WHERE FC1.Parent_func_id=FC.Parent_func_id) childnodecount ")
            sbSQL.AppendLine(" FROM SYS_Func FC ,SYS_Role_function RF,FSC_Personnel P ")
            sbSQL.AppendLine(" WHERE FC.Func_id=RF.Func_id ")
            sbSQL.AppendLine(" AND RF.Role_id in ( " + roleSql + ")")
            sbSQL.AppendLine(" And P.id_Card=@Id_card ")
            sbSQL.AppendLine(" AND Parent_func_id=@Parent_func_id")
            sbSQL.AppendLine(" AND FC.Func_type <> 'N' ")
            sbSQL.AppendLine(" AND FC.Visable_type='Y' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Parent_func_id", Parent_func_id), _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Query(sbSQL.ToString, params)
        End Function

        Function getMenu003(ByVal Orgcode As String, ByVal Id_card As String, ByVal Parent_func_id As String, ByVal roleSql As String) As DataTable
            sbSQL.Length = 0

            sbSQL.AppendLine(" SELECT  DISTINCT fc.func_id,fc.Parent_func_id,Func_name,FC.FUNC_URL ")
            sbSQL.AppendLine(" FROM SYS_Func FC ,SYS_Role_function RF,FSC_Personnel P ")
            sbSQL.AppendLine(" WHERE FC.Func_id=RF.Func_id ")
            sbSQL.AppendLine(" AND RF.Role_id in ( " + roleSql + ")")
            sbSQL.AppendLine(" And P.id_Card=@Id_card ")
            sbSQL.AppendLine(" AND Parent_func_id=@Parent_func_id")
            sbSQL.AppendLine(" AND FC.Func_type <> 'N' ")
            sbSQL.AppendLine(" AND FC.Visable_type='Y' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", Id_card), _
            New SqlParameter("@Parent_func_id", Parent_func_id), _
            New SqlParameter("@Orgcode", Orgcode)}

            Return Query(sbSQL.ToString, params)
        End Function
    End Class
End Namespace