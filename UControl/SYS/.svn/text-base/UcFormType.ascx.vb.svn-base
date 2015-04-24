Imports System.Data

Partial Class UControl_SYS_UcFormKind
    Inherits System.Web.UI.UserControl

#Region "Property"
    Public Property FlowId() As String
        Get
            Return hfFlowId.Value
        End Get
        Set(value As String)
            hfFlowId.Value = value
            SetName()
        End Set
    End Property

    Public Property Orgcode() As String
        Get
            Return hfOrgcode.Value
        End Get
        Set(value As String)
            hfOrgcode.Value = value
        End Set
    End Property

    Public Property FormId() As String
        Get
            Return hfFormId.Value
        End Get
        Set(value As String)
            hfFormId.Value = value
            SetName()
        End Set
    End Property

    Public Property NextStep() As String
        Get
            Return hfNextStep.Value
        End Get
        Set(value As String)
            hfNextStep.Value = value
            SetStep()
        End Set
    End Property
#End Region

    Public Sub SetName()
        Dim orgcode As String = hfOrgcode.Value
        Dim flowId As String = hfFlowId.Value
        Dim formId As String = hfFormId.Value
        Dim name As String = ""
        Dim url As String = ""

        Dim code As New FSCPLM.Logic.SACode()
        Dim r As DataRow = Nothing

        If "" <> flowId AndAlso "" <> formId AndAlso formId.Length >= 6 Then
            r = code.GetRow("024", formId.Substring(0, 3), formId.Substring(3))
        End If

        If String.IsNullOrEmpty(lbFormType.Text) And r IsNot Nothing Then

            If "001" = formId.Substring(0, 3) And Not String.IsNullOrEmpty(r("code_desc2").ToString()) Then
                Dim leaveType As String = ""
                Dim lm As New FSC.Logic.LeaveMain()
                Dim lt As New SYS.Logic.LeaveType()
                Dim dt As DataTable = lm.GetDataByOrgFid(orgcode, flowId)
                If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                    leaveType = dt.Rows(0)("Leave_type").ToString()
                End If
                name = lt.GetLeaveName(leaveType)
            Else
                name = r("code_desc1").ToString()
            End If

            lbFormType.Text = name

            If "002001" = formId Then

                Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(orgcode, flowId)
                Dim employeeType As String = New FSC.Logic.Personnel().GetColumnValue("employee_type", f.ApplyIdcard)

                If employeeType <> "1" _
                    And employeeType <> "6" _
                    And employeeType <> "7" _
                    And employeeType <> "9" _
                    And employeeType <> "11" _
                    And employeeType <> "13" Then '2,3,4,5,8,10,12,14,15

                    url = r("CODE_REMARK1").ToString().Split(",")(1)
                Else
                    url = r("CODE_REMARK1").ToString().Split(",")(0)
                End If

            Else
                url = r("CODE_REMARK1").ToString()
            End If


            If Not String.IsNullOrEmpty(url) Then
                lbFormType.PostBackUrl = url & "?org=" & orgcode & "&fid=" & flowId
            Else
                lbFormType.Attributes("href") = ""
                lbFormType.OnClientClick = "return false;"
                lbFormType.Style("cursor") = "default"
                lbFormType.CssClass = "noLink"
            End If
        End If
    End Sub

    Public Sub SetStep()
        Dim nextStep As String = hfNextStep.Value
        If Not String.IsNullOrEmpty(nextStep) And Not String.IsNullOrEmpty(lbFormType.PostBackUrl) Then
            lbFormType.PostBackUrl = lbFormType.PostBackUrl & "&step=" & nextStep
        End If
    End Sub

    Protected Sub lbFormType_Click(sender As Object, e As EventArgs)
        Dim orgcode As String = hfOrgcode.Value
        Dim flowId As String = hfFlowId.Value
        Dim formId As String = hfFormId.Value
        Dim nextStep As String = hfNextStep.Value
        Dim k As String = formId.Substring(0, 3)
        Dim t As String = formId.Substring(3)
        Dim code As New FSCPLM.Logic.SACode()
        Dim r As DataRow = code.GetRow("024", k, t)
        Dim url As String = r("CODE_REMARK1").ToString()

        If Not String.IsNullOrEmpty(url) Then
            Response.Redirect(url & "?org=" & orgcode & "&fid=" & flowId & "&step=" & nextStep)
        End If
    End Sub
End Class
