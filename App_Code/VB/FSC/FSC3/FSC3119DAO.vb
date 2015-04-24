Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3119DAO
        Inherits BaseDAO

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, _
                                ByVal Apply_date As String, ByVal isReword As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select r.*, ")
            sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=r.orgcode and f.depart_id=r.depart_id) as Depart_Name ")
            sql.AppendLine(" from FSC_Reword_main r ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and id_card=@id_card ")
            End If
            If Not String.IsNullOrEmpty(Apply_date) Then
                sql.AppendLine(" and Apply_date=@Apply_date ")
            End If
            If Not String.IsNullOrEmpty(isReword) Then
                If isReword.Equals("1") Then
                    sql.AppendLine(" and (Reword_Doc is null or Reword_Doc = '') ")
                ElseIf isReword.Equals("2") Then
                    sql.AppendLine(" and (Reword_Doc is not null or Reword_Doc <> '') ")
                End If
            End If

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@id_card", SqlDbType.VarChar)
            params(2).Value = id_card
            params(3) = New SqlParameter("@Apply_date", SqlDbType.VarChar)
            params(3).Value = Apply_date

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace
