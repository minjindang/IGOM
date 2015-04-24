Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System
Imports System.Text

Namespace FSC.Logic
    Public Class CPAPHYYMMDAO
        Inherits BaseDAO
        Private table_name As String

        Public Sub New(ByVal table_name As String)
            Me.table_name = table_name

            If CheckHasTable() <= 0 Then
                Throw New Exception("尚無此資料表")
            End If
        End Sub

        Public Function CheckHasTable() As Integer
            Dim StrSQL As String = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES where table_name = @table_name"
            Dim param As SqlParameter = New SqlParameter("@table_name", SqlDbType.VarChar)
            param.Value = table_name
            Return Scalar(StrSQL, param)
        End Function

        Public Function GetUnNoramlData(ByVal PKCARD As String) As DataTable
            Dim StrSQL As String = "SELECT * FROM " & table_name & " WHERE PKCARD=@PKCARD AND (PKWKTPE='0' OR PKWKTPE='7')"
            Dim param As SqlParameter = New SqlParameter("@PKCARD", SqlDbType.VarChar)
            param.Value = PKCARD
            Return Query(StrSQL, param)
        End Function

        Public Function DeleteData(ByVal PKCARD As String, ByVal PKWDATE As String) As Integer
            Dim StrSQL As String = "DELETE FROM " & table_name & " WHERE PKCARD=@PKCARD AND PKWDATE=@PKWDATE"
            Dim params() As SqlParameter = { _
            New SqlParameter("@PKCARD", SqlDbType.VarChar), _
            New SqlParameter("@PKWDATE", SqlDbType.VarChar)}
            params(0).Value = PKCARD
            params(1).Value = PKWDATE
            Return Execute(StrSQL, params)
        End Function


        Public Function GetFirstCard(ByVal PHICARD As String, ByVal IDNO As String, ByVal PHIDATE As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine(" SELECT Min(PHITIME) as PHITIME, PHITYPE ")
            StrSQL.AppendLine(" FROM " & table_name & " ")
            StrSQL.AppendLine(" WHERE (PHCARD=@PHCARD OR PHCARD=@IDNO) AND PHIDATE=@PHIDATE AND PHITYPE='A' ")
            StrSQL.AppendLine(" group by PHITYPE ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@PHCARD", PHICARD), _
            New SqlParameter("@IDNO", IDNO), _
            New SqlParameter("@PHIDATE", PHIDATE)}
            Return Query(StrSQL.ToString(), param)
        End Function

        Public Function GetListData(ByVal PHICARD As String, ByVal IDNO As String, ByVal PHIDATE As String) As DataTable
            Dim StrSQL As New StringBuilder
            StrSQL.AppendLine(" SELECT * ")
            StrSQL.AppendLine(" FROM " & table_name & " ")
            StrSQL.AppendLine(" WHERE (PHCARD=@PHCARD OR PHCARD=@IDNO) AND PHIDATE=@PHIDATE ORDER BY PHITIME ")

            Dim param() As SqlParameter = { _
            New SqlParameter("@PHCARD", PHICARD), _
            New SqlParameter("@IDNO", IDNO), _
            New SqlParameter("@PHIDATE", PHIDATE)}
            Return Query(StrSQL.ToString(), param)
        End Function


        Public Function InsertData(ByVal PHADDR As String, ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHITIME As String, _
                                    ByVal PHITYPE As String, ByVal PHCARDVER As String) As Integer
            Dim SQL As New StringBuilder
            SQL.AppendLine("INSERT INTO " & table_name & " ")
            SQL.AppendLine("(PHADDR, PHCARD, PHIDATE, PHITIME, PHITYPE, PHCARDVER, change_userid, change_date) ")
            SQL.AppendLine("VALUES ")
            SQL.AppendLine("(@PHADDR, @PHCARD, @PHIDATE, @PHITIME, @PHITYPE, @PHCARDVER, @change_userid, @change_date)")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PHADDR", SqlDbType.VarChar), _
            New SqlParameter("@PHCARD", SqlDbType.VarChar), _
            New SqlParameter("@PHIDATE", SqlDbType.VarChar), _
            New SqlParameter("@PHITIME", SqlDbType.VarChar), _
            New SqlParameter("@PHITYPE", SqlDbType.VarChar), _
            New SqlParameter("@PHCARDVER", SqlDbType.VarChar), _
            New SqlParameter("@change_userid", SqlDbType.VarChar), _
            New SqlParameter("@change_date", SqlDbType.DateTime)}
            params(0).Value = PHADDR
            params(1).Value = PHCARD
            params(2).Value = PHIDATE
            params(3).Value = PHITIME
            params(4).Value = PHITYPE
            params(5).Value = PHCARDVER
            params(6).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(7).Value = Now
            Return Execute(SQL.ToString(), params)
        End Function


        Public Function DeleteData(ByVal PHADDR As String, _
                                   ByVal PHCARD As String, _
                                   ByVal PHIDATE As String, _
                                   ByVal PHITIME As String, _
                                   ByVal PHITYPE As String, _
                                   ByVal PHCARDVER As String) As Integer

            Dim SQL As New StringBuilder()
            SQL.AppendLine(" DELETE FROM " & table_name & " ")
            SQL.AppendLine(" WHERE ")
            SQL.AppendLine(" PHADDR=@PHADDR AND PHCARD=@PHCARD AND PHIDATE=@PHIDATE AND PHITIME=@PHITIME AND PHITYPE=@PHITYPE AND PHCARDVER=@PHCARDVER ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@PHADDR", SqlDbType.VarChar), _
            New SqlParameter("@PHCARD", SqlDbType.VarChar), _
            New SqlParameter("@PHIDATE", SqlDbType.VarChar), _
            New SqlParameter("@PHITIME", SqlDbType.VarChar), _
            New SqlParameter("@PHITYPE", SqlDbType.VarChar), _
            New SqlParameter("@PHCARDVER", SqlDbType.VarChar)}
            params(0).Value = PHADDR
            params(1).Value = PHCARD
            params(2).Value = PHIDATE
            params(3).Value = PHITIME
            params(4).Value = PHITYPE
            params(5).Value = PHCARDVER
            Return Execute(SQL.ToString(), params)
        End Function


        Public Function UpdateDataOut(ByVal PHCARD As String, ByVal PHIDATE As String) As Integer
            Dim sql As New StringBuilder

            sql.AppendLine(" update " & table_name & " ")
            sql.AppendLine(" set phitype='D', ")
            sql.AppendLine("     phuserid='intrant', ")
            sql.AppendLine("     phupdate=@phupdate ")
            sql.AppendLine(" where phcard=@phcard and phidate=@phidate ")
            sql.AppendLine("    and phitime=(select max(phitime) from " & table_name & " where phcard=@phcard and phidate=@phidate )")

            Dim params() As SqlParameter = { _
            New SqlParameter("@phcard", SqlDbType.VarChar), _
            New SqlParameter("@phidate", SqlDbType.VarChar), _
            New SqlParameter("@phupdate", SqlDbType.VarChar)}
            params(0).Value = PHCARD
            params(1).Value = PHIDATE
            params(2).Value = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMddHHmmss")

            Return Execute(sql.ToString, params)
        End Function

        Public Function GetData(ByVal PHCARD As String, ByVal PHIDATE As String, ByVal PHITYPE As String) As DataTable
            Dim StrSQL As String = "select * FROM " & table_name & " WHERE PHCARD=@PHCARD AND PHIDATE=@PHIDATE and PHITYPE=@PHITYPE"
            Dim params() As SqlParameter = { _
            New SqlParameter("@PHCARD", SqlDbType.VarChar), _
            New SqlParameter("@PHIDATE", SqlDbType.VarChar), _
            New SqlParameter("@PHITYPE", SqlDbType.VarChar)}
            params(0).Value = PHCARD
            params(1).Value = PHIDATE
            params(2).Value = PHITYPE
            Return Query(StrSQL, params)
        End Function


        Public Function GetData(ByVal PHCARD As String, ByVal PHIDATE As String) As DataTable
            Dim StrSQL As String = "select * FROM " & table_name & " WHERE PHCARD=@PHCARD AND PHIDATE=@PHIDATE order by PHITIME "
            Dim params() As SqlParameter = { _
            New SqlParameter("@PHCARD", SqlDbType.VarChar), _
            New SqlParameter("@PHIDATE", SqlDbType.VarChar)}
            params(0).Value = PHCARD
            params(1).Value = PHIDATE
            Return Query(StrSQL, params)
        End Function

        Public Function get2122Data(ByVal orgcode As String, ByVal depart_id As String, ByVal PHCARD As String, _
                                    ByVal PHCARD2 As String, ByVal Sdate As String, ByVal Edate As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select h.*, p.User_Name, ")

            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f where f.orgcode=d.orgcode and f.depart_id=d.depart_id) as Depart_Name")
            Else
                sql.AppendLine(" (select top 1 Depart_Name from FSC_Org f inner join FSC_Depart_emp d  on f.orgcode=d.orgcode and f.depart_id=d.depart_id where d.id_card=p.id_card) as Depart_Name")
            End If

            sql.AppendLine(" from " & table_name & " h ")
            sql.AppendLine(" inner join FSC_personnel p on p.id_card=h.PHCARD ")

            If Not String.IsNullOrEmpty(depart_id) Then
                sql.AppendLine(" inner join FSC_Depart_emp d on p.id_card=d.id_card ")
            End If
            sql.AppendLine(" where PHADDR='L1' ")

            If Not String.IsNullOrEmpty(depart_id) Then
                If Not String.IsNullOrEmpty(orgcode) Then
                    sql.AppendLine(" and d.orgcode=@orgcode ")
                End If
                sql.AppendLine(" and (d.Depart_id = @Depart_id or d.Depart_id in (select depart_id from fsc_org where parent_depart_id=@Depart_id))")
            End If
            If Not String.IsNullOrEmpty(PHCARD) Then
                sql.AppendLine(" and p.Id_number in (select id_number from FSC_Personnel where id_card=@PHCARD) ")
            End If
            If Not String.IsNullOrEmpty(PHCARD2) Then
                sql.AppendLine(" and p.Id_number in (select id_number from FSC_Personnel where id_card=@PHCARD2) ")
            End If
            If Not String.IsNullOrEmpty(Sdate) Then
                sql.AppendLine(" and h.PHIDATE >= @Sdate ")
            End If
            If Not String.IsNullOrEmpty(Edate) Then
                sql.AppendLine(" and h.PHIDATE <= @Edate ")
            End If
            If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId).IndexOf("Secretariat") >= 0 Then
                sql.AppendLine(" and p.Employee_type in ('3','8') ")
            End If

            sql.AppendLine(" order by (case when p.Boss_level_id=0 then 99 else p.Boss_level_id end), p.id_card ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@orgcode", SqlDbType.VarChar), _
            New SqlParameter("@depart_id", SqlDbType.VarChar), _
            New SqlParameter("@PHCARD", SqlDbType.VarChar), _
            New SqlParameter("@PHCARD2", SqlDbType.VarChar), _
            New SqlParameter("@Sdate", SqlDbType.VarChar), _
            New SqlParameter("@Edate", SqlDbType.VarChar)}
            params(0).Value = orgcode
            params(1).Value = depart_id
            params(2).Value = PHCARD
            params(3).Value = PHCARD2
            params(4).Value = Sdate
            params(5).Value = Edate

            Return Query(sql.ToString(), params)
        End Function
    End Class
End Namespace