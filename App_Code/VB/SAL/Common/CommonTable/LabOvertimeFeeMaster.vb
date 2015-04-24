Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Namespace SAL.Logic
    <System.ComponentModel.DataObject()> _
    Public Class LabOvertimeFeeMaster
        Public DAO As LabOvertimeFeeMasterDAO
        Public Sub New()
            DAO = New LabOvertimeFeeMasterDAO()
        End Sub

        Public Function UpdatePrintMark2(ByVal Orgcode As String, _
                                 ByVal Depart_id As String, _
                                 ByVal Id_card As String, _
                                 ByVal Fee_ym As String, _
                                 ByVal Budget_type As String, _
                                 ByVal Apply_seq As String, _
                                 ByVal Print_mark As String) As Boolean

            Return DAO.UpdatePrintMark(Orgcode, Depart_id, Id_card, Fee_ym, Budget_type, Apply_seq, Print_mark) = 1
        End Function

        Public Function GetSum_seq(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Fee_ym As String) As String
            Dim obj As Object = DAO.GetMaxSum_seq(Orgcode, Depart_id, Fee_ym)
            If IsDBNull(obj) Then Return "1"
            Return Convert.ToString(CommonFun.ConvertToInt(CType(obj, String)) + 1)
        End Function

        Public Function UpdateSumData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                           ByVal Apply_seq As String, ByVal Sum_date As String, ByVal Sum_seq As String) As Boolean
            Return DAO.UpdateSumData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Sum_date, Sum_seq) = 1
        End Function

        Public Function GetLabOvertimeFeeMasterByQuery(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataTable
            Return DAO.GetDataByQuery(Orgcode, Depart_id, Id_card, Fee_ym)
        End Function

        Public Function getDataByFlowid(ByVal Orgcode As String, ByVal flow_id As String) As DataTable
            Dim ds As DataSet = DAO.getDataByFlowid(Orgcode, flow_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function deleteData(ByVal OrgCode As String, ByVal Depart_id As String, ByVal YearMonth As String, ByVal Id_card As String) As Boolean
            Return DAO.deleteData(OrgCode, Depart_id, YearMonth, Id_card) = 1
        End Function

        Public Function updatePayMark(ByVal orgcode As String, ByVal flow_id As String, ByVal Pay_Mark As String) As Boolean
            Return DAO.updatePayMark(orgcode, flow_id, Pay_Mark)
        End Function
    End Class
End Namespace