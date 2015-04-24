
Partial Class UControl_UcOldMember
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Username() As String
        Get
            Return Me.lbMemberName.Text
        End Get
        Set(ByVal value As String)
            Me.lbMemberName.Text = value
        End Set
    End Property

    Public Property PersonnelId() As String
        Get
            Return Me.tbPersonnelId.Text
        End Get
        Set(ByVal value As String)
            Me.tbPersonnelId.Text = value
        End Set
    End Property

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub tbIdcard_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbPersonnelId.TextChanged
        If Not String.IsNullOrEmpty(PersonnelId) Then
            Username = New FSCPLM.Logic.OldMember().GetColumnByPersonnelId("User_name", PersonnelId)
        Else
            Username = ""
        End If
    End Sub

End Class
