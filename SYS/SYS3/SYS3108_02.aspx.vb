Imports System.Data
Imports System.Transactions
Imports System.Collections.Generic
Imports FSCPLM.Logic
Imports SYS.Logic

Partial Class SYS3108_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Bind()
    End Sub

    Protected Sub Bind()
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        Dim flowOutpostId As String = Request.QueryString("fopID")
        If Not String.IsNullOrEmpty(flowOutpostId) Then
            cbConfirm.Visible = True
        End If
        Dim dt As New DataTable

        Dim stepdt As DataTable = New SACode().GetData("023", "011")
        For Each dr As DataRow In stepdt.Rows
            dr("CODE_NO") = "1," & dr("CODE_NO")
        Next
        lbxUnitInOutpost.DataSource = stepdt
        lbxUnitInOutpost.DataBind()


        Dim bossLeveldt As DataTable = New SACode().GetData("023", "015")
        For Each dr As DataRow In bossLeveldt.Rows
            dr("CODE_NO") = "0," & dr("CODE_NO")
        Next
        lbxBossLevel.DataSource = bossLeveldt
        lbxBossLevel.DataBind()


        Dim list As List(Of SYS.Logic.FlowOutpostMaster) = Session("FlowOutpostMasterList")
        If String.IsNullOrEmpty(flowOutpostId) Then
            dt = New SYS.Logic.SYS3108().GetListBoxData(orgcode, list)
        Else
            If list IsNot Nothing Then
                dt = New SYS.Logic.SYS3108().GetListBoxData(orgcode, list)
            Else
                dt = New SYS.Logic.SYS3108().GetListBoxData(orgcode, flowOutpostId)
            End If
        End If

        lbxFlowOutpost.DataSource = dt
        lbxFlowOutpost.DataBind()
    End Sub


    '下一步
    Protected Sub cbNextStep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbNextStep.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim flowOutpostId As String = Request.QueryString("fopID")

        Dim joinOutpostId As String = ""
        For Each op As ListItem In lbxFlowOutpost.Items
            joinOutpostId &= op.Value & ";"
        Next
        joinOutpostId = joinOutpostId.Trim(";")

        If String.IsNullOrEmpty(joinOutpostId) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請設定簽核關卡")
            Return
        End If

        Dim fom As New SYS.Logic.FlowOutpostMaster()
        Dim list As List(Of SYS.Logic.FlowOutpostMaster) = fom.GetFlowOutpostIdList(Orgcode, joinOutpostId)
        Session("FlowOutpostMasterList") = list

        Response.Redirect("SYS3108_03.aspx?fopID=" & flowOutpostId)
    End Sub


    '取消
    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Session("FlowOutpostMasterList") = Nothing
        Dim flowOutpostId As String = Request.QueryString("fopID")

        Response.Redirect("SYS3108_01.aspx?fopID=" & flowOutpostId)
    End Sub

    Protected Sub cbRight_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index_list As New ArrayList()
        For Each op As ListItem In lbxUnitInOutpost.Items
            If op.Selected Then
                lbxFlowOutpost.Items.Add(op)
                index_list.Add(op)
            End If
        Next
        For j As Integer = 0 To index_list.Count - 1
            lbxUnitInOutpost.Items.Remove(CType(index_list.Item(j), ListItem))
        Next

        index_list = New ArrayList()
        For Each op As ListItem In lbxBossLevel.Items
            If op.Selected Then
                lbxFlowOutpost.Items.Add(op)
                index_list.Add(op)
            End If
        Next
        For j As Integer = 0 To index_list.Count - 1
            lbxBossLevel.Items.Remove(CType(index_list.Item(j), ListItem))
        Next
        setDefault()

        '職稱
        If Not String.IsNullOrEmpty(UcTitleDialog.Value) Then
            lbxFlowOutpost.Items.Add(New ListItem(UcTitleDialog.Text, UcTitleDialog.Value))
            UcTitleDialog.Value = ""
            UcTitleDialog.Text = ""
        End If

        '人員
        If Not String.IsNullOrEmpty(UcUserDialog.Value) Then
            lbxFlowOutpost.Items.Add(New ListItem(UcUserDialog.Text, UcUserDialog.Value))
            UcUserDialog.Value = ""
            UcUserDialog.Text = ""
        End If

        '角色
        If Not String.IsNullOrEmpty(UcRoleDialog.Value) Then
            lbxFlowOutpost.Items.Add(New ListItem(UcRoleDialog.Text, UcRoleDialog.Value))
            UcRoleDialog.Value = ""
            UcRoleDialog.Text = ""
        End If


        '會辦職稱
        If Not String.IsNullOrEmpty(UcTitleDialog1.Value) Then
            Dim v() As String = UcTitleDialog1.Value.Split(",")
            v(0) = "5"
            UcTitleDialog1.Value = CommonFun.CombineString(v, ",")
            lbxFlowOutpost.Items.Add(New ListItem(UcTitleDialog1.Text & "(會)", UcTitleDialog1.Value))
            UcTitleDialog1.Value = ""
            UcTitleDialog1.Text = ""
        End If

        '會辦人員
        If Not String.IsNullOrEmpty(UcUserDialog1.Value) Then
            Dim v() As String = UcUserDialog1.Value.Split(",")
            v(0) = "6"
            UcUserDialog1.Value = CommonFun.CombineString(v, ",")
            lbxFlowOutpost.Items.Add(New ListItem(UcUserDialog1.Text & "(會)", UcUserDialog1.Value))
            UcUserDialog1.Value = ""
            UcUserDialog1.Text = ""
        End If

        '會辦角色
        If Not String.IsNullOrEmpty(UcRoleDialog1.Value) Then
            Dim v() As String = UcRoleDialog1.Value.Split(",")
            v(0) = "7"
            UcRoleDialog1.Value = CommonFun.CombineString(v, ",")
            lbxFlowOutpost.Items.Add(New ListItem(UcRoleDialog1.Text & "(會)", UcRoleDialog1.Value))
            UcRoleDialog1.Value = ""
            UcRoleDialog1.Text = ""
        End If

    End Sub

    Protected Sub cbLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index_list As New ArrayList
        For Each op As ListItem In lbxFlowOutpost.Items
            If op.Selected Then
                If op.Value.Substring(0, 1) = "1" Then
                    lbxUnitInOutpost.Items.Add(op)
                ElseIf op.Value.Substring(0, 1) = "0" Then
                    lbxBossLevel.Items.Add(op)
                End If
                index_list.Add(op)
            End If
        Next

        For j As Integer = 0 To index_list.Count - 1
            lbxFlowOutpost.Items.Remove(CType(index_list.Item(j), ListItem))
        Next

        setDefault()
    End Sub

    Protected Sub cbLeftALL_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        lbxFlowOutpost.Items.Clear()
        lbxUnitInOutpost.DataBind()
        setDefault()
    End Sub

    Protected Sub setDefault()
        lbxUnitInOutpost.SelectedIndex = -1
        lbxFlowOutpost.SelectedIndex = -1
        lbxBossLevel.SelectedIndex = -1
    End Sub

    Protected Sub cbUp_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim temp As String = lbxFlowOutpost.SelectedItem.Text
        Dim value As String = lbxFlowOutpost.SelectedItem.Value

        lbxFlowOutpost.SelectedItem.Text = lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex - 1).Text
        lbxFlowOutpost.SelectedItem.Value = lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex - 1).Value
        lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex - 1).Text = temp
        lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex - 1).Value = value

        lbxFlowOutpost.SelectedIndex = lbxFlowOutpost.SelectedIndex - 1
    End Sub

    Protected Sub cbDown_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim temp As String = lbxFlowOutpost.SelectedItem.Text
        Dim value As String = lbxFlowOutpost.SelectedItem.Value

        lbxFlowOutpost.SelectedItem.Text = lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex + 1).Text
        lbxFlowOutpost.SelectedItem.Value = lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex + 1).Value
        lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex + 1).Text = temp
        lbxFlowOutpost.Items(lbxFlowOutpost.SelectedIndex + 1).Value = value

        lbxFlowOutpost.SelectedIndex = lbxFlowOutpost.SelectedIndex + 1
    End Sub

    Protected Sub lbxFlowOutpost_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbxFlowOutpost.DataBound

        For Each op As ListItem In lbxFlowOutpost.Items
            lbxUnitInOutpost.Items.Remove(op)
        Next

    End Sub

    Protected Sub lbxBossLevel_DataBound(sender As Object, e As EventArgs) Handles lbxBossLevel.DataBound

        For Each op As ListItem In lbxFlowOutpost.Items
            lbxBossLevel.Items.Remove(op)
        Next

    End Sub

    Protected Sub cbConfirm_Click(sender As Object, e As EventArgs)
        Dim flowOutpostId As String = Request.QueryString("fopID")
        Dim changeUserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        Dim fom As New FlowOutpostMaster()

        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim joinOutpostId As String = ""
        For Each op As ListItem In lbxFlowOutpost.Items
            joinOutpostId &= op.Value & ";"
        Next
        joinOutpostId = joinOutpostId.Trim(";")
        If String.IsNullOrEmpty(joinOutpostId) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請設定簽核關卡")
            Return
        End If

        Dim list As List(Of SYS.Logic.FlowOutpostMaster) = fom.GetFlowOutpostIdList(Orgcode, joinOutpostId)
        Session("FlowOutpostMasterList") = list

        Using trans As New TransactionScope
            Dim fomList As Generic.List(Of FlowOutpostMaster) = Session("FlowOutpostMasterList")
            If fomList IsNot Nothing Then
                fom.DeleteFlowOutpostMaster(flowOutpostId)
                For i As Integer = 0 To fomList.Count - 1
                    Dim fom1 As FlowOutpostMaster = fomList(i)
                    fom1.Flow_outpost_id = flowOutpostId
                    fom1.Change_userid = changeUserid
                    fom1.Change_date = Now
                    If Not fom1.InsertFlowOutpostMaster() Then
                        Throw New Exception("設定失敗")
                    End If
                Next
            End If
            trans.Complete()
        End Using

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "設定成功", "SYS3108_01.aspx")
    End Sub
End Class
