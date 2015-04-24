
Imports SALARY.Logic

Partial Class uc_ucDateTextBox
    Inherits System.Web.UI.UserControl

    Dim textboxReadonly As Boolean = False
    Public Property v_Readonly As Boolean
        Get
            Return textboxReadonly
        End Get
        Set(value As Boolean)
            textboxReadonly = value
        End Set
    End Property
    Public Property title() As String
        Get
            Return Me.Label_title.Text
        End Get
        Set(ByVal value As String)
            Me.Label_title.Text = value
        End Set
    End Property

    Public Property Kind() As String
        Get
            Return Me.TextBox_Kind.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_Kind.Text = value

            Try
                Select Case Me.TextBox_Kind.Text

                    Case "002", "003", "004", "013", "Y"
                        ''預借考績(002),核定考績(003),年終獎金(004)
                        ''只顯示年度
                        Me.Y.Style.Item("display") = "inline"
                        Me.M.Style.Item("display") = "none"
                        Me.D.Style.Item("display") = "none"

                        Me.YCheck = True
                        Me.MCheck = False
                        Me.DCheck = False

                        Me.TextBox_Return.Text = "Y"
                    Case "001", "005", "006", "007", "010", "YM", "009", "008", "012"
                        ''月薪(001),其他薪津(005),晉級補發(006),補扣健保費(010),年度健保(008)
                        ''顯示年月
                        Me.Y.Style.Item("display") = "inline"
                        Me.M.Style.Item("display") = "inline"
                        Me.D.Style.Item("display") = "none"

                        Me.YCheck = True
                        Me.MCheck = True
                        Me.DCheck = False

                        Me.TextBox_Return.Text = "YM"
                    Case "YMD"
                        ''顯示日期(年月日)
                        Me.Y.Style.Item("display") = "inline"
                        Me.M.Style.Item("display") = "inline"
                        Me.D.Style.Item("display") = "inline"

                        Me.YCheck = True
                        Me.MCheck = True
                        Me.DCheck = True

                        Me.TextBox_Return.Text = "YMD"
                    Case Else
                        Me.Y.Style.Item("display") = "inline"
                        Me.M.Style.Item("display") = "inline"
                        Me.D.Style.Item("display") = "inline"

                        Me.YCheck = False
                        Me.MCheck = False
                        Me.DCheck = False

                        Me.TextBox_Return.Text = "YMD"
                End Select
            Catch ex As Exception

            End Try

        End Set
    End Property

    Public Property Date_Check() As Boolean
        Get
            Dim rv As Boolean = True

            Dim date_ymd As String = ""

            Dim date_y As String = ""
            Dim date_m As String = ""
            Dim date_d As String = ""

            Try

                Select Case Me.TextBox_Return.Text
                    Case "Y"
                        date_y = CStr(CInt(Me.TextBox_Y.Text) + 1911)
                        date_m = "01"
                        date_d = "01"

                        date_ymd = date_y & "/" & date_m & "/" & date_d
                        date_ymd = Date.Parse(date_ymd).ToString("yyyy")
                    Case "YM"
                        date_y = CStr(CInt(Me.TextBox_Y.Text) + 1911)
                        date_m = pub.get_zero(Me.TextBox_M.Text, 2)
                        date_d = "01"

                        date_ymd = date_y & "/" & date_m & "/" & date_d
                        date_ymd = Date.Parse(date_ymd).ToString("yyyyMM")
                    Case Else
                        '' "YMD"
                        date_y = CStr(CInt(Me.TextBox_Y.Text) + 1911)
                        date_m = pub.get_zero(Me.TextBox_M.Text, 2)
                        date_d = pub.get_zero(Me.TextBox_D.Text, 2)

                        date_ymd = date_y & "/" & date_m & "/" & date_d
                        date_ymd = Date.Parse(date_ymd).ToString("yyyyMMdd")

                End Select

            Catch ex As Exception

                rv = False

            End Try

            Return rv
        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property DateStr() As String
        Get

            Dim date_ymd As String = ""

            Dim date_y As String = ""
            Dim date_m As String = ""
            Dim date_d As String = ""

            Try

                Select Case Me.TextBox_Return.Text
                    Case "Y"
                        date_y = CStr(CInt(Me.TextBox_Y.Text) + 1911)
                        date_m = "01"
                        date_d = "01"

                        date_ymd = date_y & "/" & date_m & "/" & date_d
                        date_ymd = Date.Parse(date_ymd).ToString("yyyy")
                    Case "YM"
                        date_y = CStr(CInt(Me.TextBox_Y.Text) + 1911)
                        date_m = pub.get_zero(Me.TextBox_M.Text, 2)
                        date_d = "01"

                        date_ymd = date_y & "/" & date_m & "/" & date_d
                        date_ymd = Date.Parse(date_ymd).ToString("yyyyMM")
                    Case Else
                        '' "YMD"
                        date_y = CStr(CInt(Me.TextBox_Y.Text) + 1911)
                        date_m = pub.get_zero(Me.TextBox_M.Text, 2)
                        date_d = pub.get_zero(Me.TextBox_D.Text, 2)

                        date_ymd = date_y & "/" & date_m & "/" & date_d
                        date_ymd = Date.Parse(date_ymd).ToString("yyyyMMdd")

                End Select

            Catch ex As Exception

                date_ymd = ""

            End Try

            Return date_ymd
        End Get
        Set(ByVal value As String)

            Dim date_y, date_m, date_d As String
            date_y = ""
            date_m = ""
            date_d = ""

            Try
                If Len(value) = 4 Then
                    date_y = CStr(CInt(value) - 1911)
                ElseIf Len(value) = 6 Then
                    date_y = CStr(CInt(Mid(value, 1, 4)) - 1911)
                    date_m = Mid(value, 5, 2)
                ElseIf Len(value) = 8 Then
                    date_y = CStr(CInt(Mid(value, 1, 4)) - 1911)
                    date_m = Mid(value, 5, 2)
                    date_d = Mid(value, 7, 2)
                End If


                Me.TextBox_Y.Text = date_y
                Me.TextBox_M.Text = date_m
                Me.TextBox_D.Text = date_d

            Catch ex As Exception
                Me.TextBox_DateStr.Text = value
            End Try


        End Set
    End Property

    Public Property YCheck() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            Me.TextBox_Y.AutoPostBack = value
        End Set
    End Property

    Public Property MCheck() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            Me.TextBox_M.AutoPostBack = value
        End Set
    End Property

    Public Property DCheck() As Boolean
        Get

        End Get
        Set(ByVal value As Boolean)
            Me.TextBox_D.AutoPostBack = value
        End Set
    End Property

    Protected Sub TextBox_Y_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_Y.TextChanged
        Try
            Dim date_y As String = CStr(CInt(Me.TextBox_Y.Text) + 1911)
            Dim date_m As String = "01"
            Dim date_d As String = "01"

            Dim date_ymd As String = date_y & "/" & date_m & "/" & date_d
            date_ymd = Date.Parse(date_ymd).ToString("yyyy")

        Catch ex As Exception

            Me.TextBox_Y.Text = ""
            Me.TextBox_Y.Focus()

            Dim message As String = "日期格式不正確"
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "showmsg", "alert('" & message & "');$get('" & Me.TextBox_Y.ClientID & "').focus();", True)

        End Try
        RaiseEvent Year_Changed(Me, e)
    End Sub

    Protected Sub TextBox_M_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_M.TextChanged
        Try
            Dim date_y As String = CStr(CInt(Me.TextBox_Y.Text) + 1911)
            Dim date_m As String = pub.get_zero(Me.TextBox_M.Text, 2)
            Dim date_d As String = "01"

            Dim date_ymd As String = date_y & "/" & date_m & "/" & date_d
            date_ymd = Date.Parse(date_ymd).ToString("yyyyMM")

        Catch ex As Exception

            Me.TextBox_M.Text = ""
            Me.TextBox_M.Focus()

            Dim message As String = "日期格式不正確"
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "showmsg", "alert('" & message & "');$get('" & Me.TextBox_M.ClientID & "').focus();", True)

        End Try
        RaiseEvent Month_Changed(Me, e)
    End Sub

    Protected Sub TextBox_D_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox_D.TextChanged
        Try
            Dim date_y As String = CStr(CInt(Me.TextBox_Y.Text) + 1911)
            Dim date_m As String = pub.get_zero(Me.TextBox_M.Text, 2)
            Dim date_d As String = pub.get_zero(Me.TextBox_D.Text, 2)

            Dim date_ymd As String = date_y & "/" & date_m & "/" & date_d
            date_ymd = Date.Parse(date_ymd).ToString("yyyyMMdd")

        Catch ex As Exception

            Me.TextBox_D.Text = ""
            Me.TextBox_D.Focus()

            Dim message As String = "日期格式不正確"
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "showmsg", "alert('" & message & "');$get('" & Me.TextBox_D.ClientID & "').focus();", True)

        End Try
        RaiseEvent Day_Changed(Me, e)
    End Sub

