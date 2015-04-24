Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class Material_mainDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub

        Public Function GetDataByIds(ids As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * from MAT_Material_main where 1=1 and Material_id in (" & ids & ")"
            Return Query(StrSQL)
        End Function

        Public Function GetData(ByVal Index As String) As DataTable
            Return GetData(Index, False)
        End Function

        Public Function GetData(ByVal Index As String, isPersonLimit As Boolean) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT "
            StrSQL &= " Material_id,Material_name,MaterialClass_id,Unit,Safe_cnt,Reserve_cnt,"
            StrSQL &= " CASE WHEN Available_cnt<=0 THEN 0 ELSE Available_cnt END Available_cnt,"
            StrSQL &= " location, PersonLimitMM_cnt, PersonLimit_cnt, UnitLimitMM_cnt, UnitLimit_cnt, MaterialIcon, Memo, ModUser_id, Mod_date, orgcode"
            StrSQL &= " FROM MAT_Material_main where 1=1 and MaterialClass_id=@CODE"

            If isPersonLimit Then
                StrSQL &= " and PersonLimit_cnt<>'0' "
            End If

            Dim ps() As SqlParameter = { _
            New SqlParameter("@CODE", Index)}
            Return Query(StrSQL, ps)
        End Function

        Public Function GetOtherData(ByVal isPersonLimit As Boolean) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * from MAT_Material_main where MaterialClass_id not in (select materialClass_id from MAT_MaterialClass_data) "

            If isPersonLimit Then
                StrSQL &= " and PersonLimit_cnt<>'0' "
            End If

            Return Query(StrSQL)
        End Function

        Public Function GetDataByClassId2(ByVal orgcode As String, ByVal classId As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * from MAT_Material_main where orgcode=@orgcode and MaterialClass_id like @classId "
            Dim ps() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@classId", classId & "%")}
            Return Query(StrSQL, ps)
        End Function
        Public Function CheckInvMainExist(ByVal orgcode As String, ByVal Material_id As String, ByVal InventoryId As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * from MAT_Inventory_det AS a"
            StrSQL &= " INNER JOIN MAT_Inventory_main AS b ON b.Inventory_id = a.Inventory_id"
            StrSQL &= " WHERE a.orgcode=@orgcode AND b.Inventory_id = @Inventory_id AND Material_id = @Material_id"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@Inventory_id", InventoryId)}
            Return Query(StrSQL, ps)
        End Function
        Public Function GetMatData(ByVal item As String, ByVal code As String) As DataTable
            Dim sqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim strSQL As String = String.Empty
            strSQL = "select Material_id,Material_name, Unit, Reserve_cnt, Safe_cnt   from MAT_Material_main where 1=1 "
            If Not String.IsNullOrEmpty(item) Then
                strSQL &= " and Material_id  = @item "
            End If
            'If Not String.IsNullOrEmpty(code) Then
            '    strSQL &= " and Material_id <= @code "
            'End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@ITEM", item), _
            New SqlParameter("@CODE", code)}
            Return Query(strSQL, ps)
        End Function

        Public Function GetMaterial(ByVal item As String, ByVal code As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT Material_id,Material_name, Unit, Available_cnt, PersonLimit_cnt, PersonLimitMM_cnt, UnitLimit_cnt, UnitLimitMM_cnt  FROM MAT_Material_main WHERE 1=1"
            If Not String.IsNullOrEmpty(item) Then
                StrSQL &= "and  Material_id>=@ITEM   "
            End If
            If Not String.IsNullOrEmpty(code) Then
                StrSQL &= "AND Material_id <=@CODE"
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@ITEM", item), _
            New SqlParameter("@CODE", code)}
            Return Query(StrSQL, ps)
        End Function
        Public Function GetDataMaterial(ByVal Orgcode As String, ByVal UserId As String, ByVal Material_id As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT *  FROM MAT_Material_main WHERE 1=1"
       
            If Not String.IsNullOrEmpty(UserId) Then
                StrSQL &= " AND OrgCode <=@Orgcode"
            End If
            If Not String.IsNullOrEmpty(Material_id) Then
                StrSQL &= " AND Material_id =@Material_id"
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Orgcode", Orgcode), _
            New SqlParameter("@UserId", UserId), _
            New SqlParameter("@Material_id", Material_id)}
            Return Query(StrSQL, ps)
        End Function
        Public Function MAT1105SelectData(ByVal Index As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT MaterialClass_id from MAT_Material_main where 1=1 and MaterialClass_id=@CODE"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@CODE", Index)}
            Return Query(StrSQL, ps)
        End Function
        Public Function MAT2105SelectData() As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT Material_id, Material_name, Unit, Available_cnt, Safe_cnt from MAT_Material_main where 1=1 and Available_cnt<Safe_cnt"
            Dim ps() As SqlParameter = { _
            New SqlParameter("@CODE", "")}
            Return Query(StrSQL, ps)
        End Function
        Public Function MAT2201SelectData(ByVal Material_idS As String, ByVal Material_idE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT Material_id,Material_name, Reserve_cnt  FROM MAT_Material_main WHERE 1=1"
            If Not String.IsNullOrEmpty(Material_idS) Then
                StrSQL &= " and  Material_id>=@Material_idS"
            End If
            If Not String.IsNullOrEmpty(Material_idE) Then
                StrSQL &= " and Material_id <=@Material_idE"
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Material_idS", Material_idS), _
            New SqlParameter("@Material_idE", Material_idE)}
            Return Query(StrSQL, ps)
        End Function

        Public Function GetMaterialByCondition(ByVal Material_id As String, ByVal location As String, ByVal orgcode As String) As DataTable

            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT "
            StrSQL &= " Material_id,Material_name,MaterialClass_id,Unit,Safe_cnt,Reserve_cnt,"
            StrSQL &= " CASE WHEN Available_cnt<=0 THEN 0 ELSE Available_cnt END Available_cnt,"
            StrSQL &= " location, PersonLimitMM_cnt, PersonLimit_cnt, UnitLimitMM_cnt, UnitLimit_cnt, MaterialIcon, Memo, ModUser_id, Mod_date, orgcode"
            StrSQL &= " FROM MAT_Material_main WHERE 1=1 "
            If Not String.IsNullOrEmpty(Material_id) Then
                StrSQL &= " and Material_id like '%' + @Material_id+ '%' "
            End If
            If Not String.IsNullOrEmpty(orgcode) Then
                StrSQL &= " and Orgcode = @orgcode"
            End If
            If Not String.IsNullOrEmpty(location) Then
                StrSQL &= " and Location like '%' + @Location + '%' "
            End If
            Dim ps() As SqlParameter = { _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@orgcode", orgcode), _
            New SqlParameter("@Location", location)}
            Return Query(StrSQL, ps)
        End Function


        Public Function GetMaterialByID(ByVal Material_id As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT "
            StrSQL &= " Material_id,Material_name,MaterialClass_id,Unit,Safe_cnt,Reserve_cnt,"
            StrSQL &= " CASE WHEN Available_cnt<0 THEN 0 ELSE Available_cnt END Available_cnt,"
            StrSQL &= " location, PersonLimitMM_cnt, PersonLimit_cnt, UnitLimitMM_cnt, UnitLimit_cnt, MaterialIcon, Memo, ModUser_id, Mod_date, orgcode"
            StrSQL &= " FROM MAT_Material_main WHERE Material_id=@Material_id"

            Dim ps() As SqlParameter = { _
            New SqlParameter("@Material_id", Material_id)}
            Return Query(StrSQL, ps)
        End Function

        Public Sub Update(ByVal Material_id As String, ByVal Material_name As String, ByVal MaterialClass_id As String, ByVal Unit As String, ByVal Safe_cnt As Integer, _
                       ByVal Reserve_cnt As Integer, ByVal Available_cnt As Integer, ByVal Location As String, ByVal PersonLimitMM_cnt As Integer, ByVal PersonLimit_cnt As Integer, _
                       ByVal UnitLimitMM_cnt As Integer, ByVal UnitLimit_cnt As Integer, ByVal MaterialIcon As String, ByVal Memo As String, ByVal ModUser_id As String, _
                       ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim sql As New System.Text.StringBuilder
            sql.Append("UPDATE MAT_Material_main " & vbCrLf)
            sql.Append("            SET " & vbCrLf)
            sql.Append("             [Material_name]=@Material_name, " & vbCrLf)
            sql.Append("             [MaterialClass_id]=@MaterialClass_id, " & vbCrLf)
            sql.Append("             [Unit]=@Unit, " & vbCrLf)
            sql.Append("             [Safe_cnt]=@Safe_cnt, " & vbCrLf)
            sql.Append("             [Reserve_cnt]=@Reserve_cnt, " & vbCrLf)
            sql.Append("             [Available_cnt]=@Available_cnt, " & vbCrLf)
            sql.Append("             [Location]=@Location, " & vbCrLf)
            sql.Append("             [PersonLimitMM_cnt]=@PersonLimitMM_cnt, " & vbCrLf)
            sql.Append("             [PersonLimit_cnt]=@PersonLimit_cnt, " & vbCrLf)
            sql.Append("             [UnitLimitMM_cnt]=@UnitLimitMM_cnt, " & vbCrLf)
            sql.Append("             [UnitLimit_cnt]=@UnitLimit_cnt, " & vbCrLf)
            If Not String.IsNullOrEmpty(MaterialIcon) Then
                sql.Append("             [MaterialIcon]=@MaterialIcon, " & vbCrLf)
            End If
            sql.Append("             [Memo]=@Memo, " & vbCrLf)
            sql.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
            sql.Append("             [OrgCode]=@OrgCode, " & vbCrLf)
            sql.Append("             [Mod_date]=@Mod_date WHERE [Material_id]=@Material_id " & vbCrLf)

            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@Material_name", Material_name), _
                                        New SqlParameter("@MaterialClass_id", MaterialClass_id), _
                                        New SqlParameter("@Unit", Unit), _
                                        New SqlParameter("@Safe_cnt", Safe_cnt), _
                                        New SqlParameter("@Reserve_cnt", Reserve_cnt), _
                                        New SqlParameter("@Available_cnt", Available_cnt), _
                                        New SqlParameter("@Location", Location), _
                                        New SqlParameter("@PersonLimitMM_cnt", PersonLimitMM_cnt), _
                                        New SqlParameter("@PersonLimit_cnt", PersonLimit_cnt), _
                                        New SqlParameter("@UnitLimitMM_cnt", UnitLimitMM_cnt), _
                                        New SqlParameter("@UnitLimit_cnt", UnitLimit_cnt), _
                                        New SqlParameter("@MaterialIcon", MaterialIcon), _
                                        New SqlParameter("@Memo", Memo), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Mod_date", Mod_date)}


            Execute(sql.ToString(), ps)

        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                      ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim sql As New System.Text.StringBuilder
            sql.Append("UPDATE MAT_Material_main " & vbCrLf)
            sql.Append("            SET " & vbCrLf)
            sql.Append("             [Material_id]=@newMaterial_id, " & vbCrLf)
            sql.Append("             [MaterialClass_id]=@MaterialClass_id, " & vbCrLf)
            sql.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
            sql.Append("             [OrgCode]=@OrgCode, " & vbCrLf)
            sql.Append("             [Mod_date]=@Mod_date WHERE [Material_id]=@Material_id " & vbCrLf)

            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@newMaterial_id", newMaterial_id), _
                                        New SqlParameter("@MaterialClass_id", Left(newMaterial_id, 5)), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Mod_date", Mod_date)}

            Execute(sql.ToString(), ps)

        End Sub

        Public Sub Insert(ByVal Material_id As String, ByVal Material_name As String, ByVal MaterialClass_id As String, ByVal Unit As String, ByVal Safe_cnt As Integer, _
                       ByVal Reserve_cnt As Integer, ByVal Available_cnt As Integer, ByVal Location As String, ByVal PersonLimitMM_cnt As Integer, ByVal PersonLimit_cnt As Integer, _
                       ByVal UnitLimitMM_cnt As Integer, ByVal UnitLimit_cnt As Integer, ByVal MaterialIcon As String, ByVal Memo As String, ByVal ModUser_id As String, _
                       ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim sql As New System.Text.StringBuilder
            sql.Append("INSERT INTO MAT_Material_main " & vbCrLf)
            sql.Append("            ([Material_id], " & vbCrLf)
            sql.Append("             [Material_name], " & vbCrLf)
            sql.Append("             [MaterialClass_id], " & vbCrLf)
            sql.Append("             [Unit], " & vbCrLf)
            sql.Append("             [Safe_cnt], " & vbCrLf)
            sql.Append("             [Reserve_cnt], " & vbCrLf)
            sql.Append("             [Available_cnt], " & vbCrLf)
            sql.Append("             [Location], " & vbCrLf)
            sql.Append("             [PersonLimitMM_cnt], " & vbCrLf)
            sql.Append("             [PersonLimit_cnt], " & vbCrLf)
            sql.Append("             [UnitLimitMM_cnt], " & vbCrLf)
            sql.Append("             [UnitLimit_cnt], " & vbCrLf)
            sql.Append("             [MaterialIcon], " & vbCrLf)
            sql.Append("             [Memo], " & vbCrLf)
            sql.Append("             [ModUser_id], " & vbCrLf)
            sql.Append("             [OrgCode], " & vbCrLf)
            sql.Append("             [Mod_date]) " & vbCrLf)
            sql.Append("VALUES      (@Material_id, " & vbCrLf)
            sql.Append("             @Material_name, " & vbCrLf)
            sql.Append("             @MaterialClass_id, " & vbCrLf)
            sql.Append("             @Unit, " & vbCrLf)
            sql.Append("             @Safe_cnt, " & vbCrLf)
            sql.Append("             @Reserve_cnt, " & vbCrLf)
            sql.Append("             @Available_cnt, " & vbCrLf)
            sql.Append("             @Location, " & vbCrLf)
            sql.Append("             @PersonLimitMM_cnt, " & vbCrLf)
            sql.Append("             @PersonLimit_cnt, " & vbCrLf)
            sql.Append("             @UnitLimitMM_cnt, " & vbCrLf)
            sql.Append("             @UnitLimit_cnt, " & vbCrLf)
            sql.Append("             @MaterialIcon, " & vbCrLf)
            sql.Append("             @Memo, " & vbCrLf)
            sql.Append("             @ModUser_id, " & vbCrLf)
            sql.Append("             @OrgCode, " & vbCrLf)
            sql.Append("             @Mod_date) ")

            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@Material_name", Material_name), _
                                        New SqlParameter("@MaterialClass_id", MaterialClass_id), _
                                        New SqlParameter("@Unit", Unit), _
                                        New SqlParameter("@Safe_cnt", Safe_cnt), _
                                        New SqlParameter("@Reserve_cnt", Reserve_cnt), _
                                        New SqlParameter("@Available_cnt", Available_cnt), _
                                        New SqlParameter("@Location", Location), _
                                        New SqlParameter("@PersonLimitMM_cnt", PersonLimitMM_cnt), _
                                        New SqlParameter("@PersonLimit_cnt", PersonLimit_cnt), _
                                        New SqlParameter("@UnitLimitMM_cnt", UnitLimitMM_cnt), _
                                        New SqlParameter("@UnitLimit_cnt", UnitLimit_cnt), _
                                        New SqlParameter("@MaterialIcon", MaterialIcon), _
                                        New SqlParameter("@Memo", Memo), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Mod_date", Mod_date)}


            Execute(sql.ToString(), ps)

        End Sub

        Public Sub Delete(ByVal Material_id As String)
            Dim sql As New System.Text.StringBuilder
            sql.Append("DELETE FROM MAT_Material_main WHERE Material_id =@Material_id  ")
            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", Material_id)}
            Execute(sql.ToString(), ps)
        End Sub

        Public Function GetReserveCnt(orgCode As String) As DataTable
            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT Material_id, " & vbCrLf)
            StrSQL.Append("       Sum(Reserve_cnt) Reserve_cnt " & vbCrLf)
            StrSQL.Append("FROM   MAT_Material_main " & vbCrLf)
            StrSQL.Append("WHERE  OrgCode = @Orgcode " & vbCrLf)
            StrSQL.Append("GROUP  BY Material_id ")

            Dim ps() As SqlParameter = {New SqlParameter("@Orgcode", orgCode)}
            Return Query(StrSQL.ToString(), ps)
        End Function

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return Scalar("SELECT COUNT(*) as Count FROM  MAT_Material_main where material_id = @Material_id", New SqlParameter("Material_id", Material_id))
        End Function

        Public Function updateReserveCnt(ByVal Orgcode As String, ByVal Material_id As String, ByVal oriInCnt As Integer, ByVal InCnt As Integer) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" update MAT_Material_main set Reserve_cnt=(Reserve_cnt - @oriInCnt + @InCnt), ")
            sql.AppendLine(" ModUser_id=@ModUser_id, Mod_date=getDate() ")
            sql.AppendLine(" where OrgCode = @Orgcode and Material_id=@Material_id ")

            Dim params(4) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Material_id", SqlDbType.VarChar)
            params(1).Value = Material_id
            params(2) = New SqlParameter("@oriInCnt", SqlDbType.Int)
            params(2).Value = oriInCnt
            params(3) = New SqlParameter("@InCnt", SqlDbType.Int)
            params(3).Value = InCnt
            params(4) = New SqlParameter("@ModUser_id", SqlDbType.VarChar)
            params(4).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return Execute(sql.ToString(), params)
        End Function
        Public Function updateAvailableCnt(ByVal applyCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" UPDATE MAT_Material_main set Available_cnt=(Available_cnt - @applyCnt) ")
            sql.AppendLine(" where  Material_id=@materialID ")
            sql.AppendLine(" AND  OrgCode=@Orgcode ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@applyCnt", SqlDbType.VarChar)
            params(0).Value = applyCnt
            params(1) = New SqlParameter("@materialID", SqlDbType.VarChar)
            params(1).Value = materialID
            params(2) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(2).Value = Orgcode

            Return Execute(sql.ToString(), params)
        End Function


        Public Function updateAvailableCntReserveCnt(ByVal applyCnt As String, outCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" UPDATE MAT_Material_main set Available_cnt=(Available_cnt + @applyCnt - @outCnt), ")
            sql.AppendLine(" Reserve_cnt=(Reserve_cnt - @outCnt) ")
            sql.AppendLine(" where  Material_id=@materialID ")
            sql.AppendLine(" AND  OrgCode=@Orgcode ")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@applyCnt", SqlDbType.VarChar)
            params(0).Value = applyCnt
            params(1) = New SqlParameter("@materialID", SqlDbType.VarChar)
            params(1).Value = materialID
            params(2) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(2).Value = Orgcode
            params(3) = New SqlParameter("@outCnt", SqlDbType.VarChar)
            params(3).Value = outCnt

            Return Execute(sql.ToString(), params)
        End Function
        Public Function update3102AvailableCnt(ByVal applyCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" UPDATE MAT_Material_main set Available_cnt=(Available_cnt +@applyCnt) ")
            sql.AppendLine(" where  Material_id=@materialID ")
            sql.AppendLine(" AND  OrgCode=@Orgcode ")

            Dim params(2) As SqlParameter
            params(0) = New SqlParameter("@applyCnt", SqlDbType.VarChar)
            params(0).Value = applyCnt
            params(1) = New SqlParameter("@materialID", SqlDbType.VarChar)
            params(1).Value = materialID
            params(2) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(2).Value = Orgcode

            Return Execute(sql.ToString(), params)
        End Function
        Public Function update310203AvailableCnt(ByVal oriInCnt As String, ByVal InCnt As String, ByVal materialID As String, ByVal Orgcode As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" UPDATE MAT_Material_main set Available_cnt=(Available_cnt -@oriInCnt + @InCnt) ")
            sql.AppendLine(" where  Material_id=@materialID ")
            sql.AppendLine(" AND  OrgCode=@Orgcode ")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@oriInCnt", SqlDbType.VarChar)
            params(0).Value = oriInCnt
            params(1) = New SqlParameter("@materialID", SqlDbType.VarChar)
            params(1).Value = materialID
            params(2) = New SqlParameter("@InCnt", SqlDbType.VarChar)
            params(2).Value = InCnt
            params(3) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(3).Value = Orgcode

            Return Execute(sql.ToString(), params)
        End Function
        Public Function UpdateAvaiable(ByVal OrgCode As String, ByVal Material_id As String, ByVal InvBefore_cnt As String, _
                                       ByVal InvAfter_cnt As String) As Integer
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" UPDATE MAT_Material_main SET Available_cnt=( Available_cnt + @InvAfter_cnt - @InvBefore_cnt ) ")
            sql.AppendLine(" WHERE  Material_id=@Material_id ")
            sql.AppendLine(" AND  OrgCode=@Orgcode ")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@OrgCode", SqlDbType.VarChar)
            params(0).Value = OrgCode
            'params(1) = New SqlParameter("@Available_cnt", SqlDbType.VarChar)
            'params(1).Value = Available_cnt
            params(1) = New SqlParameter("@Material_id", SqlDbType.VarChar)
            params(1).Value = Material_id
            params(2) = New SqlParameter("@InvBefore_cnt", SqlDbType.VarChar)
            params(2).Value = InvBefore_cnt
            params(3) = New SqlParameter("@InvAfter_cnt", SqlDbType.VarChar)
            params(3).Value = InvAfter_cnt

            Return Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace