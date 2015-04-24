Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class Information
        Public DAO As InformationDAO
        Public Sub New()
            DAO = New InformationDAO()
        End Sub

        Public Function InsertInformation(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Post_idcard As String, _
                                    ByVal Inf_type As String, ByVal Inf_title As String, ByVal Inf_content As String, ByVal Inf_link As String, _
                                    ByVal Inf_orgcode As String, ByVal Inf_flag As String, ByVal Change_userid As String) As Boolean
            Return DAO.InsertData(Orgcode, Depart_id, Post_idcard, Inf_type, Inf_title, Inf_content, Inf_link, Inf_orgcode, Inf_flag, Change_userid) = 1
        End Function

        Public Function UpdateInformation(ByVal Inf_type As String, ByVal Inf_title As String, ByVal Inf_content As String, ByVal Inf_link As String, _
                                    ByVal Inf_flag As String, ByVal Inf_orgcode As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Boolean
            Return DAO.UpdateData(Inf_type, Inf_title, Inf_content, Inf_link, Inf_flag, Inf_orgcode, Change_userid, Serial_nos) = 1
        End Function

        Public Function UpdateInf_flag(ByVal Inf_flag As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Boolean
            Return DAO.UpdateInf_flag(Inf_flag, Change_userid, Serial_nos) = 1
        End Function

        Public Function GetInformationByQuery(ByVal Orgcode As String, ByVal Inf_type As String, ByVal Inf_flag As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByQuery(Orgcode, Inf_type, Inf_flag)
            If ds Is Nothing Then Return Nothing
            Dim dt As DataTable = ds.Tables(0)
            For Each dr As DataRow In dt.Rows
                Dim Inf_orgcode() As String = dr("Inf_orgcode").ToString().Split(",")
                Dim Inf_orgcode_tmp As String = String.Empty
                For Each orgcode_tmp As String In Inf_orgcode
                    Inf_orgcode_tmp &= New FSCorg().GetOrgcodeName(orgcode_tmp) & ","
                Next
                dr("Inf_orgcode") = Inf_orgcode_tmp.TrimEnd(",")
            Next
            Return dt
        End Function

        Public Function GetInformationByInf_orgcode(ByVal Inf_type As String, ByVal Inf_orgcode As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByInf_orgcode(Inf_type, Inf_orgcode)
            If ds Is Nothing Then Return Nothing
            Dim dt As DataTable = ds.Tables(0)
            Return dt
        End Function

        Public Function GetInformationBySerial_nos(ByVal Serial_nos As Integer) As DataTable
            Return DAO.GetDataBySerail_nos(Serial_nos).Tables(0)
        End Function

        Public Function DeleteInformation(ByVal Serial_nos As Integer) As Boolean
            Return DAO.DeleteData(Serial_nos) = 1
        End Function

    End Class
End Namespace