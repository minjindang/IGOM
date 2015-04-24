Imports SALARY.Logic
Imports System.Data

Partial Class SAL2104_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' 第一次進頁
        If Not Page.IsPostBack Then
            For i As Integer = 103 To Now.Year - 1911
                DropDownList_year.Items.Add(i.ToString())
            Next
            DropDownList_month.SelectedIndex = Format(Now(), "MM") - 1 ' 設定現在月份
        End If
    End Sub

    Protected Sub GridView1_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.PreRender

        For Each info_gvr As GridViewRow In Me.GridView1.Rows
            Dim f_ym As Label = CType(info_gvr.FindControl("f_ym"), Label)
            Dim f_ym_w As Label = CType(info_gvr.FindControl("f_ym_w"), Label)
            Dim f_date As Label = CType(info_gvr.FindControl("f_date"), Label)
            Dim f_date_w As Label = CType(info_gvr.FindControl("f_date_w"), Label)
            Dim f_item As Label = CType(info_gvr.FindControl("f_item"), Label)
            Dim f_item_w As Label = CType(info_gvr.FindControl("f_item_w"), Label)

            ' 日期轉換
            Try
                If f_item.Text = "002" Or f_item.Text = "003" Or f_item.Text = "004" Then
                    f_ym_w.Text = Mid(f_ym.Text, 1, 4) - 1911
                Else
                    f_ym_w.Text = Mid(f_ym.Text, 1, 4) - 1911 & " / " & Mid(f_ym.Text, 5, 2)
                End If

                f_date_w.Text = Mid(f_date.Text, 1, 4) - 1911 & " / " & Mid(f_date.Text, 5, 2) & " / " & Mid(f_date.Text, 7, 2) & " - " & _
                                Mid(f_date.Text, 9, 2) & " 時 " & Mid(f_date.Text, 11, 2) & " 分 " & Mid(f_date.Text, 13, 2) & " 秒 "
            Catch ex As Exception
            End Try
            ' 薪資項目轉換
            Select Case f_item.Text
                Case "001"
                    f_item_w.Text = "月薪"
                Case "002"
                    f_item_w.Text = "預借考績"
                Case "003"
                    f_item_w.Text = "核定考績"
                Case "004"
                    f_item_w.Text = "年終獎金"
                Case "005"
                    f_item_w.Text = "其他薪津發放"
                Case "006"
                    f_item_w.Text = "晉級補發"
                Case "007"
                    f_item_w.Text = "補發調薪差額"
                Case ""
                    f_item_w.Text = ""
            End Select
        Next
    End Sub

#Region "查詢"
    Protected Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        Bind()
    End Sub

    Protected Sub Bind()
        Dim ym As String = (Val(DropDownList_year.SelectedValue) + 1911).ToString() & DropDownList_month.SelectedValue

        Dim sal2104 As New SAL2104()
        Dim dt As DataTable = sal2104.GetDataByQuery(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode), ym)
        Me.GridView1.DataSource = dt
        Me.GridView1.DataBind()

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            tbq.Visible = True
        Else
            tbq.Visible = False
        End If
    End Sub
#End Region

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Bind()
    End Sub

End Class
