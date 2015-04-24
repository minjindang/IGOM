Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class ProcessMAI
        Inherits Process

        Public Overrides Sub RunAgreeFlow(ByVal flow As Flow)

            If flow.FormId = "003007" Then
                '報修(第一類)
                Dim fd As New FlowDetail()
                Dim code As New FSCPLM.Logic.SACode()
                Dim main As New MAI.Logic.MaintainMain()
                Dim flowNextList As New List(Of SYS.Logic.FlowNext)

                main = main.GetObject(flow.Orgcode, flow.FlowId)


                Dim r As DataRow = code.GetRow("020", main.Maintain_kind, main.Maintain_type)

                If main.Maintain_step Is Nothing OrElse main.Maintain_step = 1 Then

                    If main.Maintain_step Is Nothing Then
                        main.Maintain_step = 0
                    Else
                        main.Maintain_step += 1
                    End If


                    Dim idCard As String = r("code_remark1").ToString()

                    Dim flowNext As New FlowNext()
                    flowNext.Orgcode = flow.Orgcode
                    flowNext.FlowId = flow.FlowId
                    flowNext.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                    flowNext.GroupId = 0
                    flowNext.GroupStep = "1"
                    Dim p As FSC.Logic.Personnel = New FSC.Logic.Personnel().GetObject(idCard)

                    If p IsNot Nothing Then
                        flowNext.NextOrgcode = flow.Orgcode
                        flowNext.NextDepartid = New FSC.Logic.DepartEmp().GetDepartId(idCard)
                        flowNext.NextIdcard = p.IdCard
                        flowNext.NextPosid = p.TitleNo
                        flowNext.NextName = p.UserName
                    Else
                        Throw New FlowException("查無負責承辦人 !")
                    End If
                    flowNext.NextStep = 99
                    flowNext.MailFlag = "1"
                    flowNext.ChangeDate = Now
                    flowNextList.Add(flowNext)

                ElseIf main.Maintain_step = 0 Then

                    main.Maintain_step += 1

                    Dim roleId As String = r("CODE_REMARK2").ToString()
                    Dim p As New FSC.Logic.Personnel()

                    Dim pdt As DataTable = p.GetDataByRoleId(flow.Orgcode, "", roleId)
                    For Each pdr As DataRow In pdt.Rows
                        Dim fn As New FlowNext()
                        fn.Orgcode = flow.Orgcode
                        fn.FlowId = flow.FlowId
                        fn.ReplaceFlag = "0"   '設定批核人員時,先把代批flag設為0
                        fn.GroupId = 0
                        fn.GroupStep = "1"

                        fn.NextOrgcode = pdr("orgcode").ToString()
                        fn.NextDepartid = pdr("depart_id").ToString()
                        fn.NextIdcard = pdr("id_card").ToString()
                        fn.NextPosid = pdr("title_no").ToString()
                        fn.NextName = pdr("user_name").ToString()

                        fn.NextStep = 99
                        fn.MailFlag = "1"
                        fn.ChangeDate = Now
                        flowNextList.Add(fn)
                    Next

                End If

                If main.Maintain_step IsNot Nothing AndAlso main.Maintain_step >= 0 AndAlso main.Maintain_step <= 2 Then

                    main.Update(main.Maintain_step, main.Id)

                    For Each FlowNext As FlowNext In flowNextList
                        If Not FlowNext.Insert() Then
                            Throw New FlowException("新增批核人員失敗!")
                        End If
                    Next
                    flow.UpdateLast(flow.Orgcode, flow.FlowId, flow.CaseStatus, "0", Now)
                    fd.CancelLastData(flow.Orgcode, flow.FlowId)
                End If

            End If

        End Sub

        Public Overrides Sub RunCancelFlow(ByVal flow As SYS.Logic.Flow)

        End Sub

        Public Overrides Sub RunDeleteFlow(ByVal flow As SYS.Logic.Flow)

        End Sub

        Public Overrides Sub RunRejectFlow(ByVal flow As SYS.Logic.Flow)

        End Sub
    End Class
End Namespace