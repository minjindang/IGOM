
Partial Class UControl_SYS_UcFormKind
    Inherits System.Web.UI.UserControl

    Public Property FormId() As String
        Get
            Return hfFormId.Value
        End Get
        Set(value As String)
            hfFormId.Value = value
            Dim name As String = ""
            Dim code As New FSCPLM.Logic.SACode()
            If value IsNot Nothing AndAlso "" <> value AndAlso value.Length >= 3 Then
                name = code.GetCodeDesc("024", "**", value.Substring(0, 3))
            End If
            lbFormKind.Text = name
        End Set
    End Property
End Class
