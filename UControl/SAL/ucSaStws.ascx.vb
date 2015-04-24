
Partial Class uc_ucSaStws
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TextBox_ym.Text = Now.ToString("yyyyMM")

    End Sub

#Region "property"

    Public Property v_Level() As String
        Get
            Return Me.DropDownList_level.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.TextBox_selected.Text = value
        End Set
    End Property

    Public Property v_No() As String
        Get
            Return Me.TextBox_no.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_no.Text = value
        End Set
    End Property

    Public Property v_Ym() As String
        Get
            Return Me.TextBox_ym.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_ym.Text = value
        End Set
    End Property

    Public Property v_Mode() As String
        Get
            Return Me.TextBox_mode.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_mode.Text = value
        End Set
    End Property

#End Region


    Protected Sub DropDownList_level_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_level.DataBound
        ''增加不設定 OR 全部選項
        If Me.TextBox_mode.Text = "formsabase_001" Then
            Dim li As New ListItem
            li.Value = "0"
            li.Text = "系統設定"
            Me.DropDownList_level.Items.Insert(0, li)
        ElseIf Me.TextBox_mode.Text = "formsabase_002" Then
            Dim li As New ListItem
            li.Value = "99"
            li.Text = "系統設定"
            Me.DropDownList_level.Items.Insert(0, li)

            Dim li2 As New ListItem
            li2.Value = "0"
            li2.Text = "同勞保"
            Me.DropDownList_level.Items.Insert(1, li2)
        ElseIf Me.TextBox_mode.Text = "formsabase_005" Then
            Dim li As New ListItem
            li.Value = "A"
            li.Text = "同勞保"


            Dim li2 As New ListItem
            li2.Value = "B"
            li2.Text = "同健保"
            Me.DropDownList_level.Items.Insert(0, li2)
            Me.DropDownList_level.Items.Insert(1, li)

        Else
            ''Me.DropDownList_code_no.Items.Add("testing")
        End If


        If Me.TextBox_selected.Text <> "" Then
            For i As Integer = 0 To Me.DropDownList_level.Items.Count - 1
                If Me.DropDownList_level.Items(i).Value = Me.TextBox_selected.Text Then
                    Me.DropDownList_level.Items(i).Selected = True
                    Me.TextBox_selected.Text = ""
                End If
            Next
        End If

    End Sub
End Class
