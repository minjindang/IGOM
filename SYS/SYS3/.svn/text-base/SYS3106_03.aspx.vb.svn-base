Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports System.Transactions

Partial Class SYS3106_03
    Inherits BaseWebForm


#Region "全域宣告"
    Dim strParent_func_id As String = ""
    Dim sbXmlBuilder As New StringBuilder()
    Dim dt As DataTable
#End Region

#Region "Page_Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim roleId As String = Request.QueryString("rid")
        Dim r As New SYS.Logic.Role()

        Dim dt As DataTable = r.GetRole(orgcode, roleId)
        If dt.Rows.Count > 0 Then lblRoleName.Text = dt.Rows(0)("Role_name").ToString()

        If Not Me.IsPostBack Then
            SaveXml()
            '載入系統模組檔案(Modules.sitemap)
            Dim xmlObj As System.Xml.XmlDocument = CommonFun.LoadXML(Request.PhysicalApplicationPath & "Config\Modules.sitemap")
            Dim nodeRoot As System.Xml.XmlElement = xmlObj.DocumentElement

            '取得角色所擁有的模組權限
            '建立Tree選單
            Me.treeMenu.Nodes.Add(MakeModuleTree(nodeRoot, r.GetRolefunction(orgcode, roleId)))

            treeMenu.Attributes.Add("onclick", "checkCheckBox()")
        End If
    End Sub
#End Region

#Region "關閉"
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("SYS3106_01.aspx")
    End Sub
#End Region

#Region "確認"
    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnOK2.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim roleId As String = Request.QueryString("rid")
        Dim r As New SYS.Logic.Role()

        Dim strCheckedModulesID As String = GetCheckedModuleID(Me.treeMenu.Nodes(0))
        Dim aryModulesID() As String = Split(strCheckedModulesID, ",")

        Try
            Using trans As New TransactionScope

                '先刪除該角色所有的模組權限
                r.DeleteRoleModules(orgcode, roleId)

                '逐一加入勾選的模組權限
                For i As Integer = 0 To aryModulesID.Length - 1
                    If aryModulesID(i) <> "" And aryModulesID(i) <> "0" Then
                        r.AddRoleModule(orgcode, roleId, aryModulesID(i), LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account))
                    End If
                Next

                trans.Complete()
            End Using

            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "角色權限設定成功", "SYS3106_01.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
        End Try

    End Sub
#End Region

#Region "產出xml檔"
    Protected Sub SaveXml()
        Dim ReportPath As String = "~/Config"

        sbXmlBuilder.AppendLine("<?xml version=""1.0"" encoding=""utf-8"" ?>")
        sbXmlBuilder.AppendLine("<siteMap id=""IGSS0000"" moduleName=""整合性總務管理資訊系統"" description=""回到首頁"" >")
        sub_Xml("IGSS0000")

        sbXmlBuilder.AppendLine("</siteMap>")

        CommonFun.DeleteFile(Server.MapPath(ReportPath), "Modules.sitemap")
        CommonFun.SaveFile(sbXmlBuilder.ToString, Server.MapPath(ReportPath & "/Modules.sitemap"))
    End Sub

    Protected Sub sub_Xml(ByVal func_id As String)

        Dim func As New SYS.Logic.Func()
        Dim dv As New DataView
        dv = func.GetFunc().DefaultView
        dv.RowFilter = " parent_func_id='" & func_id & "'"
        For Each dvRow As DataRowView In dv.ToTable.DefaultView

            If strParent_func_id.IndexOf(Convert.ToString(dvRow("func_id"))) < 0 Then
                sbXmlBuilder.AppendLine("<siteMapNode id=""" & Convert.ToString(dvRow("Func_id")) & """ moduleName=""" & Convert.ToString(dvRow("Func_name")) & """ description="""" url=""" & Convert.ToString(dvRow("Func_url")) & """ >")
                sub_Xml(Convert.ToString(dvRow("func_id")))
                sbXmlBuilder.AppendLine("</siteMapNode>")
            End If

            strParent_func_id &= Convert.ToString(dvRow("func_id")) & ","

        Next
        dv.Dispose()
    End Sub
#End Region

#Region "建立系統模組TreeView選單"
    ''' <summary>
    ''' 建立供設定角色權限的模組Tree選單
    ''' </summary>
    ''' <param name="nodeElement">要建立權限Tree選單的起始節點</param>
    ''' <param name="dsModules">目前擁有之節點權限的DataSet</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function MakeModuleTree(ByVal nodeElement As System.Xml.XmlElement, ByVal strModules As String) As TreeNode

        Dim myNodeElement As System.Xml.XmlElement
        Dim treeNode As New TreeNode '建立新節點
        Dim strModuleID As String

        '取得目前要建立之節點的模組ID
        strModuleID = nodeElement.GetAttribute("id")

        '指定節點的各屬性值
        treeNode.Text = nodeElement.GetAttribute("moduleName")
        treeNode.SelectAction = TreeNodeSelectAction.Expand
        treeNode.Value = strModuleID

        '若傳入的節點id為0，則表示它是最上層的根節點，設定根節點的圖形
        If strModuleID = "0" Then
            treeNode.ImageUrl = "~/img/root.gif"
        End If

        '比對傳入的dsModules，判斷是否擁有目前要建立之節點的權限，若有則將CheckBox設為勾選狀態 
        If strModules.IndexOf(strModuleID) >= 0 Then
            treeNode.Checked = True
        End If

        '再逐筆建立目前傳入之節點下的所有子節點的選單
        For Each myNodeElement In nodeElement.ChildNodes
            treeNode.ChildNodes.Add(MakeModuleTree(myNodeElement, strModules))
        Next

        '回傳建立好的節點選單

        Return treeNode

    End Function
#End Region

#Region "取得系統模組的Tree選單節點中，有勾選之節點的ModuleID，以「,」區隔"
    ''' <summary>
    ''' 取得系統模組的Tree選單節點中，有勾選之節點的模組ID組合值。
    ''' </summary>
    ''' <param name="treeNode">要檢查是否勾選的起始節點</param>
    ''' <returns>回傳有勾選之模組節點的模組ID，以以「,」區隔開每個模組的唯一ID值</returns>
    ''' <remarks></remarks>
    Public Shared Function GetCheckedModuleID(ByVal treeNode As TreeNode) As String

        Dim strModulesID As String = ""

        '若有勾選此節點，則記錄節點的Module ID值
        If treeNode.Checked = True Then
            strModulesID = treeNode.Value
        End If

        '再逐一的呼叫節點下的子節點，檢查勾選狀態
        For Each myNode As TreeNode In treeNode.ChildNodes
            Dim strTempModulesID As String = GetCheckedModuleID(myNode)
            If strTempModulesID <> "" Then
                If strModulesID = "" Then
                    strModulesID = strTempModulesID
                Else
                    strModulesID = strModulesID & "," & strTempModulesID
                End If
                If strModulesID.IndexOf(myNode.Parent.Value) < 0 Then
                    strModulesID &= "," & myNode.Parent.Value
                End If
            End If
        Next

        Return strModulesID

    End Function
#End Region

End Class
