Imports System
Imports System.Data
Imports SYS.Logic
Imports FSCPLM.Logic

Partial Class SYS2106_01
    Inherits BaseWebForm

    Dim dtData As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack() Then
            Return
        End If
        InitControl()
    End Sub


    Protected Sub InitControl()

        UcDate1.Text = DateTimeInfo.GetRocTodayString("yyyyMMdd")
        'UcDate2.Text = DateTimeInfo.GetRocTodayString("yyyyMM") & Date.DaysInMonth(Now.Year, Now.Month).ToString.PadLeft(2, "0")
        'UserName_Bind()
    End Sub


    Protected Sub btnQuery_Click(sender As Object, e As EventArgs)
        Dim message As String = txtMessage.Text
        'Dim Start_date As String = UcDate1.Text
        Dim bll As New SYS2106()
        Dim dt As DataTable
        Dim count1 = 0

        Dim Start_date As Integer = CommonFun.getInt(UcDate1.Text)
        message = "%" + message + "%"

        Dim year As Integer = Left(Start_date, 3) + 1911
        Dim month As Integer = Right(Left(Start_date, 5), 2)
        Dim day As Integer = Right(Start_date, 2)

        Try
            dt = bll.getQueryData(message, year, month, day)
            tbq.Visible = True
            ViewState("dt") = dt
            Me.gvList.DataSource = dt
            Me.gvList.DataBind()
            dt.Dispose()


        Catch ex As Exception
            CommonFun.MsgShow(Me.Page, CommonFun.Msg.SystemError)
            AppException.WriteErrorLog(ex.StackTrace, ex.Message)
        End Try

    End Sub
#Region "頁數改變時"
    Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Me.gvlist.PageIndex = e.NewPageIndex
        Me.gvlist.DataSource = CType(ViewState("dt"), DataTable)
        Me.gvlist.DataBind()
    End Sub
#End Region

End Class
