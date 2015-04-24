Imports System.Data

Partial Class SAL2113_01
    Inherits BaseWebForm


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack Then

            Dim v_UserId As String = LoginManager.UserId      '------------- 使用者身分證號
            Dim v_UserOrgId As String = LoginManager.OrgCode  '--------------------使用者 機關代號 

            YM_Bind()
            nhino_Bind(LoginManager.UserId)

            TextBox1.Style.Add("text-align", "right")
            TextBox2.Style.Add("text-align", "right")
            txtNhiTot.Style.Add("text-align", "right")
            txtNhiFin.Style.Add("text-align", "right")
            txtNhiAmt.Style.Add("text-align", "right")

            Me.set_div_step(Me.RadioButtonList_step.SelectedValue)
            gvExt_Bind()

        End If



    End Sub
    Protected Sub RadioButtonList_step_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList_step.SelectedIndexChanged
        Me.set_div_step(Me.RadioButtonList_step.SelectedValue)
    End Sub
    Protected Sub set_div_step(ByVal v_step As String)
        Select Case v_step
            Case "1"
                div_nhi.Visible = False
                div_rptunit.Visible = True
                div_rptnhi.Visible = False
                Me.div_nhi.Style.Item("visibility") = "hidden"
                Me.div_rptunit.Style.Item("display") = "block"
                Me.div_rptnhi.Style.Item("display") = "none"

                Me.lbUnitYY.Text = Me.ddlYY.SelectedValue & Me.ddlMM.SelectedValue
                gvExt_Bind()
            Case "2"
                div_nhi.Visible = True
                div_rptunit.Visible = False
                div_rptnhi.Visible = True
                Me.div_nhi.Style.Item("visibility") = "visible"
                Me.div_rptunit.Style.Item("display") = "none"
                Me.div_rptnhi.Style.Item("display") = "blcok"

                get_nhi_info()
        End Select


    End Sub
#Region " DDL "

    Protected Sub nhino_Bind(ByVal v_UserOrgId As String)
        Dim bll As New SAL.Logic.SAL2113()
        Using t As DataTable = bll.GetUnit(v_UserOrgId)
            For Each rs As DataRow In t.Rows
                Dim li As ListItem = New ListItem(rs("text").ToString, rs("CODE_DESC2").ToString)
                ddlNHINO.Items.Add(li)
            Next
        End Using
    End Sub

    Protected Sub YM_Bind()
        Dim yy_s As Integer = CInt(Now.ToString("yyyy")) - 1911 - 2
        If yy_s < 2013 Then yy_s = 102
        Dim yy_e As Integer = CInt(Now.ToString("yyyy")) - 1911 + 1
        Dim yy_now As Integer = CInt(Now.ToString("yyyy"))

        For i As Integer = yy_s To yy_e
            Dim li As ListItem = New ListItem(CStr(i), CStr(i))
            If i = yy_now Then li.Selected = True
            ddlYY.Items.Add(li)
        Next

        Me.ddlMM.SelectedValue = Now.ToString("MM")
    End Sub
#End Region

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Select Case RadioButtonList_step.SelectedValue
            Case "1"
                ''保險對象各類所得
                Me.lbUnitYY.Text = Me.ddlYY.SelectedValue & Me.ddlMM.SelectedValue
                gvExt_Bind()
            Case "2"
                ''投保單位(機關負擔)
                get_nhi_info()
        End Select




    End Sub

#Region " unit "

    Protected Sub gvExt_Bind()

        Dim bll As New SAL.Logic.SAL2113()
        Dim v_ym As String = CStr(CInt(Me.ddlYY.SelectedValue) + 1911) & Me.ddlMM.SelectedValue
        Dim strBudget As String = UcSaCode1.SelectedValue
        Dim newbudget As String = ""
        If (strBudget.Length > 3) Then
            Dim aa As String() = strBudget.Split(","c)
            For i As Integer = 0 To aa.Length - 1
                If newbudget <> "" Then
                    newbudget &= ","
                End If
                newbudget &= "'" & aa(i).ToString & "'"
            Next
            strBudget = newbudget
        Else
            strBudget = "'" & strBudget & "'"
        End If


        Me.gvExt.DataSource = bll.GetExtData(v_ym, strBudget)
        Me.gvExt.DataBind()

    End Sub

    Protected Sub gvExt_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExt.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim txtAmt As TextBox = CType(e.Row.FindControl("txtAmt"), TextBox)

            txtAmt.Style.Add("text-align", "right")
        End If

    End Sub

    Protected Sub gvExt_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvExt.RowCommand
        Dim v_yy As String = Me.lbUnitYY.Text
        Dim v_amt As String = ""
        Dim v_kind As String = ""

        If e.CommandName = "Print" Then
            Dim gvr As GridViewRow = CType(e.CommandSource, Button).NamingContainer

            v_amt = CType(gvr.FindControl("txtAmt"), TextBox).Text
            v_kind = CType(gvr.FindControl("lbCode_No"), Label).Text

            If (v_amt = "") Or (Not IsNumeric(v_amt)) Or (v_amt.IndexOf(".") > 0) Or (v_amt.IndexOf(",") > 0) Then
                Response.Write("<script language='javascript'>")
                Response.Write("alert('金額格式錯誤');")
                Response.Write("</script>")
                Exit Sub
            End If
            Dim url As String = "SAL2113_02.aspx?ym=" & v_yy & "&kind=" & v_kind & "&amt=" & v_amt

            CommonFun.OpenWindow(Me, url, "width=800,height=600,scrollbars=1,resize=0")

        End If
    End Sub


#End Region

