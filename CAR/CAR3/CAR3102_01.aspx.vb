Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Partial Class CAR_CAR3_CAR3102_01
    Inherits BaseWebForm

    Dim carDT As DataTable
    Dim carMain As New Car_main

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlCarId.Enabled = False
            rdoStatus.Code_no = "001"

            Dim DT = carMain.GetcarId("")
            ddlCarId.DataSource = DT
            ddlCarId.DataTextField = "Car_id"
            ddlCarId.DataValueField = "Car_id"
            ddlCarId.DataBind()
            ddlCarId.Enabled = True
            ddlCarId.Items.Insert(0, New ListItem("請選擇車輛代號", ""))

            If Not String.IsNullOrEmpty(Request("ucCarTypemaintain")) And Not String.IsNullOrEmpty(Request("ddlCar_Namemaintain")) And _
               Not String.IsNullOrEmpty(Request("Car_Idmemaintain")) And Not String.IsNullOrEmpty(Request("rdo_Statusmaintain")) Then

                ucCarType.Code_no = HttpUtility.UrlDecode(Request("ucCarTypemaintain").ToString())
                ddlCarName.Items.Clear()
                ddlCarName.Items.Add((HttpUtility.UrlDecode(Request("ddlCar_Namemaintain").ToString())))

                ddlCarId.Enabled = True
                ddlCarId.Items.Clear()
                ddlCarId.Items.Add((HttpUtility.UrlDecode(Request("Car_Idmemaintain").ToString())))
                rdoStatus.Code_no = HttpUtility.UrlDecode(Request("rdo_Statusmaintain").ToString())
                newUpdate()

            End If

            If Not String.IsNullOrEmpty(Request("result")) Then
                If Convert.ToBoolean(Request("result")) Then
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改完成")
                Else
                    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "修改失敗")
                End If
            End If
        End If
    End Sub

    Protected Sub newCarName()
        carDT = carMain.GetcarName(LoginManager.OrgCode, ucCarType.Code_no)
        ddlCarName.DataSource = carDT
        ddlCarName.DataTextField = "Car_name"
        ddlCarName.DataValueField = "Car_name"
        ddlCarName.DataBind()
        ddlCarName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlCarName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCarName.SelectedIndexChanged
        Dim DT = carMain.GetcarId(ddlCarName.SelectedValue)
        ddlCarId.DataSource = DT
        ddlCarId.DataTextField = "Car_id"
        ddlCarId.DataValueField = "Car_id"
        ddlCarId.DataBind()
        ddlCarId.Enabled = True
        ddlCarId.Items.Insert(0, New ListItem("請選擇車輛代號", ""))
    End Sub

    Protected Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        ucCarType.Code_no = "001"
        ddlCarName.SelectedIndex = "0"
        ddlCarId.Items.Insert(0, New ListItem("請選擇車輛代號", ""))
        ddlCarId.SelectedIndex = "0"
        ddlCarId.Enabled = False
        rdoStatus.Code_no = "001"
        div1.Visible = False
    End Sub

    Protected Sub SelectBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectBtn.Click
        Dim db As DataTable = New DataTable
        Dim CarMain As Car_main = New Car_main
        Dim ucCar_Type As String = ucCarType.Code_no
        Dim ddlCar_Name As String = ddlCarName.SelectedValue
        Dim ddlCar_Id As String = ddlCarId.SelectedValue
        Dim rdo_Status As String = rdoStatus.Code_no
 
        db = CarMain.CAR1103_SELECT(ucCar_Type, ddlCar_Name, ddlCar_Id, rdo_Status)

        Dim org As New FSC.Logic.Org()
        Dim dt As DataTable = org.GetDataByParentDepartid(LoginManager.OrgCode, "")

        For Each dr As DataRow In db.Rows
            If dr("UsedUnit_code").ToString().Contains("*") Then
                dr("UsedUnit_code") = "全部單位"
            Else
                Dim UsedUnit_codeAry() As String = dr("UsedUnit_code").ToString().Split(",")
                Dim newUsedUnit_code As String = ""
                For Each s As String In UsedUnit_codeAry
                    Dim drARY() As DataRow = dt.Select(String.Format("Depart_id = '{0}'", s))
                    If drARY.Length > 0 Then
                        newUsedUnit_code &= drARY(0)("Depart_name") & ","
                    End If

                Next

                dr("UsedUnit_code") = newUsedUnit_code.TrimEnd(",")
            End If

           
        Next

        db.AcceptChanges()

        Me.GridViewA.DataSource = db
        Me.GridViewA.DataBind()
        div1.Visible = True
    End Sub

    Protected Sub GridViewA_RowCommand(ByVal sender As Object, _
                                        ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridViewA.RowCommand
        If e.CommandName = "editor" Then
            Dim tb1 As String = e.CommandArgument
            Response.Redirect("~/CAR/CAR3/CAR3102_02.aspx?tb1=" + tb1)
        End If
    End Sub

    Protected Sub newUpdate()
        'Dim db As DataTable = New DataTable
        'Dim CarMain As Car_main = New Car_main


        ''db = CarMain.getAll(ddlCarId.SelectedValue)
        'db = CarMain.CAR1103_SELECT("", "", ddlCarId.SelectedValue, "")

        'Me.GridViewA.DataSource = db
        'Me.GridViewA.DataBind()
        SelectBtn_Click(Nothing, Nothing)
        div1.Visible = True
    End Sub

    Protected Sub ucCarType_CodeChanged(sender As Object, e As EventArgs)
        newCarName()
    End Sub

End Class
