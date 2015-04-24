Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace SYS.Logic
    <System.ComponentModel.DataObject()> _
    Public Class RoleCustomLeave
        Public DAO As RoleCustomLeaveDAO
        Public Sub New()
            DAO = New RoleCustomLeaveDAO()
        End Sub

#Region "fields"
        Private _id As Integer
        Private _Custom_leave_setting_id As Integer
        Private _Role_id As String
        Private _change_userid As String
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
        Public Property Custom_leave_setting_id() As Integer
            Get
                Return _Custom_leave_setting_id
            End Get
            Set(ByVal value As Integer)
                _Custom_leave_setting_id = value
            End Set
        End Property
        Public Property Role_id() As String
            Get
                Return _Role_id
            End Get
            Set(ByVal value As String)
                _Role_id = value
            End Set
        End Property
        Public Property change_userid() As String
            Get
                Return _change_userid
            End Get
            Set(ByVal value As String)
                _change_userid = value
            End Set
        End Property
#End Region

        Public Function InsertData() As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Custom_leave_setting_id", Custom_leave_setting_id)
            d.Add("Role_id", Role_id)
            d.Add("change_userid", change_userid)
            d.Add("change_date", Now)

            Return DAO.InsertByExample("SYS_Role_custom_leave", d) >= 1
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Return DAO.DeleteData(id)
        End Function

        Public Function DeleteDataByCusId(ByVal Custom_leave_setting_id As Integer) As String
            Return DAO.DeleteDataByCusId(Custom_leave_setting_id)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataById(id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByCusId(ByVal id As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataByCusId(id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function
    End Class
End Namespace
