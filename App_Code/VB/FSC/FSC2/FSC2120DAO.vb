Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC2120DAO
        Inherits BaseDAO

          ''' <summary>
        ''' 回傳人員類別
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getEmployeeTypeData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT CODE_DESC1,CODE_NO FROM SYS_CODE AS SC ")
            szSQL.AppendLine(" WHERE 1 = 1 ")
            szSQL.AppendLine(" AND SC.CODE_SYS=@CODE_SYS  ")
            szSQL.AppendLine(" AND SC.CODE_TYPE=@CODE_TYPE")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@CODE_SYS", SqlDbType.VarChar)
            params(0).Value = CODE_SYS
            params(1) = New SqlParameter("@CODE_TYPE", SqlDbType.VarChar)
            params(1).Value = CODE_TYPE

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 回傳慶生人員名單
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <param name="iMonth">月份</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="Employee_type">人員類別代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal iMonth As Integer, ByVal Depart_id As String, ByVal Employee_type As String) As DataTable
            Dim szSQL As String = String.Empty
            Dim params(IIf(String.IsNullOrEmpty(Employee_type), 3, Employee_type.Split(",").Length + 3)) As SqlParameter

            szSQL += " SELECT RANK() OVER (ORDER BY FDE.Depart_id, FP.Birth_date, FP.Id_card) AS '項次',"
            szSQL += " FO.Depart_name AS '單位名稱' ,"
            szSQL += " FP.User_name AS '姓名',"
            szSQL += " FP.Id_card AS '員工編號',"
            szSQL += " SC.CODE_DESC1 AS '職稱',"
            szSQL += " SUBSTRING (FP.Birth_date,4,2)+'/'+SUBSTRING (FP.Birth_date,6,2) AS '生日',' ' AS '禮券簽收'"
            szSQL += " FROM FSC_Personnel AS FP"
            szSQL += " LEFT JOIN FSC_Depart_EMP AS FDE ON FP.Id_card=FDE.Id_card"
            szSQL += " LEFT JOIN FSC_Org AS FO ON FDE.Depart_id=FO.Depart_id"
            szSQL += " LEFT JOIN SYS_CODE AS SC ON FP.Title_no=SC.CODE_NO "
            szSQL += " WHERE 1 = 1"
            szSQL += " AND SC.CODE_SYS=@CODE_SYS "
            szSQL += " AND SC.CODE_TYPE=@CODE_TYPE "

            If iMonth <> "-1" Then
                szSQL += " AND CONVERT(INT,SUBSTRING(FP.Birth_date,4,2))=@iMonth "
            End If
            If Depart_id <> "" Then
                szSQL += " AND FDE.Depart_id like @Depart_id "
            End If
            If Employee_type <> "" Then
                szSQL += " AND FP.Employee_type IN ("
                For i As Integer = 0 To Employee_type.Split(",").Length - 1
                    szSQL += "@Employee_type" + i.ToString() + ","
                    params(i + 4) = New SqlParameter("@Employee_type" + i.ToString(), SqlDbType.VarChar)
                    params(i + 4).Value = Employee_type.Split(",")(i)
                Next
                szSQL = szSQL.Trim(",") + ")"
            End If


            params(0) = New SqlParameter("@CODE_SYS", SqlDbType.VarChar)
            params(0).Value = CODE_SYS
            params(1) = New SqlParameter("@CODE_TYPE", SqlDbType.VarChar)
            params(1).Value = CODE_TYPE
            params(2) = New SqlParameter("@iMonth", SqlDbType.VarChar)
            params(2).Value = iMonth
            params(3) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            If String.IsNullOrEmpty(Depart_id) Then
                params(3).Value = Depart_id
            Else
                params(3).Value = Depart_id.Substring(0, 2) + "%"
            End If

            Return Query(szSQL.ToString(), params)
        End Function

    End Class
End Namespace
