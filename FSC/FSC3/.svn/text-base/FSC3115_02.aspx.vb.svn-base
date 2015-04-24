Imports System
Imports System.Data
Imports FSCPLM.Logic

Partial Class FSC3_FSC3115_02
    Inherits BaseWebForm

    Dim dtData As DataTable
    Dim bll As New FSC.Logic.FSC3115()

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load

        Dim szPECARD As String = Session("FSC_PECARD")
        Dim szPEIDNO As String = Session("FSC_PEIDNO")

        If IsPostBack Then
            If szPECARD = "" And szPEIDNO = "" Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "資料遺失，請重新選擇!")
                Response.Redirect("FSC3115_01.aspx")
            End If
            Return
        End If

        ' 取出差異資料
        dtData = bll.GetDifferenceDetailsData(szPECARD, szPEIDNO)

        Me.gvList.DataSource = dtData
        Me.gvList.DataBind()

        ' TABLENAME=P2K，隱藏CheckBox
        For i As Integer = 0 To (gvList.Rows.Count - 1)
            Dim cbSubmit As CheckBox = gvList.Rows(i).FindControl("cbSubmit")
            Dim lbTABLENAME As Label = gvList.Rows(i).FindControl("lbTABLENAME")

            If lbTABLENAME.Text = "P2K" Then
                cbSubmit.Visible = False
            Else
                cbSubmit.Visible = True
            End If
        Next

    End Sub


    Protected Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim iCounts As Integer = 0
        Dim szMsg As String = String.Empty

        For i As Integer = 0 To (gvList.Rows.Count - 1)
            Dim cbSubmit As CheckBox = gvList.Rows(i).FindControl("cbSubmit")
            Dim lbTABLENAME As Label = gvList.Rows(i).FindControl("lbTABLENAME")
            Dim lbPECARD As Label = gvList.Rows(i).FindControl("lbPECARD")
            Dim hfPEIDNO As HiddenField = gvList.Rows(i).FindControl("hfPEIDNO")

            ' 更新資料
            If cbSubmit.Visible = True And cbSubmit.Checked And lbTABLENAME.Text = "FSC" Then
                iCounts = bll.UpdateFSC(lbPECARD.Text, hfPEIDNO.Value)
                If iCounts > 0 Then
                    szMsg += lbPECARD.Text + "，FSC資料更新成功。\n"
                End If
            End If

            If cbSubmit.Visible = True And cbSubmit.Checked And lbTABLENAME.Text = "SAL" Then
                iCounts = bll.UpdateSAL(lbPECARD.Text, hfPEIDNO.Value)
                If iCounts > 0 Then
                    szMsg += lbPECARD.Text + "，SAL資料更新成功。\n"
                End If
            End If

            If cbSubmit.Visible = True And cbSubmit.Checked And lbTABLENAME.Text = "EMP" Then
                iCounts = bll.UpdateEMP(lbPECARD.Text, hfPEIDNO.Value)
                If iCounts > 0 Then
                    szMsg += lbPECARD.Text + "，EMP資料更新成功。\n"
                End If
            End If
        Next

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, szMsg)

        ' 重新繫結資料
        Dim szPECARD As String = Session("FSC_PECARD")
        Dim szPEIDNO As String = Session("FSC_PEIDNO")

        dtData = bll.GetDifferenceDetailsData(szPECARD, szPEIDNO)

        Me.gvList.DataSource = dtData
        Me.gvList.DataBind()

        ' TABLENAME=P2K，隱藏CheckBox
        For i As Integer = 0 To (gvList.Rows.Count - 1)
            Dim cbSubmit As CheckBox = gvList.Rows(i).FindControl("cbSubmit")
            Dim lbTABLENAME As Label = gvList.Rows(i).FindControl("lbTABLENAME")

            If lbTABLENAME.Text = "P2K" Then
                cbSubmit.Visible = False
            Else
                cbSubmit.Visible = True
            End If
        Next

    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Session.Clear()
        Response.Redirect("FSC3115_01.aspx")
    End Sub
End Class
