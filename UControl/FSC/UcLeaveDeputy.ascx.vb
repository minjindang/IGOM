Imports System.Data

Partial Class UControl_UcLeaveDeputy
    Inherits System.Web.UI.UserControl

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
        End Set
    End Property

    Public Property DepartId() As String
        Get
            If rb1.Checked Then
                Return ddlDefaultDeputy.SelectedValue.Split(",")(1)
            Else
                Return UcDDLDeputyDepart.SelectedValue
            End If
        End Get
        Set(ByVal value As String)
            hfDepartId.Value = value
            BindDeputyDep()
        End Set
    End Property

    Public ReadOnly Property Posid() As String
        Get
            Return hfDeputyPosid.Value
        End Get
    End Property

    Public Property IdCard() As String
        Get
            If rb1.Checked Then
                Return ddlDefaultDeputy.SelectedValue.Split(",")(2)
            Else
                Return ddlDeputy.SelectedValue
            End If
        End Get
        Set(ByVal value As String)
            Dim isDefault As Boolean = False
            For Each i As ListItem In ddlDefaultDeputy.Items
                If i.Value.Split(",")(2) = value Then
                    i.Selected = True
                    isDefault = True
                Else
                    i.Selected = False 
                End If
            Next
            BindDeputyDep()
            ddlDeputy_Bind()
            ddlDeputy.SelectedValue = value

            If Not isDefault Then
                rb1.Checked = False
                rb2.Checked = True
                setEnabled("2")
            End If
        End Set
    End Property

    Public ReadOnly Property UserName() As String
        Get
            If rb1.Checked Then
                Return ddlDefaultDeputy.SelectedItem.Text.Split("/")(2)
            Else
                Return IIf(String.IsNullOrEmpty(ddlDeputy.SelectedValue), "", ddlDeputy.SelectedItem.Text)
            End If
        End Get
    End Property


    Public Property ApplyIdcard() As String
        Get
            Return hfApplyIdcard.Value
        End Get
        Set(ByVal value As String)
            hfApplyIdcard.Value = value
            BindDeputy()
            BindPosid()
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return UcDDLDeputyDepart.Enabled And ddlDeputy.Enabled
        End Get
        Set(value As Boolean)
            rb1.Enabled = value
            rb2.Enabled = value
            ddlDefaultDeputy.Enabled = value
            UcDDLDeputyDepart.Enabled = value
            ddlDeputy.Enabled = value
        End Set
    End Property

    Protected Sub BindDeputyDep()
        UcDDLDeputyDepart.Orgcode = hfOrgcode.Value
        UcDDLDeputyDepart.SelectedValue = hfDepartId.Value
    End Sub

    Protected Sub BindDeputy()
        Dim dd As New FSC.Logic.DeputyDet()
        Dim dt As DataTable = dd.GetDeputyDetByID_card(hfApplyIdcard.Value)

        ddlDeputy_Bind()
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            ddlDefaultDeputy.DataValueField = "cols"
            ddlDefaultDeputy.DataTextField = "ALL_name"
            ddlDefaultDeputy.DataSource = dt
            ddlDefaultDeputy.DataBind()
            setValue()

            rb2.Checked = False
            rb1.Checked = True
            rb1.Visible = True
            ddlDefaultDeputy.Visible = True
            UcDDLDeputyDepart.Enabled = False
            ddlDeputy.Enabled = False
        Else
            rb1.Visible = False
            rb2.Visible = False
            ddlDefaultDeputy.Visible = False
            rb1.Checked = False
            rb2.Checked = True
            UcDDLDeputyDepart.Enabled = True
            ddlDeputy.Enabled = True
        End If

        Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(ApplyIdcard)
        If psn.MutiDepartDeputy_flag <> "1" Then
            UcDDLDeputyDepart.Enabled = False
        End If
    End Sub

    Protected Sub ddlDeputy_Bind()
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        ddlDeputy.Items.Clear()
        If Not String.IsNullOrEmpty(UcDDLDeputyDepart.SelectedValue) Then
            ddlDeputy.DataSource = New FSC.Logic.Personnel().GetDataByOrgDepWithOutNonMember(Orgcode, UcDDLDeputyDepart.SelectedValue)
            ddlDeputy.DataBind()
            ddlDeputy.Items.Insert(0, New ListItem("請選擇", ""))
        End If
    End Sub

    Protected Sub UcDDLDeputyDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UcDDLDeputyDepart.SelectedIndexChanged
        ddlDeputy_Bind()
    End Sub

    Protected Sub ddlDeputy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDeputy.SelectedIndexChanged
        BindPosid()
    End Sub

    Protected Sub BindPosid()
        Dim Deputy_id As String = String.Empty
        If rb1.Checked Then
            Deputy_id = ddlDefaultDeputy.SelectedValue.Split(",")(2)
            hfDepartId.Value = ddlDefaultDeputy.SelectedValue.Split(",")(1)
        Else
            Deputy_id = ddlDeputy.SelectedValue
            hfDepartId.Value = UcDDLDeputyDepart.SelectedValue
        End If
        hfDeputyPosid.Value = New FSC.Logic.Personnel().GetColumnValue("title_no", Deputy_id)
    End Sub

    Protected Sub rb1_CheckedChanged(sender As Object, e As EventArgs)
        setEnabled("1")
        setValue()
    End Sub

    Protected Sub rb2_CheckedChanged(sender As Object, e As EventArgs)
        setEnabled("2")
        setValue()
    End Sub

    Protected Sub setEnabled(ByVal type As String)
        If type = "1" Then
            ddlDefaultDeputy.Enabled = True
            UcDDLDeputyDepart.Enabled = False
            ddlDeputy.Enabled = False
        Else
            ddlDefaultDeputy.Enabled = False
            UcDDLDeputyDepart.Enabled = True
            ddlDeputy.Enabled = True

            Dim psn As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(ApplyIdcard)
            If psn.MutiDepartDeputy_flag <> "1" Then
                UcDDLDeputyDepart.Enabled = False
            End If
        End If
    End Sub


    Protected Sub ddlDefaultDeputy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDefaultDeputy.SelectedIndexChanged
        setValue()
    End Sub

    Protected Sub setValue()
        If rb1.Checked Then
            hfOrgcode.Value = ddlDefaultDeputy.SelectedValue.Split(",")(0)
            hfDepartId.Value = ddlDefaultDeputy.SelectedValue.Split(",")(1)
            hfDeputyPosid.Value = New FSC.Logic.Personnel().GetColumnValue("title_no", ddlDefaultDeputy.SelectedValue.Split(",")(2))
        ElseIf rb2.Checked Then
            hfOrgcode.Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
            hfDepartId.Value = ddlDeputy.SelectedValue
            hfDeputyPosid.Value = New FSC.Logic.Personnel().GetColumnValue("title_no", ddlDeputy.SelectedValue)
        End If
    End Sub
End Class
