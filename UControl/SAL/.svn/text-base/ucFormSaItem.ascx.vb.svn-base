Imports SALARY.Logic

Partial Class uc_ucFormSaItem
    Inherits System.Web.UI.UserControl

#Region " PageLoad"

#End Region

#Region " Visible"


    Protected Sub edit_Item_Code_No_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_Item_Code_No.DataBound
        If Fmode = FormViewMode.Edit Then
            Me.edit_Item_Code_No.Enabled = False
        Else
            Me.edit_Item_Code_No.Enabled = True
        End If
        'ChangeADD_SA_Inco()
    End Sub

    '' Belong and ICode
#Region " Belong and ICode"
    Protected Sub edit_Item_Code_Type_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_Item_Code_Type.DataBound

        Me.Label_Type_Name.Text = Server.HtmlEncode(Me.edit_Item_Code_Type.SelectedItem.Text)
        show_type(Me.edit_Item_Code_Type.SelectedValue)

        If Fmode = FormViewMode.Edit Then
            Me.edit_Item_Code_Type.Enabled = False
        Else
            Me.edit_Item_Code_Type.Enabled = True
        End If
        If (edit_Item_Code_Type.SelectedValue = "002") Then '應扣款
            Me.edit_ITEM_ADD_HealthPlus.Visible = False
            Me.edit_ITEM_ADD_HealthPlusbonus.Visible = False '應發款
            Me.tr_HealthPlus.Visible = False
            Me.tr_HealthPlusbonus.Visible = False
        Else
            Me.edit_ITEM_ADD_HealthPlus.Visible = True
            Me.edit_ITEM_ADD_HealthPlusbonus.Visible = True
            Me.tr_HealthPlus.Visible = True
            Me.tr_HealthPlusbonus.Visible = True
        End If
        ChangeADD_SA_Inco()
    End Sub

    Protected Sub edit_Item_Code_Type_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_Item_Code_Type.SelectedIndexChanged

        Me.Label_Type_Name.Text = Server.HtmlEncode(Me.edit_Item_Code_Type.SelectedItem.Text)
        If (edit_Item_Code_Type.SelectedValue = "002") Then '應扣款
            Me.edit_ITEM_ADD_HealthPlus.Visible = False
            Me.edit_ITEM_ADD_HealthPlusbonus.Visible = False
            Me.edit_Item_Tax.Checked = False
            Me.edit_Item_Tax.Enabled = False
            Me.tr_HealthPlus.Visible = False
            Me.tr_HealthPlusbonus.Visible = False
            edit_item_tax_CheckedChanged(sender, e)
        Else '應發款
            Me.edit_Item_Tax.Enabled = True
            Me.edit_ITEM_ADD_HealthPlus.Visible = True
            Me.edit_ITEM_ADD_HealthPlusbonus.Visible = True
            Me.tr_HealthPlus.Visible = True
            Me.tr_HealthPlusbonus.Visible = True
            edit_item_tax_CheckedChanged(sender, e)
        End If
        
        show_type(Me.edit_Item_Code_Type.SelectedValue)
    End Sub

    Protected Sub show_type(ByVal value)
        If value = "001" Then
            Me.tr_belong.Visible = False
            Me.tr_icode.Visible = True
            Me.tr_tax.Visible = True
            Me.tr_year.Visible = False
            Me.tr_merit_before.Visible = False
            Me.tr_merit_after.Visible = False
            Me.tr_promo.Visible = False
        Else
            Me.tr_belong.Visible = True
            Me.tr_icode.Visible = False
            Me.tr_tax.Visible = False
            Me.tr_year.Visible = True
            Me.tr_merit_before.Visible = True
            Me.tr_merit_after.Visible = True
            Me.tr_promo.Visible = True
        End If
    End Sub
#End Region

    '' Doc_Type
