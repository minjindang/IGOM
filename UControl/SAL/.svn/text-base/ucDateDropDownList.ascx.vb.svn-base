Imports SALARY.Logic

Partial Class uc_ucDateDropdownList
    Inherits System.Web.UI.UserControl


#Region " Property"

    Public Property title() As String
        Get
            Return Me.Label_title.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_title.Text = value
        End Set
    End Property


    Public Property Kind() As String
        Get
            Return Me.TextBox_Kind.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_Kind.Text = value

            Try
                setstyle()
            Catch ex As Exception

            End Try

        End Set
    End Property

    Public Property ReturnValue() As String
        Get
            Return Me.TextBox_Return.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_Return.Text = value
        End Set
    End Property

    Public Property DateStr() As String
        Get
            Dim date_ymd As String = ""

            Try

                Select Case Me.TextBox_Return.Text
                    Case "Y"
                        date_ymd = Me.DropDownList_Y.SelectedValue
                    Case "YM"
                        date_ymd = Me.DropDownList_Y.SelectedValue & _
                                   Me.DropDownList_M.SelectedValue
                    Case Else
                        date_ymd = Me.DropDownList_Y.SelectedValue & _
                                   Me.DropDownList_M.SelectedValue & _
                                   Me.DropDownList_D.SelectedValue
                End Select

            Catch ex As Exception

                date_ymd = ""

            End Try

            Return date_ymd
            Return ""
        End Get
        Set(ByVal value As String)
            Me.TextBox_datestr.Text = value
            Try
                setdate()
            Catch ex As Exception

            End Try
        End Set
    End Property

    Public Property year_s() As String
        Get
            Return Me.TextBox_year_s.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_year_s.Text = value
        End Set
    End Property

    Public Property year_e() As String
        Get
            Return Me.TextBox_year_e.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_year_e.Text = value
        End Set
    End Property

#End Region

#Region " PageLoad"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Get_Y_Item()
            Get_M_Item()
            Get_D_Item()
            Get_S_Item()
            setstyle()
            setdate()

        End If
    End Sub


    Protected Sub Label_title_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label_title.Load
        Me.Label_title.Text = Server.HtmlEncode(Me.TextBox_title.Text)
        'Me.TextBox_title.Text = ""
    End Sub

#End Region

