Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace FSC.Logic
    Public Class FSC4101DAO
        Inherits BaseDAO

        Dim sbSQL As New StringBuilder

        ''' <summary>
        ''' 回傳單位名稱/科別名稱
        ''' </summary>
        ''' <param name="orgcode">機關代號</param>
        ''' <param name="departId">單位代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepart(ByVal orgcode As String, ByVal departId As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT Depart_id,Depart_name  FROM FSC_Org WHERE Orgcode=@orgcode  ")

            If departId = "" Then
                sbSQL.AppendLine(" AND Parent_depart_id IS NULL ")
            Else
                sbSQL.AppendLine(" AND Parent_depart_id=@departId ")
            End If

            Dim param() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId)}
            Return Query(sbSQL.ToString(), param)

        End Function

        ''' <summary>
        ''' 回傳職稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCODE(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT CODE_NO,CODE_DESC1  FROM SYS_CODE WHERE CODE_SYS=@CODE_SYS AND CODE_TYPE=@CODE_TYPE ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@CODE_SYS", CODE_SYS), _
            New SqlParameter("@CODE_TYPE", CODE_TYPE)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 回傳人員姓名
        ''' </summary>
        ''' <param name="orgcode">機關代硯</param>
        ''' <param name="departId">部門代碼</param>
        ''' <param name="title">職稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserName(ByVal orgcode As String, ByVal departId As String, ByVal title As String) As DataTable
            sbSQL.Length = 0
            sbSQL.AppendLine(" SELECT P.Id_card,P.User_name ")
            sbSQL.AppendLine(" FROM FSC_Personnel P ")
            sbSQL.AppendLine(" LEFT JOIN FSC_Depart_EMP DE ON P.Id_card=DE.Id_card ")

            If title <> "" Then
                sbSQL.AppendLine(" LEFT JOIN SYS_CODE SC ON P.Title_no=SC.CODE_NO ")
            End If
            sbSQL.AppendLine(" WHERE DE.Orgcode=@orgcode ")

            If departId <> "" Then
                sbSQL.AppendLine(" AND Depart_id=@departId ")
            End If

            If title <> "" Then
                sbSQL.AppendLine(" AND SC.CODE_SYS='023' AND SC.CODE_TYPE='012' AND SC.CODE_NO=@title ")
            End If

            sbSQL.AppendLine("  ORDER BY P.Id_card ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@departId", departId), _
            New SqlParameter("@title", title)}
            Return Query(sbSQL.ToString(), param)
        End Function

        ''' <summary>
        ''' 查詢資料
        ''' </summary>
        ''' <param name="orgcode">機關代碼</param>
        ''' <param name="departId">單位名稱</param>
        ''' <param name="subdepartId">科別名稱</param>
        ''' <param name="title">職稱</param>
        ''' <param name="Name">人員姓名</param>
        ''' <param name="years">年度</param>
        ''' <param name="Works">在職狀況</param>
        ''' <param name="idcard">員工編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getData(ByVal orgcode As String, ByVal departId As String, ByVal subdepartId As String, ByVal title As String, ByVal Name As String, ByVal years As String, ByVal Works As String, ByVal idcard As String) As DataTable
            sbSQL.Length = 0
            '1.身份證字號:10碼
            '2.姓名:12碼
            '3.員工代碼:10碼
            '4.請假別:2碼
            '5.假別名稱:8碼
            '6.開始日期:6碼 YYMMDD
            '7.結束日期:6碼 YYMMDD
            '8.開始時間:4碼 HHMM
            '9.結束時間:4碼 HHMM
            '10.合計日時數:7碼
            '11.合計日時數是否含假日期:1碼
            '12.出差地點:20碼
            '13.INTRANET KEY:32碼
            sbSQL.AppendLine(" SELECT ")
            sbSQL.AppendLine(" P.Id_number AS idno, ")
            sbSQL.AppendLine(" P.User_name AS NAME, ")
            sbSQL.AppendLine(" P.Id_card AS CARD, ")
            sbSQL.AppendLine(" F.Apply_stype AS type, ")
            sbSQL.AppendLine(" LG.Leave_group_name AS type_name, ")
            sbSQL.AppendLine(" LM.Start_date AS dateb, ")
            sbSQL.AppendLine(" LM.End_date AS datee, ")
            sbSQL.AppendLine(" LM.Start_time AS timeb, ")
            sbSQL.AppendLine(" LM.End_time AS timee, ")
            sbSQL.AppendLine(" LM.Leave_hours AS dayhours, ")
            sbSQL.AppendLine(" LM.Place AS place ")
            sbSQL.AppendLine(" FROM FSC_Personnel P LEFT JOIN SYS_Flow F ON P.Id_card=F.Apply_idcard ")
            sbSQL.AppendLine(" LEFT JOIN FSC_leave_main LM ON F.Flow_id=LM.Flow_id ")
            sbSQL.AppendLine(" LEFT JOIN SYS_Leave_group LG ON F.Apply_stype=LG.Leave_group_id ")

            sbSQL.AppendLine(" WHERE 1 = 1 ")

            If Not String.IsNullOrEmpty(orgcode) Then
                sbSQL.AppendLine(" AND LM.Orgcode=@orgcode ")
            End If
            If String.IsNullOrEmpty(subdepartId) Then
                sbSQL.AppendLine(" AND LM.Depart_id=@departId ")
            Else
                sbSQL.AppendLine(" AND LM.Depart_id=@subdepartId ")
            End If
            If Not String.IsNullOrEmpty(title) Then
                sbSQL.AppendLine(" AND P.Title_no=@title ")
            End If
            If Not String.IsNullOrEmpty(Name) Then
                sbSQL.AppendLine(" AND P.User_name=@Name ")
            End If
            If Not String.IsNullOrEmpty(years) Then
                sbSQL.AppendLine(" AND LM.Start_date LIKE @years ")
            End If
            'If Not String.IsNullOrEmpty(Works) Then
            '    sbSQL.AppendLine(" AND =@Works ")
            'End If
            If Not String.IsNullOrEmpty(idcard) Then
                sbSQL.AppendLine(" AND P.Id_card=@idcard ")
            End If

            Dim param() As SqlParameter = { _
        New SqlParameter("@orgcode", orgcode), _
        New SqlParameter("@departId", departId), _
        New SqlParameter("@subdepartId", subdepartId), _
        New SqlParameter("@title", title), _
        New SqlParameter("@Name", Name), _
        New SqlParameter("@years", years + "%"), _
        New SqlParameter("@Works", Works), _
        New SqlParameter("@idcard", idcard)}

            Return Query(sbSQL.ToString(), param)
        End Function

    End Class
End Namespace
