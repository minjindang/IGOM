Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter
Imports System.Text

Namespace FSC.Logic
    Public Class DeputyDetDAO
        Inherits BaseDAO

        Dim ConnectionString As String = String.Empty

        Public Sub New()
            MyBase.New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        ''' <summary>
        ''' 依使用者ID_card查詢職務代理人設定檔
        ''' </summary>
        ''' <param name="ID_card"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDataById_card(ByVal ID_card As String, ByVal Deputy_flag As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT d.id, d.Deputy_orgcode, d.Deputy_departid, d.Deputy_flag, d.Deputy_seq, m.id_card, m.title_no, m.user_name ")
            sql.AppendLine(" , (select top 1 Depart_Name from FSC_Org f where f.Orgcode=d.Deputy_orgcode and f.depart_id=d.Deputy_departid) + '/' + ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_code s where s.code_sys = '023' and s.code_type = '012' and s.code_no=m.title_no ) + ")
            sql.AppendLine(" '/' +  m.user_name as ALL_name, d.Deputy_idcard ")
            sql.AppendLine(" , (select top 1 Depart_Name from FSC_Org f where f.Orgcode=d.Deputy_orgcode and f.depart_id=SUBSTRING(d.Deputy_departid,1,2)) + '/' + ")
            sql.AppendLine(" (select top 1 CODE_DESC1 from SYS_code s where s.code_sys = '023' and s.code_type = '012' and s.code_no=m.title_no ) + ")
            sql.AppendLine(" '/' +  m.user_name as ALL_name_short ")
            sql.AppendLine(" , Deputy_orgcode + ',' + Deputy_departid + ',' + m.id_card as cols ")
            sql.AppendLine(" FROM FSC_Deputy_det d ")
            sql.AppendLine("        INNER JOIN FSC_personnel m ON d.Deputy_idcard=m.ID_card ")
            sql.AppendLine(" WHERE d.ID_card=@Id_card and m.Quit_job_flag<>'Y' ")

            If Not String.IsNullOrEmpty(Deputy_flag) Then
                sql.AppendLine(" AND d.Deputy_flag=@Deputy_flag ")
            End If

            sql.AppendLine(" ORDER BY d.Deputy_seq ")

            Dim params(1) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = ID_card
            params(1) = New SqlParameter("@Deputy_flag", SqlDbType.VarChar)
            params(1).Value = Deputy_flag

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function


        Public Function GetDataById_card(ByVal Orgcode As String, ByVal Depart_id As String, ByVal ID_card As String, ByVal Deputy_flag As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT d.Serial_nos, d.Deputy_flag, m.*, ")
            sql.AppendLine("        f.Orgcode_name, f.Orgcode_shortname, f.Depart_name, r.*, dc.detail_code_name as DESCR, dc.detail_code_id as CODE, ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + m.User_name as full_name, ")
            sql.AppendLine("        m.Title_no +','+ m.Id_card AS ValueList, convert(integer, d.Deputy_flag) as seq ")
            sql.AppendLine(" FROM FSC_Deputy_det d ")
            sql.AppendLine("        INNER JOIN Member m ON d.Deputy_id_card=m.ID_card and m.Orgcode=@Orgcode  ")
            sql.AppendLine("        inner join member m2 on d.id_card=m2.Id_card and m2.Orgcode=@Orgcode and m2.Depart_id=@Depart_id ")
            sql.AppendLine("        LEFT OUTER JOIN FSCorg f ON m.Orgcode=f.Orgcode AND m.Depart_id=f.Depart_id and m.Sub_depart_id=f.Sub_depart_id ")
            sql.AppendLine("        LEFT OUTER JOIN Role r ON m.Role_id=r.Role_id AND m.Orgcode=r.Orgcode ")
            sql.AppendLine("        LEFT OUTER JOIN Detail_code dc ON dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine(" WHERE d.ID_card=@Id_card ")

            If Not String.IsNullOrEmpty(Deputy_flag) Then
                sql.AppendLine(" AND d.Deputy_flag=@Deputy_flag ")
            End If

            sql.AppendLine(" ORDER BY seq ")

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            params(0).Value = Orgcode
            params(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            params(1).Value = Depart_id
            params(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(2).Value = ID_card
            params(3) = New SqlParameter("@Deputy_flag", SqlDbType.VarChar)
            params(3).Value = Deputy_flag
            DBUtil.SetParamsNull(params)
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="ID_card"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDeputyDetByDeputy_idcard(ByVal ID_card As String, ByVal Deputy_id_card As String, Optional ByVal Deputy_flag As String = Nothing, Optional ByVal Deputy_type As String = Nothing) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT d.*, p.* ")
            sql.AppendLine(" FROM FSC_Deputy_det d ")
            sql.AppendLine("    INNER JOIN FSC_personnel p ON d.Deputy_idcard=p.ID_card ")
            sql.AppendLine(" WHERE d.ID_card=@Id_card ")
            sql.AppendLine(" and d.Deputy_idcard=@Deputy_id_card ")

            'If Not String.IsNullOrEmpty(Deputy_flag) Then
            '    sql.AppendLine(" AND d.Deputy_flag=@Deputy_flag ")
            'End If

            'If Not String.IsNullOrEmpty(Deputy_type) Then
            '    sql.AppendLine(" and Deputy_type=@Deputy_type")
            'End If

            Dim params(3) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = ID_card
            params(1) = New SqlParameter("@Deputy_id_card", SqlDbType.VarChar)
            params(1).Value = Deputy_id_card
            params(2) = New SqlParameter("@Deputy_flag", SqlDbType.VarChar)
            params(2).Value = Deputy_flag
            params(3) = New SqlParameter("@Deputy_type", SqlDbType.VarChar)
            params(3).Value = Deputy_type
            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDLLDataById_card(ByVal Orgcode As String, ByVal Id_card As String, Optional ByVal DeputyType As String = "") As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine(" SELECT d.Serial_nos, d.Deputy_flag, ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            sql.AppendLine("        isnull(m.id_Card,'') + ',' + isnull(m.title_no,'') + ',' + isnull(m.Personnel_ID,'') cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) dseq ")
            sql.AppendLine(" FROM FSC_Deputy_det d ")
            sql.AppendLine("        inner join FSC_personnel m ON d.Deputy_id_card=m.ID_card ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" WHERE d.ID_card=@Id_card and m.Quit_job_flag<>'Y' ")

            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" and dc.Fsc_flag <>'0' ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" and dc.Bank_flag <>'0' ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" and dc.sfb_flag <>'0' ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" and dc.Ib_flag <>'0' ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" and dc.Feb_flag <>'0' ")
            End If
            '行政代理人&教學代理人要分開 jessica add 20131220
            If Not String.IsNullOrEmpty(DeputyType) Then
                sql.AppendLine(" and d.Deputy_type = '" & DeputyType & "'")
            End If

            sql.AppendLine(" order by d.Deputy_flag, dseq, f.sub_depart_id ")

            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" , dc.Fsc_flag ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" , dc.Bank_flag ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" , dc.sfb_flag ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" , dc.Ib_flag ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" , dc.Feb_flag ")
            Else
                sql.AppendLine(" , m.Title_no ")
            End If



            Dim params(0) As SqlParameter
            params(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            params(0).Value = Id_card

            DBUtil.SetParamsNull(params)

            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function


        Public Function GetDataBySerial_nos(ByVal id As Integer) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn
            StrSQL = "SELECT * FROM FSC_Deputy_det d INNER JOIN FSC_Personnel m ON d.Deputy_idcard=m.ID_card WHERE d.id={0}"
            StrSQL = String.Format(StrSQL, id)

            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds)
                End Using
            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try
            Return Ds
        End Function


        ''' <summary>
        ''' 新增一筆職務代理人設定檔
        ''' </summary>
        ''' <param name="Id_card"></param>
        ''' <param name="Depart_id"></param>
        ''' <param name="Deputy_flag"></param>
        ''' <param name="Change_userid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertDeputyDet(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Deputy_orgcode As String, _
                                   ByVal Deputy_departid As String, ByVal Deputy_posid As String, ByVal Deputy_idcard As String, ByVal Change_userid As String, ByVal Deputy_flag As String, ByVal Deputy_seq As Integer) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn
            Dim affact As Integer
            Dim StrSQL As String = ""
            StrSQL = "INSERT INTO FSC_Deputy_Det (Orgcode, Depart_id, Id_card, Deputy_orgcode, Deputy_departid, Deputy_posid, Deputy_idcard, Change_userid, Change_date,Deputy_flag,Deputy_seq) " & _
                        "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, Orgcode, Depart_id, Id_card, Deputy_orgcode, Deputy_departid, Deputy_posid, Deputy_idcard, Change_userid, Now.ToString("yyyy/MM/dd HH:mm:ss"), Deputy_flag, Deputy_seq)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    affact = SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try

            Return affact
        End Function

        ''' <summary>
        ''' 更新一筆職務代理人設定檔
        ''' </summary>
        ''' <param name="Id_card"></param>
        ''' <param name="Depart_id"></param>
        ''' <param name="Deputy_flag"></param>
        ''' <param name="Change_userid"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Deputy_orgcode As String, ByVal Deputy_departid As String, _
                                   ByVal Deputy_posid As String, ByVal Deputy_idcard As String, ByVal Change_userid As String, ByVal id As Integer, ByVal Deputy_flag As String, ByVal Deputy_seq As Integer) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim affact As Integer
            Dim StrSQL As String = ""

            StrSQL = " update FSC_Deputy_Det set Orgcode='{0}', Depart_id='{1}', Id_card='{2}', Deputy_orgcode='{3}', "
            StrSQL += " Deputy_departid='{4}', Deputy_posid='{5}', Deputy_idcard='{6}', Change_userid='{7}', Change_date='{8}', Deputy_flag='{10}', Deputy_seq='{11}' "
            StrSQL += " where id={9} "

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, Orgcode, Depart_id, Id_card, Deputy_orgcode, Deputy_departid, Deputy_posid, Deputy_idcard, Change_userid, Now.ToString("yyyy/MM/dd HH:mm:ss"), id, Deputy_flag, Deputy_seq)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    affact = SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
            Return affact
        End Function


        Public Function UpdateDeputyFlag(ByVal Id_card As String, ByVal Deputy_flag As String, ByVal Change_userid As String, Optional ByVal Deputy_Type As String = "1") As Integer
            Dim affact As Integer
            Dim sql As String = ""



            sql = "UPDATE Deputy_Det SET Deputy_flag=@Deputy_flag, Deputy_type=@Deputy_type, Change_userid=@Change_userid, Change_date=@Change_date WHERE Id_card=@Id_card "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@Deputy_flag", Deputy_flag), _
            New SqlParameter("@Deputy_type", Deputy_Type), _
            New SqlParameter("@Change_userid", Change_userid), _
            New SqlParameter("@Change_date", Now.ToString("yyyy/MM/dd HH:mm:ss")), _
            New SqlParameter("@Id_card", Id_card)}

            affact = CommonFun.getInt(Execute(sql, ps).ToString())
            Return affact
        End Function


        ''' <summary>
        ''' 刪除一筆職務代理人設定檔
        ''' </summary>
        ''' <param name="id"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteData(ByVal id As Integer) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim affact As Integer
            Dim StrSQL As String = ""
            StrSQL = "DELETE FROM FSC_Deputy_det WHERE id={0}"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, id)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    affact = SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try
            Return affact
        End Function

        Public Function DeleteIdcard(ByVal Orgcode As String, ByVal Id_card As String) As Integer
            Dim sql As New StringBuilder

            sql.Append("DELETE FROM FSC_Deputy_det ")
            sql.Append("WHERE Orgcode=@Orgcode AND Id_card=@Id_card")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card

            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function getNotDefaultData(ByVal Orgcode As String, ByVal Id_card As String) As DataTable
            Dim sql As New StringBuilder

            sql.Append(" select * from FSC_Deputy_det ")
            sql.Append(" WHERE Orgcode=@Orgcode AND Id_card=@Id_card and Deputy_seq <> '1' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card

            Return Query(sql.ToString(), params)
        End Function

        Public Function UpdateSeq(ByVal id As String, ByVal Deputy_seq As String) As Integer
            Dim sql As New StringBuilder

            sql.Append(" update FSC_Deputy_det set Deputy_seq=@Deputy_seq ")
            sql.Append(" ,Deputy_flag = '0' ")
            sql.Append(" WHERE id=@id ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@id", SqlDbType.VarChar), _
            New SqlParameter("@Deputy_seq", SqlDbType.VarChar)}
            params(0).Value = id
            params(1).Value = Deputy_seq

            Return Execute(sql.ToString(), params)
        End Function
    End Class
End Namespace
