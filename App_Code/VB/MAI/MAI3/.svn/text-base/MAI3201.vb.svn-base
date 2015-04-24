Imports Microsoft.VisualBasic

Imports System.Data
Imports System.Transactions
Imports System.IO

Namespace FSCPLM.Logic

    Public Class MAI3201 

        Dim emdDAO As ElecMaintain_det
        Dim emmDAO As ElecMaintain_main
        Dim DAO As MAI3201DAO
        Dim saDAO As SACode

        Dim mDAO As MaintainerMain

        Public Sub New()
            emdDAO = New ElecMaintain_det()
            emmDAO = New ElecMaintain_main()
            DAO = New MAI3201DAO()
            saDAO = New SACode()
            mDAO = New MaintainerMain
        End Sub

        Public Function GetUnitCode() As DataTable
            Return DAO.SelectUnitCode()
        End Function

        Public Function GetByMaintain_type(orgCode As String) As DataTable
            Return mDAO.GetByMaintain_type("001", orgCode)
        End Function

        Private Function CheckCount(OrgCode As String, Flow_id As String) As Boolean
            Return DAO.SelectStatusNot003Count(OrgCode, Flow_id) > 0
        End Function

        Public Function Done(OrgCode As String, Flow_id As String, MtClass_type As String, _
                        maintainerName As String, maintainerPhone_nos As String, MtStatus_type As String, MtStatus_desc As String, _
                        CaseClose_type As String) As String
            Dim result As String = String.Empty
            '必須檢查同筆申請單下其他報修類別是否也都處理完成(處理情形為完成)，
            If "Y" = CaseClose_type Then
                If CheckCount(OrgCode, Flow_id) Then
                    result = "尚有未完成之報修項目"
                End If

            End If

            If String.IsNullOrEmpty(result) Then
                '001 待維修
                '002 處理中 更新MtStartTime
                '003 005 006 更新EndTime , 更新處理時數(開始維修時間與完成維修時間 相減。 單位為小時, 小數點下2位) ,自動結案(CaseCkise_type = Y) 
                '004 待料中 TODO : Send Mail
                Select Case MtStatus_type
                    Case "001"
                        Update001(OrgCode, Flow_id, MtClass_type, maintainerName)
                    Case "002"
                        Update002(OrgCode, Flow_id, MtClass_type, maintainerName, maintainerPhone_nos, MtStatus_desc)
                    Case "004"
                        'TODO : Send Mail
                    Case Else
                        Update00356(OrgCode, Flow_id, MtClass_type, maintainerName, maintainerPhone_nos, MtStatus_type, MtStatus_desc)

                        '結案流程
                        'Dim f As New Flow()
                        'f.Flow_id = Flow_id
                        'f.Orgcode = OrgCode
                        'f.Case_status = 1
                        'f.UpdateFlowLastStatus()

                End Select

            End If

            Return result
        End Function

        Private Sub Update001(OrgCode As String, Flow_id As String, MtClass_type As String, MtStatus_desc As String)
            emdDAO.Modify(Flow_id, MtClass_type, OrgCode, "", "", "", "", DateTime.MinValue, DateTime.MinValue, 0, _
                          "", "", "001", MtStatus_desc, "", LoginManager.UserId, Now)
        End Sub

        Private Sub Update002(OrgCode As String, Flow_id As String, MtClass_type As String, _
                              maintainerName As String, maintainerPhone_nos As String, MtStatus_desc As String)
            emdDAO.Modify(Flow_id, MtClass_type, OrgCode, "", "", "", "", Now, DateTime.MinValue, 0, _
                          maintainerPhone_nos, maintainerName, "002", MtStatus_desc, "", LoginManager.UserId, Now)
        End Sub

        Private Sub Update00356(OrgCode As String, Flow_id As String, MtClass_type As String, _
                              maintainerName As String, maintainerPhone_nos As String, MtStatus_type As String, MtStatus_desc As String)
            Dim dr As DataRow = emdDAO.GetOne(Flow_id, MtClass_type, OrgCode)

            Dim mtStartTime As DateTime = IIf(TypeOf (CommonFun.SetDataRow(dr, "MtStartTime")) Is System.String, Now, CommonFun.SetDataRow(dr, "MtStartTime"))

            Dim mtTime As Double = Math.Abs(DateDiff(DateInterval.Hour, Now, mtStartTime))

            emdDAO.Modify(Flow_id, MtClass_type, OrgCode, "", "", "", "", DateTime.MinValue, Now, mtTime, _
                          maintainerPhone_nos, maintainerName, MtStatus_type, MtStatus_desc, "", LoginManager.UserId, Now)
            emmDAO.Modify(Flow_id, OrgCode, "", "", "", "", DateTime.MinValue, "", "", "Y", LoginManager.UserId, Now)
        End Sub

        Public Sub GetOne(flow_id As String, MtClass_type As String, ByRef detDR As DataRow, ByRef mainDR As DataRow)

            mainDR = emmDAO.GetOne(flow_id, LoginManager.OrgCode)
            detDR = emdDAO.GetOne(flow_id, MtClass_type, LoginManager.OrgCode)

            If detDR IsNot Nothing Then
                detDR("MtClass_type") = saDAO.GetCodeDesc("019", "008", CommonFun.SetDataRow(detDR, "MtClass_type"))

                detDR("ElecExpect_type") = saDAO.GetCodeDesc("019", "005", CommonFun.SetDataRow(detDR, "ElecExpect_type"))
            End If
        End Sub

        Public Function GetBy(MtClass_type As String, MtItemOther_desc As String, ApplyTimeS As DateTime, ApplyTimeE As DateTime, _
                                 Unit_code As String, Phone_nos As String, MtStatus_type As String) As DataTable
            Dim dt As DataTable = DAO.SelectBy(MtClass_type, MtItemOther_desc, ApplyTimeS, ApplyTimeE, _
                                                Unit_code, Phone_nos, MtStatus_type)
            Dim resultDT As New DataTable

            resultDT.Columns.Add(New DataColumn("Flow_id"))
            resultDT.Columns.Add(New DataColumn("User_name"))
            resultDT.Columns.Add(New DataColumn("ApplyTime"))
            resultDT.Columns.Add(New DataColumn("MtClass_type"))
            resultDT.Columns.Add(New DataColumn("MtClass_typeName"))
            resultDT.Columns.Add(New DataColumn("Problem_desc"))
            resultDT.Columns.Add(New DataColumn("Maintainer"))
            resultDT.Columns.Add(New DataColumn("MtStatus_type"))
            resultDT.Columns.Add(New DataColumn("CaseClose_type"))

            For Each dr As DataRow In dt.Rows
                Dim applyTime As DateTime = dr("ApplyTime")
                Dim newDR As DataRow = resultDT.NewRow()
                newDR("Flow_id") = CommonFun.SetDataRow(dr, "Flow_id")
                newDR("User_name") = CommonFun.SetDataRow(dr, "User_name")
                newDR("ApplyTime") = String.Format("{0}/{1}/{2}", applyTime.Year - 1911, applyTime.Month, applyTime.Day)
                newDR("MtClass_type") = CommonFun.SetDataRow(dr, "MtClass_type")
                newDR("MtClass_typeName") = saDAO.GetCodeDesc("019", "008", CommonFun.SetDataRow(dr, "MtClass_type"))
                newDR("Problem_desc") = CommonFun.SetDataRow(dr, "Problem_desc")
                newDR("Maintainer") = CommonFun.SetDataRow(dr, "Maintainer_name") + " " + CommonFun.SetDataRow(dr, "MaintainerPhone_nos")
                newDR("MtStatus_type") = saDAO.GetCodeDesc("019", "006", CommonFun.SetDataRow(dr, "MtStatus_type"))
                newDR("CaseClose_type") = IIf(CommonFun.SetDataRow(dr, "CaseClose_type") = "Y", "結案", "未結案")
                resultDT.Rows.Add(newDR)
            Next

            Return resultDT

        End Function

    End Class
End Namespace
