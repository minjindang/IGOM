Imports System.Data
Imports FSCPLM.Logic

Partial Class MAI_MAI1_MAI1201_01
    Inherits BaseWebForm

    Dim dao As New MAI1201

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            SetInitialRow()
            lblUserName.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
            lblDeptName.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.DepartName)
        End If

    End Sub

    Protected Sub AddBtn_Click(sender As Object, e As EventArgs) Handles AddBtn.Click
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(txtProblem_desc.Text) Then
            msg += "請輸入問題描述\n"
        End If
        If String.IsNullOrEmpty(ucMtClass_type.SelectedValue) Then
            msg += "請選擇報修類別\n"
        Else
            Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
            If Not dtCurrentTable Is Nothing OrElse dtCurrentTable.Rows.Count > 0 Then
                Dim newDT As DataTable = dtCurrentTable.DefaultView.ToTable(True, "MtClass_type")
                If newDT.Select(String.Format(" MtClass_type = '{0}' ", ucMtClass_type.SelectedValue)).Length > 0 Then
                    msg += "報修類別已重複\n"
                End If
            End If
        End If
        If String.IsNullOrEmpty(ucElecExpect_type.SelectedValue) Then
            msg += "請選擇前往維修時間\n"
        End If

        If String.IsNullOrEmpty(msg) Then
            AddNewRowToGrid()
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If


    End Sub

    Protected Sub DoneBtn_Click(sender As Object, e As EventArgs) Handles DoneBtn.Click
        Dim msg As String = String.Empty
        If String.IsNullOrEmpty(txtPhone_nos.Text) Then
            msg += "請輸入報修人聯絡分機\n"
        End If
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
        If dtCurrentTable Is Nothing OrElse dtCurrentTable.Rows.Count <= 0 Then
            msg += "至少要一筆報修申請\n"
        End If

        If String.IsNullOrEmpty(msg) Then
            Dim attPath As String = String.Empty
            If Me.fuAttachment.HasFile Then
                attPath = "~/fileupload/Attachment/55/" + fuAttachment.FileName
                Me.fuAttachment.PostedFile.SaveAs(IO.Path.Combine(MapPath("~/fileupload/Attachment/55"), fuAttachment.FileName))
            End If
            Try
                dao.Add(txtPhone_nos.Text, attPath, dtCurrentTable)

                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "申請已送出")
            Catch ex As Exception
                CommonFun.MsgShow(Page, CommonFun.Msg.Custom, ex.Message)
            End Try
          
        Else
            CommonFun.MsgShow(Page, CommonFun.Msg.Custom, msg)
        End If
    End Sub

    Protected Sub btnMaintain_Click(sender As Object, e As System.EventArgs)
        Dim gr As GridViewRow = CType(sender, Button).NamingContainer
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")

        Dim dr As DataRow = dtCurrentTable.Rows(gr.RowIndex)

        txtProblem_desc.Text = CommonFun.SetDataRow(dr, "Problem_desc")
        ucMtClass_type.Code_no = CommonFun.SetDataRow(dr, "MtClass_type")
        ucElecExpect_type.Code_no = CommonFun.SetDataRow(dr, "ElecExpect_type")

        If ucMtClass_type.Code_no = "010" Then
            txtMtItemOther_desc.Text = CommonFun.SetDataRow(dr, "MtClass_typeName")
        End If


    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As System.EventArgs)
        Dim gr As GridViewRow = CType(sender, Button).NamingContainer
        Dim dtCurrentTable As DataTable = ViewState("CurrentTable")

        dtCurrentTable.Rows.RemoveAt(gr.RowIndex)
        ViewState("CurrentTable") = dtCurrentTable
        Me.GridViewA.DataSource = dtCurrentTable
        Me.GridViewA.DataBind()

    End Sub

    Private Sub AddNewRowToGrid()
        Dim rowIndex As Integer = 0
        If Not ViewState("CurrentTable") Is Nothing Then
            Dim dtCurrentTable As DataTable = ViewState("CurrentTable")
            Dim dr As DataRow = dtCurrentTable.NewRow()
            If ucMtClass_type.SelectedValue = "010" Then
                dr("MtClass_typeName") = txtMtItemOther_desc.Text
            Else
                dr("MtClass_typeName") = ucMtClass_type.SelectedItem.Text
            End If
            dr("Problem_desc") = txtProblem_desc.Text
            dr("ElecExpect_typeName") = ucElecExpect_type.SelectedItem.Text
            dr("ElecExpect_type") = ucElecExpect_type.SelectedValue
            dr("MtClass_type") = ucMtClass_type.SelectedValue


            'Dim filePath As String = IO.Path.Combine(MapPath("~/fileupload/Attachment/55/temp"), hfGuid.Value)

            'If Not System.IO.Directory.Exists(filePath) Then
            '    System.IO.Directory.CreateDirectory(filePath)
            'End If



            'If Me.fuAttachment.HasFile Then
            '    Me.fuAttachment.PostedFile.SaveAs(IO.Path.Combine(filePath, fuAttachment.FileName))
            '    dr("Attachment") = IO.Path.Combine(filePath, fuAttachment.FileName)
            'End If


            dtCurrentTable.Rows.Add(dr)
            ViewState("CurrentTable") = dtCurrentTable
            Me.GridViewA.DataSource = dtCurrentTable
            Me.GridViewA.DataBind()


            'End If
        End If
    End Sub

    Private Sub SetInitialRow()
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(New DataColumn("MtClass_typeName"))
        dt.Columns.Add(New DataColumn("Problem_desc"))
        dt.Columns.Add(New DataColumn("ElecExpect_typeName"))
        dt.Columns.Add(New DataColumn("ElecExpect_type"))
        dt.Columns.Add(New DataColumn("MtClass_type"))
        dt.Columns.Add(New DataColumn("Attachment"))

        ViewState("CurrentTable") = dt

        Me.GridViewA.DataSource = dt
        Me.GridViewA.DataBind()
    End Sub

End Class
