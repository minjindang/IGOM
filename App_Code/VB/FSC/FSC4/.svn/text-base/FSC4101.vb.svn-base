Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC4101
        Private DAO As FSC4101DAO

        Public Sub New()
            DAO = New FSC4101DAO()
        End Sub

        Dim dtData As DataTable

        ''' <summary>
        ''' 回傳單位名稱/科別名稱
        ''' </summary>
        ''' <param name="orgcode">機關代號</param>
        ''' <param name="departId">單位代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepart(ByVal orgcode As String, ByVal departId As String) As DataTable
            dtData = DAO.GetDepart(orgcode, departId)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳職稱/在職狀況
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCODE(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            dtData = DAO.GetCODE(CODE_SYS, CODE_TYPE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳人員姓名
        ''' </summary>
        ''' <param name="orgcode">機關代硯</param>
        ''' <param name="departId">部門代碼</param>
        ''' <param name="title">職稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserName(ByVal orgcode As String, ByVal departId As String, ByVal title As String) As DataTable
            dtData = DAO.GetUserName(orgcode, departId, title)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 查詢資料
        ''' </summary>
        ''' <param name="orgcode">機關代碼</param>
        ''' <param name="departId">單位名稱</param>
        ''' <param name="subdepartId">科別名稱</param>
        ''' <param name="title">職稱</param>
        ''' <param name="Name">人員姓名</param>
        ''' <param name="years">年度</param>
        ''' <param name="Works">在職狀況</param>
        ''' <param name="idcard">員工編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getData(ByVal orgcode As String, ByVal departId As String, ByVal subdepartId As String, ByVal title As String, ByVal Name As String, ByVal years As String, ByVal Works As String, ByVal idcard As String) As DataTable
            dtData = DAO.getData(orgcode, departId, subdepartId, title, Name, years, Works, idcard)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

    End Class
End Namespace
