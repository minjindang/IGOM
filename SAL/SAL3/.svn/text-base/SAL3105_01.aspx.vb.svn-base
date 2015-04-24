Imports System.Data
Imports SALARY.Logic

Partial Class SAL3105_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then Return
        Year_Bind()
        InitControl()
    End Sub

    Protected Sub Year_Bind()
        For i As Integer = Now.Year - 1911 - 2 To Now.Year - 1911 + 1
            ddlYear.Items.Add(i.ToString())
            ddlBatchYear.Items.Add(i.ToString())
        Next

        ddlYear.SelectedValue = Now.Year - 1911
        ddlBatchYear.SelectedValue = Now.Year - 1911
    End Sub

#Region "控制項初始化"

    Protected Sub InitControl()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Member_Bind()

        UcDDLDepart_batch.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Member_batch_Bind()

        Dim tmp As DataTable = New SYS.Logic.CODE().GetData("002", "017")
        Dim dt As DataTable = tmp.Clone()

        For Each dr As DataRow In tmp.Rows
            If dr("CODE_NO").ToString = "001" OrElse dr("CODE_NO").ToString = "002" OrElse dr("CODE_NO").ToString = "003" OrElse _
               dr("CODE_NO").ToString = "005" OrElse dr("CODE_NO").ToString = "011" Then
                dt.ImportRow(dr)
            End If
        Next

        ddlBase_prono.DataSource = dt
        ddlBase_prono.DataBind()
        ddlBase_prono.Items.Insert(0, New ListItem("請選擇", ""))

        ddlbatch_Base_prono.DataSource = dt
        ddlbatch_Base_prono.DataBind()
        ddlbatch_Base_prono.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub Member_Bind()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub Member_batch_Bind()
        UcDDLMember_batch.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember_batch.DepartId = UcDDLDepart_batch.SelectedValue
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        Member_Bind()
    End Sub

    Protected Sub UcDDLDepart_batch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart_batch.SelectedIndexChanged
        Member_batch_Bind()
    End Sub
#End Region

