Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Namespace SYS.Logic
    Public Class PaperFileDAO
        Inherits BaseDAO

        Public Function InsertData(paperFile As PaperFile) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", paperFile.Orgcode)
            d.Add("Depart_id", paperFile.DepartId)
            d.Add("File_name", paperFile.FileName)
            d.Add("Real_name", paperFile.RealName)
            d.Add("Path", paperFile.Path)
            d.Add("Start_date", paperFile.Start_date)
            d.Add("End_date", paperFile.End_date)
            d.Add("removed_flag", paperFile.removed_flag)
            d.Add("Change_userid", paperFile.ChangeUserid)
            d.Add("Change_date", paperFile.ChangeDate)

            Return InsertByExample("SYS_Paper_file", d)
        End Function

        Public Function UpdateData(paperFile As PaperFile, ByVal id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("Start_date", paperFile.Start_date)
            d.Add("End_date", paperFile.End_date)
            d.Add("removed_flag", paperFile.removed_flag)
            d.Add("Change_userid", paperFile.ChangeUserid)
            d.Add("Change_date", paperFile.ChangeDate)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return UpdateByExample("SYS_Paper_file", d, cd)
        End Function

        Public Function GetDataByOuery(orgcode As String, departId As String) As DataTable
            Dim d As New Dictionary(Of String, Object)
            If Not String.IsNullOrEmpty(orgcode) Then
                d.Add("Orgcode", orgcode)
            End If
            If Not String.IsNullOrEmpty(departId) Then
                d.Add("Depart_id", departId)
            End If

            Return GetDataByExample("SYS_Paper_file", d)
        End Function

        Public Function DeleteById(id As Integer) As Integer
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return DeleteByExample("SYS_Paper_file", d)
        End Function

        Public Function GetDataById(id As Integer) As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)

            Return GetDataByExample("SYS_Paper_file", d)
        End Function

        Public Function GetData(ByVal orgcode As String, ByVal departId As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from SYS_Paper_file ")
            sql.AppendLine(" where orgcode=@orgcode ")
            sql.AppendLine(" and depart_Id=@departId ")
            sql.AppendLine(" and @Today between Start_date and End_date ")
            sql.AppendLine(" and removed_flag <> 'Y' ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@orgcode", SqlDbType.VarChar)
            params(0).Value = orgcode
            params(1) = New SqlParameter("@departId", SqlDbType.VarChar)
            params(1).Value = departId
            params(2) = New SqlParameter("@Today", SqlDbType.VarChar)
            params(2).Value = FSC.Logic.DateTimeInfo.GetRocTodayString("yyyyMMdd")

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace