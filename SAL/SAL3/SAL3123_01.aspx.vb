Imports System.Data
Imports SALARY.Logic
Imports System.Transactions

Partial Class SAL3123_01
    Inherits BaseWebForm


#Region "Property"
    Protected ReadOnly Property v_orgid() As String
        Get
            Return LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        End Get
    End Property
    Protected ReadOnly Property v_mid() As String
        Get
            Return LoginManager.GetTicketUserData(LoginManager.LoginUserData.Account)
        End Get
    End Property
#End Region

#Region "PageLoad"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then Return
    End Sub
#End Region


#Region " PITM - Button "

    '' 上傳
    Protected Sub Button_pitm_upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button_Family_upload.Click
        get_file()

        Dim FileName As String = Me.FileUpload1.FileName
        Dim FilePath As String = Server.MapPath(app.FilePath)

        Try
            Using fr As System.IO.StreamReader = New System.IO.StreamReader(FilePath & FileName, System.Text.Encoding.GetEncoding("big5"))
                '' 逐行讀取資料

                Dim datastr As String = ""

                While Not fr.EndOfStream
                    datastr = fr.ReadLine
                    Me.ImportFamily(datastr)
                End While

                'pub.Execute(delstr & insStr)
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, FileName & "上傳成功")

            End Using
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ImportFamily(ByVal aStr)
        '' 身分證字號(0), 金額(1)

        Dim v_idno As String = ""
        Dim v_name As String = ""
        Dim v_Familyidno As String = ""
        Dim v_Familyname As String = ""
        Dim v_seqno As String = ""
        Dim v_amt As String = ""
        Dim v_type As String = ""

        Dim DAry() As String = Split(aStr, ",")

        If UBound(DAry) >= 1 Then
            v_type = Trim(DAry(0))
            v_idno = Trim(DAry(1))
            v_Familyidno = Trim(DAry(2))
            v_amt = Trim(DAry(3))
            v_name = Trim(DAry(4))
            v_Familyname = Trim(DAry(5))
        End If
        v_seqno = New SAL3123().getSeqno(v_orgid, v_idno)


        If v_seqno <> "" And IsNumeric(v_amt) Then
            'Dim insStr As String = ""
            Dim bll As New SAL3123
            Select Case v_type
                Case "1"
                    'insStr &= " insert into SAL_safamily(family_orgid, family_seqno, family_id, family_birthday, family_name, "
                    'insStr &= " family_relationship, family_sdate, family_edate, family_self, family_amt,family_agency,family_dct,family_muser,family_mdate,family_nol ) values"
                    'insStr &= " ('" & v_orgid & "','" & v_seqno & "','" & v_idno & "',NULL,'" & v_name & "',NULL,NULL,NULL,NULL,'" & v_amt & "',NULL,NULL,"
                    'insStr &= "'" & v_mid & "','" & DateTime.Now.ToString("yyyyMMddHHmmss") & "',NULL);"

                    Using trans As New TransactionScope
                        bll.delete()
                        bll.insert(v_orgid, v_seqno, v_idno, v_name, v_amt, v_mid)

                        trans.Complete()
                    End Using
                Case Else
                    'insStr &= " insert into SAL_safamily(family_orgid, family_seqno, family_id, family_birthday, family_name, "
                    'insStr &= " family_relationship, family_sdate, family_edate, family_self, family_amt,family_agency,family_dct,family_muser,family_mdate,family_nol ) values"
                    'insStr &= " ('" & v_orgid & "','" & v_seqno & "','" & v_Familyidno & "',NULL,'" & v_Familyname & "',NULL,NULL,NULL,NULL,'" & v_amt & "',NULL,NULL,"
                    'insStr &= "'" & v_mid & "','" & DateTime.Now.ToString("yyyyMMddHHmmss") & "',NULL);"

                    Using trans As New TransactionScope
                        bll.delete()
                        bll.insert(v_orgid, v_seqno, v_Familyidno, v_Familyname, v_amt, v_mid)

                        trans.Complete()
                    End Using
            End Select
        End If
    End Sub
#End Region

#Region " Button - UpLoad"

    Protected Sub get_file()

        Dim FileName As String = ""

        Dim FilePath As String = ""

        Try

            If upload_check() Then

                ''使用原來檔名
                FileName = Me.FileUpload1.FileName

                FilePath = Server.MapPath(app.FilePath) ''( * 實際磁碟路徑 Ex. FilePath == "C:\AppName\..." ; )

                If (Not My.Computer.FileSystem.DirectoryExists(FilePath)) Then
                    My.Computer.FileSystem.CreateDirectory(FilePath) ''( * 如果資料夾不存在則新建該資料夾 ; )
                End If

                Dim fname As String = ""

                Me.FileUpload1.SaveAs(FilePath & FileName) ''存檔
            End If

        Catch ex As Exception
            pub.PrintException(ex)
        End Try


    End Sub

    Protected Function upload_check() As Boolean

        Dim rv As Boolean = True

        '' 是否有檔案
        If Me.FileUpload1.PostedFile IsNot Nothing Then

            Dim len As Integer = Me.v_orgid.Length
            Dim FileName As String = Me.FileUpload1.FileName

            If FileName = "" Then
                rv = False
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇檔案!!")
            End If

            '' 副檔名是否正確(*.CSV) 
            If (IO.Path.GetExtension(Me.FileUpload1.FileName).ToLower <> ".csv") Then
                rv = False
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "副檔名應為.csv")
            End If

            ' '' 檔名格式檢查
            'If Left(FileName, len).ToLower <> Me.TextBox_orgid.Text.ToLower Then
            '    rv = False
            '    Me.MessageBox("檔名格式不正確!")
            'End If

        Else
            rv = False
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "請選擇檔案!!")
        End If


        Return rv

    End Function
#End Region

End Class
