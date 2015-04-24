Imports Microsoft.VisualBasic

' ################################################
' ########## Property And BusinessLogic ##########
' ################################################
Namespace FSC.Logic
    Public Class FSC4103_01
        Public DAO As FSC4103_01DAO
        Public Sub New()
            DAO = New FSC4103_01DAO()
        End Sub

#Region "Field"
        Private _Orgcode As String = String.Empty                   ' 1.诀闽絏
        Private _Unlimited_time As String = String.Empty            ' 2.ぃΩ计
        Private _Year_time As String = String.Empty                 ' 3.–Ω计
        Private _Month_time As String = String.Empty                ' 4.–るΩ计
        Private _Change_userid As String = String.Empty             ' 5.ミ
        Private _Change_date As Date = Date.MinValue        ' 6.钵笆ら戳
        Private _Depart_id As String = String.Empty
#End Region

#Region "Property"
        ''' <summary>
        ''' 诀闽絏
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
        ''' <summary>
        ''' ぃΩ计:0.ぃΩ计;1.ΤΩ计
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Unlimited_time() As String
            Get
                Return _Unlimited_time
            End Get
            Set(ByVal value As String)
                _Unlimited_time = value
            End Set
        End Property
        ''' <summary>
        ''' –Ω计
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Year_time() As String
            Get
                Return _Year_time
            End Get
            Set(ByVal value As String)
                _Year_time = value
            End Set
        End Property
        ''' <summary>
        ''' –るΩ计
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Month_time() As String
            Get
                Return _Month_time
            End Get
            Set(ByVal value As String)
                _Month_time = value
            End Set
        End Property
        ''' <summary>
        ''' ミ
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property
        ''' <summary>
        ''' 钵笆ら戳
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_date() As Date
            Get
                Return _Change_date
            End Get
            Set(ByVal value As Date)
                _Change_date = value
            End Set
        End Property

        Public Property DepartId() As String
            Get
                Return _Depart_id
            End Get
            Set(ByVal value As String)
                _Depart_id = value
            End Set
        End Property
#End Region

#Region "Method"
        Public Function CompareNumberValue(ByVal maxValue As Integer, ByVal minValue As Integer) As String
            Dim Message As String = ""

            If maxValue < minValue Then
                Message = "–るΩ计ぃ–Ω计!"
            End If
            Return Message
        End Function
        Public Function NotZeroNumberValue(ByVal numValue As Integer, ByVal strType As String) As String
            Dim Message As String = ""

            If numValue = 0 Then
                Message = strType + "ぃ0!"
            End If
            Return Message
        End Function
#End Region

    End Class
End Namespace
