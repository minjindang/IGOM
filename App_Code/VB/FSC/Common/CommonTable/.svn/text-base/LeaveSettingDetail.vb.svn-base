Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text
Namespace FSC.Logic
    <System.ComponentModel.DataObject()> _
    Public Class LeaveSettingDetail
        Public DAO As LeaveSettingDetailDAO
        Public Sub New()
            DAO = New LeaveSettingDetailDAO()
        End Sub

#Region "fields"
        Private _id As Integer
        Private _Limitdays As Double
        Private _Detail_code_id As String
        Private _Leave_setting_id As Integer
        Private _update_userid As String
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
        Public Property Limitdays() As Double
            Get
                Return _Limitdays
            End Get
            Set(ByVal value As Double)
                _Limitdays = value
            End Set
        End Property
        Public Property Detail_code_id() As String
            Get
                Return _Detail_code_id
            End Get
            Set(ByVal value As String)
                _Detail_code_id = value
            End Set
        End Property
        Public Property Leave_setting_id() As Integer
            Get
                Return _Leave_setting_id
            End Get
            Set(ByVal value As Integer)
                _Leave_setting_id = value
            End Set
        End Property
        Public Property update_userid() As String
            Get
                Return _update_userid
            End Get
            Set(ByVal value As String)
                _update_userid = value
            End Set
        End Property
#End Region

        Public Function InsertData() As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Limitdays", Limitdays)
            d.Add("Detail_code_id", Detail_code_id)
            d.Add("Leave_setting_id", Leave_setting_id)
            d.Add("update_userid", update_userid)
            d.Add("update_date", Date.Now)

            Return DAO.InsertByExample("FSC_Leave_setting_detail", d) >= 1
        End Function

        Public Function UpdateData() As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Limitdays", Limitdays)
            d.Add("Detail_code_id", Detail_code_id)
            d.Add("Leave_setting_id", Leave_setting_id)
            d.Add("update_userid", update_userid)
            d.Add("update_date", Date.Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("FSC_Leave_setting_detail", d, cd) >= 1
        End Function

        Public Function DeleteData(ByVal id As Integer) As String
            Return DAO.DeleteData(id)
        End Function

        Public Function GetDataById(ByVal id As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataById(id)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

        Public Function GetDataByMasterId(ByVal MasterId As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataByMasterId(MasterId)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function
    End Class
End Namespace
