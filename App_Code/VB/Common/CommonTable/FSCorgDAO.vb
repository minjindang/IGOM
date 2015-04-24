Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Text
Imports System

Namespace FSCPLM.Logic
    Public Class FSCorgDAO
        Inherits BaseDAO
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Function updateData(ByVal f As FSCorg, ByVal UOrgcode As String, ByVal UDepart_id As String, ByVal USub_depart_id As String) As Integer
            Dim sql As New StringBuilder()
            sql.AppendLine(" update fscorg set ")
            sql.AppendLine(" Orgcode=@Orgcode, Orgcode_name=@Orgcode_name, Orgcode_shortname=@Orgcode_shortname, ")
            sql.AppendLine(" Depart_id=@Depart_id, Depart_name=@Depart_name, Sub_depart_id=@Sub_depart_id, Sub_depart_name=@Sub_depart_name, ")
            sql.AppendLine(" Seq=@Seq, Visable_flag=@Visable_flag ")
            sql.AppendLine(" where ")
            sql.AppendLine(" Orgcode=@UOrgcode and Depart_id=@UDepart_id and Sub_depart_id=@USub_depart_id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode_name", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode_shortname", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Depart_name", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_name", SqlDbType.VarChar), _
            New SqlParameter("@Seq", SqlDbType.VarChar), _
            New SqlParameter("@Visable_flag", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar), _
            New SqlParameter("@Change_date", SqlDbType.VarChar), _
            New SqlParameter("@UOrgcode", SqlDbType.VarChar), _
            New SqlParameter("@UDepart_id", SqlDbType.VarChar), _
            New SqlParameter("@USub_depart_id", SqlDbType.VarChar)}
            params(0).Value = f.Orgcode
            params(1).Value = f.Orgcode_name
            params(2).Value = f.Orgcode_shortname
            params(3).Value = f.Depart_id
            params(4).Value = f.Depart_name
            params(5).Value = f.Sub_depart_id
            params(6).Value = f.Sub_depart_name
            params(7).Value = f.Seq
            params(8).Value = f.Visable_flag
            params(9).Value = f.Change_userid
            params(10).Value = f.Change_date
            params(11).Value = UOrgcode
            params(12).Value = UDepart_id
            params(13).Value = USub_depart_id

            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetData(ByVal Orgcode As String) As DataSet
            Dim StrSQL As String = String.Empty

            StrSQL = "select distinct Orgcode, Orgcode_name, Orgcode_shortname, Orgcode_shortname AS OrgcodeName from FSCorg "

            Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param.Value = DBNull.Value

            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= "Where Orgcode = @Orgcode "
                param.Value = Orgcode
            End If

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, param)
        End Function


        Public Function GetSeq(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As Object
            Dim sql As New StringBuilder()

            sql.AppendLine(" select top 1 Seq  ")
            sql.AppendLine(" from FSCorg where 1=1 ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.Append(" AND Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.Append(" AND Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Sub_depart_id) And Not "0".Equals(Sub_depart_id) Then
                sql.Append(" AND Sub_depart_id=@Sub_departid ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_departid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Sub_depart_id
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteScalar(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.Append("select *,(select top 1 seq from FSCorg sf where db1.Orgcode=sf.Orgcode and db1.Depart_id=sf.Depart_id ) as seq from ( ")
            sql.Append(" SELECT distinct  Orgcode, Depart_id, Depart_name FROM FSCOrg ")
            sql.Append(" WHERE Orgcode=@Orgcode and Visable_flag='Y' ")
            If "DeptHead".Equals(Role_id) Or "Master".Equals(Role_id) Then
                '部門主管
                sql.Append(" AND Depart_id=@Depart_id ")
            End If
            sql.Append("GROUP BY Orgcode, Depart_id, Depart_name")
            sql.Append(" ) as db1 ")
            sql.Append(" order by seq ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("Depart_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetSub_depart(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_departid As String) As DataSet
            Dim sql As New StringBuilder
            sql.Append("SELECT distinct Orgcode, Sub_depart_id, Sub_depart_name FROM FSCOrg ")
            sql.Append("WHERE  Sub_depart_id<>'' ")
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.Append(" AND Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.Append(" AND Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Sub_departid) And Not "0".Equals(Sub_departid) Then
                sql.Append(" AND Sub_depart_id=@Sub_departid ")
            End If
            sql.Append("GROUP BY Orgcode, Sub_depart_id, Sub_depart_name ")
            sql.Append(" order by Sub_depart_id ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_departid", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Sub_departid
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDepartNameByOrgcodeDepartID(ByVal Orgcode As String, ByVal DepartID As String) As DataSet
            Dim sql As New StringBuilder()
            sql.AppendLine(" select distinct *,(select top 1 seq from FSCorg sf where db1.Orgcode=sf.Orgcode and db1.Depart_id=sf.Depart_id and visable_flag='Y') as seq ")
            sql.AppendLine(" from (select Distinct Orgcode_shortname as OrgcodeName, Orgcode_name as LongOrgcodeName, Orgcode_name, ")
            sql.AppendLine("       Orgcode, Depart_id as DepartID, Depart_id, Depart_name as DepartName, Depart_name, Sub_depart_id, Sub_depart_name from FSCorg where visable_flag='Y') as db1 ")
            sql.AppendLine(" where ")
            sql.AppendLine(" Orgcode = @Orgcode ")
            If Not String.IsNullOrEmpty(DepartID) Then
                sql.AppendLine(" And Depart_id = @Depart_id ")
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = DepartID
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataByODS(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select distinct Orgcode,* from FSCorg Where "
            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL &= " Orgcode = @Orgcode "
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                StrSQL &= " And Depart_id = @Depart_id "
            End If
            If Not String.IsNullOrEmpty(Sub_depart_id) Then
                StrSQL &= " And Sub_depart_id = @Sub_depart_id "
            End If
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Sub_depart_id
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        ''' <summary>
        ''' [組織架構檔]
        ''' 取得 機關名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataByOrgcode(ByVal Orgcode As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine(" select *,(select top 1 seq from FSCorg sf where db1.Orgcode=sf.Orgcode and db1.Depart_id=sf.Depart_id and visable_flag='Y') as seq ")
            sql.AppendLine(" from (select Distinct Orgcode_shortname as OrgcodeName, Orgcode_name as LongOrgcodeName, Orgcode_name, ")
            sql.AppendLine("       Orgcode, Depart_id as DepartID, Depart_id, Depart_name as DepartName, Depart_name from FSCorg where visable_flag='Y') as db1 ")

            Dim param As SqlParameter = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            param.Value = DBNull.Value

            If Not String.IsNullOrEmpty(Orgcode) Then
                '0980819 人立修改，增加判斷 visable_flag='Y'
                sql.AppendLine(" where Orgcode = @Orgcode  ")
                param.Value = Orgcode
            End If
            sql.AppendLine(" order by seq ")

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), param)

        End Function

        ''' <summary>
        ''' [組織架構檔]
        ''' 取得 單位名稱
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepartName(ByVal Orgcode As String, ByVal DepartID As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "select distinct Depart_name as DepartName, Depart_id as DepartID, Orgcode from FSCorg Where Orgcode=@orgcode and depart_id=@depart_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@orgcode", Orgcode), _
            New SqlParameter("@depart_id", DepartID)}
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, ps)
        End Function

        Public Function GetDataByCondition(ByVal Orgcode As String, ByVal DepartID As String, ByVal SubDepartID As String) As DataSet
            Dim StrSQL As New StringBuilder
            Dim paramList As New System.Collections.Generic.List(Of SqlParameter)
            Dim param As SqlParameter
            '0980819 人立修改，增加判斷 visable_flag='Y' 
            StrSQL.AppendLine(" SELECT *,(select top 1 seq from FSCorg sf where db1.Orgcode=sf.Orgcode and db1.Depart_id=sf.Depart_id ) as seq ")
            StrSQL.AppendLine(" from ( ")
            StrSQL.AppendLine(" SELECT distinct ")
            StrSQL.AppendLine("       Orgcode, Orgcode_name, Orgcode_shortname, Depart_id, Depart_name ")

            If Not String.IsNullOrEmpty(SubDepartID) Then
                StrSQL.AppendLine(" , Sub_depart_id, Sub_depart_name ")
            End If

            StrSQL.AppendLine(" FROM ")
            StrSQL.AppendLine("      FSCorg f")
            StrSQL.AppendLine(" WHERE ")
            StrSQL.AppendLine(" visable_flag='Y' ")


            If Not String.IsNullOrEmpty(Orgcode) Then
                StrSQL.AppendLine(" AND Orgcode = @Orgcode ")
                param = New SqlParameter("@Orgcode", SqlDbType.VarChar)
                param.Value = Orgcode
                paramList.Add(param)
            End If

            If Not String.IsNullOrEmpty(DepartID) Then
                StrSQL.AppendLine(" AND Depart_id = @DepartID ")
                param = New SqlParameter("@DepartID", SqlDbType.VarChar)
                param.Value = DepartID
                paramList.Add(param)
            End If

            If Not String.IsNullOrEmpty(SubDepartID) Then
                StrSQL.AppendLine(" AND Sub_depart_id = @SubDepartID ")
                param = New SqlParameter("@SubDepartID", SqlDbType.VarChar)
                param.Value = SubDepartID
                paramList.Add(param)
            End If
            StrSQL.AppendLine(" ) as db1  ")
            StrSQL.AppendLine(" order by seq ")
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL.ToString(), paramList.ToArray)
        End Function

        Public Function GetDepartByNotLikeDepartId(ByVal DepartID As String)
            Dim StrSQL As String = String.Empty
            StrSQL = "select distinct Orgcode_shortname + '-' + Depart_name as DepartName, Depart_id as DepartID, Orgcode "
            StrSQL &= " from FSCorg Where depart_id not like @depart_id "
            StrSQL &= " order by Orgcode, depart_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@depart_id", "%" & DepartID & "%")}
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, ps)
        End Function

        Public Function GetDepartByRole_id(ByVal Orgcode As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine("select *,(select top 1 seq from FSCorg sf where db1.Orgcode=sf.Orgcode and db1.Depart_id=sf.Depart_id ) as seq ")
            sql.AppendLine("from (select distinct m.depart_id, f.depart_name,f.OrgCode ")
            sql.AppendLine("        from member m ")
            sql.AppendLine("        inner join fscorg f on m.orgcode=f.orgcode and m.depart_id=f.depart_id ")
            sql.AppendLine("        where f.orgcode=@Orgcode and visable_flag='Y' and m.Quit_job_flag<>'Y' ")
            If Role_id = "Personnel" Then
                sql.AppendLine(" and m.Metadb_id='1' ")
            ElseIf Role_id = "TWDAdmin" Then
                sql.AppendLine(" and m.Metadb_id='2' ")
            ElseIf Role_id = "GenServAdmin" Then
                sql.AppendLine(" and m.Metadb_id='2' ")
            End If
            sql.AppendLine("        ) as db1 ")
            sql.AppendLine(" order by seq ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDepartIdAndNameByOrgcodeDepartID(ByVal Orgcode As String, ByVal DepartID As String) As DataSet
            Dim sql As New StringBuilder()
            sql.AppendLine(" select Depart_id , Depart_name ")
            sql.AppendLine(" from FSCorg where visable_flag='Y' ")
            sql.AppendLine(" and Orgcode = @Orgcode ")
            If Not String.IsNullOrEmpty(DepartID) Then
                sql.AppendLine(" And Depart_id = @Depart_id ")
            End If
            sql.AppendLine(" group by Depart_id , Depart_name ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = DepartID
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

    End Class
End Namespace