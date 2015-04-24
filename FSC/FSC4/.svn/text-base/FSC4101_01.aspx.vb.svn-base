Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports FSCPLM.Logic

Partial Class FSC4_FSC4101_01
    Inherits BaseWebForm

    Dim szOrgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)
    Dim bll As New FSC.Logic.FSC4101()
    Dim dtData As DataTable

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Return
        End If

        ' 繫結單位名稱
       Depart_Bind()

        ' 繫結科別名稱
        Me.ddlSubDepart_name.Items.Insert(0, New ListItem("請選擇", ""))

        ' 繫結職稱
        Title_Bind()

        ' 繫結姓名
        Me.ddlName.Items.Insert(0, New ListItem("請選擇", ""))

        ' 繫結狀況
        Work_Bind()
    End Sub

    ''' <summary>
    ''' 繫結單位名稱
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Depart_Bind()
        Me.ddlDepart.DataValueField = "Depart_id"
        Me.ddlDepart.DataTextField = "Depart_name"
        Me.ddlDepart.DataSource = bll.GetDepart(szOrgcode, "")
        Me.ddlDepart.DataBind()
        Me.ddlDepart.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 繫結科別名稱
    ''' </summary>
    ''' <param name="DepartID"></param>
    ''' <remarks></remarks>
    Protected Sub SubDepart_Bind(ByVal DepartID As String)
        Me.ddlSubDepart_name.DataValueField = "Depart_id"
        Me.ddlSubDepart_name.DataTextField = "Depart_name"
        Me.ddlSubDepart_name.DataSource = bll.GetDepart(szOrgcode, DepartID)
        Me.ddlSubDepart_name.DataBind()
        Me.ddlSubDepart_name.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 繫結職稱
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Title_Bind()
        Me.ddlTitle.DataValueField = "CODE_NO"
        Me.ddlTitle.DataTextField = "CODE_DESC1"
        Me.ddlTitle.DataSource = bll.GetCODE("023", "012")
        Me.ddlTitle.DataBind()
        Me.ddlTitle.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 繫結姓名
    ''' </summary>
    ''' <param name="DepartID"></param>
    ''' <param name="Title"></param>
    ''' <remarks></remarks>
    Protected Sub Name_Bind(ByVal DepartID As String, ByVal Title As String)
        Me.ddlName.DataValueField = "Id_card"
        Me.ddlName.DataTextField = "User_name"
        Me.ddlName.DataSource = bll.GetUserName(szOrgcode, DepartID, Title)
        Me.ddlName.DataBind()
        Me.ddlName.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    ''' <summary>
    ''' 繫結狀況
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub Work_Bind()
        Me.ddlWork.DataValueField = "CODE_NO"
        Me.ddlWork.DataTextField = "CODE_DESC1"
        Me.ddlWork.DataSource = bll.GetCODE("023", "025")
        Me.ddlWork.DataBind()
        Me.ddlWork.Items.Insert(0, New ListItem("請選擇", ""))
    End Sub

    Protected Sub ddlDepart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlDepart.SelectedIndexChanged
        SubDepart_Bind(Me.ddlDepart.SelectedValue)
        Name_Bind(Me.ddlDepart.SelectedValue, Me.ddlTitle.SelectedValue)
    End Sub

    Protected Sub ddlSubDepart_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlSubDepart_name.SelectedIndexChanged
        Name_Bind(Me.ddlSubDepart_name.SelectedValue, Me.ddlTitle.SelectedValue)
    End Sub

    Protected Sub ddlTitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlTitle.SelectedIndexChanged
        Name_Bind(Me.ddlSubDepart_name.SelectedValue, Me.ddlTitle.SelectedValue)
    End Sub

    Protected Sub cbExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbExport.Click
        bind()
    End Sub

    ''' <summary>
    ''' 查詢資料
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub bind()
        Try
            If Not CommonFun.IsNum(tbYear.Text) Then
                CommonFun.MsgShow(Me, CommonFun.Msg.Custom, "年度要為數字")
                Return
            End If
            Dim orgcode As String = LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)

            dtData = bll.getData(orgcode, ddlDepart.SelectedValue, Me.ddlSubDepart_name.SelectedValue, Me.ddlTitle.SelectedValue, Me.ddlName.SelectedValue, Me.tbYear.Text, Me.ddlWork.SelectedValue, Me.tbID_card.Text)

            If dtData Is Nothing OrElse dtData.Rows.Count <= 0 Then
                CommonFun.MsgShow(Me, CommonFun.Msg.QueryNothing)
                Return
            End If


            doExportTxt(dtData)

        Catch ex As Exception

        End Try
    End Sub

    Protected Function sqlChar(ByVal val As String) As String
        Return """" & val & """"
    End Function

    Protected Sub doExportTxt(ByVal dt As DataTable)
        Dim sb As StringBuilder = New StringBuilder

        If Not dt Is Nothing Then
            For Each dr As DataRow In dt.Rows
                '1.身份證字號:10碼
                '2.姓名:12碼
                '3.員工代碼:10碼
                '4.請假別:2碼
                '5.假別名稱:8碼
                '6.開始日期:6碼 YYMMDD
                '7.結束日期:6碼 YYMMDD
                '8.開始時間:4碼 HHMM
                '9.結束時間:4碼 HHMM
                '10.合計日時數:7碼
                '11.合計日時數是否含假日期:1碼
                '12.出差地點:20碼
                '13.INTRANET KEY:32碼
                Dim idno As String = Convert.ToString(dr("idno"))
                Dim name As String = Convert.ToString(dr("name"))
                Dim card As String = Convert.ToString(dr("card"))
                Dim type As String = Right("00" & Convert.ToString(dr("type")), 2)
                Dim type_name As String = Convert.ToString(dr("type_name"))
                Dim dateb As String = Right(Convert.ToString(dr("dateb")), 7)
                Dim datee As String = Right(Convert.ToString(dr("datee")), 7)
                Dim timeb As String = Left(Convert.ToString(dr("timeb")), 4)
                Dim timee As String = Left(Convert.ToString(dr("timee")), 4)
                Dim place As String = Right(Convert.ToString(dr("place")), 20)
                'Dim holiday As String = Convert.ToString(dr("holiday"))
                Dim dayhours As String = Convert.ToString(dr("dayhours"))

                sb.Append(sqlChar(idno)).Append(",")
                sb.Append(sqlChar(name)).Append(",")
                sb.Append(sqlChar(card)).Append(",")
                sb.Append(sqlChar(type)).Append(",")
                sb.Append(sqlChar(type_name)).Append(",")
                sb.Append(sqlChar(dateb)).Append(",")
                sb.Append(sqlChar(datee)).Append(",")
                sb.Append(sqlChar(timeb)).Append(",")
                sb.Append(sqlChar(dayhours)).Append(",")
                'sb.Append(sqlChar(IIf("1" = holiday, "2", "1"))).Append(",")
                sb.Append(sqlChar(place)).Append(",")
                sb.Append(sqlChar("")).Append("。").AppendLine()
            Next
        End If

        HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("Big5")
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & "FSC4101.txt")
        HttpContext.Current.Response.ClearContent()
        'HttpContext.Current.Response.ContentType = "application/txt"
        HttpContext.Current.Response.ContentType = "Application/octet-stream"
        HttpContext.Current.Response.Write(sb.ToString())
        HttpContext.Current.Response.End()
    End Sub

End Class
