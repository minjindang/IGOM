
Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic

    Public Class MAI1103
        Public SMDAO As SwMaintainMain
        Public MTDAO As MaintainerMain
        Public SADAO As SACode
        Public MBDAO As Member

        Public Sub New()
            SMDAO = New SwMaintainMain()
            MTDAO = New MaintainerMain()
            SADAO = New SACode()
            MBDAO = New Member()
        End Sub

        Public Function GetOne(orgCode As String, swCode As String) As DataRow
            Return SMDAO.GetOne(orgCode, swCode)
        End Function

        Public Function GetAll(MtClass_type As String, ApplyTimeS As String, ApplyTimeE As String, Phone_nos As String, Unit_code As String, User_id As String, _
                             MtStatus_type As String, ServApply_type As String, orgCode As String) As DataTable
            Dim atS As DateTime = New DateTime(1911, 1, 1)
            Dim atE As DateTime = New DateTime(1911, 1, 1)
            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                atS = CommonFun.getYYYMMDD(ApplyTimeS)
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                atE = CommonFun.getYYYMMDD(ApplyTimeE)
            End If

            Dim dt As DataTable = SMDAO.GetAll(MtClass_type, atS, atE, Phone_nos, Unit_code, User_id, MtStatus_type, ServApply_type, orgCode)

            dt.Columns.Add(New DataColumn("Index"))
            dt.Columns.Add(New DataColumn("ApplyTimeString"))

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    dt.Rows(i)("Index") = i + 1
                    'dt.Rows(i)("Unit_code") = ""
                    'dt.Rows(i)("User_id") = "" 
                    dt.Rows(i)("ApplyTimeString") = CommonFun.getYYYMMDD(CommonFun.SetDataRow(dt.Rows(i), "ApplyTime"))
                    dt.Rows(i)("MtClass_type") = SADAO.GetCodeDesc("020", "**", CommonFun.SetDataRow(dt.Rows(i), "MtClass_type"))
                    dt.Rows(i)("ServApply_type") = SADAO.GetCodeDesc("019", "002", CommonFun.SetDataRow(dt.Rows(i), "ServApply_type"))
                    dt.Rows(i)("MtStatus_type") = SADAO.GetCodeDesc("019", "003", CommonFun.SetDataRow(dt.Rows(i), "MtStatus_type"))
                Next

            End If

            dt.AcceptChanges()

            Return dt
        End Function


        Public Sub UpdateRepeatApply_type(SwMaintain_code As String, RepeatApply_type As String)

            SMDAO.Update(LoginManager.OrgCode, SwMaintain_code, "", "", "", "", "", "", "", "", "", "", "", DateTime.MinValue, "", "", "", "", DateTime.MinValue, _
                         "", DateTime.MinValue, DateTime.MinValue, "", "", "", "", "", "", "", "", "", "", RepeatApply_type, LoginManager.UserId, Now, "")

        End Sub

        Public Sub UpdateServConfirm_type(SwMaintain_code As String, ServConfirm_type As String)

            SMDAO.Update(LoginManager.OrgCode, SwMaintain_code, "", "", "", "", "", "", "", "", "", "", "", DateTime.MinValue, "", "", "", "", DateTime.MinValue, _
                         "", DateTime.MinValue, DateTime.MinValue, "", "", "", "", ServConfirm_type, "", "", "", "", "", "", LoginManager.UserId, Now, "")

        End Sub

        Public Sub Update02(swCode As String, flowID As String, Phone_nos As String, Unit_code As String, User_id As String, MtSys_type As String, _
                             ClientUnit_code As String, ClientUser_id As String, ServApply_type As String, SfExpect_date As String, _
                            Problem_desc As String, Attachment1 As String, Attachment2 As String, MtClass_type As String, MtItem_type As String, _
                            TaskType As String, Maintainer_name As String, MaintainerPhone_nos As String, MtStatus_desc As String, _
                            MtStatus_type As String, Forecast_date As String, ServConfirm_type As String, Property_id As String, _
                            ReqAttachment As String, ResponseTime As DateTime, Exceed3Month_type As String, _
                           OrgCode As String, ModUser_id As String, Mod_date As DateTime)

            SMDAO.Update(OrgCode, swCode, flowID, MtClass_type, MtItem_type, TaskType, Phone_nos, Unit_code, User_id, _
                         ClientUnit_code, ClientUser_id, ServApply_type, Problem_desc, DateTime.MinValue, _
                         SfExpect_date, Attachment1, Attachment2, "", DateTime.MinValue, "", DateTime.MinValue, ResponseTime, MaintainerPhone_nos, Maintainer_name, _
                        MtStatus_type, MtStatus_desc, ServConfirm_type, ReqAttachment, Exceed3Month_type, "", "", Property_id, "", LoginManager.UserId, Now, MtSys_type)

        End Sub

        Public Function GetMaintainer(MtItem_type As String, orgCode As String) As DataRow
            Return MTDAO.GetByItem_type(MtItem_type, orgCode)
        End Function

    End Class

End Namespace
