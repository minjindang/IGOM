Imports System.Data

Partial Class UControl_SYS_UcNextName
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(ByVal value As String)
            hfOrgcode.Value = value
        End Set
    End Property
    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(ByVal value As String)
            hfFlowId.Value = value
        End Set
    End Property
    Public Property FormId() As String
        Get
            Return hfFormId.Value
        End Get
        Set(ByVal value As String)
            hfFormId.Value = value
        End Set
    End Property
    Public Property NextDepartName() As String
        Get
            Return hfNextDepartName.Value
        End Get
        Set(value As String)
            hfNextDepartName.Value = value
        End Set
    End Property
    Public Property NextName() As String
        Get
            Return hfNextName.Value
        End Get
        Set(ByVal value As String)
            hfNextName.Value = value
            SetNextName()
        End Set
    End Property
    Public Property LastPass() As String
        Get
            Return hfLastPass.Value
        End Get
        Set(ByVal value As String)
            hfLastPass.Value = value
        End Set
    End Property
    Public Property CaseStatus() As String
        Get
            Return hfCaseStatus.Value
        End Get
        Set(value As String)
            hfCaseStatus.Value = value
        End Set
    End Property
#End Region

    Public Sub SetNextName()
        Dim k As String = hfFormId.Value.Substring(0, 3)
        Dim t As String = hfFormId.Value.Substring(3)
        Dim payDate As String = ""
        lbNextName.Text = hfNextDepartName.Value & hfNextName.Value

        If hfCaseStatus.Value <> "1" Or hfLastPass.Value <> "1" Or k <> "002" Then
            Return
        End If

        Select Case t
            Case "001"  '加班費申請
                Dim fee As New SAL.Logic.OvertimeFeeMaster()
                Dim dt As DataTable = fee.getDataByFlowid(hfOrgcode.Value, hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If

                Dim labfee As New SAL.Logic.LabOvertimeFeeMaster()
                dt = labfee.getDataByFlowid(hfOrgcode.Value, hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "002"  '差旅費
                Dim fee As New SAL.Logic.SAL_OfficialoutFee()
                Dim dt As DataTable = fee.GetDataByOrgFid(hfOrgcode.Value, hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "003"  '短程車費
                Dim fee As New FSCPLM.Logic.SAL_TRAFFIC_FEE()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "004"  '值班費申請
                Dim fee As New FSCPLM.Logic.SAL_DUTY_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "005"  '子女教育補助津貼
                Dim fee As New FSCPLM.Logic.SAL_EDU_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "006"  '評審委員出席審查費、講師鐘點費申請作業
                Dim fee As New FSCPLM.Logic.SAL_EXAMINE_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "007"  '健檢補助費
                Dim fee As New FSCPLM.Logic.SAL_HealthSubsidy_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "008"  '未休假加班費-正式人員
                Dim fee As New FSCPLM.Logic.FSC_Settlement_Annual()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "009"  '替代役交通費
                Dim fee As New FSCPLM.Logic.SAL_TRANS_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "010"  '環保志工服務費
                Dim fee As New FSCPLM.Logic.SAL_VOL_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "011"  '結婚生育及喪葬補助費
                Dim fee As New FSCPLM.Logic.SAL_ALLOWANCE_fee()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, "", hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "012" Or "013"  '勞公健保繳納證明申請-技工工友
                Dim fee As New FSCPLM.Logic.SAL_PROOF_rpt()
                Dim dt As DataTable = fee.GetAll2(hfOrgcode.Value, hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
            Case "018"  '未休假加班費-技工工友司機
                Dim fee As New FSCPLM.Logic.FSC_Settlement_Annual()
                Dim dt As DataTable = fee.GetAll(hfOrgcode.Value, hfFlowId.Value)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    payDate = dt.Rows(0)("pay_date").ToString()
                End If
        End Select

        If Not String.IsNullOrEmpty(payDate) Then
            lbNextName.Text = "費用已於" & FSCPLM.Logic.DateTimeInfo.ToDisplay(payDate) & "撥付"
        Else
            lbNextName.Text = "已送秘書室撥款"
        End If
    End Sub
End Class
