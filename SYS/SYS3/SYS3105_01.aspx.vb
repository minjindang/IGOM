Imports System.Data
Imports SYS.Logic

Partial Class SYS3105_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        genTree()
    End Sub

#Region "TreeView"
    Protected Sub genTree()

        tv.Nodes.Clear()

        Dim func As New Func()
        Dim dt As DataTable = func.getDataByPid("IGSS0000")
        tv.Nodes.Add(New TreeNode("整合性總務作業管理資訊系統", "IGSS0000"))
        addNode(tv.Nodes.Item(0), dt)

        tv.ExpandAll()
    End Sub

    Protected Sub addNode(ByVal n As TreeNode, ByVal dt As DataTable)
        Dim i As Integer = 0
        For Each dr As DataRow In dt.Rows
            Dim node As New TreeNode
            node.Value = dr("Func_id").ToString()
            node.Text = dr("Func_name").ToString() & "(" & dr("Func_id").ToString() & ")#" & dr("Func_sort").ToString()
            n.ChildNodes.Add(node)
            Dim ndt As DataTable = New Func().getDataByPid(dr("Func_id").ToString())
            If ndt IsNot Nothing AndAlso ndt.Rows.Count > 0 Then
                addNode(n.ChildNodes.Item(i), ndt)
            End If
            i += 1
        Next
    End Sub

    Protected Sub tv_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tv.SelectedNodeChanged
        Dim Func_id As String = CType(sender, TreeView).SelectedNode.Value
        Bind(Func_id)
    End Sub
#End Region

    Protected Sub Bind(ByVal Func_id As String)
        Dim dt As DataTable = New Func().getDataByFid(Func_id)
        For Each dr As DataRow In dt.Rows
            tbFunc_id.Text = dr("Func_id").ToString()
            tbFunc_name.Text = dr("Func_name").ToString()
            tbFunc_sort.Text = dr("Func_sort").ToString()
            ddlFunc_type.SelectedValue = dr("Func_type").ToString()
            tbFunc_url.Text = dr("Func_url").ToString()
            lbParent_func_id.Text = dr("Parent_func_id").ToString()
            lbParent_func_id1.Text = dr("Func_id").ToString()
            tbFunc_Memo.Text = dr("Func_Memo").ToString()
        Next

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            cbUpdate.Enabled = True
            cbDelete.Enabled = True
            cbAdd.Enabled = True
            cbCancel.Enabled = True
            cbCancel1.Enabled = True
        End If
    End Sub

    Protected Sub cbDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim funcId As String = tbFunc_id.Text.Trim()
        Try
            Dim func As New Func()
            Dim dt As DataTable = func.getDataByPid(funcId)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "尚有下層資料")
                Return
            End If
            func.deleteData(funcId)
            CommonFun.MsgShow(Me, CommonFun.Msg.DeleteOK)
            genTree()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim func As New Func()
            func.Func_id = tbFunc_id1.Text.Trim()
            func.Func_name = tbFunc_name1.Text.Trim()
            func.Func_sort = tbFunc_sort1.Text.Trim()
            func.Func_url = tbFunc_url1.Text.Trim()
            func.Func_type = ddlFunc_type1.SelectedValue()
            func.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            func.Parent_func_id = lbParent_func_id1.Text
            func.Visable_type = "Y"
            func.Func_Memo = tbFunc_Memo1.Text.Trim()
            func.insertData()
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
            genTree()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim func As New Func()
            func.Func_id = tbFunc_id.Text.Trim()
            func.Func_name = tbFunc_name.Text.Trim()
            func.Func_sort = tbFunc_sort.Text.Trim()
            func.Func_url = tbFunc_url.Text.Trim()
            func.Func_type = ddlFunc_type.SelectedValue()
            func.Func_Memo = tbFunc_Memo.Text.Trim()
            func.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            func.updateData()
            CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            genTree()
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lbParent_func_id.Text = ""
        tbFunc_id.Text = ""
        tbFunc_name.Text = ""
        tbFunc_sort.Text = ""
        tbFunc_url.Text = ""
        lbParent_func_id1.Text = ""
        tbFunc_id1.Text = ""
        tbFunc_name1.Text = ""
        tbFunc_sort1.Text = ""
        tbFunc_url1.Text = ""
        tbFunc_Memo.Text = ""
        tbFunc_Memo1.Text = ""

        cbUpdate.Enabled = False
        cbDelete.Enabled = False
        cbAdd.Enabled = False
        cbCancel.Enabled = False
        cbCancel1.Enabled = False
    End Sub

End Class
