Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.Office.Interop
Imports System.IO
Imports NLog

Partial Class FSC2128_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

        InitControl()
    End Sub

    Protected Sub InitControl()
        UcDDLDepart.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue

        For i As Integer = 103 To Now.Year - 1911
            ddlYear.Items.Add(i.ToString())
        Next

        Dim dt As DataTable = New DataTable
        dt = New FSCPLM.Logic.SACode().GetData("023", "012")
        ddlJobtype.DataTextField = "CODE_DESC1"
        ddlJobtype.DataValueField = "CODE_NO"
        ddlJobtype.DataSource = dt
        ddlJobtype.DataBind()
        ddlJobtype.Items.Insert(0, New ListItem("請選擇", ""))

        If LoginManager.GetTicketUserData(LoginManager.LoginUserData.isGeneral) Then
            tr0.Visible = False
            tr1.Visible = False
            tr2.Visible = False
        End If
    End Sub

    Protected Sub UcDDLDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDepart.SelectedIndexChanged
        UcDDLMember.Orgcode = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        UcDDLMember.Depart_id = UcDDLDepart.SelectedValue
    End Sub

    Protected Sub btnQuery_Click(sender As Object, e As EventArgs) Handles btnQuery.Click
        Dim Year As String = ddlYear.SelectedValue
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = UcDDLDepart.SelectedValue
        Dim Id_card As String = UcDDLMember.SelectedValue
        Dim Title_no As String = ddlJobtype.SelectedValue
        Dim Quit_job_flag As String = ddlQuit_Job.SelectedValue

        'If String.IsNullOrEmpty(Id_card) Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇人員!")
        '    Return
        'End If

        Dim bll As FSC2128 = New FSC2128

        Try
            Dim ds As DataSet = bll.getData(Year, Orgcode, Depart_id, Title_no, Id_card, Quit_job_flag)

            If ds.Tables.Count > 0 Then
                tbq.Visible = True
                'Dim psn As Personnel = New Personnel().GetObject(Id_card)
                'lbYear.Text = ddlYear.SelectedValue
                'lbYear2.Text = ddlYear.SelectedValue
                'lbYear3.Text = ddlYear.SelectedValue
                'lbYear4.Text = CommonFun.getInt(ddlYear.SelectedValue) - 1
                'lbYear5.Text = CommonFun.getInt(ddlYear.SelectedValue) - 2
                'lbId_card.Text = UcDDLMember.SelectedValue
                'lbUser_name.Text = UcDDLMember.SelectedItem.Text
                'lbDepart_name.Text = UcDDLDepart.SelectedItem.Text
                'lbEmployee_type.Text = New SYS.Logic.CODE().GetDataDESC("023", "022", psn.EmployeeType)
                'lbPEHDAY.Text = psn.Pehday
                'lbPERDAY1.Text = psn.Perday1
                'lbPERDAY2.Text = psn.Perday2

                'Dim pd04mdt As DataTable = New DataTable
                'If Not String.IsNullOrEmpty(psn.Pehday2) Then
                '    lbPEHDAY2.Text = psn.Pehday2
                'Else
                '    pd04mdt = New CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, "01".ToString().PadLeft(2, "0"))
                '    For Each dr As DataRow In pd04mdt.Rows
                '        lbPEHDAY2.Text = CommonFun.getDouble(dr("PDDAYS").ToString()).ToString()
                '    Next
                'End If

                'pd04mdt = New CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, "02".ToString().PadLeft(2, "0"))

                'For Each dr As DataRow In pd04mdt.Rows
                '    lbdays2.Text = CommonFun.getDouble(dr("PDDAYS").ToString()).ToString()
                'Next

                '將日時數轉為時數
                For Each tmpdt As DataTable In ds.Tables
                    For Each dr As DataRow In tmpdt.Rows
                        For i As Integer = 3 To tmpdt.Columns.Count - 1
                            dr(i) = Content.ConvertToHours(CommonFun.getDouble(dr(i)))
                        Next
                    Next
                Next

                Dim dt As DataTable = ds.Tables(0).Clone()

                For Each tmpdt As DataTable In ds.Tables
                    Dim tmpdr As DataRow = dt.NewRow
                    '將1~12月資料累加
                    For Each dr As DataRow In tmpdt.Rows
                        tmpdr("id_card") = dr("id_card").ToString()
                        For i As Integer = 3 To tmpdt.Columns.Count - 1
                            tmpdr(i) = CommonFun.getInt(tmpdr(i)) + CommonFun.getInt(dr(i))
                        Next
                    Next
                    dt.Rows.Add(tmpdr)
                Next

                '將時數轉為日時數
                For Each dr As DataRow In dt.Rows
                    For i As Integer = 3 To dt.Columns.Count - 1
                        dr(i) = Content.ConvertDayHours(dr(i))
                    Next
                Next

                dt.Columns.Add("User_name")
                dt.Columns.Add("Depart_name")
                dt.Columns.Add("employee_type_name")
                dt.Columns.Add("Pehday")    '休假上限
                dt.Columns.Add("Pehday2")   '事假上限
                dt.Columns.Add("Perday1")   '前一年保留假上限
                dt.Columns.Add("Perday2")   '前二年保留上限
                dt.Columns.Add("limit")     '病假上限

                For Each dr As DataRow In dt.Rows
                    Dim psn As Personnel = New Personnel().GetObject(dr("id_card").ToString())
                    dr("User_name") = psn.UserName
                    dr("Depart_name") = New DepartEmp().GetDepartNameWithoutSubDepart(Orgcode, dr("id_card").ToString(), "0")
                    dr("employee_type_name") = New SYS.Logic.CODE().GetDataDESC("023", "022", psn.EmployeeType)
                    dr("Pehday") = psn.Pehday
                    dr("Perday1") = psn.Perday1
                    dr("Perday2") = psn.Perday2

                    Dim pd04mdt As DataTable = New DataTable
                    If Not String.IsNullOrEmpty(psn.Pehday2) Then
                        dr("Pehday2") = psn.Pehday2
                    Else
                        pd04mdt = New CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, "01".ToString().PadLeft(2, "0"))
                        If pd04mdt IsNot Nothing AndAlso pd04mdt.Rows.Count > 0 Then
                            dr("Pehday2") = CommonFun.getDouble(pd04mdt.Rows(0)("PDDAYS").ToString()).ToString()
                        Else
                            dr("Pehday2") = "0"
                        End If
                    End If

                    pd04mdt = New CPAPD04M().GetDataByQuery(psn.Pekind, psn.EmployeeType, "02".ToString().PadLeft(2, "0"))

                    If pd04mdt IsNot Nothing AndAlso pd04mdt.Rows.Count > 0 Then
                        dr("limit") = CommonFun.getDouble(pd04mdt.Rows(0)("PDDAYS").ToString()).ToString()
                    Else
                        dr("limit") = "0"
                    End If
                Next

                ViewState("dt") = dt
                gvlist.DataSource = dt
                gvlist.DataBind()
            Else
                gvlist.DataSource = New DataTable
                gvlist.DataBind()
            End If
        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try
    End Sub

    Protected Sub gvlist_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvlist.PageIndexChanging
        gvlist.PageIndex = e.NewPageIndex
        gvlist.DataSource = CType(ViewState("dt"), DataTable)
        gvlist.DataBind()
    End Sub
End Class
