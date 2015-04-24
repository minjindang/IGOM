
Partial Class UControl_UcSelectOrg
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Bindorg()
        End If

    End Sub
#Region "Property"
    Public Property ShowMulti As Boolean
        Get
            Return hfShowMulti.Value
        End Get
        Set(value As Boolean)
            hfShowMulti.Value = value
        End Set
    End Property
    Public Property debug() As Boolean
        Get
            Return lblorgs.Visible
        End Get
        Set(value As Boolean)
            lblorgs.Visible = value
        End Set
    End Property
    Public ReadOnly Property OrgCode() As String
        Get
            Dim rv As String = ""
            Select Case ddlorg.SelectedValue
                Case "00"
                    rv = "ALL"
                Case "Multi"
                    rv = getOrgs()
                Case Else
                    rv = ddlorg.SelectedValue
            End Select


            Return rv
        End Get
    End Property

    'Public Property ParentId() As Integer
    Public Property ParentId() As String
        Get
            Dim rv As String = ""
            If Not String.IsNullOrEmpty(hfParentOrgid.Value) Then
                'rv = Integer.Parse(hfParentOrgid.Value)
                rv = hfParentOrgid.Value
            End If
            Return rv
        End Get
        'Set(ByVal value As Integer)
        Set(ByVal value As String)
            hfParentOrgid.Value = value
        End Set
    End Property


#End Region


    Protected Sub Bindorg()
        Dim fdao As New FSCPLM.Logic.FSCorg1DAO
        ddlorg.DataTextField = "Depart_name"
        ddlorg.DataValueField = "Depart_code"

        ddlorg.DataSource = fdao.GetDataByParentid(ParentId)
        ddlorg.DataBind()
        Dim li As New ListItem("全部", "ALL")
        ddlorg.Items.Insert(0, li)
        If (ShowMulti) Then
            Dim li2 As New ListItem("複選單位", "Multi")
            ddlorg.Items.Insert(1, li2)
        End If
        
    End Sub

    Protected Function getOrgs() As String
        Dim rv As String = ""

        For Each li As ListItem In cblorg.Items
            If li.Selected Then
                If rv <> "" Then
                    rv &= ","
                End If
                rv &= li.Value '& ","
            End If
        Next
        Return rv
    End Function


    Protected Sub ddlorg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlorg.SelectedIndexChanged
        If ddlorg.SelectedValue = "Multi" Then
            cblorg.Visible = True
            BindCblOrg()
        Else
            cblorg.Visible = False
        End If
    End Sub

    Protected Sub BindCblOrg()
        Dim fdao As New FSCPLM.Logic.FSCorg1DAO
        cblorg.DataTextField = "Depart_name"
        cblorg.DataValueField = "Depart_code"

        cblorg.DataSource = fdao.GetDataByParentid(ParentId)
        cblorg.DataBind()

    End Sub

    Protected Sub cblorg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cblorg.SelectedIndexChanged
        lblorgs.Text &= getOrgs()
    End Sub

    Public Sub Rebind()
        Bindorg()
    End Sub
End Class
