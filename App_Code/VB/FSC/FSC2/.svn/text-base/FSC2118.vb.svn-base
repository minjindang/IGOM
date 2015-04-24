Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2118
        Private DAO As FSC2118DAO

        Public Sub New()
            DAO = New FSC2118DAO()
        End Sub

        ''' <summary>
        ''' 回傳敍獎申請資料檔
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="ApplyDateStart">提報日期起日</param>
        ''' <param name="ApplyDateEnd">提報日期迄日</param>
        ''' <param name="RewordDateStart">獎勵令日期起日</param>
        ''' <param name="RewordDateEnd">獎勵令日期迄日</param>
        ''' <param name="RewordDoc">獎勵令文號</param>
        ''' <param name="RewordDepartID">獎懲人員單位代碼</param>
        ''' <param name="RewordLevel">官職等</param>
        ''' <returns>項次,提報單位,提報日期,獎勵令日期,獎勵令文號,獎懲人員單位,獎懲人員姓名,獎懲人員官職等</returns>
        ''' <remarks></remarks>
        Public Function getData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String, ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, _
                                ByVal ApplyDateStart As String, ByVal ApplyDateEnd As String, ByVal RewordDateStart As String, ByVal RewordDateEnd As String, ByVal RewordDoc As String, _
                                ByVal RewordDepartID As String, ByVal RewordLevel As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetData(CODE_SYS, CODE_TYPE, Dept, CouncilDateStart, CouncilDateEnd, ApplyDateStart, ApplyDateEnd, RewordDateStart, RewordDateEnd, RewordDoc, RewordDepartID, RewordLevel)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔
        ''' </summary>
        ''' <param name="strCheckBox">子系統別</param>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="ApplyDateStart">提報日期起日</param>
        ''' <param name="ApplyDateEnd">提報日期迄日</param>
        ''' <param name="RewordDateStart">獎勵令日期起日</param>
        ''' <param name="RewordDateEnd">獎勵令日期迄日</param>
        ''' <param name="RewordDoc">獎勵令文號</param>
        ''' <param name="RewordDepartID">獎懲人員單位代碼</param>
        ''' <param name="RewordLevel">官職等</param>
        ''' <returns>項次,提報單位,提報日期,獎勵令日期,獎勵令文號,獎懲人員單位,獎懲人員姓名,獎懲人員官職等</returns>
        ''' <remarks></remarks>
        Public Function getReportData(ByVal strCheckBox() As String, ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, _
                                ByVal ApplyDateStart As String, ByVal ApplyDateEnd As String, ByVal RewordDateStart As String, ByVal RewordDateEnd As String, ByVal RewordDoc As String, _
                                ByVal RewordDepartID As String, ByVal RewordLevel As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetReportData(strCheckBox, Dept, CouncilDateStart, CouncilDateEnd, ApplyDateStart, ApplyDateEnd, RewordDateStart, RewordDateEnd, RewordDoc, RewordDepartID, RewordLevel)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function
    End Class
End Namespace
