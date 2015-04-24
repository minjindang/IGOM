Imports Microsoft.VisualBasic
Imports System.Data

Namespace MAI.Logic
    Public Class MaintainDns
        Private DAO As MaintainDnsDAO
#Region "Property"
        Private _Id As Integer
        Public Property Id() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal value As Integer)
                _Id = value
            End Set
        End Property
        Private _Main_id As Integer
        Public Property Main_id() As Integer
            Get
                Return _Main_id
            End Get
            Set(ByVal value As Integer)
                _Main_id = value
            End Set
        End Property
        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
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
        Private _Use_sdate As String
        Public Property Use_sdate() As String
            Get
                Return _Use_sdate
            End Get
            Set(ByVal value As String)
                _Use_sdate = value
            End Set
        End Property
        Private _Use_edate As String
        Public Property Use_edate() As String
            Get
                Return _Use_edate
            End Get
            Set(ByVal value As String)
                _Use_edate = value
            End Set
        End Property
        Private _Apply_type As String
        Public Property Apply_type() As String
            Get
                Return _Apply_type
            End Get
            Set(ByVal value As String)
                _Apply_type = value
            End Set
        End Property
        Private _Server_name As String
        Public Property Server_name() As String
            Get
                Return _Server_name
            End Get
            Set(ByVal value As String)
                _Server_name = value
            End Set
        End Property
        Private _Server_ip As String
        Public Property Server_ip() As String
            Get
                Return _Server_ip
            End Get
            Set(ByVal value As String)
                _Server_ip = value
            End Set
        End Property
        Private _Dns_name As String
        Public Property Dns_name() As String
            Get
                Return _Dns_name
            End Get
            Set(ByVal value As String)
                _Dns_name = value
            End Set
        End Property
        Private _Firewall_port As String
        Public Property Firewall_port() As String
            Get
                Return _Firewall_port
            End Get
            Set(ByVal value As String)
                _Firewall_port = value
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
        Private _Change_date As Date = Now
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property
#End Region

        Public Sub New()
            DAO = New MaintainDnsDAO()
        End Sub

        Public Function Insert() As Boolean
            Return DAO.InsertData(Me)
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Return DAO.GetDataByMainId(mainId)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Boolean
            Return DAO.DeleteDataByMainId(mainId) > 0
        End Function
    End Class
End Namespace