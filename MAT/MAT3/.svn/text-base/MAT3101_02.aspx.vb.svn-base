Imports System.Data
Imports FSCPLM.Logic 
Imports System.Collections.Generic

Partial Class MAT_MAT3_MAT3101_02
    Inherits BaseWebForm



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''initfunction()
        If Not (IsPostBack) Then
            SetInitialRow()
            BindNotImportData()
        End If
    End Sub


    Private Sub SetInitialRow()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("Index"))
        dt.Columns.Add(New DataColumn("Flow_id"))
        dt.Columns.Add(New DataColumn("Material_name"))
        dt.Columns.Add(New DataColumn("Out_cnt"))
        dt.Columns.Add(New DataColumn("Unit"))
        dt.Columns.Add(New DataColumn("TotalPrice_amt"))
        dt.Columns.Add(New DataColumn("Company_name"))
        dt.Columns.Add(New DataColumn("Memo"))
        dt.Columns.Add(New DataColumn("IsAuto", GetType(System.Boolean)))
        Dim dr As DataRow = dt.NewRow()
        dr("Index") = dt.Rows.Count + 1
        dr("Flow_id") = ""
        dr("Material_name") = ""
        dr("Out_cnt") = ""
        dr("Unit") = ""
        dr("TotalPrice_amt") = ""
        dr("Company_name") = ""
        dr("Memo") = ""
        dr("IsAuto") = False

        dt.Rows.Add(dr)

        ViewState("CurrentTable") = dt

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
    End Sub

    Protected Sub DonBtn_Click(sender As Object, e As System.EventArgs) Handles DonBtn.Click
        Try
            Dim am As New ApplyOtherMtrMain
            Dim ad As New ApplyOtherMtrDet
            'If Not ViewState("CurrentTable") Is Nothing Then
            '    Dim dtCurrentTable As DataTable = ViewState("CurrentTable") 
            '    For Each dr As DataRow In dtCurrentTable.Rows 

            '        If IsDBNull(dr("Material_name")) Then
            '            Continue For
            '        End If
            '        ad.Insert(formID, dr("Material_name"), dr("Unit"), dr("Out_cnt"), dr("TotalPrice_amt"), dr("Company_name"), dr("Memo"), "", "", "")
            '    Next
            'End If
            Dim bool As Boolean = False

            Dim flowID As String = ""
            Dim formID As Integer = 0

            For Each dr As GridViewRow In Me.GridViewA.Rows
                Dim box1 As TextBox = dr.Cells(1).FindControl("txtMaterialName")
                Dim box2 As TextBox = dr.Cells(2).FindControl("txtOutCnt")
                Dim box3 As TextBox = dr.Cells(3).FindControl("txtUnit")
                Dim box4 As TextBox = dr.Cells(4).FindControl("txtTotalPriceAmt")
                Dim box5 As TextBox = dr.Cells(5).FindControl("txtCompanyName")
                Dim box6 As TextBox = dr.Cells(6).FindControl("txtMemo")

                If Not CommonFun.IsNum(box4.Text) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "總價需為數字!")
                    Return
                End If

                If Not CommonFun.IsNum(box2.Text) Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "領用數量需為數字!")
                    Return
                End If

                If String.IsNullOrEmpty(box1.Text) Then
                    Continue For
                End If

                bool = True

                If flowID <> CType(dr.FindControl("hfFlowId"), HiddenField).Value Then
                    flowID = CType(dr.FindControl("hfFlowId"), HiddenField).Value
                    formID = am.Insert(flowID, Me.ucApply_date.Text, LoginManager.Depart_id, LoginManager.UserId, 0, LoginManager.UserId, Now, LoginManager.OrgCode)
                End If

                ad.Insert(formID, box1.Text, box3.Text, box2.Text, box4.Text, box5.Text, box6.Text, LoginManager.UserId, Now, LoginManager.OrgCode)
            Next
            If bool Then
                CommonFun.MsgShow(Page, CommonFun.Msg.InsertOK)
            Else
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "至少需輸入一筆資料!")
            End If
            'Page.Response.Redirect("~/MAT/MAT3/MAT3101_01.aspx")
        Catch ex As Exception
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
        End Try

    End Sub

    Protected Sub GridViewA_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewA.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
            Dim btnAdd As Button = e.Row.Cells(7).FindControl("btnAdd")
            btnAdd.Visible = False
            If (e.Row.RowIndex = dtCurrentTable.Rows.Count - 1) Then
                btnAdd.Visible = True 
            End If
            Dim box1 As TextBox = e.Row.Cells(1).FindControl("txtMaterialName")
            Dim box2 As TextBox = e.Row.Cells(2).FindControl("txtOutCnt")
            Dim box3 As TextBox = e.Row.Cells(3).FindControl("txtUnit")
            Dim hf_IsAuto As HiddenField = e.Row.FindControl("hf_IsAuto")
            If Not String.IsNullOrEmpty(hf_IsAuto.Value) AndAlso Convert.ToBoolean(hf_IsAuto.Value) Then
                box1.Enabled = False
                box2.Enabled = False
                box3.Enabled = False
            End If
        End If
    End Sub

    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0
        If Not ViewState("CurrentTable") Is Nothing Then
            Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
            Dim drCurrentRow As DataRow = Nothing
            If dtCurrentTable.Rows.Count > 0 Then
                For i As Integer = 1 To dtCurrentTable.Rows.Count
                    Dim box1 As TextBox = Me.GridViewA.Rows(rowIndex).Cells(1).FindControl("txtMaterialName")
                    Dim box2 As TextBox = Me.GridViewA.Rows(rowIndex).Cells(2).FindControl("txtOutCnt")
                    Dim box3 As TextBox = Me.GridViewA.Rows(rowIndex).Cells(3).FindControl("txtUnit")
                    Dim box4 As TextBox = Me.GridViewA.Rows(rowIndex).Cells(4).FindControl("txtTotalPriceAmt")
                    Dim box5 As TextBox = Me.GridViewA.Rows(rowIndex).Cells(5).FindControl("txtCompanyName")
                    Dim box6 As TextBox = Me.GridViewA.Rows(rowIndex).Cells(6).FindControl("txtMemo")
                    Dim hf_IsAuto As HiddenField = Me.GridViewA.Rows(rowIndex).FindControl("hf_IsAuto")
                    drCurrentRow = dtCurrentTable.NewRow()
                    drCurrentRow("Index") = i + 1
                    dtCurrentTable.Rows(i - 1)("Material_name") = box1.Text
                    dtCurrentTable.Rows(i - 1)("Out_cnt") = box2.Text
                    dtCurrentTable.Rows(i - 1)("Unit") = box3.Text
                    dtCurrentTable.Rows(i - 1)("TotalPrice_amt") = box4.Text
                    dtCurrentTable.Rows(i - 1)("Company_name") = box5.Text
                    dtCurrentTable.Rows(i - 1)("Memo") = box6.Text

                    If String.IsNullOrEmpty(hf_IsAuto.Value) Then
                        hf_IsAuto.Value = "false"
                    End If

                    dtCurrentTable.Rows(i - 1)("IsAuto") = IIf(String.IsNullOrEmpty(hf_IsAuto.Value), False, Convert.ToBoolean(hf_IsAuto.Value))

                    rowIndex = rowIndex + 1

                Next
                dtCurrentTable.Rows.Add(drCurrentRow)
                ViewState("CurrentTable") = dtCurrentTable
                Me.GridViewA.DataSource = dtCurrentTable
                Me.GridViewA.DataBind()


            End If
        End If
    End Sub


    Protected Sub btnAdd_Click(sender As Object, e As System.EventArgs)
        AddNewRowToGrid()
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs)
        Dim gr As GridViewRow = CType(sender, Button).NamingContainer
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
        If dtCurrentTable.Rows.Count = 1 Then
            SetInitialRow()
            Return
        End If

        dtCurrentTable.Rows.RemoveAt(gr.RowIndex)
        For i As Integer = 0 To dtCurrentTable.Rows.Count - 1
            dtCurrentTable.Rows(i)("Index") = i + 1
        Next
        ViewState("CurrentTable") = dtCurrentTable
        Me.GridViewA.DataSource = dtCurrentTable
        Me.GridViewA.DataBind()

    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As System.EventArgs) Handles ResetBtn.Click
        Me.ucApply_date.Text = String.Empty

        ViewState("CurrentTable") = Nothing
        SetInitialRow()
    End Sub

    Protected Sub BindFlowData(FlowId As String)
        If Not String.IsNullOrEmpty(FlowId) Then
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", FlowId)
            Dim am As New ApplyOtherMtrMain
            Dim dt As DataTable = am.DAO.GetDataByExample("MAT_Purchase_det", d)
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                Dim oldDT As DataTable = ViewState("CurrentTable")
                oldDT.Rows.Clear()
                Dim i As Integer = 1
                For Each dr As DataRow In dt.Rows
                    Dim oldDR As DataRow = oldDT.NewRow()
                    oldDR("Index") = i
                    oldDR("Flow_id") = FlowId
                    oldDR("Material_name") = dr("Item_name")
                    oldDR("Out_cnt") = dr("Apply_cnt")
                    oldDR("Unit") = dr("Unit")
                    oldDR("TotalPrice_amt") = ""
                    oldDR("Company_name") = ""
                    oldDR("Memo") = ""
                    oldDR("IsAuto") = True
                    i += 1
                    oldDT.Rows.Add(oldDR)
                Next
                oldDT.AcceptChanges()
                Me.GridViewA.DataSource = oldDT
                Me.GridViewA.DataBind()
                'For Each gr As GridViewRow In GridViewA.Rows
                '    Dim box1 As TextBox = gr.Cells(1).FindControl("txtMaterialName")
                '    Dim box2 As TextBox = gr.Cells(2).FindControl("txtOutCnt")
                '    Dim box3 As TextBox = gr.Cells(3).FindControl("txtUnit")
                '    box1.Enabled = False
                '    box2.Enabled = False
                '    box3.Enabled = False
                'Next
            End If
        Else
            SetInitialRow()
        End If
    End Sub

    Protected Sub BindNotImportData()
        Dim pm As PurchaseMain = New PurchaseMain()
        Dim dt As DataTable = pm.GetImporrtOtMtrNOTYData(LoginManager.OrgCode)
        gv.DataSource = dt
        gv.DataBind()

        lblDept_name.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)
        lblUser_name.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
    End Sub

    Protected Sub cbSelect_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        For Each gvr As GridViewRow In gv.Rows
            If CType(gvr.FindControl("cbx"), CheckBox).Checked Then
                Dim flowId As String = CType(gvr.FindControl("hfFlowId"), HiddenField).Value
                BindFlowData(flowId)
            End If
        Next
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Hide()
    End Sub

    Protected Sub cbxAll_CheckedChanged(sender As Object, e As EventArgs)
        Dim cbxAll As CheckBox = CType(sender, CheckBox)
        For Each gvr As GridViewRow In gv.Rows
            CType(gvr.FindControl("cbx"), CheckBox).Checked = cbxAll.Checked
        Next
    End Sub
End Class
