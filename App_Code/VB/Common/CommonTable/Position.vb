Imports Microsoft.VisualBasic

' ################################################
' ################## 層級關係檔 ##################
' ########## Property And BusinessLogic ##########
' ################################################
Namespace FSCPLM.Logic
    Public Class Position
        Public DAO As PositionDAO
        Public Sub New()
            DAO = New PositionDAO()
        End Sub

#Region "Field"
        Private _Posid As Integer = -1                      ' 1.位置碼
        Private _Fid As Integer = -1                        ' 2.直屬長官位置碼
        Private _Pos_name As String = String.Empty          ' 3.位置名稱
        Private _Class_id As Integer = -1                   ' 4.級職等級
        Private _Depart_id As String = String.Empty         ' 5.單位代碼

        Private _Deputy_posid As Integer = -1               ' 6.代理人位置代碼
        Private _ID As String = String.Empty                ' 7.身分證字號
        Private _Prev_id As String = String.Empty           ' 8.前一位身分證字號
        Private _Flow_group As String = String.Empty        ' 9.假單群組
        Private _Orgcode As String = String.Empty           ' 10.機關代碼
#End Region

#Region "Property"
        ''' <summary>
        ''' 位置碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Posid() As Integer
            Get
                Return _Posid
            End Get
            Set(ByVal value As Integer)
                _Posid = value
            End Set
        End Property
        ''' <summary>
        ''' 直屬長官位置碼:FK_Position.Posid
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Fid() As Integer
            Get
                Return _Fid
            End Get
            Set(ByVal value As Integer)
                _Fid = value
            End Set
        End Property
        ''' <summary>
        ''' 位置名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Pos_name() As String
            Get
                Return _Pos_name
            End Get
            Set(ByVal value As String)
                _Pos_name = value
            End Set
        End Property
        ''' <summary>
        ''' 級職等級:預設0
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Class_id() As Integer
            Get
                Return _Class_id
            End Get
            Set(ByVal value As Integer)
                _Class_id = value
            End Set
        End Property
        ''' <summary>
        ''' 單位代碼:FK_FSCorg.Depart_id
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Depart_id() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property

        ''' <summary>
        ''' 代理人位置代碼:FK_Position.Posid
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Deputy_posid() As Integer
            Get
                Return _Deputy_posid
            End Get
            Set(ByVal value As Integer)
                _Deputy_posid = value
            End Set
        End Property
        ''' <summary>
        ''' 身分證字號:FK_Member.ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ID() As String
            Get
                Return _ID
            End Get
            Set(ByVal value As String)
                _ID = value
            End Set
        End Property
        ''' <summary>
        ''' 前一位身分證字號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Prev_id() As String
            Get
                Return _Prev_id
            End Get
            Set(ByVal value As String)
                _Prev_id = value
            End Set
        End Property
        ''' <summary>
        ''' 假單群組:FK_Leave_group.Leave_group_id
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Flow_group() As String
            Get
                Return _Flow_group
            End Get
            Set(ByVal value As String)
                _Flow_group = value
            End Set
        End Property
        ''' <summary>
        ''' 機關代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property
#End Region

#Region "Method"
        Public Function GetNextOutpostType(ByVal OutPostID As String) As String
            Dim NextType As String = ""

            If OutPostID.Contains("直屬主管") Then
                NextType = "Master"
            ElseIf OutPostID.Contains("代理人") Then
                NextType = "Deputy"
            Else
                NextType = "Title"
            End If

            Return NextType
        End Function
#End Region
    End Class
End Namespace