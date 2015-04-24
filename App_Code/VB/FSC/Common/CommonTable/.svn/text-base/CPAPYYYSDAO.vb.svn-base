Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System
Imports FSCPLM.Logic

Namespace FSC.Logic
    Public Class CPAPYYYSDAO
        Inherits BaseDAO

        Private tableName As String

        Public Sub New(ByVal tableName As String)
            Me.tableName = tableName
        End Sub


        Public Function GetQueryByIdno(ByVal pyidno As String, ByVal pyvtype As String) As DataTable
            Dim sql As New StringBuilder()

            sql.AppendLine(" select pyvtype, pymon1 , pymon2, pymon3, pymon4, pymon5, pymon6, pymon7, pymon8, pymon9, pymon10, pymon11, pymon12, pytot ")
            sql.AppendLine(" from " & tableName & " ")
            sql.AppendLine(" where pyidno=@pyidno ")
            sql.AppendLine("    and pyvtype=@pyvtype")

            Dim params() As SqlParameter = { _
            New SqlParameter("@pyidno", pyidno), _
            New SqlParameter("@pyvtype", pyvtype)}

            Return Query(sql.ToString, params)
        End Function

        Public Function GetQueryData(ByVal pyidno As String, ByVal type As String) As DataTable
            Dim sql As New StringBuilder()
            sql.AppendLine(" select pyvtype, pymon1 , pymon2, pymon3, pymon4, pymon5, pymon6, pymon7, pymon8, pymon9, pymon10, pymon11, pymon12, pytot ")
            sql.AppendLine(" from " & tableName & " ")
            sql.AppendLine(" where 1=1 ")

            If Not String.IsNullOrEmpty(pyidno) Then
                sql.AppendLine(" and pyidno=@pyidno ")
            End If

            Dim leave_type As String = String.Empty

            For i As Integer = 1 To 25
                'leave_type &= "'" & i.ToString.PadLeft(2, "0") & "',"
                '它不應為2碼
                leave_type &= "'" & i.ToString() & "',"
            Next

            If type = "3" Then
                '免刷卡人員
                leave_type = leave_type.Trim(",")
                sql.Append(" and pyvtype in (" & leave_type & ") ")
            Else
                sql.Append(" and pyvtype in (" & leave_type & "'51','52','53','57') ")
            End If

            sql.Append(" ORDER BY pycard, pyvtype ")

            Dim params() As SqlParameter = {New SqlParameter("@pyidno", pyidno)}

            Return Query(sql.ToString, params)
        End Function

        Public Function UpdateData(ByVal PYMON1 As Double, ByVal PYMON2 As Double, ByVal PYMON3 As Double, ByVal PYMON4 As Double, ByVal PYMON5 As Double, _
                                   ByVal PYMON6 As Double, ByVal PYMON7 As Double, ByVal PYMON8 As Double, ByVal PYMON9 As Double, ByVal PYMON10 As Double, _
                                   ByVal PYMON11 As Double, ByVal PYMON12 As Double, ByVal PYTOT As Double, ByVal PYIDNO As String, ByVal PYVTYPE As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine("UPDATE " & Me.tableName & " ")
            sql.AppendLine("SET PYMON1=@PYMON1, PYMON2=@PYMON2, PYMON3=@PYMON3, PYMON4=@PYMON4, PYMON5=@PYMON5, ")
            sql.AppendLine("    PYMON6=@PYMON6, PYMON7=@PYMON7, PYMON8=@PYMON8, PYMON9=@PYMON9, PYMON10=@PYMON10, ")
            sql.AppendLine("    PYMON11=@PYMON11, PYMON12=@PYMON12, PYTOT=@PYTOT, PYUSERID=@PYUSERID, PYUPDATE=@PYUPDATE ")
            sql.AppendLine("WHERE PYIDNO=@PYIDNO AND PYVTYPE=@PYVTYPE ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@PYMON1", SqlDbType.Float), _
            New SqlParameter("@PYMON2", SqlDbType.Float), _
            New SqlParameter("@PYMON3", SqlDbType.Float), _
            New SqlParameter("@PYMON4", SqlDbType.Float), _
            New SqlParameter("@PYMON5", SqlDbType.Float), _
            New SqlParameter("@PYMON6", SqlDbType.Float), _
            New SqlParameter("@PYMON7", SqlDbType.Float), _
            New SqlParameter("@PYMON8", SqlDbType.Float), _
            New SqlParameter("@PYMON9", SqlDbType.Float), _
            New SqlParameter("@PYMON10", SqlDbType.Float), _
            New SqlParameter("@PYMON11", SqlDbType.Float), _
            New SqlParameter("@PYMON12", SqlDbType.Float), _
            New SqlParameter("@PYTOT", SqlDbType.Float), _
            New SqlParameter("@PYIDNO", SqlDbType.VarChar), _
            New SqlParameter("@PYVTYPE", SqlDbType.VarChar), _
            New SqlParameter("@PYUSERID", SqlDbType.VarChar), _
            New SqlParameter("@PYUPDATE", SqlDbType.VarChar)}
            params(0).Value = PYMON1
            params(1).Value = PYMON2
            params(2).Value = PYMON3
            params(3).Value = PYMON4
            params(4).Value = PYMON5
            params(5).Value = PYMON6
            params(6).Value = PYMON7
            params(7).Value = PYMON8
            params(8).Value = PYMON9
            params(9).Value = PYMON10
            params(10).Value = PYMON11
            params(11).Value = PYMON12
            params(12).Value = PYTOT
            params(13).Value = PYIDNO
            params(14).Value = PYVTYPE
            params(15).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(16).Value = FSCPLM.Logic.DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss")

            Return Execute(sql.ToString(), params)
        End Function

        Public Function CheckHasData(ByVal PYIDNO As String) As Integer
            Dim StrSQL As String = "SELECT COUNT(*) FROM " & tableName & " WHERE PYIDNO=@PYIDNO "
            Dim param As SqlParameter = New SqlParameter("@PYIDNO", SqlDbType.VarChar)
            param.Value = PYIDNO
            
            Return Scalar(StrSQL, param)
        End Function


        Public Function CheckHasTable() As Integer
            Dim StrSQL As String = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES where table_name = @table_name"
            Dim param As SqlParameter = New SqlParameter("@table_name", SqlDbType.VarChar)
            param.Value = tableName

            Return Scalar(StrSQL, param)
        End Function

        Public Function CreateTABLE() As Integer
            Dim sql As New StringBuilder
            sql.AppendLine("CREATE TABLE " & tableName & " (")
            sql.AppendLine("    PYIDNO CHAR(10) NULL, ")
            sql.AppendLine("    PYNAME CHAR(12) NULL, ")
            sql.AppendLine("    PYCARD CHAR(10) NULL, ")
            sql.AppendLine("    PYVTYPE CHAR(2) NULL, ")
            sql.AppendLine("    PYMON1  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON2  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON3  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON4  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON5  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON6  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON7  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON8  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON9  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON10  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON11  FLOAT(8) NULL, ")
            sql.AppendLine("    PYMON12  FLOAT(8) NULL, ")
            sql.AppendLine("    PYTOT   FLOAT(8) NULL, ")
            sql.AppendLine("    PYUSERID CHAR(10) NULL, ")
            sql.AppendLine("    PYUPDATE CHAR(13) NULL) ")

            Return Execute(sql.ToString())
        End Function

        Public Function InsertDefaultData(ByVal PYIDNO As String, ByVal PYCARD As String, ByVal PYNAME As String) As Integer
            Dim sql As New StringBuilder

            For PYVTYPE As Integer = 1 To 25
                sql.AppendLine(" INSERT INTO " & tableName & " ")
                sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
                sql.AppendLine(" VALUES ")
                sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '" & PYVTYPE.ToString.PadLeft(2, "0") & "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")
            Next

            For PYVTYPE As Integer = 51 To 53
                sql.AppendLine(" INSERT INTO " & tableName & " ")
                sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
                sql.AppendLine(" VALUES ")
                sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '" & PYVTYPE.ToString.PadLeft(2, "0") & "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")
            Next

            sql.AppendLine(" INSERT INTO " & tableName & " ")
            sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
            sql.AppendLine(" VALUES ")
            sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '28', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")

            sql.AppendLine(" INSERT INTO " & tableName & " ")
            sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
            sql.AppendLine(" VALUES ")
            sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '30', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")

            sql.AppendLine(" INSERT INTO " & tableName & " ")
            sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
            sql.AppendLine(" VALUES ")
            sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '31', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")

            sql.AppendLine(" INSERT INTO " & tableName & " ")
            sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
            sql.AppendLine(" VALUES ")
            sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '55', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")

            sql.AppendLine(" INSERT INTO " & tableName & " ")
            sql.AppendLine(" (PYIDNO, PYNAME, PYCARD, PYVTYPE, PYMON1, PYMON2, PYMON3, PYMON4, PYMON5, PYMON6, PYMON7, PYMON8, PYMON9, PYMON10, PYMON11, PYMON12, PYTOT, PYUSERID, PYUPDATE )")
            sql.AppendLine(" VALUES ")
            sql.AppendLine(" ('" & PYIDNO & "', '" & PYNAME & "','" & PYCARD & "', '57', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" & LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account) & "', '" & DateTimeInfo.GetRocDate(Now) & Now.ToString("HHmmss") & "');")

            Return Execute(sql.ToString())
        End Function

        Public Function GetDataByIdnoType(ByVal pyidno As String, ByVal pyvtype As String) As DataTable
            Dim sql As New StringBuilder
            sql.Append("select * from " & tableName & " ")
            sql.Append("where pyidno=@pyidno and pyvtype=@pyvtype ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@pyidno", SqlDbType.VarChar), _
            New SqlParameter("@pyvtype", SqlDbType.VarChar)}
            params(0).Value = pyidno
            params(1).Value = pyvtype

            Return Query(sql.ToString(), params)
        End Function


        Public Function UpdateDataByColumn(ByVal column As String, ByVal value As Double, ByVal pyidno As String, ByVal pyvtype As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" update " & tableName & " ")
            sql.AppendLine(" set " & column & "= case when (" & column & "+@value)<0 then 0 else (" & column & "+@value) end, ")
            sql.AppendLine("     PYTOT= case when (PYTOT+@value)<0 then 0 else (PYTOT+@value) end ")
            sql.AppendLine(" where pyidno=@pyidno and pyvtype=@pyvtype ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@value", SqlDbType.Float), _
            New SqlParameter("@pyidno", SqlDbType.VarChar), _
            New SqlParameter("@pyvtype", SqlDbType.VarChar)}
            params(0).Value = value
            params(1).Value = pyidno
            params(2).Value = pyvtype

            Return Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace