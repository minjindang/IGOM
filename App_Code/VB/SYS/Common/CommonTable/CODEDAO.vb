Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SYS.Logic
    Public Class CODEDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function GetData(ByVal Code_sys As String, ByVal Code_type As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = " select * from SYS_Code where Code_sys=@Code_sys and Code_type=@Code_type order by CODE_SORT "
            Dim params() As SqlParameter = { _
            New SqlParameter("@Code_sys", SqlDbType.VarChar), _
            New SqlParameter("@Code_type", SqlDbType.VarChar)}
            params(0).Value = Code_sys
            params(1).Value = Code_type

            Return Query(StrSQL, params)
        End Function

        Public Function getData(ByVal Code_sys As String, ByVal Code_type As String, ByVal Code_no As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = " select * from SYS_Code where Code_sys=@Code_sys and Code_type=@Code_type and Code_no=@Code_no "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Code_sys", SqlDbType.VarChar), _
            New SqlParameter("@Code_type", SqlDbType.VarChar), _
            New SqlParameter("@Code_no", SqlDbType.VarChar)}
            params(0).Value = Code_sys
            params(1).Value = Code_type
            params(2).Value = Code_no
            Return Query(StrSQL, params)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal CODE_NO As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = " select sc.*, "
            StrSQL &= " (select top 1 CODE_DESC1 from sys_code where CODE_SYS='SYS' and CODE_TYPE='*' and CODE_NO=sc.CODE_SYS) as CODE_SYS_Name, "
            StrSQL &= " case when CODE_KIND = 'P' then '公共' when CODE_KIND = 'D' then '自訂' when CODE_KIND = 'S' then '系統用' end as CODE_KIND_Name, "
            StrSQL &= " (select top 1 CODE_DESC1 from sys_code where CODE_SYS=sc.CODE_SYS and CODE_TYPE='**' and CODE_NO=sc.CODE_TYPE) as CODE_TYPE_Name "
            StrSQL &= " from SYS_Code sc where 1=1"

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= " and sc.CODE_ORGID=@CODE_ORGID "
            End If
            If Not String.IsNullOrEmpty(CODE_SYS) Then
                StrSQL &= " and sc.CODE_SYS=@CODE_SYS "
            End If
            If Not String.IsNullOrEmpty(CODE_TYPE) Then
                StrSQL &= " and sc.CODE_TYPE=@CODE_TYPE "
            End If
            If Not String.IsNullOrEmpty(CODE_NO) Then
                StrSQL &= " and sc.CODE_NO=@CODE_NO "
            End If

            StrSQL &= " order by sc.CODE_SORT "

            Dim params() As SqlParameter = { _
            New SqlParameter("@CODE_ORGID", SqlDbType.VarChar), _
            New SqlParameter("@CODE_SYS", SqlDbType.VarChar), _
            New SqlParameter("@CODE_TYPE", SqlDbType.VarChar), _
            New SqlParameter("@CODE_NO", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = CODE_SYS
            params(2).Value = CODE_TYPE
            params(3).Value = CODE_NO

            Return Query(StrSQL, params)
        End Function
    End Class
End Namespace