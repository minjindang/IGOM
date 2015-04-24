Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace SYS.Logic
    <System.ComponentModel.DataObject()> _
    Public Class CustomLeaveSetting
        Public DAO As CustomLeaveSettingDAO
        Public Sub New()
            DAO = New CustomLeaveSettingDAO()
        End Sub

#Region "fields"
        Private _id As Integer
        Private _Orgcode As String
        Private _Leave_group_id As String
        Private _Leave_type As Integer
        Private _isApply As String
        Private _isApllyDate As String
        Private _isApllyDateSE As String
        Private _isReason As String
        Private _isAttach As String
        Private _isDetail As String
        Private _Explanation As String
        Private _Mark As String
        Private _isCustom1 As String
        Private _Change_userid As String
#End Region

#Region "Property"
        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
        Public Property Leave_group_id() As String
            Get
                Return _Leave_group_id
            End Get
            Set(ByVal value As String)
                _Leave_group_id = value
            End Set
        End Property
        Public Property Leave_type() As Integer
            Get
                Return _Leave_type
            End Get
            Set(ByVal value As Integer)
                _Leave_type = value
            End Set
        End Property
        Public Property isApply() As String
            Get
                Return _isApply
            End Get
            Set(ByVal value As String)
                _isApply = value
            End Set
        End Property
        Public Property isApllyDate() As String
            Get
                Return _isApllyDate
            End Get
            Set(ByVal value As String)
                _isApllyDate = value
            End Set
        End Property
        Public Property isApllyDateSE() As String
            Get
                Return _isApllyDateSE
            End Get
            Set(ByVal value As String)
                _isApllyDateSE = value
            End Set
        End Property
        Public Property isReason() As String
            Get
                Return _isReason
            End Get
            Set(ByVal value As String)
                _isReason = value
            End Set
        End Property
        Public Property isAttach() As String
            Get
                Return _isAttach
            End Get
            Set(ByVal value As String)
                _isAttach = value
            End Set
        End Property
        Public Property isDetail() As String
            Get
                Return _isDetail
            End Get
            Set(ByVal value As String)
                _isDetail = value
            End Set
        End Property
        Public Property Explanation() As String
            Get
                Return _Explanation
            End Get
            Set(ByVal value As String)
                _Explanation = value
            End Set
        End Property
        Public Property Mark() As String
            Get
                Return _Mark
            End Get
            Set(ByVal value As String)
                _Mark = value
            End Set
        End Property
        Public Property isCustom1() As String
            Get
                Return _isCustom1
            End Get
            Set(ByVal value As String)
                _isCustom1 = value
            End Set
        End Property
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
#End Region

        Public Function GetData(ByVal Orgcode As String, ByVal leaveGroup As String, ByVal leaveType As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode, leaveGroup, leaveType)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetData(ByVal Orgcode As String, ByVal leaveGroup As String, ByVal leaveType As String, ByVal role_id As String) As DataTable
            Dim ds As DataSet = DAO.GetData(Orgcode, leaveGroup, leaveType, role_id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Return DAO.DeleteData(id)
        End Function

        Public Function InsertData() As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Leave_group_id", Leave_group_id)
            d.Add("Leave_type", Leave_type)
            d.Add("isApply", isApply)
            d.Add("isApllyDate", isApllyDate)
            d.Add("isApllyDateSE", isApllyDateSE)
            d.Add("isReason", isReason)
            d.Add("isAttach", isAttach)
            'd.Add("isDetail", isDetail)
            'd.Add("Explanation", Explanation)
            d.Add("Mark", Mark)
            d.Add("isCustom1", isCustom1)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("SYS_Custom_leave_setting", d) >= 1
        End Function

        Public Function UpdateData() As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Orgcode", Orgcode)
            d.Add("Leave_group_id", Leave_group_id)
            d.Add("Leave_type", Leave_type)
            d.Add("isApply", isApply)
            d.Add("isApllyDate", isApllyDate)
            d.Add("isApllyDateSE", isApllyDateSE)
            d.Add("isReason", isReason)
            d.Add("isAttach", isAttach)
            'd.Add("isDetail", isDetail)
            'd.Add("Explanation", Explanation)
            d.Add("Mark", Mark)
            d.Add("isCustom1", isCustom1)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("SYS_Custom_leave_setting", d, cd) >= 1
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataById(id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function
    End Class
End Namespace
