Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace FSC.Logic
    Public Class LeaveMainDetail
        Protected DAO As LeaveMainDetailDAO

        Public Sub New()
            DAO = New LeaveMainDetailDAO
        End Sub

#Region "property"
        Private _id As Integer
        Public Property id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property


        Private _Flow_id As String
        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property

        Private _Start_date As String
        Public Property Start_date() As String
            Get
                Return _Start_date
            End Get
            Set(ByVal value As String)
                _Start_date = value
            End Set
        End Property

        Private _End_date As String
        Public Property End_date() As String
            Get
                Return _End_date
            End Get
            Set(ByVal value As String)
                _End_date = value
            End Set
        End Property

        Private _Reason As String
        Public Property Reason() As String
            Get
                Return _Reason
            End Get
            Set(ByVal value As String)
                _Reason = value
            End Set
        End Property

        Private _city As String
        Public Property city() As String
            Get
                Return _city
            End Get
            Set(ByVal value As String)
                _city = value
            End Set
        End Property

        Private _Start_place As String
        Public Property Start_place() As String
            Get
                Return _Start_place
            End Get
            Set(ByVal value As String)
                _Start_place = value
            End Set
        End Property

        Private _End_place As String
        Public Property End_place() As String
            Get
                Return _End_place
            End Get
            Set(ByVal value As String)
                _End_place = value
            End Set
        End Property

        Private _DetailPlace As String
        Public Property DetailPlace() As String
            Get
                Return _DetailPlace
            End Get
            Set(ByVal value As String)
                _DetailPlace = value
            End Set
        End Property

        Private _Transport As String
        Public Property Transport() As String
            Get
                Return _Transport
            End Get
            Set(ByVal value As String)
                _Transport = value
            End Set
        End Property

        Private _Transport_desc As String
        Public Property Transport_desc() As String
            Get
                Return _Transport_desc
            End Get
            Set(ByVal value As String)
                _Transport_desc = value
            End Set
        End Property

        Private _Change_userid As String
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property

#End Region

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)
            d.Add("Start_date", Start_date)
            d.Add("End_date", End_date)
            d.Add("Reason", Reason)
            d.Add("city", city)
            d.Add("Start_place", Start_place)
            d.Add("End_place", End_place)
            d.Add("DetailPlace", DetailPlace)
            d.Add("Transport", Transport)
            d.Add("Transport_desc", Transport_desc)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Leave_main_detail", d)
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)
            d.Add("Start_date", Start_date)
            d.Add("End_date", End_date)
            d.Add("Reason", Reason)
            d.Add("city", city)
            d.Add("Start_place", Start_place)
            d.Add("End_place", End_place)
            d.Add("DetailPlace", DetailPlace)
            d.Add("Transport", Transport)
            d.Add("Transport_desc", Transport_desc)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("FSC_Leave_main_detail", d, cd)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("Flow_id", Flow_id)

            Return DAO.DeleteByExample("FSC_Leave_main_detail", d)
        End Function

        Public Function getDataByFid(ByVal Flow_id As String) As DataTable
            Return DAO.getDataByFid(Flow_id)
        End Function

        Public Function getData(ByVal Flow_id As String, ByVal Officialout_date As String) As DataTable
            Return DAO.getData(Flow_id, Officialout_date)
        End Function
    End Class
End Namespace
