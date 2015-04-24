Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Configuration
Imports System
Imports System.Web

Namespace SYS.Logic
    Public Class Attachment
        Public DAO As AttachmentDAO

        Public Sub New()
            DAO = New AttachmentDAO()
        End Sub

#Region "Property"
        Private _id As String = String.Empty                     ' 1.附件代碼
        Private _Flow_id As String = String.Empty                       ' 2.表單編號 
        Private _File_name As String = String.Empty                     ' 3.檔案名稱 
        Private _File_type As String = String.Empty                     ' 4.檔案型態 
        Private _File_size As String = String.Empty                     ' 5.檔案大小 

        Private _File_path As String = String.Empty                     ' 6.檔案存放路徑 
        Private _File_real_name As String = String.Empty                ' 7.上傳檔案名稱
        Private _Is_visible As String = String.Empty                    ' 8.是否隱藏 
        Private _Upload_userid As String = String.Empty                 ' 9.上傳人員 
        Private _Upload_date As Date = Date.MinValue            ' 10.上傳日期
        ''' <summary>
        ''' 附件代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
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


        Public Function SaveFile(ByRef fuFile As FileUpload, ByVal Flow_id As String) As Integer
            Dim yy As String = Flow_id.Substring(3, 2)
            Dim Filepath As String = HttpContext.Current.Server.MapPath("~\fileupload\Attachment\" & yy & "\" & Flow_id)

            If Not fuFile.HasFile Then
                Return True
            Else
                Dim attsize As Integer = CommonFun.getInt(ConfigurationManager.AppSettings("attsize").ToString())

                If fuFile.PostedFile.ContentLength > attsize * 1000 Then
                    Throw New FlowException("文件大小不能超過" & attsize & "k!")
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
                    Throw New FlowException("文件格式不符!")
                End If

                Dim FileName As String = String.Format("{0}", fuFile.FileName)
                Dim realName As String = Guid.NewGuid.ToString() + System.IO.Path.GetExtension(fuFile.FileName)

                Me.Flow_id = Flow_id
                Me.File_path = Filepath
                Me.File_name = FileName
                Me.File_size = fuFile.PostedFile.ContentLength.ToString() & "kBytes"
                Me.File_type = fuFile.PostedFile.ContentType
                Me.File_real_name = realName

                '建立附件目錄
                If Not My.Computer.FileSystem.DirectoryExists(Filepath) Then
                    My.Computer.FileSystem.CreateDirectory(Filepath)
                End If

                fuFile.SaveAs(Path.Combine(Filepath, String.Format("{0}", realName)))

                Return InsertAttach()
            End If

        End Function

        Public Function CopyFile(ByVal Flow_id As String, ByVal tmpFolder As String) As Integer
            Dim yy As String = Flow_id.Substring(3, 2)
            Dim tempFilePath As String = HttpContext.Current.Server.MapPath("~\fileupload\Attachment\temp\" & tmpFolder & "\")
            Dim Filepath As String = HttpContext.Current.Server.MapPath("~\fileupload\Attachment\" & yy & "\" & Flow_id & "\")

            Try
                '建立附件目錄
                If Not My.Computer.FileSystem.DirectoryExists(Filepath) Then
                    My.Computer.FileSystem.CreateDirectory(Filepath)
                End If

                Me.Flow_id = Flow_id
                Me.File_path = Filepath

                Dim finfo As FileInfo = New FileInfo(tempFilePath + Me.File_real_name)
                If finfo IsNot Nothing Then
                    finfo.MoveTo(Path.Combine(Filepath, Me.File_real_name))
                End If

                Return UpdateAttach()

            Catch ex As Exception

            End Try

            Return True

        End Function


        Public Function SaveTempFile(ByRef fuFile As FileUpload, ByVal folderName As String) As Integer
            Dim Filepath As String = HttpContext.Current.Server.MapPath("~\fileupload\Attachment\temp\" & folderName & "\")

            If Not fuFile.HasFile Then
                Return True
            Else
                Dim attsize As Integer = CommonFun.getInt(ConfigurationManager.AppSettings("attsize").ToString())

                If fuFile.PostedFile.ContentLength > attsize * 1000 Then
                    Throw New FlowException("文件大小不能超過" & attsize & "k!")
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
                    Throw New FlowException("文件格式不符!")
                End If

                Dim FileName As String = String.Format("{0}", fuFile.FileName)
                Dim realName As String = Guid.NewGuid.ToString() + System.IO.Path.GetExtension(fuFile.FileName)

                Me.File_path = Filepath
                Me.File_name = FileName
                Me.File_size = fuFile.PostedFile.ContentLength.ToString() & "kBytes"
                Me.File_type = fuFile.PostedFile.ContentType
                Me.File_real_name = realName

                '建立附件目錄
                If Not My.Computer.FileSystem.DirectoryExists(Filepath) Then
                    My.Computer.FileSystem.CreateDirectory(Filepath)
                End If

                fuFile.SaveAs(Path.Combine(Filepath, String.Format("{0}", realName)))

                Return InsertAttach()
            End If

        End Function


        Public Function GetObjectById(id As Integer) As Attachment
            Dim dt As DataTable = DAO.GetById(id)
            Dim list As Generic.List(Of Attachment) = CommonFun.ConvertToList(Of Attachment)(dt)
            If list IsNot Nothing AndAlso list.Count > 0 Then
                Return list(0)
            End If
            Return Nothing
        End Function

        Public Function GetAttachByFlowId(ByVal Flow_id As String) As DataTable
            Return DAO.GetDataByFlowId(Flow_id)
        End Function

        Public Function InsertAttach() As Integer
            Me.Upload_date = DateTime.Now()
            Return DAO.Insert(Me)
        End Function

        Public Function UpdateAttach() As Boolean
            Me.Upload_date = DateTime.Now()
            Return DAO.Update(Me) > 0
        End Function

        Public Function DeleteAttachById(id As Integer) As Boolean
            Return DAO.DeleteById(id) > 0
        End Function

        Public Function DeleteAttachByFlowId(flowId As String) As Boolean
            Return DAO.DeleteByFlowId(flowId) = 1
        End Function

        Public Function UpdateFlowid() As Integer
            Return DAO.UpdateFlowid(Me) > 0
        End Function

        Public Function getDataByid() As DataTable
            Return DAO.getDataByid(Me)
        End Function
    End Class
End Namespace