Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class FlowOutpostForm
        Private DAO As FlowOutpostFormDAO

#Region "Property"
        Private _orgcode As String
        Private _flow_outpost_id As String
        Private _form_id As String
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
        Public Property Form_id() As String
            Get
                Return _form_id
            End Get
            Set(value As String)
                _form_id = value
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
        Public Property Change_date() As Date
            Get
                Return _change_date
            End Get
            Set(value As Date)
                _change_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New FlowOutpostFormDAO()
        End Sub

        Public Function GetFlowOutpostForm(ByVal flowOutpostId As String) As DataTable
            Return DAO.GetDataByfopid(flowOutpostId)
        End Function

        Public Function InsertFlowOutpostForm() As Boolean
            If "" = Me.Flow_outpost_id Then
                Return False
            End If
            Return DAO.InsertData(Me) = 1
        End Function

        Public Function DeleteFlowOutpostForm(ByVal flowOutpostId As String) As Boolean
            Return DAO.DeleteData(flowOutpostId) = 1
        End Function

        Public Function GetFormIdByQuery(ByVal flowOutpostId As String, ByVal orgcode As String, ByVal departId As String) As DataTable
            Return DAO.GetFormIdByQuery(flowOutpostId, orgcode, departId)
        End Function
    End Class
End Namespace