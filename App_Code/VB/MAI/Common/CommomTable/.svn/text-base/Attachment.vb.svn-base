Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data

Namespace MAI.Logic
    Public Class Attachment
        Private DAO As AttachmentDAO
#Region "Property"
        Private _id As String                   ' 1.附件代碼
        Private _Main_id As String
        Private _Flow_id As String              ' 2.表單編號 
        Private _File_name As String            ' 3.檔案名稱 
        Private _File_type As String            ' 4.檔案型態 
        Private _File_size As String            ' 5.檔案大小 

        Private _File_path As String            ' 6.檔案存放路徑 
        Private _File_real_name As String       ' 7.上傳檔案名稱
        Private _Is_visible As String           ' 8.是否隱藏 
        Private _Change_userid As String        ' 9.上傳人員 
        Private _Change_date As Date = Now      ' 10.上傳日期

        Private _Orgcode As String
        Public Property Orgcode() As String
            Get
                Return _Orgcode
            End Get
            Set(ByVal value As String)
                _Orgcode = value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property
        Public Property Main_id() As String
            Get
                Return _Main_id
            End Get
            Set(ByVal value As String)
                _Main_id = value
            End Set
        End Property

        Public Property Flow_id() As String
            Get
                Return _Flow_id
            End Get
            Set(ByVal value As String)
                _Flow_id = value
            End Set
        End Property

        Public Property File_name() As String
            Get
                Return _File_name
            End Get
            Set(ByVal value As String)
                _File_name = value
            End Set
        End Property

        Public Property File_type() As String
            Get
                Return _File_type
            End Get
            Set(ByVal value As String)
                _File_type = value
            End Set
        End Property

        Public Property File_size() As String
            Get
                Return _File_size
            End Get
            Set(ByVal value As String)
                _File_size = value
            End Set
        End Property

        Public Property File_path() As String
            Get
                Return _File_path
            End Get
            Set(ByVal value As String)
                _File_path = value
            End Set
        End Property

        Public Property File_real_name() As String
            Get
                Return _File_real_name
            End Get
            Set(ByVal value As String)
                _File_real_name = value
            End Set
        End Property

        Public Property Is_visible() As String
            Get
                Return _Is_visible
            End Get
            Set(ByVal value As String)
                _Is_visible = value
            End Set
        End Property

        Public Property Change_userid() As String
            Get
                Return _Change_userid
            End Get
            Set(ByVal value As String)
                _Change_userid = value
            End Set
        End Property

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
            DAO = New AttachmentDAO()
        End Sub

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


        Public Function SaveFile(ByRef fuFile As FileUpload) As Integer
            Dim yy As String = (Now.Year - 1911).ToString() 'Flow_id.Substring(3, 2)
            Dim Filepath As String = HttpContext.Current.Server.MapPath("~\fileupload\MAI_Attachment\" & yy & "\" & Flow_id & "\")

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

                Dim targetFolder As String = Filepath '& Flow_id
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

                fuFile.SaveAs(Path.Combine(targetFolder, String.Format("{0}", realName)))

                Return InsertAttach()
            End If

        End Function

        Public Function GetAttachByFlowId(ByVal Flow_id As String) As DataTable
            Return DAO.GetDataByFlowId(Flow_id)
        End Function

        Public Function InsertAttach() As Integer
            Return DAO.Insert(Me)
        End Function

        Public Function UpdateAttach() As Boolean
            Return DAO.Update(Me) = 1
        End Function

        Public Function DeleteAttachById(id As Integer) As Boolean
            Return DAO.DeleteById(id) = 1
        End Function

        Public Function DeleteAttachByFlowId(flowId As String) As Boolean
            Return DAO.DeleteByFlowId(flowId) = 1
        End Function

        Public Function UpdateFlowid() As Integer
            Return DAO.UpdateFlowid(Me) = 1
        End Function

        Public Function getDataByid() As DataTable
            Return DAO.getDataByid(Me)
        End Function

    End Class

End Namespace
