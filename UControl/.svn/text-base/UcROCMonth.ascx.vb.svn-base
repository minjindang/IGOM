
Partial Class UControl_UcROCMonth
    Inherits System.Web.UI.UserControl


#Region "Property"
    'Public Property Enabled() As Boolean
    '    Get
    '        Return panel.Enabled
    '    End Get
    '    Set(value As Boolean)
    '        panel.Enabled = value
    '    End Set
    'End Property

    Public Property Month() As Integer
        Get
            If String.IsNullOrEmpty(ddlMonth.SelectedValue) Then
                Return "01"
            End If
            Return ddlMonth.SelectedValue
        End Get
        Set(ByVal value As Integer)
            'ddlMonth.SelectedValue = value
            hf_Month.Value = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim monthList As New ArrayList
            For index As Integer = 1 To 12
                monthList.Add(New ListItem(index.ToString().PadLeft(2, "0"), index))
            Next

            ddlMonth.DataSource = monthList
            ddlMonth.DataBind()

            If Not String.IsNullOrEmpty(hf_Month.Value) Then
                ddlMonth.SelectedValue = hf_Month.Value.PadLeft(2, "0")
            Else
                ddlMonth.SelectedValue = Now.Month
            End If

        End If
    End Sub

End Class
