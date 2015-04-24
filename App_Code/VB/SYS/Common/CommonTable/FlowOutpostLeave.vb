Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class FlowOutpostLeave
        Private DAO As FlowOutpostLeaveDAO

#Region "Property"
        Private _orgcode As String
        Private _flow_outpost_id As String
        Private _leave_group_id As String
        Private _change_userid As String
        Private _change_date As Date

        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(value As String)
                _orgcode = value
            End Set
        End Property
        Public Property Flow_outpost_id() As String
            Get
                Return _flow_outpost_id
            End Get
            Set(value As String)
                _flow_outpost_id = value
            End Set
        End Property
        Public Property Leave_group_id() As String
            Get
                Return _leave_group_id
            End Get
            Set(value As String)
                _leave_group_id = value
            End Set
        End Property
        Public Property Change_userid() As String
            Get
                Return _change_userid
            End Get
            Set(value As String)
                _change_userid = value
            End Set
        End Property
        Public Property Change_date() As String
            Get
                Return _change_date
            End Get
            Set(value As String)
                _change_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New FlowOutpostLeaveDAO()
        End Sub

        Public Function GetFlowOutpostLeave(ByVal flowOutpostId As String) As DataTable
            Return DAO.GetDataByfopid(flowOutpostId)
        End Function

        Public Function InsertFlowOutpostLeave(ByVal flowOutpostId As String, ByVal leaveGroupId As String, ByVal changeUserid As String, ByVal changeDate As Date) As Boolean
            Return DAO.InsertData(flowOutpostId, leaveGroupId, changeUserid, changeDate) = 1
        End Function

        Public Function DeleteFlowOutpostLeave(ByVal flowOutpostId As String) As Boolean
            Return DAO.DeleteData(flowOutpostId) = 1
        End Function

        Public Function GetLeaveGroupIdByQuery(ByVal flowOutpostId As String, ByVal orgcode As String, ByVal departId As String) As DataTable
            Return DAO.GetLeaveGroupIdByQuery(flowOutpostId, orgcode, departId)
        End Function
    End Class
End Namespace