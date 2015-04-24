
Partial Class UControl_UcROCYearMonth
    Inherits System.Web.UI.UserControl


#Region "Property"
    Public Property Enabled() As Boolean
        Get
            Return panel.Enabled
        End Get
        Set(value As Boolean)
            panel.Enabled = value
        End Set
    End Property
    
    Public ReadOnly Property Year() As Integer
        Get
            Return (ROCYear() + 1911).ToString().PadLeft(3, "0")
        End Get
    End Property

    Public Property ROCYear() As String
        Get
            Return ddlYear.SelectedValue
        End Get
        Set(ByVal value As String)
            'ddlYear.SelectedValue = value
            hf_Year.Value = value
        End Set
    End Property

    Public Property Month() As String
        Get
            If String.IsNullOrEmpty(ddlMonth.SelectedValue) Then
                Return "01"
            End If
            Return ddlMonth.SelectedValue
        End Get
        Set(ByVal value As String)
            'ddlMonth.SelectedValue = value
            hf_Month.Value = value
        End Set
    End Property

    Public ReadOnly Property YearMonth() As String
        Get
            Return Year() + Month().ToString().PadLeft(2, "0")
        End Get
    End Property

    Public ReadOnly Property ROCYearMonth() As String
        Get
            Return ROCYear() + Month().ToString().PadLeft(2, "0")
        End Get 
    End Property 


#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim monthList As New ArrayList
            For index = 1 To 12
                monthList.Add(New ListItem(index.ToString().PadLeft(2, "0"), index))
            Next

            ddlMonth.DataSource = monthList
            ddlMonth.DataBind()
            If Not String.IsNullOrEmpty(hf_Month.Value) Then
                ddlMonth.SelectedValue = hf_Month.Value.PadLeft(2, "0")
            Else
                ddlMonth.SelectedValue = Now.Month.ToString().PadLeft(2, "0")
            End If 

            Dim yearList As New ArrayList
            For index = Now.Year - 1911 + 2 To 50 Step -1
                yearList.Add(New ListItem(index.ToString().PadLeft(3, "0"), index))
            Next

            ddlYear.DataSource = yearList
            ddlYear.DataBind()

            If Not String.IsNullOrEmpty(hf_Year.Value) Then
                ddlYear.SelectedValue = hf_Year.Value
            Else
                ddlYear.SelectedValue = Now.Year - 1911
            End If

        End If
    End Sub

End Class
