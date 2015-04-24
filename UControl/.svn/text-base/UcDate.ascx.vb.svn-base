Imports FSCPLM.Logic

Partial Class UControl_UcDate
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Enabled() As Boolean
        Get
            Return tbDate.Enabled
        End Get
        Set(value As Boolean)
            tbDate.Enabled = value
        End Set
    End Property
    Public Property Text() As String
        Get
            If Not String.IsNullOrEmpty(tbDate.Text) Then
                Return tbDate.Text.Trim().PadLeft(7, "0").Replace("/", "")
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)
            If value.Length = 7 Then
                tbDate.Text = DateTimeInfo.ToDisplay(value)
            Else
                tbDate.Text = value
            End If
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbDate.Attributes.Add("onchange", "checkDate(this.id,this.value);")
        imgDate.Attributes.Add("onmouseover", "this.style.cursor='hand'")
        imgDate.Attributes.Add("onclick", "displayDatePicker('" & tbDate.ClientID & "');return false;")
        tbDate.Attributes.Add("onchange", "checkDate(this.id); if('function' == typeof(chgUcDate)){chgUcDate(this.id);} ")

        If IsPostBack Then Return
    End Sub
End Class
