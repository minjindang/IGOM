Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web

Namespace FSCPLM.Logic
    Public Class Attachement
        Public DAO As AttachementDAO

        Public Sub New()
            DAO = New AttachementDAO()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            DAO = New AttachementDAO(conn)
        End Sub

#Region "Field"
        Private _Attach_id As String = String.Empty                     ' 1.附件代碼
        Private _Flow_id As String = String.Empty                       ' 2.表單編號 
        Private _File_name As String = String.Empty                     ' 3.檔案名稱 
        Private _File_type As String = String.Empty                     ' 4.檔案型態 
        Private _File_size As String = String.Empty                     ' 5.檔案大小 

        Private _File_path As String = String.Empty                     ' 6.檔案存放路徑 
        Private _File_real_name As String = String.Empty                ' 7.上傳檔案名稱
        Private _Is_visible As String = String.Empty                    ' 8.是否隱藏 
        Private _Upload_userid As String = String.Empty                 ' 9.上傳人員 
        Private _Upload_date As Date = Date.MinValue            ' 10.上傳日期
#End Region

#Region "Property"
        ''' <summary>
        ''' 附件代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Attach_id() As String
            Get
                Return _Attach_id
            End Get
            Set(ByVal value As String)
                _Attach_id = value
            End Set
        End Property
        ''' <summary>
        ''' 表單編號
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property
        ''' <summary>
        ''' 檔案名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property File_name() As String
            Get
                Return _File_name
            End Get
            Set(ByVal value As String)
                _File_name = value
            End Set
        End Property
        ''' <summary>
        ''' 檔案型態
        ''' </summary>
        ''' <remarks></remarks>
        Public Property File_type() As String
            Get
                Return _File_type
            End Get
            Set(ByVal value As String)
                _File_type = value
            End Set
        End Property
        ''' <summary>
        ''' 檔案大小
        ''' </summary>
        ''' <remarks></remarks>
        Public Property File_size() As String
            Get
                Return _File_size
            End Get
            Set(ByVal value As String)
                _File_size = value
            End Set
        End Property

        ''' <summary>
        ''' 檔案存放路徑
        ''' </summary>
        ''' <remarks></remarks>
        Public Property File_path() As String
            Get
                Return _File_path
            End Get
            Set(ByVal value As String)
                _File_path = value
            End Set
        End Property
        ''' <summary>
        ''' 上傳檔案名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property File_real_name() As String
            Get
                Return _File_real_name
            End Get
            Set(ByVal value As String)
                _File_real_name = value
            End Set
        End Property
        ''' <summary>
        ''' 是否隱藏:Y:隱藏;N:不隱藏
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Is_visible() As String
            Get
                Return _Is_visible
            End Get
            Set(ByVal value As String)
                _Is_visible = value
            End Set
        End Property
        ''' <summary>
        ''' 上傳人員
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Upload_userid() As String
            Get
                Return _Upload_userid
            End Get
            Set(ByVal value As String)
                _Upload_userid = value
            End Set
        End Property
        ''' <summary>
        ''' 上傳日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Upload_date() As Date
            Get
                Return _Upload_date
            End Get
            Set(ByVal value As Date)
                _Upload_date = value
            End Set
        End Property
