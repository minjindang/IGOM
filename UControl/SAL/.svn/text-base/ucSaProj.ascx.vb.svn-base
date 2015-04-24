
Partial Class uc_ucSaProj
    Inherits System.Web.UI.UserControl

    Public Property CssClass() As String
        Get
            Return Me.DropDownList_proj_no.CssClass
        End Get
        Set(ByVal value As String)
            Me.DropDownList_proj_no.CssClass = value
        End Set
    End Property

    Public Property Mode() As String
        Get
            Return Me.TextBox_mode.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_mode.Text = value
        End Set
    End Property

    Public Property Orgid() As String
        Get
            Return Me.TextBox_orgid.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_orgid.Text = value
        End Set
    End Property

    Public Property ReturnEvent() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            Me.DropDownList_proj_no.AutoPostBack = value
        End Set
    End Property

    Public Property Proj_no() As String
        Get
            Return Me.DropDownList_proj_no.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.TextBox_selected.Text = value
            Try
                For i As Integer = 0 To Me.DropDownList_proj_no.Items.Count - 1
                    If Me.DropDownList_proj_no.Items(i).Value = value Then
                        Me.DropDownList_proj_no.ClearSelection()
                        Me.DropDownList_proj_no.Items(i).Selected = True
                    End If
                    Me.TextBox_selected.Text = ""
                Next
            Catch ex As Exception

            End Try
        End Set
    End Property

    Protected Sub DropDownList_proj_no_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_proj_no.DataBound


        ''增加不設定 OR 全部選項
        If Me.TextBox_mode.Text = "edit" Then
            Dim li As New ListItem
            li.Value = ""
            li.Text = "---不設定---"
            Me.DropDownList_proj_no.Items.Insert(0, li)
        ElseIf Me.TextBox_mode.Text = "query" Then
            Dim li As New ListItem
            li.Value = "ALL"
            li.Text = "---全部---"
            Me.DropDownList_proj_no.Items.Insert(0, li)
        Else
            ''Me.DropDownList_code_no.Items.Add("testing")
        End If


        If Me.TextBox_selected.Text <> "" Then
            For i As Integer = 0 To Me.DropDownList_proj_no.Items.Count - 1
                If Me.DropDownList_proj_no.Items(i).Value = Me.TextBox_selected.Text Then
                    Me.DropDownList_proj_no.Items(i).Selected = True
                    Me.TextBox_selected.Text = ""
                End If
            Next
        End If

    End Sub

    Public Event ProjChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    Protected Sub DropDownList_proj_no_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_proj_no.SelectedIndexChanged
        RaiseEvent ProjChanged(Me, e)
    End Sub

End Class
