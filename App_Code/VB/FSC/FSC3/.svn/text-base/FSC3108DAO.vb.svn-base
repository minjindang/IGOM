Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text

Namespace FSC.Logic
    Public Class FSC3108DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Function getData(ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHIDATE2 As String, ByVal PHITYPE As String, ByVal PHITIME As String) As DataTable

            Dim YYMM As String = Integer.Parse(PHIDATE).ToString().Substring(0, Integer.Parse(PHIDATE).ToString().Length() - 2)
            Dim sSQL As New StringBuilder()
            sSQL.Append(" SELECT * ")
            sSQL.Append(" FROM FSC_CPAPH" + YYMM)
            sSQL.Append(" WHERE PHIDATE>=@PHIDATE ")

            If PHCARD <> "" Then
                sSQL.Append(" and PHCARD = @PHCARD ")
            End If
            If PHIDATE2 <> "" Then
                sSQL.Append(" and PHIDATE <=@PHIDATE2 ")
            End If
            If "" <> PHITYPE Then
                sSQL.Append(" and PHITYPE =@PHITYPE ")
            End If

            If "" <> PHITIME Then
                sSQL.Append(" and PHITIME =@PHITIME ")
            End If

            Dim params() As SqlParameter = {New SqlParameter("@PHCARD", PHCARD), New SqlParameter("@PHIDATE", PHIDATE), New SqlParameter("@PHIDATE2", PHIDATE2), New SqlParameter("@PHITYPE", PHITYPE), New SqlParameter("@PHITIME", PHITIME)}
            Return Query(sSQL.ToString, params)
        End Function

        Public Sub update(ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHITYPE As String, ByVal PHITIME As String, _
                            ByVal MPHIDATE As String, ByVal MPHITYPE As String, ByVal MPHITIME As String)

            Dim YYMM As String = Integer.Parse(PHIDATE).ToString().Substring(0, Integer.Parse(PHIDATE).ToString().Length() - 2)
            Dim sql As New StringBuilder()
            sql.AppendLine(" Update ")
            sql.AppendLine(" FSC_CPAPH" + YYMM)
            sql.AppendLine(" Set ")
            sql.AppendLine(" PHIDATE = @PHIDATE , ")
            sql.AppendLine(" PHITYPE = @PHITYPE , ")
            sql.AppendLine(" PHITIME = @PHITIME , ")
            sql.AppendLine(" Change_userid = @Change_userid , ")
            sql.AppendLine(" Change_date = @Change_date ")
            sql.AppendLine(" WHERE PHCARD = @PHCARD ")
            sql.AppendLine("    and PHIDATE = @MPHIDATE ")
            sql.AppendLine("    and PHITYPE = @MPHITYPE ")
            If Not String.IsNullOrEmpty(MPHITIME) Then
                sql.AppendLine("    and PHITIME = @MPHITIME ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@PHIDATE", PHIDATE), _
            New SqlParameter("@PHITYPE", PHITYPE), _
            New SqlParameter("@PHITIME", PHITIME), _
            New SqlParameter("@PHCARD", PHCARD), _
            New SqlParameter("@Change_userid", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)), _
            New SqlParameter("@Change_date", Date.Now), _
            New SqlParameter("@MPHIDATE", MPHIDATE), _
            New SqlParameter("@MPHITYPE", MPHITYPE), _
            New SqlParameter("@MPHITIME", MPHITIME)}

            Execute(sql.ToString, params)
        End Sub

    End Class
End Namespace
