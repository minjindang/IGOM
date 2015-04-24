Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class Bulletin
        Public DAO As BulletinDAO
        Public Sub New()
            DAO = New BulletinDAO()
        End Sub

        Public Function GetBulletinByOrgcode(ByVal Orgcode As String, ByVal Bulletin_date_s As String, ByVal Bulletin_date_e As String, ByVal Bulletin_flag As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByQuery(Orgcode, Bulletin_date_s, Bulletin_date_e, Bulletin_flag)
            If ds Is Nothing Then Return Nothing
            For Each dr As DataRow In ds.Tables(0).Rows
                dr("Bulletin_date") = DateTimeInfo.ConvertToDisplay(dr("Bulletin_date").ToString())
            Next
            Return ds.Tables(0)
        End Function

        Public Function GetBulletinBySnos(ByVal Serial_nos As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataBySerialNos(Serial_nos)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetBulletinByToday(ByVal Orgcode As String, ByVal Bulletin_date As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByToday(Orgcode, Bulletin_date)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetBulletinByFlag(ByVal Orgcode As String, ByVal Bulletin_flag As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByFlag(Orgcode, Bulletin_flag)
            If ds Is Nothing Then Return Nothing

            Dim dt As DataTable = ds.Tables(0)
            dt.Columns.Add("Bulletin", GetType(String))

            For Each dr As DataRow In dt.Rows
                dr("Bulletin") = "(" & dr("Bulletin_seq") & ")(" & dr("Bulletin_date") & ")" & Mid(dr("Bulletin_content"), 1, 20) & "..."
            Next

            Return dt
        End Function


        Public Function InsertBulletin(ByVal Orgcode As String, ByVal Bulletin_userid As String, ByVal Bulletin_content As String, _
                                        ByVal Bulletin_date As String, ByVal Change_userid As String) As Boolean

            Return DAO.InsertData(Orgcode, Bulletin_userid, Bulletin_content, Bulletin_date, Change_userid) = 1
        End Function


        Public Function UpdateBulletin(ByVal Orgcode As String, ByVal Bulletin_userid As String, ByVal Bulletin_content As String, _
                                       ByVal Bulletin_date As String, ByVal Change_userid As String, ByVal Serial_nos As Integer) As Boolean

            Return DAO.UpdateData(Orgcode, Bulletin_userid, Bulletin_content, Bulletin_date, Change_userid, Serial_nos) = 1
        End Function


        Public Function UpdateBulletinFlag(ByVal Bulletin_flag As String, ByVal Serial_nos As Integer, Optional ByVal Bulletin_seq As Integer = Nothing) As Boolean

            Return DAO.UpdateDataFlag(Bulletin_flag, Serial_nos, Bulletin_seq) = 1
        End Function


        Public Function DeleteBulletin(ByVal Serial_nos As Integer) As Boolean

            Return DAO.DeleteData(Serial_nos) = 1
        End Function


    End Class
End Namespace