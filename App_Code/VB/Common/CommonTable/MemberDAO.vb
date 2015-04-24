Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Pemis2009.SQLAdapter
Imports System.Collections.Generic
Imports System.Text

Namespace FSCPLM.Logic
    Public Class MemberDAO
        Inherits BaseDAO

        Dim ConnectionString As String = ""
        Dim ConnectionStringCPA As String = ""
        Dim Connection As SqlConnection

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            MyBase.New(conn)
            Me.Connection = conn
        End Sub

        Public Function insert(ByVal mem As Member) As Integer
            Dim sql As String = String.Empty

            sql = " INSERT INTO Member "
            sql &= "        (Id_card, Personnel_id, Title_no, Orgcode, Depart_id, Sub_depart_id, User_name, "
            sql &= "        Email, User_password, Boss_orgcode, Boss_departid, Boss_posid, Boss_idcard, "
            sql &= "        Budget_type,Role_id, Quit_job_flag, Metadb_id, Delete_flag, Email_YN, Frequency, "
            sql &= "        Change_userid, Change_date, Office_tel, Office_ext, Indigenous_flag, Login_type, Join_sdate, Login_status, Elected_officials_flag , "
            sql &= "        Cold_dates , Cold_datee "
            sql &= "        ) "
            sql &= " VALUES (@Id_card, @Personnel_id, @Title_no, @Orgcode, @Depart_id, @Sub_depart_id, @User_name, "
            sql &= "        @Email, @User_password, @Boss_orgcode, @Boss_departid, @Boss_posid, @Boss_idcard, "
            sql &= "        @Budget_type,@Role_id, @Quit_job_flag, @Metadb_id, 'N', 'Y', '1', "
            sql &= "        @Change_userid, getdate(), @Office_tel, @Office_ext, @Indigenous_flag, @Login_type, @Join_sdate, @Login_status, @Elected_officials_flag ,  "
            sql &= "        @Cold_dates , @Cold_datee "
            sql &= "        ) "

            Dim aryParms(26) As SqlParameter
            aryParms(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(1) = New SqlParameter("@Personnel_id", SqlDbType.VarChar)
            aryParms(2) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            aryParms(3) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(4) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(5) = New SqlParameter("@User_name", SqlDbType.NVarChar)
            aryParms(6) = New SqlParameter("@Email", SqlDbType.NVarChar)
            aryParms(7) = New SqlParameter("@User_password", SqlDbType.VarChar)
            aryParms(8) = New SqlParameter("@Boss_orgcode", SqlDbType.VarChar)
            aryParms(9) = New SqlParameter("@Boss_departid", SqlDbType.VarChar)
            aryParms(10) = New SqlParameter("@Boss_posid", SqlDbType.VarChar)
            aryParms(11) = New SqlParameter("@Boss_idcard", SqlDbType.VarChar)
            aryParms(12) = New SqlParameter("@Budget_type", SqlDbType.VarChar)
            aryParms(13) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(14) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(15) = New SqlParameter("@Metadb_id", SqlDbType.VarChar)
            aryParms(16) = New SqlParameter("@Sub_depart_id", SqlDbType.VarChar)
            aryParms(17) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            aryParms(18) = New SqlParameter("@Office_tel", SqlDbType.VarChar)
            aryParms(19) = New SqlParameter("@Office_ext", SqlDbType.VarChar)
            aryParms(20) = New SqlParameter("@Indigenous_flag", SqlDbType.VarChar)
            aryParms(21) = New SqlParameter("@Login_type", SqlDbType.VarChar)
            aryParms(22) = New SqlParameter("@Join_sdate", SqlDbType.VarChar)
            aryParms(23) = New SqlParameter("@Login_status", SqlDbType.VarChar)
            aryParms(24) = New SqlParameter("@Elected_officials_flag", SqlDbType.VarChar)
            aryParms(25) = New SqlParameter("@Cold_dates", SqlDbType.VarChar)
            aryParms(26) = New SqlParameter("@Cold_datee", SqlDbType.VarChar)

            aryParms(0).Value = mem.Id_card
            aryParms(1).Value = mem.Personnel_id
            aryParms(2).Value = mem.Title_no
            aryParms(3).Value = mem.Orgcode
            aryParms(4).Value = mem.Depart_id
            aryParms(5).Value = mem.User_name
            aryParms(6).Value = mem.Email
            aryParms(7).Value = mem.User_password
            aryParms(8).Value = mem.Boss_orgcode
            aryParms(9).Value = mem.Boss_departid
            aryParms(10).Value = mem.Boss_posid
            aryParms(11).Value = mem.Boss_idcard
            aryParms(12).Value = mem.Budget_type
            aryParms(13).Value = mem.Role_id
            aryParms(14).Value = mem.Quit_job_flag
            aryParms(15).Value = mem.Metadb_id
            aryParms(16).Value = mem.Sub_depart_id
            aryParms(15).Value = mem.Metadb_id
            aryParms(16).Value = mem.Sub_depart_id
            aryParms(17).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            aryParms(18).Value = mem.Office_tel
            aryParms(19).Value = mem.Office_ext
            aryParms(20).Value = mem.Indigenous_flag
            aryParms(21).Value = mem.Login_type
            aryParms(22).Value = mem.Join_sdate
            aryParms(23).Value = "0"
            aryParms(24).Value = mem.Elected_officials_flag
            aryParms(25).Value = mem.Cold_dates
            aryParms(26).Value = mem.Cold_datee

            'DBUtil.SetParamsNull(aryParms)

            'If Me.Connection IsNot Nothing Then
            '    Return SqlAccessHelper.ExecuteNonQuery(Connection, CommandType.Text, sql, aryParms)
            'End If
            'Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, aryParms)

            Return Execute(sql, aryParms)
        End Function


        Public Function update(ByVal mem As Member) As Integer
            Dim sql As String = String.Empty

            sql = " UPDATE Member "
            sql &= " SET  Personnel_id =@Personnel_id, Title_no =@Title_no "
            sql &= " , Orgcode =@Orgcode, Depart_id =@Depart_id, Sub_depart_id=@Sub_depart_id, User_name =@User_name, Email =@Email, User_password =@User_password"
            sql &= " , Boss_orgcode=@Boss_orgcode, Boss_departid=@Boss_departid, Boss_posid =@Boss_posid, Boss_idcard =@Boss_idcard"
            sql &= " , Budget_type =@Budget_type , Role_id=@Role_id, Quit_job_flag=@Quit_job_flag, Change_userid=@Change_userid, Change_date=getdate() " ', Metadb_id=@Metadb_id "
            sql &= " , Office_tel=@Office_tel, Office_ext=@Office_ext, Indigenous_flag=@Indigenous_flag, Login_type=@Login_type, Join_sdate=@Join_sdate, Elected_officials_flag=@Elected_officials_flag "
            sql &= " , Cold_dates=@Cold_dates , Cold_datee=@Cold_datee "
            sql &= " where Id_card =@Id_card and Orgcode =@Orgcode "
            'sql &= " and Quit_job_flag=@Quit_job_flag "

            Dim aryParms(25) As SqlParameter
            aryParms(0) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(1) = New SqlParameter("@Personnel_id", SqlDbType.VarChar)
            aryParms(2) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            aryParms(3) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(4) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(5) = New SqlParameter("@User_name", SqlDbType.NVarChar)
            aryParms(6) = New SqlParameter("@Email", SqlDbType.NVarChar)
            aryParms(7) = New SqlParameter("@User_password", SqlDbType.VarChar)
            aryParms(8) = New SqlParameter("@Boss_orgcode", SqlDbType.VarChar)
            aryParms(9) = New SqlParameter("@Boss_departid", SqlDbType.VarChar)
            aryParms(10) = New SqlParameter("@Boss_posid", SqlDbType.VarChar)
            aryParms(11) = New SqlParameter("@Boss_idcard", SqlDbType.VarChar)
            aryParms(12) = New SqlParameter("@Budget_type", SqlDbType.VarChar)
            aryParms(13) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(14) = New SqlParameter("@Quit_job_flag", SqlDbType.VarChar)
            aryParms(15) = New SqlParameter("@Metadb_id", SqlDbType.VarChar)
            aryParms(16) = New SqlParameter("@Sub_depart_id", SqlDbType.VarChar)
            aryParms(17) = New SqlParameter("@Change_userid", SqlDbType.VarChar)
            aryParms(18) = New SqlParameter("@Office_tel", SqlDbType.VarChar)
            aryParms(19) = New SqlParameter("@Office_ext", SqlDbType.VarChar)
            aryParms(20) = New SqlParameter("@Indigenous_flag", SqlDbType.VarChar)
            aryParms(21) = New SqlParameter("@Login_type", SqlDbType.VarChar)
            aryParms(22) = New SqlParameter("@Join_sdate", SqlDbType.VarChar)
            aryParms(23) = New SqlParameter("@Elected_officials_flag", SqlDbType.VarChar)
            aryParms(24) = New SqlParameter("@Cold_dates", SqlDbType.VarChar)
            aryParms(25) = New SqlParameter("@Cold_datee", SqlDbType.VarChar)

            aryParms(0).Value = mem.Id_card
            aryParms(1).Value = mem.Personnel_id
            aryParms(2).Value = mem.Title_no
            aryParms(3).Value = mem.Orgcode
            aryParms(4).Value = mem.Depart_id
            aryParms(5).Value = mem.User_name
            aryParms(6).Value = mem.Email
            aryParms(7).Value = mem.User_password
            aryParms(8).Value = mem.Boss_orgcode
            aryParms(9).Value = mem.Boss_departid
            aryParms(10).Value = mem.Boss_posid
            aryParms(11).Value = mem.Boss_idcard
            aryParms(12).Value = mem.Budget_type
            aryParms(13).Value = mem.Role_id
            aryParms(14).Value = mem.Quit_job_flag
            aryParms(15).Value = mem.Metadb_id
            aryParms(16).Value = mem.Sub_depart_id
            aryParms(15).Value = mem.Metadb_id
            aryParms(16).Value = mem.Sub_depart_id
            aryParms(17).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            aryParms(18).Value = mem.Office_tel
            aryParms(19).Value = mem.Office_ext
            aryParms(20).Value = mem.Indigenous_flag
            aryParms(21).Value = mem.Login_type
            aryParms(22).Value = mem.Join_sdate
            aryParms(23).Value = mem.Elected_officials_flag
            aryParms(24).Value = mem.Cold_dates
            aryParms(25).Value = mem.Cold_datee
            'DBUtil.SetParamsNull(aryParms)

            'If Me.Connection IsNot Nothing Then
            '    Return SqlAccessHelper.ExecuteNonQuery(Connection, CommandType.Text, sql, aryParms)
            'End If
            'Return SqlAccessHelper.ExecuteNonQuery(ConnectionString, CommandType.Text, sql, aryParms)

            Return Execute(sql, aryParms)
        End Function

        Public Function GetDataByOrgCode(ByVal OrgCode As String) As DataTable
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM Member WHERE Orgcode=@Orgcode"
            Dim param() As SqlParameter = {New SqlParameter("@Orgcode", OrgCode)}
            
            Return Query(StrSQL, param)
        End Function

        Public Function GetDataByPId(ByVal PId As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM Member WHERE Personnel_id=@PId"
            Dim param As SqlParameter = New SqlParameter("@PId", SqlDbType.VarChar)
            param.Value = PId

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, StrSQL, param)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataAll(ByVal PId As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM Member WHERE Id_card=@PId"
            Dim param As SqlParameter = New SqlParameter("@PId", SqlDbType.VarChar)
            param.Value = PId

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, StrSQL, param)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        Public Function GetDataByIDcard(ByVal Orgcode As String, _
                                        ByVal DepartID As String, _
                                        ByVal Sub_depart_id As String, _
                                        ByVal ID_card As String, _
                                        ByVal Personnel_id As String, _
                                        ByVal Include_Quit_job As Boolean, _
                                        Optional ByVal Trans_All As Boolean = True) As DataSet

            Dim sql As New StringBuilder()
            sql.AppendLine("select m.*, ")
            sql.AppendLine("(select top 1 Orgcode_name from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as Orgcode_name, ")
            sql.AppendLine("(select top 1 Orgcode_shortname from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as Orgcode_shortname, ")
            sql.AppendLine("(select top 1 Depart_name from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as Depart_name, ")
            sql.AppendLine("(select top 1 Sub_depart_name from fscorg where orgcode=m.orgcode and depart_id=m.depart_id and sub_depart_id=m.sub_depart_id) as Sub_depart_name, ")
            sql.AppendLine("r.*, dc.detail_code_name as DESCR, dc.detail_code_id as CODE, dc.detail_code_name as Title_name ")
            sql.AppendLine("FROM Member m ")
            sql.AppendLine("LEFT OUTER JOIN Role r ON m.Role_id=r.Role_id AND m.Orgcode=r.Orgcode ")
            sql.AppendLine("LEFT OUTER JOIN Detail_code dc ON dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("WHERE 1=1 ")

            '因應自動轉出勤,如果人事尚未轉入刷卡資料,則原民處及民政處將濾掉
            If Not Trans_All Then
                sql.AppendLine(" AND m.Depart_id not in('0200','1500') ")
            End If

            If Not Include_Quit_job Then
                sql.AppendLine(" AND m.Quit_job_flag<>'Y' ")
            End If
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" AND m.Orgcode=@Orgcode ")
            End If
            If Not String.IsNullOrEmpty(DepartID) Then
                sql.AppendLine(" AND m.Depart_id=@Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Sub_depart_id) Then
                sql.AppendLine(" AND m.Sub_depart_id=@Sub_depart_id ")
            End If
            If Not String.IsNullOrEmpty(ID_card) Then
                sql.AppendLine(" AND m.ID_card=@Id_card ")
            End If
            If Not String.IsNullOrEmpty(Personnel_id) Then
                sql.AppendLine(" AND m.Personnel_id=@Personnel_id ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Personnel_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = DepartID
            params(2).Value = Sub_depart_id
            params(3).Value = ID_card
            params(4).Value = Personnel_id
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataByTitle_no(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String, ByVal Title_no As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine("SELECT m.*, f.Orgcode_name, f.Orgcode_shortname, f.Depart_name, f.sub_depart_name, r.*, dc.detail_code_name as DESCR, dc.detail_code_id as CODE ")
            sql.AppendLine("FROM Member m ")
            sql.AppendLine("LEFT OUTER JOIN FSCorg f ON m.Orgcode=f.Orgcode AND m.Depart_id=f.Depart_id AND f.sub_depart_id=m.sub_depart_id  ")
            sql.AppendLine("LEFT OUTER JOIN Role r ON m.Role_id=r.Role_id AND m.Orgcode=r.Orgcode ")
            sql.AppendLine("LEFT OUTER JOIN Detail_code dc ON dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("WHERE m.Orgcode=@Orgcode AND m.Title_no=@Title_no and m.Quit_job_flag<>'Y' ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" AND m.Depart_id=@Depart_id  ")
            End If

            If Not String.IsNullOrEmpty(Sub_depart_id) Then
                sql.AppendLine(" AND m.Sub_depart_id=@Sub_depart_id  ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Title_no", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Sub_depart_id
            params(3).Value = Title_no

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString, params)
        End Function

        Public Function GetDataByBudgetType(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Budget_type As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM Member WHERE Orgcode=@Orgcode AND Budget_type=@Budget_type "

            If Not String.IsNullOrEmpty(Depart_id) Then
                StrSQL &= " AND Depart_id=@Depart_id "
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Budget_type", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Budget_type

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, StrSQL, params)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, params)
        End Function

        'use for fsc3401_01
        Public Function GetDLLDataByODSTQM(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Role_id As String, ByVal Sub_departid As String, ByVal Title_no As String, ByVal Quit_job_Flag As String, ByVal Metadb_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            sql.AppendLine("        User_name + '(' + m.Personnel_ID + ')' + '-' + isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') as full_name2, ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as show_name, ")
            'sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + isnull(m.Personnel_ID,'')  cols, m.*, ")
            sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + m.Personnel_ID as  cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=isnull(m.Title_no,'') and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Role_id<>'SysAdmin' ")

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

            If Not String.IsNullOrEmpty(Quit_job_Flag) Then
                sql.AppendLine(" and m.Quit_job_Flag = @Quit_job_Flag ")
            End If
            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and m.Depart_id= @Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Sub_departid) AndAlso Not "0".Equals(Sub_departid) Then
                sql.AppendLine(" and m.Sub_depart_id=@Sub_departid ")
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                sql.AppendLine(" and m.Title_no= @Title_no ")
            End If

            ' If LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) <> "TWDAdmin" And _
            '    LoginManager.GetTicketUserData(LoginManager.LoginUserData.RoleId) <> "Personnel" And _
            '      Not String.IsNullOrEmpty(Metadb_id) Then
            ' sql.AppendLine(" and m.Metadb_id=@Metadb_id ")
            ' End If

            If Role_id = "Personnel" Or Role_id = "FeePersonnel" Then
                sql.AppendLine(" and m.Metadb_id='1' ")
            ElseIf Role_id = "TWDAdmin" Or Role_id = "TWDFee" Or Role_id = "GenServAdmin" Then
                sql.AppendLine(" and m.Metadb_id='2' ")
            End If

            sql.AppendLine(" order by dseq, f.sub_depart_id ")

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

            If String.IsNullOrEmpty(Orgcode) Then
                Orgcode = ""
            End If
            If String.IsNullOrEmpty(Depart_id) Then
                Depart_id = ""
            End If
            If String.IsNullOrEmpty(Sub_departid) Then
                Sub_departid = ""
            End If
            If String.IsNullOrEmpty(Title_no) Then
                Title_no = ""
            End If
            If String.IsNullOrEmpty(Metadb_id) Then
                Metadb_id = ""
            End If

            Dim aryParms(5) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Sub_departid", SqlDbType.VarChar)
            aryParms(2).Value = Sub_departid
            aryParms(3) = New SqlParameter("@Title_no", SqlDbType.VarChar)
            aryParms(3).Value = Title_no
            aryParms(4) = New SqlParameter("@Quit_job_Flag", SqlDbType.VarChar)
            aryParms(4).Value = Quit_job_Flag
            aryParms(5) = New SqlParameter("@Metadb_id", SqlDbType.VarChar)
            aryParms(5).Value = Metadb_id
            DBUtil.SetParamsNull(aryParms)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), aryParms)
            End If
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), aryParms)
        End Function

        Public Function GetDLLDataByODR(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            'sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + isnull(m.Personnel_ID,'')  cols, m.*, ")
            sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + m.Personnel_ID as  cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Quit_job_flag<>'Y' ")

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

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and m.Depart_id= @Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Role_id) Then
                sql.AppendLine(" and m.Role_id in (" & Role_id & ") ")
            End If
            sql.AppendLine(" order by dseq, f.sub_depart_id ")

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

            Dim aryParms(1) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            DBUtil.SetParamsNull(aryParms)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), aryParms)
            End If
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), aryParms)
        End Function


        Public Function GetDLLDataByODR2(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_departid As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            'sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + isnull(m.Personnel_ID,'')  cols, m.*, ")
            sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + m.Personnel_ID as  cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Quit_job_flag<>'Y' ")

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

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and m.Depart_id= @Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Sub_departid) Then
                sql.AppendLine(" and m.Sub_depart_id= @Sub_departid ")
            End If
            If Role_id = "Personnel" Or Role_id = "FeePersonnel" Then
                sql.AppendLine(" and m.Metadb_id='1' ")
            ElseIf Role_id = "TWDAdmin" Or Role_id = "TWDFee" Or Role_id = "GenServAdmin" Then
                sql.AppendLine(" and m.Metadb_id='2' ")
            End If
            sql.AppendLine(" order by dseq, f.sub_depart_id ")

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

            Dim aryParms(2) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Sub_departid", SqlDbType.VarChar)
            aryParms(2).Value = Sub_departid
            DBUtil.SetParamsNull(aryParms)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), aryParms)
            End If
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), aryParms)
        End Function

        '20120730 remark by chihliwang
        '人員介面切換功能
        Public Function GetDLLDataByODRR(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Subdepid As String, ByVal Old_roleid As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            sql.AppendLine("        isnull(Personnel_ID,'') + '/' + isnull(id_Card,'') cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Quit_job_flag<>'Y' ")

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

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and m.Depart_id= @Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Subdepid) Then
                sql.AppendLine(" and m.Sub_depart_id= @Sub_depart_id ")
            End If

            'If Old_roleid.Equals("SysAdmin") Then
            '    If Not String.IsNullOrEmpty(Role_id) AndAlso Role_id.Equals("Personnel") Then
            '        sql.AppendLine(" and (m.Metadb_id='1' OR m.Metadb_id='2' OR m.Role_id='SysAdmin' OR m.Role_id='Personnel') ")
            '    End If
            '    If Not String.IsNullOrEmpty(Role_id) AndAlso Role_id.Equals("TWDAdmin") Then
            '        sql.AppendLine(" and (m.Metadb_id='2' OR m.Role_id='SysAdmin' OR m.Role_id='TWDAdmin') ")
            '    End If
            'End If

            If Old_roleid.Equals("Personnel") Then
                'sql.AppendLine(" and (m.Metadb_id='1' OR m.Metadb_id='2' OR m.Role_id='Personnel') ")
                '20120730 mod by chihliwang
                sql.AppendLine(" and (m.Metadb_id='1' OR m.Role_id='Personnel') ")
            End If

            If Old_roleid.Equals("TWDAdmin") Then
                sql.AppendLine(" and (m.Metadb_id='2' OR m.Role_id='TWDAdmin') ")
            End If

            If Old_roleid.Equals("GenServAdmin") Then
                sql.AppendLine(" and (m.Metadb_id='2' OR m.Role_id='GenServAdmin') ")
            End If

            '20120730 add by chihliwang
            If Old_roleid.Equals("SysAdmin") Then
                sql.AppendLine(" and (m.Metadb_id='1' OR m.Metadb_id='2' OR m.Role_id='SysAdmin') ")
            End If

            sql.AppendLine(" order by dseq, f.sub_depart_id ")

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

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Subdepid
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString, params)
        End Function


        Public Function GetDLLDataByODT2(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Title_no As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            sql.AppendLine("        isnull(Personnel_ID,'') + '/' + isnull(id_Card,'') cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Quit_job_flag<>'Y' and ")

            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" dc.Fsc_flag <>'0' and ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" dc.Bank_flag <>'0' and ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" dc.sfb_flag <>'0' and ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" dc.Ib_flag <>'0' and ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" dc.Feb_flag <>'0' and ")
            End If

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" m.Orgcode = @Orgcode AND ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" m.Depart_id in (" & Depart_id & ") AND ")
            End If
            If Not String.IsNullOrEmpty(Title_no) Then
                sql.AppendLine(" m.Title_no in (" & Title_no & " ) AND ")
            End If
            If Not String.IsNullOrEmpty(Role_id) And Role_id = "TWDAdmin" Then
                sql.AppendLine(" m.Metadb_id='2' and ")
            End If
            If Not String.IsNullOrEmpty(Role_id) And Role_id = "GenServAdmin" Then
                sql.AppendLine(" m.Metadb_id='2' and ")
            End If

            sql.AppendLine(" 1=1 order by dseq, m.sub_depart_id ")

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

            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDataNoSelf(ByVal Orgcode As String, _
                                      ByVal DepartID As String, _
                                      ByVal SubDepartID As String, _
                                      ByVal Id_Card As String, _
                                      ByVal Metadb_id As String, _
                                      ByVal Title_no As String) As DataSet

            Dim sql As New StringBuilder

            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            sql.AppendLine("        isnull(dc.detail_code_name,'') + '/' + User_name as show_name, ")
            'sql.AppendLine("        isnull(m.id_Card,'') + ',' + isnull(m.title_no,'') + ',' + isnull(m.Personnel_ID,'') cols, m.*, ")
            sql.AppendLine("        isnull(m.id_Card,'') + ',' + isnull(m.title_no,'') + ',' + m.Personnel_ID as  cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Quit_job_flag<>'Y' and Role_id<>'SysAdmin' and ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" m.Orgcode=@Orgcode and ")
            End If
            If Not String.IsNullOrEmpty(DepartID) Then
                If Title_no <> "1104" Then
                    sql.AppendLine(" m.Depart_id=@DepartID and  ")
                End If
            End If
            If Not String.IsNullOrEmpty(SubDepartID) Then
                If SubDepartID = "0" Then
                    sql.AppendLine(" (m.Sub_Depart_id='0' or m.Sub_Depart_id='' or m.Sub_Depart_id is null) and ")
                Else
                    If Title_no <> "1104" Then
                        sql.AppendLine(" m.Sub_Depart_id=@SubDepartID and ")
                    End If
                End If
            End If
            If Not String.IsNullOrEmpty(Id_Card) Then
                sql.AppendLine(" m.Id_card<>@Id_card and ")
            End If
            If Not String.IsNullOrEmpty(Metadb_id) And Metadb_id = "2" Then
                sql.AppendLine(" m.Metadb_id=@Metadb_id and ")
            End If

            'jessica modi 20131230代理人應該不能選擇下屬
            If Not String.IsNullOrEmpty(Title_no) Then
                If Title_no <> "1104" Then
                    sql.AppendLine(" m.Title_no <=@Title_no and ")
                Else
                    sql.AppendLine(" m.Title_no=@Title_no and ")
                End If
            End If

            sql.AppendLine(" 1=1 order by dseq, m.sub_depart_id ")

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

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@DepartID", SqlDbType.VarChar), _
            New SqlParameter("@SubDepartID", SqlDbType.VarChar), _
            New SqlParameter("@ID_Card", SqlDbType.VarChar), _
            New SqlParameter("@Metadb_id", SqlDbType.VarChar), _
            New SqlParameter("@Title_no", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = DepartID
            params(2).Value = SubDepartID
            params(3).Value = Id_Card
            params(4).Value = Metadb_id
            params(5).Value = Title_no
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetTitle(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_departid As String) As DataSet
            Dim sql As New StringBuilder

            sql.AppendLine(" SELECT distinct M.Title_no, d.detail_code_id As code, d.detail_code_name as descr ")
            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" ,d.Fsc_flag ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" ,d.Bank_flag ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" ,d.sfb_flag ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" ,d.Ib_flag ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" ,d.Feb_flag ")
            Else
                sql.AppendLine(" , d.Seq ")
            End If
            sql.AppendLine(" FROM Member m ")
            sql.AppendLine(" inner join detail_code d on m.title_no=d.detail_code_id and d.master_code_id='1012' ")
            sql.AppendLine(" WHERE ")

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" Orgcode=@Orgcode AND ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) AndAlso Depart_id.IndexOf(",") > 0 Then
                sql.AppendLine(" Depart_id in ( " & Depart_id & " ) AND ")
            ElseIf Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" Depart_id=@Depart_id AND ")
            End If

            If Not String.IsNullOrEmpty(Sub_departid) Then
                sql.AppendLine(" Sub_depart_id=@Sub_depart_id and ")
            End If
            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" d.Fsc_flag <>'0' and ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" d.Bank_flag <>'0' and ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" d.sfb_flag <>'0' and ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine(" d.Ib_flag <>'0' and ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" d.Feb_flag <>'0' and ")
            End If

            sql.AppendLine(" Title_no<>'' ")
            If Orgcode = "367000000D" Then '本會
                sql.AppendLine(" order by d.Fsc_flag ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                sql.AppendLine(" order by d.Bank_flag ")
            ElseIf Orgcode = "367020000D" Then '證期局
                sql.AppendLine(" order by d.sfb_flag ")
            ElseIf Orgcode = "367030000D" Then '保險局
                sql.AppendLine("  order by d.Ib_flag ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                sql.AppendLine(" order by d.Feb_flag ")
            Else
                sql.AppendLine(" order by d.Seq ")
            End If
            Dim s As String = sql.ToString

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Sub_depart_id", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Depart_id
            params(2).Value = Sub_departid
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function UpdateBudgetType(ByVal ID_card As String, ByVal Budget_type As String, ByVal Change_userid As String, ByVal Orgcode As String) As Integer
            Dim DeleteMessage As String = ""
            Dim SqlConn As SqlConnection = New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString.Trim()
            SqlCmd.Connection = SqlConn

            Dim StrSQL As String = ""
            StrSQL = "UPDATE Member SET Budget_type='{0}', Change_userid='{1}', Change_date='{2}' WHERE ID_card='{3}' and Orgcode='{4}'"
            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If
                    StrSQL = String.Format(StrSQL, Budget_type, Change_userid, Now.ToString("yyyy/MM/dd HH:mm:ss"), ID_card, Orgcode)

                    SqlCmd.CommandText = StrSQL
                    SqlCmd.CommandType = CommandType.Text

                    Return SqlCmd.ExecuteNonQuery()
                End Using
            Catch ex As Exception
                Return -1
            Finally
                SqlCmd.Connection.Close()
            End Try

        End Function

        Public Function UpdateQuit_job_flag(ByVal Quit_job_flag As String, ByVal Id_card As String) As Integer
            Dim sql As New StringBuilder

            sql.Append("UPDATE Member SET Quit_job_flag=@Quit_job_flag, Change_userid=@Change_userid, Change_date= GETDATE() ")
            sql.Append("WHERE Id_card=@Id_card")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Quit_job_flag", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = Quit_job_flag
            params(1).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            params(2).Value = Id_card


            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function DeleteIdcard(ByVal Orgcode As String, ByVal Id_card As String) As Integer
            Dim sql As New StringBuilder

            sql.Append("delete from Member ")
            sql.Append("WHERE Orgcode=@Orgcode and  Id_card=@Id_card")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = Id_card

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function UpdateBOSS(ByVal Orgcode As String, ByVal DepartID As String, ByVal Id_Card As String, ByVal Boss_orgcode As String, ByVal Boss_departid As String, ByVal Boss_posid As String, ByVal Boss_idcard As String) As Integer
            Dim sql As New StringBuilder

            sql.Append(" UPDATE Member SET Boss_orgcode=@Boss_orgcode, Boss_departid=@Boss_departid, Boss_posid=@Boss_posid, Boss_idcard=@Boss_idcard ")
            sql.Append(" WHERE Orgcode=@Orgcode and Depart_ID=@DepartID and Id_card in ('" & Id_Card & "') and Quit_job_flag<>'Y' ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@DepartID", SqlDbType.VarChar), _
            New SqlParameter("@Boss_orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Boss_departid", SqlDbType.VarChar), _
            New SqlParameter("@Boss_posid", SqlDbType.VarChar), _
            New SqlParameter("@Boss_idcard", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = DepartID
            'params(2).Value = Id_Card
            params(2).Value = Boss_orgcode
            params(3).Value = Boss_departid
            params(4).Value = Boss_posid
            params(5).Value = Boss_idcard

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function UpdateUserPassword(ByVal ID_card As String, ByVal User_password As String, ByVal Orgcode As String, ByVal DepartID As String, ByVal Change_userid As String) As Integer
            Dim StrSQL As String = ""
            StrSQL = "  UPDATE Member "
            StrSQL &= " SET User_password=@User_password, Change_userid=@Change_userid, Change_date=Getdate(), Login_status='1' "
            StrSQL &= " WHERE ID_card=@ID_card and Orgcode=@Orgcode and Depart_id=@Depart_id "

            Dim ps() As SqlParameter = { _
            New SqlParameter("@ID_card", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@User_password", SqlDbType.VarChar), _
            New SqlParameter("@Change_userid", SqlDbType.VarChar)}
            ps(0).Value = ID_card
            ps(1).Value = Orgcode
            ps(2).Value = DepartID
            ps(3).Value = User_password
            ps(4).Value = Change_userid
            Return Execute(StrSQL, ps)
        End Function

        'Public Function GetDataBySub_depart_id(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_depart_id As String) As DataSet
        '    Dim SQL As New StringBuilder
        '    SQL.Append("SELECT * FROM Member WHERE Orgcode=@Orgcode and Depart_id=@Depart_id and Sub_depart_id=@Sub_depart_id ")
        '    Dim params() As SqlParameter = { _
        '    New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        '    New SqlParameter("@Depart_id", SqlDbType.VarChar), _
        '    New SqlParameter("@Sub_depart_id", SqlDbType.VarChar)}
        '    params(0).Value = Orgcode
        '    params(1).Value = Depart_id
        '    params(2).Value = Sub_depart_id
        '    Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, SQL.ToString(), params)
        'End Function

        'Public Function GetUserSub_depart_id(ByVal Orgcode As String, ByVal User_id As String) As DataSet
        '    Dim SQL As New StringBuilder
        '    SQL.Append("SELECT top 1 * FROM Member WHERE Orgcode=@Orgcode and Id_Card=@User_id ")
        '    Dim params() As SqlParameter = { _
        '    New SqlParameter("@Orgcode", SqlDbType.VarChar), _
        '    New SqlParameter("@User_id", SqlDbType.VarChar)}
        '    params(0).Value = Orgcode
        '    params(1).Value = User_id
        '    Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, SQL.ToString(), params)
        'End Function

        '''' <summary>
        '''' 機關名稱來源
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function GetDDLOrgcodeInfo() As DataSet
        '    Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
        '    Dim StrSQL As String = String.Empty
        '    Dim Ds As New DataSet()

        '    Dim SqlConn As New SqlConnection()
        '    Dim SqlCmd As New SqlCommand()

        '    SqlConn.ConnectionString = Me.ConnectionString
        '    SqlCmd.Connection = SqlConn
        '    StrSQL = "select distinct orgcode, orgcode_name as fullname, orgcode_shortname as shortname  from FSCorg "
        '    If (StrSQL.LastIndexOf("Where") = StrSQL.Length - 5) Then
        '        StrSQL = StrSQL.Substring(0, StrSQL.Length - 5)
        '    End If

        '    StrSQL = StrSQL + " order by orgcode"

        '    SqlCmd.CommandText = StrSQL
        '    SqlDA.SelectCommand = SqlCmd

        '    Try
        '        Using (SqlCmd)
        '            If SqlCmd.Connection.State = ConnectionState.Closed Then
        '                SqlCmd.Connection.Open()
        '            End If

        '            SqlDA.Fill(Ds, "OrgcodeInfoName_Query")
        '        End Using
        '    Catch ex As Exception
        '        Ds = Nothing
        '    Finally
        '        SqlDA.Dispose()
        '        SqlCmd.Connection.Close()
        '    End Try

        '    Return Ds
        'End Function


        '' ########## 多載 ##########
        ' ''' <summary>
        ' ''' 單位名稱來源
        ' ''' </summary>
        ' ''' <param name="Orgcode"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function GetDDLDepartInfo(ByVal Orgcode As String, ByVal loginorgcode As String, ByVal logindepartid As String, ByVal loginstatus As String) As DataSet
        '    Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
        '    Dim StrSQL As String = String.Empty
        '    Dim Ds As New DataSet()

        '    Dim SqlConn As New SqlConnection()
        '    Dim SqlCmd As New SqlCommand()

        '    SqlConn.ConnectionString = Me.ConnectionString
        '    SqlCmd.Connection = SqlConn
        '    StrSQL = "select * from FSCorg "
        '    StrSQL = StrSQL + " Where"


        '    If loginstatus = "IN" Then
        '        ' 單位內
        '        If Orgcode <> "" Then
        '            StrSQL = StrSQL + " Orgcode = '" + loginorgcode + "' and "
        '        End If
        '        If logindepartid <> "" Then
        '            StrSQL = StrSQL + " depart_id = '" + logindepartid + "' "
        '        Else
        '            StrSQL = StrSQL + " depart_id like '%' "
        '        End If
        '    ElseIf loginstatus = "OUT" Then
        '        ' 單位外
        '        If Orgcode = loginorgcode Then
        '            ' 同一機關:其他單位
        '            If logindepartid <> "" Then
        '                If Orgcode <> "" Then
        '                    StrSQL = StrSQL + " Orgcode = '" + loginorgcode + "' and "
        '                End If
        '                If logindepartid <> "" Then
        '                    StrSQL = StrSQL + " depart_id <> '" + logindepartid + "' "
        '                Else
        '                    StrSQL = StrSQL + " depart_id like '%' "
        '                End If
        '            Else
        '                StrSQL = StrSQL + " Orgcode = '" + loginorgcode + "' "
        '            End If
        '        Else
        '            ' 不同機關:全部單位
        '            If Orgcode <> "" Then
        '                If Orgcode <> "" Then
        '                    StrSQL = StrSQL + " Orgcode = '" + Orgcode + "' "
        '                End If
        '            End If
        '        End If
        '    End If

        '    If (StrSQL.LastIndexOf("Where") = StrSQL.Length - 5) Then
        '        StrSQL = StrSQL.Substring(0, StrSQL.Length - 5)
        '    End If

        '    StrSQL = StrSQL + " order by cast(depart_id as  varchar(4))"

        '    SqlCmd.CommandText = StrSQL
        '    SqlDA.SelectCommand = SqlCmd

        '    Try
        '        Using (SqlCmd)
        '            If SqlCmd.Connection.State = ConnectionState.Closed Then
        '                SqlCmd.Connection.Open()
        '            End If

        '            SqlDA.Fill(Ds, "OutpostInfo_Query")
        '        End Using
        '    Catch ex As Exception
        '        Ds = Nothing
        '    Finally
        '        SqlDA.Dispose()
        '        SqlCmd.Connection.Close()
        '    End Try

        '    Return Ds
        'End Function


        '''' <summary>
        '''' 機關名稱來源
        '''' </summary>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function GetDDLOrgcodeInfo(ByVal loginorgcode As String, ByVal loginstatus As String) As DataSet
        '    Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
        '    Dim StrSQL As String = String.Empty
        '    Dim Ds As New DataSet()

        '    Dim SqlConn As New SqlConnection()
        '    Dim SqlCmd As New SqlCommand()

        '    SqlConn.ConnectionString = Me.ConnectionString
        '    SqlCmd.Connection = SqlConn
        '    StrSQL = "select distinct orgcode, orgcode_name as fullname, orgcode_shortname as shortname  from FSCorg Where"

        '    If loginstatus = "IN" Then
        '        If loginorgcode <> "" Then
        '            StrSQL = StrSQL + " orgcode = '" + loginorgcode + "' "
        '        End If
        '    End If

        '    If (StrSQL.LastIndexOf("Where") = StrSQL.Length - 5) Then
        '        StrSQL = StrSQL.Substring(0, StrSQL.Length - 5)
        '    End If

        '    StrSQL = StrSQL + " order by orgcode"

        '    SqlCmd.CommandText = StrSQL
        '    SqlDA.SelectCommand = SqlCmd

        '    Try
        '        Using (SqlCmd)
        '            If SqlCmd.Connection.State = ConnectionState.Closed Then
        '                SqlCmd.Connection.Open()
        '            End If

        '            SqlDA.Fill(Ds, "OrgcodeInfoName_Query")
        '        End Using
        '    Catch ex As Exception
        '        Ds = Nothing
        '    Finally
        '        SqlDA.Dispose()
        '        SqlCmd.Connection.Close()
        '    End Try

        '    Return Ds
        'End Function


        ''' <summary>
        ''' 人員名稱來源:機關、單位
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDDLMemberInfo(ByVal Orgcode As String, ByVal DepartID As String) As DataSet
            Dim sql As String = String.Empty

            sql = "  SELECT distinct ID_card AS IDNo,isnull((select top 1 detail_code_name  from detail_code  where master_code_id='1012'  and title_no=detail_code_id),'') + '/' + User_name as User_name, user_name as Name ,Depart_ID as DepartID, Title_no, Personnel_id "
            sql &= " FROM Member "
            sql &= " Where Role_id<>'SysAdmin' "

            If Orgcode <> "" And Not String.IsNullOrEmpty(Orgcode) Then
                sql &= " and Orgcode=@Orgcode  "
            End If
            If DepartID <> "" And Not String.IsNullOrEmpty(DepartID) Then
                sql &= " and Depart_id=@DepartID "
            End If
            sql &= " order by Depart_ID,title_no "

            Dim params() As SqlParameter = { _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@DepartID", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = DepartID

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql, params)
            End If
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql, params)
        End Function

        ''' <summary>
        ''' 人員名稱來源:機關、單位、登入者ID
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDDLMemberInfo(ByVal Orgcode As String, ByVal DepartID As String, ByVal LoginID As String, ByVal flag As Boolean) As DataSet
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            Dim Ds As New DataSet()

            Dim SqlConn As New SqlConnection()
            Dim SqlCmd As New SqlCommand()

            SqlConn.ConnectionString = Me.ConnectionString
            SqlCmd.Connection = SqlConn

            StrSQL = "SELECT distinct ID AS IDNo ,isnull((select top 1 detail_code_name  from detail_code  where master_code_id='1012'  and title_no=detail_code_id),'') + '/' + User_name as User_name, user_name as Name ,Depart as DepartID FROM Member"
            StrSQL = StrSQL + " Where"
            If Orgcode <> "" Then
                StrSQL = StrSQL + " Orgcode = '{0}'  "
            End If
            If DepartID <> "" Then
                StrSQL = StrSQL + " and Depart = '{1}' "
            End If
            If LoginID <> "" Then
                StrSQL = StrSQL + " and ID = '{2}' "
            End If

            If (StrSQL.LastIndexOf("Where") = StrSQL.Length - 5) Then
                StrSQL = StrSQL.Substring(0, StrSQL.Length - 5)
            End If

            StrSQL = String.Format(StrSQL, Orgcode, DepartID, LoginID)

            StrSQL = StrSQL + " order by Depart,title_no, "
            SqlCmd.CommandText = StrSQL
            SqlDA.SelectCommand = SqlCmd

            Try
                Using (SqlCmd)
                    If SqlCmd.Connection.State = ConnectionState.Closed Then
                        SqlCmd.Connection.Open()
                    End If

                    SqlDA.Fill(Ds, "MemberInfoLoginID_Query")
                End Using
            Catch ex As Exception
                Ds = Nothing
            Finally
                SqlDA.Dispose()
                SqlCmd.Connection.Close()
            End Try

            Return Ds
        End Function

        Public Function GetDataBymcIDdcID(ByVal Orgcode As String, ByVal MasterCodeID As String, ByVal Idno As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" SELECT f.seq as fscseq, f.depart_id as did, d.* ")
            sql.AppendLine(" FROM detail_code d , member m , FSCorg f ")
            sql.AppendLine(" WHERE ")
            sql.AppendLine("    m.orgcode=f.orgcode and d.detail_code_id=m.Title_no and f.depart_id=m.depart_id ")
            sql.AppendLine("    and f.orgcode=@Orgcode  and d.Master_code_id=@Master_code_id AND m.Id_card=@Idno AND d.Delete_flag='N'  ")
            sql.AppendLine(" Order by f.seq,d.Seq, d.detail_code_id ")

            Dim params() As SqlParameter = {New SqlParameter("@Orgcode", SqlDbType.VarChar), New SqlParameter("@Master_code_id", SqlDbType.VarChar), New SqlParameter("@Idno", SqlDbType.VarChar)}
            params(0).Value = Orgcode
            params(1).Value = MasterCodeID
            params(2).Value = Idno
            DBUtil.SetParamsNull(params)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            End If
            Return SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), params)
        End Function

        Public Function GetDLLDataByODSR(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Sub_departid As String, ByVal Role_id As String) As DataSet
            Dim sql As New StringBuilder
            sql.AppendLine(" select ")
            sql.AppendLine("        isnull(f.sub_depart_name ,'') + isnull(dc.detail_code_name,'') + '/' + User_name as full_name, ")
            'sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + isnull(m.Personnel_ID,'')  cols, m.*, ")
            sql.AppendLine("        isnull(m.id_Card,'') + '/' + isnull(m.title_no,'') + '/' + m.Personnel_ID as  cols, m.*, ")
            sql.AppendLine("        (select top 1 seq from fscorg where orgcode=m.orgcode and depart_id=m.depart_id) as dseq ")
            sql.AppendLine(" from member m ")
            sql.AppendLine("        inner join detail_code dc on dc.detail_code_id=m.Title_no and dc.master_code_id='1012' ")
            sql.AppendLine("        left outer join fscorg f on f.orgcode=m.orgcode and f.depart_id=m.depart_id and f.sub_depart_id=m.sub_depart_id ")
            sql.AppendLine(" where m.Quit_job_flag<>'Y' ")

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

            If Not String.IsNullOrEmpty(Orgcode) Then
                sql.AppendLine(" and m.Orgcode = @Orgcode ")
            End If
            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and m.Depart_id= @Depart_id ")
            End If
            If Not String.IsNullOrEmpty(Sub_departid) Then
                sql.AppendLine(" and m.Sub_depart_id= @Sub_departid ")
            End If
            If Not String.IsNullOrEmpty(Role_id) Then
                sql.AppendLine(" and m.Role_id= @Role_id ")
            End If

            If Role_id = "Personnel" Or Role_id = "FeePersonnel" Then
                sql.AppendLine(" and m.Metadb_id='1' ")
            ElseIf Role_id = "TWDAdmin" Or Role_id = "TWDFee" Or Role_id = "GenServAdmin" Then
                sql.AppendLine(" and m.Metadb_id='2' ")
            End If
            sql.AppendLine(" order by dseq, f.sub_depart_id ")

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

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Sub_departid", SqlDbType.VarChar)
            aryParms(2).Value = Sub_departid
            aryParms(3) = New SqlParameter("@Role_id", SqlDbType.VarChar)
            aryParms(3).Value = Role_id
            DBUtil.SetParamsNull(aryParms)

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), aryParms)
            End If
            Return Pemis2009.SQLAdapter.SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql.ToString(), aryParms)
        End Function

        '  Function GetDLLDataByODSTQM(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Role_id As String, ByVal Sub_depart_id As String, ByVal Title_no As String, ByVal Quit_job_Flag As String, ByVal Metadb_id As String) As DataSet
        '     Throw New NotImplementedException
        'End Function

        Public Function getAllMembers(ByVal Metadb_id As String) As DataTable
            Dim sql As New StringBuilder
            sql.Append("select m.*, d.detail_code_name as title_no_name, f.Depart_name, f.Sub_depart_name ")
            sql.AppendLine(" FROM Member m, detail_code d, FSCorg f")
            sql.AppendLine(" where m.title_no=d.detail_code_id and d.master_code_id='1012' and isnull(m.Quit_job_flag,'N')<>'Y' ")
            sql.AppendLine(" and m.Sub_depart_id=f.Sub_depart_id ")
            sql.AppendLine(" and m.Metadb_id=@Metadb_id")
            sql.AppendLine(" order by m.Orgcode, m.Sub_depart_id, d.Seq")

            Dim s As String = sql.ToString

            Dim params() As SqlParameter = { _
            New SqlParameter("@Metadb_id", SqlDbType.VarChar)}
            params(0).Value = Metadb_id
            DBUtil.SetParamsNull(params)

            Dim ds As DataSet
            If Me.Connection IsNot Nothing Then
                ds = SqlAccessHelper.ExecuteDataset(Connection, CommandType.Text, sql.ToString(), params)
            Else
                ds = SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, sql.ToString(), params)
            End If
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function


    End Class

End Namespace