Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class OvertimepaySetting
        Public DAO As OvertimepaySettingDAO
        Public Sub New()
            DAO = New OvertimepaySettingDAO()
        End Sub

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetOvertimepaySetting(ByVal Orgcode As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByOrgcode(Orgcode)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


        Public Function GetOvertimepaySettingBySerial_nos(ByVal Serial_nos As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataBySerial_nos(Serial_nos)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function InsertOvertimepaySetting(ByVal Orgcode As String, ByVal Year As String, ByVal Month As String, ByVal Close_day As String, ByVal Start_flag As String, ByVal Change_userid As String) As Boolean
            Return DAO.InsertData(Orgcode, Year, Month, Close_day, Start_flag, Change_userid) = 1
        End Function

        Public Function UpdateOvertimepaySetting(ByVal Orgcode As String, ByVal Year As String, ByVal Month As String, ByVal Close_day As String, ByVal Start_flag As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Boolean
            Return DAO.UpdateData(Orgcode, Year, Month, Close_day, Start_flag, Change_userid, Serial_nos) = 1
        End Function


        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Delete)> _
        Public Function DeleteOvertimepaySetting(ByVal original_Serial_nos As Integer) As Boolean
            Return DAO.DeleteData(original_Serial_nos) = 1
        End Function

        Private Function ComponentModel() As Object
            Throw New System.NotImplementedException
        End Function

    End Class
End Namespace