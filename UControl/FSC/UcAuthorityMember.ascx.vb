
Partial Class UControl_UcAuthorityMember
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
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Role_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId)
        Dim Boss_Level_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Boss_Level_id)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        If Me.tbPersonnelId.Text.Length > 6 Then
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.Custom, "「員工編號不能超過6碼」")
            Return
        End If
        If Not String.IsNullOrEmpty(PersonnelId) Then
            If Role_id.IndexOf("Personnel") >= 0 OrElse Role_id.IndexOf("OrgHead") >= 0 OrElse Boss_Level_id = "1" Then
                Username = New FSC.Logic.Personnel().GetColumnValue("User_name", PersonnelId)
                Dim dt As System.Data.DataTable = New FSC.Logic.DepartEmp().GetDataByIdcard(PersonnelId)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    DepartName = New FSC.Logic.Org().GetDepartName(dt.Rows(0)("Orgcode").ToString(), dt.Rows(0)("Depart_id").ToString())
                End If
            ElseIf Role_id.IndexOf("DeptHead") >= 0 OrElse Boss_Level_id = "2" Then
                Dim dt As System.Data.DataTable = New FSC.Logic.Personnel().GetDataByQuery(Orgcode, Depart_id.Substring(0, 2), "", PersonnelId)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Username = dt.Rows(0)("User_name").ToString()
                    DepartName = New FSC.Logic.Org().GetDepartName(Orgcode, dt.Rows(0)("Depart_id").ToString())
                End If
            ElseIf Role_id.IndexOf("Master") >= 0 OrElse Boss_Level_id = "3" Then
                Dim dt As System.Data.DataTable = New FSC.Logic.Personnel().GetDataByQuery(Orgcode, Depart_id, "", PersonnelId)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    Username = dt.Rows(0)("User_name").ToString()
                    DepartName = New FSC.Logic.Org().GetDepartName(Orgcode, dt.Rows(0)("Depart_id").ToString())
                End If
            ElseIf Role_id.IndexOf("Secretariat") >= 0 Then
                Dim dt As System.Data.DataTable = New FSC.Logic.Personnel().GetDataByQuery(Orgcode, Depart_id, "", PersonnelId)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    If dt.Rows(0)("Employee_type").ToString() = "3" OrElse dt.Rows(0)("Employee_type").ToString() = "8" Then
                        Username = dt.Rows(0)("User_name").ToString()
                        DepartName = New FSC.Logic.Org().GetDepartName(Orgcode, dt.Rows(0)("Depart_id").ToString())
                    Else
                        Username = ""
                        DepartName = ""
                    End If
                End If
            Else
                Dim Id_card As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                If PersonnelId.ToLower = Id_card.ToLower Then
                    Username = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    DepartName = New FSC.Logic.Org().GetDepartName(Orgcode, Depart_id)
                Else
                    Username = ""
                    DepartName = ""
                End If
            End If
        Else
            Username = ""
            DepartName = ""
        End If
    End Sub

End Class
