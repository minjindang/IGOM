Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Namespace MAI.Logic
    Public Class MaintainMainDAO
        Inherits BaseDAO

        Public Function InsertData(main As MaintainMain) As Integer
            'Dim d As New Dictionary(Of String, Object)
            'd.Add("Orgcode", main.Orgcode)
            'd.Add("Flow_id", main.Flow_id)
            'd.Add("Apply_ext", main.Apply_ext)
            'd.Add("Apply_idcard", main.Apply_idcard)
            'd.Add("Apply_name", main.Apply_name)
            'd.Add("Maintain_kind", main.Maintain_kind)
            'd.Add("Maintain_type", main.Maintain_type)
            'd.Add("Problem_desc", main.Problem_desc)
            'd.Add("Change_userid", main.Change_userid)
            'd.Add("Change_date", main.Change_date)

            'Return InsertByExample("MAI_Maintain_main", d)

            Dim sql As New StringBuilder()
            sql.AppendLine(" insert into MAI_Maintain_main ")
            sql.AppendLine(" (Orgcode, Flow_id, Apply_ext, Apply_departid, Apply_idcard, Apply_name, Apply_date, ")
            sql.AppendLine("    Writer_ext, Writer_departid, Writer_idcard, Writer_name, Maintain_kind, Maintain_type, Problem_desc, Change_userid, Change_date) ")
            sql.AppendLine(" values ")
            sql.AppendLine(" (@Orgcode, @Flow_id, @Apply_ext, @Apply_departid, @Apply_idcard, @Apply_name, @Apply_date, ")
            sql.AppendLine("   @Writer_ext, @Writer_departid, @Writer_idcard, @Writer_name,  @Maintain_kind, @Maintain_type, @Problem_desc, @Change_userid, @Change_date); ")
            sql.AppendLine(" select SCOPE_IDENTITY();")

            Dim params() As SqlParameter = { _
                New SqlParameter("@Orgcode", main.Orgcode), _
                New SqlParameter("@Flow_id", main.Flow_id), _
                New SqlParameter("@Apply_ext", main.Apply_ext), _
                New SqlParameter("@Apply_departid", main.Apply_departid), _
                New SqlParameter("@Apply_idcard", main.Apply_idcard), _
                New SqlParameter("@Apply_name", main.Apply_name), _
                New SqlParameter("@Apply_date", main.Apply_date), _
                New SqlParameter("@Writer_ext", main.Writer_ext), _
                New SqlParameter("@Writer_departid", main.Writer_departid), _
                New SqlParameter("@Writer_idcard", main.Writer_idcard), _
                New SqlParameter("@Writer_name", main.Writer_name), _
                New SqlParameter("@Maintain_kind", main.Maintain_kind), _
                New SqlParameter("@Maintain_type", main.Maintain_type), _
                New SqlParameter("@Problem_desc", main.Problem_desc), _
                New SqlParameter("@Change_userid", main.Change_userid), _
                New SqlParameter("@Change_date", main.Change_date)}

            Return Scalar(sql.ToString(), params)
        End Function

        Public Function GetDataByOrgFid(orgcode As String, flowId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", orgcode)
            d.Add("Flow_id", flowId)

            Return GetDataByExample("MAI_Maintain_main", d)
        End Function

        Public Function UpdateData(main As MaintainMain) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Maintain_step", main.Maintain_step)
            d.Add("Maintain_kind", main.Maintain_kind)
            d.Add("Maintain_type", main.Maintain_type)
            d.Add("Problem_desc", main.Problem_desc)
            d.Add("Change_userid", main.Change_userid)
            d.Add("Change_date", main.Change_date)

            Dim c As New Dictionary(Of String, Object)
            c.Add("Id", main.Id)

            Return UpdateByExample("MAI_Maintain_main", d, c)
        End Function


        Public Function UpdateData(Maintain_kind As String, Maintain_type As String, Id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Maintain_kind", Maintain_kind)
            d.Add("Maintain_type", Maintain_type)

            Dim c As New Dictionary(Of String, Object)
            c.Add("Id", Id)

            Return UpdateByExample("MAI_Maintain_main", d, c)
        End Function


        Public Function UpdateData(Maintain_step As Integer, Id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Maintain_step", Maintain_Step)

            Dim c As New Dictionary(Of String, Object)
            c.Add("Id", Id)

            Return UpdateByExample("MAI_Maintain_main", d, c)
        End Function

    End Class
End Namespace