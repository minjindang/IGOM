Imports SYS.Logic
Imports System.Data
Imports System.IO

Partial Class MasterPage_MasterPage
    Inherits System.Web.UI.MasterPage

    Dim dao As New FuncDAO
    Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim pageName As String = ""
    Dim roleSql As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "unblockUI", "$.unblockUI();", True)

        If IsPostBack Then Return

        UcUsePDF.UrlName = System.IO.Path.GetFileName(Request.PhysicalPath)
        BindMenu()
        checkFreeze()
    End Sub

#Region "建立選單"
    ''' <summary>
    ''' 建立選單
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BindMenu()
        Dim aryPageName As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
        Dim aryProgramName As String() = Split(aryPageName(aryPageName.Length - 1).Replace(".aspx", ""), "_")
        pageName = aryProgramName(0)

        If CommonFun.GetAppSetting("FromWWW") = "Y" Then
            roleSql = "'WWW'"
        Else
            For Each role As String In LoginManager.RoleId.Split(",")
                roleSql += "'" + role.Trim() + "',"
            Next
            roleSql = roleSql.TrimEnd(",")
        End If

        ' 依人員，取得一階清單
        Dim dtData As DataTable = dao.getMenu001(Orgcode, idCard, roleSql)
        If dtData IsNot Nothing And dtData.Rows.Count > 0 Then
            For i As Integer = 0 To dtData.Rows.Count - 1
                Dim funcNum As String = dtData.Rows(i).Item("FUNCNUM")

                Dim tb As Control = FindControl("table" & funcNum)
                tb.Visible = True

                Dim tv As TreeView = CType(FindControl("TreeView" & funcNum), TreeView)
                PopulateRootLevel("IGSS" & funcNum, tv)

                Dim lb As Label = CType(FindControl("button" & funcNum), Label)
                lb.Text = dtData.Rows(i).Item("Func_name")
                lb.Visible = True
            Next
        End If


        Dim fdt As DataTable = dao.getFavoriteMenu(Orgcode, idCard, roleSql)
        If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
            table0000.Visible = True
            For Each dr As DataRow In fdt.Rows
                Dim tn As New TreeNode()
                tn.Text = dr("Func_name").ToString()
                tn.Value = dr("func_id").ToString()
                tn.NavigateUrl = dr("FUNC_URL").ToString()
                TreeView0000.Nodes.Add(tn)
            Next
        End If

    End Sub

    Private Sub PopulateRootLevel(ByVal Parent_func_id As String, ByVal tree As TreeView)
        Dim dt02 As DataTable = dao.getMenu002(Orgcode, idCard, Parent_func_id, roleSql)
        Dim isShow As Boolean = False

        For Each dr As DataRow In dt02.Rows
            Dim tn As New TreeNode()
            tn.Text = dr("Func_name").ToString()
            tn.Value = dr("func_id").ToString()
            If Not String.IsNullOrEmpty(dr("FUNC_URL").ToString()) Then
                tn.NavigateUrl = dr("FUNC_URL").ToString()
                If dr("FUNC_URL").ToString().IndexOf(pageName) >= 0 Then
                    isShow = True
                End If
            End If
            tn.SelectAction = TreeNodeSelectAction.Expand
            tree.Nodes.Add(tn)

            Dim dt03 As DataTable = dao.getMenu003(Orgcode, idCard, dr("func_id").ToString(), roleSql)
            Dim isExpand As Boolean = PopulateNodes(dt03, tn.ChildNodes)
            If isExpand Then
                tn.Expand()
                isShow = True
            End If

            If isShow Then
                Dim tr As Control = FindControl("tr" + Parent_func_id.Substring(4))
                CType(tr, HtmlTableRow).Attributes.Add("style", "")
            End If
        Next
    End Sub


    Private Function PopulateNodes(ByVal dt As DataTable, ByVal nodes As TreeNodeCollection) As Boolean
        Dim isExpand As Boolean = False
        For Each dr As DataRow In dt.Rows
            Dim tn As New TreeNode()
            tn.Text = dr("Func_name").ToString()
            tn.Value = dr("func_id").ToString()
            tn.NavigateUrl = dr("FUNC_URL").ToString()

            If dr("FUNC_URL").ToString().IndexOf(pageName) >= 0 Then
                isExpand = True
            End If

            nodes.Add(tn)
        Next
        Return isExpand
    End Function
#End Region

    Protected Sub ibOpen_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("Menu") = "open"
    End Sub

    Protected Sub ibClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Session("Menu") = "close"
    End Sub

    Protected Sub checkFreeze()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim aryPageName As String() = Split(HttpContext.Current.Request.PhysicalPath, "\")
        Dim strProgramName As String = aryPageName(aryPageName.Length - 1)

        Dim ff As SYS.Logic.FreezeFunc = New SYS.Logic.FreezeFunc
        Dim dt As DataTable = ff.getFreezeData(Orgcode, Depart_id, strProgramName)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, dt.Rows(0)("Func_name").ToString() + "作業功能已鎖定，不開放使用。", "../../FSC/FSC0/FSC0101_01.aspx")
        End If
    End Sub


End Class

