Imports Microsoft.VisualBasic
Imports System.Data

Public Class Unusualnotify
    Public DAO As UnusualnotifyDAO

    Public Sub New()
        DAO = New UnusualnotifyDAO()
    End Sub

    Public Function InsertData(ByVal orgcode As String, ByVal id_card As String, ByVal notice_date As String, ByVal notice_flag As String) As Boolean
        Return DAO.InsertData(orgcode, id_card, notice_date, notice_flag) = 1
    End Function


    Public Function GetData(ByVal orgcode As String, ByVal id_card As String, ByVal notice_date As String) As DataTable
        Return DAO.GetData(orgcode, id_card, notice_date).Tables(0)
    End Function
End Class
