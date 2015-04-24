Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Collections.Generic
Imports FSC.Logic

Partial Class FSC4102_02
    Inherits BaseWebForm


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        ViewState("dt") = Nothing

        If IsPostBack Then Return

        ShowMasterFrom()

    End Sub

#Region "建立列表"
    Public Sub ShowMasterFrom()
        Dim strOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode) '機構代碼
        Dim LeaveType As New SYS.Logic.LeaveType()
        Dim dt As DataTable = LeaveType.GetLeaveType(strOrgcode)
        dt.Columns.Add("User_names")
        dt.Columns.Add("num")
        Dim num As Integer = 0

        Dim NoticePerson As New NoticePerson
        For Each row As DataRow In dt.Rows
            num += 1

            Dim dt2 As DataTable = NoticePerson.getDataByLeaveType(strOrgcode, row("Leave_type"))
            Dim User_names As String = ""
            For Each row2 As DataRow In dt2.Rows
                User_names += row2("User_name") + "、"
            Next
            If String.IsNullOrEmpty(User_names) Then
                User_names = "未設定收件人"
            Else
                User_names = User_names.TrimEnd("、")
            End If
            row("User_names") = User_names
            row("num") = num
        Next
        '增加出國請假類別  代碼為88
        Dim vdr As DataRow = dt.NewRow
        Dim dt3 As DataTable = NoticePerson.getDataByLeaveType(strOrgcode, "88")
        Dim UserNames As String = ""
        For Each row2 As DataRow In dt3.Rows
            UserNames += row2("User_name") + "、"
        Next
        If String.IsNullOrEmpty(UserNames) Then
            UserNames = "未設定收件人"
        Else
            UserNames = UserNames.TrimEnd("、")
        End If
        num += 1
        vdr("Leave_type") = "88"
        vdr("Leave_name") = "出國請假"
        vdr("User_names") = UserNames
        vdr("num") = num
        dt.Rows.Add(vdr)

        Me.GridView1.DataSource = dt
        Me.GridView1.DataBind()

    End Sub




#End Region


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        If e.CommandName = "Modify" Then
            Dim Leave As String = e.CommandArgument()
            Dim Leaves() As String = Leave.Split(",")
            Response.Redirect("FSC4102_03.aspx?lt=" & Leaves(0))
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ShowMasterFrom()
    End Sub

    Protected Sub btnToFSC4102_01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnToFSC4102_01.Click
        Response.Redirect("FSC4102_01.aspx")
    End Sub


End Class
