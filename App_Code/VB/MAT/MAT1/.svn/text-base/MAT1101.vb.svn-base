Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Transactions

Namespace FSCPLM.Logic
    Public Class MAT1101

        Public AMMAO As ApplyMaterialMain
        Public AMDAO As ApplyMaterialDet
        Public MMDAO As Material_main
        Private _FlowID As String
        Public Property FlowId() As String
            Get
                Return _FlowID
            End Get
            Set(ByVal value As String)
                _FlowID = value
            End Set
        End Property

        Public Sub New()
            AMMAO = New ApplyMaterialMain()
            AMDAO = New ApplyMaterialDet()
            MMDAO = New Material_main()
        End Sub

        Public Function Update(Apply_date As String, Unit_Code As String, User_id As String, ModUser_id As String, OrgCode As String, flow_id As String, detail As DataTable) As String
            Dim msg As String = ""
            Dim reason As New StringBuilder()
            Me.FlowId = flow_id
            Dim isMore As Boolean = False

            '先檢查是否超過可用餘額
            Dim cnt As Integer = 0

            For Each dr As DataRow In detail.Rows
                Dim applyCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Apply_cnt")), 0, dr("Apply_cnt"))
                Dim outCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Out_cnt")), 0, dr("Out_cnt"))
                Dim materialID As String = CommonFun.SetDataRow(dr, "Material_id")

                Dim dtMaterial As DataTable = MMDAO.GetMaterial(materialID, materialID)
                If dtMaterial Is Nothing OrElse dtMaterial.Rows.Count = 0 Then
                    msg &= "找不到領物\n" & materialID
                ElseIf applyCnt <= 0 Then
                    msg &= String.Format("{0}領物,申請數量必須大於0\n", dtMaterial.Rows(0)("Material_name"))
                Else
                    Dim limitMM As Integer = dtMaterial.Rows(0)("PersonLimitMM_cnt")
                    Dim limit As Integer = dtMaterial.Rows(0)("PersonLimit_cnt")
                    Dim unit As String = dtMaterial.Rows(0)("Unit").ToString()
                    Dim mName As String = dtMaterial.Rows(0)("Material_name").ToString()
                    Dim Available_cnt As Integer = CommonFun.getInt(dtMaterial.Rows(0)("Available_cnt").ToString())
                    If Available_cnt - applyCnt <= 0 Then
                        msg &= String.Format("{0}領物，可用餘額不足\n", dtMaterial.Rows(0)("Material_name"))
                    End If

                    Dim startRoc As String = ""
                    Dim endRoc As String = CommonFun.getYYYMMDD()
                    If Now.AddMonths(-1 * limitMM).Year <> Now.Year Then '若有跨年度的情況,以本年度起算
                        startRoc = (Now.Year - 1911) & "0101"
                    Else
                        startRoc = (Now.Year - 1911) & Now.AddMonths(-1 * limitMM).Month.ToString().PadLeft(2, "0") & "01"
                    End If

                    Dim nowApplyCnt As Integer = AMDAO.GetApplyCnt(materialID, User_id, startRoc, endRoc)

                    If nowApplyCnt + applyCnt > limit Then
                        msg &= String.Format("{0}已超過個人申請限額({1}{2}/{3}月),已申請過{4}{5}，本次申請{6}台\n", mName, limit, unit, limitMM, nowApplyCnt, unit, applyCnt)
                    End If

                    If cnt = 5 Then
                        If isMore = False Then
                            reason.Append("more...")
                            isMore = True
                        End If
                    Else
                        reason.Append(mName).Append("*").Append(applyCnt).Append(unit).Append("<br/>")
                        cnt += 1
                    End If
                End If
            Next

            Dim f As SYS.Logic.Flow = New SYS.Logic.Flow().GetObject(OrgCode, flow_id)

            Using trans As New TransactionScope
                f.Reason = reason.ToString()
                f.CaseStatus = 2
                f.Update()

                AMDAO.DeleteByOrgFid(flow_id, OrgCode)
                AMMAO.DeleteByOrgFid(flow_id, OrgCode)

                For Each dr As DataRow In detail.Rows
                    Dim applyCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Apply_cnt")), 0, dr("Apply_cnt"))
                    Dim outCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Out_cnt")), 0, dr("Out_cnt"))
                    Dim materialID As String = CommonFun.SetDataRow(dr, "Material_id")
                    AMDAO.Insert(FlowId, CommonFun.SetDataRow(dr, "Material_id"), applyCnt, outCnt, _
                                    CommonFun.SetDataRow(dr, "Out_date"), CommonFun.SetDataRow(dr, "Memo"), ModUser_id, DateTime.Now, OrgCode)
                    MMDAO.updateAvailableCnt(applyCnt, materialID, OrgCode)
                Next
                AMMAO.Insert(FlowId, "001", Apply_date, Unit_Code, User_id, ModUser_id, DateTime.Now, OrgCode)
                Me.FlowId = FlowId
                trans.Complete()
            End Using

            Return msg
        End Function

        Public Function Insert(Apply_date As String, Unit_Code As String, User_id As String, ModUser_id As String, OrgCode As String, detail As DataTable) As String
            Dim msg As String = ""
            Dim reason As New StringBuilder()
            Dim isMore As Boolean = False

            Try
                '先檢查是否超過可用餘額
                Dim cnt As Integer = 0
                For Each dr As DataRow In detail.Rows
                    Dim applyCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Apply_cnt")), 0, dr("Apply_cnt"))
                    Dim outCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Out_cnt")), 0, dr("Out_cnt"))
                    Dim materialID As String = CommonFun.SetDataRow(dr, "Material_id")

                    Dim dtMaterial As DataTable = MMDAO.GetMaterial(materialID, materialID)
                    If dtMaterial Is Nothing OrElse dtMaterial.Rows.Count = 0 Then
                        msg &= "找不到領物\n" & materialID
                    ElseIf applyCnt <= 0 Then
                        msg &= String.Format("{0}領物,申請數量必須大於0\n", dtMaterial.Rows(0)("Material_name"))
                    Else
                        Dim limitMM As Integer = dtMaterial.Rows(0)("PersonLimitMM_cnt")
                        Dim limit As Integer = dtMaterial.Rows(0)("PersonLimit_cnt")
                        Dim unit As String = dtMaterial.Rows(0)("Unit").ToString()
                        Dim mName As String = dtMaterial.Rows(0)("Material_name").ToString()
                        Dim Available_cnt As Integer = CommonFun.getInt(dtMaterial.Rows(0)("Available_cnt").ToString())
                        If Available_cnt - applyCnt <= 0 Then
                            msg &= String.Format("{0}領物，可用餘額不足\n", dtMaterial.Rows(0)("Material_name"))
                        End If

                        Dim startRoc As String = ""
                        Dim endRoc As String = CommonFun.getYYYMMDD()
                        If Now.AddMonths(-1 * limitMM).Year <> Now.Year Then '若有跨年度的情況,以本年度起算
                            startRoc = (Now.Year - 1911) & "0101"
                        Else
                            startRoc = (Now.Year - 1911) & Now.AddMonths(-1 * limitMM).Month.ToString().PadLeft(2, "0") & "01"
                        End If

                        Dim nowApplyCnt As Integer = AMDAO.GetApplyCnt(materialID, User_id, startRoc, endRoc)
                        If nowApplyCnt + applyCnt > limit Then
                            msg &= String.Format("{0}已超過個人申請限額({1}{2}/{3}月),已申請過{4}{5}，本次申請{6}台\n", mName, limit, unit, limitMM, nowApplyCnt, unit, applyCnt)
                        End If

                        If cnt = 5 Then
                            If isMore = False Then
                                reason.Append("more...")
                                isMore = True
                            End If
                        Else
                            reason.Append(mName).Append("*").Append(applyCnt).Append(unit).Append("<br/>")
                            cnt += 1
                        End If
                    End If
                Next

                If Not String.IsNullOrEmpty(msg) Then
                    Return msg
                End If
                Dim flowID As String = String.Empty
           
                Using trans As New TransactionScope
                    Dim f As New SYS.Logic.Flow()
                    f.Orgcode = OrgCode
                    f.DepartId = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Depart_id)
                    f.ApplyPosid = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Title_no)
                    f.ApplyIdcard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
                    f.ApplyName = LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)
                    f.ApplyStype = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Service_type)
                    f.FormId = "003001"
                    f.FlowId = New SYS.Logic.FlowId().GetFlowId(OrgCode, f.FormId)
                    f.Reason = reason.ToString()
                    SYS.Logic.CommonFlow.AddFlow(f)

                    flowID = f.FlowId
                    For Each dr As DataRow In detail.Rows
                        Dim applyCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Apply_cnt")), 0, dr("Apply_cnt"))
                        Dim outCnt As Integer = IIf(String.IsNullOrEmpty(CommonFun.SetDataRow(dr, "Out_cnt")), 0, dr("Out_cnt"))
                        Dim materialID As String = CommonFun.SetDataRow(dr, "Material_id")
                        AMDAO.Insert(flowID, CommonFun.SetDataRow(dr, "Material_id"), applyCnt, outCnt, _
                                     CommonFun.SetDataRow(dr, "Out_date"), CommonFun.SetDataRow(dr, "Memo"), ModUser_id, DateTime.Now, OrgCode)
                        MMDAO.updateAvailableCnt(applyCnt, materialID, OrgCode)
                    Next
                    AMMAO.Insert(flowID, "001", Apply_date, Unit_Code, User_id, ModUser_id, DateTime.Now, OrgCode)
                    Me.FlowId = flowID
                    trans.Complete()
                End Using
            Catch ex As Exception
                msg = ex.Message
            End Try

            Return msg
        End Function

    End Class
End Namespace