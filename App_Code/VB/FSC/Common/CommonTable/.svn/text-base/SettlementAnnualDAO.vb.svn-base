Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Imports FSCPLM.Logic
Imports System.Text
Imports System

Namespace FSC.Logic
    Public Class SettlementAnnualDAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            MyBase.New(conn)
        End Sub

        Public Function InsertData(ByVal sa As SettlementAnnual) As Integer

            Dim Sql As New StringBuilder
            Sql.AppendLine(" INSERT INTO FSC_Settlement_Annual")
            Sql.AppendLine(" 		  (Orgcode, Depart_id, Id_card, Personnel_id, User_name, Title, Annual_Year, Budget_type, Annual_Days, Reserve_Days, Reserve_Days1, ")
            Sql.AppendLine(" 		  Reserve_Days2, Vacation_Days, Pay_Days, Abroad_Days, Over_Days_Kind, Hour_Pay, Settle_Date, History_Mark, create_date, update_date, ")
            Sql.AppendLine(" 		  create_userid, update_userid)")
            Sql.AppendLine(" VALUES     (@PEORG,@PEUNIT,@PEIDNO,@PECARD,@PENAME,@PETIT ,@Annual_Year,@Budget_type,@PEHDAY,@PERDAY,@PERDAY1,")
            Sql.AppendLine(" 			@PERDAY2,@PYTOT ,@PEPAYDAYA,@Abroad_Days,@PERDAYK,@PEOVERHFEE,@Date,'0',getdate(),getdate(),")
            Sql.AppendLine(" 			@username,@username)")

            Dim aryParms(18) As SqlParameter
            aryParms(0) = New SqlParameter("@PEORG", SqlDbType.VarChar)              'Orgcode          
            aryParms(1) = New SqlParameter("@PEUNIT", SqlDbType.VarChar)             'Depart_id        
            aryParms(2) = New SqlParameter("@PECARD", SqlDbType.VarChar)             'Id_card          
            aryParms(3) = New SqlParameter("@PEIDNO", SqlDbType.VarChar)             'Personnel_id     
            aryParms(4) = New SqlParameter("@PENAME", SqlDbType.NVarChar)             'User_name        
            aryParms(5) = New SqlParameter("@PETIT", SqlDbType.VarChar)              'Title = @PETIT   
            aryParms(6) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)        'Annual_Year      
            aryParms(7) = New SqlParameter("@Budget_type", SqlDbType.VarChar)        'Budget_type      
            aryParms(8) = New SqlParameter("@PEHDAY", SqlDbType.Float)             'Annual_Days      
            aryParms(9) = New SqlParameter("@PERDAY", SqlDbType.Float)             'Reserve_Days     
            aryParms(10) = New SqlParameter("@PERDAY1", SqlDbType.Float)           'Reserve_Days1    
            aryParms(11) = New SqlParameter("@PERDAY2", SqlDbType.Float)           'Reserve_Days2    
            aryParms(12) = New SqlParameter("@PYTOT", SqlDbType.Float)             'Vacation_Days    
            aryParms(13) = New SqlParameter("@PEPAYDAYA", SqlDbType.Float)         'Pay_Days         
            aryParms(14) = New SqlParameter("@Abroad_Days", SqlDbType.Float)       'Abroad_Days      
            aryParms(15) = New SqlParameter("@PERDAYK", SqlDbType.VarChar)           'Over_Days_Kind   
            aryParms(16) = New SqlParameter("@PEOVERHFEE", SqlDbType.Float)        'Hour_Pay         
            aryParms(17) = New SqlParameter("@Date", SqlDbType.VarChar)              'Settle_Date      
            aryParms(18) = New SqlParameter("@username", SqlDbType.VarChar)          'create_username  

            aryParms(0).Value = sa.Orgcode
            aryParms(1).Value = sa.Depart_id
            aryParms(2).Value = sa.Personnel_id
            aryParms(3).Value = sa.Id_card
            aryParms(4).Value = sa.User_name
            aryParms(5).Value = sa.Title
            aryParms(6).Value = sa.Annual_Year
            aryParms(7).Value = sa.Budget_type
            aryParms(8).Value = sa.Annual_Days
            aryParms(9).Value = sa.Reserve_Days
            aryParms(10).Value = sa.Reserve_Days1
            aryParms(11).Value = sa.Reserve_Days2
            aryParms(12).Value = sa.Vacation_Days
            aryParms(13).Value = sa.Pay_Days
            aryParms(14).Value = sa.Abroad_Days
            aryParms(15).Value = sa.Over_Days_Kind
            aryParms(16).Value = sa.Hour_Pay
            aryParms(17).Value = sa.Settle_Date
            aryParms(18).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)

            Return Execute(Sql.ToString(), aryParms)
        End Function

        Public Function UpdateData(ByVal sa As SettlementAnnual) As Integer

            Dim Sql As New StringBuilder
            Sql.AppendLine(" Update FSC_Settlement_Annual")
            Sql.AppendLine(" Set ")
            Sql.AppendLine(" 	Annual_Days=@PEHDAY, Reserve_Days=@PERDAY, Reserve_Days1=@PERDAY1, ")
            Sql.AppendLine(" 	Reserve_Days2=@PERDAY2, Vacation_Days=@PYTOT, Pay_Days=@PEPAYDAYA, Abroad_Days=@Abroad_Days, ")
            Sql.AppendLine("    Over_Days_Kind=@PERDAYK, Hour_Pay=@PEOVERHFEE, update_date=getdate(), update_userid=@username, ")
            Sql.AppendLine("    budget_type=@budget_type ")
            Sql.AppendLine(" where Id_card=@PEIDNO and Annual_Year=@Annual_Year")

            Dim aryParms(12) As SqlParameter

            aryParms(0) = New SqlParameter("@PEIDNO", SqlDbType.VarChar)            'Personnel_id     
            aryParms(1) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)       'Annual_Year      
            aryParms(2) = New SqlParameter("@PEHDAY", SqlDbType.Float)              'Annual_Days      
            aryParms(3) = New SqlParameter("@PERDAY", SqlDbType.Float)              'Reserve_Days     
            aryParms(4) = New SqlParameter("@PERDAY1", SqlDbType.Float)             'Reserve_Days1    
            aryParms(5) = New SqlParameter("@PERDAY2", SqlDbType.Float)             'Reserve_Days2    
            aryParms(6) = New SqlParameter("@PYTOT", SqlDbType.Float)               'Vacation_Days    
            aryParms(7) = New SqlParameter("@PEPAYDAYA", SqlDbType.Float)           'Pay_Days         
            aryParms(8) = New SqlParameter("@Abroad_Days", SqlDbType.Float)         'Abroad_Days      
            aryParms(9) = New SqlParameter("@PERDAYK", SqlDbType.VarChar)           'Over_Days_Kind   
            aryParms(10) = New SqlParameter("@PEOVERHFEE", SqlDbType.Float)         'Hour_Pay         
            aryParms(11) = New SqlParameter("@username", SqlDbType.VarChar)         'create_username  
            aryParms(12) = New SqlParameter("@budget_type", SqlDbType.VarChar)      'budget_type  

            aryParms(0).Value = sa.Id_card
            aryParms(1).Value = sa.Annual_Year
            aryParms(2).Value = sa.Annual_Days
            aryParms(3).Value = sa.Reserve_Days
            aryParms(4).Value = sa.Reserve_Days1
            aryParms(5).Value = sa.Reserve_Days2
            aryParms(6).Value = sa.Vacation_Days
            aryParms(7).Value = sa.Pay_Days
            aryParms(8).Value = sa.Abroad_Days
            aryParms(9).Value = sa.Over_Days_Kind
            aryParms(10).Value = sa.Hour_Pay
            aryParms(11).Value = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            aryParms(12).Value = sa.Budget_type

            Return Execute(Sql.ToString(), aryParms)
        End Function

        Public Function GetDataByIdcard(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Annual_year As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" select * from FSC_Settlement_Annual where Id_card=@Id_card and Annual_Year=@Annual_Year ")
            Dim params() As SqlParameter = { _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Annual_year", SqlDbType.VarChar)}
            params(0).Value = Id_card
            params(1).Value = Annual_year

            Return Query(sql.ToString(), params)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Annual_Year As String, ByVal History_mark As String) As DataTable
            Dim sql As New StringBuilder
            sql.AppendLine(" Select distinct s.*, ")
            sql.AppendLine("    d.detail_code_name as Title_name, ")
            sql.AppendLine("    (select top 1 Depart_name from fscorg f where f.Orgcode=s.Orgcode and f.Depart_id=s.Depart_id) as Depart_name, ")
            sql.AppendLine("    (select top 1 seq from fscorg f where f.Orgcode=s.Orgcode and f.Depart_id=s.Depart_id and f.sub_depart_id=m.sub_depart_id) as seq, ")
            sql.AppendLine("     m.User_name, d.fsc_flag , ")
            sql.AppendLine("     m.Personnel_id ")
            sql.AppendLine(" from FSC_Settlement_Annual s ")
            sql.AppendLine("    left outer join detail_code d on s.Title=d.detail_code_id and d.Master_code_id='1012' ")
            sql.AppendLine("    left outer join member m on s.Title=m.title_no and m.Id_card=s.Id_card and s.Orgcode=m.Orgcode ")
            sql.AppendLine(" where ")
            sql.AppendLine("    s.Orgcode = @Orgcode  ")
            sql.AppendLine("    and s.Depart_id = @Depart_id ")
            sql.AppendLine("    and s.Annual_Year = @Annual_Year  ") '系統年 

            If Not String.IsNullOrEmpty(History_mark) Then
                sql.AppendLine(" and History_mark=@History_mark ")
            End If

            sql.AppendLine(" order by s.Orgcode,s.Depart_id,seq,d.Title_name")

            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)
            aryParms(2).Value = Annual_Year
            aryParms(3) = New SqlParameter("@History_mark", SqlDbType.VarChar)
            aryParms(3).Value = History_mark

            Return Query(sql.ToString, aryParms)
        End Function

        Public Function UpdateHistoryMark(ByVal History_mark As String, ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Annual_year As String) As Integer
            Dim sql As New StringBuilder
            sql.AppendLine(" Update FSC_Settlement_Annual set History_mark=@History_mark, Settle_date=@Settle_date ")
            sql.AppendLine(" where Orgcode=@Orgcode and Id_card=@Id_card and Annual_year=@Annual_year ")

            If Not String.IsNullOrEmpty(Depart_id) Then
                sql.AppendLine(" and Depart_id=@Depart_id ")
            End If

            Dim params() As SqlParameter = { _
            New SqlParameter("@History_mark", SqlDbType.VarChar), _
            New SqlParameter("@Settle_date", SqlDbType.VarChar), _
            New SqlParameter("@Orgcode", SqlDbType.VarChar), _
            New SqlParameter("@Depart_id", SqlDbType.VarChar), _
            New SqlParameter("@Id_card", SqlDbType.VarChar), _
            New SqlParameter("@Annual_year", SqlDbType.VarChar)}
            params(0).Value = History_mark
            params(1).Value = IIf(History_mark = "1", DateTimeInfo.GetRocDate(Now), DBNull.Value)
            params(2).Value = Orgcode
            params(3).Value = Depart_id
            params(4).Value = Id_card
            params(5).Value = Annual_year
            DBUtil.SetParamsNull(params)
            Return Execute(sql.ToString(), params)
        End Function


        Public Function GetBeforeData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Annual_Year As String) As DataTable
            Dim strSQL As String = " Select * from FSC_Settlement_Annual "
            strSQL &= " where Orgcode = @Orgcode " '機關代碼  
            strSQL &= " and Depart_id = @Depart_id  " '單位代碼  
            strSQL &= " and Id_card = @Id_card  " '身分證號 
            strSQL &= " and Annual_Year < @Annual_Year  " '系統年 
            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(2).Value = Id_card
            aryParms(3) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)
            aryParms(3).Value = Annual_Year
            Return Query(strSQL, aryParms)
        End Function


        Public Function GetYearData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Id_card As String, ByVal Annual_Year As String) As DataTable
            Dim strSQL As String = " Select * from FSC_Settlement_Annual "
            strSQL &= " where Orgcode = @Orgcode " '機關代碼  
            strSQL &= " and Depart_id = @Depart_id  " '單位代碼  
            strSQL &= " and Id_card = @Id_card  " '身分證號 
            strSQL &= " and Annual_Year = @Annual_Year  " '系統年 
            Dim aryParms(3) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Depart_id", SqlDbType.VarChar)
            aryParms(1).Value = Depart_id
            aryParms(2) = New SqlParameter("@Id_card", SqlDbType.VarChar)
            aryParms(2).Value = Id_card
            aryParms(3) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)
            aryParms(3).Value = Annual_Year
            Return Query(strSQL, aryParms)
        End Function


        Public Function GetFSC3208Data(ByVal Orgcode As String, ByVal Annual_Year As String, ByVal Depart_id As String, ByVal Budget_type As String) As DataTable
            Dim SQL As New StringBuilder
            SQL.AppendLine(" SELECT S.Depart_id, S.Title, S.User_name, S.Id_card, ")
            SQL.AppendLine("        dc.detail_code_name as Title_name, ")
            SQL.AppendLine("        isnull(S.Personnel_id,0) Personnel_id, ")
            SQL.AppendLine("        isnull(S.Annual_Days,0) Annual_Days, ")
            SQL.AppendLine("        isnull(S.Reserve_Days1,0) Reserve_Days1, ")
            SQL.AppendLine("        isnull(S.Reserve_Days2,0) Reserve_Days2, ")
            SQL.AppendLine(" 		isnull( S.Vacation_Days,0) Vacation_Days, ")
            SQL.AppendLine("        isnull( S.Reserve_Days,0) Reserve_Days, ")
            SQL.AppendLine("        isnull(S.Pay_Days,0) Pay_Days, ")
            SQL.AppendLine("        isnull(S.Hour_Pay,0) Hour_Pay, ")
            SQL.AppendLine("        (case  S.Budget_type when '1' then '公務' when '2' then '基金' else '' end) Budget_type, ")
            SQL.AppendLine("        S.Abroad_Days, ")
            SQL.AppendLine("        (select top 1 Orgcode_name from fscorg where orgcode= S.orgcode) as Orgcode_name, ")                            '機關名稱
            SQL.AppendLine("        (select top 1 Depart_name from fscorg where orgcode= S.orgcode and Depart_id=S.Depart_id) as Depart_name, ")    '單位名稱
            SQL.AppendLine("        (select top 1 seq from fscorg where orgcode= S.orgcode and depart_id=S.depart_id ) as seq ")                    '單位排序
            SQL.AppendLine(" FROM    FSC_Settlement_Annual AS S ")
            SQL.AppendLine("        INNER JOIN Detail_code dc ON S.Title = dc.detail_code_id and dc.master_code_id='1012' ")
            SQL.AppendLine(" where  1=1 ")

            If Orgcode <> "" Then SQL.AppendLine(" and S.Orgcode = @Orgcode ")
            If Annual_Year <> "" Then SQL.AppendLine(" and S.Annual_Year = @Annual_Year ")
            If Depart_id <> "" Then SQL.AppendLine(" and S.Depart_id in (" & Depart_id & ") ")
            If Budget_type <> "" Then SQL.AppendLine(" and S.Budget_type = @Budget_type ")

            SQL.AppendLine(" order by seq , ")

            If Orgcode = "367000000D" Then '本會
                SQL.AppendLine(" dc.Fsc_flag ")
            ElseIf Orgcode = "367010000D" Then '銀行局
                SQL.AppendLine(" dc.Bank_flag ")
            ElseIf Orgcode = "367020000D" Then '證期局
                SQL.AppendLine(" dc.sfb_flag ")
            ElseIf Orgcode = "367030000D" Then '保險局
                SQL.AppendLine(" dc.Ib_flag ")
            ElseIf Orgcode = "367040000D" Then '檢查局
                SQL.AppendLine(" dc.Feb_flag ")
            End If

            Dim aryParms(2) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@Annual_Year", SqlDbType.VarChar)
            aryParms(1).Value = Annual_Year
            aryParms(2) = New SqlParameter("@Budget_type", SqlDbType.VarChar)
            aryParms(2).Value = Budget_type

            Return Query(SQL.ToString(), aryParms)

        End Function

        Public Function getDataByOrgFid(ByVal Orgcode As String, ByVal Flow_id As String) As DataTable
            Dim sql As StringBuilder = New StringBuilder
            sql.AppendLine(" select * from fsc_settlement_annual ")
            sql.AppendLine(" where Orgcode=@Orgcode and ( @Flow_id=Flow_id or Flow_id in (select Flow_id from SYS_Flow where Merge_flowid=@Flow_id))")

            Dim sp() As SqlParameter = { _
                New SqlParameter("@Orgcode", Orgcode), _
                New SqlParameter("@Flow_id", Flow_id)}

            Return Query(sql.ToString(), sp)
        End Function
    End Class
End Namespace