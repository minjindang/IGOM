Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace EMP.Logic
    <System.ComponentModel.DataObject()> _
    Public Class DepartEmp
        Public DAO As DepartEmpDAO

        Public Sub New()
            DAO = New DepartEmpDAO()
        End Sub

#Region "Property"
        Private _orgcode As String
        Private _departId As String
        Private _idCard As String
        Private _serviceSdate As Date
        Private _serviceEdate As String
        Private _serviceType As String
        Private _changeUserid As String
        Private _changeDate As Date

        Public Property Orgcode() As String
            Get
                Return _orgcode
            End Get
            Set(ByVal value As String)
                _orgcode = value
            End Set
        End Property

        Public Property DepartId() As String
            Get
                Return _departId
            End Get
            Set(ByVal value As String)
                _departId = value
            End Set
        End Property

        Public Property IdCard() As String
            Get
                Return _idCard
            End Get
            Set(ByVal value As String)
                _idCard = value
            End Set
        End Property

        Public Property ServiceSdate() As Date
            Get
                Return _serviceSdate
            End Get
            Set(ByVal value As Date)
                _serviceSdate = value
            End Set
        End Property

        Public Property ServiceEdate() As String
            Get
                Return _serviceEdate
            End Get
            Set(ByVal value As String)
                _serviceEdate = value
            End Set
        End Property

        Public Property ServiceType() As String
            Get
                Return _serviceType
            End Get
            Set(ByVal value As String)
                _serviceType = value
            End Set
        End Property

        Public Property ChangeUserid() As String
            Get
                Return _changeUserid
            End Get
            Set(ByVal value As String)
                _changeUserid = value
            End Set
        End Property

        Public Property ChangeDate() As Date
            Get
                Return _changeDate
            End Get
            Set(ByVal value As Date)
                _changeDate = value
            End Set
        End Property

#End Region

        Public Function GetDataByIdcard(ByVal idCard As String) As DataTable
            Return DAO.GetDataByIdcard(idCard)
        End Function

        Public Function GetDataByServiceType(ByVal idCard As String, ByVal serviceType As String) As DataTable
            Return DAO.GetDataByServiceType(idCard, serviceType)
        End Function

    End Class
End Namespace