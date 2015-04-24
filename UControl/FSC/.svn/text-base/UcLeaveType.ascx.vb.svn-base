Imports FSCPLM.Logic

Partial Class UControl_UcLeaveType
    Inherits System.Web.UI.UserControl

#Region "Property"
    Private _flow_id As String
    Private _Leave_type As Integer
    Private _Leave_group As String
    Private _Orgcode As String

    Public Property Flow_id() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(ByVal value As String)
            hfFlowId.Value = value
         End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
        End Set
    End Property

    Public Property Leave_type() As Integer
        Get
            Return _Leave_type
        End Get
        Set(ByVal value As Integer)
            _Leave_type = value
        End Set
    End Property

    Public Property Leave_name() As String
        Get
            Return lbLeave_name.Text
        End Get
        Set(ByVal value As String)
            lbLeave_name.Text = value
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbLeave_name.Attributes.Add("onmouseover", "this.style.cursor='hand'")
        lbLeave_name.Attributes.Add("onclick", "javascript:window.open('../../FSC/FSC0/FSC0101_03.aspx?fid=" & hfFlowId.Value & "&org=" & hfOrgcode.Value & "','','height=550px,Width=600px,menubar=no,scrollbars=yes,resizable=yes,location=no,toolbar=no;');")

    End Sub

End Class
