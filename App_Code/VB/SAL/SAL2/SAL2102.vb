Imports Microsoft.VisualBasic
Imports System.Data

Namespace SALARY.Logic
    Public Class SAL2102
        Public DAO As SAL2102DAO

        Public Sub New()
            DAO = New SAL2102DAO()
        End Sub

        Dim dtData As DataTable

        ''' <summary>
        ''' 回傳單位名稱/科別名稱
        ''' </summary>
        ''' <param name="orgcode">機關代號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDepart(ByVal orgcode As String) As DataTable
            dtData = DAO.GetDepart(orgcode)
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
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserName(ByVal orgcode As String, ByVal departId As String) As DataTable
            dtData = DAO.GetUserName(orgcode, departId)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="Apply_yy"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData(ByVal Apply_yy As String, ByVal PAYOD_CODE As String, ByVal Id_card As String) As DataTable
            dtData = DAO.GetData(Apply_yy, PAYOD_CODE, Id_card)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 列印用
        ''' </summary>
        ''' <param name="Apply_yy"></param>
        ''' <param name="SpecialInquiry"></param>
        ''' <param name="Type"></param>
        ''' <param name="PAYOD_CODE"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PrintData(ByVal Apply_yy As String, ByVal SpecialInquiry As String, ByVal Type As String, ByVal PAYOD_CODE As String) As DataTable
            dtData = DAO.PrintData(Apply_yy, SpecialInquiry, Type, PAYOD_CODE)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        Public Function getFamily(ByVal id_card As String) As DataTable
            Return DAO.getFamily(id_card)
        End Function
    End Class
End Namespace