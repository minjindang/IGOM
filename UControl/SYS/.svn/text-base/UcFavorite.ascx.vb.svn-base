Imports System.Data

Partial Class UControl_SYS_UcFavorite
    Inherits System.Web.UI.UserControl


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim fav As New SYS.Logic.Favorite()
        Dim func As New SYS.Logic.Func()
        Dim role As New SYS.Logic.Role()
        Dim funcs As String = role.GetRolefunction(LoginManager.OrgCode, LoginManager.RoleId)

        Dim rdt As New DataTable()
        Dim dt As DataTable = fav.GetData(LoginManager.OrgCode, LoginManager.UserId)

        rdt = dt.Clone()
        rdt.Columns.Add("Func_name")

        For Each dr As DataRow In dt.Rows
            If funcs.IndexOf(dr("Func_id").ToString()) < 0 Then
                Continue For
            End If

            Dim rdr As DataRow = rdt.NewRow
            rdr("Func_id") = dr("Func_id").ToString()
            Dim fdt As DataTable = func.getDataByFid(dr("Func_id").ToString())
            If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
                rdr("Func_name") = fdt.Rows(0)("Func_name").ToString()
            End If
            rdt.Rows.Add(rdr)
        Next

        ddlFavorite.DataSource = rdt
        ddlFavorite.DataBind()
        ddlFavorite.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlFavorite_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim func As New SYS.Logic.Func()
        Dim fdt As DataTable = func.getDataByFid(ddlFavorite.SelectedValue)
        If fdt IsNot Nothing AndAlso fdt.Rows.Count > 0 Then
            Response.Redirect(fdt.Rows(0)("Func_url").ToString())
        End If
    End Sub
End Class
