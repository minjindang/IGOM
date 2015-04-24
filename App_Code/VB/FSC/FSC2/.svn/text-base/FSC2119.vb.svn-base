Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC2119
        Private DAO As FSC2119DAO

        Public Sub New()
            DAO = New FSC2119DAO()
        End Sub

        ''' <summary>
        ''' 回傳敍獎申請資料檔-提報單位
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordDepart() As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetRewordDepart()
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔-考績會名稱
        ''' </summary>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRewordCouncilName(ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetRewordCouncilName(Dept, CouncilDateStart, CouncilDateEnd)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔【敘獎提案統計表】
        ''' </summary>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="dtTable">考績會名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportData01(ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, ByVal dtTable As DataTable) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetReportData01(Dept, CouncilDateStart, CouncilDateEnd, dtTable)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳敍獎申請資料檔【敘獎統計表】
        ''' </summary>
        ''' <param name="Dept">提報單位</param>
        ''' <param name="CouncilDateStart">考績會日期起日</param>
        ''' <param name="CouncilDateEnd">考績會日期迄日</param>
        ''' <param name="dtTable">考績會名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetReportData02(ByVal Dept As String, ByVal CouncilDateStart As String, ByVal CouncilDateEnd As String, ByVal dtTable As DataTable) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetReportData02(Dept, CouncilDateStart, CouncilDateEnd, dtTable)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function
    End Class
End Namespace
