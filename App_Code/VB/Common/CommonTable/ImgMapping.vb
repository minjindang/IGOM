Imports system.Data

Namespace FSCPLM.Logic
    Public Class ImgMapping
        Public DAO As ImgMappingDAO

        Public Sub New()
            DAO = New ImgMappingDAO
        End Sub

#Region "Field"
        Private _Img_id As Integer = -1                     ' 1.圖示ID
        Private _Func_id As String = String.Empty           ' 2.功能ID
        Private _Img_path As String = String.Empty          ' 3.圖示Path
        Private _Img_file_name As String = String.Empty     ' 4.圖示FileName
        Private _Func_name As String = String.Empty         ' 5.功能Name

        Private _Func_Program_Name As String = String.Empty ' 6.功能的程式代碼名稱
        Private _Level As String = String.Empty             ' 7.功能的程式層級
#End Region

#Region "Property"
        ''' <summary>
        ''' 圖示ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Img_id() As Integer
            Get
                Return _Img_id
            End Get
            Set(ByVal value As Integer)
                _Img_id = value
            End Set
        End Property
        ''' <summary>
        ''' 功能ID
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Func_id() As String
            Get
                Return _Func_id
            End Get
            Set(ByVal value As String)
                _Func_id = value
            End Set
        End Property
        ''' <summary>
        ''' 圖示Path
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Img_path() As String
            Get
                Return _Img_path
            End Get
            Set(ByVal value As String)
                _Img_path = value
            End Set
        End Property
        ''' <summary>
        ''' 圖示FileName
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Img_file_name() As String
            Get
                Return _Img_file_name
            End Get
            Set(ByVal value As String)
                _Img_file_name = value
            End Set
        End Property
        ''' <summary>
        ''' 功能Name
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Func_name() As String
            Get
                Return _Func_name
            End Get
            Set(ByVal value As String)
                _Func_name = value
            End Set
        End Property

        ''' <summary>
        ''' 功能的程式代碼名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Func_Program_Name() As String
            Get
                Return _Func_Program_Name
            End Get
            Set(ByVal value As String)
                _Func_Program_Name = value
            End Set
        End Property
        ''' <summary>
        ''' 功能的程式層級:以資料夾表示
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Level() As String
            Get
                Return _Level
            End Get
            Set(ByVal value As String)
                _Level = value
            End Set
        End Property
#End Region

        Public Function GetImgMappingByQuery(ByVal Func_id As String, ByVal Func_program_name As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByQuery(Func_id, Func_Program_Name)
            Return ds.Tables(0)
        End Function

    End Class
End Namespace