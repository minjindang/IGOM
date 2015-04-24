Imports MAI.Logic
Imports System.Data
Imports System.Collections.Generic


Partial Class MAI2101_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If

        InitControl()
    End Sub

    Protected Sub InitControl()
        ddlType.DataSource = New SYS.Logic.CODE().GetData("019", "013")
        ddlType.DataBind()
        ddlType.Items.Insert(0, New ListItem("請選擇", ""))

        UcDateS.Text = (Now.Year - 1911).ToString() + Now.Month.ToString().PadLeft(2, "0") + "01"
        UcDateE.Text = (Now.Year - 1911).ToString() + Now.Month.ToString().PadLeft(2, "0") + Date.DaysInMonth(Now.Year, Now.Month).ToString()
    End Sub

#Region "報表"
    Protected Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If String.IsNullOrEmpty(ddlType.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇統計類別!")
            Return
        End If
        If String.IsNullOrEmpty(UcDateS.Text) OrElse String.IsNullOrEmpty(UcDateE.Text) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "報修日期不可空白!")
            Return
        End If
        If UcDateS.Text > UcDateE.Text Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "報修日期(起)不可大於報修日期(迄)!")
            Return
        End If

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim bll As New MAI2101
        Dim dt As DataTable = New DataTable
        Dim total_count As Integer = bll.getTotalCount(Orgcode, UcDateS.Text, UcDateE.Text)
        Dim Title_Name As String = String.Empty

        If ddlType.SelectedValue = "001" Then
            dt = bll.getData001(Orgcode, UcDateS.Text, UcDateE.Text)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Columns.Add("p")
                For Each dr As DataRow In dt.Rows
                    dr("p") = Math.Round(CommonFun.getInt(dr("Num")) / total_count, 2)
                Next
            End If
        ElseIf ddlType.SelectedValue = "002" OrElse ddlType.SelectedValue = "003" Then
            If ddlType.SelectedValue = "002" Then
                dt = bll.getData002(Orgcode, UcDateS.Text, UcDateE.Text)
            ElseIf ddlType.SelectedValue = "003" Then
                dt = bll.getData003(Orgcode, UcDateS.Text, UcDateE.Text)
            End If
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Columns.Add("Done_p")
                dt.Columns.Add("Un_p")
                For Each dr As DataRow In dt.Rows
                    dr("Done_p") = Math.Round(CommonFun.getInt(dr("Done_Num")) / total_count, 2)
                    dr("Un_p") = Math.Round(CommonFun.getInt(dr("Un_Num")) / total_count, 2)
                Next
            End If
        ElseIf ddlType.SelectedValue = "006" Then
            Title_Name = "依超過三天完成率"
            dt = bll.getData006(Orgcode, UcDateS.Text, UcDateE.Text)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                dt.Columns.Add("p")

                For Each dr As DataRow In dt.Rows
                    dr("p") = Math.Round(CommonFun.getInt(dr("Num")) / total_count, 2)
                Next
            End If
        Else
            dt = bll.getData0045(Orgcode, UcDateS.Text, UcDateE.Text, ddlType.SelectedValue)
            dt.Columns.Add("Item")
            dt.Columns.Add("p")
            If ddlType.SelectedValue = "004" Then
                Title_Name = "依四小時完成率"
            ElseIf ddlType.SelectedValue = "005" Then
                Title_Name = "依當日完成率"
            End If

            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Dim dr As DataRow = dt.NewRow
                dr("Num") = 0
                dt.Rows.Add(dr)
            End If

            For Each dr As DataRow In dt.Rows
                dr("Item") = Title_Name.Replace("依", "").Replace("率", "") + "之報修筆數及比率"
                dr("p") = Math.Round(CommonFun.getInt(dr("Num")) / total_count, 2)
            Next
        End If

        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
            Return
        Else
            Dim theDTReport As CommonLib.DTReport
            Dim param(2) As String
            param(0) = FSC.Logic.DateTimeInfo.ToDisplay(UcDateS.Text) + "~" + FSC.Logic.DateTimeInfo.ToDisplay(UcDateE.Text)
            param(1) = total_count
            param(2) = Title_Name

            If ddlType.SelectedValue = "004" OrElse ddlType.SelectedValue = "005" OrElse ddlType.SelectedValue = "006" Then
                theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/MAI/MAI2101_01_00456.mht"), dt)
            Else
                theDTReport = New CommonLib.DTReport(Server.MapPath("../../Report/MAI/MAI2101_01_" + ddlType.SelectedValue + ".mht"), dt)
            End If
            theDTReport.Param = param
            theDTReport.ExportFileName = ddlType.SelectedItem.Text
            theDTReport.ExportToExcel()
        End If
    End Sub

#End Region

End Class
