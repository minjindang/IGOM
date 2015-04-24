Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Collections.Generic

Namespace MAI.Logic
    Public Class MaintainHandle
        Private DAO As MaintainHandleDAO

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
        Private _Confirm_idcard As String
        Public Property Confirm_idcard() As String
            Get
                Return _Confirm_idcard
            End Get
            Set(ByVal value As String)
                _Confirm_idcard = value
            End Set
        End Property
        Private _Confirm_name As String
        Public Property Confirm_name() As String
            Get
                Return _Confirm_name
            End Get
            Set(ByVal value As String)
                _Confirm_name = value
            End Set
        End Property
        Private _Confirm_ext As String
        Public Property Confirm_ext() As String
            Get
                Return _Confirm_ext
            End Get
            Set(ByVal value As String)
                _Confirm_ext = value
            End Set
        End Property
        Private _Problem_analyze As String
        Public Property Problem_analyze() As String
            Get
                Return _Problem_analyze
            End Get
            Set(ByVal value As String)
                _Problem_analyze = value
            End Set
        End Property
        Private _Predict_date As String
        Public Property Predict_date() As String
            Get
                Return _Predict_date
            End Get
            Set(ByVal value As String)
                _Predict_date = value
            End Set
        End Property
        Private _Handle_idcard As String
        Public Property Handle_idcard() As String
            Get
                Return _Handle_idcard
            End Get
            Set(ByVal value As String)
                _Handle_idcard = value
            End Set
        End Property
        Private _Handle_name As String
        Public Property Handle_name() As String
            Get
                Return _Handle_name
            End Get
            Set(ByVal value As String)
                _Handle_name = value
            End Set
        End Property
        Private _Handle_ext As String
        Public Property Handle_ext() As String
            Get
                Return _Handle_ext
            End Get
            Set(ByVal value As String)
                _Handle_ext = value
            End Set
        End Property
        Private _Operate_type As String
        Public Property Operate_type() As String
            Get
                Return _Operate_type
            End Get
            Set(ByVal value As String)
                _Operate_type = value
            End Set
        End Property
        Private _Service_type As String
        Public Property Service_type() As String
            Get
                Return _Service_type
            End Get
            Set(ByVal value As String)
                _Service_type = value
            End Set
        End Property
        Private _Status_type As String
        Public Property Status_type() As String
            Get
                Return _Status_type
            End Get
            Set(ByVal value As String)
                _Status_type = value
            End Set
        End Property
        Private _Handle_type As String
        Public Property Handle_type() As String
            Get
                Return _Handle_type
            End Get
            Set(ByVal value As String)
                _Handle_type = value
            End Set
        End Property
        Private _Handle_desc As String
        Public Property Handle_desc() As String
            Get
                Return _Handle_desc
            End Get
            Set(ByVal value As String)
                _Handle_desc = value
            End Set
        End Property
        Private _Handle_sdate As String
        Public Property Handle_sdate() As String
            Get
                Return _Handle_sdate
            End Get
            Set(ByVal value As String)
                _Handle_sdate = value
            End Set
        End Property
        Private _Handle_stime As String
        Public Property Handle_stime() As String
            Get
                Return _Handle_stime
            End Get
            Set(ByVal value As String)
                _Handle_stime = value
            End Set
        End Property
        Private _Handle_edate As String
        Public Property Handle_edate() As String
            Get
                Return _Handle_edate
            End Get
            Set(ByVal value As String)
                _Handle_edate = value
            End Set
        End Property
        Private _Handle_etime As String
        Public Property Handle_etime() As String
            Get
                Return _Handle_etime
            End Get
            Set(ByVal value As String)
                _Handle_etime = value
            End Set
        End Property
        Private _Handle_hours As String
        Public Property Handle_hours() As String
            Get
                Return _Handle_hours
            End Get
            Set(ByVal value As String)
                _Handle_hours = value
            End Set
        End Property
        Private _Reply_date As String
        Public Property Reply_date() As String
            Get
                Return _Reply_date
            End Get
            Set(ByVal value As String)
                _Reply_date = value
            End Set
        End Property
        Private _Case_status As String
        Public Property Case_status() As String
            Get
                Return _Case_status
            End Get
            Set(ByVal value As String)
                _Case_status = value
            End Set
        End Property
        Private _Comment As String
        Public Property Comment() As String
            Get
                Return _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property
        Private _Maintain_code As String
        Public Property Maintain_code() As String
            Get
                Return _Maintain_code
            End Get
            Set(ByVal value As String)
                _Maintain_code = value
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
            DAO = New MaintainHandleDAO()
        End Sub

        Public Function GetDataByMainId(mainId As Integer) As DataTable
            Return DAO.GetDataByMainId(mainId)
        End Function

        Public Function Insert() As Boolean
            Return DAO.InsertData(Me) > 0
        End Function

        Public Function Update() As Boolean
            Return DAO.UpdateData(Me) > 0
        End Function

        Public Function GetObject(mainId As Integer) As MaintainHandle
            Dim dt As DataTable = GetDataByMainId(mainId)
            Dim list As List(Of MaintainHandle) = CommonFun.ConvertToList(Of MaintainHandle)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If
            Return Nothing
        End Function

    End Class
End Namespace