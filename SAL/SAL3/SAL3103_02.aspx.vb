Imports System.Data
Imports FSCPLM.Logic
Imports SALARY.Logic
Imports System.Transactions
Imports System.IO

Partial Class SAL3103_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Me.TextBox_act.Text = Request.QueryString("act")
            Me.TextBox_code.Text = Request.QueryString("code")
            'Me.TextBox_btn.Text = Request.QueryString("btn")
            Me.TextBox_orgid.Text = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

            Me.FormView_item.ChangeMode(Me.TextBox_act.Text)

        End If
    End Sub

    Protected Sub FormInsert(ByVal sender As Object, ByVal e As System.EventArgs)

        ''取號
        CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_code = Me.GetCode
        CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_orgid = Me.TextBox_orgid.Text

        CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_muser = Me.TextBox_mid.Text
        CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_mdate = Now.ToString("yyyyMMddHHmmss")
        Dim txtcount = LenC(CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_name)

        If (txtcount <= 20) Then
            Try
                Me.FormView_item.InsertItem(False)
            Catch ex As Exception
                Dim msg As String = ex.Message.ToString
                Dim script As String = "alert('{0}'); "
                ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "Message", String.Format(script, msg), True)
            End Try
        Else
            Dim script As String = "alert('{0}'); "
            Dim msg As String = "輸入字元超過20個，請檢查輸入字數!!"
            ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "Message", String.Format(script, msg), True)


        End If


    End Sub
    Private Function LenC(ByVal s As String) As Integer
        Dim n As Integer
        LenC = 0
        For n = 1 To Len(s)
            If (AscW(Mid(s, n, 1)) > 256) Or (AscW(Mid(s, n, 1)) < 0) Then
                LenC = LenC + 2
            Else
                LenC = LenC + 1
            End If
        Next n
    End Function
    Protected Sub FormUpdate(ByVal sender As Object, ByVal e As System.EventArgs)
        CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_muser = Me.TextBox_mid.Text
        CType(Me.FormView_item.FindControl("UcFormSaItem1"), uc_ucFormSaItem).v_mdate = Now.ToString("yyyyMMddHHmmss")

        Me.FormView_item.UpdateItem(False)
    End Sub


    Protected Sub FormClose(ByVal sender As Object, ByVal e As System.EventArgs)
        ''關閉本視窗
        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "window.close(); void(0);", True)
        Response.Redirect("SAL3103_01.aspx")
    End Sub

#Region " FormView"

    Protected Sub FormView_item_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView_item.ItemInserted

        ''原視窗重整
        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "Button_binding_Click", "opener.$get('" & Me.TextBox_btn.Text & "').click(); void(0);", True)
        ''關閉本視窗
        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "window.close(); void(0);", True)

        CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK, "", "SAL3103_01.aspx")
    End Sub

    Protected Sub FormView_item_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView_item.ItemUpdated

        ''原視窗重整
        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "Button_binding_Click", "opener.$get('" & Me.TextBox_btn.Text & "').click(); void(0);", True)
        ''關閉本視窗
        'ScriptManager.RegisterClientScriptBlock(Me.Page, GetType(Page), "window_close", "window.close(); void(0);", True)

        CommonFun.MsgShow(Me, CommonFun.Msg.UpdateOK, "", "SAL3103_01.aspx")
    End Sub

    Protected Function GetCode() As String
        Dim rv As String = "001"

        Using ta As New dt_SaItem_TableAdapters.MaxItemCode_TableAdapter
            Using t As dt_SaItem_.MaxItemCode_DataTable = ta.GetData(Me.TextBox_orgid.Text)
                If t.Rows.Count > 0 Then
                    rv = pub.get_zero(CStr(CInt(t(0)("Item_Code").ToString) + 1), 3)
                End If
            End Using
        End Using

        Return rv
    End Function

#End Region


End Class