#Region " Button "

    Protected Sub Button_Search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Search.Click

        Query()

    End Sub

    Protected Sub Button_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Update.Click

        Dim v_grad_year As String = ddlYear.SelectedValue + 1911
        Dim v_grad_seqno As String = ""
        Dim v_grad_orgid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim v_grad_muser As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim v_grad_brot As String = ""
        Dim v_grad_prot As String = ""
        Dim v_grad_code_no As String = "" '' 併入其他薪資項目(目前無作用)
        Dim v_grad_mdate As String = Now.ToString("yyyyMMddHHmmss")

        Dim sql_str As String = ""

        Dim gvr As GridViewRow

        For Each gvr In Me.GridView_Grad.Rows

            v_grad_seqno = CType(gvr.FindControl("TextBox_grad_seqno"), TextBox).Text
            v_grad_brot = "0"
            v_grad_brot = CType(gvr.FindControl("textbox_grad_brot"), TextBox).Text
            If (v_grad_brot = "") Or (Not IsNumeric(v_grad_brot)) Then
                v_grad_brot = "0"
            End If

            v_grad_prot = CType(gvr.FindControl("TextBox_grad_prot"), TextBox).Text
            If (v_grad_prot = "") Or (Not IsNumeric(v_grad_prot)) Then
                v_grad_prot = "0"
            End If

            Using ta As SaGradDAOTableAdapters.SAL_SAGRADTableAdapter = New SaGradDAOTableAdapters.SAL_SAGRADTableAdapter
                '' 先刪除
                ta.DeletebySAL3105(v_grad_year, v_grad_orgid, v_grad_seqno)

                '' 再新增
                ta.Insert(v_grad_year, v_grad_seqno, v_grad_orgid, v_grad_brot, v_grad_prot, v_grad_muser, v_grad_mdate, v_grad_code_no)
            End Using

        Next

        CommonFun.MsgShow(Me.Page, CommonFun.Msg.UpdateOK)

        Query()

    End Sub

    Protected Sub Button_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Copy.Click

        Dim v_grad_year As String = ddlYear.SelectedValue + 1911
        Dim v_grad_seqno As String = ""
        Dim v_grad_orgid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim v_grad_muser As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim v_grad_mdate As String = Now.ToString("yyyyMMddHHmmss")

        Dim sql_str As String = ""

        Dim gvr As GridViewRow

        For Each gvr In Me.GridView_Grad.Rows

            v_grad_seqno = CType(gvr.FindControl("TextBox_grad_seqno"), TextBox).Text

            '' 複製
            Using ta As SaGradDAOTableAdapters.SAL_SAGRADTableAdapter = New SaGradDAOTableAdapters.SAL_SAGRADTableAdapter

                ta.UpdatebySAL3105(v_grad_muser, v_grad_mdate, v_grad_year, v_grad_orgid, v_grad_seqno)

            End Using

        Next

        CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "複製儲存成功")

        Query()
    End Sub

    Protected Sub Button_Batch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Batch.Click

        Dim v_grad_Orgid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim v_grad_year As String = ddlBatchYear.SelectedValue + 1911
        'Dim v_grad_job As String = Me.ucSaCode_batch_base_job.Code_no
        Dim v_grad_prono As String = ddlbatch_Base_prono.SelectedValue
        Dim v_grad_dept As String = UcDDLDepart_batch.SelectedValue
        Dim v_grad_id_card As String = UcDDLMember_batch.SelectedValue
        Dim v_grad_brot As String = Me.TextBox_batch_grad_brot.Text
        If (v_grad_brot = "") Or (Not IsNumeric(v_grad_brot)) Then
            v_grad_brot = "0"
        End If
        Dim v_grad_prot As String = Me.TextBox_batch_grad_prot.Text
        If (v_grad_prot = "") Or (Not IsNumeric(v_grad_prot)) Then
            v_grad_prot = "0"
        End If
        Dim v_grad_muser As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        Dim v_grad_mdate As String = Now.ToString("yyyyMMddHHmmss")
        Dim v_grad_seqno As String = ""
        Dim v_grad_code_no As String = ""

        Dim sal3105 As New SAL3105()

        Dim db As DataTable = sal3105.GetBaseData(v_grad_Orgid, v_grad_year, v_grad_prono, v_grad_dept, v_grad_id_card)
        For Each dr As DataRow In db.Rows
            v_grad_seqno = dr("base_seqno").ToString

            Using ta As SaGradDAOTableAdapters.SAL_SAGRADTableAdapter = New SaGradDAOTableAdapters.SAL_SAGRADTableAdapter
                '' 先刪除
                ta.DeletebySAL3105(v_grad_year, v_grad_Orgid, v_grad_seqno)

                '' 再新增
                ta.Insert(v_grad_year, v_grad_seqno, v_grad_Orgid, v_grad_brot, v_grad_prot, v_grad_muser, v_grad_mdate, v_grad_code_no)
            End Using
        Next

        CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "整批儲存成功")

        'Me.ucSaCode_base_job.Code_no = Me.ucSaCode_batch_base_job.Code_no
        ddlBase_prono.SelectedValue = ddlbatch_Base_prono.SelectedValue
        UcDDLDepart.SelectedValue = UcDDLDepart_batch.SelectedValue
        UcDDLMember.SelectedValue = UcDDLMember_batch.SelectedValue
        Me.table_batch.Visible = False
        Query()
    End Sub


    Protected Sub Query()
        Me.tbm.Visible = True
        Me.tbq.Visible = True

        Dim v_Orgid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim v_year As String = ddlYear.SelectedValue + 1911
        'Dim v_job As String = Me.ucSaCode_base_job.Code_no
        Dim v_prono As String = ddlBase_prono.SelectedValue
        Dim v_edate As String = Me.DropDownList_base_edate.SelectedValue
        Dim v_str As String = UcMember.PersonnelId
        Dim v_dept As String = UcDDLDepart.SelectedValue
        Dim v_id_card As String = UcDDLMember.SelectedValue

        Dim sal3105 As New SAL3105()

        Dim db As DataTable = sal3105.GetDataByQuery(v_Orgid, v_edate, v_prono, v_year, v_str, v_dept, v_id_card)

        Me.GridView_Grad.DataSource = db
        Me.GridView_Grad.DataBind()

        tbq.Visible = True
        If db IsNot Nothing AndAlso db.Rows.Count > 0 Then
            Button_Update.Visible = True
            Button_ShowBatch.Visible = True
            Ucpager1.Visible = True
        Else
            Button_Update.Visible = False
            Button_ShowBatch.Visible = False
            Ucpager1.Visible = False
        End If
    End Sub


    Protected Sub Button_ShowBatch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_ShowBatch.Click
        Me.table_batch.Visible = True
        Me.tbm.Visible = False
        Me.tbq.Visible = False
    End Sub

    Protected Sub Button_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Cancel.Click
        Me.table_batch.Visible = False
        Me.tbm.Visible = True
        Me.tbq.Visible = True
    End Sub

#End Region

    Protected Sub GridView_Grad_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView_Grad.PageIndexChanging
        Me.GridView_Grad.PageIndex = e.NewPageIndex
        Query()
    End Sub
End Class
