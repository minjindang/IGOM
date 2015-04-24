Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace FSC.Logic
    Public Class EMP3109
        Private DAO As EMP3109DAO

        Public Sub New()
            DAO = New EMP3109DAO()
        End Sub

        Public Function getQueryData(ByVal depart_id As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal id_card2 As String, _
                                     ByVal isdisable As String) As DataTable
            Return DAO.getQueryData(depart_id, Apply_idcard, id_card2, isdisable)
        End Function
        Public Function getUpdateData(ByVal idcard As String, _
                                      ByVal isdisable As String, _
                                      ByVal Unique_id As String, _
                                      ByVal note As String) As Boolean
            Return DAO.getUpdateData(idcard, isdisable, Unique_id, note)
        End Function
    End Class
End Namespace