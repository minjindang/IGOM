Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class SYS3113
        Private DAO As SYS3113DAO

        Public Sub New()
            DAO = New SYS3113DAO()
        End Sub

        ''' <summary>
        ''' 回傳功能名稱-父選單
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFuncFlag() As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetFuncFlag()
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳功能名稱-子選單
        ''' </summary>
        ''' <param name="Func_Flag">申請作業名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFuncName(ByVal Func_id As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetFuncName(Func_id)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳單位名稱與功能選單狀態
        ''' </summary>
        ''' <param name="Func_Flag">申請作業名稱</param>
        ''' <param name="Func_id">申請作業名稱</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepartName(ByVal Func_Flag As String, ByVal Func_id As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetDepartName(Func_Flag, Func_id)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 新增功能選單狀態(新增前，如資料存在，則先刪除)
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="Depart_id">單位代碼</param>
        ''' <param name="Func_id">功能代碼</param>
        ''' <param name="isFreeze">是否鎖定</param>
        ''' <param name="Change_userid">異動人員</param>
        ''' <param name="Change_date">異動日期</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertData(ByVal Orgcode As String, ByVal Depart_id As String, ByVal Func_id As String, ByVal isFreeze As String, ByVal Change_userid As String, ByVal Change_date As DateTime) As Integer
            Dim iCounts As Integer = 0
            iCounts = DAO.InsertData(Orgcode, Depart_id, Func_id, isFreeze, Change_userid, Change_date)
            Return iCounts
        End Function

    End Class
End Namespace
