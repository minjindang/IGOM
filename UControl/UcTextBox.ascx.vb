
Partial Class UControl_UcTextBox
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Width() As Integer
        Get
            Return tb.Width.Value
        End Get
        Set(ByVal value As Integer)
            tb.Width = value
        End Set
    End Property
    Public Property Height() As Integer
        Get
            Return tb.Height.Value
        End Get
        Set(ByVal value As Integer)
            tb.Height = value
        End Set
    End Property

    Public Property TextMode() As TextBoxMode
        Get
            Return tb.TextMode
        End Get
        Set(ByVal value As TextBoxMode)
            tb.TextMode = value
        End Set
    End Property

    Private _MaxLength As Integer = 0
    Public Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return tb.Text.Trim()
        End Get
        Set(ByVal value As String)
            tb.Text = value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return tb.Enabled
        End Get
        Set(value As Boolean)
            tb.Enabled = value
        End Set
    End Property
#End Region

End Class
