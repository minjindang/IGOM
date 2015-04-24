Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic

    Public Class ApplyMaterialMainDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Sub Insert(ByVal Flow_id As String, ByVal Form_type As String, ByVal Apply_date As String, ByVal Unit_Code As String, ByVal User_id As String, _
                                 ByVal ModUser_id As String, ByVal Mod_date As DateTime, ByVal Orgcode As String)

            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO MAT_ApplyMaterial_main (Flow_id,Form_type, Apply_date, Unit_Code,User_id,ModUser_id,Mod_date, Orgcode) " & _
                     " VALUES (@Flow_id,@Form_type, @Apply_date, @Unit_Code,@User_id,@ModUser_id,@Mod_date, @Orgcode) "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Flow_id", Flow_id), _
            New SqlParameter("@Form_type", Form_type), _
            New SqlParameter("@Apply_date", Apply_date), _
            New SqlParameter("@Unit_Code", Unit_Code), _
            New SqlParameter("@User_id", User_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", Orgcode)}
            Execute(StrSQL, ps)

        End Sub

        Public Function GetOne(flow_id As String, orgCode As String) As DataTable
            Dim StrSQL As String = " SELECT * FROM [MAT_ApplyMaterial_main] where flow_id = @flow_id and OrgCode = @orgCode "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@orgCode", orgCode)}
            Return Query(StrSQL, ps)
        End Function

        Public Function DeleteByOrgFid(flow_id As String, orgCode As String) As Integer
            Dim StrSQL As String = " DELETE FROM [MAT_ApplyMaterial_main] where flow_id = @flow_id and OrgCode = @orgCode "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@flow_id", flow_id), _
            New SqlParameter("@orgCode", orgCode)}
            Return Execute(StrSQL, ps)
        End Function

    End Class

End Namespace