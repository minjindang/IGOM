Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Data.SqlClient
Imports FSC.Logic

Partial Class FSC3103_02
    Inherits BaseWebForm

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack Then
            ShowOrg()
            ShowPersonnel()
            ShowServiceType()
            ShowDepartName()
            ShowName()
        End If
    End Sub

#Region "顯示下拉選單"
    Public Sub ShowPersonnel()
        Dim id_card As String = Request.QueryString("idcard")
        lbName.Text = New Personnel().GetColumnValue("User_name", id_card)
    End Sub

    Public Sub ShowServiceType()
        Dim id_card As String = Request.QueryString("idcard")
        Dim dt As DataTable = New DepartEmp().GetDataByIdcard(id_card)
        For Each dr As DataRow In dt.Rows
            If dr("Service_type").ToString() = "0" Then
                ddlServiceType.Items.Insert(ddlServiceType.Items.Count, New ListItem("佔缺單位", "0"))
            ElseIf dr("Service_type").ToString() = "1" Then
                ddlServiceType.Items.Insert(ddlServiceType.Items.Count, New ListItem("服務單位", "1"))
            ElseIf dr("Service_type").ToString() = "2" Then
                ddlServiceType.Items.Insert(ddlServiceType.Items.Count, New ListItem("兼職單位", "2"))
            End If
        Next
    End Sub

    Public Sub ShowOrg()
        ddlOrg.DataTextField = "Orgcode_shortname"
        ddlOrg.DataValueField = "Orgcode"
        ddlOrg.DataSource = New Org().GetOrgcode()
        ddlOrg.DataBind()
    End Sub

    Public Sub ShowDepartName()
        Try
            UcDDLDepart.Orgcode = ddlOrg.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ShowName()
        ddlName.Items.Clear()
        If Not String.IsNullOrEmpty(UcDDLDepart.SelectedValue()) Then

            ddlName.DataValueField = "id_card"
            ddlName.DataTextField = "FULL_Name"
            ddlName.DataSource = New FSC.Logic.Member().GetDataByOrgDep(ddlOrg.SelectedValue, UcDDLDepart.SelectedValue)
            ddlName.DataBind()
        End If
        ddlName.Items.Insert(0, New ListItem("請選擇", ""))

    End Sub

    Protected Sub ddlOrg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlOrg.SelectedIndexChanged
        ShowDepartName()
        ShowName()
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        ShowName()
    End Sub

#End Region

    Protected Sub btnConfrim_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click
        If String.IsNullOrEmpty(ddlName.SelectedValue) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇主管!")
            Return
        End If

        Dim pb As PersonnelBoss = New PersonnelBoss()
        Dim id_card As String = Request.QueryString("idcard")
        Dim orgcode As String = Request.QueryString("org")
        Dim depart_id As String = Request.QueryString("did")

        Try
            pb.Orgcode = orgcode
            pb.Depart_id = depart_id
            pb.IdCard = id_card
            pb.Service_type = ddlServiceType.SelectedValue
            pb.Boss_orgcode = ddlOrg.SelectedValue
            pb.Boss_departid = UcDDLDepart.SelectedValue
            pb.Boss_idcard = ddlName.SelectedValue
            pb.Boss_posid = New Personnel().GetColumnValue("Title_no", ddlName.SelectedValue)
            pb.Change_userid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)


            Dim dt As DataTable = New PersonnelBoss().GetData(orgcode, depart_id, id_card, ddlServiceType.SelectedValue)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                pb.Update()
                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "FSC3103_01.aspx")
            Else
                pb.Insert()
                CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "FSC3103_01.aspx")
            End If
        Catch ex As Exception
            AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try
    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Response.Redirect("FSC3103_01.aspx")
    End Sub

End Class
