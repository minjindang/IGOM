Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_UcUsePDF
    Inherits System.Web.UI.UserControl

#Region "Property"
    Private _UrlName As String
    Public Property UrlName() As String
        Get
            Return _UrlName
        End Get
        Set(ByVal value As String)
            If Split(value, "_").Length > 1 Then
                _UrlName = Split(value, "_")(0)
            Else
                _UrlName = value
            End If

            'Button1.Attributes.Add("onclick", "window.open('../../OnlineHelp/" & UrlName & ".pdf','','width=800px,height=600px')")
            Button1.Attributes.Add("onclick", "window.open('../../user_guide.doc','','width=800px,height=600px')")
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Button1.Attributes.Add("onmouseover", "this.style.cursor='hand'")
    End Sub


End Class