#Region " Doc_Type"

    Protected Sub edit_item_icode_CodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_Item_Icode.CodeChanged
        show_doc_type(Me.edit_Item_Icode.Code_no)
    End Sub

    Protected Sub show_doc_type(ByVal value)
        Select Case value
            Case "014"
                Me.Label_doc_type.Text = "稿費代號"
                Me.tr_doc_type.Visible = True

                Me.edit_Item_Doc_Type.Items.Clear()

                set_item(Me.edit_Item_Doc_Type, "N", "---不設定---")
                set_item(Me.edit_Item_Doc_Type, "98", "98 非自行出版之稿費、版稅等七項")
                set_item(Me.edit_Item_Doc_Type, "99", "99 自行出版之稿費、版稅、作曲等")

            Case "012"
                Me.Label_doc_type.Text = "其他所得"
                Me.tr_doc_type.Visible = True

                Me.edit_Item_Doc_Type.Items.Clear()

                set_item(Me.edit_Item_Doc_Type, "N", "---不設定---")
                set_item(Me.edit_Item_Doc_Type, "80", "80 汽車駕駛訓練補習班")
                set_item(Me.edit_Item_Doc_Type, "81", "81 文理、升學、語文、法商職業補習班")
                set_item(Me.edit_Item_Doc_Type, "82", "82 縫紉、美容、美髮、音樂、舞蹈技藝及其他補習班")
                set_item(Me.edit_Item_Doc_Type, "83", "83 私立托兒所")
                set_item(Me.edit_Item_Doc_Type, "84", "84 私立幼稚園")
                set_item(Me.edit_Item_Doc_Type, "85", "85 托育中心")
                set_item(Me.edit_Item_Doc_Type, "86", "86 安親班")
                set_item(Me.edit_Item_Doc_Type, "87", "87 私立養護、療養院所")
                set_item(Me.edit_Item_Doc_Type, "88", "88 私立護理機構及依老人福利機構設置標準設立")
                set_item(Me.edit_Item_Doc_Type, "8A", "8A 職工福利金")
                set_item(Me.edit_Item_Doc_Type, "8B", "8B 違約金")
                set_item(Me.edit_Item_Doc_Type, "8C", "8C 佃農因終止375租約取得之補償費")
                set_item(Me.edit_Item_Doc_Type, "8D", "8D 個人遷讓非自有房屋、土地所取得之補償費")
                set_item(Me.edit_Item_Doc_Type, "8E", "8E 多層次傳銷參加人直接進貨取得之業績獎金或各種補助費")
                set_item(Me.edit_Item_Doc_Type, "8Z", "8Z 其他")

            Case "017"
                Me.Label_doc_type.Text = "政府補助款"
                Me.tr_doc_type.Visible = True

                Me.edit_Item_Doc_Type.Items.Clear()

                set_item(Me.edit_Item_Doc_Type, "N", "---不設定---")
                set_item(Me.edit_Item_Doc_Type, "A", "A 實報實銷")
                set_item(Me.edit_Item_Doc_Type, "B", "B 非實報實銷")


            Case "011"
                Me.Label_doc_type.Text = "競技競賽及機會中獎獎金"
                Me.tr_doc_type.Visible = True

                Me.edit_Item_Doc_Type.Items.Clear()

                set_item(Me.edit_Item_Doc_Type, "", "91　競技競賽及機會中獎獎金")
                set_item(Me.edit_Item_Doc_Type, "D", "91D 政府舉辦獎券中獎獎金")
            Case Else
                Me.Label_doc_type.Text = ""
                Me.tr_doc_type.Visible = False

                Me.edit_Item_Doc_Type.Items.Clear()

                set_item(Me.edit_Item_Doc_Type, "", "")

        End Select
    End Sub

    Protected Sub set_item(ByRef item, ByVal value, ByVal text)
        Dim li As New ListItem(text, value)
        CType(item, DropDownList).Items.Add(li)
    End Sub
#End Region

    '' Tax_Type
#Region " Tax_Type"


    Protected Sub show_tax_type(ByVal value)
        Me.edit_Item_Tax_Type.Visible = value
    End Sub

#End Region

#End Region

