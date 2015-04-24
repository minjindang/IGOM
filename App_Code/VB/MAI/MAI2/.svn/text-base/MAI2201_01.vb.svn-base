Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSCPLM.Logic
    Public Class MAI2201_01
        Public DAO As MAI2201_01DAO

        Public Sub New()
            DAO = New MAI2201_01DAO()
        End Sub
        'MAI_ElecMaintain_main Join MAI_ElecMaintain_det
        Public Function MAI3202_01_01(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Return DAO.MAI3202_01_01(ApplyTimeS, ApplyTimeE)
        End Function
        Public Function MAI3202_01_02FSCorg(ByVal Orgcode As String) As DataTable
            Return DAO.MAI3202_01_02FSCorg(Orgcode)
        End Function
        '依單位報修次數統計
        Public Function MAI3202_01_02Maintain_mainJoinMAI_ElecMaintain_det(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Return DAO.MAI3202_01_02Maintain_mainJoinMAI_ElecMaintain_det(ApplyTimeS, ApplyTimeE, Type)
        End Function
        '依單位滿意度統計
        Public Function MAI3202_01_02Satisfaction(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Return DAO.MAI3202_01_02Satisfaction(ApplyTimeS, ApplyTimeE, Type)
        End Function
        '個人報修統計
        Public Function MAI3202_01_02Personal(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Return DAO.MAI3202_01_02Personal(ApplyTimeS, ApplyTimeE, Type)
        End Function
        '依時限完成率統計結果
        Public Function MAI3202_01_02MtTime(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Return DAO.MAI3202_01_02MtTime(ApplyTimeS, ApplyTimeE)
        End Function
        '水電報修至完成之平均時數統計結果
        Public Function MAI3202_01_02Average(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Return DAO.MAI3202_01_02Average(ApplyTimeS, ApplyTimeE)
        End Function
        '待料狀況統計結果
        Public Function MAI3202_01_02Queliao(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String) As DataTable
            Return DAO.MAI3202_01_02Queliao(ApplyTimeS, ApplyTimeE)
        End Function
        '排休人員處裡次數統計結果
        Public Function MAI3202_01_02Process(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Return DAO.MAI3202_01_02Process(ApplyTimeS, ApplyTimeE, Type)
        End Function
        '完成案件排休人員處裡滿意度統計結果
        Public Function MAI3202_01_02SatisfactoryCompletion(ByVal ApplyTimeS As String, ByVal ApplyTimeE As String, ByVal Type As String) As DataTable
            Return DAO.MAI3202_01_02SatisfactoryCompletion(ApplyTimeS, ApplyTimeE, Type)
        End Function
    End Class
End Namespace