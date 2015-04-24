Imports System.Collections

Partial Class ajax_getWorkTime
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim curdate As String = Request.QueryString("curdate")
        Dim idcard As String = Request.QueryString("idcard")

        curdate = curdate.Replace("/", "")

        Dim ht As Hashtable = FSC.Logic.Content.getWorkTime(idcard, curdate)
        If ht IsNot Nothing Then
            Response.Write(ht.Item("WORKTIMEB").ToString() & "," & ht.Item("WORKTIMEE").ToString())
        End If
    End Sub
End Class
