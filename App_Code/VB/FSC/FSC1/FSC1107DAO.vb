Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC1107DAO
        Inherits BaseDAO

        ''' <summary>
        ''' 回傳類別名稱與代碼
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCodeData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT CODE_NO ,CODE_DESC1 FROM SYS_CODE AS SC ")
            szSQL.AppendLine(" WHERE 1 = 1 ")
            szSQL.AppendLine(" AND SC.CODE_SYS=@CODE_SYS ")
            szSQL.AppendLine(" AND SC.CODE_TYPE=@CODE_TYPE ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@CODE_SYS", SqlDbType.VarChar)
            params(0).Value = CODE_SYS
            params(1) = New SqlParameter("@CODE_TYPE", SqlDbType.VarChar)
            params(1).Value = CODE_TYPE

            Return Query(szSQL.ToString(), params)
        End Function

        ''' <summary>
        ''' 新增【在職/服務中文證明資料檔】
        ''' </summary>
        ''' <param name="flow_id">表單編號</param>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="id_card">員工編號</param>
        ''' <param name="Apply_name">姓名</param>
        ''' <param name="Apply_date">申請日期</param>
        ''' <param name="Apply_type">申請類別</param>
        ''' <param name="Apply_copies">申請份數</param>
        ''' <param name="Purpose">用途</param>
        ''' <param name="Notes">備註說明</param>
        ''' <param name="Change_userid">異動人員</param>
        ''' <param name="Change_date">異動時間</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertWorkserviceProof(ByVal flow_id As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal id_card As String, ByVal Apply_name As String, ByVal Apply_date As String, ByVal Apply_type As String, ByVal Apply_copies As String, ByVal Purpose As String, ByVal Notes As String, ByVal Change_userid As String, ByVal Change_date As DateTime) As Integer
            Dim szSQL As New StringBuilder()

            szSQL.AppendLine(" INSERT INTO FSC_Workservice_proof (flow_id,Orgcode,Depart_id,id_card,Apply_name,Apply_date,Apply_type,Apply_copies,Purpose,Notes,Change_userid,Change_date) ")
            szSQL.AppendLine(" VALUES  ")
            szSQL.AppendLine(" (@flow_id,@Orgcode,@Depart_id,@id_card,@Apply_name,@Apply_date,@Apply_type,@Apply_copies,@Purpose,@Notes,@Change_userid,@Change_date) ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@Depart_id", Depart_id), _
            New SqlParameter("@id_card", id_card), _
            New SqlParameter("@Apply_name", Apply_name), _
            New SqlParameter("@Apply_date", Apply_date), _
            New SqlParameter("@Apply_type", Apply_type), _
            New SqlParameter("@Apply_copies", Apply_copies), _
            New SqlParameter("@Purpose", Purpose), _
            New SqlParameter("@Notes", Notes), _
            New SqlParameter("@Change_userid", Change_userid), _
            New SqlParameter("@Change_date", Change_date)}

            Return Execute(szSQL.ToString(), params)
        End Function

    End Class
End Namespace
