Imports Microsoft.VisualBasic
Imports System.Data
Imports FSCPLM.Logic
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class ProcessPRO
        Inherits Process

        Public Overrides Sub RunAgreeFlow(ByVal flow As Flow)
            Dim Form_id As String = flow.FormId
            Dim code As New FSCPLM.Logic.SACode()
            '004001~004041 報廢
            If Form_id >= "004001" AndAlso Form_id <= "004041" Then
                Dim trDAO As New PRO_PropertyTran_detDAO
                Dim d As New Dictionary(Of String, Object)
                d.Add("OrgCode", flow.Orgcode)
                d.Add("Flow_id", flow.FlowId)
                Dim dt As DataTable = trDAO.GetDataByExample("PRO_PropertyScrap_main", d)
                Dim ds As New DataSet
                Dim dtNew As DataTable = ds.Tables.Add("dt")
                dtNew.Columns.Add(New DataColumn("MASTNO"))
                dtNew.Columns.Add(New DataColumn("FAKind"))
                dtNew.Columns.Add(New DataColumn("UpUser"))
                dtNew.Columns.Add(New DataColumn("DELDT"))
                dtNew.Columns.Add(New DataColumn("TRCAUSE"))

                For Each dr As DataRow In dt.Rows
                    Dim drNew As DataRow = dtNew.NewRow()
                    drNew("MASTNO") = dr("Property_id")
                    drNew("FAKind") = code.GetCodeDesc("016", "006", dr("Property_type").ToString())
                    drNew("UpUser") = dr("ModUser_id")
                    drNew("DELDT") = CommonFun.getYYYMMDD()
                    drNew("TRCAUSE") = dr("ScrapReason_type")
                    dtNew.Rows.Add(drNew)

                    Dim pr As New PRO_PropertyTran_det
                    pr.Add(flow.Orgcode, flow.FlowId, dr("Property_id").ToString, dr("Property_clsno").ToString, dr("Property_name").ToString, Nothing, _
                           Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, dr("Buy_date").ToString, _
                           dr("Property_type").ToString, Nothing, Nothing, dr("Scrap_date").ToString, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card), Now)
                Next

                'ds.Tables.Add(dtNew)

                Dim faClient As New FAService.WebService1SoapClient
                Dim reDS As DataSet = faClient.ScrapFA(ds)
                If Not reDS Is Nothing AndAlso reDS.Tables.Count > 0 Then
                    Dim reDT As DataTable = reDS.Tables(0)
                    If Not reDT Is Nothing AndAlso reDT.Rows.Count > 0 Then
                        Dim reDR As DataRow = reDT.Rows(0)
                        If Not reDR Is Nothing Then
                            'System.Diagnostics.Debug.WriteLine("{0}", reDR("Result"))
                            If Not String.IsNullOrEmpty(reDR("Msg")) Then
                                Throw New FlowException(reDR("Msg").ToString())
                            End If
                        End If
                    End If
                End If


                '004051~004087 移轉
            ElseIf Form_id >= "004051" AndAlso Form_id <= "004087" Then
                Dim trDAO As New PRO_PropertyTran_detDAO
                Dim d As New Dictionary(Of String, Object)
                d.Add("OrgCode", flow.Orgcode)
                d.Add("Flow_id", flow.FlowId)
                Dim dt As DataTable = trDAO.GetDataByExample("PRO_PropertyTran_det", d)
                Dim ds As New DataSet
                Dim dtNew As New DataTable
                dtNew.Columns.Add(New DataColumn("MASTNO"))
                dtNew.Columns.Add(New DataColumn("FAKind"))
                dtNew.Columns.Add(New DataColumn("UpUser"))
                dtNew.Columns.Add(New DataColumn("TRANSDT"))
                dtNew.Columns.Add(New DataColumn("DELDT"))
                dtNew.Columns.Add(New DataColumn("STOREROOM"))
                dtNew.Columns.Add(New DataColumn("ACCUSER"))
                dtNew.Columns.Add(New DataColumn("LOCATION"))

                For Each dr As DataRow In dt.Rows
                    Dim drNew As DataRow = dtNew.NewRow()
                    drNew("MASTNO") = dr("Property_id")
                    drNew("FAKind") = code.GetCodeDesc("016", "006", dr("Property_type").ToString())
                    drNew("UpUser") = dr("ModUser_id")
                    drNew("TRANSDT") = CommonFun.getYYYMMDD
                    drNew("DELDT") = ""
                    drNew("STOREROOM") = dr("NewUnit_code")
                    drNew("ACCUSER") = dr("NewKeeper_id")
                    drNew("LOCATION") = dr("NewLocation")
                    dtNew.Rows.Add(drNew)
                Next

                ds.Tables.Add(dtNew)

                Dim faClient As New FAService.WebService1SoapClient
                Dim reDS As DataSet = faClient.TransferFA(ds)
                If Not reDS Is Nothing AndAlso reDS.Tables.Count > 0 Then
                    Dim reDT As DataTable = reDS.Tables(0)
                    If Not reDT Is Nothing AndAlso reDT.Rows.Count > 0 Then
                        Dim reDR As DataRow = reDT.Rows(0)
                        If Not reDR Is Nothing Then
                            'System.Diagnostics.Debug.WriteLine("{0}", reDR("Result"))
                            If Not String.IsNullOrEmpty(reDR("Msg")) Then
                                Throw New FlowException(reDR("Msg").ToString())
                            End If
                        End If
                    End If
                End If
            ElseIf Form_id = "004091" Then '軟體轉移申請
                Dim bll As New PRO.Logic.PRO_SwRegister_Trans
                bll.OrgCode = flow.Orgcode
                bll.Flow_id = flow.FlowId
                bll.Trans_Allow_date = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd")
                bll.updateAllow_date()

                Dim dt As DataTable = New PRO.Logic.PRO_SwRegister_Trans().getDataByOrgFid(flow.Orgcode, flow.FlowId)
                For Each dr As DataRow In dt.Rows
                    bll = New PRO.Logic.PRO_SwRegister_Trans
                    bll.updateSWMain(flow.Orgcode, dr("SR_Flow_id").ToString(), dr("NewUnit_code").ToString(), dr("NewKeeper_id").ToString())
                Next
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