Imports System
Imports System.Data
Imports FSC.Logic
Imports System.Collections.Generic

Partial Class SYS2108_01
    Inherits BaseWebForm

    Dim idCard As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim roleSql As String = ""
    Dim dao As New SYS.Logic.FuncDAO()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        GenTree()
    End Sub

    Protected Sub GenTree()
        tv.Nodes.Clear()

        Dim func As New SYS.Logic.Func()
        For Each role As String In LoginManager.RoleId.Split(",")
            roleSql += "'" + role.Trim() + "',"
        Next
        roleSql = roleSql.TrimEnd(",")

        Dim dt As DataTable = dao.getMenu001(Orgcode, idCard, roleSql)

        tv.Nodes.Add(New TreeNode("整合性總務作業管理資訊系統", "IGSS0000"))
        AddNode(tv.Nodes.Item(0), dt)

        tv.ExpandAll()
    End Sub

    Protected Sub AddNode(ByVal n As TreeNode, ByVal dt As DataTable)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            Dim node As New TreeNode
            node.Value = dr("Func_id").ToString()
            node.Text = dr("Func_name").ToString()
            If Not String.IsNullOrEmpty(dr("Func_url").ToString()) Then
                node.NavigateUrl = dr("Func_url").ToString()
            End If
            n.ChildNodes.Add(node)
            Dim ndt As DataTable = dao.getDataMenuByPersonelId(dr("Func_id").ToString(), idCard, Orgcode, roleSql)
            If ndt IsNot Nothing AndAlso ndt.Rows.Count > 0 Then
                AddNode(n.ChildNodes.Item(i), ndt)

            End If
            i += 1
        Next
    End Sub

    Protected Sub cbQuery_Click(sender As Object, e As EventArgs)
        GenTree()
        For Each node As TreeNode In tv.Nodes
            CheckKeyWord(node)
        Next
    End Sub


    Protected Function CheckKeyWord(node As TreeNode) As Boolean
        Dim b As Boolean = False
        Dim nodeList As New List(Of TreeNode)

        For Each n As TreeNode In node.ChildNodes

            If n.ChildNodes.Count > 0 Then
                Dim b2 As Boolean = CheckKeyWord(n)

                If Not b2 Then
                    nodeList.Add(n)
                Else
                    b = b2
                End If
            Else
                If n.Text.IndexOf(tbFuncName.Text) >= 0 Then
                    b = True
                Else
                    nodeList.Add(n)
                End If
            End If
        Next

        For Each n As TreeNode In nodeList
            node.ChildNodes.Remove(n)
        Next

        Return b
    End Function
End Class
