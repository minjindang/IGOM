Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Namespace FSC.Logic

    Public Class DutyChange
        Public DAO As DutyChangeDAO

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

        Private _Apply_Date As String
        Public Property Apply_Date() As String
            Get
                Return _Apply_Date
            End Get
            Set(ByVal value As String)
                _Apply_Date = value
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

        Private _Shift_Orgcode As String
        Public Property Shift_Orgcode() As String
            Get
                Return _Shift_Orgcode
            End Get
            Set(ByVal value As String)
                _Shift_Orgcode = value
            End Set
        End Property

        Private _Shift_Depart_id As String
        Public Property Shift_Depart_id() As String
            Get
                Return _Shift_Depart_id
            End Get
            Set(ByVal value As String)
                _Shift_Depart_id = value
            End Set
        End Property

        Private _Shift_Idcard As String
        Public Property Shift_Idcard() As String
            Get
                Return _Shift_Idcard
            End Get
            Set(ByVal value As String)
                _Shift_Idcard = value
            End Set
        End Property

        Private _Shift_Username As String
        Public Property Shift_Username() As String
            Get
                Return _Shift_Username
            End Get
            Set(ByVal value As String)
                _Shift_Username = value
            End Set
        End Property

        Private _Original_Dutydate As String
        Public Property Original_Dutydate() As String
            Get
                Return _Original_Dutydate
            End Get
            Set(ByVal value As String)
                _Original_Dutydate = value
            End Set
        End Property

        Private _Shift_Dutydate As String
        Public Property Shift_Dutydate() As String
            Get
                Return _Shift_Dutydate
            End Get
            Set(ByVal value As String)
                _Shift_Dutydate = value
            End Set
        End Property

        Private _Duty_type As String
        Public Property Duty_type() As String
            Get
                Return _Duty_type
            End Get
            Set(ByVal value As String)
                _Duty_type = value
            End Set
        End Property

        Private _Schedule_id As String
        Public Property Schedule_id() As String
            Get
                Return _Schedule_id
            End Get
            Set(ByVal value As String)
                _Schedule_id = value
            End Set
        End Property

        Private _Shift_Schedule_id As String
        Public Property Shift_Schedule_id() As String
            Get
                Return _Shift_Schedule_id
            End Get
            Set(ByVal value As String)
                _Shift_Schedule_id = value
            End Set
        End Property

        Private _Duty_reason As String
        Public Property Duty_reason() As String
            Get
                Return _Duty_reason
            End Get
            Set(ByVal value As String)
                _Duty_reason = value
            End Set
        End Property

        Private _Duty_Sendtype As String
        Public Property Duty_Sendtype() As String
            Get
                Return _Duty_Sendtype
            End Get
            Set(ByVal value As String)
                _Duty_Sendtype = value
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
            DAO = New DutyChangeDAO()
        End Sub

        Public Function insert() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)
            d.Add("Apply_Orgcode", Apply_Orgcode)
            d.Add("Apply_Depart_id", Apply_Depart_id)
            d.Add("Apply_Idcard", Apply_Idcard)
            d.Add("Apply_Username", Apply_Username)
            d.Add("Apply_Date", Apply_Date)
            d.Add("Write_Orgcode", Write_Orgcode)
            d.Add("Write_Depart_id", Write_Depart_id)
            d.Add("Write_Idcard", Write_Idcard)
            d.Add("Write_Username", Write_Username)
            d.Add("Shift_Orgcode", Shift_Orgcode)
            d.Add("Shift_Depart_id", Shift_Depart_id)
            d.Add("Shift_Idcard", Shift_Idcard)
            d.Add("Shift_Username", Shift_Username)
            d.Add("Original_Dutydate", Original_Dutydate)
            d.Add("Shift_Dutydate", Shift_Dutydate)
            d.Add("Duty_type", Duty_type)
            d.Add("Schedule_id", Schedule_id)
            d.Add("Shift_Schedule_id", Shift_Schedule_id)
            d.Add("Duty_reason", Duty_reason)
            d.Add("Duty_Sendtype", Duty_Sendtype)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Return DAO.InsertByExample("FSC_Duty_change", d)
        End Function

        Public Function update() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)
            d.Add("Apply_Orgcode", Apply_Orgcode)
            d.Add("Apply_Depart_id", Apply_Depart_id)
            d.Add("Apply_Idcard", Apply_Idcard)
            d.Add("Apply_Username", Apply_Username)
            d.Add("Apply_Date", Apply_Date)
            d.Add("Write_Orgcode", Write_Orgcode)
            d.Add("Write_Depart_id", Write_Depart_id)
            d.Add("Write_Idcard", Write_Idcard)
            d.Add("Write_Username", Write_Username)
            d.Add("Shift_Orgcode", Shift_Orgcode)
            d.Add("Shift_Depart_id", Shift_Depart_id)
            d.Add("Shift_Idcard", Shift_Idcard)
            d.Add("Shift_Username", Shift_Username)
            d.Add("Original_Dutydate", Original_Dutydate)
            d.Add("Shift_Dutydate", Shift_Dutydate)
            d.Add("Duty_type", Duty_type)
            d.Add("Schedule_id", Schedule_id)
            d.Add("Shift_Schedule_id", Shift_Schedule_id)
            d.Add("Duty_reason", Duty_reason)
            d.Add("Duty_Sendtype", Duty_Sendtype)
            d.Add("Change_userid", Change_userid)
            d.Add("Change_date", Now)

            Dim cd As New Dictionary(Of String, Object)
            cd.Add("id", id)

            Return DAO.UpdateByExample("FSC_Duty_change", d, cd)
        End Function

        Public Function delete() As Boolean
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.DeleteByExample("FSC_Duty_change", d)
        End Function

        Public Function getData() As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("id", id)
            Return DAO.GetDataByExample("FSC_Duty_change", d)
        End Function

        Public Function getDataByFid() As DataTable
            Dim d As New Dictionary(Of String, Object)
            d.Add("flow_id", flow_id)
            Return DAO.GetDataByExample("FSC_Duty_change", d)
        End Function

        Public Function getNotSendData() As DataTable
            Return DAO.getNotSendData()
        End Function

        Public Function getDataByShift_Dutydate(ByVal Original_Dutydate As String, ByVal Shift_Dutydate As String) As DataTable
            Return DAO.getDataByShift_Dutydate(Original_Dutydate, Shift_Dutydate)
        End Function
    End Class
End Namespace