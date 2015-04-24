
Partial Class uc_uc_SaParameter_List
    Inherits System.Web.UI.UserControl


#Region " Property "

    Public Property v_code_sys() As String
        Get
            Return Me.TextBox_code_sys.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_sys.Text = value
            Me.get_ym()
        End Set
    End Property

    Public Property v_code_kind() As String
        Get
            Return Me.TextBox_code_kind.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_kind.Text = value
            Me.get_ym()
        End Set
    End Property

    Public Property v_code_type() As String
        Get
            Return Me.TextBox_code_type.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_type.Text = value
            Me.get_ym()
        End Set
    End Property

    Public Property v_code_no() As String
        Get
            Return Me.TextBox_code_no.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_code_no.Text = value
            Me.get_ym()
        End Set
    End Property

    Public ReadOnly Property v_ym() As String
        Get
            Return Me.DropDownList_ym.SelectedValue
        End Get
    End Property

#End Region

#Region " YM "

    Protected Sub DropDownList_ym_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_ym.DataBound
        Me.get_parameter()
    End Sub

    Protected Sub DropDownList_ym_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList_ym.SelectedIndexChanged
        Me.get_parameter()
    End Sub


    Protected Sub get_ym()

        Dim sql As String = ""

        sql = " select parameter_ym "
        sql &= " , (cast(cast(substring(parameter_ym,1,4) as int) - 1911 as varchar) + ' 年 ' + substring(parameter_ym,5,2) + ' 月') as ymstr"
        sql &= " from sal_saparameter "
        sql &= " where parameter_code_sys = '" & v_code_sys & "' "
        sql &= " and parameter_code_kind  = '" & v_code_kind & "' "
        sql &= " and parameter_code_type  = '" & v_code_type & "' "
        sql &= " and parameter_code_no    = '" & v_code_no & "' "
        sql &= " group by parameter_ym "
        sql &= " order by parameter_ym desc "

        Me.TextBox_ym.Text = sql
        Me.DropDownList_ym.DataBind()

    End Sub

    Protected Sub get_parameter()

        Dim sql As String = ""
        Dim v_value As String = ""

        sql &= " select parameter_value "
        sql &= " from sal_saparameter "
        sql &= " where parameter_code_sys = '" & v_code_sys & "' "
        sql &= " and parameter_code_kind  = '" & v_code_kind & "' "
        sql &= " and parameter_code_type  = '" & v_code_type & "' "
        sql &= " and parameter_code_no    = '" & v_code_no & "' "
        sql &= " and parameter_ym         = '" & v_ym & "' "

        Using ta As New DB_TableAdapters.DB_TableAdapter
            Using t As DB_.DB_DataTable = ta.spExeSQLGetDataTable(sql)
                If t.Rows.Count > 0 Then
                    v_value = t(0)("parameter_value").ToString

                    If v_value = "" Then
                        v_value = "未設定"
                    End If

                    Me.Label_value.Text = v_value
                Else
                    Me.Label_value.Text = "未輸入"
                End If
            End Using
        End Using

    End Sub

#End Region

End Class
