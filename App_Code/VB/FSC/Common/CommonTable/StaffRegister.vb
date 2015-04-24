Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic

    Public Class StaffRegister
        Public DAO As StaffRegisterDAO

#Region "property"
        Private _flow_id As String
        Public Property flow_id() As String
            Get
                Return _flow_id
            End Get
            Set(ByVal value As String)
                _flow_id = value
            End Set
        End Property

        Private _Apply_Orgcode As String
        Public Property Apply_Orgcode() As String
            Get
                Return _Apply_Orgcode
            End Get
            Set(ByVal value As String)
                _Apply_Orgcode = value
            End Set
        End Property

        Private _Apply_Depart_id As String
        Public Property Apply_Depart_id() As String
            Get
                Return _Apply_Depart_id
            End Get
            Set(ByVal value As String)
                _Apply_Depart_id = value
            End Set
        End Property

        Private _Apply_Idcard As String
        Public Property Apply_Idcard() As String
            Get
                Return _Apply_Idcard
            End Get
            Set(ByVal value As String)
                _Apply_Idcard = value
            End Set
        End Property

        Private _Apply_Username As String
        Public Property Apply_Username() As String
            Get
                Return _Apply_Username
            End Get
            Set(ByVal value As String)
                _Apply_Username = value
            End Set
        End Property

        Private _Write_Orgcode As String
        Public Property Write_Orgcode() As String
            Get
                Return _Write_Orgcode
            End Get
            Set(ByVal value As String)
                _Write_Orgcode = value
            End Set
        End Property

        Private _Write_Depart_id As String
        Public Property Write_Depart_id() As String
            Get
                Return _Write_Depart_id
            End Get
            Set(ByVal value As String)
                _Write_Depart_id = value
            End Set
        End Property

        Private _Write_Idcard As String
        Public Property Write_Idcard() As String
            Get
                Return _Write_Idcard
            End Get
            Set(ByVal value As String)
                _Write_Idcard = value
            End Set
        End Property

        Private _Write_Username As String
        Public Property Write_Username() As String
            Get
                Return _Write_Username
            End Get
            Set(ByVal value As String)
                _Write_Username = value
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

        Public Sub New()
            DAO = New StaffRegisterDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)
            d.Add("Apply_Orgcode", Apply_Orgcode)
            d.Add("Apply_Depart_id", Apply_Depart_id)
            d.Add("Apply_Idcard", Apply_Idcard)
            d.Add("Apply_Username", Apply_Username)
            d.Add("Write_Orgcode", Write_Orgcode)
            d.Add("Write_Depart_id", Write_Depart_id)
            d.Add("Write_Idcard", Write_Idcard)
            d.Add("Write_Username", Write_Username)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Date.Now)

            Return DAO.InsertByExample("FSC_Staff_register", d)
        End Function

        Public Function getData() As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("Apply_Orgcode", Apply_Orgcode)
            d.Add("Apply_Depart_id", Apply_Depart_id)
            d.Add("Apply_Idcard", Apply_Idcard)

            Return DAO.GetDataByExample("FSC_Staff_register", d)
        End Function
    End Class
End Namespace
