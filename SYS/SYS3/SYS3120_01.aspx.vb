Imports System.Data
Imports System.Transactions
Imports SYS.Logic

Partial Class SYS3120_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        bind()
    End Sub

    Protected Sub bind()
        Dim role As New SYS.Logic.Role()
        Dim func As New SYS.Logic.Func()

        Dim funcs As String = role.GetRolefunction(LoginManager.OrgCode, LoginManager.RoleId)
        Dim dt As New DataTable()
        dt.Columns.Add("Func_id")
        dt.Columns.Add("Func_name")

        If Not String.IsNullOrEmpty(funcs) Then
            For Each fid As String In funcs.Split(",")
                Dim dr As DataRow = dt.NewRow
                dr("Func_id") = fid
                Dim d As DataTable = func.getDataByFid(fid)
                If d IsNot Nothing AndAlso d.Rows.Count > 0 Then

                    If d.Rows(0)("Func_type").ToString() = "G" Then
                        Continue For
                    End If

                    dr("Func_name") = d.Rows(0)("Func_name").ToString()
                End If
                dt.Rows.Add(dr)
            Next
        End If

        cbl.DataSource = dt
        cbl.DataBind()

        Dim fav As New SYS.Logic.Favorite()
        Dim fdt As DataTable = fav.GetData(LoginManager.OrgCode, LoginManager.UserId)
        For Each fdr As DataRow In fdt.Rows
            For Each item As ListItem In cbl.Items
                If fdr("Func_id").ToString() = item.Value Then
                    item.Selected = True
                End If
            Next
        Next

    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim fav As New SYS.Logic.Favorite()
        fav.Orgcode = LoginManager.OrgCode
        fav.Id_card = LoginManager.UserId
        fav.Delete()

        For Each item As ListItem In cbl.Items
            If item.Selected Then
                fav = New SYS.Logic.Favorite()
                fav.Orgcode = LoginManager.OrgCode
                fav.Id_card = LoginManager.UserId
                fav.Func_id = item.Value
                fav.Change_userid = LoginManager.Account
                fav.Insert()
            End If
        Next

        CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)
    End Sub
End Class
