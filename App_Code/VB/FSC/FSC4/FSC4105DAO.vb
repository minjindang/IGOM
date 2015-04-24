Imports Microsoft.VisualBasic
Imports System.Data
Imports Pemis2009.SQLAdapter
Imports System.Data.SqlClient
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class FSC4105DAO
        Inherits BaseDAO

        Dim connstring As String
        Public Sub New()
            MyBase.New()
            Me.connstring = ConnectDB.GetDBString()
        End Sub

        Public Function getQueryData(ByVal Orgcode As String, _
                                     ByVal Depart_id As String, _
                                     ByVal Id_card As String, _
                                     ByVal Deputy_active As String, _
                                     ByVal User_name As String) As DataTable

            Dim sql As New StringBuilder()
            sql.AppendLine(" select p.*, ")
            sql.AppendLine(" (select top 1 Depart_name from FSC_Org f where f.orgcode=de.orgcode and f.depart_id=de.depart_id ) as Depart_name, ")
            sql.AppendLine(" (select top 1 User_name from FSC_personnel f where f.id_card=p.deputy_active_idcard ) as Deputy_active_name ")
            sql.AppendLine(" from FSC_Personnel p ")
            sql.AppendLine(" inner join FSC_Depart_emp de on p.id_card=de.id_card ")
            sql.AppendLine(" where 1= 1")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and de.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and (de.Depart_id=@Depart_id or de.Depart_id in (select Depart_id from FSC_Org where parent_depart_id = @Depart_id)) ")
            End If
            If Not String.IsNullOrEmpty(Id_card) Then
                sql.AppendLine(" and de.Id_card=@Id_card ")
            End If
            If Not String.IsNullOrEmpty(Deputy_active) Then
                If Deputy_active = "Y" Then
                    sql.AppendLine(" and p.Deputy_active=@Deputy_active ")
                Else
                    sql.AppendLine(" and (p.Deputy_active=@Deputy_active or p.Deputy_active is null) ")
                End If
            End If
            If Not String.IsNullOrEmpty(User_name) Then
                sql.AppendLine(" and p.user_name like '%'+@user_name+'%' ")
            End If

            Dim aryParms(4) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.NVarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Id_card", SqlDbType.NVarChar)
            aryParms(2).Value = Id_card
            aryParms(3) = New SqlParameter("@Deputy_active", SqlDbType.NVarChar)
            aryParms(3).Value = Deputy_active
            aryParms(4) = New SqlParameter("@user_name", SqlDbType.NVarChar)
            aryParms(4).Value = User_name

            Return Query(sql.ToString(), aryParms)
        End Function

        Public Function updateDeputyactive(ByVal Id_card As String, ByVal Deputy_active As String, ByVal Deputy_active_idcard As String, _
                                           ByVal Deputy_active_sdate As String, ByVal Deputy_active_stime As String, _
                                           ByVal Deputy_active_edate As String, ByVal Deputy_active_etime As String) As Integer
            Dim sql As StringBuilder = New StringBuilder()
            sql.AppendLine(" update FSC_Personnel set Deputy_active=@Deputy_active, Deputy_active_idcard=@Deputy_active_idcard, ")
            sql.AppendLine(" Deputy_active_sdate=@Deputy_active_sdate, Deputy_active_stime=@Deputy_active_stime, ")
            sql.AppendLine(" Deputy_active_edate=@Deputy_active_edate, Deputy_active_etime=@Deputy_active_etime ")
            sql.AppendLine(" where Id_card=@Id_card ")

            Dim paras(6) As SqlParameter
            paras(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            paras(0).Value = Id_card
            paras(1) = New SqlParameter("@Deputy_active", SqlDbType.VarChar)
            paras(1).Value = Deputy_active
            paras(2) = New SqlParameter("@Deputy_active_idcard", SqlDbType.VarChar)
            paras(2).Value = Deputy_active_idcard
            paras(3) = New SqlParameter("@Deputy_active_sdate", SqlDbType.VarChar)
            paras(3).Value = Deputy_active_sdate
            paras(4) = New SqlParameter("@Deputy_active_stime", SqlDbType.VarChar)
            paras(4).Value = Deputy_active_stime
            paras(5) = New SqlParameter("@Deputy_active_edate", SqlDbType.VarChar)
            paras(5).Value = Deputy_active_edate
            paras(6) = New SqlParameter("@Deputy_active_etime", SqlDbType.VarChar)
            paras(6).Value = Deputy_active_etime

            Return SqlAccessHelper.ExecuteNonQuery(Me.connstring, CommandType.Text, sql.ToString(), paras)
        End Function
    End Class
End Namespace
