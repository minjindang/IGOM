Imports Pemis2009.SQLAdapter
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
'疑問
'1.ID 與 FileName前面的 16位元的ID編碼，是跟哪一種的ID編碼有關?!視 系統功能不同!
'2.上傳附件，可以重複上傳 相同檔名的檔案附件嗎??


Partial Class FileUpload
    Inherits System.Web.UI.UserControl
    Protected FormID As String = String.Empty                                               ' 預新增的 請假單的 ID(New.Guid)
    Protected UploadID As String = String.Empty

    Protected AttachID As String = String.Empty
    Protected FileUploadPath As String = String.Empty
    Protected Enable As Boolean = True
    Private filepath As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FileUploadPath = ConfigurationManager.AppSettings("FileUploadPath").ToString()
        filepath = Server.MapPath(FileUploadPath)
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            'If Enable Then
            '    Dim chkbox As New CheckBox()
            '    chkbox.ID = "chkbox"
            '    e.Row.Cells(0).Controls.Add(chkbox)
            'End If

            Dim strFileNAme As String = CType(e.Row.Cells(0).FindControl("FileName"), HiddenField).Value
            strFileNAme = strFileNAme

            e.Row.Cells(1).Style("cursor") = "hand"
            e.Row.Cells(1).Attributes.Add("onclick", "window.open('" & strFileNAme & "');")

            Try
                e.Row.Cells(3).Text = Convert.ToDateTime(e.Row.Cells(3).Text).ToString("yyyy/MM/dd HH:mm:ss")
            Catch
            End Try

            'Add CSS in even row
            Dim INT As Integer
            Dim i As Integer
            INT = e.Row.RowIndex Mod 2
            Select Case INT
                Case 1
                Case 0
                    For i = 0 To e.Row.Cells.Count - 1
                        e.Row.Cells(i).CssClass = "trcolor"
                    Next
            End Select
        End If


    End Sub

#Region "Property"
    Shared _FlowID As String = ""
    Public Shared Property FlowIDGuid() As String
        Get
            Return _FlowID
        End Get
        Set(ByVal value As String)
            _FlowID = value
        End Set
    End Property
#End Region

#Region "Button Event"
    ''' <summary>
    ''' 上傳
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (FileUpload1.HasFile = True) Then

            If Not (Directory.Exists(filepath)) Then
                Directory.CreateDirectory(filepath)
            End If

            FileUpload1.SaveAs(filepath & String.Format("{0}", FileUpload1.FileName))
            Dim SqlAccess As New SQLAdapter
            With SqlAccess
                .OpenConn()
                Dim FileName As String = String.Format("{0}", FileUpload1.FileName)

                ' 有[顯示欄位]
                AttachID = GetNewAttachID()
                UploadID = "Q220681829"
                Dim file_path = filepath + FileUpload1.FileName
                Dim Str As String = String.Format("insert Attachement (Flow_id, Attach_id, File_name, File_type, File_path, File_real_name, Upload_userid, File_size, Is_visible) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');", _
                    FlowIDGuid, AttachID, FileName, FileUpload1.PostedFile.ContentType, file_path, FileUpload1.FileName, _
                    UploadID, FileUpload1.PostedFile.ContentLength.ToString() + " Bytes", IIf(chkVisible.Checked, 0, 1))
                .ExecNoQueryCmd(Str)
                .CloseConn()
            End With
        End If

        Bind()
    End Sub

    ''' <summary>
    ''' 刪除
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Count As Integer = 0
        Dim strAppName As String = String.Empty
        Dim strDid As String = String.Empty
        Dim strFileName As String = String.Empty

        For Count = 0 To GridView1.Rows.Count - 1 Step 1
            Dim row As GridViewRow = GridView1.Rows(Count)
            Dim blncheck As Boolean = CType(row.FindControl("cbxAttach"), CheckBox).Checked
            If blncheck Then
                strDid = CType(row.FindControl("AttachID"), HiddenField).Value
                strFileName = CType(row.FindControl("FileName"), HiddenField).Value
                deleteData(strDid)
                Dim FileAdrs As String = strFileName
                File.Delete(FileAdrs)
            End If
        Next

        Call Bind()
    End Sub
