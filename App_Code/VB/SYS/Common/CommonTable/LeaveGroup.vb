Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    <System.ComponentModel.DataObject()> _
    Public Class LeaveGroup
        Public DAO As LeaveGroupDAO
        Public Sub New()
            DAO = New LeaveGroupDAO()
        End Sub

#Region "Field"
        Private _Leave_group_id As String = String.Empty            ' 1.差假類型ID
        Private _Orgcode As String = String.Empty                   ' 2.機關代碼
        Private _Depart_id As String = String.Empty                 ' 3.單位代碼
        Private _Leave_group_name As String = String.Empty          ' 4.差假類型名稱
        Private _Leavetype As String = String.Empty                 ' 5.假別代碼
#End Region

#Region "Property"
        ''' <summary>
        ''' 差假類型ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Leave_group_id() As Integer
            Get
                Return _Leave_group_id
            End Get
            Set(ByVal value As Integer)
                _Leave_group_id = value
            End Set
        End Property
        ''' <summary>
        ''' 機關代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        ''' <summary>
        ''' 祝賀語內容
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
        ''' <summary>
        ''' 差假類型名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Leave_group_name() As String
            Get
                Return _Leave_group_name
            End Get
            Set(ByVal value As String)
                _Leave_group_name = value
            End Set
        End Property
        ''' <summary>
        ''' 假別代碼:","隔開
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Leavetype() As String
            Get
                Return _Leavetype
            End Get
            Set(ByVal value As String)
                _Leavetype = value
            End Set
        End Property

#End Region

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetLeaveGroupByOrgcode(ByVal orgcode As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByOrgcode(orgcode)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function


        Public Function GetLeaveGroupByOrgcode(ByVal orgcode As String, ByVal Leave_group_id As String) As DataTable
            Dim dt As DataTable = DAO.GetDataByOrgcodelgID(orgcode, Leave_group_id)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetLeaveGroupInfo(ByVal orgcode As String, ByVal Depart_id As String) As DataTable
            Dim dt As DataTable = DAO.GetLeaveGroupInfo(orgcode, Depart_id)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetLeaveGroup2(ByVal Orgcode As String, ByVal Leave_group_id As String, ByVal Depart_id As String) As DataTable
            Dim dt As DataTable = DAO.GetLeaveGroup2(Orgcode, Leave_group_id, Depart_id)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetLeaveGroupCombineLeaveType(ByVal Orgcode As String, ByVal Leave_group_id As String) As String
            Return GetLeaveGroupByOrgcode(Orgcode, Leave_group_id).Rows(0)("Leave_group_name") & New LeaveType().GetCombineLeaveType(Orgcode, Leave_group_id)
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetLeaveGroupWithType(ByVal orgcode As String, ByVal depart_id As String) As DataTable
            Dim lg_dt As DataTable = GetLeaveGroupInfo(orgcode, depart_id)
            For Each lg_dr As DataRow In lg_dt.Rows
                Dim lt_dt As DataTable = New LeaveType().GetLeaveType(orgcode, lg_dr("LeaveGroupID").ToString)
                Dim leave As String = lg_dr("LeaveGroupName").ToString & "("
                Dim i As Integer = 0

                For Each lt_dr As DataRow In lt_dt.Rows
                    leave &= lt_dr("LeaveName").ToString & IIf(i <> lt_dt.Rows.Count - 1, "、", "")
                    i += 1
                Next
                leave &= ")"
                lg_dr("LeaveGroupName") = leave
            Next
            Return lg_dt
        End Function

        <System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select)> _
        Public Function GetLeaveGroupAndType(ByVal orgcode As String, ByVal Leave_group_id As String) As DataTable
            Dim lg_dt As DataTable = GetLeaveGroupByOrgcode(orgcode, Leave_group_id)
            lg_dt.Columns.Add("LeaveType", GetType(String))

            For Each lg_dr As DataRow In lg_dt.Rows
                Dim lt_dt As DataTable = New LeaveType().GetLeaveType(orgcode, lg_dr("Leave_group_id").ToString)
                Dim i As Integer = 0
                For Each lt_dr As DataRow In lt_dt.Rows
                    lg_dr("LeaveType") &= lt_dr("LeaveName").ToString & IIf(i <> lt_dt.Rows.Count - 1, "、", "")
                    i += 1
                Next
            Next
            Return lg_dt
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Return DAO.DeleteData(id)
        End Function

        Public Function InsertData(ByVal Orgcode As String, ByVal GroupId As String, ByVal DepartId As String, ByVal GroupName As String) As String
            Return DAO.InsertData(Orgcode, GroupId, DepartId, GroupName)
        End Function

        Public Function UpdateData(ByVal Orgcode As String, ByVal GroupId As String, ByVal DepartId As String, ByVal GroupName As String, ByVal id As Integer) As String
            Return DAO.UpdateData(Orgcode, GroupId, DepartId, GroupName, id)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim dt As DataTable = DAO.GetDataById(id)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function

        Public Function GetCustomGroup(ByVal Orgcode As String) As DataTable
            Dim dt As DataTable = DAO.GetCustomGroup(Orgcode)
            If dt Is Nothing Then Return Nothing
            Return dt
        End Function
    End Class
End Namespace