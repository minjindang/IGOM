Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MaterialInDetDAO
        Inherits BaseDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

        Public Function GetByMaterialID(ByVal MaterialID As Integer) As DataTable
            Return Query("select * from MAT_MaterialIn_det where Material_id = @Material_id", New SqlParameter("@Material_id", MaterialID))
        End Function

        Public Function GetAll(ByVal materialId As String, ByVal companyName As String) As DataTable
            Dim sqlStr As String = " select * from MAT_MaterialIn_det a left join MAT_Material_main b on a.Material_id = b.Material_id where 1= 1 "
            If Not String.IsNullOrEmpty(materialId) Then
                sqlStr += " and a.Material_id=@Material_id "
            End If
            If Not String.IsNullOrEmpty(companyName) Then
                sqlStr += " and a.company_name like '%' + @companyName + '%' "
            End If

            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", materialId), _
                                        New SqlParameter("@companyName", companyName)}

            Return Query(sqlStr, ps)

        End Function

        Public Function GetAll(ByVal materialId As String, ByVal companyName As String, ByVal In_dateS As String, ByVal In_dateE As String) As DataTable
            Dim sqlStr As String = " select * from MAT_MaterialIn_det a left join MAT_Material_main b on a.Material_id = b.Material_id where 1= 1 "
            If Not String.IsNullOrEmpty(materialId) Then
                sqlStr += " and a.Material_id=@Material_id "
            End If
            If Not String.IsNullOrEmpty(companyName) Then
                sqlStr += " and a.company_name like '%' + @companyName + '%' "
            End If
            If Not String.IsNullOrEmpty(In_dateS) Then
                sqlStr += " and a.In_date>=@In_dateS "
            End If
            If Not String.IsNullOrEmpty(In_dateE) Then
                sqlStr += " and a.In_date<=@In_dateE "
            End If

            Dim ps() As SqlParameter = {New SqlParameter("@Material_id", materialId), _
                                        New SqlParameter("@companyName", companyName), _
                                        New SqlParameter("@In_dateS", In_dateS), _
                                        New SqlParameter("@In_dateE", In_dateE)}

            Return Query(sqlStr, ps)

        End Function

        Public Function GetOne(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String) As DataTable
            Dim sqlStr As String = _
                " select * from MAT_MaterialIn_det a left join MAT_Material_main b on a.Material_id = b.Material_id where a.OrgCode=@OrgCode AND a.Material_id=@Material_id and a.In_date=@In_date "


            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@In_date", In_date)}

            Return Query(sqlStr, ps)
        End Function

        Public Sub Update(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String, ByVal In_cnt As Integer, ByVal Unit As String _
                      , ByVal Buy_date As String, ByVal Buy_cnt As Integer, ByVal UnitPrice_amt As Double, ByVal TotalPrice_amt As Double, ByVal Company_name As String, _
                      ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime)
            Dim sql As New System.Text.StringBuilder
            sql.Append("UPDATE MAT_MaterialIn_det " & vbCrLf)
            sql.Append("            set [In_cnt]=@In_cnt, " & vbCrLf)
            sql.Append("             [Unit]=@Unit, " & vbCrLf)
            sql.Append("             [Buy_date]=@Buy_date, " & vbCrLf)
            sql.Append("             [Buy_cnt]=@Buy_cnt, " & vbCrLf)
            sql.Append("             [UnitPrice_amt]=@UnitPrice_amt, " & vbCrLf)
            sql.Append("             [TotalPrice_amt]=@TotalPrice_amt, " & vbCrLf)
            sql.Append("             [Company_name]=@Company_name, " & vbCrLf)
            sql.Append("             [Memo]=@Memo, " & vbCrLf)
            sql.Append("             [ModUser_id]=@ModUser_id, " & vbCrLf)
            sql.Append("             [Mod_date]=@Mod_date, " & vbCrLf)
            sql.Append("             [OrgCode]=@OrgCode WHERE OrgCode =@OrgCode AND Material_id =@Material_id AND In_date =@In_date " & vbCrLf)

            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@In_date", In_date), _
                                        New SqlParameter("@In_cnt", In_cnt), _
                                        New SqlParameter("@Unit", Unit), _
                                        New SqlParameter("@Buy_date", Buy_date), _
                                        New SqlParameter("@Buy_cnt", Buy_cnt), _
                                        New SqlParameter("@UnitPrice_amt", UnitPrice_amt), _
                                        New SqlParameter("@TotalPrice_amt", TotalPrice_amt), _
                                        New SqlParameter("@Company_name", Company_name), _
                                        New SqlParameter("@Memo", Memo), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@Mod_date", Mod_date)}


            Execute(sql.ToString(), ps)
        End Sub

        Public Sub Update(ByVal Material_id As String, newMaterial_id As String, ByVal ModUser_id As String, _
                    ByVal OrgCode As String, ByVal Mod_date As DateTime)
            Dim StrSQL As String = String.Empty
            StrSQL = " UPDATE MAT_MaterialIn_det SET Material_id=@newMaterial_id,ModUser_id=@ModUser_id,Mod_date=@Mod_date, Orgcode=@Orgcode WHERE Material_id=@Material_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@newMaterial_id", newMaterial_id), _
            New SqlParameter("@Material_id", Material_id), _
            New SqlParameter("@ModUser_id", ModUser_id), _
            New SqlParameter("@Mod_date", Mod_date), _
            New SqlParameter("@Orgcode", OrgCode)}
            Execute(StrSQL, ps)
        End Sub

        Public Sub Insert(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String, ByVal In_cnt As Integer, ByVal Unit As String _
                      , ByVal Buy_date As String, ByVal Buy_cnt As Integer, ByVal UnitPrice_amt As Double, ByVal TotalPrice_amt As Double, ByVal Company_name As String, _
                      ByVal Memo As String, ByVal ModUser_id As String, ByVal Mod_date As DateTime)
            Dim sql As New System.Text.StringBuilder
            sql.Append("INSERT INTO MAT_MaterialIn_det " & vbCrLf)
            sql.Append("            ([OrgCode], " & vbCrLf)
            sql.Append("             [Material_id], " & vbCrLf)
            sql.Append("             [In_date], " & vbCrLf)
            sql.Append("             [In_cnt], " & vbCrLf)
            sql.Append("             [Unit], " & vbCrLf)
            sql.Append("             [Buy_date], " & vbCrLf)
            sql.Append("             [Buy_cnt], " & vbCrLf)
            sql.Append("             [UnitPrice_amt], " & vbCrLf)
            sql.Append("             [TotalPrice_amt], " & vbCrLf)
            sql.Append("             [Company_name], " & vbCrLf)
            sql.Append("             [Memo], " & vbCrLf)
            sql.Append("             [ModUser_id], " & vbCrLf)
            sql.Append("             [Mod_date]) " & vbCrLf)
            sql.Append("VALUES      (@OrgCode, " & vbCrLf)
            sql.Append("             @Material_id, " & vbCrLf)
            sql.Append("             @In_date, " & vbCrLf)
            sql.Append("             @In_cnt, " & vbCrLf)
            sql.Append("             @Unit, " & vbCrLf)
            sql.Append("             @Buy_date, " & vbCrLf)
            sql.Append("             @Buy_cnt, " & vbCrLf)
            sql.Append("             @UnitPrice_amt, " & vbCrLf)
            sql.Append("             @TotalPrice_amt, " & vbCrLf)
            sql.Append("             @Company_name, " & vbCrLf)
            sql.Append("             @Memo, " & vbCrLf)
            sql.Append("             @ModUser_id, " & vbCrLf)
            sql.Append("             @Mod_date) ")

            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@In_date", In_date), _
                                        New SqlParameter("@In_cnt", In_cnt), _
                                        New SqlParameter("@Unit", Unit), _
                                        New SqlParameter("@Buy_date", Buy_date), _
                                        New SqlParameter("@Buy_cnt", Buy_cnt), _
                                        New SqlParameter("@UnitPrice_amt", UnitPrice_amt), _
                                        New SqlParameter("@TotalPrice_amt", TotalPrice_amt), _
                                        New SqlParameter("@Company_name", Company_name), _
                                        New SqlParameter("@Memo", Memo), _
                                        New SqlParameter("@ModUser_id", ModUser_id), _
                                        New SqlParameter("@Mod_date", Mod_date)}


            Execute(sql.ToString(), ps)

        End Sub

        Public Sub Delete(ByVal OrgCode As String, ByVal Material_id As String, ByVal In_date As String)
            Dim sql As New System.Text.StringBuilder
            sql.Append("DELETE FROM MAT_MaterialIn_det WHERE OrgCode =@OrgCode AND Material_id =@Material_id AND In_date =@In_date ")

            Dim ps() As SqlParameter = {New SqlParameter("@OrgCode", OrgCode), _
                                        New SqlParameter("@Material_id", Material_id), _
                                        New SqlParameter("@In_date", In_date)}


            Execute(sql.ToString(), ps)

        End Sub

        Public Function GetMaterialCnt(Material_id As String) As Integer
            Return Scalar("SELECT COUNT(*) as Count FROM  MAT_MaterialIn_det where material_id = @Material_id", New SqlParameter("Material_id", Material_id))
        End Function

        Public Function GetIn_cnt(orgCode As String, yearMonth As String) As DataTable

            Dim StrSQL As New System.Text.StringBuilder
            StrSQL.Append("SELECT Material_id, " & vbCrLf)
            StrSQL.Append("       Sum(In_cnt) In_cnt " & vbCrLf)
            StrSQL.Append("FROM   MAT_MaterialIn_det " & vbCrLf)
            StrSQL.Append("WHERE  Substring (in_date, 1, 5) = @yearMonth " & vbCrLf)
            StrSQL.Append("       AND OrgCode = @Orgcode " & vbCrLf)
            StrSQL.Append("GROUP  BY Material_id ")

            Dim ps() As SqlParameter = { _
            New SqlParameter("@yearMonth", yearMonth), _
            New SqlParameter("@Orgcode", orgCode)}
            Return Query(StrSQL.ToString(), ps)
        End Function

    End Class
End Namespace
