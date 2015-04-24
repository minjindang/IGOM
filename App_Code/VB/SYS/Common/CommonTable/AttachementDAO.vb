Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Collections.Generic

Namespace SYS.Logic
    Public Class AttachmentDAO
        Inherits BaseDAO

        Public Function GetDataByFlowId(ByVal Flow_id As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM SYS_Attachment WHERE Flow_id=@Flow_id"
            Dim param As SqlParameter = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            param.Value = Flow_id
            Return Query(StrSQL, param)
        End Function


        ''' <summary>
        ''' �O���������
        ''' </summary>
        ''' <param name="att"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Insert(ByVal att As Attachment) As Integer

            'Dim d As New Dictionary(Of String, Object)
            'd.Add("Flow_id", att.Flow_id)
            'd.Add("File_name", att.File_name)
            'd.Add("File_type", att.File_type)
            'd.Add("File_size", att.File_size)
            'd.Add("File_path", att.File_path)
            'd.Add("File_real_name", att.File_real_name)
            'd.Add("Change_userid", att.Upload_userid)
            'd.Add("Change_date", att.Upload_date)

            'Return InsertByExample("SYS_Attachment", d)

            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" insert into SYS_Attachment( ")
            sql.AppendLine(" Flow_id, ")
            sql.AppendLine(" File_name, ")
            sql.AppendLine(" File_type, ")
            sql.AppendLine(" File_size, ")
            sql.AppendLine(" File_path, ")
            sql.AppendLine(" File_real_name, ")
            sql.AppendLine(" Change_userid, ")
            sql.AppendLine(" Change_date) ")
            sql.AppendLine(" values( ")
            sql.AppendLine(" @Flow_id, ")
            sql.AppendLine(" @File_name, ")
            sql.AppendLine(" @File_type, ")
            sql.AppendLine(" @File_size, ")
            sql.AppendLine(" @File_path, ")
            sql.AppendLine(" @File_real_name, ")
            sql.AppendLine(" @Change_userid, ")
            sql.AppendLine(" @Change_date); ")
            'sql.AppendLine(" GO ")
            sql.AppendLine(" select SCOPE_IDENTITY();")

            Dim params() As SqlParameter = { _
                New SqlParameter("Flow_id", att.Flow_id), _
                New SqlParameter("File_name", att.File_name), _
                New SqlParameter("File_type", att.File_type), _
                New SqlParameter("File_size", att.File_size), _
                New SqlParameter("File_path", att.File_path), _
                New SqlParameter("File_real_name", att.File_real_name), _
                New SqlParameter("Change_userid", att.Upload_userid), _
                New SqlParameter("Change_date", att.Upload_date)}

            Return Scalar(sql.ToString(), params)
        End Function

        Public Function Update(ByVal att As Attachment) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", att.Id)

            Dim v As New Dictionary(Of String, Object)
            v.Add("Flow_id", att.Flow_id)
            v.Add("File_name", att.File_name)
            v.Add("File_type", att.File_type)
            v.Add("File_size", att.File_size)
            v.Add("File_path", att.File_path)
            v.Add("File_real_name", att.File_real_name)
            v.Add("Change_userid", att.Upload_userid)
            v.Add("Change_date", att.Upload_date)

            Return UpdateByExample("SYS_Attachment", v, d)
        End Function


        Public Function GetById(id As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)

            Return GetDataByExample("SYS_Attachment", d)
        End Function


        Public Function DeleteById(id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", id)

            Return DeleteByExample("SYS_Attachment", d)
        End Function


        Public Function DeleteByFlowId(flowId As String) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", flowId)

            Return DeleteByExample("SYS_Attachment", d)
        End Function

        Public Function UpdateFlowid(ByVal att As Attachment) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", att.Id)

            Dim v As New Dictionary(Of String, Object)
            v.Add("Flow_id", att.Flow_id)

            Return UpdateByExample("SYS_Attachment", v, d)
        End Function

        Public Function getDataByid(ByVal att As Attachment) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Id", att.Id)

            Return GetDataByExample("SYS_Attachment", d)
        End Function
    End Class
End Namespace