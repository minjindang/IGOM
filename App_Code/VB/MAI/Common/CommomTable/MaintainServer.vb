Imports Microsoft.VisualBasic
Imports System.Data

Namespace MAI.Logic
    Public Class MaintainServer
        Private DAO As MaintainServerDAO
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
        Private _Cpu_nos As String
        Public Property Cpu_nos() As String
            Get
                Return _Cpu_nos
            End Get
            Set(ByVal value As String)
                _Cpu_nos = value
            End Set
        End Property
        Private _Ram_size As String
        Public Property Ram_size() As String
            Get
                Return _Ram_size
            End Get
            Set(ByVal value As String)
                _Ram_size = value
            End Set
        End Property
        Private _Hd_size As String
        Public Property Hd_size() As String
            Get
                Return _Hd_size
            End Get
            Set(ByVal value As String)
                _Hd_size = value
            End Set
        End Property
        Private _Windows_ver As String
        Public Property Windows_ver() As String
            Get
                Return _Windows_ver
            End Get
            Set(ByVal value As String)
                _Windows_ver = value
            End Set
        End Property
        Private _Other_ver As String
        Public Property Other_ver() As String
            Get
                Return _Other_ver
            End Get
            Set(ByVal value As String)
                _Other_ver = value
            End Set
        End Property
        Private _Intra_flag As String
        Public Property Intra_flag() As String
            Get
                Return _Intra_flag
            End Get
            Set(ByVal value As String)
                _Intra_flag = value
            End Set
        End Property
        Private _Outer_flag As String
        Public Property Outer_flag() As String
            Get
                Return _Outer_flag
            End Get
            Set(ByVal value As String)
                _Outer_flag = value
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
            DAO = New MaintainServerDAO()
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