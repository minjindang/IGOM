Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class MaterialClass_dataDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return Scalar("SELECT COUNT(*) as Count FROM  MAT_MaterialMStat_det where material_id = @Material_id", New SqlParameter("Material_id", Material_id))
        End Function

        Public Function GetData(ByVal item As String, ByVal code As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT MaterialClass_id, MaterialClass_name, ModUser_id, Mod_date from MAT_MaterialClass_data where 1=1"
            If Not String.IsNullOrEmpty(item) Then
                StrSQL &= " and MaterialClass_id=@ITEM"
            End If
            If Not String.IsNullOrEmpty(code) Then
                StrSQL &= " and MaterialClass_name=@CODE"
            End If

            Dim ps() As SqlParameter = { _
            New SqlParameter("@CODE", code), _
            New SqlParameter("@ITEM", item)}
            Return Query(StrSQL, ps)
        End Function

        Public Function GetDataByOrgCode(OrgCode As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * from MAT_MaterialClass_data where OrgCode = @OrgCode "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode)}
            Return Query(StrSQL, ps)
        End Function

        Public Function MAT0305SelectData(ByVal item As String, ByVal code As String, ByVal orgcode As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT MaterialClass_id, MaterialClass_name, (select top 1 User_name from FSC_Personnel where id_card = ModUser_id) as ModUser_Name, ModUser_id, Mod_date from MAT_MaterialClass_data where 1=1"
            If Not String.IsNullOrEmpty(item) Then
                StrSQL &= " and MaterialClass_id=@ITEM"
            End If
            If Not String.IsNullOrEmpty(code) Then
                StrSQL &= " and MaterialClass_name=@CODE"
            End If
            If Not String.IsNullOrEmpty(orgcode) Then
                StrSQL &= " and Orgcode=@orgcode"
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@CODE", code), _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@ITEM", item)}
            Return Query(StrSQL, ps)
        End Function
        Public Function MAT0305DeleteData(ByVal Index As String, ByVal item As String, ByVal code As String, ByVal orgcode As String) As DataTable
            Dim memo As String = ""
            Dim dt As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "DELETE FROM MAT_MaterialClass_data WHERE MaterialClass_id=@Index"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Index", Index)}
            Execute(StrSQL, ps)
            dt = MAT0305SelectData(item, code, orgcode)
            Return dt
        End Function

        Public Function MAT0305InsertGetData(ByVal Index As String, ByVal item As String, ByVal Next_id As String, ByVal Next_date As Date, ByVal Orgcode As String) As String
            Dim memo As String = ""
            Dim dt As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO MAT_MaterialClass_data (MaterialClass_id,MaterialClass_name, Mod_date, ModUser_id, Orgcode) VALUES(@Index, @item, @Next_date, @Next_id, @Orgcode)"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Index", Index), _
            New SqlParameter("@item", item), _
            New SqlParameter("@Next_id", Next_id), _
            New SqlParameter("@Next_date", Next_date), _
            New SqlParameter("@Orgcode", Orgcode)}
            Execute(StrSQL, ps)
            memo = "新增成功"
            Return memo
        End Function

        Public Function MAT0305MaintainData(ByVal Index As String, ByVal item As String, ByVal Next_id As String, ByVal Next_date As Date, ByVal Orgcode As String) As String
            Dim memo As String = ""
            Dim dt As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "UPDATE MAT_MaterialClass_data set MaterialClass_name=@item, Mod_date=@Mod_date, ModUser_id=@ModUser_id, Orgcode=@Orgcode where MaterialClass_id=@Index"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Index", Index), _
            New SqlParameter("@item", item), _
            New SqlParameter("@ModUser_id", Next_id), _
            New SqlParameter("@Mod_date", Next_date), _
            New SqlParameter("@Orgcode", Orgcode)}
            Execute(StrSQL, ps)
            memo = "修改成功"
            Return memo
        End Function
    End Class
End Namespace