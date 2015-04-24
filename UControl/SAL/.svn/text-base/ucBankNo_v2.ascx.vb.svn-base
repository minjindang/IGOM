
Partial Class uc_ucBankNo_v2
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
        End If
    End Sub

    Private Sub __initial_query()
        Me.oBankNoDDL_ObjectDataSource1.SelectParameters("SQLs").DefaultValue = Me.SQLs(Me.v_base_seqno, Me.v_UserOrgId)
    End Sub

    Public Property SelectedValue() As String
        Get
            Return Me.oBankNoDDL.SelectedValue
        End Get
        Set(ByVal value As String)
            For Each li As ListItem In Me.oBankNoDDL.Items
                If li.Value = value Then
                    Me.oBankNoDDL.SelectedValue = value
                End If
            Next
        End Set
    End Property

    Public Property SelectedIndex() As Integer
        Get
            Return Me.oBankNoDDL.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            Me.oBankNoDDL.SelectedIndex = value
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As ListItem
        Get
            Return Me.oBankNoDDL.SelectedItem
        End Get
    End Property

    Public Property v_base_seqno() As String
        Get
            Return Me._base_seqno.Text
        End Get
        Set(ByVal value As String)
            Me._base_seqno.Text = value
        End Set
    End Property

    Public Property v_UserOrgId() As String
        Get
            Return Me._UserOrgId.Text
        End Get
        Set(ByVal value As String)
            Me._UserOrgId.Text = value
            __initial_query()
            Me.BankInit()
        End Set
    End Property

    Public Property v_account_no() As String
        Get
            Return Me.TextBox_account_no.Text
        End Get
        Set(ByVal value As String)
            Me.TextBox_account_no.Text = value
        End Set
    End Property

    'Public Property v_bank_code() As String
    '    Get
    '        Return Me.TextBox_bank_code.Text
    '    End Get
    '    Set(ByVal value As String)
    '        Me.TextBox_bank_code.Text = value
    '    End Set
    'End Property

#Region "    SQLs  "
    Function SQLs(ByVal p_base_seqno As String, ByVal p_UserOrgId As String) As String
        Dim rv As String = _
        "select a.*,b.*," & _
        "  isNull((select top 1 trnfmt_length from sal_satrnfmt" & _
        "  where tdpf_orgid=tdpf_orgid" & _
        "  and trnfmt_bank_codeno=tdpf_bank" & _
        "  and trnfmt_table='SAL_SABANK'" & _
        "  and trnfmt_field='BANK_BANK_NO'" & _
        "  and trnfmt_source_type='001'),0) as trnfmt_length," & _
        "  isNull((select top 1 bank_bank_no from sal_sabank" & _
        "  where bank_orgid=tdpf_orgid" & _
        "  and bank_tdpf_seqno=tdpf_seqno" & _
        "  and bank_seqno='" & p_base_seqno & "'),'') as bank_bank_no" & _
        "  from sys_code a,sal_satdpf b" & _
        "  where code_sys='004'" & _
        "  and code_kind='P'" & _
        "  and code_type='002'" & _
        "  and tdpf_orgid='" & p_UserOrgId & "' " & _
        "  and code_no=tdpf_bank" & _
        "  order by code_no, tdpf_seqno "
        rv = _
        "select " & _
        "    /* a.* , '---' as cc , b.* , */ " & _
        "    code_desc1 + '[' + tdpf_bank_no + ']' as [ccText] , code_no + tdpf_seqno as [ccValue] , " & _
        "    a.code_no , a.code_desc1 , b.tdpf_seqno , b.tdpf_bank_no , " & _
        "    isNull( ( " & _
        "        select top 1 trnfmt_length from sal_satrnfmt " & _
        "        where tdpf_orgid=tdpf_orgid " & _
        "            and trnfmt_bank_codeno=tdpf_bank " & _
        "            and trnfmt_table='SAL_SABANK' " & _
        "            and trnfmt_field='BANK_BANK_NO' " & _
        "            and trnfmt_source_type='001' ) , 0 ) as trnfmt_length , " & _
        "    isNull( ( " & _
        "        select top 1 bank_bank_no from sal_sabank " & _
        "        where bank_orgid=tdpf_orgid " & _
        "            and bank_tdpf_seqno=tdpf_seqno " & _
        "            and bank_seqno='" & p_base_seqno & "' /* v_base_seqno */ ) , '' ) as bank_bank_no " & _
        "from sys_code a , sal_satdpf b " & _
        "where code_sys='004' " & _
        "    and code_kind='P' " & _
        "    and code_type='002' " & _
        "    and tdpf_orgid='" & p_UserOrgId & "' /* v_UserOrgId */ " & _
        "    and code_no=tdpf_bank " & _
        "order by code_no, tdpf_seqno " & _
        ""
        'Response.Write(rv)
        Return rv
    End Function
#End Region

    Protected Sub BankInit()

        If (v_UserOrgId <> "") And (v_base_seqno <> "") Then

            Dim tdpf_seqno As String = ""
            Dim bank_no As String = ""

            Dim sql As String = ""
            sql = "select * from sal_sabank "
            sql &= " where bank_orgid='" & v_UserOrgId & "' "
            sql &= " and bank_seqno='" & v_base_seqno & "' "
            sql &= " and bank_tdpf_seqno <> '' "
            sql &= " order by bank_mdate desc, bank_code,bank_tdpf_seqno "

            Using ta As New DB_TableAdapters.DB_TableAdapter
                Using t As DB_.DB_DataTable = ta.spExeSQLGetDataTable(sql)
                    If t.Rows.Count > 0 Then

                        Try
                            SelectedValue = t(0)("bank_code").ToString & t(0)("bank_tdpf_seqno").ToString
                            'Response.Write(t(0)("bank_code").ToString & t(0)("bank_tdpf_seqno").ToString)
                            v_account_no = t(0)("bank_bank_no").ToString
                            'v_bank_code = t(0)("bank_code").ToString
                        Catch ex As Exception

                        End Try

                    End If
                End Using
            End Using

            'For Each li As ListItem In Me.oBankNoDDL.Items
            '    If li.Value = tdpf_seqno Then
            '        li.Selected = True
            '        v_account_no = bank_no
            '    End If
            'Next
        End If


    End Sub

    Protected Sub oBankNoDDL_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles oBankNoDDL.DataBound
        BankInit()
    End Sub
End Class