#Region " nhi "

    Protected Sub get_nhi_info()

        Me.lbNhiNO_show.Text = Me.ddlNHINO.SelectedItem.Text
        Me.lbNhiNO.Text = Me.ddlNHINO.SelectedValue
        Me.lbNhiYY.Text = Me.ddlYY.SelectedValue & Me.ddlMM.SelectedValue

        If UcSaCode1.SelectedValue = "" Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請勾選預算來源!")
        End If

        Dim val As String = Me.UcSaCode1.SelectedValue
        Dim aa As String() = val.Split(","c)
        Dim newtext As String
        For i As Integer = 0 To aa.Length - 1
            If newtext <> "" Then
                newtext &= ","
            End If
            newtext &= SALARY.Logic.app.GetSaCode_Desc1("002", "018", aa(i))
        Next

        If Me.UcSaCode1.SelectedValue = "ALL" Then
            newtext = "全部"
        End If

        Me.lb_budget.Text = newtext

        Dim SumFlag As Boolean = Me.cbSum.Checked = False

        If SumFlag Then
            Me.lbNhiTot.Text = "所有投保單位總額"
            Me.lbNhiSum.Text = "Y"
        Else
            Me.lbNhiTot.Text = Me.ddlNHINO.SelectedItem.Text
            Me.lbNhiSum.Text = "N"
        End If


        Dim v_nhino As String = Me.ddlNHINO.SelectedValue
        Dim v_nhiym As String = CStr(CInt(Me.ddlYY.SelectedValue) + 1911) & Me.ddlMM.SelectedValue
        Dim v_UserId As String = LoginManager.UserId      '------------- 使用者身分證號
        Dim v_UserOrgId As String = LoginManager.OrgCode  '--------------------使用者 機關代號 
        Dim strBudget As String = UcSaCode1.SelectedValue

        Dim newbudget As String = ""

        If (strBudget.Length > 3) Then
            Dim bb As String() = strBudget.Split(","c)
            For i As Integer = 0 To bb.Length - 1
                If newbudget <> "" Then
                    newbudget &= ","
                End If
                newbudget &= "'" & bb(i).ToString & "'"
            Next
            strBudget = newbudget
        Else
            strBudget = "'" & strBudget & "'"
        End If

        Dim bll As New SAL.Logic.SAL2113()

        Using t As DataTable = bll.GetNhiInfoData(v_UserOrgId, v_nhiym, strBudget, "ALL")
            If (t.Rows.Count > 0) Then
                Dim rs As DataRow = t.Rows(0)
                Me.txtNhiTot.Text = rs("inco_amt").ToString
            Else
                Me.txtNhiTot.Text = "0"
            End If
            Me.txtNhiFin.Text = "0"
            Me.txtNhiAmt.Text = "0"
        End Using

        Using t As DataTable = bll.GetNhiInfoData(v_UserOrgId, v_nhiym, strBudget, "Y")
            If (t.Rows.Count > 0) Then
                Dim rs As DataRow = t.Rows(0)
                Me.TextBox1.Text = rs("inco_amt").ToString
            Else
                Me.TextBox1.Text = "0"
            End If
        End Using

        Using t As DataTable = bll.GetNhiInfoData(v_UserOrgId, v_nhiym, strBudget, "N")
            If (t.Rows.Count > 0) Then
                Dim rs As DataRow = t.Rows(0)
                Me.TextBox2.Text = rs("inco_amt").ToString
            Else
                Me.TextBox2.Text = "0"
            End If
        End Using


    End Sub

    Protected Sub btnNhiCalc_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNhiCalc.Click
        Dim msg As String = ""

        Dim s_tot As String = Me.txtNhiTot.Text
        Dim s_fin As String = Me.txtNhiFin.Text

        If (s_tot = "") Or (Not IsNumeric(s_tot)) Or (s_tot.IndexOf(".") > 0) Or (s_tot.IndexOf(",") > 0) Then
            msg &= "本月薪資總額格式錯誤,"
        End If

        If (s_fin = "") Or (Not IsNumeric(s_fin)) Or (s_fin.IndexOf(".") > 0) Or (s_fin.IndexOf(",") > 0) Then
            msg &= "本月投保金總額格式錯誤,"
        End If

        If msg <> "" Then
            Response.Write("<script language='javascript'>")
            Response.Write("alert('" & msg.Replace(",", "\n") & "');")
            Response.Write("</script>")

            Me.txtNhiTot.Focus()
            Exit Sub
        End If

        If CLng(s_tot) - CLng(s_fin) > 0 Then
            Dim para_ym As String = Me.lbNhiYY.Text
            para_ym = CStr(CInt(para_ym.Substring(0, 3)) + 1911) & para_ym.Substring(3, 2)
            Dim rate As String = "2"
            Me.txtNhiAmt.Text = CStr(Format((CLng(s_tot) - CLng(s_fin)) * CDbl(rate) / 100, 0))
        Else
            Me.txtNhiAmt.Text = "0"
        End If

    End Sub


    Protected Sub btnNhi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNhi.Click

        Dim v_nhino As String = Me.lbNhiNO.Text
        Dim v_yy As String = Me.lbNhiYY.Text
        Dim v_amt As String = Me.txtNhiAmt.Text

        If (v_amt = "") Or (Not IsNumeric(v_amt)) Or (v_amt.IndexOf(".") > 0) Or (v_amt.IndexOf(",") > 0) Then

            Response.Write("<script language='javascript'>")
            Response.Write("alert('金額格式錯誤');")
            Response.Write("</script>")

            Me.txtNhiTot.Focus()
            Exit Sub
        End If

        Response.Write("<script language='javascript'>")
        Response.Write("window.open('SAL2113_03.aspx?ym=" & v_yy & "&nhino=" & v_nhino & "&amt=" & v_amt & "','_blank','width=800,height=600,scrollbars=1,resize=0');")
        Response.Write("</script>")

    End Sub

#End Region

End Class
