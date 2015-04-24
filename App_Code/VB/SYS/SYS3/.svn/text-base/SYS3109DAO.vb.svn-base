Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS3109DAO
        Inherits BaseDAO

        Public Function GetData(ByVal FromName As String, ByVal FromMail As String, ByVal ToName As String, ByVal ToMail As String, ByVal dateS As String, ByVal dateE As String, ByVal ErrorM As String) As DataTable
            Dim sql As String = String.Empty
            Dim Parms As New ArrayList

            sql &= " SELECT * FROM SYS_MailError WHERE 1=1 "

            If Not String.IsNullOrEmpty(dateS) Then
                sql &= " AND SendDate >= " + dateS
            End If

            If Not String.IsNullOrEmpty(dateE) Then
                sql &= " AND SendDate <=  " + dateE
            End If

            If FromName <> "" Then
                sql &= " AND  FromName like '%" + FromName + "%' "
            End If

            If FromMail <> "" Then
                sql &= " AND  FromMail like '%" + FromMail + "%' "
            End If

            If ToName <> "" Then
                sql &= " AND  ToName like '%" + ToName + "%' "
            End If

            If ToMail <> "" Then
                sql &= " AND  ToMail like '%" + ToMail + "%' "
            End If

            If ErrorM <> "" Then
                sql &= " AND  ErrorMag=" + ErrorM
            End If

            sql &= " order by SendDate desc"

            Return Query(sql.ToString())
        End Function

    End Class

End Namespace
