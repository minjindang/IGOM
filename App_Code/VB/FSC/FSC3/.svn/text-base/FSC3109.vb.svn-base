Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class FSC3109
        Private DAO As FSC3109DAO

        Public Sub New()
            DAO = New FSC3109DAO()
        End Sub

        Public Function getQueryData(ByVal Orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Id_card As String, _
                                     ByVal employee_type As String, _
                                     ByVal Leave_types As String, _
                                     ByVal dateb As String, _
                                     ByVal datee As String, _
                                     ByVal case_status As String, _
                                     Optional ByVal isA4 As Boolean = True) As DataTable

            Return DAO.getQueryData(Orgcode, Depart_id, Id_card, employee_type, Leave_types, dateb, datee, case_status, isA4)
        End Function

        Public Function getFDObjectByFlowId(ByVal orgcode As String, ByVal flow_id As String) As SYS.Logic.FlowDetail
            Dim fd As New SYS.Logic.FlowDetail
            Dim dt As DataTable = fd.GetDataByFlow_id(orgcode, flow_id)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                fd.FlowId = dt.Rows(0)("Flow_id").ToString()
                fd.Orgcode = dt.Rows(0)("Orgcode").ToString()
                fd.LastOrgcode = dt.Rows(0)("Last_orgcode").ToString()
                fd.LastDepartid = dt.Rows(0)("Last_departid").ToString()
                fd.LastPosid = dt.Rows(0)("Last_posid").ToString()
                fd.LastIdcard = dt.Rows(0)("Last_idcard").ToString()
                fd.LastName = dt.Rows(0)("Last_name").ToString()
                fd.AgreeTime = dt.Rows(0)("Agree_time").ToString()
                fd.AgreeFlag = dt.Rows(0)("Agree_flag").ToString()
                fd.Comment = dt.Rows(0)("Comment").ToString()
                fd.LastDate = dt.Rows(0)("Last_date").ToString()
                fd.LastPass = dt.Rows(0)("Last_pass").ToString()
                fd.ReplaceOrgcode = dt.Rows(0)("Replace_orgcode").ToString()
                fd.ReplaceDepartid = dt.Rows(0)("Replace_Departid").ToString()
                fd.ReplacePosid = dt.Rows(0)("Replace_posid").ToString()
                fd.ReplaceIdcard = dt.Rows(0)("Replace_idcard").ToString()
                fd.ReplaceName = dt.Rows(0)("Replace_name").ToString()
                fd.DeputyFlag = dt.Rows(0)("Deputy_flag").ToString()
                fd.ReplaceFlag = dt.Rows(0)("Replace_flag").ToString()
                fd.ChangeUserid = dt.Rows(0)("Change_userid").ToString()
                fd.ChangeDate = dt.Rows(0)("Change_date").ToString()
            End If

            Return fd
        End Function

    End Class
End Namespace