#Region " Property"

    Public Property Fmode() As FormViewMode
        Get
            Dim rv As Byte = FormViewMode.ReadOnly
            Select Case Me.TextBox_Fmode.Text
                Case "1"
                    rv = FormViewMode.Edit
                Case "2"
                    rv = FormViewMode.Insert
                Case "0"
                    rv = FormViewMode.ReadOnly
                Case Else
                    rv = FormViewMode.ReadOnly
            End Select
            Return rv
        End Get
        Set(ByVal value As FormViewMode)
            Me.TextBox_Fmode.Text = Convert.ToByte(value).ToString()

            Select Case value

                Case FormViewMode.Edit
                    Me.FunctionEdit.Visible = True
                    Me.FunctionInsert.Visible = False
                    Me.lbTitle.Text = "維護自訂薪資項目"
                Case FormViewMode.Insert
                    Me.FunctionEdit.Visible = False
                    Me.FunctionInsert.Visible = True
                    Me.lbTitle.Text = "新增自訂薪資項目"
                Case Else
                    Me.FunctionEdit.Visible = False
                    Me.FunctionInsert.Visible = False

            End Select
        End Set
    End Property

    Public Property v_orgid() As String
        Get
            Return Me.edt_Item_Orgid.Text
        End Get
        Set(ByVal value As String)
            Me.edt_Item_Orgid.Text = value
        End Set
    End Property

    Public Property v_code_sys() As String
        Get
            Return "005"
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_code_kind() As String
        Get
            Return "D"
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_code_type() As String
        Get
            Return Me.edit_Item_Code_Type.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Code_Type.SelectedValue = value
        End Set
    End Property

    Public Property v_code_no() As String
        Get
            Return Me.edit_Item_Code_No.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Code_No.SelectedValue = value
        End Set
    End Property

    Public Property v_code() As String
        Get
            Return Me.edit_Item_Code.Text
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Code.Text = value
        End Set
    End Property

    Public Property v_name() As String
        Get
            Return Me.edit_Item_Name.Text
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Name.Text = value
        End Set
    End Property

    Public Property v_operation() As String
        Get
            Dim rv As String = ""
            Select Case v_code_type
                Case "001"
                    rv = "+"
                Case "002"
                    rv = "-"
                Case Else
                    rv = "+"
            End Select
            Return rv
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_bmon() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_emon() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_icode() As String
        Get
            Dim rv As String = ""
            Select Case v_code_type
                Case "001"
                    rv = Me.edit_Item_Icode.Code_no
                Case "002"
                    rv = ""
                Case Else
                    rv = ""
            End Select
            Return rv
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Icode.Code_no = value
            show_doc_type(value)
        End Set
    End Property

    Public Property v_tax() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_Item_Tax.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_Item_Tax.Checked)
            show_tax_type(pub.ConvertYNtoTrueFalse(value))
        End Set
    End Property

    Public Property v_type() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_item_type.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_item_type.Checked)
            show_tax_type(pub.ConvertYNtoTrueFalse(v_tax))
        End Set
    End Property
    Public Property v_add_inco() As String '回傳是否是納入薪資所得
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_item_Add_SAinco.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_item_Add_SAinco.Checked)
        End Set
    End Property

    Public Property v_ADD_HealthPlus() As String '回傳是否是納入薪資所得
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_ITEM_ADD_HealthPlus.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Me.edit_ITEM_ADD_HealthPlus.Checked = pub.ConvertYNtoTrueFalse(value)
        End Set
    End Property
    Public Property v_ADD_HealthPlusbonus() As String '回傳是否是納入薪資所得
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_ITEM_ADD_HealthPlusbonus.Checked.ToString())
        End Get
        Set(ByVal value As String)
            'Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_ITEM_ADD_HealthPlusbonus.Checked)
            Me.edit_ITEM_ADD_HealthPlusbonus.Checked = pub.ConvertYNtoTrueFalse(value)
        End Set
    End Property
    Public Property v_row() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_muser() As String
        Get
            Return Me.edit_Item_Muser.Text
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Muser.Text = value
        End Set
    End Property

    Public Property v_mdate() As String
        Get
            Return Me.edit_Item_Mdate.Text
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Mdate.Text = value
        End Set
    End Property

    Public Property v_permanent() As String
        Get
            Return "Y"
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_form() As String
        Get
            Return "N"
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property v_suspend() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_Item_Suspend.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_Item_Suspend.Checked)
        End Set
    End Property

    Public Property v_year() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_Item_Year.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_Item_Year.Checked)
        End Set
    End Property

    Public Property v_merit_before() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_Item_Merit_Before.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_Item_Merit_Before.Checked)
        End Set
    End Property

    Public Property v_merit_after() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_Item_Merit_After.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_Item_Merit_After.Checked)
        End Set
    End Property

    Public Property v_promo() As String
        Get
            Return pub.ConvertTrueFalseToYN(Me.edit_Item_Promo.Checked.ToString())
        End Get
        Set(ByVal value As String)
            Boolean.TryParse(pub.ConvertYNtoTrueFalse(value), Me.edit_Item_Promo.Checked)
        End Set
    End Property

    Public Property v_belong() As String
        Get
            Return Me.edit_Item_Belong.Code_no
        End Get
        Set(ByVal value As String)
            Me.edit_Item_Belong.Code_no = value
        End Set
    End Property

    Public Property v_doc_type() As String
        Get
            Return Me.edit_Item_Doc_Type.SelectedValue
        End Get
        Set(ByVal value As String)

            'Me.edit_Item_Doc_Type.SelectedValue = value

            If value <> "" Then
                For i As Integer = 0 To Me.edit_Item_Doc_Type.Items.Count - 1
                    If Me.edit_Item_Doc_Type.Items(i).Value = value Then
                        Me.edit_Item_Doc_Type.Items(i).Selected = True
                    End If
                Next
            End If
        End Set
    End Property

    Public Property v_tax_type() As String
        Get
            Dim rv As String = ""
            If v_tax = "Y" Then
                rv = Me.edit_Item_Tax_Type.SelectedValue
            Else
                rv = ""
            End If
            Return rv
        End Get
        Set(ByVal value As String)

            If value <> "" Then
                For i As Integer = 0 To Me.edit_Item_Tax_Type.Items.Count - 1
                    If Me.edit_Item_Tax_Type.Items(i).Value = value Then
                        Me.edit_Item_Tax_Type.Items(i).Selected = True
                    End If
                Next
            End If

        End Set
    End Property

    Public Property v_memo() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)

        End Set
    End Property

