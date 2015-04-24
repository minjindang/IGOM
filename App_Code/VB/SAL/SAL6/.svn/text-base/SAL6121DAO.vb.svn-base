Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace SALARY.Logic
    Public Class SAL6121DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New()
        End Sub
        Public Function SAL6121SelectData(ByVal Apply_yy As String) As DataTable '勞/健、公/健保查詢

            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT "
            StrSQL &= "Depart_name "
            StrSQL &= ",Sub_depart_name "
            StrSQL &= ",Member.User_name "
            StrSQL &= ",PROOF_rpt.User_id "
            StrSQL &= ",PAYOD_CODE "
            StrSQL &= ",Apply_yy "
            StrSQL &= ",PAYOD_AMT "
            StrSQL &= ",'0' as PAYOD_AMT1 "
            StrSQL &= ",family_amt "
            StrSQL &= ",Id_card "
            StrSQL &= "FROM SAL_PROOF_rpt "
            StrSQL &= "inner Join Flow on Flow.Flow_id=PROOF_rpt.Flow_id "
            StrSQL &= "inner Join Member on Member.Personnel_id=SAL_PROOF_rpt.User_id "
            StrSQL &= "inner Join SAL_SAPAYOD on SAL_PROOF_rpt.User_id=SAL_SAPAYOD.PAYOD_SEQNO and SAL_PROOF_rpt.Apply_yy=CAST(substring(SAL_SAPAYOD.PAYOD_YM,1,4)-1911 as int) "
            StrSQL &= "inner Join SAL_SAFAMILY on SAL_PROOF_rpt.User_id=SAL_SAFAMILY.family_seqno "
            StrSQL &= "inner Join FSCorg on Member.Sub_depart_id=FSCorg.Sub_depart_id  "
            StrSQL &= "where PAYOD_CODE_SYS='003' "
            StrSQL &= "and PAYOD_CODE_KIND='P' "
            StrSQL &= "and PAYOD_CODE_TYPE='002' "
            StrSQL &= "and PAYOD_CODE_NO='003' "
            StrSQL &= "and (PAYOD_CODE='001') " '公保
            StrSQL &= "and PAYOD_KIND='001' "
            StrSQL &= "and Apply_yy=@Apply_yy "
            StrSQL &= "and Last_pass='1' " '申請流程跑完
            StrSQL &= "union " '合併公保、勞保查詢結果
            StrSQL &= "SELECT "
            StrSQL &= "Depart_name "
            StrSQL &= ",Sub_depart_name "
            StrSQL &= ",Member.User_name "
            StrSQL &= ",PROOF_rpt.User_id "
            StrSQL &= ",PAYOD_CODE "
            StrSQL &= ",Apply_yy "
            StrSQL &= ",'0' as PAYOD_AMT1 "
            StrSQL &= ",PAYOD_AMT "
            StrSQL &= ",family_amt "
            StrSQL &= ",Id_card "
            StrSQL &= "FROM SAL_PROOF_rpt "
            StrSQL &= "inner Join Flow on Flow.Flow_id=PROOF_rpt.Flow_id "
            StrSQL &= "inner Join Member on Member.Personnel_id=SAL_PROOF_rpt.User_id "
            StrSQL &= "inner Join SAL_SAPAYOD on SAL_PROOF_rpt.User_id=SAL_SAPAYOD.PAYOD_SEQNO and SAL_PROOF_rpt.Apply_yy=CAST(substring(SAL_SAPAYOD.PAYOD_YM,1,4)-1911 as int) "
            StrSQL &= "inner Join SAL_SAFAMILY on SAL_PROOF_rpt.User_id=SAL_SAFAMILY.family_seqno "
            StrSQL &= "inner Join FSCorg on Member.Sub_depart_id=FSCorg.Sub_depart_id  "
            StrSQL &= "where PAYOD_CODE_SYS='003' "
            StrSQL &= "and PAYOD_CODE_KIND='P' "
            StrSQL &= "and PAYOD_CODE_TYPE='002' "
            StrSQL &= "and PAYOD_CODE_NO='003' "
            StrSQL &= "and (PAYOD_CODE='002') " '勞保
            StrSQL &= "and PAYOD_KIND='001' "
            StrSQL &= "and Apply_yy=@Apply_yy "
            StrSQL &= "and Last_pass='1' " '申請流程跑完
            Dim ps() As SqlParameter = {New SqlParameter("@Apply_yy", Apply_yy)}
            Return Query(StrSQL, ps)
        End Function
        Public Function SAL6121PrintData(ByVal Apply_yy As String, _
                                         ByVal SpecialInquiry As String, _
                                         ByVal Type As String, _
                                         ByVal PAYOD_CODE As String) As DataTable '列印用
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT "
            StrSQL &= "Depart_name "
            StrSQL &= ",Sub_depart_name "
            StrSQL &= ",Member.User_name "
            StrSQL &= ",PROOF_rpt.User_id "
            StrSQL &= ",PAYOD_CODE "
            StrSQL &= ",Apply_yy "
            StrSQL &= ",Cast(PAYOD_AMT as numeric) as PAYOD_AMT "
            StrSQL &= ",family_amt "
            StrSQL &= ",Id_card "
            StrSQL &= "FROM SAL_PROOF_rpt "
            StrSQL &= "inner Join Flow on Flow.Flow_id=PROOF_rpt.Flow_id "
            StrSQL &= "inner Join Member on Member.Personnel_id=SAL_PROOF_rpt.User_id "
            StrSQL &= "inner Join SAL_SAPAYOD on SAL_PROOF_rpt.User_id=SAL_SAPAYOD.PAYOD_SEQNO and SAL_PROOF_rpt.Apply_yy=CAST(substring(SAL_SAPAYOD.PAYOD_YM,1,4)-1911 as int) "
            StrSQL &= "inner Join SAL_SAFAMILY on SAL_PROOF_rpt.User_id=SAL_SAFAMILY.family_seqno "
            StrSQL &= "inner Join FSCorg on Member.Sub_depart_id=FSCorg.Sub_depart_id  "
            StrSQL &= "where PAYOD_CODE_SYS='003' "
            StrSQL &= "and PAYOD_CODE_KIND='P' "
            StrSQL &= "and PAYOD_CODE_TYPE='002' "
            StrSQL &= "and PAYOD_CODE_NO='003' "
            StrSQL &= "and PAYOD_KIND='001' "
            StrSQL &= "and Apply_yy=@Apply_yy " '年度
            If Type = "1" Then '依年度列印
                StrSQL &= "and PAYOD_CODE=@PAYOD_CODE " '公、勞保
                StrSQL &= "and Last_pass='1' " '申請流程跑完
            ElseIf Type = "2" Then '依資料列列印
                StrSQL &= "and User_id=@SpecialInquiry " '以資料列的User_id查詢當年度公、勞健保資料
                StrSQL &= "and Last_pass='1' " '申請流程跑完
            ElseIf Type = "3" Then '依指定人員列印
                StrSQL &= "and Id_card=@SpecialInquiry " '以人員身分證號查詢當年度公、勞健保資料
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@Apply_yy", Apply_yy), _
                                        New SqlParameter("@SpecialInquiry", SpecialInquiry), _
                                        New SqlParameter("@PAYOD_CODE", PAYOD_CODE)}
            Return Query(StrSQL, ps)
        End Function
    End Class
End Namespace