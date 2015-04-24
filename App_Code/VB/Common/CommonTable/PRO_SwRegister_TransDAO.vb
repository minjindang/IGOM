Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace PRO.Logic
    Public Class PRO_SwRegister_TransDAO
        Inherits BaseDAO

        Public Function getDataByOrgFid(ByVal OrgCode As String, ByVal Flow_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from PRO_SwRegister_Trans where 1=1 ")

            If Not String.IsNullOrEmpty(OrgCode) Then
                sql.AppendLine(" and OrgCode=@OrgCode ")
            End If
            If Not String.IsNullOrEmpty(Flow_id) Then
                sql.AppendLine(" and Flow_id=@Flow_id ")
            End If

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@OrgCode", SqlDbType.VarChar)
            params(0).Value = OrgCode
            params(1) = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            params(1).Value = Flow_id

            Return Query(sql.ToString, params)
        End Function

        Public Function updateSWMain(ByVal Orgcode As String, ByVal Flow_id As String, ByVal NewUnit_code As String, ByVal NewKeeper_id As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update PRO_SwRegister_main set ")
            sql.AppendLine(" Unit_code=@NewUnit_code, ")
            sql.AppendLine(" User_id=@NewKeeper_id, ")
            sql.AppendLine(" ModUser_id=@ModUser_id, ")
            sql.AppendLine(" Mod_date=getDate() ")
            sql.AppendLine(" where Orgcode=@Orgcode and Flow_id=@Flow_id ")

            Dim params(4) As SqlParameter
            params(0) = New SqlParameter("@OrgCode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            params(1).Value = Flow_id
            params(2) = New SqlParameter("@NewUnit_code", SqlDbType.VarChar)
            params(2).Value = NewUnit_code
            params(3) = New SqlParameter("@NewKeeper_id", SqlDbType.VarChar)
            params(3).Value = NewKeeper_id
            params(4) = New SqlParameter("@ModUser_id", SqlDbType.VarChar)
            params(4).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)

            Return Execute(sql.ToString, params)
        End Function
    End Class
End Namespace
