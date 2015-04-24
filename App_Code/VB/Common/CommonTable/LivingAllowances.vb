Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class LivingAllowances
        Public DAO As LivingAllowancesDAO

        Public Sub New()
            DAO = New LivingAllowancesDAO()
        End Sub

        Public Function GetLivingAllowancesBySerialNos(ByVal Serial_nos As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataBySerialNos(Serial_nos)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function InsertLivingAllowances(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ID_card As String, ByVal personnel_id As String, _
                ByVal Title_name As String, ByVal Salary_level_id As String, ByVal Apply_type As String, ByVal Persons_name As String, ByVal Relationship As String, _
                ByVal Occur_date As String, ByVal Apply_money As String, ByVal Testimonial_type As String, ByVal Change_userid As String, ByVal Salary As String) As Integer

            Return DAO.InsertData(Orgcode, Depart_id, ID_card, personnel_id, Title_name, Salary_level_id, Apply_type, _
                                    Persons_name, Relationship, Occur_date, Apply_money, Testimonial_type, Change_userid, Salary)
        End Function

    End Class
End Namespace
