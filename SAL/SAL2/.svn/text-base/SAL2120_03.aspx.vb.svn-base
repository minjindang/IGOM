Imports System.Data.SqlClient
Imports System.Data
Imports SAL.Logic

Partial Class SAL2120_03
    Inherits BaseWebForm

    Public totPage As Integer = 0
    Public totRow As Integer = 0
    Public page_size As Integer = 10
    Public pagez As Integer = 1

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim v_UserId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
            Dim v_UserOrgId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

            DATE_Bind()

            Proj_Bind(v_UserOrgId)

            Job_Bind(v_UserOrgId, "002", "001")

        End If
    End Sub

#Region " DDL "

    Protected Sub DATE_Bind()
        Dim yy_s As Integer = CInt(Now.ToString("yyyy")) - 2
        If yy_s < 2013 Then yy_s = 2013
        Dim yy_e As Integer = CInt(Now.ToString("yyyy")) + 1
        Dim yy_now As Integer = CInt(Now.ToString("yyyy"))

        For i As Integer = yy_s To yy_e
            Dim li As ListItem = New ListItem(CStr(i - 1911), CStr(i))
            If i = yy_now Then li.Selected = True
            ddlYY.Items.Add(li)
        Next

    End Sub

    Protected Sub Proj_Bind(ByVal v_orgid As String)

        Dim dt As DataTable = New SAL2120().getProj(v_orgid)
        ddlProj.Items.Add(New ListItem("---全部---", ""))
        For Each dr As DataRow In dt.Rows
            Dim li As ListItem = New ListItem(dr("proj_code_name").ToString, dr("proj_code").ToString)
            ddlProj.Items.Add(li)
        Next

    End Sub

    Protected Sub Job_Bind(ByVal v_orgid As String, ByVal code_sys As String, ByVal code_type As String)

        Dim dt As DataTable = New SAL2120().getJob(v_orgid, code_sys, code_type)
        ddlJob.Items.Add(New ListItem("---全部---", ""))

        For Each dr As DataRow In dt.Rows
            Dim li As ListItem = New ListItem(dr("code_desc1").ToString, dr("CODE_NO").ToString)
            ddlJob.Items.Add(li)
        Next

    End Sub

#End Region


    Protected Sub btnQuery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim v_UserId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim v_UserOrgId As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim s_name As String = Me.txtNameStr.Text.Trim
        Dim s_year As String = Me.ddlYY.SelectedValue

        Dim s_proj As String = Me.ddlProj.SelectedValue
        Dim s_job As String = Me.ddlJob.SelectedValue
        Dim s_bdate As String = Me.ddlBdate.SelectedValue
        Dim s_nhikind As String = Me.ddlNhiKind.SelectedValue

        Dim dt As DataTable = New SAL2120().getData2(v_UserOrgId, s_year, s_name, s_proj, s_job, s_bdate)

        Me.gvlist.DataSource = dt
        Me.gvlist.DataBind()

        Session("dt") = dt

        If Me.gvlist.Rows.Count > 0 Then
            Me.div_btn.Visible = True
            Me.Ucpager1.Visible = True
        Else
            Me.div_btn.Visible = False
            Me.Ucpager1.Visible = False
        End If

        gettotamt()
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim p_type As Integer = 0

        For Each li As ListItem In Me.cblType.Items
            If li.Selected Then
                p_type += CInt(li.Value)
            End If
        Next

        Dim type_list As String = ""
        type_list &= "<input type='text' name='p_type' value='" & p_type & "' />"

        Dim inco_list As String = ""

        For Each gvr As GridViewRow In gvlist.Rows

            Dim chk As Boolean = CType(gvr.FindControl("chk"), CheckBox).Checked

            If chk Then

                Dim seqno As String = CType(gvr.FindControl("PAYO_SEQNO"), Label).Text
                inco_list &= "<input type='text' name='seqno' value='" & seqno & "' />"

                'Dim year As String = CType(gvr.FindControl("YEAR"), Label).Text
                inco_list &= "<input type='text' name='year' value='" & ddlYY.SelectedValue & "' />"

                Dim nhikind As String = CType(gvr.FindControl("NHIKIND"), Label).Text
                inco_list &= "<input type='text' name='nhikind' value='" & nhikind & "' />"

                Dim amt As String = CType(gvr.FindControl("AMT"), Label).Text
                inco_list &= "<input type='text' name='amt' value='" & amt & "' />"

                Dim ext As String = CType(gvr.FindControl("EXT"), Label).Text
                inco_list &= "<input type='text' name='ext' value='" & ext & "' />"
            End If
        Next

        If inco_list = "" Then
            Exit Sub
        Else

            Dim url As String = "SAL2120_04.aspx"

            HttpContext.Current.Response.Write(" <div style='display:none;'><form id='formGoto' action='" & url & "' target='_Blank' method='POST' >" & type_list & inco_list & "</form></div> " & vbCrLf & _
                " <script type='text/javascript' language='javascript'>formGoto.submit(); </script> " & vbCrLf)
        End If
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "this.className='list_tr1'")
            e.Row.Attributes.Add("OnMouseOut", "this.className='list_tr'")
        End If
    End Sub

#Region "分頁功能"
    Protected Sub gvlist_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        gvlist.PageIndex = e.NewPageIndex
        Bind()
    End Sub

    Public Function chkfirst() As Boolean
        Dim rv As Boolean = True
        If pagez <> 1 Then
            rv = True
        Else
            rv = False
        End If
        Return rv
    End Function

    Public Function chklast() As Boolean
        Dim rv As Boolean = True
        If pagez <> totPage Then
            rv = True
        Else
            rv = False
        End If
        Return rv
    End Function

    Protected Sub gettotamt()

        Dim dt As New Data.DataTable
        dt = CType(Session("dt"), Data.DataTable)

        Dim tot_inco_amt As Integer = 0
        Dim tot_health_ext As Integer = 0

        For Each dr As DataRow In dt.Rows
            Dim amt As Integer = CInt(dr("AMT").ToString)
            Dim ext As Integer = CInt(dr("EXT").ToString)

            tot_inco_amt += amt
            tot_health_ext += ext
        Next
        If dt.Rows.Count > 0 Then
            Me.lbSum.Text = "給付總額：<font color='red'>" & FormatNumber(tot_inco_amt, 0) & "</font> ，補充健保費總額：<font color='red'>" & FormatNumber(tot_health_ext, 0) & "</font>"
        Else
            Me.lbSum.Text = ""
        End If

    End Sub

#End Region

End Class
