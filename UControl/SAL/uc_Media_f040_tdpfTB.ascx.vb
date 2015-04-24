
Partial Class uc_uc_Media_f040_tdpfTB
    Inherits System.Web.UI.UserControl

    Protected Sub GetText()

        Dim bankno As String = ""
        Dim medi As String = ""

        Using ta As New dt_SaTdpf_TableAdapters.SATDPF_TableAdapter
            Using t As dt_SaTdpf_.SATDPF_DataTable = ta.GetDataBySeqno(v_seqno)
                If t.Rows.Count > 0 Then
                    bankno = t(0)("tdpf_bank_no").ToString
                    medi = t(0)("tdpf_medi").ToString
                End If
            End Using
        End Using

        Me.TextBox_bankno.Text = bankno
        Me.TextBox_medi.Text = medi

        If medi <> "" Then
            Me.div_medi.Visible = True
        Else
            Me.div_medi.Visible = False
        End If

    End Sub

#Region " Property"

    Public Property v_seqno() As String
        Get
            Return Me.TextBox_Seqno.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_Seqno.Text = value

            Me.GetText()
        End Set
    End Property

#End Region

End Class
