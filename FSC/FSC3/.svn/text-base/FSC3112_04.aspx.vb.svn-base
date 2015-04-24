Imports System.Data
Imports FSCPLM.Logic
Imports Microsoft.Office.Interop

Partial Class FSC3112_04
    Inherits BaseWebForm

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    '備值人員
    Protected Function GetPreData(ByVal yymm As String) As String
        Dim Orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim mdt As DataTable = New FSC.Logic.FSC3112().GetDataByOnDutySex("1", "")
        Dim sb As New StringBuilder()
        Dim scheSetting As New FSC.Logic.ScheduleSetting()
        Dim sche As New FSC.Logic.Schedule()

        Dim dt As DataTable = sche.GetData(Orgcode)

        For Each dr As DataRow In dt.Rows
            Dim scheduleId As String = dr("schedule_id").ToString()
            Dim scheduleName As String = dr("name").ToString()

            sb.Append("(").Append(scheduleName).Append("): ")

            If scheduleId = "A00004" Or scheduleId = "A00005" Then
                '1.農曆過年, 先找上個月
                dt = scheSetting.GetMaxDataByScheId(Orgcode, yymm, scheduleId)

                If mdt Is Nothing OrElse mdt.Rows.Count <= 0 Then
                    '2.無資料, 找去年
                    yymm = (DateTimeInfo.GetPublicDate(yymm.Substring(0, 3) & "0101").AddYears(-1).Year - 1911).ToString().PadLeft(3, "0")
                    dt = scheSetting.GetMaxDataByScheId(Orgcode, yymm, scheduleId)
                End If

            End If

            Dim sdt As DataTable = scheSetting.GetMaxDataByScheId(Orgcode, yymm, scheduleId)

            For Each sdr As DataRow In sdt.Rows
                Dim i As Integer = 0
                For Each mdr As DataRow In mdt.Rows
                    If mdr("id_card").ToString() = sdr("id_card").ToString() Then
                        i += 1
                    End If

                    If i > 0 And i <= 2 Then
                        Dim departName As String = New FSC.Logic.DepartEmp().GetDepartName(Orgcode, mdr("id_card").ToString(), "1")
                        sb.Append(departName).Append(":")
                        sb.Append(mdr("User_name").ToString()).Append("&nbsp;")
                        i += 1
                    End If

                    If i > 2 Then
                        Exit For
                    End If
                Next
            Next

            sb.Append("<br/>")
        Next

        Return sb.ToString()
    End Function


End Class
