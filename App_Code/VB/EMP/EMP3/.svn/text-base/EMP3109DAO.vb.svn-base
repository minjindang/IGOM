Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class EMP3109DAO
        Inherits BaseDAO

        Public Function getQueryData(ByVal depart_id As String, _
                                     ByVal Apply_idcard As String, _
                                     ByVal id_card2 As String, _
                                     ByVal isdisable As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" SELECT ")
            sql.AppendLine(" (select e.Depart_name from FSC_ORG AS e where e.Orgcode=b.Orgcode AND e.Depart_id = b.Depart_id)AS depart_name,")
            sql.AppendLine(" a.Id_card,c.User_name,a.Unique_id,a.mob_type,a.is_disable,a.Notes ")

            sql.AppendLine("  from EMP_Mobidev_reg AS a")
            sql.AppendLine("  INNER JOIN FSC_Personnel AS c ON c.Id_card = a.Id_card")
            sql.AppendLine("  INNER JOIN FSC_Depart_EMP AS b ON a.Id_card = b.Id_card")

            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" AND b.Depart_id = @depart_id")
            End If
            If Not String.IsNullOrEmpty(Apply_idcard) Then
                sql.AppendLine(" AND a.Id_card = @Apply_idcard")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sql.AppendLine(" AND a.Id_card = @id_card2")
            End If
            If Not String.IsNullOrEmpty(isdisable) Then
                sql.AppendLine(" AND a.is_disable = @isdisable")
            End If
            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@depart_id", SqlDbType.VarChar)
            aryParms(0).Value = depart_id
            aryParms(1) = New SqlParameter("@Apply_idcard", SqlDbType.VarChar)
            aryParms(1).Value = Apply_idcard
            aryParms(2) = New SqlParameter("@isdisable", SqlDbType.VarChar)
            aryParms(2).Value = isdisable
            aryParms(3) = New SqlParameter("@id_card2", SqlDbType.VarChar)
            aryParms(3).Value = id_card2

            Return Query(sql.ToString(), aryParms)
        End Function
        Public Function getUpdateData(ByVal idcard As String, _
                             ByVal isdisable As String, _
                             ByVal Unique_id As String, _
                             ByVal note As String) As Integer
            Dim sql As New StringBuilder()

            sql.AppendLine("UPDATE EMP_Mobidev_reg SET Notes=@note,is_disable=@isdisable WHERE Unique_id = @Unique_id")

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@idcard", SqlDbType.VarChar)
            aryParms(0).Value = idcard
            aryParms(1) = New SqlParameter("@isdisable", SqlDbType.VarChar)
            aryParms(1).Value = isdisable
            aryParms(2) = New SqlParameter("@note", SqlDbType.VarChar)
            aryParms(2).Value = note
            aryParms(3) = New SqlParameter("@Unique_id", SqlDbType.VarChar)
            aryParms(3).Value = Unique_id

            Return Execute(sql.ToString(), aryParms)
        End Function
    End Class
End Namespace
