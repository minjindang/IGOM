Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic

    Public Class MaterialAccuDetDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Function GetOne(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = " SELECT * FROM MAT_MaterialAccu_det WHERE MAccu_yyymm = @MAccu_yyymm and OrgCode = @OrgCode and MAccu_mtrid= @MAccu_mtrid "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", orgCode), _
            New SqlParameter("@MAccu_yyymm", MAccu_yyymm), _
            New SqlParameter("@MAccu_mtrid", MAccu_mtrid)}
            Return Query(StrSQL, ps)
        End Function

        Public Sub Insert(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String, MAccu_remain As Double, MAccu_in As Double, _
                                MAccu_out As Double, MAccu_modify As Double, MAccu_store As Double, MAccu_date As String, ModUser_id As String, Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " INSERT INTO MAT_MaterialAccu_det ([OrgCode] ,[MAccu_yyymm] ,[MAccu_mtrid] ,[MAccu_remain] ,[MAccu_in] " & _
                     " ,[MAccu_out] ,[MAccu_modify] ,[MAccu_store] ,[MAccu_date] ,[ModUser_id]  ,[Mod_date])  " & _
                     " VALUES (@OrgCode ,@MAccu_yyymm ,@MAccu_mtrid ,@MAccu_remain ,@MAccu_in " & _
                     " ,@MAccu_out ,@MAccu_modify ,@MAccu_store ,@MAccu_date ,@ModUser_id  ,@Mod_date) "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", orgCode), _
            New SqlParameter("@MAccu_yyymm", MAccu_yyymm), _
            New SqlParameter("@MAccu_mtrid", MAccu_mtrid), _
            New SqlParameter("@MAccu_remain", MAccu_remain), _
            New SqlParameter("@MAccu_in", MAccu_in), _
            New SqlParameter("@MAccu_out", MAccu_out), _
            New SqlParameter("@MAccu_modify", MAccu_modify), _
            New SqlParameter("@MAccu_store", MAccu_store), _
            New SqlParameter("@MAccu_date", MAccu_date), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date)}
            Execute(StrSQL, ps)
        End Sub

        Public Sub Update(orgCode As String, MAccu_yyymm As String, MAccu_mtrid As String, MAccu_remain As Double, MAccu_in As Double, _
                               MAccu_out As Double, MAccu_modify As Double, MAccu_store As Double, MAccu_date As String, ModUser_id As String, Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE MAT_MaterialAccu_det SET [MAccu_remain]=@MAccu_remain ,[MAccu_in]=@MAccu_in " & _
                     " ,[MAccu_out]=@MAccu_out ,[MAccu_modify]=@MAccu_modify ,[MAccu_store]=@MAccu_store ,[MAccu_date]=@MAccu_date " & _
                     " ,[ModUser_id]=@ModUser_id  ,[Mod_date]=@Mod_date    " & _
                     " WHERE OrgCode=@OrgCode and MAccu_yyymm=@MAccu_yyymm and MAccu_mtrid=@MAccu_mtrid "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", orgCode), _
            New SqlParameter("@MAccu_yyymm", MAccu_yyymm), _
            New SqlParameter("@MAccu_mtrid", MAccu_mtrid), _
            New SqlParameter("@MAccu_remain", MAccu_remain), _
            New SqlParameter("@MAccu_in", MAccu_in), _
            New SqlParameter("@MAccu_out", MAccu_out), _
            New SqlParameter("@MAccu_modify", MAccu_modify), _
            New SqlParameter("@MAccu_store", MAccu_store), _
            New SqlParameter("@MAccu_date", MAccu_date), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date)}
            Execute(StrSQL, ps)
        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE MAT_MaterialAccu_det SET MAccu_mtrid=@newMaterial_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date, Orgcode=@Orgcode WHERE MAccu_mtrid=@Material_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@newMaterial_id", newMaterial_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", OrgCode)}
            Execute(StrSQL, ps)
        End Sub
    End Class

End Namespace
