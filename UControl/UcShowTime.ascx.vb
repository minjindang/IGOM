
Partial Class UControl_UcShowTime
    Inherits System.Web.UI.UserControl

    Private _Text As String

    Property Text() As String
        Get
            Return _Text
        End Get
        Set(value As String)
            _Text = value
            lbTime.Text = FSCPLM.Logic.DateTimeInfo.ToDisplayTime(_Text)
        End Set
    End Property
End Class
