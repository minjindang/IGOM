Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSCPLM.Logic
    Public Class SaCodeDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function GetRow(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal CODE_NO As String) As DataRow
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM SYS_CODE WHERE CODE_SYS=@CODE_SYS  AND CODE_TYPE=@CODE_TYPE  AND CODE_NO=@CODE_NO")

            Dim params() As SqlParameter = { _
            New SqlParameter("@CODE_SYS", CODE_SYS), _
            New SqlParameter("@CODE_NO", CODE_NO), _
            New SqlParameter("@CODE_TYPE", CODE_TYPE)}
            Dim dt As DataTable = Query(StrSQL.ToString(), params)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                Return Nothing
            Else
                Return dt.Rows(0)
            End If

        End Function


        Public Function GetData(ByVal CODE_SYS As String, Optional CODE_TYPE As String = "") As DataSet
            Return GetData("", CODE_SYS, CODE_TYPE)
        End Function


        '2014/4/29 Eliot Chen
        '增加 ORG_CODE
        Public Function GetData(ByVal ORG_CD As String, ByVal CODE_SYS As String, CODE_TYPE As String) As DataSet
            Return GetData("", ORG_CD, CODE_SYS, CODE_TYPE)
        End Function

        '2014/8/3 Anthony Wang
        '增加 CODE_REMARK1
        Public Function GetData(ByVal CODE_REMARK1 As String, ByVal ORG_CD As String, ByVal CODE_SYS As String, CODE_TYPE As String) As DataSet
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM SYS_CODE WHERE CODE_SYS=@CODE_SYS  ")

            If Not String.IsNullOrEmpty(CODE_TYPE) Then
                StrSQL.Append("  AND CODE_TYPE=@CODE_TYPE")
            End If

            If Not String.IsNullOrEmpty(ORG_CD) Then
                StrSQL.Append("  AND CODE_ORGID=@CODE_ORGID")
            End If

            If Not String.IsNullOrEmpty(CODE_REMARK1) Then
                StrSQL.Append("  AND CODE_REMARK1=@CODE_REMARK1")
            End If

            StrSQL.Append(" order by code_sort ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@CODE_REMARK1", CODE_REMARK1), _
            New SqlParameter("@CODE_SYS", CODE_SYS), _
            New SqlParameter("@CODE_ORGID", ORG_CD), _
            New SqlParameter("@CODE_TYPE", CODE_TYPE)}
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function GetData2(ByVal CODE_SYS As String, ByVal CODE_KIND As String, ByVal CODE_TYPE As String) As DataSet
            Return GetData2("", CODE_SYS, CODE_KIND, CODE_TYPE)
        End Function

        '2014/4/29 Eliot Chen
        '增加 ORG_CODE
        Public Function GetData2(ByVal ORG_CD As String, ByVal CODE_SYS As String, ByVal CODE_KIND As String, ByVal CODE_TYPE As String) As DataSet
            Return GetData2("", ORG_CD, CODE_SYS, CODE_KIND, CODE_TYPE)
        End Function

        '2014/8/3 Anthony Wang
        '增加 CODE_REMARK1
        Public Function GetData2(ByVal CODE_REMARK1 As String, ByVal ORG_CD As String, ByVal CODE_SYS As String, ByVal CODE_KIND As String, ByVal CODE_TYPE As String) As DataSet
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM SYS_CODE WHERE CODE_SYS=@CODE_SYS AND CODE_KIND=@CODE_KIND AND CODE_TYPE=@CODE_TYPE")

            If Not String.IsNullOrEmpty(ORG_CD) Then
                StrSQL.Append("  AND CODE_ORGID=@CODE_ORGID")
            End If

            If Not String.IsNullOrEmpty(CODE_REMARK1) Then
                StrSQL.Append("  AND CODE_REMARK1=@CODE_REMARK1")
            End If


            Dim params() As SqlParameter = { _
            New SqlParameter("@CODE_REMARK1", CODE_REMARK1), _
            New SqlParameter("@CODE_SYS", CODE_SYS), _
            New SqlParameter("@CODE_KIND", CODE_KIND), _
            New SqlParameter("@CODE_ORGID", ORG_CD), _
            New SqlParameter("@CODE_TYPE", CODE_TYPE)}

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), params)
        End Function

        Public Function GetTYPEData(ByVal CODE_SYS As String) As DataSet
            Dim StrSQL As New StringBuilder
            StrSQL.Append("SELECT * FROM SYS_CODE WHERE CODE_SYS=@CODE_SYS  AND CODE_TYPE='**'")

            Dim params() As SqlParameter = { _
            New SqlParameter("@CODE_SYS", CODE_SYS)}
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), params)

        End Function

        Public Function updateCodeDesc2(codeSys As String, codeKind As String, codeType As String, codeNo As String, codeDesc2 As String) As Integer
            Dim sql As String = "update SYS_CODE set code_desc2=@code_desc2 where code_sys=@code_sys and code_kind=@code_kind and code_type=@code_type and code_no=@code_no"
            Dim params() As SqlParameter = { _
            New SqlParameter("@code_desc2", codeDesc2), _
            New SqlParameter("@code_sys", codeSys), _
            New SqlParameter("@code_kind", codeKind), _
            New SqlParameter("@code_type", codeType), _
            New SqlParameter("@code_no", codeNo)}

            Return Execute(sql, params)
        End Function
    End Class
End Namespace
