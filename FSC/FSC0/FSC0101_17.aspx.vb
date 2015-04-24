Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0101_17
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        BindProjectKind()
        Bind()
    End Sub

#Region "下拉選單"
    Protected Sub BindProjectKind()
        Dim code As New FSCPLM.Logic.SACode()
        rblProjectKind.DataSource = code.GetData("023", "029")
        rblProjectKind.DataBind()
        rblProjectKind.SelectedIndex = 0
        rblProjectKind.Enabled = False
    End Sub
#End Region

    Protected Sub Bind()
        Dim fid As String = Request.QueryString("fid")
        Dim org As String = Request.QueryString("org")

        If Not String.IsNullOrEmpty(fid) And Not String.IsNullOrEmpty(org) Then

            UcFlowDetail.Orgcode = org
            UcFlowDetail.FlowId = fid

            Dim por As New FSC.Logic.ProjectOvertimeRule()
            Dim list As List(Of FSC.Logic.ProjectOvertimeRule) = por.GetObjects(org, fid)
            If list.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "查無表單資料!", ViewState("BackUrl"))
                Return
            End If

            Dim fscorg As New FSC.Logic.Org()
            Dim code As New FSCPLM.Logic.SACode()
            Dim i As Integer = 1
            Dim sb As New StringBuilder()
            For Each p As FSC.Logic.ProjectOvertimeRule In list

                If i = list.Count Then
                    lbProjectCode.Text = p.ProjectCode
                    lbProjectName.Text = p.ProjectName
                    lbProjectDesc.Text = p.ProjectDesc
                    rblProjectKind.SelectedValue = p.ProjectKind
                    lbCheckType.Text = IIf(p.CheckType = "1", "一般加班", "專案加班")
                    lbLocation.Text = IIf(p.Location = "1", "機關內", "機關外")
                    UcDate1.Text = FSC.Logic.DateTimeInfo.ConvertToDisplay(p.StartDate, p.Start_time)
                    UcDate2.Text = FSC.Logic.DateTimeInfo.ConvertToDisplay(p.EndDate, p.End_time)
                    lbisCard.Text = IIf(p.isCard = "1", "是", "否")
                    lbisOnlyLeave.Text = IIf(p.isOnlyLeave = "1", "是", "否")
                    lbDailyOTHr.Text = p.DailyOTHr
                    lbDailyOTPayHr.Text = p.DailyOTPayHr
                    lbMonOTHr.Text = p.MonOTHr
                    lbMonOTPayHr.Text = p.MonOTPayHr
                End If

                Dim item As New ListItem
                item.Value = p.DepartId & "," & p.TitleNo & "," & p.IdCard
                sb.Append(fscorg.GetDepartName(org, p.DepartId) & "/" & code.GetCodeDesc("023", "012", p.TitleNo) & "/" & p.UserName).Append("<br/>")
                i += 1
            Next
            lbMember.Text = sb.ToString()
        End If
    End Sub


    ''' <summary>
    ''' 回上頁
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Dim url As String = ViewState("BackUrl")
        Response.Redirect(url)
    End Sub
End Class
