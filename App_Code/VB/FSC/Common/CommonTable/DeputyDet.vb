Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    <System.ComponentModel.DataObject()> _
    Public Class DeputyDet
        Public DAO As DeputyDetDAO
        Public Sub New()
            DAO = New DeputyDetDAO()
        End Sub

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetDeputyDetByID_card(ByVal ID_card As String) As DataTable
            Dim ds As DataSet = DAO.GetDataById_card(ID_card, "")
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


        Public Function GetDeputyDetByID_card(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ID_card As String, Optional ByVal Deputy_flag As String = Nothing) As DataTable
            Dim ds As DataSet = DAO.GetDataById_card(Orgcode, Depart_id, ID_card, Deputy_flag)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDeputyDetByID_card(ByVal ID_card As String, ByVal Deputy_flag As String) As DataTable
            Dim ds As DataSet = DAO.GetDataById_card(ID_card, Deputy_flag)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDeputyDetByDeputy_idcard(ByVal ID_card As String, ByVal Deputy_id_card As String, Optional ByVal Deputy_flag As String = Nothing, Optional ByVal Deputy_type As String = Nothing) As DataTable
            Dim ds As DataSet = DAO.GetDeputyDetByDeputy_idcard(ID_card, Deputy_id_card, Deputy_flag, Deputy_type)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDLLDataById_card(ByVal Orgcode As String, ByVal Id_card As String, Optional ByVal DeputyType As String = "") As DataTable
            Dim ds As DataSet = DAO.GetDLLDataById_card(Orgcode, Id_card, DeputyType)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDefalutDeputy(ByVal Column_name As String, ByVal ID_card As String) As String
            Dim dt As DataTable = GetDeputyDetByID_card(ID_card, "1")
            If dt.Rows.Count <= 0 Then Return String.Empty
            Return dt.Rows(0)(Column_name).ToString()
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete)> _
        Public Function DeleteDeputyDet(ByVal id As Integer) As Boolean
            Return DAO.DeleteData(id) = 1
        End Function

        Public Function DeleteIdcard(ByVal Orgcode As String, ByVal Id_card As String) As Boolean
            Return DAO.DeleteIdcard(Orgcode, Id_card) = 1
        End Function

        Public Function InsertDeputyDet(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Deputy_orgcode As String, _
                                   ByVal Deputy_departid As String, ByVal Deputy_posid As String, ByVal Deputy_idcard As String, ByVal Change_userid As String, ByVal Deputy_flag As String, ByVal Deputy_seq As Integer) As Boolean
            Return DAO.InsertDeputyDet(Orgcode, Depart_id, Id_card, Deputy_orgcode, Deputy_departid, Deputy_posid, Deputy_idcard, Change_userid, Deputy_flag, Deputy_seq) = 1
        End Function

        Public Function UpdateDeputyDet(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Deputy_orgcode As String, ByVal Deputy_departid As String, _
                                   ByVal Deputy_posid As String, ByVal Deputy_idcard As String, ByVal Change_userid As String, ByVal id As Integer, ByVal Deputy_flag As String, ByVal Deputy_seq As Integer) As Boolean
            Return DAO.UpdateData(Orgcode, Depart_id, Id_card, Deputy_orgcode, Deputy_departid, Deputy_posid, Deputy_idcard, Change_userid, id, Deputy_flag, Deputy_seq) = 1
        End Function

        Public Function UpdateDeputyFlag(ByVal Id_card As String, ByVal Deputy_flag As String, ByVal Change_userid As String, Optional ByVal Deputy_type As String = "1") As Boolean
            Return DAO.UpdateDeputyFlag(Id_card, Deputy_flag, Change_userid, Deputy_type) = 1
        End Function

        Public Function ChkDefalutDeputy(ByVal ID_card As String, ByVal Deputy_id_card As String, Optional ByVal Deputy_flag As String = Nothing, Optional ByVal Deputy_type As String = Nothing) As Boolean
            Dim dt As DataTable = GetDeputyDetByDeputy_idcard(ID_card, Deputy_id_card, Deputy_flag, Deputy_type)
            If dt.Rows.Count <= 0 Then Return False
            Return True
        End Function

        Public Function GetDeputyDetBySerial_nos(ByVal id As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataBySerial_nos(id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function getNotDefaultData(ByVal Orgcode As String, ByVal Id_card As String) As DataTable
            Return DAO.getNotDefaultData(Orgcode, Id_card)
        End Function

        Public Function UpdateSeq(ByVal id As String, ByVal Deputy_seq As String) As Boolean
            Return DAO.UpdateSeq(id, Deputy_seq) >= 1
        End Function
    End Class
End Namespace
