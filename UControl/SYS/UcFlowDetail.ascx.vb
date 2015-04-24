Imports System.Data
Imports System.Collections.Generic

Partial Class UControl_SYS_UcFlowDetail
    Inherits System.Web.UI.UserControl


    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(ByVal value As String)
            hfFlowId.Value = value
            Bind()
        End Set
    End Property


    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
        End Set
    End Property


    Protected Sub Bind()
        Dim f As New SYS.Logic.Flow()
        Dim fd As New SYS.Logic.FlowDetail()
        Dim code As New FSCPLM.Logic.SACode()

        Dim departId As String = ""
        Dim idCard As String = ""
        Dim formId As String = ""

        Dim fdt As DataTable = f.GetDataByOrgFid(hfOrgcode.Value, hfFlowId.Value)
        Dim fList As List(Of SYS.Logic.Flow) = CommonFun.ConvertToList(Of SYS.Logic.Flow)(fdt)
        If fList IsNot Nothing AndAlso fList.Count > 0 Then
            f = fList(0)
            departId = f.DepartId
            idCard = f.ApplyIdcard
            formId = f.FormId
        End If

        Dim ndt As New DataTable()
        ndt.Columns.Add("text", GetType(String))
        ndt.Columns.Add("agree_name", GetType(String))
        ndt.Columns.Add("agree_date", GetType(String))
        ndt.Columns.Add("agree_time", GetType(String))
        ndt.Columns.Add("agree_flag", GetType(String))
        ndt.Columns.Add("img_url", GetType(String))
        ndt.Columns.Add("img_url2", GetType(String))


        Dim r As DataRow = ndt.NewRow
        r("text") = "申請人"
        r("agree_name") = f.ApplyName & "(" & code.GetCodeDesc("023", "012", f.ApplyPosid) & ")"
        r("agree_date") = f.WriteTime.ToLongDateString()
        r("agree_time") = f.WriteTime.ToLongTimeString()
        r("img_url") = "~/images/FlowProcess/status1.png"
        r("img_url2") = "~/images/FlowProcess/sign1.png"
        ndt.Rows.Add(r)

        Dim outpostdt As DataTable = SYS.Logic.Outpost.GetFlowOutpost(hfOrgcode.Value, departId, idCard, formId)
        Dim detaildt As DataTable = fd.GetDataByFlow_id(hfOrgcode.Value, hfFlowId.Value)

        For i As Integer = 0 To outpostdt.Rows.Count - 1
            Dim ddr As DataRow = ndt.NewRow()
            Dim ndr As DataRow = ndt.NewRow()
            Dim dr As DataRow = outpostdt.Rows(i)

            If IsNotOverHours(f, dr("Hoursetting_id").ToString()) Then
                If i <> outpostdt.Rows.Count - 1 Then '非最後一關則送至最後一關
                    i = outpostdt.Rows.Count - 2
                End If
                Continue For
            End If

            Dim text As String = SYS.Logic.Outpost.GetOutpostIdNameWithHoursetting( _
                dr("Orgcode").ToString(), _
                "", _
                "", _
                dr("Outpost_id").ToString(), _
                dr("Outpost_orgcode").ToString(), _
                dr("Outpost_departid").ToString(), _
                dr("Outpost_posid").ToString(), _
                dr("Relate_flag").ToString(), _
                dr("Hoursetting_id").ToString())


            Dim agreeName As String = ""
            Dim agreeFlag As String = ""
            Dim agreeTime As String = ""
            Dim lastPass As String = ""
            Dim deputyFlag As String = ""
            Dim resendFlag As String = ""
            Dim comment As String = ""
            Dim agreeText As String = ""
            Dim disAgree As Boolean = False
            Dim isDelete As Boolean = False
            Dim img2 As String = "~/images/FlowProcess/status2.png"
            Dim img3 As String = "~/images/FlowProcess/status3.png"
            Dim sign1 As String = "~/images/FlowProcess/sign1.png"
            Dim sign2 As String = "~/images/FlowProcess/sign2.png"


            Dim detailRows() As DataRow = detaildt.Select(" agree_step=" & dr("outpost_seq").ToString())

            If detailRows IsNot Nothing AndAlso detailRows.Length > 0 Then

                ndr("img_url") = img2
                ndr("img_url2") = IIf(i <> outpostdt.Rows.Count - 1, sign1, "")

                For j As Integer = 0 To detailRows.Length - 1
                    If j <> 0 Then
                        ndr = ndt.NewRow()
                        ndr("text") = text
                        ndr("img_url") = img2
                        ndr("img_url2") = IIf(i <> outpostdt.Rows.Count - 1, sign1, "")
                    End If

                    Dim detailRow As DataRow = detailRows(j)

                    agreeTime = detailRow("Agree_time").ToString()
                    agreeName = detailRow("Last_name").ToString() & "(" & code.GetCodeDesc("023", "012", detailRow("Last_posid").ToString()) & ")"

                    agreeFlag = detailRow("Agree_flag").ToString()
                    lastPass = detailRow("Last_pass").ToString()
                    deputyFlag = detailRow("Deputy_flag").ToString()
                    comment = detailRow("Comment").ToString()
                    resendFlag = detailRow("Resend_flag").ToString()

                    If Not String.IsNullOrEmpty(detailRow("Replace_name").ToString()) Then
                        agreeName = detailRow("Replace_name").ToString() & "(" & code.GetCodeDesc("023", "012", detailRow("Replace_posid").ToString()) & ")" & "[<font color='red'>代</font>" & agreeName & "<font color='red'>批</font>]"
                    End If

                    If agreeFlag = "1" Then
                        disAgree = False
                        If lastPass = "1" Then
                            agreeText = "批示同意"
                        ElseIf deputyFlag = "1" Then
                            agreeText = "同意代理"
                        ElseIf resendFlag = "1" Then
                            agreeText = "重送"
                            disAgree = True
                        Else
                            agreeText = "核稿"
                        End If
                    ElseIf agreeFlag = "2" Then
                        agreeText = "不同意"
                        disAgree = True
                        ddr = ndt.NewRow()
                        ddr("text") = text
                        ddr("img_url") = img3
                        ddr("img_url2") = IIf(i <> outpostdt.Rows.Count - 1, sign2, "")
                        ddr("agree_name") = agreeName
                        ddr("agree_flag") = "(等待批核中)"
                    ElseIf agreeFlag = "4" Then
                        agreeText = "已刪除"
                        ndr("img_url2") = ""
                        isDelete = True
                    End If
                    If Not String.IsNullOrEmpty(comment) Then
                        agreeText &= ",意見:" & comment
                    End If

                    ndr("text") = IIf(resendFlag = "1" Or isDelete, "申請人", text)
                    ndr("agree_name") = agreeName
                    ndr("agree_date") = CType(agreeTime, Date).ToLongDateString()
                    ndr("agree_time") = CType(agreeTime, Date).ToLongTimeString()
                    ndr("agree_flag") = agreeText

                    ndt.Rows.Add(ndr)

                    If isDelete Then
                        Exit For
                    End If
                Next

                If disAgree Then
                    ndt.Rows.Add(ddr)
                End If

            Else

                ndr("text") = text
                ndr("img_url") = img3
                ndr("img_url2") = IIf(i <> outpostdt.Rows.Count - 1, sign2, "")
                ndr("agree_flag") = "(等待批核中)"

                ndt.Rows.Add(ndr)

            End If

            If isDelete Then
                Exit For
            End If
        Next

        If ndt IsNot Nothing AndAlso ndt.Rows.Count > 0 Then
            ndt.Rows(ndt.Rows.Count - 1)("img_url2") = ""
        End If

        dl.DataSource = ndt
        dl.DataBind()

    End Sub


