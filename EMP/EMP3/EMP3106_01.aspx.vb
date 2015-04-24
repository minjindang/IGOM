Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports System.Transactions
Imports System.IO

Partial Class EMP3106_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return
        InitControl()
    End Sub

    Protected Sub InitControl()
        Depart_bind()
        Personnel_bind()
        EmpStaffIntro_bind()
        Deputy_bind()
    End Sub
    Protected Sub Depart_bind()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim dt As DataTable = New DepartEmp().GetDataByServiceType(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card), "0")
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            UcDDLDepart.SelectedValue = dt.Rows(0)("Depart_id").ToString()
            Dim ddl As DropDownList = CType(UcDDLDepart.FindControl("ddlDepart"), DropDownList)
            ddl.Enabled = False
        End If
    End Sub

    Protected Sub Personnel_bind()
        Dim psn As Personnel = New Personnel().GetObject(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        lbName.Text = psn.UserName
        lbId_card.Text = psn.IdCard
        lbBirthday.Text = psn.Birth_date
        tbext.Text = New EMP.Logic.Member().GetColumnValue("Ext", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
    End Sub

    Protected Sub EmpStaffIntro_bind()
        Dim bll As EMP3105DAO = New EMP3105DAO()
        Dim dt As DataTable = bll.queryEmpStaffIntroMain(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            txtIntro_desc.Text = dt.Rows(0)("INTRO_DESC").ToString()
            txtSkill_desc.Text = dt.Rows(0)("SKILL_DESC").ToString()
            txtSpecialty_desc.Text = dt.Rows(0)("SPECIALTY_DESC").ToString()
            txtMood_desc.Text = dt.Rows(0)("MOOD_DESC").ToString()
            imgPic.ImageUrl = dt.Rows(0)("PICFILE_PATH").ToString()
        End If
    End Sub

    Protected Sub Deputy_bind()
        Dim bll As DeputyDet = New DeputyDet()
        Dim dt As DataTable = bll.GetDeputyDetByID_card(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
        If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
            dt = New DataTable()
            dt.Columns.Add("Deputy_departid")
            dt.Columns.Add("Deputy_idcard")
            dt.Columns.Add("Deputy_flag")

            Dim dr As DataRow = dt.NewRow
            dt.Rows.Add(dr)
        End If

        gvList.DataSource = dt
        gvList.DataBind()
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Dim FileUploadPath As String = "~\fileupload\Attachment\EMP\"
        Dim filepath As String = Server.MapPath(FileUploadPath)
        Dim I_type As String = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1)
        Dim strFileName As String = DateTime.Now.ToString("EMP_yyyyMMddHHmmssfffff")
        Dim strFileNameFull As String = String.Format("{0}", strFileName) + "." + I_type

        Dim fi As New FileInfo(FileUpload1.PostedFile.FileName)
        Dim ismatch As Boolean = False
        Dim attkinds As String = "jpg|png|bmp"
        For Each attkind As String In attkinds.Split("|")
            If attkind.ToLower() = fi.Extension.ToLower().Replace(".", "") Then
                ismatch = True
            End If
        Next

        If Not ismatch Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請上傳JPG、PNG或BMP格式檔案!")
            Return
        End If

        '建立附件目錄
        If Not My.Computer.FileSystem.DirectoryExists(filepath) Then
            My.Computer.FileSystem.CreateDirectory(filepath)
        End If

        FileUpload1.SaveAs(filepath + strFileNameFull)
        imgPic.ImageUrl = FileUploadPath + strFileNameFull
    End Sub

    Protected Sub btnInsert_Click(sender As Object, e As EventArgs)
        GvToDt()

        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim index As Integer = gvr.RowIndex

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.NewRow
            dt.Rows.InsertAt(dr, index + 1)
        End If

        ViewState("dt") = dt
        gvList.DataSource = dt
        gvList.DataBind()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs)
        GvToDt()

        Dim gvr As GridViewRow = CType(sender, Button).NamingContainer
        Dim index As Integer = gvr.RowIndex

        If index = 0 Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "不可刪除第一筆代理人!")
            Return
        End If

        Dim dt As DataTable = CType(ViewState("dt"), DataTable)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            dt.Rows.RemoveAt(index)
        End If

        ViewState("dt") = dt
        gvList.DataSource = dt
        gvList.DataBind()
    End Sub

    Protected Sub GvToDt()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add("Deputy_departid")
        dt.Columns.Add("Deputy_idcard")
        dt.Columns.Add("Deputy_flag")

        For Each gvr As GridViewRow In gvList.Rows
            Dim dr As DataRow = dt.NewRow
            dr("Deputy_departid") = CType(gvr.FindControl("UcDDLDepart"), UControl_UcDDLDepart).SelectedValue
            dr("Deputy_idcard") = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMemberWithoutMaintainVendors).SelectedValue
            dr("Deputy_flag") = IIf(CType(gvr.FindControl("cbDeputy_flag"), CheckBox).Checked, "1", "0")

            dt.Rows.Add(dr)
        Next

        ViewState("dt") = dt
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim gvr As GridViewRow = CType(CType(sender, DropDownList).NamingContainer, UControl_UcDDLDepart).NamingContainer
        Dim UcDDLDepart As UControl_UcDDLDepart = CType(CType(sender, DropDownList).NamingContainer, UControl_UcDDLDepart)
        Dim UcDDLMember As UControl_UcDDLMemberWithoutMaintainVendors = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMemberWithoutMaintainVendors)
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub gvList_DataBound(sender As Object, e As EventArgs) Handles gvList.DataBound
        For Each gvr As GridViewRow In gvList.Rows
            Dim UcDDLDepart As UControl_UcDDLDepart = CType(gvr.FindControl("UcDDLDepart"), UControl_UcDDLDepart)
            Dim UcDDLMember As UControl_UcDDLMemberWithoutMaintainVendors = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMemberWithoutMaintainVendors)
            UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            UcDDLMember.DepartId = UcDDLDepart.SelectedValue

            Dim hfDeputy_departid As HiddenField = CType(gvr.FindControl("hfDeputy_departid"), HiddenField)
            Dim hfDeputy_idcard As HiddenField = CType(gvr.FindControl("hfDeputy_idcard"), HiddenField)
            Dim hfDeputy_flag As HiddenField = CType(gvr.FindControl("hfDeputy_flag"), HiddenField)

            Dim psn As Personnel = New Personnel().GetObject(lbId_card.Text)
            If psn.MutiDepartDeputy_flag <> "1" Then
                UcDDLDepart.SelectedValue = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                UcDDLDepart.Enabled = False
                UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                UcDDLMember.DepartId = UcDDLDepart.SelectedValue
            End If
            If Not String.IsNullOrEmpty(hfDeputy_departid.Value) Then
                UcDDLDepart.SelectedValue = hfDeputy_departid.Value
            End If
            If Not String.IsNullOrEmpty(hfDeputy_idcard.Value) Then
                UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                UcDDLMember.DepartId = UcDDLDepart.SelectedValue
                UcDDLMember.SelectedValue = hfDeputy_idcard.Value
            End If
            If Not String.IsNullOrEmpty(hfDeputy_flag.Value) AndAlso hfDeputy_flag.Value.Trim = "1" Then
                Dim cbDeputy_flag As CheckBox = CType(gvr.FindControl("cbDeputy_flag"), CheckBox)
                cbDeputy_flag.Checked = True
            End If
        Next
    End Sub

    Protected Sub btnConfrim_Click(sender As Object, e As EventArgs) Handles btnConfrim.Click
        Try
            If txtIntro_desc.Text.Trim.Length > 600 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "自述不可超過600字!")
                Return
            End If
            If txtSkill_desc.Text.Trim.Length > 300 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "專長不可超過300字!")
                Return
            End If
            If txtSpecialty_desc.Text.Trim.Length > 300 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "興趣不可超過300字!")
                Return
            End If
            If txtMood_desc.Text.Trim.Length > 600 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "心情感言不可超過600字!")
                Return
            End If

            Dim Default_count As Integer = CheckDefaultDeputy()
            If Default_count = 0 Then
                'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請至少選擇一位代理人為預設代理人!")
                'Return
            ElseIf Default_count > 1 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "不可選擇多位代理人為預設代理人!")
                Return
            End If

            Using trans As New TransactionScope
                Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
                Dim EMP3105 As New EMP3105DAO()
                Dim EMP3106 As New EMP.Logic.EMP3106
                Dim dd As New DeputyDet

                Dim m As New EMP.Logic.Member
                m.UpdateExt(lbId_card.Text, tbext.Text.Trim())

                '員工員工個人簡介
                Dim edt As DataTable = EMP3105.queryEmpStaffIntroMain(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card))
                If edt IsNot Nothing AndAlso edt.Rows.Count > 0 Then
                    EMP3105.UpdateEmpStaffIntroMain(lbBirthday.Text, txtIntro_desc.Text.Trim, txtSkill_desc.Text.Trim, txtSpecialty_desc.Text.Trim, _
                                txtMood_desc.Text.Trim, imgPic.ImageUrl, lbId_card.Text, lbId_card.Text)
                Else
                    EMP3105.insertEmpStaffintroMain(lbBirthday.Text, txtIntro_desc.Text.Trim, txtSkill_desc.Text.Trim, txtSpecialty_desc.Text.Trim, _
                                txtMood_desc.Text.Trim, imgPic.ImageUrl, lbId_card.Text, lbId_card.Text)
                End If

                'EMP_Depart_emp
                EMP3106.DeleteDepartEmp(lbId_card.Text, "0")
                EMP3105.insertEmpDepartEmp(Orgcode, UcDDLDepart.SelectedValue, lbId_card.Text, "", "", "0", lbId_card.Text)

                '代理人
                EMP3106.DeleteDeputy(lbId_card.Text)
                For Each gvr As GridViewRow In gvList.Rows
                    Dim UcDDLDeputyDepart As UControl_UcDDLDepart = CType(gvr.FindControl("UcDDLDepart"), UControl_UcDDLDepart)
                    Dim UcDDLMember As UControl_UcDDLMemberWithoutMaintainVendors = CType(gvr.FindControl("UcDDLMember"), UControl_UcDDLMemberWithoutMaintainVendors)
                    Dim cbDeputy_flag As CheckBox = CType(gvr.FindControl("cbDeputy_flag"), CheckBox)
                    Dim psn As Personnel = New Personnel().GetObject(UcDDLMember.SelectedValue)

                    If UcDDLMember.SelectedValue = "" Then
                        Continue For
                    End If

                    Dim isDouble As Boolean = False
                    isDouble = dd.ChkDefalutDeputy(lbId_card.Text, UcDDLMember.SelectedValue)
                    If isDouble Then
                        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "職務代理人已重複，請重新設定!")
                        Return
                    End If

                    dd.InsertDeputyDet(Orgcode, UcDDLDepart.SelectedValue, lbId_card.Text, Orgcode, UcDDLDeputyDepart.SelectedValue, psn.TitleNo, _
                                       UcDDLMember.SelectedValue, lbId_card.Text, IIf(cbDeputy_flag.Checked, "1", "0"), IIf(cbDeputy_flag.Checked, 1, 2))
                Next
                '重新編號
                Dim dt As DataTable = dd.getNotDefaultData(Orgcode, lbId_card.Text)
                For i As Integer = 0 To dt.Rows.Count - 1
                    dd.UpdateSeq(dt.Rows(i)("id").ToString(), i + 2)
                Next

                trans.Complete()

                CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK)
            End Using
            InitControl()

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Function CheckDefaultDeputy() As Integer
        Dim Default_count As Integer = 0
        For Each gvr As GridViewRow In gvList.Rows
            Dim cbDeputy_flag As CheckBox = CType(gvr.FindControl("cbDeputy_flag"), CheckBox)
            If cbDeputy_flag.Checked Then
                Default_count += 1
            End If
        Next

        Return Default_count
    End Function
End Class
