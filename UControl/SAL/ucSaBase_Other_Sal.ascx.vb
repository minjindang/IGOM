
Partial Class uc_ucSaBase_Other_Sal
    Inherits System.Web.UI.UserControl


    Protected Function chk_Checked(ByVal value) As Boolean
        Dim rv As Boolean = False
        Try
            If Not IsDBNull(value) Then
                rv = True
            End If
        Catch ex As Exception

        End Try
        Return rv
    End Function

    Protected Function show_acc_no(ByVal code_sys, ByVal code_type, ByVal code_no) As Boolean
        Dim rv As Boolean = False

        'If code_sys = "005" And code_type = "002" And code_no = "003" Then
        '    rv = True
        'End If

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

    Public Property v_Other_Sal_Str() As String
        Get

            Dim rv As String = ""
            ''rv = [code_sys1, code_kind1, code_type1, code_no1, code1, amt1 , acc_no1][code_sys2, code_kind2, code_type2, code_no2, code2, amt2 , acc_no2]
            Dim rvs As String = ""

            '' 加項
            For Each gvr As GridViewRow In Me.GridView_Other_1.Rows

                Dim chk As Boolean = CType(gvr.FindControl("CheckBox_chk"), CheckBox).Checked

                If chk Then

                    Dim code_sys As String = CType(gvr.FindControl("TextBox_code_sys"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_kind As String = CType(gvr.FindControl("TextBox_code_kind"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_type As String = CType(gvr.FindControl("TextBox_code_type"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_no As String = CType(gvr.FindControl("TextBox_code_no"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code As String = CType(gvr.FindControl("TextBox_code"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim pitm_amt As String = CType(gvr.FindControl("TextBox_pitm_amt"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim acc_no As String = ""

                    rvs = "[" & code_sys & ", " & _
                                code_kind & ", " & _
                                code_type & ", " & _
                                code_no & ", " & _
                                code & ", " & _
                                pitm_amt & ", " & _
                                acc_no & _
                          "]"

                    rv &= rvs
                End If
            Next

            '' 扣項
            For Each gvr As GridViewRow In Me.GridView_Other_2.Rows

                Dim chk As Boolean = CType(gvr.FindControl("CheckBox_chk"), CheckBox).Checked

                If chk Then

                    Dim code_sys As String = CType(gvr.FindControl("TextBox_code_sys"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_kind As String = CType(gvr.FindControl("TextBox_code_kind"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_type As String = CType(gvr.FindControl("TextBox_code_type"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code_no As String = CType(gvr.FindControl("TextBox_code_no"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim code As String = CType(gvr.FindControl("TextBox_code"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim pitm_amt As String = CType(gvr.FindControl("TextBox_pitm_amt"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()
                    Dim acc_no As String = CType(gvr.FindControl("TextBox_acc_accno"), TextBox).Text.Replace("[", "").Replace("]", "").Replace(",", "").Trim()

                    rvs = "[" & code_sys & ", " & _
                                code_kind & ", " & _
                                code_type & ", " & _
                                code_no & ", " & _
                                code & ", " & _
                                pitm_amt & ", " & _
                                acc_no & _
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
