Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace EMP.Logic
    Public Class EMP3106DAO
        Inherits BaseDAO

        Public Function DeleteDepartEmp(ByVal id_card As String, ByVal Service_type As String) As Integer
            Dim sql As String = " delete emp_depart_emp where id_card=@id_card and Service_type=@Service_type "

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(0).Value = id_card
            params(1) = New SqlParameter("@Service_type", SqlDbType.VarChar)
            params(1).Value = Service_type

            Return Execute(sql, params)
        End Function


        Public Function DeleteDeputy(ByVal id_card As String) As Integer
            Dim sql As String = " delete FSC_Deputy_det where id_card=@id_card "

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(0).Value = id_card

            Return Execute(sql, params)
        End Function
    End Class
End Namespace