#Region " ListItem"

    Protected Sub setdate()
        Dim value = Me.TextBox_datestr.Text
        Dim date_y, date_m, date_d As String
        date_y = ""
        date_m = ""
        date_d = ""

        Try
            If Len(value) = 4 Then
                date_y = value
            ElseIf Len(value) = 6 Then
                date_y = Mid(value, 1, 4)
                date_m = Mid(value, 5, 2)
            ElseIf Len(value) = 8 Then
                date_y = Mid(value, 1, 4)
                date_m = Mid(value, 5, 2)
                date_d = Mid(value, 7, 2)
            End If

        Catch ex As Exception

        End Try

        Me.DropDownList_Y.SelectedValue = date_y
        Me.DropDownList_M.SelectedValue = date_m
        Me.DropDownList_D.SelectedValue = date_d

    End Sub

    Protected Sub setstyle()

        Select Case Me.TextBox_Kind.Text

            Case "002", "003", "004", "Y"
                ''預借考績(002),核定考績(003),年終獎金(004)
                ''只顯示年度
                Me.Y.Style.Item("display") = "inline"
                Me.M.Style.Item("display") = "none"
                Me.D.Style.Item("display") = "none"
                Me.S.Style.Item("display") = "none"
                Me.LabelY.Text = "年"
                Me.TextBox_Return.Text = "Y"
            Case "001", "005", "006", "007", "010", "YM", "009", "008"
                ''月薪(001),其他薪津(005),晉級補發(006),補扣健保費(010),年度健保(008)
                ''顯示年月
                Me.Y.Style.Item("display") = "inline"
                Me.LabelY.Text = "年"
                Me.M.Style.Item("display") = "inline"
                Me.D.Style.Item("display") = "none"
                Me.S.Style.Item("display") = "none"
                Me.TextBox_Return.Text = "YM"
            Case "YMD"
                ''顯示日期(年月日)
                Me.Y.Style.Item("display") = "inline"
                Me.LabelY.Text = "年"
                Me.M.Style.Item("display") = "inline"
                Me.D.Style.Item("display") = "inline"
                Me.S.Style.Item("display") = "none"
                Me.TextBox_Return.Text = "YMD"
            Case "S"
                Me.Y.Style.Item("display") = "inline"
                Me.LabelY.Text = "年度"
                Me.M.Style.Item("display") = "none"
                Me.D.Style.Item("display") = "none"
                Me.S.Style.Item("display") = "inline"
                Me.TextBox_Return.Text = "S"
            Case Else
                Me.Y.Style.Item("display") = "inline"
                Me.M.Style.Item("display") = "inline"
                Me.D.Style.Item("display") = "inline"

                Me.TextBox_Return.Text = "YMD"
        End Select
    End Sub

    Protected Sub Get_Y_Item()
        Dim year_s As Integer
        Dim year_e As Integer

        Try
            year_s = CInt(Me.TextBox_year_s.Text)
            year_e = CInt(Me.TextBox_year_e.Text)
        Catch ex As Exception
            year_s = CInt(Now.ToString("yyyy")) - 16
            year_e = CInt(Now.ToString("yyyy")) + 1
        End Try

        Me.DropDownList_Y.Items.Clear()

        For i As Integer = year_s To year_e

            Dim li As New ListItem(CStr(i - 1911), i)
            Me.DropDownList_Y.Items.Add(li)

        Next
    End Sub

    Protected Sub Get_M_Item()
        Me.DropDownList_M.Items.Clear()

        For i As Integer = 1 To 12

            Dim str As String = SALARY.Logic.pub.lpad(CStr(i), 2, "0")

            Dim li As New ListItem(str, str)
            Me.DropDownList_M.Items.Add(li)

        Next
    End Sub

    Protected Sub Get_D_Item()

        Dim v_year As String = Me.DropDownList_Y.SelectedValue
        Dim v_month As String = Me.DropDownList_M.SelectedValue
        Dim v_day As String = CInt(DateSerial(CInt(v_year), CInt(v_month) + 1, 0).Day.ToString)

        Dim v_date As String = Me.DropDownList_D.SelectedValue

        Me.DropDownList_D.Items.Clear()

        For i As Integer = 1 To v_day

            Dim str As String = SALARY.Logic.pub.lpad(CStr(i), 2, "0")

            Dim li As New ListItem(str, str)

            If str = v_date Then
                li.Selected = True
            End If

            Me.DropDownList_D.Items.Add(li)

        Next
    End Sub
    Protected Sub Get_S_Item()
        Dim li As New ListItem("一", "0")
        Me.DropDownList_S.Items.Add(li)
        li = New ListItem("二", "1")
        Me.DropDownList_S.Items.Add(li)
        Dim DD = Now.ToString("yyyyMM").Substring(4, 2)
        If "01".Equals(DD) Or "02".Equals(DD) Or "03".Equals(DD) Or "04".Equals(DD) Or "05".Equals(DD) Or "06".Equals(DD) Then
            Me.DropDownList_S.SelectedValue = "1"
        Else
            Me.DropDownList_S.SelectedValue = "0"
        End If
    End Sub
#End Region



    Protected Sub DropDownList_D_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_D.SelectedIndexChanged

        RaiseEvent Date_Changed(Me, e)
    End Sub

    Protected Sub DropDownList_M_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_M.SelectedIndexChanged
        Get_D_Item()
        RaiseEvent Date_Changed(Me, e)
    End Sub


    Protected Sub DropDownList_Y_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_Y.SelectedIndexChanged
        Get_D_Item()
        RaiseEvent Date_Changed(Me, e)
    End Sub


#Region " Event"

    Public Event Date_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

    Public ReadOnly Property DropDownList_S_() As DropDownList
        Get
            Return DropDownList_S
        End Get
    End Property

End Class
