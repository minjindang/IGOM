Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Excel = Microsoft.Office.Interop.Excel

Partial Class FSC2_FSC2101_01
    Inherits BaseWebForm

    Dim szOrgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim szLoginUserID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
    Dim szUserName As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
    Dim szRoldID As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
    Dim szDepart As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)

    Dim bll As New FSC.Logic.FSC2101()
    Dim dtData As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            Return
        End If

        Dim dr As DataRow = New FSC.Logic.Org().GetDataByDepartid(szOrgCode, szDepart)

        Depart_Bind()
        UcDDLDepart.SelectedValue = szDepart
        Name_Bind()
        UcDDLAuthorityMember.SelectedValue = szLoginUserID
        UcMember.PersonnelId = szLoginUserID

        Title_Bind()
        Work_Bind()

        Dim isQuery As Boolean = False
        Dim Boss_Level_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Boss_Level_id)
        ' 取得目前登入的角色，如為個人，即顯示個人資料
        If szRoldID <> "" Then
            Dim DateArray As String() = szRoldID.Split(",")
            For Each st In DateArray
                If st = "General" Then
                    Data_Bind(szOrgCode, Me.UcDDLDepart.SelectedValue, Me.UcDDLAuthorityMember.SelectedValue, Me.ddlTitle.SelectedValue, Me.UcMember.PersonnelId, Me.ddlWork.SelectedValue)
                    Me.pnlEdit.Visible = True
                End If
                If st = "Personnel" OrElse st = "Secretariat" OrElse st = "OrgHead" OrElse st = "DeptHead" OrElse st = "Master" _
                   OrElse Boss_Level_id = "1" OrElse Boss_Level_id = "2" OrElse Boss_Level_id = "3" Then
                    Me.tQuery.Visible = True
                    Me.pnlEdit.Visible = False
                    Exit For
                End If
            Next
        Else
            Me.pnlEdit.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' 選擇 單位
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Name_Bind()
    End Sub

    Protected Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Data_Bind(szOrgCode, Me.UcDDLDepart.SelectedValue, Me.UcDDLAuthorityMember.SelectedValue, Me.ddlTitle.SelectedValue, Me.UcMember.PersonnelId, Me.ddlWork.SelectedValue)
    End Sub

    Protected Sub btnPrint_Click(sender As Object, e As EventArgs)

        ' 取得該列數
        Dim Row As System.Web.UI.WebControls.GridViewRow
        Dim RowIndex As Integer
        Row = CType(sender, Button).NamingContainer
        RowIndex = Row.RowIndex

        ' 取得該列的資料
        Dim QDepart_ID As HiddenField = gvResult.Rows(RowIndex).FindControl("QDepart_ID")
        Dim User_name As Label = gvResult.Rows(RowIndex).FindControl("Qid_card")
        Dim Employee_type As HiddenField = gvResult.Rows(RowIndex).FindControl("QEmployee_type")
        Dim id_card As Label = gvResult.Rows(RowIndex).FindControl("Qid_card")

        Data_Bind(szOrgCode, QDepart_ID.Value, User_name.Text, Employee_type.Value, id_card.Text, "")
    End Sub

    ''' <summary>
    ''' 繫結單位名稱
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Depart_Bind()
        UcDDLDepart.Orgcode = szOrgCode
    End Sub

    ''' <summary>
    ''' 繫結 人員姓名
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Name_Bind()
        UcDDLAuthorityMember.Orgcode = szOrgCode
        UcDDLAuthorityMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub


    ''' <summary>
    ''' 繫結 職務類別
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Title_Bind()
        Me.ddlTitle.DataValueField = "CODE_NO"
        Me.ddlTitle.DataTextField = "CODE_DESC1"
        Me.ddlTitle.DataSource = bll.GetCODE("023", "022")
        Me.ddlTitle.DataBind()

        Me.ddlTitle.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 繫結 狀況
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Work_Bind()
        Me.ddlWork.DataValueField = "CODE_NO"
        Me.ddlWork.DataTextField = "CODE_DESC1"
        Me.ddlWork.DataSource = bll.GetCODE("023", "025")
        Me.ddlWork.DataBind()

        Me.ddlWork.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 回傳人員相關資料
    ''' </summary>
    ''' <param name="orgcode"></param>
    ''' <param name="departId"></param>
    ''' <param name="id_card"></param>
    ''' <param name="employeeType"></param>
    ''' <param name="idCard"></param>
    ''' <remarks></remarks>
    Protected Sub Data_Bind(ByVal orgcode As String, ByVal departId As String, ByVal id_card As String, ByVal employeeType As String, ByVal idCard As String, ByVal Quit_job_flag As String)
        dtData = bll.GetData(orgcode, departId, id_card, employeeType, idCard, Quit_job_flag)
        For Each dr As DataRow In dtData.Rows
            Dim dt As DataTable = New Member().GetDataByIdCard(dr("Id_card").ToString())
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                dr("ADID") = dt.Rows(0)("AD_ID").ToString()
                dr("User_password") = dt.Rows(0)("User_password").ToString()
                dr("LivePhone") = dt.Rows(0)("Live_Phone").ToString()
                dr("Phone") = dt.Rows(0)("Phone").ToString()
                dr("Ext") = dt.Rows(0)("Ext").ToString()
            End If
        Next
        ViewState("dt") = dtData

        If dtData.Rows.Count = 1 Then
            Me.pnlEdit.Visible = True
            Me.pnlQuery.Visible = False
        Else
            Me.pnlEdit.Visible = False
            Me.pnlQuery.Visible = True
        End If

        gvResult.DataSource = dtData
        gvResult.DataBind()

        If dtData.Rows.Count > 0 Then
            For Each dr As DataRow In dtData.Rows
                Me.lbId_number.Text = Convert.ToString(dr("Id_number"))
                Me.lbId_card.Text = Convert.ToString(dr("Id_card"))
                Me.lbUser_Name.Text = Convert.ToString(dr("User_name"))
                Me.lbBossLevelID.Text = Convert.ToString(dr("BossLevelID"))
                Me.lbYoyoCard.Text = Convert.ToString(dr("YoyoCard"))
                Me.lbADID.Text = Convert.ToString(dr("ADID"))
                Me.lbUser_password.Text = Convert.ToString(dr("User_password"))
                Me.lbEmail.Text = Convert.ToString(dr("Email"))
                Me.lbTitleNo.Text = Convert.ToString(dr("TitleNo"))
                Me.lbLivePhone.Text = Convert.ToString(dr("LivePhone"))
                Me.lbOfficeTel.Text = Convert.ToString(dr("Phone"))
                Me.lbOfficeExt.Text = Convert.ToString(dr("Ext"))
                Me.lbPEKIND.Text = Convert.ToString(dr("KindName"))
                Me.lbPEWKTYPE.Text = Convert.ToString(dr("PEWKTYPE"))
                Me.lbPESEX.Text = Convert.ToString(dr("PESEX"))
                Me.lbPEBIRTHD.Text = Convert.ToString(dr("PEBIRTHD"))
                Me.lbPECRKCOD.Text = Convert.ToString(dr("PECRKCOD"))
                Me.lbPEMEMCOD.Text = Convert.ToString(dr("PEMEMCOD"))
                Me.lbPEPOINT.Text = Convert.ToString(dr("PEPOINT"))
                Me.lbPEPROFESS.Text = Convert.ToString(dr("PEPROFESS"))
                Me.lbPECHIEF.Text = Convert.ToString(dr("PECHIEF"))
                Me.lbPEYKIND.Text = Convert.ToString(dr("PEYKIND"))
                Me.lbPEACTDATE.Text = Convert.ToString(dr("PEACTDATE"))
                Me.lbJoinDate.Text = Convert.ToString(dr("JoinDate"))
                Me.lbPELEVDATE.Text = Convert.ToString(dr("PELEVDATE"))
                Me.lbLoginType.Text = Convert.ToString(dr("LoginType"))
                Me.lbYearStartDate.Text = Convert.ToString(dr("YearStartDate"))
                Me.lbPEHDAY2.Text = Convert.ToString(dr("PEHDAY2"))
                Me.lbYear.Text = Convert.ToString(dr("PEHYEAR"))
                Me.txtPEHDAY.Text = Convert.ToString(dr("PEHDAY"))
                Me.lbChgYear.Text = Convert.ToString(dr("ChgYear"))
                Me.lbPerday1.Text = Convert.ToString(dr("PERDAY1"))
                Me.lbPerday2.Text = Convert.ToString(dr("PERDAY2"))
                Me.lbSyslogin.Text = Convert.ToString(dr("Syslogin"))
                Me.lbOnDuty.Text = Convert.ToString(dr("OnDuty"))
                Me.txtIntro_desc.Text = Convert.ToString(dr("IntroDesc"))
                Me.txtSkill_desc.Text = Convert.ToString(dr("SkillDesc"))
                Me.txtSpecialty_desc.Text = Convert.ToString(dr("SpecialtyDesc"))
                Me.txtMood_desc.Text = Convert.ToString(dr("MoodDesc"))

                Dim FileUploadPath As String = ConfigurationManager.AppSettings("FileUploadPath").ToString() + "EMP\\"
                If Convert.ToString(dr("PicFile_path")) <> "" Then
                    Me.imgPic.ImageUrl = FileUploadPath + Convert.ToString(dr("PicFile_path"))
                    Me.imgPic.Visible = True
                Else
                    Me.imgPic.Visible = False
                End If

            Next
        Else
            Me.lbId_number.Text = ""
        End If
    End Sub



    Protected Sub gvResult_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvResult.PageIndexChanging
        Me.gvResult.PageIndex = e.NewPageIndex
        gvResult.DataSource = CType(ViewState("dt"), DataTable)
        gvResult.DataBind()
    End Sub
End Class
