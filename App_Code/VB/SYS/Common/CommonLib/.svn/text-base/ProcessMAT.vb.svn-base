Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class ProcessMAT
        Inherits Process

        Public Overrides Sub RunAgreeFlow(ByVal flow As Flow)
            Dim Form_id As String = flow.FormId

            'If Form_id = "003001" OrElse Form_id = "003002" Then '個人領物 單位領物
            '    Dim applyDet As New FSCPLM.Logic.ApplyMaterialDet()

            '    If String.IsNullOrEmpty(flow.MergeFlowid) Then
            '        UpdateMaterialData(flow.Orgcode, flow.FlowId)
            '    Else
            '        Dim fdt As DataTable = flow.GetDataByOrgMergeFid(flow.Orgcode, flow.FlowId)
            '        For Each fdr As DataRow In fdt.Rows
            '            UpdateMaterialData(fdr("Orgcode").ToString(), fdr("Flow_id").ToString())
            '        Next
            '    End If

            'End If

            'flow.UpdateMAT_ApplyOutdateByMergeFid(flow.Orgcode, flow.FlowId)
        End Sub

        Public Overrides Sub RunCancelFlow(ByVal flow As SYS.Logic.Flow)

        End Sub

        Public Overrides Sub RunDeleteFlow(ByVal flow As SYS.Logic.Flow)

            If flow.FormId = "003001" Or flow.FlowId = "003002" Then
                Dim det As New FSCPLM.Logic.ApplyMaterialDet()
                Dim main As New FSCPLM.Logic.Material_main()
                Dim dt As DataTable = det.GetByFlow(flow.FlowId, flow.Orgcode)

                For Each dr As DataRow In dt.Rows
                    Dim mid As String = dr("Material_id").ToString()
                    Dim cnt As String = dr("Apply_cnt").ToString()
                    main.update3102AvailableCnt(cnt, mid, flow.Orgcode)
                Next

            End If

        End Sub

        Public Overrides Sub RunRejectFlow(ByVal flow As SYS.Logic.Flow)

        End Sub


        Protected Sub UpdateMaterialData(orgcode As String, flowId As String)
            Dim applyDet As New FSCPLM.Logic.ApplyMaterialDet()
            Dim main As New FSCPLM.Logic.Material_main()

            Dim dt As DataTable = applyDet.GetByFlow(flowId, orgcode)
            For Each dr As DataRow In dt.Rows
                If String.IsNullOrEmpty(dr("Out_date").ToString()) Then
                    '若未有 out_date

                    'update 領用數量
                    applyDet.UpdateOutCnt(dr("orgcode").ToString(), dr("flow_id").ToString(), dr("Apply_cnt").ToString(), dr("material_id").ToString())

                    'update 可用餘額 Available_cnt 庫存量 Reserve_cnt
                    main.updateAvailableCntReserveCnt(dr("Apply_cnt").ToString(), dr("Apply_cnt").ToString(), dr("material_id").ToString(), dr("orgcode").ToString())
                End If
            Next

        End Sub
    End Class
End Namespace