Imports System.Data
Imports System.Data.SqlClient
Imports System.Transactions
Imports System.IO
Imports System.Text
Imports FSCPLM.Logic
Imports Microsoft.Office.Interop

Partial Class FSC3113_01
    Inherits BaseWebForm

    Const CpaNum As Integer = 1
    Public CardPath As String = ConfigurationManager.AppSettings("CardPath")
    Const LimitDays As String = "14"
    Dim con As SqlConnection
    Dim sw As StreamWriter
    Dim SKEY As String
    Dim User_IdCard As String
    Private DAO As FSC.Logic.ScheduleDAO

    Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If Page.IsPostBack Then Return
        'DD_Create()
    End Sub

    'Protected Sub DD_Create()
    '    Dim Year As String = Now.Year - 2 - 1911
    '    For i As Integer = 0 To 3
    '        DD_Year.Items.Add(Year + i)
    '    Next
    '    For i As Integer = 1 To 12
    '        DD_Month.Items.Add(i.ToString().PadLeft(2, "0"))
    '    Next
    '    DD_Year.SelectedValue = Now.Year - 1911
    '    DD_Month.SelectedValue = Now.Month.ToString().PadLeft(2, "0")
    'End Sub
    Protected Sub cbImport_Click(sender As Object, e As EventArgs) Handles cbImport.Click
        Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
        Dim RtnMsg As String = String.Empty
        Dim UpFileStatus As Boolean = True
        Dim FileName As String = fuFile.PostedFile.FileName
        Dim FileExtension As String = Path.GetExtension(FileName)

        User_IdCard = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Id_card)
        SKEY = (Now.Year - 1911).ToString.PadLeft(3, "0") & Now.ToString("MMddHHmmss")

        'If String.IsNullOrEmpty(DD_Year.SelectedValue) Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "年不可空白，請重新輸入!")
        '    Return
        'End If
        'If String.IsNullOrEmpty(DD_Month.SelectedValue) Then
        '    CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "月不可空白，請重新輸入!")
        '    Return
        'End If

        If Not fuFile.HasFile Then
            'CommonFun.MsgShow(Me, CommonFun.Msg.NotSelectItem)
            'Return
            RtnMsg = CommonFun.Msg.NotSelectItem
            UpFileStatus = False
        End If


        If (FileExtension.ToLower() <> ".txt") And UpFileStatus = True Then
            RtnMsg = "只能上傳文字檔格式"
            UpFileStatus = False
        End If

        If Not UpFileStatus Then
            CommonFun.MsgShow(Me, CommonFun.Msg.Custom, RtnMsg)
            Return
        End If

        Dim lpath As String = Server.MapPath(ConfigurationManager.AppSettings("CardLog").ToString() & _
                                             "\" & DateTimeInfo.GetRocDate(Now).Substring(0, 3))

        Dim d As New DirectoryInfo(lpath)
        If Not d.Exists() Then
            d.Create()
        End If

        'Dim logfname As String = Now.ToString("yyyyMMddHHmmss") & "(" & fuFile.FileName.ToLower().Substring(0, fuFile.FileName.IndexOf("."))
        Try
            Dim logfile As String = Now.ToString("yyyyMMdd") & "_cardtoph_log.txt"

            Dim f As FileInfo = New FileInfo(lpath & "\" & logfile)
            Dim fpath As String = lpath & "\" & fuFile.FileName
            fuFile.PostedFile.SaveAs(fpath)

            sw = New StreamWriter(f.FullName, False, System.Text.Encoding.Default)

            'Dim sd As FSC.Logic.Schedule = New FSC.Logic.Schedule()
            'Dim dt As DataTable = sd.getTmpSchedule()

            con = New SqlConnection(ConnectDB.GetDBString())
            con.Open()

            Run(fpath)

            con.Close()
            con = Nothing

            fuFile.Dispose()
            sw.Flush()
            sw.Close()
            sw.Dispose()

        Catch ex As Exception

            sw.WriteLine(ex.Message)
            sw.WriteLine(ex.ToString)

            sw.Flush()
            sw.Close()
            sw.Dispose()

            CommonFun.MsgShow(Me, CommonFun.Msg.ImportFail)
        End Try
    End Sub

    Sub Run(ByVal file As String)
        Dim sEcnt As Integer = 0
        Dim sScnt As Integer = 0


        Dim fi As New FileInfo(file)

        Dim sr As New StreamReader(fi.FullName)

        While Not sr.EndOfStream
            Dim line As String = sr.ReadLine()

            If IsDouble(line) Then
                sEcnt = sEcnt + 1
                sw.WriteLine("重覆資料：" & line.ToString)
            Else
                sw.WriteLine("新增資料：" & line.ToString)
                InserData(line)
                sScnt = sScnt + 1
            End If

        End While

        CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "匯入完成：成功" & sScnt & "筆,重覆" & sEcnt & "筆")

        'Next


    End Sub
    Sub InserData(ByVal line As String)

        If String.IsNullOrEmpty(line) Then Return

        Try
            '001140417090401002357052646 001140417091201000036111044
            '碼數	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	21	22	23	24	25	26	27
            '資料	K	C	C	Y	Y	M	M	D	D	H	H	M	M	A	A	C	C	C	C	C	C	C	C	C	C	C	C
            'KCC:        卡鐘編號()
            'YYMMDDHHMM: 年月日時分()
            'AA: 01 表上班 ， 02 表下班
            'CCCCCCCCCCCC: 悠遊卡卡號()

            Dim r() As String = line.Replace("""", "").Split(" ")
            Dim KCC As String = r(0).Substring(0, 3) '卡鐘編號
            Dim YYMMDDHHMM As String = r(0).Substring(3, 10)
            Dim PHITYPE As String = IIf(r(0).Substring(13, 2) = "01", "A", IIf(r(0).Substring(13, 2) = "02", "D", ""))
            Dim PHICARD As String = r(0).Substring(15, 12)
            Dim yy As String = (CType("20" & YYMMDDHHMM.Substring(0, 2), Integer) - 1911).ToString()
            Dim yymm As String = yy & YYMMDDHHMM.Substring(2, 2)

            Dim sql As New StringBuilder

            sql.AppendLine("DECLARE @phcard VARCHAR(6)")
            sql.AppendLine("SELECT @phcard=id_card FROM FSC_Personnel WITH(NOLOCK) WHERE Yoyo_card = @YoYocard")
            sql.AppendLine("IF @phcard IS NOT NULL ")
            sql.AppendLine("BEGIN")
            sql.AppendLine("    INSERT INTO FSC_CPAPH" & yymm & " ")
            sql.AppendLine("        (phaddr, phcard, phidate, phitime, phitype, Change_userid, Change_date) ")
            sql.AppendLine("    VALUES ")
            sql.AppendLine("        (@phaddr, @phcard, @phidate, @phitime, @phitype, @phuserid, @phupdate) ")
            sql.AppendLine("END")

            Dim params() As SqlParameter = { _
            New SqlParameter("@phaddr", SqlDbType.VarChar), _
            New SqlParameter("@YoYocard", SqlDbType.VarChar), _
            New SqlParameter("@phidate", SqlDbType.VarChar), _
            New SqlParameter("@phitime", SqlDbType.VarChar), _
            New SqlParameter("@phitype", SqlDbType.VarChar), _
            New SqlParameter("@phuserid", SqlDbType.VarChar), _
            New SqlParameter("@phupdate", SqlDbType.DateTime)}
            params(0).Value = KCC
            params(1).Value = PHICARD
            params(2).Value = YYMMDDHHMM.Substring(2, 4)
            params(3).Value = YYMMDDHHMM.Substring(6, 4)
            params(4).Value = PHITYPE
            params(5).Value = "batch"
            params(6).Value = Now


            Dim cmd As New SqlCommand(sql.ToString, con)
            cmd.Parameters.AddRange(params)
            Dim aff As Integer = cmd.ExecuteNonQuery()

        Catch ex As Exception
            sw.WriteLine(ex.Message)
            'CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
        End Try

    End Sub

    Function IsDouble(ByVal line As String) As Boolean

        Try
            '001140417090401002357052646 001140417091201000036111044
            '碼數	1	2	3	4	5	6	7	8	9	10	11	12	13	14	15	16	17	18	19	20	21	22	23	24	25	26	27
            '資料	K	C	C	Y	Y	M	M	D	D	H	H	M	M	A	A	C	C	C	C	C	C	C	C	C	C	C	C
            'KCC:        卡鐘編號()
            'YYMMDDHHMM: 年月日時分()
            'AA: 01 表上班 ， 02 表下班
            'CCCCCCCCCCCC: 悠遊卡卡號()

            Dim r() As String = line.Replace("""", "").Split(" ")
            Dim KCC As String = r(0).Substring(0, 3) '卡鐘編號
            Dim YYMMDDHHMM As String = r(0).Substring(3, 10)
            Dim PHITYPE As String = IIf(r(0).Substring(13, 2) = "01", "A", IIf(r(0).Substring(13, 2) = "02", "D", ""))
            Dim PHICARD As String = r(0).Substring(15, 12)
            Dim yy As String = (CType("20" & YYMMDDHHMM.Substring(0, 2), Integer) - 1911).ToString()
            Dim yymm As String = yy & YYMMDDHHMM.Substring(2, 2)

            Dim sql As New StringBuilder

            sql.AppendLine("DECLARE @phcard VARCHAR(6)")
            sql.AppendLine("SELECT @phcard=id_card FROM FSC_Personnel WITH(NOLOCK) WHERE Yoyo_card = @YoYocard")
            sql.AppendLine(" select count(*) from FSC_CPAPH" & yymm & " with(nolock) ")
            sql.AppendLine(" where phcard=@phcard and phidate=@phidate and phitime=@phitime ")

            Dim params() As SqlParameter = { _
            New SqlParameter("@YoYocard", SqlDbType.VarChar), _
            New SqlParameter("@phidate", SqlDbType.VarChar), _
            New SqlParameter("@phitime", SqlDbType.VarChar)}

            params(0).Value = PHICARD
            params(1).Value = YYMMDDHHMM.Substring(2, 4)
            params(2).Value = YYMMDDHHMM.Substring(6, 4)


            Dim cmd As New SqlCommand(sql.ToString, con)
            cmd.Parameters.AddRange(params)


            If Integer.Parse(cmd.ExecuteScalar.ToString) > 0 Then
                Return True
            End If


        Catch ex As Exception
            sw.WriteLine(ex.Message)
            'CommonFun.MsgShow(Me, CommonFun.Msg.SystemError)
            Return True
        End Try

        Return False
    End Function

End Class
