Imports Microsoft.VisualBasic
Imports System.Data

Namespace FSC.Logic
    Public Class FSC3115
        Private DAO As FSC3115DAO

        Public Sub New()
            DAO = New FSC3115DAO()
        End Sub

        Dim dtData As DataTable

        ''' <summary>
        ''' 取出P2K資料->將P2K資料，寫入差勤系統
        ''' </summary>
        ''' <param name="dbName">P2K的連線名稱</param>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PENAME">姓名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetData_InsertData_ToIGOMDB(ByVal dbName As String, ByVal PECARD As String, ByVal PENAME As String) As DataTable
            dtData = DAO.GetData_InsertData_ToIGOMDB(dbName, PECARD, PENAME)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 取出差異資料
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PENAME">姓名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDifferenceData(ByVal PECARD As String, ByVal PENAME As String) As DataTable
            dtData = DAO.GetDifferenceData(PECARD, PENAME)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 取出差異明細資料(P2K.FSC.SAL.EMP)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PENAME">姓名</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDifferenceDetailsData(ByVal PECARD As String, ByVal PENAME As String) As DataTable
            dtData = DAO.GetDifferenceDetailsData(PECARD, PENAME)
            If dtData Is Nothing Then
                Return Nothing
            Else
                Return dtData
            End If
        End Function

        ''' <summary>
        ''' 更新員工差勤基本資料檔(FSC_Personnel)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateFSC(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            Dim iCounts = DAO.UpdateFSC(PECARD, PEIDNO)
                Return iCounts
        End Function

        ''' <summary>
        ''' 更新人員薪資資料檔(SAL_SABASE)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateSAL(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            Dim iCounts = DAO.UpdateSAL(PECARD, PEIDNO)
            Return iCounts
        End Function

        ''' <summary>
        ''' 更新員工基本資料檔(EMP_Member)
        ''' </summary>
        ''' <param name="PECARD">員工代號</param>
        ''' <param name="PEIDNO">身分證字號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateEMP(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            Dim iCounts = DAO.UpdateEMP(PECARD, PEIDNO)
            Return iCounts
        End Function


    End Class
End Namespace