#Region " Event"

    Public Event Year_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Event Month_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Event Day_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.TextBox_DateStr.Text <> "" Then
            Dim value As String = Me.TextBox_DateStr.Text
            Dim date_y, date_m, date_d As String
            date_y = ""
            date_m = ""
            date_d = ""

            Try
                If Len(value) = 4 Then
                    date_y = CStr(CInt(value) - 1911)
                ElseIf Len(value) = 6 Then
                    date_y = CStr(CInt(Mid(value, 1, 4)) - 1911)
                    date_m = Mid(value, 5, 2)
                ElseIf Len(value) = 8 Then
                    date_y = CStr(CInt(Mid(value, 1, 4)) - 1911)
                    date_m = Mid(value, 5, 2)
                    date_d = Mid(value, 7, 2)
                End If


                Me.TextBox_Y.Text = date_y
                Me.TextBox_M.Text = date_m
                Me.TextBox_D.Text = date_d

            Catch ex As Exception
                Me.TextBox_DateStr.Text = value
            End Try
            Me.TextBox_DateStr.Text = ""
        End If

        If Me.TextBox_Kind.Text <> "" Then

            Select Case Me.TextBox_Kind.Text

                Case "002", "003", "004", "013", "Y"
                    ''預借考績(002),核定考績(003),年終獎金(004)
                    ''只顯示年度
                    Me.Y.Style.Item("display") = "inline"
                    Me.M.Style.Item("display") = "none"
                    Me.D.Style.Item("display") = "none"

                    Me.YCheck = True
                    Me.MCheck = False
                    Me.DCheck = False

                    Me.TextBox_Return.Text = "Y"
                Case "001", "005", "006", "007", "010", "YM", "009", "008", "012"
                    ''月薪(001),其他薪津(005),晉級補發(006),補扣健保費(010),年度健保(008)
                    ''顯示年月
                    Me.Y.Style.Item("display") = "inline"
                    Me.M.Style.Item("display") = "inline"
                    Me.D.Style.Item("display") = "none"

                    Me.YCheck = True
                    Me.MCheck = True
                    Me.DCheck = False

                    Me.TextBox_Return.Text = "YM"
                Case "YMD"
                    ''顯示日期(年月日)
                    Me.Y.Style.Item("display") = "inline"
                    Me.M.Style.Item("display") = "inline"
                    Me.D.Style.Item("display") = "inline"

                    Me.YCheck = True
                    Me.MCheck = True
                    Me.DCheck = True

                    Me.TextBox_Return.Text = "YMD"
                Case Else
                    Me.Y.Style.Item("display") = "inline"
                    Me.M.Style.Item("display") = "inline"
                    Me.D.Style.Item("display") = "inline"

                    Me.YCheck = False
                    Me.MCheck = False
                    Me.DCheck = False

                    Me.TextBox_Return.Text = "YMD"
            End Select
        End If
        If (textboxReadonly) Then
            Me.TextBox_Y.ReadOnly = textboxReadonly
            Me.TextBox_M.ReadOnly = textboxReadonly
            Me.TextBox_D.ReadOnly = textboxReadonly
            'Me.TextBox_Y.BackColor = Drawing.Color.LightGray
            'Me.TextBox_M.BackColor = Drawing.Color.LightGray
            'Me.TextBox_D.BackColor = Drawing.Color.LightGray
        Else
            Me.TextBox_Y.ReadOnly = textboxReadonly
            Me.TextBox_M.ReadOnly = textboxReadonly
            Me.TextBox_D.ReadOnly = textboxReadonly
            'Me.TextBox_Y.BackColor = Drawing.Color.White
            'Me.TextBox_M.BackColor = Drawing.Color.White
            'Me.TextBox_D.BackColor = Drawing.Color.White
        End If
        

    End Sub

End Class
