Imports System
Imports System.Data
Imports System.Xml
Imports System.IO
Imports System.Drawing
Imports FSC.Logic

Partial Class FSC4103_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            hfOrgcode.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            QueryData()
        End If

    End Sub

    Protected Sub QueryData()
        Dim PropertyA As FSC.Logic.FSC4103_01 = New FSC.Logic.FSC4103_01()
        Dim ds As DataSet = New DataSet()
        ds = PropertyA.DAO.GetData(hfOrgcode.Value)

        If (ds.Tables(0).Rows.Count > 0) Then
            gvnotClockInOutTimesSettingForm.DataSource = ds
            gvnotClockInOutTimesSettingForm.DataBind()

            btnAdd.Visible = False
        Else
            btnAdd.Visible = True
        End If
    End Sub
    Protected Sub SetLayoutStatus(ByVal bStatus As Boolean)
        gvnotClockInOutTimesSettingForm.Visible = bStatus
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("FSC4103_02.aspx")
    End Sub

    Protected Sub gvnotClockInOutTimesSettingForm_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvnotClockInOutTimesSettingForm.RowCommand
        Try
            Select Case e.CommandName
                Case "Mod"
                    Response.Redirect("FSC4103_03.aspx?" & e.CommandArgument.ToString)
            End Select
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub gvnotClockInOutTimesSettingForm_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvnotClockInOutTimesSettingForm.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow Then
            If Not e.Row.Cells(0).FindControl("btnUpdate") Is Nothing Then
                Dim btnUp As Button = DirectCast(e.Row.Cells(0).FindControl("btnUpdate"), Button)
            End If
        End If
    End Sub

    Protected Sub gvnotClockInOutTimesSettingForm_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvnotClockInOutTimesSettingForm.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim hf As HiddenField = New HiddenField()
            Dim lbl As Label = New Label()
            Dim lblYear As Label = New Label()
            Dim lblMonth As Label = New Label()

            If Not e.Row.Cells(0).FindControl("hfTimes") Is Nothing Then
                hf = DirectCast(e.Row.Cells(0).FindControl("hfTimes"), HiddenField)

                If Not e.Row.Cells(0).FindControl("lblTimes") Is Nothing Then
                    lbl = DirectCast(e.Row.Cells(0).FindControl("lblTimes"), Label)
                    lblYear = DirectCast(e.Row.Cells(0).FindControl("lblYearTimes"), Label)
                    lblMonth = DirectCast(e.Row.Cells(0).FindControl("lblMonthTimes"), Label)
                    If hf.Value = "0" Then
                        lbl.Text = "<font color = '#000000'>●</font>"
                        lblYear.Text = ""
                        lblMonth.Text = ""
                    Else
                        lbl.Text = ""
                    End If
                End If
            End If
        End If
    End Sub
End Class