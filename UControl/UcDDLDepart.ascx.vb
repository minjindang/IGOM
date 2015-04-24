Imports System.Data

Partial Class UControl_UcDDLDepart
    Inherits System.Web.UI.UserControl
    Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    Private org As New FSC.Logic.Org()

    Public Property Enabled() As Boolean
        Get
            Return ddlDepart.Enabled
        End Get
        Set(ByVal value As Boolean)
            ddlDepart.Enabled = value
            ddlSubDepart.Enabled = value
        End Set
    End Property

    Public Property Sub_Visible() As Boolean
        Get
            Return ddlSubDepart.Visible
        End Get
        Set(ByVal value As Boolean)
            ddlSubDepart.Visible = value
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
            BindDepart()
            BindSubDepart()
        End Set
    End Property

    Public Property SelectedValue() As String
        Get
            If String.IsNullOrEmpty(ddlSubDepart.SelectedValue) Then
                Return ddlDepart.SelectedValue
            End If
            Return ddlSubDepart.SelectedValue
        End Get
        Set(ByVal value As String)
            Try
                'Dim dt As DataTable = ddlDepart.DataSource
                'Dim drAry() As DataRow = dt.Select(String.Format(" Depart_id = '{0}' ", value))
                'If Not drAry Is Nothing AndAlso drAry.Length > 0 Then
                '    ddlDepart.SelectedValue = value
                '    BindSubDepart()
                'Else


                '    drAry = dt.Select(String.Format(" Parent_depart_id = '{0}' ", ddlDepart.SelectedValue))
                '    BindSubDepart()
                '    dt = ddlSubDepart.DataSource
                '    drAry = dt.Select(String.Format(" Depart_id = '{0}' ", value))
                '    If Not drAry Is Nothing AndAlso drAry.Length > 0 Then
                '        ddlSubDepart.SelectedValue = value
                '    End If
                'End If
                Dim dr As DataRow = org.GetDataByDepartid(Orgcode, value)
                If String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Parent_depart_id")) Then
                    ddlDepart.SelectedValue = value
                    BindSubDepart()
                Else
                    ddlDepart.SelectedValue = CommonFun.SetDataRow(dr, "Parent_depart_id")
                    BindSubDepart()
                    ddlSubDepart.SelectedValue = value
                End If

            Catch ex As Exception

            End Try
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As ListItem
        Get
            If String.IsNullOrEmpty(ddlSubDepart.SelectedValue) Then
                Return ddlDepart.SelectedItem
            End If
            Return ddlSubDepart.SelectedItem
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If


    End Sub

    Protected Sub BindDepart()
        Dim dt As DataTable = org.GetDataByParentDepartid(orgcode, "")
        ddlDepart.DataSource = dt
        ddlDepart.DataBind()
        ddlDepart.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub BindSubDepart()
        Dim dt As New DataTable
        If Not String.IsNullOrEmpty(ddlDepart.SelectedValue) Then
            dt = org.GetDataByParentDepartid(Orgcode, ddlDepart.SelectedValue)
        End If
        ddlSubDepart.DataSource = dt
        ddlSubDepart.DataBind()
        ddlSubDepart.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepart.SelectedIndexChanged
        BindSubDepart()
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub ddlSubDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubDepart.SelectedIndexChanged
        RaiseEvent SelectedIndexChanged(sender, e)
    End Sub
End Class
