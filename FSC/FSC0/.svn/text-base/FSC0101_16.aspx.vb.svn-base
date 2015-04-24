Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0101_16
    Inherits BaseWebForm

    Dim fd As New SYS.Logic.FlowDetail()
    Dim bll As New FSC.Logic.FSC0101()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        Bind()
    End Sub

    Protected Sub Bind()
        Dim flowId As String = Request.QueryString("fId")
        Dim orgcode As String = Request.QueryString("org")
        Dim flow As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)
        Dim fdList As List(Of SYS.Logic.FlowDetail) = CommonFun.ConvertToList(Of SYS.Logic.FlowDetail)(fd.GetDataByFlow_id(orgcode, flowId))

        UcFlowDetail.Orgcode = orgcode
        UcFlowDetail.FlowId = flowId

        Me.lbFlow_id.Text = flowId
        Me.lbApply_name.Text = GetMemberInfo(flow.Orgcode, flow.DepartId, flow.ApplyPosid, flow.ApplyName)
        Me.lbWrite_name.Text = GetMemberInfo(flow.WriterOrgcode, flow.WriterDepartid, flow.WriterPosid, flow.WriterName)
        Me.lbWrite_time.Text = flow.WriteTime

        For Each fdetail As SYS.Logic.FlowDetail In fdList
            Me.lbAgree_time.Text = fdetail.AgreeTime
        Next

        Dim dtData As DataTable = bll.GetDutyChangeData(flowId, orgcode)
        If dtData.Rows.Count > 0 Then
            For Each dr As DataRow In dtData.Rows
                If dr("Duty_type").ToString().Trim = "1" Then
                    lbDuty_type.Text = "代值"
                Else
                    lbDuty_type.Text = "換值"
                End If
                lbApply_Username.Text = dr("Apply_Username").ToString()
                lbShift_Username.Text = dr("Shift_Username").ToString()
                lbOriginal_Dutydate.Text = dr("Original_Dutydate").ToString()
                lbShift_Dutydate.Text = dr("Shift_Dutydate").ToString()
                lbSchedule_Name.Text = dr("Schedule_Name").ToString()
                lbShift_Schedule_Name.Text = dr("Shift_Schedule_Name").ToString()
                lbDuty_reason.Text = dr("Duty_reason").ToString()
            Next
        End If
    End Sub

    ''' <summary>
    ''' 取得人員職稱
    ''' </summary>
    ''' <param name="Orgcode">機關代碼</param>
    ''' <param name="Depart_id">單位代碼</param>
    ''' <param name="Apply_posid">申請代碼</param>
    ''' <param name="User_name">申請人</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMemberInfo(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Apply_posid As String, ByVal User_name As String) As String
        Dim name As New StringBuilder
        Dim org As New FSC.Logic.Org()
        Dim code As New FSCPLM.Logic.SACode()

        name.Append(org.GetDepartName(Orgcode, Depart_id))
        name.Append("：")
        name.Append("(" & code.GetCodeDesc("023", "012", Apply_posid) & ")")
        name.Append(User_name)

        Return name.ToString()
    End Function

    ''' <summary>
    ''' 回上頁
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub cbBack_Click(sender As Object, e As EventArgs)
        Dim url As String = ViewState("BackUrl")
        Response.Redirect(url)
    End Sub

End Class
