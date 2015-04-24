Imports System.Data

Partial Class UControl_UcDDLDepart02
    Inherits System.Web.UI.UserControl
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private org As New FSC.Logic.Org()
    Private _orgcode As String

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
            BindDepart()
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
                Return ddlDepart.SelectedValue
        End Get
        Set(ByVal value As String)
            Try
                Dim dr As DataRow = org.GetDataByDepartid(Orgcode, value)
                If String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Parent_depart_id")) Then
                    ddlDepart.SelectedValue = value
                Else
                    ddlDepart.SelectedValue = CommonFun.SetDataRow(dr, "Parent_depart_id")
                End If

            Catch ex As Exception

            End Try
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
    End Sub

    Protected Sub BindDepart()
        Dim dt As DataTable = org.GetDataByParentDepartid(Orgcode, "")
        ddlDepart.DataSource = dt
        ddlDepart.DataBind()
        ddlDepart.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepart.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

End Class
