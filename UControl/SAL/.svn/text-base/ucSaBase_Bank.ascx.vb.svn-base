
Partial Class uc_ucSaBase_Bank
    Inherits System.Web.UI.UserControl

#Region "property"

    Public Property v_orgid() As String
        Get
            Return Me.TextBox_orgid.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_orgid.Text = value
        End Set
    End Property

    Public Property v_seqno() As String
        Get
            Return Me.TextBox_seqno.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_seqno.Text = value
        End Set
    End Property

    Public Property v_Bank_Str() As String
        Get

            Dim rv As String = ""
            ''rv = [seq1, bank1][seq2, bank2][seq3, bank3]
            Dim rvs As String = ""

            For Each gvr As GridViewRow In Me.GridView_Bank.Rows

                Dim tdpf_bank As String = CType(gvr.FindControl("TextBox_Tdpf_Bank"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                Dim tdpf_seqno As String = CType(gvr.FindControl("TextBox_Tdpf_Seqno"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                Dim bank_no As String = CType(gvr.FindControl("TextBox_Bank_No"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()

                If bank_no <> "" Then

                    rvs = "[" & tdpf_seqno & ", " & bank_no & ", " & tdpf_bank & "]"
                    rv &= rvs

                End If

            Next

            Return rv

        End Get
        Set(ByVal value As String)

        End Set
    End Property


#End Region

End Class
