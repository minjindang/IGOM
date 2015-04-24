Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class FSC4102
        Private DAO As FSC4102DAO

        Public Sub New()
            DAO = New FSC4102DAO()
        End Sub

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String) As DataTable
            Return DAO.getData(Orgcode, Depart_id, id_card)
        End Function

        Public Function updateEmailConfig(ByVal id_card As String, ByVal Email_YN As String, ByVal Frequency As String, _
                                          ByVal Send_time1 As String, ByVal Send_time2 As String, ByVal Send_time3 As String, _
                                          ByVal Send_time4 As String, ByVal Send_time5 As String, ByVal Send_time6 As String) As Boolean

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id_card", id_card)

            Dim c As New Dictionary(Of String, Object)
            c.Add("Email_YN", Email_YN)
            c.Add("Frequency", Frequency)
            c.Add("Send_time1", Send_time1)
            c.Add("Send_time2", Send_time2)
            c.Add("Send_time3", Send_time3)
            c.Add("Send_time4", Send_time4)
            c.Add("Send_time5", Send_time5)
            c.Add("Send_time6", Send_time6)

            Return DAO.UpdateByExample("FSC_Personnel", c, cd)
        End Function
    End Class
End Namespace
