
Partial Class UControl_UcMember
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
    Public Property DepartName() As String
        Get
            Return Me.lbDepartName.Text
        End Get
        Set(ByVal value As String)
            Me.lbDepartName.Text = value
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
            Username = New FSC.Logic.Personnel().GetColumnValue("User_name", PersonnelId)
            Dim dt As System.Data.DataTable = New FSC.Logic.DepartEmp().GetDataByIdcard(PersonnelId)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                DepartName = New FSC.Logic.Org().GetDepartName(dt.Rows(0)("Orgcode").ToString(), dt.Rows(0)("Depart_id").ToString())
            End If
        Else
            Username = ""
            DepartName = ""
        End If
    End Sub

End Class
