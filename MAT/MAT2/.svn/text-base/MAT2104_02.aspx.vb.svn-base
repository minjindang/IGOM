Imports System.Data
Imports FSCPLM.Logic
Partial Class MAT2104_02
    Inherits System.Web.UI.Page
    Dim dbA As DataTable
    Dim In_dateS As String = ""
    Dim In_dateE As String = ""
    Dim Material_idS As String = ""
    Dim Material_idE As String = ""
    Dim pagerowcnt As Integer = 0
#Region " 初始化"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (IsPostBack) Then
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("In_dateS"))) Then
                In_dateS = Server.HtmlEncode(Request("In_dateS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("In_dateE"))) Then
                In_dateE = Server.HtmlEncode(Request("In_dateE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Material_idS"))) Then
                Material_idS = Server.HtmlEncode(Request("Material_idS").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("Material_idE"))) Then
                Material_idE = Server.HtmlEncode(Request("Material_idE").ToString())
            End If
            If Not String.IsNullOrEmpty(Server.HtmlEncode(Request("pagerowcnt"))) Then
                pagerowcnt = Integer.Parse(Server.HtmlEncode(Request("pagerowcnt")))
            End If
            PrintBtn_Click(In_dateS, In_dateE, Material_idS, Material_idE, pagerowcnt)
        End If

    End Sub
#End Region
#Region " 列印"
    Protected Sub PrintBtn_Click(ByVal In_dateS As String, ByVal In_dateE As String, ByVal Material_idS As String, ByVal Material_idE As String, ByVal pagerowcnt As Integer)
        Dim db As New DataTable
        Dim mc As MAT2104 = New MAT2104()
        db = mc.MAT2104SelectData(In_dateS, In_dateE, Material_idS, Material_idE)
        Dim theDTReport As CommonLib.DTReport
        Dim strParam(2) As String '宣告字串陣列

        strParam(0) = Server.HtmlEncode(Right("000" & Today.Year - 1911, 3) & "/" & Today.ToString("MM/dd")) '製表日期
        strParam(1) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.User_name)) '製表人
        strParam(2) = Server.HtmlEncode(LoginManager.GetTicketUserData(LoginManager.LoginUserData.Orgcode)) '單位

        theDTReport = New CommonLib.DTReport(Server.MapPath("~/Report/MAT/MAT2104.mht"), db)
        theDTReport.Param = strParam
        theDTReport.ExportFileName = "物品入庫清單"
        theDTReport.ExportToWord()
        db.Dispose()
    End Sub
#End Region
End Class


