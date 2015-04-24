Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace MAT.Logic
    Public Class MAT2109DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        Public Function MAT2109Select(ByVal Material_detS As String, _
                                          ByVal Material_detE As String, _
                                          ByVal ReceiveDayS As String, _
                                          ByVal ReceiveDayE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""


            'StrSQL &= "select Out_date, Flow_id, Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, OrgCode, P4 from ( "
            'StrSQL &= "select Out_date, test11.Flow_id, test11.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, test11.OrgCode, test22.P4 from ("
            'StrSQL &= "select Out_date, test.Flow_id, test.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, test.OrgCode, '0' as P4 from ("
            'StrSQL &= "select Out_date, MAT_ApplyMaterial_det.Flow_id, Material_id, Apply_cnt, Out_cnt, MAT_ApplyMaterial_main.Unit_code, MAT_ApplyMaterial_main.Form_type, MAT_ApplyMaterial_main.USER_ID, MAT_ApplyMaterial_det.OrgCode, MAT_ApplyMaterial_main.Apply_date from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= ") as test "
            'StrSQL &= "inner join Flow on (test.Flow_id=Flow.Flow_id and Flow.Orgcode=test.OrgCode) "
            'StrSQL &= "inner join Flow_detail on Flow_detail.Flow_id=test.Flow_id "
            'StrSQL &= "inner join MAT_Material_main on MAT_Material_main.Material_id=test.Material_id "
            'StrSQL &= "inner join Member on Member.Personnel_id=test.User_id "
            'StrSQL &= "inner join SACODE on SACODE.CODE_NO=test.Form_type "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            'If Not String.IsNullOrEmpty(ReceiveDayS) Then
            '    StrSQL &= "and Out_date >= @ReceiveDayS "
            'End If
            'If Not String.IsNullOrEmpty(ReceiveDayE) Then
            '    StrSQL &= "and Out_date <= @ReceiveDayE "
            'End If
            'If Not String.IsNullOrEmpty(Material_detS) Then
            '    StrSQL &= "and test.Flow_id >= @Material_detS "
            'End If
            'If Not String.IsNullOrEmpty(Material_detE) Then
            '    StrSQL &= "and test.Flow_id <= @Material_detE "
            'End If
            'StrSQL &= ") as test11 "
            'StrSQL &= "inner join ("
            'StrSQL &= "select MAT_ApplyMaterial_det.Flow_id, Form_type, ROW_NUMBER() OVER(ORDER BY Form_type) AS P4 from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= "inner join Flow on (MAT_ApplyMaterial_det.Flow_id=Flow.Flow_id and Flow.Orgcode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= "inner join Flow_detail on (Flow_detail.Flow_id=MAT_ApplyMaterial_det.Flow_id and Flow_detail.Orgcode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= "inner join SACODE on SACODE.CODE_NO=Form_type "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            'If Not String.IsNullOrEmpty(ReceiveDayS) Then
            '    StrSQL &= "and Out_date >= @ReceiveDayS "
            'End If
            'If Not String.IsNullOrEmpty(ReceiveDayE) Then
            '    StrSQL &= "and Out_date <= @ReceiveDayE "
            'End If
            'If Not String.IsNullOrEmpty(Material_detS) Then
            '    StrSQL &= "and MAT_ApplyMaterial_det.Flow_id >= @Material_detS "
            'End If
            'If Not String.IsNullOrEmpty(Material_detE) Then
            '    StrSQL &= "and MAT_ApplyMaterial_det.Flow_id <= @Material_detE "
            'End If
            'StrSQL &= "group by MAT_ApplyMaterial_det.Flow_id, Form_type "
            'StrSQL &= ") as test22 on test11.Flow_id=test22.Flow_id "
            'StrSQL &= ") as test33 "




            'StrSQL &= "select Out_date, Flow_id, Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, OrgCode, P4 from ( "
            'StrSQL &= "select Out_date, test11.Flow_id, test11.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, test11.OrgCode, test22.P4 from ("
            'StrSQL &= "select Out_date, test.Flow_id, test.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, test.OrgCode, '0' as P4 from ("
            'StrSQL &= "select Out_date, MAT_ApplyMaterial_det.Flow_id, Material_id, Apply_cnt, Out_cnt, MAT_ApplyMaterial_main.Unit_code, MAT_ApplyMaterial_main.Form_type, MAT_ApplyMaterial_main.USER_ID, MAT_ApplyMaterial_det.OrgCode, MAT_ApplyMaterial_main.Apply_date from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= ") as test "
            'StrSQL &= "inner join Flow on (test.Flow_id=Flow.Flow_id and Flow.Orgcode=test.OrgCode) "
            'StrSQL &= "inner join Flow_detail on Flow_detail.Flow_id=test.Flow_id "
            'StrSQL &= "inner join MAT_Material_main on MAT_Material_main.Material_id=test.Material_id "
            'StrSQL &= "inner join Member on Member.Personnel_id=test.User_id "
            'StrSQL &= "inner join SACODE on SACODE.CODE_NO=test.Form_type "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            'If Not String.IsNullOrEmpty(ReceiveDayS) Then
            '    StrSQL &= "and Out_date >= @ReceiveDayS "
            'End If
            'If Not String.IsNullOrEmpty(ReceiveDayE) Then
            '    StrSQL &= "and Out_date <= @ReceiveDayE "
            'End If
            'If Not String.IsNullOrEmpty(Material_detS) Then
            '    StrSQL &= "and test.Flow_id >= @Material_detS "
            'End If
            'If Not String.IsNullOrEmpty(Material_detE) Then
            '    StrSQL &= "and test.Flow_id <= @Material_detE "
            'End If
            'StrSQL &= ") as test11 "
            'StrSQL &= "inner join ("
            'StrSQL &= "select MAT_ApplyMaterial_det.Flow_id, Form_type, ROW_NUMBER() OVER(ORDER BY Form_type) AS P4 from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= "inner join Flow on (MAT_ApplyMaterial_det.Flow_id=Flow.Flow_id and Flow.Orgcode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= "inner join Flow_detail on (Flow_detail.Flow_id=MAT_ApplyMaterial_det.Flow_id and Flow_detail.Orgcode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= "inner join SACODE on SACODE.CODE_NO=Form_type "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            'If Not String.IsNullOrEmpty(ReceiveDayS) Then
            '    StrSQL &= "and Out_date >= @ReceiveDayS "
            'End If
            'If Not String.IsNullOrEmpty(ReceiveDayE) Then
            '    StrSQL &= "and Out_date <= @ReceiveDayE "
            'End If
            'If Not String.IsNullOrEmpty(Material_detS) Then
            '    StrSQL &= "and MAT_ApplyMaterial_det.Flow_id >= @Material_detS "
            'End If
            'If Not String.IsNullOrEmpty(Material_detE) Then
            '    StrSQL &= "and MAT_ApplyMaterial_det.Flow_id <= @Material_detE "
            'End If
            'StrSQL &= "group by MAT_ApplyMaterial_det.Flow_id, Form_type "
            'StrSQL &= ") as test22 on test11.Flow_id=test22.Flow_id "
            'StrSQL &= ") as test33 "

            StrSQL &= "select Out_date, Flow_id, Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flowid, OrgCode, P3, Form_type from ( "
            StrSQL &= "select Out_date, test11.Flow_id, test11.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flowid, test11.OrgCode, test22.P3, Form_type from ( "
            StrSQL &= "select Out_date, test.Flow_id, test.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flowid, test.OrgCode, '0' as P3 from ( "
            StrSQL &= "select Out_date, MAT_ApplyMaterial_det.Flow_id, Material_id, Apply_cnt, Out_cnt, MAT_ApplyMaterial_main.Unit_code, MAT_ApplyMaterial_main.Form_type, MAT_ApplyMaterial_main.USER_ID, MAT_ApplyMaterial_det.OrgCode, MAT_ApplyMaterial_main.Apply_date from MAT_ApplyMaterial_det "
            StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            StrSQL &= ") as test "
            StrSQL &= "inner join SYS_Flow on (test.Flow_id=SYS_Flow.Flow_id and SYS_Flow.Orgcode=test.OrgCode) "
            StrSQL &= "inner join SYS_Flow_detail on SYS_Flow_detail.Flow_id=test.Flow_id "
            StrSQL &= "inner join MAT_Material_main on MAT_Material_main.Material_id=test.Material_id "
            StrSQL &= "inner join FSC_Personnel on FSC_Personnel.id_card=test.User_id "
            StrSQL &= "inner join SYS_CODE on SYS_CODE.CODE_NO=test.Form_type "
            StrSQL &= "where SYS_Flow.Last_pass='1' "
            StrSQL &= "and SYS_Flow_detail.Last_pass='1' "
            StrSQL &= "and SYS_Flow_detail.Agree_flag='1' "
            StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            If Not String.IsNullOrEmpty(ReceiveDayS) Then
                StrSQL &= "and Out_date >= @ReceiveDayS "
            End If
            If Not String.IsNullOrEmpty(ReceiveDayE) Then
                StrSQL &= "and Out_date <= @ReceiveDayE "
            End If
            If Not String.IsNullOrEmpty(Material_detS) Then
                StrSQL &= "and test.Flow_id >= @Material_detS "
            End If
            If Not String.IsNullOrEmpty(Material_detE) Then
                StrSQL &= "and test.Flow_id <= @Material_detE "
            End If
            StrSQL &= ") as test11 "
            StrSQL &= "inner join ( "
            StrSQL &= "select MAT_ApplyMaterial_det.Flow_id, Form_type, ROW_NUMBER() OVER(ORDER BY Form_type) AS P3 from MAT_ApplyMaterial_det "
            StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            StrSQL &= "inner join SYS_Flow on (MAT_ApplyMaterial_det.Flow_id=SYS_Flow.Flow_id and SYS_Flow.Orgcode=MAT_ApplyMaterial_det.OrgCode) "
            StrSQL &= "inner join SYS_Flow_detail on (SYS_Flow_detail.Flow_id=MAT_ApplyMaterial_det.Flow_id and SYS_Flow_detail.Orgcode=MAT_ApplyMaterial_det.OrgCode) "
            StrSQL &= "inner join SYS_CODE on SYS_CODE.CODE_NO=Form_type "
            StrSQL &= "where SYS_Flow.Last_pass='1' "
            StrSQL &= "and SYS_Flow_detail.Last_pass='1' "
            StrSQL &= "and SYS_Flow_detail.Agree_flag='1' "
            StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            If Not String.IsNullOrEmpty(ReceiveDayS) Then
                StrSQL &= "and Out_date >= @ReceiveDayS "
            End If
            If Not String.IsNullOrEmpty(ReceiveDayE) Then
                StrSQL &= "and Out_date <= @ReceiveDayE "
            End If
            If Not String.IsNullOrEmpty(Material_detS) Then
                StrSQL &= "and MAT_ApplyMaterial_det.Flow_id >= @Material_detS "
            End If
            If Not String.IsNullOrEmpty(Material_detE) Then
                StrSQL &= "and MAT_ApplyMaterial_det.Flow_id <= @Material_detE "
            End If
            StrSQL &= "group by MAT_ApplyMaterial_det.Flow_id, Form_type "
            StrSQL &= ") as test22 on test11.Flow_id=test22.Flow_id "
            StrSQL &= ") as test33 "

            StrSQL &= "order by Form_type "



            'StrSQL &= "select Out_date, test.Flow_id, test.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, test.OrgCode, '0' as P4 from ("
            'StrSQL &= "select Out_date, MAT_ApplyMaterial_det.Flow_id, Material_id, Apply_cnt, Out_cnt, MAT_ApplyMaterial_main.Unit_code, MAT_ApplyMaterial_main.Form_type, MAT_ApplyMaterial_main.USER_ID, MAT_ApplyMaterial_det.OrgCode, MAT_ApplyMaterial_main.Apply_date from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on (MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id and MAT_ApplyMaterial_main.OrgCode=MAT_ApplyMaterial_det.OrgCode) "
            'StrSQL &= ") as test "
            'StrSQL &= "inner join Flow on (test.Flow_id=Flow.Flow_id and Flow.Orgcode=test.OrgCode) "
            'StrSQL &= "inner join Flow_detail on Flow_detail.Flow_id=test.Flow_id "
            'StrSQL &= "inner join MAT_Material_main on MAT_Material_main.Material_id=test.Material_id "
            'StrSQL &= "inner join Member on Member.Personnel_id=test.User_id "
            'StrSQL &= "inner join SACODE on SACODE.CODE_NO=test.Form_type "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            'StrSQL &= "order by Form_type "



            'StrSQL &= "select Out_date, test.Flow_id, test.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, CODE_DESC1, User_name, Apply_date, Merge_Flow_id, '0' as P4 from ("
            'StrSQL &= "select Out_date, MAT_ApplyMaterial_det.Flow_id, Material_id, Apply_cnt, Out_cnt, MAT_ApplyMaterial_main.Unit_code, MAT_ApplyMaterial_main.Form_type, MAT_ApplyMaterial_main.USER_ID, MAT_ApplyMaterial_main.Apply_date from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id "
            'StrSQL &= ") as test "
            'StrSQL &= "inner join Flow on test.Flow_id=Flow.Flow_id "
            'StrSQL &= "inner join Flow_detail on Flow_detail.Flow_id=test.Flow_id "
            'StrSQL &= "inner join MAT_Material_main on MAT_Material_main.Material_id=test.Material_id "
            'StrSQL &= "inner join Member on Member.Personnel_id=test.User_id "
            'StrSQL &= "inner join SACODE on SACODE.CODE_NO=test.Form_type "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "and (CODE_SYS='014' and CODE_TYPE='001') "
            'StrSQL &= "order by Form_type "


            'StrSQL &= "select Out_date, test.Flow_id, test.Material_id, Material_name, Apply_cnt, Out_cnt, Unit_code, Form_type, USER_ID, Apply_date, Merge_Flow_id, '0' as P4 from ( "
            'StrSQL &= "select Out_date, MAT_ApplyMaterial_det.Flow_id, Material_id, Apply_cnt, Out_cnt, MAT_ApplyMaterial_main.Unit_code, MAT_ApplyMaterial_main.Form_type, MAT_ApplyMaterial_main.USER_ID, MAT_ApplyMaterial_main.Apply_date from MAT_ApplyMaterial_det "
            'StrSQL &= "inner join MAT_ApplyMaterial_main on MAT_ApplyMaterial_main.Flow_id=MAT_ApplyMaterial_det.Flow_id "
            'If Not String.IsNullOrEmpty(ReceiveDayS) Then
            '    StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),ElecMaintain_main.ApplyTime,20) - 1911)+ "
            '    StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),ElecMaintain_main.ApplyTime,20),6,2) + "
            '    StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            'End If
            'If Not String.IsNullOrEmpty(ReceiveDayE) Then
            '    StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),ElecMaintain_main.ApplyTime,20) - 1911)+ "
            '    StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),ElecMaintain_main.ApplyTime,20),6,2) + "
            '    StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            'End If
            'StrSQL &= ") as test "
            'StrSQL &= "inner join Flow on test.Flow_id=Flow.Flow_id "
            'StrSQL &= "inner join Flow_detail on Flow_detail.Flow_id=test.Flow_id "
            'StrSQL &= "inner join MAT_Material_main on MAT_Material_main.Material_id=test.Material_id "
            'StrSQL &= "where Flow.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Last_pass='1' "
            'StrSQL &= "and Flow_detail.Agree_flag='1' "
            'StrSQL &= "order by Form_type "

            Dim ps() As SqlParameter = {New SqlParameter("@Material_detS", Material_detS), _
                                        New SqlParameter("@Material_detE", Material_detE), _
                                        New SqlParameter("@ReceiveDayS", ReceiveDayS), _
                                        New SqlParameter("@ReceiveDayE", ReceiveDayE)}
            Return Query(StrSQL, ps)
        End Function
    End Class
End Namespace