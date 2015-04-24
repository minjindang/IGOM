Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Namespace SAL.Logic
    Public Class SAL4107
        Private DAO As SAL4107DAO

        Public Sub New()
            DAO = New SAL4107DAO()
        End Sub

        ''' <summary>
        ''' 回傳資料
        ''' </summary>
        ''' <param name="orgcode"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getQueryData(ByVal orgcode As String, ByVal JOB_ITEM As String, ByVal PAY_DATE As String) As DataTable
            Return DAO.getQueryData(orgcode, JOB_ITEM, PAY_DATE)
        End Function
     
    End Class
End Namespace