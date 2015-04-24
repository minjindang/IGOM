
Partial Class uc_ucSaCode
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RadioButton_Code_no.Style.Add("border-width", "0px")
        CheckBoxList_Code_no.Style.Add("border-width", "0px")
        If Not IsPostBack Then

            BindCode()
        End If

    End Sub

    Protected Sub BindCode4Multi()
        Dim sdao As New FSCPLM.Logic.SACode
        If (ShowType) Then
            CheckBoxList_Code_no.DataTextField = "CODE_DESC1"
            CheckBoxList_Code_no.DataValueField = "CODE_NO"

            CheckBoxList_Code_no.DataSource = sdao.GetTYPEData(Code_sys)
            CheckBoxList_Code_no.DataBind()
        Else

            CheckBoxList_Code_no.DataTextField = "CODE_DESC1"
            CheckBoxList_Code_no.DataValueField = "CODE_NO"

            CheckBoxList_Code_no.DataSource = sdao.GetData(Code_sys, Code_type)
            CheckBoxList_Code_no.DataBind()
        End If

        If Not (String.IsNullOrEmpty(Code_Kind)) Then
            CheckBoxList_Code_no.DataTextField = "CODE_DESC1"
            CheckBoxList_Code_no.DataValueField = "CODE_NO"

            CheckBoxList_Code_no.DataSource = sdao.GetData2(Code_sys, Code_Kind, Code_type)
            CheckBoxList_Code_no.DataBind()
        End If


    End Sub


    Protected Sub BindCode()
        Dim sdao As New FSCPLM.Logic.SACode
        If (ShowType) Then
            '強制僅顯示TYPE
            Select Case ControlType
                Case Control.DropDownList
                    DropDownList_code_no.DataTextField = "CODE_DESC1"
                    DropDownList_code_no.DataValueField = "CODE_NO"

                    DropDownList_code_no.DataSource = sdao.GetTYPEData(Code_sys)
                    DropDownList_code_no.DataBind()
                Case Control.RadioButtonList
                    RadioButton_Code_no.DataTextField = "CODE_DESC1"
                    RadioButton_Code_no.DataValueField = "CODE_NO"

                    RadioButton_Code_no.DataSource = sdao.GetTYPEData(Code_sys)
                    RadioButton_Code_no.DataBind()
                Case Control.CheckBoxList
                    CheckBoxList_Code_no.DataTextField = "CODE_DESC1"
                    CheckBoxList_Code_no.DataValueField = "CODE_NO"

                    CheckBoxList_Code_no.DataSource = sdao.GetTYPEData(Code_sys)
                    CheckBoxList_Code_no.DataBind()
            End Select
        Else
            '原程式碼
            Select Case ControlType
                Case Control.DropDownList
                    DropDownList_code_no.DataTextField = "CODE_DESC1"
                    DropDownList_code_no.DataValueField = "CODE_NO"

                    DropDownList_code_no.DataSource = sdao.GetData(Code_sys, Code_type)
                    DropDownList_code_no.DataBind()
                Case Control.RadioButtonList
                    RadioButton_Code_no.DataTextField = "CODE_DESC1"
                    RadioButton_Code_no.DataValueField = "CODE_NO"

                    RadioButton_Code_no.DataSource = sdao.GetData(Code_sys, Code_type)
                    RadioButton_Code_no.DataBind()
                Case Control.CheckBoxList
                    CheckBoxList_Code_no.DataTextField = "CODE_DESC1"
                    CheckBoxList_Code_no.DataValueField = "CODE_NO"

                    CheckBoxList_Code_no.DataSource = sdao.GetData(Code_sys, Code_type)
                    CheckBoxList_Code_no.DataBind()
            End Select
        End If


        If Not (String.IsNullOrEmpty(Code_Kind)) Then

            Select Case ControlType
                Case Control.DropDownList
                    DropDownList_code_no.DataTextField = "CODE_DESC1"
                    DropDownList_code_no.DataValueField = "CODE_NO"

                    DropDownList_code_no.DataSource = sdao.GetData2(Code_sys, Code_Kind, Code_type)
                    DropDownList_code_no.DataBind()
                Case Control.RadioButtonList
                    RadioButton_Code_no.DataTextField = "CODE_DESC1"
                    RadioButton_Code_no.DataValueField = "CODE_NO"

                    RadioButton_Code_no.DataSource = sdao.GetData2(Code_sys, Code_Kind, Code_type)
                    RadioButton_Code_no.DataBind()
                Case Control.CheckBoxList
                    CheckBoxList_Code_no.DataTextField = "CODE_DESC1"
                    CheckBoxList_Code_no.DataValueField = "CODE_NO"

                    CheckBoxList_Code_no.DataSource = sdao.GetData2(Code_sys, Code_Kind, Code_type)
                    CheckBoxList_Code_no.DataBind()
            End Select

        End If
    End Sub
    Dim v_showtype As Boolean = False
    Public Property ShowType As Boolean
        Get
            Return v_showtype
        End Get
        Set(value As Boolean)
            v_showtype = value
        End Set
    End Property

    Enum Control
        RadioButtonList = 1
        DropDownList = 2
        CheckBoxList = 3
    End Enum
    Public Property ControlType As Control
        Get
            Dim rtn As Control
            Select Case TextBox_controltype.Text
                Case "1"
                    rtn = Control.RadioButtonList
                Case "2"
                    rtn = Control.DropDownList
                Case "3"
                    rtn = Control.CheckBoxList
            End Select
            Return rtn
        End Get
        Set(value As Control)
            Select Case value
                Case Control.DropDownList
                    DropDownList_code_no.Visible = True
                    RadioButton_Code_no.Visible = False
                    CheckBoxList_Code_no.Visible = False
                    TextBox_controltype.Text = "2"
                Case Control.RadioButtonList
                    DropDownList_code_no.Visible = False
                    RadioButton_Code_no.Visible = True
                    CheckBoxList_Code_no.Visible = False
                    TextBox_controltype.Text = "1"
                Case Control.CheckBoxList
                    DropDownList_code_no.Visible = False
                    RadioButton_Code_no.Visible = False
                    CheckBoxList_Code_no.Visible = True
                    TextBox_controltype.Text = "3"
            End Select
        End Set
    End Property

    Public ReadOnly Property SelectedItem As ListItem
        Get
            Dim rtn As ListItem = Nothing
            Select Case ControlType
                Case Control.DropDownList
                    ' Add Multi
                    If Me.DropDownList_code_no.SelectedValue = "Multi" Then
                        rtn = CheckBoxList_Code_no.SelectedItem
                    Else
                        rtn = DropDownList_code_no.SelectedItem
                    End If

                Case Control.RadioButtonList
                    rtn = RadioButton_Code_no.SelectedItem
                Case Control.CheckBoxList
                    rtn = CheckBoxList_Code_no.SelectedItem
            End Select
            Return rtn

        End Get
    End Property

    '增加 ShowMulti Propority
    ' 20140325 Eliot Chen
    Public Property ShowMulti As Boolean
        Get
            If hfShowMulti.Value = "" Then
                Return False
            Else
                Return hfShowMulti.Value
            End If
        End Get
        Set(ByVal value As Boolean)
            hfShowMulti.Value = value
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            Dim rtn As String = ""
            Select Case ControlType
                Case Control.DropDownList
                    ' Add Multi
                    If Me.DropDownList_code_no.SelectedValue = "Multi" Then
                        For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                            If Me.CheckBoxList_Code_no.Items(i).Selected Then
                                If rtn <> "" Then rtn &= ","
                                'rtn &= ";" & Me.CheckBoxList_Code_no.Items(i).Value & ";"
                                rtn &= Me.CheckBoxList_Code_no.Items(i).Value
                            End If
                        Next
                    Else
                        rtn = DropDownList_code_no.SelectedValue
                    End If

                Case Control.RadioButtonList
                    rtn = RadioButton_Code_no.SelectedValue
                Case Control.CheckBoxList
                    For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                        If Me.CheckBoxList_Code_no.Items(i).Selected Then
                            rtn &= ";" & Me.CheckBoxList_Code_no.Items(i).Value & ";"
                        End If
                    Next
            End Select
            Return rtn

        End Get
        Set(ByVal value As String)
            Select Case ControlType
                Case Control.DropDownList
                    DropDownList_code_no.SelectedValue = value
                    Me.TextBox_mode.Text = value
                Case Control.RadioButtonList
                    RadioButton_Code_no.SelectedValue = value
                    Me.TextBox_mode.Text = value
                Case Control.CheckBoxList
                    For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                        If value.Contains(";" & Me.CheckBoxList_Code_no.Items(i).Value & ";") Then
                            Me.CheckBoxList_Code_no.ClearSelection()
                            Me.CheckBoxList_Code_no.Items(i).Selected = True
                        End If
                    Next
                    Me.TextBox_mode.Text = value
            End Select

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

    Public Property Code_sys() As String
        Get
            Return Me.TextBox_code_sys.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_sys.Text = value
        End Set
    End Property
    Public Property Code_Kind() As String
        Get
            Return Me.TextBox_code_kind.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_kind.Text = value
        End Set
    End Property
    Public Property Code_type() As String
        Get
            Return Me.TextBox_code_type.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_type.Text = value
        End Set
    End Property

    Public Property Code_no() As String
        Get
            Dim rtn As String = ""
            Select Case ControlType
                Case Control.DropDownList
                    If Me.DropDownList_code_no.SelectedValue = "Multi" Then
                        For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                            If Me.CheckBoxList_Code_no.Items(i).Selected Then
                                If rtn <> "" Then rtn &= ","
                                'rtn &= ";" & Me.CheckBoxList_Code_no.Items(i).Value & ";"
                                rtn &= Me.CheckBoxList_Code_no.Items(i).Value
                            End If
                        Next
                    Else
                        rtn = Me.DropDownList_code_no.SelectedValue
                    End If
                Case Control.RadioButtonList
                    rtn = Me.RadioButton_Code_no.SelectedValue
                Case Control.CheckBoxList
                    'rtn = Me.CheckBoxList_Code_no.SelectedValue
                    For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                        If Me.CheckBoxList_Code_no.Items(i).Selected Then
                            rtn &= ";" & Me.CheckBoxList_Code_no.Items(i).Value & ";"
                        End If
                    Next
            End Select

            Return rtn
        End Get
        Set(ByVal value As String)
            Me.TextBox_selected.Text = value
            Select Case ControlType
                Case Control.DropDownList
                    Try
                        For i As Integer = 0 To Me.DropDownList_code_no.Items.Count - 1
                            If Me.DropDownList_code_no.Items(i).Value = value Then
                                Me.DropDownList_code_no.ClearSelection()
                                Me.DropDownList_code_no.Items(i).Selected = True
                            End If
                            Me.TextBox_selected.Text = ""
                        Next
                    Catch ex As Exception

                    End Try
                Case Control.RadioButtonList
                    Try
                        For i As Integer = 0 To Me.RadioButton_Code_no.Items.Count - 1
                            If Me.RadioButton_Code_no.Items(i).Value = value Then
                                Me.RadioButton_Code_no.ClearSelection()
                                Me.RadioButton_Code_no.Items(i).Selected = True
                            End If
                            Me.TextBox_selected.Text = ""
                        Next
                    Catch ex As Exception

                    End Try
                Case Control.CheckBoxList
                    Try
                        For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                            If TextBox_selected.Text.Contains(";" & Me.CheckBoxList_Code_no.Items(i).Value & ";") Then
                                Me.CheckBoxList_Code_no.ClearSelection()
                                Me.CheckBoxList_Code_no.Items(i).Selected = True
                            End If
                        Next
                        Me.TextBox_selected.Text = ""
                    Catch ex As Exception

                    End Try
            End Select

        End Set
    End Property

    Public WriteOnly Property ReturnEvent() As Boolean
        Set(ByVal value As Boolean)
            'DropDown Always auto PostBack
            'By Eliot 20140325
            'Me.DropDownList_code_no.AutoPostBack = value
            Me.RadioButton_Code_no.AutoPostBack = value
        End Set
    End Property

    Public Property RepeatColumns() As Integer
        Get
            Dim rtn As Integer = 0
            Select Case ControlType
                Case Control.RadioButtonList
                    rtn = RadioButton_Code_no.RepeatColumns
                Case Control.CheckBoxList
                    rtn = CheckBoxList_Code_no.RepeatColumns
            End Select
            Return rtn

        End Get
        Set(ByVal value As Integer)
            Me.CheckBoxList_Code_no.RepeatColumns = value
            Me.RadioButton_Code_no.RepeatColumns = value
        End Set
    End Property

    Public ReadOnly Property DDL() As DropDownList
        Get
            Return Me.DropDownList_code_no
        End Get
    End Property

    Public Sub CheckAll(check As Boolean)
        For Each cb As ListItem In CheckBoxList_Code_no.Items
            cb.Selected = check
        Next

    End Sub

    Protected Sub DropDownList_code_no_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_code_no.DataBound, RadioButton_Code_no.DataBound

        ''增加不設定 OR 全部選項
        If Me.TextBox_mode.Text = "edit" Then
            Dim li As New ListItem
            li.Value = "N"
            li.Text = "---不設定---"
            If ControlType = Control.DropDownList Then
                Me.DropDownList_code_no.Items.Insert(0, li)
            ElseIf ControlType = Control.RadioButtonList Then
                Me.RadioButton_Code_no.Items.Insert(0, li)
            Else
                Me.CheckBoxList_Code_no.Items.Insert(0, li)
            End If

        ElseIf Me.TextBox_mode.Text = "query" Then
            Dim li As New ListItem
            li.Value = "ALL"
            li.Text = "---全部---"

            If ControlType = Control.DropDownList Then
                Me.DropDownList_code_no.Items.Insert(0, li)

            ElseIf ControlType = Control.RadioButtonList Then
                Me.RadioButton_Code_no.Items.Insert(0, li)
            Else
                Me.CheckBoxList_Code_no.Items.Insert(0, li)
            End If
        ElseIf Me.TextBox_mode.Text = "selectone" Then
            Dim li As New ListItem
            li.Value = ""
            li.Text = "---請選擇---"
            If ControlType = Control.DropDownList Then
                Me.DropDownList_code_no.Items.Insert(0, li)
            ElseIf ControlType = Control.RadioButtonList Then
                Me.RadioButton_Code_no.Items.Insert(0, li)
            Else
                Me.CheckBoxList_Code_no.Items.Insert(0, li)
            End If

        ElseIf Me.TextBox_mode.Text = "empty" Then
            Dim li As New ListItem
            li.Value = ""
            li.Text = ""

            If ControlType = Control.DropDownList Then
                Me.DropDownList_code_no.Items.Insert(0, li)
            ElseIf ControlType = Control.RadioButtonList Then
                Me.RadioButton_Code_no.Items.Insert(0, li)
            Else
                Me.CheckBoxList_Code_no.Items.Insert(0, li)
            End If
        ElseIf Me.TextBox_mode.Text = "Readonly" Then

            If ControlType = Control.DropDownList Then
                Me.DropDownList_code_no.Enabled = False
            ElseIf ControlType = Control.RadioButtonList Then
                Me.RadioButton_Code_no.Enabled = False
            Else
                Me.CheckBoxList_Code_no.Enabled = False
            End If
        Else
            ''Me.DropDownList_code_no.Items.Add("testing")
        End If

        If (ShowMulti) Then
            Dim li2 As New ListItem("複選", "Multi")
            DropDownList_code_no.Items.Insert(1, li2)
        End If


        If Me.TextBox_selected.Text <> "" Then
            If ControlType = Control.DropDownList Then
                For i As Integer = 0 To Me.DropDownList_code_no.Items.Count - 1
                    If Me.DropDownList_code_no.Items(i).Value = Me.TextBox_selected.Text Then
                        Me.DropDownList_code_no.ClearSelection()
                        Me.DropDownList_code_no.Items(i).Selected = True
                        Me.TextBox_selected.Text = ""
                    End If
                Next
            ElseIf ControlType = Control.RadioButtonList Then
                For i As Integer = 0 To Me.RadioButton_Code_no.Items.Count - 1
                    If Me.RadioButton_Code_no.Items(i).Value = Me.TextBox_selected.Text Then
                        Me.RadioButton_Code_no.ClearSelection()
                        Me.RadioButton_Code_no.Items(i).Selected = True
                        Me.RadioButton_Code_no.Text = ""
                    End If
                Next
            Else
                For i As Integer = 0 To Me.CheckBoxList_Code_no.Items.Count - 1
                    If Me.CheckBoxList_Code_no.Items(i).Value = Me.TextBox_selected.Text Then
                        Me.CheckBoxList_Code_no.ClearSelection()
                        Me.CheckBoxList_Code_no.Items(i).Selected = True
                        Me.CheckBoxList_Code_no.Text = ""
                    End If
                Next
            End If


        End If
    End Sub

    Public Event CodeChanged(ByVal sender As Object, ByVal e As System.EventArgs)


    Protected Sub DropDownList_code_no_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_code_no.SelectedIndexChanged
        If DropDownList_code_no.SelectedValue = "Multi" Then
            CheckBoxList_Code_no.Visible = True
            BindCode4Multi()
        Else
            CheckBoxList_Code_no.Visible = False
        End If
        RaiseEvent CodeChanged(Me, e)
    End Sub

    Public Sub Rebind()
        BindCode()
    End Sub



End Class
