Imports Microsoft.VisualBasic
Imports System.Data

Namespace SAL.Logic
    Public Class SAL2103
        Private DAO As SAL2103DAO

        Public Sub New()
            DAO = New SAL2103DAO()
        End Sub

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="orgcode">機關代碼</param>
        ''' <param name="YYMM">發放年月</param>
        ''' <param name="CODENO">代碼</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFormData(ByVal orgcode As String, ByVal YYMM As String, ByVal CODENO As String) As DataTable
            Dim dssdata As DataTable
            dssdata = DAO.GetFormData(orgcode, YYMM, CODENO)
            Return DAO.GetFormData(orgcode, YYMM, CODENO)
        End Function

    End Class
End Namespace
