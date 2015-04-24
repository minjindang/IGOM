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
        ''' ���XP2K���->�NP2K��ơA�g�J�t�Ԩt��
        ''' </summary>
        ''' <param name="dbName">P2K���s�u�W��</param>
        ''' <param name="PECARD">���u�N��</param>
        ''' <param name="PENAME">�m�W</param>
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
        ''' ���X�t�����
        ''' </summary>
        ''' <param name="PECARD">���u�N��</param>
        ''' <param name="PENAME">�m�W</param>
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
        ''' ���X�t�����Ӹ��(P2K.FSC.SAL.EMP)
        ''' </summary>
        ''' <param name="PECARD">���u�N��</param>
        ''' <param name="PENAME">�m�W</param>
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
        ''' ��s���u�t�԰򥻸����(FSC_Personnel)
        ''' </summary>
        ''' <param name="PECARD">���u�N��</param>
        ''' <param name="PEIDNO">�����Ҧr��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateFSC(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            Dim iCounts = DAO.UpdateFSC(PECARD, PEIDNO)
                Return iCounts
        End Function

        ''' <summary>
        ''' ��s�H���~������(SAL_SABASE)
        ''' </summary>
        ''' <param name="PECARD">���u�N��</param>
        ''' <param name="PEIDNO">�����Ҧr��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateSAL(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            Dim iCounts = DAO.UpdateSAL(PECARD, PEIDNO)
            Return iCounts
        End Function

        ''' <summary>
        ''' ��s���u�򥻸����(EMP_Member)
        ''' </summary>
        ''' <param name="PECARD">���u�N��</param>
        ''' <param name="PEIDNO">�����Ҧr��</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateEMP(ByVal PECARD As String, ByVal PEIDNO As String) As Integer
            Dim iCounts = DAO.UpdateEMP(PECARD, PEIDNO)
            Return iCounts
        End Function


    End Class
End Namespace
