Imports FSC.Logic
Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.Office.Interop
Imports System.IO
Imports NLog

Partial Class FSC2129_01
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If
        Bind()
    End Sub

    Protected Sub Bind()
        Dim idCard As String = LoginManager.UserId
        Dim yyy As String = (Now.Year - 1911).ToString().PadLeft(3, "0")
        Dim orgcode As String = LoginManager.OrgCode
        Dim departId As String = New FSC.Logic.DepartEmp().GetDepartId(idCard)
        Dim bll As New FSC.Logic.FSC2129()

        Dim p As New FSC.Logic.Personnel()
        p = p.GetObject(idCard)

        If p IsNot Nothing Then

            lbId_card.Text = idCard
            lbUser_name.Text = p.UserName
            lbDepart_name.Text = New FSC.Logic.Org().GetDepartNameWithoutSubDepart(orgcode, departId)
            lbEmployee_type.Text = New SYS.Logic.CODE().GetDataDESC("023", "022", p.EmployeeType)

            lbPEHDAY.Text = p.Pehday
            lbPERDAY1.Text = p.Perday1
            lbPERDAY2.Text = p.Perday2
            lbPEHDAY2.Text = p.Pehday2
            lbPEHDAY3.Text = p.Pehday3

        End If

        Dim dt As DataTable = bll.GetData(orgcode, idCard, yyy)
        If dt IsNot Nothing And dt.Rows.Count > 0 Then
            Dim dr As DataRow = dt.Rows(0)

            lb05.Text = Content.ConvertDayHours(dr("L05").ToString())
            lb01.Text = Content.ConvertDayHours(dr("L01").ToString())
            lb25.Text = Content.ConvertDayHours(dr("L25").ToString())
            lb02.Text = Content.ConvertDayHours(dr("L02").ToString())
            lb24.Text = Content.ConvertDayHours(dr("L24").ToString())
            lb08.Text = Content.ConvertDayHours(dr("L08").ToString())
            lb21.Text = Content.ConvertDayHours(dr("L21").ToString())
            lb09.Text = Content.ConvertDayHours(dr("L09").ToString())
            lb13.Text = Content.ConvertDayHours(dr("L13").ToString())
            lb22.Text = Content.ConvertDayHours(dr("L22").ToString())
            lb03_0.Text = Content.ConvertDayHours(dr("L03_0").ToString())
            lb03_1.Text = Content.ConvertDayHours(dr("L03_1").ToString())
            lb10.Text = Content.ConvertDayHours(dr("L10").ToString())
            lb04.Text = Content.ConvertDayHours(dr("L04").ToString())
            lb20.Text = Content.ConvertDayHours(dr("L20").ToString())
            lb32.Text = Content.ConvertDayHours(dr("L32").ToString())
            lb06.Text = Content.ConvertDayHours(dr("L06").ToString())
            lb18.Text = Content.ConvertDayHours(dr("L18").ToString())
            lb23.Text = Content.ConvertDayHours(dr("L23").ToString())


        End If


    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Response.Redirect("FSC2103_01.aspx")
    End Sub
End Class
