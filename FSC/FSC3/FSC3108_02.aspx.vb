Imports FSC.Logic
Partial Class FSC3108_02
    Inherits BaseWebForm

    '(1)	當按下確認鈕時，進行下列檢核
    '   1.	若任一必填欄位未填寫，則提示訊息ErrMsg(“{必填欄位}不可為空白!請重新輸入”)
    '   2.	若必填欄位皆填寫，則以「刷卡代碼」為條件，將資料更新至「刷卡紀錄檔」（CPAPHYYMM）
    Protected Sub toConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles toConfirm.Click
        If "" <> Me.tbPHIDATE.Text And "" <> Me.tbPHITIME.Text And "" <> Me.ddlPHITYPE.SelectedValue Then
            Dim fsc3108 As New FSC3108DAO()

            Dim mcard As String = Me.Request.QueryString("PHCARD")
            Dim mdate As String = Me.Request.QueryString("PHIDATE")
            Dim mtype As String = Me.Request.QueryString("PHITYPE")
            Dim mtime As String = Me.Request.QueryString("PHITIME")

            fsc3108.update(Me.lbPHCARD.Text, Me.tbPHIDATE.Text, Me.ddlPHITYPE.SelectedValue, Me.tbPHITIME.Text, mdate, mtype, mtime)

            Dim card As String = Me.Request.QueryString("card")
            Dim idate As String = Me.Request.QueryString("date")
            Dim itime As String = Me.Request.QueryString("time")
            Dim itype As String = Me.Request.QueryString("type")

            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "更新完成!!", "FSC3108_01.aspx?card=" & card & "&date=" & idate & "&time=" & itime & "&type=" & itype)
        Else
            Dim msg As String = ""
            If "" = Me.tbPHIDATE.Text Then
                msg += "刷卡日期不可為空白!請重新輸入\n"
            End If
            If "" = Me.ddlPHITYPE.SelectedValue Then
                msg += "進出種類不可為空白!請重新輸入\n"
            End If
            If "" = Me.tbPHITIME.Text Then
                msg += "刷卡時間不可為空白!請重新輸入\n"
            End If
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, msg)
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lbPHCARD.Text = Me.Request.QueryString("PHCARD")
            Me.tbPHIDATE.Text = Me.Request.QueryString("PHIDATE")
            Me.tbPHITIME.Text = Me.Request.QueryString("PHITIME")
            Me.ddlPHITYPE.SelectedValue = Me.Request.QueryString("PHITYPE")
        End If
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click

        Dim card As String = Me.Request.QueryString("card")
        Dim idate As String = Me.Request.QueryString("date")
        Dim itime As String = Me.Request.QueryString("time")
        Dim itype As String = Me.Request.QueryString("type")

        Response.Redirect("FSC3108_01.aspx?card=" & card & "&date=" & idate & "&time=" & itime & "&type=" & itype)
    End Sub
End Class
