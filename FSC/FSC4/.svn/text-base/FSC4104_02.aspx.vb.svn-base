Imports System.Data
Imports FSC.Logic

Partial Class FSC4104_02
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return
        DD_Create()
    End Sub

    Protected Sub DD_Create()
        Dim Year As String = Now.Year - 2 - 1911
        For i As Integer = 0 To 3
            DD_Year.Items.Add(Year + i)
        Next
        DD_Year.SelectedValue = Now.Year - 1911
    End Sub


    Protected Sub cbAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAdd.Click
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim Depart_id As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
        Dim yyy As String = DD_Year.SelectedValue()
        Dim pb02m As New CPAPB02M()
        Try
            Dim dt As DataTable = pb02m.getData(Orgcode, "", yyy)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "已有該年度行事曆資料!")
                Return
            End If

            Dim week() As String = {"日", "一", "二", "三", "四", "五", "六"}
            Dim year As Integer = CommonFun.getInt(yyy) + 1911
            Dim sdate As Date = New Date(year, 1, 1)
            Dim edate As Date = New Date(year, 12, 31)

            Do
                pb02m.Orgcode = Orgcode
                pb02m.DepartId = Depart_id
                pb02m.PBDDATE = DateTimeInfo.GetRocDate(sdate)
                pb02m.PBDWEEK = week(sdate.DayOfWeek)
                If sdate.DayOfWeek = 0 Or sdate.DayOfWeek = 6 Then
                    pb02m.PBDTYPE = 2
                Else
                    pb02m.PBDTYPE = 0
                End If
                pb02m.PBDDESC = ""
                pb02m.ChangeUserid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
                pb02m.insert()

                If sdate.Equals(edate) Then
                    Exit Do
                End If
                sdate = sdate.AddDays(1)
            Loop

            CommonFun.MsgShow(Me, CommonFun.Msg.InsertOK)

        Catch ex As Exception
            CommonFun.MsgShow(Me, CommonFun.Msg.InsertFail)
        End Try
    End Sub

    Protected Sub cbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCancel.Click
        Response.Redirect("FSC4104_01.aspx")
    End Sub
End Class
