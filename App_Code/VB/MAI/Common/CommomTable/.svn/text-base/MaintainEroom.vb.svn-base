Imports Microsoft.VisualBasic
Imports System.Data

Namespace MAI.Logic
    Public Class MaintainEroom
        Private DAO As MaintainEroomDAO

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
        Private _Enter_date As String
        Public Property Enter_date() As String
            Get
                Return _Enter_date
            End Get
            Set(ByVal value As String)
                _Enter_date = value
            End Set
        End Property
        Private _Enter_time As String
        Public Property Enter_time() As String
            Get
                Return _Enter_time
            End Get
            Set(ByVal value As String)
                _Enter_time = value
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
        Private _Application_name As String
        Public Property Application_name() As String
            Get
                Return _Application_name
            End Get
            Set(ByVal value As String)
                _Application_name = value
            End Set
        End Property
        Private _Card_type As String
        Public Property Card_type() As String
            Get
                Return _Card_type
            End Get
            Set(ByVal value As String)
                _Card_type = value
            End Set
        End Property
        Private _Card_nos As String
        Public Property Card_nos() As String
            Get
                Return _Card_nos
            End Get
            Set(ByVal value As String)
                _Card_nos = value
            End Set
        End Property
        Private _Desc_flag As String
        Public Property Desc_flag() As String
            Get
                Return _Desc_flag
            End Get
            Set(ByVal value As String)
                _Desc_flag = value
            End Set
        End Property
        Private _Describe As String
        Public Property Describe() As String
            Get
                Return _Describe
            End Get
            Set(ByVal value As String)
                _Describe = value
            End Set
        End Property
        Private _Equipment_desc As String
        Public Property Equipment_desc() As String
            Get
                Return _Equipment_desc
            End Get
            Set(ByVal value As String)
                _Equipment_desc = value
            End Set
        End Property
        Private _Enter_realdate As String
        Public Property Enter_realdate() As String
            Get
                Return _Enter_realdate
            End Get
            Set(ByVal value As String)
                _Enter_realdate = value
            End Set
        End Property
        Private _Enter_realtime As String
        Public Property Enter_realtime() As String
            Get
                Return _Enter_realtime
            End Get
            Set(ByVal value As String)
                _Enter_realtime = value
            End Set
        End Property
        Private _Enter_signidcard As String
        Public Property Enter_signidcard() As String
            Get
                Return _Enter_signidcard
            End Get
            Set(ByVal value As String)
                _Enter_signidcard = value
            End Set
        End Property
        Private _Enter_signname As String
        Public Property Enter_signname() As String
            Get
                Return _Enter_signname
            End Get
            Set(ByVal value As String)
                _Enter_signname = value
            End Set
        End Property
        Private _Left_realdate As String
        Public Property Left_realdate() As String
            Get
                Return _Left_realdate
            End Get
            Set(ByVal value As String)
                _Left_realdate = value
            End Set
        End Property
        Private _Left_realtime As String
        Public Property Left_realtime() As String
            Get
                Return _Left_realtime
            End Get
            Set(ByVal value As String)
                _Left_realtime = value
            End Set
        End Property
        Private _Left_signidcard As String
        Public Property Left_signidcard() As String
            Get
                Return _Left_signidcard
            End Get
            Set(ByVal value As String)
                _Left_signidcard = value
            End Set
        End Property
        Private _Left_signname As String
        Public Property Left_signname() As String
            Get
                Return _Left_signname
            End Get
            Set(ByVal value As String)
                _Left_signname = value
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
            DAO = New MaintainEroomDAO()
        End Sub

        Public Function Insert() As Boolean
            Return DAO.InsertData(Me) > 0
        End Function

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Return DAO.GetDataByMainId(mainId)
        End Function

        Public Function DeleteDataByMainId(mainId As Integer) As Boolean
            Return DAO.DeleteDataByMainId(mainId) > 0
        End Function

    End Class
End Namespace