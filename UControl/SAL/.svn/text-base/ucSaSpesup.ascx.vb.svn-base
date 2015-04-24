
Partial Class uc_ucSaSpesup
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.TextBox_ym.Text = Now.ToString("yyyyMM")

    End Sub

#Region "property"

    Public Property v_Type() As String
        Get
            Return Me.TextBox_type.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_type.Text = value
        End Set
    End Property

    Public Property v_No() As String
        Get
            Return Me.TextBox_no.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_no.Text = value
        End Set
    End Property

    Public Property v_Ym() As String
        Get
            Return Me.TextBox_ym.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_ym.Text = value
        End Set
    End Property

    Public Property v_Series() As String
        Get
            Return Me.DropDownList_series.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.TextBox_selected.Text = value
            Try
                For i As Integer = 0 To Me.DropDownList_series.Items.Count - 1
                    If Me.DropDownList_series.Items(i).Value = value Then
                        Me.DropDownList_series.ClearSelection()
                        Me.DropDownList_series.Items(i).Selected = True
                    End If
                    Me.TextBox_selected.Text = ""
                Next
            Catch ex As Exception

            End Try
        End Set
    End Property

    Public Property bind() As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.DropDownList_series.DataBind()
            End If
        End Set
    End Property
    Public ReadOnly Property DDL() As DropDownList
        Get
            Return Me.DropDownList_series
        End Get
    End Property
#End Region

    Protected Sub DropDownList_series_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_series.DataBound

        If Me.TextBox_selected.Text <> "" Then
            For i As Integer = 0 To Me.DropDownList_series.Items.Count - 1
                If Me.DropDownList_series.Items(i).Value = Me.TextBox_selected.Text Then
                    Me.DropDownList_series.ClearSelection()
                    Me.DropDownList_series.Items(i).Selected = True
                    Me.TextBox_selected.Text = ""
                End If
            Next

        End If
    End Sub
End Class
