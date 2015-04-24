Imports System.Data
Imports SALARY.Logic
Imports System.IO

Partial Class SAL_SAL2102_01
    Inherits BaseWebForm

    Dim bll As SAL2102 = New SAL2102()
    Dim dtTable As DataTable = New DataTable
    Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

    Public Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim orgCode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            UcDDLDepart.Orgcode = orgCode
        End If
    End Sub


    Protected Sub UcDDLDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        BindMember()
    End Sub

    Protected Sub BindMember()
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.DepartId = UcDDLDepart.SelectedValue
    End Sub

    ''' <summary>
    ''' 繫結單位名稱
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Depart_Bind()
        Me.ddlDepart.DataValueField = "Depart_id"
        Me.ddlDepart.DataTextField = "Depart_name"
        Me.ddlDepart.DataSource = bll.GetDepart(szOrgcode)
        Me.ddlDepart.DataBind()
        Me.ddlDepart.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 繫結姓名
    ''' </summary>
    ''' <param name="DepartID"></param>
    ''' <remarks></remarks>
    Protected Sub Name_Bind(ByVal DepartID As String)
        Me.ddlname.DataValueField = "IDCARD"
        Me.ddlname.DataTextField = "USERNAME"
        Me.ddlName.DataSource = bll.GetUserName(szOrgcode, DepartID)
        Me.ddlName.DataBind()
        Me.ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 【新增人員】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub InsertButtonVisible(sender As Object, e As EventArgs) Handles InsertBtnVisible.Click
        InsertTr.Visible = True

        ' 繫結單位名稱
        Me.Depart_Bind()

        ' 繫結姓名
        Me.Name_Bind(ddlDepart.SelectedValue)
    End Sub

    ''' <summary>
    ''' 【清空重填】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ResetButton(sender As Object, e As EventArgs) Handles ResetBtn.Click
        ' 繫結單位名稱
        Me.Depart_Bind()

        ' 繫結姓名
        Me.Name_Bind(ddlDepart.SelectedValue)
    End Sub

    ''' <summary>
    ''' 【查詢】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub SelectButton(sender As Object, e As EventArgs) Handles SelectBtn.Click
     
        dtTable = bll.GetData(Server.HtmlEncode((UcROCYear.Year + 1911).ToString), rblPAYOD_CODE.SelectedValue, UcDDLMember.SelectedValue)
        dtTable.Columns.Add("NO", GetType(System.String))
        dtTable.Columns.Add("family_amt")

        For i As Integer = 0 To dtTable.Rows.Count - 1
            dtTable.Rows(i).Item("NO") = i + 1 '流水號欄位
            Dim dt As DataTable = bll.getFamily(dtTable.Rows(i)("id_card").ToString())
            Dim family_amt As Double = 0
            For Each dr As DataRow In dt.Rows
                family_amt += CommonFun.getDouble(dr("family_amt"))
            Next
            dtTable.Rows(i)("family_amt") = family_amt
        Next

        GridViewA.DataSource = dtTable
        GridViewA.DataBind()
        tbq.Visible = True
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepart.SelectedIndexChanged
        Me.Name_Bind(Me.ddlDepart.SelectedValue)
    End Sub

    ''' <summary>
    ''' 依新增人員列印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub InsertButton(sender As Object, e As EventArgs) Handles InsertBtn.Click
        If Not String.IsNullOrEmpty(Me.ddlName.SelectedValue.ToString) Then
            Dim url As String
            url = "SAL2102_02.aspx?SelectedValue=" + Server.HtmlEncode(Me.ddlname.SelectedValue.ToString)
            url &= "&Year=" + Server.HtmlEncode(UcROCYear.Year.ToString) + "" + "&Type=3"
            url &= "&sPageSize=" + Server.HtmlEncode(Ucpager1.sPageSize.ToString) + ""
            'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")
            Response.Redirect(url)
        Else
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇新增人員資料")
        End If
    End Sub

    ''' <summary>
    ''' 依資料列列印
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub GridView_RowPrintBtn_RowCommand(ByVal sender As Object,  ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        Dim myButton As Button = CType(e.CommandSource, Button)
        Dim myRow As GridViewRow = CType(myButton.NamingContainer, GridViewRow)

        If e.CommandName = "RowPrintBtn" Then
            If Not String.IsNullOrEmpty(CType(GridViewA.Rows(myRow.RowIndex).FindControl("User_id"), Label).Text) Then
                Dim url As String
                url = "SAL2102_02.aspx?SelectedValue=" + CType(GridViewA.Rows(myRow.RowIndex).FindControl("User_id"), Label).Text
                url &= "&Year=" + Server.HtmlEncode(UcROCYear.Year.ToString) + "" + "&Type=2"
                url &= "&sPageSize=" + Server.HtmlEncode(Ucpager1.sPageSize.ToString) + ""

                If CType(GridViewA.Rows(myRow.RowIndex).FindControl("PAYOD_CODE"), Label).Text = "公" Then
                    url &= "&PAYOD_CODE=001"
                ElseIf CType(GridViewA.Rows(myRow.RowIndex).FindControl("PAYOD_CODE"), Label).Text = "勞" Then
                    url &= "&PAYOD_CODE=002"
                End If
                'Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")
                Response.Redirect(url)
            Else
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "依資料列列印出錯")
            End If
        End If
    End Sub

    ''' <summary>
    ''' 【全部匯出】按鈕
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub PrintButton(sender As Object, e As EventArgs) Handles PrintBtn.Click
        Dim url As String
        ''公保列印
        'url = "SAL2102_02.aspx?SelectedValue=" + "" + "&Year=" + Server.HtmlEncode(UcROCYear.Year.ToString) + ""
        'url &= "&Type=1" + "&sPageSize=" + Server.HtmlEncode(Ucpager1.sPageSize.ToString) + "" + "&PAYOD_CODE=001"
        ''Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")
        'Response.Redirect(url)

        ''勞保列印
        'url = "SAL2102_02.aspx?SelectedValue=" + "" + "&Year=" + Server.HtmlEncode(UcROCYear.Year.ToString) + ""
        'url &= "&Type=1" + "&sPageSize=" + Server.HtmlEncode(Ucpager1.sPageSize.ToString) + "" + "&PAYOD_CODE=002"
        ''Response.Write("<script>window.open('" & url & "','','menubar=no,status=no,scrollbars=yes,top=100,left=200,toolbar=no,width=800,height=600')</script>;")
        'Response.Redirect(url)

        url = "SAL2102_02.aspx?SelectedValue=" + "" + "&Year=" + Server.HtmlEncode((UcROCYear.Year + 1911).ToString) + ""
        url &= "&Type=1" + "&sPageSize=" + Server.HtmlEncode(Ucpager1.sPageSize.ToString) + "" + "&PAYOD_CODE=" + rblPAYOD_CODE.SelectedValue
        url &= "&id_card=" + UcDDLMember.SelectedValue

        Response.Redirect(url)
    End Sub
End Class