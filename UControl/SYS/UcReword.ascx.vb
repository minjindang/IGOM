
Partial Class UControl_SYS_UcReword
    Inherits System.Web.UI.UserControl
    Public Event Click(ByVal sender As Object, ByVal e As System.EventArgs)

#Region "property"
    Public Property Council_name() As String
        Get
            Return tbCouncil_name.Text.Trim
        End Get
        Set(ByVal value As String)
            tbCouncil_name.Text = value
        End Set
    End Property
    Public Property Council_date() As String
        Get
            Return UcCouncil_date.Text
        End Get
        Set(ByVal value As String)
            UcCouncil_date.Text = value
        End Set
    End Property
    Public Property Council_approve() As String
        Get
            Return ddlCouncil_approve.SelectedValue
        End Get
        Set(ByVal value As String)
            ddlCouncil_approve.SelectedValue = value
        End Set
    End Property
    Public Property Reword_date() As String
        Get
            Return UcReword_date.Text
        End Get
        Set(ByVal value As String)
            UcReword_date.Text = value
        End Set
    End Property
    Public Property Reword_Doc() As String
        Get
            Return tbReword_Doc.Text.Trim
        End Get
        Set(ByVal value As String)
            tbReword_Doc.Text = value
        End Set
    End Property
#End Region
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then Return

    End Sub

    Protected Sub cbReword_Click(sender As Object, e As EventArgs)
        btnQuery_ModalPopupExtender.Show()
    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs) Handles cbConfirm.Click
        btnQuery_ModalPopupExtender.Hide()
        
        RaiseEvent Click(sender, e)
    End Sub

    Protected Sub cbCancel_Click(sender As Object, e As EventArgs) Handles cbCancel.Click
        btnQuery_ModalPopupExtender.Hide()
    End Sub

End Class
