Imports System.Data
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Transactions
Imports System.IO

Partial Class SAL_SAL3_SAL3116_02
    Inherits System.Web.UI.Page

#Region " PageLoad"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Page.Form.DefaultButton = Me.Button_Update.UniqueID

        If Not Page.IsPostBack Then
            'Me.TextBox_orgid.Text = Me.LoginManager.UserData.v_ROLE_ORGID.ToString
            'Me.TextBox_mid.Text = Me.LoginManager.UserData.v_ROLE_EMPLOYEES_ID.ToString

            Dim orgname As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Me.Label_orgid.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            Me.Label_orgname.Text = orgname


            Dim dt As DataTable = SQLs1("1")
            Me.GridView_SaTdpm.DataSource = dt
            Me.GridView_SaTdpm.DataBind()

        End If
    End Sub

#End Region

#Region " KindChanged"
    Protected Sub DropDownList_kind_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_kind.SelectedIndexChanged
        'Me.TextBox_Sqls1.Text = Me.SQLs1(Me.DropDownList_kind.SelectedValue)
        ''Me.GridView_SaTdpm.DataBind()


        Dim dt As DataTable = SQLs1(Me.DropDownList_kind.SelectedValue)
        Me.GridView_SaTdpm.DataSource = dt
        'Me.GridView_SaTdpm.DataBind()
        Me.GridView_SaTdpm.DataBind()

    End Sub
#End Region

#Region " ButtonClick"
    '' 儲存變更
    Protected Sub Button_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Update.Click

        Dim v_mdate As String = pub.Nowdatetime
        Dim v_mid As String = Me.TextBox_mid.Text

        Dim v_orgid As String = ""
        Dim v_kind As String = ""
        Dim v_code_sys As String = ""
        Dim v_code_kind As String = ""
        Dim v_code_type As String = ""
        Dim v_code_no As String = ""
        Dim v_code As String = ""
        Dim v_seqno As String = ""

        For Each gvr As GridViewRow In Me.GridView_SaTdpm.Rows
            v_orgid = CType(gvr.FindControl("TextBox_tdpf_orgid"), TextBox).Text
            v_kind = CType(gvr.FindControl("TextBox_tdpf_kind"), TextBox).Text
            v_code_sys = CType(gvr.FindControl("TextBox_tdpf_code_sys"), TextBox).Text
            v_code_kind = CType(gvr.FindControl("TextBox_tdpf_code_kind"), TextBox).Text
            v_code_type = CType(gvr.FindControl("TextBox_tdpf_code_type"), TextBox).Text
            v_code_no = CType(gvr.FindControl("TextBox_tdpf_code_no"), TextBox).Text
            v_code = CType(gvr.FindControl("TextBox_tdpf_code"), TextBox).Text
            v_seqno = CType(gvr.FindControl("Uc_Media_f040_tdpfDD1"), uc_uc_Media_f040_tdpfDD).v_selected

            Using ta As New dt_SaTdpm_TableAdapters.SaTdpm_TableAdapter

                Using t As dt_SaTdpm_.SaTdpm_DataTable = ta.GetDataByPK(v_orgid, _
                                                                        v_kind, _
                                                                        v_code_sys, _
                                                                        v_code_kind, _
                                                                        v_code_type, _
                                                                        v_code_no, _
                                                                        v_code)

                    If t.Rows.Count > 0 Then
                        t(0)("tdpm_tdpf_seqno") = v_seqno
                        ta.Update(t)
                    Else
                        ta.Insert(v_kind, v_code_sys, v_code_kind, v_code_type, v_code_no, v_code, v_seqno, v_mid, v_mdate, v_orgid)
                    End If
                End Using
            End Using
        Next
        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "儲存完畢!!")

    End Sub
#End Region


#Region " SQLs1"
    Protected Function SQLs1(ByVal v_kind) As DataTable



        Dim v_orgid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim sal3116 As New SAL3116()

        Dim dt As DataTable = sal3116.GetData(v_orgid, v_kind)

        Return dt
    End Function
#End Region

#Region " DropDown_tdpm_tdpf_Seqno_Changed"
    Protected Sub SeqnoChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim v_seqno As String = CType(sender, uc_uc_Media_f040_tdpfDD).v_selected

        Dim v_id = CType(sender, uc_uc_Media_f040_tdpfDD).ClientID

        ''ctl00_ContentPlaceHolder1_GridView_SaTdpm_ctl03_Uc_Media_f040_tdpfDD1
        Dim vv_id As Integer = CInt(v_id.Replace("ctl00_ContentPlaceHolder1_GridView_SaTdpm_ctl", "").Replace("_Uc_Media_f040_tdpfDD1", "").replace("_DropDownList_tdpf", ""))

        Dim gvr As GridViewRow = Me.GridView_SaTdpm.Rows(vv_id - 2)
        '' ClientID 第一列為 2, GridViewRow 第一列為 0, vv_id-2 = row 
        CType(gvr.FindControl("Uc_Media_f040_tdpfTB1"), uc_uc_Media_f040_tdpfTB).v_seqno = v_seqno

        'Me.MessageBox_ScriptManager(v_id)


    End Sub

#End Region




End Class