#End Region

#Region "Method"
    Private Sub deleteData(ByVal AttachID As String)
        Dim strSql As String = String.Empty
        strSql = "delete from Attachement  where Attach_id = '" & AttachID & "'"
        If strSql <> String.Empty Then
            Dim sqlAccess As New SQLAdapter(ConnectDB.GetDBString())
            sqlAccess.OpenConn()
            sqlAccess.ExecNoQueryCmd(strSql)
            sqlAccess.CloseConn()
        End If

    End Sub

    ''' <summary>
    ''' 檔案剛上傳時的 Bind, 用假的 FormID
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Bind()
        Dim SqlAccess As New SQLAdapter
        Dim adapter As New SqlDataAdapter
        With SqlAccess
            .OpenConn()
            Dim Str As String = String.Format("select Attach_id as AttachID, File_path as FileName, File_real_name as FileRealName, File_path as FilePath,  Upload_userid as UploadID, Upload_date as UploadDate from Attachement where Flow_id='{0}' order by Upload_date asc", FlowIDGuid)
            adapter = .GetSQLAdapter(Str)
            Dim Ds As New DataSet
            adapter.Fill(Ds, "Attachement")
            GridView1.DataSource = Ds
            GridView1.DataBind()
            .CloseConn()
        End With
    End Sub

    ''' <summary>
    ''' 含 條件:表單編號
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Bind2()
        Dim SqlAccess As New SQLAdapter
        Dim adapter As New SqlDataAdapter
        With SqlAccess
            .OpenConn()
            Dim Str As String = String.Format("select * from Attachement where  Attach_id='{0}' and Flow_id='{1}' order by Upload_date asc", AttachID, FormID)
            adapter = .GetSQLAdapter(Str)
            Dim Ds As New DataSet
            adapter.Fill(Ds, "Attachement")
            GridView1.DataSource = Ds
            GridView1.DataBind()
            .CloseConn()
        End With
    End Sub

    Private Function GetNewAttachID()
        Dim attachid As String = ""

        Dim SqlAccess As New SQLAdapter
        Dim adapter As New SqlDataAdapter
        With SqlAccess
            .OpenConn()
            Dim Str As String = String.Format("select top 1 Attach_Id from Attachement order by Substring(Attach_id ,4 ,len(Attach_id)) desc")
            adapter = .GetSQLAdapter(Str)
            Dim Ds As New DataSet
            adapter.Fill(Ds, "Attachement_ID")
            If Ds.Tables(0).Rows.Count > 0 Then
                attachid = FileUpload.GetMaxValueAddOne(Ds.Tables(0).Rows(0)(0).ToString(), 7)
            Else
                attachid = "ATH0000001"
            End If
            .CloseConn()
        End With

        Return attachid
    End Function

    ''' <summary>
    ''' 加1後回傳CodeID
    ''' </summary>
    ''' <param name="StrObject"></param>
    ''' <param name="INum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMaxValueAddOne(ByVal StrObject As String, ByVal INum As Integer) As String
        Dim StrMaxValue As String = ""
        StrMaxValue = StrObject.Substring(0, StrObject.Trim().Length - INum) & _
            GetInt32ValueAddOne(StrObject.Substring(StrObject.Trim().Length - INum, INum), INum)
        Return StrMaxValue
    End Function

    ''' <summary>
    ''' 加1後回傳數字
    ''' </summary>
    ''' <param name="StrMaxValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetInt32ValueAddOne(ByVal StrMaxValue As String, ByVal INum As Integer) As String
        Dim SAddOne As String = ""
        Dim SAddZero As String = ""
        SAddOne = (Convert.ToInt32(StrMaxValue) + 1).ToString()
        For i As Integer = 0 To INum - 1 - SAddOne.Length
            SAddZero = "0" & SAddZero
        Next
        SAddOne = SAddZero & SAddOne
        Return SAddOne
    End Function
#End Region
End Class