#Region "跑時數限制條件"
    Protected Function IsNotOverHours(ByVal flow As SYS.Logic.Flow, ByVal hoursettingId As String) As Boolean

        '除人事之外不跑
        If "001" <> flow.FormId.Substring(0, 3) Then
            Return False
        End If

        Dim leaveHours As Integer = 0
        Dim leaveMain As New FSC.Logic.LeaveMain()
        Dim dt As DataTable = leaveMain.GetDataByOrgFid(flow.Orgcode, flow.FlowId)
        For Each dr As DataRow In dt.Rows
            leaveHours += CommonFun.getInt(dr("Leave_hours").ToString())
        Next

        '這個關卡有時數限制
        If Not String.IsNullOrEmpty(hoursettingId) Then
            Dim hoursText As String = New FSCPLM.Logic.SACode().GetCodeDesc("023", "006", hoursettingId)
            Dim hours As Integer = CType(Mid(hoursText, 2), Integer)

            If Mid(hoursText, 1, 1) <> ">" Then
                Return False
            End If

            'Select Case CType(Mid(hour_text, 2), Integer)    '限制時數
            '    Case 3
            '        hour = 0.3
            '    Case 7
            '        hour = 0.7
            '    Case 23
            '        hour = 3.0
            '    Case 55
            '        hour = 7.0
            'End Select

            If leaveHours <= hours Then
                Return True
            End If
        End If
        Return False
    End Function
#End Region

End Class
