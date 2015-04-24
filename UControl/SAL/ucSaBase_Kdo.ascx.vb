
Partial Class uc_ucSaBase_Kdo
    Inherits System.Web.UI.UserControl

    Protected Sub chk_Changed(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim gvr As GridViewRow

        For Each gvr In Me.GridView_pitm.Rows

            Dim v_chk As Boolean = CType(gvr.FindControl("CheckBox_chk"), CheckBox).Checked

            CType(gvr.FindControl("UcSaSpesup_pitm_amt"), uc_ucSaSpesup).Visible = v_chk

        Next

    End Sub

    Protected Function chk_Checked(ByVal value) As Boolean
        Dim rv As Boolean = False
        Try
            If Not IsDBNull(CStr(value)) Then
                rv = True
            End If
        Catch ex As Exception

        End Try
        Return rv
    End Function


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

    Public Property v_Kdo_Str() As String
        Get

            Dim rv As String = ""
            ''rv = [code_sys1, code_kind1, code_type1, code_no1, code1][code_sys2, code_kind2, code_type2, code_no2, code2]
            Dim rvs As String = ""

            For Each gvr As GridViewRow In Me.GridView_pitm.Rows

                Dim chk As Boolean = CType(gvr.FindControl("CheckBox_chk"), CheckBox).Checked

                If chk Then

                    Dim code_sys As String = CType(gvr.FindControl("TextBox_code_sys"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_kind As String = CType(gvr.FindControl("TextBox_code_kind"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_type As String = CType(gvr.FindControl("TextBox_code_type"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_no As String = CType(gvr.FindControl("TextBox_code_no"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code As String = CType(gvr.FindControl("UcSaSpesup_pitm_amt"), uc_ucSaSpesup).v_Series

                    rvs = "[" & code_sys & ", " & _
                                code_kind & ", " & _
                                code_type & ", " & _
                                code_no & ", " & _
                                code & _
                          "]"

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
