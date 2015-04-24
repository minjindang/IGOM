Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports FSCPLM.Logic
Imports System.Collections.Generic
Imports System.Text
Imports System.Web
Imports System.Configuration
Imports System.Collections
Imports System

Namespace FSC.Logic
    Public Class FSC3103
        Private DAO As FSC3103DAO

        Public Sub New()
            DAO = New FSC3103DAO()
        End Sub

#Region "取得主管資料"
        Public Function Get_Boss(ByVal Orgcode As String, ByVal DepartID As String, ByVal IDCard As String, ByVal Title_no As String, ByVal BOSS_idcard As String) As DataTable
            Dim SQL As String = ""
            SQL &= " SELECT "
            SQL &= " (select top 1 Orgcode_name from FSC_ORG where Orgcode=b.Orgcode and Depart_id=b.Depart_id ) Orgcode_name, "
            SQL &= " (select top 1 Depart_name from FSC_ORG where Orgcode=b.Orgcode and Depart_id=b.Depart_id) Depart_name, "
            SQL &= " (select top 1 CODE_DESC1 from sys_code where code_sys = '023' and  code_type = '012' and code_no = p.title_no) as titleName, "
            SQL &= " (select top 1 User_name from FSC_Personnel where Orgcode=b.Boss_orgcode and Depart_id=b.Boss_departid and ID_card=b.Boss_idcard) BossName, "
            SQL &= " p.*, b.* "

            SQL &= "  FROM FSC_Personnel p "
            SQL &= "    left outer join FSC_Personnel_Boss b on p.id_card = b.id_card"
            SQL &= " where 1=1 "

            If IDCard <> "" Then SQL &= " and p.id_card=@IDCard"
            If Orgcode <> "" Then SQL &= " and b.Boss_orgcode = @Orgcode"
            If DepartID <> "" Then SQL &= " and b.Boss_departid= @DepartID"
            If Title_no <> "" Then SQL &= " and b.Boss_posid = @Title_no "
            If BOSS_idcard <> "" Then SQL &= " and b.Boss_idcard = @BOSS_idcard  "

            Dim aryParms(4) As SqlParameter
            aryParms(0) = New SqlParameter("@Orgcode", SqlDbType.VarChar)
            aryParms(0).Value = Orgcode
            aryParms(1) = New SqlParameter("@DepartID", SqlDbType.VarChar)
            aryParms(1).Value = DepartID
            aryParms(2) = New SqlParameter("@Title_no", SqlDbType.NVarChar)
            aryParms(2).Value = Title_no
            aryParms(3) = New SqlParameter("@IDCard", SqlDbType.VarChar)
            aryParms(3).Value = IDCard
            aryParms(4) = New SqlParameter("@BOSS_idcard", SqlDbType.VarChar)
            aryParms(4).Value = BOSS_idcard
            Return DAO.Query(SQL, aryParms)
        End Function
#End Region
    End Class
End Namespace