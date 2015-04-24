Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3101DAO
        Inherits BaseDAO

        Public Function GetDataByQuery(ByVal Orgcode As String, ByVal ID_card As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT d.id, p.title_no, ")
            sql.AppendLine("        '行政代理' as Deput_TypeName, sc.CODE_DESC1 as title_name, ")
            sql.AppendLine("        p.id_card, p.User_name,d.Deputy_flag,D.Deputy_seq ")
            sql.AppendLine(" FROM FSC_Deputy_det d ")
            sql.AppendLine("        INNER JOIN FSC_personnel p ON d.Deputy_idcard=p.ID_card ")
            sql.AppendLine("        LEFT OUTER JOIN SYS_CODE sc on sc.CODE_SYS='023' and sc.CODE_TYPE='012' and sc.CODE_NO=p.title_no ")
            sql.AppendLine(" WHERE d.ID_card=@Id_card  and d.Orgcode=@Orgcode")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = ID_card
            params(1) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(1).Value = Orgcode

            Return Query(sql.ToString(), params)
        End Function


        Public Function deleteData(ByVal id As Integer) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" delete from FSC_deputy_det where id=@id ")

            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@id", SqlDbType.Int)
            params(0).Value = id

            Return Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace
