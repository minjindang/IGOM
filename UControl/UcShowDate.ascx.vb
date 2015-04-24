
Partial Class UControl_UcShowDate
    Inherits System.Web.UI.UserControl

    Private _Text As String

    Property Text() As String
        Get
            Return lbDate.Text.Replace("/", "")
        End Get
        Set(value As String)
            _Text = value
            lbDate.Text = FSCPLM.Logic.DateTimeInfo.ToDisplay(_Text)
        End Set
    End Property

End Class
