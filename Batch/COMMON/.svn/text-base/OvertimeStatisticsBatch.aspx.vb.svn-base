
Partial Class OvertimeStatisticsBatch
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            RunBatch()

            'Dim js As New StringBuilder
            'js.AppendLine("<script type='text/javascript'>")
            'js.AppendLine("     window.opener=null;")
            'js.AppendLine("     window.open('','_self');")
            'js.AppendLine("     window.close();")
            'js.AppendLine("</script>")

            'Page.ClientScript.RegisterStartupScript(GetType(String), "", js.ToString)
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Public Sub RunBatch()
        Try
            Dim bll As New SAL.Logic.OvertimeStatistics()

            If ConfigurationManager.AppSettings("System_site").ToString() = "A" Then
                '本會
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPA55_A").ToString())
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPASC55_A").ToString())
                '銀行局
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPA67").ToString())
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPA67_A").ToString())
                '保險局
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPA55_B").ToString())
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPASC55_B").ToString())
                '檢查局
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPA55_C").ToString())
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPASC55_C").ToString())
            Else
                '證期局
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPASFB").ToString())
                bll.UpdateStatisticsData(ConfigurationManager.AppSettings("DBStringCPASFBSC").ToString())
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
End Class
