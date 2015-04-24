Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class SYS2104
        Private DAO As SYS2104DAO

        Public Sub New()
            DAO = New SYS2104DAO()
        End Sub

        ''' <summary>
        ''' 回傳人員類別
        ''' </summary>
        ''' <param name="CODE_SYS">子系統別</param>
        ''' <param name="CODE_TYPE">代碼類別</param>
        ''' <returns>CODE_DESC1,CODE_NO</returns>
        ''' <remarks></remarks>
        Public Function getEmployeeTypeData(ByVal CODE_SYS As String, ByVal CODE_TYPE As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.getEmployeeTypeData(CODE_SYS, CODE_TYPE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 取 員工基本資料檔 資料
        ''' </summary>
        ''' <returns>User_name</returns>
        ''' <remarks></remarks>
        Public Function getMemberName() As DataTable
            Dim dtData As DataTable
            dtData = DAO.getMemberName()
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳單位資料
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepart() As DataTable
            Dim dtData As DataTable
            dtData = DAO.GetDepart()
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 查詢資料
        ''' </summary>
        ''' <param name="Orgcode">機關代碼</param>
        ''' <param name="LoginTimeStart">登入時間(起)</param>
        ''' <param name="LoginTimeEnd">登入時間(迄)</param>
        ''' <param name="DepartId">單位代碼</param>
        ''' <param name="UserName">員工姓名</param>
        ''' <param name="IdCard">員工編號</param>
        ''' <param name="EmployeeType">人員類別</param>
        ''' <param name="LoginStatus">登入狀態</param>
        ''' <param name="WorkType">在職狀態</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getData(ByVal Orgcode As String, ByVal LoginTimeStart As String, ByVal LoginTimeEnd As String, ByVal DepartId As String, ByVal UserName As String, ByVal IdCard As String, ByVal EmployeeType As String, ByVal LoginStatus As String, ByVal WorkType As String) As DataTable
            Dim dtData As DataTable
            dtData = DAO.getData(Orgcode, LoginTimeStart, LoginTimeEnd, DepartId, UserName, IdCard, EmployeeType, LoginStatus, WorkType)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

    End Class
End Namespace
