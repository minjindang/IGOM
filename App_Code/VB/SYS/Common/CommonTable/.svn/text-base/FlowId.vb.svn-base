Imports Microsoft.VisualBasic
Imports System.Data

Namespace SYS.Logic
    Public Class FlowId
        Dim DAO As FlowIdDAO

        Public Sub New()
            DAO = New FlowIdDAO()
        End Sub

#Region "Property"
        Private _orgcode As String
        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(ByVal value As String)
                _orgcode = value
            End Set
        End Property
        Private _flowKind As String
        Public Property FlowKind() As String
            Get
                Return _flowKind
            End Get
            Set(ByVal value As String)
                _flowKind = value
            End Set
        End Property
        Private _flowType As String
        Public Property FlowType() As String
            Get
                Return _flowType
            End Get
            Set(ByVal value As String)
                _flowType = value
            End Set
        End Property
        Private _flowYear As String
        Public Property FlowYear() As String
            Get
                Return _flowYear
            End Get
            Set(ByVal value As String)
                _flowYear = value
            End Set
        End Property
        Private _flowId As String
        Public Property FlowId() As String
            Get
                Return _flowId
            End Get
            Set(ByVal value As String)
                _flowId = value
            End Set
        End Property

#End Region

        ''' <summary>
        ''' 取Flow_id
        ''' </summary>
        ''' <param name="orgcode">機關</param>
        ''' <param name="formId">表單編號</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFlowId(ByVal orgcode As String, ByVal formId As String) As String
            Dim flowId As String = ""
            If formId.Length <> 6 Then
                Return ""
            End If
            Dim k As String = formId.Substring(2, 1)
            Dim t As String = formId.Substring(4)
            Dim y As String = (Now.Year - 1911).ToString().Substring(1, 2)
            flowId = ConbimeFlowId(orgcode, k, t, y)
            Return flowId
        End Function

        ''' <summary>
        ''' 取Flow_id (差假表單)
        ''' </summary>
        ''' <param name="orgcode">機關</param>
        ''' <param name="formId">表單編號</param>
        ''' <param name="leaveType">假別</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFlowId(ByVal orgcode As String, ByVal formId As String, ByVal leaveType As Integer) As String
            If leaveType = Nothing Then
                Return GetFlowId(orgcode, formId)
            End If
            Dim flowId As String = ""
            If formId.Length <> 6 Then
                Return ""
            End If
            Dim k As String = "0"
            Dim t As String = leaveType.ToString().PadLeft(2, "0")
            Dim y As String = (Now.Year - 1911).ToString().Substring(1, 2)
            flowId = ConbimeFlowId(orgcode, k, t, y)
            Return flowId
        End Function

        Protected Function ConbimeFlowId(orgcode As String, k As String, t As String, y As String) As String
            Dim changeUserid As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
            Dim flowId As String = ""
            Dim dt As DataTable = DAO.GetDataByQuery(orgcode, k, t, y)
            If dt Is Nothing OrElse dt.Rows.Count <= 0 Then
                flowId = "000001"
                DAO.insertData(orgcode, k, t, y, (CommonFun.getInt(flowId) + 1).ToString().PadLeft(6, "0"), changeUserid, Now)
            Else
                flowId = dt.Rows(0)("Flow_id").ToString()
                DAO.UpdateFlowId(orgcode, k, t, y, (CommonFun.getInt(flowId) + 1).ToString().PadLeft(6, "0"), changeUserid, Now)
            End If
            flowId = k & t & y & flowId
            Return flowId
        End Function
    End Class
End Namespace