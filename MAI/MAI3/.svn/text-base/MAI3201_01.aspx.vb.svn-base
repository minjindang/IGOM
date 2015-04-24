Imports System.Data

Imports FSCPLM.Logic

Partial Class MAI_MAI3_MAI3201_01
    Inherits BaseWebForm

    Dim dao As New MAI3201



    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        CommonFun.ClearContentPlaceHolder(Me.Master)
    End Sub

    Private Sub BindGV()
        Dim mtClssTypes As String = String.Empty
        Dim mtStatusTypes As String = String.Empty
        Dim mtClssTypeAry() As String = ucMtClass_type.SelectedValue.TrimStart(";").TrimEnd(";").Split(";")
        Dim mtStatusTypeAry() As String = ucMtStatus_type.SelectedValue.TrimStart(";").TrimEnd(";").Split(";")
        For Each s As String In mtClssTypeAry
            If Not String.IsNullOrEmpty(s) Then
                mtClssTypes += String.Format("'{0}',", s)
            End If 
        Next
        If mtClssTypes.Length > 0 Then 
            mtClssTypes = mtClssTypes.TrimEnd(",") 
        End If
        For Each s As String In mtStatusTypeAry
            If Not String.IsNullOrEmpty(s) Then
                mtStatusTypes += String.Format("'{0}',", s)
            End If
        Next
        If mtStatusTypes.Length > 0 Then
            mtStatusTypes = mtStatusTypes.TrimEnd(",")
        End If

        Dim applyTimeS As Date = DateTime.MinValue
        If Not String.IsNullOrEmpty(ucApplyTimeS.Text) Then
            applyTimeS = CommonFun.getYYYMMDD(ucApplyTimeS.Text)
        End If

        Dim applyTimeE As Date = DateTime.MinValue
        If Not String.IsNullOrEmpty(ucApplyTimeE.Text) Then
            applyTimeE = CommonFun.getYYYMMDD(ucApplyTimeE.Text)
        End If


        Dim dt As DataTable = dao.GetBy(mtClssTypes, txtMtItemOther_desc.Text, applyTimeS, applyTimeE, _
                                        ddlDept.SelectedValue, txtPhone_nos.Text, mtStatusTypes)
        tbq.Visible = Not dt Is Nothing AndAlso dt.Rows.Count > 0

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
        ViewState("DataTable") = dt '將資料暫存起來，做為資料的跳頁等顯示
        dt.Dispose()
    End Sub

    Protected Sub QryBtn_Click(sender As Object, e As EventArgs) Handles QryBtn.Click
        BindGV()
    End Sub

    Protected Sub btnCAll_Click(sender As Object, e As EventArgs) Handles btnCAll.Click
        ucMtClass_type.CheckAll(False)
    End Sub

    Protected Sub btnSAll_Click(sender As Object, e As EventArgs) Handles btnSAll.Click
        ucMtClass_type.CheckAll(True)
    End Sub

    Protected Sub GridViewA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridViewA.PageIndexChanging
        GridViewA.PageIndex = e.NewPageIndex
        Me.GridViewA.DataSource = CType(ViewState("DataTable"), DataTable)
        Me.GridViewA.DataBind()
    End Sub
 

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            ddlDept.DataSource = dao.GetUnitCode()
            ddlDept.DataTextField = "Unit_code"
            ddlDept.DataValueField = "Unit_code"
            ddlDept.DataBind()
        End If

    End Sub

    Protected Sub GridViewA_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewA.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(7).Text = "未結案" Then
                e.Row.Cells(7).ForeColor = Drawing.Color.Red
            End If
        End If

    End Sub

End Class
