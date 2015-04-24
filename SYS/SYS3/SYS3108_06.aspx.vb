Imports System.Data
Imports FSCPLM.Logic

Partial Class SYS3108_06
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Bind()
        BindFormDesc()
    End Sub

    Protected Sub BindFormDesc()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim code As New SACode()
        Dim leaveType As New SYS.Logic.LeaveType()
        Dim dt As DataTable = code.GetData2("024", "P", "**")
        dt.DefaultView.Sort = "code_no"
        dt = dt.DefaultView.ToTable

        Dim ndt As New DataTable
        ndt.Columns.Add("form_name", GetType(String))
        ndt.Columns.Add("form_desc", GetType(String))
        For Each dr As DataRow In dt.Rows
            Dim ndr As DataRow = ndt.NewRow
            ndr("form_name") = dr("code_desc1").ToString()
            Dim dt1 As DataTable = code.GetData2("024", "P", dr("code_no").ToString())

            Dim formDesc As String = ""
            For Each dr1 As DataRow In dt1.Rows
                If Not "" = formDesc Then
                    If "001" = dr("code_no").ToString() Then
                        formDesc &= "<br/>"
                    Else
                        formDesc &= "、"
                    End If
                End If
                formDesc &= dr1("code_desc1").ToString()
                If "001" = dr("code_no").ToString() Then
                    formDesc &= leaveType.GetCombineLeaveType(orgcode, dr1("code_desc2").ToString())
                End If
            Next
            ndr("form_desc") = formDesc
            ndt.Rows.Add(ndr)
        Next
        gvFormList.DataSource = ndt
        gvFormList.DataBind()
    End Sub

    Protected Sub Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim departId As String = Request.QueryString("depId")
        Dim titleNo As String = Request.QueryString("titNo")
        Dim idCard As String = Request.QueryString("idCard")
        Dim personnel As New FSC.Logic.Personnel()

        Dim dt As DataTable = personnel.GetDataByQuery(Orgcode, departId, titleNo, idCard)
        gv.DataSource = dt
        gv.DataBind()
    End Sub

    Protected Sub gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim gvi As GridView = CType(e.Row.FindControl("gvi"), GridView)
            Dim orgcode As String = CType(e.Row.FindControl("gv_lbOrgcode"), Label).Text
            Dim departId As String = CType(e.Row.FindControl("gv_lbDepart_id"), Label).Text
            Dim idCard As String = CType(e.Row.FindControl("gv_lbId_card"), Label).Text
            Dim titleNo As String = CType(e.Row.FindControl("gv_lbTitle_no"), Label).Text
            Dim employeeType As String = CType(e.Row.FindControl("gv_lbEmployee_type"), Label).Text
            Dim formId As String = Request.QueryString("formId")

            Dim sys3108 As New SYS.Logic.SYS3108()
            Dim dt As DataTable = sys3108.GetDataByQuery2(orgcode, departId, titleNo, idCard, employeeType, formId)
            gvi.DataSource = dt.DefaultView
            gvi.DataBind()

        End If
    End Sub

End Class
