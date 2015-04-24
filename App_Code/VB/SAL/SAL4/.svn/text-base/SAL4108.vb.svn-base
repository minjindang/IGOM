Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace SAL.Logic
    Public Class SAL4108
        Private DAO As SAL4108DAO

        Public Sub New()
            DAO = New SAL4108DAO()
        End Sub

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="STAN_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal Stan_Sal_Point As String) As DataTable
            Return DAO.getQueryData(STAN_YM, STAN_TYPE, STAN_NO,Stan_Sal_Point )
        End Function

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="stan_type"></param>
        ''' <param name="stan_no"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal stan_type As String, ByVal stan_no As String) As DataTable
            Return DAO.getQueryData(stan_type, stan_no)
        End Function

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="stan_ym"></param>
        ''' <param name="stan_type"></param>
        ''' <param name="stan_no"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal stan_ym As String, ByVal stan_type As String, ByVal stan_no As String) As DataTable
            Return DAO.getQueryData(stan_ym, stan_type, stan_no)
        End Function

        ''' <summary>
        ''' 修改資料
        ''' </summary>
        ''' <param name="STAN_ID"></param>
        ''' <param name="Stan_Sal"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Update(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal Stan_Sal_Point As String, ByVal Stan_Sal As String, ByVal STAN_MUSER As String, ByVal STAN_MDATE As String) As Boolean
            Return DAO.Update(STAN_YM, STAN_TYPE, STAN_NO, Stan_Sal_Point, Stan_Sal, STAN_MUSER, STAN_MDATE) > 0
        End Function

        ''' <summary>
        ''' 新增資料
        ''' </summary>
        ''' <param name="STAN_YM"></param>
        ''' <param name="STAN_TYPE"></param>
        ''' <param name="STAN_NO"></param>
        ''' <param name="STAN_SAL_POINT"></param>
        ''' <param name="STAN_SAL"></param>
        ''' <param name="STAN_MUSER"></param>
        ''' <param name="STAN_MDATE"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Insert(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal STAN_SAL_POINT As String, ByVal STAN_SAL As String, ByVal STAN_MUSER As String, ByVal STAN_MDATE As String) As Boolean
            Return DAO.Insert(STAN_YM, STAN_TYPE, STAN_NO, STAN_SAL_POINT, STAN_SAL, STAN_MUSER, STAN_MDATE) > 0
        End Function

        ''' <summary>
        ''' 刪除資料
        ''' </summary>
        ''' <param name="STAN_ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Delete(ByVal STAN_YM As String, ByVal STAN_TYPE As String, ByVal STAN_NO As String, ByVal STAN_SAL_POINT As String) As Boolean
            Return DAO.Delete(STAN_YM, STAN_TYPE, STAN_NO, STAN_SAL_POINT) > 0
        End Function
    End Class
End Namespace