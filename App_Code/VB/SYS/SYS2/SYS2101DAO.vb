Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Namespace SYS.Logic
    Public Class SYS2101DAO
        Inherits BaseDAO

      
        Public Function GetFormKind(ByVal orgcode As String, ByVal codeNos As String) As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT CODE_DESC1,CODE_NO FROM SYS_CODE AS SC ")
            szSQL.AppendLine(" WHERE  ")
            szSQL.AppendLine(" SC.CODE_ORGID=@orgcode ")
            szSQL.AppendLine(" AND SC.CODE_SYS='024'  ")
            szSQL.AppendLine(" AND SC.CODE_TYPE='**' ")

            Dim cs() As String = codeNos.Split(",")

            szSQL.AppendLine(" AND SC.CODE_NO IN ( ")
            For i As Integer = 0 To cs.Length - 1
                If i <> 0 Then
                    szSQL.AppendLine(", ")
                End If
                szSQL.AppendLine(" @CODE_NO" & i)
            Next
            szSQL.AppendLine(" ) ")

            Dim params(0 + cs.Length) As SqlParameter
            params(0) = New SqlParameter("orgcode", orgcode)
            For i As Integer = 0 To cs.Length - 1
                Dim c As String = ""
                If Not String.IsNullOrEmpty(cs(i)) Then
                    c = cs(i).ToString().Substring(0, 3)
                End If
                params(i + 1) = New SqlParameter("@CODE_NO" & i, c)
            Next

            Return Query(szSQL.ToString(), params)
        End Function

        Public Function GetFormType(ByVal orgcode As String, ByVal codeType As String, ByVal codeNos As String) As DataTable
            Dim szSQL As New StringBuilder

            szSQL.AppendLine(" SELECT CODE_DESC1,CODE_NO FROM SYS_CODE AS SC ")
            szSQL.AppendLine(" WHERE  ")
            szSQL.AppendLine(" SC.CODE_ORGID=@orgcode ")
            szSQL.AppendLine(" AND SC.CODE_SYS='024'  ")
            szSQL.AppendLine(" AND SC.CODE_TYPE=@codeType ")

            Dim cs() As String = codeNos.Split(",")

            szSQL.AppendLine(" AND SC.CODE_NO IN ( ")
            For i As Integer = 0 To cs.Length - 1
                If i <> 0 Then
                    szSQL.AppendLine(", ")
                End If
                szSQL.AppendLine(" @CODE_NO" & i)
            Next
            szSQL.AppendLine(" ) ")

            Dim params(1 + cs.Length) As SqlParameter
            params(0) = New SqlParameter("orgcode", orgcode)
            params(1) = New SqlParameter("codeType", codeType)

            For i As Integer = 0 To cs.Length - 1
                Dim c As String = ""
                If Not String.IsNullOrEmpty(cs(i)) Then
                    c = cs(i).ToString().Substring(3, 3)
                End If
                params(i + 2) = New SqlParameter("@CODE_NO" & i, c)
            Next

            Return Query(szSQL.ToString(), params)
        End Function

        Public Function GetFormData(ByVal orgcode As String, ByVal Start_date As String, ByVal End_date As String, ByVal formId As String, ByVal codeNos As String, ByVal caseStatus As String, ByVal lastPass As String, _
                                    ByVal Depart_id As String, ByVal id_card As String, ByVal id_card2 As String) As DataTable
            Dim sbSQL As New StringBuilder()

            sbSQL.AppendLine(" SELECT a.id, ")
            sbSQL.AppendLine("    a.Flow_id, ")
            sbSQL.AppendLine("    a.Orgcode, ")
            sbSQL.AppendLine("    (SELECT depart_name FROM fsc_org WHERE orgcode=a.orgcode AND depart_id=a.depart_id) Depart_name, ")
            sbSQL.AppendLine("    a.Apply_idcard, ")
            sbSQL.AppendLine("    a.Apply_name, ")
            sbSQL.AppendLine("    a.write_time, ")
            sbSQL.AppendLine("    a.Reason, ")
            sbSQL.AppendLine("    a.form_id, ")
            sbSQL.AppendLine("    a.merge_flag, ")
            sbSQL.AppendLine("    a.case_status, ")
            sbSQL.AppendLine("    a.Last_pass, ")
            sbSQL.AppendLine("    b.next_name, ")
            sbSQL.AppendLine("    (SELECT top 1 agree_time FROM SYS_Flow_detail d WHERE d.orgcode=a.orgcode AND d.flow_id=a.flow_id order by agree_time ) agree_time ")
            sbSQL.AppendLine(" FROM SYS_Flow a WITH(NOLOCK) ")
            sbSQL.AppendLine(" left join SYS_Flow_Next b on a.flow_id=b.flow_id ")

            sbSQL.AppendLine(" WHERE ")
            sbSQL.AppendLine(" a.orgcode=@orgcode ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sbSQL.AppendLine(" and (a.Depart_id = @Depart_id or a.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(id_card) Then
                sbSQL.AppendLine(" and a.Apply_idcard=@id_card ")
            End If
            If Not String.IsNullOrEmpty(id_card2) Then
                sbSQL.AppendLine(" and a.Apply_idcard=@id_card2 ")
            End If
            If Not String.IsNullOrEmpty(Start_date) Then
                sbSQL.AppendLine(" and  convert(varchar(8), a.write_time, 112)-19110000 >=@Start_date ")
            End If
            If Not String.IsNullOrEmpty(End_date) Then
                sbSQL.AppendLine(" and convert(varchar(8), a.write_time, 112)-19110000 <=@End_date ")
            End If
            If Not String.IsNullOrEmpty(formId) Then
                If formId.Length = 3 Then
                    formId = formId & "%"
                    sbSQL.AppendLine(" AND a.form_id like @formId ")
                Else
                    sbSQL.AppendLine(" AND a.form_id=@formId ")
                End If
            End If

            Dim caseStatus1 As String = ""
            Dim caseStatus2 As String = ""
            If caseStatus.IndexOf(",") >= 0 Then
                sbSQL.AppendLine("AND (a.case_status=@caseStatus1 or a.case_status=@caseStatus2) ")
                caseStatus1 = caseStatus.Split(",")(0)
                caseStatus2 = caseStatus.Split(",")(1)
            Else
                sbSQL.AppendLine("AND a.case_status=@caseStatus1 ")
                caseStatus1 = caseStatus
            End If

            sbSQL.AppendLine(" AND a.Last_pass=@lastPass ")

            Dim cs() As String = codeNos.Split(",")

            sbSQL.AppendLine(" AND a.form_id IN ( ")
            For i As Integer = 0 To cs.Length - 1
                If i <> 0 Then
                    sbSQL.AppendLine(", ")
                End If
                sbSQL.AppendLine(" @formId" & i)
            Next
            sbSQL.AppendLine(" ) ")


            Dim params(9 + cs.Length) As SqlParameter
            params(0) = New SqlParameter("@orgcode", orgcode)
            params(1) = New SqlParameter("@formId", formId)
            params(2) = New SqlParameter("@caseStatus1", caseStatus1)
            params(3) = New SqlParameter("@caseStatus2", caseStatus2)
            params(4) = New SqlParameter("@lastPass", lastPass)
            params(5) = New SqlParameter("@Depart_id", Depart_id)
            params(6) = New SqlParameter("@id_card", id_card)
            params(7) = New SqlParameter("@id_card2", id_card2)
            params(8) = New SqlParameter("@Start_date", Start_date)
            params(9) = New SqlParameter("@End_date", End_date)

            For i As Integer = 0 To cs.Length - 1
                params(i + 10) = New SqlParameter("@formId" & i, cs(i).ToString())
            Next

            Return Query(sbSQL.ToString(), params)
        End Function
    End Class
End Namespace
