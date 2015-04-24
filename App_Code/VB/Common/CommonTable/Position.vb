Imports Microsoft.VisualBasic

' ################################################
' ################## �h�����Y�� ##################
' ########## Property And BusinessLogic ##########
' ################################################
Namespace FSCPLM.Logic
    Public Class Position
        Public DAO As PositionDAO
        Public Sub New()
            DAO = New PositionDAO()
        End Sub

#Region "Field"
        Private _Posid As Integer = -1                      ' 1.��m�X
        Private _Fid As Integer = -1                        ' 2.���ݪ��x��m�X
        Private _Pos_name As String = String.Empty          ' 3.��m�W��
        Private _Class_id As Integer = -1                   ' 4.��¾����
        Private _Depart_id As String = String.Empty         ' 5.���N�X

        Private _Deputy_posid As Integer = -1               ' 6.�N�z�H��m�N�X
        Private _ID As String = String.Empty                ' 7.�����Ҧr��
        Private _Prev_id As String = String.Empty           ' 8.�e�@�쨭���Ҧr��
        Private _Flow_group As String = String.Empty        ' 9.����s��
        Private _Orgcode As String = String.Empty           ' 10.�����N�X
#End Region

#Region "Property"
        ''' <summary>
        ''' ��m�X
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
        ''' ���ݪ��x��m�X:FK_Position.Posid
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
        ''' ��m�W��
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
        ''' ��¾����:�w�]0
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
        ''' ���N�X:FK_FSCorg.Depart_id
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
        ''' �N�z�H��m�N�X:FK_Position.Posid
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
        ''' �����Ҧr��:FK_Member.ID
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
        ''' �e�@�쨭���Ҧr��
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
        ''' ����s��:FK_Leave_group.Leave_group_id
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
        ''' �����N�X
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

            If OutPostID.Contains("���ݥD��") Then
                NextType = "Master"
            ElseIf OutPostID.Contains("�N�z�H") Then
                NextType = "Deputy"
            Else
                NextType = "Title"
            End If

            Return NextType
        End Function
#End Region
    End Class
End Namespace