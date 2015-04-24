Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MaterialMStatDetDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                     ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE MAT_MaterialMStat_det SET Material_id=@newMaterial_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date, Orgcode=@Orgcode WHERE Material_id=@Material_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@newMaterial_id", newMaterial_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", OrgCode)}
            Execute(StrSQL, ps)
        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return Scalar("SELECT COUNT(*) as Count FROM  MAT_MaterialMStat_det where material_id = @Material_id", New SqlParameter("Material_id", Material_id))
        End Function

        Public Function GetOne(OrgCode As String, Year_id As String, ByVal Material_id As String, Unit_code As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = " SELECT * FROM dbo.MAT_MaterialMStat_det WHERE OrgCode =@OrgCode and Year_id =@Year_id and Material_id = @Material_id and Unit_code = @Unit_code "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Year_id", Year_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Unit_code", Unit_code)}
            Return Query(StrSQL, ps)
        End Function

        Public Sub Insert(OrgCode As String, Year_id As String, ByVal Material_id As String, Unit_code As String)
            Dim StrSQL As String = String.Empty
            StrSQL = " INSERT INTO MAT_MaterialMStat_det ( OrgCode,Year_id,Material_id ,Unit_code) VALUES ( @OrgCode,@Year_id,@Material_id ,@Unit_code) "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Year_id", Year_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Unit_code", Unit_code)}
            Execute(StrSQL, ps)
        End Sub

        Public Sub Update(OrgCode As String, Year_id As String, Material_id As String, Unit_code As String, month As String, value As String, ModUser_id As String)
            Dim StrSQL As String = String.Empty
            Dim StrSQL2 As String = String.Empty
            Dim sql2 As String = String.Format(" [{0}MOut_amt] = '{1}' ", month, value)
            StrSQL = " UPDATE MAT_MaterialMStat_det SET " & sql2 & " WHERE OrgCode =@OrgCode and Year_id =@Year_id and Material_id = @Material_id and Unit_code = @Unit_code "

            StrSQL2 = " UPDATE MAT_MaterialMStat_det SET Stat_date=@Stat_date,ModUser_id=@ModUser_id,Mod_date=GETDATE() , " _
                 & " TotalOut_AMT = ISNULL([01MOut_amt],0) + ISNULL([02MOut_amt],0) + ISNULL([03MOut_amt],0) + ISNULL([04MOut_amt],0) " _
                 & " + ISNULL([05MOut_amt],0) + ISNULL([06MOut_amt],0) + ISNULL([07MOut_amt],0) + ISNULL([08MOut_amt],0) " _
                 & " + ISNULL([09MOut_amt],0) + ISNULL([10MOut_amt],0) + ISNULL([11MOut_amt],0) + ISNULL([12MOut_amt],0) " _
                 & " WHERE OrgCode =@OrgCode and Year_id =@Year_id and Material_id = @Material_id and Unit_code = @Unit_code "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@OrgCode", OrgCode), _
            New SqlParameter("@Year_id", Year_id), _
            New SqlParameter("@Stat_date", CommonFun.getYYYMMDD ), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Unit_code", Unit_code)}
            Execute(StrSQL, ps)
            Execute(StrSQL2, ps)
        End Sub

        Public Function MAT2108_Print(ByVal tbMaterial_id1 As String, ByVal tbMaterial_id2 As String, ByVal ddlyear As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select a.Material_id, ")
            sql.AppendLine(" ( select top 1 Material_name from MAT_Material_main ma where a.Material_id=ma.Material_id) as Material_name, ")

            sql.AppendLine(" CASE WHEN LEN(Unit_code)=1 THEN ")
            sql.AppendLine(" (select top 1 depart_name from FSC_ORG where Orgcode='355000000I' and SUBSTRING(Depart_id,1,1) =  SUBSTRING(Unit_code,1,1)) ")
            sql.AppendLine(" ELSE ")
            sql.AppendLine(" (select top 1 depart_name from FSC_ORG where Orgcode='355000000I' and SUBSTRING(Depart_id,1,2) =  SUBSTRING(Unit_code,1,2)) ")
            sql.AppendLine(" END AS Depart_name, ")
            'sql.AppendLine(" (select top 1 depart_name from FSC_ORG where Orgcode=@Orgcode and Depart_id like SUBSTRING(a.Unit_code,1,2)) Depart_name, ")

            sql.AppendLine(" SUM(isnull(a.[01MOut_amt],0)) as [01MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[02MOut_amt],0)) as [02MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[03MOut_amt],0)) as [03MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[04MOut_amt],0)) as [04MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[05MOut_amt],0)) as [05MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[06MOut_amt],0)) as [06MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[07MOut_amt],0)) as [07MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[08MOut_amt],0)) as [08MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[09MOut_amt],0)) as [09MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[10MOut_amt],0)) as [10MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[11MOut_amt],0)) as [11MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[12MOut_amt],0)) as [12MOut_amt] ")
            sql.AppendLine(" from MAT_MaterialMStat_det a where a.Year_id= @ddlyear ")

            If Not String.IsNullOrEmpty(tbMaterial_id1) Then
                sql.AppendLine(" and a.Material_id >=@tbMaterial_id1 ")
            End If
            If Not String.IsNullOrEmpty(tbMaterial_id2) Then
                sql.AppendLine(" and a.Material_id <=@tbMaterial_id2 ")
            End If

            sql.AppendLine(" group by Material_id,SUBSTRING(a.Unit_code,1,2)--Unit_code--  ")

            Dim ps() As SqlParameter = { _
               New SqlParameter("@Orgcode", LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)), _
               New SqlParameter("@tbMaterial_id1", tbMaterial_id1), _
               New SqlParameter("@tbMaterial_id2", tbMaterial_id2), _
               New SqlParameter("@ddlyear", ddlyear)}
            Return Query(sql.ToString, ps)

        End Function

        Public Function get2108SumData(ByVal Material_id As String, ByVal Year_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select a.Material_id, ")
            sql.AppendLine(" ( select top 1 Material_name from MAT_Material_main ma where a.Material_id=ma.Material_id) as Material_name, ")
            sql.AppendLine(" SUM(isnull(a.[01MOut_amt],0)) as [01MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[02MOut_amt],0)) as [02MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[03MOut_amt],0)) as [03MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[04MOut_amt],0)) as [04MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[05MOut_amt],0)) as [05MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[06MOut_amt],0)) as [06MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[07MOut_amt],0)) as [07MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[08MOut_amt],0)) as [08MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[09MOut_amt],0)) as [09MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[10MOut_amt],0)) as [10MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[11MOut_amt],0)) as [11MOut_amt], ")
            sql.AppendLine(" SUM(isnull(a.[12MOut_amt],0)) as [12MOut_amt] ")
            sql.AppendLine(" from MAT_MaterialMStat_det a where a.Year_id= @Year_id and a.Material_id=@Material_id ")

            sql.AppendLine(" group by Material_id ")

            Dim ps() As SqlParameter = { _
               New SqlParameter("@Material_id", Material_id), _
               New SqlParameter("@Year_id", Year_id)}
            Return Query(sql.ToString, ps)
        End Function
    End Class
End Namespace

