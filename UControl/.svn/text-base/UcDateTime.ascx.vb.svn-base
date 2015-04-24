Imports FSCPLM.Logic

Partial Class UControl_UcDateTime
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Text() As String
        Get
            If Not String.IsNullOrEmpty(tbDate.Text.Trim()) Then
                Return tbDate.Text.Trim().PadLeft(7, "0").Replace("/", "")
            End If
            Return tbDate.Text.Trim()
        End Get
        Set(ByVal value As String)
            If value.Length = 7 Then
                tbDate.Text = DateTimeInfo.ToDisplay(value)
            Else
                tbDate.Text = value
            End If
        End Set
    End Property

    Public Property Time() As String
        Get
            If Not String.IsNullOrEmpty(tbTime.Text.Trim()) Then
                Return tbTime.Text.Trim().PadLeft(4, "0")
            End If
            Return tbTime.Text.Trim()
        End Get
        Set(ByVal value As String)
            tbTime.Text = value
        End Set
    End Property

    Public Property Text_Enabled() As Boolean
        Get
            Return tbDate.Enabled
        End Get
        Set(ByVal value As Boolean)
            tbDate.Enabled = value
        End Set
    End Property

    Public Property Time_Enabled() As Boolean
        Get
            Return tbTime.Enabled
        End Get
        Set(ByVal value As Boolean)
            tbTime.Enabled = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        imgDates.Attributes.Add("onmouseover", "this.style.cursor='hand'")
        imgDateS.Attributes.Add("onclick", "displayDatePicker('" & tbDate.ClientID & "');return false;")

        tbDate.Attributes.Add("onchange", "checkDate(this.id); if('function' == typeof(chgUcDate)){chgUcDate(this.id);}")
        tbTime.Attributes.Add("onchange", "checkTime(this.id)")

        If IsPostBack Then
            Return
        End If

    End Sub
End Class
