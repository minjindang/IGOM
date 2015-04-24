Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    <System.ComponentModel.DataObject()> _
    Public Class LeaveType

        Public Enum LeaveTable
            CPAPO15M = 15
            CPAPP16M = 16
            CPAPR18M = 18
        End Enum

        Public DAO As LeaveTypeDAO
        Public Sub New()
            DAO = New LeaveTypeDAO()
        End Sub

        Public Function GetLeaveType(ByVal Orgcode As String, ByVal LeaveGroup As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode, LeaveGroup)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetLeaveType(ByVal Orgcode As String, ByVal LeaveGroupList As ArrayList) As DataTable
            Dim leaveGroups As String = ""
            For Each leaveGroup As String In LeaveGroupList
                leaveGroups &= "'" & leaveGroup & "',"
            Next
            Dim dt As DataTable = DAO.GetData2(Orgcode, leaveGroups.TrimEnd(","))
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetLeaveType(ByVal Orgcode As String) As DataTable
            Dim dt As DataTable = DAO.GetData(Orgcode)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function


        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetLeaveType() As DataTable
            Dim dt As DataTable = DAO.GetData()
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function


        Public Function GetLeaveName(ByVal Leave_type As String) As String
            If String.IsNullOrEmpty(Leave_type) Then
                Return ""
            End If
            Dim dt As DataTable = DAO.GetDataByLeave_type(Leave_type)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                Return ""
            End If
            Return dt.Rows(0)("Leave_name").ToString()
        End Function


        Public Function GetLeaveTable(ByVal Leave_type As String) As String
            Dim dt As DataTable = DAO.GetDataByLeave_type(Leave_type)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then Return "0"
            Return dt.Rows(0)("Leave_table").ToString()
        End Function

        ''' <summary>
        ''' 組合 LeaveGroup 和對應的 LeaveType 中文字串
        ''' </summary>
        ''' <param name="Orgcode"></param>
        ''' <param name="LeaveGroupID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetCombineLeaveType(ByVal Orgcode As String, ByVal LeaveGroupID As String) As String

            Dim lt_dt As DataTable = GetLeaveType(Orgcode, LeaveGroupID)

            Dim LeaveType As String = "("
            Dim i As Integer = 0
            For Each lt_dr As DataRow In lt_dt.Rows
                LeaveType &= lt_dr("LeaveName").ToString & IIf(i <> lt_dt.Rows.Count - 1, "、", "")
                i += 1
            Next
            LeaveType &= ")"

            Return LeaveType
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Return DAO.DeleteData(id)
        End Function

        Public Function InsertData(ByVal LeaveType As String, ByVal LeaveName As String) As String
            Return DAO.InsertData(LeaveType, LeaveName)
        End Function

        Public Function UpdateData(ByVal LeaveType As String, ByVal LeaveName As String, ByVal id As Integer) As String
            Return DAO.UpdateData(LeaveType, LeaveName, id)
        End Function

        Public Function GetDataByLeave_type(ByVal LeaveType As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByLeave_type(LeaveType)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim dt As DataTable = DAO.GetDataById(id)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
        '==============20140422==============
        Public Function GetData(ByVal Leavetable As String) As DataTable
            Dim dt As DataTable = DAO.GetData1(Leavetable)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function


        Public Function GetDataBySexFlag(orgcode As String, sexFlag As String) As DataTable
            Return DAO.GetDataBySexFlag(orgcode, sexFlag)
        End Function
    End Class
End Namespace
