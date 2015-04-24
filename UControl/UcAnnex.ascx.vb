Imports FSCPLM.Logic
Imports System.Data

Partial Class UControl_UcAnnex
    Inherits System.Web.UI.UserControl

#Region "Property"
    Private _Flow_id As String
    Public Property Flow_id() As String
        Get
            Return _Flow_id
        End Get
        Set(ByVal value As String)
            _Flow_id = value

            Dim dt As DataTable = New FSCPLM.Logic.Attachement().GetAttachByFlow_id(value)
            If dt.Rows.Count <= 0 Then
                lbLook.Visible = False
            Else
                lbLook.Visible = True
                lbLook.Attributes.Add("onclick", "window.open('FSC1101_10.aspx?fid=" & Flow_id & "','_blank','width=300px,height=250px,resizable=yes,scrollbars=yes,toolbar=false,menubar=false')")
            End If
        End Set
    End Property
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lbLook.Attributes.Add("onmouseover", "this.style.cursor='hand'")
    End Sub

  
End Class
