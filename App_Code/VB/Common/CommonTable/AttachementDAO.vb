Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports Pemis2009.SQLAdapter

Namespace FSCPLM.Logic
    Public Class AttachementDAO

        Dim Connection As SqlConnection
        Dim ConnectionString As String = String.Empty

        Public Sub New()
            ConnectionString = ConnectDB.GetDBString()
        End Sub

        Public Sub New(ByVal conn As SqlConnection)
            Me.Connection = conn
        End Sub

#Region "Field"
        Private _Congratulate_id As Integer = -1                            ' 1.祝賀語標題代碼
        Private _Congratulate_name As String = String.Empty                 ' 2.祝賀語標題名稱
        Private _Congratulate_content As String = String.Empty              ' 3.祝賀語內容
        Private _Orgcode As String = String.Empty                           ' 4.機關代碼
        Private _Change_userid As String = String.Empty                     ' 5.異動人員

        Private _Change_date As DateTime = DateTime.MinValue                ' 6.異動日期
#End Region

#Region "Property"
        ''' <summary>
        ''' 祝賀語標題代碼
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Congratulate_id() As Integer
            Get
                Return _Congratulate_id
            End Get
            Set(ByVal value As Integer)
                _Congratulate_id = value
            End Set
        End Property
        ''' <summary>
        ''' 祝賀語標題名稱
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Congratulate_name() As String
            Get
                Return _Congratulate_name
            End Get
            Set(ByVal value As String)
                _Congratulate_name = value
            End Set
        End Property
        ''' <summary>
        ''' 祝賀語內容
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Congratulate_content() As String
            Get
                Return _Congratulate_content
            End Get
            Set(ByVal value As String)
                _Congratulate_content = value
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
        ''' <summary>
        ''' 異動人員
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
        ''' 異動日期
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Change_date() As DateTime
            Get
                Return _Change_date
            End Get
            Set(ByVal value As DateTime)
                _Change_date = value
            End Set
        End Property
#End Region

        ''' <summary>
        ''' 從資料庫取得單筆資料
        ''' </summary>
        ''' <param name="vCodes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function Get_Data(ByVal vCodes As String) As String
            Dim ds As DataSet
            Dim i, num As Integer
            Dim WorkStr As String = String.Empty

            Dim sql As String = "select Attach_id from Attachement where Attach_id='" & vCodes & "'"

            If Me.Connection IsNot Nothing Then
                ds = SqlAccessHelper.ExecuteDataset(Me.Connection, CommandType.Text, sql)
            Else
                ds = SqlAccessHelper.ExecuteDataset(Me.ConnectionString, CommandType.Text, sql)
            End If

            If (ds.Tables(0).Rows.Count = 0) Then
                Return Nothing
            Else
                num = ds.Tables(0).Columns.Count
                For i = 0 To num - 1
                    WorkStr += ds.Tables(0).Rows(0)(i).ToString()
                    If i <> num - 1 Then WorkStr += ","
                Next
            End If

            Return WorkStr
        End Function


        Public Function GetDataByFlow_id(ByVal Flow_id As String) As DataSet
            Dim StrSQL As String = String.Empty
            StrSQL = "SELECT * FROM Attachement WHERE Flow_id=@Flow_id"
            Dim param As SqlParameter = New SqlParameter("@Flow_id", SqlDbType.VarChar)
            param.Value = Flow_id
            Return SqlAccessHelper.ExecuteDataset(ConnectionString, CommandType.Text, StrSQL, param)
        End Function

        ''' <summary>
        ''' 記錄到附件檔
        ''' </summary>
        ''' <param name="att"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertData(ByVal att As Attachement) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = "INSERT INTO SYS_Attachement (Flow_id ,File_name ,File_type,File_size ,File_path,File_real_name ,Change_userid ,Change_date) VALUES "
            StrSQL += "('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')"

            StrSQL = String.Format(StrSQL, att.Attach_id, att.Flow_id, att.File_name, att.File_type, _
                att.File_size, att.File_path, att.File_real_name, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account), _
                Convert.ToDateTime(att.Upload_date.ToString()).ToString("yyyy/MM/dd HH:mm:ss"))

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Me.Connection, CommandType.Text, StrSQL)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL)

        End Function

        ''' <summary>
        ''' 記錄到附件檔
        ''' </summary>
        ''' <param name="att"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertDatabyNotFid(ByVal att As Attachement) As Integer

            Dim StrSQL As String = String.Empty
            StrSQL = "insert into Attachement(Attach_id  ,File_name ,File_type ,File_size ,File_path  "
            StrSQL = StrSQL & " ,File_real_name  ,Change_userid ,Change_date) values "
            StrSQL = StrSQL & "('{0}','{1}','{2}','{3}','{4}','{5}'"
            StrSQL = StrSQL & ",'{6}','{7}')"

            StrSQL = String.Format(StrSQL, att.Attach_id, att.File_name, att.File_type, _
                att.File_size, att.File_path, att.File_real_name, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account), _
                Convert.ToDateTime(att.Upload_date.ToString()).ToString("yyyy/MM/dd HH:mm:ss"))

            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Me.Connection, CommandType.Text, StrSQL)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL)

        End Function
        ''' <summary>

        ''' </summary>
        ''' <param name="att"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateData(ByVal att As Attachement) As Integer
            Dim StrSQL As String = String.Empty
            StrSQL = "UPDATE Attachement SET Flow_id='{0}',Change_userid='{1}' ,Change_date= '{2}' WHERE Attach_id ='{3}' "
            StrSQL = String.Format(StrSQL, att.Flow_id, LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account), _
                Convert.ToDateTime(att.Upload_date.ToString()).ToString("yyyy/MM/dd HH:mm:ss"), att.Attach_id)
            If Me.Connection IsNot Nothing Then
                Return SqlAccessHelper.ExecuteNonQuery(Me.Connection, CommandType.Text, StrSQL)
            End If
            Return SqlAccessHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, StrSQL)
        End Function
    End Class
End Namespace