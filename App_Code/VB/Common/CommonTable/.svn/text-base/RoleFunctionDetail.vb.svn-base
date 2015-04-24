Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic
Imports System.Text

Namespace FSCPLM.Logic
    <System.ComponentModel.DataObject()> _
    Public Class RoleFunctionDetail
        Public DAO As RoleFunctionDetailDAO
        Public Sub New()
            DAO = New RoleFunctionDetailDAO()
        End Sub

#Region "fields"
        Private _id As Integer
        Private _Role_id As String
        Private _Role_function_id As Integer
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
        Public Property Role_id() As String
            Get
                Return _Role_id
            End Get
            Set(ByVal value As String)
                _Role_id = value
            End Set
        End Property
        Public Property Role_function_id() As Integer
            Get
                Return _Role_function_id
            End Get
            Set(ByVal value As Integer)
                _Role_function_id = value
            End Set
        End Property
#End Region

        Public Function InsertData() As String
            Dim d As New Dictionary(Of String, Object)
            d.Add("Role_id", Role_id)
            d.Add("Role_function_id", Role_function_id)

            Return DAO.insertByExample("Role_function_detail", d) >= 1
        End Function

        Public Function DeleteDataByrfid(ByVal rfid As Integer) As String
            Return DAO.DeleteDataByrfid(rfid)
        End Function

        Public Function GetDataByrfid(ByVal rfid As Integer) As DataTable
            Dim ds As DataSet = DAO.GetDataByrfid(rfid)
            If ds Is Nothing Then Return Nothing
            Return ds.Tables(0)
        End Function

    End Class
End Namespace
