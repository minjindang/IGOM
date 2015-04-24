Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Namespace FSCPLM.Logic
    Public Class MAI2201_01DAO
        Inherits BaseDAO

        Public Sub New()
            MyBase.New(ConnectDB.GetDBString())
        End Sub
        'MAI_ElecMaintain_main Join MAI_ElecMaintain_det 報修類別統計
        Public Function MAI3202_01_01(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "Select MtClass_type,COUNT(MtClass_type) as Countnum from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "where 1 = 1 "
            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            StrSQL &= "group by MtClass_type "
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        Public Function MAI3202_01_02FSCorg(ByVal Orgcode As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = "select Depart_id,Depart_name from FSC_org "
            StrSQL &= "where Orgcode=@Orgcode"
            Dim ps() As SqlParameter = {New SqlParameter("@Orgcode", Orgcode)}
            Return Query(StrSQL, ps)
        End Function
        '依單位報修次數統計
        Public Function MAI3202_01_02Maintain_mainJoinMAI_ElecMaintain_det(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            Select Case Type
                Case "1"
                    StrSQL &= "select MAI_ElecMaintain_main.Unit_code, COUNT(Unit_code) as Total from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
                    StrSQL &= "where 1 = 1 "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MAI_ElecMaintain_main.Unit_code"
                Case "2"
                    StrSQL &= "select MAI_ElecMaintain_main.Unit_code, CaseClose_type from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
                    StrSQL &= "where 1 = 1 "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
            End Select
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '依單位報滿意度統計
        Public Function MAI3202_01_02Satisfaction(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            Select Case Type
                Case "0"
                    StrSQL &= "select Unit_code from MAI_ElecMaintain_det "
                    StrSQL &= "inner join MAI_ElecMaintain_main on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by Unit_code "
                Case "1"
                    StrSQL &= "select Unit_code, Satisfaction_type from MAI_ElecMaintain_det "
                    StrSQL &= "inner join MAI_ElecMaintain_main on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
            End Select
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '個人報修統計
        Public Function MAI3202_01_02Personal(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            Select Case Type
                Case "0"
                    StrSQL &= "select MAI_ElecMaintain_main.User_name,MAI_ElecMaintain_main.User_id, COUNT(User_id) as Total from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
                    StrSQL &= "where 1 = 1 "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MAI_ElecMaintain_main.User_name, MAI_ElecMaintain_main.User_id "
                Case "1"
                    StrSQL &= "select MAI_ElecMaintain_main.Unit_code, MAI_ElecMaintain_main.User_id, MAI_ElecMaintain_main.CaseClose_type, COUNT(User_id) as Total from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
                    StrSQL &= "where 1 = 1 "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MAI_ElecMaintain_main.Unit_code, MAI_ElecMaintain_main.CaseClose_type, MAI_ElecMaintain_main.User_id "
            End Select
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '依時限完成率統計結果
        Public Function MAI3202_01_02MtTime(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            'Select Case Type
            '    Case "0"
            StrSQL &= "select '001' as Day,count(MAI_ElecMaintain_det.MtTime) as MaintainDayNum from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "where MAI_ElecMaintain_det.MtTime <='24' "
            StrSQL &= "and MAI_ElecMaintain_det.MtTime >'0' "
            StrSQL &= "and MAI_ElecMaintain_main.CaseClose_type='Y' "
            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            StrSQL &= "union "
            StrSQL &= "select '002' as Day,count(MAI_ElecMaintain_det.MtTime) as MaintainDayNum from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "where MAI_ElecMaintain_det.MtTime <='48' "
            StrSQL &= "and MAI_ElecMaintain_det.MtTime >'24' "
            StrSQL &= "and MAI_ElecMaintain_main.CaseClose_type='Y' "

            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            StrSQL &= "union "
            StrSQL &= "select '003' as Day,count(MAI_ElecMaintain_det.MtTime) as MaintainDayNum from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "where MAI_ElecMaintain_det.MtTime <='72' "
            StrSQL &= "and MAI_ElecMaintain_det.MtTime >'48' "
            StrSQL &= "and MAI_ElecMaintain_main.CaseClose_type='Y' "

            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            StrSQL &= "union "
            StrSQL &= "select '004' as Day,count(MAI_ElecMaintain_det.MtTime) as MaintainDayNum from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "where MAI_ElecMaintain_det.MtTime >'72' "
            StrSQL &= "and MAI_ElecMaintain_main.CaseClose_type='Y' "

            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            '    Case "1"

            'End Select
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '水電報修至完成之平均時數統計結果
        Public Function MAI3202_01_02Average(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            StrSQL &= "select '報修至完成之筆數、總時數及平均時數' as Item, count(MAI_ElecMaintain_det.MtTime) as MaintainDayNum, sum(MAI_ElecMaintain_det.MtTime) as MtTime, sum(MAI_ElecMaintain_det.MtTime) / count(MAI_ElecMaintain_det.MtTime) as Average from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "Where 1=1 "
            StrSQL &= "and MAI_ElecMaintain_main.CaseClose_type='Y' "
            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '待料狀況統計結果
        Public Function MAI3202_01_02Queliao(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            StrSQL &= "select ROW_NUMBER() OVER(ORDER BY ApplyTime desc) AS ROWID, MAI_ElecMaintain_main.Flow_id, User_name, USER_ID, CODE_DESC1, Maintainer_name + MaintainerPhone_nos as Maintainer_name, '待料中' as MtStatus_type, Problem_desc,'未結案' as CaseClose_type,CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ '/' + "
            StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + '/' +"
            StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) as ApplyTime from MAI_ElecMaintain_main "
            StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode)  "
            StrSQL &= "inner join SYS_Code on CODE_NO=MtClass_type "
            StrSQL &= "where MtStatus_type='004' "
            StrSQL &= "and CaseClose_type <> 'Y' "
            StrSQL &= "and CODE_SYS='019' "
            StrSQL &= "and CODE_TYPE='008' "
            If Not String.IsNullOrEmpty(ApplyTimeS) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
            End If
            If Not String.IsNullOrEmpty(ApplyTimeE) Then
                StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
            End If
            StrSQL &= "order by ApplyTime desc "
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '排休人員處裡次數統計結果
        Public Function MAI3202_01_02Process(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            Select Case Type
                Case "0" '查出維修人
                    StrSQL &= "select Maintainer_name, Depart_name, MtUser_id, '0' as Complete, '0' as CompleteProportion,'0' as NonCompleteNum, '0' as NonCompleteProportion,Total, '0' as TotalPercentage from ( "
                    StrSQL &= "select MAI_ElecMaintain_det.Maintainer_name, MtUnit_code, MtUser_id, COUNT(MtUser_id) as Total from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MAI_ElecMaintain_det.Maintainer_name, MtUnit_code, MtUser_id "
                    StrSQL &= ") as test "
                    StrSQL &= "inner join FSC_org on test.MtUnit_code=FSC_org.Depart_id "
                    StrSQL &= "group by Maintainer_name, Depart_name, MtUser_id, Total "
                Case "1" '查出維修明細
                    StrSQL &= "select MtUser_id, MtStatus_type, COUNT(MAI_ElecMaintain_det.Maintainer_name) as Num from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "and MtStatus_type='003' "
                    StrSQL &= "group by MtUser_id, MtStatus_type "
                    StrSQL &= "union "
                    StrSQL &= "select MtUser_id, MtStatus_type, COUNT(MAI_ElecMaintain_det.Maintainer_name) as Num from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "and MtStatus_type<>'001' "
                    StrSQL &= "group by MtUser_id, MtStatus_type "
            End Select

            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
        '完成案件排休人員處裡滿意度統計結果
        Public Function MAI3202_01_02SatisfactoryCompletion(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Dim SqlDA As SqlDataAdapter = New SqlDataAdapter()
            Dim StrSQL As String = String.Empty
            StrSQL = ""
            Select Case Type
                Case "0" '查出維修人與維修總數
                    StrSQL &= "select MAI_ElecMaintain_det.Maintainer_name, MtUser_id, COUNT(MtUser_id) as Total, '0' as Complete001, '0' as Complete001Proportion, '0' as Complete002, '0' as Complete002Proportion, '0' as Complete003, '0' as Complete003Proportion, '0' as Complete004, '0' as Complete004Proportion, '0' as Complete005, '0' as Complete005Proportion, '0' as Complete000, '0' as Complete000Proportion from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where MtStatus_type='003' "
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MAI_ElecMaintain_det.Maintainer_name, MtUser_id "
                Case "1" '查出維修明細與滿意度
                    StrSQL &= "select MtUser_id, Satisfaction_type, COUNT(Satisfaction_type) as Satisfaction_typeNum from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' " '完成
                    StrSQL &= "and Satisfaction_type='001' " '非常滿意
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MtUser_id, Satisfaction_type "
                    StrSQL &= "union "
                    StrSQL &= "select MtUser_id, Satisfaction_type, COUNT(Satisfaction_type) as Satisfaction_typeNum from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' " '完成
                    StrSQL &= "and Satisfaction_type='002' " '滿意
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MtUser_id, Satisfaction_type "
                    StrSQL &= "union "
                    StrSQL &= "select MtUser_id, Satisfaction_type, COUNT(Satisfaction_type) as Satisfaction_typeNum from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' " '完成
                    StrSQL &= "and Satisfaction_type='003' " '普通
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MtUser_id, Satisfaction_type "
                    StrSQL &= "union "
                    StrSQL &= "select MtUser_id, Satisfaction_type, COUNT(Satisfaction_type) as Satisfaction_typeNum from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' " '完成
                    StrSQL &= "and Satisfaction_type='004' " '不滿意
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MtUser_id, Satisfaction_type "
                    StrSQL &= "union "
                    StrSQL &= "select MtUser_id, Satisfaction_type, COUNT(Satisfaction_type) as Satisfaction_typeNum from MAI_ElecMaintain_main "
                    StrSQL &= "inner join MAI_ElecMaintain_det on (MAI_ElecMaintain_det.Flow_id=MAI_ElecMaintain_main.Flow_id and MAI_ElecMaintain_det.OrgCode=MAI_ElecMaintain_main.OrgCode) "
                    StrSQL &= "inner join MAI_Maintainer_main on MAI_Maintainer_main.MaintainerPhone_nos=MAI_ElecMaintain_det.MaintainerPhone_nos "
                    StrSQL &= "where 1 = 1 "
                    StrSQL &= "and MtStatus_type='003' " '完成
                    StrSQL &= "and Satisfaction_type='005' " '非常不滿意
                    If Not String.IsNullOrEmpty(ApplyTimeS) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) >= @ApplyTimeS "
                    End If
                    If Not String.IsNullOrEmpty(ApplyTimeE) Then
                        StrSQL &= "and CONVERT(VARCHAR(3),CONVERT(VARCHAR(4),MAI_ElecMaintain_main.ApplyTime,20) - 1911)+ "
                        StrSQL &= " SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),6,2) + "
                        StrSQL &= "SUBSTRING(CONVERT(VARCHAR(10),MAI_ElecMaintain_main.ApplyTime,20),9,2) <= @ApplyTimeE "
                    End If
                    StrSQL &= "group by MtUser_id, Satisfaction_type "
            End Select
            Dim ps() As SqlParameter = {New SqlParameter("@ApplyTimeS", ApplyTimeS), _
                                        New SqlParameter("@ApplyTimeE", ApplyTimeE)}
            Return Query(StrSQL, ps)
        End Function
    End Class
End Namespace