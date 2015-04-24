Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC4102DAO
        Inherits BaseDAO

        Public Function getData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder()
            sql.AppendLine(" select p.*, d.*, ")
            sql.AppendLine(" (select top 1 Depart_name from FSC_Org f where f.orgcode=d.orgcode and f.depart_id=d.depart_id ) as Depart_name, ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_code where CODE_SYS='023' and CODE_TYPE='012' and CODE_NO=p.title_no) as Title_Name ")
            sql.AppendLine(" from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_Depart_emp d on p.id_card=d.id_card ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and d.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and d.Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sql.AppendLine(" and p.id_card=@id_card ")
            End If

            Dim paras(2) As SqlParameter
            paras(0) = New SqlParameter("Orgcode", SqlDbType.VarChar)
            paras(0).Value = Orgcode
            paras(1) = New SqlParameter("Depart_id", SqlDbType.VarChar)
            paras(1).Value = Depart_id
            paras(2) = New SqlParameter("id_card", SqlDbType.VarChar)
            paras(2).Value = id_card

            Return Query(sql.ToString(), paras)
        End Function

    End Class
End Namespace
