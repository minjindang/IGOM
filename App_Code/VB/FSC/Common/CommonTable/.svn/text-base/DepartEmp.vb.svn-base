Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
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
            Return DAO.GetDataByIdcard("", idCard, "")
        End Function

        Public Function GetDataByIdcard(ByVal orgcode As String, ByVal idCard As String) As DataTable
            Return DAO.GetDataByIdcard(orgcode, idCard, "")
        End Function

        Public Function GetDataByIdcard(ByVal orgcode As String, ByVal idCard As String, ByVal rocDate As String) As DataTable
            Return DAO.GetDataByIdcard(orgcode, idCard, rocDate)
        End Function

        Public Function GetDataByServiceType(ByVal idCard As String, ByVal serviceType As String) As DataTable
            Return DAO.GetDataByServiceType("", idCard, serviceType)
        End Function

        Public Function GetDataByServiceType(ByVal orgcode As String, ByVal idCard As String, ByVal serviceType As String) As DataTable
            Return DAO.GetDataByServiceType(orgcode, idCard, serviceType)
        End Function

        Public Function GetDepartNameWithoutSubDepart(ByVal orgcode As String, ByVal idCard As String, ByVal serviceType As String) As String
            Dim dt As DataTable = GetDataByServiceType(idCard, serviceType)
            Dim org As New FSC.Logic.Org()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return org.GetDepartNameWithoutSubDepart(orgcode, dt.Rows(0)("depart_id").ToString())
            End If
            Return ""
        End Function

        Public Function GetDepartName(ByVal orgcode As String, ByVal idCard As String, ByVal serviceType As String) As String
            Dim dt As DataTable = GetDataByServiceType(idCard, serviceType)
            Dim org As New FSC.Logic.Org()
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Return org.GetDepartName(orgcode, dt.Rows(0)("depart_id").ToString())
            End If
            Return ""
        End Function

        Public Function GetDepartId(ByVal idCard As String) As String
            Dim dt As DataTable = GetDataByIdcard(idCard)
            Dim psn As New Personnel()
            psn = psn.GetObject(idCard)
            Dim serviceType As String = "0"

            If psn.EmployeeType = "9" Then
                serviceType = "1"
            End If

            For Each dr As DataRow In dt.Rows
                If dr("service_type").ToString() = serviceType Then
                    Return dr("depart_id").ToString()
                End If
            Next
            Return ""
        End Function

        Public Function GetDataByDepartId(ByVal orgcode As String, ByVal departId As String) As DataTable
            Return DAO.GetDataByDepartId(orgcode, departId, "")
        End Function


        Public Function GetDataByDepartId(ByVal orgcode As String, ByVal departId As String, ByVal idCard As String) As DataTable
            Return DAO.GetDataByDepartId(orgcode, departId, idCard)
        End Function

        Public Function GetParentDepartByIdCard(ByVal orgcode As String, ByVal idCard As String) As DataTable
            Return DAO.GetParentDepartByIdCard(orgcode, idCard)
        End Function

        Public Function GetDepartByParentDepartId(ByVal orgcode As String, ByVal parentDepartId As String, ByVal idCard As String) As DataTable
            Return DAO.GetDepartByParentDepartId(orgcode, parentDepartId, idCard)
        End Function

        Public Function getServiceDep(ByVal Orgcode As String, ByVal Id_card As String) As String
            Dim Depart_id As String = ""
            Dim Today As String = DateTimeInfo.GetRocTodayString("yyyyMMdd")
            Dim dt As DataTable = DAO.GetDataByIdcard(Orgcode, Id_card, "")
            For Each dr As DataRow In dt.Rows
                If Not String.IsNullOrEmpty(dr("Service_sdate").ToString) AndAlso dr("Service_sdate").ToString > Today Then
                    Continue For
                End If
                If Not String.IsNullOrEmpty(dr("Service_edate").ToString) AndAlso dr("Service_edate").ToString < Today Then
                    Continue For
                End If
                If dr("Service_type").ToString = "1" Then
                    Return dr("Depart_id").ToString
                Else
                    Depart_id = dr("Depart_id").ToString
                End If
            Next

            Return Depart_id
        End Function

        Public Function getServiceDepRow(ByVal Orgcode As String, ByVal Id_card As String) As DataRow
            Dim Today As String = DateTimeInfo.GetRocTodayString("yyyyMMdd")
            Dim dt As DataTable = DAO.GetDataByIdcard(Orgcode, Id_card, "")
            For Each dr As DataRow In dt.Rows
                If Not String.IsNullOrEmpty(dr("Service_sdate").ToString) AndAlso dr("Service_sdate").ToString > Today Then
                    Continue For
                End If
                If Not String.IsNullOrEmpty(dr("Service_edate").ToString) AndAlso dr("Service_edate").ToString < Today Then
                    Continue For
                End If
                If dr("Service_type").ToString = "1" Then
                    Return dr
                End If
            Next

            For Each dr As DataRow In dt.Rows
                If Not String.IsNullOrEmpty(dr("Service_sdate").ToString) AndAlso dr("Service_sdate").ToString > Today Then
                    Continue For
                End If
                If Not String.IsNullOrEmpty(dr("Service_edate").ToString) AndAlso dr("Service_edate").ToString < Today Then
                    Continue For
                End If
                Return dr
            Next

            Return Nothing
        End Function
    End Class
End Namespace