#End Region

        Public Shared Function getAttTip() As String
            Try
                Dim attsize As Integer = CommonFun.getInt(ConfigurationManager.AppSettings("attsize").ToString())
                Dim tip As String = ConfigurationManager.AppSettings("atttip").ToString()

                Dim attkinds() As String = ConfigurationManager.AppSettings("attkind").ToString().Split("|")
                Dim tmp As String = String.Empty
                For Each kind As String In attkinds
                    tmp &= kind & "、"
                Next
                tmp = tmp.TrimEnd("、")

                Return String.Format(tip, attsize / 1024, attsize, tmp)

            Catch ex As Exception
                Return String.Empty
            End Try
        End Function


        ''' <summary>
        ''' 取得附件流水號
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAttachmentNo() As String
            Dim vCodes As String = String.Empty
            Dim GetNo As String = "0"
            Do While GetNo <> ""
                Randomize()
                Dim cAmount, i As Integer
                Dim cCode As String = ""
                cAmount = 10 '文字數量
                cCode = "0123456789"
                ' 隨機產生
                Dim vCode(32)
                For i = 0 To 31
                    vCode(i) = Int(Rnd() * cAmount)
                    vCodes = vCodes & Mid(cCode, vCode(i) + 1, 1)
                Next
                GetNo = DAO.Get_Data(vCodes)
            Loop
            Dim tempNum As String
            tempNum = vCodes

            Return tempNum
        End Function

        Public Function CheckInsertAttach(ByRef fuFile As FileUpload, ByVal Flow_id As String) As String

            Try
                Dim Filepath As String = HttpContext.Current.Server.MapPath("~\fileupload\Attachment\" & Flow_id.Substring(3, 2) & "\")

                If Not fuFile.HasFile Then
                    Return String.Empty
                Else
                    Me.Attach_id = GetAttachmentNo()

                    Dim attsize As Integer = CommonFun.getInt(ConfigurationManager.AppSettings("attsize").ToString())

                    If fuFile.PostedFile.ContentLength > attsize * 1000 Then
                        Return "文件大小不能超過" & attsize & "k!"
                    End If

                    Dim fi As New FileInfo(fuFile.PostedFile.FileName)

                    Dim ismatch As Boolean = False
                    Dim attkinds() As String = ConfigurationManager.AppSettings("attkind").ToString().Split("|")
                    For Each kind As String In attkinds
                        If kind.ToLower() = fi.Extension.ToLower().Replace(".", "") Then
                            ismatch = True
                        End If
                    Next

                    If Not ismatch Then
                        Return "文件格式不符!"
                    End If

                    Dim targetFolder As String = Filepath & Flow_id

                    Dim FileName As String = String.Format("{0}", fuFile.FileName)

                    Me.Flow_id = Flow_id
                    Me.File_path = Filepath & Flow_id
                    Me.File_name = FileName
                    Me.File_size = fuFile.PostedFile.ContentLength.ToString() & "kBytes"
                    Me.File_type = fuFile.PostedFile.ContentType

                    '建立附件目錄
                    If Not My.Computer.FileSystem.DirectoryExists(Filepath & Flow_id) Then
                        My.Computer.FileSystem.CreateDirectory(Filepath & Flow_id)
                    End If

                    fuFile.SaveAs(Path.Combine(targetFolder, String.Format("{0}", FileName)))

                    'If Not InsertAttach(targetFolder, FileName, Flow_id, fuFile.PostedFile.ContentLength.ToString() & "kBytes", fuFile.PostedFile.ContentType, Id_card, Me.Attach_id) Then
                    '    Return "新增附件檔案資料失敗!"
                    'End If
                End If

            Catch ex As Exception
                AppException.WriteErrorLog(ex.StackTrace(), ex.Message())
            End Try
            Return String.Empty
        End Function

        Public Function InsertAttach() As Boolean
            If String.IsNullOrEmpty(Me.Flow_id) Then
                Return True
            End If
            Me.Upload_date = DateTime.Now()
            Return DAO.InsertData(Me) = 1
        End Function


        Public Function GetAttachByFlow_id(ByVal Flow_id As String) As DataTable
            Dim ds As DataSet = DAO.GetDataByFlow_id(Flow_id)
            Return ds.Tables(0)
        End Function

        Public Function InsertAttachNotFid() As Boolean
            'by jessica modi 20131225因為假單附件上傳改可同時上傳三個檔案，但flow_id要在送出表單後才會產生
            Me.Upload_date = DateTime.Now()
            Return DAO.InsertDatabyNotFid(Me) = 1
        End Function

        Public Function UpdateAttach() As Boolean
            If String.IsNullOrEmpty(Me.Flow_id) Then
                Return True
            End If
            Me.Upload_date = DateTime.Now()
            Return DAO.UpdateData(Me) = 1
        End Function
    End Class
End Namespace