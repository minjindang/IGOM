Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class CAR_CAR3_CAR3102_02
    Inherits BaseWebForm

    Dim carDT As DataTable
    Dim carMain As New Car_main

     
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'usedUnit2.Items.Clear()
            newListbox()
            Maintain()
        End If


    End Sub

    Protected Sub newListbox()
        Dim org As New FSC.Logic.Org()
        Dim dt As DataTable = org.GetDataByParentDepartid(LoginManager.OrgCode, "") 'carMain.newlist("")
        usedUnit1.DataSource = dt
        usedUnit1.DataTextField = "Depart_name"
        usedUnit1.DataValueField = "Depart_id"
        usedUnit1.DataBind()
        usedUnit1.Items.Insert(0, New ListItem("全部單位", "*"))
    End Sub

    Protected Sub Maintain()
        Dim db As New DataTable
        Dim Carmain As New Car_main
        Dim carid As String = ""

        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request("tb1")) Then
                tbCarId.Text = Request("tb1")
                carid = Server.HtmlEncode(Request("tb1"))
            End If
            db = Carmain.getAll(carid)

            ucCarType.Code_no = db.Rows(0)("Car_type").ToString()
            tbCarName.Text = db.Rows(0)("Car_name").ToString()
            rdoStatus.Code_no = db.Rows(0)("Status_type").ToString()
            rdoVerify.Code_no = db.Rows(0)("NeedVerify_type").ToString()

            Dim Unit As String = db.Rows(0)("UsedUnit_code").ToString()
            Dim UnitItem() As String = Unit.Split(",")
            usedUnit2.Items.Clear()

            If Unit = "*" Then
                If usedUnit2.Items.Count <= 0 Then
                    usedUnit2.Items.Add(New ListItem("全部單位", "*"))
                End If
            Else
                Dim dt As DataTable = usedUnit1.DataSource

                Dim dt2 As DataTable = dt.Clone

                For Each dr As DataRow In dt.Rows
                    If Array.IndexOf(UnitItem, dr("Depart_id")) <> "-1" Then
                        Dim dr2 As DataRow = dt2.NewRow
                        dr2("Depart_name") = dr("Depart_name")
                        dr2("Depart_id") = dr("Depart_id")
                        dt2.Rows.Add(dr2)
                        usedUnit1.Items.Remove(New ListItem(dr2("Depart_name"), dr("Depart_id")))
                    End If

                Next

                dt2.AcceptChanges()

                usedUnit2.DataSource = dt2
                usedUnit2.DataTextField = "Depart_name"
                usedUnit2.DataValueField = "Depart_id"
                usedUnit2.DataBind()
            End If
        End If
    End Sub


    Protected Sub btnGiveup_Click(sender As Object, e As EventArgs) Handles btnGiveup.Click
        Response.Redirect("~/CAR/CAR3/CAR3102_01.aspx")
    End Sub

    Protected Sub btnConfirm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConfirm.Click
        Dim UnitItem(usedUnit2.Items.Count - 1) As String
        Dim i As Int16 = 0
        For Each item As ListItem In usedUnit2.Items
            UnitItem(i) = item.Value
            i += 1
        Next
        Dim CarMain As Car_main = New Car_main
        Dim ucCar_Type As String = ""
        Dim Car_Name As String = ""
        Dim Car_Id As String = ""
        Dim rdo_Status As String = ""
        Dim rdo_Verify As String = ""
        Dim used_Unit As String = ""
        Dim moduserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Personnel_id)
        Dim moddate As Date = Now.Date
        Dim modorg As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

        If String.IsNullOrEmpty(tbCarName.Text.Trim) Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請輸入車輛代號!")
            Return
        End If

        If Not String.IsNullOrEmpty(ucCarType.Code_no) Then
            ucCar_Type = Server.HtmlEncode(ucCarType.Code_no)
        End If
        If Not String.IsNullOrEmpty(tbCarName.Text) Then
            Car_Name = Server.HtmlEncode(tbCarName.Text)
        End If
        If Not String.IsNullOrEmpty(tbCarId.Text) Then
            Car_Id = Server.HtmlEncode(tbCarId.Text)
        End If
        If Not String.IsNullOrEmpty(rdoStatus.Code_no) Then
            rdo_Status = Server.HtmlEncode(rdoStatus.Code_no)
        End If
        If Not String.IsNullOrEmpty(rdoVerify.Code_no) Then
            rdo_Verify = Server.HtmlEncode(rdoVerify.Code_no)
        End If

        Dim result As Boolean = True
        If CarMain.CAR1103_update(ucCar_Type, Car_Name, Car_Id, rdo_Status, rdo_Verify, UnitItem, moduserid, moddate, modorg) = 1 Then
            'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改完成")
            result = True
        Else
            'CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改失敗")
            result = False
        End If
        Response.Redirect("~/CAR/CAR3/CAR3102_01.aspx?op=A&ucCarTypemaintain=" + HttpUtility.UrlEncode(ucCar_Type) + "&ddlCar_Namemaintain=" _
                          + HttpUtility.UrlEncode(Car_Name) + "&Car_Idmemaintain=" + HttpUtility.UrlEncode(Car_Id) _
                          + "&rdo_Statusmaintain=" + HttpUtility.UrlEncode(rdo_Status) + "&result=" + HttpUtility.UrlEncode(result))

    End Sub



    Protected Sub btnRight_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRight.Click
        Dim list As New System.Collections.Generic.List(Of ListItem)
        For Each item As ListItem In usedUnit1.Items
            If item.Selected Then
                If usedUnit2.Items.Count <= 0 Then
                    list.Add(item)

                ElseIf usedUnit2.Items.FindByValue("*") IsNot Nothing Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "已選全部單位")
                ElseIf usedUnit1.SelectedIndex = 0 Then
                    CommonFun.MsgShow(Page, CommonFun.Msg.Custom, "已有其他單位資料，不可再選擇全部單位，若要選擇，請先移除已選擇單位")
                Else
                    Dim had As Boolean = False
                    For Each sitem As ListItem In usedUnit2.Items
                        If item.Value = sitem.Value Then
                            had = True
                            Exit For
                        End If
                    Next
                    If Not had Then
                        list.Add(item)
                    End If
                End If
            End If
        Next
        For Each item As ListItem In list
            usedUnit2.Items.Add(item)
        Next
        usedUnit1.SelectedIndex = -1
        usedUnit2.SelectedIndex = -1

        'Dim a As Integer = 0
        'For i As Integer = 0 To (usedUnit1.Items.Count - 1)
        '    If usedUnit1.Items(i).Selected Then  '==判定哪一個子選項被點選了。
        '        usedUnit2.Items.Add(usedUnit1.Items(i).Text)

        '        a = a + 1
        '        usedUnit1.Items(i).Enabled = False


        '        '==被搬移走了，這個子選項就該移除！
        '        Exit For   '同C#的break             
        '        '** 重點！沒有這一段程式的話，中間的子選項被移走，就會報錯！
        '        '** 中間的子選項突然變少（臨時被移走），所以迴圈次數又少一個，因此報錯！
        '    End If
        'Next

    End Sub

    Protected Sub btnLeft_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLeft.Click
        Dim list As New System.Collections.Generic.List(Of ListItem)
        For Each item As ListItem In usedUnit2.Items
            If item.Selected Then
                list.Add(item)
            End If
        Next
        For Each item As ListItem In list
            usedUnit2.Items.Remove(item)
        Next
        usedUnit1.SelectedIndex = -1
        usedUnit2.SelectedIndex = -1

        'Dim a As Integer = 0
        'If usedUnit2.Items.Count = 0 Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已無子選項")
        'End If
        'For i As Integer = 0 To (usedUnit2.Items.Count - 1)
        '    If usedUnit2.Items(i).Selected Then  '==判定哪一個子選項被點選了。
        '        usedUnit1.Items(i).Enabled = True
        '        a = a + 1
        '        usedUnit2.Items.Remove(usedUnit2.Items(i).Text)
        '        'For Each item As ListItem In usedUnit2.Items
        '        '    UnitItem.a()
        '        'Next
        '        '==被搬移走了，這個子選項就該移除！
        '        Exit For   '同C#的break             
        '        '** 重點！沒有這一段程式的話，中間的子選項被移走，就會報錯！
        '        '** 中間的子選項突然變少（臨時被移走），所以迴圈次數又少一個，因此報錯！
        '    End If
        'Next
    End Sub


    Protected Sub BackBtn_Click(sender As Object, e As EventArgs) Handles BackBtn.Click
        Response.Redirect("CAR3102_01.aspx")
    End Sub
End Class