#End Region


#Region "event"

    Public Event WindowClose(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Event FormInsert(ByVal sender As Object, ByVal e As System.EventArgs)

    Public Event FormUpdate(ByVal sender As Object, ByVal e As System.EventArgs)

#End Region

#Region "RaiseEvent"

    Protected Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        RaiseEvent WindowClose(Me, e)
    End Sub

    Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        RaiseEvent FormInsert(Me, e)
    End Sub

    Protected Sub UpdateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        If (Me.edit_ITEM_ADD_HealthPlus.Checked) Then
            If (CheckIcode(edit_Item_Icode.Code_no, Me.edit_ITEM_ADD_HealthPlus.Checked)) Then
                RaiseEvent FormUpdate(Me, e)
            Else
                Me.MessageBox_ScriptManager("您選的項目並非補充保費收取的標的，不得點選納入補充保費扣繳計算或納入補充保費之獎金計算")
            End If
        Else '如果沒有勾選的話不用檢查直接更新
            RaiseEvent FormUpdate(Me, e)
        End If




    End Sub
    Public Sub MessageBox_ScriptManager(ByVal message As String)

        Dim script As String = "alert('{0}'); "
        ScriptManager.RegisterClientScriptBlock( _
            Me, _
            GetType(Page), _
            "MessageBox", _
            String.Format(script, message), _
            True)

    End Sub
#End Region
    Protected Function CheckIcode(ByVal ItemIcode As String, ByVal AddHealthplus As Boolean) As Boolean
        Dim rv As Boolean = False
        If ItemIcode = "001" Then
            rv = True
        End If
        If ItemIcode = "002" Then
            rv = True
        End If
        If ItemIcode = "003" Then
            rv = True
        End If
        If ItemIcode = "005" Then
            rv = True
        End If
        If ItemIcode = "006" Then
            rv = True
        End If
        If ItemIcode = "007" Then
            rv = True
        End If
        If ItemIcode = "013" Then
            rv = True
        End If
        If ItemIcode = "014" Then
            rv = True
        End If
        Return (AddHealthplus And rv)
    End Function
    Protected Sub edit_item_tax_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_Item_Tax.CheckedChanged
        show_tax_type(Me.edit_Item_Tax.Checked)
        ChangeADD_SA_Inco()
    End Sub

    Protected Sub ChangeADD_SA_Inco()

        If Not ((Me.edit_Item_Tax.Checked And Me.edit_item_type.Checked)) Then
            Me.edit_item_Add_SAinco.Enabled = False
            Me.edit_item_Add_SAinco.Visible = False
            Me.edit_item_Add_SAinco.Checked = (Me.edit_Item_Tax.Checked And Me.edit_item_type.Checked)
            Me.tr_SAinco.Visible = False
        Else
            Me.edit_item_Add_SAinco.Enabled = True
            Me.edit_item_Add_SAinco.Visible = True
            Me.tr_SAinco.Visible = True
        End If


        'Me.edit_item_Add_SAinco.Checked = Me.edit_item_Add_SAinco.Enabled
    End Sub


    Protected Sub ChangeAdd_Health()
        '如果納入補充保費扣繳計算沒有勾選，納入補充保費之獎金計算也不能勾選
        If Not (Me.edit_ITEM_ADD_HealthPlus.Checked) Then
            Me.edit_ITEM_ADD_HealthPlusbonus.Checked = False
        End If
    End Sub
    Protected Sub ChangeAdd_HealthBonus()
        '如果納入補充保費之獎金計算有勾選，納入補充保費扣繳計算也要勾選
        If (Me.edit_ITEM_ADD_HealthPlusbonus.Checked) Then
            Me.edit_ITEM_ADD_HealthPlus.Checked = True
        End If
    End Sub
    Protected Sub edit_item_type_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_item_type.CheckedChanged
        ChangeADD_SA_Inco()
    End Sub


    Protected Sub edit_ITEM_ADD_HealthPlus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_ITEM_ADD_HealthPlus.CheckedChanged
        ChangeAdd_Health()
    End Sub


    Protected Sub edit_ITEM_ADD_HealthPlusBouns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles edit_ITEM_ADD_HealthPlusbonus.CheckedChanged
        ChangeAdd_HealthBonus()
    End Sub

End Class
