
Partial Class UControl_UcROCYear
    Inherits System.Web.UI.UserControl
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

#Region "Property"
    Public Property Enabled() As Boolean
        Get
            Return Panel.Enabled
        End Get
        Set(value As Boolean)
            Panel.Enabled = value
        End Set
    End Property

    'Public ReadOnly Property ROCYear() As Integer
    '    Get
    '        Return (Year() - 1911).ToString().PadLeft(3, "0")
    '    End Get
    'End Property

    Public Property Year() As Integer
        Get
            If ddlYear.SelectedValue = "請選擇" Then
                Return 0
            Else
                Return CommonFun.getInt(ddlYear.SelectedValue)
            End If


        End Get
        Set(ByVal value As Integer)
            BindDDL()
            hfYear.Value = value - 1911
            'ddlYear.SelectedValue = value 'FSC0101_28對此行是正確的
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindDDL()
        End If
    End Sub

    Protected Sub BindDDL()

        Dim yearList As New ArrayList
        For index As Integer = Now.Year - 1911 + 2 To 50 Step -1
            yearList.Add(New ListItem(index.ToString().PadLeft(3, "0"), index))
        Next
        yearList.Insert(0, New ListItem("請選擇", ""))
        ddlYear.DataSource = yearList
        ddlYear.DataBind()

        If Not String.IsNullOrEmpty(hfYear.Value) Then
            ddlYear.SelectedValue = hfYear.Value
        Else
            ddlYear.SelectedValue = Now.Year - 1911
        End If
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
End Class
