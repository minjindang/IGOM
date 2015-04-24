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
        Private _Attach_id As String = String.Empty                     ' 1.����N�X
        Private _Flow_id As String = String.Empty                       ' 2.���s�� 
        Private _File_name As String = String.Empty                     ' 3.�ɮצW�� 
        Private _File_type As String = String.Empty                     ' 4.�ɮ׫��A 
        Private _File_size As String = String.Empty                     ' 5.�ɮפj�p 

        Private _File_path As String = String.Empty                     ' 6.�ɮצs����| 
        Private _File_real_name As String = String.Empty                ' 7.�W���ɮצW��
        Private _Is_visible As String = String.Empty                    ' 8.�O�_���� 
        Private _Upload_userid As String = String.Empty                 ' 9.�W�ǤH�� 
        Private _Upload_date As Date = Date.MinValue            ' 10.�W�Ǥ��
#End Region

#Region "Property"
        ''' <summary>
        ''' ����N�X
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
        ''' ���s��
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
        ''' �ɮצW��
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
        ''' �ɮ׫��A
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
        ''' �ɮפj�p
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
        ''' �ɮצs����|
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
        ''' �W���ɮצW��
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
        ''' �O�_����:Y:����;N:������
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
        ''' �W�ǤH��
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
        ''' �W�Ǥ��
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
                    tmp &= kind & "�B"
                Next
                tmp = tmp.TrimEnd("�B")

                Return String.Format(tip, attsize / 1024, attsize, tmp)

            Catch ex As Exception
                Return String.Empty
            End Try
        End Function


        ''' <summary>
        ''' ���o����y����
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
                cAmount = 10 '��r�ƶq
                cCode = "0123456789"
                ' �H������
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
                        Return "���j�p����W�L" & attsize & "k!"
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
                        Return "���榡����!"
                    End If

                    Dim targetFolder As String = Filepath & Flow_id

                    Dim FileName As String = String.Format("{0}", fuFile.FileName)

                    Me.Flow_id = Flow_id
                    Me.File_path = Filepath & Flow_id
                    Me.File_name = FileName
                    Me.File_size = fuFile.PostedFile.ContentLength.ToString() & "kBytes"
                    Me.File_type = fuFile.PostedFile.ContentType

                    '�إߪ���ؿ�
                    If Not My.Computer.FileSystem.DirectoryExists(Filepath & Flow_id) Then
                        My.Computer.FileSystem.CreateDirectory(Filepath & Flow_id)
                    End If

                    fuFile.SaveAs(Path.Combine(targetFolder, String.Format("{0}", FileName)))

                    'If Not InsertAttach(targetFolder, FileName, Flow_id, fuFile.PostedFile.ContentLength.ToString() & "kBytes", fuFile.PostedFile.ContentType, Id_card, Me.Attach_id) Then
                    '    Return "�s�W�����ɮ׸�ƥ���!"
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
            'by jessica modi 20131225�]���������W�ǧ�i�P�ɤW�ǤT���ɮסA��flow_id�n�b�e�X����~�|����
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