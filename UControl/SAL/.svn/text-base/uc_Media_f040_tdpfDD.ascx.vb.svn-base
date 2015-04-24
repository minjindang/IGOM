
Partial Class uc_uc_Media_f040_tdpfDD
    Inherits System.Web.UI.UserControl

#Region "Property"

    Public Property v_orgid() As String
        Get
            Return Me.TextBox_orgid.text
        End Get
        Set(ByVal value As String)
            Me.TextBox_orgid.Text = value
        End Set
    End Property

    Public Property v_selected() As String
        Get
            Return Me.DropDownList_tdpf.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.TextBox_selected.Text = value
        End Set
    End Property

#End Region

    Protected Sub DropDownList_tdpf_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_tdpf.DataBound
        Dim li As New ListItem("未設定", "")
        Me.DropDownList_tdpf.Items.Insert(0, li)

        Dim selected As String = Me.TextBox_selected.Text

        If selected <> "" Then
            For Each li2 As ListItem In Me.DropDownList_tdpf.Items
                If selected = li2.Value Then
                    li2.Selected = True
                    Me.TextBox_selected.Text = ""
                End If
            Next
        End If

    End Sub

#Region " SeqnoChanged"
    Protected Sub DropDownList_tdpf_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_tdpf.SelectedIndexChanged
        RaiseEvent SeqnoChanged(Me, e)
    End Sub
#End Region

#Region " Event"
    Public Event SeqnoChanged(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

End Class
