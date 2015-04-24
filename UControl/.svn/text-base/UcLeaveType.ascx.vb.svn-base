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
            Return _flow_id
        End Get
        Set(ByVal value As String)
            _flow_id = value
            If Leave_type = 51 OrElse Leave_type = 52 Then
                lbLeave_name.Attributes.Add("onclick", "javascript:window.open('../../MAT/MAT1/MAT1103_01.aspx?flow_id=" & Me.Flow_id & "&org=" & Me.Orgcode & "','','height=550px,Width=600px,menubar=no,scrollbars=yes,resizable=yes,location=no,toolbar=no;');")
            Else
                lbLeave_name.Attributes.Add("onclick", "javascript:window.open('../../FSC1/FSC11/FSC1101_09.aspx?fid=" & Me.Flow_id & "&org=" & Me.Orgcode & "','','height=550px,Width=600px,menubar=no,scrollbars=yes,resizable=yes,location=no,toolbar=no;');")
                'lbLeave_name.Attributes.Add("onclick", "javascript:window.showModalDialog('../../FSC1/FSC11/FSC1101_09.aspx?fid=" & Me.Flow_id & "&org=" & Me.Orgcode & "','','dialogHeight:550px; dialogWidth:600px;')")

            End If

        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return _Orgcode
        End Get
        Set(ByVal value As String)
            _Orgcode = value
        End Set
    End Property

    Public Property Leave_group() As String
        Get
            Return _Leave_group
        End Get
        Set(ByVal value As String)
            _Leave_group = value
            If value = "B" And Me.Leave_type <> "85" Then lbLeave_name.Text = "出國請假"
        End Set
    End Property

    Public Property Leave_type() As Integer
        Get
            Return _Leave_type
        End Get
        Set(ByVal value As Integer)
            _Leave_type = value
            If Leave_type = 51 OrElse Leave_type = 52 Then
                lbLeave_name.Attributes.Add("onclick", "javascript:window.open('../../MAT/MAT1/MAT1103_01.aspx?flow_id=" & Me.Flow_id & "&org=" & Me.Orgcode & "','','height=550px,Width=600px,menubar=no,scrollbars=yes,resizable=yes,location=no,toolbar=no;');")
            Else
                lbLeave_name.Attributes.Add("onclick", "javascript:window.open('../../FSC1/FSC11/FSC1101_09.aspx?fid=" & Me.Flow_id & "&org=" & Me.Orgcode & "','','height=550px,Width=600px,menubar=no,scrollbars=yes,resizable=yes,location=no,toolbar=no;');")
                'lbLeave_name.Attributes.Add("onclick", "javascript:window.showModalDialog('../../FSC1/FSC11/FSC1101_09.aspx?fid=" & Me.Flow_id & "&org=" & Me.Orgcode & "','','dialogHeight:550px; dialogWidth:600px;')")

            End If
        End Set
    End Property

    Public Property Leave_name() As String
        Get
            Return lbLeave_name.Text
        End Get
        Set(ByVal value As String)
            lbLeave_name.Text = value
            If Me.Leave_group = "B" And Me.Leave_type <> "85" Then lbLeave_name.Text = "出國請假"
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbLeave_name.Attributes.Add("onmouseover", "this.style.cursor='hand'")
    End Sub

End Class
