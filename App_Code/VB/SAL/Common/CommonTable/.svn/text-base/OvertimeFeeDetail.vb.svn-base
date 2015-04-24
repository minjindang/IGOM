Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OvertimeFeeDetail
        Public DAO As OvertimeFeeDetailDAO
        Public Sub New()
            DAO = New OvertimeFeeDetailDAO()
        End Sub

        Public Function InsertOvertimeFeeDetail(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String, _
                                    ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Applytime_start As String, ByVal Applytime_end As String, _
                                    ByVal Overtime_start As String, ByVal Overtime_end As String, ByVal Overtime_hour As Integer, ByVal Apply_hour As Integer, _
                                    ByVal Reason As String, ByVal Create_userid As String) As Boolean
            Return DAO.InsertData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Overtime_type, Overtime_date, Applytime_start, Applytime_end, Overtime_start, Overtime_end, Overtime_hour, Apply_hour, Reason, Create_userid) = 1
        End Function

        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="Depart_id"></param>
        ''' <param name="Id_card"></param>
        ''' <param name="Fee_ym"></param>
        ''' <param name="Overtime_date"></param>
        ''' <param name="Overtime_start"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode, Depart_id, Id_card, Fee_ym, Overtime_date, Overtime_start)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetCount(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String, ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As Integer
            Dim ds As DataSet = DAO.GetDataByQuery(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Overtime_type, Overtime_date, Overtime_start)
            If ds Is Nothing Then Return 0
            Dim dt As DataTable = ds.Tables(0)
            Return dt.Rows.Count
        End Function

        Public Function UpdateApply_hour(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, _
                ByVal Apply_seq As String, ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal overtime_start As String, ByVal Apply_hour As Integer, ByVal Update_userid As String) As Boolean
            Return DAO.UpdateApplyHour(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Overtime_type, Overtime_date, overtime_start, Apply_hour, Update_userid) = 1
        End Function

        Public Function DeleteOvertimeFeeDetail(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String, ByVal Overtime_type As String, ByVal Overtime_date As String, ByVal Overtime_start As String) As Boolean
            Return DAO.DeleteData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq, Overtime_type, Overtime_date, Overtime_start) = 1
        End Function

        Public Function DeleteOvertimeFeeDetail(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As Boolean
            Return DAO.DeleteData(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq) = 1
        End Function


        Public Function GetFSC1301_02Data2(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String, ByVal Apply_seq As String) As DataTable
            Dim ds As DataSet = DAO.GetFSC1301_02Data2(Orgcode, Depart_id, Id_card, Fee_ym, Apply_seq)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByFeeYm(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Fee_ym As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByFeeYm(Orgcode, Depart_id, Id_card, Fee_ym)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function
    End Class
End Namespace