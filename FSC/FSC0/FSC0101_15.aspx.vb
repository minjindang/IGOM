Imports FSCPLM.Logic
Imports System.Data
Imports System.Data.SqlClient
Imports CommonLib
Imports System.Collections.Generic

Partial Class FSC0101_15
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

        Me.lbFlow_id.Text = flowId
        Me.lbApply_name.Text = GetMemberInfo(flow.Orgcode, flow.DepartId, flow.ApplyPosid, flow.ApplyName)
        Me.lbWrite_name.Text = GetMemberInfo(flow.WriterOrgcode, flow.WriterDepartid, flow.WriterPosid, flow.WriterName)
        Me.lbWrite_time.Text = flow.WriteTime

        For Each fdetail As SYS.Logic.FlowDetail In fdList
            Me.lbAgree_time.Text = fdetail.AgreeTime
        Next

        UcFlowDetail.Orgcode = orgcode
        UcFlowDetail.FlowId = flowId

        Dim dtData As DataTable = bll.GetRewordMainData(flowId, orgcode)
        If dtData.Rows.Count > 0 Then
            For Each dr As DataRow In dtData.Rows
               
                lbDepart_name.Text = dr("Depart_name").ToString()
                lbApply_date.Text = dr("Apply_date").ToString()
                lbReason.Text = dr("Reason").ToString()

                If dr("Reason_type").ToString().Trim = "1" Then
                    lbReason_type.Text = " 依「行政院環境保護署所屬人員提報敘獎原則」"
                    lbReason_type.Text &= "第" + dr("Reason_point").ToString() + "點"
                    lbReason_type.Text &= "第" + dr("Reason_section").ToString() + "項"
                    lbReason_type.Text &= "第" + dr("Reason_item").ToString() + "款"
                    lbReason_type.Text &= "第" + dr("Reason_list").ToString() + "目"
                    lbReason_type.Text &= "規定辦理。"
                Else
                    lbReason_type.Text = "其他〈相關法令、計畫或評比定有明確獎勵標準者，請檢附相關規定並敘明〉。"
                End If

                lbSelf_ssessment_point.Text = dr("Self_ssessment_point").ToString()
                lbLast_point.Text = dr("Last_point").ToString()
                lbLast_datereason.Text = dr("Last_datereason").ToString()

                lbInput_manpower.Text = dr("Input_manpower").ToString()
                If dr("Input_manpower_type").ToString().Trim = "1" Then
                    lbInput_manpower_type.Text = "自辦"
                Else
                    lbInput_manpower_type.Text = "委辦〈請說明分工項目，例：場地佈置委由廠商辦理，餘自辦〉備註說明：" + dr("Input_manpower_note").ToString()
                End If

                lbInput_sdate.Text = dr("Input_sdate").ToString()
                lbInput_edate.Text = dr("Input_edate").ToString()
                If dr("input_conform").ToString().Trim = "1" Then
                    lbinput_notconform.Text = "符合〈敘獎原則第五點〉"
                Else
                    lbinput_notconform.Text = "未符合〈請敘明理由〉理由：" + dr("input_notconform_reason").ToString()
                End If

                lbInnovative_desc.Text = dr("Innovative_desc").ToString()
                lbDifficulty_desc.Text = dr("Difficulty_desc").ToString()
                lbContribution_desc.Text = dr("Contribution_desc").ToString()

            Next

            gv.DataSource = bll.GetRewordDetailData(flowId, orgcode)
            gv.DataBind()
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
