
Partial Class ajax_getNotWorkHours
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dateb As String = Request.QueryString("dateb")
        Dim datee As String = Request.QueryString("datee")
        Dim timeb As String = Request.QueryString("timeb")
        Dim timee As String = Request.QueryString("timee")
        Dim idcard As String = Request.QueryString("idcard")

        dateb = dateb.Replace("/", "")
        datee = datee.Replace("/", "")

        Dim hours As String = FSC.Logic.Content.computeNotWorkHour(dateb, datee, timeb, timee, idcard)
        Response.Write(hours)
    End Sub
End Class
